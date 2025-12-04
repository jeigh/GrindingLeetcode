# GitHub Copilot Instructions for GrindingLeetcode Workspace

This document provides guidelines and conventions for GitHub Copilot when working in this workspace.

---

## Unit Testing Standards

### Test Structure for LeetCode Problems

All unit tests for LeetCode problem implementations must follow these conventions:

#### 1. Use DynamicData Pattern for Multiple Implementations

- **Always use `DynamicData`** to test all implementations of an interface
- Define a static method `GetImplementations()` that yields all implementations to test
- Apply `[DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]` to each test method
- Each test method should accept the interface type as a parameter

**Example:**
```csharp
[TestClass]
public class ProblemName_###_Tests
{
    public static IEnumerable<object[]> GetImplementations()
    {
        yield return new object[] { new CSharpSolution_###() };
        yield return new object[] { new VisualBasicSolution_###() };
        // Add more implementations as needed
    }

    [TestMethod]
    [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
    public void MethodName_Scenario_ExpectedResult(IProblemInterface_### solution)
    {
        // Arrange
        
        // Act
        
        // Assert
    }
}
```

#### 2. Avoid TestInitialize for Solution Instantiation

- **Do NOT use `[TestInitialize]`** with separate instance variables for each implementation
- Use DynamicData instead to instantiate solutions per test
- This ensures all implementations are tested with the same test cases consistently

**Avoid this pattern:**
```csharp
// ? DON'T DO THIS
private Solution1 _solution1;
private Solution2 _solution2;

[TestInitialize]
public void Initialize()
{
    _solution1 = new Solution1();
    _solution2 = new Solution2();
}
```

**Use this pattern instead:**
```csharp
// ? DO THIS
public static IEnumerable<object[]> GetImplementations()
{
    yield return new object[] { new Solution1() };
    yield return new object[] { new Solution2() };
}

[TestMethod]
[DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
public void TestName(ISolution solution)
{
    // Test logic here
}
```

#### 3. Test Naming Convention

- Format: `MethodName_Scenario_ExpectedResult`
- Be descriptive about the test scenario
- Examples:
  - `HasCycle_Example1_CycleAtPosition1_ReturnsTrue`
  - `DeleteNode_DeleteFirstNode_WorksCorrectly`
  - `MergeTwoLists_Example2_BothEmpty_ReturnsNull`
  - `ReverseList_SingleElement_ReturnsSameElement`

#### 4. Test Organization

- Group related helper methods in a `#region Helper Methods` section
- Include helpers for:
  - Creating test data structures (e.g., `CreateList()`, `CreateListWithCycle()`)
  - Converting data structures to arrays for assertions (e.g., `LinkedListToArray()`)
  - Custom assertion helpers (e.g., `AssertListEquals()`)

**Example:**
```csharp
#region Helper Methods

/// <summary>
/// Creates a linked list from an array of values
/// </summary>
private ListNode CreateList(params int[] values)
{
    if (values == null || values.Length == 0) return null;
    
    ListNode head = new ListNode(values[0]);
    ListNode current = head;
    
    for (int i = 1; i < values.Length; i++)
    {
        current.next = new ListNode(values[i]);
        current = current.next;
    }
    
    return head;
}

/// <summary>
/// Converts a linked list to an array for easy comparison
/// </summary>
private int[] LinkedListToArray(ListNode head)
{
    var result = new List<int>();
    var current = head;
    
    while (current != null)
    {
        result.Add(current.val);
        current = current.next;
    }
    
    return result.ToArray();
}

/// <summary>
/// Asserts that two linked lists have the same values
/// </summary>
private void AssertListEquals(int[] expected, ListNode actual)
{
    var actualArray = LinkedListToArray(actual);
    CollectionAssert.AreEqual(expected, actualArray);
}

#endregion
```

#### 5. Test Coverage Requirements

Each test class should include:
- **All examples** from the LeetCode problem description
- **Edge cases**: null, empty, single element, two elements, etc.
- **Boundary conditions**: first, last, middle elements
- **Special values**: negatives, zeros, large numbers, duplicates
- **Performance considerations** for large inputs (where applicable)
- **Order/sequence preservation validation** (where applicable)
- **Validation tests** that verify the problem requirements are met

Aim for **20-30 test cases minimum** per problem to ensure comprehensive coverage.

#### 6. Arrange-Act-Assert Pattern

Always use clear AAA pattern with comments:
```csharp
[TestMethod]
[DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
public void MethodName_Scenario_ExpectedResult(IInterface solution)
{
    // Arrange
    var input = CreateTestData();

    // Act
    var result = solution.Method(input);

    // Assert
    Assert.AreEqual(expected, result);
}
```

#### 7. File Location and Naming

