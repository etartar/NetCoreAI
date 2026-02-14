# 🎨 NetCoreAI.Project03 - DALL-E Image Generation

OpenAI DALL-E API kullanarak metin açıklamalarından (text prompts) görsel üreten .NET 10 konsol uygulaması.

## 📋 Özellikler

- ✅ OpenAI DALL-E API ile görsel oluşturma
- ✅ User Secrets ile güvenli API key yönetimi
- ✅ 1024x1024 çözünürlükte görsel üretimi
- ✅ Özelleştirilebilir prompt desteği

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
cd NetCoreAI/NetCoreAI.Project03.DALL-EImageGeneration
```

### 2. API Key'i kaydedin

```bash
dotnet user-secrets set "OpenAI:ApiKey" "YOUR_OPENAI_API_KEY"
```

### 3. Bağımlılıkları yükleyin

```bash
dotnet restore
```

### 4. Uygulamayı çalıştırın

```bash
dotnet run
```

## 💡 Kullanım

Uygulama çalıştığında, oluşturmak istediğiniz görselin açıklamasını (prompt) girin:

```
Example prompts: 
> A futuristic city at sunset with flying cars

Generated Image URL: https://oaidalleapiprodscus.blob.core.windows.net/...
```

### Örnek Prompt'lar:

- "A serene landscape with mountains and a lake at sunrise"
- "A cyberpunk cat wearing neon glasses in a rainy city"
- "An astronaut riding a horse on Mars"
- "Abstract art with vibrant colors and geometric shapes"

## 🔧 Yapılandırma

Görsel ayarlarını değiştirmek için `Program.cs` dosyasındaki `requestBody` nesnesini düzenleyebilirsiniz:

```csharp
var requestBody = new
{
    prompt = prompt,
    n = 1,              // Oluşturulacak görsel sayısı (1-10 arası)
    size = "1024x1024"  // Görsel boyutu: "256x256", "512x512", "1024x1024"
};
```

## 📝 API Limitleri

- DALL-E 2: `256x256`, `512x512`, `1024x1024`
- DALL-E 3: `1024x1024`, `1024x1792`, `1792x1024`
- Her istekte 1-10 arası görsel oluşturabilirsiniz
- Rate limit ve pricing bilgisi için [OpenAI Pricing](https://openai.com/pricing) sayfasını kontrol edin

## 🔒 Güvenlik

⚠️ **ÖNEMLİ**: API key'inizi asla kaynak kodda saklamayın veya Git'e commit etmeyin!

Bu proje User Secrets kullanarak API key'i güvenli bir şekilde saklar. User secrets dosyaları:

- **Windows**: `%APPDATA%\Microsoft\UserSecrets\netcoreai-project03-secrets\secrets.json`
- **Linux/macOS**: `~/.microsoft/usersecrets/netcoreai-project03-secrets/secrets.json`

## 📚 Kaynaklar

- [OpenAI DALL-E API Documentation](https://platform.openai.com/docs/guides/images)
- [.NET User Secrets](https://learn.microsoft.com/en-us/aspnet/core/security/app-secrets)
- [OpenAI API Reference](https://platform.openai.com/docs/api-reference/images)

## 🐛 Sorun Giderme

### "API Key bulunamadı" hatası alıyorsanız:

```bash
cd NetCoreAI.Project03.DALL-EImageGeneration
dotnet user-secrets set "OpenAI:ApiKey" "YOUR_API_KEY"
```

### HTTP 401 Unauthorized hatası alıyorsanız:

- API key'inizin geçerli olduğundan emin olun
- OpenAI hesabınızda kredi bakiyeniz olup olmadığını kontrol edin

### HTTP 429 Rate Limit hatası alıyorsanız:

- Çok fazla istek göndermiş olabilirsiniz
- Birkaç dakika bekleyip tekrar deneyin

## 📄 Lisans

Bu proje eğitim amaçlıdır.

## 👨‍💻 Geliştirici

**Emir TARTAR**
- GitHub: [@etartar](https://github.com/etartar)

---

⭐ Projeyi beğendiyseniz yıldız vermeyi unutmayın!
