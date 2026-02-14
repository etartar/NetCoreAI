using Microsoft.Extensions.Configuration;
using System.Net.Http.Headers;
using System.Text.Json;

var configuration = new ConfigurationBuilder()
    .AddUserSecrets<Program>()
    .Build();

var apiKey = configuration["OpenAI:ApiKey"] ?? throw new InvalidOperationException("API Key bulunamadı. Lütfen 'dotnet user-secrets set \"OpenAI:ApiKey\" \"YOUR_API_KEY\"' komutunu çalıştırın.");

Console.WriteLine("Example prompts: ");

string prompt = Console.ReadLine();

using var httpClient = new HttpClient();

httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);


var requestBody = new
{
    prompt = prompt,
    n = 1,
    size = "1024x1024"
};

var request = JsonSerializer.Serialize(requestBody);

var content = new StringContent(request, System.Text.Encoding.UTF8, "application/json");

try
{
    var response = await httpClient.PostAsync("https://api.openai.com/v1/images/generations", content);
    var responseContent = await response.Content.ReadAsStringAsync();
    if (response.IsSuccessStatusCode)
    {
        var result = JsonSerializer.Deserialize<JsonElement>(responseContent);
        var imageUrl = result.GetProperty("data")[0].GetProperty("url").GetString();
        Console.WriteLine($"Generated Image URL: {imageUrl}");
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