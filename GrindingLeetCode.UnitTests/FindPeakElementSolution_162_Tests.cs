using LeetCodeProblems.BinarySearch;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GrindingLeetCode.UnitTests
{
    [TestClass]
    public class FindPeakElementSolution_162_Tests
    {
        private FindPeakElementSolution_162 _solution;

        [TestInitialize]
        public void Initialize()
        {
            _solution = new FindPeakElementSolution_162();
        }

        [TestMethod]
        public void FindPeakElement_SingleElementArray_ReturnsThatIndex()
        {
            // Arrange
            int[] nums = { 5 };

            // Act
            int result = _solution.FindPeakElement(nums);

            // Assert
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void FindPeakElement_TwoElementsIncreasing_ReturnsSecondIndex()
        {
            // Arrange
            int[] nums = { 1, 2 };

            // Act
            int result = _solution.FindPeakElement(nums);

            // Assert
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void FindPeakElement_TwoElementsDecreasing_ReturnsFirstIndex()
        {
            // Arrange
            int[] nums = { 2, 1 };

            // Act
            int result = _solution.FindPeakElement(nums);

            // Assert
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void FindPeakElement_PeakInMiddle_ReturnsPeakIndex()
        {
            // Arrange
            int[] nums = { 1, 3, 2 };

            // Act
            int result = _solution.FindPeakElement(nums);

            // Assert
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void FindPeakElement_MultiplePeaks_ReturnsAnyPeakIndex()
        {
            // Arrange
            int[] nums = { 1, 3, 2, 4, 1 };

            // Act
            int result = _solution.FindPeakElement(nums);

            // Assert
            // Either index 1 (value 3) or index 3 (value 4) is correct
            Assert.IsTrue(result == 1 || result == 3);
        }

        [TestMethod]
        public void FindPeakElement_IncreasingArray_ReturnsLastIndex()
        {
            // Arrange
            int[] nums = { 1, 2, 3, 4, 5 };

            // Act
            int result = _solution.FindPeakElement(nums);

            // Assert
            Assert.AreEqual(4, result);
        }

        [TestMethod]
        public void FindPeakElement_DecreasingArray_ReturnsFirstIndex()
        {
            // Arrange
            int[] nums = { 5, 4, 3, 2, 1 };

            // Act
            int result = _solution.FindPeakElement(nums);

            // Assert
            Assert.IsTrue(result == 0);
        }

        [TestMethod]
        public void FindPeakElement_LargeExample_ReturnsPeakIndex()
        {
            // Arrange
            int[] nums = { 1, 2, 1, 3, 5, 6, 4 };

            // Act
            int result = _solution.FindPeakElement(nums);

            // Assert
            // Any of these indices could be valid peaks
            Assert.IsTrue(result == 1 || result == 5);
        }

        [TestMethod]
        public void FindPeakElement_PlateauIsNotAPeak_ReturnsSurroundingPeak()
        {
            // Arrange - Note: plateau (equal values) are not peaks per LeetCode definition
            int[] nums = { 1, 2, 2, 2, 1 };

            // Act
            int result = _solution.FindPeakElement(nums);

            // Assert
            // Since plateaus are not peaks, a correct implementation would either
            // return index 1 (start of plateau) or find another peak if present
            Assert.IsTrue(result == -1);
            // We can't assert a specific value since the problem allows any peak
        }
    }
}