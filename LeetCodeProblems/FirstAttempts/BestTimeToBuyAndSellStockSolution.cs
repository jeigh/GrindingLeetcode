namespace LeetCodeProblems.FirstAttempts
{
    public class BestTimeToBuyAndSellStockSolution
    {
        // time complexity: O(n^2) (because of the nested loop,
        // space complexity O(1)
        public int MaxProfitBruteForce(int[] prices)
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
                    difference =  prices[j] - prices[i];
                    if (difference > maxDifference) maxDifference = difference;
                    j++;
                }

                i++;
            }

            return maxDifference;
        }

        // this one is better both in performance and in readability
        // time complexity O(n), space complexity O(1)
        public int MaxProfitDynamic(int[] prices)
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

        // this is the two-pointers solution.   
        // time complexity O(n), space complexity O(1)
        public int MaxProfitTwoPointers(int [] prices)
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
