using LivingDocumentation.Cli.Models;

namespace LivingDocumentation.Cli.Generators;

public interface IGenerateReport
{
    /// <summary>
    /// Generate a report
    /// </summary>
    /// <param name="attributes">List of attributes to be written</param>
    /// <param name="writePath">Path where the document should be generated</param>
    /// <param name="cancellationToken">Cancellation token</param>
    Task GenerateReport(List<AttributeInstance> attributes, string writePath, CancellationToken cancellationToken);
}