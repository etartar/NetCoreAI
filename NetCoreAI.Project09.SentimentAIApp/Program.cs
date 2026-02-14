using Microsoft.Extensions.Configuration;
using System.Net.Http.Headers;
using System.Text.Json;

var configuration = new ConfigurationBuilder()
    .AddUserSecrets<Program>()
    .Build();

var apiKey = configuration["OpenAI:ApiKey"] ??
    throw new InvalidOperationException("API Key bulunamadı. Lütfen 'dotnet user-secrets set \"OpenAI:ApiKey\" \"YOUR_API_KEY\"' komutunu çalıştırın.");

Console.Write("Lütfen Metni Giriniz: ");

string? input = Console.ReadLine();

if (string.IsNullOrWhiteSpace(input))
{
    Console.WriteLine("Geçerli bir metin giriniz.");
    return;
}

Console.WriteLine();
Console.WriteLine("Duygu Analizi Yapılıyor...");

string sentiment = await SentimentAnalyzeAsync(input, apiKey);

Console.WriteLine($"Duygu Analizi Sonucu: {sentiment}");

async Task<string> SentimentAnalyzeAsync(string input, string apiKey)
{
    using var httpClient = new HttpClient();
    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);

    var requestBody = new
    {
        model = "gpt-3.5-turbo",
        messages = new[]
        {
            new { role = "system", content = "You are an AI that analyzes sentiment. You categorize text as Positive, Negative or Neutral." }, // Sen bir duygu analizi uzmanısın. Verilen metnin olumlu, olumsuz veya nötr olduğunu belirle.
            new { role = "user", content = $"Analyze the sentiment of this text: {input} and return only Positive, Negative or Neutral" }
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
            var sentimentResult = result.GetProperty("choices")[0].GetProperty("message").GetProperty("content").GetString();
            return sentimentResult ?? "Sonuç alınamadı.";
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