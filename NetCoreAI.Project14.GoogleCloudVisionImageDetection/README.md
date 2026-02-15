# 👁️ NetCoreAI.Project14 - Google Cloud Vision Image Detection

Google Cloud Vision API kullanarak görsellerdeki nesneleri algılama ve etiketleme .NET 10 konsol uygulaması.

## 📋 Özellikler

- ✅ Google Cloud Vision API ile nesne tespiti
- ✅ Label Detection (Etiket algılama)
- ✅ Base64 encoding ile görsel gönderimi
- ✅ JSON formatında detaylı sonuçlar
- ✅ User Secrets ile güvenli API key yönetimi

## 🛠️ Gereksinimler

- .NET 10 SDK
- Google Cloud Vision API Key ([Google Cloud Console](https://console.cloud.google.com/) üzerinden alabilirsiniz)
- Analiz edilecek görsel dosyası

## 📦 Kullanılan Paketler

```xml
<PackageReference Include="Google.Cloud.Vision.V1" Version="3.8.0" />
<PackageReference Include="Microsoft.Extensions.Configuration.UserSecrets" Version="10.0.3" />
```

## 🚀 Kurulum

### 1. Projeyi klonlayın veya indirin

```bash
git clone https://github.com/etartar/NetCoreAI
cd NetCoreAI/NetCoreAI.Project14.GoogleCloudVisionImageDetection
```

### 2. Google Cloud Vision API'yi Etkinleştirin

1. [Google Cloud Console](https://console.cloud.google.com/) üzerinden proje oluşturun
2. Vision API'yi etkinleştirin
3. API Key oluşturun

### 3. API Key'i kaydedin

```bash
dotnet user-secrets set "GoogleVisionApi:ApiKey" "YOUR_GOOGLE_API_KEY"
```

### 4. Bağımlılıkları yükleyin

```bash
dotnet restore
```

### 5. Uygulamayı çalıştırın

```bash
dotnet run
```

## 💡 Kullanım

Uygulama çalıştığında analiz etmek istediğiniz görselin yolunu girin:

```
Resim yolunu giriniz: C:\Images\photo.jpg

Google Vision Api ile Görsel Nesne Tespiti Yapılıyor...
Tespit Edilen Nesneler:
{
  "responses": [
    {
      "labelAnnotations": [
        {
          "mid": "/m/01yrx",
          "description": "Cat",
          "score": 0.98756,
          "topicality": 0.98756
        },
        {
          "mid": "/m/0jbk",
          "description": "Animal",
          "score": 0.95432,
          "topicality": 0.95432
        }
      ]
    }
  ]
}
```

### Örnek Kullanımlar:

**Hayvan Fotoğrafı:**
```
Input:  C:\Pictures\dog.jpg
Output: Dog (0.98), Animal (0.95), Pet (0.92), Mammal (0.89)
```

**Manzara Fotoğrafı:**
```
Input:  D:\Photos\mountain.jpg
Output: Mountain (0.96), Sky (0.94), Nature (0.91), Landscape (0.88)
```

**Ürün Fotoğrafı:**
```
Input:  E:\Products\laptop.jpg
Output: Laptop (0.97), Computer (0.95), Electronics (0.93), Technology (0.90)
```

## 🎯 Kullanım Alanları

### E-Ticaret
- Ürün kategorileme
- Otomatik etiketleme
- Ürün arama optimizasyonu
- İçerik moderasyonu

### Sosyal Medya
- Otomatik hashtag önerme
- İçerik filtreleme
- Görsel kategorileme
- Trend analizi

### Fotoğraf Yönetimi
- Otomatik albüm oluşturma
- Görsel arama
- Kategorizasyon
- Etiketleme

### Güvenlik
- Yasak içerik tespiti
- Nesne tanıma
- Anormal durum tespiti
- İzleme sistemleri

## 🔧 Yapılandırma

### Daha Fazla Sonuç Alma

maxResults parametresini artırın:

```csharp
features = new[] { new { type = "LABEL_DETECTION", maxResults = 20 } }
```

### Farklı Tespit Türleri

Google Vision API birçok özellik sunar:

```csharp
// Yüz algılama
features = new[] { new { type = "FACE_DETECTION", maxResults = 10 } }

// Metin algılama (OCR)
features = new[] { new { type = "TEXT_DETECTION", maxResults = 10 } }

// Logo algılama
features = new[] { new { type = "LOGO_DETECTION", maxResults = 10 } }

// Landmark algılama
features = new[] { new { type = "LANDMARK_DETECTION", maxResults = 10 } }

// Güvenli arama (uygunsuz içerik)
features = new[] { new { type = "SAFE_SEARCH_DETECTION" } }

// Web algılama
features = new[] { new { type = "WEB_DETECTION", maxResults = 10 } }

// Baskın renkler
features = new[] { new { type = "IMAGE_PROPERTIES" } }

// Obje lokasyonu
features = new[] { new { type = "OBJECT_LOCALIZATION", maxResults = 10 } }
```

### Çoklu Özellik Tespiti

Aynı anda birden fazla özelliği tespit etmek için:

```csharp
var requestBody = new
{
    requests = new[]
    {
        new
        {
            image = new { content = base64Image },
            features = new[] 
            { 
                new { type = "LABEL_DETECTION", maxResults = 10 },
                new { type = "FACE_DETECTION", maxResults = 5 },
                new { type = "TEXT_DETECTION" },
                new { type = "SAFE_SEARCH_DETECTION" }
            }
        }
    }
};
```

## 🚀 Gelişmiş Özellikler

### JSON Parse Etme

Sonuçları düzgün parse etmek için:

```csharp
var jsonResponse = JsonDocument.Parse(responseContent);
var labels = jsonResponse.RootElement
    .GetProperty("responses")[0]
    .GetProperty("labelAnnotations");

Console.WriteLine("Tespit Edilen Etiketler:");
foreach (var label in labels.EnumerateArray())
{
    string description = label.GetProperty("description").GetString();
    double score = label.GetProperty("score").GetDouble();
    Console.WriteLine($"- {description}: {score:P2}"); // Yüzdelik format
}
```

### Toplu Görsel Analizi

Bir klasördeki tüm görselleri analiz etmek için:

```csharp
string folderPath = @"C:\Images";
var imageFiles = Directory.GetFiles(folderPath, "*.jpg")
    .Concat(Directory.GetFiles(folderPath, "*.png"))
    .Concat(Directory.GetFiles(folderPath, "*.jpeg"));

foreach (var imagePath in imageFiles)
{
    Console.WriteLine($"\nAnaliz ediliyor: {Path.GetFileName(imagePath)}");
    string result = await DetectObjects(imagePath);
    
    // Sonuçları kaydet
    string outputPath = Path.ChangeExtension(imagePath, ".labels.json");
    await File.WriteAllTextAsync(outputPath, result);
}
```

### URL'den Görsel Analizi

Web'deki bir görseli analiz etmek için:

```csharp
var requestBody = new
{
    requests = new[]
    {
        new
        {
            image = new { source = new { imageUri = "https://example.com/image.jpg" } },
            features = new[] { new { type = "LABEL_DETECTION", maxResults = 10 } }
        }
    }
};
```

### Yüz Tespiti

Görseldeki yüzleri tespit etmek için:

```csharp
async Task<string> DetectFaces(string imagePath)
{
    using var client = new HttpClient();
    string apiUrl = $"https://vision.googleapis.com/v1/images:annotate?key={googleApiKey}";

    byte[] imageBytes = await File.ReadAllBytesAsync(imagePath);
    string base64Image = Convert.ToBase64String(imageBytes);

    var requestBody = new
    {
        requests = new[]
        {
            new
            {
                image = new { content = base64Image },
                features = new[] { new { type = "FACE_DETECTION", maxResults = 10 } }
            }
        }
    };

    var jsonRequest = JsonSerializer.Serialize(requestBody);
    var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");
    var response = await client.PostAsync(apiUrl, content);
    
    return await response.Content.ReadAsStringAsync();
}
```

### Metin Tespiti (OCR)

Görseldeki metni çıkarmak için:

```csharp
features = new[] { new { type = "TEXT_DETECTION" } }

// Sonucu parse et
var textAnnotations = jsonResponse.RootElement
    .GetProperty("responses")[0]
    .GetProperty("textAnnotations");

string fullText = textAnnotations[0].GetProperty("description").GetString();
Console.WriteLine($"Tespit edilen metin:\n{fullText}");
```

## 📊 Güven Skoru (Confidence Score)

Sonuçlar güven skoru ile gelir (0-1 arası):

- **0.9-1.0**: Çok yüksek güven
- **0.7-0.9**: Yüksek güven
- **0.5-0.7**: Orta güven
- **0.0-0.5**: Düşük güven

Sadece yüksek güvenli sonuçları filtrelemek için:

```csharp
foreach (var label in labels.EnumerateArray())
{
    double score = label.GetProperty("score").GetDouble();
    if (score >= 0.8) // Sadece %80'den yüksek güvenli sonuçlar
    {
        string description = label.GetProperty("description").GetString();
        Console.WriteLine($"- {description}: {score:P2}");
    }
}
```

## 💰 Fiyatlandırma

### Google Cloud Vision API Fiyatları:

| Özellik | İlk 1000 birim/ay | 1001-5M birim/ay | 5M+ birim/ay |
|---------|-------------------|------------------|--------------|
| Label Detection | ÜCRETSİZ | $1.50 / 1000 | $0.60 / 1000 |
| OCR | ÜCRETSİZ | $1.50 / 1000 | $0.60 / 1000 |
| Face Detection | ÜCRETSİZ | $1.50 / 1000 | $0.60 / 1000 |
| Logo Detection | ÜCRETSİZ | $1.50 / 1000 | $0.60 / 1000 |

Detaylı fiyatlandırma: [Google Cloud Vision Pricing](https://cloud.google.com/vision/pricing)

## 🔒 Güvenlik

- API anahtarınızı asla kaynak koduna yazmayın
- User Secrets veya ortam değişkenleri kullanın
- Ücretsiz kotayı aşmamak için kullanımı takip edin
- Hassas görselleri şifreleyerek gönderin

## 🐛 Hata Ayıklama

### "API Key bulunamadı" hatası:

```bash
dotnet user-secrets set "GoogleVisionApi:ApiKey" "YOUR_GOOGLE_API_KEY"
```

### HTTP 400 Bad Request:

Görsel formatını kontrol edin:
- Desteklenen formatlar: JPEG, PNG, GIF, BMP, WEBP, RAW, ICO, PDF, TIFF
- Maksimum boyut: 20MB (Base64), 10MB (URL)

### HTTP 403 Forbidden:

- API'nin etkin olduğundan emin olun
- API key'in doğru projeye ait olduğunu kontrol edin
- Billing (faturalama) aktif olmalı

### Boş sonuç dönüyor:

```csharp
if (!responseContent.Contains("labelAnnotations"))
{
    Console.WriteLine("Görselde nesne tespit edilemedi.");
}
```

## 📚 İlgili Kaynaklar

- [Google Cloud Vision Documentation](https://cloud.google.com/vision/docs)
- [Vision API Try It](https://cloud.google.com/vision/docs/drag-and-drop)
- [Label Detection Guide](https://cloud.google.com/vision/docs/labels)
- [Best Practices](https://cloud.google.com/vision/docs/best-practices)

## 👨‍💻 Geliştirici

**Emir TARTAR**
- GitHub: [@etartar](https://github.com/etartar)

## 📄 Lisans

Bu proje eğitim amaçlıdır.
