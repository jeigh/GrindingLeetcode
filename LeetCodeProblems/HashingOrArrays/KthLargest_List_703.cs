using LeetCodeProblems.Interfaces.Easy;

namespace LeetCodeProblems.CSharp.HashingOrArrays
{
    public class KthLargest_List_703 : IKthLargestElementInAStream_703
    {
        // this was my first stab at this solution, with a slightly less ideal performance.
        // space: O(n), time: O(n^2)

        private List<int> items = new List<int>();
        private readonly int _k;

        public KthLargest_List_703(int k, int[] nums)
        {
            _k = k;
            foreach(var item in nums)
            {
                Add(item);
            }
        }

        public int Add(int val)
        {
            int index = items.BinarySearch(val);
            if (index < 0)
                index = ~index; 

            items.Insert(index, val);

            if (_k > items.Count) return 0;
            return items[items.Count - _k];

        }
    }
}
