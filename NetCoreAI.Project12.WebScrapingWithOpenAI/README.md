# 🌐 NetCoreAI.Project12 - Web Scraping with OpenAI

HtmlAgilityPack ve OpenAI GPT-3.5-turbo API kullanarak web sayfalarından içerik çekme ve analiz etme .NET 10 konsol uygulaması.

## 📋 Özellikler

- ✅ HtmlAgilityPack ile web scraping
- ✅ OpenAI GPT ile içerik analizi ve özetleme
- ✅ Türkçe çıktı desteği
- ✅ User Secrets ile güvenli API key yönetimi
- ✅ Otomatik HTML temizleme

## 🛠️ Gereksinimler

- .NET 10 SDK
- OpenAI API Key ([OpenAI Platform](https://platform.openai.com/api-keys) üzerinden alabilirsiniz)
- İnternet bağlantısı

## 📦 Kullanılan Paketler

```xml
<PackageReference Include="HtmlAgilityPack" Version="1.12.4" />
<PackageReference Include="Microsoft.Extensions.Configuration.UserSecrets" Version="10.0.3" />
```

## 🚀 Kurulum

### 1. Projeyi klonlayın veya indirin

```bash
git clone https://github.com/etartar/NetCoreAI
cd NetCoreAI/NetCoreAI.Project12.WebScrapingWithOpenAI
```

### 2. API Key'i kaydedin

```bash
dotnet user-secrets set "OpenAI:ApiKey" "YOUR_OPENAI_API_KEY"
```

> **Not:** API key'inizi [OpenAI Platform](https://platform.openai.com/api-keys) adresinden oluşturabilirsiniz.

### 3. Bağımlılıkları yükleyin

```bash
dotnet restore
```

### 4. Uygulamayı çalıştırın

```bash
dotnet run
```

## 💡 Kullanım

Uygulama çalıştığında analiz etmek istediğiniz web sitesinin URL'sini girin:

```
Lüften analiz yapmak istediğiniz web sitesinin URL'sini giriniz: https://example.com

Web sayfası içeriği: 

 AI Analizi (Web Sayfası İçeriği): 
Bu web sitesi [içerik özeti]... [AI tarafından Türkçe özet]
```

### Örnek Kullanımlar:

**Haber Sitesi Analizi:**
```
Input:  https://www.bbc.com/turkce
Output: Web sitesi Türkiye ve dünyadan güncel haberleri içermektedir...
```

**Blog Analizi:**
```
Input:  https://medium.com/@username/article
Output: Bu blog yazısı [konu] hakkında detaylı bilgi vermektedir...
```

**Ürün Sayfası Analizi:**
```
Input:  https://www.example.com/product/123
Output: Bu ürün sayfası [ürün adı] için fiyat ve özellik bilgilerini içerir...
```

## 🎯 Kullanım Alanları

### İçerik Analizi
- Rakip analizi
- İçerik benchmark
- SEO analizi
- Trend takibi

### Haber ve Medya
- Haber özetleme
- Trend analizi
- Konu sınıflandırma
- Kaynak doğrulama

### E-Ticaret
- Ürün bilgisi toplama
- Fiyat karşılaştırma
- Ürün özellikleri çıkarma
- Müşteri yorumları analizi

### Akademik Araştırma
- Veri toplama
- İçerik analizi
- Bilgi çıkarma
- Literatür tarama

## 🔧 Yapılandırma

### Farklı HTML Elementleri Çekme

Sadece belirli elementleri almak için:

```csharp
// Sadece başlıkları al
var headers = doc.DocumentNode.SelectNodes("//h1 | //h2 | //h3");

// Sadece paragrafları al
var paragraphs = doc.DocumentNode.SelectNodes("//p");

// Belirli bir div içeriğini al
var content = doc.DocumentNode.SelectSingleNode("//div[@class='content']");
```

### Farklı Analiz Türleri

Sistem mesajını değiştirerek farklı analizler yapabilirsiniz:

```csharp
// Özet için
new { role = "system", content = "Metni kısa ve öz şekilde özetle." }

// Anahtar kelimeler için
new { role = "system", content = "Bu metindeki en önemli 5 anahtar kelimeyi çıkar." }

// Duygu analizi için
new { role = "system", content = "Bu metnin genel tonunu ve duygusunu analiz et." }

// Kategori belirleme için
new { role = "system", content = "Bu metni en uygun kategoriye atama yap (Teknoloji, Spor, Ekonomi, vb.)." }
```

### Çoklu Sayfa Analizi

Birden fazla URL'yi analiz etmek için:

```csharp
string[] urls = 
{
    "https://example.com/page1",
    "https://example.com/page2",
    "https://example.com/page3"
};

foreach (var url in urls)
{
    string content = await GetWebPageContentAsync(url);
    await AnalyzeWithAI(content, $"Sayfa: {url}");
}
```

## 🚀 Gelişmiş Özellikler

### Link Çıkarma

Sayfadaki tüm linkleri çıkarmak için:

```csharp
var links = doc.DocumentNode.SelectNodes("//a[@href]");
foreach (var link in links)
{
    string url = link.GetAttributeValue("href", "");
    string text = link.InnerText;
    Console.WriteLine($"{text}: {url}");
}
```

### Görsel URL'lerini Alma

Sayfadaki tüm görselleri almak için:

```csharp
var images = doc.DocumentNode.SelectNodes("//img[@src]");
foreach (var img in images)
{
    string src = img.GetAttributeValue("src", "");
    string alt = img.GetAttributeValue("alt", "");
    Console.WriteLine($"{alt}: {src}");
}
```

### Tablo Verilerini Çıkarma

HTML tablolarından veri çekmek için:

```csharp
var tables = doc.DocumentNode.SelectNodes("//table");
foreach (var table in tables)
{
    var rows = table.SelectNodes(".//tr");
    foreach (var row in rows)
    {
        var cells = row.SelectNodes(".//td | .//th");
        if (cells != null)
        {
            var cellValues = cells.Select(c => c.InnerText).ToList();
            Console.WriteLine(string.Join(" | ", cellValues));
        }
    }
}
```

### Meta Bilgilerini Alma

Sayfa meta verilerini çıkarmak için:

```csharp
var title = doc.DocumentNode.SelectSingleNode("//title")?.InnerText;
var description = doc.DocumentNode.SelectSingleNode("//meta[@name='description']")?.GetAttributeValue("content", "");
var keywords = doc.DocumentNode.SelectSingleNode("//meta[@name='keywords']")?.GetAttributeValue("content", "");

Console.WriteLine($"Başlık: {title}");
Console.WriteLine($"Açıklama: {description}");
Console.WriteLine($"Anahtar Kelimeler: {keywords}");
```

## 📊 Performans İpuçları

### HTML Temizleme

Gereksiz whitespace'leri temizlemek için:

```csharp
string cleanText = System.Text.RegularExpressions.Regex.Replace(bodyText, @"\s+", " ").Trim();
```

### Token Limitine Dikkat

Uzun içerikleri parçalayın:

```csharp
const int maxChars = 10000;
if (webContent.Length > maxChars)
{
    webContent = webContent.Substring(0, maxChars) + "...";
}
```

### Retry Mekanizması

Web sitesine bağlanırken hata durumunda yeniden deneme:

```csharp
int retryCount = 3;
for (int i = 0; i < retryCount; i++)
{
    try
    {
        var doc = await web.LoadFromWebAsync(url);
        return doc;
    }
    catch (Exception ex)
    {
        if (i == retryCount - 1) throw;
        await Task.Delay(1000 * (i + 1)); // Exponential backoff
    }
}
```

## 🔒 Güvenlik ve Etik

### Robots.txt Kontrolü

Web scraping yaparken her zaman robots.txt dosyasını kontrol edin:

```csharp
var robotsUrl = new Uri(new Uri(url), "/robots.txt").ToString();
// robots.txt kontrol et
```

### User-Agent Ayarlama

Saygılı bir bot olun:

```csharp
var web = new HtmlWeb();
web.UserAgent = "Mozilla/5.0 (compatible; MyBot/1.0; +https://mywebsite.com/bot)";
```

### Rate Limiting

Sunucuyu yormamak için istekler arasında bekleme:

```csharp
await Task.Delay(2000); // 2 saniye bekle
```

### Yasal Uyarı

⚠️ **ÖNEMLİ**: 
- Web scraping yaparken sitenin kullanım şartlarını okuyun
- robots.txt dosyasına uyun
- Telif haklarına saygı gösterin
- Kişisel verileri koruyun (GDPR/KVKK)
- Sunucuyu aşırı yüklemeyin

## 📝 API Limitleri ve Fiyatlandırma

- **GPT-3.5-turbo**: ~$0.0005 / 1K token (input), ~$0.0015 / 1K token (output)
- Ortalama bir sayfa analizi: ~2000-3000 token
- 100 sayfa analizi maliyeti: ~$0.75 - $1.50

## 🐛 Hata Ayıklama

### "İçerik bulunamadı" hatası:

```csharp
// Alternatif selektörler deneyin
var bodyText = doc.DocumentNode.SelectSingleNode("//body")?.InnerText 
    ?? doc.DocumentNode.SelectSingleNode("//main")?.InnerText
    ?? doc.DocumentNode.InnerText;
```

### JavaScript ile yüklenen içerik:

HtmlAgilityPack JavaScript'i çalıştırmaz. Selenium veya Puppeteer kullanın:

```bash
dotnet add package Selenium.WebDriver
dotnet add package Selenium.WebDriver.ChromeDriver
```

### HTTP Hataları:

```csharp
try
{
    var doc = await web.LoadFromWebAsync(url);
}
catch (WebException ex)
{
    Console.WriteLine($"Web hatası: {ex.Message}");
    // 404, 403, vb. hataları yönet
}
```

## 📚 İlgili Kaynaklar

- [HtmlAgilityPack Documentation](https://html-agility-pack.net/)
- [XPath Syntax](https://www.w3schools.com/xml/xpath_syntax.asp)
- [Web Scraping Best Practices](https://www.scrapehero.com/web-scraping-best-practices/)
- [Robots.txt Guide](https://developers.google.com/search/docs/crawling-indexing/robots/intro)

## 👨‍💻 Geliştirici

**Emir TARTAR**
- GitHub: [@etartar](https://github.com/etartar)

## 📄 Lisans

Bu proje eğitim amaçlıdır.
