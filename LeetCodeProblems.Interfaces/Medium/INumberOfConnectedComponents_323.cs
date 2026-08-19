namespace LeetCodeProblems.Interfaces.Medium
{
    /// <summary>
    /// LeetCode Problem 323: Number of Connected Components in an Undirected Graph
    ///
    /// You have a graph of n nodes labeled 0 to n-1. You are given an integer n
    /// and an array edges where edges[i] = [ai, bi] indicates that there is an
    /// undirected edge between ai and bi in the graph.
    /// Return the number of connected components in the graph.
    /// </summary>
    public interface INumberOfConnectedComponents_323
    {
        int CountComponents(int n, int[][] edges);
    }
}
