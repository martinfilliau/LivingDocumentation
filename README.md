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

### More tools to come

## Generation
