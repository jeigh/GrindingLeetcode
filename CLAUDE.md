# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Repository Purpose

A polyglot LeetCode practice repository. The owner writes solutions by hand — do not implement solutions unless explicitly asked. AI-generated tests are acceptable and encouraged; AI-generated solutions are not committed unless the owner was personally involved.

## Build & Test Commands

### .NET (C#, VB)
```bash
dotnet build
dotnet test GrindingLeetCode.UnitTests
# Run a single test class
dotnet test GrindingLeetCode.UnitTests --filter "ClassName=Combinations_77_Tests"
# Run a single test method
dotnet test GrindingLeetCode.UnitTests --filter "Name=Combine_Example1_ReturnsCorrectCombinations"
```

### TypeScript (`LeetCodeProblems.Typescript/`)
```bash
npm test
npm run build
npm run test:watch
```

### C++ (Visual Studio only)
Build and run tests via Visual Studio Test Explorer or VS Developer Command Prompt using MSBuild with the v143 toolset.

## Architecture

The solution is organized into language-specific projects all targeting the same problem set:

- **`LeetCodeProblems.Interfaces`** — Defines `I{ProblemName}_{###}.cs` contracts and shared data structures (`TreeNode`, `ListNode`, `Node`, `QuadNode`). All implementations must satisfy these interfaces.
- **`LeetCodeProblems` (C#)** — C# 12 / .NET 8 implementations, organized by algorithm category subfolder (e.g., `Backtracking/`, `BinarySearch/`, `SlidingWindow/`, `TwoPointers/`, `Stack/`, `HashingOrArrays/`, `Tree/`, `LinkedList/`). Some older files at root level lack subfolder organization.
- **`LeetCodeProblems.VisualBasic`** — VB.NET implementations organized by category, parallel to C#.
- **`LeetCodeProblems.UnmanagedCpp`** — Header-only C++20 library. Each implementation is a `.h` file. Uses abstract base classes mirroring the .NET interfaces.
- **`GrindingLeetCode.UnitTests`** — MSTest v3 tests for all managed (.NET) implementations, organized into `Easy/`, `Medium/`, `Hard/` subfolders.
- **`GrindingLeetcode.Unmanaged.UnitTests`** — Google Test suite for C++ implementations.
- **`LeetCodeProblems.Typescript`** — TypeScript implementations with Jest tests.

## Naming Conventions

| Artifact | Pattern | Example |
|---|---|---|
| Implementation | `{ProblemName}_{Strategy}_{Language}_{###}.{ext}` | `Combinations_Backtracking_CSharp_77.cs` |
| Interface | `I{ProblemName}_{###}.cs` | `ICombinations_77.cs` |
| Test class | `{ProblemName}_{###}_Tests.cs` | `Combinations_77_Tests.cs` |

## Namespace Conventions

- Implementations: `LeetCodeProblems.CSharp.{CategoryName}` or `LeetCodeProblems.VisualBasic.{CategoryName}`
- Interfaces: `LeetCodeProblems.Interfaces.{Difficulty}` (e.g., `Easy`, `Medium`, `Hard`)
- Tests: `GrindingLeetCode.UnitTests.{Difficulty}`

## Test Structure (Critical)

All MSTest test classes **must** use the `DynamicData` pattern to test every implementation (C# and VB) with identical test cases. Never use `[TestInitialize]` to instantiate solutions.

```csharp
[TestClass]
public class ProblemName_###_Tests
{
    public static IEnumerable<object[]> GetImplementations()
    {
        yield return new object[] { new CSharpImpl_###() };
        yield return new object[] { new VBImpl_###() };
    }

    [TestMethod]
    [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
    public void MethodName_Scenario_ExpectedResult(IInterface_### solution)
    {
        // Arrange
        // Act
        // Assert
    }
}
```

Group helper methods for constructing test data (e.g., `CreateList()`, `TreeFromArray()`) in a `#region Helper Methods` section. Test names follow `MethodName_Scenario_ExpectedResult` format. Target 20–30+ test cases per problem covering LeetCode examples, edge cases, and boundary conditions.

## Implementation Style

Always include time/space complexity comments above the method:

```csharp
// time complexity: O(n)
// space complexity: O(1)
public IList<IList<int>> Combine(int n, int k) { ... }
```
