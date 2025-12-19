using LeetCodeProblems.Interfaces.Easy;
using LeetCodeProblems.Shared;

namespace LeetCodeProblems.CSharp.Tree
{

    public class InvertBinaryTree_Stack_CSharp_226 : IInvertBinaryTree_226
    {
        // solved on 2025-12-14
        public TreeNode InvertTree(TreeNode root)
        {
            if (root == null) return null;
            var stack = new Stack<TreeNode>();
            stack.Push(root);

            while (stack.Count > 0)
            {
                var current = stack.Pop();
                
                if (current.left != null) stack.Push(current.left);
                if (current.right != null) stack.Push(current.right);

                var temp = current.left;
                current.left = current.right;
                current.right = temp;
            }

            return root;            
        }
    }
}
