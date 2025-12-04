# Architecture and Design Principles

## Project Philosophy

This repository follows a **clean architecture** approach with clear separation of concerns:

1. **Interfaces** - Define contracts (problem specifications)
2. **Implementations** - Solve problems in C# or Visual Basic
3. **Tests** - Verify correctness across all implementations

## Why This Architecture?

### 1. **Interface-Driven Development**
Every LeetCode problem gets an interface that:
- Documents the problem requirements
- Provides a clear contract for implementations
- Enables multiple solution approaches
- Facilitates comprehensive testing

### 2. **Language Agnostic Testing**
Using `[DynamicData]` pattern allows:
- Testing C# and VB implementations with identical test cases
- Easy addition of new implementations
- Confidence that all solutions are correct

### 3. **Organized by Problem Category**
Solutions are grouped by algorithmic pattern:
- `Stack/` - Stack-based problems (LIFO operations)
- `LinkedList/` - Pointer manipulation
- `BinarySearch/` - Divide and conquer search
- `SlidingWindow/` - Window-based optimization
- `TwoPointers/` - Pointer traversal techniques
- `HashingOrArrays/` - Hash tables and array manipulation
- `Unconventional/` - Highly optimized or non-standard approaches

This organization helps understand **when to apply each technique**.

## Design Patterns Used

### Dummy Head Pattern (Linked Lists)
**When to use:** Building or merging linked lists

**Why:** Eliminates special cases for the first node

```csharp
var dummy = new ListNode(0);
var current = dummy;
// Build list...
return dummy.next;  // Skip dummy
```

### Stack Simulation with StringBuilder
**When to use:** String processing with backtracking

**Why:** Avoids actual stack + array reversal overhead

```csharp
var sb = new StringBuilder();
sb.Append(data);
// "Pop" by reducing length
sb.Length = previousLength;
```

### Two-Pointer Technique
**When to use:** Sorted arrays, palindromes, partitioning

**Why:** O(1) space vs O(n) auxiliary arrays

```csharp
int left = 0, right = n - 1;
while (left < right)
{
    // Compare/swap
    left++; right--;
}
```

### Sliding Window
**When to use:** Contiguous subarray/substring problems

**Why:** O(n) time vs O(n²) nested loops

```csharp
for (int right = 0; right < n; right++)
{
    // Expand window
    while (invalid)
    {
        // Shrink from left
        left++;
    }
}
```

## Complexity Analysis Guidelines

### Always Document Both Time and Space Complexity

```csharp
// Time complexity: O(n log n) - sorting dominates
// Space complexity: O(n) - auxiliary array for merge
public int[] SortArray(int[] nums)
```

### Common Complexity Classes
- O(1) - Constant (hash lookup, array access)
- O(log n) - Logarithmic (binary search, balanced tree)
- O(n) - Linear (single pass through data)
- O(n log n) - Linearithmic (efficient sorting)
- O(n²) - Quadratic (nested loops, avoid when possible)
- O(2?) - Exponential (recursion with branching, avoid!)

### Amortized vs Worst-Case
Document both when they differ:
```csharp
// Time complexity: O(1) amortized, O(n) worst case (dynamic array resize)
// Space complexity: O(n)
public void Add(T item)
```

## When to Create an "Unconventional" Solution

Place solutions in `Unconventional/` folder when:

1. **Significantly faster than standard approach** (e.g., O(n) vs O(n log n))
2. **Uses non-obvious data structures** (e.g., StringBuilder as stack)
3. **Trades readability for performance**
4. **Leverages language-specific features** (e.g., `Span<char>`)

Always include comments explaining:
- Why it's faster
- What the tradeoffs are
- When to use this vs standard approach

## Testing Philosophy

### Test All Edge Cases
- **Null/empty inputs**
- **Single element**
- **Two elements** (often reveals off-by-one errors)
- **All same values**
- **Sorted vs unsorted**
- **Minimum/maximum values**

### Test Common Patterns
- **Monotonic increasing**
- **Monotonic decreasing**
- **Alternating pattern**
- **V-pattern** (down then up)
- **Mountain pattern** (up then down)
- **Plateau pattern** (repeated values)

### Test Real-World Scenarios
Include tests with descriptive names like:
- `RealWorldExample_HomeDirectory`
- `ComplexPattern_ReturnsCorrectResult`
- `LongSequence_HandlesCorrectly`

