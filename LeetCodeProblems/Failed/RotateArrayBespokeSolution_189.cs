namespace LeetCodeProblems.Failed
{
    public class RotateArrayBespokeSolution_189
    {
        // Given an integer array nums, rotate the array to the right by k steps, where k is non-negative.
        // the intent here is to do it in-place with O(1) space
        // in this case, however, it's O(n) space, so it does not meet specs.
        public void Rotate(int[] nums, int k)
        {
            if (nums == null || nums.Length == 0 || k == 0) return;

            int n = nums.Length;
            k %= n;
            if (k == 0) return;

            // Enqueue the first n-k elements (we need them later).
            int keep = n - k;
            var queue = new Queue<int>(keep);
            for (int i = 0; i < keep; i++)
            {
                queue.Enqueue(nums[i]);
            }

            // Copy the last k original elements into the front of the array.
            // These indices still hold original values because we haven't overwritten them.
            for (int i = 0; i < k; i++)
            {
                nums[i] = nums[keep + i];
            }

            // Dequeue the saved first n-k elements into the remainder of the array.
            for (int i = k; i < n; i++)
            {
                nums[i] = queue.Dequeue();
            }
        }
    }
}
