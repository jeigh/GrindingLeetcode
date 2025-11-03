namespace LeetCodeProblems.Unconventional
{
    /// <summary>
    /// Given n non-negative integers representing an elevation map where the width of each bar is 1, compute how much water it can trap after raining.
    /// </summary>
    public class TrappingRainWaterUnconventionalSolution_42
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
                sumArea += waterLevel - height[i];
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
