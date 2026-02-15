# ✍️ NetCoreAI.Project16 - Story Generator with AI

OpenAI GPT-4-turbo API kullanarak kullanıcı tercihlerine göre yaratıcı hikayeler oluşturan .NET 10 konsol uygulaması.

## 📋 Özellikler

- ✅ OpenAI GPT-4-turbo ile hikaye oluşturma
- ✅ Özelleştirilebilir hikaye türü (Macera, Korku, Bilim Kurgu, vb.)
- ✅ Ana karakter seçimi
- ✅ Mekan belirleme
- ✅ Hikaye uzunluğu kontrolü (kısa/orta/uzun)
- ✅ Giriş, gelişme ve sonuç yapısı
- ✅ User Secrets ile güvenli API key yönetimi

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
cd NetCoreAI/NetCoreAI.Project16.CreateStoryWithAI
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

Uygulama çalıştığında hikaye parametrelerini girin:

```
Hikaye türünü seçiniz (Macera, Korku, Bilim Kurgu, Fantastik, Komedi): Macera
Ana karakteriniz kim: Kaşif Ali
Hikaye nerede geçiyor: Amazon Ormanları
Hikayenin uzunluğu (kısa/orta/uzun): orta

--- AI tarafından oluşturulan hikaye ---
Kaşif Ali, Amazon ormanlarının derinliklerinde kayıp bir uygarlığın izini sürüyordu...
```

### Örnek Kullanımlar:

**Bilim Kurgu Hikayesi:**
```
Tür: Bilim Kurgu
Karakter: Dr. Ayşe Yılmaz
Mekan: Mars Koloni Üssü
Uzunluk: uzun

Output: 2157 yılında Mars'taki ilk kolonide görevli Dr. Ayşe Yılmaz, gizemli sinyaller almaya başladı...
```

**Korku Hikayesi:**
```
Tür: Korku
Karakter: Emre
Mekan: Terk edilmiş köy evi
Uzunluk: kısa

Output: Emre, fırtınalı bir gecede yolunu kaybetmiş ve eski bir köy evine sığınmıştı...
```

**Komedi Hikayesi:**
```
Tür: Komedi
Karakter: Mehmet Abi
Mekan: İstanbul, Boğaz
Uzunluk: orta

Output: Mehmet Abi, boğazda balık tutarken hiç beklemediği maceralarla karşılaştı...
```

## 🎭 Desteklenen Hikaye Türleri

| Tür | Açıklama | Örnek Temalar |
|-----|----------|---------------|
| **Macera** | Aksiyon dolu, heyecanlı | Hazine avcılığı, keşifler |
| **Korku** | Gerilim, korku unsurları | Hayaletler, gizem |
| **Bilim Kurgu** | Gelecek, teknoloji | Uzay, yapay zeka |
| **Fantastik** | Büyü, mitoloji | Ejderhalar, büyücüler |
| **Komedi** | Mizah, eğlence | Komik durumlar |
| **Romantik** | Aşk, duygusal | İlişkiler, romantizm |
| **Polisiye** | Gizem, dedektif | Suç, araştırma |
| **Tarihi** | Geçmiş dönemler | Tarihsel olaylar |

## 🎯 Kullanım Alanları

### Eğitim
- Yaratıcı yazma egzersizleri
- Öğrenci projeleri
- Dil öğrenimi
- Hayal gücü geliştirme

### Eğlence
- Kişisel hikayeler
- Çocuklar için masallar
- Rol yapma oyunları
- Yaratıcı aktiviteler

### İçerik Üretimi
- Blog içeriği
- Sosyal medya hikayeleri
- Podcast senaryoları
- Video içerik fikirleri

### Profesyonel
- Senaryo taslakları
- Kitap fikirleri
- Oyun hikayeleri
- Reklam metinleri

## 🔧 Yapılandırma

### Farklı Uzunluk Seviyeleri

max_tokens parametresini ayarlayın:

```csharp
string maxTokens = length switch
{
    "kısa" => "500",
    "orta" => "1000",
    "uzun" => "2000",
    _ => "1000"
};

var requestBody = new
{
    model = "gpt-4-turbo",
    messages = new[] { ... },
    max_tokens = int.Parse(maxTokens)
};
```

### Tema Ekleme

Daha detaylı hikayeler için tema parametresi ekleyin:

```csharp
Console.Write("Hikayenin teması: ");
string theme = Console.ReadLine();

string prompt = $"{genre} türünde bir hikaye yaz. " +
    $"Baş karakterin adı {character}. " +
    $"Hikaye {setting} bölgesinde geçiyor. " +
    $"Ana tema: {theme}. " +
    $"{length} bir hikaye olsun.";
```

### Ton Ayarlama

Hikaye tonunu belirleyin:

```csharp
Console.Write("Hikayenin tonu (ciddi/neşeli/karanlık): ");
string tone = Console.ReadLine();

var systemMessage = tone switch
{
    "ciddi" => "You are a serious, dramatic story writer.",
    "neşeli" => "You are a cheerful, upbeat story writer.",
    "karanlık" => "You are a dark, mysterious story writer.",
    _ => "You are a creative story writer."
};
```

## 🚀 Gelişmiş Özellikler

### Bölüm Bölüm Hikaye

Hikayeleri bölümler halinde oluşturmak için:

