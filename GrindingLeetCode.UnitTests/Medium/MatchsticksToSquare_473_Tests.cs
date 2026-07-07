using LeetCodeProblems.CSharp.Backtracking;
using LeetCodeProblems.Interfaces.Medium;
using LeetCodeProblems.VisualBasic.Backtracking;

namespace GrindingLeetCode.UnitTests.Medium
{
    [TestClass]
    public class MatchsticksToSquare_473_Tests
    {
        public static IEnumerable<object[]> GetImplementations()
        {
            yield return new object[] { new MatchsticksToSquare_Backtracking_CSharp_473(), "C# Backtracking" };
            yield return new object[] { new MatchsticksToSquare_BacktrackingII_CSharp_473(), "C# Backtracking II" };
            yield return new object[] { new MatchsticksToSquare_BacktrackingIII_CSharp_473(), "C# Backtracking III" };
            yield return new object[] { new MatchsticksToSquare_BacktrackingIV_CSharp_473(), "C# Backtracking IV" };
            yield return new object[] { new MatchsticksToSquare_BacktrackingOptimized_CSharp_473(), "C# Backtracking Optimized" };

            yield return new object[] { new MatchsticksToSquare_Backtracking_VB_473(), "VB Backtracking" };
            yield return new object[] { new MatchsticksToSquare_BacktrackingIII_VB_473(), "VB Backtracking III" };
        }

        #region LeetCode Examples

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Makesquare_Example1_ReturnsTrue(IMatchsticksToSquare_473 solution, string solutionName)
        {
            // Input: [1,1,2,2,2] — sides: [2],[2],[2],[1,1]
            Assert.IsTrue(solution.Makesquare(new[] { 1, 1, 2, 2, 2 }), $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Makesquare_Example2_ReturnsFalse(IMatchsticksToSquare_473 solution, string solutionName)
        {
            // Input: [3,3,3,3,4] — sum=16, side=4, but 4 can't pair with any 3 to reach 4
            Assert.IsFalse(solution.Makesquare(new[] { 3, 3, 3, 3, 4 }), $"[{solutionName}]");
        }

        #endregion

        #region Sum Divisibility

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Makesquare_SumNotDivisibleBy4_ReturnsFalse(IMatchsticksToSquare_473 solution, string solutionName)
        {
            // sum = 10, not divisible by 4
            Assert.IsFalse(solution.Makesquare(new[] { 1, 2, 3, 4 }), $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Makesquare_SumNotDivisibleBy4_ThreeSticks_ReturnsFalse(IMatchsticksToSquare_473 solution, string solutionName)
        {
            // sum = 6, not divisible by 4
            Assert.IsFalse(solution.Makesquare(new[] { 1, 2, 3 }), $"[{solutionName}]");
        }

        #endregion

        #region Too Few Sticks

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Makesquare_OneStick_ReturnsFalse(IMatchsticksToSquare_473 solution, string solutionName)
        {
            Assert.IsFalse(solution.Makesquare(new[] { 4 }), $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Makesquare_ThreeSticks_ReturnsFalse(IMatchsticksToSquare_473 solution, string solutionName)
        {
            // Can't form 4 sides with only 3 sticks
            Assert.IsFalse(solution.Makesquare(new[] { 2, 2, 2 }), $"[{solutionName}]");
        }

        #endregion

        #region Stick Exceeds Side Length

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Makesquare_StickExceedsSideLength_ReturnsFalse(IMatchsticksToSquare_473 solution, string solutionName)
        {
            // sum=8, side=2, but one stick is 5 > 2
            Assert.IsFalse(solution.Makesquare(new[] { 5, 1, 1, 1 }), $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Makesquare_StickEqualsSideLength_ReturnsTrue(IMatchsticksToSquare_473 solution, string solutionName)
        {
            // sum=12, side=3, [3],[3],[3],[3] — each stick is exactly one side
            Assert.IsTrue(solution.Makesquare(new[] { 3, 3, 3, 3 }), $"[{solutionName}]");
        }

        #endregion

        #region Simple True Cases

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Makesquare_FourEqualSticks_ReturnsTrue(IMatchsticksToSquare_473 solution, string solutionName)
        {
            Assert.IsTrue(solution.Makesquare(new[] { 1, 1, 1, 1 }), $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Makesquare_EightEqualSticks_ReturnsTrue(IMatchsticksToSquare_473 solution, string solutionName)
        {
            // sum=8, side=2, pairs of 1s on each side
            Assert.IsTrue(solution.Makesquare(new[] { 1, 1, 1, 1, 1, 1, 1, 1 }), $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Makesquare_TwelveSticksDivisibleBy4_ReturnsTrue(IMatchsticksToSquare_473 solution, string solutionName)
        {
            // sum=24, side=6, each side [1+2+3]
            Assert.IsTrue(solution.Makesquare(new[] { 1, 2, 3, 1, 2, 3, 1, 2, 3, 1, 2, 3 }), $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Makesquare_LargeEqualSticks_ReturnsTrue(IMatchsticksToSquare_473 solution, string solutionName)
        {
            Assert.IsTrue(solution.Makesquare(new[] { 10, 10, 10, 10 }), $"[{solutionName}]");
        }

        #endregion

        #region Simple False Cases

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Makesquare_FiveSameSticks_ReturnsFalse(IMatchsticksToSquare_473 solution, string solutionName)
        {
            // sum=5, not divisible by 4
            Assert.IsFalse(solution.Makesquare(new[] { 1, 1, 1, 1, 1 }), $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Makesquare_CannotPartitionEvenly_ReturnsFalse(IMatchsticksToSquare_473 solution, string solutionName)
        {
            // sum=12, side=3, but [5] alone exceeds side length
            Assert.IsFalse(solution.Makesquare(new[] { 5, 5, 1, 1 }), $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Makesquare_ImbalancedSticks_ReturnsFalse(IMatchsticksToSquare_473 solution, string solutionName)
        {
            // sum=16, side=4, but [7] alone exceeds the side
            Assert.IsFalse(solution.Makesquare(new[] { 7, 3, 2, 2, 2 }), $"[{solutionName}]");
        }

        #endregion

        #region Mixed Cases

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Makesquare_MixedLengths_ReturnsTrue(IMatchsticksToSquare_473 solution, string solutionName)
        {
            // sum=16, side=4: [1+3],[4],[1+3],[4] — wait, only one 4 and one 3...
            // [1,1,1,1,2,2,2,2] sum=12, side=3: [1+2],[1+2],[1+2],[1+2]
            Assert.IsTrue(solution.Makesquare(new[] { 1, 1, 1, 1, 2, 2, 2, 2 }), $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Makesquare_AllPairsOfThrees_ReturnsTrue(IMatchsticksToSquare_473 solution, string solutionName)
        {
            // sum=24, side=6: [3+3],[3+3],[3+3],[3+3]
            Assert.IsTrue(solution.Makesquare(new[] { 3, 3, 3, 3, 3, 3, 3, 3 }), $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Makesquare_SumDivisibleButNoValidPartition_ReturnsFalse(IMatchsticksToSquare_473 solution, string solutionName)
        {
            // sum=8, side=2: [4] alone exceeds side length
            Assert.IsFalse(solution.Makesquare(new[] { 4, 1, 1, 1, 1 }), $"[{solutionName}]");
        }

        #endregion
    }
}
