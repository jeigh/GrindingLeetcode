using LeetCodeProblems.Interfaces;

namespace LeetCodeProblems.Dynamic
{
    public class BestTimeToBuyAndSellStockDynamicSolution_121 : IBestTimeToBuyAndSellStock_121
    {
        // this one is better both in performance and in readability
        // time complexity O(n), space complexity O(1)
        public int MaxProfit(int[] prices)
        {
            var maxProfit = 0;
            var minValue = prices.First();

            foreach (var price in prices)
            {
                maxProfit = Math.Max(maxProfit, price - minValue);
                minValue = Math.Min(price, minValue);
            }

            return maxProfit;
        }
    }
}
