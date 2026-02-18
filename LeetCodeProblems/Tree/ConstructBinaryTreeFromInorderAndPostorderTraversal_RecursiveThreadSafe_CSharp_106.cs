using LeetCodeProblems.Interfaces.Medium;
using LeetCodeProblems.Shared;
using index = System.Int32;


namespace LeetCodeProblems.CSharp.Tree
{
    public class ConstructBinaryTreeFromInorderAndPostorderTraversal_RecursiveThreadSafe_CSharp_106 : IConstructBinaryTreeFromInOrderAndPostOrderTraversal_106
    {
        public TreeNode BuildTree(int[] inorder, int[] postorder)
        {
            return BuildTree(inorder, postorder, 0, postorder.Length, 0, inorder.Length);
        }

        public TreeNode BuildTree(int[] inorder, int[] postorder, index postStart, index postEnd, index inStart, index inEnd)
        {
            if (postStart >= postEnd) return null;
            if (inStart >= inEnd) return null;

            var currentValue = postorder[postEnd - 1];
            var inIndex = DetermineInorderIndex(inorder, currentValue, inStart, inEnd);
            var leftTreeSize = inIndex - inStart;

            index leftInStart = inStart;
            index leftInEnd = inIndex;
            index leftPostStart = postStart;
            index leftPostEnd = leftTreeSize + postStart;

            index rightInStart = inIndex + 1;
            index rightInEnd = inEnd;
            index rightPostStart = leftTreeSize + postStart;
            index rightPostEnd = postEnd - 1;

            TreeNode left = BuildTree(inorder, postorder, leftPostStart, leftPostEnd, leftInStart, leftInEnd);
            TreeNode right = BuildTree(inorder, postorder, rightPostStart, rightPostEnd, rightInStart, rightInEnd);

            return new TreeNode(currentValue, left, right);
        }

        private index DetermineInorderIndex(int[] inorder, int currentValue, int inStart, int inEnd)
        {
            for (int i = inStart; i < inEnd; i++)
            {
                if (inorder[i] == currentValue) return i;
            }
            throw new Exception("you have an off by 1 error somewhere");
        }
    }
}
