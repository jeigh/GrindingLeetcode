using LeetCodeProblems.CSharp.HashingOrArrays;
using LeetCodeProblems.Interfaces.Medium;
using LeetCodeProblems.VisualBasic.HashingOrArrays;

namespace GrindingLeetCode.UnitTests.Medium
{
    [TestClass]
    public class SurroundedRegions_130_Tests
    {
        public static IEnumerable<object[]> GetImplementations()
        {
            yield return new object[] { new SurroundedRegions_CSharp_130(), "C#" };
            //yield return new object[] { new SurroundedRegions_VB_130(), "VB" };
        }

        #region Helper Methods

        private static char[][] Board(params string[] rows) =>
            rows.Select(r => r.ToCharArray()).ToArray();

        private static void AssertBoard(char[][] expected, char[][] actual, string solutionName)
        {
            Assert.AreEqual(expected.Length, actual.Length, $"[{solutionName}] Row count mismatch");
            for (int i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i].Length, actual[i].Length, $"[{solutionName}] Col count mismatch at row {i}");
                for (int j = 0; j < expected[i].Length; j++)
                    Assert.AreEqual(expected[i][j], actual[i][j],
                        $"[{solutionName}] Mismatch at [{i},{j}]: expected '{expected[i][j]}', got '{actual[i][j]}'");
            }
        }

        #endregion

        #region LeetCode Examples

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Solve_Example1_CapturesSurroundedRegion(ISurroundedRegions_130 solution, string solutionName)
        {
            var board = Board(
                "XXXX",
                "XOOX",
                "XXOX",
                "XOXX");

            solution.Solve(board);

            AssertBoard(Board(
                "XXXX",
                "XXXX",
                "XXXX",
                "XOXX"), board, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Solve_Example2_SingleX_NoChange(ISurroundedRegions_130 solution, string solutionName)
        {
            var board = Board("X");
            solution.Solve(board);
            AssertBoard(Board("X"), board, solutionName);
        }

        #endregion

        #region Single Cell

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Solve_SingleO_NotCaptured(ISurroundedRegions_130 solution, string solutionName)
        {
            var board = Board("O");
            solution.Solve(board);
            AssertBoard(Board("O"), board, solutionName);
        }

        #endregion

        #region All Same

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Solve_AllX_NoChange(ISurroundedRegions_130 solution, string solutionName)
        {
            var board = Board(
                "XXX",
                "XXX",
                "XXX");
            solution.Solve(board);
            AssertBoard(Board(
                "XXX",
                "XXX",
                "XXX"), board, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Solve_AllO_3x3_NoneCaptures(ISurroundedRegions_130 solution, string solutionName)
        {
            // Center is connected to border O's — not surrounded by X's, so not captured
            var board = Board(
                "OOO",
                "OOO",
                "OOO");
            solution.Solve(board);
            AssertBoard(Board(
                "OOO",
                "OOO",
                "OOO"), board, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Solve_AllO_2x2_NoneCaptures(ISurroundedRegions_130 solution, string solutionName)
        {
            // All cells are border cells in a 2x2 grid
            var board = Board(
                "OO",
                "OO");
            solution.Solve(board);
            AssertBoard(Board(
                "OO",
                "OO"), board, solutionName);
        }

        #endregion

        #region Single Row / Column

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Solve_SingleRow_NoneCaptures(ISurroundedRegions_130 solution, string solutionName)
        {
            var board = Board("XOXOX");
            solution.Solve(board);
            AssertBoard(Board("XOXOX"), board, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Solve_SingleColumn_NoneCaptures(ISurroundedRegions_130 solution, string solutionName)
        {
            var board = Board("X", "O", "X", "O", "X");
            solution.Solve(board);
            AssertBoard(Board("X", "O", "X", "O", "X"), board, solutionName);
        }

        #endregion

        #region Border-Connected

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Solve_OOnTopBorder_NotCaptured(ISurroundedRegions_130 solution, string solutionName)
        {
            var board = Board(
                "XOX",
                "XXX",
                "XXX");
            solution.Solve(board);
            AssertBoard(Board(
                "XOX",
                "XXX",
                "XXX"), board, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Solve_OOnBottomBorder_NotCaptured(ISurroundedRegions_130 solution, string solutionName)
        {
            var board = Board(
                "XXX",
                "XXX",
                "XOX");
            solution.Solve(board);
            AssertBoard(Board(
                "XXX",
                "XXX",
                "XOX"), board, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Solve_OOnLeftBorder_NotCaptured(ISurroundedRegions_130 solution, string solutionName)
        {
            var board = Board(
                "XXX",
                "OXX",
                "XXX");
            solution.Solve(board);
            AssertBoard(Board(
                "XXX",
                "OXX",
                "XXX"), board, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Solve_OOnRightBorder_NotCaptured(ISurroundedRegions_130 solution, string solutionName)
        {
            var board = Board(
                "XXX",
                "XXO",
                "XXX");
            solution.Solve(board);
            AssertBoard(Board(
                "XXX",
                "XXO",
                "XXX"), board, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Solve_OConnectedToBorderViaChain_NotCaptured(ISurroundedRegions_130 solution, string solutionName)
        {
            // Interior O is connected to the left-border O via a chain
            var board = Board(
                "XXXXX",
                "OOOXX",
                "XXXXX");
            solution.Solve(board);
            AssertBoard(Board(
                "XXXXX",
                "OOOXX",
                "XXXXX"), board, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Solve_OSnakingFromTopBorder_NotCaptured(ISurroundedRegions_130 solution, string solutionName)
        {
            var board = Board(
                "XOXX",
                "XOXX",
                "XOOX",
                "XXOX",
                "XXXX");
            solution.Solve(board);
            AssertBoard(Board(
                "XOXX",
                "XOXX",
                "XOOX",
                "XXOX",
                "XXXX"), board, solutionName);
        }

        #endregion

        #region Fully Surrounded

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Solve_SingleOInCenter_Captured(ISurroundedRegions_130 solution, string solutionName)
        {
            var board = Board(
                "XXX",
                "XOX",
                "XXX");
            solution.Solve(board);
            AssertBoard(Board(
                "XXX",
                "XXX",
                "XXX"), board, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Solve_MultipleDisjointSurroundedRegions_AllCaptured(ISurroundedRegions_130 solution, string solutionName)
        {
            var board = Board(
                "XXXXXXX",
                "XOXXXOX",
                "XXXXXXX");
            solution.Solve(board);
            AssertBoard(Board(
                "XXXXXXX",
                "XXXXXXX",
                "XXXXXXX"), board, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Solve_LShapedSurroundedRegion_Captured(ISurroundedRegions_130 solution, string solutionName)
        {
            var board = Board(
                "XXXXX",
                "XOOXX",
                "XXOXX",
                "XXXXX");
            solution.Solve(board);
            AssertBoard(Board(
                "XXXXX",
                "XXXXX",
                "XXXXX",
                "XXXXX"), board, solutionName);
        }

        #endregion

        #region Mixed

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Solve_MixedSurroundedAndBorderConnected_OnlySurroundedCaptured(ISurroundedRegions_130 solution, string solutionName)
        {
            var board = Board(
                "XXXX",
                "XOXX",
                "XOOX",
                "OOXX");
            solution.Solve(board);
            // (1,1) connects to (2,1) which connects to (3,1) which is on the bottom border
            AssertBoard(Board(
                "XXXX",
                "XOXX",
                "XOOX",
                "OOXX"), board, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Solve_5x5_SurroundedAndBorderRegions(ISurroundedRegions_130 solution, string solutionName)
        {
            var board = Board(
                "XXXXX",
                "XOOOX",
                "XOXOX",
                "XOOOX",
                "XXXXX");
            solution.Solve(board);
            AssertBoard(Board(
                "XXXXX",
                "XXXXX",
                "XXXXX",
                "XXXXX",
                "XXXXX"), board, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Solve_OOnAllFourCorners_NotCaptured(ISurroundedRegions_130 solution, string solutionName)
        {
            var board = Board(
                "OXO",
                "XXX",
                "OXO");
            solution.Solve(board);
            AssertBoard(Board(
                "OXO",
                "XXX",
                "OXO"), board, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Solve_InteriorIsAllX_BorderHasO_NoChange(ISurroundedRegions_130 solution, string solutionName)
        {
            var board = Board(
                "OOOOO",
                "OXXXO",
                "OXXXO",
                "OXXXO",
                "OOOOO");
            solution.Solve(board);
            AssertBoard(Board(
                "OOOOO",
                "OXXXO",
                "OXXXO",
                "OXXXO",
                "OOOOO"), board, solutionName);
        }

        #endregion
    }
}
