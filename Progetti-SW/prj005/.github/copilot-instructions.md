<!-- .github/copilot-instructions.md - guidance for AI coding agents -->
# Copilot instructions for prj005

This repo is a minimal .NET console application. The goal of this file is to give an AI coding agent the concise, project-specific information needed to be productive without asking for trivial facts.

**Quick facts**
- **Project type**: .NET Console App (single project)
- **Key files**: `Albero.cs`, `prj005.csproj`
- **Target framework**: `net10.0` (see `prj005.csproj`)
- **Build/run**: `dotnet build` and `dotnet run --project .` from the project folder

**Big picture / architecture**
- This repository contains a small single-project console application implemented in `Albero` namespace.
- `Albero.cs` contains the program entrypoint (`Main`) that prints to the console. There are no other components, services, or external integrations in the repo.

**Project-specific conventions and patterns**
- Uses SDK-style csproj with `ImplicitUsings` enabled and `Nullable` reference types enabled. When adding files, rely on implicit usings unless a type is ambiguous.
- Keep top-level namespace `Albero` consistent with the existing file. New classes should live in the same namespace unless a clear refactor is requested.
- Entry point signature: `public static void Main(string[] args)`.

**Common tasks / developer workflows**
- Build: `dotnet build` (run from the project folder containing `prj005.csproj`)
- Run: `dotnet run --project .` or `dotnet run --project prj005.csproj`
- There are no test projects in the repository. If you add tests, create a new `Xunit` or `NUnit` test project under a `tests/` folder and reference the main project.

**Examples of small changes**
- Add a new class file:
```csharp
namespace Albero;

public class TreePrinter
{
    public static void Print() => Console.WriteLine("Tree");
}
```
- Update `Albero.cs` to call the new helper:
```csharp
public static void Main(string[] args)
{
    TreePrinter.Print();
}
```

**When to ask for clarification**
- If a change would add new projects, tests, or external dependencies, ask where to place them and what CI/test matrix to target.
- If a feature requires persistent state (DB, files), ask which storage and connection strings to use — none are present in the repo.

**Files to inspect for context**
- `Albero.cs` — program entrypoint and current runtime behavior
- `prj005.csproj` — project configuration (target framework, SDK, nullable/implicit usings)

If anything here is incorrect or you'd like additional sections (CI, release notes, testing conventions), tell me what to add or correct.
