using Assignment.Interfaces;

namespace Assignment.Models;

//Denna klass är address modellen som förklarar vad address ska innehålla. 
public class Address : IAddress
{
    public string? StreetName { get; set; }
    public string? StreetNumber { get; set; }
    public string? AreaCode { get; set; }
    public string? Region { get; set; }

    public string? CompleteAdress => $"{StreetName}, {StreetNumber}, {AreaCode}, {Region}"; //detta är en sammanfattning för hela address där alla detaljer medföljer

}