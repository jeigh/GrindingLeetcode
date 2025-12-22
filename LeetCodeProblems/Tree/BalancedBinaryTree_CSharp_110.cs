using LeetCodeProblems.Interfaces.Easy;
using LeetCodeProblems.Shared;

namespace LeetCodeProblems.CSharp.Tree
{
    // solved 2025-12-20
    public class BalancedBinaryTree_Recursive_CSharp_110 : IBalancedBinaryTree_110
    {
        public bool IsBalanced(TreeNode root)
        {
            if (root == null) return true;
            return GetMaxDepth(root).isBalanced;
        }

        public (bool isBalanced, int maxDepth) GetMaxDepth(TreeNode? node)
        {
            if (node == null) return (true, 0);

            var left = GetMaxDepth(node.left);
            var right = GetMaxDepth(node.right);

            if (!left.isBalanced) return (false, 0);
            if (!right.isBalanced) return (false, 0);
            if (Math.Abs(left.maxDepth - right.maxDepth) > 1) return (false, 0);

            return (true, 1 + Math.Max(left.maxDepth, right.maxDepth));
        }
    }
}
