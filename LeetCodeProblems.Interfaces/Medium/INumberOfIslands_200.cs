namespace LeetCodeProblems.Interfaces.Medium
{
    /// <summary>
    /// LeetCode Problem 200: Number of Islands
    ///
    /// Given an m x n 2D binary grid of '1's (land) and '0's (water),
    /// return the number of islands. An island is surrounded by water and
    /// formed by connecting adjacent land cells horizontally or vertically.
    /// </summary>
    public interface INumberOfIslands_200
    {
        int NumIslands(char[][] grid);
    }
}
