using LeetCodeProblems.HashingOrArrays;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GrindingLeetCode.UnitTests.Medium
{
    [TestClass]
    public class MergeSortSolution_912_RunZipperMerge_Tests
    {
        private MergeSortSolution_912 _solution;

        [TestInitialize]
        public void Initialize()
        {
            _solution = new MergeSortSolution_912();
        }

        [TestMethod]
        public void RunZipperMerge_BothHalvesSorted_MergesCorrectly()
        {
            int[] nums = new int[6];
            int[] leftNums = { 1, 3, 5 };
            int[] rightNums = { 2, 4, 6 };
            int leftOffset = 0, rightOffset = 0, mergedOffset = 0;

            _solution.RunZipperMerge(nums, leftNums, rightNums, ref leftOffset, ref rightOffset, ref mergedOffset);

            CollectionAssert.AreEqual(new[] { 1, 2, 3, 4, 5 }, nums[..5]);
            Assert.AreEqual(3, leftOffset);
            Assert.AreEqual(2, rightOffset);
            Assert.AreEqual(5, mergedOffset);
        }




        [TestMethod]
        public void RunZipperMerge_OneArrayEmpty_MergesCorrectly()
        {
            int[] nums = new int[3];
            int[] leftNums = { };
            int[] rightNums = { 1, 2, 3 };
            int leftOffset = 0, rightOffset = 0, mergedOffset = 0;

            _solution.RunZipperMerge(nums, leftNums, rightNums, ref leftOffset, ref rightOffset, ref mergedOffset);

            // nums should remain unchanged, as leftNums is empty and RunZipperMerge does not copy rightNums
            CollectionAssert.AreEqual(new[] { 0, 0, 0 }, nums);
            Assert.AreEqual(0, leftOffset);
            Assert.AreEqual(0, rightOffset);
            Assert.AreEqual(0, mergedOffset);
        }
    }
}