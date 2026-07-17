using LeetCodeProblems.Shared;

namespace LeetCodeProblems.Interfaces.Medium
{
    /// <summary>
    /// LeetCode Problem 133: Clone Graph
    ///
    /// Given a reference to a node in a connected undirected graph, return a
    /// deep copy of the graph. Each node contains a val and a list of neighbors.
    /// </summary>
    public interface ICloneGraph_133
    {
        GraphNode? CloneGraph(GraphNode? node);
    }
}
