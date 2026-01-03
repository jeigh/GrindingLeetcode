using LeetCodeProblems.Interfaces.Medium;
using LeetCodeProblems.Shared;


namespace LeetCodeProblems.CSharp.Tree
{
    // solved on 2025-12-29 with a migraine
    public class LowestCommonAncestorOfBinarySearchTree_Iterative_CSharp_235 : ILowestCommonAncestorOfBinarySearchTree_235
    {
        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            if (p == null || q == null || root == null) return null;
            var stack = new Stack<TreeNode>();
            stack.Push(root);

            var bigger = q.val > p.val ? q : p;
            var smaller = q.val < p.val ? q : p;

            while (stack.Count > 0)
            {
                var currentNode = stack.Pop();

                if (currentNode == null) return null;

                if (currentNode.val > bigger.val) stack.Push(currentNode.left);
                else if (currentNode.val < smaller.val) stack.Push(currentNode.right);
                else return currentNode;
            }
            return null;

        }
    }
}
