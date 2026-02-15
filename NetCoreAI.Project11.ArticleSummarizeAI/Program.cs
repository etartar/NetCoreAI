using Microsoft.Extensions.Configuration;
using System.Net.Http.Headers;
using System.Text.Json;

var configuration = new ConfigurationBuilder()
    .AddUserSecrets<Program>()
    .Build();

var apiKey = configuration["OpenAI:ApiKey"] ??
    throw new InvalidOperationException("API Key bulunamadı. Lütfen 'dotnet user-secrets set \"OpenAI:ApiKey\" \"YOUR_API_KEY\"' komutunu çalıştırın.");

Console.Write("Uzun metninizi veya makalenizi giriniz: ");

string? inputText = Console.ReadLine();

if (string.IsNullOrWhiteSpace(inputText))
{
    Console.WriteLine("Geçerli bir metin giriniz.");
    return;
}

Console.WriteLine();
Console.WriteLine("Girmiş olduğunuz metin AI tarafından özetleniyor...");
Console.WriteLine();

string shortSummary = await SummarizeTextAsync(inputText, apiKey, "short");
string mediumSummary = await SummarizeTextAsync(inputText, apiKey, "medium");
string detailedSummary = await SummarizeTextAsync(inputText, apiKey, "detailed");

Console.WriteLine("Özetler");
Console.WriteLine("---------------------");
Console.WriteLine(" **Kısa Özet: ** ");
Console.WriteLine(shortSummary);
Console.WriteLine("---------------------");
Console.WriteLine(" **Orta Özet: ** ");
Console.WriteLine(mediumSummary);
Console.WriteLine("---------------------");
Console.WriteLine(" **Detaylı Özet: ** ");
Console.WriteLine(detailedSummary);

async Task<string> SummarizeTextAsync(string text, string apiKey, string level)
{
    using var httpClient = new HttpClient();
    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);

    string instruction = level switch
    {
        "short" => "Summarize the following text in 1-2 sentences.",
        "medium" => "Summarize the following text in 3-5 sentences.",
        "detailed" => "Summarize the following text in a detailed concise manner, covering all key points.",
        _ => "Summarize the following text."
    };

    var requestBody = new
    {
        model = "gpt-3.5-turbo",
        messages = new[]
        {
            new { role = "system", content = "You are an AI that summarize text info different levels: short, medium and detailed" },
            new { role = "user", content = $"{instruction}\n\n{inputText}" }
        }
    };

    var request = JsonSerializer.Serialize(requestBody);
    var content = new StringContent(request, System.Text.Encoding.UTF8, "application/json");

    try
    {
        var response = await httpClient.PostAsync("https://api.openai.com/v1/chat/completions", content);
        if (response.IsSuccessStatusCode)
        {
            var responseContent = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<JsonElement>(responseContent);
            var summarizeResult = result.GetProperty("choices")[0].GetProperty("message").GetProperty("content").GetString();
            return summarizeResult ?? "Sonuç alınamadı.";
        }
        else
        {
            return "Bir hata oluştu.";
        }
    }
    catch (Exception ex)
    {
        return $"Hata: {ex.Message}";
    }
}

Console.ReadLine();