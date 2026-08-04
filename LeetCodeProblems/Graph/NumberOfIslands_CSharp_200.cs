using LeetCodeProblems.Interfaces.Medium;

namespace LeetCodeProblems.CSharp.Graph
{
    public class NumberOfIslands_CSharp_200 : INumberOfIslands_200
    {
        // time complexity: O(m * n)
        // space complexity: O(m * n)
        public int NumIslands(char[][] grid)
        {

            var returnable = 0;
            if (grid.Length == 0) return returnable;
            bool[,] touched = new bool[grid.Length, grid[0].Length];


            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[0].Length; j++)
                {
                    if (grid[i][j] == '1' && !touched[i,j])
                    {
                        AddIslandToHeatmap(grid, i, j, touched);
                        returnable += 1;
                    }
                }
            }
            return returnable;
        }



        private void AddIslandToHeatmap(char[][] grid, int i, int j, bool[,] touched)
        {
            if (grid[i][j] != '1' || touched[i,j]) return;

            touched[i,j] = true;


            // up
            if (i != 0) 
                AddIslandToHeatmap(grid, i - 1, j, touched);
            
            // down
            if (i < grid.Length - 1)
                AddIslandToHeatmap(grid, i + 1, j, touched);

            // left
            if (j != 0)
                AddIslandToHeatmap(grid, i, j - 1, touched);

            // right
            if (j < grid[0].Length - 1)
                AddIslandToHeatmap(grid, i, j + 1, touched);


        }
    }
}
