using LeetCodeProblems.Interfaces.Medium;
using LeetCodeProblems.Shared;

namespace LeetCodeProblems.CSharp.Tree
{
    public class InsertIntoABinarySearchTree_Recursion_CSharp_701 : IInsertIntoABinarySearchTree_701
    {
        public TreeNode InsertIntoBST(TreeNode root, int val)
        {
            if (root == null) return new TreeNode(val);

            if (val > root.val && root.right != null) InsertIntoBST(root.right, val);
            else if (val > root.val) root.right = new TreeNode(val);

            if (val < root.val && root.left != null) InsertIntoBST(root.left, val);
            else if (val < root.val) root.left = new TreeNode(val);

            return root;
        }
    }
}
