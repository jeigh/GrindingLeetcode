using LeetCodeProblems.CSharp.Graph;
using LeetCodeProblems.CSharp.UnionFind;
using LeetCodeProblems.Interfaces.Medium;
using LeetCodeProblems.VisualBasic.Graph;

namespace GrindingLeetCode.UnitTests.Medium
{
    [TestClass]
    public class RedundantConnection_684_Tests
    {
        public static IEnumerable<object[]> GetImplementations()
        {
            // Uncomment as each implementation is written.
            yield return new object[] { new RedundantConnection_Solution_CycleDetection_CSharp_684(), "C# Solution" };
            yield return new object[] { new RedundantConnection_CycleDetection_Solution_VB_684(), "VB Solution" };
            //yield return new object[] { new RedundantConnection_UnionFind_CSharp_684(), "C# UnionFind" };

            yield break;
        }

        #region LeetCode Examples

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void FindRedundantConnection_Example1_ReturnsLastCycleEdge(IRedundantConnection_684 solution, string solutionName)
        {
            var result = solution.FindRedundantConnection([[1, 2], [1, 3], [2, 3]]);
            CollectionAssert.AreEqual(new[] { 2, 3 }, result, $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void FindRedundantConnection_Example2_ReturnsCycleClosingEdge(IRedundantConnection_684 solution, string solutionName)
        {
            var result = solution.FindRedundantConnection([[1, 2], [2, 3], [3, 4], [1, 4], [1, 5]]);
            CollectionAssert.AreEqual(new[] { 1, 4 }, result, $"[{solutionName}]");
        }

        #endregion

        #region Simple Cycles

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void FindRedundantConnection_TriangleCycle_ReturnsLastEdge(IRedundantConnection_684 solution, string solutionName)
        {
            var result = solution.FindRedundantConnection([[1, 2], [2, 3], [1, 3]]);
            CollectionAssert.AreEqual(new[] { 1, 3 }, result, $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void FindRedundantConnection_SquareCycle_ReturnsLastEdge(IRedundantConnection_684 solution, string solutionName)
        {
            var result = solution.FindRedundantConnection([[1, 2], [2, 3], [3, 4], [4, 1]]);
            CollectionAssert.AreEqual(new[] { 4, 1 }, result, $"[{solutionName}]");
        }

        #endregion

        #region Redundant Edge Position

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void FindRedundantConnection_RedundantEdgeInMiddle_TreeContinuesAfter(IRedundantConnection_684 solution, string solutionName)
        {
            // Cycle closes at index 2 (1-2-3), then the tree keeps extending validly
            var result = solution.FindRedundantConnection([[1, 2], [2, 3], [1, 3], [3, 4], [4, 5]]);
            CollectionAssert.AreEqual(new[] { 1, 3 }, result, $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void FindRedundantConnection_EarlyRedundantEdge_ReturnsCorrectEdge(IRedundantConnection_684 solution, string solutionName)
        {
            var result = solution.FindRedundantConnection([[1, 2], [1, 3], [2, 3], [3, 4], [4, 5], [5, 6]]);
            CollectionAssert.AreEqual(new[] { 2, 3 }, result, $"[{solutionName}]");
        }

        #endregion

        #region Branching Structures

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void FindRedundantConnection_StarShapeWithOneExtraEdge(IRedundantConnection_684 solution, string solutionName)
        {
            var result = solution.FindRedundantConnection([[1, 2], [1, 3], [1, 4], [1, 5], [2, 3]]);
            CollectionAssert.AreEqual(new[] { 2, 3 }, result, $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void FindRedundantConnection_WideBranchingWithRedundantEdge(IRedundantConnection_684 solution, string solutionName)
        {
            var result = solution.FindRedundantConnection([[1, 2], [1, 3], [1, 4], [1, 5], [1, 6], [2, 6]]);
            CollectionAssert.AreEqual(new[] { 2, 6 }, result, $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void FindRedundantConnection_RedundantEdgeConnectsTwoBranches(IRedundantConnection_684 solution, string solutionName)
        {
            var result = solution.FindRedundantConnection([[1, 2], [1, 3], [3, 4], [2, 5], [5, 4]]);
            CollectionAssert.AreEqual(new[] { 5, 4 }, result, $"[{solutionName}]");
        }

        #endregion

        #region Chains and Larger Graphs

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void FindRedundantConnection_LinearChainWithOneExtraEdge(IRedundantConnection_684 solution, string solutionName)
        {
            var result = solution.FindRedundantConnection([[1, 2], [2, 3], [3, 4], [4, 5], [5, 1]]);
            CollectionAssert.AreEqual(new[] { 5, 1 }, result, $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void FindRedundantConnection_DenseGraphWithSingleRedundantEdge(IRedundantConnection_684 solution, string solutionName)
        {
            // Two paths from 1 (via 2->4 and via 3... actually via 1->2->4 and 1->2->5) converge at 6
            var result = solution.FindRedundantConnection([[1, 2], [1, 3], [2, 4], [2, 5], [4, 6], [5, 6]]);
            CollectionAssert.AreEqual(new[] { 5, 6 }, result, $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void FindRedundantConnection_LargerGraphStressTest(IRedundantConnection_684 solution, string solutionName)
        {
            // Chain 1-2-3-4-5-6-7-8, plus an edge back to node 3 closing a loop
            var result = solution.FindRedundantConnection([[1, 2], [2, 3], [3, 4], [4, 5], [5, 6], [6, 7], [7, 8], [8, 3]]);
            CollectionAssert.AreEqual(new[] { 8, 3 }, result, $"[{solutionName}]");
        }

        #endregion

        #region Multiple Components Merging

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void FindRedundantConnection_LegitimateMergeAfterRedundantEdge_DoesNotOverwriteAnswer(IRedundantConnection_684 solution, string solutionName)
        {
            // Three separate components {1,2}, {3,4}, {5,6} form independently first.
            // [1,3] merges the first two into {1,2,3,4} -- a legitimate, non-redundant edge.
            // [2,4] closes a cycle within that merged component -- this is the true answer.
            // [4,5] comes after it and legitimately merges {1,2,3,4} with {5,6} -- both of its
            // endpoints have already appeared in earlier, unrelated edges, but it does NOT
            // create a cycle. A solution that only tracks "has this node appeared before"
            // instead of "which component is this node actually in" will wrongly flag [4,5]
            // (or [1,3]) as redundant instead of [2,4].
            var result = solution.FindRedundantConnection([[1, 2], [3, 4], [5, 6], [1, 3], [2, 4], [4, 5]]);
            CollectionAssert.AreEqual(new[] { 2, 4 }, result, $"[{solutionName}]");
        }

        #endregion

        #region Edge Order Sensitivity

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void FindRedundantConnection_SameTriangleDifferentEdgeOrder_ReturnsDifferentEdge(IRedundantConnection_684 solution, string solutionName)
        {
            // Same triangle as the other tests, but the edge that closes the cycle changes
            // depending on input order.
            var result = solution.FindRedundantConnection([[2, 3], [1, 3], [1, 2]]);
            CollectionAssert.AreEqual(new[] { 1, 2 }, result, $"[{solutionName}]");
        }

        #endregion
    }
}
