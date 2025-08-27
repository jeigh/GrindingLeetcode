namespace LeetCodeProblems
{
    public class KokoEatingBananas
    {

        public int MinEatingSpeedUsingBinarySearch(int[] piles, int h)
        {
            int leftPointer = 1;
            int rightPointer = piles.Max();
            int result = rightPointer;

            while (leftPointer <= rightPointer)
            {
                int resultUnderConsideration = (leftPointer + rightPointer) / 2;

                long totalTime = 0;
                foreach (int pile in piles)
                {
                    totalTime += CeilingDivision(pile, resultUnderConsideration); 
                }

                if (totalTime <= h)
                {
                    result = resultUnderConsideration;
                    rightPointer = resultUnderConsideration - 1;
                }
                else
                {
                    leftPointer = resultUnderConsideration + 1;
                }
            }

            return result;
        }


        // time complexity: O(m * n) where n is the number of piles, and m is the size of the largest pile (maxk variable).
        public int MinEatingSpeedBruteForce(int[] piles, int h)
        {
            var targetTime = h;
            int maxK = piles.Max();
            int k = int.MaxValue;
            
            for (int eatingSpeed = 1; eatingSpeed <= maxK; eatingSpeed++)
            {
                var temp = 0;
                foreach (var pile in piles)
                {
                    temp += CeilingDivision(pile, eatingSpeed);
                }

                if (temp <= targetTime) 
                    return eatingSpeed;
            }            

            return k;
        }


        private int CeilingDivision(int pile, int rate)
        {
            return (pile + rate - 1) / rate;
        }
    }
}
