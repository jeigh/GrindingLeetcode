using LeetCodeProblems.Interfaces.Medium;
using LeetCodeProblems.Shared;

namespace LeetCodeProblems.CSharp.Tree
{
    // solved 2026-01-23
    public class CountGoodNodesInBinaryTree_CSharp_DFS_Iterative_1448 : ICountGoodNodesInBinaryTree_1448
    {
        public int GoodNodes(TreeNode root)
        {
            var stack = new Stack<(TreeNode node, int maxValue)>();
            stack.Push((root, root.val));
            int goodNodes = 0;
            while (stack.Count > 0)
            {
                (TreeNode node, int maxValue) = stack.Pop();

                if (node.val >= maxValue) goodNodes++;
                maxValue = Math.Max(maxValue, node.val);

                if (node.left != null) stack.Push((node.left, maxValue));
                if (node.right != null) stack.Push((node.right, maxValue));
            }

            return goodNodes;            
        }
    }
}
