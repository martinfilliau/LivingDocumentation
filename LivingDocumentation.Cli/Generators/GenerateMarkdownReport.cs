using LivingDocumentation.Cli.Models;

namespace LivingDocumentation.Cli.Generators;

public class GenerateMarkdownReport : IGenerateReport
{
    /// <inheritdoc />
    public async Task GenerateReport(List<AttributeInstance> attributes, string writePath, CancellationToken cancellationToken)
    {
        await using var writer = new StreamWriter(writePath);
        await writer.WriteLineAsync("# Refactoring Documentation\n");

        foreach (var attribute in attributes)
        {
            cancellationToken.ThrowIfCancellationRequested();
            
            await writer.WriteLineAsync($"## {attribute.Symbol}");
            await writer.WriteLineAsync($"- **Reason:** {attribute.Reason}");
            await writer.WriteLineAsync($"- **File:** {attribute.DocumentLocation}\n");
        }
    }
}