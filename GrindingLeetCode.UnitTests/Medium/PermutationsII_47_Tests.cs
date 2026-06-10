using LeetCodeProblems.CSharp.Backtracking;
using LeetCodeProblems.Interfaces.Medium;
using LeetCodeProblems.VisualBasic.Backtracking;

namespace GrindingLeetCode.UnitTests.Medium
{
    /// <summary>
    /// Unit tests for LeetCode Problem 47: Permutations II
    ///
    /// Problem Description:
    /// Given a collection of numbers, nums, that might contain duplicates,
    /// return all possible unique permutations in any order.
    /// </summary>
    [TestClass]
    public class PermutationsII_47_Tests
    {
        public static IEnumerable<object[]> GetImplementations()
        {
            yield return new object[] { new PermutationsII_Backtracking_CSharp_47(), "C# Backtracking" };
            yield return new object[] { new PermutationsII_Backtracking_VB_47(), "VB Backtracking" };
            yield break;
        }

        // Sorts the outer collection for order-independent comparison.
        // Inner permutation order is preserved — [1,2,1] and [1,1,2] are distinct.
        private static List<List<int>> Normalize(IList<IList<int>> result)
        {
            return result
                .Select(perm => perm.ToList())
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
        public void Permute_Example1_ReturnsUniquePermutations(IPermutationsII_47 solution, string solutionName)
        {
            // Input: nums = [1,1,2]
            // Output: [[1,1,2],[1,2,1],[2,1,1]]

            // Arrange
            int[] nums = [1, 1, 2];
            IList<IList<int>> expected = new List<IList<int>>
            {
                new List<int> { 1, 1, 2 },
                new List<int> { 1, 2, 1 },
                new List<int> { 2, 1, 1 }
            };

            // Act
            var result = solution.Permute(nums);

            // Assert
            AssertPermutationsEqual(expected, result, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Permute_Example2_DistinctInputReturnsAllPermutations(IPermutationsII_47 solution, string solutionName)
        {
            // Input: nums = [1,2,3] (no duplicates — same as #46)
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

        #endregion

        #region Edge Cases

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Permute_SingleElement_ReturnsSinglePermutation(IPermutationsII_47 solution, string solutionName)
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

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Permute_TwoIdenticalElements_ReturnsSinglePermutation(IPermutationsII_47 solution, string solutionName)
        {
            // Input: nums = [2,2]
            // Output: [[2,2]]

            // Arrange
            int[] nums = [2, 2];
            IList<IList<int>> expected = new List<IList<int>>
            {
                new List<int> { 2, 2 }
            };

            // Act
            var result = solution.Permute(nums);

            // Assert
            AssertPermutationsEqual(expected, result, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Permute_AllSameElements_ReturnsSinglePermutation(IPermutationsII_47 solution, string solutionName)
        {
            // Input: nums = [1,1,1]
            // Output: [[1,1,1]]   (3!/3! = 1)

            // Arrange
            int[] nums = [1, 1, 1];
            IList<IList<int>> expected = new List<IList<int>>
            {
                new List<int> { 1, 1, 1 }
            };

            // Act
            var result = solution.Permute(nums);

            // Assert
            AssertPermutationsEqual(expected, result, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Permute_AllSameFourElements_ReturnsSinglePermutation(IPermutationsII_47 solution, string solutionName)
        {
            // Input: nums = [5,5,5,5]
            // Output: [[5,5,5,5]]   (4!/4! = 1)

            // Arrange
            int[] nums = [5, 5, 5, 5];

            // Act
            var result = solution.Permute(nums);

            // Assert
            Assert.AreEqual(1, result.Count, $"Expected 1 unique permutation [{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Permute_NegativeNumbersWithDuplicates_ReturnsUniquePermutations(IPermutationsII_47 solution, string solutionName)
        {
            // Input: nums = [-1,-1,0]
            // Output: [[-1,-1,0],[-1,0,-1],[0,-1,-1]]   (3!/2! = 3)

            // Arrange
            int[] nums = [-1, -1, 0];
            IList<IList<int>> expected = new List<IList<int>>
            {
                new List<int> { -1, -1, 0 },
                new List<int> { -1, 0, -1 },
                new List<int> { 0, -1, -1 }
            };

            // Act
            var result = solution.Permute(nums);

            // Assert
            AssertPermutationsEqual(expected, result, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Permute_ZerosWithDuplicate_ReturnsUniquePermutations(IPermutationsII_47 solution, string solutionName)
        {
            // Input: nums = [0,0,1]
            // Output: [[0,0,1],[0,1,0],[1,0,0]]   (3!/2! = 3)

            // Arrange
            int[] nums = [0, 0, 1];
            IList<IList<int>> expected = new List<IList<int>>
            {
                new List<int> { 0, 0, 1 },
                new List<int> { 0, 1, 0 },
                new List<int> { 1, 0, 0 }
            };

            // Act
            var result = solution.Permute(nums);

            // Assert
            AssertPermutationsEqual(expected, result, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Permute_TwoPairsOfDuplicates_ReturnsSixPermutations(IPermutationsII_47 solution, string solutionName)
        {
            // Input: nums = [1,1,2,2]
            // 4!/(2!*2!) = 6 unique permutations

            // Arrange
            int[] nums = [1, 1, 2, 2];

            // Act
            var result = solution.Permute(nums);

            // Assert
            Assert.AreEqual(6, result.Count, $"Expected 6 unique permutations for [1,1,2,2] [{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Permute_OneDuplicateInFourElements_ReturnsTwelvePermutations(IPermutationsII_47 solution, string solutionName)
        {
            // Input: nums = [1,1,2,3]
            // 4!/2! = 12 unique permutations

            // Arrange
            int[] nums = [1, 1, 2, 3];

            // Act
            var result = solution.Permute(nums);

            // Assert
            Assert.AreEqual(12, result.Count, $"Expected 12 unique permutations for [1,1,2,3] [{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Permute_NoDuplicatePermutations(IPermutationsII_47 solution, string solutionName)
        {
            // No two permutations in the result should be identical.
            // Input: nums = [1,1,2]

            // Arrange
            int[] nums = [1, 1, 2];

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
        public void Permute_NoDuplicatePermutations_LargerInput(IPermutationsII_47 solution, string solutionName)
        {
            // Input: nums = [1,1,2,2]

            // Arrange
            int[] nums = [1, 1, 2, 2];

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
        public void Permute_AllPermutationsHaveCorrectLength(IPermutationsII_47 solution, string solutionName)
        {
            // Every returned permutation must have the same length as the input.
            // Input: nums = [1,1,2]

            // Arrange
            int[] nums = [1, 1, 2];

            // Act
            var result = solution.Permute(nums);

            // Assert
            foreach (var perm in result)
                Assert.AreEqual(nums.Length, perm.Count,
                    $"Permutation [{string.Join(",", perm)}] has wrong length [{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Permute_AllPermutationsContainAllOriginalElements(IPermutationsII_47 solution, string solutionName)
        {
            // Every permutation must contain exactly the same multiset of elements as the input.
            // Input: nums = [1,1,2]

            // Arrange
            int[] nums = [1, 1, 2];
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
        public void Permute_InputOrderDoesNotAffectResult(IPermutationsII_47 solution, string solutionName)
        {
            // [1,2,1] and [1,1,2] describe the same multiset — both should produce 3 unique permutations.

            // Arrange
            int[] numsA = [1, 2, 1];
            int[] numsB = [1, 1, 2];

            // Act
            var resultA = solution.Permute(numsA);
            var resultB = solution.Permute(numsB);

            // Assert
            AssertPermutationsEqual(resultA, resultB, solutionName);
        }

        #endregion
    }
}
