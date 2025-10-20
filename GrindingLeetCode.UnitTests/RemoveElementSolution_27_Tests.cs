using LeetCodeProblems.HashingOrArrays;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GrindingLeetCode.UnitTests
{
    [TestClass]
    public class RemoveElementSolution_27_Tests
    {
        private RemoveElementSolution_27 _solution;

        [TestInitialize]
        public void Initialize()
        {
            _solution = new RemoveElementSolution_27();
        }

        [TestMethod]
        public void RemoveElement_Example1_RemovesAllTarget()
        {
            int[] nums = { 3, 2, 2, 3 };
            int val = 3;
            int k = _solution.RemoveElement(nums, val);
            Assert.AreEqual(2, k);
            CollectionAssert.AreEquivalent(new[] { 2, 2 }, nums[..k]);
        }

        [TestMethod]
        public void RemoveElement_Example2_RemovesAllTarget()
        {
            int[] nums = { 0, 1, 2, 2, 3, 0, 4, 2 };
            int val = 2;
            int k = _solution.RemoveElement(nums, val);
            Assert.AreEqual(5, k);
            CollectionAssert.AreEquivalent(new[] { 0, 1, 3, 0, 4 }, nums[..k]);
        }

        [TestMethod]
        public void RemoveElement_NoTarget_ReturnsOriginalLength()
        {
            int[] nums = { 1, 2, 3, 4 };
            int val = 5;
            int k = _solution.RemoveElement(nums, val);
            Assert.AreEqual(4, k);
            CollectionAssert.AreEquivalent(new[] { 1, 2, 3, 4 }, nums[..k]);
        }

        [TestMethod]
        public void RemoveElement_AllElementsAreTarget_ReturnsZero()
        {
            int[] nums = { 7, 7, 7 };
            int val = 7;
            int k = _solution.RemoveElement(nums, val);
            Assert.AreEqual(0, k);
        }

        [TestMethod]
        public void RemoveElement_EmptyArray_ReturnsZero()
        {
            int[] nums = { };
            int val = 1;
            int k = _solution.RemoveElement(nums, val);
            Assert.AreEqual(0, k);
        }

        [TestMethod]
        public void RemoveElement_SingleElementIsTarget_ReturnsZero()
        {
            int[] nums = { 2 };
            int val = 2;
            int k = _solution.RemoveElement(nums, val);
            Assert.AreEqual(0, k);
        }

        [TestMethod]
        public void RemoveElement_SingleElementIsNotTarget_ReturnsOne()
        {
            int[] nums = { 2 };
            int val = 3;
            int k = _solution.RemoveElement(nums, val);
            Assert.AreEqual(1, k);
            CollectionAssert.AreEquivalent(new[] { 2 }, nums[..k]);
        }
    }
}