using LeetCodeProblems.CSharp.Graph;
using LeetCodeProblems.Interfaces.Medium;
using LeetCodeProblems.VisualBasic.Graph;

namespace GrindingLeetCode.UnitTests.Medium
{
    [TestClass]
    public class NumberOfIslands_200_Tests
    {
        public static IEnumerable<object[]> GetImplementations()
        {
            yield return new object[] { new NumberOfIslands_CSharp_200(), "C#" };
            //yield return new object[] { new NumberOfIslands_VB_200(), "VB" };
        }

        #region Helper Methods

        private static char[][] Grid(params string[] rows) =>
            rows.Select(r => r.ToCharArray()).ToArray();

        #endregion

        #region LeetCode Examples

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void NumIslands_Example1_Returns1(INumberOfIslands_200 solution, string solutionName)
        {
            var grid = Grid(
                "11110",
                "11010",
                "11000",
                "00000");
            Assert.AreEqual(1, solution.NumIslands(grid), $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void NumIslands_Example2_Returns3(INumberOfIslands_200 solution, string solutionName)
        {
            var grid = Grid(
                "11000",
                "11000",
                "00100",
                "00011");
            Assert.AreEqual(3, solution.NumIslands(grid), $"[{solutionName}]");
        }

        #endregion

        #region Single Cell

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void NumIslands_SingleLandCell_Returns1(INumberOfIslands_200 solution, string solutionName)
        {
            Assert.AreEqual(1, solution.NumIslands(Grid("1")), $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void NumIslands_SingleWaterCell_Returns0(INumberOfIslands_200 solution, string solutionName)
        {
            Assert.AreEqual(0, solution.NumIslands(Grid("0")), $"[{solutionName}]");
        }

        #endregion

        #region All Land / All Water

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void NumIslands_AllLand_Returns1(INumberOfIslands_200 solution, string solutionName)
        {
            var grid = Grid(
                "111",
                "111",
                "111");
            Assert.AreEqual(1, solution.NumIslands(grid), $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void NumIslands_AllWater_Returns0(INumberOfIslands_200 solution, string solutionName)
        {
            var grid = Grid(
                "000",
                "000",
                "000");
            Assert.AreEqual(0, solution.NumIslands(grid), $"[{solutionName}]");
        }

        #endregion

        #region Diagonal Islands

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void NumIslands_DiagonalCells_EachIsOwnIsland_Returns4(INumberOfIslands_200 solution, string solutionName)
        {
            // diagonal cells are NOT connected — each is its own island
            var grid = Grid(
                "10",
                "01");
            Assert.AreEqual(2, solution.NumIslands(grid), $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void NumIslands_CheckerboardPattern_Returns4(INumberOfIslands_200 solution, string solutionName)
        {
            var grid = Grid(
                "101",
                "010",
                "101");
            Assert.AreEqual(5, solution.NumIslands(grid), $"[{solutionName}]");
        }

        #endregion

        #region Linear Islands

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void NumIslands_HorizontalStrip_Returns1(INumberOfIslands_200 solution, string solutionName)
        {
            Assert.AreEqual(1, solution.NumIslands(Grid("1111")), $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void NumIslands_VerticalStrip_Returns1(INumberOfIslands_200 solution, string solutionName)
        {
            var grid = Grid("1", "1", "1", "1");
            Assert.AreEqual(1, solution.NumIslands(grid), $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void NumIslands_TwoHorizontalStrips_Returns2(INumberOfIslands_200 solution, string solutionName)
        {
            var grid = Grid(
                "1111",
                "0000",
                "1111");
            Assert.AreEqual(2, solution.NumIslands(grid), $"[{solutionName}]");
        }

        #endregion

        #region Separated Islands

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void NumIslands_FourCornerIslands_Returns4(INumberOfIslands_200 solution, string solutionName)
        {
            var grid = Grid(
                "101",
                "000",
                "101");
            Assert.AreEqual(4, solution.NumIslands(grid), $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void NumIslands_ManySmallIslands_Returns5(INumberOfIslands_200 solution, string solutionName)
        {
            var grid = Grid(
                "10101",
                "00000",
                "10101");
            Assert.AreEqual(6, solution.NumIslands(grid), $"[{solutionName}]");
        }

        #endregion

        #region Complex Shapes

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void NumIslands_UShape_Returns1(INumberOfIslands_200 solution, string solutionName)
        {
            var grid = Grid(
                "101",
                "101",
                "111");
            Assert.AreEqual(1, solution.NumIslands(grid), $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void NumIslands_RingShape_Returns1(INumberOfIslands_200 solution, string solutionName)
        {
            var grid = Grid(
                "1111",
                "1001",
                "1001",
                "1111");
            Assert.AreEqual(1, solution.NumIslands(grid), $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void NumIslands_TwoLargeIslands_Returns2(INumberOfIslands_200 solution, string solutionName)
        {
            var grid = Grid(
                "11100",
                "11100",
                "00011",
                "00011");
            Assert.AreEqual(2, solution.NumIslands(grid), $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void NumIslands_IslandTouchingAllEdges_Returns1(INumberOfIslands_200 solution, string solutionName)
        {
            var grid = Grid(
                "11111",
                "10001",
                "10101",
                "10001",
                "11111");
            Assert.AreEqual(2, solution.NumIslands(grid), $"[{solutionName}]");
        }

        #endregion
    }
}
