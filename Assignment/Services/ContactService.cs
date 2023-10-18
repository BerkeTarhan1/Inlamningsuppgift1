using Assignment.Interfaces;
using Assignment.Models;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Assignment.Services;


public class ContactService : IContactService
{

    private List<Contact> _contacts = new List<Contact>(); //Skapar en lista som skapar, hanterar och lagrar kontakter
    
    //Denna metod skapar en kontakt och sedan sparar ned inmatningen till textformat i en json fil. Async-Await hjälper oss spara informationen med hjälp av en tidsperiod. 
    public async Task CreateContactAsync(Contact contact)
    {
        _contacts.Add(contact);
        await FileService.DownloadToFileAsync(JsonConvert.SerializeObject(_contacts));
        
    }

    //Denna metod hämtar alla kontakter från listan. 
    public IEnumerable<Contact> GetAllContacts()
    {
        var content = FileService.GetFromFile();       //Ger tillgång till filen och all kontakt information
        if (!string.IsNullOrEmpty(content))       //Visar all information om filen inte är tom
        {
            _contacts = JsonConvert.DeserializeObject<List<Contact>>(content)!;           //Alla kontakter omvandlas till en lista av kontakter

        }

        return _contacts.OrderByDescending(contacts => contacts.Created);           //returnerar kund listan i ordning av när dom skapades
    }

    //Denna metod hämtar en specifik kontakt från listan 
    public Contact GetOneContact(string email)
    {
        var content = FileService.GetFromFile();             //hämtar en specifik kontakt från filen 
        if (!string.IsNullOrEmpty(content))                  //kollar ifall filen inte är tom 
        {
            _contacts = JsonConvert.DeserializeObject<List<Contact>>(content)!;          //omvandlar texten i json filen till en lista av kontakter
        }

        var contact = _contacts.FirstOrDefault(x => x.Email == email);               //frågar och dubbelkollar ifall det är samma mejl

        if (contact == null)                          //kollar om kontakten är rätt eller fel
        {
            Console.WriteLine("Contact not found");                  //skickar ut meddelande att kontakten inte är hittad
        }

        return contact!;                         //skickar användaren tillbaka till menyn
    }

    //metod för att ta bort en kontakt 
    public async Task RemoveOneContactAsync(string email)   //frågar om e-post för att ta bort en specifik kontakt 
    {
        var content = FileService.GetFromFile();                 //hämtar kontakter från json filen 
        if (_contacts.Count == 0)                               //ifall inga kontakter existeras får vi meddelandet 
        {
            Console.WriteLine("There are no contacts");
        }

        else
        {
             var removeContact = _contacts.FirstOrDefault(c => c.Email == email);     //frågar efter mail för kontakten som skall tas bort 
            if (removeContact != null)                      //kollar om kontakten finns med 
            {
                _contacts.Remove(removeContact);                  //kontakten raderas 
                await FileService.DownloadToFileAsync(JsonConvert.SerializeObject(_contacts));           //sparar ner ändringen som gjorts
            }

            else
            {
                Console.WriteLine("This contact can not be found");                 //om e-post addressen inte är det samma som kontakten skickar den ut detta mellande
            }
        }
    }
}
