namespace LeetCodeProblems.ProductExceptSelf
{
    public class ProductExceptSelfBruteForceSolution
    {
        // this was my hand-crafted solution.
        // time complexity: O(n^2) where n is the length of the input array.
        // space complexity: O(n) where n is the length of the input array.

        public int[] ProductExceptSelf(int[] nums)
        {
            var result = Enumerable.Repeat(1, nums.Length).ToArray();
            for (int i = 0; i < nums.Length; i++)
            {
                for(int j = 0; j < nums.Length; j++)
                {
                    if (i == j) continue;
                    result[i] = result[i] * nums[j];
                }
            }
            return result;
        }
    }

}
