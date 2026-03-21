using LeetCodeProblems.CSharp.Queue;
using LeetCodeProblems.Interfaces.Medium;

namespace GrindingLeetCode.UnitTests.Medium
{
    /// <summary>
    /// Unit tests for LeetCode Problem 1094: Car Pooling
    ///
    /// Problem Description:
    /// Given a car with a fixed capacity and an array of trips where each trip is
    /// [numPassengers, from, to], return true if all passengers can be picked up
    /// and dropped off without exceeding capacity at any point on the route.
    /// </summary>
    [TestClass]
    public class CarPooling_1094_Tests
    {
        public static IEnumerable<object[]> GetImplementations()
        {
            yield return new object[] { new CarPooling_CSharp_1094(), "C# Implementation" };
        }

        #region LeetCode Examples

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CarPooling_Example1_ReturnsFalse(ICarPooling_1094 solution, string solutionName)
        {
            // Input: trips = [[2,1,5],[3,3,7]], capacity = 4
            // At stop 3: 2 + 3 = 5 passengers on board, exceeds capacity 4.
            // Output: false

            int[][] trips = [[2, 1, 5], [3, 3, 7]];
            int capacity = 4;

            bool result = solution.CarPooling(trips, capacity);

            Assert.IsFalse(result, $"Expected false for example 1 [{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CarPooling_Example2_ReturnsTrue(ICarPooling_1094 solution, string solutionName)
        {
            // Input: trips = [[2,1,5],[3,3,7]], capacity = 5
            // At stop 3: 2 + 3 = 5 passengers, exactly at capacity.
            // Output: true

            int[][] trips = [[2, 1, 5], [3, 3, 7]];
            int capacity = 5;

            bool result = solution.CarPooling(trips, capacity);

            Assert.IsTrue(result, $"Expected true for example 2 [{solutionName}]");
        }

        #endregion

        #region Edge Cases

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CarPooling_SingleTrip_PassengersWithinCapacity_ReturnsTrue(ICarPooling_1094 solution, string solutionName)
        {
            // One trip, passengers do not exceed capacity.
            int[][] trips = [[3, 0, 5]];
            int capacity = 3;

            bool result = solution.CarPooling(trips, capacity);

            Assert.IsTrue(result, $"Expected true for single trip within capacity [{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CarPooling_SingleTrip_PassengersExceedCapacity_ReturnsFalse(ICarPooling_1094 solution, string solutionName)
        {
            // One trip immediately exceeds capacity.
            int[][] trips = [[4, 0, 5]];
            int capacity = 3;

            bool result = solution.CarPooling(trips, capacity);

            Assert.IsFalse(result, $"Expected false for single trip exceeding capacity [{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CarPooling_NonOverlappingTrips_ReturnsTrue(ICarPooling_1094 solution, string solutionName)
        {
            // Second trip starts exactly where first ends -- passengers dropped before next pickup.
            int[][] trips = [[3, 1, 4], [3, 4, 8]];
            int capacity = 3;

            bool result = solution.CarPooling(trips, capacity);

            Assert.IsTrue(result, $"Expected true when trips do not overlap [{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CarPooling_OverlappingTrips_ExceedCapacity_ReturnsFalse(ICarPooling_1094 solution, string solutionName)
        {
            // Two trips overlap and their combined passengers exceed capacity.
            int[][] trips = [[3, 1, 6], [3, 2, 5]];
            int capacity = 5;

            bool result = solution.CarPooling(trips, capacity);

            Assert.IsFalse(result, $"Expected false when overlapping trips exceed capacity [{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CarPooling_OverlappingTrips_WithinCapacity_ReturnsTrue(ICarPooling_1094 solution, string solutionName)
        {
            // Two trips overlap but combined passengers stay within capacity.
            int[][] trips = [[2, 1, 6], [2, 2, 5]];
            int capacity = 5;

            bool result = solution.CarPooling(trips, capacity);

            Assert.IsTrue(result, $"Expected true when overlapping trips stay within capacity [{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CarPooling_DropOffBeforeNextPickup_ReturnsTrue(ICarPooling_1094 solution, string solutionName)
        {
            // Passengers from trip 1 drop off at stop 3; trip 2 picks up at stop 3.
            // Drop-off happens before pickup at the same stop, so capacity is never exceeded.
            int[][] trips = [[4, 1, 3], [4, 3, 6]];
            int capacity = 4;

            bool result = solution.CarPooling(trips, capacity);

            Assert.IsTrue(result, $"Expected true when drop-off and pickup share a stop [{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CarPooling_ManyTripsAllFitSequentially_ReturnsTrue(ICarPooling_1094 solution, string solutionName)
        {
            // Multiple sequential non-overlapping trips, each within capacity.
            int[][] trips = [[1, 0, 1], [1, 1, 2], [1, 2, 3], [1, 3, 4]];
            int capacity = 1;

            bool result = solution.CarPooling(trips, capacity);

            Assert.IsTrue(result, $"Expected true for sequential single-passenger trips [{solutionName}]");
        }

        #endregion
    }
}
