using LeetCodeProblems.Hashing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GrindingLeetCode.UnitTests
{
    [TestClass]
    public class ConcatenationOfArraySolution_1929_Tests
    {
        private ConcatenationOfArraySolution_1929 _solution;

        [TestInitialize]
        public void Initialize()
        {
            _solution = new ConcatenationOfArraySolution_1929();
        }

        [TestMethod]
        public void GetConcatenation_Example_ReturnsConcatenatedArray()
        {
            // Arrange
            int[] nums = { 1, 2, 1 };

            // Act
            int[] result = _solution.GetConcatenation(nums);

            // Assert
            CollectionAssert.AreEqual(new[] { 1, 2, 1, 1, 2, 1 }, result);
        }

        [TestMethod]
        public void GetConcatenation_EmptyArray_ReturnsEmptyArray()
        {
            // Arrange
            int[] nums = { };

            // Act
            int[] result = _solution.GetConcatenation(nums);

            // Assert
            CollectionAssert.AreEqual(new int[0], result);
        }

        [TestMethod]
        public void GetConcatenation_SingleElementArray_ReturnsDoubleElementArray()
        {
            // Arrange
            int[] nums = { 42 };

            // Act
            int[] result = _solution.GetConcatenation(nums);

            // Assert
            CollectionAssert.AreEqual(new[] { 42, 42 }, result);
        }

        [TestMethod]
        public void GetConcatenation_MultipleElements_ReturnsCorrectConcatenation()
        {
            // Arrange
            int[] nums = { 5, 6, 7, 8 };

            // Act
            int[] result = _solution.GetConcatenation(nums);

            // Assert
            CollectionAssert.AreEqual(new[] { 5, 6, 7, 8, 5, 6, 7, 8 }, result);
        }

        [TestMethod]
        public void GetConcatenation_NegativeAndZeroElements_ReturnsCorrectConcatenation()
        {
            // Arrange
            int[] nums = { -1, 0, 1 };

            // Act
            int[] result = _solution.GetConcatenation(nums);

            // Assert
            CollectionAssert.AreEqual(new[] { -1, 0, 1, -1, 0, 1 }, result);
        }
    }
}