using LeetCodeProblems.CSharp.Graph;
using LeetCodeProblems.Interfaces.Medium;

namespace GrindingLeetCode.UnitTests.Medium
{
    [TestClass]
    public class CourseSchedule_207_Tests
    {
        public static IEnumerable<object[]> GetImplementations()
        {
            //yield return new object[] { new CourseSchedule_Kahns_CSharp_207(), "C# Kahn's" };
            yield return new object[] { new CourseSchedule_DFS_CSharp_207(), "C# DFS" };
            yield return new object[] { new CourseSchedule_FLATTENED_DFS_CSharp_207(), "C# Flattened DFS" };

            //yield return new object[] { new CourseSchedule_Kahns_VB_207(), "VB Kahn's" };
            //yield return new object[] { new CourseSchedule_DFS_VB_207(), "VB DFS" };
        }

        #region LeetCode Examples

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CanFinish_Example1_TwoCoursesOnePrereq_ReturnsTrue(ICourseSchedule_207 solution, string solutionName)
        {
            // Take course 0, then course 1
            var result = solution.CanFinish(2, [[1, 0]]);
            Assert.IsTrue(result, $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CanFinish_Example2_DirectCycle_ReturnsFalse(ICourseSchedule_207 solution, string solutionName)
        {
            // 0 requires 1, 1 requires 0 — impossible
            var result = solution.CanFinish(2, [[1, 0], [0, 1]]);
            Assert.IsFalse(result, $"[{solutionName}]");
        }

        #endregion

        #region No Prerequisites

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CanFinish_SingleCourse_NoPrereqs_ReturnsTrue(ICourseSchedule_207 solution, string solutionName)
        {
            var result = solution.CanFinish(1, []);
            Assert.IsTrue(result, $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CanFinish_TwoCourses_NoPrereqs_ReturnsTrue(ICourseSchedule_207 solution, string solutionName)
        {
            var result = solution.CanFinish(2, []);
            Assert.IsTrue(result, $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CanFinish_ManyCourses_NoPrereqs_ReturnsTrue(ICourseSchedule_207 solution, string solutionName)
        {
            var result = solution.CanFinish(100, []);
            Assert.IsTrue(result, $"[{solutionName}]");
        }

        #endregion

        #region Valid Orderings (no cycle)

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CanFinish_LinearChain_ReturnsTrue(ICourseSchedule_207 solution, string solutionName)
        {
            // 0 → 1 → 2 → 3
            var result = solution.CanFinish(4, [[1, 0], [2, 1], [3, 2]]);
            Assert.IsTrue(result, $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CanFinish_AllBranchFromRoot_ReturnsTrue(ICourseSchedule_207 solution, string solutionName)
        {
            // 0 is prereq for 1, 2, and 3
            var result = solution.CanFinish(4, [[1, 0], [2, 0], [3, 0]]);
            Assert.IsTrue(result, $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CanFinish_AllConvergeToLeaf_ReturnsTrue(ICourseSchedule_207 solution, string solutionName)
        {
            // 1, 2, 3, 4 all require course 0 as a prereq
            var result = solution.CanFinish(5, [[0, 1], [0, 2], [0, 3], [0, 4]]);
            Assert.IsTrue(result, $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CanFinish_DiamondDependency_ReturnsTrue(ICourseSchedule_207 solution, string solutionName)
        {
            // 0 and 1 both feed into 2, which feeds into 3
            var result = solution.CanFinish(4, [[2, 0], [2, 1], [3, 2]]);
            Assert.IsTrue(result, $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CanFinish_DisconnectedChains_ReturnsTrue(ICourseSchedule_207 solution, string solutionName)
        {
            // Three independent chains: 0→1, 2→3, 4→5
            var result = solution.CanFinish(6, [[1, 0], [3, 2], [5, 4]]);
            Assert.IsTrue(result, $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CanFinish_SharedPrereq_ReturnsTrue(ICourseSchedule_207 solution, string solutionName)
        {
            // Course 0 is prereq for both 1 and 2
            var result = solution.CanFinish(3, [[1, 0], [2, 0]]);
            Assert.IsTrue(result, $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CanFinish_TwoPathsToSameCourse_ReturnsTrue(ICourseSchedule_207 solution, string solutionName)
        {
            // Both 0 and 1 are prereqs of 2; 2 is prereq of 3 and 4; 4 is prereq of 5
            var result = solution.CanFinish(5, [[1, 0], [2, 0], [3, 1], [3, 2], [4, 3]]);
            Assert.IsTrue(result, $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CanFinish_LongChainAllCourses_ReturnsTrue(ICourseSchedule_207 solution, string solutionName)
        {
            // 0 → 1 → 2 → 3 → 4
            var result = solution.CanFinish(5, [[1, 0], [2, 1], [3, 2], [4, 3]]);
            Assert.IsTrue(result, $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CanFinish_ReverseChain_ReturnsTrue(ICourseSchedule_207 solution, string solutionName)
        {
            // Course 2 is prereq for both 0 and 1
            var result = solution.CanFinish(3, [[0, 2], [1, 2]]);
            Assert.IsTrue(result, $"[{solutionName}]");
        }

        #endregion

        #region Cycles (impossible)

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CanFinish_TriangleCycle_ReturnsFalse(ICourseSchedule_207 solution, string solutionName)
        {
            // 0 → 1 → 2 → 0
            var result = solution.CanFinish(3, [[1, 0], [2, 1], [0, 2]]);
            Assert.IsFalse(result, $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CanFinish_LongCycle_ReturnsFalse(ICourseSchedule_207 solution, string solutionName)
        {
            // 0 → 1 → 2 → 3 → 4 → 0
            var result = solution.CanFinish(5, [[1, 0], [2, 1], [3, 2], [4, 3], [0, 4]]);
            Assert.IsFalse(result, $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CanFinish_CycleAtEndOfChain_ReturnsFalse(ICourseSchedule_207 solution, string solutionName)
        {
            // Chain 0→1→2→3, then 3 and 4 form a cycle: 3→4→3
            var result = solution.CanFinish(5, [[1, 0], [2, 1], [3, 2], [4, 3], [3, 4]]);
            Assert.IsFalse(result, $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CanFinish_CycleWithExternalNode_ReturnsFalse(ICourseSchedule_207 solution, string solutionName)
        {
            // 0↔1 cycle; course 2 depends on 1 but is not part of the cycle
            var result = solution.CanFinish(3, [[1, 0], [0, 1], [2, 1]]);
            Assert.IsFalse(result, $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CanFinish_DisconnectedSubgraphWithCycle_ReturnsFalse(ICourseSchedule_207 solution, string solutionName)
        {
            // 0↔1 cycle in one component; 2→3 valid in another
            var result = solution.CanFinish(4, [[1, 0], [0, 1], [3, 2]]);
            Assert.IsFalse(result, $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CanFinish_TwoDisconnectedCycles_ReturnsFalse(ICourseSchedule_207 solution, string solutionName)
        {
            // 0↔1 and 2↔3, both cycles
            var result = solution.CanFinish(4, [[0, 1], [1, 0], [2, 3], [3, 2]]);
            Assert.IsFalse(result, $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CanFinish_HiddenCycleInLargeGraph_ReturnsFalse(ICourseSchedule_207 solution, string solutionName)
        {
            // Chain 0→1→2→3→4→5 with back-edge 5→1 creating a cycle
            var result = solution.CanFinish(6, [[1, 0], [2, 1], [3, 2], [4, 3], [5, 4], [1, 5]]);
            Assert.IsFalse(result, $"[{solutionName}]");
        }

        #endregion
    }
}
