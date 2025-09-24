using LeetCodeProblems.BinarySearch;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GrindingLeetCode.UnitTests
{
    [TestClass]
    public class SearchInsertPosition_35_Tests
    {
        private SearchInsertPosition_35 _solution;

        [TestInitialize]
        public void Initialize()
        {
            _solution = new SearchInsertPosition_35();
        }

        [TestMethod]
        public void SearchInsert_TargetFoundAtBeginning_ReturnsCorrectIndex()
        {
            // Arrange
            int[] nums = { 1, 3, 5, 6 };
            int target = 1;

            // Act
            int result = _solution.SearchInsert(nums, target);

            // Assert
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void SearchInsert_TargetFoundInMiddle_ReturnsCorrectIndex()
        {
            // Arrange
            int[] nums = { 1, 3, 5, 6 };
            int target = 5;

            // Act
            int result = _solution.SearchInsert(nums, target);

            // Assert
            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void SearchInsert_TargetFoundAtEnd_ReturnsCorrectIndex()
        {
            // Arrange
            int[] nums = { 1, 3, 5, 6 };
            int target = 6;

            // Act
            int result = _solution.SearchInsert(nums, target);

            // Assert
            Assert.AreEqual(3, result);
        }

        [TestMethod]
        public void SearchInsert_TargetNotFound_ReturnsInsertPosition()
        {
            // Arrange
            int[] nums = { 1, 3, 5, 6 };
            int target = 2;

            // Act
            int result = _solution.SearchInsert(nums, target);

            // Assert
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void SearchInsert_TargetNotFoundBetweenElements_ReturnsInsertPosition()
        {
            // Arrange
            int[] nums = { 1, 3, 5, 6 };
            int target = 4;

            // Act
            int result = _solution.SearchInsert(nums, target);

            // Assert
            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void SearchInsert_TargetSmallerThanAllElements_ReturnsZero()
        {
            // Arrange
            int[] nums = { 1, 3, 5, 6 };
            int target = 0;

            // Act
            int result = _solution.SearchInsert(nums, target);

            // Assert
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void SearchInsert_TargetLargerThanAllElements_ReturnsLength()
        {
            // Arrange
            int[] nums = { 1, 3, 5, 6 };
            int target = 7;

            // Act
            int result = _solution.SearchInsert(nums, target);

            // Assert
            Assert.AreEqual(4, result);
        }

        [TestMethod]
        public void SearchInsert_EmptyArray_ReturnsZero()
        {
            // Arrange
            int[] nums = { };
            int target = 5;

            // Act
            int result = _solution.SearchInsert(nums, target);

            // Assert
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void SearchInsert_SingleElementArrayTargetFound_ReturnsZero()
        {
            // Arrange
            int[] nums = { 5 };
            int target = 5;

            // Act
            int result = _solution.SearchInsert(nums, target);

            // Assert
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void SearchInsert_SingleElementArrayTargetSmaller_ReturnsZero()
        {
            // Arrange
            int[] nums = { 5 };
            int target = 3;

            // Act
            int result = _solution.SearchInsert(nums, target);

            // Assert
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void SearchInsert_SingleElementArrayTargetLarger_ReturnsOne()
        {
            // Arrange
            int[] nums = { 5 };
            int target = 7;

            // Act
            int result = _solution.SearchInsert(nums, target);

            // Assert
            Assert.AreEqual(1, result);
        }
    }
}