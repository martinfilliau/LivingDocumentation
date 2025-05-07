using System.Text;
using LivingDocumentation.Attributes;
using LivingDocumentation.Generator.Builders;
using LivingDocumentation.Generator.Models;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Text;

namespace LivingDocumentation.Generator.Generators;

[Generator]
public class RefactorDocumentationGenerator : IIncrementalGenerator
{
    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        var refactorAttributes = context.SyntaxProvider
            .CreateSyntaxProvider(
                predicate: static (s, _) => s is Microsoft.CodeAnalysis.CSharp.Syntax.AttributeSyntax,
                transform: static (ctx, _) => GetRefactorInfo(ctx))
            .Where(static info => info is not null);

        context.RegisterSourceOutput(refactorAttributes.Collect(), (sourceProductionContext, refactorInfos) =>
        {
            try
            {
                var sourceCode = MarkdownFileClass.BuildCSharpClassWithMarkdown(refactorInfos);
                sourceProductionContext.AddSource("RefactoringDocumentation.g",
                    SourceText.From(sourceCode, Encoding.UTF8));
            }
            catch (Exception ex)
            {
                sourceProductionContext.ReportDiagnostic(Diagnostic.Create(new DiagnosticDescriptor(
                            "GEN001",
                            "Source Generator Error",
                            $"An error occurred in the RefactorDocumentationGenerator: {ex.Message}",
                            "SourceGeneration",
                            DiagnosticSeverity.Error,
                            isEnabledByDefault: true), location: null));
            }
        });
    }

    private static RefactorInfo? GetRefactorInfo(GeneratorSyntaxContext context)
    {
        var semanticModel = context.SemanticModel;
        var node = (Microsoft.CodeAnalysis.CSharp.Syntax.AttributeSyntax)context.Node;

        var symbol = semanticModel.GetSymbolInfo(node).Symbol?.ContainingSymbol;
        if (symbol == null) return null;

        foreach (var attribute in symbol.GetAttributes())
        {
            if (attribute.AttributeClass?.Name != "RefactorNeededAttribute") continue;
            
            var reason = attribute.ConstructorArguments.FirstOrDefault().Value?.ToString() ?? "No reason specified.";
            return new RefactorInfo
            {
                SymbolName = symbol.ToDisplayString(),
                Reason = reason,
                FilePath = symbol.Locations.FirstOrDefault()?.SourceTree?.FilePath ?? "Unknown"
            };
        }

        return null;
    }
}
