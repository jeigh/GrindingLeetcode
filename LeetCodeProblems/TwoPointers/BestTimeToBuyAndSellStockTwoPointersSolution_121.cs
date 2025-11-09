using LeetCodeProblems.Interfaces.Easy;

namespace LeetCodeProblems.TwoPointers
{
    public class BestTimeToBuyAndSellStockTwoPointersSolution_121 : IBestTimeToBuyAndSellStock_121
    {
        // this is the two-pointers solution.   
        // time complexity O(n), space complexity O(1)
        public int MaxProfit(int [] prices)
        {
            var left = 0;
            var right = left + 1;
            var maxProfit = 0;

            while(right < prices.Length)
            {
                if (prices[left] > prices[right]) left = right;
                else
                {
                    var diff = prices[right] - prices[left];
                    maxProfit = Math.Max(maxProfit, diff);
                    right++;
                }
            }
            return maxProfit;
        }
    }
}
