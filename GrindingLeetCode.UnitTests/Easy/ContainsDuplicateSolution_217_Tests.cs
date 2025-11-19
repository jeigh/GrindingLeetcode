using LeetCodeProblems.HashingOrArrays;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GrindingLeetCode.UnitTests.Easy
{
    [TestClass]
    public class ContainsDuplicateSolution_217_Tests
    {
        private ContainsDuplicateSolution_217 _solution;

        [TestInitialize]
        public void Initialize()
        {
            _solution = new ContainsDuplicateSolution_217();
        }

        [TestMethod]
        public void HasDuplicateBruteForce_ContainsDuplicate_ReturnsTrue()
        {
            int[] nums = { 1, 2, 3, 1 };
            Assert.IsTrue(_solution.hasDuplicate(nums));
        }

        [TestMethod]
        public void HasDuplicateBruteForce_NoDuplicate_ReturnsFalse()
        {
            int[] nums = { 1, 2, 3, 4 };
            Assert.IsFalse(_solution.hasDuplicate(nums));
        }

        [TestMethod]
        public void HasDuplicateBruteForce_EmptyArray_ReturnsFalse()
        {
            int[] nums = { };
            Assert.IsFalse(_solution.hasDuplicate(nums));
        }

        [TestMethod]
        public void HasDuplicateBruteForce_SingleElement_ReturnsFalse()
        {
            int[] nums = { 42 };
            Assert.IsFalse(_solution.hasDuplicate(nums));
        }

        [TestMethod]
        public void HasDuplicateBruteForce_AllDuplicates_ReturnsTrue()
        {
            int[] nums = { 7, 7, 7, 7 };
            Assert.IsTrue(_solution.hasDuplicate(nums));
        }

        [TestMethod]
        public void HasDuplicate_ContainsDuplicate_ReturnsTrue()
        {
            int[] nums = { 1, 2, 3, 1 };
            Assert.IsTrue(_solution.hasDuplicate(nums));
        }

        [TestMethod]
        public void HasDuplicate_NoDuplicate_ReturnsFalse()
        {
            int[] nums = { 1, 2, 3, 4 };
            Assert.IsFalse(_solution.hasDuplicate(nums));
        }

        [TestMethod]
        public void HasDuplicate_EmptyArray_ReturnsFalse()
        {
            int[] nums = { };
            Assert.IsFalse(_solution.hasDuplicate(nums));
        }

        [TestMethod]
        public void HasDuplicate_SingleElement_ReturnsFalse()
        {
            int[] nums = { 42 };
            Assert.IsFalse(_solution.hasDuplicate(nums));
        }

        [TestMethod]
        public void HasDuplicate_AllDuplicates_ReturnsTrue()
        {
            int[] nums = { 7, 7, 7, 7 };
            Assert.IsTrue(_solution.hasDuplicate(nums));
        }
    }
}