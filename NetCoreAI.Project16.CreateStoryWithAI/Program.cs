using Microsoft.Extensions.Configuration;
using System.Net.Http.Headers;
using System.Text.Json;

var configuration = new ConfigurationBuilder()
    .AddUserSecrets<Program>()
    .Build();

var apiKey = configuration["OpenAI:ApiKey"] ??
    throw new InvalidOperationException("API Key bulunamadı. Lütfen 'dotnet user-secrets set \"OpenAI:ApiKey\" \"YOUR_API_KEY\"' komutunu çalıştırın.");

Console.Write("Hikaye türünü seçiniz (Macera, Korku, Bilim Kurgu, Fantastik, Komedi): ");

string? genre = Console.ReadLine();

if (string.IsNullOrWhiteSpace(genre))
{
    Console.WriteLine("Geçerli bir hikaye türü seçiniz.");
    return;
}

Console.Write("Ana karakteriniz kim: ");

string? character = Console.ReadLine();

if (string.IsNullOrWhiteSpace(character))
{
    Console.WriteLine("Geçerli bir ana karakter giriniz.");
    return;
}

Console.Write("Hikaye nerede geçiyor: ");

string? setting = Console.ReadLine();

if (string.IsNullOrWhiteSpace(setting))
{
    Console.WriteLine("Geçerli bir hikayenin nerede geçtiğini giriniz.");
    return;
}

Console.Write("Hikayenin uzunluğu (kısa/orta/uzun): ");

string? length = Console.ReadLine();

if (string.IsNullOrWhiteSpace(setting))
{
    Console.WriteLine("Geçerli bir hikaye uzunluğu giriniz.");
    return;
}

string prompt = $"{genre} türünde bir hikaye yaz. Baş karakterin adı {character}. Hikaye {setting} bölgesinde geçiyor. {length} bir hikaye olsun. Giriş, gelişme ve sonuç içermeli.";

string story = await GenerateStoryAsync(prompt);

Console.WriteLine();
Console.WriteLine("--- AI tarafından oluşturulan hikaye ---");
Console.WriteLine(story);

async Task<string> GenerateStoryAsync(string prompt)
{
    using var httpClient = new HttpClient();
    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);

    var requestBody = new
    {
        //model = "gpt-3.5-turbo",
        model = "gpt-4-turbo",
        messages = new[]
        {
            new { role = "system", content = "You are a creative story writer." },
            new { role = "user", content = prompt }
        },
        max_tokens = 1000
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
