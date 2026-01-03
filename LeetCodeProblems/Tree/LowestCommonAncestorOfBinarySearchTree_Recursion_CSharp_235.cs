using LeetCodeProblems.Interfaces.Medium;
using LeetCodeProblems.Shared;

namespace LeetCodeProblems.CSharp.Tree
{ 
    public class LowestCommonAncestorOfBinarySearchTree_Recursion_CSharp_235 : ILowestCommonAncestorOfBinarySearchTree_235
    {
        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            if (root == null || p == null || q == null) return null;

            TreeNode greater;
            TreeNode lesser;

            if (p.val >= q.val) 
            {
                greater = p;
                lesser = q;
            }
            else 
            { 
                greater = q; 
                lesser = p;
            }
            
            if (greater.val < root.val) return LowestCommonAncestor(root.left, p, q);
            else if (lesser.val > root.val) return LowestCommonAncestor(root.right, p, q);

            return root;
        }
    }
}
