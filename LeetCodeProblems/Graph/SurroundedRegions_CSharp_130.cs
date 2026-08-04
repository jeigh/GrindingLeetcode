using LeetCodeProblems.Interfaces.Medium;

namespace LeetCodeProblems.CSharp.Graph
{
    public class SurroundedRegions_CSharp_130 : ISurroundedRegions_130
    {
        // time complexity: O(m * n)
        // space complexity: O(m * n)
        public void Solve(char[][] board)
        {
            var queue = new Queue<(int i, int j)>();
            var visited = new bool[board.Length, board[0].Length];
            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board[0].Length; j++)
                {
                    if (board[i][j] == 'O')
                    {
                        if (i == 0 || j == 0 || i == board.Length - 1 || j == board[0].Length - 1) queue.Enqueue((i, j));
                    }
                }
            }

            while (queue.Count > 0)
            {
                (int i, int j) = queue.Dequeue();

                if (visited[i, j]) continue;
                visited[i, j] = true;

                if (board[i][j] == 'O')
                {
                    if (i > 0) queue.Enqueue((i - 1, j));
                    if (j > 0) queue.Enqueue((i, j - 1));
                    if (i < board.Length - 1) queue.Enqueue((i + 1, j));
                    if (j < board[0].Length - 1) queue.Enqueue((i, j + 1));
                } 
            }

            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board[0].Length; j++)
                {
                    if (!visited[i,j])
                    {
                        board[i][j] = 'X';
                    }
                }
            }
        }
    }
}
