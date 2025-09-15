namespace LeetCodeProblems
{
    public class FindMinInRotatedSortedArraySolution
    {
        // time complexity O(log n)
        public int FindMin(int[] nums)
        {
            int leftIndex = 0;
            int rightIndex = nums.Length - 1;
            while(leftIndex < rightIndex)
            {
                int currentIndex = leftIndex + (rightIndex - leftIndex) / 2;
                if (nums[currentIndex] < nums[rightIndex]) rightIndex = currentIndex;
                else leftIndex = currentIndex + 1;
            }
            return nums[leftIndex];
        }
    }
}
