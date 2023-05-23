using Skidly.Shared.Abstractions.Domain;

namespace Skidly.Domain.ValueObjects;

public class DateOfBirth : ValueObject
{
    public DateOfBirth(string date)
    {

        var validDate = DateOnly.Parse(date);
        
        if (validDate > DateOnly.FromDateTime(DateTime.Now))
        {
            throw new Exception("InvalidBirthDateException()");
        }

        Value = validDate;
    }

    public DateOnly Value { get; private set; }
    
    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}