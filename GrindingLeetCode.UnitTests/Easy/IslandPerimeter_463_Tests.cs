using LeetCodeProblems.CSharp.HashingOrArrays;
using LeetCodeProblems.Interfaces.Easy;
using LeetCodeProblems.VisualBasic.HashingOrArrays;

namespace GrindingLeetCode.UnitTests.Easy
{
    [TestClass]
    public class IslandPerimeter_463_Tests
    {
        public static IEnumerable<object[]> GetImplementations()
        {
            yield return new object[] { new IslandPerimeter_CSharp_463(), "C#" };
            yield return new object[] { new IslandPerimeter_recursive_CSharp_463(), "CS Recursive" };
        }

        #region Helper Methods

        private static int[][] Grid(params int[][] rows) => rows;
        private static int[] Row(params int[] cells) => cells;

        #endregion

        #region LeetCode Examples

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IslandPerimeter_Example1_Returns16(IIslandPerimeter_463 solution, string solutionName)
        {
            // [[0,1,0,0],[1,1,1,0],[0,1,0,0],[1,1,0,0]]
            var grid = Grid(
                Row(0, 1, 0, 0),
                Row(1, 1, 1, 0),
                Row(0, 1, 0, 0),
                Row(1, 1, 0, 0));
            Assert.AreEqual(16, solution.IslandPerimeter(grid), $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IslandPerimeter_Example2_SingleCell_Returns4(IIslandPerimeter_463 solution, string solutionName)
        {
            // [[1]]
            var grid = Grid(Row(1));
            Assert.AreEqual(4, solution.IslandPerimeter(grid), $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IslandPerimeter_Example3_HorizontalLine_Returns6(IIslandPerimeter_463 solution, string solutionName)
        {
            // [[1,0]] → single cell perimeter=4; [[1,1]] → two adjacent cells perimeter=6
            var grid = Grid(Row(1, 1));
            Assert.AreEqual(6, solution.IslandPerimeter(grid), $"[{solutionName}]");
        }

        #endregion

        #region Single Cell

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IslandPerimeter_SingleCellInLargerGrid_Returns4(IIslandPerimeter_463 solution, string solutionName)
        {
            var grid = Grid(
                Row(0, 0, 0),
                Row(0, 1, 0),
                Row(0, 0, 0));
            Assert.AreEqual(4, solution.IslandPerimeter(grid), $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IslandPerimeter_SingleCellCorner_Returns4(IIslandPerimeter_463 solution, string solutionName)
        {
            var grid = Grid(
                Row(1, 0),
                Row(0, 0));
            Assert.AreEqual(4, solution.IslandPerimeter(grid), $"[{solutionName}]");
        }

        #endregion

        #region Linear Islands

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IslandPerimeter_HorizontalLine3_Returns8(IIslandPerimeter_463 solution, string solutionName)
        {
            var grid = Grid(Row(1, 1, 1));
            Assert.AreEqual(8, solution.IslandPerimeter(grid), $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IslandPerimeter_VerticalLine3_Returns8(IIslandPerimeter_463 solution, string solutionName)
        {
            var grid = Grid(Row(1), Row(1), Row(1));
            Assert.AreEqual(8, solution.IslandPerimeter(grid), $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IslandPerimeter_HorizontalLine4_Returns10(IIslandPerimeter_463 solution, string solutionName)
        {
            var grid = Grid(Row(1, 1, 1, 1));
            Assert.AreEqual(10, solution.IslandPerimeter(grid), $"[{solutionName}]");
        }

        #endregion

        #region Rectangular Islands

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IslandPerimeter_2x2Square_Returns8(IIslandPerimeter_463 solution, string solutionName)
        {
            var grid = Grid(
                Row(1, 1),
                Row(1, 1));
            Assert.AreEqual(8, solution.IslandPerimeter(grid), $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IslandPerimeter_3x3Square_Returns12(IIslandPerimeter_463 solution, string solutionName)
        {
            var grid = Grid(
                Row(1, 1, 1),
                Row(1, 1, 1),
                Row(1, 1, 1));
            Assert.AreEqual(12, solution.IslandPerimeter(grid), $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IslandPerimeter_2x3Rectangle_Returns10(IIslandPerimeter_463 solution, string solutionName)
        {
            var grid = Grid(
                Row(1, 1, 1),
                Row(1, 1, 1));
            Assert.AreEqual(10, solution.IslandPerimeter(grid), $"[{solutionName}]");
        }

        #endregion

        #region Islands at Grid Edges

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IslandPerimeter_IslandTouchesTopEdge_Returns6(IIslandPerimeter_463 solution, string solutionName)
        {
            var grid = Grid(
                Row(1, 1),
                Row(0, 0));
            Assert.AreEqual(6, solution.IslandPerimeter(grid), $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IslandPerimeter_IslandTouchesBottomEdge_Returns6(IIslandPerimeter_463 solution, string solutionName)
        {
            var grid = Grid(
                Row(0, 0),
                Row(1, 1));
            Assert.AreEqual(6, solution.IslandPerimeter(grid), $"[{solutionName}]");
        }

        #endregion

        #region L-Shaped and Irregular

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IslandPerimeter_LShape_Returns10(IIslandPerimeter_463 solution, string solutionName)
        {
            // L: [1,0]
            //    [1,0]
            //    [1,1]
            var grid = Grid(
                Row(1, 0),
                Row(1, 0),
                Row(1, 1));
            Assert.AreEqual(10, solution.IslandPerimeter(grid), $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IslandPerimeter_TShape_Returns12(IIslandPerimeter_463 solution, string solutionName)
        {
            // T: [1,1,1]
            //    [0,1,0]
            //    [0,1,0]
            var grid = Grid(
                Row(1, 1, 1),
                Row(0, 1, 0),
                Row(0, 1, 0));
            Assert.AreEqual(12, solution.IslandPerimeter(grid), $"[{solutionName}]");
        }

        #endregion
    }
}
