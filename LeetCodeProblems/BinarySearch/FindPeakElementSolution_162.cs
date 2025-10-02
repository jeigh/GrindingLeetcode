using System.Runtime.Versioning;

namespace LeetCodeProblems.BinarySearch
{
    public class FindPeakElementSolution_162
    {
        public int FindPeakElement(int[] nums)
        {
            var mid = 0;
            var left = 0;
            var right = nums.Length - 1;

            while (left <= right)
            {
                mid = left + (right - left) / 2;

                if (mid != 0 && nums[mid] <= nums[mid - 1]) right = mid - 1;
                else if (mid != nums.Length - 1 && nums[mid] <= nums[mid + 1]) left = mid + 1;
                else return mid;
            }
            return -1;
        }
    }
}
