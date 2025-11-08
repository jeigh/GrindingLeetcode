using LeetCodeProblems.BruteForce;
using LeetCodeProblems.Dynamic;
using LeetCodeProblems.Interfaces.Easy;
using LeetCodeProblems.TwoPointers;
using LeetCodeProblems.VisualBasic.SlidingWindow;

namespace GrindingLeetCode.UnitTests
{
    [TestClass]
    public class BestTimeToBuyAndSellStockSolution_121_Tests
    {
        public static IEnumerable<object[]> GetImplementations()
        {
            yield return new object[] { new BestTimeToBuyAndSellStockBruteForceSolution_121() };
            yield return new object[] { new BestTimeToBuyAndSellStockDynamicSolution_121() };
            yield return new object[] { new BestTimeToBuyAndSellStockTwoPointersSolution_121() };
            yield return new object[] { new BestTimeToBuyAndSellStock_121() };
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void MaxProfit_Example1_ReturnsFive(IBestTimeToBuyAndSellStock_121 solution)
        {
            int[] prices = { 7, 1, 5, 3, 6, 4 };
            Assert.AreEqual(5, solution.MaxProfit(prices));
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void MaxProfit_Example2_ReturnsZero(IBestTimeToBuyAndSellStock_121 solution)
        {
            int[] prices = { 7, 6, 4, 3, 1 };
            Assert.AreEqual(0, solution.MaxProfit(prices));
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void MaxProfit_TwoElements_Increasing_ReturnsProfit(IBestTimeToBuyAndSellStock_121 solution)
        {
            int[] prices = { 1, 5 };
            Assert.AreEqual(4, solution.MaxProfit(prices));
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void MaxProfit_TwoElements_Decreasing_ReturnsZero(IBestTimeToBuyAndSellStock_121 solution)
        {
            int[] prices = { 5, 1 };
            Assert.AreEqual(0, solution.MaxProfit(prices));
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void MaxProfit_AllSamePrice_ReturnsZero(IBestTimeToBuyAndSellStock_121 solution)
        {
            int[] prices = { 3, 3, 3, 3 };
            Assert.AreEqual(0, solution.MaxProfit(prices));
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void MaxProfit_SingleElement_ReturnsZero(IBestTimeToBuyAndSellStock_121 solution)
        {
            int[] prices = { 10 };
            Assert.AreEqual(0, solution.MaxProfit(prices));
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void MaxProfit_BuyFirstSellLast_ReturnsMaxProfit(IBestTimeToBuyAndSellStock_121 solution)
        {
            int[] prices = { 1, 2, 3, 4, 5 };
            Assert.AreEqual(4, solution.MaxProfit(prices));
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void MaxProfit_LargePriceSwing_ReturnsCorrectProfit(IBestTimeToBuyAndSellStock_121 solution)
        {
            int[] prices = { 100, 50, 25, 200 };
            Assert.AreEqual(175, solution.MaxProfit(prices));
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void MaxProfit_MinAtEnd_ReturnsZero(IBestTimeToBuyAndSellStock_121 solution)
        {
            int[] prices = { 5, 4, 3, 2, 1 };
            Assert.AreEqual(0, solution.MaxProfit(prices));
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void MaxProfit_MaxAtBeginning_ReturnsZero(IBestTimeToBuyAndSellStock_121 solution)
        {
            int[] prices = { 10, 9, 8, 7 };
            Assert.AreEqual(0, solution.MaxProfit(prices));
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void MaxProfit_MultiplePeaksAndValleys_ReturnsOptimalProfit(IBestTimeToBuyAndSellStock_121 solution)
        {
            int[] prices = { 3, 2, 6, 5, 0, 3 };
            Assert.AreEqual(4, solution.MaxProfit(prices));
        }
    }
}