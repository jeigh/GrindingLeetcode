using LeetCodeProblems.CSharp.Backtracking;
using LeetCodeProblems.Interfaces.Medium;
using LeetCodeProblems.VisualBasic.Backtracking;

namespace GrindingLeetCode.UnitTests.Medium
{
    /// <summary>
    /// Unit tests for LeetCode Problem 77: Combinations
    ///
    /// Problem Description:
    /// Given two integers n and k, return all possible combinations of k numbers
    /// chosen from the range [1, n]. You may return the answer in any order.
    /// </summary>
    [TestClass]
    public class Combinations_77_Tests
    {
        public static IEnumerable<object[]> GetImplementations()
        {
            yield return new object[] { new Combinations_BacktrackingWithForLoop_CSharp_77(), "C# Backtracking With For Loop" };
            yield return new object[] { new Combinations_Backtracking_CSharp_77(), "C# Backtracking" };
            yield return new object[] { new Combinations_Iterative_CSharp_77(), "C# Iterative" };

            yield return new object[] { new Combinations_Backtracking_VB_77(), "VB Backtracking" };
            yield return new object[] { new Combinations_BacktrackingForLoops_VB_77(), "VB Backtracking With For Loop" };
            yield return new object[] { new Combinations_Iterative_VB_77(), "VB Iterative" };
        }

        // Normalizes results for order-independent comparison:
        // sorts each inner combination, then sorts the collection of combinations.
        private static List<List<int>> Normalize(IList<IList<int>> result)
        {
            return result
                .Select(combo => combo.OrderBy(x => x).ToList())
                .OrderBy(combo => combo.Count)
                .ThenBy(combo => string.Join(",", combo))
                .ToList();
        }

        private static void AssertCombinationsEqual(
            IList<IList<int>> expected,
            IList<IList<int>> actual,
            string solutionName)
        {
            var normalizedExpected = Normalize(expected);
            var normalizedActual = Normalize(actual);

            Assert.AreEqual(
                normalizedExpected.Count,
                normalizedActual.Count,
                $"Expected {normalizedExpected.Count} combinations but got {normalizedActual.Count} [{solutionName}]");

            for (int i = 0; i < normalizedExpected.Count; i++)
            {
                CollectionAssert.AreEqual(
                    normalizedExpected[i],
                    normalizedActual[i],
                    $"Combination at index {i} does not match [{solutionName}]");
            }
        }

        #region LeetCode Examples

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Combine_Example1_ReturnsAllCombinations(ICombinations_77 solution, string solutionName)
        {
            // Input: n = 4, k = 2
            // Output: [[1,2],[1,3],[1,4],[2,3],[2,4],[3,4]]

            // Arrange
            int n = 4, k = 2;
            IList<IList<int>> expected = new List<IList<int>>
            {
                new List<int> { 1, 2 },
                new List<int> { 1, 3 },
                new List<int> { 1, 4 },
                new List<int> { 2, 3 },
                new List<int> { 2, 4 },
                new List<int> { 3, 4 }
            };

            // Act
            var result = solution.Combine(n, k);

            // Assert
            AssertCombinationsEqual(expected, result, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Combine_Example2_ReturnsSingleCombination(ICombinations_77 solution, string solutionName)
        {
            // Input: n = 1, k = 1
            // Output: [[1]]

            // Arrange
            int n = 1, k = 1;
            IList<IList<int>> expected = new List<IList<int>>
            {
                new List<int> { 1 }
            };

            // Act
            var result = solution.Combine(n, k);

            // Assert
            AssertCombinationsEqual(expected, result, solutionName);
        }

        #endregion

        #region Edge Cases

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Combine_KEqualsN_ReturnsSingleCombinationWithAllNumbers(ICombinations_77 solution, string solutionName)
        {
            // When k == n, there is exactly one combination: [1,2,...,n]
            // Input: n = 3, k = 3
            // Output: [[1,2,3]]

            // Arrange
            int n = 3, k = 3;
            IList<IList<int>> expected = new List<IList<int>>
            {
                new List<int> { 1, 2, 3 }
            };

            // Act
            var result = solution.Combine(n, k);

            // Assert
            AssertCombinationsEqual(expected, result, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Combine_KEquals1_ReturnsEachNumberAsSingletonList(ICombinations_77 solution, string solutionName)
        {
            // When k == 1, each number forms its own combination.
            // Input: n = 4, k = 1
            // Output: [[1],[2],[3],[4]]

            // Arrange
            int n = 4, k = 1;
            IList<IList<int>> expected = new List<IList<int>>
            {
                new List<int> { 1 },
                new List<int> { 2 },
                new List<int> { 3 },
                new List<int> { 4 }
            };

            // Act
            var result = solution.Combine(n, k);

            // Assert
            AssertCombinationsEqual(expected, result, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Combine_ResultCount_MatchesBinomialCoefficient(ICombinations_77 solution, string solutionName)
        {
            // C(5,3) = 10
            // Input: n = 5, k = 3

            // Arrange
            int n = 5, k = 3;

            // Act
            var result = solution.Combine(n, k);

            // Assert
            Assert.AreEqual(10, result.Count,
                $"Expected C(5,3)=10 combinations but got {result.Count} [{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Combine_AllCombinationsHaveExactlyKElements(ICombinations_77 solution, string solutionName)
        {
            // Every returned combination must have exactly k elements.
            // Input: n = 5, k = 2

            // Arrange
            int n = 5, k = 2;

            // Act
            var result = solution.Combine(n, k);

            // Assert
            foreach (var combo in result)
                Assert.AreEqual(k, combo.Count,
                    $"Combination [{string.Join(",", combo)}] has {combo.Count} elements, expected {k} [{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Combine_AllElementsInRange_NoOutOfBoundsValues(ICombinations_77 solution, string solutionName)
        {
            // Every element in every combination must be in [1, n].
            // Input: n = 4, k = 2

            // Arrange
            int n = 4, k = 2;

            // Act
            var result = solution.Combine(n, k);

            // Assert
            foreach (var combo in result)
                foreach (int val in combo)
                    Assert.IsTrue(val >= 1 && val <= n,
                        $"Value {val} is out of range [1,{n}] [{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Combine_NoDuplicateCombinations(ICombinations_77 solution, string solutionName)
        {
            // No two combinations in the result should be identical.
            // Input: n = 5, k = 3

            // Arrange
            int n = 5, k = 3;

            // Act
            var result = solution.Combine(n, k);
            var normalized = Normalize(result);

            // Assert
            var distinct = normalized.Select(c => string.Join(",", c)).Distinct().ToList();
            Assert.AreEqual(normalized.Count, distinct.Count,
                $"Result contains duplicate combinations [{solutionName}]");
        }

        #endregion
    }
}
