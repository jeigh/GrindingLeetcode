﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeProblems
{
    public class LargestConsecutiveUnoptimized
    {
        // after misinterpreting the problem and writing a solution that did not target the test cases, I fell back on this hand-crafted solution
        // time complexity: O(n log n) due to sorting
        // space complexity: O(n) due to the use of a list to store the sorted values
        public int LongestConsecutive(int[] nums)
        {
            var sorted = nums.Distinct().OrderBy(x => x).ToList();
            if (sorted.Count == 0) return 0;
            int maxCount = 1;
            int currentCount = 1;

            int previousValue = 0;
            for (int i = 0; i < sorted.Count; i++)
            {
                if (i == 0)
                {
                    previousValue = sorted[i];
                    currentCount = 1;
                    maxCount = 1;
                }
                else
                {
                    if (sorted[i] == previousValue + 1)
                    {
                        previousValue = sorted[i];
                        currentCount++;
                        maxCount = Math.Max(maxCount, currentCount);
                    }
                    else if (sorted[i] != previousValue)
                    {
                        previousValue = sorted[i];
                        currentCount = 1;
                    }
                }
                
            }
            return maxCount;
        }

        // I wrote this after researching the most efficient solution.
        // time and space complexity: O(n), which is slightly faster than my O(n log n) solution

        public int LongestConsecutiveOptimized(int[] nums)
        {
            var hashset = new HashSet<int>(nums);
            int longest = 0;
            foreach (int n in nums)
            {
                int length = 0;
                if (!hashset.Contains(n - 1))
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
