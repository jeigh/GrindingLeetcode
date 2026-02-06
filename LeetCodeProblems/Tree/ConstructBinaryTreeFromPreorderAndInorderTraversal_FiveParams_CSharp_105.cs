using LeetCodeProblems.Interfaces.Medium;
using LeetCodeProblems.Shared;

namespace LeetCodeProblems.CSharp.Tree
{
    using index = System.Int32;
    public class ConstructBinaryTreeFromPreorderAndInorderTraversal_FiveParams_CSharp_105 : IConstructBinaryTreeFromPreorderAndInorderTraversal_105
    {      
        public TreeNode BuildTree(int[] preorder, int[] inorder)
        {
            int inIndex = 0;
            int preIndex = 0;
            return BuildSubTree(preorder, inorder, Int64.MaxValue, ref preIndex, ref inIndex);
        }

        public TreeNode BuildSubTree(int[] preorder, int[] inorder, Int64 limitValue, ref index preIndex, ref index inIndex)
        {
            if (inorder.Length <= inIndex) return null;
            if (preorder.Length <= preIndex) return null;
            if (inorder[inIndex] == limitValue)
            {
                inIndex += 1;
                return null;
            }

            var currentValue = preorder[preIndex++];


            var left = BuildSubTree(preorder, inorder, currentValue, ref preIndex,  ref inIndex);
            var right = BuildSubTree(preorder, inorder, limitValue, ref preIndex, ref inIndex);

            return new TreeNode(currentValue, left, right);
        }

        

    }
}
