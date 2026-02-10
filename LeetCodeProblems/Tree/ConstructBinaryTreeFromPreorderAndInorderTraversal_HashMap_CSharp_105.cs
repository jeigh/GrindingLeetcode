using LeetCodeProblems.Interfaces.Medium;
using LeetCodeProblems.Shared;

namespace LeetCodeProblems.CSharp.Tree
{
    using index = int;

    public class ConstructBinaryTreeFromPreorderAndInorderTraversal_HashMap_CSharp_105 : IConstructBinaryTreeFromPreorderAndInorderTraversal_105
    {
        public TreeNode BuildTree(int[] preorder, int[] inorder)
        {
            var inorderIndices = GenerateInOrderIndices(inorder);
            int preIndex = 0;

            return BuildTree(preorder, inorderIndices, ref preIndex, 0, inorder.Length);
        }

        private TreeNode BuildTree(int[] preorder, Dictionary<int, index> inorderIndices, ref index preIndex, index inStart, index inEnd)
        {
            if (preIndex > preorder.Length - 1) return null;
            if (inStart >= inEnd) return null;

            var currentValue = preorder[preIndex++];
            var inIndex = inorderIndices[currentValue];

            var left = BuildTree(preorder, inorderIndices, ref preIndex, inStart, inIndex);
            var right = BuildTree(preorder, inorderIndices, ref preIndex, inIndex + 1, inEnd);

            return new TreeNode(currentValue, left, right);
        }

        private Dictionary<int, index> GenerateInOrderIndices(int[] inorder)
        {
            var HashMap = new Dictionary<int, index>();
            for (index i = 0; i < inorder.Length; i++) HashMap[inorder[i]] = i;
            return HashMap;
        }
    }
}
