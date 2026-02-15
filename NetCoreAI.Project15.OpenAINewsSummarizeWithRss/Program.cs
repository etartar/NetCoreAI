using Microsoft.Extensions.Configuration;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Xml.Linq;

var configuration = new ConfigurationBuilder()
    .AddUserSecrets<Program>()
    .Build();

var apiKey = configuration["OpenAI:ApiKey"] ??
    throw new InvalidOperationException("API Key bulunamadı. Lütfen 'dotnet user-secrets set \"OpenAI:ApiKey\" \"YOUR_API_KEY\"' komutunu çalıştırın.");

Console.Write("Haber sitesi RSS Feed Url Adresini giriniz: ");

// https://www.sozcu.com.tr/rss/tum-haberler.xml
// https://bigpara.hurriyet.com.tr/rss/
string? rssFeedUrl = Console.ReadLine();

if (string.IsNullOrWhiteSpace(rssFeedUrl))
{
    Console.WriteLine("Geçerli bir rss feed url adresini giriniz.");
    return;
}

Console.WriteLine("Haberler sistemden alınıyor...");
Console.WriteLine();

List<string> articles = await FetchLastestNewsAsync(10);

Console.WriteLine("Haber özetleri oluşturuluyor...");
Console.WriteLine("---------------------");

foreach (var article in articles)
{
    string summary = await SummarizeArticleAsync(article);
    Console.WriteLine("------ AI tarafından özetlenen haber ------");
    Console.WriteLine(summary);
    Console.WriteLine("--------------------------------------------\n");
}

async Task<List<string>> FetchLastestNewsAsync(int count)
{
    List<string> articles = new List<string>(1);

    try
    {
        using var httpClient = new HttpClient();
        var response = await httpClient.GetStringAsync(rssFeedUrl);

        XDocument doc = XDocument.Parse(response);
        var items = doc.Descendants("item").Take(count);

        foreach (var item in items)
        {
            string title = item.Element("title")?.Value ?? "";
            string description = item.Element("description")?.Value ?? "";

            articles.Add($"{title}. {description}");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"RSS beslemesi alınırken hata oluştu: {ex.Message}");
    }

    return articles;
}

async Task<string> SummarizeArticleAsync(string articleText)
{

    using var httpClient = new HttpClient();
    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);

    var requestBody = new
    {
        //model = "gpt-3.5-turbo",
        model = "gpt-4-turbo",
        messages = new[]
        {
            new { role = "system", content = "You are an expert news summarizer." },
            new { role = "user", content = $"Bu haberi 3 cümlede özetle: {articleText}" }
        },
        max_tokens = 500
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
