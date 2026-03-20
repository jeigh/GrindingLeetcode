using LeetCodeProblems.CSharp.Queue;
using LeetCodeProblems.Hashing;
using LeetCodeProblems.Interfaces.Medium;
using LeetCodeProblems.VisualBasic;

namespace GrindingLeetCode.UnitTests.Medium
{
    /// <summary>
    /// Unit tests for LeetCode Problem 621: Task Scheduler
    /// 
    /// Problem Description:
    /// You are given an array of CPU tasks, each represented by letters A to Z, 
    /// and a cooling time, n. Each cycle or interval allows the completion of one task. 
    /// Tasks can be completed in any order, but there's a constraint: 
    /// identical tasks must be separated by at least n intervals due to cooling time.
    /// 
    /// Return the minimum number of intervals required to complete all tasks.
    /// </summary>
    [TestClass]
    public class TaskScheduler_621_Tests
    {
        public static IEnumerable<object[]> GetImplementations()
        {
            yield return new object[] { new TaskScheduler_Math_CSharp_621(), "C# Math Implementation" };
            yield return new object[] { new TaskScheduler_Greedy_CSharp_621(), "C# Greedy Implementation" };
            yield return new object[] { new TaskScheduler_TwoQueues_CSharp_621(), "C# TwoQueues Implementation" };

            yield return new object[] { new TaskScheduler_Math_VB_621(), "VB Math Implementation" };
            yield return new object[] { new TaskScheduler_Greedy_VB_621(), "VB Greedy Implementation" };
            yield return new object[] { new TaskScheduler_TwoQueues_VB_621(), "VB TwoQueues Implementation" };
        }

