using LeetCodeProblems.TwoPointers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GrindingLeetCode.UnitTests.Easy
{
    [TestClass]
    public class MergeSortedArraySolution_88_Tests
    {
        private MergeSortedArraySolution_88 _solution;

        [TestInitialize]
        public void Initialize()
        {
            _solution = new MergeSortedArraySolution_88();
        }

        [TestMethod]
        public void Merge_BothArraysHaveElements_MergesCorrectly()
        {
            int[] nums1 = { 1, 2, 3, 0, 0, 0 };
            int[] nums2 = { 2, 5, 6 };
            _solution.Merge(nums1, 3, nums2, 3);
            CollectionAssert.AreEqual(new[] { 1, 2, 2, 3, 5, 6 }, nums1);
        }

        [TestMethod]
        public void Merge_SecondArrayEmpty_OriginalRemains()
        {
            int[] nums1 = { 1, 2, 3 };
            int[] nums2 = { };
            _solution.Merge(nums1, 3, nums2, 0);
            CollectionAssert.AreEqual(new[] { 1, 2, 3 }, nums1);
        }

        [TestMethod]
        public void Merge_FirstArrayEmpty_SecondCopied()
        {
            int[] nums1 = { 0, 0, 0 };
            int[] nums2 = { 2, 5, 6 };
            _solution.Merge(nums1, 0, nums2, 3);
            CollectionAssert.AreEqual(new[] { 2, 5, 6 }, nums1);
        }

        [TestMethod]
        public void Merge_BothArraysEmpty_ResultEmpty()
        {
            int[] nums1 = { };
            int[] nums2 = { };
            _solution.Merge(nums1, 0, nums2, 0);
            CollectionAssert.AreEqual(new int[0], nums1);
        }

        [TestMethod]
        public void Merge_InterleavedElements_MergesCorrectly()
        {
            int[] nums1 = { 1, 3, 5, 0, 0, 0 };
            int[] nums2 = { 2, 4, 6 };
            _solution.Merge(nums1, 3, nums2, 3);
            CollectionAssert.AreEqual(new[] { 1, 2, 3, 4, 5, 6 }, nums1);
        }

        [TestMethod]
        public void Merge_AllElementsInSecondArraySmaller()
        {
            int[] nums1 = { 4, 5, 6, 0, 0, 0 };
            int[] nums2 = { 1, 2, 3 };
            _solution.Merge(nums1, 3, nums2, 3);
            CollectionAssert.AreEqual(new[] { 1, 2, 3, 4, 5, 6 }, nums1);
        }

        [TestMethod]
        public void Merge_AllElementsInFirstArraySmaller()
        {
            int[] nums1 = { 1, 2, 3, 0, 0, 0 };
            int[] nums2 = { 4, 5, 6 };
            _solution.Merge(nums1, 3, nums2, 3);
            CollectionAssert.AreEqual(new[] { 1, 2, 3, 4, 5, 6 }, nums1);
        }

        [TestMethod]
        public void Merge_DuplicateElements_MergesCorrectly()
        {
            int[] nums1 = { 1, 2, 2, 0, 0, 0 };
            int[] nums2 = { 2, 2, 3 };
            _solution.Merge(nums1, 3, nums2, 3);
            CollectionAssert.AreEqual(new[] { 1, 2, 2, 2, 2, 3 }, nums1);
        }
    }
}