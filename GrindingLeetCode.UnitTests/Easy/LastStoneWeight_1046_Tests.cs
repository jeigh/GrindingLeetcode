using LeetCodeProblems.CSharp.Queue;
using LeetCodeProblems.Interfaces.Easy;
using LeetCodeProblems.VisualBasic;

namespace GrindingLeetCode.UnitTests.Easy
{
    [TestClass]
    public class LastStoneWeight_1046_Tests
    {
        public static IEnumerable<object[]> GetImplementations()
        {
            yield return new object[] { typeof(LastStoneWeight_CSharp_1046), "C# PriorityQueue" };
            yield return new object[] { typeof(LastStoneWeight_VB_1046), "VB PriorityQueue" };
        }

        #region Helper Methods

        private ILastStoneWeight_1046 CreateInstance(Type implementationType, int[] stones)
        {
            if (implementationType == typeof(LastStoneWeight_CSharp_1046))
                return new LastStoneWeight_CSharp_1046();
            else if (implementationType == typeof(LastStoneWeight_VB_1046))
                return new LastStoneWeight_VB_1046();
            else
                throw new ArgumentException($"Unknown implementation type: {implementationType.Name}");
        }

        #endregion

        #region LeetCode Examples

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void LastStoneWeight_Example1_Returns1(Type implementationType, string solutionName)
        {
            // Input: stones = [2,7,4,1,8,1]
            // Output: 1
            // Explanation:
            // - Smash 7 and 8 ? 1, stones = [2,4,1,1,1]
            // - Smash 2 and 4 ? 2, stones = [2,1,1,1]
            // - Smash 2 and 1 ? 1, stones = [1,1,1]
            // - Smash 1 and 1 ? 0, stones = [1]

            // Arrange
            int[] stones = { 2, 7, 4, 1, 8, 1 };
            var solution = CreateInstance(implementationType, stones);

            // Act
            int result = solution.LastStoneWeight(stones);

            // Assert
            Assert.AreEqual(1, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void LastStoneWeight_Example2_Returns1(Type implementationType, string solutionName)
        {
            // Input: stones = [1]
            // Output: 1

            // Arrange
            int[] stones = { 1 };
            var solution = CreateInstance(implementationType, stones);

            // Act
            int result = solution.LastStoneWeight(stones);

            // Assert
            Assert.AreEqual(1, result, $"Failed for {solutionName}");
        }

        #endregion

        #region Single Stone

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void LastStoneWeight_SingleStone_ReturnsStoneWeight(Type implementationType, string solutionName)
        {
            // Arrange
            int[] stones = { 5 };
            var solution = CreateInstance(implementationType, stones);

            // Act
            int result = solution.LastStoneWeight(stones);

            // Assert
            Assert.AreEqual(5, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void LastStoneWeight_SingleStoneMinValue_ReturnsMinValue(Type implementationType, string solutionName)
        {
            // Arrange
            int[] stones = { 1 };
            var solution = CreateInstance(implementationType, stones);

            // Act
            int result = solution.LastStoneWeight(stones);

            // Assert
            Assert.AreEqual(1, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void LastStoneWeight_SingleStoneMaxValue_ReturnsMaxValue(Type implementationType, string solutionName)
        {
            // Arrange
            int[] stones = { 1000 };
            var solution = CreateInstance(implementationType, stones);

            // Act
            int result = solution.LastStoneWeight(stones);

            // Assert
            Assert.AreEqual(1000, result, $"Failed for {solutionName}");
        }

        #endregion

        #region Two Stones

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void LastStoneWeight_TwoEqualStones_Returns0(Type implementationType, string solutionName)
        {
            // Arrange
            int[] stones = { 5, 5 };
            var solution = CreateInstance(implementationType, stones);

            // Act
            int result = solution.LastStoneWeight(stones);

            // Assert
            Assert.AreEqual(0, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void LastStoneWeight_TwoDifferentStones_ReturnsDifference(Type implementationType, string solutionName)
        {
            // Arrange
            int[] stones = { 10, 3 };
            var solution = CreateInstance(implementationType, stones);

            // Act
            int result = solution.LastStoneWeight(stones);

            // Assert
            Assert.AreEqual(7, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void LastStoneWeight_TwoStones_LargeGap_ReturnsDifference(Type implementationType, string solutionName)
        {
            // Arrange
            int[] stones = { 100, 1 };
            var solution = CreateInstance(implementationType, stones);

            // Act
            int result = solution.LastStoneWeight(stones);

            // Assert
            Assert.AreEqual(99, result, $"Failed for {solutionName}");
        }

        #endregion

        #region Multiple Equal Stones

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void LastStoneWeight_AllEqualStones_EvenCount_Returns0(Type implementationType, string solutionName)
        {
            // Arrange
            int[] stones = { 5, 5, 5, 5 };
            var solution = CreateInstance(implementationType, stones);

            // Act
            int result = solution.LastStoneWeight(stones);

            // Assert
            Assert.AreEqual(0, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void LastStoneWeight_AllEqualStones_OddCount_ReturnsOneStone(Type implementationType, string solutionName)
        {
            // Arrange
            int[] stones = { 3, 3, 3, 3, 3 };
            var solution = CreateInstance(implementationType, stones);

            // Act
            int result = solution.LastStoneWeight(stones);

            // Assert
            Assert.AreEqual(3, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void LastStoneWeight_ThreeEqualStones_ReturnsOneStone(Type implementationType, string solutionName)
        {
            // Arrange
            int[] stones = { 7, 7, 7 };
            var solution = CreateInstance(implementationType, stones);

            // Act
            int result = solution.LastStoneWeight(stones);

            // Assert
            Assert.AreEqual(7, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void LastStoneWeight_SixEqualStones_Returns0(Type implementationType, string solutionName)
        {
            // Arrange
            int[] stones = { 2, 2, 2, 2, 2, 2 };
            var solution = CreateInstance(implementationType, stones);

            // Act
            int result = solution.LastStoneWeight(stones);

            // Assert
            Assert.AreEqual(0, result, $"Failed for {solutionName}");
        }

        #endregion

        #region Ascending Order

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void LastStoneWeight_AscendingOrder_3Stones_ReturnsCorrect(Type implementationType, string solutionName)
        {
            // Arrange
            int[] stones = { 1, 2, 3 };
            var solution = CreateInstance(implementationType, stones);

            // Act
            int result = solution.LastStoneWeight(stones);

            // Assert
            // Smash 2,3 ? 1, stones = [1,1]
            // Smash 1,1 ? 0
            Assert.AreEqual(0, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void LastStoneWeight_AscendingOrder_5Stones_ReturnsCorrect(Type implementationType, string solutionName)
        {
            // Arrange
            int[] stones = { 1, 2, 3, 4, 5 };
            var solution = CreateInstance(implementationType, stones);

            // Act
            int result = solution.LastStoneWeight(stones);

            // Assert
            // Smash 4,5 ? 1, stones = [1,2,3,1]
            // Smash 2,3 ? 1, stones = [1,1,1]
            // Smash 1,1 ? 0, stones = [1]
            Assert.AreEqual(1, result, $"Failed for {solutionName}");
        }

        #endregion

        #region Descending Order

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void LastStoneWeight_DescendingOrder_3Stones_ReturnsCorrect(Type implementationType, string solutionName)
        {
            // Arrange
            int[] stones = { 10, 5, 2 };
            var solution = CreateInstance(implementationType, stones);

            // Act
            int result = solution.LastStoneWeight(stones);

            // Assert
            // Smash 10,5 ? 5, stones = [5,2]
            // Smash 5,2 ? 3
            Assert.AreEqual(3, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void LastStoneWeight_DescendingOrder_5Stones_ReturnsCorrect(Type implementationType, string solutionName)
        {
            // Arrange
            int[] stones = { 10, 8, 6, 4, 2 };
            var solution = CreateInstance(implementationType, stones);

            // Act
            int result = solution.LastStoneWeight(stones);

            // Assert
            // Smash 10,8 ? 2, stones = [6,4,2,2]
            // Smash 6,4 ? 2, stones = [2,2,2]
            // Smash 2,2 ? 0, stones = [2]
            Assert.AreEqual(2, result, $"Failed for {solutionName}");
        }

        #endregion

        #region Mixed Patterns

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void LastStoneWeight_MixedValues_SmallArray_ReturnsCorrect(Type implementationType, string solutionName)
        {
            // Arrange
            int[] stones = { 3, 7, 2 };
            var solution = CreateInstance(implementationType, stones);

            // Act
            int result = solution.LastStoneWeight(stones);

            // Assert
            // Smash 7,3 ? 4, stones = [4,2]
            // Smash 4,2 ? 2
            Assert.AreEqual(2, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void LastStoneWeight_MixedValues_MediumArray_ReturnsCorrect(Type implementationType, string solutionName)
        {
            // Arrange
            int[] stones = { 5, 10, 3, 8, 1 };
            var solution = CreateInstance(implementationType, stones);

            // Act
            int result = solution.LastStoneWeight(stones);

            // Assert
            // Process: largest stones smashed repeatedly
            Assert.IsTrue(result >= 0, $"Result should be non-negative for {solutionName}");
        }

        #endregion

        #region Pairs of Stones

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void LastStoneWeight_TwoPairs_Equal_Returns0(Type implementationType, string solutionName)
        {
            // Arrange
            int[] stones = { 5, 5, 3, 3 };
            var solution = CreateInstance(implementationType, stones);

            // Act
            int result = solution.LastStoneWeight(stones);

            // Assert
            // Smash 5,5 ? 0, stones = [3,3]
            // Smash 3,3 ? 0
            Assert.AreEqual(0, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void LastStoneWeight_TwoPairs_Different_ReturnsCorrect(Type implementationType, string solutionName)
        {
            // Arrange
            int[] stones = { 10, 10, 5, 5 };
            var solution = CreateInstance(implementationType, stones);

            // Act
            int result = solution.LastStoneWeight(stones);

            // Assert
            // Smash 10,10 ? 0, stones = [5,5]
            // Smash 5,5 ? 0
            Assert.AreEqual(0, result, $"Failed for {solutionName}");
        }

        #endregion

        #region Large Values

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void LastStoneWeight_LargeValues_ReturnsCorrect(Type implementationType, string solutionName)
        {
            // Arrange
            int[] stones = { 1000, 999, 998 };
            var solution = CreateInstance(implementationType, stones);

            // Act
            int result = solution.LastStoneWeight(stones);

            // Assert
            // Smash 1000,999 ? 1, stones = [998,1]
            // Smash 998,1 ? 997
            Assert.AreEqual(997, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void LastStoneWeight_MaxValues_ReturnsCorrect(Type implementationType, string solutionName)
        {
            // Arrange
            int[] stones = { 1000, 1000, 1000, 1000 };
            var solution = CreateInstance(implementationType, stones);

            // Act
            int result = solution.LastStoneWeight(stones);

            // Assert
            Assert.AreEqual(0, result, $"Failed for {solutionName}");
        }

        #endregion

        #region One Heavy Stone

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void LastStoneWeight_OneHeavyStone_ReturnsRemainder(Type implementationType, string solutionName)
        {
            // Arrange
            int[] stones = { 100, 1, 1, 1, 1 };
            var solution = CreateInstance(implementationType, stones);

            // Act
            int result = solution.LastStoneWeight(stones);

            // Assert
            // Heavy stone destroys all smaller ones
            Assert.AreEqual(96, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void LastStoneWeight_OneHeavyStone_MultipleSmall_ReturnsCorrect(Type implementationType, string solutionName)
        {
            // Arrange
            int[] stones = { 50, 10, 10, 10, 10, 10 };
            var solution = CreateInstance(implementationType, stones);

            // Act
            int result = solution.LastStoneWeight(stones);

            // Assert
            Assert.AreEqual(0, result, $"Failed for {solutionName}");
        }

        #endregion

        #region Cascading Destruction

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void LastStoneWeight_CascadingDestruction_ReturnsCorrect(Type implementationType, string solutionName)
        {
            // Arrange
            int[] stones = { 10, 9, 8, 7, 6 };
            var solution = CreateInstance(implementationType, stones);

            // Act
            int result = solution.LastStoneWeight(stones);

            // Assert
            // Smash 10,9 ? 1, stones = [8,7,6,1]
            // Smash 8,7 ? 1, stones = [6,1,1]
            // Smash 6,1 ? 5, stones = [5,1]
            // Smash 5,1 ? 4
            Assert.AreEqual(4, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void LastStoneWeight_CompleteDestruction_Returns0(Type implementationType, string solutionName)
        {
            // Arrange
            int[] stones = { 10, 10, 5, 5 };
            var solution = CreateInstance(implementationType, stones);

            // Act
            int result = solution.LastStoneWeight(stones);

            // Assert
            Assert.AreEqual(0, result, $"Failed for {solutionName}");
        }

        #endregion

        #region Larger Arrays

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void LastStoneWeight_10Stones_ReturnsCorrect(Type implementationType, string solutionName)
        {
            // Arrange
            int[] stones = { 10, 20, 30, 5, 15, 25, 8, 12, 18, 22 };
            var solution = CreateInstance(implementationType, stones);

            // Act
            int result = solution.LastStoneWeight(stones);

            // Assert
            Assert.IsTrue(result >= 0, $"Result should be non-negative for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void LastStoneWeight_15Stones_AllDifferent_ReturnsCorrect(Type implementationType, string solutionName)
        {
            // Arrange
            int[] stones = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
            var solution = CreateInstance(implementationType, stones);

            // Act
            int result = solution.LastStoneWeight(stones);

            // Assert
            Assert.IsTrue(result >= 0, $"Result should be non-negative for {solutionName}");
        }

        #endregion

        #region Alternating Patterns

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void LastStoneWeight_AlternatingLargeSmall_ReturnsCorrect(Type implementationType, string solutionName)
        {
            // Arrange
            int[] stones = { 100, 1, 100, 1, 100, 1 };
            var solution = CreateInstance(implementationType, stones);

            // Act
            int result = solution.LastStoneWeight(stones);

            // Assert
            // Step 1: Smash 100,100 ? 0, stones = [100,1,1,1]
            // Step 2: Smash 100,1 ? 99, stones = [99,1,1]
            // Step 3: Smash 99,1 ? 98, stones = [98,1]
            // Step 4: Smash 98,1 ? 97, stones = [97]
            Assert.AreEqual(97, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void LastStoneWeight_AlternatingPairs_ReturnsCorrect(Type implementationType, string solutionName)
        {
            // Arrange
            int[] stones = { 5, 5, 10, 10, 15, 15 };
            var solution = CreateInstance(implementationType, stones);

            // Act
            int result = solution.LastStoneWeight(stones);

            // Assert
            Assert.AreEqual(0, result, $"Failed for {solutionName}");
        }

        #endregion

        #region Sequential Values

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void LastStoneWeight_Sequential1To5_ReturnsCorrect(Type implementationType, string solutionName)
        {
            // Arrange
            int[] stones = { 1, 2, 3, 4, 5 };
            var solution = CreateInstance(implementationType, stones);

            // Act
            int result = solution.LastStoneWeight(stones);

            // Assert
            Assert.AreEqual(1, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void LastStoneWeight_Sequential2To6_ReturnsCorrect(Type implementationType, string solutionName)
        {
            // Arrange
            int[] stones = { 2, 3, 4, 5, 6 };
            var solution = CreateInstance(implementationType, stones);

            // Act
            int result = solution.LastStoneWeight(stones);

            // Assert
            Assert.IsTrue(result >= 0, $"Result should be non-negative for {solutionName}");
        }

        #endregion

        #region Powers of Two

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void LastStoneWeight_PowersOfTwo_ReturnsCorrect(Type implementationType, string solutionName)
        {
            // Arrange
            int[] stones = { 1, 2, 4, 8, 16 };
            var solution = CreateInstance(implementationType, stones);

            // Act
            int result = solution.LastStoneWeight(stones);

            // Assert
            Assert.IsTrue(result >= 0, $"Result should be non-negative for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void LastStoneWeight_PowersOfTwoPairs_ReturnsCorrect(Type implementationType, string solutionName)
        {
            // Arrange
            int[] stones = { 2, 2, 4, 4, 8, 8 };
            var solution = CreateInstance(implementationType, stones);

            // Act
            int result = solution.LastStoneWeight(stones);

            // Assert
            Assert.AreEqual(0, result, $"Failed for {solutionName}");
        }

        #endregion

        #region Edge Cases - Min/Max

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void LastStoneWeight_AllOnes_OddCount_Returns1(Type implementationType, string solutionName)
        {
            // Arrange
            int[] stones = { 1, 1, 1, 1, 1, 1, 1 };
            var solution = CreateInstance(implementationType, stones);

            // Act
            int result = solution.LastStoneWeight(stones);

            // Assert
            Assert.AreEqual(1, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void LastStoneWeight_AllOnes_EvenCount_Returns0(Type implementationType, string solutionName)
        {
            // Arrange
            int[] stones = { 1, 1, 1, 1, 1, 1 };
            var solution = CreateInstance(implementationType, stones);

            // Act
            int result = solution.LastStoneWeight(stones);

            // Assert
            Assert.AreEqual(0, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void LastStoneWeight_MaxConstraint_30Stones_ReturnsCorrect(Type implementationType, string solutionName)
        {
            // Arrange - 30 stones (constraint max)
            int[] stones = Enumerable.Range(1, 30).ToArray();
            var solution = CreateInstance(implementationType, stones);

            // Act
            int result = solution.LastStoneWeight(stones);

            // Assert
            Assert.IsTrue(result >= 0, $"Result should be non-negative for {solutionName}");
        }

        #endregion

        #region Property Tests

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void LastStoneWeight_ResultAlwaysNonNegative(Type implementationType, string solutionName)
        {
            // Test multiple scenarios

            // Arrange
            var testCases = new[]
            {
                new[] { 5, 10, 15 },
                new[] { 1, 1, 1, 1 },
                new[] { 100, 50, 25 },
                new[] { 7, 7, 7, 7, 7 }
            };

            foreach (var stones in testCases)
            {
                var solution = CreateInstance(implementationType, stones);

                // Act
                int result = solution.LastStoneWeight(stones);

                // Assert
                Assert.IsTrue(result >= 0, 
                    $"Result should always be non-negative for {solutionName}");
            }
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void LastStoneWeight_ResultNotLargerThanMaxStone(Type implementationType, string solutionName)
        {
            // The result should never be larger than the largest stone

            // Arrange
            var testCases = new[]
            {
                new[] { 10, 5, 3, 2 },
                new[] { 100, 50, 25, 10 },
                new[] { 7, 6, 5, 4, 3 }
            };

            foreach (var stones in testCases)
            {
                int maxStone = stones.Max();
                var solution = CreateInstance(implementationType, stones);

                // Act
                int result = solution.LastStoneWeight(stones);

                // Assert
                Assert.IsTrue(result <= maxStone, 
                    $"Result should not exceed max stone weight for {solutionName}");
            }
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void LastStoneWeight_EqualPairs_AlwaysReturns0OrSingleValue(Type implementationType, string solutionName)
        {
            // When all stones come in equal pairs, result should be 0
            // Unless there's one odd one out

            // Arrange - Even count of equal pairs
            int[] stonesEven = { 10, 10, 5, 5, 3, 3 };
            var solutionEven = CreateInstance(implementationType, stonesEven);
            
            // Arrange - Odd count (one extra)
            int[] stonesOdd = { 10, 10, 5, 5, 3, 3, 2 };
            var solutionOdd = CreateInstance(implementationType, stonesOdd);

            // Act
            int resultEven = solutionEven.LastStoneWeight(stonesEven);
            int resultOdd = solutionOdd.LastStoneWeight(stonesOdd);

            // Assert
            Assert.AreEqual(0, resultEven, $"Even pairs should result in 0 for {solutionName}");
            Assert.AreEqual(2, resultOdd, $"Odd one out should remain for {solutionName}");
        }

        #endregion
    }
}
