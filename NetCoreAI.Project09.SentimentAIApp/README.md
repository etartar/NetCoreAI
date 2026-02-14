# 😊 NetCoreAI.Project09 - Sentiment Analysis

OpenAI GPT-3.5-turbo API kullanarak metin duygu analizi yapan .NET 10 konsol uygulaması. Verilen metindeki duyguyu (Positive, Negative, Neutral) tespit eder.

## 📋 Özellikler

- ✅ OpenAI GPT-3.5-turbo modeli ile duygu analizi
- ✅ 3 kategori: Positive (Olumlu), Negative (Olumsuz), Neutral (Nötr)
- ✅ User Secrets ile güvenli API key yönetimi
- ✅ Hızlı ve doğru analiz sonuçları
- ✅ Çok dilli destek

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
cd NetCoreAI/NetCoreAI.Project09.SentimentAIApp
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

Uygulama çalıştığında analiz etmek istediğiniz metni girin:

```
Lütfen Metni Giriniz: Bu ürün harika, çok memnun kaldım!

Duygu Analizi Yapılıyor...
Duygu Analizi Sonucu: Positive
```

### Örnek Analizler:

**Olumlu Metin:**
```
Input:  Bu harika bir deneyimdi, kesinlikle tavsiye ederim!
Output: Positive
```

**Olumsuz Metin:**
```
Input:  Çok kötü bir hizmet, asla bir daha kullanmam.
Output: Negative
```

**Nötr Metin:**
```
Input:  Ürün sipariş edildi ve kargo ile gönderildi.
Output: Neutral
```

**Karışık Duygular:**
```
Input:  Ürün kaliteli ama fiyatı biraz pahalı.
Output: Neutral (veya Positive - bağlama göre değişebilir)
```

## 🎯 Kullanım Alanları

### E-Ticaret
- Müşteri yorumları analizi
- Ürün değerlendirmeleri
- Müşteri memnuniyeti ölçümü

### Sosyal Medya
- Tweet analizi
- Marka algısı tespiti
- Kriz yönetimi

### Müşteri Hizmetleri
- Destek talebi önceliklendirme
- Müşteri geri bildirimi analizi
- Şikayet tespiti

### İnsan Kaynakları
- Çalışan memnuniyeti analizi
- Anket değerlendirmeleri
- Geri bildirim analizi

## 🔧 Yapılandırma

### Farklı Dillerde Analiz

API otomatik olarak dili algılar, ekstra yapılandırma gerekmez:

```csharp
// Türkçe
Input: "Bu film mükemmeldi!"
Output: Positive

// İngilizce
Input: "This movie was terrible."
Output: Negative

// İspanyolca
Input: "No está mal, pero podría ser mejor."
Output: Neutral
```

### GPT-4 ile Daha Gelişmiş Analiz

Daha hassas sonuçlar için GPT-4 kullanabilirsiniz:

```csharp
var requestBody = new
{
    model = "gpt-4", // veya "gpt-4-turbo"
    messages = new[]
    {
        new { role = "system", content = "You are an AI that analyzes sentiment. You categorize text as Positive, Negative or Neutral." },
        new { role = "user", content = $"Analyze the sentiment of this text: {input} and return only Positive, Negative or Neutral" }
    }
};
```

### Özel Kategoriler

Kendi kategorilerinizi tanımlayabilirsiniz:

```csharp
new { role = "system", content = "You are an AI that analyzes sentiment. You categorize text as: VeryPositive, Positive, Neutral, Negative, VeryNegative." }
```

## 📊 Duygu Kategorileri

| Kategori | Açıklama | Örnek |
|----------|----------|-------|
| **Positive** | Olumlu duygular içeren metinler | "Harika!", "Mükemmel hizmet", "Çok mutluyum" |
| **Negative** | Olumsuz duygular içeren metinler | "Berbat", "Asla tavsiye etmem", "Çok kötü" |
| **Neutral** | Nötr veya bilgilendirici metinler | "Ürün geldi", "Sipariş alındı", "Normal" |

