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
List<Project> projects = [];

if (inputPath.EndsWith(".sln", StringComparison.OrdinalIgnoreCase))
{
    var solution = await workspace.OpenSolutionAsync(inputPath);
    projects = solution.Projects.ToList();
    Console.WriteLine("!! at the moment, only the first project will be analysed");
}
else
{
    var project = await workspace.OpenProjectAsync(inputPath);
    projects.Add(project);
}

List<AttributeInstance> attributes = [];
var analyser = new RoslynAnalyser
{
    Annotations = ["RefactorNeeded"]
};

foreach (var project in projects)
{
    foreach (var document in project.Documents)
    {
        // XXX TODO include project name / path?
        var results = await analyser.AnalyseDocumentAsync(document);
        attributes.AddRange(results);
    }   
}

var reportWriter = new GenerateMarkdownReport();
await reportWriter.GenerateReport(attributes, outputPath, CancellationToken.None);

Console.WriteLine($"=> Refactoring documentation generated at {outputPath}");
