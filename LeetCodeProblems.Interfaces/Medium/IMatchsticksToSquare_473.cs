namespace LeetCodeProblems.Interfaces.Medium
{
    /// <summary>
    /// LeetCode Problem 473: Matchsticks to Square
    ///
    /// Given an integer array matchsticks where matchsticks[i] is the length of
    /// the ith matchstick, use all matchsticks to form a square without breaking
    /// any stick. Each matchstick must be used exactly once.
    /// Return true if you can make this square, false otherwise.
    /// </summary>
    public interface IMatchsticksToSquare_473
    {
        bool Makesquare(int[] matchsticks);
    }
}
