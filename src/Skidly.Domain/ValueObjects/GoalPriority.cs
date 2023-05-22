﻿using Skidly.Domain.Exceptions;
using Skidly.Shared.Abstractions.Domain;

namespace Skidly.Domain.ValueObjects;

public class GoalPriority : ValueObject
{
    public GoalPriority(byte value)
    {
        if (value < 1 || value > 10)
        {
            throw new InvalidPriorityException();
        }
        
        Value = value;
    }

    public byte Value { get; private set; }


    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
    
    public static implicit operator byte(GoalPriority priority) => priority.Value;
    public static implicit operator GoalPriority(byte priority) => new(priority);
    
    public override string ToString()
    {
        return Value.ToString();
    }
}