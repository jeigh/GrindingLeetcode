using LeetCodeProblems.CSharp.Graph;
using LeetCodeProblems.Interfaces.Medium;

namespace GrindingLeetCode.UnitTests.Medium
{
    [TestClass]
    public class CourseScheduleII_210_Tests
    {
        public static IEnumerable<object[]> GetImplementations()
        {
            yield return new object[] { new CourseScheduleII_Solution_CSharp_210(), "C# Solution" };
            yield return new object[] { new CourseScheduleII_Iterative_Solution_CSharp_210(), "C# Iterative Solution" };

            yield break;
        }

        #region LeetCode Examples

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void FindOrder_Example1_TwoCoursesOnePrereq_ReturnsValidOrder(ICourseScheduleII_210 solution, string solutionName)
        {
            // Take course 0, then course 1
            var result = solution.FindOrder(2, [[1, 0]]);
            CollectionAssert.AreEqual(new[] { 0, 1 }, result, $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void FindOrder_Example2_DiamondDependency_ReturnsValidOrder(ICourseScheduleII_210 solution, string solutionName)
        {
            // 0 is prereq for 1 and 2; both 1 and 2 are prereqs for 3
            var result = solution.FindOrder(4, [[1, 0], [2, 0], [3, 1], [3, 2]]);
            Assert.IsTrue(IsValidTopologicalOrder(result, 4, [[1, 0], [2, 0], [3, 1], [3, 2]]), $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void FindOrder_Example3_SingleCourseNoPrereqs_ReturnsSingleElementOrder(ICourseScheduleII_210 solution, string solutionName)
        {
            var result = solution.FindOrder(1, []);
            CollectionAssert.AreEqual(new[] { 0 }, result, $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void FindOrder_DirectCycle_ReturnsEmptyArray(ICourseScheduleII_210 solution, string solutionName)
        {
            // 0 requires 1, 1 requires 0 — impossible
            var result = solution.FindOrder(2, [[1, 0], [0, 1]]);
            Assert.AreEqual(0, result.Length, $"[{solutionName}]");
        }

        #endregion

        #region No Prerequisites

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void FindOrder_TwoCourses_NoPrereqs_ReturnsValidOrder(ICourseScheduleII_210 solution, string solutionName)
        {
            var result = solution.FindOrder(2, []);
            Assert.IsTrue(IsValidTopologicalOrder(result, 2, []), $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void FindOrder_ManyCourses_NoPrereqs_ReturnsValidOrder(ICourseScheduleII_210 solution, string solutionName)
        {
            var result = solution.FindOrder(100, []);
            Assert.IsTrue(IsValidTopologicalOrder(result, 100, []), $"[{solutionName}]");
        }

        #endregion

        #region Valid Orderings (no cycle)

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void FindOrder_LinearChain_ReturnsValidOrder(ICourseScheduleII_210 solution, string solutionName)
        {
            // 0 → 1 → 2 → 3
            var result = solution.FindOrder(4, [[1, 0], [2, 1], [3, 2]]);
            CollectionAssert.AreEqual(new[] { 0, 1, 2, 3 }, result, $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void FindOrder_AllBranchFromRoot_ReturnsValidOrder(ICourseScheduleII_210 solution, string solutionName)
        {
            // 0 is prereq for 1, 2, and 3
            var prerequisites = new[] { new[] { 1, 0 }, new[] { 2, 0 }, new[] { 3, 0 } };
            var result = solution.FindOrder(4, prerequisites);
            Assert.IsTrue(IsValidTopologicalOrder(result, 4, prerequisites), $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void FindOrder_AllConvergeToLeaf_ReturnsValidOrder(ICourseScheduleII_210 solution, string solutionName)
        {
            // 1, 2, 3, 4 all require course 0 as a prereq
            var prerequisites = new[] { new[] { 0, 1 }, new[] { 0, 2 }, new[] { 0, 3 }, new[] { 0, 4 } };
            var result = solution.FindOrder(5, prerequisites);
            Assert.IsTrue(IsValidTopologicalOrder(result, 5, prerequisites), $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void FindOrder_DiamondDependency_ReturnsValidOrder(ICourseScheduleII_210 solution, string solutionName)
        {
            // 0 and 1 both feed into 2, which feeds into 3
            var prerequisites = new[] { new[] { 2, 0 }, new[] { 2, 1 }, new[] { 3, 2 } };
            var result = solution.FindOrder(4, prerequisites);
            Assert.IsTrue(IsValidTopologicalOrder(result, 4, prerequisites), $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void FindOrder_DisconnectedChains_ReturnsValidOrder(ICourseScheduleII_210 solution, string solutionName)
        {
            // Three independent chains: 0→1, 2→3, 4→5
            var prerequisites = new[] { new[] { 1, 0 }, new[] { 3, 2 }, new[] { 5, 4 } };
            var result = solution.FindOrder(6, prerequisites);
            Assert.IsTrue(IsValidTopologicalOrder(result, 6, prerequisites), $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void FindOrder_SharedPrereq_ReturnsValidOrder(ICourseScheduleII_210 solution, string solutionName)
        {
            // Course 0 is prereq for both 1 and 2
            var prerequisites = new[] { new[] { 1, 0 }, new[] { 2, 0 } };
            var result = solution.FindOrder(3, prerequisites);
            Assert.IsTrue(IsValidTopologicalOrder(result, 3, prerequisites), $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void FindOrder_TwoPathsToSameCourse_ReturnsValidOrder(ICourseScheduleII_210 solution, string solutionName)
        {
            // Both 0 and 1 are prereqs of 2; 2 is prereq of 3 and 4; 4 is prereq of 5
            var prerequisites = new[] { new[] { 1, 0 }, new[] { 2, 0 }, new[] { 3, 1 }, new[] { 3, 2 }, new[] { 4, 3 } };
            var result = solution.FindOrder(5, prerequisites);
            Assert.IsTrue(IsValidTopologicalOrder(result, 5, prerequisites), $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void FindOrder_LongChainAllCourses_ReturnsValidOrder(ICourseScheduleII_210 solution, string solutionName)
        {
            // 0 → 1 → 2 → 3 → 4
            var result = solution.FindOrder(5, [[1, 0], [2, 1], [3, 2], [4, 3]]);
            CollectionAssert.AreEqual(new[] { 0, 1, 2, 3, 4 }, result, $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void FindOrder_ReverseChain_ReturnsValidOrder(ICourseScheduleII_210 solution, string solutionName)
        {
            // Course 2 is prereq for both 0 and 1
            var prerequisites = new[] { new[] { 0, 2 }, new[] { 1, 2 } };
            var result = solution.FindOrder(3, prerequisites);
            Assert.IsTrue(IsValidTopologicalOrder(result, 3, prerequisites), $"[{solutionName}]");
        }

        #endregion

        #region Cycles (impossible)

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void FindOrder_TriangleCycle_ReturnsEmptyArray(ICourseScheduleII_210 solution, string solutionName)
        {
            // 0 → 1 → 2 → 0
            var result = solution.FindOrder(3, [[1, 0], [2, 1], [0, 2]]);
            Assert.AreEqual(0, result.Length, $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void FindOrder_LongCycle_ReturnsEmptyArray(ICourseScheduleII_210 solution, string solutionName)
        {
            // 0 → 1 → 2 → 3 → 4 → 0
            var result = solution.FindOrder(5, [[1, 0], [2, 1], [3, 2], [4, 3], [0, 4]]);
            Assert.AreEqual(0, result.Length, $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void FindOrder_CycleAtEndOfChain_ReturnsEmptyArray(ICourseScheduleII_210 solution, string solutionName)
        {
            // Chain 0→1→2→3, then 3 and 4 form a cycle: 3→4→3
            var result = solution.FindOrder(5, [[1, 0], [2, 1], [3, 2], [4, 3], [3, 4]]);
            Assert.AreEqual(0, result.Length, $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void FindOrder_CycleWithExternalNode_ReturnsEmptyArray(ICourseScheduleII_210 solution, string solutionName)
        {
            // 0↔1 cycle; course 2 depends on 1 but is not part of the cycle
            var result = solution.FindOrder(3, [[1, 0], [0, 1], [2, 1]]);
            Assert.AreEqual(0, result.Length, $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void FindOrder_DisconnectedSubgraphWithCycle_ReturnsEmptyArray(ICourseScheduleII_210 solution, string solutionName)
        {
            // 0↔1 cycle in one component; 2→3 valid in another
            var result = solution.FindOrder(4, [[1, 0], [0, 1], [3, 2]]);
            Assert.AreEqual(0, result.Length, $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void FindOrder_TwoDisconnectedCycles_ReturnsEmptyArray(ICourseScheduleII_210 solution, string solutionName)
        {
            // 0↔1 and 2↔3, both cycles
            var result = solution.FindOrder(4, [[0, 1], [1, 0], [2, 3], [3, 2]]);
            Assert.AreEqual(0, result.Length, $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void FindOrder_HiddenCycleInLargeGraph_ReturnsEmptyArray(ICourseScheduleII_210 solution, string solutionName)
        {
            // Chain 0→1→2→3→4→5 with back-edge 5→1 creating a cycle
            var result = solution.FindOrder(6, [[1, 0], [2, 1], [3, 2], [4, 3], [5, 4], [1, 5]]);
            Assert.AreEqual(0, result.Length, $"[{solutionName}]");
        }

        #endregion

        #region Helper Methods

        // Verifies `order` is a permutation of 0..numCourses-1 that satisfies every
        // prerequisite constraint (bi appears before ai for each [ai, bi] pair).
        private static bool IsValidTopologicalOrder(int[] order, int numCourses, int[][] prerequisites)
        {
            if (order.Length != numCourses) return false;

            var position = new int[numCourses];
            var seen = new HashSet<int>();
            for (int i = 0; i < order.Length; i++)
            {
                if (order[i] < 0 || order[i] >= numCourses) return false;
                if (!seen.Add(order[i])) return false;
                position[order[i]] = i;
            }

            foreach (var prereq in prerequisites)
            {
                var course = prereq[0];
                var prerequisite = prereq[1];
                if (position[prerequisite] > position[course]) return false;
            }

            return true;
        }

        #endregion
    }
}
