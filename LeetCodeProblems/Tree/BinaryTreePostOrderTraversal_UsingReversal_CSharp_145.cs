using LeetCodeProblems.Interfaces.Easy;
using LeetCodeProblems.Shared;

namespace LeetCodeProblems.CSharp.Tree
{
    public class BinaryTreePostOrderTraversal_UsingReversal_CSharp_145 : IBinaryTreePostOrderTraversal_145
    {
        // solved on 2025-12-14
        public IList<int> PostOrderTraversal(TreeNode root)
        {
            var result = new List<int>();
            var stack = new Stack<TreeNode>();
            var current = root;

            while (current != null || stack.Any())
            {
                while (current != null)
                {
                    result.Add(current.val);
                    stack.Push(current);
                    current = current.right;
                }

                current = stack.Pop();
                current = current.left;                
            }

            result.Reverse();
            return result;

        }
    }
}
