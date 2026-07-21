namespace LeetCodeProblems.Interfaces.Medium
{
    /// <summary>
    /// LeetCode Problem 417: Pacific Atlantic Water Flow
    ///
    /// Given an m x n grid of heights, water can flow to adjacent cells
    /// (up/down/left/right) only if the neighbor's height is less than or equal
    /// to the current cell's height. The Pacific ocean borders the top and left
    /// edges; the Atlantic borders the bottom and right edges.
    ///
    /// Return all [r, c] coordinates from which water can flow to both oceans.
    /// </summary>
    public interface IPacificAtlanticWaterFlow_417
    {
        IList<IList<int>> PacificAtlantic(int[][] heights);
    }
}
