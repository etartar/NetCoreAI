using Microsoft.Extensions.Configuration;
using System.Net.Http.Headers;

var configuration = new ConfigurationBuilder()
    .AddUserSecrets<Program>()
    .Build();

var apiKey = configuration["OpenAI:ApiKey"] ?? 
    throw new InvalidOperationException("API Key bulunamadı. Lütfen 'dotnet user-secrets set \"OpenAI:ApiKey\" \"YOUR_API_KEY\"' komutunu çalıştırın.");

Console.Write("Lütfen çevirmek istediğiniz cümleyi giriniz: ");
string? inputText = Console.ReadLine();

if (string.IsNullOrWhiteSpace(inputText))
{
    Console.WriteLine("Çevirmek istediğiniz cümleyi girmelisiniz.");
    return;
}

string translatedText = await TranslateTextToEnglishAsync(inputText, apiKey);

Console.WriteLine(translatedText);

async Task<string> TranslateTextToEnglishAsync(string text, string apiKey)
{
    using var httpClient = new HttpClient();
    
    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);

    var requestBody = new
    {
        model = "gpt-3.5-turbo",
        messages = new[]
        {
            new { role = "system", content = "You are a helpful translator." },
            new { role = "user", content = $"Please translate this text to English: {text}" }
        }
    };

    var request = System.Text.Json.JsonSerializer.Serialize(requestBody);

    var content = new StringContent(request, System.Text.Encoding.UTF8, "application/json");

    try
    {
        var response = await httpClient.PostAsync("https://api.openai.com/v1/chat/completions", content);
        var responseContent = await response.Content.ReadAsStringAsync();
        if (response.IsSuccessStatusCode)
        {
            var result = System.Text.Json.JsonSerializer.Deserialize<System.Text.Json.JsonElement>(responseContent);
            var translatedText = result.GetProperty("choices")[0].GetProperty("message").GetProperty("content").GetString();
            return $"Translated Text: {translatedText}";
        }
        else
        {
            return $"Error: {response.StatusCode}\n{responseContent}";
        }
    }
    catch (Exception ex)
    {
        return $"Error: {ex.Message}";
    }
}