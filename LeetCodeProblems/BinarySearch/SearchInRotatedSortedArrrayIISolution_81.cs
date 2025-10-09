
using System.Security.Cryptography;

namespace LeetCodeProblems.BinarySearch
{
    public class SearchInRotatedSortedArrrayIISolution_81
    {
        public bool Search(int[] nums, int target)
        {
            if (nums == null || nums.Length == 0) return false;

            int left = 0;
            int right = nums.Length - 1;
            var mid = 0;

            var moveLeft = () => right = mid - 1;
            var moveRight = () => left = mid + 1;

            while (left <= right)
            {
                mid = left + (right - left) / 2;

                if (nums[mid] == target || nums[left] == target || nums[right] == target)
                    return true;

                if (nums[left] == nums[mid])
                {
                    left++;
                    continue;
                }


                bool isLeftSorted = nums[left] < nums[mid];

                if (isLeftSorted)
                {
                    if (target > nums[left] && target < nums[mid])
                        moveLeft();
                    else
                        moveRight();
                }
                else
                {
                    if (target > nums[mid] && target < nums[right])
                        moveRight();
                    else
                        moveLeft();
                }
            }

            return false;
        }
    }
}
