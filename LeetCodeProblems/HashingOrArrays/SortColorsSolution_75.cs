
namespace LeetCodeProblems.HashingOrArrays
{
    public class SortColorsSolution_75
    {
        // this was my bespoke attempt at solving the problem from scratach (after having read the neetcode solution but not having looked at a code solution yet.
        // it's got a lot of extra redundancy in it, but still ranks 100% on performance
        public void SortColors(int[] nums)
        {
            int rightOfZeros = 0;
            int leftOfTwos = nums.Length - 1;
            int midOffset = rightOfZeros + 1;

            while (true)
            {
                if (leftOfTwos < midOffset) return;
                if (leftOfTwos <= 0) return;
                if (rightOfZeros >= nums.Length - 1) return;
                var continueOuter = false;

                while (nums[rightOfZeros] == 0) 
                { 
                    rightOfZeros++;
                    if (rightOfZeros > midOffset) midOffset = rightOfZeros + 1;
                    if (rightOfZeros == nums.Length - 1) return;
                    continueOuter = true;
                    continue;
                }
                if (continueOuter) continue;

                while (nums[leftOfTwos] == 2) 
                {
                    leftOfTwos--;
                    if (leftOfTwos <= rightOfZeros) return;
                    continueOuter = true;
                    continue;
                }
                if (continueOuter) continue;


                if (nums[midOffset] == 0)
                {
                    Swap(nums, rightOfZeros, midOffset);
                    rightOfZeros++;
                    midOffset++;
                    continue;
                }

                if (nums[leftOfTwos] == 0 && nums[rightOfZeros] != 0)
                {
                    Swap(nums, leftOfTwos, rightOfZeros);
                    continue;
                }

                if (nums[leftOfTwos] < nums[midOffset])
                {
                    Swap(nums, midOffset, leftOfTwos);
                    continue;
                }

                if (nums[rightOfZeros] == 2)
                {
                    Swap(nums, rightOfZeros, leftOfTwos);
                    leftOfTwos--;
                    continue;
                }

                midOffset++;

            }
            
            

        }

        public void Swap(int[] nums, int leftOffset, int rightOffset)
        {
            var tempValue = nums[leftOffset];
            nums[leftOffset] = nums[rightOffset];
            nums[rightOffset] = tempValue;
        }

        // this is the version of the method on neetcode
        public void SortColorsTerse(int[] nums)
        {
            int nextZeroIndex = 0, nextOneIndex = 0;

            for (int currentIndex = 0; currentIndex < nums.Length; currentIndex++)
            {
                int currentValue = nums[currentIndex];
                nums[currentIndex] = 2;

                if (currentValue < 2)
                {
                    nums[nextOneIndex] = 1;
                    nextOneIndex++;
                }
                if (currentValue < 1)
                {
                    nums[nextZeroIndex] = 0;
                    nextZeroIndex++;
                }
            }
        }

    }
}
