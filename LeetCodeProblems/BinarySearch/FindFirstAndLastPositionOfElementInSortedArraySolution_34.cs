using System.Security.AccessControl;
using System.Security.Cryptography;

namespace LeetCodeProblems.BinarySearch
{
    public class FindFirstAndLastPositionOfElementInSortedArraySolution_34
    {
        public int[] SearchRange(int[] nums, int target)
        {
            var minval = DoBinarySearch(nums, target, false);
            var maxval = DoBinarySearch(nums, target, true);

            return [maxval, minval];
        }


        public int DoBinarySearch(int[] nums, int target, bool leftBias)
        {
            var left = 0;
            var right = nums.Length - 1;
            var mid = 0;
            var result = -1;

            Action executeBias = () => left = mid + 1;
            if (leftBias)
                executeBias = () => right = mid - 1;

            while (left <= right)
            {
                mid = left + (right - left) / 2;

                if (target == nums[mid])
                {
                    result = mid;
                    executeBias();
                }                    

                if (target < nums[mid])
                    right = mid - 1;

                if (target > nums[mid])
                    left = mid + 1;
            }
            return result;
        }
    }
}
