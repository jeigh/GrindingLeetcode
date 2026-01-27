using LeetCodeProblems.Interfaces.Medium;
using LeetCodeProblems.Shared;

namespace LeetCodeProblems.CSharp.Tree
{
    // solved 2026-01-18
    public class BinaryTreeRightSideView_IterativeInOrder_CSharp_199 : IBinaryTreeRightSideView_199
    {
        public List<int> RightSideView(TreeNode root)
        {
            var returnable = new List<int>();
            if (root == null) return returnable;
            var stack = new Stack<(int depth, TreeNode node)>();
            TreeNode node = root;
            var depth = 0;
            while (stack.Count > 0 || node != null)
            {
                while (node != null)
                {
                    stack.Push((depth, node));
                    depth++;
                    node = node.left;
                }

                (depth, node) = stack.Pop();

                while (returnable.Count < depth + 1) returnable.Add(node.val);
                returnable[depth] = node.val;

                node = node.right;
                depth++;
            }

            return returnable;
        }
    }
}
