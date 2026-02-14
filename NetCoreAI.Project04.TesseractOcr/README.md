# 🔍 NetCoreAI.Project04.TesseractOcr - Tesseract

Tesseract, açık kaynaklı bir OCR (Optical Character Recognition - Optik Karakter Tanıma) motorudur. OCR, Görüntülerdeki veya taranmış belgelerdeki metinleri tanımak ve dijital metne dönüştürmek için kullanılan bir teknolojidir. Tesseract, Google tarafından geliştirilmiş ve desteklenmektedir.

## 📋 Özellikler

- ✅ Tesseract OCR motoru ile görüntü metni tanıma
- ✅ Çoklu dil desteği (Türkçe, İngilizce, vb.)
- ✅ PNG, JPG, TIFF formatı desteği
- ✅ Yüksek doğrulukla metin çıkarma
- ✅ User Secrets ile yapılandırma yönetimi

## 🛠️ Gereksinimler

- .NET 10 SDK
- Tesseract OCR Engine
- Tesseract Language Data Files (traineddata)

## 📦 Kullanılacak Paketler

```xml
<PackageReference Include="Tesseract" Version="5.2.0" />
<PackageReference Include="Microsoft.Extensions.Configuration.UserSecrets" Version="9.0.0" />
```

## 🚀 Kurulum

### 1. Projeyi klonlayın veya indirin

```bash
git clone https://github.com/etartar/NetCoreAI
cd NetCoreAI/NetCoreAI.Project04.TesseractOcr
```

### 2. Tesseract OCR Engine'i yükleyin

