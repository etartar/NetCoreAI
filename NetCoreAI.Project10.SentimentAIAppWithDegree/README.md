# 📊 NetCoreAI.Project10 - Advanced Sentiment Analysis with Scores

OpenAI GPT-3.5-turbo API kullanarak gelişmiş metin duygu analizi yapan .NET 10 konsol uygulaması. 6 farklı duygu kategorisi için yüzdelik skorlar üretir.

## 📋 Özellikler

- ✅ OpenAI GPT-3.5-turbo modeli ile gelişmiş duygu analizi
- ✅ 6 duygu kategorisi: Joy (Mutluluk), Sadness (Üzüntü), Anger (Öfke), Fear (Korku), Surprise (Şaşkınlık), Neutral (Nötr)
- ✅ Her duygu için %0-100 arası skor
- ✅ JSON formatında detaylı sonuçlar
- ✅ User Secrets ile güvenli API key yönetimi
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
cd NetCoreAI/NetCoreAI.Project10.SentimentAIAppWithDegree
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
Lütfen Metni Giriniz: Bugün harika bir gün geçirdim, çok mutluyum!

Gelişmiş Duygu Analizi Yapılıyor...
Gelişmiş Duygu Analizi Sonucu: 
{
  "Joy": "85%",
  "Sadness": "0%",
  "Anger": "0%",
  "Fear": "0%",
  "Surprise": "10%",
  "Neutral": "5%"
}
```

### Örnek Analizler:

**Mutluluk Dolu Metin:**
```
Input:  Terfi aldım! Çok heyecanlıyım ve mutluyum!
Output: 
{
  "Joy": "90%",
  "Sadness": "0%",
  "Anger": "0%",
  "Fear": "0%",
  "Surprise": "40%",
  "Neutral": "0%"
}
```

**Üzüntü İfadesi:**
```
Input:  Sevdiğim kişiyi kaybettim, çok üzgünüm.
Output:
{
  "Joy": "0%",
  "Sadness": "95%",
  "Anger": "0%",
  "Fear": "10%",
  "Surprise": "0%",
  "Neutral": "0%"
}
```

**Öfke Dolu Metin:**
```
Input:  Bu kabul edilemez! Çok kızgınım!
Output:
{
  "Joy": "0%",
  "Sadness": "5%",
  "Anger": "85%",
  "Fear": "0%",
  "Surprise": "10%",
  "Neutral": "0%"
}
```

**Karışık Duygular:**
```
Input:  Sınav sonuçları açıklandı. Geçtim ama notum düşük.
Output:
{
  "Joy": "40%",
  "Sadness": "30%",
  "Anger": "5%",
  "Fear": "10%",
  "Surprise": "15%",
  "Neutral": "20%"
}
```

## 🎯 Duygu Kategorileri

### Detaylı Açıklamalar:

| Duygu | İngilizce | Açıklama | Göstergeler |
|-------|-----------|----------|-------------|
| 😊 **Joy** | Mutluluk | Pozitif, neşeli, memnun duygular | "harika", "mükemmel", "mutluyum" |
| 😢 **Sadness** | Üzüntü | Keder, hüzün, melankolik duygular | "üzgünüm", "kötü", "kayıp" |
| 😠 **Anger** | Öfke | Kızgınlık, sinir, rahatsızlık | "kızgınım", "sinir", "kabul edilemez" |
| 😨 **Fear** | Korku | Endişe, tedirginlik, kaygı | "korku", "endişe", "tehlikeli" |
| 😲 **Surprise** | Şaşkınlık | Beklenmedik, şaşırtıcı durumlar | "inanamıyorum", "şok", "beklemiyordum" |
| 😐 **Neutral** | Nötr | Duygusal olmayan, bilgilendirici | "bilgilendirme", "açıklama", "durum" |

## 📊 Kullanım Alanları

### Pazar Araştırması
- Ürün yorumlarında detaylı duygu haritası
- Rekabet analizi
- Marka algısı değerlendirmesi

### Sosyal Medya Analizi
- Toplumsal olayların duygu profili
- Trend analizi
- Marka krizi erken tespit

### Müşteri Deneyimi
- Detaylı müşteri memnuniyeti analizi
- Hizmet kalitesi değerlendirmesi
- NPS (Net Promoter Score) destekleme

### Sağlık ve Psikoloji
- Mental sağlık takibi
- Terapi oturumu analizi
- Günlük duygu durumu izleme

### İnsan Kaynakları
- Çalışan moral analizi
- Anket detaylı değerlendirmesi
- Şirket kültürü ölçümü

## 🔧 Yapılandırma

### Farklı Duygu Setleri

Sistem mesajını değiştirerek farklı duygu setleri kullanabilirsiniz:

**Plutchik'in 8 Temel Duygusu:**
```csharp
new { role = "system", content = "Analyze emotions and return JSON with percentages for: Joy, Trust, Fear, Surprise, Sadness, Disgust, Anger, Anticipation." }
```

**İş Dünyası Odaklı:**
```csharp
new { role = "system", content = "Analyze sentiment and return JSON with percentages for: Satisfied, Frustrated, Excited, Disappointed, Concerned, Indifferent." }
```

### GPT-4 ile Daha Hassas Analiz

```csharp
var requestBody = new
{
    model = "gpt-4", // veya "gpt-4-turbo"
    messages = new[]
    {
        new { role = "system", content = "You are an advanced AI that analyzes emotions in text..." },
        new { role = "user", content = $"Analyze the sentiment of this text: {input}..." }
    }
};
```

### JSON Parsing İyileştirmesi

AI'nın JSON formatında daha tutarlı sonuç vermesini sağlamak için:

```csharp
new { role = "system", content = @"You are an advanced AI that analyzes emotions. 
IMPORTANT: Return ONLY valid JSON, nothing else. Format:
{
  ""Joy"": ""X%"",
  ""Sadness"": ""X%"",
  ""Anger"": ""X%"",
  ""Fear"": ""X%"",
  ""Surprise"": ""X%"",
  ""Neutral"": ""X%""
}" }
```

## 📈 Sonuç Yorumlama

### Baskın Duygu Tespiti

JSON sonucunu parse ederek baskın duyguyu bulabilirsiniz:

```csharp
var result = JsonSerializer.Deserialize<Dictionary<string, string>>(sentimentResult);
var dominant = result.OrderByDescending(x => int.Parse(x.Value.TrimEnd('%'))).First();
Console.WriteLine($"Baskın Duygu: {dominant.Key} ({dominant.Value})");
```

### Duygu Karmaşıklığı Hesaplama

Birden fazla duygunun yüksek olması karmaşık duygu durumunu gösterir:

```csharp
int highEmotionCount = result.Count(x => int.Parse(x.Value.TrimEnd('%')) > 30);
if (highEmotionCount > 2)
{
    Console.WriteLine("Karmaşık duygu durumu tespit edildi.");
}
```

## 📝 API Limitleri ve Fiyatlandırma

- **GPT-3.5-turbo**: ~$0.0005 / 1K token (input), ~$0.0015 / 1K token (output)
- **GPT-4**: ~$0.03 / 1K token (input), ~$0.06 / 1K token (output)

### Maliyet Tahmini

Gelişmiş analiz daha uzun prompt kullandığı için maliyeti biraz daha yüksektir:

Örnek kullanım: 1000 detaylı analiz:
- **GPT-3.5-turbo**: ~$0.10 - $0.20
- **GPT-4**: ~$2.00 - $4.00

## 🔒 Güvenlik

- API anahtarınızı asla kaynak koduna yazmayın
- User Secrets veya ortam değişkenleri kullanın
- Kullanıcı girişlerini sanitize edin
- Rate limiting uygulayın
- GDPR ve veri gizliliği kurallarına uyun

## 🐛 Hata Ayıklama

### JSON Parse Hatası:

AI bazen JSON dışında metin ekleyebilir. Bunu temizlemek için:

```csharp
string cleanJson = sentimentResult;
// ```json ve ``` etiketlerini temizle
cleanJson = cleanJson.Replace("```json", "").Replace("```", "").Trim();

var result = JsonSerializer.Deserialize<Dictionary<string, string>>(cleanJson);
```

### Toplam %100'ü Geçme veya Eksik Kalma:

AI bazen toplamı tam 100% yapmayabilir. Bunu normalleştirmek için:

```csharp
var result = JsonSerializer.Deserialize<Dictionary<string, string>>(cleanJson);
int total = result.Sum(x => int.Parse(x.Value.TrimEnd('%')));

var normalized = result.ToDictionary(
    x => x.Key, 
    x => $"{(int.Parse(x.Value.TrimEnd('%')) * 100.0 / total):F0}%"
);
```

### Tutarsız Sonuçlar:

Temperature parametresini düşürerek tutarlılığı artırın:

```csharp
var requestBody = new
{
    model = "gpt-3.5-turbo",
    temperature = 0.3, // 0-1 arası (düşük = tutarlı)
    messages = new[] { ... }
};
```

## 🚀 Gelişmiş Özellikler

### Görselleştirme İçin Veri Hazırlama

```csharp
var result = JsonSerializer.Deserialize<Dictionary<string, string>>(sentimentResult);

Console.WriteLine("\nDuygu Grafiği:");
foreach (var emotion in result)
{
    int percentage = int.Parse(emotion.Value.TrimEnd('%'));
    string bar = new string('█', percentage / 2);
    Console.WriteLine($"{emotion.Key,-12}: {bar} {emotion.Value}");
}
```

Çıktı:
```
Duygu Grafiği:
Joy         : ████████████████████████████████████████ 80%
Sadness     : ██ 5%
Anger       : █ 3%
Fear        : ████ 8%
Surprise    : ██ 4%
Neutral     : 0%
```

### Zaman Serisi Analizi

Duygu değişimini zaman içinde takip edin:

```csharp
var emotionHistory = new List<Dictionary<string, string>>();

foreach (var text in dailyTexts)
{
    string result = await AdvancedSentimentAnalyzeAsync(text, apiKey);
    var emotions = JsonSerializer.Deserialize<Dictionary<string, string>>(result);
    emotionHistory.Add(emotions);
}

// Trend analizi
Console.WriteLine("Joy trendi: " + string.Join(" -> ", 
    emotionHistory.Select(e => e["Joy"])));
```

## 📚 İlgili Kaynaklar

- [OpenAI API Documentation](https://platform.openai.com/docs/api-reference)
- [Emotion Detection with AI](https://platform.openai.com/docs/guides/text-generation)
- [Plutchik's Wheel of Emotions](https://en.wikipedia.org/wiki/Contrasting_and_categorization_of_emotions)
- [JSON Serialization in .NET](https://learn.microsoft.com/en-us/dotnet/standard/serialization/system-text-json-overview)

## 🆚 Project09 vs Project10 Karşılaştırma

| Özellik | Project09 (Basic) | Project10 (Advanced) |
|---------|-------------------|----------------------|
| **Duygu Sayısı** | 3 (Pos/Neg/Neu) | 6 (Joy/Sad/Anger/Fear/Surprise/Neu) |
| **Çıktı Formatı** | Basit metin | JSON ile yüzdeler |
| **Detay Seviyesi** | Düşük | Yüksek |
| **İşlem Süresi** | Hızlı | Orta |
| **Maliyet** | Düşük | Orta |
| **Kullanım Alanı** | Basit kategorizasyon | Detaylı analiz, araştırma |
| **Parsing** | Gerekli değil | JSON parsing gerekli |
| **Veri Görselleştirme** | Sınırlı | Çok uygun |

**Öneri:**
- **Gerçek zamanlı filtreleme** → Project09
- **Detaylı raporlama** → Project10
- **Akademik araştırma** → Project10
- **Hızlı sınıflandırma** → Project09

## 👨‍💻 Geliştirici

**Emir TARTAR**
- GitHub: [@etartar](https://github.com/etartar)

## 📄 Lisans

Bu proje eğitim amaçlıdır.
