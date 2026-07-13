using LeetCodeProblems.Interfaces.Easy;

namespace LeetCodeProblems.CSharp.HashingOrArrays
{
    public class IslandPerimeter_recursive_CSharp_463 : IIslandPerimeter_463
    {
        public int IslandPerimeter(int[][] grid)
        {
            if (grid.Length == 0) return 0;
            int returnable = 0;
            recurse(grid, 0, 0, ref returnable);
            return returnable;
        }

        private void recurse(int[][] grid, int i, int j, ref int rollingPerimeter)
        {
            if (i == grid.Length) return;
            if (j == grid[0].Length) return;

            if (grid[i][j] == 1) rollingPerimeter += 4 - GetAdjacentLands(grid, i, j);

            int nextJ = j + 1;
            int nextI = i;
            if (nextJ == grid[0].Length)
            {
                nextJ = 0;
                nextI = i + 1;
            }

            recurse(grid, nextI, nextJ, ref rollingPerimeter);
        }

        private int GetAdjacentLands(int[][] grid, int i, int j)
        {
            int count = 0;
            if (i > 0 && grid[i - 1][j] == 1) count++;
            if (j > 0 && grid[i][j - 1] == 1) count++;
            if (i < grid.Length - 1 && grid[i + 1][j] == 1) count++;
            if (j < grid[0].Length - 1 && grid[i][j + 1] == 1) count++;
            return count;
        }


    }
}
