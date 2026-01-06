using LeetCodeProblems.Shared;

namespace LeetCodeProblems.Interfaces.Medium
{
    /// <summary>
    /// LeetCode 285: Inorder Successor in BST
    /// 
    /// Given the root of a binary search tree and a node p in it, 
    /// return the in-order successor of that node in the BST.
    /// If the given node has no in-order successor in the tree, return null.
    /// 
    /// The successor of a node p is the node with the smallest key greater than p.val.
    /// 
    /// Constraints:
    /// - The number of nodes in the tree is in the range [1, 10^4].
    /// - -10^5 <= Node.val <= 10^5
    /// - All Nodes will have unique values.
    /// </summary>
    public interface IInorderSuccessorInBST_285
    {
        /// <summary>
        /// Finds the inorder successor of node p in the BST
        /// </summary>
        /// <param name="root">Root of the binary search tree</param>
        /// <param name="p">The node to find the successor for</param>
        /// <returns>The inorder successor node, or null if no successor exists</returns>
        TreeNode InorderSuccessor(TreeNode root, TreeNode p);
    }
}
