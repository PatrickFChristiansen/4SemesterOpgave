using System;


namespace Application.Institutions.CreateInstitution
{
    public sealed record Command(
    
        string Name,
        string Street,
        string City,
        string StreetNumber,
        string PostalCode);
    
}
