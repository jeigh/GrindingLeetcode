using LeetCodeProblems.Interfaces.Medium;
using LeetCodeProblems.Shared;

namespace LeetCodeProblems.CSharp.Tree
{
    public class DeleteNodeInABST_DirectSuccessorPromotion_CSharp_450 : IDeleteNodeInABST_450
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

            var leftTree = root.left;

            var downStreamSuccessor = DetachNextDownstreamSuccessor(root);

            var rightTree = root.right;

            downStreamSuccessor.left = leftTree;
            downStreamSuccessor.right = rightTree;

            return downStreamSuccessor;
        }

        private TreeNode DetachNextDownstreamSuccessor(TreeNode root)
        {
            if (root == null) return null;
            var parent = root;
            var successor = root.right;
            bool lastMovedRight = true;
            while (successor.left != null)  
            {
                parent = successor;
                successor = successor.left; 
                lastMovedRight = false;
            }
            if (lastMovedRight)  
                parent.right = successor.right;
            else 
                parent.left = successor.right;

            return successor;
        }

    }
}
