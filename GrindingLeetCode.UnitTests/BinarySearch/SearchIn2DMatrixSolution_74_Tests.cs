using LeetCodeProblems.BinarySearch;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GrindingLeetCode.UnitTests.BinarySearch
{
    [TestClass]
    public class SearchIn2DMatrixSolution_74_Tests
    {
        private SearchIn2DMatrixSolution_74 _solution;

        [TestInitialize]
        public void Initialize()
        {
            _solution = new SearchIn2DMatrixSolution_74();
        }

        [TestMethod]
        public void SearchMatrix_TargetExists_ReturnsTrue()
        {
            // Arrange
            int[][] matrix = new int[][]
            {
                new int[] { 1, 3, 5, 7 },
                new int[] { 10, 11, 16, 20 },
                new int[] { 23, 30, 34, 60 }
            };
            int target = 3;

            // Act
            bool result = _solution.SearchMatrix(matrix, target);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void SearchMatrix_TargetDoesNotExist_ReturnsFalse()
        {
            // Arrange
            int[][] matrix = new int[][]
            {
                new int[] { 1, 3, 5, 7 },
                new int[] { 10, 11, 16, 20 },
                new int[] { 23, 30, 34, 60 }
            };
            int target = 13;

            // Act
            bool result = _solution.SearchMatrix(matrix, target);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void SearchMatrix_TargetAtFirstElement_ReturnsTrue()
        {
            // Arrange
            int[][] matrix = new int[][]
            {
                new int[] { 1, 3, 5, 7 },
                new int[] { 10, 11, 16, 20 },
                new int[] { 23, 30, 34, 60 }
            };
            int target = 1;

            // Act
            bool result = _solution.SearchMatrix(matrix, target);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void SearchMatrix_TargetAtLastElement_ReturnsTrue()
        {
            // Arrange
            int[][] matrix = new int[][]
            {
                new int[] { 1, 3, 5, 7 },
                new int[] { 10, 11, 16, 20 },
                new int[] { 23, 30, 34, 60 }
            };
            int target = 60;

            // Act
            bool result = _solution.SearchMatrix(matrix, target);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void SearchMatrix_TargetAtRowBoundary_ReturnsTrue()
        {
            // Arrange
            int[][] matrix = new int[][]
            {
                new int[] { 1, 3, 5, 7 },
                new int[] { 10, 11, 16, 20 },
                new int[] { 23, 30, 34, 60 }
            };
            int target = 7;  // Last element of first row

            // Act
            bool result = _solution.SearchMatrix(matrix, target);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void SearchMatrix_TargetSmallerThanAllElements_ReturnsFalse()
        {
            // Arrange
            int[][] matrix = new int[][]
            {
                new int[] { 1, 3, 5, 7 },
                new int[] { 10, 11, 16, 20 },
                new int[] { 23, 30, 34, 60 }
            };
            int target = 0;

            // Act
            bool result = _solution.SearchMatrix(matrix, target);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void SearchMatrix_TargetLargerThanAllElements_ReturnsFalse()
        {
            // Arrange
            int[][] matrix = new int[][]
            {
                new int[] { 1, 3, 5, 7 },
                new int[] { 10, 11, 16, 20 },
                new int[] { 23, 30, 34, 60 }
            };
            int target = 61;

            // Act
            bool result = _solution.SearchMatrix(matrix, target);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void SearchMatrix_EmptyMatrix_ReturnsFalse()
        {
            // Arrange
            int[][] matrix = new int[][] { };
            int target = 1;

            // Act
            bool result = _solution.SearchMatrix(matrix, target);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void SearchMatrix_SingleElementMatrixWithTarget_ReturnsTrue()
        {
            // Arrange
            int[][] matrix = new int[][] { new int[] { 1 } };
            int target = 1;

            // Act
            bool result = _solution.SearchMatrix(matrix, target);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void SearchMatrix_SingleElementMatrixWithoutTarget_ReturnsFalse()
        {
            // Arrange
            int[][] matrix = new int[][] { new int[] { 1 } };
            int target = 2;

            // Act
            bool result = _solution.SearchMatrix(matrix, target);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void SearchMatrix_SingleElementMatrixWithTarget_ReturnsTrue2()
        {
            // Arrange
            int[][] matrix = new int[][]
{
                new int[] { 1, 3, 5, 7 },
                new int[] { 10, 11, 16, 20 },
                new int[] { 23, 30, 34, 50 }
};
            int target = 11;

            // Act
            bool result = _solution.SearchMatrix(matrix, target);

            // Assert
            Assert.IsTrue(result);
        }

    }
}