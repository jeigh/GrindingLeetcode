using LeetCodeProblems.Interfaces.Medium;

namespace LeetCodeProblems.CSharp.Backtracking
{
    public class WordSearch_Backtracking_CSharp_79 : IWordSearch_79
    {

        public bool Exist(char[][] board, string word)
        {
            var usedCoordinates = new HashSet<(int x, int y)>();
            for (int x = 0; x < board.Length; x++)
            {
                for (int y = 0; y < board[0].Length; y++)
                {
                    if (board[x][y] == word[0] && recurse(board, word, 0, x, y, usedCoordinates)) return true;
                }
            }
            return false;
        }

        private bool recurse(char[][] board, string word, int i, int x, int y, HashSet<(int x, int y)> usedCoordinates)
        {
            if (board[x][y] == word[i])
            {
                if (i == word.Length - 1) return true;
                var adjacencies = GetAdjacencyList(board, x, y);
                usedCoordinates.Add((x, y));
                foreach (var adjacency in adjacencies)
                {
                    if (usedCoordinates.Contains((adjacency.x, adjacency.y))) continue;
                    if (recurse(board, word, i + 1, adjacency.x, adjacency.y, usedCoordinates)) return true;
                }
                usedCoordinates.Remove((x, y));
            }
            return false;
        }

        private List<(int x, int y)> GetAdjacencyList(char[][] board, int x, int y)
        {
            var result = new List<(int x, int y)>();

            var isTop = x == 0;
            var isLeft = y == 0;
            var isRight = y == board[0].Length - 1;
            var isBottom = x == board.Length - 1;

            if (!isTop) result.Add((x - 1, y));
            if (!isLeft) result.Add((x, y - 1));
            if (!isRight) result.Add((x, y + 1));
            if (!isBottom) result.Add((x + 1, y));           

            return result;
        }
    }
}
