using Google.Cloud.Vision.V1;

Console.Write("Resim yolunu giriniz: ");
var imagePath = Console.ReadLine();
Console.WriteLine();

string credentialPath = "credential path gelecek";

Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", credentialPath);

try
{
    var client = await ImageAnnotatorClient.CreateAsync();
    var image = await Image.FromFileAsync(imagePath);
    var response = await client.DetectTextAsync(image);
    Console.WriteLine($"Resimdeki metin: {response[0].Description}");
    Console.WriteLine();

    foreach (var annotation in response)
    {
        if (!string.IsNullOrEmpty(annotation.Description))
        {
            Console.WriteLine($"Metin: {annotation.Description}");
            Console.WriteLine($"Konum: {annotation.BoundingPoly}");
            Console.WriteLine();
        }
    }
}
catch (Exception ex)
{
    Console.WriteLine($"Hata: {ex.Message}");
}