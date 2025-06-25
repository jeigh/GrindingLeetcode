Largest Rectangle in Histogram
========================
Given an array of integers representing the heights of bars in a histogram, the task is to find the area of the largest rectangle that can be formed using these bars. The rectangle can extend to the left and right as far as possible, but its height is limited by the shortest bar in that range.


## How the Algorithm Works
### Stack Stores (Index, Height) Pairs
-	The stack keeps track of bars in increasing height order.
-	Each stack entry is a tuple: (index, height), where index is the leftmost position this height could extend to.
### Iterating Through Bars

```csharp
for (int i = 0; i < heights.Length; i++)
{
    start = i;
    while (myStack.TryPeek(out (int index, int height) peeked) && heights[i] < peeked.height)
    {
        var popped = myStack.Pop();
        start = popped.index;

        var currentArea = popped.height * (i - start);
        maxArea = Math.Max(maxArea, currentArea);

    }
    myStack.Push((start, heights[i]));
}
```
-	For each bar at index i:
-	Set start = i (the current bar's index).
-	While the stack is not empty and the current bar is shorter than the bar on top of the stack:
-	Pop the stack. The popped bar's height can't extend to i anymore.
-	Calculate the area: popped.height * (i - popped.index).
-	Update maxArea if this area is larger.
-	Update start to popped.index (the leftmost index this shorter bar could have started).
-	Push (start, heights[i]) onto the stack. This means the current bar could extend left to start.
### Final Stack Cleanup
```csharp
foreach((int index, int height) item in myStack)
{
    maxArea = Math.Max(maxArea, item.height * (heights.Length - item.index));
}
```
-	After the loop, some bars may still be in the stack. For each:
-	The rectangle can extend from its index to the end of the histogram (heights.Length).
-	Calculate area: height * (heights.Length - index).
-	Update maxArea if needed.
---

## Why Does This Work?
-	**Every rectangle is considered:**
Each time a bar is popped, the algorithm computes the largest rectangle that can be formed with that bar as the shortest bar, extending as far left and right as possible.
-	**No area is missed:**
By pushing the current bar with the correct start index, the algorithm ensures that rectangles can extend left as far as possible.
- **Efficient:**
Each bar is pushed and popped at most once, so the algorithm runs in O(n) time.

## This is a classic monotonic increasing stack problem.
-	The algorithm maintains a stack where the heights are in monotonic increasing order (from bottom to top).
-	As you iterate through the bars, you push the current bar onto the stack if it is taller than or equal to the bar on top (maintaining the increasing order).
-	When you encounter a bar that is shorter than the bar on top of the stack, you pop from the stack and calculate the area for the popped bar, because its "right boundary" has been found.
-	This use of a monotonic (increasing) stack is what enables the O(n) solution.
