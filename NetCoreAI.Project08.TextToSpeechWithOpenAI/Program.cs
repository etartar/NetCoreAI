using Microsoft.Extensions.Configuration;
using System.Net.Http.Headers;
using System.Text.Json;

var configuration = new ConfigurationBuilder()
    .AddUserSecrets<Program>()
    .Build();

var apiKey = configuration["OpenAI:ApiKey"] ??
    throw new InvalidOperationException("API Key bulunamadı. Lütfen 'dotnet user-secrets set \"OpenAI:ApiKey\" \"YOUR_API_KEY\"' komutunu çalıştırın.");


Console.Write("Metni Giriniz: ");

string? inputText = Console.ReadLine();

if (string.IsNullOrWhiteSpace(inputText))
{
    Console.WriteLine("Lütfen geçerli bir metin girin.");
}

Console.WriteLine("Ses dosyası oluşturuluyor...");

await GenerateSpeechAsync(inputText!, apiKey);

Console.WriteLine("Ses dosyası 'output.mp3' olarak kaydedildi.");

System.Diagnostics.Process.Start("explorer.exe", "output.mp3");

async Task GenerateSpeechAsync(string text, string apiKey)
{
    using var httpClient = new HttpClient();
    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);

    var requestBody = new
    {
        model = "tts-1",
        input = inputText,
        voice = "alloy" // allow, echo, fable, onyx, nova, shimmer
    };

    var request = JsonSerializer.Serialize(requestBody);
    var content = new StringContent(request, System.Text.Encoding.UTF8, "application/json");

    try
    {
        var response = await httpClient.PostAsync("https://api.openai.com/v1/audio/speech", content);
        if (response.IsSuccessStatusCode)
        {
            byte[] audioBytes = await response.Content.ReadAsByteArrayAsync();

            await File.WriteAllBytesAsync("output.mp3", audioBytes);
        }
        else
        {
            Console.WriteLine("Bir hata oluştu.");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Hata oluştu: {ex.Message}");
    }
}