## Performance Considerations

### Micro-Optimizations to Avoid
Unless profiling shows a bottleneck:
- ? Bit manipulation tricks (loses readability)
- ? Unrolling loops
- ? Premature inlining

### Macro-Optimizations to Pursue
- ? Use correct data structure (O(1) hash vs O(n) array)
- ? Avoid nested loops when possible (O(n²) ? O(n))
- ? Use StringBuilder in loops (O(n²) ? O(n))
- ? Reuse nodes instead of allocating (O(n) space ? O(1))

### Benchmark Real Performance
When claiming a solution is "faster," measure it:
```csharp
// Before: O(n²) Insert(0) - 5000 operations
// After: O(n) Append - 150 operations
// 33x improvement
```

## Multi-Language Strategy

### Why Both C# and Visual Basic?

1. **Compare approaches** - VB sometimes leads to clearer solutions
2. **Verify correctness** - Independent implementations reduce bugs
3. **Learn idioms** - Each language has strengths

### When to Implement in Both Languages

- ? Core data structure problems (linked lists, trees)
- ? Classic algorithms (sorting, searching)
- ? Problems with multiple approaches
- ?? Skip for trivial problems or niche use cases

## Code Quality Standards

### Readability > Cleverness
```csharp
// ? Clever but unclear
return (a ^ b) & -(a < b);

// ? Clear intent
return a < b ? a : b;
```

### Self-Documenting Code
```csharp
// ? Needs comment to explain
if (x & 1) // Check if odd

// ? Clear without comment
if (IsOdd(x))
```

### Extract Complex Logic to Methods
```csharp
// ? Inline complexity
if ((betweenSlashes.Length != 2 || betweenSlashes[0] != '.' || 
     betweenSlashes[1] != '/') && betweenSlashes[0] != '/')

// ? Named method
if (!IsCurrentDirectory(betweenSlashes) && !IsEmptySegment(betweenSlashes))
```

## Common Anti-Patterns to Avoid

### 1. Creating New Nodes When Rewiring Suffices
```csharp
// ? O(n) space - creates new list
var newNode = new ListNode(current.val);

// ? O(1) space - rewires pointers
current.next = prev;
```

### 2. String Concatenation in Loops
```csharp
// ? O(n²) - string is immutable
for (int i = 0; i < n; i++)
    result += chars[i];

// ? O(n) - StringBuilder
var sb = new StringBuilder();
for (int i = 0; i < n; i++)
    sb.Append(chars[i]);
```

### 3. Checking Count Inside Loop When Unnecessary
```csharp
// ? Redundant check every iteration
while (true)
{
    if (stack.Count == 0) break;
    // process
}

// ? Check in condition
while (stack.Count > 0)
{
    // process
}
```

### 4. Not Handling Null Early
```csharp
// ? Null check deep in logic
public ListNode Process(ListNode head)
{
    var current = head;
    // 20 lines later...
    if (current == null) return null;  // Too late!
}

// ? Handle null early
public ListNode Process(ListNode head)
{
    if (head == null) return null;
    // Rest of logic
}
```

## Future Enhancements

As the repository grows, consider:

1. **Benchmarking framework** - Compare performance of implementations
2. **Visualization tools** - Animate algorithm execution
3. **Difficulty progression** - Track learning path through problems
4. **Pattern recognition** - Auto-suggest similar problems
5. **Performance tests** - Verify O(n) claims with actual measurements

## Learning Resources

### Recommended Order for Learning Patterns
1. **Arrays & Hashing** - Foundation
2. **Two Pointers** - Simple optimization
3. **Sliding Window** - Advanced two-pointer
4. **Stack** - LIFO data structure
5. **Binary Search** - Divide and conquer
6. **Linked Lists** - Pointer manipulation
7. **Trees** - Recursive structures
8. **Graphs** - Complex relationships
9. **Dynamic Programming** - Optimization problems

### Books Referenced
- "Cracking the Coding Interview" - Gayle Laakmann McDowell
- "Introduction to Algorithms" - CLRS
- "The Algorithm Design Manual" - Steven Skiena

### Online Resources
- [NeetCode.io](https://neetcode.io/) - Problem patterns
- [LeetCode Discuss](https://leetcode.com/discuss/) - Community solutions
- [Big-O Cheat Sheet](https://www.bigocheatsheet.com/) - Complexity reference
