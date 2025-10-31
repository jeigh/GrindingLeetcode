using LeetCodeProblems.BinarySearch;

namespace GrindingLeetCode.UnitTests.BinarySearch
{
    [TestClass]
    public class KokoEatingBananasSolution_875_Tests
    {
        private KokoEatingBananasSolution_875 _solution;

        [TestInitialize]
        public void Initialize()
        {
            _solution = new KokoEatingBananasSolution_875();
        }

        [TestMethod]
        public void MinEatingSpeed_Example1_ReturnsFour()
        {
            // Arrange
            int[] piles = { 3, 6, 7, 11 };
            int h = 8;

            // Act
            int resultBinarySearch = _solution.MinEatingSpeedUsingBinarySearch(piles, h);
            int resultBruteForce = _solution.MinEatingSpeedBruteForce(piles, h);

            // Assert
            Assert.AreEqual(4, resultBinarySearch);
            Assert.AreEqual(4, resultBruteForce);
        }

        [TestMethod]
        public void MinEatingSpeed_Example2_ReturnsThirty()
        {
            // Arrange
            int[] piles = { 30, 11, 23, 4, 20 };
            int h = 5;

            // Act
            int resultBinarySearch = _solution.MinEatingSpeedUsingBinarySearch(piles, h);
            int resultBruteForce = _solution.MinEatingSpeedBruteForce(piles, h);

            // Assert
            Assert.AreEqual(30, resultBinarySearch);
            Assert.AreEqual(30, resultBruteForce);
        }

        [TestMethod]
        public void MinEatingSpeed_Example3_ReturnsFour()
        {
            // Arrange
            int[] piles = { 30, 11, 23, 4, 20 };
            int h = 6;

            // Act
            int resultBinarySearch = _solution.MinEatingSpeedUsingBinarySearch(piles, h);
            int resultBruteForce = _solution.MinEatingSpeedBruteForce(piles, h);

            // Assert
            Assert.AreEqual(23, resultBinarySearch);
            Assert.AreEqual(23, resultBruteForce);
        }

        [TestMethod]
        public void MinEatingSpeed_SinglePile_ReturnsMinimumSpeed()
        {
            // Arrange
            int[] piles = { 10 };
            int h = 4;

            // Act
            int resultBinarySearch = _solution.MinEatingSpeedUsingBinarySearch(piles, h);
            int resultBruteForce = _solution.MinEatingSpeedBruteForce(piles, h);

            // Assert
            Assert.AreEqual(3, resultBinarySearch);
            Assert.AreEqual(3, resultBruteForce);
        }

        [TestMethod]
        public void MinEatingSpeed_HEqualsNumberOfPiles_ReturnsMaximumPile()
        {
            // Arrange
            int[] piles = { 3, 6, 7, 11 };
            int h = 4;

            // Act
            int resultBinarySearch = _solution.MinEatingSpeedUsingBinarySearch(piles, h);
            int resultBruteForce = _solution.MinEatingSpeedBruteForce(piles, h);

            // Assert
            Assert.AreEqual(11, resultBinarySearch);
            Assert.AreEqual(11, resultBruteForce);
        }

        [TestMethod]
        public void MinEatingSpeed_LargePile_FindsCorrectSpeed()
        {
            // Arrange
            int[] piles = { 805306368, 805306368, 805306368 };
            int h = 1000000000;

            // Act
            int resultBinarySearch = _solution.MinEatingSpeedUsingBinarySearch(piles, h);
            // Skip brute force due to time complexity

            // Assert
            Assert.AreEqual(3, resultBinarySearch);
        }

        [TestMethod]
        public void MinEatingSpeed_AllIdenticalPiles_FindsCorrectSpeed()
        {
            // Arrange
            int[] piles = { 5, 5, 5, 5, 5 };
            int h = 8;

            // Act
            int resultBinarySearch = _solution.MinEatingSpeedUsingBinarySearch(piles, h);
            int resultBruteForce = _solution.MinEatingSpeedBruteForce(piles, h);

            // Assert
            Assert.AreEqual(5, resultBinarySearch);
            Assert.AreEqual(5, resultBruteForce);
        }

        [TestMethod]
        public void MinEatingSpeed_UnevenDistribution_FindsCorrectSpeed()
        {
            // Arrange
            int[] piles = { 1, 1, 1, 999999999 };
            int h = 10;

            // Act
            int resultBinarySearch = _solution.MinEatingSpeedUsingBinarySearch(piles, h);
            // Skip brute force due to time complexity

            // Assert
            Assert.AreEqual(142857143, resultBinarySearch);
        }
    }
}