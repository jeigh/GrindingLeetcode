using LeetCodeProblems.Interfaces.Easy;

namespace LeetCodeProblems.CSharp.Backtracking
{
    public class SubsetXORSum_CSharp_Neetcode_1863 : ISubsetXORSum_1863
    {
        public int SubsetXORSum(int[] nums)
        {
            return recurse(nums, 0, 0);
        }

        private int recurse(int[] nums, int i, int total)
        {
            if (i == nums.Length) return total;

            return recurse(nums, i + 1, total) + recurse(nums, i+1, total ^= nums[i]);
        }
        
    }
}
