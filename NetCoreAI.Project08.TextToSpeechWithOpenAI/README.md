# 🎙️ NetCoreAI.Project08 - Text to Speech with OpenAI

OpenAI Text-to-Speech (TTS) API kullanarak metni yüksek kaliteli sese dönüştüren .NET 10 konsol uygulaması. Gerçekçi ve doğal ses çıktıları için güçlü bir çözüm.

## 📋 Özellikler

- ✅ OpenAI TTS-1 modeli ile metin okuma
- ✅ 6 farklı ses seçeneği (alloy, echo, fable, onyx, nova, shimmer)
- ✅ Yüksek kaliteli MP3 ses dosyası oluşturma
- ✅ User Secrets ile güvenli API key yönetimi
- ✅ Otomatik dosya açma özelliği
- ✅ Çok dilli destek

## 🛠️ Gereksinimler

- .NET 10 SDK
- OpenAI API Key ([OpenAI Platform](https://platform.openai.com/api-keys) üzerinden alabilirsiniz)
- Windows işletim sistemi (explorer.exe kullanımı için)

## 📦 Kullanılan Paketler

```xml
<PackageReference Include="Microsoft.Extensions.Configuration.UserSecrets" Version="10.0.3" />
```

## 🚀 Kurulum

### 1. Projeyi klonlayın veya indirin

```bash
git clone https://github.com/etartar/NetCoreAI
cd NetCoreAI/NetCoreAI.Project08.TextToSpeechWithOpenAI
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

Uygulama çalıştığında metninizi girin ve ses dosyası otomatik olarak oluşturulacaktır:

```
Metni Giriniz: Merhaba, bu OpenAI Text-to-Speech API örneğidir.

Ses dosyası oluşturuluyor...
Ses dosyası 'output.mp3' olarak kaydedildi.
```

Ses dosyası otomatik olarak Windows Explorer'da açılacaktır.

### Örnek Kullanımlar:

**Türkçe Metin:**
```
Metni Giriniz: Yapay zeka teknolojileri hayatımızı kolaylaştırıyor.
```

**İngilizce Metin:**
```
Metni Giriniz: Artificial intelligence is transforming the world.
```

**Uzun Metin:**
```
Metni Giriniz: OpenAI's text-to-speech API can generate natural sounding speech from text. It supports multiple languages and various voice options.
```

## 🎵 Ses Seçenekleri

OpenAI TTS API 6 farklı ses tonu sunar:

| Ses | Açıklama | Karakter |
|-----|----------|----------|
| **alloy** | Dengeli, nötr ses | ⚖️ Nötral |
| **echo** | Erkek, net ve güçlü | 💪 Güçlü |
| **fable** | İngiliz aksanı, dramatik | 🎭 Dramatik |
| **onyx** | Derin erkek sesi | 🎙️ Derin |
| **nova** | Genç kadın sesi | 🌟 Dinamik |
| **shimmer** | Yumuşak kadın sesi | ✨ Yumuşak |

### Sesi Değiştirme

`Program.cs` dosyasında `voice` parametresini değiştirin:

```csharp
var requestBody = new
{
    model = "tts-1",
    input = inputText,
    voice = "nova" // İstediğiniz sesi seçin
};
```

## 🔧 Yapılandırma

### HD Kalite İçin TTS-1-HD Kullanımı

Daha yüksek kalite için TTS-1-HD modelini kullanabilirsiniz:

```csharp
var requestBody = new
{
    model = "tts-1-hd", // HD kalite
    input = inputText,
    voice = "alloy"
};
```

**Model Karşılaştırması:**
- **tts-1**: Hızlı, düşük gecikme, standart kalite
- **tts-1-hd**: Yüksek kalite, daha fazla işlem süresi

### Çıktı Dosya Adını Değiştirme

Farklı dosya adı kullanmak için:

```csharp
string outputFileName = $"speech_{DateTime.Now:yyyyMMdd_HHmmss}.mp3";
await File.WriteAllBytesAsync(outputFileName, audioBytes);
Console.WriteLine($"Ses dosyası '{outputFileName}' olarak kaydedildi.");
System.Diagnostics.Process.Start("explorer.exe", outputFileName);
```

### Otomatik Dosya Açmayı Devre Dışı Bırakma

Explorer otomatik açılmasını istemiyorsanız, bu satırı yoruma alın:

```csharp
// System.Diagnostics.Process.Start("explorer.exe", "output.mp3");
```

## 🌍 Dil Desteği

OpenAI TTS API çok sayıda dili destekler:

- 🇹🇷 Türkçe
- 🇺🇸 İngilizce
- 🇪🇸 İspanyolca
- 🇫🇷 Fransızca
- 🇩🇪 Almanca
- 🇮🇹 İtalyanca
- 🇵🇹 Portekizce
- 🇳🇱 Hollandaca
- 🇵🇱 Lehçe
- 🇷🇺 Rusça
- 🇯🇵 Japonca
- 🇰🇷 Korece
- 🇨🇳 Çince
- 🇸🇦 Arapça
- ve daha fazlası...

> **Not:** API otomatik olarak dili algılar, ekstra yapılandırma gerekmez.

## 📝 API Limitleri ve Fiyatlandırma

### TTS-1 Model:
- **Fiyat**: ~$15.00 / 1M karakter
- **Hız**: Gerçek zamanlıya yakın
- **Kalite**: Standart

### TTS-1-HD Model:
- **Fiyat**: ~$30.00 / 1M karakter
- **Hız**: Daha yavaş
- **Kalite**: Yüksek kalite

### Limitler:
- **Maksimum karakter**: 4096 karakter/istek
- **Rate Limit**: Dakikada 50 istek (ücretsiz katman)

## 🔒 Güvenlik

- API anahtarınızı asla kaynak koduna yazmayın
- User Secrets veya ortam değişkenleri kullanın
- Production ortamlarında Azure Key Vault kullanın
- API key'i versiyon kontrolüne eklemeyin

## 🐛 Hata Ayıklama

### "API Key bulunamadı" hatası:

```bash
dotnet user-secrets set "OpenAI:ApiKey" "YOUR_OPENAI_API_KEY"
```

### HTTP 401 Unauthorized hatası:
- API key'inizin doğru olduğundan emin olun
- OpenAI hesabınızda kredi olup olmadığını kontrol edin
- API key'in doğru formatta olduğunu kontrol edin

### HTTP 429 Rate Limit hatası:
- Çok fazla istek gönderiyor olabilirsiniz
- Birkaç saniye bekleyip tekrar deneyin
- Rate limit kotanızı kontrol edin

### Ses dosyası oluşturuluyor ancak açılmıyor:
- Windows dışında çalışıyorsanız `explorer.exe` çalışmayacaktır
- Dosya yolunu manuel olarak açın
- Varsayılan MP3 oynatıcınızın doğru ayarlandığından emin olun

### "Lütfen geçerli bir metin girin" mesajı:
- Boş metin girmeyin
- En az bir karakter içeren metin girin

## 📊 Performans İpuçları

1. **TTS-1 vs TTS-1-HD**: Prodüksiyon için TTS-1 yeterlidir, özel durumlar için TTS-1-HD kullanın
2. **Metin Uzunluğu**: 4096 karakterden uzun metinler için parçalama yapın
3. **Cache Kullanımı**: Aynı metinleri tekrar üretmek yerine önbellekleyin
4. **Async İşlemler**: Birden fazla dosya için paralel işlem yapabilirsiniz

## 🚀 Gelişmiş Kullanım

### Birden Fazla Ses Dosyası Oluşturma

```csharp
string[] texts = { "Metin 1", "Metin 2", "Metin 3" };
string[] voices = { "alloy", "echo", "nova" };

for (int i = 0; i < texts.Length; i++)
{
    await GenerateSpeechAsync(texts[i], apiKey, voices[i], $"output_{i}.mp3");
}
```

### Format Desteği

Şu anda API şu formatları destekler:
- MP3 (varsayılan)
- OPUS
- AAC
- FLAC

Format değiştirmek için `response_format` parametresini ekleyin:

```csharp
var requestBody = new
{
    model = "tts-1",
    input = inputText,
    voice = "alloy",
    response_format = "opus" // mp3, opus, aac, flac
};
```

## 📚 İlgili Kaynaklar

- [OpenAI TTS API Documentation](https://platform.openai.com/docs/guides/text-to-speech)
- [OpenAI Audio API Reference](https://platform.openai.com/docs/api-reference/audio)
- [OpenAI Pricing](https://openai.com/pricing)
- [.NET User Secrets](https://learn.microsoft.com/en-us/aspnet/core/security/app-secrets)

## 🆚 Project07 vs Project08

| Özellik | Project07 | Project08 |
|---------|-----------|-----------|
| **Teknoloji** | System.Speech | OpenAI TTS API |
| **Platform** | Windows Only | Cross-platform |
| **İnternet** | Offline | Online (API gerekli) |
| **Kalite** | Standart | Yüksek kalite |
| **Maliyet** | Ücretsiz | Ücretli (~$15/1M karakter) |
| **Sesler** | Sistem sesleri | 6 profesyonel ses |
| **Diller** | Sınırlı | 50+ dil |

## 👨‍💻 Geliştirici

**Emir TARTAR**
- GitHub: [@etartar](https://github.com/etartar)

## 📄 Lisans

Bu proje eğitim amaçlıdır.
