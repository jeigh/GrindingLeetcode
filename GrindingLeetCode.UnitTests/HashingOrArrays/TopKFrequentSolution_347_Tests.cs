using LeetCodeProblems;

namespace GrindingLeetCode.UnitTests.HashingOrArrays
{
    [TestClass]
    public class TopKFrequentSolution_347_Tests
    {
        private TopKFrequentSolution_347 _solution;

        [TestInitialize]
        public void Initialize()
        {
            _solution = new TopKFrequentSolution_347();
        }

        [TestMethod]
        public void TopKFrequent_Example1_ReturnsCorrectElements()
        {
            int[] nums = { 1, 1, 1, 2, 2, 3 };
            int k = 2;
            int[] result = _solution.TopKFrequent(nums, k);
            // The order does not matter
            CollectionAssert.AreEquivalent(new[] { 1, 2 }, result);
        }

        [TestMethod]
        public void TopKFrequent_Example2_ReturnsCorrectElement()
        {
            int[] nums = { 1 };
            int k = 1;
            int[] result = _solution.TopKFrequent(nums, k);
            CollectionAssert.AreEquivalent(new[] { 1 }, result);
        }

        [TestMethod]
        public void TopKFrequent_AllUnique_ReturnsAnyKElements()
        {
            int[] nums = { 4, 5, 6, 7 };
            int k = 2;
            int[] result = _solution.TopKFrequent(nums, k);
            // Any two elements are valid
            Assert.AreEqual(2, result.Length);
            Assert.IsTrue(nums.Contains(result[0]));
            Assert.IsTrue(nums.Contains(result[1]));
            Assert.AreNotEqual(result[0], result[1]);
        }

        [TestMethod]
        public void TopKFrequent_KEqualsArrayLength_ReturnsAllElements()
        {
            int[] nums = { 1, 2, 3, 4 };
            int k = 4;
            int[] result = _solution.TopKFrequent(nums, k);
            CollectionAssert.AreEquivalent(new[] { 1, 2, 3, 4 }, result);
        }

        [TestMethod]
        public void TopKFrequent_MultipleFrequencies_ReturnsMostFrequent()
        {
            int[] nums = { 1, 1, 2, 2, 3 };
            int k = 1;
            int[] result = _solution.TopKFrequent(nums, k);
            // 1 and 2 both appear twice, so either is valid
            Assert.AreEqual(1, result.Length);
            Assert.IsTrue(result[0] == 1 || result[0] == 2);
        }

        [TestMethod]
        public void TopKFrequent_NegativeNumbers_WorksCorrectly()
        {
            int[] nums = { -1, -1, -2, -2, -2, 3 };
            int k = 2;
            int[] result = _solution.TopKFrequent(nums, k);
            CollectionAssert.AreEquivalent(new[] { -2, -1 }, result);
        }

        [TestMethod]
        public void TopKFrequentOptimized_Example1_ReturnsCorrectElements()
        {
            int[] nums = { 1, 1, 1, 2, 2, 3 };
            int k = 2;
            int[] result = _solution.TopKFrequentOptimized(nums, k);
            CollectionAssert.AreEquivalent(new[] { 1, 2 }, result);
        }

        [TestMethod]
        public void TopKFrequentOptimized_AllUnique_ReturnsAnyKElements()
        {
            int[] nums = { 4, 5, 6, 7 };
            int k = 2;
            int[] result = _solution.TopKFrequentOptimized(nums, k);
            Assert.AreEqual(2, result.Length);
            Assert.IsTrue(nums.Contains(result[0]));
            Assert.IsTrue(nums.Contains(result[1]));
            Assert.AreNotEqual(result[0], result[1]);
        }
    }
}