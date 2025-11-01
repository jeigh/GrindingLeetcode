using LeetCodeProblems.BinarySearch;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GrindingLeetCode.UnitTests.BinarySearch
{
    [TestClass]
    public class SearchInRotatedSortedArrayIISolution_81_Tests
    {
        private SearchInRotatedSortedArrrayIISolution_81 _solution;

        [TestInitialize]
        public void Initialize()
        {
            _solution = new SearchInRotatedSortedArrrayIISolution_81();
        }

        [TestMethod]
        public void Search_10111_FindsElement()
        {
            // Arrange
            int[] nums = { 1, 0, 1, 1, 1 };
            int target = 0;

            // Act
            bool result = _solution.Search(nums, target);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Search_NonRotatedArray_FindsElement()
        {
            // Arrange
            int[] nums = { 1, 2, 3, 4, 5, 6, 7 };
            int target = 4;

            // Act
            bool result = _solution.Search(nums, target);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Search_RotatedArray_FindsElementInLeftHalf()
        {
            // Arrange
            int[] nums = { 4, 5, 6, 7, 0, 1, 2 };
            int target = 5;

            // Act
            bool result = _solution.Search(nums, target);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Search_RotatedArray_FindsElementInRightHalf()
        {
            // Arrange
            int[] nums = { 4, 5, 6, 7, 0, 1, 2 };
            int target = 0;

            // Act
            bool result = _solution.Search(nums, target);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Search_RotatedArray_ElementNotFound()
        {
            // Arrange
            int[] nums = { 4, 5, 6, 7, 0, 1, 2 };
            int target = 3;

            // Act
            bool result = _solution.Search(nums, target);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Search_SingleElementArray_ElementFound()
        {
            // Arrange
            int[] nums = { 5 };
            int target = 5;

            // Act
            bool result = _solution.Search(nums, target);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Search_SingleElementArray_ElementNotFound()
        {
            // Arrange
            int[] nums = { 5 };
            int target = 7;

            // Act
            bool result = _solution.Search(nums, target);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Search_EmptyArray_ReturnsFalse()
        {
            // Arrange
            int[] nums = { };
            int target = 5;

            // Act
            bool result = _solution.Search(nums, target);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Search_ArrayWithDuplicates_FindsElement()
        {
            // Arrange
            int[] nums = { 2, 5, 6, 0, 0, 1, 2 };
            int target = 0;

            // Act
            bool result = _solution.Search(nums, target);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Search_ArrayWithDuplicates_ElementNotFound()
        {
            // Arrange
            int[] nums = { 2, 5, 6, 0, 0, 1, 2 };
            int target = 3;

            // Act
            bool result = _solution.Search(nums, target);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Search_111111211111_FindsElement()
        {
            // Arrange
            int[] nums = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 1, 1, 1, 1, 1 };
            int target = 2;

            // Act
            bool result = _solution.Search(nums, target);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Search_twentyfiveInMiddle_FindsElement()
        {
            // Arrange
            int[] nums = { 15, 16, 19, 20, 25, 1, 3, 4, 5, 7, 10, 14 };
            int target = 25;

            // Act
            bool result = _solution.Search(nums, target);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Search_ArrayWithManyLeadingDuplicates_FindsElement()
        {
            // Arrange
            int[] nums = { 1, 1, 1, 1, 1, 1, 2, 3 };
            int target = 2;

            // Act
            bool result = _solution.Search(nums, target);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Search_ArrayWithDuplicatesAtRotationPoint_FindsElement()
        {
            // Arrange
            int[] nums = { 3, 1, 1, 1, 1, 3 };
            int target = 3;

            // Act
            bool result = _solution.Search(nums, target);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Search_ArrayWithDuplicatesOnBothEnds_FindsElement()
        {
            // Arrange
            int[] nums = { 2, 2, 3, 0, 1, 2, 2 };
            int target = 0;

            // Act
            bool result = _solution.Search(nums, target);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Search_ArrayAllSameValues_TargetMatches()
        {
            // Arrange
            int[] nums = { 5, 5, 5, 5, 5, 5 };
            int target = 5;

            // Act
            bool result = _solution.Search(nums, target);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Search_ArrayAllSameValues_TargetDoesNotMatch()
        {
            // Arrange
            int[] nums = { 5, 5, 5, 5, 5, 5 };
            int target = 6;

            // Act
            bool result = _solution.Search(nums, target);

            // Assert
            Assert.IsFalse(result);
        }
    }
}