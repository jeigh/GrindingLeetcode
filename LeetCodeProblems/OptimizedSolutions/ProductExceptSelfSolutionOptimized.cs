namespace LeetCodeProblems.OptimizedSolutions
{

    public class ProductExceptSelfSolutionOptimized
    {
        // i wrote this by hand after reading about the most efficient solution.   
        // Time complexity is O(n) where n is the length of the array.
        // Space complexity is O(1) because we are not using any extra space except for the output array.

        public int[] ProductExceptSelf(int[] nums)
        {
            int[] arr = Enumerable.Repeat(1, nums.Length).ToArray();

            for (int i = 0; i < nums.Length; i++)
            {
                if (i == 0) continue;
                arr[i] = arr[i - 1] * nums[i-1];
            }
            var postfixValue = 1;
            for (int i = nums.Length - 1; i >= 0; i--)
            {
                
                if (!(i == nums.Length - 1))
                    arr[i] = arr[i] * postfixValue;
                postfixValue *= nums[i];
            }
            return arr;
        }
    }

}