- **Easy problems**: `GrindingLeetCode.UnitTests\Easy\ProblemName_###_Tests.cs`
- **Medium problems**: `GrindingLeetCode.UnitTests\Medium\ProblemName_###_Tests.cs`
- **Hard problems**: `GrindingLeetCode.UnitTests\Hard\ProblemName_###_Tests.cs`

Where `###` is the LeetCode problem number.

#### 8. Test Class Structure

```csharp
using LeetCodeProblems.CSharp.CategoryName;
using LeetCodeProblems.Interfaces.Difficulty;
using LeetCodeProblems.Shared;
using LeetCodeProblems.VisualBasic.CategoryName;

namespace GrindingLeetCode.UnitTests.Difficulty
{
    [TestClass]
    public class ProblemName_###_Tests
    {
        // 1. GetImplementations method
        public static IEnumerable<object[]> GetImplementations()
        {
            yield return new object[] { new CSharpImplementation() };
            yield return new object[] { new VBImplementation() };
        }

        // 2. Helper Methods region
        #region Helper Methods
        
        // Helper methods here
        
        #endregion

        // 3. Test methods grouped logically
        
        // LeetCode Examples
        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Method_Example1_ExpectedBehavior(IInterface solution)
        {
            // Test
        }

        // Edge Cases
        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Method_EdgeCase_ExpectedBehavior(IInterface solution)
        {
            // Test
        }

        // Validation Tests
        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Method_ValidatesRequirement_ExpectedBehavior(IInterface solution)
        {
            // Test
        }
    }
}
```

### Why DynamicData?

This pattern ensures:
- ? All implementations are tested with identical test cases
- ? Easy to add new implementations without duplicating tests
- ? Consistent test coverage across C#, Visual Basic, and other implementations
- ? Clear identification of which implementation fails when tests break
- ? Reduced code duplication and maintenance overhead
- ? Better maintainability as test logic is centralized

### When Creating Tests for Existing Implementations

When asked to create tests for implementations that already exist:

1. **Find all implementations** of the interface (C#, VB, etc.)
2. **Include all implementations** in `GetImplementations()`
3. **DO NOT implement the solution** unless explicitly asked
4. **Focus on comprehensive test coverage** that will validate the implementation when completed

---

## Project Structure

### Solution Projects

- **LeetCodeProblems.CSharp**: C# implementations of LeetCode problems
- **LeetCodeProblems.VisualBasic**: Visual Basic implementations of LeetCode problems
- **LeetCodeProblems.Interfaces**: Interface definitions for all problems
- **GrindingLeetCode.UnitTests**: MSTest unit tests for all implementations

### Namespace Conventions

- **Implementations**: `LeetCodeProblems.CSharp.CategoryName` or `LeetCodeProblems.VisualBasic.CategoryName`
  - Examples: `LinkedList`, `HashingOrArrays`, `TwoPointers`, `BinarySearch`, etc.
- **Interfaces**: `LeetCodeProblems.Interfaces.Difficulty`
  - Examples: `Easy`, `Medium`, `Hard`
- **Tests**: `GrindingLeetCode.UnitTests.Difficulty`

### File Naming Conventions

- **Implementation**: `ProblemNameLanguage_###.cs` or `ProblemNameLanguage_###.vb`
  - Example: `LinkedListCycleFastAndSlowPointersCSharp_141.cs`
- **Interface**: `IProblemName_###.cs`
  - Example: `ILinkedListCycle_141.cs`
- **Tests**: `ProblemName_###_Tests.cs`
  - Example: `LinkedListCycle_141_Tests.cs`

---

## General Coding Guidelines

### When Implementing Solutions

- Add **time complexity** and **space complexity** comments above the method
- Use descriptive variable names
- Follow C# or VB.NET conventions based on the language
- Implement the interface exactly as defined

**Example:**
```csharp
// time complexity: O(n)
// space complexity: O(1)
public bool HasCycle(ListNode head)
{
    // Implementation
}
```

### When Working with Linked Lists

- Use the `ListNode` class from `LeetCodeProblems.Shared` namespace
- Remember that `ListNode` uses lowercase field names: `val` and `next`
- Handle null cases appropriately

---

## Testing Framework

- Use **MSTest** framework (`[TestClass]`, `[TestMethod]`, etc.)
- Use `Assert` class for assertions
- Use `CollectionAssert` for collection comparisons
- Follow AAA (Arrange-Act-Assert) pattern consistently

---

## Summary

When GitHub Copilot is asked to create unit tests for LeetCode problems:

1. ? **Always use DynamicData pattern**
2. ? Test all implementations of the interface
3. ? Create 20-30+ comprehensive test cases
4. ? Include helper methods for test data creation and assertions
5. ? Follow AAA pattern with clear comments
6. ? Use descriptive test names
7. ? Place tests in the correct difficulty folder
8. ? Do NOT use TestInitialize for solution instances
9. ? Do NOT implement the solution unless explicitly asked

This ensures consistency, maintainability, and comprehensive test coverage across the entire workspace.
