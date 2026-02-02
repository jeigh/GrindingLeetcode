using LeetCodeProblems.HashingOrArrays;
using LeetCodeProblems.Interfaces;
using LeetCodeProblems.Interfaces.Medium;
using LeetCodeProblems.Shared;

namespace LeetCodeProblems.CSharp.Tree
{

    public class ConstructQuadTree_Recursion_CSharp_427 : IConstructQuadTree_427
    {
        public QuadNode Construct(int[][] grid) => CreateSubTree(grid, grid.Length, 0, 0);

        public QuadNode CreateSubTree(int[][] grid, int regionSize, int rowStart, int colStart)
        {
            if (IsUniform(grid, regionSize, rowStart, colStart))
                return new QuadNode(1 == grid[rowStart][colStart], true);

            var half = regionSize / 2;

            var topLeft = CreateSubTree(grid, half, rowStart, colStart);
            var topRight = CreateSubTree(grid, half, rowStart, colStart + half);
            var bottomLeft = CreateSubTree(grid, half, rowStart + half, colStart);
            var bottomRight = CreateSubTree(grid, half, rowStart + half, colStart + half);

            return new QuadNode(false, false, topLeft, topRight, bottomLeft, bottomRight);
        }

        public bool IsUniform(int[][] grid, int regionSize, int rowStart, int colStart)
        {
            var compareval = grid[rowStart][colStart];

            for (int i = 0; i < regionSize; i++)
            {
                for (int j = 0; j < regionSize; j++)
                {
                    if (compareval != grid[rowStart + i][colStart + j]) return false;
                }
            }

            return true;
        }
    }
}
