namespace LeetCodeProblems.Interfaces.Medium
{
    /// <summary>
    /// LeetCode Problem 684: Redundant Connection
    ///
    /// A tree with n nodes labeled 1 to n had one additional edge added, creating
    /// exactly one cycle. edges[i] = [ai, bi] represents an undirected edge in the
    /// resulting graph. Return the edge that can be removed so the graph becomes a
    /// tree again. If multiple such edges exist, return the one that occurs last
    /// in the input.
    /// </summary>
    public interface IRedundantConnection_684
    {
        int[] FindRedundantConnection(int[][] edges);
    }
}
