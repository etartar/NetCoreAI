using HtmlAgilityPack;
using Microsoft.Extensions.Configuration;
using System.Net.Http.Headers;
using System.Text.Json;

var configuration = new ConfigurationBuilder()
    .AddUserSecrets<Program>()
    .Build();

var apiKey = configuration["OpenAI:ApiKey"] ??
    throw new InvalidOperationException("API Key bulunamadı. Lütfen 'dotnet user-secrets set \"OpenAI:ApiKey\" \"YOUR_API_KEY\"' komutunu çalıştırın.");

Console.Write("Lüften analiz yapmak istediğiniz web sitesinin URL'sini giriniz: ");

string? inputUrl = Console.ReadLine();

if (string.IsNullOrWhiteSpace(inputUrl))
{
    Console.WriteLine("Geçerli bir url giriniz.");
    return;
}

Console.WriteLine();
Console.WriteLine("Web sayfası içeriği: ");

string webContent = await GetWebPageContentAsync(inputUrl);

await AnalyzeWithAI(webContent, "Web Sayfası İçeriği");

async Task<string> GetWebPageContentAsync(string url)
{
    var web = new HtmlWeb();
    var doc = await web.LoadFromWebAsync(url);

    var bodyText = doc.DocumentNode.SelectSingleNode("//body")?.InnerText;

    return bodyText ?? "İçerik bulunamadı.";
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