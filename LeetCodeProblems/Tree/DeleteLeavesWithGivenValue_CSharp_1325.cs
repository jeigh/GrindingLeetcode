using LeetCodeProblems.Interfaces.Medium;
using LeetCodeProblems.Shared;

namespace LeetCodeProblems.CSharp.Tree
{
    public class DeleteLeavesWithGivenValue_CSharp_1325 : IDeleteLeavesWithAGivenValue_1325
    {
        public TreeNode RemoveLeafNodes(TreeNode root, int target)
        {
            if (root == null) return null;

            root.left = RemoveLeafNodes(root.left, target);
            root.right = RemoveLeafNodes(root.right, target);

            if (root.left == null && root.right == null && root.val == target) root = null;
            return root;
        }
    }
}
