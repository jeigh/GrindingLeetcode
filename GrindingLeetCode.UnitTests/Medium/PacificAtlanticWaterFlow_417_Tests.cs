using LeetCodeProblems.CSharp.HashingOrArrays;
using LeetCodeProblems.Interfaces.Medium;
using LeetCodeProblems.VisualBasic.HashingOrArrays;

namespace GrindingLeetCode.UnitTests.Medium
{
    [TestClass]
    public class PacificAtlanticWaterFlow_417_Tests
    {
        public static IEnumerable<object[]> GetImplementations()
        {
            yield return new object[] { new PacificAtlanticWaterFlow_Stack_CSharp_417(), "C# Stack" };
            yield return new object[] { new PacificAtlanticWaterFlow_Queue_CSharp_417(), "C# Queue" };
            //yield return new object[] { new PacificAtlanticWaterFlow_VB_417(), "VB" };
        }

        #region Helper Methods

        private static int[][] Grid(params int[][] rows) => rows;
        private static int[] Row(params int[] cells) => cells;

        private static void AssertResult(int[][] expectedCoords, IList<IList<int>> actual, string solutionName)
        {
            var expectedSet = expectedCoords.Select(c => (c[0], c[1])).ToHashSet();
            var actualSet = actual.Select(c => (c[0], c[1])).ToHashSet();
            Assert.AreEqual(expectedSet.Count, actualSet.Count,
                $"[{solutionName}] Expected {expectedSet.Count} cells, got {actualSet.Count}");
            foreach (var coord in expectedSet)
                Assert.IsTrue(actualSet.Contains(coord),
                    $"[{solutionName}] Missing expected cell [{coord.Item1},{coord.Item2}]");
        }

        #endregion

