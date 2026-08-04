using LeetCodeProblems.CSharp.Graph;
using LeetCodeProblems.Interfaces.Medium;
using LeetCodeProblems.VisualBasic.Graph;

namespace GrindingLeetCode.UnitTests.Medium
{
    [TestClass]
    public class OpenTheLock_752_Tests
    {
        public static IEnumerable<object[]> GetImplementations()
        {
            yield return new object[] { new OpenTheLock_CSharp_752(), "C#" };
            yield return new object[] { new OpenTheLock_VB_752(), "VB" };
        }

        #region LeetCode Examples

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void OpenLock_Example1_Returns6(IOpenTheLock_752 solution, string solutionName)
        {
            var result = solution.OpenLock(["0201", "0101", "0102", "1212", "2002"], "0202");
            Assert.AreEqual(6, result, $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void OpenLock_Example2_Returns1(IOpenTheLock_752 solution, string solutionName)
        {
            var result = solution.OpenLock(["8888"], "0009");
            Assert.AreEqual(1, result, $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void OpenLock_Example3_AllPathsBlocked_ReturnsNeg1(IOpenTheLock_752 solution, string solutionName)
        {
            var result = solution.OpenLock(["8887", "8889", "8878", "8898", "8788", "8988", "7888", "9888"], "8888");
            Assert.AreEqual(-1, result, $"[{solutionName}]");
        }

        #endregion

        #region Already at Target

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void OpenLock_TargetIsStart_Returns0(IOpenTheLock_752 solution, string solutionName)
        {
            var result = solution.OpenLock([], "0000");
            Assert.AreEqual(0, result, $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void OpenLock_TargetIsStartWithDeadends_Returns0(IOpenTheLock_752 solution, string solutionName)
        {
            var result = solution.OpenLock(["1234", "5678"], "0000");
            Assert.AreEqual(0, result, $"[{solutionName}]");
        }

        #endregion

        #region Immediate Deadlock

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void OpenLock_StartIsDeadend_ReturnsNeg1(IOpenTheLock_752 solution, string solutionName)
        {
            var result = solution.OpenLock(["0000"], "9999");
            Assert.AreEqual(-1, result, $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void OpenLock_TargetIsDeadend_ReturnsNeg1(IOpenTheLock_752 solution, string solutionName)
        {
            var result = solution.OpenLock(["0202"], "0202");
            Assert.AreEqual(-1, result, $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void OpenLock_AllNeighborsOfStartAreDeadends_ReturnsNeg1(IOpenTheLock_752 solution, string solutionName)
        {
            // Every dial from 0000 can only move to these 8 states
            var result = solution.OpenLock(
                ["1000", "9000", "0100", "0900", "0010", "0090", "0001", "0009"],
                "5555");
            Assert.AreEqual(-1, result, $"[{solutionName}]");
        }

        #endregion

        #region One Turn

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void OpenLock_OneTurnForward_Returns1(IOpenTheLock_752 solution, string solutionName)
        {
            var result = solution.OpenLock([], "0001");
            Assert.AreEqual(1, result, $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void OpenLock_OneTurnBackwardWrap_Returns1(IOpenTheLock_752 solution, string solutionName)
        {
            // 0 → 9 is one backward turn
            var result = solution.OpenLock([], "0009");
            Assert.AreEqual(1, result, $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void OpenLock_AllFourDialsOneBackwardWrap_Returns4(IOpenTheLock_752 solution, string solutionName)
        {
            // Each dial: 0 → 9 is one backward step
            var result = solution.OpenLock([], "9999");
            Assert.AreEqual(4, result, $"[{solutionName}]");
        }

        #endregion

        #region Turn Counting

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void OpenLock_AllFourDialsOneForward_Returns4(IOpenTheLock_752 solution, string solutionName)
        {
            var result = solution.OpenLock([], "1111");
            Assert.AreEqual(4, result, $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void OpenLock_FirstDialSixForwardFourBackward_Returns4(IOpenTheLock_752 solution, string solutionName)
        {
            // Dial 0: min(6 forward, 4 backward) = 4
            var result = solution.OpenLock([], "6000");
            Assert.AreEqual(4, result, $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void OpenLock_AllDialsAtMidpoint_Returns20(IOpenTheLock_752 solution, string solutionName)
        {
            // Each dial: min(5 forward, 5 backward) = 5, four dials = 20
            var result = solution.OpenLock([], "5555");
            Assert.AreEqual(20, result, $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void OpenLock_TwoDialsWrap_Returns2(IOpenTheLock_752 solution, string solutionName)
        {
            // Dials 1 and 2: 0 → 9 each is 1 step backward
            var result = solution.OpenLock([], "0990");
            Assert.AreEqual(2, result, $"[{solutionName}]");
        }

        #endregion

        #region Deadend Detours

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void OpenLock_DeadendForcesDetour_StillReachable(IOpenTheLock_752 solution, string solutionName)
        {
            // "0001" blocks the direct forward path on dial 3; must go via wrap 0009
            var result = solution.OpenLock(["0001"], "0002");
            Assert.IsTrue(result > 0, $"[{solutionName}] Should be reachable via detour");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void OpenLock_IrrelevantDeadend_DoesNotAffectResult(IOpenTheLock_752 solution, string solutionName)
        {
            // "9999" is nowhere near the optimal path 0000 → 1111
            var result = solution.OpenLock(["9999"], "1111");
            Assert.AreEqual(4, result, $"[{solutionName}]");
        }

        #endregion
    }
}
