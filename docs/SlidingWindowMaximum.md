# Monotonic Deque (LinkedList)

The linkedList stores indices of elements in nums. It is maintained so that the values at these indices are always in **decreasing order from front to back**. This ensures the front always holds the index of the current window's maximum.

## Window Edges:
-	leftEdgeOfWindow and rightEdgeOfWindow track the current window's bounds.
-	As rightEdgeOfWindow advances, the window slides right.
Maintaining the Deque:
## Pop from Back:
Before adding the new index (rightEdgeOfWindow), remove indices from the back of the deque while their corresponding values in nums are less than nums[rightEdgeOfWindow].  This is because any value less than the new value can never be the maximum for the current or any future window that includes the new value.

```csharp
                var lastIsSmallerThanRightEdge = indexes.Count > 0 && nums[indexes.Last!.Value] < nums[rightEdgeOfWindow];
                while (lastIsSmallerThanRightEdge)
                {
                    indexes.RemoveLast();                    
                    lastIsSmallerThanRightEdge = indexes.Count > 0 && nums[indexes.Last.Value] < nums[rightEdgeOfWindow];
                }

```

## Add New Index:
- Add rightEdgeOfWindow to the back.
- Pop from Front (Out of Window):
If the index at the front is outside the current window (linkedList.First!.Value < leftEdgeOfWindow), remove it.
-	Recording the Maximum:
Once the window is full (rightEdgeOfWindow + 1 >= k), the maximum for the current window is always at nums[linkedList.First.Value].

```csharp
                indexes.AddLast(rightEdgeOfWindow);
                var isOutOfWindow = indexes.First!.Value < leftEdgeOfWindow;
                if (isOutOfWindow)
                    indexes.RemoveFirst(); 
                var windowIsFull = (rightEdgeOfWindow + 1) >= k;
                if (windowIsFull)
                {
                    output.Add(nums[indexes.First.Value]);
                    leftEdgeOfWindow++;
                }
```

##	Advance Window:
Increment leftEdgeOfWindow and rightEdgeOfWindow to slide the window.

```csharp

                var windowIsFull = (rightEdgeOfWindow + 1) >= k;
                if (windowIsFull)
                {
                    output.Add(nums[indexes.First.Value]);
                    leftEdgeOfWindow++;
                }

                rightEdgeOfWindow++;
   

```