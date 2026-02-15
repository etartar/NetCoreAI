using Microsoft.Extensions.Configuration;
using System.Text;
using System.Text.Json;

var configuration = new ConfigurationBuilder()
    .AddUserSecrets<Program>()
    .Build();

var googleApiKey = configuration["GoogleVisionApi:ApiKey"] ??
    throw new InvalidOperationException("API Key bulunamadı. Lütfen 'dotnet user-secrets set \"GoogleVisionApi:ApiKey\" \"YOUR_API_KEY\"' komutunu çalıştırın.");

Console.Write("Resim yolunu giriniz: ");
var imagePath = Console.ReadLine();
Console.WriteLine();

Console.WriteLine("Google Vision Api ile Görsel Nesne Tespiti Yapılıyor...");

string response = await DetectObjects(imagePath!);

Console.WriteLine("Tespit Edilen Nesneler:");
Console.WriteLine(response);

async Task<string> DetectObjects(string path)
{
    using var client = new HttpClient();
    string apiUrl = $"https://vision.googleapis.com/v1/images:annotate?key={googleApiKey}";

    byte[] imageBytes = await File.ReadAllBytesAsync(path);
    string base64Image = Convert.ToBase64String(imageBytes);

    var requestBody = new
    {
        requests = new[]
        {
            new
            {
                image = new { content = base64Image },
                features = new[] { new { type = "LABEL_DETECTION", maxResults = 10 } }
            }
        }
    };

    var jsonRequest = JsonSerializer.Serialize(requestBody);
    var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

    var response = await client.PostAsync(apiUrl, content);
    string responseContent = await response.Content.ReadAsStringAsync();

    return responseContent;
}
