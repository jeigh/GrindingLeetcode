using LeetCodeProblems.TwoPointers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GrindingLeetCode.UnitTests.Medium
{
    [TestClass]
    public class RotateArrayReverseSolution_189_Tests
    {
        private RotateArrayReverseSolution_189 _solution;

        [TestInitialize]
        public void Initialize()
        {
            _solution = new RotateArrayReverseSolution_189();
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
        public void Reverse_WholeArray_ReversesAll()
        {
            int[] nums = { 1, 2, 3, 4, 5 };
            _solution.Reverse(nums, 0, nums.Length - 1);
            CollectionAssert.AreEqual(new[] { 5, 4, 3, 2, 1 }, nums);
        }

        [TestMethod]
        public void Reverse_SubArray_ReversesSegment()
        {
            int[] nums = { 1, 2, 3, 4, 5 };
            _solution.Reverse(nums, 1, 3); // reverse elements at indices 1..3
            CollectionAssert.AreEqual(new[] { 1, 4, 3, 2, 5 }, nums);
        }

        [TestMethod]
        public void Reverse_SingleElement_NoChange()
        {
            int[] nums = { 7, 8, 9 };
            _solution.Reverse(nums, 1, 1); // single element
            CollectionAssert.AreEqual(new[] { 7, 8, 9 }, nums);
        }
    }
}