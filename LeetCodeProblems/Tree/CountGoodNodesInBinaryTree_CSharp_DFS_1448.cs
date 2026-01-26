using LeetCodeProblems.Interfaces.Medium;
using LeetCodeProblems.Shared;

namespace LeetCodeProblems.CSharp.Tree
{
    // solved 2026-01-23
    public class CountGoodNodesInBinaryTree_CSharp_DFS_1448 : ICountGoodNodesInBinaryTree_1448
    {
        public int GoodNodes(TreeNode root)
        {
            int goodNodes = 0;
            recurse(root, root.val, ref goodNodes);
            return goodNodes;
        }

        private void recurse(TreeNode node, int maxValue, ref int goodNodes)
        {
            if (node == null) return;
            if (node.val >= maxValue) goodNodes += 1;
            maxValue = Math.Max(maxValue, node.val);

            recurse(node.left, maxValue, ref goodNodes);
            recurse(node.right, maxValue, ref goodNodes);
        }
    }
}
