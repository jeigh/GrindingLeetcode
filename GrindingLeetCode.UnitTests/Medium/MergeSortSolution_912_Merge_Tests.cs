using LeetCodeProblems.HashingOrArrays;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GrindingLeetCode.UnitTests.Medium
{
    [TestClass]
    public class MergeSortSolution_912_Merge_Tests
    {
        private MergeSortSolution_912 _solution;

        [TestInitialize]
        public void Initialize()
        {
            _solution = new MergeSortSolution_912();
        }

        [TestMethod]
        public void Merge_TwoSortedHalves_MergesCorrectly()
        {
            int[] nums = { 1, 3, 5, 2, 4, 6 };
            // left = 0, mid = 2, right = 5
            _solution.merge(nums, 0, 2, 5);
            CollectionAssert.AreEqual(new[] { 1, 2, 3, 4, 5, 6 }, nums);
        }

        [TestMethod]
        public void Merge_LeftHalfSmaller_MergesCorrectly()
        {
            int[] nums = { 1, 2, 3, 4, 5, 6 };
            // left = 0, mid = 2, right = 5 (already sorted)
            _solution.merge(nums, 0, 2, 5);
            CollectionAssert.AreEqual(new[] { 1, 2, 3, 4, 5, 6 }, nums);
        }

        [TestMethod]
        public void Merge_RightHalfSmaller_MergesCorrectly()
        {
            int[] nums = { 4, 5, 6, 1, 2, 3 };
            // left = 0, mid = 2, right = 5
            _solution.merge(nums, 0, 2, 5);
            CollectionAssert.AreEqual(new[] { 1, 2, 3, 4, 5, 6 }, nums);
        }

        [TestMethod]
        public void Merge_WithDuplicates_MergesCorrectly()
        {
            int[] nums = { 1, 2, 2, 1, 2, 2 };
            // left = 0, mid = 2, right = 5
            _solution.merge(nums, 0, 2, 5);
            CollectionAssert.AreEqual(new[] { 1, 1, 2, 2, 2, 2 }, nums);
        }

        [TestMethod]
        public void Merge_SingleElementHalves_MergesCorrectly()
        {
            int[] nums = { 2, 1 };
            // left = 0, mid = 0, right = 1
            _solution.merge(nums, 0, 0, 1);
            CollectionAssert.AreEqual(new[] { 1, 2 }, nums);
        }

        [TestMethod]
        public void Merge_AlreadySorted_MaintainsOrder()
        {
            int[] nums = { 1, 2, 3, 4 };
            // left = 0, mid = 1, right = 3
            _solution.merge(nums, 0, 1, 3);
            CollectionAssert.AreEqual(new[] { 1, 2, 3, 4 }, nums);
        }
    }
}