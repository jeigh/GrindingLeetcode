namespace LeetCodeProblems.Interfaces.Medium
{
    /// <summary>
    /// There are n cars at given miles away from the starting mile 0, traveling to reach the mile target.
    /// 
    /// You are given two integer arrays position and speed, both of length n, where position[i] is the starting mile of the ith car and speed[i] is the speed of the ith car in miles per hour.
    /// 
    /// A car cannot pass another car, but it can catch up and then travel next to it at the speed of the slower car.
    /// 
    /// A car fleet is a single car or a group of cars driving next to each other.The speed of the car fleet is the minimum speed of any car in the fleet.
    /// 
    /// If a car catches up to a car fleet at the mile target, it will still be considered as part of the car fleet.
    /// 
    /// Return the number of car fleets that will arrive at the destination.
    /// </summary>
    public interface ICarFleet_853
    {
        int CarFleet(int target, int[] position, int[] speed);
    }
}