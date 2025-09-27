using LeetCodeProblems.BinarySearch;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GrindingLeetCode.UnitTests
{
    [TestClass]
    public class SearchInRotatedSortedArrayTests
    {
        private SearchInRotatedSortedArraySolution_33 _solution;

        [TestInitialize]
        public void Initialize()
        {
            _solution = new SearchInRotatedSortedArraySolution_33();
        }

        [TestMethod]
        public void Search_NonRotatedArray_FindsElement()
        {
            // Arrange
            int[] nums = { 1, 2, 3, 4, 5, 6, 7 };
            int target = 4;

            // Act
            int result = _solution.Search(nums, target);

            // Assert
            Assert.AreEqual(3, result);
        }

        [TestMethod]
        public void Search_RotatedArray_FindsElementInLeftHalf()
        {
            // Arrange
            int[] nums = { 4, 5, 6, 7, 0, 1, 2 };
            int target = 5;

            // Act
            int result = _solution.Search(nums, target);

            // Assert
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void Search_RotatedArray_FindsElementInRightHalf()
        {
            // Arrange
            int[] nums = { 4, 5, 6, 7, 0, 1, 2 };
            int target = 0;

            // Act
            int result = _solution.Search(nums, target);

            // Assert
            Assert.AreEqual(4, result);
        }

        [TestMethod]
        public void Search_RotatedArray_ElementNotFound()
        {
            // Arrange
            int[] nums = { 4, 5, 6, 7, 0, 1, 2 };
            int target = 3;

            // Act
            int result = _solution.Search(nums, target);

            // Assert
            Assert.AreEqual(-1, result);
        }

        [TestMethod]
        public void Search_SingleElementArray_ElementFound()
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
        public void Search_SingleElementArray_ElementNotFound()
        {
            // Arrange
            int[] nums = { 5 };
            int target = 7;

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
        public void Search_FullyRotatedArray_FindsElement()
        {
            // Arrange - this is essentially a non-rotated array
            int[] nums = { 1, 2, 3, 4, 5, 6, 7 };
            int target = 6;

            // Act
            int result = _solution.Search(nums, target);

            // Assert
            Assert.AreEqual(5, result);
        }
    }
}