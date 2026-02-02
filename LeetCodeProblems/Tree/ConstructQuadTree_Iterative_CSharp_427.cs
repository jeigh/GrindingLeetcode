using LeetCodeProblems.Interfaces;
using LeetCodeProblems.Interfaces.Medium;
using LeetCodeProblems.Shared;

namespace LeetCodeProblems.CSharp.Tree
{
    public class ConstructQuadTree_Iterative_CSharp_427 : IConstructQuadTree_427
    {
        public QuadNode Construct(int[][] grid)
        {
            var root = new QuadNode();
            var stack = new Stack<(QuadNode node, int regionSize, int rowStart, int colStart)>();
            stack.Push((root, grid.Length, 0, 0));

            while (stack.Count > 0)
            {
                (QuadNode node, int regionSize, int rowStart, int colStart) = stack.Pop();

                if (AllSame(grid, regionSize, rowStart, colStart))
                {
                    node.val = grid[rowStart][colStart] == 1;
                    node.isLeaf = true;
                } 
                else
                {
                    node.isLeaf = false;
                    int half = regionSize / 2;

                    node.topLeft = new QuadNode();
                    node.topRight = new QuadNode();
                    node.bottomLeft = new QuadNode();
                    node.bottomRight = new QuadNode();

                    stack.Push((node.topLeft, half, rowStart, colStart));
                    stack.Push((node.topRight, half, rowStart, colStart + half));
                    stack.Push((node.bottomLeft, half, rowStart + half, colStart));
                    stack.Push((node.bottomRight, half, rowStart + half, colStart + half));
                }
            }

            return root;
        }

        private bool AllSame(int[][] grid, int size, int rowStart, int colStart)
        {
            int firstValue = grid[rowStart][colStart];
            for (int i = rowStart; i < rowStart + size; i++)
            {
                for (int j = colStart; j < colStart + size; j++)
                {
                    if (grid[i][j] != firstValue)
                        return false;
                }
            }
            return true;
        }
    }
}
