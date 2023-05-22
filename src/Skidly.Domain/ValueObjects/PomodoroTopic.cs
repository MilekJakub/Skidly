﻿using Skidly.Domain.Exceptions;
using Skidly.Shared.Abstractions.Domain;

namespace Skidly.Domain.ValueObjects;

public class PomodoroTopic : ValueObject
{
    
    public PomodoroTopic(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new EmptyPomodoroTopicException();

        if (name.Length > 25)
            throw new PomodoroTopicTooLongException();

        Value = name;
    }
    
    public string Value { get; private set; }
    
    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
    
    public static implicit operator string(PomodoroTopic topic) => topic.Value;
    public static implicit operator PomodoroTopic(string topic) => new(topic);

    public override string ToString()
    {
        return Value;
    }
}