using Assignment.Interfaces;
using Assignment.Models;
using System.Runtime.CompilerServices;

namespace Assignment.Services;

public class MenuService
{
   private static readonly IContactService contactService = new ContactService();               //använder oss av readonly för att ge ContactService ny information

    //lägger till kontakt
    public static void CreateContactMenu()
   {
        
        Contact contact = new Contact();

        Console.Write("Förnamn: ");
        contact.FirstName = Console.ReadLine();
        Console.Write("Efternamn: ");                                  //ber om användarens svar och inmatningar för att ge dom olimka strängarna värde
        contact.LastName = Console.ReadLine();
        Console.Write("E-Post: ");
        contact.Email = Console.ReadLine();
        Console.Write("Telefon nummer: ");
        contact.PhoneNumber = Console.ReadLine();

        contact.CompleteAdress = new Address();
        Console.Write("Gatunamn: ");
        contact.CompleteAdress.StreetName = Console.ReadLine();
        Console.Write("Gatunummer: ");
        contact.CompleteAdress.StreetNumber = Console.ReadLine();
        Console.Write("Områdeskod: ");
        contact.CompleteAdress.AreaCode = Console.ReadLine();
        Console.Write("Region: ");
        contact.CompleteAdress.Region = Console.ReadLine();


       Task.Run(() => contactService.CreateContactAsync(contact));   //hjälper informationen att sparas ned medans användaren kan göra annat utan denna funktion låser programmet sig 
   }

    public static void ViewAllContactsMenu()           //hämtar alla kontakter från json filen 
    {
        var contacts = contactService.GetAllContacts();             //kopplar nuvarande kod till funktionerna i ContactService
        if (contacts.Any())                        //hämtar befintliga kontakter 
        {
            foreach (var contact in contacts)               //hämtar information för varje kontakt i filen 
            {
                Console.WriteLine($"{contact.CompleteName} {contact.Email} {contact?.CompleteAdress?.CompleteAdress}");
            }
        }

        else
        {
            Console.WriteLine("There is no contacts");              //ifall inga kontakter finns 
        }
    }

    public static void ViewOneContactMenu()         //metod för en specifik kontakt 
    {
        Console.WriteLine("Skriv in din e-post: ");
        var email = Console.ReadLine();                         //frågar om användarens e-post för hitta rätt specifik kontakt 

        var contact = contactService.GetOneContact(email!);                   //tar fram alla funktioner

        if (contact != null)             //om kontakten finns tar den fram nedanstående information
        {
            Console.WriteLine($"{contact.CompleteName} {contact.Email} {contact?.CompleteAdress?.CompleteAdress}");
        }

    }

    //metod för ta bort en kontakt 
    public static void RemoveOneContactMenu()
    {
        Console.WriteLine("Skriv in din e-post: ");           //frågar om e-post kopplad till kontakten 
        var email = Console.ReadLine();

        Task.Run(() => contactService.RemoveOneContactAsync(email!));                //efter ändringen sparar den ned ändringen under tiden 
        
    }

    public static void MainMenu()          //huvudmenyn för att användaren ska kunna navigera 
    {
        do
        {
            Console.Clear();
            Console.WriteLine("1. Skapa en ny kontakt");
            Console.WriteLine("2. Vissa alla kontakter");
            Console.WriteLine("3. Visa en/specifik kontakt");
            Console.WriteLine("4. Radera en kontakt");
            Console.WriteLine("0. Avsluta");
            Console.WriteLine("Välj ett av ovanstående alternativ");
            var option = Console.ReadLine();              //frågar om användarens val 

            Console.Clear();

            switch (option)                  //användaren väljer ett av alternativen och skickas till den sidan för att gå vidare
            {
                case "1":
                    MenuService.CreateContactMenu();
                    break;

                case "2":
                    MenuService.ViewAllContactsMenu();
                    break;

                case "3":
                    MenuService.ViewOneContactMenu();
                    break;

                case "4":
                    MenuService.RemoveOneContactMenu();
                    break;

                case "0":
                    Environment.Exit(0);
                    break;
            }

            Console.ReadKey();
        } while (true);
    }
    
    
}

