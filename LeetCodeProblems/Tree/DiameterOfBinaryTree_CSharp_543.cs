using LeetCodeProblems.Shared;

namespace LeetCodeProblems.CSharp.Tree
{
    public class DiameterOfBinaryTree_CSharp_543
    {
        // space complexity O(n), time complexity O(h)
        // where h is the height of the tree, and n is the total number of nodes

        public int DiameterOfBinaryTree(TreeNode root)
        {
            DiameterOfBinaryTreeRecursive(root);
            return maxValue;
        }

        private int maxValue { get; set; }

        public int DiameterOfBinaryTreeRecursive(TreeNode root)
        {
            if (root == null) return 0;
            if (root.left == null && root.right == null) return 1;

            var leftDepth = DiameterOfBinaryTreeRecursive(root.left);
            var rightDepth = DiameterOfBinaryTreeRecursive(root.right);

            maxValue = Math.Max(maxValue, leftDepth + rightDepth);
            return 1 + Math.Max(leftDepth, rightDepth);
        }
    }
}
