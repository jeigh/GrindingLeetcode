# Binary Search Sub-Categories

## Summary 
| Variant | Loop Condition | Right Assignment | Use Case |
|---------|---------------|------------------|----------|
| Exact Match | left <= right | right = mid - 1 | Find exact element |
| Lower Bound | left < right | right = mid | First >= target |
| Upper Bound | left < right | right = mid | First > target |
| Find Last | left < right | right = mid - 1 | Last == target |
| Answer Space | left < right | right = mid or left = mid + 1 | Min/max optimization |
| Rotated Array | left <= right | Depends on sorted half | Rotated search |
| Peak Finding | left < right | right = mid | Local maximum |


### Classic/Exact Match Binary Search

```csharp
// Find exact target, return index or -1
while (left <= right) 
{
    mid = left + (right - left) / 2;

    if (arr[mid] == target) 
        return mid;
    else if (arr[mid] < target) 
        left = mid + 1;
    else 
        right = mid - 1;
}
return -1;
```
* Use case: Array.BinarySearch(), finding exact value
* Result: Index of element or -1

### Lower Bound (Find First)
```csharp
// Find first position where arr[i] >= target
while (left < right) 
{
    mid = left + (right - left) / 2;
    if (arr[mid] < target) 
        left = mid + 1;
    else 
        right = mid;  // Keep mid as candidate
}
return left;
```

* Use case: Find first occurrence, insertion point
* Result: First index where arr[i] >= target
* Leetcode Examples:
    * 35
    * 658
    * 704


### Upper Bound (Find Last + 1)
```csharp
// Find first position where arr[i] > target
while (left < right) 
{
    mid = left + (right - left) / 2;
    if (arr[mid] <= target) 
        left = mid + 1;
    else 
        right = mid;
}
return left;
```

* Use case: Find insertion point after all duplicates
* Result: First index where arr[i] > target
* Leetcode Examples:
    * 34
    * 1283

### Find last Occurrence

```csharp
// Find last position where arr[i] == target
while (left < right) 
{
    mid = left + (right - left + 1) / 2;  // Round UP!
    if (arr[mid] <= target) 
        left = mid;  // Keep mid as candidate
    else 
        right = mid - 1;
}
return arr[left] == target ? left : -1;
```

* Use case: Last occurrence in duplicates
* Result: Last index where arr[i] == target
* Note: Uses mid = left + (right - left + 1) / 2 to avoid infinite loop!
* Leetcode Examples
    * 34

### Binary Search on Answer Space

```csharp
// Find minimum/maximum value that satisfies a condition
while (left < right) 
{
    mid = left + (right - left) / 2;
    if (isValid(mid)) 
        right = mid;  // Try smaller
    else 
        left = mid + 1;
}
return left;
```

* Use case: Minimize/maximize something (capacity, time, etc.)
* Leetcode Examples:
  * Koko eating bananas (875)
  * Split array largest sum (410)
  * Minimum days to make bouquets (1482)
  * 1011

### Rotated Array Binary Search

```csharp
// Search in rotated sorted array
while (left <= right) 
{
    mid = left + (right - left) / 2;
    if (arr[mid] == target) return mid;
    
    // Determine which half is sorted
    if (arr[left] <= arr[mid]) // Left half sorted
    {  
        if (target >= arr[left] && target < arr[mid])
            right = mid - 1;
        else
            left = mid + 1;
    } else {  // Right half sorted
        if (target > arr[mid] && target <= arr[right])
            left = mid + 1;
        else
            right = mid - 1;
    }
}
```
* Use case: Rotated sorted arrays
* Leetcode Examples: 
    * 33
    * 81
    * 153
    * 154

### Peak Finding

```csharp
while (left < right) 
{
    mid = left + (right - left) / 2;
    if (arr[mid] < arr[mid + 1])
        left = mid + 1;  // Peak is on right
    else
        right = mid;  // Peak is on left or at mid
}
return left;
```

* Use case: Find local maximum
* Leetcode Examples: 
    * 162
    * 852

### Binary Search in 2D Matrix


```csharp
// Search in row-wise and column-wise sorted matrix
while (left <= right) 
{
    mid = left + (right - left) / 2;
    row = mid / cols;
    col = mid % cols;
    
    if (matrix[row][col] == target) 
        return true;

    else if (matrix[row][col] < target) 
        left = mid + 1;

    else 
        right = mid - 1;
}
```
* Use case: 2D matrix treated as 1D array
* Leetcode Examples: 
    * 74
    * 240


