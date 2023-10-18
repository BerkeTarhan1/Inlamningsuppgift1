using Assignment.Models;

namespace Assignment.Interfaces;

//Denna interface klassen innehåller funktionerna för ContactService som behövs för att det ska fungera. Mindre kod och bättre struktur. 
public interface IContactService
{
    Task CreateContactAsync(Contact contact);
    IEnumerable<Contact> GetAllContacts();
    Contact GetOneContact(string email);
    Task RemoveOneContactAsync(string email);
}