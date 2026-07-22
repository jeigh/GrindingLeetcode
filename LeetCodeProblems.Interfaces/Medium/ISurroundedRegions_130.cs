namespace LeetCodeProblems.Interfaces.Medium
{
    /// <summary>
    /// LeetCode Problem 130: Surrounded Regions
    ///
    /// Given an m x n board containing 'X' and 'O', capture all regions
    /// that are 4-directionally surrounded by 'X' by flipping all surrounded
    /// 'O's to 'X'. A region is NOT captured if any 'O' in it touches the border.
    /// Modifies the board in place.
    /// </summary>
    public interface ISurroundedRegions_130
    {
        void Solve(char[][] board);
    }
}
