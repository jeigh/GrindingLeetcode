namespace LeetCodeProblems.Interfaces.Medium
{
    /// <summary>
    /// LeetCode Problem 79: Word Search
    ///
    /// Given an m x n grid of characters board and a string word, return true
    /// if word exists in the grid. The word can be constructed from letters of
    /// sequentially adjacent cells (horizontally or vertically). The same cell
    /// may not be used more than once.
    /// </summary>
    public interface IWordSearch_79
    {
        bool Exist(char[][] board, string word);
    }
}
