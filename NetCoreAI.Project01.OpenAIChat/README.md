# 💬 NetCoreAI.Project01 - OpenAI Chat

OpenAI GPT-3.5-turbo API kullanarak yapay zeka destekli sohbet uygulaması. Kullanıcıların sorularına akıllı yanıtlar üreten .NET 10 konsol uygulaması.

## 📋 Özellikler

- ✅ OpenAI GPT-3.5-turbo modeli ile sohbet
- ✅ User Secrets ile güvenli API key yönetimi
- ✅ Özelleştirilebilir maksimum token limiti (500 token)
- ✅ Hata yönetimi ve kullanıcı dostu mesajlar

## 🛠️ Gereksinimler

- .NET 10 SDK
- OpenAI API Key ([OpenAI Platform](https://platform.openai.com/api-keys) üzerinden alabilirsiniz)

## 📦 Kullanılan Paketler

```xml
<PackageReference Include="Microsoft.Extensions.Configuration.UserSecrets" Version="9.0.0" />
```

## 🚀 Kurulum

### 1. Projeyi klonlayın veya indirin

```bash
git clone https://github.com/etartar/NetCoreAI
cd NetCoreAI/NetCoreAI.Project01.OpenAIChat
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

Uygulama çalıştığında, sorunuzu yazın ve AI asistanından yanıt alın:

```
Lütfen sorunuzu yazınız:
> .NET 10'un yeni özellikleri nelerdir?

AI: .NET 10, performans iyileştirmeleri, yeni C# 14 özellikleri ve gelişmiş bulut entegrasyonları sunmaktadır...
```

### Örnek Sorular:

- "Python ile C# arasındaki farklar nelerdir?"
- "RESTful API nedir ve nasıl çalışır?"
- "Docker container'ı nasıl oluşturulur?"
- "SOLID prensipleri nelerdir?"

## 🔧 Yapılandırma

### Model ve Token Ayarları

`Program.cs` dosyasında şu ayarları değiştirebilirsiniz:

```csharp
var requestBody = new
{
    model = "gpt-3.5-turbo",  // Model: "gpt-3.5-turbo", "gpt-4", "gpt-4-turbo"
    messages = new[]
    {
        new { role = "system", content = "You are a helpful assistant." },
        new { role = "user", content = prompt! },
    },
    max_tokens = 500  // Maksimum yanıt uzunluğu (token cinsinden)
};
```

### Kullanılabilir Modeller:

- **gpt-3.5-turbo**: Hızlı ve ekonomik
- **gpt-4**: Daha gelişmiş akıl yürütme
- **gpt-4-turbo**: GPT-4'ün daha hızlı versiyonu

## 📝 API Limitleri ve Fiyatlandırma

- **GPT-3.5-turbo**: ~$0.0005 / 1K token (input), ~$0.0015 / 1K token (output)
- **GPT-4**: ~$0.03 / 1K token (input), ~$0.06 / 1K token (output)
- Rate limit bilgisi için [OpenAI Rate Limits](https://platform.openai.com/docs/guides/rate-limits) sayfasını kontrol edin

## 🔒 Güvenlik

⚠️ **ÖNEMLİ**: API key'inizi asla kaynak kodda saklamayın veya Git'e commit etmeyin!

Bu proje User Secrets kullanarak API key'i güvenli bir şekilde saklar. User secrets dosyaları:

- **Windows**: `%APPDATA%\Microsoft\UserSecrets\netcoreai-project01-secrets\secrets.json`
- **Linux/macOS**: `~/.microsoft/usersecrets/netcoreai-project01-secrets/secrets.json`

## 📚 Kaynaklar

- [OpenAI Chat Completions API](https://platform.openai.com/docs/guides/text-generation)
- [.NET User Secrets](https://learn.microsoft.com/en-us/aspnet/core/security/app-secrets)
- [OpenAI API Reference](https://platform.openai.com/docs/api-reference/chat)
- [Best Practices for Prompt Engineering](https://platform.openai.com/docs/guides/prompt-engineering)

## 🐛 Sorun Giderme

### "API Key bulunamadı" hatası alıyorsanız:

```bash
cd NetCoreAI.Project01.OpenAIChat
dotnet user-secrets set "OpenAI:ApiKey" "YOUR_API_KEY"
```

### HTTP 401 Unauthorized hatası alıyorsanız:

- API key'inizin geçerli olduğundan emin olun
- OpenAI hesabınızda kredi bakiyeniz olup olmadığını kontrol edin

### HTTP 429 Rate Limit hatası alıyorsanız:

- Çok fazla istek göndermiş olabilirsiniz
- Birkaç dakika bekleyip tekrar deneyin
- Ücretsiz plan kullanıyorsanız, dakikalık limit aşılmış olabilir

### Yanıtlar çok kısa veya kesiliyorsa:

- `max_tokens` değerini artırın (örn: 1000, 2000)
- Daha fazla token daha fazla maliyet demektir

## 🎯 Geliştirme Fikirleri

- Sohbet geçmişini saklama
- Çoklu mesaj desteği (conversation history)
- Farklı system prompt'ları deneme
- Stream yanıt desteği ekleme
- GUI arayüz ekleme

## 📄 Lisans

Bu proje eğitim amaçlıdır.

## 👨‍💻 Geliştirici

**Emir TARTAR**
- GitHub: [@etartar](https://github.com/etartar)

---

⭐ Projeyi beğendiyseniz yıldız vermeyi unutmayın!
