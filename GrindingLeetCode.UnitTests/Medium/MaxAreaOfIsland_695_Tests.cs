using LeetCodeProblems.CSharp.HashingOrArrays;
using LeetCodeProblems.Interfaces.Medium;
using LeetCodeProblems.VisualBasic.HashingOrArrays;

namespace GrindingLeetCode.UnitTests.Medium
{
    [TestClass]
    public class MaxAreaOfIsland_695_Tests
    {
        public static IEnumerable<object[]> GetImplementations()
        {
            yield return new object[] { new MaxAreaOfIsland_CSharp_695(), "C#" };
        }

        #region Helper Methods

        private static int[][] Grid(params int[][] rows) => rows;
        private static int[] Row(params int[] cells) => cells;

        #endregion

        #region LeetCode Examples

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void MaxAreaOfIsland_Example1_Returns6(IMaxAreaOfIsland_695 solution, string solutionName)
        {
            var grid = Grid(
                Row(0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0),
                Row(0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0),
                Row(0, 1, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0),
                Row(0, 1, 0, 0, 1, 1, 0, 0, 1, 0, 1, 0, 0),
                Row(0, 1, 0, 0, 1, 1, 0, 0, 1, 1, 1, 0, 0),
                Row(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0),
                Row(0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0),
                Row(0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0));
            Assert.AreEqual(6, solution.MaxAreaOfIsland(grid), $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void MaxAreaOfIsland_Example2_AllWater_Returns0(IMaxAreaOfIsland_695 solution, string solutionName)
        {
            var grid = Grid(Row(0, 0, 0, 0, 0, 0, 0, 0));
            Assert.AreEqual(0, solution.MaxAreaOfIsland(grid), $"[{solutionName}]");
        }

        #endregion

        #region Single Cell

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void MaxAreaOfIsland_SingleLandCell_Returns1(IMaxAreaOfIsland_695 solution, string solutionName)
        {
            Assert.AreEqual(1, solution.MaxAreaOfIsland(Grid(Row(1))), $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void MaxAreaOfIsland_SingleWaterCell_Returns0(IMaxAreaOfIsland_695 solution, string solutionName)
        {
            Assert.AreEqual(0, solution.MaxAreaOfIsland(Grid(Row(0))), $"[{solutionName}]");
        }

        #endregion

        #region All Land / All Water

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void MaxAreaOfIsland_AllLand_ReturnsFullArea(IMaxAreaOfIsland_695 solution, string solutionName)
        {
            var grid = Grid(
                Row(1, 1, 1),
                Row(1, 1, 1),
                Row(1, 1, 1));
            Assert.AreEqual(9, solution.MaxAreaOfIsland(grid), $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void MaxAreaOfIsland_AllWater_Returns0(IMaxAreaOfIsland_695 solution, string solutionName)
        {
            var grid = Grid(
                Row(0, 0, 0),
                Row(0, 0, 0));
            Assert.AreEqual(0, solution.MaxAreaOfIsland(grid), $"[{solutionName}]");
        }

        #endregion

        #region Multiple Islands — Returns Largest

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void MaxAreaOfIsland_TwoIslands_ReturnsLarger(IMaxAreaOfIsland_695 solution, string solutionName)
        {
            var grid = Grid(
                Row(1, 1, 0, 1),
                Row(1, 0, 0, 1));
            Assert.AreEqual(3, solution.MaxAreaOfIsland(grid), $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void MaxAreaOfIsland_SeveralSmallIslands_Returns1(IMaxAreaOfIsland_695 solution, string solutionName)
        {
            var grid = Grid(
                Row(1, 0, 1),
                Row(0, 0, 0),
                Row(1, 0, 1));
            Assert.AreEqual(1, solution.MaxAreaOfIsland(grid), $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void MaxAreaOfIsland_LargestIslandNotFirst_Returns4(IMaxAreaOfIsland_695 solution, string solutionName)
        {
            var grid = Grid(
                Row(1, 0, 1, 1),
                Row(0, 0, 1, 1));
            Assert.AreEqual(4, solution.MaxAreaOfIsland(grid), $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void MaxAreaOfIsland_LargestIslandNotLast_Returns4(IMaxAreaOfIsland_695 solution, string solutionName)
        {
            var grid = Grid(
                Row(1, 1, 0, 1),
                Row(1, 1, 0, 0));
            Assert.AreEqual(4, solution.MaxAreaOfIsland(grid), $"[{solutionName}]");
        }

        #endregion

        #region Shape Variations

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void MaxAreaOfIsland_HorizontalStrip_Returns4(IMaxAreaOfIsland_695 solution, string solutionName)
        {
            Assert.AreEqual(4, solution.MaxAreaOfIsland(Grid(Row(1, 1, 1, 1))), $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void MaxAreaOfIsland_VerticalStrip_Returns4(IMaxAreaOfIsland_695 solution, string solutionName)
        {
            var grid = Grid(Row(1), Row(1), Row(1), Row(1));
            Assert.AreEqual(4, solution.MaxAreaOfIsland(grid), $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void MaxAreaOfIsland_LShape_Returns4(IMaxAreaOfIsland_695 solution, string solutionName)
        {
            var grid = Grid(
                Row(1, 0),
                Row(1, 0),
                Row(1, 1));
            Assert.AreEqual(4, solution.MaxAreaOfIsland(grid), $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void MaxAreaOfIsland_DiagonalCells_Returns1(IMaxAreaOfIsland_695 solution, string solutionName)
        {
            // diagonal cells are not connected
            var grid = Grid(
                Row(1, 0),
                Row(0, 1));
            Assert.AreEqual(1, solution.MaxAreaOfIsland(grid), $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void MaxAreaOfIsland_RingShape_Returns8(IMaxAreaOfIsland_695 solution, string solutionName)
        {
            var grid = Grid(
                Row(1, 1, 1),
                Row(1, 0, 1),
                Row(1, 1, 1));
            Assert.AreEqual(8, solution.MaxAreaOfIsland(grid), $"[{solutionName}]");
        }

        #endregion
    }
}
