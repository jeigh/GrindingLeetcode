using LeetCodeProblems.Interfaces.Medium;
using LeetCodeProblems.Shared;

namespace LeetCodeProblems.CSharp.Tree
{
    public class KthSmallestElementInBST_Morris_CSharp_230 : IKthSmallestElementInBST_230
    {
        // I don't really understand this one.
        // leaving it here for future reference for when I undeerstand trees better
        public int KthSmallest(TreeNode root, int k)
        {
            int result = -1;
            TreeNode curr = root;
            while (curr != null)
            {
                if (curr.left == null)
                {
                    if (--k == 0) result = curr.val;
                    curr = curr.right;
                    continue;
                }
                TreeNode predecessor = GetPredecessor(curr);
                if (predecessor.right == null)
                {
                    predecessor.right = curr;
                    curr = curr.left;
                    continue;
                }
                predecessor.right = null;
                if (--k == 0) result = curr.val;
                curr = curr.right;
            }

            return result;
        }

        private TreeNode GetPredecessor(TreeNode curr)
        {
            TreeNode predecessor = curr.left;
            while (predecessor.right != null && predecessor.right != curr) predecessor = predecessor.right;
            return predecessor;
        }
    }
}
