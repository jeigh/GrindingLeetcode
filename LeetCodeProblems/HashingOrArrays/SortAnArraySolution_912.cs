
namespace LeetCodeProblems.HashingOrArrays
{

    public class MergeSortSolution_912
    {
        public int[] SortArray(int[] nums)
        {
            return mergeSort(nums, 0, nums.Length-1);
        }

        public int[] mergeSort(int[] nums, int left, int right)
        {
            if (left == right) return nums;

            var mid = left + (right - left) / 2;

            mergeSort(nums, left, mid);
            mergeSort(nums, mid + 1, right);
            merge(nums, left, mid, right);
            return nums;
        }

        public void merge(int[] nums, int left, int mid, int right)
        {
            var leftNums = nums[left..(mid + 1)];
            var rightNums = nums[(mid + 1)..(right + 1)];

            var leftOffset = 0;
            var rightOffset = 0;
            var mergedOffset = left;

            RunZipperMerge(nums, leftNums, rightNums, ref leftOffset, ref rightOffset, ref mergedOffset);
            CopyRemaining(nums, leftNums, ref leftOffset, ref mergedOffset);
            CopyRemaining(nums, rightNums, ref rightOffset, ref mergedOffset);
        }

        public void RunZipperMerge(int[] nums, int[] leftNums, int[] rightNums, ref int leftOffset, ref int rightOffset, ref int mergedOffset)
        {
            while (leftOffset < leftNums.Length && rightOffset < rightNums.Length)
            {
                if (leftNums[leftOffset] <= rightNums[rightOffset])
                {
                    nums[mergedOffset] = leftNums[leftOffset];
                    leftOffset++;
                }
                else
                {
                    nums[mergedOffset] = rightNums[rightOffset];
                    rightOffset++;
                }
                mergedOffset++;
            }
        }

        public void CopyRemaining(int[] merged, int[] mergingArray, ref int mergingOffset, ref int mergedOffset)
        {
            while (mergingOffset < mergingArray.Length)
            {
                merged[mergedOffset] = mergingArray[mergingOffset];
                mergedOffset++;
                mergingOffset++;
            }
        }
    }
}
