using LeetCodeProblems.HashingOrArrays;
using LeetCodeProblems.Interfaces.Easy;

namespace GrindingLeetCode.UnitTests.Easy
{

    [TestClass]
    public class TwoSumHashMapSolution_1_Tests
    {
        private ITwoSum_1 _solution;

        [TestInitialize]
        public void Initialize()
        {
            _solution = new TwoSumHashMapSolution_1();
        }

        [TestMethod]
        public void TwoSum_Example1_ReturnsCorrectIndices()
        {
            int[] nums = { 2, 7, 11, 15 };
            int target = 9;
            int[] result = _solution.TwoSum(nums, target);
            CollectionAssert.AreEquivalent(new[] { 0, 1 }, result);
        }

        [TestMethod]
        public void TwoSum_Example2_ReturnsCorrectIndices()
        {
            int[] nums = { 3, 2, 4 };
            int target = 6;
            int[] result = _solution.TwoSum(nums, target);
            CollectionAssert.AreEquivalent(new[] { 1, 2 }, result);
        }

        [TestMethod]
        public void TwoSum_NoSolution_ReturnsMinusOneArray()
        {
            int[] nums = { 1, 2, 3 };
            int target = 7;
            int[] result = _solution.TwoSum(nums, target);
            CollectionAssert.AreEqual(new[] { -1, -1 }, result);
        }

        [TestMethod]
        public void TwoSum_DuplicateNumbers_ReturnsCorrectIndices()
        {
            int[] nums = { 3, 3 };
            int target = 6;
            int[] result = _solution.TwoSum(nums, target);
            CollectionAssert.AreEquivalent(new[] { 0, 1 }, result);
        }

        [TestMethod]
        public void TwoSum_SingleElement_ReturnsMinusOneArray()
        {
            int[] nums = { 5 };
            int target = 10;
            int[] result = _solution.TwoSum(nums, target);
            CollectionAssert.AreEqual(new[] { -1, -1 }, result);
        }

        [TestMethod]
        public void TwoSum_EmptyArray_ReturnsMinusOneArray()
        {
            int[] nums = { };
            int target = 0;
            int[] result = _solution.TwoSum(nums, target);
            CollectionAssert.AreEqual(new[] { -1, -1 }, result);
        }

        [TestMethod]
        public void TwoSumHashMap_Example1_ReturnsCorrectIndices()
        {
            int[] nums = { 2, 7, 11, 15 };
            int target = 9;
            int[] result = _solution.TwoSum(nums, target);
            CollectionAssert.AreEquivalent(new[] { 0, 1 }, result);
        }

        [TestMethod]
        public void TwoSumHashMap_Example2_ReturnsCorrectIndices()
        {
            int[] nums = { 3, 2, 4 };
            int target = 6;
            int[] result = _solution.TwoSum(nums, target);
            CollectionAssert.AreEquivalent(new[] { 1, 2 }, result);
        }

        [TestMethod]
        public void TwoSumHashMap_NoSolution_ReturnsMinusOneArray()
        {
            int[] nums = { 1, 2, 3 };
            int target = 7;
            int[] result = _solution.TwoSum(nums, target);
            CollectionAssert.AreEqual(new[] { -1, -1 }, result);
        }

        [TestMethod]
        public void TwoSumHashMap_DuplicateNumbers_ReturnsCorrectIndices()
        {
            int[] nums = { 3, 3 };
            int target = 6;
            int[] result = _solution.TwoSum(nums, target);
            CollectionAssert.AreEquivalent(new[] { 0, 1 }, result);
        }

        [TestMethod]
        public void TwoSumHashMap_SingleElement_ReturnsMinusOneArray()
        {
            int[] nums = { 5 };
            int target = 10;
            int[] result = _solution.TwoSum(nums, target);
            CollectionAssert.AreEqual(new[] { -1, -1 }, result);
        }

        [TestMethod]
        public void TwoSumHashMap_EmptyArray_ReturnsMinusOneArray()
        {
            int[] nums = { };
            int target = 0;
            int[] result = _solution.TwoSum(nums, target);
            CollectionAssert.AreEqual(new[] { -1, -1 }, result);
        }
    }
}