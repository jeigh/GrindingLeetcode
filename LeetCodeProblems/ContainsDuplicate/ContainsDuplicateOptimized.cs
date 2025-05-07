namespace LeetCodeProblems.ContainsDuplicate
{
    internal class ContainsDuplicateOptimized : IContainsDuplicate
    {
        // this one I looked up;   Faster because it sorts the array first.
        // Time: O(n log n) Space: O(1)

        public bool hasDuplicate(int[] nums)
        {
            Array.Sort(nums);
            for (int i = 0; i < nums.Length - 1; i++)
            {
                if (nums[i] == nums[i + 1]) return true;
            }
            return false;
        }
    }
}
