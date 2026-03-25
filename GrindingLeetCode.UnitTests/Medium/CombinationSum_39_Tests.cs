using LeetCodeProblems.CSharp.Backtracking;
using LeetCodeProblems.Interfaces.Medium;
using LeetCodeProblems.VisualBasic.Backtracking;

namespace GrindingLeetCode.UnitTests.Medium
{
    /// <summary>
    /// Unit tests for LeetCode Problem 39: Combination Sum
    ///
    /// Problem Description:
    /// Given an array of distinct integers candidates and a target integer target,
    /// return a list of all unique combinations of candidates where the chosen numbers
    /// sum to target. The same number may be chosen an unlimited number of times.
    /// </summary>
    [TestClass]
    public class CombinationSum_39_Tests
    {
        public static IEnumerable<object[]> GetImplementations()
        {
            yield return new object[] { new CombinationSum_Recursive_CSharp_39(), "C# Recursive Implementation" };
            yield return new object[] { new CombinationSum_Iterative_CSharp_39(), "C# Iterative_Implementation" };

            yield return new object[] { new CombinationSum_Recursive_VB_39(), "VB Recursive Implementation" };
            yield return new object[] { new CombinationSum_Iterative_VB_39(), "VB Iterative_Implementation" };
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
        public void CombinationSum_Example1_ReturnsCorrectCombinations(ICombinationSum_39 solution, string solutionName)
        {
            // Input: candidates = [2,3,6,7], target = 7
            // Output: [[2,2,3],[7]]

            // Arrange
            int[] candidates = { 2, 3, 6, 7 };
            int target = 7;
            IList<IList<int>> expected = new List<IList<int>>
            {
                new List<int> { 2, 2, 3 },
                new List<int> { 7 }
            };

            // Act
            var result = solution.CombinationSum(candidates, target);

            // Assert
            AssertCombinationsEqual(expected, result, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CombinationSum_Example2_ReturnsCorrectCombinations(ICombinationSum_39 solution, string solutionName)
        {
            // Input: candidates = [2,3,5], target = 8
            // Output: [[2,2,2,2],[2,3,3],[3,5]]

            // Arrange
            int[] candidates = { 2, 3, 5 };
            int target = 8;
            IList<IList<int>> expected = new List<IList<int>>
            {
                new List<int> { 2, 2, 2, 2 },
                new List<int> { 2, 3, 3 },
                new List<int> { 3, 5 }
            };

            // Act
            var result = solution.CombinationSum(candidates, target);

            // Assert
            AssertCombinationsEqual(expected, result, solutionName);
        }

        #endregion

        #region Edge Cases

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CombinationSum_NoValidCombination_ReturnsEmpty(ICombinationSum_39 solution, string solutionName)
        {
            // No candidate divides evenly into or sums to 1.
            // Input: candidates = [2], target = 1
            // Output: []

            // Arrange
            int[] candidates = { 2 };
            int target = 1;

            // Act
            var result = solution.CombinationSum(candidates, target);

            // Assert
            Assert.AreEqual(0, result.Count, $"Expected empty result [{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CombinationSum_SingleCandidateExactMatch_ReturnsSingleCombination(ICombinationSum_39 solution, string solutionName)
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
            var result = solution.CombinationSum(candidates, target);

            // Assert
            AssertCombinationsEqual(expected, result, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CombinationSum_SingleCandidateRepeated_ReturnsSingleCombination(ICombinationSum_39 solution, string solutionName)
        {
            // Same number used multiple times.
            // Input: candidates = [3], target = 9
            // Output: [[3,3,3]]

            // Arrange
            int[] candidates = { 3 };
            int target = 9;
            IList<IList<int>> expected = new List<IList<int>>
            {
                new List<int> { 3, 3, 3 }
            };

            // Act
            var result = solution.CombinationSum(candidates, target);

            // Assert
            AssertCombinationsEqual(expected, result, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CombinationSum_NoDuplicateCombinations_EachCombinationIsUnique(ICombinationSum_39 solution, string solutionName)
        {
            // Verifies that [2,2,3] and [3,2,2] are not both returned.
            // Input: candidates = [2,3,6,7], target = 7

            // Arrange
            int[] candidates = { 2, 3, 6, 7 };
            int target = 7;

            // Act
            var result = solution.CombinationSum(candidates, target);
            var normalized = Normalize(result);

            // Assert
            var distinct = normalized.Select(c => string.Join(",", c)).Distinct().ToList();
            Assert.AreEqual(normalized.Count, distinct.Count, $"Result contains duplicate combinations [{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CombinationSum_AllCombinationsSumToTarget_SumsAreCorrect(ICombinationSum_39 solution, string solutionName)
        {
            // Verifies every returned combination actually sums to the target.
            // Input: candidates = [2,3,5], target = 8

            // Arrange
            int[] candidates = { 2, 3, 5 };
            int target = 8;

            // Act
            var result = solution.CombinationSum(candidates, target);

            // Assert
            foreach (var combo in result)
                Assert.AreEqual(target, combo.Sum(), $"Combination [{string.Join(",", combo)}] does not sum to {target} [{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CombinationSum_AllElementsFromCandidates_NoCandidatesViolated(ICombinationSum_39 solution, string solutionName)
        {
            // Verifies every number in every combination appears in the candidates array.
            // Input: candidates = [2,3,6,7], target = 7

            // Arrange
            int[] candidates = { 2, 3, 6, 7 };
            int target = 7;
            var candidateSet = new HashSet<int>(candidates);

            // Act
            var result = solution.CombinationSum(candidates, target);

            // Assert
            foreach (var combo in result)
                foreach (int num in combo)
                    Assert.IsTrue(candidateSet.Contains(num), $"Number {num} is not in candidates [{solutionName}]");
        }

        #endregion
    }
}
