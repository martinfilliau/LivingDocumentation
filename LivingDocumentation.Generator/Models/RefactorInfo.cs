namespace LivingDocumentation.Generator.Models;

public record RefactorInfo
{
    /// <summary>
    /// Symbol attached to the annotation (class, method...)
    /// </summary>
    public string SymbolName { get; init; } = "";
    
    /// <summary>
    /// Explanation of why the refactoring is needed
    /// </summary>
    public string Reason { get; init; } = "";
    
    /// <summary>
    /// Filepath of the file
    /// </summary>
    public string FilePath { get; init; } = "";
}