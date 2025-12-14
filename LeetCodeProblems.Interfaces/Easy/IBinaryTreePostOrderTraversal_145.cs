using LeetCodeProblems.Shared;

namespace LeetCodeProblems.Interfaces.Easy
{
    /// <summary>
    /// Given the root of a binary tree, return the postorder traversal of its nodes' values.
    /// </summary>
    public interface IBinaryTreePostOrderTraversal_145
    {
        IList<int> PostOrderTraversal(TreeNode root);
    }

}
