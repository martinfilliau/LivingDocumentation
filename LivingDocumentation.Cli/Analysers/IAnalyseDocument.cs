using LivingDocumentation.Cli.Models;
using Microsoft.CodeAnalysis;

namespace LivingDocumentation.Cli.Analysers;

public interface IAnalyseDocument
{
    /// <summary>
    /// List of Annotations to analyse
    /// </summary>
    List<string> Annotations { get; set; }
    
    /// <summary>
    /// Analyse a document to get the defined Annotations
    /// </summary>
    Task<List<AttributeInstance>> AnalyseDocumentAsync(Document document);
}