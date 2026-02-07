using LeetCodeProblems.Interfaces.Medium;
using LeetCodeProblems.Shared;
using System.ComponentModel.Design.Serialization;

namespace LeetCodeProblems.CSharp.Tree
{
    using index = int;

    public class ConstructBinaryTreeFromPreorderAndInorderTraversal_SixParams_CSharp_105 : IConstructBinaryTreeFromPreorderAndInorderTraversal_105
    {
        public TreeNode BuildTree(int[] preorder, int[] inorder) =>
            BuildTree(preorder, inorder, 0, preorder.Length, 0, inorder.Length);

        private TreeNode BuildTree(int[] preorder, int[] inorder, index preStart, index preEnd, index inStart, index inEnd)
        {
            if (preorder.Length < preStart) return null;
            if (inorder.Length < inStart) return null;
            if (preStart >= preEnd) return null;
            if (inStart >= inEnd) return null;
            
            var currentValue = preorder[preStart];
            var inIndex = GetInIndex(inorder, inStart, inEnd, currentValue);
            var leftSize = inIndex - inStart;

            var leftPreStart = preStart + 1;
            var leftPreEnd = preStart + 1 + leftSize;

            var leftInStart = inStart;
            var leftInEnd = inIndex + 1;

            var rightPreStart = preStart + 1 + leftSize;
            var rightPreEnd = preEnd;

            var rightInStart = inIndex + 1;
            var rightInEnd = inEnd;

            TreeNode left = BuildTree(preorder, inorder, leftPreStart, leftPreEnd, leftInStart, leftInEnd);
            TreeNode right = BuildTree(preorder, inorder, rightPreStart, rightPreEnd, rightInStart, rightInEnd);

            return new TreeNode(currentValue, left, right); 
        }

        private index GetInIndex(int[] inorder, index inStart, index inEnd, int searchValue)
        {
            for (index i = inStart; i < inEnd; i++)
            {
                if (inorder[i] == searchValue) return i;
            }
            throw new Exception("you have an off by 1 error somewhere");
        }
    }
}
