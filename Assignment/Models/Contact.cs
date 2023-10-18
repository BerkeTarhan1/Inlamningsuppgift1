using Assignment.Interfaces;

namespace Assignment.Models;

//Samma sak som address denna klass förklarar vad en kontakt ska innehålla. 
public class Contact : IContact
{
    public DateTime Created { get; set; } = DateTime.Now;  //Denna metod används ungefär som en tidstämpel för skapade kontakter
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public Address? CompleteAdress { get; set; }

    public string? CompleteName => $"{FirstName}, {LastName}"; //Detta är en sammanfattning för hela kontakten namn dvs : förnamn + efternamn

}
