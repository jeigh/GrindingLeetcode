using LeetCodeProblems.Interfaces.Medium;
using LeetCodeProblems.Shared;

namespace LeetCodeProblems.CSharp.Tree
{
    public class KthSmallestElementInBST_IterativeDFS_CSharp_230 : IKthSmallestElementInBST_230
    {
        public int KthSmallest(TreeNode root, int k)
        {
            if (root == null || k == 0) return 0;
            var stack = new Stack<TreeNode>();
            var current = root;

            while (k > 0 && (current != null || stack.Count > 0))
            {
                while (current != null)
                {
                    stack.Push(current);
                    current = current.left;
                }

                current = stack.Pop();
                k--;
                if (k > 0) current = current.right;
            }

            if (current != null) return current.val;
            return 0; 
        }
    }
}
