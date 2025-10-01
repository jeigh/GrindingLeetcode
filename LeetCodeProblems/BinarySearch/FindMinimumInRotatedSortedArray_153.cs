namespace LeetCodeProblems.BinarySearch
{
    public class FindMinimumInRotatedSortedArray_153
    {
        public int FindMin(int[] nums)
        {
            var left = 0;
            var right = nums.Length - 1;
            var mid = 0;
            var minval = nums[0];
            

            while (left <= right)
            {
                mid = left + (right - left) / 2;

                minval = Math.Min(nums[mid], minval);

                var midIsLeftOfPivot = nums[0] <= nums[mid];
                var midIsRightOfPivot = !midIsLeftOfPivot;

                var midValIsLessThanRightVal = nums[mid] < nums[right];
                

                if (midIsLeftOfPivot) left = mid + 1;
                if (midIsRightOfPivot) right = mid - 1;
                
            }

            return minval;
        }
    }
}
