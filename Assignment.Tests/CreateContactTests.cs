using Assignment.Interfaces;
using Assignment.Models;
using Assignment.Services;
using System.Net;

namespace Assignment.Tests
{
    public class CreateContactTests
    {
        [Fact]
      
        
            public async Task CreateContactAsync_ShouldCreateContactToList_ReturnTrue()   //här testar vi om kontakten sparas ned (huvudfunktionen)
            {
            // Arrange
            IContactService contactService = new ContactService();               // Ger ContactService en ny instans
                var contact = new Contact                        //skapar en nytt värde för contact och lägger in informationen nedanför 
                {                                               // Detta är nya informationen vi vill testa och se ifall det sparas 
                    FirstName = "Berke",
                    LastName = "Tarhan",
                    Email = "berke@domain.com",
                    PhoneNumber = "12345678",
                    CompleteAdress = new Address
                    {
                        StreetName = "Tre Källor",
                        StreetNumber = "9",
                        AreaCode = "14565",
                        Region = "Botkyrka"
                    }
                };


                //Act 
                await contactService.CreateContactAsync(contact);        // Medans testet pågar skapar den en kontakt 


                // Assert
                var retrievedContact = contactService.GetOneContact(contact.Email); //Kontakten hämtas in genom GetOneContact funktionen och navigerar med e-post

                Assert.NotNull(retrievedContact);                                      // säkerställer att kontakten som hämtas inte har ett nullvärde
                Assert.Equal(contact.CompleteName, retrievedContact.CompleteName);            // kontakten som hämtas ska ha samma informations struktur som informationen ovanför 
                Assert.Equal(contact.Email, retrievedContact.Email);                  // Kontakten som vi testar ska ha identisk e-post som kontakten vi hämtar frånlistan
                Assert.Equal(contact.PhoneNumber, retrievedContact.PhoneNumber);      // kontakten som testas har samma telefonnummer som kontakten vi hämtar från listan
                Assert.Equal(contact.CompleteAdress?.CompleteAdress, retrievedContact.CompleteAdress?.CompleteAdress); // Testar och kollar ifall kontakten som vi sparat går att hämta upp från listan
            }

        
    }
}