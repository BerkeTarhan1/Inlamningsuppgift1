using Assignment.Models;
using Newtonsoft.Json;

namespace Assignment.Services;

public class FileService
{
    private static readonly string filePath = @"C:\Inlamningsuppgift\contact.json";      //sökvägen som filen ska sparas ned till 

    //metod som sparar ned informationen 
    public static async Task DownloadToFileAsync(string contentAsJson)
    {

        using StreamWriter contactFile = new StreamWriter(filePath);
        await contactFile.WriteLineAsync(contentAsJson);          //skapar kontakt filen som heter contactFile
        await Task.Delay(7000);                                   //skapar en tidsperiod på 7 sekunder 
        Console.WriteLine(" ");
        Console.WriteLine("File has been saved");              //skickar ut meddelande som indikerar på att filen är sparad

    }

    public static string GetFromFile()        //denna metod används för att hämta tillbaka kontakter från json filen         
    {
        if (File.Exists(filePath))                    //kollar om filen existerar i det angivna filepathen 
        {
            using StreamReader get = new StreamReader(filePath);                //använder streamreader för att läsa igenom filen 
            return get.ReadToEnd();                                             //läser informationen från den valda sökvägen 
        }

        return null!;
    } 

    public static async Task RemoveFromFile(string email)               //använder email för att navigera och hitta rätt kontakt 
    {
        var contacts = JsonConvert.DeserializeObject<List<Contact>>(File.ReadAllText(filePath));                //hittar kontakt listen genom sökvägen och läser upp alla infromation
        using StreamWriter contactDelete = new StreamWriter(filePath);                                           //hjälper oss att radera kontakten 
        await contactDelete.WriteAsync(email);                                                                   //skriver ner email för att konfirmera att man raderar kontakten
    }
}
