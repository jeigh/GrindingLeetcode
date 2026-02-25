using LeetCodeProblems.Interfaces.Easy;

namespace LeetCodeProblems.CSharp.Queue
{
    public class KthLargestInAStream_PriorityQueue_CSharp_703 : IKthLargestElementInAStream_703
    {
        // surprisingly, this solution actually runs slower than the List version on leetcode dispite having better time complexity.
        // time complexity: O(n log k) space: O(log k) 
        // where n is the number of elements.
        private PriorityQueue<int, int> items = new PriorityQueue<int, int>();
        private readonly int _k;

        public KthLargestInAStream_PriorityQueue_CSharp_703(int k, int[] nums)
        {
            _k = k;
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
