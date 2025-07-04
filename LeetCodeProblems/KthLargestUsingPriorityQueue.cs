namespace LeetCodeProblems
{

    public class KthLargestUsingPriorityQueue
    {
        // surprisingly, this solution actually runs slower than the List version on leetcode dispite having better time complexity.
        // time complexity: O(n log k) space: O(log k) 
        // where n is the number of elements.
        private PriorityQueue<int, int> items = new PriorityQueue<int, int>();
        private readonly int _k;

        public KthLargestUsingPriorityQueue(int k, int[] nums)
        {
            this._k = k;
            foreach (var item in nums)
            {
                Add(item);
            }
        }

        public int Add(int val)
        {
            items.Enqueue(val, val);
            if (items.Count > _k) items.Dequeue();
            return items.Peek();
        }
    }
}
