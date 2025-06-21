using System.ComponentModel;
using System.Formats.Tar;
using System.Security.AccessControl;
using System.Security.Cryptography.X509Certificates;

namespace LeetCodeProblems.FirstAttempts
{
    public class MaxSlidingWindowSolution
    {

        // space complexity: O(n*k) where n is the number of nums.
        // time complexity:  O(n)

        public int[] MaxSlidingWindow(int[] nums, int k)
        {
            var maxValues = new List<int>();
            var theQueue = new Queue<int>();
            foreach (var x in nums.Take(k))
            {
                theQueue.Enqueue(x);
            }

            maxValues.Add(theQueue.Max());

            for (int r = k; r < nums.Length; r++)
            {
                theQueue.Dequeue();
                theQueue.Enqueue(nums[r]);
                maxValues.Add(theQueue.Max());
            }

            return maxValues.ToArray();
        }

        public int[] MaxSlidingWindowWithLinkedList(int[] nums, int k)
        {

            List<int> output = new();
            var indexes = new LinkedList<int>();
            
            int leftEdgeOfWindow = 0;
            int rightEdgeOfWindow = 0;

            while (rightEdgeOfWindow < nums.Length)
            {
                var lastIsSmallerThanRightEdge = indexes.Count > 0 && nums[indexes.Last.Value] < nums[rightEdgeOfWindow];
                while (lastIsSmallerThanRightEdge)
                {
                    Console.WriteLine($"Removing Last (value:{nums[indexes.Last.Value]}, index:{indexes.Last.Value}) because Last Index (value:{nums[indexes.Last.Value]}, index {indexes.Last.Value}), is Smaller than Right Edge (value: {nums[rightEdgeOfWindow]}, index {rightEdgeOfWindow})..");
                    indexes.RemoveLast();                    
                    lastIsSmallerThanRightEdge = indexes.Count > 0 && nums[indexes.Last.Value] < nums[rightEdgeOfWindow];
                }

                Console.WriteLine($"Adding {nums[rightEdgeOfWindow]}, whose index is {rightEdgeOfWindow}.");
                indexes.AddLast(rightEdgeOfWindow);

                var isOutOfWindow = leftEdgeOfWindow > indexes.First.Value;
                if (isOutOfWindow)
                {
                    Console.WriteLine($"We are out of the window.  Removing leftmost, whose value is {nums[indexes.First.Value]} and index is {indexes.First.Value}");
                    indexes.RemoveFirst(); 
                }

                var windowIsFull = (rightEdgeOfWindow + 1) >= k;
                if (windowIsFull)
                {
                    
                    output.Add(nums[indexes.First.Value]);
                    Console.WriteLine($"Window is full.  Maximum value in window is {nums[indexes.First.Value]}, with index at {indexes.First.Value}.");
                    leftEdgeOfWindow++;
                    Console.WriteLine($"Window is full.  Left Pointer moving to {nums[leftEdgeOfWindow]}, which has index {leftEdgeOfWindow}");
                }

                rightEdgeOfWindow++;
                Console.WriteLine($"Encountering value {nums[rightEdgeOfWindow]}, at index {rightEdgeOfWindow}.");
            }

            return output.ToArray();
        }
    }
}
