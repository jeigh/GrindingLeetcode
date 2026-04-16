using LeetCodeProblems.CSharp.Backtracking;
using LeetCodeProblems.Interfaces.Medium;

namespace GrindingLeetCode.UnitTests.Medium
{
    /// <summary>
    /// Unit tests for LeetCode Problem 90: Subsets II
    ///
    /// Problem Description:
    /// Given an integer array nums that may contain duplicates, return all possible
    /// subsets (the power set). The solution set must not contain duplicate subsets.
    /// Return the solution in any order.
    /// </summary>
    [TestClass]
    public class SubsetsII_90_Tests
    {
        public static IEnumerable<object[]> GetImplementations()
        {
            yield return new object[] { new SubsetsII_Backtracking_CSharp_90(), "C# Backtracking" };
            //yield return new object[] { new SubsetsII_Iterative_CSharp_90(), "C# Iterative" };
            //yield return new object[] { new SubsetsII_BitMask_CSharp_90(), "C# Bit Mask" };
        }

        // Normalizes results for order-independent comparison:
        // sorts each inner subset, then sorts the collection of subsets.
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
                    $"Subset at index {i} does not match [{solutionName}]");
            }
        }

        #region LeetCode Examples

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void SubsetsWithDup_Example1_ReturnsAllUniqueSubsets(ISubsetsII_90 solution, string solutionName)
        {
            // Input: nums = [1,2,2]
            // Output: [[],[1],[1,2],[1,2,2],[2],[2,2]]

            // Arrange
            int[] nums = [1, 2, 2];
            IList<IList<int>> expected = new List<IList<int>>
            {
                new List<int> { },
                new List<int> { 1 },
                new List<int> { 1, 2 },
                new List<int> { 1, 2, 2 },
                new List<int> { 2 },
                new List<int> { 2, 2 }
            };

            // Act
            var result = solution.SubsetsWithDup(nums);

            // Assert
            AssertSubsetsEqual(expected, result, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void SubsetsWithDup_Example2_SingleElement_ReturnsEmptyAndSelf(ISubsetsII_90 solution, string solutionName)
        {
            // Input: nums = [0]
            // Output: [[],[0]]

            // Arrange
            int[] nums = [0];
            IList<IList<int>> expected = new List<IList<int>>
            {
                new List<int> { },
                new List<int> { 0 }
            };

            // Act
            var result = solution.SubsetsWithDup(nums);

            // Assert
            AssertSubsetsEqual(expected, result, solutionName);
        }

        #endregion

        #region Duplicate Handling

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void SubsetsWithDup_AllDuplicates_ReturnsSubsetsOfCounts(ISubsetsII_90 solution, string solutionName)
        {
            // Input: nums = [2,2,2]
            // Output: [[],[2],[2,2],[2,2,2]]

            // Arrange
            int[] nums = [2, 2, 2];
            IList<IList<int>> expected = new List<IList<int>>
            {
                new List<int> { },
                new List<int> { 2 },
                new List<int> { 2, 2 },
                new List<int> { 2, 2, 2 }
            };

            // Act
            var result = solution.SubsetsWithDup(nums);

            // Assert
            AssertSubsetsEqual(expected, result, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void SubsetsWithDup_TwoPairsOfDuplicates_ReturnsCorrectSubsets(ISubsetsII_90 solution, string solutionName)
        {
            // Input: nums = [1,1,2,2]
            // Output: [[],[1],[1,1],[1,1,2],[1,1,2,2],[1,2],[1,2,2],[2],[2,2]]

            // Arrange
            int[] nums = [1, 1, 2, 2];
            IList<IList<int>> expected = new List<IList<int>>
            {
                new List<int> { },
                new List<int> { 1 },
                new List<int> { 1, 1 },
                new List<int> { 1, 1, 2 },
                new List<int> { 1, 1, 2, 2 },
                new List<int> { 1, 2 },
                new List<int> { 1, 2, 2 },
                new List<int> { 2 },
                new List<int> { 2, 2 }
            };

            // Act
            var result = solution.SubsetsWithDup(nums);

            // Assert
            AssertSubsetsEqual(expected, result, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void SubsetsWithDup_NoDuplicates_ReturnsPowerSet(ISubsetsII_90 solution, string solutionName)
        {
            // Input: nums = [1,2,3] — no duplicates, should behave like Subsets 78
            // Output: [[],[1],[2],[3],[1,2],[1,3],[2,3],[1,2,3]]

            // Arrange
            int[] nums = [1, 2, 3];
            IList<IList<int>> expected = new List<IList<int>>
            {
                new List<int> { },
                new List<int> { 1 },
                new List<int> { 2 },
                new List<int> { 3 },
                new List<int> { 1, 2 },
                new List<int> { 1, 3 },
                new List<int> { 2, 3 },
                new List<int> { 1, 2, 3 }
            };

            // Act
            var result = solution.SubsetsWithDup(nums);

            // Assert
            AssertSubsetsEqual(expected, result, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void SubsetsWithDup_UnsortedInput_ReturnsSameAsIfSorted(ISubsetsII_90 solution, string solutionName)
        {
            // Input order shouldn't matter — [2,1,2] should produce same subsets as [1,2,2]
            // Output: [[],[1],[1,2],[1,2,2],[2],[2,2]]

            // Arrange
            int[] nums = [2, 1, 2];
            IList<IList<int>> expected = new List<IList<int>>
            {
                new List<int> { },
                new List<int> { 1 },
                new List<int> { 1, 2 },
                new List<int> { 1, 2, 2 },
                new List<int> { 2 },
                new List<int> { 2, 2 }
            };

            // Act
            var result = solution.SubsetsWithDup(nums);

            // Assert
            AssertSubsetsEqual(expected, result, solutionName);
        }

        #endregion

        #region Edge Cases

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void SubsetsWithDup_EmptyArray_ReturnsOnlyEmptySubset(ISubsetsII_90 solution, string solutionName)
        {
            // Input: nums = []
            // Output: [[]]

            // Arrange
            int[] nums = [];
            IList<IList<int>> expected = new List<IList<int>>
            {
                new List<int> { }
            };

            // Act
            var result = solution.SubsetsWithDup(nums);

            // Assert
            AssertSubsetsEqual(expected, result, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void SubsetsWithDup_NoDuplicates_CountEquals2ToThePowerN(ISubsetsII_90 solution, string solutionName)
        {
            // Without duplicates, the power set has exactly 2^n subsets.
            // Input: nums = [1,2,3,4] — 4 distinct elements
            // Expected count: 2^4 = 16

            // Arrange
            int[] nums = [1, 2, 3, 4];

            // Act
            var result = solution.SubsetsWithDup(nums);

            // Assert
            Assert.AreEqual(16, result.Count,
                $"Expected 2^4=16 subsets but got {result.Count} [{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void SubsetsWithDup_AlwaysContainsEmptySubset(ISubsetsII_90 solution, string solutionName)
        {
            // The empty subset must always be present.
            // Input: nums = [1,2,2]

            // Arrange
            int[] nums = [1, 2, 2];

            // Act
            var result = solution.SubsetsWithDup(nums);

            // Assert
            var normalized = Normalize(result);
            Assert.IsTrue(normalized.Any(s => s.Count == 0),
                $"Result does not contain the empty subset [{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void SubsetsWithDup_AlwaysContainsFullSet(ISubsetsII_90 solution, string solutionName)
        {
            // The full input (sorted) must always appear as a subset.
            // Input: nums = [1,2,2]

            // Arrange
            int[] nums = [1, 2, 2];
            var expectedFull = nums.OrderBy(x => x).ToList();

            // Act
            var result = solution.SubsetsWithDup(nums);

            // Assert
            var normalized = Normalize(result);
            Assert.IsTrue(normalized.Any(s => s.SequenceEqual(expectedFull)),
                $"Result does not contain the full set [{string.Join(",", expectedFull)}] [{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void SubsetsWithDup_NoDuplicateSubsetsInResult(ISubsetsII_90 solution, string solutionName)
        {
            // No two subsets in the result should be identical.
            // Input: nums = [1,2,2]

            // Arrange
            int[] nums = [1, 2, 2];

            // Act
            var result = solution.SubsetsWithDup(nums);
            var normalized = Normalize(result);

            // Assert
            var distinct = normalized.Select(s => string.Join(",", s)).Distinct().ToList();
            Assert.AreEqual(normalized.Count, distinct.Count,
                $"Result contains duplicate subsets [{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void SubsetsWithDup_NegativeNumbers_HandledCorrectly(ISubsetsII_90 solution, string solutionName)
        {
            // Input: nums = [-1,-1,0]
            // Output: [[],[-1],[-1,-1],[-1,-1,0],[-1,0],[0]]

            // Arrange
            int[] nums = [-1, -1, 0];
            IList<IList<int>> expected = new List<IList<int>>
            {
                new List<int> { },
                new List<int> { -1 },
                new List<int> { -1, -1 },
                new List<int> { -1, -1, 0 },
                new List<int> { -1, 0 },
                new List<int> { 0 }
            };

            // Act
            var result = solution.SubsetsWithDup(nums);

            // Assert
            AssertSubsetsEqual(expected, result, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void SubsetsWithDup_FourElementsWithOneDuplicate_ReturnsCorrectCount(ISubsetsII_90 solution, string solutionName)
        {
            // Input: nums = [1,2,2,3]
            // Output: [[],[1],[1,2],[1,2,2],[1,2,2,3],[1,2,3],[1,3],[2],[2,2],[2,2,3],[2,3],[3]]
            // Count: 12

            // Arrange
            int[] nums = [1, 2, 2, 3];
            IList<IList<int>> expected = new List<IList<int>>
            {
                new List<int> { },
                new List<int> { 1 },
                new List<int> { 1, 2 },
                new List<int> { 1, 2, 2 },
                new List<int> { 1, 2, 2, 3 },
                new List<int> { 1, 2, 3 },
                new List<int> { 1, 3 },
                new List<int> { 2 },
                new List<int> { 2, 2 },
                new List<int> { 2, 2, 3 },
                new List<int> { 2, 3 },
                new List<int> { 3 }
            };

            // Act
            var result = solution.SubsetsWithDup(nums);

            // Assert
            AssertSubsetsEqual(expected, result, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void SubsetsWithDup_AllSameElement_CountEqualsNPlusOne(ISubsetsII_90 solution, string solutionName)
        {
            // When all elements are identical, there are exactly n+1 subsets
            // (one for each possible count from 0 to n).
            // Input: nums = [5,5,5,5] — 4 identical elements
            // Expected count: 5

            // Arrange
            int[] nums = [5, 5, 5, 5];

            // Act
            var result = solution.SubsetsWithDup(nums);

            // Assert
            Assert.AreEqual(5, result.Count,
                $"Expected 5 subsets for 4 identical elements but got {result.Count} [{solutionName}]");
        }

        #endregion
    }
}
