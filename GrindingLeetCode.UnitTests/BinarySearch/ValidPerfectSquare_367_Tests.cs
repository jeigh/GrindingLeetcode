using LeetCodeProblems.BinarySearch;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GrindingLeetCode.UnitTests.BinarySearch
{
    [TestClass]
    public class ValidPerfectSquare_367_Tests
    {
        private ValidPerfectSquare_367 _solution;

        [TestInitialize]
        public void Initialize()
        {
            _solution = new ValidPerfectSquare_367();
        }

        [TestMethod]
        public void IsPerfectSquare_InputIs1_ReturnsTrue()
        {
            // Arrange
            int num = 1;

            // Act
            bool result = _solution.IsPerfectSquare(num);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsPerfectSquare_InputIs4_ReturnsTrue()
        {
            // Arrange
            int num = 4;

            // Act
            bool result = _solution.IsPerfectSquare(num);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsPerfectSquare_InputIs9_ReturnsTrue()
        {
            // Arrange
            int num = 9;

            // Act
            bool result = _solution.IsPerfectSquare(num);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsPerfectSquare_InputIs16_ReturnsTrue()
        {
            // Arrange
            int num = 16;

            // Act
            bool result = _solution.IsPerfectSquare(num);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsPerfectSquare_InputIs3_ReturnsFalse()
        {
            // Arrange
            int num = 3;

            // Act
            bool result = _solution.IsPerfectSquare(num);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsPerfectSquare_InputIs14_ReturnsFalse()
        {
            // Arrange
            int num = 14;

            // Act
            bool result = _solution.IsPerfectSquare(num);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsPerfectSquare_InputIs2147395600_ReturnsTrue()
        {
            // Arrange - 46340² = 2147395600 (close to Int32.MaxValue)
            int num = 2147395600;

            // Act
            bool result = _solution.IsPerfectSquare(num);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsPerfectSquare_InputIs2147483647_ReturnsFalse()
        {
            // Arrange - Int32.MaxValue
            int num = 2147483647;

            // Act
            bool result = _solution.IsPerfectSquare(num);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsPerfectSquare_InputIs2147483646_ReturnsFalse()
        {
            // Arrange - Int32.MaxValue - 1
            int num = 2147483646;

            // Act
            bool result = _solution.IsPerfectSquare(num);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsPerfectSquare_InputIs100_ReturnsTrue()
        {
            // Arrange
            int num = 100;

            // Act
            bool result = _solution.IsPerfectSquare(num);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsPerfectSquare_InputIs99_ReturnsFalse()
        {
            // Arrange
            int num = 99;

            // Act
            bool result = _solution.IsPerfectSquare(num);

            // Assert
            Assert.IsFalse(result);
        }
    }
}