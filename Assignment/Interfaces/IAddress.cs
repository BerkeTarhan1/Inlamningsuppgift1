namespace Assignment.Interfaces

/* Detta är interfacet som förklarar vad adressen ska innehålla, interfacet är kopplat till address - modellen.  */
{
    public interface IAddress
    {
        string? AreaCode { get; set; }                   
        string? Region { get; set; }
        string? StreetName { get; set; }
        string? StreetNumber { get; set; }
        string? CompleteAdress { get; }
    }
}