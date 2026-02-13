using System.Text.Json;
using Microsoft.Extensions.Configuration;

var configuration = new ConfigurationBuilder()
    .AddUserSecrets<Program>()
    .Build();

var apiKey = configuration["OpenAI:ApiKey"] ?? throw new InvalidOperationException("API Key bulunamadı. Lütfen 'dotnet user-secrets set \"OpenAI:ApiKey\" \"YOUR_API_KEY\"' komutunu çalıştırın.");

Console.WriteLine("Lütfen sorunuzu yazınız: ");

var prompt = Console.ReadLine();

using var httpClient = new HttpClient();

httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");

var requestBody = new
{
    model = "gpt-3.5-turbo",
    messages = new[]
    {
        new { role = "system", content = "You are a helpful assistant." },
        new { role = "user", content = prompt! },
    },
    max_tokens = 500
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

        var answer = result.GetProperty("choices")[0].GetProperty("message").GetProperty("content").GetString();

        Console.WriteLine($"AI: {answer}");
    }
    else
    {
        Console.WriteLine($"Error: {response.StatusCode}");
        Console.WriteLine(responseContent);
    }
}
catch (Exception ex)
{
    Console.WriteLine($"An error occurred: {ex.Message}");
}

Console.ReadKey();