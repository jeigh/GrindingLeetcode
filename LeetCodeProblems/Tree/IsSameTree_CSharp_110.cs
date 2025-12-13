using LeetCodeProblems.Shared;

namespace LeetCodeProblems.CSharp.Tree
{
    public class IsSameTree_CSharp_110
    {
        // time complexity: O(n), space complexity: O(h),
        // where n is the number of nodes in both trees, and h is the height of both trees.
        public bool IsSameTree(TreeNode p, TreeNode q)
        {
            if (p == null && q == null) return true;
            if (p != null && q == null) return false;
            if (p == null && q != null) return false;
            if (p.val != q.val) return false;

            var left = IsSameTree(p.left, q.left);
            var right = IsSameTree(p.right, q.right);

            return left && right;
        }
    }
}
