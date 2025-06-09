using LivingDocumentation.Cli.Analysers;
using LivingDocumentation.Cli.Generators;
using LivingDocumentation.Cli.Models;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.MSBuild;

if (args.Length < 2)
{
    Console.WriteLine("Usage: living-documentation <path-to-sln-or-csproj> <output-md>");
    return;
}

var inputPath = args[0];
var outputPath = args[1];

using var workspace = MSBuildWorkspace.Create();
Project project;

if (inputPath.EndsWith(".sln", StringComparison.OrdinalIgnoreCase))
{
    var solution = await workspace.OpenSolutionAsync(inputPath);
    // XXX TODO handle multiple projects
    project = solution.Projects.First();
    Console.WriteLine("!! at the moment, only the first project will be analysed");
}
else
{
    project = await workspace.OpenProjectAsync(inputPath);
}

List<AttributeInstance> attributes = [];
var analyser = new RoslynAnalyser();

foreach (var document in project.Documents)
{
    var results = await analyser.AnalyseDocumentAsync(document);
    attributes.AddRange(results);
}

var reportWriter = new GenerateMarkdownReport();
await reportWriter.GenerateReport(attributes, outputPath, CancellationToken.None);

Console.WriteLine($"=> Refactoring documentation generated at {outputPath}");
