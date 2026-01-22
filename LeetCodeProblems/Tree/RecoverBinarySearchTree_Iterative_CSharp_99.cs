using LeetCodeProblems.Interfaces.Medium;
using LeetCodeProblems.Shared;

namespace LeetCodeProblems.CSharp.Tree
{
    // solved 2026-01-17
    public class RecoverBinarySearchTree_Iterative_CSharp_99 : IRecoverBinarySearchTree_99
    {
        public void RecoverTree(TreeNode root)
        {
            TreeNode first = null;
            TreeNode second = null;

            var stack = new Stack<TreeNode>();
            
            var currentNode = root;
            TreeNode previousNode = null;
            while (stack.Count > 0 || currentNode != null)
            {
                while (currentNode != null)
                {
                    stack.Push(currentNode);
                    currentNode = currentNode.left;
                }

                currentNode = stack.Pop();

                if (first == null && previousNode != null && previousNode.val > currentNode.val)
                {
                    first = previousNode;
                    second = currentNode;
                }
                else if (first != null && previousNode != null && previousNode.val > currentNode.val)
                { 
                    second = currentNode;
                    break;
                }

                previousNode = currentNode;
                currentNode = currentNode.right;
            }

            if (first != null && second != null)  
                SwapValues(first, second);
        }

        private void SwapValues(TreeNode first, TreeNode second)
        {
            var temp = first.val;
            first.val = second.val;
            second.val = temp;
        }
    }
}
