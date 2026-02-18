using LeetCodeProblems.Interfaces.Medium;
using LeetCodeProblems.Shared;

namespace LeetCodeProblems.CSharp.Tree
{
    using index = System.Int32;

    public class ConstructBinaryTreeFromInorderAndPostorderTraversal_RecursiveHashmap_CSharp_106 : IConstructBinaryTreeFromInOrderAndPostOrderTraversal_106
    {
        public TreeNode BuildTree(int[] inorder, int[] postorder)
        {
            var inorderIndices = CreateInorderIndices(inorder);
            index postIndex = postorder.Length - 1;

            return BuildTree(postorder, inorderIndices, 0, inorder.Length, ref postIndex);
        }

        public Dictionary<int, index> CreateInorderIndices(int[] inorder)
        {
            var returnable = new Dictionary<int, index>();
            for(index i = 0; i < inorder.Length; i++) returnable[inorder[i]] = i;
            return returnable;
        }

        public TreeNode BuildTree(int[] postorder, Dictionary<int, index> inorderIndices, index inStart, index inEnd, ref int postIndex)
        {
            if (inStart >= inEnd) return null;

            var currentValue = postorder[postIndex--];
            var inIndex = inorderIndices[currentValue];

            TreeNode right = BuildTree(postorder, inorderIndices, inIndex + 1, inEnd, ref postIndex);
            TreeNode left = BuildTree(postorder, inorderIndices, inStart, inIndex, ref postIndex);

            return new TreeNode(currentValue, left, right);
        }
    }
}
