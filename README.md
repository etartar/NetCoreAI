# 🤖 NetCoreAI - Yapay Zeka Projeleri Koleksiyonu

.NET 10 ile geliştirilmiş OpenAI, Google Cloud Vision ve Tesseract OCR entegrasyonlarını içeren kapsamlı AI projeleri koleksiyonu.

![.NET](https://img.shields.io/badge/.NET-10.0-512BD4?style=flat-square&logo=dotnet)
![C#](https://img.shields.io/badge/C%23-14.0-239120?style=flat-square&logo=c-sharp)
![License](https://img.shields.io/badge/License-Educational-blue?style=flat-square)

## 📚 Projeler

Bu repository 10 farklı AI projesini içermektedir:

### 1️⃣ [OpenAI Chat](./NetCoreAI.Project01.OpenAIChat) 💬
OpenAI GPT-3.5-turbo API kullanarak yapay zeka destekli sohbet uygulaması.

**Özellikler:**
- ✅ GPT-3.5-turbo model entegrasyonu
- ✅ Özelleştirilebilir token limiti
- ✅ User Secrets ile güvenli API key yönetimi

**Kullanım Alanları:**
- Chatbot geliştirme
- Soru-cevap sistemleri
- Kod asistanı

---

### 2️⃣ [Whisper Audio Transcript](./NetCoreAI.Project02.OpenWhisperAudioTranskript) 🎙️
OpenAI Whisper API ile ses dosyalarını metne dönüştürme.

**Özellikler:**
- ✅ Çoklu ses formatı desteği (MP3, WAV, M4A)
- ✅ 50+ dil desteği
- ✅ Yüksek doğrulukta transkripsiyon

**Kullanım Alanları:**
- Ses kayıtlarını yazıya dökme
- Podcast transkripti
- Toplantı notları oluşturma

---

### 3️⃣ [DALL-E Image Generation](./NetCoreAI.Project03.DALL-EImageGeneration) 🎨
OpenAI DALL-E API ile text-to-image görsel üretimi.

**Özellikler:**
- ✅ Metin açıklamalarından görsel üretme
- ✅ 1024x1024 çözünürlük desteği
- ✅ Özelleştirilebilir prompt'lar

**Kullanım Alanları:**
- Sanatsal görsel üretimi
- Konsept tasarım
- İçerik oluşturma

---

### 4️⃣ [Tesseract OCR](./NetCoreAI.Project04.TesseractOcr) 🔍
Tesseract OCR motoru ile görüntülerden metin çıkarma.

**Özellikler:**
- ✅ Optik karakter tanıma
- ✅ Çoklu dil desteği (Türkçe, İngilizce, vb.)
- ✅ Yüksek doğruluk oranı

**Kullanım Alanları:**
- Belge dijitalleştirme
- Plaka tanıma
- Fatura ve fiş işleme

---

### 5️⃣ [Google Cloud Vision OCR](./NetCoreAI.Project05.GoogleCloudVision) 👁️
Google Cloud Vision API ile bulut tabanlı güçlü görüntü analizi ve metin çıkarma.

**Özellikler:**
- ✅ Bulut tabanlı OCR (Optik Karakter Tanıma)
- ✅ 100+ dil desteği ve otomatik dil algılama
- ✅ Yüksek doğruluk oranı ve metin konum bilgisi
- ✅ Etiket, yüz, logo algılama özellikleri

**Kullanım Alanları:**
- Profesyonel belge dijitalleştirme
- El yazısı tanıma
- Çoklu dil OCR işlemleri
- Görüntü içerik analizi

---

### 6️⃣ [OpenAI Translate](./NetCoreAI.Project06.OpenAITranslate) 🌍
OpenAI GPT-3.5-turbo API ile çok dilli metin çevirisi.

**Özellikler:**
- ✅ Çok dilli çeviri desteği
- ✅ Doğal ve akıcı çeviriler
- ✅ 50+ dil desteği
- ✅ User Secrets ile güvenli API key yönetimi

**Kullanım Alanları:**
- Belge çevirisi
- Çok dilli içerik üretimi
- Uluslararası iletişim
- Yerelleştirme projeleri

---

### 7️⃣ [Text to Speech](./NetCoreAI.Project07.TextToSpeech) 🔊
System.Speech kütüphanesi ile offline metin okuma.

**Özellikler:**
- ✅ Offline çalışma (API gerektirmez)
- ✅ Ayarlanabilir ses seviyesi ve hızı
- ✅ Basit ve hızlı kullanım
- ✅ Windows yerleşik sesler

**Kullanım Alanları:**
- Offline metin okuma
- Erişilebilirlik uygulamaları
- Test ve prototipleme
- Eğitim materyalleri

---

### 8️⃣ [Text to Speech with OpenAI](./NetCoreAI.Project08.TextToSpeechWithOpenAI) 🎙️
OpenAI TTS API ile profesyonel kalitede ses üretimi.

**Özellikler:**
- ✅ 6 farklı profesyonel ses seçeneği
- ✅ Yüksek kaliteli MP3 çıktısı
- ✅ Çok dilli destek
- ✅ TTS-1 ve TTS-1-HD modelleri

**Kullanım Alanları:**
- Podcast üretimi
- Sesli kitap oluşturma
- Profesyonel anons sistemleri
- E-öğrenme içerikleri

---

### 9️⃣ [Sentiment Analysis](./NetCoreAI.Project09.SentimentAIApp) 😊
OpenAI ile basit ve hızlı duygu analizi.

**Özellikler:**
- ✅ Positive/Negative/Neutral kategorizasyonu
- ✅ Hızlı analiz
- ✅ Çok dilli destek
- ✅ Basit çıktı formatı

**Kullanım Alanları:**
- Müşteri yorumu filtreleme
- Sosyal medya takibi
- Gerçek zamanlı duygu analizi
- Hızlı kategorizasyon

---

### 🔟 [Advanced Sentiment Analysis](./NetCoreAI.Project10.SentimentAIAppWithDegree) 📊
OpenAI ile gelişmiş duygu analizi ve skorlama.

**Özellikler:**
- ✅ 6 duygu kategorisi (Joy, Sadness, Anger, Fear, Surprise, Neutral)
- ✅ Her duygu için %0-100 skor
- ✅ JSON formatında detaylı sonuçlar
- ✅ Duygu profili çıkarma

**Kullanım Alanları:**
- Detaylı pazar araştırması
- Müşteri deneyimi analizi
- Mental sağlık uygulamaları
- Akademik araştırmalar

---

## 🚀 Hızlı Başlangıç

### Gereksinimler

- [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0)
- [OpenAI API Key](https://platform.openai.com/api-keys) (Project 01, 02, 03, 06, 08, 09, 10 için)
- [Tesseract OCR Engine](https://github.com/UB-Mannheim/tesseract/wiki) (Project 04 için)
- [Google Cloud Account](https://console.cloud.google.com/) (Project 05 için)

### Kurulum

1. **Repository'yi klonlayın:**

```bash
git clone https://github.com/etartar/NetCoreAI.git
cd NetCoreAI
```

2. **OpenAI projeler için API key'i kaydedin:**

```bash
# Project 01
cd NetCoreAI.Project01.OpenAIChat
dotnet user-secrets set "OpenAI:ApiKey" "YOUR_API_KEY"

# Project 02
cd ../NetCoreAI.Project02.OpenWhisperAudioTranskript
dotnet user-secrets set "OpenAI:ApiKey" "YOUR_API_KEY"

# Project 03
cd ../NetCoreAI.Project03.DALL-EImageGeneration
dotnet user-secrets set "OpenAI:ApiKey" "YOUR_API_KEY"

# Project 06
cd ../NetCoreAI.Project06.OpenAITranslate
dotnet user-secrets set "OpenAI:ApiKey" "YOUR_API_KEY"

# Project 08
cd ../NetCoreAI.Project08.TextToSpeechWithOpenAI
dotnet user-secrets set "OpenAI:ApiKey" "YOUR_API_KEY"

# Project 09
cd ../NetCoreAI.Project09.SentimentAIApp
dotnet user-secrets set "OpenAI:ApiKey" "YOUR_API_KEY"

# Project 10
cd ../NetCoreAI.Project10.SentimentAIAppWithDegree
dotnet user-secrets set "OpenAI:ApiKey" "YOUR_API_KEY"
```

**Tesseract OCR için (Project 04):**

1. [Tesseract OCR](https://github.com/UB-Mannheim/tesseract/wiki) uygulamasını kurun
2. Dil paketlerini indirin
3. PATH değişkenine Tesseract klasörünü ekleyin

**Google Cloud Vision için (Project 05):**

1. [Google Cloud Console](https://console.cloud.google.com/) üzerinden proje oluşturun
2. Cloud Vision API'yi etkinleştirin
3. Service Account oluşturun ve JSON key dosyasını indirin
4. JSON dosyasını proje klasörüne yerleştirin

```bash
# Project 05
cd ../NetCoreAI.Project05.GoogleCloudVision
# Program.cs dosyasında JSON dosya yolunu güncelleyin
```

3. **Projeleri çalıştırın:**

```bash
# İstediğiniz projeye gidin
cd NetCoreAI.Project01.OpenAIChat

# Bağımlılıkları yükleyin
dotnet restore

# Uygulamayı çalıştırın
dotnet run
```

## 📦 Kullanılan Teknolojiler

| Teknoloji | Versiyon | Açıklama | Kullanıldığı Projeler |
|-----------|----------|----------|-----------------------|
| .NET | 10.0 | Ana framework | Tüm projeler |
| C# | 14.0 | Programlama dili | Tüm projeler |
| OpenAI API | Latest | GPT, Whisper, DALL-E, TTS servisleri | 01, 02, 03, 06, 08, 09, 10 |
| Tesseract | 5.2.0 | OCR motoru (offline) | 04 |
| Google Cloud Vision | 3.8.0 | Bulut tabanlı OCR ve görüntü analizi | 05 |
| System.Speech | 10.0.3 | Offline TTS (Windows) | 07 |
| User Secrets | 10.0.3 | Güvenli yapılandırma yönetimi | Tüm projeler |

## 🔒 Güvenlik

⚠️ **ÖNEMLİ GÜVENLİK UYARILARI:**

- API key'lerinizi **asla** kaynak kodda saklamayın
- Google Cloud Service Account JSON dosyalarını **asla** Git'e commit etmeyin
- `.gitignore` dosyasına `appsettings.json`, `*.json` (credentials) ve secrets dosyalarını ekleyin
- User Secrets kullanarak API key'leri güvenli bir şekilde saklayın
- Production ortamında Azure Key Vault, Google Secret Manager veya ortam değişkenleri kullanın

### User Secrets Konumları:

- **Windows**: `%APPDATA%\Microsoft\UserSecrets\<user_secrets_id>\secrets.json`
- **Linux/macOS**: `~/.microsoft/usersecrets/<user_secrets_id>/secrets.json`

## 💰 Maliyet Bilgileri

### OpenAI API

OpenAI API kullanımı ücretlidir. Güncel fiyatlandırma:

| Servis | Fiyat |
|--------|-------|
| GPT-3.5-turbo | ~$0.0005-0.0015 / 1K token |
| GPT-4 | ~$0.03-0.06 / 1K token |
| Whisper | $0.006 / dakika |
| DALL-E 2 | $0.018-0.020 / görsel |
| DALL-E 3 | $0.040-0.120 / görsel |
| TTS-1 | $15.00 / 1M karakter |
| TTS-1-HD | $30.00 / 1M karakter |

Detaylı fiyatlandırma için: [OpenAI Pricing](https://openai.com/pricing)

### Google Cloud Vision API

İlk 1000 istek/ay ücretsiz, sonrası ücretli:

| Özellik | İlk 1000 birim/ay | 1001-5M birim/ay |
|---------|-------------------|------------------|
| Text Detection | ÜCRETSİZ | $1.50 / 1000 |
| Document Text Detection | ÜCRETSİZ | $1.50 / 1000 |
| Label Detection | ÜCRETSİZ | $1.50 / 1000 |

Detaylı fiyatlandırma için: [Google Cloud Vision Pricing](https://cloud.google.com/vision/pricing)

## 📖 Dokümantasyon

Her proje için detaylı README dosyaları mevcuttur:

- 📄 [Project01 - OpenAI Chat README](./NetCoreAI.Project01.OpenAIChat/README.md)
- 📄 [Project02 - Whisper Audio Transcript README](./NetCoreAI.Project02.OpenWhisperAudioTranskript/README.md)
- 📄 [Project03 - DALL-E Image Generation README](./NetCoreAI.Project03.DALL-EImageGeneration/README.md)
- 📄 [Project04 - Tesseract OCR README](./NetCoreAI.Project04.TesseractOcr/README.md)
- 📄 [Project05 - Google Cloud Vision OCR README](./NetCoreAI.Project05.GoogleCloudVision/README.md)
- 📄 [Project06 - OpenAI Translate README](./NetCoreAI.Project06.OpenAITranslate/README.md)
- 📄 [Project07 - Text to Speech README](./NetCoreAI.Project07.TextToSpeech/README.md)
- 📄 [Project08 - Text to Speech with OpenAI README](./NetCoreAI.Project08.TextToSpeechWithOpenAI/README.md)
- 📄 [Project09 - Sentiment Analysis README](./NetCoreAI.Project09.SentimentAIApp/README.md)
- 📄 [Project10 - Advanced Sentiment Analysis README](./NetCoreAI.Project10.SentimentAIAppWithDegree/README.md)

## 🛠️ Geliştirme

### Proje Yapısı

```
NetCoreAI/
├── NetCoreAI.Project01.OpenAIChat/
│   ├── Program.cs
│   ├── NetCoreAI.Project01.OpenAIChat.csproj
│   └── README.md
├── NetCoreAI.Project02.OpenWhisperAudioTranskript/
│   ├── Program.cs
│   ├── NetCoreAI.Project02.OpenWhisperAudioTranskript.csproj
│   └── README.md
├── NetCoreAI.Project03.DALL-EImageGeneration/
│   ├── Program.cs
│   ├── NetCoreAI.Project03.DALL-EImageGeneration.csproj
│   └── README.md
├── NetCoreAI.Project04.TesseractOcr/
│   ├── Program.cs
│   ├── NetCoreAI.Project04.TesseractOcr.csproj
│   └── README.md
├── NetCoreAI.Project05.GoogleCloudVision/
│   ├── Program.cs
│   ├── NetCoreAI.Project05.GoogleCloudVision.csproj
│   └── README.md
├── NetCoreAI.Project06.OpenAITranslate/
│   ├── Program.cs
│   ├── NetCoreAI.Project06.OpenAITranslate.csproj
│   └── README.md
├── NetCoreAI.Project07.TextToSpeech/
│   ├── Program.cs
│   ├── NetCoreAI.Project07.TextToSpeech.csproj
│   └── README.md
├── NetCoreAI.Project08.TextToSpeechWithOpenAI/
│   ├── Program.cs
│   ├── NetCoreAI.Project08.TextToSpeechWithOpenAI.csproj
│   └── README.md
├── NetCoreAI.Project09.SentimentAIApp/
│   ├── Program.cs
│   ├── NetCoreAI.Project09.SentimentAIApp.csproj
│   └── README.md
├── NetCoreAI.Project10.SentimentAIAppWithDegree/
│   ├── Program.cs
│   ├── NetCoreAI.Project10.SentimentAIAppWithDegree.csproj
│   └── README.md
└── README.md
```

### Build Komutları

```bash
# Tüm projeleri build etme
dotnet build

# Spesifik bir projeyi build etme
dotnet build NetCoreAI.Project01.OpenAIChat

# Release modunda build
dotnet build -c Release
```

## 🐛 Sorun Giderme

### Yaygın Hatalar ve Çözümleri

#### 1. "API Key bulunamadı" hatası

```bash
# Doğru proje klasöründe olduğunuzdan emin olun
cd NetCoreAI.ProjectXX
dotnet user-secrets set "OpenAI:ApiKey" "YOUR_API_KEY"
```

#### 2. HTTP 401 Unauthorized

- API key'inizi kontrol edin
- OpenAI hesabınızda kredi bakiyeniz olup olmadığını kontrol edin
- API key'in doğru kopyalandığından emin olun

#### 3. HTTP 429 Rate Limit

- Çok fazla istek göndermiş olabilirsiniz
- Birkaç dakika bekleyip tekrar deneyin
- Ücretsiz plan kullanıyorsanız, limitleri kontrol edin

#### 4. Tesseract Engine Not Found

- Tesseract OCR'nin kurulu olduğundan emin olun
- PATH değişkenine Tesseract klasörünü ekleyin
- Dil dosyalarının (`tessdata`) doğru konumda olduğunu kontrol edin

#### 5. Google Cloud Vision "Service Account Not Found"

- Service Account JSON dosyasının doğru konumda olduğundan emin olun
- `GOOGLE_APPLICATION_CREDENTIALS` ortam değişkenini kontrol edin
- Cloud Vision API'nin etkinleştirildiğinden emin olun

## 📚 Kaynaklar

### Resmi Dokümantasyon

- [OpenAI API Documentation](https://platform.openai.com/docs)
- [Google Cloud Vision API Documentation](https://cloud.google.com/vision/docs)
- [.NET 10 Documentation](https://learn.microsoft.com/en-us/dotnet/)
- [Tesseract OCR Documentation](https://tesseract-ocr.github.io/)
- [C# 14 Language Reference](https://learn.microsoft.com/en-us/dotnet/csharp/)

### Yararlı Linkler

- [OpenAI Platform](https://platform.openai.com/)
- [OpenAI Playground](https://platform.openai.com/playground)
- [Google Cloud Console](https://console.cloud.google.com/)
- [Vision API Try It](https://cloud.google.com/vision/docs/drag-and-drop)
- [OpenAI Community Forum](https://community.openai.com/)
- [.NET Community](https://dotnet.microsoft.com/platform/community)

## 🤝 Katkıda Bulunma

Bu proje eğitim amaçlıdır. Katkılarınızı bekliyoruz!

1. Fork yapın
2. Feature branch oluşturun (`git checkout -b feature/AmazingFeature`)
3. Değişikliklerinizi commit edin (`git commit -m 'Add some AmazingFeature'`)
4. Branch'inizi push edin (`git push origin feature/AmazingFeature`)
5. Pull Request oluşturun

## 📄 Lisans

Bu proje eğitim amaçlıdır ve herhangi bir lisans altında dağıtılmamaktadır.

## 👨‍💻 Geliştirici

**Emir TARTAR**
- GitHub: [@etartar](https://github.com/etartar)
- Repository: [NetCoreAI](https://github.com/etartar/NetCoreAI)

## 🙏 Teşekkürler

- OpenAI ekibine harika API'ler için
- Tesseract OCR geliştiricilerine
- .NET topluluğuna

---

⭐ **Projeyi beğendiyseniz yıldız vermeyi unutmayın!**

💡 **Sorularınız için Issue açabilir veya Pull Request gönderebilirsiniz.**

🚀 **Happy Coding!**