using LeetCodeProblems.Shared;

namespace LeetCodeProblems.FirstAttempts
{
    public class TwoSumSolution 
    {
        public int[] TwoSum(int[] nums, int target)
        {
            int firstIndex = 0;
            foreach (int firstAddend in nums)
            {
                int secondIndex = 0;
                foreach (int secondAddend in nums)
                {
                    if (firstIndex == secondIndex) continue;
                    if (firstAddend + secondAddend == target) return [secondIndex, firstIndex];

                    secondIndex += 1;
                }

                firstIndex += 1;
            }
            return [-1, -1];
        }

        public int[] TwoSumHashMap(int[] nums, int target)
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
