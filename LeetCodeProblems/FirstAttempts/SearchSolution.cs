namespace LeetCodeProblems.FirstAttempts
{
    public class SearchSolution
    {
        // time complexity: O(log n)
        // space complexity: O(1)
        public int Search(int[] nums, int target)
        {
            if (target < nums[0] || target > nums[nums.Length - 1]) return -1;

            int localStart = 0;
            int localEnd = nums.Length - 1;
            int nextMidpoint = (localStart + localEnd) / 2;

            while (true)
            {
                nextMidpoint = (localStart + localEnd) / 2;

                if (nums[nextMidpoint] == target) return nextMidpoint;
                if (target < nums[nextMidpoint]) localEnd = nextMidpoint - 1;
                if (target > nums[nextMidpoint]) localStart = nextMidpoint + 1;

                if (localEnd < localStart) break;

            }
            return -1;
        }
    }
}
