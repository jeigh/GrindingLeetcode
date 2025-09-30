namespace LeetCodeProblems.BinarySearch
{
    public class SearchInRotatedSortedArraySolution_33
    {
        public int Search(int[] nums, int target)
        {
            int left = 0;
            int right = nums.Length - 1;
            int mid = 0;
            var moveLeftToNext = () => left = mid + 1;
            var moveRightToPrev = () => right = mid - 1;


            while (left <= right)
            {
                mid = left + (right - left) / 2;

                if (nums[mid] == target) return mid;

                var midValueIsRightOfPivot = nums[mid] < nums[left];
                var midValueIsLeftOfPivot = nums[mid] >= nums[left];

                var targetLTMidValue = target < nums[mid];
                var targetGtMidValue = target > nums[mid];
                var targetGteMidValue = target >= nums[mid];

                var targetGteLeftValue = target >= nums[left];
                var targetLtLeftValue = target < nums[left];
                var targetEqLeftValue = target == nums[left];

                var targetGtRightValue = target > nums[right];
                var targetLteRightValue = target <= nums[right];


                

                // Condition 1: Left is sorted, target is greater than midValue - search right
                // we want a value between midvalue and pivot
                if (midValueIsLeftOfPivot && targetGtMidValue)
                    moveLeftToNext();

                // Condition 2: Left is sorted, target is less than leftValue
                // we want a value to the right of pivot
                if (midValueIsLeftOfPivot && targetLtLeftValue)
                    moveLeftToNext();

                // Condition 3: Left is sorted, target is between leftValue and midValue
                // we want a value between left and mid
                if (midValueIsLeftOfPivot && targetGteLeftValue && targetLTMidValue)
                    moveRightToPrev();

                

                // Condition 4: Right is sorted, target is less than midValue, target is less than leftValue
                // we want a value between pivot and midvalue
                if (midValueIsRightOfPivot && targetLTMidValue && targetLtLeftValue)
                    moveRightToPrev();

                // Condition 6: Right is sorted, target is greater than rightValue
                // we want a value between pivot and midvalue
                if (midValueIsRightOfPivot && targetGtRightValue)
                    moveRightToPrev();

                // Condition 7: Right is sorted, target is between midValue and rightValue
                // we want a value between midvalue and right
                if (midValueIsRightOfPivot && targetGteMidValue && targetLteRightValue)
                    moveLeftToNext();
            }

            return -1;
        }
    }
}
