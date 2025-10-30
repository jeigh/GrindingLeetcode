using LeetCodeProblems.BinarySearch;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GrindingLeetCode.UnitTests.BinarySearch
{
    [TestClass]
    public class FindMinimumInRotatedSortedArray_153_Tests
    {
        private FindMinimumInRotatedSortedArray_153 _solution;

        [TestInitialize]
        public void Initialize()
        {
            _solution = new FindMinimumInRotatedSortedArray_153();
        }

        [TestMethod]
        public void FindMin_RotatedArray_ReturnsMinimumValue()
        {
            // Arrange
            int[] nums = { 4, 5, 6, 7, 0, 1, 2 };

            // Act
            int result = _solution.FindMin(nums);

            // Assert
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void FindMin_NotRotatedArray_ReturnsFirstElement()
        {
            // Arrange
            int[] nums = { 1, 2, 3, 4, 5 };

            // Act
            int result = _solution.FindMin(nums);

            // Assert
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void FindMin_SingleElementArray_ReturnsThatElement()
        {
            // Arrange
            int[] nums = { 5 };

            // Act
            int result = _solution.FindMin(nums);

            // Assert
            Assert.AreEqual(5, result);
        }

        [TestMethod]
        public void FindMin_TwoElementRotated_ReturnsMinimum()
        {
            // Arrange
            int[] nums = { 2, 1 };

            // Act
            int result = _solution.FindMin(nums);

            // Assert
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void FindMin_RotatedByOne_ReturnsMinimum()
        {
            // Arrange
            int[] nums = { 2, 3, 4, 5, 1 };

            // Act
            int result = _solution.FindMin(nums);

            // Assert
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void FindMin_RotatedNearMiddle_ReturnsMinimum()
        {
            // Arrange
            int[] nums = { 4, 5, 6, 7, 8, 1, 2, 3 };

            // Act
            int result = _solution.FindMin(nums);

            // Assert
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void FindMin_FullyRotated_ReturnsMinimum()
        {
            // Arrange - array rotated completely (same as not rotated)
            int[] nums = { 1, 2, 3, 4, 5 };

            // Act
            int result = _solution.FindMin(nums);

            // Assert
            Assert.AreEqual(1, result);
        }
        
        [TestMethod]
        public void FindMin_LargeRotatedArray_ReturnsMinimum()
        {
            // Arrange
            int[] nums = new int[1000];
            for (int i = 0; i < 500; i++)
            {
                nums[i] = i + 501; // 501 to 1000
            }
            for (int i = 500; i < 1000; i++)
            {
                nums[i] = i - 499; // 1 to 500
            }

            // Act
            int result = _solution.FindMin(nums);

            // Assert
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void FindMin_TwoElementNotRotated_ReturnsMinimum()
        {
            // Arrange
            int[] nums = { 1, 2 };

            // Act
            int result = _solution.FindMin(nums);

            // Assert
            Assert.AreEqual(1, result);
        }
    }
}