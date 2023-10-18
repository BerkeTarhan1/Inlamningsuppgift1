using Assignment.Interfaces;
using Assignment.Models;
using Assignment.Services;
using System.Net;

namespace Assignment.Tests
{
    public class CreateContactTests
    {
        [Fact]
      
        
            public async Task CreateContactAsync_ShouldCreateContactToList_ReturnTrue()   //h�r testar vi om kontakten sparas ned (huvudfunktionen)
            {
            // Arrange
            IContactService contactService = new ContactService();               // Ger ContactService en ny instans
                var contact = new Contact                        //skapar en nytt v�rde f�r contact och l�gger in informationen nedanf�r 
                {                                               // Detta �r nya informationen vi vill testa och se ifall det sparas 
                    FirstName = "Berke",
                    LastName = "Tarhan",
                    Email = "berke@domain.com",
                    PhoneNumber = "12345678",
                    CompleteAdress = new Address
                    {
                        StreetName = "Tre K�llor",
                        StreetNumber = "9",
                        AreaCode = "14565",
                        Region = "Botkyrka"
                    }
                };


                //Act 
                await contactService.CreateContactAsync(contact);        // Medans testet p�gar skapar den en kontakt 


                // Assert
                var retrievedContact = contactService.GetOneContact(contact.Email); //Kontakten h�mtas in genom GetOneContact funktionen och navigerar med e-post

                Assert.NotNull(retrievedContact);                                      // s�kerst�ller att kontakten som h�mtas inte har ett nullv�rde
                Assert.Equal(contact.CompleteName, retrievedContact.CompleteName);            // kontakten som h�mtas ska ha samma informations struktur som informationen ovanf�r 
                Assert.Equal(contact.Email, retrievedContact.Email);                  // Kontakten som vi testar ska ha identisk e-post som kontakten vi h�mtar fr�nlistan
                Assert.Equal(contact.PhoneNumber, retrievedContact.PhoneNumber);      // kontakten som testas har samma telefonnummer som kontakten vi h�mtar fr�n listan
                Assert.Equal(contact.CompleteAdress?.CompleteAdress, retrievedContact.CompleteAdress?.CompleteAdress); // Testar och kollar ifall kontakten som vi sparat g�r att h�mta upp fr�n listan
            }

        
    }
}