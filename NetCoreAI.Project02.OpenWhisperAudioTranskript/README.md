# 🎙️ NetCoreAI.Project02 - OpenAI Whisper Audio Transcript

OpenAI Whisper API kullanarak ses dosyalarını metne dönüştüren .NET 10 konsol uygulaması. Ses kaydı transkripsiyonu için güçlü ve doğru bir çözüm.

## 📋 Özellikler

- ✅ OpenAI Whisper API ile ses dosyası transkripsiyonu
- ✅ MP3 formatında ses dosyası desteği
- ✅ User Secrets ile güvenli API key yönetimi
- ✅ Yüksek doğrulukta metin dönüşümü
- ✅ Hata yönetimi ve kullanıcı dostu mesajlar

## 🛠️ Gereksinimler

- .NET 10 SDK
- OpenAI API Key ([OpenAI Platform](https://platform.openai.com/api-keys) üzerinden alabilirsiniz)
- Transkript edilecek ses dosyası (MP3, WAV, M4A, vb.)

## 📦 Kullanılan Paketler

```xml
<PackageReference Include="Microsoft.Extensions.Configuration.UserSecrets" Version="9.0.0" />
```

## 🚀 Kurulum

### 1. Projeyi klonlayın veya indirin

```bash
git clone https://github.com/etartar/NetCoreAI
cd NetCoreAI/NetCoreAI.Project02.OpenWhisperAudioTranskript
```

### 2. API Key'i kaydedin

```bash
dotnet user-secrets set "OpenAI:ApiKey" "YOUR_OPENAI_API_KEY"
```

> **Not:** API key'inizi [OpenAI Platform](https://platform.openai.com/api-keys) adresinden oluşturabilirsiniz.

### 3. Ses dosyanızı projeye ekleyin

Transkript edilecek ses dosyasını proje klasörüne kopyalayın veya `Program.cs` dosyasında dosya yolunu güncelleyin:

```csharp
string audioFilePath = "audio1.mp3";  // Buraya kendi dosya yolunuzu yazın
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

Uygulama çalıştığında ses dosyanız otomatik olarak işlenecek ve transkript edilecektir:

```
Ses Dosyası İşleniyor, Lütfen Bekleyiniz...

Transcription:
{
  "text": "Merhaba, bu bir ses dosyası transkript örneğidir..."
}
```

## 🎵 Desteklenen Ses Formatları

Whisper API aşağıdaki ses formatlarını destekler:

- MP3
- MP4
- MPEG
- MPGA
- M4A
- WAV
- WEBM

**Maksimum dosya boyutu**: 25 MB

## 🔧 Yapılandırma

### Farklı Ses Dosyası Kullanma

`Program.cs` dosyasında ses dosyası yolunu değiştirin:

```csharp
string audioFilePath = "C:/MyAudio/interview.mp3";
```

veya göreli yol kullanın:

```csharp
string audioFilePath = "recordings/meeting.wav";
```

### Content Type Ayarlama

Farklı ses formatları için content type'ı güncelleyin:

```csharp
// MP3 için
fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse("audio/mpeg");

// WAV için
fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse("audio/wav");

// M4A için
fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse("audio/m4a");
```

## 📝 API Limitleri ve Fiyatlandırma

- **Model**: whisper-1
- **Fiyat**: $0.006 / dakika
- **Maksimum dosya boyutu**: 25 MB
- **Diller**: 50+ dil desteği (otomatik algılama)

Daha fazla bilgi için [OpenAI Pricing](https://openai.com/pricing) sayfasını kontrol edin.

## 🌍 Dil Desteği

Whisper API, dil belirtmeden otomatik algılama yapabilir. İsterseniz dil parametresi ekleyebilirsiniz:

```csharp
multipartContent.Add(new StringContent("tr"), "language");  // Türkçe
```

Desteklenen diller: İngilizce, Türkçe, Almanca, Fransızca, İspanyolça, İtalyanca, Japonca, Korece, Çince ve 50+ dil.

## 🔒 Güvenlik

⚠️ **ÖNEMLİ**: API key'inizi asla kaynak kodda saklamayın veya Git'e commit etmeyin!

Bu proje User Secrets kullanarak API key'i güvenli bir şekilde saklar. User secrets dosyaları:

- **Windows**: `%APPDATA%\Microsoft\UserSecrets\netcoreai-project02-secrets\secrets.json`
- **Linux/macOS**: `~/.microsoft/usersecrets/netcoreai-project02-secrets/secrets.json`

## 📚 Kaynaklar

- [OpenAI Whisper API Documentation](https://platform.openai.com/docs/guides/speech-to-text)
- [.NET User Secrets](https://learn.microsoft.com/en-us/aspnet/core/security/app-secrets)
- [OpenAI Audio API Reference](https://platform.openai.com/docs/api-reference/audio)
- [Whisper Model Details](https://openai.com/research/whisper)

## 🐛 Sorun Giderme

### "API Key bulunamadı" hatası alıyorsanız:

```bash
cd NetCoreAI.Project02.OpenWhisperAudioTranskript
dotnet user-secrets set "OpenAI:ApiKey" "YOUR_API_KEY"
```

### HTTP 401 Unauthorized hatası alıyorsanız:

- API key'inizin geçerli olduğundan emin olun
- OpenAI hesabınızda kredi bakiyeniz olup olmadığını kontrol edin

### "File not found" hatası alıyorsanız:

- Ses dosyanızın doğru konumda olduğundan emin olun
- Dosya yolunu tam path olarak belirtin

```csharp
string audioFilePath = @"C:\MyProject\audio1.mp3";
```

### Dosya çok büyük hatası alıyorsanız:

- Ses dosyanız 25 MB'dan küçük olmalıdır
- Büyük dosyaları önce sıkıştırın veya bölerek gönderim

### HTTP 429 Rate Limit hatası alıyorsanız:

- Çok fazla istek göndermiş olabilirsiniz
- Birkaç dakika bekleyip tekrar deneyin

## 🎯 Geliştirme Fikirleri

- Birden fazla ses dosyasını toplu işleme
- Ses dosyasını parçalara bölerek uzun kayıtları işleme
- Transkripti dosyaya kaydetme (.txt, .json)
- Zaman damgalı transkript oluşturma
- Gerçek zamanlı ses kaydı ve transkript
- Farklı dillerde transkript desteği

## 📄 Lisans

Bu proje eğitim amaçlıdır.

## 👨‍💻 Geliştirici

**Emir Tartar**
- GitHub: [@etartar](https://github.com/etartar)

---

⭐ Projeyi beğendiyseniz yıldız vermeyi unutmayın!
