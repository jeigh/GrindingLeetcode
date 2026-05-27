using LeetCodeProblems.Interfaces.Easy;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace LeetCodeProblems.CSharp.Backtracking
{

    public class SubsetXORSum_CSharp_Recursive_1863 : ISubsetXORSum_1863
    {
        public int SubsetXORSum(int[] nums)
        {
            return recurse(nums, 0, new List<int>());
        }

        private int recurse(int[] nums, int i, List<int> subset)
        {
            if (i == nums.Length)
            {
                int xor = 0;
                foreach (var n in subset) xor ^= n;
                return xor;
            }

            // include
            subset.Add(nums[i]);
            var sumIncluding = recurse(nums, i + 1, subset);
            subset.RemoveAt(subset.Count - 1);  // backtrack

            // exclude
            var sumExcluding = recurse(nums, i + 1, subset);

            return sumIncluding + sumExcluding;
        }
    }
}
