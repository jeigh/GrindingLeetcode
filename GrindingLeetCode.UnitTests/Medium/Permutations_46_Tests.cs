using LeetCodeProblems.CSharp.Backtracking;
using LeetCodeProblems.Interfaces.Medium;
using LeetCodeProblems.VisualBasic.Backtracking;

namespace GrindingLeetCode.UnitTests.Medium
{
    /// <summary>
    /// Unit tests for LeetCode Problem 46: Permutations
    ///
    /// Problem Description:
    /// Given an array nums of distinct integers, return all the possible
    /// permutations. You can return the answer in any order.
    /// </summary>
    [TestClass]
    public class Permutations_46_Tests
    {
        public static IEnumerable<object[]> GetImplementations()
        {
            yield return new object[] { new Permutations_Recursive_CSharp_46(), "C# Backtracking" };
            yield return new object[] { new Permutations_Iterative_CSharp_46(), "C# Iterative" };
            yield return new object[] { new Permutations_BacktrackingOptimized_CSharp_46(), "C# Optimized" };
            yield return new object[] { new Permutations_LinqQuery_CSharp_46(), "C# LINQ Query" };

            yield return new object[] { new Permutations_Recursive_VB_46(), "VB Recursive" };
            yield return new object[] { new Permutations_Iterative_VB_46(), "VB Iterative" };
            yield return new object[] { new Permutations_BacktrackingOptimized_VB_46(), "VB Optimized" };
            yield return new object[] { new Permutations_LinqQuery_VB_46(), "VB LINQ Query" };
        }

        // Normalizes results for order-independent comparison:
        // sorts each inner permutation, then sorts the collection of permutations.
        private static List<List<int>> Normalize(IList<IList<int>> result)
        {
            return result
                .Select(perm => perm.OrderBy(x => x).ToList())
                .OrderBy(perm => string.Join(",", perm))
                .ToList();
        }

        private static void AssertPermutationsEqual(
            IList<IList<int>> expected,
            IList<IList<int>> actual,
            string solutionName)
        {
            var normalizedExpected = Normalize(expected);
            var normalizedActual = Normalize(actual);

            Assert.AreEqual(
                normalizedExpected.Count,
                normalizedActual.Count,
                $"Expected {normalizedExpected.Count} permutations but got {normalizedActual.Count} [{solutionName}]");

            for (int i = 0; i < normalizedExpected.Count; i++)
            {
                CollectionAssert.AreEqual(
                    normalizedExpected[i],
                    normalizedActual[i],
                    $"Permutation at index {i} does not match [{solutionName}]");
            }
        }

        #region LeetCode Examples

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Permute_Example1_ReturnsAllPermutations(IPermutations_46 solution, string solutionName)
        {
            // Input: nums = [1,2,3]
            // Output: [[1,2,3],[1,3,2],[2,1,3],[2,3,1],[3,1,2],[3,2,1]]

            // Arrange
            int[] nums = [1, 2, 3];
            IList<IList<int>> expected = new List<IList<int>>
            {
                new List<int> { 1, 2, 3 },
                new List<int> { 1, 3, 2 },
                new List<int> { 2, 1, 3 },
                new List<int> { 2, 3, 1 },
                new List<int> { 3, 1, 2 },
                new List<int> { 3, 2, 1 }
            };

            // Act
            var result = solution.Permute(nums);

            // Assert
            AssertPermutationsEqual(expected, result, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Permute_Example2_ReturnsSingleSwapPermutations(IPermutations_46 solution, string solutionName)
        {
            // Input: nums = [0,1]
            // Output: [[0,1],[1,0]]

            // Arrange
            int[] nums = [0, 1];
            IList<IList<int>> expected = new List<IList<int>>
            {
                new List<int> { 0, 1 },
                new List<int> { 1, 0 }
            };

            // Act
            var result = solution.Permute(nums);

            // Assert
            AssertPermutationsEqual(expected, result, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Permute_Example3_ReturnsSingleElement(IPermutations_46 solution, string solutionName)
        {
            // Input: nums = [1]
            // Output: [[1]]

            // Arrange
            int[] nums = [1];
            IList<IList<int>> expected = new List<IList<int>>
            {
                new List<int> { 1 }
            };

            // Act
            var result = solution.Permute(nums);

            // Assert
            AssertPermutationsEqual(expected, result, solutionName);
        }

        #endregion

        #region Edge Cases

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Permute_ResultCount_MatchesFactorial(IPermutations_46 solution, string solutionName)
        {
            // 4! = 24
            // Input: nums = [1,2,3,4]

            // Arrange
            int[] nums = [1, 2, 3, 4];

            // Act
            var result = solution.Permute(nums);

            // Assert
            Assert.AreEqual(24, result.Count,
                $"Expected 4!=24 permutations but got {result.Count} [{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Permute_AllPermutationsHaveCorrectLength(IPermutations_46 solution, string solutionName)
        {
            // Every returned permutation must have the same length as the input.
            // Input: nums = [1,2,3]

            // Arrange
            int[] nums = [1, 2, 3];

            // Act
            var result = solution.Permute(nums);

            // Assert
            foreach (var perm in result)
                Assert.AreEqual(nums.Length, perm.Count,
                    $"Permutation [{string.Join(",", perm)}] has {perm.Count} elements, expected {nums.Length} [{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Permute_AllPermutationsContainAllOriginalElements(IPermutations_46 solution, string solutionName)
        {
            // Every permutation must contain exactly the same elements as the input.
            // Input: nums = [1,2,3]

            // Arrange
            int[] nums = [1, 2, 3];
            var sortedNums = nums.OrderBy(x => x).ToList();

            // Act
            var result = solution.Permute(nums);

            // Assert
            foreach (var perm in result)
            {
                var sortedPerm = perm.OrderBy(x => x).ToList();
                CollectionAssert.AreEqual(sortedNums, sortedPerm,
                    $"Permutation [{string.Join(",", perm)}] does not contain the original elements [{solutionName}]");
            }
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Permute_NoDuplicatePermutations(IPermutations_46 solution, string solutionName)
        {
            // No two permutations in the result should be identical.
            // Input: nums = [1,2,3,4]

            // Arrange
            int[] nums = [1, 2, 3, 4];

            // Act
            var result = solution.Permute(nums);

            // Assert
            var asStrings = result.Select(p => string.Join(",", p)).ToList();
            var distinct = asStrings.Distinct().ToList();
            Assert.AreEqual(asStrings.Count, distinct.Count,
                $"Result contains duplicate permutations [{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Permute_NegativeNumbers_ReturnsAllPermutations(IPermutations_46 solution, string solutionName)
        {
            // Input: nums = [-1,0,1]
            // Output: [[-1,0,1],[-1,1,0],[0,-1,1],[0,1,-1],[1,-1,0],[1,0,-1]]

            // Arrange
            int[] nums = [-1, 0, 1];
            IList<IList<int>> expected = new List<IList<int>>
            {
                new List<int> { -1, 0, 1 },
                new List<int> { -1, 1, 0 },
                new List<int> { 0, -1, 1 },
                new List<int> { 0, 1, -1 },
                new List<int> { 1, -1, 0 },
                new List<int> { 1, 0, -1 }
            };

            // Act
            var result = solution.Permute(nums);

            // Assert
            AssertPermutationsEqual(expected, result, solutionName);
        }

        #endregion
    }
}
