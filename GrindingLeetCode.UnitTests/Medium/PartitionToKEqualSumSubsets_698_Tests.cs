using LeetCodeProblems.CSharp.Backtracking;
using LeetCodeProblems.Interfaces.Medium;
using LeetCodeProblems.VisualBasic.Backtracking;

namespace GrindingLeetCode.UnitTests.Medium
{
    [TestClass]
    public class PartitionToKEqualSumSubsets_698_Tests
    {
        public static IEnumerable<object[]> GetImplementations()
        {
            yield return new object[] { new PartitionToKEqualSumSubsets_Backtracking_CSharp_698(), "C# Backtracking" };
            yield return new object[] { new PartitionToKEqualSumSubsets_Backtracking_VB_698(), "VB Backtracking" };
        }

        #region LeetCode Examples

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CanPartitionKSubsets_Example1_ReturnsTrue(IPartitionToKEqualSumSubsets_698 solution, string solutionName)
        {
            // Input: nums = [4,3,2,3,5,2,1], k = 4
            // Output: true — [5],[1,4],[2,3],[2,3]
            Assert.IsTrue(solution.CanPartitionKSubsets(new[] { 4, 3, 2, 3, 5, 2, 1 }, 4), $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CanPartitionKSubsets_Example2_ReturnsFalse(IPartitionToKEqualSumSubsets_698 solution, string solutionName)
        {
            // Input: nums = [1,2,3,4], k = 3
            // Output: false — sum=10 not divisible by 3
            Assert.IsFalse(solution.CanPartitionKSubsets(new[] { 1, 2, 3, 4 }, 3), $"[{solutionName}]");
        }

        #endregion

        #region Sum Divisibility

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CanPartitionKSubsets_SumNotDivisibleByK_ReturnsFalse(IPartitionToKEqualSumSubsets_698 solution, string solutionName)
        {
            // sum=7, k=3 — not divisible
            Assert.IsFalse(solution.CanPartitionKSubsets(new[] { 1, 2, 4 }, 3), $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CanPartitionKSubsets_SumDivisibleByK_ReturnsTrue(IPartitionToKEqualSumSubsets_698 solution, string solutionName)
        {
            // sum=12, k=3, target=4: [1,3],[4],[2,2] — wait [2,2] sums to 4 ✓
            Assert.IsTrue(solution.CanPartitionKSubsets(new[] { 1, 2, 2, 3, 4 }, 3), $"[{solutionName}]");
        }

        #endregion

        #region Element Exceeds Target

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CanPartitionKSubsets_ElementExceedsTarget_ReturnsFalse(IPartitionToKEqualSumSubsets_698 solution, string solutionName)
        {
            // sum=12, k=3, target=4, but 5 > 4
            Assert.IsFalse(solution.CanPartitionKSubsets(new[] { 5, 2, 2, 3 }, 3), $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CanPartitionKSubsets_ElementEqualsTarget_ReturnsTrue(IPartitionToKEqualSumSubsets_698 solution, string solutionName)
        {
            // Each element is exactly the target — [4],[4],[4]
            Assert.IsTrue(solution.CanPartitionKSubsets(new[] { 4, 4, 4 }, 3), $"[{solutionName}]");
        }

        #endregion

        #region K = 1

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CanPartitionKSubsets_KEquals1_AlwaysTrue(IPartitionToKEqualSumSubsets_698 solution, string solutionName)
        {
            // k=1 means the whole array is one subset — always true
            Assert.IsTrue(solution.CanPartitionKSubsets(new[] { 3, 1, 4, 1, 5 }, 1), $"[{solutionName}]");
        }

        #endregion

        #region K = n

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CanPartitionKSubsets_KEqualsN_AllEqual_ReturnsTrue(IPartitionToKEqualSumSubsets_698 solution, string solutionName)
        {
            // Each element is its own subset — valid only if all elements are equal
            Assert.IsTrue(solution.CanPartitionKSubsets(new[] { 2, 2, 2, 2 }, 4), $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CanPartitionKSubsets_KEqualsN_NotAllEqual_ReturnsFalse(IPartitionToKEqualSumSubsets_698 solution, string solutionName)
        {
            Assert.IsFalse(solution.CanPartitionKSubsets(new[] { 1, 2, 3, 4 }, 4), $"[{solutionName}]");
        }

        #endregion

        #region All Elements Equal

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CanPartitionKSubsets_AllEqual_KDividesN_ReturnsTrue(IPartitionToKEqualSumSubsets_698 solution, string solutionName)
        {
            // 6 elements of value 3, k=3 — two per subset
            Assert.IsTrue(solution.CanPartitionKSubsets(new[] { 3, 3, 3, 3, 3, 3 }, 3), $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CanPartitionKSubsets_AllEqual_KDoesNotDivideN_ReturnsFalse(IPartitionToKEqualSumSubsets_698 solution, string solutionName)
        {
            // 5 elements of value 2, k=3 — sum=10 not divisible by 3
            Assert.IsFalse(solution.CanPartitionKSubsets(new[] { 2, 2, 2, 2, 2 }, 3), $"[{solutionName}]");
        }

        #endregion

        #region Requires Backtracking

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CanPartitionKSubsets_RequiresBacktracking_ReturnsTrue(IPartitionToKEqualSumSubsets_698 solution, string solutionName)
        {
            // Greedy fails here — must backtrack to find valid partition
            // [3,3,3,3], k=2: [3,3],[3,3] — target=6
            Assert.IsTrue(solution.CanPartitionKSubsets(new[] { 3, 3, 3, 3 }, 2), $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CanPartitionKSubsets_LargerInput_ReturnsTrue(IPartitionToKEqualSumSubsets_698 solution, string solutionName)
        {
            // sum=20, k=4, target=5: [5],[1,4],[2,3],[2,3]
            Assert.IsTrue(solution.CanPartitionKSubsets(new[] { 1, 2, 3, 4, 5, 2, 3 }, 4), $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CanPartitionKSubsets_NoPossiblePartition_ReturnsFalse(IPartitionToKEqualSumSubsets_698 solution, string solutionName)
        {
            // sum=12, k=4, target=3, but [5] alone exceeds target
            Assert.IsFalse(solution.CanPartitionKSubsets(new[] { 5, 4, 2, 1 }, 4), $"[{solutionName}]");
        }

        #endregion

        #region Generalisation from Matchsticks (k=4)

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CanPartitionKSubsets_K4_MatchsticksExample1_ReturnsTrue(IPartitionToKEqualSumSubsets_698 solution, string solutionName)
        {
            // Same as Matchsticks example 1
            Assert.IsTrue(solution.CanPartitionKSubsets(new[] { 1, 1, 2, 2, 2 }, 4), $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CanPartitionKSubsets_K4_MatchsticksExample2_ReturnsFalse(IPartitionToKEqualSumSubsets_698 solution, string solutionName)
        {
            // Same as Matchsticks example 2
            Assert.IsFalse(solution.CanPartitionKSubsets(new[] { 3, 3, 3, 3, 4 }, 4), $"[{solutionName}]");
        }

        #endregion

        #region K = 2

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CanPartitionKSubsets_K2_EvenSplit_ReturnsTrue(IPartitionToKEqualSumSubsets_698 solution, string solutionName)
        {
            // sum=10, k=2, target=5: [1,4],[2,3]
            Assert.IsTrue(solution.CanPartitionKSubsets(new[] { 1, 2, 3, 4 }, 2), $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CanPartitionKSubsets_K2_NoEvenSplit_ReturnsFalse(IPartitionToKEqualSumSubsets_698 solution, string solutionName)
        {
            // sum=10, k=2, target=5, but only way is [5] and [1,2,2] — wait [1,2,2]=5 ✓
            // Use [1,1,5,5] instead: sum=12, target=6, but [5,1],[5,1] works...
            // [1,1,1,1,5], sum=9 not div by 2
            Assert.IsFalse(solution.CanPartitionKSubsets(new[] { 1, 1, 1, 1, 5 }, 2), $"[{solutionName}]");
        }

        #endregion
    }
}
