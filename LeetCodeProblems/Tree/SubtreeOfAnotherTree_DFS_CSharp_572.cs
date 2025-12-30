using LeetCodeProblems.Interfaces.Easy;
using LeetCodeProblems.Shared;

namespace LeetCodeProblems.CSharp.Tree
{
    public class SubtreeOfAnotherTree_DFS_CSharp_572 : ISubtreeOfAnotherTree_572
    {
        // solved 2025-12-25 (christmas)
        public bool IsSubtree(TreeNode root, TreeNode subroot)
        {
            if (subroot == null) return true;
            if (root == null) return false;
            if (IsSameTree(root, subroot)) return true;
            return IsSubtree(root?.left, subroot) || IsSubtree(root?.right, subroot);
        }

        public bool IsSameTree(TreeNode? p, TreeNode? q)
        {
            if (p == null && q == null) return true;
            if (p == null || q == null) return false;
            if (p.val != q.val) return false;

            if (!IsSameTree(p?.left, q?.left)) return false;
            if (!IsSameTree(p?.right, q?.right)) return false;
            return true;
        }

    }
}
