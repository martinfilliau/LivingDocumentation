using LivingDocumentation.Cli.Models;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace LivingDocumentation.Cli.Analysers;

public class RoslynAnalyser : IAnalyseDocument
{
    public async Task<List<AttributeInstance>> AnalyseDocumentAsync(Document document)
    {
        List<AttributeInstance> attributes = [];
        
        var root = await document.GetSyntaxRootAsync();
        var model = await document.GetSemanticModelAsync();
        if (root == null || model == null) return attributes;

        var candidates = root.DescendantNodes()
            .OfType<AttributeSyntax>()
            // XXX TODO stop hardcoding RefactorNeeded here, 
            .Where(attr => attr.Name.ToString().Contains("RefactorNeeded"));

        foreach (var attribute in candidates)
        {
            var parent = attribute.Parent?.Parent;
            if (parent == null) continue;
            var symbol = model.GetDeclaredSymbol(parent);
            if (symbol == null) continue;

            var reasonArg = attribute.ArgumentList?.Arguments.FirstOrDefault();
            var reason = reasonArg != null ? reasonArg.ToString().Trim('"') : "No reason specified";
        
            attributes.Add(new AttributeInstance(attribute.Name.ToString(), symbol.ToDisplayString(), reason, document.FilePath));
        }
        return attributes;
    }
}