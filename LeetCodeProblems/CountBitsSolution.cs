namespace LeetCodeProblems
{
    public class CountBitsSolution
    {
        public int[] CountBitsOptimized(int n)
        {
            List<int> bitCounts = [0];
            int powerOfTwo = 1;  // 2^0

            for (int i = 1; i <= n; i++)
            {
                if (powerOfTwo * 2 == i) powerOfTwo = i;
                var addable = 1 + bitCounts[i - powerOfTwo];
                bitCounts.Add(addable);
            }
            return bitCounts.ToArray();
        }


        // not optimized, but solves the problem.
        // time: O(n log n) space: O(n)
        public int[] CountBitsFirstAttempt(int n)
        {
            var result = new List<int>();
            for(int i = 0; i < n+1; i++)
            {
                var bitCounter = 0;
                var intBeingConsidered = i;
                while(intBeingConsidered > 0)
                {
                    if (intBeingConsidered % 2 == 1) bitCounter++;

                    intBeingConsidered >>= 1;
                }
                result.Add(bitCounter);
            }

            return result.ToArray();
        }
    }
}