## 📝 API Limitleri ve Fiyatlandırma

- **GPT-3.5-turbo**: ~$0.0005 / 1K token (input), ~$0.0015 / 1K token (output)
- **GPT-4**: ~$0.03 / 1K token (input), ~$0.06 / 1K token (output)
- Rate limit bilgisi için [OpenAI Rate Limits](https://platform.openai.com/docs/guides/rate-limits) sayfasını kontrol edin

### Maliyet Tahmini

Örnek kullanım: 1000 analiz (ortalama 20 kelime):
- **GPT-3.5-turbo**: ~$0.05 - $0.10
- **GPT-4**: ~$1.00 - $2.00

## 🔒 Güvenlik

- API anahtarınızı asla kaynak koduna yazmayın
- User Secrets veya ortam değişkenleri kullanın
- Production ortamlarında Azure Key Vault kullanın
- Kullanıcı girişlerini sanitize edin

## 🐛 Hata Ayıklama

### "API Key bulunamadı" hatası:

```bash
dotnet user-secrets set "OpenAI:ApiKey" "YOUR_OPENAI_API_KEY"
```

### HTTP 401 Unauthorized hatası:
- API key'inizin doğru olduğundan emin olun
- OpenAI hesabınızda kredi olup olmadığını kontrol edin

### "Geçerli bir metin giriniz" mesajı:
- Boş metin göndermeyin
- En az bir karakter içeren metin girin

### Tutarsız sonuçlar:
- AI modelleri bazen aynı metin için farklı sonuçlar verebilir
- Daha tutarlı sonuçlar için GPT-4 kullanın
- Temperature parametresini 0'a ayarlayarak belirleyiciliği artırın:

```csharp
var requestBody = new
{
    model = "gpt-3.5-turbo",
    temperature = 0, // 0 = belirleyici, 1 = yaratıcı
    messages = new[] { ... }
};
```

## 🚀 Gelişmiş Kullanım

### Toplu Analiz

Birden fazla metni toplu olarak analiz etmek için:

```csharp
string[] texts = 
{
    "Bu harika!",
    "Çok kötü deneyim.",
    "Normal bir ürün."
};

foreach (var text in texts)
{
    string sentiment = await SentimentAnalyzeAsync(text, apiKey);
    Console.WriteLine($"{text} -> {sentiment}");
}
```

### Güven Skoru Ekleme

Sistem mesajını değiştirerek güven skorları alabilirsiniz:

```csharp
new { role = "system", content = "Analyze sentiment and return format: 'Positive (95%)' or 'Negative (80%)' or 'Neutral (60%)'" }
```

## 📚 İlgili Kaynaklar

- [OpenAI API Documentation](https://platform.openai.com/docs/api-reference)
- [OpenAI Chat Completions Guide](https://platform.openai.com/docs/guides/chat)
- [Sentiment Analysis Best Practices](https://platform.openai.com/docs/guides/text-generation/sentiment-analysis)

## 🆚 Project09 vs Project10

| Özellik | Project09 | Project10 |
|---------|-----------|-----------|
| **Analiz Türü** | Basit (3 kategori) | Gelişmiş (6 duygu + yüzdeler) |
| **Çıktı** | Positive/Negative/Neutral | JSON formatında detaylı skorlar |
| **Kullanım** | Hızlı kategorizasyon | Detaylı duygu profili |
| **Kullanım Alanı** | Genel amaçlı | Araştırma, detaylı analiz |

> **İpucu:** Basit kategorizasyon için Project09, detaylı duygu analizi için Project10 kullanın.

## 👨‍💻 Geliştirici

**Emir TARTAR**
- GitHub: [@etartar](https://github.com/etartar)

## 📄 Lisans

Bu proje eğitim amaçlıdır.
