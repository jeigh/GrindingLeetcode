using LeetCodeProblems.BinarySearch;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GrindingLeetCode.UnitTests.BinarySearch
{
    [TestClass]
    public class FirstBadVersion_278_Tests
    {
        [TestMethod]
        public void FirstBadVersion_BadVersionIsFirst_ReturnsOne()
        {
            // Arrange
            var solution = new FirstBadVersion_278(1);
            int n = 10;

            // Act
            int result = solution.FirstBadVersion(n);

            // Assert
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void FirstBadVersion_BadVersionIsLast_ReturnsN()
        {
            // Arrange
            int n = 10;
            var solution = new FirstBadVersion_278(n);

            // Act
            int result = solution.FirstBadVersion(n);

            // Assert
            Assert.AreEqual(n, result);
        }

        [TestMethod]
        public void FirstBadVersion_BadVersionInMiddle_ReturnsCorrectVersion()
        {
            // Arrange
            int firstBad = 4;
            var solution = new FirstBadVersion_278(firstBad);
            int n = 10;

            // Act
            int result = solution.FirstBadVersion(n);

            // Assert
            Assert.AreEqual(firstBad, result);
        }

        [TestMethod]
        public void FirstBadVersion_OnlyOneVersion_ReturnsOne()
        {
            // Arrange
            var solution = new FirstBadVersion_278(1);
            int n = 1;

            // Act
            int result = solution.FirstBadVersion(n);

            // Assert
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void FirstBadVersion_LargeInput_HandlesCorrectly()
        {
            // Arrange
            int n = 2147483647; // Max int value
            int firstBad = 1702766719; // Large number within range
            var solution = new FirstBadVersion_278(firstBad);

            // Act
            int result = solution.FirstBadVersion(n);

            // Assert
            Assert.AreEqual(firstBad, result);
        }

        [TestMethod]
        public void FirstBadVersion_TwoVersions_FirstIsBad_ReturnsOne()
        {
            // Arrange
            var solution = new FirstBadVersion_278(1);
            int n = 2;

            // Act
            int result = solution.FirstBadVersion(n);

            // Assert
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void FirstBadVersion_TwoVersions_SecondIsBad_ReturnsTwo()
        {
            // Arrange
            var solution = new FirstBadVersion_278(2);
            int n = 2;

            // Act
            int result = solution.FirstBadVersion(n);

            // Assert
            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void FirstBadVersion_ConsecutiveVersions_FindsFirstBad()
        {
            // Arrange
            int firstBad = 1000;
            var solution = new FirstBadVersion_278(firstBad);
            int n = 2000;

            // Act
            int result = solution.FirstBadVersion(n);

            // Assert
            Assert.AreEqual(firstBad, result);
        }
    }
}