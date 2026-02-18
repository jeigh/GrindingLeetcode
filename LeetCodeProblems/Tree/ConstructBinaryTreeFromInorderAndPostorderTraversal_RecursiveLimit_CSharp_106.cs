using LeetCodeProblems.Interfaces.Medium;
using LeetCodeProblems.Shared;
using index = System.Int32;

namespace LeetCodeProblems.CSharp.Tree
{
    public class ConstructBinaryTreeFromInorderAndPostorderTraversal_IterativeLimit_CSharp_106 : IConstructBinaryTreeFromInOrderAndPostOrderTraversal_106
    {
        public TreeNode BuildTree(int[] inorder, int[] postorder)
        {
            var inIndex = inorder.Length - 1;
            var postIndex = postorder.Length - 1;

            var stack = new Stack<(TreeNode parent, Int64 limitValue, bool isRight)>();
            TreeNode root = null;
            stack.Push((null, Int64.MaxValue, true));

            while (stack.Count > 0)
            {
                (TreeNode parent, Int64 limitValue, bool isRight) = stack.Pop();
                
                if (postIndex < 0) continue;
                if (inIndex < 0) continue;

                if (inorder[inIndex] == limitValue)
                {
                    inIndex--;
                    continue;
                }

                var currentValue = postorder[postIndex--];
                TreeNode node = new TreeNode(currentValue);

                if (parent == null) root = node;
                else if (isRight) parent.right = node;
                else parent.left = node;

                stack.Push((node, limitValue, false));        // left
                stack.Push((node, currentValue, true));       // right
            }

            return root;
        }
    }











    public class ConstructBinaryTreeFromInorderAndPostorderTraversal_RecursiveLimit_CSharp_106 : IConstructBinaryTreeFromInOrderAndPostOrderTraversal_106
    {
        public TreeNode BuildTree(int[] inorder, int[] postorder)
        {
            var postIndex = postorder.Length - 1;
            var inIndex = inorder.Length - 1;

            return BuildTree(inorder, postorder, Int64.MaxValue, ref inIndex, ref postIndex);
        }

        private TreeNode BuildTree(int[] inorder, int[] postorder, Int64 limitValue, ref index inIndex, ref index postIndex)
        {
            if (postIndex < 0) return null;
            if (inorder[inIndex] == limitValue)
            {
                inIndex--;
                return null;
            }

            var currentValue = postorder[postIndex--];
            TreeNode root = new TreeNode(currentValue);

            root.right = BuildTree(inorder, postorder, currentValue, ref inIndex, ref postIndex);
            root.left = BuildTree(inorder, postorder, limitValue, ref inIndex, ref postIndex);

            return root;
        }
    }
}
