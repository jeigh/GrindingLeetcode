using LeetCodeProblems.Interfaces.Easy;
using LeetCodeProblems.Shared;

namespace LeetCodeProblems.CSharp.Tree
{
    public class MaxDepthOfBinaryTree_Stack_CSharp_104 : IMaxDepthOfBinaryTree_104
    {
        public int MaxDepth(TreeNode root)
        {
            if (root == null) return 0;
            var stack = new Stack<(TreeNode, int depth)>();
                        
            var maxDepth = 0;
            stack.Push((root, 1));

            while (stack.Count > 0)
            {
                (TreeNode current, int curDepth) = stack.Pop();
                maxDepth = Math.Max(maxDepth, curDepth);

                if (current.left != null)
                {
                    stack.Push((current.left, curDepth + 1));
                }

                if (current.right != null)
                {
                    stack.Push((current.right, curDepth + 1));
                }
            }

            return maxDepth;
        }
        
    }
}
