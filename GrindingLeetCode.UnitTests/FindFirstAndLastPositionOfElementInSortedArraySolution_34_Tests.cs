using LeetCodeProblems.BinarySearch;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GrindingLeetCode.UnitTests
{
    [TestClass]
    public class FindFirstAndLastPositionOfElementInSortedArraySolution_34_Tests
    {
        private FindFirstAndLastPositionOfElementInSortedArraySolution_34 _solution;

        [TestInitialize]
        public void Initialize()
        {
            _solution = new FindFirstAndLastPositionOfElementInSortedArraySolution_34();
        }

        [TestMethod]
        public void SearchRange_TargetExistsMultipleTimes_ReturnsCorrectRange()
        {
            // Arrange
            int[] nums = { 5, 7, 7, 8, 8, 8, 10 };
            int target = 8;

            // Act
            int[] result = _solution.SearchRange(nums, target);

            // Assert
            CollectionAssert.AreEqual(new int[] { 3, 5 }, result);
        }

        [TestMethod]
        public void SearchRange_TargetExistsOnce_ReturnsCorrectRange()
        {
            // Arrange
            int[] nums = { 5, 7, 7, 8, 10 };
            int target = 8;

            // Act
            int[] result = _solution.SearchRange(nums, target);

            // Assert
            CollectionAssert.AreEqual(new int[] { 3, 3 }, result);
        }

        [TestMethod]
        public void SearchRange_TargetDoesNotExist_ReturnsMinusOnes()
        {
            // Arrange
            int[] nums = { 5, 7, 7, 8, 8, 10 };
            int target = 6;

            // Act
            int[] result = _solution.SearchRange(nums, target);

            // Assert
            CollectionAssert.AreEqual(new int[] { -1, -1 }, result);
        }

        [TestMethod]
        public void SearchRange_EmptyArray_ReturnsMinusOnes()
        {
            // Arrange
            int[] nums = { };
            int target = 8;

            // Act
            int[] result = _solution.SearchRange(nums, target);

            // Assert
            CollectionAssert.AreEqual(new int[] { -1, -1 }, result);
        }

        [TestMethod]
        public void SearchRange_SingleElementArrayWithTarget_ReturnsCorrectRange()
        {
            // Arrange
            int[] nums = { 5 };
            int target = 5;

            // Act
            int[] result = _solution.SearchRange(nums, target);

            // Assert
            CollectionAssert.AreEqual(new int[] { 0, 0 }, result);
        }

        [TestMethod]
        public void SearchRange_SingleElementArrayWithoutTarget_ReturnsMinusOnes()
        {
            // Arrange
            int[] nums = { 5 };
            int target = 8;

            // Act
            int[] result = _solution.SearchRange(nums, target);

            // Assert
            CollectionAssert.AreEqual(new int[] { -1, -1 }, result);
        }

        [TestMethod]
        public void SearchRange_TargetAtBeginning_ReturnsCorrectRange()
        {
            // Arrange
            int[] nums = { 8, 8, 8, 10, 10 };
            int target = 8;

            // Act
            int[] result = _solution.SearchRange(nums, target);

            // Assert
            CollectionAssert.AreEqual(new int[] { 0, 2 }, result);
        }

        [TestMethod]
        public void SearchRange_TargetAtEnd_ReturnsCorrectRange()
        {
            // Arrange
            int[] nums = { 5, 7, 7, 8, 8, 8 };
            int target = 8;

            // Act
            int[] result = _solution.SearchRange(nums, target);

            // Assert
            CollectionAssert.AreEqual(new int[] { 3, 5 }, result);
        }

        [TestMethod]
        public void SearchRange_AllElementsAreTarget_ReturnsFullRange()
        {
            // Arrange
            int[] nums = { 8, 8, 8, 8, 8 };
            int target = 8;

            // Act
            int[] result = _solution.SearchRange(nums, target);

            // Assert
            CollectionAssert.AreEqual(new int[] { 0, 4 }, result);
        }

        [TestMethod]
        public void SearchRange_TargetLargerThanAllElements_ReturnsMinusOnes()
        {
            // Arrange
            int[] nums = { 1, 2, 3, 4, 5 };
            int target = 6;

            // Act
            int[] result = _solution.SearchRange(nums, target);

            // Assert
            CollectionAssert.AreEqual(new int[] { -1, -1 }, result);
        }

        [TestMethod]
        public void SearchRange_TargetSmallerThanAllElements_ReturnsMinusOnes()
        {
            // Arrange
            int[] nums = { 2, 3, 4, 5, 6 };
            int target = 1;

            // Act
            int[] result = _solution.SearchRange(nums, target);

            // Assert
            CollectionAssert.AreEqual(new int[] { -1, -1 }, result);
        }
    }
}