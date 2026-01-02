using LeetCodeProblems.Interfaces.Medium;
using LeetCodeProblems.Shared;

namespace LeetCodeProblems.CSharp.Tree
{
    // solved 2025-12-30
    public class InsertIntoABinarySearchTree_Iterative_CSharp_701 : IInsertIntoABinarySearchTree_701
    {
        public TreeNode InsertIntoBST(TreeNode root, int val)
        {
            if (root == null) return new TreeNode(val);
            var top = root;
            while (true)
            {
                if (val < top.val && top.left != null) 
                { 
                    top = top.left;
                    continue;
                }
                else if (val < top.val) 
                { 
                    top.left = new TreeNode(val); 
                    break; 
                }

                if (val > top.val && top.right != null) 
                { 
                    top = top.right;
                    continue;
                }
                else if (val > top.val)
                {
                    top.right = new TreeNode(val);
                    break;
                }
            }
            return root;
        }
    }
}
