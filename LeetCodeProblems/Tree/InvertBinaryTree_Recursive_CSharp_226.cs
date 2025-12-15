using LeetCodeProblems.Interfaces.Easy;
using LeetCodeProblems.Shared;

namespace LeetCodeProblems.CSharp.Tree
{
    // solved 2025-07-02
    public class InvertBinaryTree_Recursive_CSharp_226 : IInvertBinaryTree_226
    {
        // space complexity: O(h);  time complexity: O(n)
        // where h is the height of the tree, and n is the number of nodes in the tree
        public TreeNode InvertTree(TreeNode root)
        {
            if (root == null) return null;
            
            var temp = root.left;
            root.left = InvertTree(root.right);
            root.right = InvertTree(temp);
            return root;
        }
    }
}
