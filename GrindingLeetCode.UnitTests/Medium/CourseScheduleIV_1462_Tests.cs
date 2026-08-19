using LeetCodeProblems.CSharp.Graph;
using LeetCodeProblems.Interfaces.Medium;
using LeetCodeProblems.VisualBasic.Graph;

namespace GrindingLeetCode.UnitTests.Medium
{
    [TestClass]
    public class CourseScheduleIV_1462_Tests
    {
        public static IEnumerable<object[]> GetImplementations()
        {
            // Uncomment as each implementation is written.
            yield return new object[] { new CourseScheduleIV_Solution_CSharp_1462(), "C# Solution" };
            yield return new object[] { new CourseScheduleIV_Solution_VB_1462(), "VB Solution" };

            yield break;
        }

        #region LeetCode Examples

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CheckIfPrerequisite_Example1_ReturnsExpectedAnswers(ICourseScheduleIV_1462 solution, string solutionName)
        {
            var result = solution.CheckIfPrerequisite(2, [[1, 0]], [[0, 1], [1, 0]]);
            CollectionAssert.AreEqual(new[] { false, true }, (System.Collections.ICollection)result, $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CheckIfPrerequisite_Example2_NoPrereqs_ReturnsAllFalse(ICourseScheduleIV_1462 solution, string solutionName)
        {
            var result = solution.CheckIfPrerequisite(2, [], [[1, 0], [0, 1]]);
            CollectionAssert.AreEqual(new[] { false, false }, (System.Collections.ICollection)result, $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CheckIfPrerequisite_Example3_DirectPrereqs_ReturnsTrue(ICourseScheduleIV_1462 solution, string solutionName)
        {
            var result = solution.CheckIfPrerequisite(3, [[1, 2], [1, 0], [2, 0]], [[1, 0], [1, 2]]);
            CollectionAssert.AreEqual(new[] { true, true }, (System.Collections.ICollection)result, $"[{solutionName}]");
        }

        #endregion

        #region No Prerequisites

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CheckIfPrerequisite_ManyCourses_NoPrereqs_AllQueriesFalse(ICourseScheduleIV_1462 solution, string solutionName)
        {
            var result = solution.CheckIfPrerequisite(5, [], [[0, 1], [2, 3], [4, 0]]);
            CollectionAssert.AreEqual(new[] { false, false, false }, (System.Collections.ICollection)result, $"[{solutionName}]");
        }

        #endregion

        #region Direct Prerequisites

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CheckIfPrerequisite_SingleDirectPrerequisite_ReturnsTrue(ICourseScheduleIV_1462 solution, string solutionName)
        {
            var result = solution.CheckIfPrerequisite(2, [[0, 1]], [[0, 1]]);
            CollectionAssert.AreEqual(new[] { true }, (System.Collections.ICollection)result, $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CheckIfPrerequisite_ReverseOfDirectPrerequisite_ReturnsFalse(ICourseScheduleIV_1462 solution, string solutionName)
        {
            var result = solution.CheckIfPrerequisite(2, [[0, 1]], [[1, 0]]);
            CollectionAssert.AreEqual(new[] { false }, (System.Collections.ICollection)result, $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CheckIfPrerequisite_MultipleDirectFromSameCourse_SiblingsAreNotPrereqs(ICourseScheduleIV_1462 solution, string solutionName)
        {
            var result = solution.CheckIfPrerequisite(4, [[0, 1], [0, 2], [0, 3]], [[0, 1], [0, 2], [0, 3], [1, 2]]);
            CollectionAssert.AreEqual(new[] { true, true, true, false }, (System.Collections.ICollection)result, $"[{solutionName}]");
        }

        #endregion

        #region Transitive Prerequisites

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CheckIfPrerequisite_TransitiveChain_ReturnsTrue(ICourseScheduleIV_1462 solution, string solutionName)
        {
            // 0 -> 1 -> 2 -> 3
            var result = solution.CheckIfPrerequisite(4, [[0, 1], [1, 2], [2, 3]], [[0, 3]]);
            CollectionAssert.AreEqual(new[] { true }, (System.Collections.ICollection)result, $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CheckIfPrerequisite_TransitiveChain_AllIntermediateStepsTrue(ICourseScheduleIV_1462 solution, string solutionName)
        {
            var result = solution.CheckIfPrerequisite(4, [[0, 1], [1, 2], [2, 3]], [[0, 1], [0, 2], [0, 3], [1, 3]]);
            CollectionAssert.AreEqual(new[] { true, true, true, true }, (System.Collections.ICollection)result, $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CheckIfPrerequisite_TransitiveChain_WrongDirectionReturnsFalse(ICourseScheduleIV_1462 solution, string solutionName)
        {
            var result = solution.CheckIfPrerequisite(4, [[0, 1], [1, 2], [2, 3]], [[3, 0]]);
            CollectionAssert.AreEqual(new[] { false }, (System.Collections.ICollection)result, $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CheckIfPrerequisite_DiamondConvergence_ReturnsTrue(ICourseScheduleIV_1462 solution, string solutionName)
        {
            // 0 -> 1 -> 3 and 0 -> 2 -> 3
            var result = solution.CheckIfPrerequisite(4, [[0, 1], [0, 2], [1, 3], [2, 3]], [[0, 3]]);
            CollectionAssert.AreEqual(new[] { true }, (System.Collections.ICollection)result, $"[{solutionName}]");
        }

        #endregion

        #region Non-Prerequisites

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CheckIfPrerequisite_UnrelatedCourses_ReturnsFalse(ICourseScheduleIV_1462 solution, string solutionName)
        {
            var result = solution.CheckIfPrerequisite(5, [[0, 1], [2, 3]], [[0, 3], [2, 1], [4, 0]]);
            CollectionAssert.AreEqual(new[] { false, false, false }, (System.Collections.ICollection)result, $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CheckIfPrerequisite_SiblingCourses_NeitherIsPrereqOfOther(ICourseScheduleIV_1462 solution, string solutionName)
        {
            var result = solution.CheckIfPrerequisite(3, [[0, 1], [0, 2]], [[1, 2], [2, 1]]);
            CollectionAssert.AreEqual(new[] { false, false }, (System.Collections.ICollection)result, $"[{solutionName}]");
        }

        #endregion

        #region Mixed Results

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CheckIfPrerequisite_MixedTrueAndFalseResults(ICourseScheduleIV_1462 solution, string solutionName)
        {
            // 0 -> 1 -> 2 -> 3 -> 4
            var result = solution.CheckIfPrerequisite(5, [[0, 1], [1, 2], [2, 3], [3, 4]], [[0, 4], [4, 0], [1, 3], [3, 1]]);
            CollectionAssert.AreEqual(new[] { true, false, true, false }, (System.Collections.ICollection)result, $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CheckIfPrerequisite_TwoDisconnectedChains_CrossComponentQueriesFalse(ICourseScheduleIV_1462 solution, string solutionName)
        {
            // 0 -> 1 -> 2  and  3 -> 4 -> 5
            var result = solution.CheckIfPrerequisite(6, [[0, 1], [1, 2], [3, 4], [4, 5]], [[0, 2], [3, 5], [0, 4], [2, 3]]);
            CollectionAssert.AreEqual(new[] { true, true, false, false }, (System.Collections.ICollection)result, $"[{solutionName}]");
        }

        #endregion

        #region Larger Graphs

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CheckIfPrerequisite_WideBranchingFanOut(ICourseScheduleIV_1462 solution, string solutionName)
        {
            var result = solution.CheckIfPrerequisite(6, [[0, 1], [0, 2], [0, 3], [0, 4], [0, 5]], [[0, 1], [0, 5], [1, 2]]);
            CollectionAssert.AreEqual(new[] { true, true, false }, (System.Collections.ICollection)result, $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CheckIfPrerequisite_LongChainAllTransitive(ICourseScheduleIV_1462 solution, string solutionName)
        {
            var result = solution.CheckIfPrerequisite(6, [[0, 1], [1, 2], [2, 3], [3, 4], [4, 5]], [[0, 5], [0, 3], [2, 5], [5, 0]]);
            CollectionAssert.AreEqual(new[] { true, true, true, false }, (System.Collections.ICollection)result, $"[{solutionName}]");
        }

        #endregion

        #region Edge Cases

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CheckIfPrerequisite_EmptyQueries_ReturnsEmptyList(ICourseScheduleIV_1462 solution, string solutionName)
        {
            var result = solution.CheckIfPrerequisite(3, [[0, 1], [1, 2]], []);
            Assert.AreEqual(0, result.Count, $"[{solutionName}]");
        }

        #endregion
    }
}
