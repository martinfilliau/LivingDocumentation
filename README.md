# Living Documentation tools

Some tools for C# to create living documentation.

Inspired by some ideas of the book _Living Documentation_ by Cyrille Martraire, where the documentation should be:
- Reliable
- Low-effort (to maintain):
  - Simplicity
  - Standard over custom solutions
  - Evergreen content
  - Refactoring-proof knowledge
- Collaborative
- Insightful

## Tools

### Highlight some areas of a codebase which might need refactoring

Objective: make more visible _known_ technical debt.

Simply annotate a class or method with the attribute `[RefactorNeeded]` from `LivingDocumentation`.

It is possible to add a reason to briefly explain why the refactoring is needed, and use a category
to be able to quickly find a specific area of interest (testability, performance, security, maintainability...).

```C#
[RefactorNeeded("Strongly couples business and external dependencies", RefactorNeededReason.Testability)]
public class DocumentationBuilder 
{
    // ...
}
```

The attribute can be used on a class, a method or a property.

### Highlight areas of a codebase which need special security considerations

Objective: warn the developer, and the code reviewer that an area is _known_ to be security sensitive.

```C#
[SecurityCritical("Parses raw input from the user")
public void Parse(string input)
{
    // ...
```

### More tools to come

## Generation

See `LivingDocumentation.Cli` to get a tool analysing a code base from a `.csproj` or `.sln` file, and generate a Markdown
report. This can be put in a CI context.
