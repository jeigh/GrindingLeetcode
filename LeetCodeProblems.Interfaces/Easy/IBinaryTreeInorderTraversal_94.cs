using LeetCodeProblems.Shared;

namespace LeetCodeProblems.Interfaces.Easy
{
    /// <summary>
    /// Given the root of a binary tree, return the inorder traversal of its nodes' values.
    /// </summary>
    public interface IBinaryTreeInorderTraversal_94
    {
        IList<int> InorderTraversal(TreeNode root);
    }
}
