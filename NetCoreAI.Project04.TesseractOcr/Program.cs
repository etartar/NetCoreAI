Console.Write("Karakter Okuması Yapılacak Resim Yolu: ");

string imagePath = Console.ReadLine();

string tessDataPath = @"C:\tessdata";

try
{
    using var engine = new Tesseract.TesseractEngine(tessDataPath, "tur+eng", Tesseract.EngineMode.Default);
    using var img = Tesseract.Pix.LoadFromFile(imagePath);
    using var page = engine.Process(img);
    string text = page.GetText();
    Console.WriteLine("Okunan Metin:");
    Console.WriteLine(text);
}
catch (Exception ex)
{
    Console.WriteLine($"Hata: {ex.Message}");
}