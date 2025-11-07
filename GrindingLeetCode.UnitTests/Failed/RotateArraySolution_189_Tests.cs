using LeetCodeProblems.Failed;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GrindingLeetCode.UnitTests.Failed
{
    [TestClass]
    public class RotateArraySolution_189_Tests
    {
        private RotateArrayTooSlowSolution_189 _solution;

        [TestInitialize]
        public void Initialize()
        {
            _solution = new RotateArrayTooSlowSolution_189();
        }

        [TestMethod]
        public void Rotate_BasicShift_RotatesRightByK()
        {
            int[] nums = { 1, 2, 3, 4, 5, 6, 7 };
            _solution.Rotate(nums, 3);
            CollectionAssert.AreEqual(new[] { 5, 6, 7, 1, 2, 3, 4 }, nums);
        }

        [TestMethod]
        public void Rotate_KGreaterThanLength_UsesModulo()
        {
            int[] nums = { 1, 2, 3, 4 };
            _solution.Rotate(nums, 5); // 5 % 4 == 1
            CollectionAssert.AreEqual(new[] { 4, 1, 2, 3 }, nums);
        }

        [TestMethod]
        public void Rotate_KIsZero_NoChange()
        {
            int[] nums = { 10, 20, 30 };
            _solution.Rotate(nums, 0);
            CollectionAssert.AreEqual(new[] { 10, 20, 30 }, nums);
        }

        [TestMethod]
        public void Rotate_EmptyArray_NoChange()
        {
            int[] nums = { };
            _solution.Rotate(nums, 3);
            CollectionAssert.AreEqual(new int[0], nums);
        }

        [TestMethod]
        public void Rotate_SingleElement_NoChange()
        {
            int[] nums = { 42 };
            _solution.Rotate(nums, 10);
            CollectionAssert.AreEqual(new[] { 42 }, nums);
        }

        [TestMethod]
        public void Rotate_FullRotation_NoChange()
        {
            int[] nums = { 1, 2, 3 };
            _solution.Rotate(nums, 3); // full rotation
            CollectionAssert.AreEqual(new[] { 1, 2, 3 }, nums);
        }

        [TestMethod]
        public void Rotate_WithDuplicates_RotatesCorrectly()
        {
            int[] nums = { 1, 2, 3, 1, 2 };
            _solution.Rotate(nums, 2);
            CollectionAssert.AreEqual(new[] { 1, 2, 1, 2, 3 }, nums);
        }
    }
}