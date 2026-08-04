using LeetCodeProblems.CSharp.Graph;
using LeetCodeProblems.Interfaces.Easy;
using LeetCodeProblems.VisualBasic.Graph;

namespace GrindingLeetCode.UnitTests.Easy
{
    [TestClass]
    public class FindTheTownJudge_997_Tests
    {
        public static IEnumerable<object[]> GetImplementations()
        {
            yield return new object[] { new FindTheTownJudge_CSharp_997(), "C#" };
            yield return new object[] { new FindTheTownJudge_VB_997(), "VB" };
        }

        #region LeetCode Examples

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void FindJudge_Example1_Returns2(IFindTheTownJudge_997 solution, string solutionName)
        {
            // n=2, [[1,2]] — person 1 trusts 2, person 2 trusts nobody → judge is 2
            Assert.AreEqual(2, solution.FindJudge(2, new[] { new[] { 1, 2 } }), $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void FindJudge_Example2_Returns3(IFindTheTownJudge_997 solution, string solutionName)
        {
            // n=3, [[1,3],[2,3]] — both 1 and 2 trust 3, 3 trusts nobody → judge is 3
            Assert.AreEqual(3, solution.FindJudge(3, new[] { new[] { 1, 3 }, new[] { 2, 3 } }), $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void FindJudge_Example3_ReturnsNegative1(IFindTheTownJudge_997 solution, string solutionName)
        {
            // n=3, [[1,3],[2,3],[3,1]] — 3 trusts 1, so 3 cannot be the judge
            Assert.AreEqual(-1, solution.FindJudge(3, new[] { new[] { 1, 3 }, new[] { 2, 3 }, new[] { 3, 1 } }), $"[{solutionName}]");
        }

        #endregion

        #region Single Person

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void FindJudge_SinglePerson_NoTrust_Returns1(IFindTheTownJudge_997 solution, string solutionName)
        {
            // n=1, no trust entries — the one person is trivially the judge
            Assert.AreEqual(1, solution.FindJudge(1, Array.Empty<int[]>()), $"[{solutionName}]");
        }

        #endregion

        #region No Judge Exists

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void FindJudge_EveryoneTrustsEachOther_ReturnsNegative1(IFindTheTownJudge_997 solution, string solutionName)
        {
            // n=2, [[1,2],[2,1]] — mutual trust, no judge
            Assert.AreEqual(-1, solution.FindJudge(2, new[] { new[] { 1, 2 }, new[] { 2, 1 } }), $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void FindJudge_NoTrustEntries_ThreePeople_ReturnsNegative1(IFindTheTownJudge_997 solution, string solutionName)
        {
            // n=3, no trust — nobody is trusted by n-1 others
            Assert.AreEqual(-1, solution.FindJudge(3, Array.Empty<int[]>()), $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void FindJudge_CandidateTrustsSomeone_ReturnsNegative1(IFindTheTownJudge_997 solution, string solutionName)
        {
            // n=4, person 4 trusted by 1,2,3 but also trusts 1 → disqualified
            Assert.AreEqual(-1, solution.FindJudge(4, new[]
            {
                new[] { 1, 4 }, new[] { 2, 4 }, new[] { 3, 4 }, new[] { 4, 1 }
            }), $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void FindJudge_NotTrustedByAll_ReturnsNegative1(IFindTheTownJudge_997 solution, string solutionName)
        {
            // n=4, person 4 trusted by only 1 and 2, not 3 → no judge
            Assert.AreEqual(-1, solution.FindJudge(4, new[]
            {
                new[] { 1, 4 }, new[] { 2, 4 }
            }), $"[{solutionName}]");
        }

        #endregion

        #region Judge Found

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void FindJudge_FourPeople_Returns4(IFindTheTownJudge_997 solution, string solutionName)
        {
            // n=4, everyone trusts 4, 4 trusts nobody
            Assert.AreEqual(4, solution.FindJudge(4, new[]
            {
                new[] { 1, 4 }, new[] { 2, 4 }, new[] { 3, 4 }
            }), $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void FindJudge_JudgeIsPersonOne_Returns1(IFindTheTownJudge_997 solution, string solutionName)
        {
            // n=3, judge is person 1 — others trust 1 and also trust each other
            Assert.AreEqual(1, solution.FindJudge(3, new[]
            {
                new[] { 2, 1 }, new[] { 3, 1 }, new[] { 2, 3 }
            }), $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void FindJudge_FivePeople_Returns5(IFindTheTownJudge_997 solution, string solutionName)
        {
            Assert.AreEqual(5, solution.FindJudge(5, new[]
            {
                new[] { 1, 5 }, new[] { 2, 5 }, new[] { 3, 5 }, new[] { 4, 5 },
                new[] { 1, 2 }, new[] { 2, 3 }
            }), $"[{solutionName}]");
        }

        #endregion

        #region Edge Cases

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void FindJudge_TwoPeople_NeitherTrustsOther_ReturnsNegative1(IFindTheTownJudge_997 solution, string solutionName)
        {
            // n=2, no trust — neither is trusted by the other
            Assert.AreEqual(-1, solution.FindJudge(2, Array.Empty<int[]>()), $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void FindJudge_ChainTrust_ReturnsNegative1(IFindTheTownJudge_997 solution, string solutionName)
        {
            // n=4, 1→2→3→4→1: circular chain, no judge
            Assert.AreEqual(-1, solution.FindJudge(4, new[]
            {
                new[] { 1, 2 }, new[] { 2, 3 }, new[] { 3, 4 }, new[] { 4, 1 }
            }), $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void FindJudge_AllTrustOneButOneTrustsBack_ReturnsNegative1(IFindTheTownJudge_997 solution, string solutionName)
        {
            // n=3, 1 and 2 trust 3, but 3 trusts 2 → no judge
            Assert.AreEqual(-1, solution.FindJudge(3, new[]
            {
                new[] { 1, 3 }, new[] { 2, 3 }, new[] { 3, 2 }
            }), $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void FindJudge_LargeN_JudgeInMiddle_Returns3(IFindTheTownJudge_997 solution, string solutionName)
        {
            // n=5, judge is person 3
            Assert.AreEqual(3, solution.FindJudge(5, new[]
            {
                new[] { 1, 3 }, new[] { 2, 3 }, new[] { 4, 3 }, new[] { 5, 3 },
                new[] { 1, 2 }, new[] { 2, 4 }
            }), $"[{solutionName}]");
        }

        #endregion
    }
}
