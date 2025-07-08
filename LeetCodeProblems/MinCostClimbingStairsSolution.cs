namespace LeetCodeProblems
{
    public class MinCostClimbingStairsSolution
    {
        // space complexity: O(n), Time Complexity O(1)
        public int MinCostClimbingStairs(int[] cost)
        {
            var twoPrev = cost[cost.Length - 1];
            var onePrev = cost[cost.Length - 2];

            for (int i = cost.Length - 3; i > -1; i--)
            {
                var curCost = Math.Min(cost[i] + twoPrev, cost[i] + onePrev);

                var temp = onePrev;
                onePrev = curCost;
                twoPrev = temp;
            }
            return Math.Min(onePrev, twoPrev);
        }
    }
}
