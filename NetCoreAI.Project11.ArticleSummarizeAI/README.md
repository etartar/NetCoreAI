# 📝 NetCoreAI.Project11 - Article Summarizer

OpenAI GPT-3.5-turbo API kullanarak uzun metinleri ve makaleleri farklı detay seviyelerinde özetleyen .NET 10 konsol uygulaması.

## 📋 Özellikler

- ✅ 3 farklı özet seviyesi: Kısa, Orta, Detaylı
- ✅ OpenAI GPT-3.5-turbo modeli ile akıllı özetleme
- ✅ Uzun makaleler için optimize edilmiş
- ✅ User Secrets ile güvenli API key yönetimi
- ✅ Paralel özet üretimi

## 🛠️ Gereksinimler

- .NET 10 SDK
- OpenAI API Key ([OpenAI Platform](https://platform.openai.com/api-keys) üzerinden alabilirsiniz)

## 📦 Kullanılan Paketler

```xml
<PackageReference Include="Microsoft.Extensions.Configuration.UserSecrets" Version="10.0.3" />
```

## 🚀 Kurulum

### 1. Projeyi klonlayın veya indirin

```bash
git clone https://github.com/etartar/NetCoreAI
cd NetCoreAI/NetCoreAI.Project11.ArticleSummarizeAI
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

Uygulama çalıştığında özetlemek istediğiniz uzun metni veya makaleyi girin:

```
Uzun metninizi veya makalenizi giriniz: [Uzun bir makale metni]

Girmiş olduğunuz metin AI tarafından özetleniyor...

Özetler
---------------------
 **Kısa Özet: ** 
Bu makale yapay zeka ve makine öğrenimi hakkındadır.

---------------------
 **Orta Özet: ** 
Bu makale yapay zeka teknolojilerinin gelişimini ve günümüzde kullanım alanlarını incelemektedir. 
Özellikle makine öğrenimi algoritmalarının iş dünyasındaki uygulamalarına odaklanmaktadır.

---------------------
 **Detaylı Özet: ** 
Makale, yapay zeka ve makine öğrenimi teknolojilerinin tarihsel gelişimini ve günümüzdeki 
uygulamalarını detaylı bir şekilde ele almaktadır. İş dünyasında kullanılan çeşitli algoritmaların 
yanı sıra, gelecekte bu teknolojilerin yaratacağı potansiyel etkilere de değinmektedir...
```

## 🎯 Özet Seviyeleri

### 📌 Kısa Özet (Short)
- **Uzunluk**: 1-2 cümle
- **Kullanım**: Hızlı göz atmak için
- **İdeal**: Başlık ve ana fikir

### 📄 Orta Özet (Medium)
- **Uzunluk**: 3-5 cümle
- **Kullanım**: Temel bilgileri öğrenmek için
- **İdeal**: Ana konular ve önemli noktalar

### 📚 Detaylı Özet (Detailed)
- **Uzunluk**: Kapsamlı paragraf(lar)
- **Kullanım**: Derinlemesine anlayış için
- **İdeal**: Tüm anahtar noktaları kapsar

## 🎯 Kullanım Alanları

### Akademik Araştırma
- Bilimsel makalelerin özetlenmesi
- Literatür taraması için hızlı özet
- Araştırma notları oluşturma

### İş Dünyası
- Uzun raporların özetlenmesi
- Toplantı notlarının özetleri
- İş belgelerinin hızlı taranması

### Medya ve Yayıncılık
- Haber makalelerinin özetlenmesi
- Blog içeriği ön izleme
- İçerik küratörlüğü

### Eğitim
- Ders notlarının özetlenmesi
- Kitap bölümlerinin özeti
- Öğrenci ödevleri için kaynak özetleme

## 🔧 Yapılandırma

### Farklı Model Kullanma

GPT-4 ile daha kaliteli özetler için:

```csharp
var requestBody = new
{
    model = "gpt-4", // veya "gpt-4-turbo"
    messages = new[]
    {
        new { role = "system", content = "You are an AI that summarize text info different levels..." },
        new { role = "user", content = $"{instruction}\n\n{inputText}" }
    }
};
```

### Özel Özet Seviyeleri Ekleme

Yeni seviyeler tanımlayabilirsiniz:

```csharp
string instruction = level switch
{
    "short" => "Summarize the following text in 1-2 sentences.",
    "medium" => "Summarize the following text in 3-5 sentences.",
    "detailed" => "Summarize the following text in a detailed concise manner, covering all key points.",
    "bullet" => "Summarize the following text as bullet points (5-7 points).",
    "executive" => "Create an executive summary of the following text.",
    _ => "Summarize the following text."
};
```

### Dil Desteği

Türkçe özetleme için sistem mesajını değiştirin:

```csharp
new { role = "system", content = "Sen metinleri farklı seviyelerde özetleyen bir yapay zeka asistanısın. Türkçe özet üret." }
```

## 📊 Performans ve Maliyet

### Token Kullanımı

Ortalama bir makale (1000 kelime) için:
- **Input**: ~1,500 token
- **Output** (3 özet): ~500 token
- **Toplam**: ~2,000 token

### Maliyet Tahmini

**GPT-3.5-turbo** ile 100 makale özetleme:
- Maliyet: ~$0.30 - $0.50

**GPT-4** ile 100 makale özetleme:
- Maliyet: ~$6.00 - $10.00

## 🚀 Gelişmiş Özellikler

### Tek Seviyede Özet

Sadece bir seviye özet almak için:

```csharp
string summary = await SummarizeTextAsync(inputText, apiKey, "medium");
Console.WriteLine(summary);
```

### Dosyadan Okuma

Metin dosyasından okuyup özetlemek için:

```csharp
Console.Write("Dosya yolunu giriniz: ");
string filePath = Console.ReadLine();
string inputText = await File.ReadAllTextAsync(filePath);
```

### Çoklu Makale Özetleme

Birden fazla makaleyi toplu özetlemek için:

```csharp
string[] articles = Directory.GetFiles("articles", "*.txt");

foreach (var articlePath in articles)
{
    string text = await File.ReadAllTextAsync(articlePath);
    string summary = await SummarizeTextAsync(text, apiKey, "medium");
    
    string outputPath = Path.Combine("summaries", Path.GetFileName(articlePath));
    await File.WriteAllTextAsync(outputPath, summary);
}
```

### Özet Karşılaştırması

Farklı seviyelerdeki özetleri karşılaştırma:

```csharp
Console.WriteLine($"Kısa özet kelime sayısı: {shortSummary.Split(' ').Length}");
Console.WriteLine($"Orta özet kelime sayısı: {mediumSummary.Split(' ').Length}");
Console.WriteLine($"Detaylı özet kelime sayısı: {detailedSummary.Split(' ').Length}");
```

## 📝 En İyi Uygulamalar

### Giriş Metni Hazırlama

1. **Temiz Metin**: HTML etiketlerini ve gereksiz karakterleri temizleyin
2. **Maksimum Uzunluk**: 4000 kelimeden kısa metinler kullanın
3. **Yapılandırılmış İçerik**: Paragraflar ve bölümler belirgin olmalı

### Özet Kalitesini Artırma

1. **Doğru Model Seçimi**: Karmaşık metinler için GPT-4 kullanın
2. **Açık Talimatlar**: Sistem mesajında ne istediğinizi net belirtin
3. **Temperature Ayarı**: Tutarlılık için düşük temperature (0.3-0.5)

## 🔒 Güvenlik

- API anahtarınızı asla kaynak koduna yazmayın
- User Secrets veya ortam değişkenleri kullanın
- Hassas içerikleri özetlerken dikkat edin
- GDPR ve veri gizliliği kurallarına uyun

## 🐛 Hata Ayıklama

### "API Key bulunamadı" hatası:

```bash
dotnet user-secrets set "OpenAI:ApiKey" "YOUR_OPENAI_API_KEY"
```

### Özet çok kısa/uzun geliyor:

Instruction metinlerini daha spesifik hale getirin:

```csharp
"short" => "Summarize in EXACTLY 1 sentence (max 25 words)."
```

### Çok fazla token hatası:

Giriş metnini bölün ve ayrı ayrı özetleyin:

```csharp
if (inputText.Length > 3000)
{
    // Metni parçalara böl
    var chunks = SplitText(inputText, 2000);
    var summaries = new List<string>();
    
    foreach (var chunk in chunks)
    {
        summaries.Add(await SummarizeTextAsync(chunk, apiKey, "short"));
    }
    
    // Özetleri birleştir
    string combinedSummary = string.Join(" ", summaries);
}
```

## 📚 İlgili Kaynaklar

- [OpenAI Summarization Guide](https://platform.openai.com/docs/guides/text-generation)
- [Best Practices for Summarization](https://platform.openai.com/docs/guides/prompt-engineering)
- [Token Counting](https://platform.openai.com/tokenizer)

## 👨‍💻 Geliştirici

**Emir TARTAR**
- GitHub: [@etartar](https://github.com/etartar)

## 📄 Lisans

Bu proje eğitim amaçlıdır.
