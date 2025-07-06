namespace LeetCodeProblems
{
    public class ClimbStairsDynamic
    {
        // time: O(n);  space: O(2)
        public int ClimbStairs(int n)
        {
            int currentWays = 1;
            int previousWays = 1;

            for (int i = 0; i < n; i++)
            {
                var futurePreviousWays = currentWays;
                previousWays = currentWays + previousWays;
                previousWays = futurePreviousWays;
            }

            return currentWays;            
        }
    }
}
