﻿using Skidly.Shared.Abstractions.Exceptions;

namespace Skidly.Domain.Exceptions;

public sealed class AreaWithSameNameAlreadyExistException : SkidlyException
{
    public AreaWithSameNameAlreadyExistException() : base("The area with the same name already exist.")
    {
    }
}