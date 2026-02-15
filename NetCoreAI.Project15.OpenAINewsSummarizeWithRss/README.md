# 📰 NetCoreAI.Project15 - RSS News Summarizer with OpenAI

RSS feed'lerinden haber çekerek OpenAI GPT-4-turbo ile özetleyen .NET 10 konsol uygulaması.

## 📋 Özellikler

- ✅ RSS feed parsing
- ✅ OpenAI GPT-4-turbo ile haber özetleme
- ✅ Çoklu haber işleme (varsayılan 10 haber)
- ✅ Türkçe özet desteği
- ✅ XML parsing ile RSS okuma
- ✅ User Secrets ile güvenli API key yönetimi

## 🛠️ Gereksinimler

- .NET 10 SDK
- OpenAI API Key ([OpenAI Platform](https://platform.openai.com/api-keys) üzerinden alabilirsiniz)
- İnternet bağlantısı

## 📦 Kullanılan Paketler

```xml
<PackageReference Include="Microsoft.Extensions.Configuration.UserSecrets" Version="10.0.3" />
```

## 🚀 Kurulum

### 1. Projeyi klonlayın veya indirin

```bash
git clone https://github.com/etartar/NetCoreAI
cd NetCoreAI/NetCoreAI.Project15.OpenAINewsSummarizeWithRss
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

Uygulama çalıştığında RSS feed URL'sini girin:

```
Haber sitesi RSS Feed Url Adresini giriniz: https://www.sozcu.com.tr/rss/tum-haberler.xml

Haberler sistemden alınıyor...

Haber özetleri oluşturuluyor...
---------------------
------ AI tarafından özetlenen haber ------
Ekonomide yeni gelişmeler yaşanıyor. Merkez Bankası faiz kararını açıkladı. 
Piyasalar olumlu tepki verdi.
--------------------------------------------

------ AI tarafından özetlenen haber ------
Teknoloji sektöründe yeni bir yapay zeka modeli tanıtıldı. 
Model, önceki versiyonlardan çok daha güçlü yeteneklere sahip...
--------------------------------------------
```

### Popüler RSS Feed Örnekleri:

**Türkçe Haber Siteleri:**
```
https://www.sozcu.com.tr/rss/tum-haberler.xml
https://bigpara.hurriyet.com.tr/rss/
https://www.ntv.com.tr/gundem.rss
https://www.milliyet.com.tr/rss/rssnew/gundemrss.xml
https://www.bbc.com/turkce/index.xml
```

**Teknoloji:**
```
https://techcrunch.com/feed/
https://www.theverge.com/rss/index.xml
https://feeds.arstechnica.com/arstechnica/index
https://www.wired.com/feed/rss
```

**Ekonomi:**
```
https://www.reuters.com/rssFeed/businessNews
https://www.bloomberg.com/feed/podcast/all
```

**Bilim:**
```
https://www.sciencedaily.com/rss/all.xml
https://www.nature.com/nature.rss
```

## 🎯 Kullanım Alanları

### Medya Takibi
- Günlük haber özetleri
- Sektör haberleri takibi
- Rakip analizi
- Trend belirleme

### İçerik Küratörlüğü
- Newsletter hazırlama
- Blog içeriği oluşturma
- Sosyal medya paylaşımları
- Haber bülteni

### Araştırma
- Gündem analizi
- Konu araştırması
- Veri toplama
- İstatistiksel analiz

### Kurumsal
- Pazarlama analizi
- PR takibi
- Marka izleme
- Kriz yönetimi

## 🔧 Yapılandırma

### Haber Sayısını Değiştirme

`FetchLastestNewsAsync` metodunda count parametresini değiştirin:

```csharp
List<string> articles = await FetchLastestNewsAsync(20); // 20 haber al
```

### GPT-3.5-turbo Kullanma

Daha ekonomik çözüm için GPT-4 yerine GPT-3.5-turbo kullanabilirsiniz:

```csharp
var requestBody = new
{
    model = "gpt-3.5-turbo", // GPT-4-turbo yerine
    messages = new[]
    {
        new { role = "system", content = "You are an expert news summarizer." },
        new { role = "user", content = $"Bu haberi 3 cümlede özetle: {articleText}" }
    },
    max_tokens = 200 // Daha kısa özetler
};
```

### Farklı Özet Uzunlukları

Özet uzunluğunu değiştirmek için prompt'u güncelleyin:

```csharp
// Çok kısa (1 cümle)
new { role = "user", content = $"Bu haberi 1 cümlede özetle: {articleText}" }

// Orta (3 cümle) - Varsayılan
new { role = "user", content = $"Bu haberi 3 cümlede özetle: {articleText}" }

// Detaylı (5 cümle)
new { role = "user", content = $"Bu haberi 5 cümlede özetle: {articleText}" }

// Madde madde
new { role = "user", content = $"Bu haberin ana noktalarını 3 madde halinde özetle: {articleText}" }
```

## 🚀 Gelişmiş Özellikler

### Çoklu RSS Feed

Birden fazla kaynaktan haber toplamak için:

```csharp
string[] rssFeeds = 
{
    "https://www.sozcu.com.tr/rss/tum-haberler.xml",
    "https://www.ntv.com.tr/gundem.rss",
    "https://techcrunch.com/feed/"
};

var allArticles = new List<string>();

foreach (var feedUrl in rssFeeds)
{
    rssFeedUrl = feedUrl;
    var articles = await FetchLastestNewsAsync(5);
    allArticles.AddRange(articles);
    Console.WriteLine($"\n{feedUrl} kaynağından {articles.Count} haber alındı.\n");
}

foreach (var article in allArticles)
{
    string summary = await SummarizeArticleAsync(article);
    Console.WriteLine("------ AI tarafından özetlenen haber ------");
    Console.WriteLine(summary);
    Console.WriteLine("--------------------------------------------\n");
}
```

### Özetleri Dosyaya Kaydetme

```csharp
string outputFile = $"news_summary_{DateTime.Now:yyyyMMdd_HHmmss}.txt";
using var writer = new StreamWriter(outputFile);

await writer.WriteLineAsync($"Haber Özetleri - {DateTime.Now:dd.MM.yyyy HH:mm}");
await writer.WriteLineAsync("=".PadLeft(50, '='));
await writer.WriteLineAsync();

foreach (var article in articles)
{
    string summary = await SummarizeArticleAsync(article);
    await writer.WriteLineAsync(summary);
    await writer.WriteLineAsync("\n" + "-".PadLeft(50, '-') + "\n");
}

Console.WriteLine($"\nÖzetler kaydedildi: {outputFile}");
```

### HTML İçerik Temizleme

Bazı RSS feed'lerde HTML etiketleri olabilir:

```csharp
using System.Text.RegularExpressions;

string CleanHtml(string html)
{
    if (string.IsNullOrEmpty(html)) return string.Empty;
    
    // HTML etiketlerini kaldır
    string text = Regex.Replace(html, "<[^>]*>", "");
    
    // HTML entity'lerini çöz
    text = System.Net.WebUtility.HtmlDecode(text);
    
    // Fazla boşlukları temizle
    text = Regex.Replace(text, @"\s+", " ").Trim();
    
    return text;
}
```

## 💰 Maliyet Tahmini

### GPT-4-turbo:
- 10 haber özeti: ~3000 token
- Maliyet: ~$0.09/10 haber
- Günlük (30 haber): ~$0.27/gün
- Aylık (900 haber): ~$8.10/ay

### GPT-3.5-turbo:
- 10 haber özeti: ~$0.009/10 haber
- Günlük (30 haber): ~$0.027/gün
- Aylık (900 haber): ~$0.81/ay

**Tavsiye:** Düzenli kullanım için GPT-3.5-turbo daha ekonomiktir.

## 🐛 Hata Ayıklama

### "API Key bulunamadı" hatası:

```bash
dotnet user-secrets set "OpenAI:ApiKey" "YOUR_OPENAI_API_KEY"
```

### "RSS beslemesi alınırken hata oluştu":

- Feed URL'sinin geçerli olduğundan emin olun
- İnternet bağlantısını kontrol edin
- Bazı siteler bot trafiğini engelleyebilir

### Boş description:

```csharp
string description = item.Element("description")?.Value 
    ?? item.Element("summary")?.Value 
    ?? item.Element("content")?.Value 
    ?? "";
```

### XML Parse hatası:

```csharp
try
{
    XDocument doc = XDocument.Parse(response);
}
catch (XmlException ex)
{
    Console.WriteLine($"XML format hatası: {ex.Message}");
}
```

## 📚 İlgili Kaynaklar

- [RSS Specification](https://www.rssboard.org/rss-specification)
- [XDocument Documentation](https://learn.microsoft.com/en-us/dotnet/api/system.xml.linq.xdocument)
- [OpenAI API Documentation](https://platform.openai.com/docs/api-reference)
- [GPT Best Practices](https://platform.openai.com/docs/guides/gpt-best-practices)

## 👨‍💻 Geliştirici

**Emir TARTAR**
- GitHub: [@etartar](https://github.com/etartar)

## 📄 Lisans

Bu proje eğitim amaçlıdır.
