using LeetCodeProblems.Interfaces;
using LeetCodeProblems.TwoPointers;

namespace GrindingLeetCode.UnitTests.TwoPointers
{
    [TestClass]
    public class TwoIntegerSumIITwoPointersSolution_167_Tests
    {
        private ITwoSum _solution;

        [TestInitialize]
        public void Initialize()
        {
            _solution = new TwoIntegerSumIITwoPointersSolution_167();
        }

        [TestMethod]
        public void TwoSum_Example1_ReturnsCorrectIndices()
        {
            int[] numbers = { 2, 7, 11, 15 };
            int target = 9;
            int[] result = _solution.TwoSum(numbers, target);
            CollectionAssert.AreEqual(new[] { 1, 2 }, result);
        }

        [TestMethod]
        public void TwoSum_Example2_ReturnsCorrectIndices()
        {
            int[] numbers = { 2, 3, 4 };
            int target = 6;
            int[] result = _solution.TwoSum(numbers, target);
            CollectionAssert.AreEqual(new[] { 1, 3 }, result);
        }

        [TestMethod]
        public void TwoSum_NegativeNumbers_ReturnsCorrectIndices()
        {
            int[] numbers = { -3, 0, 2, 4, 5 };
            int target = 1;
            int[] result = _solution.TwoSum(numbers, target);
            CollectionAssert.AreEqual(new[] { 1, 4 }, result); // -1 + 2 = 1
        }

        [TestMethod]
        public void TwoSum_SinglePairAtEnds_ReturnsCorrectIndices()
        {
            int[] numbers = { 1, 3, 5, 7, 9 };
            int target = 10;
            int[] result = _solution.TwoSum(numbers, target);
            CollectionAssert.AreEqual(new[] { 1, 5 }, result);
        }

        [TestMethod]
        public void TwoSum_MinLengthArray_ReturnsIndices()
        {
            int[] numbers = { 1, 3 };
            int target = 4;
            int[] result = _solution.TwoSum(numbers, target);
            CollectionAssert.AreEqual(new[] { 1, 2 }, result);
        }

        [TestMethod]
        public void TwoSum_DuplicateElements_ReturnsCorrectPair()
        {
            int[] numbers = { 1, 2, 3, 4, 4, 9 };
            int target = 8;
            int[] result = _solution.TwoSum(numbers, target);
            CollectionAssert.AreEqual(new[] { 4, 5 }, result); // 4 + 4 = 8
        }

        [TestMethod]
        public void TwoSum_NoSolution_ReturnsMinusOneArray()
        {
            int[] numbers = { 1, 2, 3 };
            int target = 100;
            int[] result = _solution.TwoSum(numbers, target);
            CollectionAssert.AreEqual(new[] { -1, -1 }, result);
        }
    }
}