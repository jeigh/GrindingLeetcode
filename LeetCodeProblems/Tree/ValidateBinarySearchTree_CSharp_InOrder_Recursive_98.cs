using LeetCodeProblems.Interfaces.Medium;
using LeetCodeProblems.Shared;

namespace LeetCodeProblems.CSharp.Tree
{
    public class ValidateBinarySearchTree_CSharp_InOrder_Recursive_98 : IValidateBinarySearchTree_98
    {
        public bool IsValidBST(TreeNode root)
        {
            if (root == null) return true;
            var minValue = int.MinValue;
            return recurse(root, ref minValue);
        }

        public bool recurse(TreeNode node, ref int prev)
        {
            if (node == null) return true;

            if (!recurse(node.left, ref prev)) return false;

            if (prev >= node.val) return false;
            prev = node.val;

            if (!recurse(node.right, ref prev)) return false;

            return true;
        }
    }
}
