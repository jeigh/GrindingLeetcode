using LeetCodeProblems.CSharp.Backtracking;
using LeetCodeProblems.Interfaces.Medium;
using LeetCodeProblems.VisualBasic.Backtracking;

namespace GrindingLeetCode.UnitTests.Medium
{
    /// <summary>
    /// Unit tests for LeetCode Problem 40: Combination Sum II
    ///
    /// Problem Description:
    /// Given a collection of candidate numbers and a target, find all unique
    /// combinations where the candidate numbers sum to target. Each number in
    /// candidates may only be used once. The solution set must not contain
    /// duplicate combinations.
    /// </summary>
    [TestClass]
    public class CombinationSum2_40_Tests
    {
        public static IEnumerable<object[]> GetImplementations()
        {
            yield return new object[] { new CombinationSum2_Recursive_Backtracking_CSharp_40(), "C# Recursive Backtracking" };
            yield return new object[] { new CombinationSum2_BacktrackingHashmap_CSharp_40(), "C# Backtracking Hashmap" };
            yield return new object[] { new CombinationSum2_BacktrackingOptimal_CSharp_40(), "C# Backtracking Optimal" };

            yield return new object[] { new CombinationSumII_Recursive_VB_40(), "VB Recursive" };
            yield return new object[] { new CombinationSumII_BacktrackingHashmap_VB_40(), "VB Backtracking Hashmap" };
            yield return new object[] { new CombinationSumII_RecursiveOptimized_VB_40(), "VB Backtracking Optimized" };
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
        public void CombinationSum2_Example1_ReturnsCorrectCombinations(ICombinationSumII_40 solution, string solutionName)
        {
            // Input: candidates = [10,1,2,7,6,1,5], target = 8
            // Output: [[1,1,6],[1,2,5],[1,7],[2,6]]

            // Arrange
            int[] candidates = { 10, 1, 2, 7, 6, 1, 5 };
            int target = 8;
            IList<IList<int>> expected = new List<IList<int>>
            {
                new List<int> { 1, 1, 6 },
                new List<int> { 1, 2, 5 },
                new List<int> { 1, 7 },
                new List<int> { 2, 6 }
            };

            // Act
            var result = solution.CombinationSum2(candidates, target);

            // Assert
            AssertCombinationsEqual(expected, result, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CombinationSum2_Example2_ReturnsCorrectCombinations(ICombinationSumII_40 solution, string solutionName)
        {
            // Input: candidates = [2,5,2,1,2], target = 5
            // Output: [[1,2,2],[5]]

            // Arrange
            int[] candidates = { 2, 5, 2, 1, 2 };
            int target = 5;
            IList<IList<int>> expected = new List<IList<int>>
            {
                new List<int> { 1, 2, 2 },
                new List<int> { 5 }
            };

            // Act
            var result = solution.CombinationSum2(candidates, target);

            // Assert
            AssertCombinationsEqual(expected, result, solutionName);
        }

        #endregion

        #region Edge Cases

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CombinationSum2_NoValidCombination_ReturnsEmpty(ICombinationSumII_40 solution, string solutionName)
        {
            // No subset of [5] sums to 3.
            // Input: candidates = [5], target = 3
            // Output: []

            // Arrange
            int[] candidates = { 5 };
            int target = 3;

            // Act
            var result = solution.CombinationSum2(candidates, target);

            // Assert
            Assert.AreEqual(0, result.Count, $"Expected empty result [{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CombinationSum2_SingleCandidateExactMatch_ReturnsSingleCombination(ICombinationSumII_40 solution, string solutionName)
        {
            // Input: candidates = [7], target = 7
            // Output: [[7]]

            // Arrange
            int[] candidates = { 7 };
            int target = 7;
            IList<IList<int>> expected = new List<IList<int>>
            {
                new List<int> { 7 }
            };

            // Act
            var result = solution.CombinationSum2(candidates, target);

            // Assert
            AssertCombinationsEqual(expected, result, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CombinationSum2_NoDuplicateCombinations_WhenCandidatesHaveDuplicates(ICombinationSumII_40 solution, string solutionName)
        {
            // Key LC 40 constraint: duplicate candidates must not produce duplicate combos.
            // Input: candidates = [1,1,1], target = 2
            // Output: [[1,1]]  -- not [[1,1],[1,1],[1,1]]

            // Arrange
            int[] candidates = { 1, 1, 1 };
            int target = 2;
            IList<IList<int>> expected = new List<IList<int>>
            {
                new List<int> { 1, 1 }
            };

            // Act
            var result = solution.CombinationSum2(candidates, target);

            // Assert
            AssertCombinationsEqual(expected, result, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CombinationSum2_EachCandidateUsedOnlyOnce_ReturnsEmpty(ICombinationSumII_40 solution, string solutionName)
        {
            // Key LC 40 constraint: each element may only be used once.
            // [1,2,2] and [2,2] require reuse -- neither is valid here.
            // Input: candidates = [1,2], target = 4
            // Output: []

            // Arrange
            int[] candidates = { 1, 2 };
            int target = 4;

            // Act
            var result = solution.CombinationSum2(candidates, target);

            // Assert
            Assert.AreEqual(0, result.Count, $"Expected empty result -- no element reuse allowed [{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CombinationSum2_AllCombinationsSumToTarget(ICombinationSumII_40 solution, string solutionName)
        {
            // Verifies every returned combination actually sums to the target.
            // Input: candidates = [10,1,2,7,6,1,5], target = 8

            // Arrange
            int[] candidates = { 10, 1, 2, 7, 6, 1, 5 };
            int target = 8;

            // Act
            var result = solution.CombinationSum2(candidates, target);

            // Assert
            foreach (var combo in result)
                Assert.AreEqual(target, combo.Sum(),
                    $"Combination [{string.Join(",", combo)}] does not sum to {target} [{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CombinationSum2_UsageNeverExceedsAvailability(ICombinationSumII_40 solution, string solutionName)
        {
            // Verifies no element is used more times than it appears in candidates.
            // Input: candidates = [2,5,2,1,2], target = 5

            // Arrange
            int[] candidates = { 2, 5, 2, 1, 2 };
            int target = 5;
            var available = candidates
                .GroupBy(x => x)
                .ToDictionary(g => g.Key, g => g.Count());

            // Act
            var result = solution.CombinationSum2(candidates, target);

            // Assert
            foreach (var combo in result)
            {
                var used = combo
                    .GroupBy(x => x)
                    .ToDictionary(g => g.Key, g => g.Count());

                foreach (var kvp in used)
                    Assert.IsTrue(
                        available.ContainsKey(kvp.Key) && available[kvp.Key] >= kvp.Value,
                        $"Element {kvp.Key} used {kvp.Value}x but only available {(available.ContainsKey(kvp.Key) ? available[kvp.Key] : 0)}x [{solutionName}]");
            }
        }

        #endregion
    }
}
