using Skidly.Domain.Constants;
using Skidly.Domain.Exceptions.ApplicationUser;
using Skidly.Shared.Abstractions.Domain;

namespace Skidly.Domain.ValueObjects.ApplicationUser;

public class Country : ValueObject
{
    private Country()
    {
        // For Entity Framework
    }
    
    public Country(string code)
    {
        if (string.IsNullOrWhiteSpace(code))
        {
            throw new EmptyCountryNameException();
        }
        
        var countries = CountriesConstants.Countries;
        
        if (!countries.ContainsKey(code))
        {
            throw new InvalidCountryCodeException(code);
        }

        var country = countries[code];
        
        Name = country;
        Code = code;
    }

    public string Code { get; init; }
    public string Name { get; init; }
    
    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Code;
        yield return Name;
    }

    public override string ToString()
    {
        return Code;
    }

    public string ToString(char format)
    {
        return format switch
        {
            'c' => Code,
            'n' => Name,
            _ => throw new ArgumentException("Invalid format")
        };
    }
    
    public static implicit operator string(Country country) => country.Code;
    public static implicit operator Country(string code) => new(code);    
}