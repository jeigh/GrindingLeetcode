namespace LeetCodeProblems.Interfaces.Medium
{
    /// <summary>
    /// LeetCode 1094: Car Pooling
    ///
    /// There is a car with capacity empty seats. The vehicle only drives east
    /// (i.e., it cannot turn around and drive west).
    ///
    /// You are given the integer capacity and an array trips where
    /// trips[i] = [numPassengers, from, to] indicates that the i-th trip has
    /// numPassengers passengers and the route goes from from to to.
    ///
    /// Return true if it is possible to pick up and drop off all passengers
    /// for all the given trips, or false otherwise.
    /// </summary>
    public interface ICarPooling_1094
    {
        bool CarPooling(int[][] trips, int capacity);
    }
}
