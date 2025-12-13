using LeetCodeProblems.Shared;

namespace LeetCodeProblems.CSharp.Tree
{
    public class BalancedBinaryTree_CSharp_110
    {
        public bool IsBalanced(TreeNode root)
        {
            if (root == null) return true;
            var depth = CheckDepth(root);
            if (DepthDifference > 1) return false;
            return true;
        }

        public int DepthDifference { get; set; }

        public int CheckDepth(TreeNode node)
        {
            if (node == null) return 0;

            var left = 1 + CheckDepth(node.left);
            var right = 1 + CheckDepth(node.right);

            if (DepthDifference > 1) return 0;
            DepthDifference = Math.Max(Math.Abs(left - right), DepthDifference);
            return Math.Max(left, right);
        }
    }
}
