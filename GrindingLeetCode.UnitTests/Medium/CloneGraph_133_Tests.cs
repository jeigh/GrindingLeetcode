using LeetCodeProblems.CSharp.HashingOrArrays;
using LeetCodeProblems.Interfaces.Medium;
using LeetCodeProblems.Shared;
using LeetCodeProblems.VisualBasic.HashingOrArrays;

namespace GrindingLeetCode.UnitTests.Medium
{
    [TestClass]
    public class CloneGraph_133_Tests
    {
        public static IEnumerable<object[]> GetImplementations()
        {
            yield return new object[] { new CloneGraph_CSharp_133(), "C#" };
            yield return new object[] { new CloneGraph_VB_133(), "VB" };
        }

        #region Helper Methods

        /// <summary>
        /// Builds a graph from an adjacency list (1-indexed vals).
        /// adjacency[i] lists the neighbors of node (i+1).
        /// Returns the node with val=1.
        /// </summary>
        private static GraphNode BuildGraph(int[][] adjacency)
        {
            var nodes = new GraphNode[adjacency.Length + 1];
            for (int i = 1; i <= adjacency.Length; i++)
                nodes[i] = new GraphNode(i);
            for (int i = 0; i < adjacency.Length; i++)
                foreach (int neighbor in adjacency[i])
                    nodes[i + 1].neighbors.Add(nodes[neighbor]);
            return nodes[1];
        }

        /// <summary>
        /// Verifies that the clone has the same structure as the original,
        /// but no shared object references.
        /// </summary>
        private static void AssertDeepClone(GraphNode? original, GraphNode? clone, string solutionName)
        {
            if (original == null)
            {
                Assert.IsNull(clone, $"[{solutionName}] Clone should be null when original is null");
                return;
            }

            Assert.IsNotNull(clone, $"[{solutionName}] Clone should not be null");

            // BFS over both graphs simultaneously
            var visited = new Dictionary<GraphNode, GraphNode>();
            var queue = new Queue<(GraphNode orig, GraphNode cloned)>();
            queue.Enqueue((original, clone));
            visited[original] = clone;

            while (queue.Count > 0)
            {
                var (orig, cloned) = queue.Dequeue();

                Assert.AreNotSame(orig, cloned, $"[{solutionName}] Node val={orig.val} must be a different object");
                Assert.AreEqual(orig.val, cloned.val, $"[{solutionName}] Node val mismatch");
                Assert.AreEqual(orig.neighbors.Count, cloned.neighbors.Count,
                    $"[{solutionName}] Neighbor count mismatch at val={orig.val}");

                for (int i = 0; i < orig.neighbors.Count; i++)
                {
                    var origNeighbor = orig.neighbors[i];
                    var clonedNeighbor = cloned.neighbors[i];
                    Assert.AreNotSame(origNeighbor, clonedNeighbor,
                        $"[{solutionName}] Neighbor val={origNeighbor.val} must be a different object");
                    Assert.AreEqual(origNeighbor.val, clonedNeighbor.val,
                        $"[{solutionName}] Neighbor val mismatch at parent val={orig.val}");

                    if (!visited.ContainsKey(origNeighbor))
                    {
                        visited[origNeighbor] = clonedNeighbor;
                        queue.Enqueue((origNeighbor, clonedNeighbor));
                    }
                }
            }
        }

        #endregion

        #region LeetCode Examples

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CloneGraph_Example1_FourNodeCycle(ICloneGraph_133 solution, string solutionName)
        {
            // [[2,4],[1,3],[2,4],[1,3]]: 1-2-3-4-1 cycle
            var original = BuildGraph(new[] { new[] { 2, 4 }, new[] { 1, 3 }, new[] { 2, 4 }, new[] { 1, 3 } });
            var clone = solution.CloneGraph(original);
            AssertDeepClone(original, clone, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CloneGraph_Example2_SingleNode_NoEdges(ICloneGraph_133 solution, string solutionName)
        {
            // [[]] — single node, no neighbors
            var original = new GraphNode(1);
            var clone = solution.CloneGraph(original);
            AssertDeepClone(original, clone, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CloneGraph_Example3_NullInput_ReturnsNull(ICloneGraph_133 solution, string solutionName)
        {
            var clone = solution.CloneGraph(null);
            Assert.IsNull(clone, $"[{solutionName}]");
        }

        #endregion

        #region Simple Structures

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CloneGraph_TwoNodes_MutualEdge(ICloneGraph_133 solution, string solutionName)
        {
            // 1 <-> 2
            var original = BuildGraph(new[] { new[] { 2 }, new[] { 1 } });
            var clone = solution.CloneGraph(original);
            AssertDeepClone(original, clone, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CloneGraph_ThreeNodes_Triangle(ICloneGraph_133 solution, string solutionName)
        {
            // 1-2-3-1 triangle
            var original = BuildGraph(new[] { new[] { 2, 3 }, new[] { 1, 3 }, new[] { 1, 2 } });
            var clone = solution.CloneGraph(original);
            AssertDeepClone(original, clone, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CloneGraph_ThreeNodes_Chain(ICloneGraph_133 solution, string solutionName)
        {
            // 1-2-3 (no edge between 1 and 3)
            var original = BuildGraph(new[] { new[] { 2 }, new[] { 1, 3 }, new[] { 2 } });
            var clone = solution.CloneGraph(original);
            AssertDeepClone(original, clone, solutionName);
        }

        #endregion

        #region Deeper Verification

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CloneGraph_SingleNode_IsDistinctObject(ICloneGraph_133 solution, string solutionName)
        {
            var original = new GraphNode(1);
            var clone = solution.CloneGraph(original);
            Assert.IsNotNull(clone, $"[{solutionName}]");
            Assert.AreNotSame(original, clone, $"[{solutionName}] Clone must be a different object");
            Assert.AreEqual(1, clone.val, $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CloneGraph_FourNodes_Star(ICloneGraph_133 solution, string solutionName)
        {
            // node 1 connected to 2, 3, 4; no edges among 2/3/4
            var original = BuildGraph(new[]
            {
                new[] { 2, 3, 4 },
                new[] { 1 },
                new[] { 1 },
                new[] { 1 }
            });
            var clone = solution.CloneGraph(original);
            AssertDeepClone(original, clone, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CloneGraph_FiveNodes_FullyConnected(ICloneGraph_133 solution, string solutionName)
        {
            var original = BuildGraph(new[]
            {
                new[] { 2, 3, 4, 5 },
                new[] { 1, 3, 4, 5 },
                new[] { 1, 2, 4, 5 },
                new[] { 1, 2, 3, 5 },
                new[] { 1, 2, 3, 4 }
            });
            var clone = solution.CloneGraph(original);
            AssertDeepClone(original, clone, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CloneGraph_MutatingCloneDoesNotAffectOriginal(ICloneGraph_133 solution, string solutionName)
        {
            var original = BuildGraph(new[] { new[] { 2 }, new[] { 1 } });
            var clone = solution.CloneGraph(original);
            Assert.IsNotNull(clone, $"[{solutionName}]");

            // mutate the clone
            clone.val = 99;
            clone.neighbors.Clear();

            // original must be unchanged
            Assert.AreEqual(1, original.val, $"[{solutionName}] Mutating clone should not affect original");
            Assert.AreEqual(1, original.neighbors.Count, $"[{solutionName}] Mutating clone should not affect original neighbors");
        }

        #endregion
    }
}
