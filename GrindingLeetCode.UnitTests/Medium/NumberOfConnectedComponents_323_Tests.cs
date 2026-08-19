using LeetCodeProblems.CSharp.Graph;
using LeetCodeProblems.Interfaces.Medium;
using LeetCodeProblems.VisualBasic.Graph;

namespace GrindingLeetCode.UnitTests.Medium
{
    [TestClass]
    public class NumberOfConnectedComponents_323_Tests
    {
        public static IEnumerable<object[]> GetImplementations()
        {
            // Uncomment as each implementation is written.
            yield return new object[] { new NumberOfConnectedComponents_Solution_CSharp_323(), "C# Solution" };
            //yield return new object[] { new NumberOfConnectedComponents_Solution_VB_323(), "VB Solution" };

            yield break;
        }

        #region LeetCode Examples

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CountComponents_Example1_TwoComponents_ReturnsTwo(INumberOfConnectedComponents_323 solution, string solutionName)
        {
            // {0,1,2} and {3,4}
            var result = solution.CountComponents(5, [[0, 1], [1, 2], [3, 4]]);
            Assert.AreEqual(2, result, $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CountComponents_Example2_AllConnected_ReturnsOne(INumberOfConnectedComponents_323 solution, string solutionName)
        {
            var result = solution.CountComponents(5, [[0, 1], [1, 2], [2, 3], [3, 4]]);
            Assert.AreEqual(1, result, $"[{solutionName}]");
        }

        #endregion

        #region Trivial Cases

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CountComponents_SingleNode_NoEdges_ReturnsOne(INumberOfConnectedComponents_323 solution, string solutionName)
        {
            var result = solution.CountComponents(1, []);
            Assert.AreEqual(1, result, $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CountComponents_NoEdges_AllIsolated_ReturnsN(INumberOfConnectedComponents_323 solution, string solutionName)
        {
            var result = solution.CountComponents(5, []);
            Assert.AreEqual(5, result, $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CountComponents_TwoNodes_Connected_ReturnsOne(INumberOfConnectedComponents_323 solution, string solutionName)
        {
            var result = solution.CountComponents(2, [[0, 1]]);
            Assert.AreEqual(1, result, $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CountComponents_TwoNodes_Disconnected_ReturnsTwo(INumberOfConnectedComponents_323 solution, string solutionName)
        {
            var result = solution.CountComponents(2, []);
            Assert.AreEqual(2, result, $"[{solutionName}]");
        }

        #endregion

        #region Fully Connected (One Component)

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CountComponents_LinearChain_ReturnsOne(INumberOfConnectedComponents_323 solution, string solutionName)
        {
            var result = solution.CountComponents(4, [[0, 1], [1, 2], [2, 3]]);
            Assert.AreEqual(1, result, $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CountComponents_StarShape_ReturnsOne(INumberOfConnectedComponents_323 solution, string solutionName)
        {
            var result = solution.CountComponents(5, [[0, 1], [0, 2], [0, 3], [0, 4]]);
            Assert.AreEqual(1, result, $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CountComponents_CycleWithRedundantEdges_ReturnsOne(INumberOfConnectedComponents_323 solution, string solutionName)
        {
            // 0-1-2-3-0 cycle plus a redundant chord 0-2
            var result = solution.CountComponents(4, [[0, 1], [1, 2], [2, 3], [3, 0], [0, 2]]);
            Assert.AreEqual(1, result, $"[{solutionName}]");
        }

        #endregion

        #region Multiple Components

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CountComponents_TwoSeparatePairs_ReturnsTwo(INumberOfConnectedComponents_323 solution, string solutionName)
        {
            var result = solution.CountComponents(4, [[0, 1], [2, 3]]);
            Assert.AreEqual(2, result, $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CountComponents_ThreeSeparateChains_ReturnsThree(INumberOfConnectedComponents_323 solution, string solutionName)
        {
            var result = solution.CountComponents(9, [[0, 1], [1, 2], [3, 4], [4, 5], [6, 7], [7, 8]]);
            Assert.AreEqual(3, result, $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CountComponents_MixOfComponentSizes_ReturnsFour(INumberOfConnectedComponents_323 solution, string solutionName)
        {
            // {0,1,2}, {3,4}, {5}, {6}
            var result = solution.CountComponents(7, [[0, 1], [0, 2], [3, 4]]);
            Assert.AreEqual(4, result, $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CountComponents_UnorderedEdgeList_ReturnsTwo(INumberOfConnectedComponents_323 solution, string solutionName)
        {
            var result = solution.CountComponents(4, [[2, 3], [0, 1]]);
            Assert.AreEqual(2, result, $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CountComponents_ManySmallPairs_ReturnsThree(INumberOfConnectedComponents_323 solution, string solutionName)
        {
            var result = solution.CountComponents(6, [[0, 1], [2, 3], [4, 5]]);
            Assert.AreEqual(3, result, $"[{solutionName}]");
        }

        #endregion

        #region Larger Graphs

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CountComponents_AllIsolatedLarge_ReturnsN(INumberOfConnectedComponents_323 solution, string solutionName)
        {
            var result = solution.CountComponents(10, []);
            Assert.AreEqual(10, result, $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CountComponents_SingleChainAllNodesLarge_ReturnsOne(INumberOfConnectedComponents_323 solution, string solutionName)
        {
            var result = solution.CountComponents(6, [[0, 1], [1, 2], [2, 3], [3, 4], [4, 5]]);
            Assert.AreEqual(1, result, $"[{solutionName}]");
        }

        #endregion

        #region Edge Cases

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CountComponents_ReverseOrderEdgeEndpoints_ReturnsOne(INumberOfConnectedComponents_323 solution, string solutionName)
        {
            // Same chain 0-1-2, edges listed out of order and with endpoints reversed
            var result = solution.CountComponents(3, [[2, 1], [1, 0]]);
            Assert.AreEqual(1, result, $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CountComponents_TriangleComponent_ReturnsOne(INumberOfConnectedComponents_323 solution, string solutionName)
        {
            // A cycle is still just one component
            var result = solution.CountComponents(3, [[0, 1], [1, 2], [0, 2]]);
            Assert.AreEqual(1, result, $"[{solutionName}]");
        }

        #endregion
    }
}
