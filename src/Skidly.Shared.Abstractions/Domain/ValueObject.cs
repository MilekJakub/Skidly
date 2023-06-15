﻿namespace Skidly.Shared.Abstractions.Domain;

public abstract class ValueObject : IEquatable<ValueObject>
{
    public abstract IEnumerable<object> GetAtomicValues();

    private bool ValuesAreEqual(ValueObject other)
        => GetAtomicValues().SequenceEqual(other.GetAtomicValues());
   
    public bool Equals(ValueObject? other) 
        => other is not null && ValuesAreEqual(other);

    public override bool Equals(object? obj) 
        => obj is ValueObject other && ValuesAreEqual(other);

    public override int GetHashCode() 
        => GetAtomicValues().Aggregate(default(int), HashCode.Combine); 
}