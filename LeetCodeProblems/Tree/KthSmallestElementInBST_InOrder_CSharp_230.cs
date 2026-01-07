using LeetCodeProblems.Interfaces.Medium;
using LeetCodeProblems.Shared;

namespace LeetCodeProblems.CSharp.Tree
{
    public class KthSmallestElementInBST_InOrder_CSharp_230 : IKthSmallestElementInBST_230
    {
        public int KthSmallest(TreeNode root, int k)
        {
            if (root == null || k == 0) return 0;

            var list = new List<int>();
            
            InOrderTraversal(root, list);

            return list[k - 1];
        }

        private void InOrderTraversal(TreeNode root, List<int> list)
        {
            if (root == null) return;

            InOrderTraversal(root.left, list);
            list.Add(root.val);
            InOrderTraversal(root.right, list);
        }
    }
}
