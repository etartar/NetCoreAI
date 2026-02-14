# 🔊 NetCoreAI.Project07 - Text to Speech

.NET System.Speech kütüphanesi kullanarak metni sese dönüştüren basit ve etkili .NET 10 konsol uygulaması.

## 📋 Özellikler

- ✅ Metin okuma (Text-to-Speech) özelliği
- ✅ Ayarlanabilir ses seviyesi (0-100)
- ✅ Ayarlanabilir konuşma hızı (-10 ile +10 arası)
- ✅ Basit ve kullanımı kolay arayüz
- ✅ Çevrimdışı çalışma (API gerektirmez)

## 🛠️ Gereksinimler

- .NET 10 SDK
- Windows işletim sistemi (System.Speech kütüphanesi Windows'a özgüdür)

## 📦 Kullanılan Paketler

```xml
<PackageReference Include="System.Speech" Version="10.0.3" />
<PackageReference Include="Microsoft.Extensions.Configuration.UserSecrets" Version="10.0.3" />
```

## 🚀 Kurulum

### 1. Projeyi klonlayın veya indirin

```bash
git clone https://github.com/etartar/NetCoreAI
cd NetCoreAI/NetCoreAI.Project07.TextToSpeech
```

### 2. Bağımlılıkları yükleyin

```bash
dotnet restore
```

### 3. Uygulamayı çalıştırın

```bash
dotnet run
```

## 💡 Kullanım

Uygulama çalıştığında okutmak istediğiniz metni girin:

```
Metni Girin: Hello, this is a text to speech demo.
```

Metin sesli olarak okunacaktır.

### Örnek Kullanımlar:

**Basit Metin:**
```
Metni Girin: Merhaba dünya!
```

**Uzun Metin:**
```
Metni Girin: Bu, metin okuma teknolojisinin harika bir örneğidir. Programımız metni sesli olarak okuyabilir.
```

**İngilizce Metin:**
```
Metni Girin: Welcome to the text to speech application.
```

## 🔧 Yapılandırma

### Ses Seviyesini Ayarlama

`Program.cs` dosyasında `Volume` özelliğini değiştirin (0-100):

```csharp
SpeechSynthesizer speechSynthesizer = new()
{
    Volume = 80, // 0-100 arası (100 = maksimum)
    Rate = 0
};
```

### Konuşma Hızını Ayarlama

`Rate` özelliğini değiştirin (-10 ile +10 arası):

```csharp
SpeechSynthesizer speechSynthesizer = new()
{
    Volume = 100,
    Rate = 2 // Pozitif değer = hızlı, Negatif değer = yavaş
};
```

**Rate değerleri:**
- `-10`: Çok yavaş
- `0`: Normal hız (varsayılan)
- `+10`: Çok hızlı

### Farklı Ses Kullanma

Sisteminizde yüklü sesler arasından seçim yapabilirsiniz:

```csharp
// Tüm yüklü sesleri listele
foreach (InstalledVoice voice in speechSynthesizer.GetInstalledVoices())
{
    VoiceInfo info = voice.VoiceInfo;
    Console.WriteLine($"Name: {info.Name}, Culture: {info.Culture}");
}

// Belirli bir ses seçme
speechSynthesizer.SelectVoice("Microsoft David Desktop");
```

### Ses Dosyasına Kaydetme

Metni ses dosyası olarak kaydetmek isterseniz:

```csharp
speechSynthesizer.SetOutputToWaveFile("output.wav");
speechSynthesizer.Speak(inputText);
speechSynthesizer.SetOutputToDefaultAudioDevice();
```

## 🌍 Dil Desteği

System.Speech, sisteminizde yüklü olan dil paketlerine göre farklı dilleri destekler:

- 🇺🇸 İngilizce (US)
- 🇬🇧 İngilizce (UK)
- 🇹🇷 Türkçe (ek paket gerektirebilir)
- 🇩🇪 Almanca
- 🇫🇷 Fransızca
- 🇪🇸 İspanyolca

> **Not:** Bazı diller için Windows'a ek dil paketleri yüklemeniz gerekebilir.

## 📊 Özellikler Tablosu

| Özellik | Değer Aralığı | Varsayılan |
|---------|---------------|------------|
| Volume | 0-100 | 100 |
| Rate | -10 ile +10 | 0 |
| Ses Sayısı | Sisteme bağlı | 1+ |

## 🔒 Platform Desteği

- ✅ **Windows**: Tam destek
- ❌ **Linux**: Desteklenmiyor (System.Speech Windows'a özgüdür)
- ❌ **macOS**: Desteklenmiyor (System.Speech Windows'a özgüdür)

> **Alternatif:** Cross-platform çözümler için Azure Cognitive Services Speech SDK veya Google Cloud Text-to-Speech kullanabilirsiniz.

## 🐛 Hata Ayıklama

### "Lütfen geçerli bir metin girin" mesajı:
- Boş metin girmeyin
- En az bir karakter girin

### Ses çıkmıyor:
- Bilgisayarınızın ses seviyesini kontrol edin
- Hoparlör/kulaklık bağlantısını kontrol edin
- `Volume` ayarının 0'dan büyük olduğundan emin olun

### Linux/Mac'te çalışmıyor:
- System.Speech yalnızca Windows'ta çalışır
- Cross-platform için Azure Speech SDK veya Google Cloud TTS kullanın

## 📚 İlgili Kaynaklar

- [System.Speech Documentation](https://learn.microsoft.com/en-us/dotnet/api/system.speech.synthesis)
- [SpeechSynthesizer Class](https://learn.microsoft.com/en-us/dotnet/api/system.speech.synthesis.speechsynthesizer)
- [Azure Cognitive Services Speech](https://azure.microsoft.com/en-us/services/cognitive-services/text-to-speech/)

## 🚀 Gelişmiş Özellikler

### SSML (Speech Synthesis Markup Language) Kullanımı

Daha gelişmiş ses kontrolü için SSML kullanabilirsiniz:

```csharp
string ssml = @"
<speak version='1.0' xmlns='http://www.w3.org/2001/10/synthesis' xml:lang='en-US'>
    <voice name='Microsoft David Desktop'>
        <prosody rate='slow' pitch='low'>
            Hello, this is a slow and low-pitched voice.
        </prosody>
    </voice>
</speak>";

speechSynthesizer.SpeakSsml(ssml);
```

## 👨‍💻 Geliştirici

**Emir TARTAR**
- GitHub: [@etartar](https://github.com/etartar)

## 📄 Lisans

Bu proje eğitim amaçlıdır.