        #region LeetCode Examples

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void LeastInterval_Example1_Returns8(ITaskScheduler_621 solution, string solutionName)
        {
            // Example 1:
            // Input: tasks = ["A","A","A","B","B","B"], n = 2
            // Output: 8
            // Explanation: A possible sequence is: A -> B -> idle -> A -> B -> idle -> A -> B.
            // After completing task A, you must wait two cycles before doing A again. 
            // The same applies to task B. In the 3rd interval, neither A nor B can be done, so you idle.
            // By the 4th cycle, you can do A again as 2 intervals have passed.

            // Arrange
            char[] tasks = { 'A', 'A', 'A', 'B', 'B', 'B' };
            int n = 2;

            // Act
            int result = solution.LeastInterval(tasks, n);

            // Assert
            Assert.AreEqual(8, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void LeastInterval_Example2_Returns6(ITaskScheduler_621 solution, string solutionName)
        {
            // Example 2:
            // Input: tasks = ["A","C","A","B","D","B"], n = 1
            // Output: 6
            // Explanation: A possible sequence is: A -> B -> C -> D -> A -> B.
            // With a cooling interval of 1, you can repeat a task after just one other task.

            // Arrange
            char[] tasks = { 'A', 'C', 'A', 'B', 'D', 'B' };
            int n = 1;

            // Act
            int result = solution.LeastInterval(tasks, n);

            // Assert
            Assert.AreEqual(6, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void LeastInterval_Example3_Returns6(ITaskScheduler_621 solution, string solutionName)
        {
            // Example 3:
            // Input: tasks = ["A","A","A","B","B","B"], n = 3
            // Output: 10
            // Explanation: A possible sequence is: A -> B -> idle -> idle -> A -> B -> idle -> idle -> A -> B.
            // There are only two types of tasks, A and B, which need to be separated by 3 intervals.
            // This leads to idling twice between repetitions of these tasks.

            // Arrange
            char[] tasks = { 'A', 'A', 'A', 'B', 'B', 'B' };
            int n = 3;

            // Act
            int result = solution.LeastInterval(tasks, n);

            // Assert
            Assert.AreEqual(10, result, $"Failed for {solutionName}");
        }

        #endregion

        #region Edge Cases - Cooling Period

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void LeastInterval_NoCoolingPeriod_ReturnsTaskCount(ITaskScheduler_621 solution, string solutionName)
        {
            // When n = 0, no cooling period needed, so answer is just number of tasks

            // Arrange
            char[] tasks = { 'A', 'A', 'A', 'B', 'B', 'B' };
            int n = 0;

            // Act
            int result = solution.LeastInterval(tasks, n);

            // Assert
            Assert.AreEqual(6, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void LeastInterval_LargeCoolingPeriod_HandlesCorrectly(ITaskScheduler_621 solution, string solutionName)
        {
            // Arrange
            char[] tasks = { 'A', 'A', 'A' };
            int n = 5;

            // Act
            int result = solution.LeastInterval(tasks, n);

            // Assert
            // A -> idle -> idle -> idle -> idle -> idle -> A -> idle -> idle -> idle -> idle -> idle -> A
            Assert.AreEqual(13, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void LeastInterval_MaxCoolingPeriod_HandlesCorrectly(ITaskScheduler_621 solution, string solutionName)
        {
            // Arrange - Using n = 100 which is the maximum constraint
            char[] tasks = { 'A', 'A' };
            int n = 100;

            // Act
            int result = solution.LeastInterval(tasks, n);

            // Assert
            // A -> 100 idles -> A
            Assert.AreEqual(102, result, $"Failed for {solutionName}");
        }

        #endregion

        #region Edge Cases - Single Task

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void LeastInterval_SingleTask_Returns1(ITaskScheduler_621 solution, string solutionName)
        {
            // Arrange
            char[] tasks = { 'A' };
            int n = 10;

            // Act
            int result = solution.LeastInterval(tasks, n);

            // Assert
            Assert.AreEqual(1, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void LeastInterval_SingleTaskType_MultipleInstances_CalculatesCorrectly(ITaskScheduler_621 solution, string solutionName)
        {
            // Arrange
            char[] tasks = { 'A', 'A', 'A', 'A' };
            int n = 2;

            // Act
            int result = solution.LeastInterval(tasks, n);

            // Assert
            // A -> idle -> idle -> A -> idle -> idle -> A -> idle -> idle -> A
            Assert.AreEqual(10, result, $"Failed for {solutionName}");
        }

        #endregion

        #region Edge Cases - All Different Tasks

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void LeastInterval_AllDifferentTasks_ReturnsTaskCount(ITaskScheduler_621 solution, string solutionName)
        {
            // When all tasks are different, no cooling needed

            // Arrange
            char[] tasks = { 'A', 'B', 'C', 'D', 'E' };
            int n = 2;

            // Act
            int result = solution.LeastInterval(tasks, n);

            // Assert
            Assert.AreEqual(5, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void LeastInterval_AllDifferentTasks_LargeCooling_ReturnsTaskCount(ITaskScheduler_621 solution, string solutionName)
        {
            // Even with large cooling, if all different tasks, no idles needed

            // Arrange
            char[] tasks = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H' };
            int n = 10;

            // Act
            int result = solution.LeastInterval(tasks, n);

            // Assert
            Assert.AreEqual(8, result, $"Failed for {solutionName}");
        }

        #endregion

        #region Frequency Distribution Tests

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void LeastInterval_OneHighFrequencyTask_CalculatesCorrectly(ITaskScheduler_621 solution, string solutionName)
        {
            // Arrange - One task appears much more than others
            char[] tasks = { 'A', 'A', 'A', 'A', 'A', 'B', 'C', 'D' };
            int n = 2;

            // Act
            int result = solution.LeastInterval(tasks, n);

            // Assert
            Assert.AreEqual(13, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void LeastInterval_MultipleHighFrequencyTasks_CalculatesCorrectly(ITaskScheduler_621 solution, string solutionName)
        {
            // Arrange - Multiple tasks with same high frequency
            char[] tasks = { 'A', 'A', 'A', 'A', 'B', 'B', 'B', 'B' };
            int n = 2;

            // Act
            int result = solution.LeastInterval(tasks, n);

            // Assert
            Assert.AreEqual(11, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void LeastInterval_ThreeHighFrequencyTasks_CalculatesCorrectly(ITaskScheduler_621 solution, string solutionName)
        {
            // Arrange
            char[] tasks = { 'A', 'A', 'A', 'B', 'B', 'B', 'C', 'C', 'C' };
            int n = 2;

            // Act
            int result = solution.LeastInterval(tasks, n);

            // Assert
            Assert.AreEqual(9, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void LeastInterval_UnbalancedFrequencies_CalculatesCorrectly(ITaskScheduler_621 solution, string solutionName)
        {
            // Arrange - Mix of different frequencies
            char[] tasks = { 'A', 'A', 'A', 'A', 'A', 'B', 'B', 'C', 'C', 'D', 'E' };
            int n = 2;

            // Act
            int result = solution.LeastInterval(tasks, n);

            // Assert
            Assert.AreEqual(13, result, $"Failed for {solutionName}");
        }

        #endregion

        #region Varying Task Counts

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void LeastInterval_TwoTasks_SmallCooling_CalculatesCorrectly(ITaskScheduler_621 solution, string solutionName)
        {
            // Arrange
            char[] tasks = { 'A', 'A', 'B', 'B' };
            int n = 1;

            // Act
            int result = solution.LeastInterval(tasks, n);

            // Assert
            // A -> B -> A -> B
            Assert.AreEqual(4, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void LeastInterval_TwoTasks_LargeCooling_CalculatesCorrectly(ITaskScheduler_621 solution, string solutionName)
        {
            // Arrange
            char[] tasks = { 'A', 'A', 'B', 'B' };
            int n = 3;

            // Act
            int result = solution.LeastInterval(tasks, n);

            // Assert
            // A -> B -> idle -> idle -> A -> B
            Assert.AreEqual(6, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void LeastInterval_ManyDifferentTasks_FillsIdleSlots(ITaskScheduler_621 solution, string solutionName)
        {
            // Arrange - Enough variety to fill idle slots
            char[] tasks = { 'A', 'A', 'A', 'B', 'B', 'B', 'C', 'C', 'D', 'D', 'E', 'F' };
            int n = 2;

            // Act
            int result = solution.LeastInterval(tasks, n);

            // Assert
            Assert.AreEqual(12, result, $"Failed for {solutionName}");
        }

        #endregion

        #region Optimal Scheduling Tests

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void LeastInterval_PerfectFit_NoIdles(ITaskScheduler_621 solution, string solutionName)
        {
            // Arrange - Just enough tasks to fill all slots without idles
            char[] tasks = { 'A', 'A', 'A', 'B', 'B', 'B', 'C', 'C' };
            int n = 2;

            // Act
            int result = solution.LeastInterval(tasks, n);

            // Assert
            // A -> B -> C -> A -> B -> C -> A -> B
            Assert.AreEqual(8, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void LeastInterval_MoreTasksThanCoolingNeeds_ReturnsTaskCount(ITaskScheduler_621 solution, string solutionName)
        {
            // Arrange - So many different tasks that cooling never matters
            char[] tasks = { 'A', 'A', 'B', 'B', 'C', 'C', 'D', 'D', 'E', 'E', 'F', 'F' };
            int n = 2;

            // Act
            int result = solution.LeastInterval(tasks, n);

            // Assert
            Assert.AreEqual(12, result, $"Failed for {solutionName}");
        }

        #endregion

        #region Alphabet Range Tests

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void LeastInterval_UsesEntireAlphabet_CalculatesCorrectly(ITaskScheduler_621 solution, string solutionName)
        {
            // Arrange - Using various letters across the alphabet
            char[] tasks = { 'A', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P' };
            int n = 1;

            // Act
            int result = solution.LeastInterval(tasks, n);

            // Assert
            Assert.AreEqual(17, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void LeastInterval_LateLetter_Z_WorksCorrectly(ITaskScheduler_621 solution, string solutionName)
        {
            // Arrange
            char[] tasks = { 'Z', 'Z', 'Z', 'A', 'A' };
            int n = 2;

            // Act
            int result = solution.LeastInterval(tasks, n);

            // Assert
            Assert.AreEqual(7, result, $"Failed for {solutionName}");
        }

        #endregion

        #region Stress Tests

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void LeastInterval_LargeTaskArray_SingleType_CalculatesCorrectly(ITaskScheduler_621 solution, string solutionName)
        {
            // Arrange - Many instances of one task
            char[] tasks = new char[100];
            for (int i = 0; i < 100; i++)
            {
                tasks[i] = 'A';
            }
            int n = 2;

            // Act
            int result = solution.LeastInterval(tasks, n);

            // Assert
            // 100 tasks with cooling of 2 means: A -> idle -> idle -> A (repeat)
            // (100 - 1) * 3 + 1 = 298
            Assert.AreEqual(298, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void LeastInterval_LargeTaskArray_Balanced_CalculatesCorrectly(ITaskScheduler_621 solution, string solutionName)
        {
            // Arrange - Many tasks, evenly distributed
            char[] tasks = new char[100];
            for (int i = 0; i < 100; i++)
            {
                tasks[i] = (char)('A' + (i % 10)); // 10 different task types, 10 of each
            }
            int n = 2;

            // Act
            int result = solution.LeastInterval(tasks, n);

            // Assert
            Assert.AreEqual(100, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void LeastInterval_MaximumTasks_MixedFrequency_CalculatesCorrectly(ITaskScheduler_621 solution, string solutionName)
        {
            // Arrange - Approaching constraint limits (tasks.length <= 10^4)
            List<char> taskList = new List<char>();
            
            // 50 A's (highest frequency)
            for (int i = 0; i < 50; i++) taskList.Add('A');
            
            // 30 B's
            for (int i = 0; i < 30; i++) taskList.Add('B');
            
            // 20 other tasks
            for (int i = 0; i < 20; i++) taskList.Add('C');
            
            char[] tasks = taskList.ToArray();
            int n = 3;

            // Act
            int result = solution.LeastInterval(tasks, n);

            // Assert
            Assert.IsTrue(result >= 100, $"Result should be at least 100 for {solutionName}");
            Assert.IsTrue(result <= 199, $"Result should be reasonable for {solutionName}");
        }

        #endregion

        #region Special Patterns

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void LeastInterval_AlternatingPattern_TwoTasks_CalculatesCorrectly(ITaskScheduler_621 solution, string solutionName)
        {
            // Arrange
            char[] tasks = { 'A', 'B', 'A', 'B', 'A', 'B' };
            int n = 1;

            // Act
            int result = solution.LeastInterval(tasks, n);

            // Assert
            Assert.AreEqual(6, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void LeastInterval_ConsecutiveSameTasks_RequiresIdles(ITaskScheduler_621 solution, string solutionName)
        {
            // Arrange - Tasks given in worst-case order (all same first)
            char[] tasks = { 'A', 'A', 'A', 'A', 'B', 'B', 'C', 'C' };
            int n = 2;

            // Act
            int result = solution.LeastInterval(tasks, n);

            // Assert
            Assert.AreEqual(10, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void LeastInterval_PyramidFrequency_CalculatesCorrectly(ITaskScheduler_621 solution, string solutionName)
        {
            // Arrange - Frequencies: A=5, B=4, C=3, D=2, E=1
            char[] tasks = { 'A', 'A', 'A', 'A', 'A', 'B', 'B', 'B', 'B', 'C', 'C', 'C', 'D', 'D', 'E' };
            int n = 2;

            // Act
            int result = solution.LeastInterval(tasks, n);

            // Assert
            Assert.AreEqual(15, result, $"Failed for {solutionName}");
        }

        #endregion

        #region Minimum Intervals Formula Verification

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void LeastInterval_FormulaCheck_MaxFrequency_CalculatesCorrectly(ITaskScheduler_621 solution, string solutionName)
        {
            // This test verifies the mathematical formula:
            // intervals = max(tasks.length, (maxFreq - 1) * (n + 1) + countOfMaxFreq)

            // Arrange
            char[] tasks = { 'A', 'A', 'A', 'B', 'B', 'B' };
            int n = 2;
            // maxFreq = 3, countOfMaxFreq = 2
            // Formula: (3 - 1) * (2 + 1) + 2 = 2 * 3 + 2 = 8

            // Act
            int result = solution.LeastInterval(tasks, n);

            // Assert
            Assert.AreEqual(8, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void LeastInterval_FormulaCheck_TaskCountGreater_ReturnsTaskCount(ITaskScheduler_621 solution, string solutionName)
        {
            // When we have many different tasks, the task count itself is the answer

            // Arrange
            char[] tasks = { 'A', 'A', 'B', 'B', 'C', 'C', 'D', 'D', 'E', 'E' };
            int n = 1;
            // maxFreq = 2, but we have many different tasks
            // Formula gives: (2-1)*(1+1)+5 = 1*2+5 = 7, but tasks.length = 10
            // So answer should be 10

            // Act
            int result = solution.LeastInterval(tasks, n);

            // Assert
            Assert.AreEqual(10, result, $"Failed for {solutionName}");
        }

        #endregion

        #region Boundary Value Tests

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void LeastInterval_MinimumConstraints_TwoTasksNoCooling_Returns2(ITaskScheduler_621 solution, string solutionName)
        {
            // Arrange - Minimum possible input
            char[] tasks = { 'A', 'B' };
            int n = 0;

            // Act
            int result = solution.LeastInterval(tasks, n);

            // Assert
            Assert.AreEqual(2, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void LeastInterval_AllSameTask_LongArray_CalculatesCorrectly(ITaskScheduler_621 solution, string solutionName)
        {
            // Arrange
            char[] tasks = new char[10];
            for (int i = 0; i < 10; i++)
            {
                tasks[i] = 'X';
            }
            int n = 1;

            // Act
            int result = solution.LeastInterval(tasks, n);

            // Assert
            // X -> idle -> X -> idle -> ... -> X
            // (10 - 1) * 2 + 1 = 19
            Assert.AreEqual(19, result, $"Failed for {solutionName}");
        }

        #endregion

        #region Complex Real-World Scenarios

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void LeastInterval_RealWorldScenario1_CalculatesCorrectly(ITaskScheduler_621 solution, string solutionName)
        {
            // Arrange - Simulating a real CPU scheduling scenario
            char[] tasks = { 'A', 'A', 'A', 'A', 'B', 'B', 'B', 'C', 'C', 'D', 'D', 'E' };
            int n = 3;

            // Act
            int result = solution.LeastInterval(tasks, n);

            // Assert
            Assert.IsTrue(result >= 12, $"Result should be at least 12 for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void LeastInterval_RealWorldScenario2_ManyTaskTypes_CalculatesCorrectly(ITaskScheduler_621 solution, string solutionName)
        {
            // Arrange - Many different task types with varying frequencies
            char[] tasks = { 'A', 'A', 'A', 'B', 'B', 'C', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J' };
            int n = 2;

            // Act
            int result = solution.LeastInterval(tasks, n);

            // Assert
            Assert.AreEqual(14, result, $"Failed for {solutionName}");
        }

        #endregion
    }
}
