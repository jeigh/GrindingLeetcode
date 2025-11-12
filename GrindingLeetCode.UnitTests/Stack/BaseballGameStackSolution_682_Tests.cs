using LeetCodeProblems.CSharp.Stack;
using LeetCodeProblems.Interfaces.Easy;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GrindingLeetCode.UnitTests.Stack
{
    [TestClass]
    public class BaseballGameStackSolution_682_Tests
    {
        public static IEnumerable<object[]> GetImplementations()
        {
            yield return new object[] { new BaseballGameStackSolution_682() };
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CalPoints_Example1_Returns30(IBaseballGame_682 solution)
        {
            // Arrange
            string[] operations = { "5", "2", "C", "D", "+" };

            // Act
            int result = solution.CalPoints(operations);

            // Assert - Record: [5, 2] -> [5] -> [5, 10] -> [5, 10, 15] = 30
            Assert.AreEqual(30, result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CalPoints_Example2_Returns27(IBaseballGame_682 solution)
        {
            // Arrange
            string[] operations = { "5", "-2", "4", "C", "D", "9", "+", "+" };

            // Act
            int result = solution.CalPoints(operations);
            
            Assert.AreEqual(27, result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CalPoints_Example3_Returns0(IBaseballGame_682 solution)
        {
            // Arrange
            string[] operations = { "1", "C" };

            // Act
            int result = solution.CalPoints(operations);

            // Assert - Record: [1] -> [] = 0
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CalPoints_SingleNumber_ReturnsNumber(IBaseballGame_682 solution)
        {
            // Arrange
            string[] operations = { "10" };

            // Act
            int result = solution.CalPoints(operations);

            // Assert
            Assert.AreEqual(10, result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CalPoints_OnlyDoubleOperation_WorksCorrectly(IBaseballGame_682 solution)
        {
            // Arrange
            string[] operations = { "5", "D" };

            // Act
            int result = solution.CalPoints(operations);

            // Assert - Record: [5, 10], sum = 15
            Assert.AreEqual(15, result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CalPoints_OnlyPlusOperation_WorksCorrectly(IBaseballGame_682 solution)
        {
            // Arrange
            string[] operations = { "3", "7", "+" };

            // Act
            int result = solution.CalPoints(operations);

            // Assert - Record: [3, 7, 10], sum = 20
            Assert.AreEqual(20, result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CalPoints_MultipleCancelOperations_WorksCorrectly(IBaseballGame_682 solution)
        {
            // Arrange
            string[] operations = { "1", "2", "C", "3", "C", "4" };

            // Act
            int result = solution.CalPoints(operations);

            // Assert - Record: [1, 2] -> [1] -> [1, 3] -> [1] -> [1, 4] = 5
            Assert.AreEqual(5, result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CalPoints_NegativeNumbers_WorksCorrectly(IBaseballGame_682 solution)
        {
            // Arrange
            string[] operations = { "-5", "10", "+" };

            // Act
            int result = solution.CalPoints(operations);

            // Assert - Record: [-5, 10, 5], sum = 10
            Assert.AreEqual(10, result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CalPoints_DoubleThenCancel_WorksCorrectly(IBaseballGame_682 solution)
        {
            // Arrange
            string[] operations = { "10", "D", "C" };

            // Act
            int result = solution.CalPoints(operations);

            // Assert - Record: [10, 20] -> [10] = 10
            Assert.AreEqual(10, result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CalPoints_PlusThenCancel_WorksCorrectly(IBaseballGame_682 solution)
        {
            // Arrange
            string[] operations = { "5", "3", "+", "C" };

            // Act
            int result = solution.CalPoints(operations);

            // Assert - Record: [5, 3, 8] -> [5, 3] = 8
            Assert.AreEqual(8, result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CalPoints_ZeroValues_WorksCorrectly(IBaseballGame_682 solution)
        {
            // Arrange
            string[] operations = { "0", "5", "D", "+" };

            // Act
            int result = solution.CalPoints(operations);

            // Assert - Record: [0, 5, 10, 15], sum = 30
            Assert.AreEqual(30, result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CalPoints_LargeNumbers_WorksCorrectly(IBaseballGame_682 solution)
        {
            // Arrange
            string[] operations = { "1000", "2000", "+" };

            // Act
            int result = solution.CalPoints(operations);

            // Assert - Record: [1000, 2000, 3000], sum = 6000
            Assert.AreEqual(6000, result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CalPoints_ComplexSequence_WorksCorrectly(IBaseballGame_682 solution)
        {
            // Arrange
            string[] operations = { "10", "20", "D", "C", "+", "5" };

            // Act
            int result = solution.CalPoints(operations);

            // Assert
            // Record: [10] -> [10, 20] -> [10, 20, 40] -> [10, 20] -> [10, 20, 30] -> [10, 20, 30, 5]
            // Sum = 10 + 20 + 30 + 5 = 65
            Assert.AreEqual(65, result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CalPoints_AllNegativeNumbers_WorksCorrectly(IBaseballGame_682 solution)
        {
            // Arrange
            string[] operations = { "-10", "-5", "+" };

            // Act
            int result = solution.CalPoints(operations);

            // Assert - Record: [-10, -5, -15], sum = -30
            Assert.AreEqual(-30, result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CalPoints_DoubleNegativeNumber_WorksCorrectly(IBaseballGame_682 solution)
        {
            // Arrange
            string[] operations = { "-5", "D" };

            // Act
            int result = solution.CalPoints(operations);

            // Assert - Record: [-5, -10], sum = -15
            Assert.AreEqual(-15, result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CalPoints_MixedPositiveAndNegative_WorksCorrectly(IBaseballGame_682 solution)
        {
            // Arrange
            string[] operations = { "10", "-5", "+", "D" };

            // Act
            int result = solution.CalPoints(operations);

            // Assert - Record: [10, -5, 5, 10], sum = 20
            Assert.AreEqual(20, result);
        }
    }
}