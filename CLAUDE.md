# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Build and Run Commands

- **Build**: `dotnet build` from the repository root
- **Run benchmarks**: `dotnet run --project PerfTesting/PerfTesting.csproj`
- **Restore packages**: `dotnet restore`

## Running Specific Benchmarks

To run a specific benchmark, edit `PerfTesting/PerfTesting/Runner.cs` and uncomment the desired test class on line ~36. Only one benchmark should be active at a time for clean results.

Example:
```csharp
BenchmarkRunner.Run<RecomposeTests>();  // Currently active
// BenchmarkRunner.Run<ContainsTests>(); // Comment out others
```

Results are automatically saved to `BenchmarkDotNet.Artifacts/results/` with multiple formats (CSV, HTML, Markdown).

## Architecture Overview

This is a .NET performance testing project using **BenchmarkDotNet** to compare different approaches to common programming tasks. The solution contains:

- **PerfTesting** (.NET 8.0) - Main benchmarking project with 20+ benchmark classes
- **Scratch** (.NET 7.0) - Experimental utilities

### Benchmark Categories

**String Operations** (`Boxing/`, `Strings/`):
- String search methods (Contains, IndexOf, Regex vs Span)
- Substring counting algorithms  
- StringBuilder patterns
- String manipulation and replacement

**Collections** (`Collections/`):
- Array-to-List conversion methods
- LINQ performance comparisons
- Collection extension methods

**Memory and Boxing** (`Boxing/`):
- Class vs struct performance
- Value type vs reference type allocation patterns

**Date/Time** (`DateAndTime/`):
- DateTime API comparisons
- .NET DateTime vs NodaTime library performance

**System Performance** (`Reflection/`, `Synchronization/`):
- Reflection vs cached reflection
- Lock vs SemaphoreSlim vs FrozenDictionary

### Benchmark Patterns

All benchmark classes follow consistent patterns:
- Use `[MemoryDiagnoser, ShortRunJob]` attributes
- Methods marked with `[Benchmark]` 
- Static test data initialization for consistent measurements
- Include both execution time and memory allocation tracking

## Key Dependencies

- **BenchmarkDotNet 0.13.12** - Primary benchmarking framework
- **NodaTime 3.1.11** - Alternative date/time library for comparisons
- Target framework: .NET 8.0

## Development Notes

- Single benchmark execution by modifying `Runner.cs`
- Results include statistical analysis (mean, error, standard deviation)
- Test data uses realistic scenarios (e.g., Hobbit text excerpt for string operations)
- Focus on comparing different .NET API approaches for the same functionality

## Code Style and Guidelines

**Language**: All code is C#

**Code Style**:
- Use `var` when type is obvious from context
- Member variables use `_lowerCamel` naming convention  
- Use braces with conditionals and loops in Allman style
- In methods with many conditionals, use return ternary for final two cases when readable

**Performance-Focused Practices**:
- For string parsing/manipulation, prefer `Span<T>` and indexing over `Split()` when equally readable
- Use nullable reference types; prefer empty collections/strings over null when possible
- Benchmark methods should return results to prevent dead code elimination

**Code Quality**:
- Prefer elegance, composability, and maintainability over cleverness
- Comments should explain "why" not "what" - avoid if context makes intent clear
- When showing code examples, focus on the logic rather than using statements or namespace details

## Git Commit Guidelines

- NEVER include references to Claude, AI assistance, or tool usage in commit messages or pull request descriptions
- Keep commit messages concise and focused on the technical changes made
- Use standard conventional commit format when applicable