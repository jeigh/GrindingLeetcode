using LeetCodeProblems.Interfaces.Easy;

namespace LeetCodeProblems.HashingOrArrays
{
    public class TwoSumHashMapSolution_1 : ITwoSum_1
    {
        public int[] TwoSum(int[] nums, int target)
        {
            Dictionary<int, int> neededValueToIndex = new();
            for (int i = 0; i < nums.Length; i++)
            {
                if (neededValueToIndex.ContainsKey(nums[i]))
                    return [neededValueToIndex[nums[i]], i];

                neededValueToIndex[target - nums[i]] = i;
            }
            return [-1, -1];
        }
    }
}
