# Coding Standards for GrindingLeetcode

## Project Overview
This repository contains LeetCode problem solutions implemented in C# and Visual Basic, targeting .NET 8, with comprehensive MSTest unit tests.

## Project Structure

```
GrindingLeetcode/
├── LeetCodeProblems/                    # C# implementations
│   ├── Stack/
│   ├── LinkedList/
│   ├── BinarySearch/
│   ├── SlidingWindow/
│   ├── TwoPointers/
│   ├── HashingOrArrays/
│   └── Unconventional/                  # Optimized/non-standard solutions
├── LeetCodeProblems.VisualBasic/        # VB implementations
│   ├── Stack/
│   ├── LinkedList/
│   └── SlidingWindow/
├── LeetCodeProblems.Interfaces/         # Interface definitions
│   ├── Easy/
│   ├── Medium/
│   └── Hard/
└── GrindingLeetCode.UnitTests/          # MSTest unit tests
    ├── Easy/
    ├── Medium/
    └── Hard/
```

## Naming Conventions

### Files and Classes
- **Implementation files**: `{ProblemName}{Language}_{LeetCodeNumber}.cs`
  - Example: `MergeTwoListsCSharp_21.cs`, `ReverseLinkedListVB_206.vb`
- **Interface files**: `I{ProblemName}_{LeetCodeNumber}.cs`
  - Example: `IMergeTwoLists_21.cs`
- **Test files**: `{ProblemName}_{LeetCodeNumber}_Tests.cs`
  - Example: `MergeTwoLists_21_Tests.cs`

### Namespace Organization
- C# implementations: `LeetCodeProblems.CSharp.{Category}`
- VB implementations: `LeetCodeProblems.VisualBasic.{Category}` (use `Namespace` keyword)
- Interfaces: `LeetCodeProblems.Interfaces.{Difficulty}`
- Tests: `GrindingLeetCode.UnitTests.{Difficulty}`

## Implementation Guidelines

### 1. All Solutions Must Implement Their Interface
```csharp
public class DecodeString_394 : IDecodeString_394
{
    public string DecodeString(string s)
    {
        // Implementation
    }
}
```

### 2. Include Complexity Comments
```csharp
// Time complexity: O(n)
// Space complexity: O(1)
public int[] TwoSum(int[] nums, int target)
{
    // ...
}
```

### 3. Add Explanatory Comments for Non-Obvious Logic
```csharp
// Think of this like a base 10 left bitshift
k = k * 10 + (c - '0');
```

### 4. Use Descriptive Variable Names
- ❌ Bad: `i`, `j`, `temp`, `x`
- ✅ Good: `leftPointer`, `rightPointer`, `currentNode`, `activeSegment`

### 5. Prefer Readable Code Over Terse Code
```csharp
// ❌ Avoid complex nested conditionals
if ((betweenSlashes.Length != 2 || betweenSlashes[0] != '.' || betweenSlashes[1] != '/') && betweenSlashes[0] != '/')

// ✅ Extract to helper methods with clear names
if (IsEmptyOrSingleSlash(segment)) return;
if (IsCurrentDirectory(segment)) return;
```

## Performance Optimization

### Mark Optimized Solutions Appropriately
Place highly optimized or unconventional solutions in the `Unconventional/` folder with comments explaining:
1. Why it's faster
2. What tradeoffs were made
3. Credit original source if applicable

```csharp
// I cannot take credit for this solution... I saw it on leetcode as the fastest algorithm,
// recognized that it did not use a stack, and thought it was noteworthy.
// if anything, it should compel the reader to recognize that just because
// it's easier to think of an algorithm with a specific DS in mind, 
// it's not always going to be the fastest solution.
public class SimplifyPathCSharpOptimizedSolution_71 : ISimplifyPath_71
```

### Prefer O(n) StringBuilder Over O(n²) String Concatenation
```csharp
// ❌ Avoid in loops
for (int i = 0; i < count; i++)
{
    result += segment;  // O(n²)
}

// ✅ Use StringBuilder
var sb = new StringBuilder(result.Length + segment.Length * count);
for (int i = 0; i < count; i++)
{
    sb.Append(segment);  // O(n)
}
```

## Unit Testing Standards

### 1. Use DynamicData Pattern for Multiple Implementations
```csharp
[TestClass]
public class MergeTwoLists_21_Tests
{
    public static IEnumerable<object[]> GetImplementations()
    {
        yield return new object[] { new MergeTwoListsCSharp_21() };
        yield return new object[] { new MergeTwoListsVB_21() };
    }

    [TestMethod]
    [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
    public void MergeTwoLists_Example1_ReturnsMergedList(IMergeTwoLists_21 solution)
    {
        // Test implementation
    }
}
```

