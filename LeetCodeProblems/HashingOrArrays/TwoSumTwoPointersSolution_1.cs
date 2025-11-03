using LeetCodeProblems.Shared;

namespace LeetCodeProblems.HashingOrArrays
{
    public class TwoSumTwoPointersSolution_1 : ITwoSum 
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
    }
}
