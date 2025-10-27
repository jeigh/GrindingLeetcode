namespace LeetCodeProblems.HashingOrArrays
{

    public class RemoveDuplicatesFromSortedArrayHashsetSolution_26
    {
        // this might not be optimized, but it's the solution I came up with organically that uses a hashset instead of twopointers.
        // time complexity: O(n)
        // space complexity: O(n)

        public int RemoveDuplicates(int[] nums)
        {
            var hashset = new HashSet<int>();
            int[] originalNums = new int[nums.Length];
            Array.Copy(nums, originalNums, nums.Length);
            var insertionPoint = 0;

            foreach (int x in nums)
            {
                if (!hashset.Contains(x))
                {
                    hashset.Add(x);
                    nums[insertionPoint] = x;
                    insertionPoint++;
                }
            }
            return hashset.Count;

        }
    }
}
