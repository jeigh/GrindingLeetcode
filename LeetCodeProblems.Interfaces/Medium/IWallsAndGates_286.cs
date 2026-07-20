namespace LeetCodeProblems.Interfaces.Medium
{
    /// <summary>
    /// LeetCode Problem 286: Walls and Gates
    ///
    /// Given an m x n grid where each cell is one of:
    ///   -1  = wall/obstacle
    ///    0  = gate
    ///   INF = empty room (2147483647)
    ///
    /// Fill each empty room with the distance to its nearest gate.
    /// If a room cannot reach any gate, leave it as INF.
    /// Modifies the grid in-place.
    /// </summary>
    public interface IWallsAndGates_286
    {
        void WallsAndGates(int[][] rooms);
    }
}
