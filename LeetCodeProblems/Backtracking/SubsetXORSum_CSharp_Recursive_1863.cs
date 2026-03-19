using LeetCodeProblems.Interfaces.Easy;
using System.ComponentModel.DataAnnotations;

namespace LeetCodeProblems.CSharp.Backtracking
{
    public class SubsetXORSum_CSharp_Recursive_1863 : ISubsetXORSum_1863
    {
        public int SubsetXORSum(int[] nums)
        {
            return recurse(nums, 0, 0);
        }

        public int recurse(int[] nums, int i, int total)
        {
            if (i == nums.Length) return total;

            var sumIncluding = recurse(nums, i + 1, total ^ nums[i]);
            var sumExcluding = recurse(nums, i + 1, total);
            return sumIncluding + sumExcluding;
        }
    }
}
