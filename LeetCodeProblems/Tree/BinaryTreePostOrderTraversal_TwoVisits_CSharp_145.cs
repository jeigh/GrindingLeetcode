using LeetCodeProblems.Interfaces.Easy;
using LeetCodeProblems.Shared;

namespace LeetCodeProblems.CSharp.Tree
{
    public class BinaryTreePostOrderTraversal_TwoVisits_CSharp_145 : IBinaryTreePostOrderTraversal_145
    {
        // solved on 2025-12-14
        public IList<int> PostOrderTraversal(TreeNode root)
        {
            var stack = new Stack<(TreeNode node,  bool visited)>();
            stack.Push((root, false));
            
            var result = new List<int>();

            while (stack.Count != 0)
            {
                (TreeNode current, bool visited) = stack.Pop();
                if (current != null)
                {
                    if (visited) result.Add(current.val);
                    else
                    {
                        stack.Push((current, true));
                        stack.Push((current.right, false));
                        stack.Push((current.left, false));
                    }
                }
            }
            return result;
        }
    }
}
