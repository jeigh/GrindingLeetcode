namespace LeetCodeProblems.FirstAttempts
{
    public class MaxSlidingWindowSolution
    {
        public class Solution
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
        }
    }
}
