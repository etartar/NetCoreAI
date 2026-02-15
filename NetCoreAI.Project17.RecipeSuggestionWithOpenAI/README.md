# 🍳 NetCoreAI.Project17 - Recipe Suggestion with OpenAI

OpenAI GPT-4 API kullanarak elinizde olan malzemelere göre yemek tarifi öneren ASP.NET Core MVC .NET 10 web uygulaması.

## 📋 Özellikler

- ✅ ASP.NET Core MVC web uygulaması
- ✅ OpenAI GPT-4 ile yemek tarifi önerisi
- ✅ Malzeme bazlı tarif arama
- ✅ Profesyonel aşçı perspektifi
- ✅ Responsive web arayüzü
- ✅ User Secrets ile güvenli API key yönetimi

## 🛠️ Gereksinimler

- .NET 10 SDK
- OpenAI API Key ([OpenAI Platform](https://platform.openai.com/api-keys) üzerinden alabilirsiniz)
- Web tarayıcısı

## 📦 Kullanılan Paketler

```xml
<Project Sdk="Microsoft.NET.Sdk.Web">
  <PropertyGroup>
    <TargetFramework>net10.0</TargetFramework>
    <UserSecretsId>netcoreai-project17-secrets</UserSecretsId>
  </PropertyGroup>
</Project>
```

## 🚀 Kurulum

### 1. Projeyi klonlayın veya indirin

```bash
git clone https://github.com/etartar/NetCoreAI
cd NetCoreAI/NetCoreAI.Project17.RecipeSuggestionWithOpenAI
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

### 5. Tarayıcıda açın

```
https://localhost:5001
```

## 💡 Kullanım

1. Web uygulaması açıldığında ana sayfayı göreceksiniz
2. "Malzemeler" alanına elinizde olan malzemeleri girin
3. "Tarif Öner" butonuna tıklayın
4. AI size malzemelerinizle yapabileceğiniz tarifleri önerecek

### Örnek Kullanım:

```
Malzemeler: tavuk göğsü, domates, soğan, salatalık, zeytinyağı

Önerilen Tarif:
---
Tavuk Sote

Malzemeler:
- 500g tavuk göğsü
- 2 adet domates
- 1 adet soğan
- Zeytinyağı
- Tuz, karabiber

Yapılışı:
1. Tavuk göğsünü küp doğrayın...
2. Soğanları ince ince doğrayın...
[Detaylı tarif]
```

## 🎯 Kullanım Alanları

### Ev Kullanıcıları
- Evdeki malzemeleri değerlendirme
- Yeni tarifler keşfetme
- Yemek çeşitliliği
- Alışveriş öncesi planlama

### Mutfak Yönetimi
- Stok yönetimi
- İsraf önleme
- Maliyet optimizasyonu
- Menü planlama

### Beslenme
- Diyet tarifleri
- Kalori kontrolü
- Sağlıklı alternatifler
- Besin değeri dengesi

### Eğitim
- Yemek pişirme öğretimi
- Yaratıcı mutfak
- Malzeme bilgisi
- Teknik geliştirme

## 🏗️ Proje Yapısı

```
NetCoreAI.Project17.RecipeSuggestionWithOpenAI/
├── Controllers/
│   ├── HomeController.cs
│   └── DefaultController.cs
├── Services/
│   └── OpenAIService.cs
├── Views/
│   ├── Home/
│   │   └── Index.cshtml
│   ├── Default/
│   │   └── CreateRecipe.cshtml
│   └── Shared/
│       └── _Layout.cshtml
├── wwwroot/
│   ├── css/
│   ├── js/
│   └── lib/
├── Program.cs
└── appsettings.json
```

## 🔧 Kod Yapısı

### OpenAIService.cs

```csharp
public class OpenAIService
{
    private readonly HttpClient _httpClient;
    private readonly string _apiKey;
    
    public OpenAIService(IConfiguration configuration)
    {
        _httpClient = new HttpClient();
        _apiKey = configuration["OpenAI:ApiKey"];
        _httpClient.DefaultRequestHeaders.Authorization = 
            new AuthenticationHeaderValue("Bearer", _apiKey);
    }
    
    public async Task<string> GetRecipeAsync(string ingredients)
    {
        var requestBody = new
        {
            model = "gpt-4",
            messages = new[]
            {
                new { role = "system", content = "Sen profesyonel bir aşçısın..." },
                new { role = "user", content = $"Elimde şu malzemeler var: {ingredients}..." }
            },
            temperature = 0.7
        };
        
        // API çağrısı ve sonuç dönme
    }
}
```

### Controller Kullanımı

```csharp
public class DefaultController : Controller
{
    private readonly OpenAIService _openAIService;
    
    public DefaultController(OpenAIService openAIService)
    {
        _openAIService = openAIService;
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateRecipe(string ingredients)
    {
        var recipe = await _openAIService.GetRecipeAsync(ingredients);
        ViewBag.Recipe = recipe;
        return View();
    }
}
```

## 🚀 Gelişmiş Özellikler

### Mutfak Türü Seçimi

Farklı mutfaklar için özelleştirme:

```csharp
public async Task<string> GetRecipeAsync(string ingredients, string cuisine)
{
    var systemMessage = cuisine switch
    {
        "Türk" => "Sen Türk mutfağı uzmanı bir aşçısın.",
        "İtalyan" => "Sen İtalyan mutfağı uzmanı bir aşçısın.",
        "Çin" => "Sen Çin mutfağı uzmanı bir aşçısın.",
        "Hint" => "Sen Hint mutfağı uzmanı bir aşçısın.",
        _ => "Sen profesyonel bir aşçısın."
    };
    
    var requestBody = new
    {
        model = "gpt-4",
        messages = new[]
        {
            new { role = "system", content = systemMessage },
            new { role = "user", content = $"Elimde şu malzemeler var: {ingredients}. Ne yapabilirim?" }
        }
    };
}
```

### Diyet Kısıtlamaları

Özel beslenme gereksinimleri için:

```csharp
public async Task<string> GetRecipeAsync(string ingredients, string dietType)
{
    string dietInstruction = dietType switch
    {
        "vegan" => "Sadece vegan (hiçbir hayvansal ürün yok) tarif öner.",
        "vejetaryen" => "Sadece vejetaryen (et/balık yok) tarif öner.",
        "glutensiz" => "Glutensiz tarif öner.",
        "ketojenik" => "Düşük karbonhidratlı, yüksek yağlı (keto) tarif öner.",
        "paleo" => "Paleo diyetine uygun tarif öner.",
        _ => ""
    };
    
    var userMessage = $"Elimde şu malzemeler var: {ingredients}. " +
        $"{dietInstruction} Ne yapabilirim?";
}
```

### Öğün Bazlı Öneriler

```csharp
public async Task<string> GetRecipeAsync(string ingredients, string mealType)
{
    string mealInstruction = mealType switch
    {
        "kahvaltı" => "Kahvaltıya uygun bir tarif öner.",
        "öğle" => "Öğle yemeğine uygun bir tarif öner.",
        "akşam" => "Akşam yemeğine uygun bir tarif öner.",
        "atıştırmalık" => "Atıştırmalık/aperatif tarif öner.",
        "tatlı" => "Tatlı tarifi öner.",
        _ => "Bir tarif öner."
    };
}
```

### Porsiyon ve Süre Bilgisi

```csharp
var userMessage = $@"
Malzemeler: {ingredients}
Kişi sayısı: {servings} kişilik
Hazırlama süresi tercihi: {timePreference} (hızlı/orta/uzun)

Bu bilgilere göre detaylı bir tarif öner. 
Tarif şunları içermeli:
- Malzeme listesi (ölçüler ile)
- Hazırlama adımları
- Pişirme süresi
- Besin değerleri (yaklaşık)
- Sunuş önerileri
";
```

### Görsel Önerisi

Yemek görseli için DALL-E entegrasyonu:

```csharp
public async Task<string> GenerateFoodImageAsync(string recipeName)
{
    var requestBody = new
    {
        model = "dall-e-3",
        prompt = $"Professional food photography of {recipeName}, beautifully plated, studio lighting",
        n = 1,
        size = "1024x1024"
    };
    
    // DALL-E API çağrısı
}
```

## 📱 Frontend Geliştirmeleri

### Malzeme Auto-Complete

```javascript
// wwwroot/js/site.js
const commonIngredients = [
    "domates", "soğan", "sarımsak", "biber",
    "tavuk", "et", "balık", "yumurta",
    "pirinç", "makarna", "patates", "havuç"
];

// Auto-complete implementasyonu
```

### Favori Tarifler

LocalStorage kullanarak favori tarifleri kaydetme:

```javascript
function saveFavorite(recipe) {
    let favorites = JSON.parse(localStorage.getItem('favorites')) || [];
    favorites.push({ 
        recipe: recipe, 
        date: new Date().toISOString() 
    });
    localStorage.setItem('favorites', JSON.stringify(favorites));
}
```

### Alışveriş Listesi

Eksik malzemeler için liste oluşturma:

```csharp
public class ShoppingListService
{
    public List<string> GenerateShoppingList(string recipe, List<string> availableIngredients)
    {
        // Tarifteki malzemeleri parse et
        // Elinizde olmayan malzemeleri belirle
        // Alışveriş listesi oluştur
    }
}
```

## 💰 Maliyet Tahmini

### GPT-4:
- Tek tarif önerisi: ~$0.02 - $0.04
- 100 tarif: ~$2.00 - $4.00
- Aylık 1000 kullanıcı: ~$20 - $40

### Maliyet Düşürme:

```csharp
// Cache mekanizması
private static Dictionary<string, string> _recipeCache = new();

public async Task<string> GetRecipeAsync(string ingredients)
{
    string cacheKey = ingredients.ToLower().Trim();
    
    if (_recipeCache.ContainsKey(cacheKey))
    {
        return _recipeCache[cacheKey];
    }
    
    string recipe = await CallOpenAIAsync(ingredients);
    _recipeCache[cacheKey] = recipe;
    
    return recipe;
}
```

## 🔒 Güvenlik

### Input Validation

```csharp
public async Task<IActionResult> CreateRecipe(string ingredients)
{
    if (string.IsNullOrWhiteSpace(ingredients))
    {
        ModelState.AddModelError("", "Lütfen malzeme giriniz.");
        return View();
    }
    
    if (ingredients.Length > 500)
    {
        ModelState.AddModelError("", "Malzeme listesi çok uzun.");
        return View();
    }
    
    // XSS koruması
    ingredients = System.Net.WebUtility.HtmlEncode(ingredients);
    
    var recipe = await _openAIService.GetRecipeAsync(ingredients);
    return View("Result", recipe);
}
```

### Rate Limiting

```csharp
// Startup/Program.cs
builder.Services.AddMemoryCache();
builder.Services.AddSingleton<IRateLimitService, RateLimitService>();

public class RateLimitService
{
    private readonly IMemoryCache _cache;
    
    public bool IsAllowed(string userId)
    {
        string key = $"rate_limit_{userId}";
        
        if (_cache.TryGetValue(key, out int requestCount))
        {
            if (requestCount >= 10) // 10 istek/saat
            {
                return false;
            }
            _cache.Set(key, requestCount + 1, TimeSpan.FromHours(1));
        }
        else
        {
            _cache.Set(key, 1, TimeSpan.FromHours(1));
        }
        
        return true;
    }
}
```

## 📊 Analytics Entegrasyonu

```csharp
public class RecipeAnalyticsService
{
    public void TrackRecipeRequest(string ingredients, string result)
    {
        // Log kaydı
        // En popüler malzemeler
        // Başarı oranı
        // Kullanım istatistikleri
    }
}
```

## 🐛 Hata Ayıklama

### "API Key bulunamadı" hatası:

```bash
dotnet user-secrets set "OpenAI:ApiKey" "YOUR_OPENAI_API_KEY"
```

### Dependency Injection hatası:

```csharp
// Program.cs'de servis kaydını kontrol edin
builder.Services.AddScoped<OpenAIService>();
```

### View bulunamıyor:

View dosyalarının doğru konumda olduğundan emin olun:
- `Views/Default/CreateRecipe.cshtml`
- `Views/Home/Index.cshtml`

## 📚 İlgili Kaynaklar

- [ASP.NET Core MVC Documentation](https://learn.microsoft.com/en-us/aspnet/core/mvc/)
- [Dependency Injection in ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/dependency-injection)
- [OpenAI Cookbook - Recipes](https://github.com/openai/openai-cookbook)

## 👨‍💻 Geliştirici

**Emir TARTAR**
- GitHub: [@etartar](https://github.com/etartar)

## 📄 Lisans

Bu proje eğitim amaçlıdır.
