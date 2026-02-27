using LeetCodeProblems.Interfaces.Medium;
using LeetCodeProblems.Shared;

namespace LeetCodeProblems.CSharp.Tree
{
    public class HouseRobberIII_CSharp_337 : IHouseRobberIII_337
    {
        public int Rob(TreeNode root)
        {
            var (withRoot, withoutRoot) = RobSubTree(root);
            return Math.Max(withRoot, withoutRoot);
        }

        private (int withRoot, int withoutRoot) RobSubTree(TreeNode node)
        {
            if (node == null) return (0, 0);

            var left = RobSubTree(node.left);
            var right = RobSubTree(node.right);

            int withRoot = node.val + left.withoutRoot + right.withoutRoot;
            int withoutRoot = Math.Max(left.withRoot, left.withoutRoot) + Math.Max(right.withRoot, right.withoutRoot);

            return (withRoot, withoutRoot);
        }
    }
}
