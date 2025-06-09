using LivingDocumentation.Cli.Models;
using Microsoft.CodeAnalysis;

namespace LivingDocumentation.Cli.Analysers;

public interface IAnalyseDocument
{
    Task<List<AttributeInstance>> AnalyseDocumentAsync(Document document);
}