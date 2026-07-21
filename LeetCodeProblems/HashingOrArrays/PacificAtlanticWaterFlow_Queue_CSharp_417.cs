using LeetCodeProblems.Interfaces.Medium;

namespace LeetCodeProblems.CSharp.HashingOrArrays
{
    public class PacificAtlanticWaterFlow_Queue_CSharp_417 : IPacificAtlanticWaterFlow_417
    {
        // time complexity: O(m * n)
        // space complexity: O(m * n)
        public IList<IList<int>> PacificAtlantic(int[][] heights)
        {
            var returnable = new List<IList<int>>();
            if (heights.Length == 0) return returnable;
            var queue = new Queue<(int i, int j, bool[,] ocean)>();
            bool[,] pacific = new bool[heights.Length, heights[0].Length];
            bool[,] atlantic = new bool[heights.Length, heights[0].Length];

            for(int i = 0; i < heights.Length; i++)
            {
                for (int j = 0; j < heights[i].Length; j++)
                {
                    if (i == 0 || j == 0) queue.Enqueue((i, j, pacific));
                    if (i == heights.Length - 1 || j == heights[0].Length - 1) queue.Enqueue((i, j,  atlantic));
                }
            }

            while (queue.Count > 0)
            {
                (int i, int j, bool[,] ocean) = queue.Dequeue();

                if (ocean[i, j]) continue;
                ocean[i, j] = true;

                if (i > 0 && heights[i][j] <= heights[i - 1][j]) queue.Enqueue((i - 1, j, ocean));
                if (j > 0 && heights[i][j] <= heights[i][j - 1]) queue.Enqueue((i, j - 1, ocean));
                if (i < heights.Length - 1 && heights[i][j] <= heights[i + 1][j]) queue.Enqueue((i + 1, j, ocean));
                if (j < heights[0].Length - 1 && heights[i][j] <= heights[i][j+1]) queue.Enqueue((i, j + 1, ocean));
                
            }

            for (int i = 0; i < heights.Length; i++)
            {
                for (int j = 0; j < heights[0].Length; j++)
                {
                    if (pacific[i,j] && atlantic[i,j]) returnable.Add(new List<int>() { i, j });  
                }
            }

            return returnable;
        }
    }
}
