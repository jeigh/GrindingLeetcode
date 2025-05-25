using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeProblems.OptimizedSolutions
{
    public class LongestConsecutiveOptimized
    {
        // I wrote this after researching the most efficient solution.
        // time and space complexity: O(n), which is slightly faster than my O(n log n) solution

        public int LongestConsecutive(int[] nums)
        {
            var hashset = new HashSet<int>(nums);
            int longest = 0;
            foreach (int n in nums)
            {
                int length = 0;
                if (!hashset.Contains(n-1))
                {
                    length = 0;
                    while (hashset.Contains(n + length))
                        length++;

                    longest = Math.Max(length, longest);
                }
            }
            return longest;
        }
    }
}
