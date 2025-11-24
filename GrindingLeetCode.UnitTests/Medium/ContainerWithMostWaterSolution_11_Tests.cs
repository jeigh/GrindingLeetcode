using LeetCodeProblems.CSharp.TwoPointers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GrindingLeetCode.UnitTests.Medium
{
    [TestClass]
    public class ContainerWithMostWaterSolution_11_Tests
    {
        private ContainerWithMostWaterTwoPointersSolution_11 _solution;

        [TestInitialize]
        public void Initialize()
        {
            _solution = new ContainerWithMostWaterTwoPointersSolution_11();
        }

        [TestMethod]
        public void MaxArea_Example_ReturnsFortyNine()
        {
            int[] height = { 1, 8, 6, 2, 5, 4, 8, 3, 7 };
            int result = _solution.MaxArea(height);
            Assert.AreEqual(49, result);
        }

        [TestMethod]
        public void MaxArea_TwoElements_ReturnsMinTimesWidth()
        {
            int[] height = { 1, 1 };
            int result = _solution.MaxArea(height);
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void MaxArea_MonotonicIncreasing_ReturnsExpected()
        {
            int[] height = { 1, 2, 3, 4, 5 };
            int result = _solution.MaxArea(height);
            Assert.AreEqual(6, result);
        }

        [TestMethod]
        public void MaxArea_MonotonicDecreasing_ReturnsExpected()
        {
            int[] height = { 5, 4, 3, 2, 1 };
            int result = _solution.MaxArea(height);
            Assert.AreEqual(6, result);
        }

        [TestMethod]
        public void MaxArea_WithZeros_ReturnsZeroWhenAppropriate()
        {
            int[] height = { 0, 2, 0 };
            int result = _solution.MaxArea(height);
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void MaxArea_SingleElement_ReturnsZero()
        {
            int[] height = { 10 };
            int result = _solution.MaxArea(height);
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void MaxArea_SymmetricPeaks_ReturnsCorrect()
        {
            int[] height = { 2, 3, 4, 5, 4, 3, 2 };
            int result = _solution.MaxArea(height);
            // best between indices 0 and 6 -> min(2,2)*6 = 12
            // but better is between 1 and 5 -> min(3,3)*4 = 12, or 2 and 4 -> min(4,4)*2 = 8, so max 12
            Assert.AreEqual(12, result);
        }
    }
}