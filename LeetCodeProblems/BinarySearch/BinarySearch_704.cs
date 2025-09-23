using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeProblems.BinarySearch
{
    public class BinarySearch_704
    {
        public int Search(int[] nums, int target)
        {
            if (nums == null || nums.Length == 0)
                return -1;

            int left = 0;
            int right = nums.Length - 1;            

            while (left <= right)
            {
                var mid = left + (right-left) / 2;

                var moveLeftToNext = () => left = mid + 1;
                var moveRightToPrevious = () => right = mid - 1;

                if (nums[mid] == target) return mid;

                if (target < nums[mid]) moveRightToPrevious();
                else moveLeftToNext();
            }
            return -1;
        }
    }
}
