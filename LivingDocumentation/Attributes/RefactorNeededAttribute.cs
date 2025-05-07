namespace LivingDocumentation.Attributes;

public enum RefactorNeededReason
{
    Performance,
    Readability,
    Maintainability,
    Testability,
    Security,
}

/// <summary>
/// Indicates that the associated code element needs to be refactored.
/// This attribute can be applied to classes, methods, or properties.
/// </summary>
/// <remarks>
/// The attribute allows developers to document areas in the codebase that require improvements or restructuring,
/// along with an optional reason for why the refactoring is necessary.
/// </remarks>
/// <param name="reason">A brief description of why the refactoring is required.</param>
[AttributeUsage(AttributeTargets.Method | AttributeTargets.Class | AttributeTargets.Property, Inherited = false, AllowMultiple = true)]
public class RefactorNeededAttribute(string reason, RefactorNeededReason category) : Attribute
{
    public string Reason { get; } = reason;
    public RefactorNeededReason Category { get; } = category;
}