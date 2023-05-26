using Skidly.Domain.Exceptions.ApplicationUser;
using Skidly.Shared.Abstractions.Domain;

namespace Skidly.Domain.ValueObjects.ApplicationUser;

public class DateOfBirth : ValueObject
{
    private DateOfBirth()
    {
        // For Entity Framework
    }
    
    public DateOfBirth(string date)
    {

        var validDate = DateTime.Parse(date);
        
        if (validDate > DateTime.Now)
        {
            throw new InvalidBirthDateException(validDate.ToString());
        }

        Value = validDate;
    }

    public DateTime Value { get; private set; }
    
    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}