using LeetCodeProblems.CSharp.Backtracking;
using LeetCodeProblems.CSharp.BruteForce;
using LeetCodeProblems.Interfaces.Medium;
using LeetCodeProblems.VisualBasic.Backtracking;

namespace GrindingLeetCode.UnitTests.Medium
{
    /// <summary>
    /// Unit tests for LeetCode Problem 78: Subsets
    ///
    /// Problem Description:
    /// Given an integer array nums of unique elements, return all possible subsets
    /// (the power set). The solution set must not contain duplicate subsets.
    /// </summary>
    [TestClass]
    public class Subsets_78_Tests
    {
        public static IEnumerable<object[]> GetImplementations()
        {
            yield return new object[] { new Subsets_CSharp_Recursive_78(), "C# Recursive Implementation" };
            yield return new object[] { new Subsets_CSharp_Iterative_78(), "C# Iterative Implementation" };
            yield return new object[] { new Subsets_CSharp_ForLoop_78(), "C# ForLoops Implementation" };

            yield return new object[] { new Subsets_VB_Recursive_78(), "VB Recursive Implementation" };
            yield return new object[] { new Subsets_VB_Iterative_78(), "VB Iterative Implementation" };
            yield return new object[] { new Subsets_VB_ForLoop_78(), "VB ForLoops Implementation" };
        }

        // Normalizes a result for order-independent comparison:
        // sorts each inner list, then sorts the collection of inner lists.
        private static List<List<int>> Normalize(IList<IList<int>> result)
        {
            return result
                .Select(subset => subset.OrderBy(x => x).ToList())
                .OrderBy(subset => subset.Count)
                .ThenBy(subset => string.Join(",", subset))
                .ToList();
        }

        private static void AssertSubsetsEqual(
            IList<IList<int>> expected,
            IList<IList<int>> actual,
            string solutionName)
        {
            var normalizedExpected = Normalize(expected);
            var normalizedActual = Normalize(actual);

            Assert.AreEqual(
                normalizedExpected.Count,
                normalizedActual.Count,
                $"Expected {normalizedExpected.Count} subsets but got {normalizedActual.Count} [{solutionName}]");

            for (int i = 0; i < normalizedExpected.Count; i++)
            {
                CollectionAssert.AreEqual(
                    normalizedExpected[i],
                    normalizedActual[i],
                    $"Subset at position {i} did not match [{solutionName}]");
            }
        }

        #region LeetCode Examples

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Subsets_Example1_ReturnsAllSubsets(ISubsets_78 solution, string solutionName)
        {
            // Input: nums = [1,2,3]
            // Output: [[],[1],[2],[3],[1,2],[1,3],[2,3],[1,2,3]]
            int[] nums = [1, 2, 3];
            IList<IList<int>> expected = [[], [1], [2], [3], [1, 2], [1, 3], [2, 3], [1, 2, 3]];

            IList<IList<int>> result = solution.Subsets(nums);

            AssertSubsetsEqual(expected, result, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Subsets_Example2_ReturnsBothSubsets(ISubsets_78 solution, string solutionName)
        {
            // Input: nums = [0]
            // Output: [[],[0]]
            int[] nums = [0];
            IList<IList<int>> expected = [[], [0]];

            IList<IList<int>> result = solution.Subsets(nums);

            AssertSubsetsEqual(expected, result, solutionName);
        }

        #endregion

        #region Edge Cases

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Subsets_TwoElements_ReturnsFourSubsets(ISubsets_78 solution, string solutionName)
        {
            // nums = [1,2] -> [], [1], [2], [1,2]
            int[] nums = [1, 2];
            IList<IList<int>> expected = [[], [1], [2], [1, 2]];

            IList<IList<int>> result = solution.Subsets(nums);

            AssertSubsetsEqual(expected, result, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Subsets_ResultCount_IsPowerOfTwo(ISubsets_78 solution, string solutionName)
        {
            // For n elements the power set always has exactly 2^n subsets.
            int[] nums = [1, 2, 3, 4];

            IList<IList<int>> result = solution.Subsets(nums);

            Assert.AreEqual(16, result.Count,
                $"Expected 2^4=16 subsets for 4 elements [{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Subsets_AlwaysContainsEmptySubset(ISubsets_78 solution, string solutionName)
        {
            // The empty subset must always be present.
            int[] nums = [5, 10, 15];

            IList<IList<int>> result = solution.Subsets(nums);

            bool containsEmpty = result.Any(subset => subset.Count == 0);
            Assert.IsTrue(containsEmpty,
                $"Expected result to contain the empty subset [{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Subsets_AlwaysContainsFullSet(ISubsets_78 solution, string solutionName)
        {
            // The full input array must always appear as a subset.
            int[] nums = [5, 10, 15];

            IList<IList<int>> result = solution.Subsets(nums);

            bool containsFull = result.Any(subset =>
                subset.OrderBy(x => x).SequenceEqual(nums.OrderBy(x => x)));
            Assert.IsTrue(containsFull,
                $"Expected result to contain the full set [{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Subsets_NoDuplicateSubsets(ISubsets_78 solution, string solutionName)
        {
            // Each subset must appear exactly once.
            int[] nums = [1, 2, 3];

            IList<IList<int>> result = solution.Subsets(nums);

            var normalized = result
                .Select(subset => string.Join(",", subset.OrderBy(x => x)))
                .ToList();
            var distinct = normalized.Distinct().ToList();

            Assert.AreEqual(normalized.Count, distinct.Count,
                $"Result contains duplicate subsets [{solutionName}]");
        }

        #endregion
    }
}
