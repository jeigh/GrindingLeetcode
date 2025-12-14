using LeetCodeProblems.Shared;

namespace LeetCodeProblems.Interfaces.Easy
{
    /// <summary>
    /// Given the root of a binary tree, return the preorder traversal of its nodes' values.
    /// </summary>
    public interface IBinaryTreePreorderTraversal_144
    {
        IList<int> PreorderTraversal(TreeNode root);
    }

}
