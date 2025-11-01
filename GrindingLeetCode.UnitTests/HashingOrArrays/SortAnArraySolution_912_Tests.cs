using LeetCodeProblems.HashingOrArrays;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GrindingLeetCode.UnitTests.HashingOrArrays
{
    [TestClass]
    public class SortAnArraySolution_912_Tests
    {
        private MergeSortSolution_912 _solution;

        [TestInitialize]
        public void Initialize()
        {
            _solution = new MergeSortSolution_912();
        }

        [TestMethod]
        public void SortArray_Example1_ReturnsSortedArray()
        {
            int[] nums = { 5, 2, 3, 1 };
            int[] result = _solution.SortArray(nums);
            CollectionAssert.AreEqual(new[] { 1, 2, 3, 5 }, result);
        }

        [TestMethod]
        public void SortArray_Example2_ReturnsSortedArray()
        {
            int[] nums = { 5, 1, 1, 2, 0, 0 };
            int[] result = _solution.SortArray(nums);
            CollectionAssert.AreEqual(new[] { 0, 0, 1, 1, 2, 5 }, result);
        }

        [TestMethod]
        public void SortArray_AlreadySorted_ReturnsSameArray()
        {
            int[] nums = { 1, 2, 3, 4, 5 };
            int[] result = _solution.SortArray(nums);
            CollectionAssert.AreEqual(new[] { 1, 2, 3, 4, 5 }, result);
        }

        [TestMethod]
        public void SortArray_ReverseSorted_ReturnsSortedArray()
        {
            int[] nums = { 5, 4, 3, 2, 1 };
            int[] result = _solution.SortArray(nums);
            CollectionAssert.AreEqual(new[] { 1, 2, 3, 4, 5 }, result);
        }

        [TestMethod]
        public void SortArray_AllSameElements_ReturnsSameArray()
        {
            int[] nums = { 7, 7, 7, 7 };
            int[] result = _solution.SortArray(nums);
            CollectionAssert.AreEqual(new[] { 7, 7, 7, 7 }, result);
        }



        [TestMethod]
        public void SortArray_SingleElement_ReturnsSameArray()
        {
            int[] nums = { 42 };
            int[] result = _solution.SortArray(nums);
            CollectionAssert.AreEqual(new[] { 42 }, result);
        }

        [TestMethod]
        public void SortArray_NegativeAndPositiveNumbers_ReturnsSortedArray()
        {
            int[] nums = { -1, 2, -3, 4, 0 };
            int[] result = _solution.SortArray(nums);
            CollectionAssert.AreEqual(new[] { -3, -1, 0, 2, 4 }, result);
        }
    }
}