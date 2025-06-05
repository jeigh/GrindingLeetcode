using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeProblems.FirstAttempts
{
    public class TrappingRainWater
    {
        // this was my first attempt after reading an explaination of how it should be done
        // time complexity: O(n), space complexity: O(n)
        // according to leetcode, this isn't the fastest algorithm tho...

        public int Trap(int[] height)
        {
            var prefixMaximums = BuildPrefixMaximums(height);
            var suffixMaximums = BuildSuffixMaximums(height);
            var sumArea = 0;
            for (int i = 1; i <= height.Length - 2; i++)
            {
                var waterLevel = Math.Min(prefixMaximums[i], suffixMaximums[i]);
                sumArea += (waterLevel - height[i]);
            }

            return sumArea;
        }
        private List<int> BuildPrefixMaximums(int[] height)
        {
            var prefixMaximums = new List<int>();
            var previousMaximum = 0;
            for (int i = 0; i < height.Length; i++)
            {
                if (height[i] > previousMaximum)
                {
                    prefixMaximums.Add(height[i]);
                    previousMaximum = height[i];
                }
                else prefixMaximums.Add(previousMaximum);
            }
            return prefixMaximums;
        }

        private List<int> BuildSuffixMaximums(int[] height)
        {
            var previousMaximum = 0;
            List<int> suffixMaximums = new List<int>();
            previousMaximum = 0;
            for (int i = height.Length - 1; i >= 0; i--)
            {
                if (height[i] > previousMaximum)
                {
                    suffixMaximums.Add(height[i]);
                    previousMaximum = height[i];
                }
                else suffixMaximums.Add(previousMaximum);
            }
            suffixMaximums.Reverse();
            return suffixMaximums;
        }
    }
}
