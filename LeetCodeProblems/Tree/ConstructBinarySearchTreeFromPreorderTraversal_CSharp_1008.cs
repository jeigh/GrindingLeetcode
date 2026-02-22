using LeetCodeProblems.Interfaces.Medium;
using LeetCodeProblems.Shared;

namespace LeetCodeProblems.CSharp.Tree
{
    public class ConstructBinarySearchTreeFromPreorderTraversal_CSharp_1008 : IConstructBinarySearchTreeFromPreorderTraversal_1008
    {
        public TreeNode BstFromPreorder(int[] preorder)
        {
            var index = 0;
            return BuildTree(preorder, ref index, int.MaxValue);
        }

        private TreeNode BuildTree(int[] preorder, ref int index, int tooHigh)
        {
            TreeNode root = null;
            if (index < preorder.Length)
            {
                int currentValue = preorder[index];
                if (currentValue <= tooHigh)
                {
                    index += 1;
                    root = new TreeNode(currentValue);

                    root.left = BuildTree(preorder, ref index, currentValue);
                    root.right = BuildTree(preorder, ref index, tooHigh);
                }
            }

            return root;
        }
    }
}
