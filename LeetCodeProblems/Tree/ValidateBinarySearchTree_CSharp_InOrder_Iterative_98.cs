using LeetCodeProblems.Interfaces.Medium;
using LeetCodeProblems.Shared;

namespace LeetCodeProblems.CSharp.Tree
{
    public class ValidateBinarySearchTree_CSharp_DFS_98 : IValidateBinarySearchTree_98
    {
        public bool IsValidBST(TreeNode root) => SubtreeIsValid(root, int.MinValue, int.MaxValue);

        private bool SubtreeIsValid(TreeNode node, int minValue, int maxValue)
        {
            if (node == null) return true;

            if (minValue >= node.val) return false;
            if (maxValue <= node.val) return false;

            if (node.left != null && !SubtreeIsValid(node.left, minValue, node.val)) return false;
            if (node.right != null && !SubtreeIsValid(node.right, node.val, maxValue)) return false;

            return true;
        }
    }
}
