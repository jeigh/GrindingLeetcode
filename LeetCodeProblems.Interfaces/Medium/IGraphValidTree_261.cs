namespace LeetCodeProblems.Interfaces.Medium
{
    /// <summary>
    /// LeetCode Problem 261: Graph Valid Tree
    ///
    /// Given n nodes labeled 0 to n-1 and a list of undirected edges (each edge a
    /// pair of nodes), determine whether these edges form a valid tree — i.e.,
    /// the graph is connected and contains no cycles.
    /// </summary>
    public interface IGraphValidTree_261
    {
        bool ValidTree(int n, int[][] edges);
    }
}
