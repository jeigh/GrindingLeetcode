namespace LeetCodeProblems.BinarySearch
{
    public class SearchInsertPosition_35
    {
        public int SearchInsert(int[] nums, int target)
        {
            if (nums == null || nums.Length == 0) return 0;

            var left = 0;
            var right = nums.Length - 1;
            int mid = 0;
            var setLeftToNext = () => left = mid + 1;
            var setRightToPrev = () => right = mid - 1;

            while (left <= right)
            {
                mid = left + (right - left) / 2;

                if (target == nums[mid]) return mid;

                if (target < nums[mid]) setRightToPrev();
                if (target > nums[mid]) setLeftToNext();
            }
            
            return left;
        }
    }
}
