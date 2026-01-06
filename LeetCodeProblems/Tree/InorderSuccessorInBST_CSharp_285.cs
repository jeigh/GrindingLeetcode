using LeetCodeProblems.Interfaces.Medium;
using LeetCodeProblems.Shared;

namespace LeetCodeProblems.CSharp.Tree
{
    // solved 2026-01-03
    public class InorderSuccessorInBST_CSharp_285 : IInorderSuccessorInBST_285
    {
        public TreeNode InorderSuccessor(TreeNode root, TreeNode p)
        {
            if (p == null) return null;
            TreeNode current;
            if (p.right != null)
            {
                current = p.right;
                while (current.left != null) current = current.left;
                return current;
            }

            TreeNode successor = null;
            current = root;

            while (p != current)
            {
                if (p.val > current.val) current = current.right;
                else
                {
                    successor = current;
                    current = current.left;
                }
            }

            return successor;
        }
    }
}
