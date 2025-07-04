﻿namespace LivingDocumentation.Attributes;

public enum RefactorNeededReason
{
    Performance,
    Readability,
    Maintainability,
    Testability,
    Security,
}

public enum RefactorImpact
{
    Low,
    Medium,
    High,
}

public enum EstimatedEffort
{
    Low,
    Medium,
    High,
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
/// <param name="category"></param>
[AttributeUsage(AttributeTargets.Method | AttributeTargets.Class | AttributeTargets.Property | AttributeTargets.Enum | AttributeTargets.Interface,
    Inherited = false, AllowMultiple = true)]
public class RefactorNeededAttribute(string reason, RefactorNeededReason category, RefactorImpact impact, EstimatedEffort effort) : Attribute
{
    public string Reason { get; } = reason;
    public RefactorNeededReason Category { get; } = category;
    public RefactorImpact RefactorImpact { get; set; } = impact;
    public EstimatedEffort EstimatedEffort { get; set; } = effort;
}