```csharp
for (int chapter = 1; chapter <= 3; chapter++)
{
    string chapterPrompt = $"Bölüm {chapter}: " + 
        $"{prompt}. Bu bölümde {GetChapterFocus(chapter)} odaklan.";
    
    string chapterStory = await GenerateStoryAsync(chapterPrompt);
    Console.WriteLine($"\n--- Bölüm {chapter} ---");
    Console.WriteLine(chapterStory);
}

string GetChapterFocus(int chapter)
{
    return chapter switch
    {
        1 => "karakterin tanıtımı ve maceranın başlangıcına",
        2 => "zorluklar ve çatışmalara",
        3 => "doruk nokta ve çözüme",
        _ => "hikaye gelişimine"
    };
}
```

### Karakter Profili Oluşturma

Önce karakter profili oluşturun:

```csharp
string characterProfile = await GenerateCharacterProfileAsync(character);
Console.WriteLine($"\nKarakter Profili:\n{characterProfile}\n");

// Ardından bu profili kullanarak hikaye oluşturun
string storyPrompt = $"Bu karakter profili ile {genre} hikayesi yaz:\n{characterProfile}";
```

### Interaktif Hikaye

Kullanıcı tercihlerine göre hikaye dallandırma:

```csharp
string story = await GenerateStoryAsync(prompt);
Console.WriteLine(story);

Console.Write("\nHikaye nasıl devam etsin? (1: Mutlu son, 2: Sürpriz son, 3: Açık uçlu): ");
string choice = Console.ReadLine();

string continuation = await GenerateContinuationAsync(story, choice);
Console.WriteLine($"\n{continuation}");
```

### Farklı Dillerde Hikaye

```csharp
Console.Write("Hikaye hangi dilde olsun? (Türkçe/İngilizce/Almanca): ");
string language = Console.ReadLine();

string languageInstruction = language switch
{
    "İngilizce" => "Write the story in English.",
    "Almanca" => "Schreibe die Geschichte auf Deutsch.",
    _ => "Hikayeyi Türkçe yaz."
};

string prompt = $"{genre} türünde bir hikaye yaz. ... {languageInstruction}";
```

## 📊 Prompt Engineering İpuçları

### Detaylı Prompt Örneği

```csharp
string advancedPrompt = $@"
Tür: {genre}
Ana Karakter: {character} (yaş, kişilik, geçmiş)
Mekan: {setting} (detaylı tanım)
Uzunluk: {length}

Hikaye Yapısı:
- Giriş: Karakteri ve ortamı tanıt (1 paragraf)
- Gelişme: Ana çatışmayı kur (2-3 paragraf)
- Doruk Nokta: En heyecanlı kısım (1-2 paragraf)
- Sonuç: Çözüm ve kapanış (1 paragraf)

Stil: Betimleyici, akıcı, diyalog içeren
Ton: {tone}
";
```

### Temperature Ayarı

Yaratıcılık seviyesini kontrol edin:

```csharp
var requestBody = new
{
    model = "gpt-4-turbo",
    messages = new[] { ... },
    max_tokens = 1000,
    temperature = 0.8 // 0-1 arası (yüksek = daha yaratıcı)
};
```

## 💰 Maliyet Tahmini

### GPT-4-turbo:
- Kısa hikaye (500 token): ~$0.015
- Orta hikaye (1000 token): ~$0.030
- Uzun hikaye (2000 token): ~$0.060

### 100 Hikaye Maliyeti:
- GPT-4-turbo: ~$3.00 - $6.00
- GPT-3.5-turbo: ~$0.30 - $0.60 (daha ekonomik)

## 📝 Hikaye Kaydetme

Oluşturulan hikayeleri kaydetmek için:

```csharp
string fileName = $"story_{character}_{DateTime.Now:yyyyMMdd_HHmmss}.txt";
await File.WriteAllTextAsync(fileName, story);
Console.WriteLine($"\nHikaye kaydedildi: {fileName}");
```

## 🔒 Güvenlik

- Uygunsuz içerik filtreleme ekleyin
- Kullanıcı girişlerini sanitize edin
- Telif hakları konusunda dikkatli olun
- Yaş sınırlamaları uygulayın

## 🐛 Hata Ayıklama

### "API Key bulunamadı" hatası:

```bash
dotnet user-secrets set "OpenAI:ApiKey" "YOUR_OPENAI_API_KEY"
```

### Hikaye çok kısa/uzun geliyor:

max_tokens değerini ayarlayın:

```csharp
max_tokens = 1500 // İstenilen uzunluk için
```

### Kalitesiz içerik:

- GPT-4-turbo kullanın (GPT-3.5 yerine)
- Daha detaylı prompt yazın
- Temperature değerini optimize edin

## 📚 İlgili Kaynaklar

- [OpenAI Creative Writing Guide](https://platform.openai.com/docs/guides/text-generation)
- [Prompt Engineering for Stories](https://help.openai.com/en/articles/6654000-best-practices-for-prompt-engineering-with-openai-api)
- [Story Structure](https://en.wikipedia.org/wiki/Story_structure)

## 👨‍💻 Geliştirici

**Emir TARTAR**
- GitHub: [@etartar](https://github.com/etartar)

## 📄 Lisans

Bu proje eğitim amaçlıdır.
