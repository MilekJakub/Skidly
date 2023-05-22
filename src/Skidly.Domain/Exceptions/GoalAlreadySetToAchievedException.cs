﻿using Skidly.Shared.Abstractions.Exceptions;

namespace Skidly.Domain.Exceptions;

public sealed class GoalAlreadySetToAchievedException : SkidlyException
{
    public GoalAlreadySetToAchievedException() : base("The goal was already set as achieved.")
    {
    }
}