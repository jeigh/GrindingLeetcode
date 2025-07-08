namespace LeetCodeProblems
{
    public class HammingWeightSolution
    {
        // time: O(1), space: O(1)
        public int HammingWeight(uint n)
        {
            var result = 0;

            while (n > 0)
            {
                if (n % 2 == 1) result++;
                n >>= 1;                
            }

            return result;
        }
    }
}
