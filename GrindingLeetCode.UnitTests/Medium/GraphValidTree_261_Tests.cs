using LeetCodeProblems.CSharp.Graph;
using LeetCodeProblems.Interfaces.Medium;
using LeetCodeProblems.VisualBasic.Graph;

namespace GrindingLeetCode.UnitTests.Medium
{
    [TestClass]
    public class GraphValidTree_261_Tests
    {
        public static IEnumerable<object[]> GetImplementations()
        {
            // Uncomment as each implementation is written.
            yield return new object[] { new GraphValidTree_Solution_CSharp_261(), "C# Solution" };
            yield return new object[] { new GraphValidTree_Solution_VB_261(), "VB Solution" };
            yield return new object[] { new GraphValidTree_Solution_NoLoop_VB_261(), "VB NoLoop Solution" };

        }

        #region LeetCode Examples

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void ValidTree_Example1_SpanningTreeShape_ReturnsTrue(IGraphValidTree_261 solution, string solutionName)
        {
            var result = solution.ValidTree(5, [[0, 1], [0, 2], [0, 3], [1, 4]]);
            Assert.IsTrue(result, $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void ValidTree_Example2_HasCycle_ReturnsFalse(IGraphValidTree_261 solution, string solutionName)
        {
            var result = solution.ValidTree(5, [[0, 1], [1, 2], [2, 3], [1, 3], [1, 4]]);
            Assert.IsFalse(result, $"[{solutionName}]");
        }

        #endregion

        #region Trivial Cases

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void ValidTree_SingleNode_NoEdges_ReturnsTrue(IGraphValidTree_261 solution, string solutionName)
        {
            var result = solution.ValidTree(1, []);
            Assert.IsTrue(result, $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void ValidTree_TwoNodes_Connected_ReturnsTrue(IGraphValidTree_261 solution, string solutionName)
        {
            var result = solution.ValidTree(2, [[0, 1]]);
            Assert.IsTrue(result, $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void ValidTree_TwoNodes_Disconnected_ReturnsFalse(IGraphValidTree_261 solution, string solutionName)
        {
            var result = solution.ValidTree(2, []);
            Assert.IsFalse(result, $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void ValidTree_ManyNodes_NoEdges_ReturnsFalse(IGraphValidTree_261 solution, string solutionName)
        {
            var result = solution.ValidTree(5, []);
            Assert.IsFalse(result, $"[{solutionName}]");
        }

        #endregion

        #region Valid Trees

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void ValidTree_LinearChain_ReturnsTrue(IGraphValidTree_261 solution, string solutionName)
        {
            // 0 - 1 - 2 - 3
            var result = solution.ValidTree(4, [[0, 1], [1, 2], [2, 3]]);
            Assert.IsTrue(result, $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void ValidTree_StarShape_ReturnsTrue(IGraphValidTree_261 solution, string solutionName)
        {
            // 0 connected to 1, 2, 3, 4
            var result = solution.ValidTree(5, [[0, 1], [0, 2], [0, 3], [0, 4]]);
            Assert.IsTrue(result, $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void ValidTree_BalancedBinaryTreeShape_ReturnsTrue(IGraphValidTree_261 solution, string solutionName)
        {
            var result = solution.ValidTree(7, [[0, 1], [0, 2], [1, 3], [1, 4], [2, 5], [2, 6]]);
            Assert.IsTrue(result, $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void ValidTree_UnorderedAndReversedEdges_ReturnsTrue(IGraphValidTree_261 solution, string solutionName)
        {
            // Same path 0-1-2-3, edges listed out of order and with endpoints reversed
            var result = solution.ValidTree(4, [[3, 2], [1, 0], [2, 1]]);
            Assert.IsTrue(result, $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void ValidTree_AsymmetricBranching_ReturnsTrue(IGraphValidTree_261 solution, string solutionName)
        {
            var result = solution.ValidTree(6, [[0, 1], [1, 2], [1, 3], [3, 4], [3, 5]]);
            Assert.IsTrue(result, $"[{solutionName}]");
        }

        #endregion

        #region Invalid - Disconnected

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void ValidTree_TwoDisconnectedComponents_ReturnsFalse(IGraphValidTree_261 solution, string solutionName)
        {
            // 0-1-2 and 3-4-5, no edge between the two chains
            var result = solution.ValidTree(6, [[0, 1], [1, 2], [3, 4], [4, 5]]);
            Assert.IsFalse(result, $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void ValidTree_OneIsolatedNode_ReturnsFalse(IGraphValidTree_261 solution, string solutionName)
        {
            // 0-1-2-3 form a valid chain, but node 4 has no edges at all
            var result = solution.ValidTree(5, [[0, 1], [1, 2], [2, 3]]);
            Assert.IsFalse(result, $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void ValidTree_ThreeDisconnectedPairs_ReturnsFalse(IGraphValidTree_261 solution, string solutionName)
        {
            var result = solution.ValidTree(6, [[0, 1], [2, 3], [4, 5]]);
            Assert.IsFalse(result, $"[{solutionName}]");
        }

        #endregion

        #region Invalid - Cycles

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void ValidTree_TriangleCycle_ReturnsFalse(IGraphValidTree_261 solution, string solutionName)
        {
            var result = solution.ValidTree(3, [[0, 1], [1, 2], [0, 2]]);
            Assert.IsFalse(result, $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void ValidTree_SingleCycleAllNodes_ReturnsFalse(IGraphValidTree_261 solution, string solutionName)
        {
            // 0-1-2-3-0, every node in one cycle
            var result = solution.ValidTree(4, [[0, 1], [1, 2], [2, 3], [3, 0]]);
            Assert.IsFalse(result, $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void ValidTree_RedundantEdgeCreatesCycle_ReturnsFalse(IGraphValidTree_261 solution, string solutionName)
        {
            // A valid spanning tree over 5 nodes plus one extra edge (2-3) closing a cycle
            var result = solution.ValidTree(5, [[0, 1], [0, 2], [0, 3], [1, 4], [2, 3]]);
            Assert.IsFalse(result, $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void ValidTree_CycleInSubgraphPlusDisconnectedNode_ReturnsFalse(IGraphValidTree_261 solution, string solutionName)
        {
            // 0-1-2 form a triangle; 3-4 is a separate, disconnected edge
            var result = solution.ValidTree(5, [[0, 1], [1, 2], [2, 0], [3, 4]]);
            Assert.IsFalse(result, $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void ValidTree_EdgeCountMatchesButGraphIsInvalid_ReturnsFalse(IGraphValidTree_261 solution, string solutionName)
        {
            // Exactly n-1 = 5 edges for n=6, but it's actually two disconnected
            // components, one of which (0-1-2) contains a redundant edge/cycle.
            var result = solution.ValidTree(6, [[0, 1], [1, 2], [2, 0], [3, 4], [4, 5]]);
            Assert.IsFalse(result, $"[{solutionName}]");
        }

        #endregion
    }
}
