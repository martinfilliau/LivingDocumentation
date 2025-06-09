namespace LivingDocumentation.Cli.Models;

/// <summary>
/// Represents an instance of the attribute used in the codebase
/// </summary>
/// <param name="AttributeName">Name of the attribute (e.g. [RefactorNeeded]</param>
/// <param name="Symbol">Name of the method or class</param>
/// <param name="Reason">"Editorial" reason of the attribute's presence</param>
/// <param name="DocumentLocation">Full file path</param>
public record AttributeInstance(string AttributeName, string Symbol, string Reason, string? DocumentLocation);
