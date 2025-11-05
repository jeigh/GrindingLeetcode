namespace LeetCodeProblems.TwoPointers
{
    /// <summary>
    /// Given an integer array nums, rotate the array to the right by k steps, where k is non-negative.
    /// the intent here is to do it in-place with O(1) space
    /// </summary>
    public class RotateArrayReverseSolution_189
    {
        public void Rotate(int[] nums, int k) 
        {
            if (nums.Length == 0) return;
            var n = nums.Length;
            k %= nums.Length;
            if (k == 0) return;

            Reverse(nums, 0, n - 1);
            Reverse(nums, 0, k - 1);
            Reverse(nums, k, n - 1);
        }

        public void Reverse(int[] nums, int start, int end)
        {
            var left = start;
            var right = end;
            
            while (left < right)
            {
                Swap(nums, left, right);
                left++;
                right--;
            }
        }

        private void Swap(int[] nums, int i, int j)
        {
            var temp = nums[i];
            nums[i] = nums[j];
            nums[j] = temp;
        }
    }
}
