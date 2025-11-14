using LeetCodeProblems.Interfaces.Easy;

namespace LeetCodeProblems
{
    public class MaximumAverageSubarrayICSharp_643 : IMaximumAverageSubarray_643
    {
        public double FindMaxAverage(int[] nums, int k)
        {
            int currentSum = 0;

            for (int i = 0; i < k; i++)
                currentSum += nums[i];

            int maxSum = currentSum;

            for (int right = k; right < nums.Length; right++)
            {
                int left = right - k;
                currentSum += nums[right] - nums[left];  
                maxSum = Math.Max(currentSum, maxSum);
            }

            return maxSum / (double)k;
        }
    }
}