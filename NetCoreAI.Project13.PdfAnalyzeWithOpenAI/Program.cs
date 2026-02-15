using Microsoft.Extensions.Configuration;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using UglyToad.PdfPig;

var configuration = new ConfigurationBuilder()
    .AddUserSecrets<Program>()
    .Build();

var apiKey = configuration["OpenAI:ApiKey"] ??
    throw new InvalidOperationException("API Key bulunamadı. Lütfen 'dotnet user-secrets set \"OpenAI:ApiKey\" \"YOUR_API_KEY\"' komutunu çalıştırın.");

Console.Write("PDF Dosya Yolunu Giriniz: ");

string? pdfPath = Console.ReadLine();

if (string.IsNullOrWhiteSpace(pdfPath))
{
    Console.WriteLine("Geçerli bir pdf yolu giriniz.");
    return;
}

string pdfText = await ExtractTextFromPdf(pdfPath);

await AnalyzeWithAI(pdfText, "Pdf İçeriği");

async Task<string> ExtractTextFromPdf(string path)
{
    StringBuilder textBuilder = new StringBuilder();
    using PdfDocument pdf = PdfDocument.Open(path);

    foreach (var page in pdf.GetPages())
    {
        textBuilder.AppendLine(page.Text);
    }

    return textBuilder.ToString();
}

async Task AnalyzeWithAI(string text, string sourceType)
{
    using var httpClient = new HttpClient();
    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);

    var requestBody = new
    {
        model = "gpt-3.5-turbo",
        messages = new[]
        {
            new { role = "system", content = "Sen bir yapay zeka asistanısın. Kullanıcının gönderdiği metni analiz eder ve Türkçe olarak özetlersin. Yanıtlarını sadece Türkçe ver!" },
            new { role = "user", content = $"Analyze and summarize the following {sourceType}:\n\n{text}" }
        }
    };

    var request = JsonSerializer.Serialize(requestBody);
    var content = new StringContent(request, System.Text.Encoding.UTF8, "application/json");

    try
    {
        var response = await httpClient.PostAsync("https://api.openai.com/v1/chat/completions", content);
        var responseContent = await response.Content.ReadAsStringAsync();
        if (response.IsSuccessStatusCode)
        {
            var result = JsonSerializer.Deserialize<JsonElement>(responseContent);
            var summarizeResult = result.GetProperty("choices")[0].GetProperty("message").GetProperty("content").GetString();

            Console.WriteLine($"\n AI Analizi ({sourceType}): \n {summarizeResult}");
        }
        else
        {
            Console.WriteLine($"API isteği başarısız oldu. Durum Kodu: {response.StatusCode}. {responseContent}");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Hata: {ex.Message}");
    }
}