### 2. Test Naming Convention
Format: `MethodName_Scenario_ExpectedOutcome`

Examples:
- `SimplifyPath_Example1_ReturnsHome`
- `DecodeString_NestedOnce_ReturnsCorrect`
- `MergeTwoLists_BothEmpty_ReturnsNull`

### 3. Comprehensive Test Coverage
Include tests for:
- ✅ All LeetCode examples
- ✅ Edge cases (null, empty, single element)
- ✅ Boundary conditions (min/max values)
- ✅ Common patterns (all increasing, all decreasing, duplicates)
- ✅ Complex scenarios (nested structures, long inputs)

### 4. Use Helper Methods in Tests
```csharp
private ListNode CreateList(params int[] values) { /* ... */ }
private int[] ToArray(ListNode head) { /* ... */ }
private void AssertListEquals(int[] expected, ListNode actual) { /* ... */ }
```

### 5. Minimum 25-30 Test Cases Per Problem
Cover all reasonable scenarios to ensure correctness.

## Visual Basic Specific Guidelines

### Use Clear Loop Structures
```vb
' ✅ Preferred
While current IsNot Nothing
    ' Process
End While

' ⚠️ Avoid unless necessary
While True
    If condition Then Exit While
End While
```

### Use `Is Nothing` for Null Checks
```vb
If list1 Is Nothing Then Return list2
```

### Prefer `AndAlso` / `OrElse` for Short-Circuit Evaluation
```vb
While list1 IsNot Nothing AndAlso list2 IsNot Nothing
    ' Prevents NullReferenceException
End While
```

## Interface Documentation

### Always Include XML Comments
```csharp
/// <summary>
/// Given the head of a singly linked list, reverse the list, and return the reversed list.
/// </summary>
public interface IReverseLinkedList_206
{
    public ListNode ReverseList(ListNode head);
}
```

### Include Constraints and Examples When Available
```csharp
/// <summary>
/// Given an array of integers temperatures represents the daily temperatures, 
/// return an array answer such that answer[i] is the number of days you have to wait 
/// after the ith day to get a warmer temperature. 
/// If there is no future day for which this is possible, keep answer[i] == 0 instead.
/// </summary>
public interface IDailyTemperatures_739
{
    int[] DailyTemperatures(int[] temperatures);
}
```

## Git Workflow

### Commit Messages
Use clear, descriptive commit messages:
- ✅ "Implement DecodeString_394 with stack-based solution"
- ✅ "Add 30 unit tests for SimplifyPath_71"
- ✅ "Optimize MergeTwoLists to use O(1) space"
- ❌ "fix bug"
- ❌ "update"

## Code Review Checklist

Before committing, verify:
- [ ] Solution implements the correct interface
- [ ] Complexity analysis is included in comments
- [ ] Variable names are descriptive
- [ ] Unit tests exist with DynamicData pattern
- [ ] Minimum 25 test cases covering edge cases
- [ ] No obvious performance issues (O(n²) string concatenation, etc.)
- [ ] Code compiles without warnings
- [ ] All tests pass

## Performance Goals

- **Time Complexity**: Aim for optimal complexity (usually O(n) or O(n log n))
- **Space Complexity**: Prefer O(1) in-place solutions when possible
- **Readability**: Code should be self-documenting with clear intent

## Common Patterns

### Dummy Head Pattern (Linked Lists)
```csharp
var dummy = new ListNode(0);
var tail = dummy;
// ... build list
return dummy.next;
```

### Two-Pointer Technique
```csharp
int left = 0, right = array.Length - 1;
while (left < right)
{
    // Process
    left++;
    right--;
}
```

### Sliding Window
```csharp
int left = 0;
for (int right = 0; right < array.Length; right++)
{
    // Add right element to window
    // Shrink window if needed
    while (windowInvalid)
    {
        // Remove left element
        left++;
    }
}
```

### Stack-Based Processing
```csharp
var stack = new Stack<T>();
foreach (var item in collection)
{
    // Process with stack operations
}
```

## Resources

- [LeetCode](https://leetcode.com/)
- [.NET API Browser](https://learn.microsoft.com/en-us/dotnet/api/)
- [MSTest Documentation](https://learn.microsoft.com/en-us/dotnet/core/testing/unit-testing-with-mstest)
