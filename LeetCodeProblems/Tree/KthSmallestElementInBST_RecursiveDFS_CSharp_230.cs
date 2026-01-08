using LeetCodeProblems.Interfaces.Medium;
using LeetCodeProblems.Shared;

namespace LeetCodeProblems.CSharp.Tree
{
    public class KthSmallestElementInBST_RecursiveDFS_CSharp_230 : IKthSmallestElementInBST_230
    {
        public int KthSmallest(TreeNode root, int k)
        {
            return InOrderTraversal(root, ref k).Value;
        }

        public int? InOrderTraversal(TreeNode root, ref int k)
        {
            if (root == null) return null;
            var left = InOrderTraversal(root.left, ref k);
            if (left.HasValue) return left;
            if (--k == 0) return root.val;
            return InOrderTraversal(root.right, ref k);
        }
    }
}
