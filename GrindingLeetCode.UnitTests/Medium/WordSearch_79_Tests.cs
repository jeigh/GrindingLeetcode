using LeetCodeProblems.CSharp.Backtracking;
using LeetCodeProblems.Interfaces.Medium;
using LeetCodeProblems.VisualBasic.Backtracking;

namespace GrindingLeetCode.UnitTests.Medium
{
    /// <summary>
    /// Unit tests for LeetCode Problem 79: Word Search
    ///
    /// Problem Description:
    /// Given an m x n grid of characters and a string word, return true if the word
    /// exists in the grid via sequentially adjacent cells (horizontal/vertical).
    /// The same cell may not be used more than once.
    /// </summary>
    [TestClass]
    public class WordSearch_79_Tests
    {
        public static IEnumerable<object[]> GetImplementations()
        {
            yield return new object[] { new WordSearch_Backtracking_CSharp_79(), "C# Backtracking" };

            yield return new object[] { new WordSearch_Backtracking_VB_79(), "VB Backtracking" };
            yield break;
        }

        #region Helper Methods

        private static char[][] Board(params string[] rows) =>
            rows.Select(r => r.ToCharArray()).ToArray();

        #endregion

        #region LeetCode Examples

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Exist_Example1_WordFound(IWordSearch_79 solution, string solutionName)
        {
            // Input: board = [["A","B","C","E"],["S","F","C","S"],["A","D","E","E"]], word = "ABCCED"
            // Output: true

            var board = Board("ABCE", "SFCS", "ADEE");
            Assert.IsTrue(solution.Exist(board, "ABCCED"), $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Exist_Example2_WordFound(IWordSearch_79 solution, string solutionName)
        {
            // Input: board = [["A","B","C","E"],["S","F","C","S"],["A","D","E","E"]], word = "SEE"
            // Output: true

            var board = Board("ABCE", "SFCS", "ADEE");
            Assert.IsTrue(solution.Exist(board, "SEE"), $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Exist_Example3_WordNotFound(IWordSearch_79 solution, string solutionName)
        {
            // Input: board = [["A","B","C","E"],["S","F","C","S"],["A","D","E","E"]], word = "ABCB"
            // Output: false (would require reusing B)

            var board = Board("ABCE", "SFCS", "ADEE");
            Assert.IsFalse(solution.Exist(board, "ABCB"), $"[{solutionName}]");
        }

        #endregion

        #region Single Cell Board

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Exist_SingleCell_Match_ReturnsTrue(IWordSearch_79 solution, string solutionName)
        {
            var board = Board("A");
            Assert.IsTrue(solution.Exist(board, "A"), $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Exist_SingleCell_NoMatch_ReturnsFalse(IWordSearch_79 solution, string solutionName)
        {
            var board = Board("B");
            Assert.IsFalse(solution.Exist(board, "A"), $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Exist_SingleCell_WordTooLong_ReturnsFalse(IWordSearch_79 solution, string solutionName)
        {
            var board = Board("A");
            Assert.IsFalse(solution.Exist(board, "AB"), $"[{solutionName}]");
        }

        #endregion

        #region Cell Reuse

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Exist_CellReuse_ReturnsFalse(IWordSearch_79 solution, string solutionName)
        {
            // Only one 'A' and one 'B' — "ABA" would require reusing A
            var board = Board("AB");
            Assert.IsFalse(solution.Exist(board, "ABA"), $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Exist_AdjacentSameChars_ValidPath_ReturnsTrue(IWordSearch_79 solution, string solutionName)
        {
            // A A A — "AAA" found without reuse
            var board = Board("AAA");
            Assert.IsTrue(solution.Exist(board, "AAA"), $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Exist_AdjacentSameChars_TooLong_ReturnsFalse(IWordSearch_79 solution, string solutionName)
        {
            // Only 3 cells, word needs 4
            var board = Board("AAA");
            Assert.IsFalse(solution.Exist(board, "AAAA"), $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Exist_AllSameChar_ValidLength_ReturnsTrue(IWordSearch_79 solution, string solutionName)
        {
            var board = Board("AA", "AA");
            Assert.IsTrue(solution.Exist(board, "AAAA"), $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Exist_AllSameChar_ExceedsCellCount_ReturnsFalse(IWordSearch_79 solution, string solutionName)
        {
            var board = Board("AA", "AA");
            Assert.IsFalse(solution.Exist(board, "AAAAA"), $"[{solutionName}]");
        }

        #endregion

        #region Direction Tests

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Exist_WordGoesRight_ReturnsTrue(IWordSearch_79 solution, string solutionName)
        {
            var board = Board("ABCD");
            Assert.IsTrue(solution.Exist(board, "ABCD"), $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Exist_WordGoesLeft_ReturnsTrue(IWordSearch_79 solution, string solutionName)
        {
            var board = Board("ABCD");
            Assert.IsTrue(solution.Exist(board, "DCBA"), $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Exist_WordGoesDown_ReturnsTrue(IWordSearch_79 solution, string solutionName)
        {
            var board = Board("A", "B", "C", "D");
            Assert.IsTrue(solution.Exist(board, "ABCD"), $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Exist_WordGoesUp_ReturnsTrue(IWordSearch_79 solution, string solutionName)
        {
            var board = Board("A", "B", "C", "D");
            Assert.IsTrue(solution.Exist(board, "DCBA"), $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Exist_WordSnakesAcrossBoard_ReturnsTrue(IWordSearch_79 solution, string solutionName)
        {
            // A B C
            // F E D   → "ABCDEF" snakes right then down then left
            var board = Board("ABC", "FED");
            Assert.IsTrue(solution.Exist(board, "ABCDEF"), $"[{solutionName}]");
        }

        #endregion

        #region Word Not Present

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Exist_FirstCharNotInBoard_ReturnsFalse(IWordSearch_79 solution, string solutionName)
        {
            var board = Board("ABC", "DEF");
            Assert.IsFalse(solution.Exist(board, "XYZ"), $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Exist_CharsExistButNotAdjacent_ReturnsFalse(IWordSearch_79 solution, string solutionName)
        {
            // A X B — A and B are not adjacent
            var board = Board("AXB");
            Assert.IsFalse(solution.Exist(board, "AB"), $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Exist_WordLongerThanTotalCells_ReturnsFalse(IWordSearch_79 solution, string solutionName)
        {
            var board = Board("AB", "CD");
            Assert.IsFalse(solution.Exist(board, "ABCDE"), $"[{solutionName}]");
        }

        #endregion
    }
}
