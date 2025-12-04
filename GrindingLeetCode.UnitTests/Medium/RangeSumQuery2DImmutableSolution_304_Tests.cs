using LeetCodeProblems.HashingOrArrays;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GrindingLeetCode.UnitTests.Medium
{
    [TestClass]
    public class RangeSumQuery2DImmutableSolution_304_Tests
    {
        [TestMethod]
        public void NumMatrix_Example1_SumRegion_ReturnsCorrectValues()
        {
            int[][] matrix = new int[][]
            {
                new int[] {3, 0, 1, 4, 2},
                new int[] {5, 6, 3, 2, 1},
                new int[] {1, 2, 0, 1, 5},
                new int[] {4, 1, 0, 1, 7},
                new int[] {1, 0, 3, 0, 5}
            };
            var numMatrix = new RangeSumQuery2DImmutable_PrecomputedSolution_304.NumMatrix(matrix);

            Assert.AreEqual(8, numMatrix.SumRegion(2, 1, 4, 3));
            Assert.AreEqual(11, numMatrix.SumRegion(1, 1, 2, 2));
            Assert.AreEqual(12, numMatrix.SumRegion(1, 2, 2, 4));
        }

        [TestMethod]
        public void NumMatrix_SingleElementMatrix_ReturnsElement()
        {
            int[][] matrix =
            [
                [42]
            ];
            var numMatrix = new RangeSumQuery2DImmutable_PrecomputedSolution_304.NumMatrix(matrix);

            Assert.AreEqual(42, numMatrix.SumRegion(0, 0, 0, 0));
        }

        [TestMethod]
        public void NumMatrix_EntireMatrix_ReturnsSum()
        {
            int[][] matrix = new int[][]
            {
                new int[] {1, 2},
                new int[] {3, 4}
            };
            var numMatrix = new RangeSumQuery2DImmutable_PrecomputedSolution_304.NumMatrix(matrix);

            Assert.AreEqual(10, numMatrix.SumRegion(0, 0, 1, 1));
        }

        [TestMethod]
        public void NumMatrix_SingleRow_ReturnsRowSum()
        {
            int[][] matrix =
            [
                [1, 2, 3, 4, 5]
            ];
            var numMatrix = new RangeSumQuery2DImmutable_PrecomputedSolution_304.NumMatrix(matrix);

            Assert.AreEqual(15, numMatrix.SumRegion(0, 0, 0, 4));
            Assert.AreEqual(12, numMatrix.SumRegion(0, 2, 0, 4));
        }

        [TestMethod]
        public void NumMatrix_SingleColumn_ReturnsColumnSum()
        {
            int[][] matrix = new int[][]
            {
                new int[] {1},
                new int[] {2},
                new int[] {3}
            };
            var numMatrix = new RangeSumQuery2DImmutable_PrecomputedSolution_304.NumMatrix(matrix);

            Assert.AreEqual(6, numMatrix.SumRegion(0, 0, 2, 0));
            Assert.AreEqual(2, numMatrix.SumRegion(1, 0, 1, 0));
        }
    }
}