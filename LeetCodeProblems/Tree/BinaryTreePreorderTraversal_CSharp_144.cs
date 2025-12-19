using LeetCodeProblems.Interfaces.Easy;
using LeetCodeProblems.Shared;

namespace LeetCodeProblems.CSharp.Tree
{
    public class BinaryTreePreorderTraversal_CSharp_144 : IBinaryTreePreorderTraversal_144
    {
        public IList<int> PreorderTraversal(TreeNode root)
        {
            if (root == null) return new List<int>();
            var stack = new Stack<TreeNode>();
            var result = new List<int>();
            var current = root;
            while (stack.Any() || current != null)
            {
                while (current != null)
                {
                    result.Add(current.val);
                    stack.Push(current);
                    current = current.left;
                }
                current = stack.Pop();
                current = current.right;
            }
            return result;
        }
    }
}
