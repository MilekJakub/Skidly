using Skidly.Domain.Exceptions.StudyGoal;
using Skidly.Shared.Abstractions.Domain;

namespace Skidly.Domain.ValueObjects.StudyGoal;

public class Deadline : ValueObject
{
    private Deadline()
    {
        // For Entity Framework
    }
    
    public Deadline(DateTime deadline)
    {
        if (deadline < DateTime.Now)
        {
            throw new DeadlineCannotBeInThePastException();
        }
        
        Value = deadline;
    }
    
    public DateTime Value { get; private set; }
    
    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }

    public override string ToString()
    {
        return Value.ToString("g");
    }
}