using System.Speech.Synthesis;

SpeechSynthesizer speechSynthesizer = new()
{
    Volume = 100, // Set volume to maximum (0-100)
    Rate = 0 // Set speaking rate (default is 0, range is -10 to 10)
};

Console.Write("Metni Girin: ");

string inputText = Console.ReadLine();

if (string.IsNullOrWhiteSpace(inputText))
{
    Console.WriteLine("Lütfen geçerli bir metin girin.");
}

speechSynthesizer.Speak(inputText);