using LeetCodeProblems.CSharp.HashingOrArrays;
using LeetCodeProblems.Interfaces.Medium;
using LeetCodeProblems.VisualBasic.HashingOrArrays;

namespace GrindingLeetCode.UnitTests.Medium
{
    [TestClass]
    public class WallsAndGates_286_Tests
    {
        public static IEnumerable<object[]> GetImplementations()
        {
            yield return new object[] { new WallsAndGates_CSharp_Bespoke_286(), "C#" };
            yield return new object[] { new WallsAndGates_CSharp_286(), "C#" };
            //yield return new object[] { new WallsAndGates_VB_286(), "VB" };
        }

        #region Helper Methods

        private const int INF = int.MaxValue;
        private const int WALL = -1;
        private const int GATE = 0;

        private static int[][] Grid(params int[][] rows) => rows;
        private static int[] Row(params int[] cells) => cells;

        private static int[][] DeepCopy(int[][] grid) =>
            grid.Select(r => r.ToArray()).ToArray();

        private static void AssertGrid(int[][] expected, int[][] actual, string solutionName)
        {
            Assert.AreEqual(expected.Length, actual.Length, $"[{solutionName}] Row count mismatch");
            for (int i = 0; i < expected.Length; i++)
            {
                CollectionAssert.AreEqual(expected[i], actual[i],
                    $"[{solutionName}] Row {i} mismatch");
            }
        }

        #endregion

        #region LeetCode Example

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void WallsAndGates_Example1_FillsCorrectly(IWallsAndGates_286 solution, string solutionName)
        {
            var rooms = Grid(
                Row(INF,  WALL, GATE, INF),
                Row(INF,  INF,  INF,  WALL),
                Row(INF,  WALL, INF,  WALL),
                Row(GATE, WALL, INF,  INF));

            solution.WallsAndGates(rooms);

            var expected = Grid(
                Row(3,    WALL, GATE, 1),
                Row(2,    2,    1,    WALL),
                Row(1,    WALL, 2,    WALL),
                Row(GATE, WALL, 3,    4));

            AssertGrid(expected, rooms, solutionName);
        }

        #endregion

        #region No Gates

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void WallsAndGates_NoGates_AllRoomsStayInf(IWallsAndGates_286 solution, string solutionName)
        {
            var rooms = Grid(
                Row(INF, INF),
                Row(INF, INF));

            solution.WallsAndGates(rooms);

            var expected = Grid(
                Row(INF, INF),
                Row(INF, INF));

            AssertGrid(expected, rooms, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void WallsAndGates_AllWalls_NoChange(IWallsAndGates_286 solution, string solutionName)
        {
            var rooms = Grid(
                Row(WALL, WALL),
                Row(WALL, WALL));

            solution.WallsAndGates(rooms);

            var expected = Grid(
                Row(WALL, WALL),
                Row(WALL, WALL));

            AssertGrid(expected, rooms, solutionName);
        }

        #endregion

        #region Single Gate

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void WallsAndGates_SingleGate_Center_FillsDistances(IWallsAndGates_286 solution, string solutionName)
        {
            var rooms = Grid(
                Row(INF, INF, INF),
                Row(INF, GATE, INF),
                Row(INF, INF, INF));

            solution.WallsAndGates(rooms);

            var expected = Grid(
                Row(2, 1, 2),
                Row(1, GATE, 1),
                Row(2, 1, 2));

            AssertGrid(expected, rooms, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void WallsAndGates_SingleGate_Corner_FillsDistances(IWallsAndGates_286 solution, string solutionName)
        {
            var rooms = Grid(
                Row(GATE, INF, INF),
                Row(INF,  INF, INF),
                Row(INF,  INF, INF));

            solution.WallsAndGates(rooms);

            var expected = Grid(
                Row(GATE, 1, 2),
                Row(1,    2, 3),
                Row(2,    3, 4));

            AssertGrid(expected, rooms, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void WallsAndGates_GateBlockedByWalls_UnreachableStaysInf(IWallsAndGates_286 solution, string solutionName)
        {
            var rooms = Grid(
                Row(GATE, WALL),
                Row(WALL, INF));

            solution.WallsAndGates(rooms);

            var expected = Grid(
                Row(GATE, WALL),
                Row(WALL, INF));

            AssertGrid(expected, rooms, solutionName);
        }

        #endregion

        #region Multiple Gates

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void WallsAndGates_TwoGates_RoomsFilledByNearest(IWallsAndGates_286 solution, string solutionName)
        {
            var rooms = Grid(
                Row(GATE, INF, INF, INF, GATE));

            solution.WallsAndGates(rooms);

            var expected = Grid(
                Row(GATE, 1, 2, 1, GATE));

            AssertGrid(expected, rooms, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void WallsAndGates_TwoGates_OppositeCorners(IWallsAndGates_286 solution, string solutionName)
        {
            var rooms = Grid(
                Row(GATE, INF,  INF),
                Row(INF,  INF,  INF),
                Row(INF,  INF,  GATE));

            solution.WallsAndGates(rooms);

            var expected = Grid(
                Row(GATE, 1, 2),
                Row(1,    2, 1),
                Row(2,    1, GATE));

            AssertGrid(expected, rooms, solutionName);
        }

        #endregion

        #region Edge Cases

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void WallsAndGates_SingleCellGate_NoChange(IWallsAndGates_286 solution, string solutionName)
        {
            var rooms = Grid(Row(GATE));
            solution.WallsAndGates(rooms);
            AssertGrid(Grid(Row(GATE)), rooms, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void WallsAndGates_SingleCellRoom_StaysInf(IWallsAndGates_286 solution, string solutionName)
        {
            var rooms = Grid(Row(INF));
            solution.WallsAndGates(rooms);
            AssertGrid(Grid(Row(INF)), rooms, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void WallsAndGates_AdjacentGate_RoomGetsDistance1(IWallsAndGates_286 solution, string solutionName)
        {
            var rooms = Grid(Row(INF, GATE));
            solution.WallsAndGates(rooms);
            AssertGrid(Grid(Row(1, GATE)), rooms, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void WallsAndGates_WallsDoNotGetFilled(IWallsAndGates_286 solution, string solutionName)
        {
            var rooms = Grid(
                Row(GATE, WALL, INF));
            solution.WallsAndGates(rooms);
            AssertGrid(Grid(Row(GATE, WALL, INF)), rooms, solutionName);
        }

        #endregion
    }
}
