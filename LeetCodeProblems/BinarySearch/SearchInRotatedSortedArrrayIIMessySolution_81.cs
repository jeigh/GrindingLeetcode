
namespace LeetCodeProblems.BinarySearch
{
    // I created this on my own using trial an error.
    // it is optimized, but the logic is slightly different than what is in leetcode because of my trial-and-error methodology
    public class SearchInRotatedSortedArrrayIIMessySolution_81
    {
        public bool Search(int[] nums, int target)
        {
            if (nums.Length == 0 ) return false;
            var left = 0;
            var right = nums.Length - 1;
            int mid = 0;            
            var firstOffset = 0;
            var lastOffset = nums.Length - 1;
            if (nums[0] == target) return true;

            while (right >= left && lastOffset > firstOffset)
            {
                mid = left + (right - left) / 2;

                if (nums[mid] == target) return true;
                if (nums[left] == target) return true;
                if (nums[right] == target) return true;

                if (nums[firstOffset] == nums[mid] || nums[firstOffset] == nums[lastOffset])
                {
                    if (lastOffset < nums.Length - 1) { 
                        lastOffset++;
                        if (lastOffset < right) right--;
                    }

                    firstOffset++;
                    if (firstOffset > left) left++;
                    continue;
                }

                var moveRight = () => left = mid + 1;
                var moveLeft = () => right = mid - 1;

                var midIsBeforePivot = nums[mid] >= nums[firstOffset];
               
                if (midIsBeforePivot)
                {
                    if (target < nums[firstOffset]) moveRight();
                    else if (target > nums[mid]) moveRight();
                    else moveLeft();
                }

                else
                {
                    if (target < nums[lastOffset] && target < nums[mid]) moveLeft();
                    else if (target > nums[lastOffset]) moveLeft();
                    else moveRight();
                }
            }
            return false;

        }
    }
}
