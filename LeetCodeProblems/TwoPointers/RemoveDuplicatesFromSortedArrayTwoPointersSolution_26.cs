namespace LeetCodeProblems.TwoPointers
{
    public class RemoveDuplicatesFromSortedArrayTwoPointersSolution_26
    {
        // I wrote this after realizing that my hashset solution exceeded ideal time and space constraints.
        // time: O(n),  space: O(1)
        public int RemoveDuplicates(int[] nums)
        {            
            var k = 0;
            var lastValue = -101;
            var currentIndex = 0;
            if (nums.Length == 0) return 0;
            while(currentIndex < nums.Length)
            {
                if (lastValue != nums[currentIndex])
                {
                    lastValue = nums[currentIndex];
                    nums[k] = lastValue;
                    k++;
                }
                currentIndex++;
            }
            return k;
        }
    }
}
