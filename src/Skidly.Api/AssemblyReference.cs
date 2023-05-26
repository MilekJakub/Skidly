using System.Reflection;

namespace Skidly.Api;

public static class AssemblyReference
{
    public static readonly Assembly Assembly =
        typeof(AssemblyReference).Assembly;
}
