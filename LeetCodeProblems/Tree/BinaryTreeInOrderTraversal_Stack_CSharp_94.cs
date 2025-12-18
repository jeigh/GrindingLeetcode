using LeetCodeProblems.Interfaces.Easy;
using LeetCodeProblems.Shared;

namespace LeetCodeProblems.CSharp.Tree
{
    public class BinaryTreeInOrderTraversal_Stack_CSharp_94 : IBinaryTreeInorderTraversal_94
    {
        public IList<int> InorderTraversal(TreeNode root)
        {
            var stack = new Stack<TreeNode>();
            var returnable = new List<int>();
            var currentNode = root;

            while (currentNode != null || stack.Any())
            {
                while (currentNode != null)
                {
                    stack.Push(currentNode);
                    currentNode = currentNode.left;
                }

                currentNode = stack.Pop();
                returnable.Add(currentNode.val);
                currentNode = currentNode.right;
            }

            return returnable;
        }
    }
}
