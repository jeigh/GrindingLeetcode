using LeetCodeProblems.HashingOrArrays;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GrindingLeetCode.UnitTests
{
    [TestClass]
    public class MergeSortSolution_912_CopyRemaining_Tests
    {
        private MergeSortSolution_912 _solution;

        [TestInitialize]
        public void Initialize()
        {
            _solution = new MergeSortSolution_912();
        }

        [TestMethod]
        public void CopyRemaining_CopiesAllElementsToEnd()
        {
            int[] merged = { 0, 0, 0, 0, 0 };
            int[] mergingArray = { 1, 2, 3 };
            int mergingOffset = 0;
            int mergedOffset = 2;

            _solution.CopyRemaining(merged, mergingArray, ref mergingOffset, ref mergedOffset);

            CollectionAssert.AreEqual(new[] { 0, 0, 1, 2, 3 }, merged);
            Assert.AreEqual(3, mergingOffset);
            Assert.AreEqual(5, mergedOffset);
        }

        [TestMethod]
        public void CopyRemaining_OffsetNotZero_CopiesFromOffset()
        {
            int[] merged = { 0, 0, 0, 0 };
            int[] mergingArray = { 5, 6, 7 };
            int mergingOffset = 1;
            int mergedOffset = 2;

            _solution.CopyRemaining(merged, mergingArray, ref mergingOffset, ref mergedOffset);

            CollectionAssert.AreEqual(new[] { 0, 0, 6, 7 }, merged);
            Assert.AreEqual(3, mergingOffset);
            Assert.AreEqual(4, mergedOffset);
        }

        [TestMethod]
        public void CopyRemaining_EmptyMergingArray_DoesNothing()
        {
            int[] merged = { 1, 2, 3 };
            int[] mergingArray = { };
            int mergingOffset = 0;
            int mergedOffset = 1;

            _solution.CopyRemaining(merged, mergingArray, ref mergingOffset, ref mergedOffset);

            CollectionAssert.AreEqual(new[] { 1, 2, 3 }, merged);
            Assert.AreEqual(0, mergingOffset);
            Assert.AreEqual(1, mergedOffset);
        }

        [TestMethod]
        public void CopyRemaining_MergingOffsetAtEnd_DoesNothing()
        {
            int[] merged = { 1, 2, 3, 4 };
            int[] mergingArray = { 9, 8, 7 };
            int mergingOffset = 3;
            int mergedOffset = 2;

            _solution.CopyRemaining(merged, mergingArray, ref mergingOffset, ref mergedOffset);

            CollectionAssert.AreEqual(new[] { 1, 2, 3, 4 }, merged);
            Assert.AreEqual(3, mergingOffset);
            Assert.AreEqual(2, mergedOffset);
        }
    }
}