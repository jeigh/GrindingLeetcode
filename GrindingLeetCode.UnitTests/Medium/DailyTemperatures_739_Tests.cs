using LeetCodeProblems.CSharp.Stack;
using LeetCodeProblems.Interfaces.Medium;
using LeetCodeProblems.VisualBasic;

namespace GrindingLeetCode.UnitTests.Medium
{
    [TestClass]
    public class DailyTemperatures_739_Tests
    {
        public static IEnumerable<object[]> GetImplementations()
        {
            yield return new object[] { new DailyTemperaturesVBSolution_739() };
            yield return new object[] { new DailyTemperaturesCSharpSolution_739() };
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void DailyTemperatures_Example1_ReturnsExpectedResult(IDailyTemperatures_739 solution)
        {
            // Arrange
            int[] temperatures = { 73, 74, 75, 71, 69, 72, 76, 73 };
            int[] expected = { 1, 1, 4, 2, 1, 1, 0, 0 };

            // Act
            int[] result = solution.DailyTemperatures(temperatures);

            // Assert
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void DailyTemperatures_Example2_AllIncreasing(IDailyTemperatures_739 solution)
        {
            // Arrange
            int[] temperatures = { 30, 40, 50, 60 };
            int[] expected = { 1, 1, 1, 0 };

            // Act
            int[] result = solution.DailyTemperatures(temperatures);

            // Assert
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void DailyTemperatures_Example3_AllDecreasing(IDailyTemperatures_739 solution)
        {
            // Arrange
            int[] temperatures = { 30, 60, 90 };
            int[] expected = { 1, 1, 0 };

            // Act
            int[] result = solution.DailyTemperatures(temperatures);

            // Assert
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void DailyTemperatures_SingleDay_ReturnsZero(IDailyTemperatures_739 solution)
        {
            // Arrange
            int[] temperatures = { 75 };
            int[] expected = { 0 };

            // Act
            int[] result = solution.DailyTemperatures(temperatures);

            // Assert
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void DailyTemperatures_TwoDays_BothSameTemp_ReturnsZeros(IDailyTemperatures_739 solution)
        {
            // Arrange
            int[] temperatures = { 70, 70 };
            int[] expected = { 0, 0 };

            // Act
            int[] result = solution.DailyTemperatures(temperatures);

            // Assert
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void DailyTemperatures_TwoDays_SecondWarmer_ReturnsOne(IDailyTemperatures_739 solution)
        {
            // Arrange
            int[] temperatures = { 70, 75 };
            int[] expected = { 1, 0 };

            // Act
            int[] result = solution.DailyTemperatures(temperatures);

            // Assert
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void DailyTemperatures_TwoDays_SecondCooler_ReturnsBothZeros(IDailyTemperatures_739 solution)
        {
            // Arrange
            int[] temperatures = { 75, 70 };
            int[] expected = { 0, 0 };

            // Act
            int[] result = solution.DailyTemperatures(temperatures);

            // Assert
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void DailyTemperatures_MonotonicDecreasing_AllZeros(IDailyTemperatures_739 solution)
        {
            // Arrange
            int[] temperatures = { 100, 90, 80, 70, 60 };
            int[] expected = { 0, 0, 0, 0, 0 };

            // Act
            int[] result = solution.DailyTemperatures(temperatures);

            // Assert
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void DailyTemperatures_MonotonicIncreasing_AllOnes(IDailyTemperatures_739 solution)
        {
            // Arrange
            int[] temperatures = { 60, 70, 80, 90, 100 };
            int[] expected = { 1, 1, 1, 1, 0 };

            // Act
            int[] result = solution.DailyTemperatures(temperatures);

            // Assert
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void DailyTemperatures_AllSameTemperature_AllZeros(IDailyTemperatures_739 solution)
        {
            // Arrange
            int[] temperatures = { 75, 75, 75, 75, 75 };
            int[] expected = { 0, 0, 0, 0, 0 };

            // Act
            int[] result = solution.DailyTemperatures(temperatures);

            // Assert
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void DailyTemperatures_WarmerDayFarAway_ReturnsCorrectDistance(IDailyTemperatures_739 solution)
        {
            // Arrange
            int[] temperatures = { 50, 40, 30, 20, 60 };
            int[] expected = { 4, 3, 2, 1, 0 };

            // Act
            int[] result = solution.DailyTemperatures(temperatures);

            // Assert
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void DailyTemperatures_VPattern_ReturnsCorrectResult(IDailyTemperatures_739 solution)
        {
            // Arrange - temperature goes down then up
            int[] temperatures = { 80, 70, 60, 70, 80 };
            int[] expected = { 0, 3, 1, 1, 0 };

            // Act
            int[] result = solution.DailyTemperatures(temperatures);

            // Assert
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void DailyTemperatures_PeakInMiddle_ReturnsCorrectResult(IDailyTemperatures_739 solution)
        {
            // Arrange
            int[] temperatures = { 70, 80, 90, 80, 70 };
            int[] expected = { 1, 1, 0, 0, 0 };

            // Act
            int[] result = solution.DailyTemperatures(temperatures);

            // Assert
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void DailyTemperatures_ValleyInMiddle_ReturnsCorrectResult(IDailyTemperatures_739 solution)
        {
            // Arrange
            int[] temperatures = { 70, 60, 50, 60, 70 };
            int[] expected = { 0, 3, 1, 1, 0 };

            // Act
            int[] result = solution.DailyTemperatures(temperatures);

            // Assert
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void DailyTemperatures_MultipleEqualTemperatures_SkipsToWarmerDay(IDailyTemperatures_739 solution)
        {
            // Arrange
            int[] temperatures = { 70, 70, 70, 75 };
            int[] expected = { 3, 2, 1, 0 };

            // Act
            int[] result = solution.DailyTemperatures(temperatures);

            // Assert
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void DailyTemperatures_SmallIncrement_FindsNextWarmer(IDailyTemperatures_739 solution)
        {
            // Arrange
            int[] temperatures = { 70, 71, 72, 73 };
            int[] expected = { 1, 1, 1, 0 };

            // Act
            int[] result = solution.DailyTemperatures(temperatures);

            // Assert
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void DailyTemperatures_LargeJump_FindsNextWarmer(IDailyTemperatures_739 solution)
        {
            // Arrange
            int[] temperatures = { 30, 31, 100 };
            int[] expected = { 1, 1, 0 };

            // Act
            int[] result = solution.DailyTemperatures(temperatures);

            // Assert
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void DailyTemperatures_AlternatingHighLow_ReturnsCorrectDistances(IDailyTemperatures_739 solution)
        {
            // Arrange
            int[] temperatures = { 80, 60, 85, 55, 90 };
            int[] expected = { 2, 1, 2, 1, 0 };

            // Act
            int[] result = solution.DailyTemperatures(temperatures);

            // Assert
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void DailyTemperatures_LongSequence_ReturnsCorrectResult(IDailyTemperatures_739 solution)
        {
            // Arrange
            int[] temperatures = { 55, 38, 53, 81, 61, 93, 97, 32, 43, 78 };
            int[] expected = { 3, 1, 1, 2, 1, 1, 0, 1, 1, 0 };

            // Act
            int[] result = solution.DailyTemperatures(temperatures);

            // Assert
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void DailyTemperatures_MinimumTemperatures_ReturnsCorrectResult(IDailyTemperatures_739 solution)
        {
            // Arrange
            int[] temperatures = { 30, 30, 31 };
            int[] expected = { 2, 1, 0 };

            // Act
            int[] result = solution.DailyTemperatures(temperatures);

            // Assert
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void DailyTemperatures_MaximumTemperature_LastDayZero(IDailyTemperatures_739 solution)
        {
            // Arrange
            int[] temperatures = { 70, 75, 80, 100 };
            int[] expected = { 1, 1, 1, 0 };

            // Act
            int[] result = solution.DailyTemperatures(temperatures);

            // Assert
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void DailyTemperatures_ExtremeTemperatures_HandlesCorrectly(IDailyTemperatures_739 solution)
        {
            // Arrange - Using temperature range (30 to 100 as per LeetCode constraints)
            int[] temperatures = { 30, 100, 30 };
            int[] expected = { 1, 0, 0 };

            // Act
            int[] result = solution.DailyTemperatures(temperatures);

            // Assert
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void DailyTemperatures_SlightlyWarmerAtEnd_ReturnsLargeDistance(IDailyTemperatures_739 solution)
        {
            // Arrange
            int[] temperatures = { 50, 40, 30, 20, 10, 51 };
            int[] expected = { 5, 4, 3, 2, 1, 0 };

            // Act
            int[] result = solution.DailyTemperatures(temperatures);

            // Assert
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void DailyTemperatures_MultipleWarmDaysAhead_FindsFirst(IDailyTemperatures_739 solution)
        {
            // Arrange
            int[] temperatures = { 70, 80, 85, 90 };
            int[] expected = { 1, 1, 1, 0 };

            // Act
            int[] result = solution.DailyTemperatures(temperatures);

            // Assert
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void DailyTemperatures_ComplexPattern_ReturnsCorrectResult(IDailyTemperatures_739 solution)
        {
            // Arrange
            int[] temperatures = { 89, 62, 70, 58, 47, 47, 46, 76, 100, 70 };
            int[] expected = { 8, 1, 5, 4, 3, 2, 1, 1, 0, 0 };

            // Act
            int[] result = solution.DailyTemperatures(temperatures);

            // Assert
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void DailyTemperatures_GradualIncreaseThenDrop_ReturnsCorrectResult(IDailyTemperatures_739 solution)
        {
            // Arrange
            int[] temperatures = { 60, 65, 70, 75, 50 };
            int[] expected = { 1, 1, 1, 0, 0 };

            // Act
            int[] result = solution.DailyTemperatures(temperatures);

            // Assert
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void DailyTemperatures_PlateauPattern_ReturnsCorrectResult(IDailyTemperatures_739 solution)
        {
            // Arrange
            int[] temperatures = { 60, 70, 70, 70, 80 };
            int[] expected = { 1, 3, 2, 1, 0 };

            // Act
            int[] result = solution.DailyTemperatures(temperatures);

            // Assert
            CollectionAssert.AreEqual(expected, result);
        }
    }
}