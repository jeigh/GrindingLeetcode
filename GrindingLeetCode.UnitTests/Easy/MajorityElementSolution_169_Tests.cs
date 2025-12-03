using LeetCodeProblems.HashingOrArrays;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GrindingLeetCode.UnitTests.Easy
{
    [TestClass]
    public class MajorityElementSolution_169_Tests
    {
        private MajorityElementSolution_169 _solution;

        [TestInitialize]
        public void Initialize()
        {
            _solution = new MajorityElementSolution_169();
        }

        [TestMethod]
        public void MajorityElement_SingleElementArray_ReturnsElement()
        {
            int[] nums = { 7 };
            int result = _solution.MajorityElement(nums);
            Assert.AreEqual(7, result);
        }

        [TestMethod]
        public void MajorityElement_OddLengthArray_ReturnsMajority()
        {
            int[] nums = { 3, 3, 4 };
            int result = _solution.MajorityElement(nums);
            Assert.AreEqual(3, result);
        }

        [TestMethod]
        public void MajorityElement_EvenLengthArray_ReturnsMajority()
        {
            int[] nums = { 2, 2, 1, 1, 1, 2, 2 };
            int result = _solution.MajorityElement(nums);
            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void MajorityElement_AllSame_ReturnsElement()
        {
            int[] nums = { 5, 5, 5, 5, 5 };
            int result = _solution.MajorityElement(nums);
            Assert.AreEqual(5, result);
        }

        [TestMethod]
        public void MajorityElement_MajorityAtEnd_ReturnsMajority()
        {
            int[] nums = { 1, 2, 3, 2, 2, 2, 2 };
            int result = _solution.MajorityElement(nums);
            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void MajorityElement_MajorityAtStart_ReturnsMajority()
        {
            int[] nums = { 4, 4, 4, 2, 2, 4, 4 };
            int result = _solution.MajorityElement(nums);
            Assert.AreEqual(4, result);
        }
    }
}