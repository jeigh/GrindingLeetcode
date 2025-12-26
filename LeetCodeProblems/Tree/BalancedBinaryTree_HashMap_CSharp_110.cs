using LeetCodeProblems.Interfaces.Easy;
using LeetCodeProblems.Shared;

namespace LeetCodeProblems.CSharp.Tree
{
    // solved 2025-12-21
    public class BalancedBinaryTree_HashMap_CSharp_110 : IBalancedBinaryTree_110
    {
        public bool IsBalanced(TreeNode root)
        {
            var stack = new Stack<TreeNode>();
            var hashMap = new Dictionary<TreeNode, int>();
            TreeNode? last = null;
            var node = root;

            while (stack.Count > 0 || node != null)
            {
                if (node != null)
                {
                    stack.Push(node);
                    node = node.left;
                    continue;
                }

                node = stack.Peek();
                if (node.right != null && node.right != last) node = node.right;
                else
                {
                    stack.Pop();

                    if (node.left == null || !hashMap.TryGetValue(node.left, out int leftDepth)) leftDepth = 0;
                    if (node.right == null || !hashMap.TryGetValue(node.right, out int rightDepth)) rightDepth = 0;

                    if (Math.Abs(leftDepth - rightDepth) > 1) return false;

                    hashMap[node] = 1 + Math.Max(leftDepth, rightDepth);

                    last = node;
                    node = null;
                }
            }

            return true;
        }
    }
}
