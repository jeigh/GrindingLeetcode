using LeetCodeProblems.CSharp.Queue;
using LeetCodeProblems.Interfaces.Medium;

namespace GrindingLeetCode.UnitTests.Medium
{
    /// <summary>
    /// Unit tests for LeetCode Problem 1834: Single-Threaded CPU
    ///
    /// Problem Description:
    /// You are given n tasks labeled from 0 to n-1 represented by a 2D integer array tasks,
    /// where tasks[i] = [enqueueTimei, processingTimei] means that the i-th task will be
    /// available to process at enqueueTimei and will take processingTimei to finish processing.
    /// 
    /// The CPU is single-threaded and can process at most one task at a time.
    /// The CPU will choose a task according to the following rules:
    ///   - If the CPU is idle and there are no available tasks, it waits until the next task becomes available.
    ///   - If the CPU is idle and there are available tasks, it chooses the task with the shortest processing time.
    ///     If multiple tasks have the same shortest processing time, it chooses the one with the smallest index.
    ///   - Once a task is started, the CPU will process the entire task without stopping.
    ///
    /// Return the order in which the CPU will process the tasks.
    /// </summary>
    [TestClass]
    public class SingleThreadedCpu_1834_Tests  
    {
        public static IEnumerable<object[]> GetImplementations()
        {
             yield return new object[] { new SingleThreadedCpu_TwoQueues_1834(), "C# StableSort Implementation" };
        }

        #region LeetCode Examples

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void GetOrder_Example1_ReturnsCorrectOrder(ISingleThreadedCpu_1834 solution, string solutionName)
        {
            // Example 1:
            // Input: tasks = [[1,2],[2,4],[3,2],[4,1]]
            // Output: [0,2,3,1]
            // Explanation:
            // t=1: task 0 is enqueued and starts running. CPU processes task 0 until t=3.
            // t=2: task 1 is enqueued.
            // t=3: task 0 finishes. Tasks 1 and 2 are available. Task 2 (time=2) ties with task 1 (time=4)?
            //      Actually task 2 has processing time 2 < task 1 processing time 4, so task 2 runs next.
            // t=4: task 3 is enqueued. Task 2 finishes at t=5.
            // t=5: task 2 finishes. Tasks 1 (time=4) and 3 (time=1) are available. Task 3 has shorter time.
            // t=6: task 3 finishes. Only task 1 remains.
            // t=10: task 1 finishes.

            // Arrange
            int[][] tasks = [[1, 2], [2, 4], [3, 2], [4, 1]];

            // Act
            int[] result = solution.GetOrder(tasks);

            // Assert
            CollectionAssert.AreEqual(new[] { 0, 2, 3, 1 }, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void GetOrder_Example2_ReturnsCorrectOrder(ISingleThreadedCpu_1834 solution, string solutionName)
        {
            // Example 2:
            // Input: tasks = [[7,10],[7,12],[7,5],[7,4],[7,2]]
            // Output: [4,3,2,0,1]
            // Explanation: All tasks become available at t=7.
            // CPU picks by shortest processing time, then by smallest index.
            // Processing times: 10,12,5,4,2 -> sorted order: task4(2), task3(4), task2(5), task0(10), task1(12)

            // Arrange
            int[][] tasks = [[7, 10], [7, 12], [7, 5], [7, 4], [7, 2]];

            // Act
            int[] result = solution.GetOrder(tasks);

            // Assert
            CollectionAssert.AreEqual(new[] { 4, 3, 2, 0, 1 }, result, $"Failed for {solutionName}");
        }

        #endregion

        #region Edge Cases - Single Task

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void GetOrder_SingleTask_ReturnsSingleElementArray(ISingleThreadedCpu_1834 solution, string solutionName)
        {
            // Only one task -- must always be picked first regardless of enqueue time or processing time

            // Arrange
            int[][] tasks = [[5, 3]];

            // Act
            int[] result = solution.GetOrder(tasks);

            // Assert
            CollectionAssert.AreEqual(new[] { 0 }, result, $"Failed for {solutionName}");
        }

        #endregion

        #region Edge Cases - Tie Breaking

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void GetOrder_TieOnProcessingTime_ReturnsSmallestIndexFirst(ISingleThreadedCpu_1834 solution, string solutionName)
        {
            // When multiple tasks have the same processing time, the one with the smallest original index wins

            // Arrange
            int[][] tasks = [[1, 5], [1, 5], [1, 5]];

            // Act
            int[] result = solution.GetOrder(tasks);

            // Assert
            CollectionAssert.AreEqual(new[] { 0, 1, 2 }, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void GetOrder_TieOnProcessingTimeNonContiguousIndices_ReturnsSmallestIndexFirst(ISingleThreadedCpu_1834 solution, string solutionName)
        {
            // Tasks enqueue at same time with same processing time but different original indices
            // Indices 0, 2, 1 enqueue simultaneously -- should still be processed 0, 1, 2

            // Arrange
            int[][] tasks = [[2, 3], [2, 3], [2, 3]];

            // Act
            int[] result = solution.GetOrder(tasks);

            // Assert
            CollectionAssert.AreEqual(new[] { 0, 1, 2 }, result, $"Failed for {solutionName}");
        }

        #endregion

        #region Edge Cases - CPU Idle

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void GetOrder_TasksArrivedAfterPreviousFinishes_CpuIdlesCorrectly(ISingleThreadedCpu_1834 solution, string solutionName)
        {
            // Tasks are spaced far apart -- CPU must idle between them and still process each in arrival order

            // Arrange
            int[][] tasks = [[1, 1], [10, 1], [20, 1]];

            // Act
            int[] result = solution.GetOrder(tasks);

            // Assert
            CollectionAssert.AreEqual(new[] { 0, 1, 2 }, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void GetOrder_LongRunningTaskBlocksShorterQueuedTask_ShorterRunsAfter(ISingleThreadedCpu_1834 solution, string solutionName)
        {
            // Task 0 starts at t=1 and runs until t=11.
            // Task 1 (processingTime=1) and task 2 (processingTime=2) both enqueue before t=11.
            // At t=11, task 1 is picked first (shorter processing time).

            // Arrange
            int[][] tasks = [[1, 10], [2, 1], [3, 2]];

            // Act
            int[] result = solution.GetOrder(tasks);

            // Assert
            CollectionAssert.AreEqual(new[] { 0, 1, 2 }, result, $"Failed for {solutionName}");
        }

        #endregion
    }
}
