# 📄 NetCoreAI.Project13 - PDF Analyzer with OpenAI

PdfPig ve OpenAI GPT-3.5-turbo API kullanarak PDF dosyalarından metin çıkarma ve analiz etme .NET 10 konsol uygulaması.

## 📋 Özellikler

- ✅ PdfPig ile PDF metin çıkarma
- ✅ OpenAI GPT ile içerik analizi ve özetleme
- ✅ Çok sayfalı PDF desteği
- ✅ Türkçe çıktı desteği
- ✅ User Secrets ile güvenli API key yönetimi

## 🛠️ Gereksinimler

- .NET 10 SDK
- OpenAI API Key ([OpenAI Platform](https://platform.openai.com/api-keys) üzerinden alabilirsiniz)
- PDF dosyası

## 📦 Kullanılan Paketler

```xml
<PackageReference Include="Microsoft.Extensions.Configuration.UserSecrets" Version="10.0.3" />
<PackageReference Include="Newtonsoft.Json" Version="13.0.4" />
<PackageReference Include="PdfPig" Version="0.1.13" />
```

## 🚀 Kurulum

### 1. Projeyi klonlayın veya indirin

```bash
git clone https://github.com/etartar/NetCoreAI
cd NetCoreAI/NetCoreAI.Project13.PdfAnalyzeWithOpenAI
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

Uygulama çalıştığında analiz etmek istediğiniz PDF dosyasının yolunu girin:

```
PDF Dosya Yolunu Giriniz: C:\Documents\report.pdf

 AI Analizi (Pdf İçeriği): 
Bu PDF dosyası [içerik özeti]... [AI tarafından Türkçe analiz]
```

### Örnek Kullanımlar:

**Akademik Makale Analizi:**
```
Input:  C:\Papers\research-paper.pdf
Output: Bu akademik makale makine öğrenimi algoritmalarını karşılaştırmaktadır...
```

**İş Raporu Analizi:**
```
Input:  D:\Reports\quarterly-report.pdf
Output: Bu rapor şirketin Q4 finansal sonuçlarını içermektedir...
```

**E-Kitap Özeti:**
```
Input:  E:\Books\programming-guide.pdf
Output: Bu kitap .NET programlama konusunda kapsamlı bir rehberdir...
```

## 🎯 Kullanım Alanları

### Akademik Araştırma
- Bilimsel makalelerin özetlenmesi
- Tez ve araştırma dokümanları analizi
- Literatür taraması
- Referans çıkarma

### İş Dünyası
- Sözleşme analizi
- Finansal rapor özetleme
- Toplantı tutanaklarının analizi
- İş tekliflerinin değerlendirilmesi

### Hukuk
- Yasal doküman analizi
- Sözleşme maddeleri çıkarma
- Dava dosyalarının özetlenmesi
- Mevzuat araştırması

### Eğitim
- Ders kitaplarının özetlenmesi
- Sınav sorularının hazırlanması
- Öğrenci ödevlerinin analizi
- Ders materyallerinin hazırlanması

## 🔧 Yapılandırma

### Belirli Sayfaları İşleme

Sadece belirli sayfaları analiz etmek için:

```csharp
async Task<string> ExtractTextFromPdf(string path, int startPage = 1, int? endPage = null)
{
    StringBuilder textBuilder = new StringBuilder();
    using PdfDocument pdf = PdfDocument.Open(path);
    
    int lastPage = endPage ?? pdf.NumberOfPages;
    
    for (int i = startPage; i <= lastPage && i <= pdf.NumberOfPages; i++)
    {
        var page = pdf.GetPage(i);
        textBuilder.AppendLine($"--- Sayfa {i} ---");
        textBuilder.AppendLine(page.Text);
    }
    
    return textBuilder.ToString();
}
```

### Farklı Analiz Türleri

Sistem mesajını değiştirerek farklı analizler yapabilirsiniz:

```csharp
// Özet için
new { role = "system", content = "Bu PDF'in kapsamlı bir özetini Türkçe olarak oluştur." }

// Anahtar noktalar için
new { role = "system", content = "Bu PDF'deki en önemli 10 noktayı Türkçe madde halinde listele." }

// Soru-cevap için
new { role = "system", content = "Bu PDF'e göre kullanıcının sorularını yanıtla." }

// Kategorizasyon için
new { role = "system", content = "Bu PDF'in ana konusunu ve kategorisini belirle." }
```

### PDF Metadata Çıkarma

PDF hakkında bilgi almak için:

```csharp
using PdfDocument pdf = PdfDocument.Open(path);

Console.WriteLine($"Sayfa Sayısı: {pdf.NumberOfPages}");
Console.WriteLine($"Başlık: {pdf.Information.Title}");
Console.WriteLine($"Yazar: {pdf.Information.Author}");
Console.WriteLine($"Konu: {pdf.Information.Subject}");
Console.WriteLine($"Oluşturma Tarihi: {pdf.Information.CreationDate}");
Console.WriteLine($"Düzenleme Tarihi: {pdf.Information.ModificationDate}");
```

## 🚀 Gelişmiş Özellikler

### Toplu PDF Analizi

Bir klasördeki tüm PDF'leri analiz etmek için:

```csharp
string folderPath = @"C:\Documents\PDFs";
var pdfFiles = Directory.GetFiles(folderPath, "*.pdf");

foreach (var pdfPath in pdfFiles)
{
    Console.WriteLine($"\nAnaliz ediliyor: {Path.GetFileName(pdfPath)}");
    string pdfText = await ExtractTextFromPdf(pdfPath);
    await AnalyzeWithAI(pdfText, Path.GetFileName(pdfPath));
}
```

### Sayfa Bazlı Analiz

Her sayfayı ayrı ayrı analiz etmek için:

```csharp
using PdfDocument pdf = PdfDocument.Open(path);

foreach (var page in pdf.GetPages())
{
    string pageText = page.Text;
    await AnalyzeWithAI(pageText, $"Sayfa {page.Number}");
}
```

### Çıktıyı Dosyaya Kaydetme

Analiz sonuçlarını kaydetmek için:

```csharp
string summary = await AnalyzeWithAI(pdfText, "Pdf İçeriği");
string outputPath = Path.ChangeExtension(pdfPath, ".summary.txt");
await File.WriteAllTextAsync(outputPath, summary);
Console.WriteLine($"Özet kaydedildi: {outputPath}");
```

### Sayfa Numaraları ile Referanslama

Hangi bilginin hangi sayfada olduğunu belirtmek için:

```csharp
async Task<string> ExtractTextWithPageNumbers(string path)
{
    StringBuilder textBuilder = new StringBuilder();
    using PdfDocument pdf = PdfDocument.Open(path);

    foreach (var page in pdf.GetPages())
    {
        textBuilder.AppendLine($"\n[SAYFA {page.Number}]");
        textBuilder.AppendLine(page.Text);
    }

    return textBuilder.ToString();
}
```

## 📊 Performans İpuçları

### Token Limiti Yönetimi

Uzun PDF'ler için metin sınırlama:

```csharp
const int maxChars = 12000; // ~3000 token
if (pdfText.Length > maxChars)
{
    // İlk X karakter + son Y karakter
    string beginning = pdfText.Substring(0, maxChars / 2);
    string ending = pdfText.Substring(pdfText.Length - maxChars / 2);
    pdfText = beginning + "\n\n[...ortası atlandı...]\n\n" + ending;
}
```

### Chunk-Based Analiz

Büyük PDF'leri parçalara ayırarak analiz:

```csharp
async Task<string> AnalyzeLargePdf(string path)
{
    string fullText = await ExtractTextFromPdf(path);
    var chunks = SplitIntoChunks(fullText, 10000);
    var summaries = new List<string>();
    
    foreach (var chunk in chunks)
    {
        var summary = await AnalyzeWithAI(chunk, "PDF Bölümü");
        summaries.Add(summary);
    }
    
    // Özetleri birleştir ve final özet oluştur
    string combinedSummary = string.Join("\n\n", summaries);
    return await AnalyzeWithAI(combinedSummary, "Birleştirilmiş Özet");
}

List<string> SplitIntoChunks(string text, int chunkSize)
{
    var chunks = new List<string>();
    for (int i = 0; i < text.Length; i += chunkSize)
    {
        int length = Math.Min(chunkSize, text.Length - i);
        chunks.Add(text.Substring(i, length));
    }
    return chunks;
}
```

## 🔍 İçerik Çıkarma Teknikleri

### Tablolar

PDF'deki tabloları çıkarmak için:

```csharp
using PdfDocument pdf = PdfDocument.Open(path);
var page = pdf.GetPage(1);

var letters = page.Letters;
// Tablo algılama ve çıkarma mantığı
```

### Görüntüler

PDF'deki görselleri çıkarmak için:

```csharp
using PdfDocument pdf = PdfDocument.Open(path);
var page = pdf.GetPage(1);

var images = page.GetImages();
foreach (var image in images)
{
    // Görüntüyü kaydet
    var bytes = image.RawBytes.ToArray();
    File.WriteAllBytes($"image_{image.GetHashCode()}.jpg", bytes);
}
```

## 🔒 Güvenlik ve Gizlilik

### Şifreli PDF'ler

Şifre korumalı PDF'leri açmak için:

```csharp
var pdfDocument = PdfDocument.Open(path, new ParsingOptions
{
    Password = "your-password"
});
```

### Hassas Bilgi Maskeleme

Kişisel verileri maskelemek için:

```csharp
string MaskSensitiveData(string text)
{
    // Email maskeleme
    text = Regex.Replace(text, @"\b[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Z|a-z]{2,}\b", "[EMAIL]");
    
    // Telefon maskeleme
    text = Regex.Replace(text, @"\b\d{10,11}\b", "[PHONE]");
    
    // TC Kimlik No maskeleme
    text = Regex.Replace(text, @"\b\d{11}\b", "[TC_ID]");
    
    return text;
}
```

## 📝 API Limitleri ve Fiyatlandırma

- **GPT-3.5-turbo**: ~$0.0005 / 1K token (input), ~$0.0015 / 1K token (output)
- Ortalama bir PDF (10 sayfa): ~3000-5000 token
- 100 PDF analizi maliyeti: ~$1.50 - $3.00

## 🐛 Hata Ayıklama

### "PDF açılamıyor" hatası:

```csharp
try
{
    using PdfDocument pdf = PdfDocument.Open(path);
}
catch (Exception ex)
{
    Console.WriteLine($"PDF açma hatası: {ex.Message}");
    // Dosyanın geçerli bir PDF olduğunu kontrol edin
}
```

### Bozuk karakterler:

Encoding sorunları için:

```csharp
var options = new ParsingOptions
{
    UseLenientParsing = true
};
using PdfDocument pdf = PdfDocument.Open(path, options);
```

### Boş metin çıktısı:

Bazı PDF'ler görüntü tabanlı olabilir (OCR gerektirir):

```bash
dotnet add package Tesseract
# Tesseract ile OCR işlemi yapın
```

## 📚 İlgili Kaynaklar

- [PdfPig Documentation](https://uglytoad.github.io/PdfPig/)
- [PDF Format Specification](https://www.adobe.com/devnet/pdf/pdf_reference.html)
- [OpenAI Text Extraction Guide](https://platform.openai.com/docs/guides/text-generation)

## 🆚 Alternatif Kütüphaneler

| Kütüphane | Özellikler | Lisans |
|-----------|-----------|--------|
| **PdfPig** | Hafif, hızlı, açık kaynak | Apache 2.0 |
| iTextSharp | Kapsamlı, ticari | AGPL/Ticari |
| PDFsharp | .NET native, oluşturma | MIT |
| Aspose.PDF | Çok özellikli, ücretli | Ticari |

## 👨‍💻 Geliştirici

**Emir TARTAR**
- GitHub: [@etartar](https://github.com/etartar)

## 📄 Lisans

Bu proje eğitim amaçlıdır.
