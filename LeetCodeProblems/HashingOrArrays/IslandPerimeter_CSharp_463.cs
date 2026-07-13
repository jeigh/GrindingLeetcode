using LeetCodeProblems.HashingOrArrays;
using LeetCodeProblems.Interfaces.Easy;

namespace LeetCodeProblems.CSharp.HashingOrArrays
{
    public class IslandPerimeter_CSharp_463 : IIslandPerimeter_463
    {
        public int IslandPerimeter(int[][] grid)
        {
            if (grid.Length == 0) return 0;
            int perimeter = 0;
            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[0].Length; j++)
                {
                    if (grid[i][j] == 1) perimeter += 4 - GetAdjacentLands(grid, i, j);
                }
            }

            return perimeter;            
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
