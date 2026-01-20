using LeetCodeProblems.Interfaces.Medium;
using LeetCodeProblems.Shared;

namespace LeetCodeProblems.CSharp.Tree
{
    public class DeleteNodeInABST_LeftTreeDemotion_CSharp_450 : IDeleteNodeInABST_450
    {
        public TreeNode DeleteNode(TreeNode root, int key)
        {
            if (root == null) return null;

            if (key > root.val)
            {
                root.right = DeleteNode(root.right, key);
                return root;
            }
            if (key < root.val)
            {
                root.left = DeleteNode(root.left, key);
                return root;
            }

            if (root.left == null) return root.right;
            if (root.right == null) return root.left;

            var leftSubtree = root.left;
            var promotedNode = root.right;

            DemoteLeftSubtree(root, leftSubtree);

            return promotedNode;
        }

        private void DemoteLeftSubtree(TreeNode deletedNode, TreeNode leftSubtree)
        {
            var attachPoint = deletedNode.right;
            while (attachPoint.left != null) attachPoint = attachPoint.left;

            attachPoint.left = leftSubtree;  
        }
    }
}