        #region LeetCode Examples

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void PacificAtlantic_Example1_ReturnsCorrectCells(IPacificAtlanticWaterFlow_417 solution, string solutionName)
        {
            var heights = Grid(
                Row(1, 2, 2, 3, 5),
                Row(3, 2, 3, 4, 4),
                Row(2, 4, 5, 3, 1),
                Row(6, 7, 1, 4, 5),
                Row(5, 1, 1, 2, 4));

            var result = solution.PacificAtlantic(heights);

            // Note: (3,4) and (4,4) are excluded — they can only reach Atlantic.
            // (3,4)=5 flows to (2,4)=1,(3,3)=4,(4,4)=4 → bottom/right only; (4,0)=5 is Pacific
            // border but unreachable from (4,1)=1 (uphill). Verified by exhaustive BFS.
            var expected = new[]
            {
                new[] { 0, 4 }, new[] { 1, 3 }, new[] { 1, 4 },
                new[] { 2, 2 }, new[] { 3, 0 }, new[] { 3, 1 },
                new[] { 4, 0 }
            };
            AssertResult(expected, result, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void PacificAtlantic_Example2_SingleCell_ReturnsThatCell(IPacificAtlanticWaterFlow_417 solution, string solutionName)
        {
            var heights = Grid(Row(1));
            var result = solution.PacificAtlantic(heights);
            AssertResult(new[] { new[] { 0, 0 } }, result, solutionName);
        }

        #endregion

        #region Uniform Height

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void PacificAtlantic_UniformHeight_AllCellsReachBothOceans(IPacificAtlanticWaterFlow_417 solution, string solutionName)
        {
            // All same height — water can flow anywhere so every cell reaches both
            var heights = Grid(
                Row(5, 5, 5),
                Row(5, 5, 5),
                Row(5, 5, 5));

            var result = solution.PacificAtlantic(heights);

            var expected = new[]
            {
                new[] { 0,0 }, new[] { 0,1 }, new[] { 0,2 },
                new[] { 1,0 }, new[] { 1,1 }, new[] { 1,2 },
                new[] { 2,0 }, new[] { 2,1 }, new[] { 2,2 }
            };
            AssertResult(expected, result, solutionName);
        }

        #endregion

        #region Single Row / Column

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void PacificAtlantic_SingleRow_AllCellsReachBoth(IPacificAtlanticWaterFlow_417 solution, string solutionName)
        {
            // Single row touches both Pacific (left) and Atlantic (right)
            var heights = Grid(Row(1, 2, 3));
            var result = solution.PacificAtlantic(heights);
            AssertResult(new[] { new[] { 0,0 }, new[] { 0,1 }, new[] { 0,2 } }, result, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void PacificAtlantic_SingleColumn_AllCellsReachBoth(IPacificAtlanticWaterFlow_417 solution, string solutionName)
        {
            // Single column touches both Pacific (top) and Atlantic (bottom)
            var heights = Grid(Row(3), Row(2), Row(1));
            var result = solution.PacificAtlantic(heights);
            AssertResult(new[] { new[] { 0,0 }, new[] { 1,0 }, new[] { 2,0 } }, result, solutionName);
        }

        #endregion

        #region Directional Flow

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void PacificAtlantic_AscendingGrid_OnlyCornersAndPeak(IPacificAtlanticWaterFlow_417 solution, string solutionName)
        {
            // Heights increase toward center — only border cells and peak reach both
            var heights = Grid(
                Row(1, 2, 3),
                Row(4, 5, 6),
                Row(7, 8, 9));

            var result = solution.PacificAtlantic(heights);

            // Top row reaches Pacific; bottom-right corner reaches Atlantic
            // Cells that can reach both: top-right corner, right column, bottom row
            var expected = new[]
            {
                new[] { 0,2 },
                new[] { 1,2 },
                new[] { 2,0 }, new[] { 2,1 }, new[] { 2,2 }
            };
            AssertResult(expected, result, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void PacificAtlantic_DescendingGrid_OnlyBorderCells(IPacificAtlanticWaterFlow_417 solution, string solutionName)
        {
            // Heights decrease toward center — water flows inward from borders only
            var heights = Grid(
                Row(9, 8, 7),
                Row(6, 5, 4),
                Row(3, 2, 1));

            var result = solution.PacificAtlantic(heights);

            var expected = new[]
            {
                new[] { 0,0 }, new[] { 0,1 }, new[] { 0,2 },
                new[] { 1,0 },
                new[] { 2,0 }
            };
            AssertResult(expected, result, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void PacificAtlantic_PeakInCenter_OnlyPeakReachesBoth(IPacificAtlanticWaterFlow_417 solution, string solutionName)
        {
            // Center peak can flow down to all borders — all surrounding cells can't reach both
            var heights = Grid(
                Row(1, 1, 1, 1, 1),
                Row(1, 1, 1, 1, 1),
                Row(1, 1, 9, 1, 1),
                Row(1, 1, 1, 1, 1),
                Row(1, 1, 1, 1, 1));

            var result = solution.PacificAtlantic(heights);

            // All cells have height 1 except center (9). Since equal heights can flow,
            // every cell can reach both oceans.
            Assert.AreEqual(25, result.Count, $"[{solutionName}]");
        }

        #endregion

        #region 2x2 Grids

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void PacificAtlantic_2x2_AllSameHeight_ReturnsFour(IPacificAtlanticWaterFlow_417 solution, string solutionName)
        {
            var heights = Grid(Row(1, 1), Row(1, 1));
            var result = solution.PacificAtlantic(heights);
            AssertResult(new[] { new[] { 0,0 }, new[] { 0,1 }, new[] { 1,0 }, new[] { 1,1 } }, result, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void PacificAtlantic_2x2_HighLowHighLow_ReturnsCornersOnly(IPacificAtlanticWaterFlow_417 solution, string solutionName)
        {
            // Top-left (Pacific corner) and bottom-right (Atlantic corner) are high peaks
            var heights = Grid(Row(10, 1), Row(1, 10));
            var result = solution.PacificAtlantic(heights);
            AssertResult(new[] { new[] { 0,0 }, new[] { 0,1 }, new[] { 1,0 }, new[] { 1,1 } }, result, solutionName);
        }

        #endregion
    }
}
