# Architecture Decision Record (ADR)

Title: Refactoring Documentation Generation with Roslyn Source Generator

Date: 2025-05-07

## Context

The goal is to generate and maintain documentation listing all parts of the code annotated with the [RefactorNeeded] attribute, making technical debt visible and manageable.

## Decision

We have chosen to implement a Roslyn Source Generator to automatically generate a Markdown document (RefactoringDocumentation.md) listing all code elements annotated with the [RefactorNeeded] attribute. This approach is preferred because it is:

- Automated: The documentation is generated directly from the code without manual effort.
- Accurate: The generator reflects the actual state of the code at each compilation.
- Integrated: The generated documentation is part of the project and is automatically updated.
- Flexible: Can be extended to support other types of annotations if needed.

## Key Technical Details

The source generator is implemented using IIncrementalGenerator from Roslyn.

The `[RefactorNeeded]` attribute can be applied to classes, methods, or properties.

The generator scans the code for this attribute and extracts information (symbol name, reason, and file path).

The documentation is generated in Markdown format (RefactoringDocumentation.md), making it readable and easy to maintain.

The file is saved directly in the project directory during debug mode (#if DEBUG) for ease of use.

## Alternatives Considered

### 1. Manual Documentation

Manually maintaining a document listing all areas needing refactoring.

Rejected: Error-prone and difficult to maintain as the code evolves.

### 2. Static Analysis Tool Integration

Using external tools like SonarQube or Resharper for code quality.

Rejected: These tools do not directly generate a refactoring documentation file and are often overkill for this specific need.

### 3. Using Comments (// TODO, // REFACTOR)

Adding comments throughout the code to mark refactoring areas.

Rejected: Not easily discoverable and not centralized.

## Consequences

### Positive

- Automatically generated and up-to-date refactoring documentation.
- Easily extendable to include other custom attributes.
- Documentation is always consistent with the code.

### Negative

- Slightly increases build time due to the source generator.
- Requires understanding Roslyn source generators for future maintenance.

## Future Improvements

- Add support for other custom attributes (e.g., [TechnicalDebt], [Deprecated]).
- Allow configuration of the output path for the documentation file.