#### Windows:
- [UB Mannheim Tesseract](https://github.com/UB-Mannheim/tesseract/wiki) adresinden Tesseract'i indirin ve kurun
- Kurulum yolu: `C:\Program Files\Tesseract-OCR`

#### Linux:
```bash
sudo apt-get install tesseract-ocr
sudo apt-get install libtesseract-dev
```

#### macOS:
```bash
brew install tesseract
```

### 3. Dil dosyalarını indirin

- [Tesseract Language Data](https://github.com/tesseract-ocr/tessdata) adresinden gerekli dil dosyalarını indirin
- Türkçe: `tur.traineddata`
- İngilizce: `eng.traineddata`
- Dosyaları `tessdata` klasörüne yerleştirin

### 4. Bağımlılıkları yükleyin

```bash
dotnet restore
```

### 5. Uygulamayı çalıştırın

```bash
dotnet run
```

## 💡 Kullanım

> **Not:** Bu proje şu anda geliştirme aşamasındadır. Yakında OCR özellikleri eklenecektir.

### Planlanan Kullanım:

```csharp
using Tesseract;

var imagePath = "sample-image.png";

using (var engine = new TesseractEngine(@"./tessdata", "tur", EngineMode.Default))
{
    using (var img = Pix.LoadFromFile(imagePath))
    {
        using (var page = engine.Process(img))
        {
            var text = page.GetText();
            Console.WriteLine($"Detected Text:\n{text}");
            Console.WriteLine($"Confidence: {page.GetMeanConfidence()}");
        }
    }
}
```

## 🖼️ Desteklenen Görüntü Formatları

- PNG
- JPG / JPEG
- TIFF
- BMP
- GIF

## 🔧 Yapılandırma

### Dil Seçimi

```csharp
// Türkçe için
var engine = new TesseractEngine(@"./tessdata", "tur", EngineMode.Default);

// İngilizce için
var engine = new TesseractEngine(@"./tessdata", "eng", EngineMode.Default);

// Çoklu dil için
var engine = new TesseractEngine(@"./tessdata", "tur+eng", EngineMode.Default);
```
### Pix Sınıfı Nedir ?

Pix sınıfı, Tesseract OCR motorunun görüntüleri temsil etmek için kullandığı bir sınıftır. Görüntüleri yüklemek, işlemek ve OCR işlemi için hazırlamak amacıyla kullanılır. Pix sınıfı, görüntü verilerini bellekte tutar ve Tesseract motorunun metin tanıma işlemi sırasında bu verileri kullanmasına olanak tanır.

### TesseractEngine Sınıfı Nedir ?

TesseractEngine sınıfı, Tesseract OCR motorunu başlatmak ve yapılandırmak için kullanılan bir sınıftır. Bu sınıf, OCR işlemi sırasında kullanılacak dil dosyalarını, motor modunu ve diğer yapılandırma seçeneklerini belirlemek için kullanılır. TesseractEngine, OCR işlemi sırasında görüntüleri işlemek ve metin tanımak için gerekli olan tüm kaynakları yönetir.

### OCR Modu

```csharp
// Varsayılan mod
EngineMode.Default

// Sadece LSTM (Neural Network) - Daha yavaş ama daha doğru
EngineMode.LstmOnly

// Legacy mode - Daha hızlı ama daha az doğru
EngineMode.TesseractOnly
```

### Page Değişkeni Nedir ?

Page sınıfı, Tesseract OCR motorunun bir görüntü üzerinde gerçekleştirdiği OCR işleminin sonucunu temsil eder. Page sınıfı, tanınan metni, metnin konumunu, güvenilirlik skorlarını ve diğer ilgili bilgileri içerir. OCR işlemi tamamlandığında, Page nesnesi üzerinden tanınan metne erişebilir ve sonuçları analiz edebilirsiniz.

## 🎯 En İyi Sonuçlar İçin İpuçları

1. **Görüntü Kalitesi**: Yüksek çözünürlüklü ve net görüntüler kullanın
2. **Kontrast**: Metin ile arka plan arasında yüksek kontrast sağlayın
3. **Düz Metin**: Eğik veya bozulmuş metinlerden kaçının
4. **Ön İşleme**: Görüntüyü önce griye çevirin ve gürültüyü temizleyin
5. **Dil Seçimi**: Doğru dil dosyasını kullanın

## 📝 Örnek Senaryolar

### 1. Belge Dijitalleştirme
- Taranmış belgelerden metin çıkarma
- PDF'leri düzenlenebilir metne çevirme

### 2. Fatura ve Fiş İşleme
- Fatura bilgilerini otomatik çıkarma
- Fiş tutarlarını dijitalleştirme

### 3. Plaka Tanıma
- Araç plakalarını okuma
- Otopark sistemleri için

### 4. Kimlik Belgesi Okuma
- TC Kimlik kartı bilgilerini okuma
- Pasaport bilgilerini çıkarma

## 🔒 Güvenlik

⚠️ **ÖNEMLİ**: Hassas belgeleri işlerken veri gizliliğine dikkat edin!

Bu proje User Secrets kullanarak yapılandırma ayarlarını güvenli şekilde saklar:

- **Windows**: `%APPDATA%\Microsoft\UserSecrets\netcoreai-project04-secrets\secrets.json`
- **Linux/macOS**: `~/.microsoft/usersecrets/netcoreai-project04-secrets/secrets.json`

## 📚 Kaynaklar

- [Tesseract OCR Documentation](https://tesseract-ocr.github.io/)
- [Tesseract.NET GitHub](https://github.com/charlesw/tesseract)
- [.NET User Secrets](https://learn.microsoft.com/en-us/aspnet/core/security/app-secrets)
- [Tesseract Language Data](https://github.com/tesseract-ocr/tessdata)

## 🐛 Sorun Giderme

### "Tesseract engine not found" hatası alıyorsanız:

- Tesseract OCR'nin doğru kurulduğundan emin olun
- PATH değişkenine Tesseract klasörünü ekleyin

```bash
# Windows için (PowerShell - Admin)
$env:Path += ";C:\Program Files\Tesseract-OCR"
```

### "Language data file not found" hatası alıyorsanız:

- `tessdata` klasörünün doğru konumda olduğundan emin olun
- Gerekli dil dosyalarının (.traineddata) indirildiğinden emin olun

### Düşük doğruluk oranı alıyorsanız:

- Görüntü kalitesini artırın
- Doğru dil dosyasını kullanın
- Görüntüyü ön işlemeden geçirin (griye çevirme, kontrast artırma)

### Memory leak sorunları yaşıyorsanız:

- `using` statement'leri kullanarak kaynakları düzgün dispose edin
- Büyük görüntüleri işlemeden önce boyutlandırın

## 🎯 Geliştirme Fikirleri

- Toplu görüntü işleme
- PDF'den metin çıkarma
- Görüntü ön işleme (preprocessing) ekle
- Çoklu dil otomatik algılama
- GUI arayüz ekleme
- REST API endpoint'i oluşturma

## 📊 Performans İpuçları

- Küçük görüntülerle başlayın (1000x1000 piksel altı)
- Gereksiz sayfa segmentasyon modlarını devre dışı bırakın
- Önbellekleme kullanın (aynı görüntü için)
- Paralel işleme için Task.Parallel kullanın

## 📄 Lisans

Bu proje eğitim amaçlıdır.

## 👨‍💻 Geliştirici

**Emir TARTAR**
- GitHub: [@etartar](https://github.com/etartar)

---

⭐ Projeyi beğendiyseniz yıldız vermeyi unutmayın!
