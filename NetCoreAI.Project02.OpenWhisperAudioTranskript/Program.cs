using System.Net.Http.Headers;
using Microsoft.Extensions.Configuration;

var configuration = new ConfigurationBuilder()
    .AddUserSecrets<Program>()
    .Build();

var apiKey = configuration["OpenAI:ApiKey"] ?? throw new InvalidOperationException("API Key bulunamadı. Lütfen 'dotnet user-secrets set \"OpenAI:ApiKey\" \"YOUR_API_KEY\"' komutunu çalıştırın.");

string audioFilePath = "audio1.mp3";

using var httpClient = new HttpClient();

httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);

using var multipartContent = new MultipartFormDataContent();

var fileContent = new ByteArrayContent(System.IO.File.ReadAllBytes(audioFilePath));

fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse("audio/mpeg");

multipartContent.Add(fileContent, "file", System.IO.Path.GetFileName(audioFilePath));
multipartContent.Add(new StringContent("whisper-1"), "model");

Console.WriteLine("Ses Dosyası İşleniyor, Lütfen Bekleyiniz...");

try
{
    var response = await httpClient.PostAsync("https://api.openai.com/v1/audio/transcriptions", multipartContent);
    var responseContent = await response.Content.ReadAsStringAsync();
    
    if (response.IsSuccessStatusCode)
    {
        Console.WriteLine($"Transcription: ");
        Console.WriteLine(responseContent);
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