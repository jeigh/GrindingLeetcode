using LeetCodeProblems.BinarySearch;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GrindingLeetCode.UnitTests.BinarySearch
{
    [TestClass]
    public class SqrtSolution_69_Tests
    {
        private SqrtSolution_69 _solution;

        [TestInitialize]
        public void Initialize()
        {
            _solution = new SqrtSolution_69();
        }

        [TestMethod]
        public void MySqrt_InputIsZero_ReturnsZero()
        {
            // Arrange
            int x = 0;

            // Act
            int result = _solution.MySqrt(x);

            // Assert
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void MySqrt_InputIsOne_ReturnsOne()
        {
            // Arrange
            int x = 1;

            // Act
            int result = _solution.MySqrt(x);

            // Assert
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void MySqrt_InputIsPerfectSquare_ReturnsExactSquareRoot()
        {
            // Arrange
            int x = 16;

            // Act
            int result = _solution.MySqrt(x);

            // Assert
            Assert.AreEqual(4, result);
        }

        [TestMethod]
        public void MySqrt_InputIsNotPerfectSquare_ReturnsFloorOfSquareRoot()
        {
            // Arrange
            int x = 8;

            // Act
            int result = _solution.MySqrt(x);

            // Assert
            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void MySqrt_InputIs2_ReturnsOne()
        {
            // Arrange
            int x = 2;

            // Act
            int result = _solution.MySqrt(x);

            // Assert
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void MySqrt_InputIs3_ReturnsOne()
        {
            // Arrange
            int x = 3;

            // Act
            int result = _solution.MySqrt(x);

            // Assert
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void MySqrt_InputIs4_ReturnsTwo()
        {
            // Arrange
            int x = 4;

            // Act
            int result = _solution.MySqrt(x);

            // Assert
            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void MySqrt_InputIs9_ReturnsThree()
        {
            // Arrange
            int x = 9;

            // Act
            int result = _solution.MySqrt(x);

            // Assert
            Assert.AreEqual(3, result);
        }

        [TestMethod]
        public void MySqrt_InputIsMaxInteger_ReturnsCorrectResult()
        {
            // Arrange
            int x = int.MaxValue; // 2147483647

            // Act
            int result = _solution.MySqrt(x);

            // Assert
            Assert.AreEqual(46340, result); // sqrt(2147483647) ≈ 46340.95, floor is 46340
        }

        [TestMethod]
        public void MySqrt_InputIsLargeNumber_HandlesPrecisionCorrectly()
        {
            // Arrange
            int x = 2147395600; // 46340²

            // Act
            int result = _solution.MySqrt(x);

            // Assert
            Assert.AreEqual(46340, result);
        }

        [TestMethod]
        public void MySqrt_InputIsOneMoreThanPerfectSquare_ReturnsCorrectResult()
        {
            // Arrange
            int x = 26; // 5² + 1

            // Act
            int result = _solution.MySqrt(x);

            // Assert
            Assert.AreEqual(5, result);
        }

        [TestMethod]
        public void MySqrt_InputIsOneLessThanPerfectSquare_ReturnsCorrectResult()
        {
            // Arrange
            int x = 24; // 5² - 1

            // Act
            int result = _solution.MySqrt(x);

            // Assert
            Assert.AreEqual(4, result);
        }
    }
}