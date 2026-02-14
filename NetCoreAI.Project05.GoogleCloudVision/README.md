# 👁️ NetCoreAI.Project05 - Google Cloud Vision OCR

Google Cloud Vision API kullanarak görüntülerden metin çıkaran (OCR) .NET 10 konsol uygulaması. Bulut tabanlı güçlü optik karakter tanıma ile görsel içindeki metinleri yüksek doğrulukla dijital metne dönüştürün.

## 📋 Özellikler

- ✅ Google Cloud Vision API entegrasyonu
- ✅ Görüntüden metin çıkarma (OCR)
- ✅ Çoklu dil desteği (100+ dil)
- ✅ Metin konum bilgisi (Bounding Box)
- ✅ Yüksek doğruluk oranı
- ✅ User Secrets ile güvenli yapılandırma yönetimi

## 🛠️ Gereksinimler

- .NET 10 SDK
- Google Cloud hesabı ([Google Cloud Console](https://console.cloud.google.com/))
- Google Cloud Vision API etkinleştirilmiş proje
- Service Account JSON kimlik dosyası

## 📦 Kullanılan Paketler

```xml
<PackageReference Include="Google.Cloud.Vision.V1" Version="3.8.0" />
<PackageReference Include="Microsoft.Extensions.Configuration.UserSecrets" Version="10.0.3" />
```

## 🚀 Kurulum

### 1. Google Cloud Projesi Oluşturma

#### a. Google Cloud Console'a gidin
- [Google Cloud Console](https://console.cloud.google.com/) adresine gidin
- Yeni bir proje oluşturun veya mevcut projeyi seçin

#### b. Cloud Vision API'yi Etkinleştirin
```
1. Sol menüden "APIs & Services" > "Library" seçin
2. "Cloud Vision API" aratın
3. "Enable" butonuna tıklayın
```

#### c. Service Account Oluşturun
```
1. "APIs & Services" > "Credentials" seçin
2. "Create Credentials" > "Service Account" tıklayın
3. Service account adı verin (örn: vision-ocr-service)
4. Role olarak "Cloud Vision AI Service Agent" seçin
5. "Done" tıklayın
```

#### d. JSON Key Dosyası İndirin
```
1. Oluşturduğunuz Service Account'a tıklayın
2. "Keys" sekmesine gidin
3. "Add Key" > "Create new key" seçin
4. "JSON" formatını seçin
5. İndirilen JSON dosyasını proje klasörüne kaydedin
```

### 2. Projeyi Klonlayın

```bash
git clone https://github.com/etartar/NetCoreAI.git
cd NetCoreAI/NetCoreAI.Project05.GoogleCloudVision
```

### 3. Service Account JSON Dosyasını Yapılandırın

JSON dosyanızı proje klasörüne kopyalayın ve `Program.cs` dosyasında yolu güncelleyin:

```csharp
string credentialPath = "your-service-account-key.json";
```

**veya** tam yol belirtin:

```csharp
string credentialPath = @"C:\MyProject\credentials\vision-service-key.json";
```

### 4. Bağımlılıkları Yükleyin

```bash
dotnet restore
```

### 5. Uygulamayı Çalıştırın

```bash
dotnet run
```

## 💡 Kullanım

Uygulama çalıştığında, OCR yapılacak görüntünün yolunu girin:

```
Resim yolunu giriniz: sample-image.png

Resimdeki metin: Merhaba Dünya
Bu bir örnek metindir.

Metin: Merhaba Dünya
Konum: vertices { x: 10 y: 20 } vertices { x: 150 y: 20 } ...

Metin: Bu bir örnek metindir.
Konum: vertices { x: 10 y: 50 } vertices { x: 200 y: 50 } ...
```

### Örnek Kullanım Senaryoları:

```csharp
// Göreli yol
Resim yolunu giriniz: images/document.jpg

// Tam yol (Windows)
Resim yolunu giriniz: C:\Users\Username\Pictures\receipt.png

// Tam yol (Linux/macOS)
Resim yolunu giriniz: /home/username/images/text.jpg
```

## 🖼️ Desteklenen Görüntü Formatları

- **PNG** (.png)
- **JPEG** (.jpg, .jpeg)
- **WEBP** (.webp)
- **GIF** (.gif)
- **BMP** (.bmp)
- **TIFF** (.tiff)
- **RAW** (.raw)

**Maksimum dosya boyutu**: 20 MB

## 🔧 Yapılandırma

### Farklı OCR İşlemleri

Cloud Vision API birçok farklı görüntü analizi özelliği sunar:

```csharp
// Metin algılama (Text Detection)
var response = await client.DetectTextAsync(image);

// Etiket algılama (Label Detection)
var labels = await client.DetectLabelsAsync(image);

// Yüz algılama (Face Detection)
var faces = await client.DetectFacesAsync(image);

// Logo algılama (Logo Detection)
var logos = await client.DetectLogosAsync(image);

// Landmark algılama (Landmark Detection)
var landmarks = await client.DetectLandmarksAsync(image);

// Güvenli arama algılama (Safe Search Detection)
var safeSearch = await client.DetectSafeSearchAsync(image);

// Web varlıkları algılama (Web Detection)
var webDetection = await client.DetectWebInformationAsync(image);
```

### Toplu İşlem (Batch Request)

Birden fazla görüntüyü tek istekte işleme:

```csharp
var requests = new[]
{
    new AnnotateImageRequest
    {
        Image = Image.FromFile("image1.jpg"),
        Features = { new Feature { Type = Feature.Types.Type.TextDetection } }
    },
    new AnnotateImageRequest
    {
        Image = Image.FromFile("image2.jpg"),
        Features = { new Feature { Type = Feature.Types.Type.TextDetection } }
    }
};

var batchResponse = await client.BatchAnnotateImagesAsync(requests);
```

## 🌍 Dil Desteği

Google Cloud Vision API, **100+ dil** için OCR desteği sunar:

- Türkçe (tr)
- İngilizce (en)
- Arapça (ar)
- Çince (zh)
- Japonca (ja)
- Korece (ko)
- Rusça (ru)
- ve çok daha fazlası...

Dil otomatik olarak algılanır, manuel belirtmeye gerek yoktur.

## 💰 Fiyatlandırma

Google Cloud Vision API kullanımı ücretlidir. İlk 1000 istek/ay ücretsizdir.

| Özellik | İlk 1000 birim/ay | 1001-5M birim/ay | 5M+ birim/ay |
|---------|-------------------|------------------|--------------|
| Text Detection | ÜCRETSİZ | $1.50 / 1000 | $0.60 / 1000 |
| Document Text Detection | ÜCRETSİZ | $1.50 / 1000 | $0.60 / 1000 |
| Label Detection | ÜCRETSİZ | $1.50 / 1000 | $0.60 / 1000 |
| Image Properties | ÜCRETSİZ | $1.50 / 1000 | $0.60 / 1000 |

Detaylı fiyatlandırma için: [Google Cloud Vision Pricing](https://cloud.google.com/vision/pricing)

## 🔒 Güvenlik

⚠️ **ÖNEMLİ GÜVENLİK UYARILARI:**

- Service Account JSON dosyanızı **asla** Git'e commit etmeyin
- `.gitignore` dosyasına JSON dosya adını ekleyin
- Production ortamında ortam değişkenleri veya Secret Manager kullanın
- JSON dosyasını güvenli bir konumda saklayın
- Gereksiz izinler vermeyin, en az yetki prensibiyle çalışın

### .gitignore'a Ekleyin:

```gitignore
# Google Cloud Service Account
*-service-account.json
credentials.json
vision-key.json
*.json
```

### Ortam Değişkeni ile Kullanım (Production):

```bash
# Linux/macOS
export GOOGLE_APPLICATION_CREDENTIALS="/path/to/service-account-key.json"

# Windows PowerShell
$env:GOOGLE_APPLICATION_CREDENTIALS="C:\path\to\service-account-key.json"

# Windows CMD
set GOOGLE_APPLICATION_CREDENTIALS=C:\path\to\service-account-key.json
```

## 📝 Örnek Senaryolar

### 1. Belge Dijitalleştirme
```csharp
var client = await ImageAnnotatorClient.CreateAsync();
var image = Image.FromFile("scanned-document.pdf");
var response = await client.DetectDocumentTextAsync(image);
Console.WriteLine(response.Text);
```

### 2. Fatura OCR
```csharp
var client = await ImageAnnotatorClient.CreateAsync();
var image = Image.FromFile("invoice.jpg");
var response = await client.DetectTextAsync(image);

foreach (var annotation in response)
{
    Console.WriteLine($"Metin: {annotation.Description}");
}
```

### 3. El Yazısı Tanıma
```csharp
var client = await ImageAnnotatorClient.CreateAsync();
var image = Image.FromFile("handwritten-note.jpg");
var response = await client.DetectDocumentTextAsync(image);
Console.WriteLine(response.Text);
```

### 4. Çoklu Dil Desteği
```csharp
// Otomatik dil algılama
var client = await ImageAnnotatorClient.CreateAsync();
var image = Image.FromFile("multilingual-text.jpg");
var response = await client.DetectTextAsync(image);

foreach (var annotation in response)
{
    Console.WriteLine($"Metin: {annotation.Description}");
    Console.WriteLine($"Dil: {annotation.Locale}");
}
```

## 🎯 En İyi Sonuçlar İçin İpuçları

1. **Görüntü Kalitesi**
   - En az 300 DPI çözünürlük kullanın
   - Net ve iyi aydınlatılmış görüntüler kullanın

2. **Metin Boyutu**
   - Metin yüksekliği en az 10 piksel olmalı
   - Çok küçük metinlerden kaçının

3. **Görüntü Formatı**
   - PNG veya JPEG kullanın
   - Sıkıştırma oranını düşük tutun

4. **Döndürme ve Perspektif**
   - Görüntüleri düz olarak tarayın
   - Eğik görüntüleri düzeltin

5. **Kontrast**
   - Metin ile arka plan arasında yüksek kontrast sağlayın
   - Siyah metin, beyaz arka plan en iyisidir

## 📊 Cloud Vision vs Tesseract Karşılaştırması

| Özellik | Google Cloud Vision | Tesseract OCR |
|---------|-------------------|---------------|
| Doğruluk Oranı | ⭐⭐⭐⭐⭐ Çok Yüksek | ⭐⭐⭐⭐ Yüksek |
| El Yazısı Tanıma | ✅ Mükemmel | ⚠️ Sınırlı |
| Dil Desteği | 100+ dil | 100+ dil |
| Maliyet | Ücretli (1000 ücretsiz/ay) | Ücretsiz |
| İnternet Gereksinimi | ✅ Gerekli | ❌ Offline çalışır |
| Kurulum | Kolay (API Key) | Karmaşık (Engine kurulumu) |
| Hız | ⚡ Çok Hızlı | 🐢 Yavaş |
| Bulut Tabanlı | ✅ Evet | ❌ Hayır |

## 🐛 Sorun Giderme

### "Service Account JSON dosyası bulunamadı" hatası

```csharp
// Tam yol kullanın
string credentialPath = @"C:\MyProject\credentials\vision-service-key.json";

// Dosyanın varlığını kontrol edin
if (!File.Exists(credentialPath))
{
    throw new FileNotFoundException($"Credentials file not found: {credentialPath}");
}
```

### "The Application Default Credentials are not available" hatası

```bash
# Ortam değişkenini ayarlayın
export GOOGLE_APPLICATION_CREDENTIALS="/path/to/service-account-key.json"

# Veya kodda ayarlayın
Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", credentialPath);
```

### "Cloud Vision API has not been used" hatası

1. [Google Cloud Console](https://console.cloud.google.com/) adresine gidin
2. "APIs & Services" > "Library" seçin
3. "Cloud Vision API" aratın ve etkinleştirin

### HTTP 403 Forbidden hatası

- Service Account'a doğru izinlerin verildiğinden emin olun
- "Cloud Vision AI Service Agent" rolünü ekleyin
- Billing hesabınızın aktif olduğunu kontrol edin

### "Image too large" hatası

```csharp
// Görüntüyü yeniden boyutlandırın
var maxSize = 20 * 1024 * 1024; // 20 MB
var fileInfo = new FileInfo(imagePath);

if (fileInfo.Length > maxSize)
{
    Console.WriteLine("Görüntü çok büyük! Maksimum 20 MB olmalıdır.");
}
```

## 📚 Kaynaklar

### Resmi Dokümantasyon

- [Google Cloud Vision API Documentation](https://cloud.google.com/vision/docs)
- [Google Cloud Vision .NET Client](https://cloud.google.com/dotnet/docs/reference/Google.Cloud.Vision.V1/latest)
- [Cloud Vision API Pricing](https://cloud.google.com/vision/pricing)
- [Vision API Quotas](https://cloud.google.com/vision/quotas)

### Yararlı Linkler

- [Google Cloud Console](https://console.cloud.google.com/)
- [Vision API Try It](https://cloud.google.com/vision/docs/drag-and-drop)
- [Best Practices](https://cloud.google.com/vision/docs/best-practices)
- [Sample Images](https://cloud.google.com/vision/docs/samples)

### GitHub ve Örnekler

- [Google Cloud Vision .NET Samples](https://github.com/GoogleCloudPlatform/dotnet-docs-samples/tree/main/vision)
- [Official .NET Client Library](https://github.com/googleapis/google-cloud-dotnet)

## 🎯 Geliştirme Fikirleri

- [ ] Birden fazla görüntüyü toplu işleme
- [ ] PDF dosyalarından metin çıkarma
- [ ] Çıktıyı JSON/XML formatında kaydetme
- [ ] GUI arayüz ekleme (WPF/WinForms/Blazor)
- [ ] REST API endpoint'i oluşturma
- [ ] Azure Blob Storage entegrasyonu
- [ ] OCR sonuçlarını veritabanına kaydetme
- [ ] Görüntü ön işleme (preprocessing) ekle
- [ ] Async toplu dosya işleme
- [ ] OCR sonuçlarını Excel'e aktarma

## 📊 Performans İpuçları

1. **Batch İşleme Kullanın**
   - Birden fazla görüntüyü tek istekte gönderin
   - Network overhead'i azaltır

2. **Async/Await Kullanın**
   - Non-blocking operasyonlar için
   - Daha iyi performans

3. **Görüntü Boyutunu Optimize Edin**
   - Gereksiz yüksek çözünürlükten kaçının
   - Optimal boyut: 1024-2048 piksel genişlik

4. **Caching Mekanizması**
   - Aynı görüntüler için sonuçları önbelleğe alın
   - Gereksiz API çağrılarından kaçının

## 🔄 Tesseract'tan Google Vision'a Geçiş

Eğer Tesseract OCR kullanıyorsanız, Google Cloud Vision'a geçiş kolaydır:

### Tesseract (Eski):
```csharp
using (var engine = new TesseractEngine(@"./tessdata", "tur", EngineMode.Default))
{
    using (var img = Pix.LoadFromFile(imagePath))
    {
        using (var page = engine.Process(img))
        {
            var text = page.GetText();
        }
    }
}
```

### Google Cloud Vision (Yeni):
```csharp
var client = await ImageAnnotatorClient.CreateAsync();
var image = Image.FromFile(imagePath);
var response = await client.DetectTextAsync(image);
var text = response[0].Description;
```

## 📄 Lisans

Bu proje eğitim amaçlıdır.

## 👨‍💻 Geliştirici

**Emir TARTAR**
- GitHub: [@etartar](https://github.com/etartar)
- Repository: [NetCoreAI](https://github.com/etartar/NetCoreAI)

## 🙏 Teşekkürler

- Google Cloud ekibine güçlü Vision API için
- .NET topluluğuna

---

⭐ **Projeyi beğendiyseniz yıldız vermeyi unutmayın!**

💡 **Sorularınız için Issue açabilir veya Pull Request gönderebilirsiniz.**

🚀 **Happy Coding!**
