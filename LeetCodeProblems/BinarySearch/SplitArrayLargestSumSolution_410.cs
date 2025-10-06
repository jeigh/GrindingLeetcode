namespace LeetCodeProblems.BinarySearch
{
    public class SplitArrayLargestSumSolution_410
    {
        public int SplitArray(int[] nums, int k)
        {
            if (k > nums.Count()) return -1;
            var left = nums.Max();
            var right = nums.Sum();
            var mid = 0;
            var returnable = 0;

            while (left <=  right)
            {
                mid = left + (right - left) / 2;

                if (CanSplit(nums, k, mid))
                {
                    returnable = mid;
                    right = mid - 1;
                }

                else 
                    left = mid + 1;

            }
            return returnable;
        }

        public bool CanSplit(int[] nums, int k, int maxSumPerSubArray)
        {
            if (k > nums.Count()) return false;

            var subarrayCount = 1;
            var currentSum = 0;
            foreach( var x in nums)
            {
                if (x > maxSumPerSubArray) return false;

                if (currentSum + x > maxSumPerSubArray) 
                {
                    currentSum = x;
                    subarrayCount++;

                    if (subarrayCount > k) return false;
                }
                else currentSum += x;
            }

            return true;
        }
    }
}
