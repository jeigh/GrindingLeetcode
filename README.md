# Grinding LeetCode

A polyglot repository for practicing LeetCode data structures and algorithms problems across multiple programming languages and paradigms.

## 📋 Overview

This repository contains implementations of LeetCode problems in multiple languages (C#, Visual Basic, and C++), organized to facilitate learning DSA concepts through different programming paradigms. The project emphasizes clean code, comprehensive testing, and cross-language comparisons.

## 🏗️ Project Structure

### Core Implementation Projects

#### `LeetCodeProblems.CSharp`
**Language:** C# 12  
**Target:** .NET 8  
**Purpose:** Primary implementation project containing C# solutions to LeetCode problems.

- Solutions organized by problem category (Tree, LinkedList, etc.)
- Multiple implementation strategies per problem (recursive, iterative, stack-based, etc.)
- Implements interfaces defined in `LeetCodeProblems.Interfaces`
- Focus on idiomatic C# patterns and modern language features

#### `LeetCodeProblems.VisualBasic`
**Language:** Visual Basic  
**Target:** .NET 8  
**Purpose:** Visual Basic implementations of LeetCode problems.

- Provides VB.NET equivalents of C# solutions
- Demonstrates language interoperability within the .NET ecosystem
- Allows comparison of algorithm implementations across C# and VB syntaxes

#### `LeetCodeProblems.UnmanagedCpp`
**Language:** C++ (C++20)  
**Platform:** Windows (Visual Studio 2022, v143 toolset)  
**Purpose:** Native C++ implementations of LeetCode problems.

- Header-only library design
- Modern C++ (C++20) features
- Focus on performance-critical implementations
- Provides comparison with managed (.NET) implementations
- Compiled as a static library

### Interface & Shared Code

#### `LeetCodeProblems.Interfaces`
**Language:** C# 12  
**Target:** .NET 8  
**Purpose:** Defines contracts and shared data structures for all implementations.

- Interface definitions for each LeetCode problem
- Shared data structures (`TreeNode`, `ListNode`, etc.)
- Ensures consistency across C# and VB implementations
- Nullable reference types enabled for type safety

### Testing Projects

#### `GrindingLeetCode.UnitTests`
**Framework:** MSTest v3  
**Target:** .NET 8  
**Purpose:** Comprehensive test suite for managed (.NET) implementations.

- 40+ tests per problem covering:
  - LeetCode official examples
  - Edge cases (empty inputs, single elements, large datasets)
  - Different tree/list structures (balanced, skewed, sparse)
  - Value edge cases (negative, zero, duplicates, large values)
  - Property-based tests (invariants, idempotency)
- Dynamic test data approach allows testing multiple implementations simultaneously
- Tests both C# and Visual Basic implementations

#### `GrindingLeetcode.Unmanaged.UnitTests`
**Framework:** Google Test (gtest)  
**Platform:** Windows (Visual Studio 2022, v143 toolset)  
**Purpose:** Test suite for C++ implementations.

- Native C++ testing using Google Test framework
- Comprehensive coverage similar to managed tests
- Helper utilities for tree/list construction and validation
- Memory management verification

## Use of AI
In general, I allow AI (copilot) to generate the unit tests for me BEFORE writing the implementation.  I will not directly commit a solution to the repo unless I personally was involved in creating it.  After all, the purpose of this repo is to educate ME, not copilot.

In other words, I write the solutions by hand, but vibe-code the unit tests.

And if it isn't clear from context, I also allowed copilot to generate most of this readme. ;-) 

## 🔧 Technical Stack

| Component | Technology |
|-----------|-----------|
| **Managed Languages** | C# 12, Visual Basic |
| **.NET Runtime** | .NET 8 |
| **Native Language** | C++20 |
| **Managed Testing** | MSTest 3.6+ |
| **Native Testing** | Google Test (gtest) |
| **IDE** | Visual Studio 2022 |
| **Build System** | MSBuild (managed), MSBuild with v143 toolset (C++) |

## 🚀 Getting Started

### Prerequisites
- Visual Studio 2022 (or later) with:
  - .NET 8 SDK
  - C++ development tools
  - MSTest and Google Test test adapters
- Windows 10/11 (for C++ projects)

### Building the Solution

#### Managed Projects (.NET)
```bash
dotnet build
```

#### Running Tests

**Managed Tests:**
```bash
dotnet test GrindingLeetCode.UnitTests
```

**C++ Tests:**
Build and run through Visual Studio Test Explorer or:
```bash
# From Visual Studio Developer Command Prompt
msbuild GrindingLeetcode.Unmanaged.UnitTests.vcxproj
```

## 📊 Testing Philosophy

### Comprehensive Coverage
Each problem implementation includes extensive test coverage:
- **Basic cases**: Simple inputs, edge structures
- **Boundary cases**: Empty inputs, single elements, maximum constraints
- **Structure variations**: Balanced, skewed, sparse, deep trees/lists
- **Value variations**: Negative numbers, zeros, duplicates, large values
- **Property tests**: Invariant verification (e.g., inversion twice returns original)

### Multi-Implementation Testing
Tests are designed to validate multiple implementations of the same problem simultaneously using dynamic test data, ensuring consistency across:
- Different algorithmic approaches (recursive vs. iterative)
- Different data structures (stack-based, two-pointer, etc.)
- Different languages (C#, VB, C++)

## 📝 Code Organization Patterns

### Naming Conventions
- **Implementation files**: `{ProblemName}_{Strategy}_{Language}_{ProblemNumber}.{ext}`
  - Example: `BinaryTreeInorderTraversal_Recursion_CSharp_94.cs`
- **Interface files**: `I{ProblemName}_{ProblemNumber}.cs`
  - Example: `IBinaryTreeInorderTraversal_94.cs`
- **Test files**: `{ProblemName}_{ProblemNumber}_Tests.{ext}`
  - Example: `BinaryTreeInorderTraversal_94_Tests.cs`

### Implementation Strategies
Each problem may have multiple implementations demonstrating different approaches:
- **Recursive**: Classic recursive solutions
- **Iterative/Stack**: Stack-based iterative approaches
- **Two-pointer**: Pointer manipulation techniques
- **Optimized variants**: Performance or space optimizations

## 🎓 Learning Objectives

This repository serves as a resource for:
1. **Algorithm mastery**: Multiple implementations of the same problem reveal different perspectives
2. **Language comparison**: See how the same algorithm is expressed across C#, VB, and C++
3. **Testing practices**: Learn comprehensive test design through extensive test suites
4. **Performance awareness**: Compare managed vs. native implementations
5. **Code quality**: Emphasis on clean, well-documented, production-ready code

## 📈 Repository Status

🚧 **Active Development** - This repository is continuously updated with new problems and implementations.

### Current Statistics
- **Languages**: 3 (C#, Visual Basic, C++)
- **Test Coverage**: Comprehensive (40+ tests per problem typical)
- **Problems**: Growing collection covering Easy to Hard difficulty

## 🤝 Contributing

This is a personal learning repository, but suggestions and discussions are welcome via issues.

## 📄 License

This project is for educational purposes. Individual LeetCode problems are property of LeetCode.

## 🔗 Links

- [LeetCode Platform](https://leetcode.com)
- [Repository](https://github.com/jeigh/GrindingLeetcode)

---

**Note**: File counts, specific problem lists, and individual implementations change frequently as the repository grows. This README focuses on the organizational structure and high-level purpose of each project rather than cataloging every implementation.
