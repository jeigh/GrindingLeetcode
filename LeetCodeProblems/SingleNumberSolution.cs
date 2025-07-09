using System;
using System.Collections.Immutable;

namespace LeetCodeProblems
{
    public class SingleNumberSolution
    {
        // this was my first attempt at this problem.   Not perfect efficiency
        // time O(n log n), space O(1)
        public int SingleNumberSort(int[] nums)
        {
            Array.Sort(nums);

            for (int i = 0; i < nums.Length; i += 2)
            {
                if (i == nums.Length - 1) return nums[i];
                if (nums[i] != nums[i + 1]) return nums[i];
            }
            return 0;
        }

        // this is the intended answer to the question.
        // time: O(n), space: O(1)

        public int SingleNumberUsingXOR(int[] nums)
        {
            var xored = 0;
            foreach(int i in nums)
            {
                xored ^= i;
            }
            return xored;
        }
    }
}
