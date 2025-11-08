using LeetCodeProblems.Interfaces.Easy;

namespace LeetCodeProblems.BruteForce
{
    public class BestTimeToBuyAndSellStockBruteForceSolution_121 : IBestTimeToBuyAndSellStock_121
    {
        // time complexity: O(n^2) (because of the nested loop,
        // space complexity O(1)
        public int MaxProfit(int[] prices)
        {
            int i = 0;

            var difference = 0;
            var maxDifference = 0;

            while (i < prices.Length - 1)
            {
                int j = i + 1;
                while (j < prices.Length)
                {
                    if (i == j) continue;
                    difference = prices[j] - prices[i];
                    if (difference > maxDifference) maxDifference = difference;
                    j++;
                }

                i++;
            }

            return maxDifference;
        }
    }
}
