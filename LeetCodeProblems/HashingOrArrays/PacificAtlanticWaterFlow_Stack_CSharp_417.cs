using LeetCodeProblems.Interfaces.Medium;

namespace LeetCodeProblems.CSharp.HashingOrArrays
{

    public class PacificAtlanticWaterFlow_Stack_CSharp_417 : IPacificAtlanticWaterFlow_417
    {
        // time complexity: O(m * n)
        // space complexity: O(m * n)
        public IList<IList<int>> PacificAtlantic(int[][] heights)
        {
            bool[,] pacific = new bool[heights.Length, heights[0].Length];
            bool[,] atlantic = new bool[heights.Length, heights[0].Length];
            Stack<(int i, int j, bool[,] ocean)> stack = new Stack<(int i, int j, bool[,] ocean)>();


            for (int i = 0; i < heights.Length; i++)
            {
                for (int j = 0; j < heights[0].Length; j++)
                {
                    // top, left
                    if (i == 0 || j == 0)
                        stack.Push((i, j, pacific));

                    // bottom, right
                    if (i == heights.Length - 1 || j == heights[0].Length - 1)
                        stack.Push((i, j, atlantic));
                }
            }

            while (stack.Count > 0)
            {
                (int i, int j, bool[,] ocean)  = stack.Pop();
                
                if (ocean[i, j]) continue;

                ocean[i, j] = true;

                // left
                if (j > 0 && heights[i][j] <= heights[i][j - 1]) stack.Push((i, j - 1, ocean)); 
                // right
                if (j < heights[0].Length - 1 && heights[i][j] <= heights[i][j + 1]) stack.Push((i, j + 1, ocean));
                // up
                if (i > 0 && heights[i][j] <= heights[i - 1][j]) stack.Push((i - 1, j, ocean));
                // down
                if (i < heights.Length - 1 && heights[i][j] <= heights[i + 1][j]) stack.Push((i + 1, j, ocean));
            }

            var returnable = new List<IList<int>>();
            for (int i = 0; i < heights.Length; i++)
            {
                for (int j = 0; j < heights[0].Length; j++)
                {
                    if (pacific[i,j] && atlantic[i,j]) returnable.Add(new List<int> { i, j });
                }
            }
            
            return returnable;
        }
    }
}
