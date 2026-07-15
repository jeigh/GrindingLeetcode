using LeetCodeProblems.Interfaces.Medium;

namespace LeetCodeProblems.CSharp.HashingOrArrays
{
    public class MaxAreaOfIsland_CSharp_695 : IMaxAreaOfIsland_695
    {
        // time complexity: O(m * n)
        // space complexity: O(m * n)
        public int MaxAreaOfIsland(int[][] grid)
        {
            var returnable = 0;
            if (grid.Length == 0) return returnable;
            bool[,] touched = new bool[grid.Length, grid[0].Length];
            

            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[0].Length; j++)
                {
                    if (!touched[i,j] && grid[i][j] != 0)
                    {
                        returnable = Math.Max(TouchIslandAndGetSize(grid, i, j, touched), returnable);
                    }
                }
            }
            return returnable;

        }

        private int TouchIslandAndGetSize(int[][] grid, int i, int j, bool[,] touched)
        {
            int size = 0;
            if (i == -1 || i == grid.Length) return size;
            if (j == -1 || j == grid[0].Length) return size;
            if (touched[i, j]) return size;

            if (grid[i][j] != 0)
            {
                touched[i,j] = true;
                size += 1;

                size += TouchIslandAndGetSize(grid, i + 1, j, touched);
                size += TouchIslandAndGetSize(grid, i - 1, j, touched);
                size += TouchIslandAndGetSize(grid, i, j + 1, touched);
                size += TouchIslandAndGetSize(grid, i, j - 1, touched);
            }

            return size;
        }
    }
}
