using Skidly.Domain.Exceptions.ApplicationUser;
using Skidly.Shared.Abstractions.Domain;

namespace Skidly.Domain.ValueObjects.ApplicationUser;

public class EmailAddress : ValueObject
{
    public EmailAddress(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
        {
            throw new EmptyEmailAddressException();
        }

        email = email.Trim();
        
        var address = new System.Net.Mail.MailAddress(email);

        if (email.EndsWith('.') || address.Address != email)
        {
            throw new InvalidEmailAddressException(email);
        }

        Value = email;
    }
    
    public string Value { get; private set; }
    
    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
    
    public static implicit operator string(EmailAddress email) => email.Value;
    public static implicit operator EmailAddress(string email) => new(email);

    public override string ToString()
    {
        return Value;
    }
}