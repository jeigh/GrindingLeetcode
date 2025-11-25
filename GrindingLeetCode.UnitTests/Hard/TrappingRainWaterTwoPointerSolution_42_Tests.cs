using LeetCodeProblems.TwoPointers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GrindingLeetCode.UnitTests.Hard
{
    [TestClass]
    public class TrappingRainWaterTwoPointerSolution_42_Tests
    {
        private TrappingRainWaterTwoPointerSolution_42 _solution;

        [TestInitialize]
        public void Initialize()
        {
            _solution = new TrappingRainWaterTwoPointerSolution_42();
        }

        [TestMethod]
        public void Trap_Example_ReturnsSix()
        {
            int[] height = { 0,1,0,2,1,0,1,3,2,1,2,1 };
            int result = _solution.Trap(height);
            Assert.AreEqual(6, result);
        }

        [TestMethod]
        public void Trap_SimplePit_ReturnsTwo()
        {
            int[] height = { 2, 0, 2 };
            int result = _solution.Trap(height);
            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void Trap_MultiPit_ReturnsNine()
        {
            int[] height = { 4, 2, 0, 3, 2, 5 };
            int result = _solution.Trap(height);
            Assert.AreEqual(9, result);
        }

        [TestMethod]
        public void Trap_MonotonicIncreasing_ReturnsZero()
        {
            int[] height = { 0, 1, 2, 3, 4 };
            int result = _solution.Trap(height);
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void Trap_MonotonicDecreasing_ReturnsZero()
        {
            int[] height = { 4, 3, 2, 1, 0 };
            int result = _solution.Trap(height);
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void Trap_AllZeros_ReturnsZero()
        {
            int[] height = { 0, 0, 0, 0 };
            int result = _solution.Trap(height);
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void Trap_SingleElement_ReturnsZero()
        {
            int[] height = { 5 };
            int result = _solution.Trap(height);
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void Trap_TwoElements_ReturnsZero()
        {
            int[] height = { 5, 2 };
            int result = _solution.Trap(height);
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void Trap_PlateauAndValleys_ReturnsCorrect()
        {
            int[] height = { 5, 0, 0, 5 };
            int result = _solution.Trap(height);
            Assert.AreEqual(10, result);
        }
    }
}