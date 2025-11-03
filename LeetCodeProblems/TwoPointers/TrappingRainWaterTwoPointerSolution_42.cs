namespace LeetCodeProblems.TwoPointers
{
    public class TrappingRainWaterTwoPointerSolution_42
    {
        // this is the optimized solution.  It individually calculates the water level per index instead of constructing a dedicated array for both prefix and suffix.
        // time complexity: O(n), space complexity: O(1)

        public int Trap(int[] height)
        {
            if (height == null || height.Length == 0) return 0;

            int left = 0;
            int right = height.Length - 1;

            int leftMax = height[left];
            int rightMax = height[right];

            int returnable = 0;
            while (left < right)
            {
                if (leftMax < rightMax)
                {
                    left++;
                    leftMax = Math.Max(leftMax, height[left]);
                    returnable += leftMax - height[left];
                }
                else
                {
                    right--;
                    rightMax = Math.Max(rightMax, height[right]);
                    returnable += rightMax - height[right];
                }
            }
            return returnable;
        }
    }
}
