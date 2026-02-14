# 🌍 NetCoreAI.Project06 - OpenAI Translate

OpenAI GPT-3.5-turbo API kullanarak çok dilli metin çeviri uygulaması. Herhangi bir dildeki metni İngilizceye çeviren .NET 10 konsol uygulaması.

## 📋 Özellikler

- ✅ OpenAI GPT-3.5-turbo modeli ile çeviri
- ✅ User Secrets ile güvenli API key yönetimi
- ✅ Çok dilli destek (Türkçe, Fransızca, İspanyolca vb. → İngilizce)
- ✅ Hata yönetimi ve kullanıcı dostu mesajlar
- ✅ JSON tabanlı API iletişimi

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
cd NetCoreAI/NetCoreAI.Project06.OpenAITranslate
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

Uygulama çalıştığında, çevirmek istediğiniz metni girin:

```
Lütfen çevirmek istediğiniz cümleyi giriniz: Merhaba, nasılsın?

Translated Text: Hello, how are you?
```

### Örnek Çeviriler:

**Türkçe → İngilizce:**
```
Input:  Bugün hava çok güzel.
Output: The weather is very nice today.
```

**Fransızca → İngilizce:**
```
Input:  Bonjour, comment allez-vous?
Output: Hello, how are you?
```

**İspanyolca → İngilizce:**
```
Input:  ¿Dónde está la biblioteca?
Output: Where is the library?
```

**Almanca → İngilizce:**
```
Input:  Ich liebe Programmierung.
Output: I love programming.
```

## 🔧 Yapılandırma

### Farklı Çeviri Yönleri İçin Özelleştirme

`TranslateTextToEnglishAsync` metodunu değiştirerek farklı çeviri senaryoları oluşturabilirsiniz:

```csharp
// İngilizceye çevirme (varsayılan)
new { role = "user", content = $"Translate the following text to English: {inputText}" }

// Türkçeye çevirme
new { role = "user", content = $"Translate the following text to Turkish: {inputText}" }

// Dil tespiti ile çevirme
new { role = "user", content = $"Detect the language and translate to English: {inputText}" }

// Resmi dil ile çevirme
new { role = "system", content = "You are a professional translator." },
new { role = "user", content = $"Translate formally to English: {inputText}" }
```

### Model Değiştirme

Daha iyi çeviri kalitesi için GPT-4 kullanabilirsiniz:

```csharp
var requestBody = new
{
    model = "gpt-4",  // veya "gpt-4-turbo"
    messages = new[]
    {
        new { role = "system", content = "You are a helpful assistant that translates text." },
        new { role = "user", content = $"Translate the following text to English: {inputText}" }
    }
};
```

## 📊 Desteklenen Diller

OpenAI modelleri şu dilleri destekler (sınırlı değildir):

- 🇹🇷 Türkçe
- 🇫🇷 Fransızca
- 🇪🇸 İspanyolca
- 🇩🇪 Almanca
- 🇮🇹 İtalyanca
- 🇵🇹 Portekizce
- 🇷🇺 Rusça
- 🇯🇵 Japonca
- 🇰🇷 Korece
- 🇨🇳 Çince
- 🇸🇦 Arapça
- ve daha fazlası...

## 📝 API Limitleri ve Fiyatlandırma

- **GPT-3.5-turbo**: ~$0.0005 / 1K token (input), ~$0.0015 / 1K token (output)
- **GPT-4**: ~$0.03 / 1K token (input), ~$0.06 / 1K token (output)
- Rate limit bilgisi için [OpenAI Rate Limits](https://platform.openai.com/docs/guides/rate-limits) sayfasını kontrol edin

## 🔒 Güvenlik

- API anahtarınızı asla kaynak koduna yazmayın
- User Secrets veya ortam değişkenleri kullanın
- Production ortamlarında Azure Key Vault veya benzeri servisleri tercih edin

## 🐛 Hata Ayıklama

### "API Key bulunamadı" hatası:

```bash
dotnet user-secrets set "OpenAI:ApiKey" "YOUR_OPENAI_API_KEY"
```

### HTTP 401 Unauthorized hatası:
- API key'inizin doğru olduğundan emin olun
- OpenAI hesabınızda kredi olup olmadığını kontrol edin

### HTTP 429 Rate Limit hatası:
- Çok fazla istek gönderiyor olabilirsiniz
- Birkaç saniye bekleyip tekrar deneyin

## 📚 İlgili Kaynaklar

- [OpenAI API Documentation](https://platform.openai.com/docs/api-reference)
- [OpenAI Chat Completions Guide](https://platform.openai.com/docs/guides/chat)
- [.NET User Secrets](https://learn.microsoft.com/en-us/aspnet/core/security/app-secrets)

## 👨‍💻 Geliştirici

**Emir TARTAR**
- GitHub: [@etartar](https://github.com/etartar)

## 📄 Lisans

Bu proje eğitim amaçlıdır.
