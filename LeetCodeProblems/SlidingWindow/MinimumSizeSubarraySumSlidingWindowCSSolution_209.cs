using LeetCodeProblems.Interfaces.Medium;

namespace LeetCodeProblems.CSharp.SlidingWindow
{
    public class MinimumSizeSubarraySumSlidingWindowCSSolution_209 : IMinimumSizeSubarraySum_209
    {
        public int MinSubArrayLen(int target, int[] nums)
        {
            if (nums.Length == 0) return 0;

            var currentSum = 0;
            var minLen = int.MaxValue;
            var left = 0;

            for (int right = 0; right < nums.Length; right++)
            {
                currentSum += nums[right];

                while (currentSum >= target)
                {
                    minLen = Math.Min(minLen, right - left + 1);
                    currentSum -= nums[left];
                    left++;
                }
            }
            if (minLen == int.MaxValue) return 0;
            return minLen;
        }
    }
}
