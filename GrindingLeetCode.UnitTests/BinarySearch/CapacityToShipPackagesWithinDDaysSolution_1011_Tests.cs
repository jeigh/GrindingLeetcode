using LeetCodeProblems.BinarySearch;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GrindingLeetCode.UnitTests.BinarySearch
{
    [TestClass]
    public class CapacityToShipPackagesWithinDDaysSolution_1011_Tests
    {
        private CapacityToShipPackagesWithinDDaysSoluition_1011 _solution;

        [TestInitialize]
        public void Initialize()
        {
            _solution = new CapacityToShipPackagesWithinDDaysSoluition_1011();
        }


        [TestMethod]
        public void ShipWithinDays_Example_ReturnsNine()
        {
            // Arrange
            int[] weights = { 3,3,3,3,3,3 };
            int days = 2;

            // Act
            int result = _solution.ShipWithinDays(weights, days);

            // Assert
            Assert.AreEqual(9, result);
        }

        [TestMethod]
        public void ShipWithinDays_Example1_ReturnsFifteen()
        {
            // Arrange
            int[] weights = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int days = 5;

            // Act
            int result = _solution.ShipWithinDays(weights, days);

            // Assert
            Assert.AreEqual(15, result);
        }

        [TestMethod]
        public void ShipWithinDays_Example2_ReturnsSix()
        {
            // Arrange
            int[] weights = { 3, 2, 2, 4, 1, 4 };
            int days = 3;

            // Act
            int result = _solution.ShipWithinDays(weights, days);

            // Assert
            Assert.AreEqual(6, result);
        }

        [TestMethod]
        public void ShipWithinDays_Example3_ReturnsThree()
        {
            // Arrange
            int[] weights = { 1, 2, 3, 1, 1 };
            int days = 4;

            // Act
            int result = _solution.ShipWithinDays(weights, days);

            // Assert
            Assert.AreEqual(3, result);
        }

        [TestMethod]
        public void ShipWithinDays_OneDay_ReturnsSumOfAllWeights()
        {
            // Arrange
            int[] weights = { 1, 2, 3, 4, 5 };
            int days = 1;

            // Act
            int result = _solution.ShipWithinDays(weights, days);

            // Assert
            Assert.AreEqual(15, result); // Sum of all weights
        }

        [TestMethod]
        public void ShipWithinDays_DaysEqualToPackages_ReturnsMaxWeight()
        {
            // Arrange
            int[] weights = { 5, 3, 7, 2, 9 };
            int days = 5; // Same as number of packages

            // Act
            int result = _solution.ShipWithinDays(weights, days);

            // Assert
            Assert.AreEqual(9, result); // Max weight
        }

        [TestMethod]
        public void ShipWithinDays_SinglePackage_ReturnsThatWeight()
        {
            // Arrange
            int[] weights = { 10 };
            int days = 1;

            // Act
            int result = _solution.ShipWithinDays(weights, days);

            // Assert
            Assert.AreEqual(10, result);
        }

        [TestMethod]
        public void ShipWithinDays_IdenticalWeights_ReturnsExpectedCapacity()
        {
            // Arrange
            int[] weights = { 5, 5, 5, 5, 5 };
            int days = 2;

            // Act
            int result = _solution.ShipWithinDays(weights, days);

            // Assert
            Assert.AreEqual(15, result); // First day: 3 packages, Second day: 2 packages
        }

        [TestMethod]
        public void ShipWithinDays_LargeWeightDifferences_ReturnsMinimumCapacity()
        {
            // Arrange
            int[] weights = { 1, 1, 1, 10, 1 };
            int days = 2;

            // Act
            int result = _solution.ShipWithinDays(weights, days);

            // Assert
            Assert.AreEqual(11, result); 
        }

        [TestMethod]
        public void ShipWithinDays_MoreDaysThanNeeded_ReturnsMaxWeight()
        {
            // Arrange
            int[] weights = { 3, 5, 2, 4 };
            int days = 10; // More days than needed

            // Act
            int result = _solution.ShipWithinDays(weights, days);

            // Assert
            Assert.AreEqual(5, result); // Max weight
        }
    }
}