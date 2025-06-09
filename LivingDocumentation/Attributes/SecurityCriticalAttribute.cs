namespace LivingDocumentation.Attributes;

/// <summary>
/// Flags sensitive areas that require scrutiny and should not be changed lightly.
/// </summary>
/// <param name="reason">Brief explanation of the hotspot</param>
[AttributeUsage(AttributeTargets.Method | AttributeTargets.Class | AttributeTargets.Property, Inherited = false, AllowMultiple = true)]
public class SecurityCriticalAttribute(string reason) : Attribute
{
    public string Reason { get; set; } = reason;
}