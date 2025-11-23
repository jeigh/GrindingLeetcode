using LeetCodeProblems.BinarySearch;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GrindingLeetCode.UnitTests.Hard
{
    [TestClass]
    public class SplitArrayLargestSumSolution_410_Tests
    {
        private SplitArrayLargestSumSolution_410 _solution;

        [TestInitialize]
        public void Initialize()
        {
            _solution = new SplitArrayLargestSumSolution_410();
        }

        [TestMethod]
        public void SplitArray_Example1_Returns18()
        {
            // Arrange
            int[] nums = { 7, 2, 5, 10, 8 };
            int k = 2;

            // Act
            int result = _solution.SplitArray(nums, k);

            // Assert
            Assert.AreEqual(18, result);
        }

        [TestMethod]
        public void SplitArray_Example2_Returns9()
        {
            // Arrange
            int[] nums = { 1, 2, 3, 4, 5 };
            int k = 2;

            // Act
            int result = _solution.SplitArray(nums, k);

            // Assert
            Assert.AreEqual(9, result);
        }

        [TestMethod]
        public void SplitArray_SingleSubarray_ReturnsSumOfArray()
        {
            // Arrange
            int[] nums = { 1, 2, 3, 4, 5 };
            int k = 1;

            // Act
            int result = _solution.SplitArray(nums, k);

            // Assert
            Assert.AreEqual(15, result); // Sum of all elements
        }

        [TestMethod]
        public void SplitArray_SubarraysOfLengthOne_ReturnsMaxElement()
        {
            // Arrange
            int[] nums = { 1, 2, 3, 4, 5 };
            int k = 5; // Each subarray has one element

            // Act
            int result = _solution.SplitArray(nums, k);

            // Assert
            Assert.AreEqual(5, result); // Max element
        }

        [TestMethod]
        public void SplitArray_IdenticalValues_ReturnsCeilingOfTotalDividedByK()
        {
            // Arrange
            int[] nums = { 5, 5, 5, 5, 5 };
            int k = 3;

            // Act
            int result = _solution.SplitArray(nums, k);

            // Assert
            Assert.AreEqual(10, result); // Ceiling of (5*5)/3
        }

        [TestMethod]
        public void SplitArray_UnevenSplit_MinimizesMaxSum()
        {
            // Arrange
            int[] nums = { 1, 4, 4, 2, 8 };
            int k = 3;

            // Act
            int result = _solution.SplitArray(nums, k);

            // Assert
            Assert.AreEqual(8, result); // Optimal split: [1,4], [4,2], [8]
        }

        [TestMethod]
        public void SplitArray_LargeValues_HandlesCorrectly()
        {
            // Arrange
            int[] nums = { 1000000, 1000000 };
            int k = 2;

            // Act
            int result = _solution.SplitArray(nums, k);

            // Assert
            Assert.AreEqual(1000000, result); // Each subarray has one element of 1000000
        }

        [TestMethod]
        public void SplitArray_SingleElement_ReturnsThatElement()
        {
            // Arrange
            int[] nums = { 42 };
            int k = 1;

            // Act
            int result = _solution.SplitArray(nums, k);

            // Assert
            Assert.AreEqual(42, result);
        }

        [TestMethod]
        public void SplitArray_KIsGreaterThanArrayLength_ReturnsMaxElement()
        {
            // Arrange
            int[] nums = { 7, 2, 5 };
            int k = 10; // More subarrays than elements

            // Act
            int result = _solution.SplitArray(nums, k);

            // Assert
            Assert.AreEqual(-1, result); 
        }

        [TestMethod]
        public void SplitArray_ComplexExample_FindsMinimumLargestSum()
        {
            // Arrange
            int[] nums = { 10, 5, 13, 4, 8, 4, 5, 11, 14, 9, 16, 10, 20 };
            int k = 4;

            // Act
            int result = _solution.SplitArray(nums, k);

            // Assert
            Assert.AreEqual(39, result);
        }
    }
}