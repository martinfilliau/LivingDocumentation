# LivingDocumentation.Cli

Tool to analyse a codebase (`.sln` or `.csproj`), list all instances of some specified annotations and generate a report.

## Running

Simply run `dotnet run X Y` from the project folder, with:
- X = path to the `.sln` or `.csproj` file
- Y = output path for the markdown report

## TODO

- [ ] Handle multiple projects in an `.sln`
- [ ] Filter by namespace
- [ ] Filter by symbol? (class, method...)
- [ ] Configure annotations to be used
- [ ] Use standard `[Obsolete]` attribute
- [ ] Different output formats (e.g. JSON, CSV...)
- Optimisation strategies:
  - [ ] Parallel processing of documents (?)
  - [ ] Pre-filter to only analyse files having an annotation (e.g. `File.ReadAllText`)
- [ ] Pack as a dotnet tool? `dotnet pack` + `dotnet tool install --global --add-source ./nupkg living-documentation` + `living-documentation path/to/project.csproj report.md`
- [ ] CI: ability to build metrics, flag increase of some annotations?
