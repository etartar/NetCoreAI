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
Console.WriteLine("Gelişmiş Duygu Analizi Yapılıyor...");

string sentiment = await AdvancedSentimentAnalyzeAsync(input, apiKey);

Console.WriteLine($"Gelişmiş Duygu Analizi Sonucu: {sentiment}");

async Task<string> AdvancedSentimentAnalyzeAsync(string input, string apiKey)
{
    using var httpClient = new HttpClient();
    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);

    var requestBody = new
    {
        model = "gpt-3.5-turbo",
        messages = new[]
        {
            new { role = "system", content = "You are an advanced AI that analyzes emotions in text. Your response must be in JSON format. Identify the sentiment scores (0-100%) for the following emotions: Joy, Sadness, Anger, Fear, Surprise and Neutral." }, 
            new { role = "user", content = $"Analyze the sentiment of this text: {input} and return a JSON object with percentages for each emotions." }
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