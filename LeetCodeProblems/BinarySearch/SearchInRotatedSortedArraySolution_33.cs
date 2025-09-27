namespace LeetCodeProblems.BinarySearch
{
    public class SearchInRotatedSortedArraySolution_33
    {
        public int Search(int[] nums, int target)
        {
            var result = -1;

            int left = 0;
            int right = nums.Length - 1;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                int midval = nums[mid];

                if (midval == target) return mid;                

                var SetLeftToNext =  () => left = mid + 1;
                var SetRightToPrev = () => right = mid - 1;

                int leftval = nums[left];
                if (leftval <= midval)
                {
                    if (target > midval || target < leftval) 
                        SetLeftToNext();

                    else 
                        SetRightToPrev();
                }
                else
                {
                    var rightVal = nums[right];
                    if (target < midval || target > rightVal) 
                        SetRightToPrev();

                    else 
                        SetLeftToNext();
                }
            }

            return result;
        }
    }
}
