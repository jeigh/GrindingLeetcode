using LeetCodeProblems.HashingOrArrays;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GrindingLeetCode.UnitTests.HashingOrArrays
{
    [TestClass]
    public class LargestConsecutive_Tests
    {
        private LargestConsecutiveSolution_128 _solution;

        [TestInitialize]
        public void Initialize()
        {
            _solution = new LargestConsecutiveSolution_128();
        }

        [TestMethod]
        public void LongestConsecutive_Example1_Returns4()
        {
            int[] nums = { 100, 4, 200, 1, 3, 2 };
            int result = _solution.LongestConsecutive(nums);
            Assert.AreEqual(4, result);
        }

        [TestMethod]
        public void LongestConsecutive_Example2_Returns9()
        {
            int[] nums = { 0, 3, 7, 2, 5, 8, 4, 6, 0, 1 };
            int result = _solution.LongestConsecutive(nums);
            Assert.AreEqual(9, result);
        }

        [TestMethod]
        public void LongestConsecutive_EmptyArray_Returns0()
        {
            int[] nums = { };
            int result = _solution.LongestConsecutive(nums);
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void LongestConsecutive_SingleElement_Returns1()
        {
            int[] nums = { 42 };
            int result = _solution.LongestConsecutive(nums);
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void LongestConsecutive_AllSameElements_Returns1()
        {
            int[] nums = { 5, 5, 5, 5 };
            int result = _solution.LongestConsecutive(nums);
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void LongestConsecutive_NegativeNumbers_ReturnsCorrectLength()
        {
            int[] nums = { -2, -1, 0, 1, 2 };
            int result = _solution.LongestConsecutive(nums);
            Assert.AreEqual(5, result);
        }

        [TestMethod]
        public void LongestConsecutive_MultipleConsecutiveGroups_ReturnsLongest()
        {
            int[] nums = { 10, 5, 12, 3, 55, 30, 4, 11, 2 };
            int result = _solution.LongestConsecutive(nums);
            Assert.AreEqual(4, result); // 2,3,4,5
        }

        [TestMethod]
        public void LongestConsecutiveOptimized_Example1_Returns4()
        {
            int[] nums = { 100, 4, 200, 1, 3, 2 };
            int result = _solution.LongestConsecutiveOptimized(nums);
            Assert.AreEqual(4, result);
        }

        [TestMethod]
        public void LongestConsecutiveOptimized_EmptyArray_Returns0()
        {
            int[] nums = { };
            int result = _solution.LongestConsecutiveOptimized(nums);
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void LongestConsecutiveOptimized_AllSameElements_Returns1()
        {
            int[] nums = { 7, 7, 7 };
            int result = _solution.LongestConsecutiveOptimized(nums);
            Assert.AreEqual(1, result);
        }
    }
}