using LeetCodeProblems.Shared;

namespace LeetCodeProblems.OptimizedSolutions
{
    public class TwoSumOptimizedSolution 
    {
        public int[] TwoSum(int[] nums, int target)
        {
            Dictionary<int, int> addends = new();
            for (int i = 0; i < nums.Length; i++)
            {
                if (addends.ContainsKey(nums[i]))
                    return [addends[nums[i]], i];

                addends[target - nums[i]] = i;
            }
            return [-1, -1];
        }

    }
}
