using LeetCodeProblems.BinarySearch;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GrindingLeetCode.UnitTests.Easy
{
    [TestClass]
    public class BinarySearch_704_Tests
    {
        private BinarySearch_704 _solution;

        [TestInitialize]
        public void Initialize()
        {
            _solution = new BinarySearch_704();
        }

        [TestMethod]
        public void Search_TargetInMiddle_ReturnsCorrectIndex()
        {
            // Arrange
            int[] nums = { -1, 0, 3, 5, 9, 12 };
            int target = 9;

            // Act
            int result = _solution.Search(nums, target);

            // Assert
            Assert.AreEqual(4, result);
        }

        [TestMethod]
        public void Search_TargetAtBeginning_ReturnsCorrectIndex()
        {
            // Arrange
            int[] nums = { -1, 0, 3, 5, 9, 12 };
            int target = -1;

            // Act
            int result = _solution.Search(nums, target);

            // Assert
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void Search_TargetAtEnd_ReturnsCorrectIndex()
        {
            // Arrange
            int[] nums = { -1, 0, 3, 5, 9, 12 };
            int target = 12;

            // Act
            int result = _solution.Search(nums, target);

            // Assert
            Assert.AreEqual(5, result);
        }

        [TestMethod]
        public void Search_TargetNotFound_ReturnsMinusOne()
        {
            // Arrange
            int[] nums = { -1, 0, 3, 5, 9, 12 };
            int target = 2;

            // Act
            int result = _solution.Search(nums, target);

            // Assert
            Assert.AreEqual(-1, result);
        }

        [TestMethod]
        public void Search_EmptyArray_ReturnsMinusOne()
        {
            // Arrange
            int[] nums = { };
            int target = 5;

            // Act
            int result = _solution.Search(nums, target);

            // Assert
            Assert.AreEqual(-1, result);
        }

        [TestMethod]
        public void Search_SingleElementArrayTargetFound_ReturnsZero()
        {
            // Arrange
            int[] nums = { 5 };
            int target = 5;

            // Act
            int result = _solution.Search(nums, target);

            // Assert
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void Search_SingleElementArrayTargetNotFound_ReturnsMinusOne()
        {
            // Arrange
            int[] nums = { 5 };
            int target = 10;

            // Act
            int result = _solution.Search(nums, target);

            // Assert
            Assert.AreEqual(-1, result);
        }
    }
}