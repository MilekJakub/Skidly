using Skidly.Domain.Constants;
using Skidly.Shared.Abstractions.Domain;

namespace Skidly.Domain.ValueObjects.ApplicationUser;

public class Country : ValueObject
{
    public Country(string countryCode)
    {
        var countries = Consts.Countries;
        if (!countries.ContainsKey(countryCode))
        {
            throw new Exception("InvalidCountryException()");
        }

        var name = countries[countryCode];

        Name = name;
        Code = countryCode;
    }

    public string Code { get; init; }
    public string Name { get; init; }
    
    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Code;
        yield return Name;
    }
}