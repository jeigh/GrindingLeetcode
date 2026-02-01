using LeetCodeProblems.Interfaces;
using LeetCodeProblems.Interfaces.Medium;

namespace LeetCodeProblems.CSharp.Tree
{
    public class ConstructQuadTree_Recursion_Optimized_CSharp_427 : IConstructQuadTree_427
    {
        private readonly QuadNode falseLeaf = new QuadNode(false, true);
        private readonly QuadNode trueLeaf = new QuadNode(true, true);

        public QuadNode Construct(int[][] grid)
        {
            int n = grid.Length;
            return Dfs(grid, n, 0, 0);
        }

        private QuadNode Dfs(int[][] grid, int regionSize, int rowStart, int columnStart)
        {
            if (regionSize == 1)
                return grid[rowStart][columnStart] == 1 ? trueLeaf : falseLeaf;

            int half = regionSize / 2;
            var topLeft = Dfs(grid, half, rowStart, columnStart);
            var topRight = Dfs(grid, half, rowStart, columnStart + half);
            var bottomLeft = Dfs(grid, half, rowStart + half, columnStart);
            var bottomRight = Dfs(grid, half, rowStart + half, columnStart + half);

            if (topLeft.isLeaf && topRight.isLeaf &&
                bottomLeft.isLeaf && bottomRight.isLeaf &&
                topLeft.val == topRight.val &&
                topLeft.val == bottomLeft.val &&
                topLeft.val == bottomRight.val)
            {
                return topLeft;
            }

            return new QuadNode(false, false, topLeft, topRight, bottomLeft, bottomRight);
        }
    }
}
