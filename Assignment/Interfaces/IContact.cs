using Assignment.Models;

namespace Assignment.Interfaces;


/* Detta är interfacet som förklarar vad kontakten ska innehålla, interfacet är kopplat till kontakt - modellen.   */
public interface IContact
{
    public DateTime Created { get => Created; set => Created = value; }            
    Address? CompleteAdress { get; set; }
    string? Email { get; set; }
    string? FirstName { get; set; }
    string? LastName { get; set; }
    string? PhoneNumber { get; set; }
    string? CompleteName { get; }
}