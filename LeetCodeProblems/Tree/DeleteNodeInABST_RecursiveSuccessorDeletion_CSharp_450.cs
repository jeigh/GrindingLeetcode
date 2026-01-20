using LeetCodeProblems.Interfaces.Medium;
using LeetCodeProblems.Shared;

namespace LeetCodeProblems.CSharp.Tree
{
    public class DeleteNodeInABST_RecursiveSuccessorDeletion_CSharp_450 : IDeleteNodeInABST_450
    {
        public TreeNode DeleteNode(TreeNode root, int k)
        {
            if (root == null) return null;

            if (k > root.val) 
            { 
                root.right = DeleteNode(root.right, k); 
                return root;
            }
            
            if (k < root.val) 
            { 
                root.left = DeleteNode(root.left, k);
                return root;
            }

            if (root.left == null) return root.right;
            if (root.right == null) return root.left;

            var cur = root.right;
            while (cur.left != null) cur = cur.left;

            root.val = cur.val;
            root.right = DeleteNode(root.right, root.val);
            
            return root;
        }
    }


}
