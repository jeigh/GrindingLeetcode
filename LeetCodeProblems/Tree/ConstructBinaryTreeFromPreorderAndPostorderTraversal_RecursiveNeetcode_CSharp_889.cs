using LeetCodeProblems.Interfaces.Medium;
using LeetCodeProblems.Shared;
using index = System.Int32;


namespace LeetCodeProblems.CSharp.Tree
{
    public class ConstructBinaryTreeFromPreorderAndPostorderTraversal_RecursiveNeetcode_CSharp_889 : IConstructBinaryTreeFromPreorderAndPostorderTraversal_889
    {
        public TreeNode ConstructFromPrePost(int[] preorder, int[] postorder)
        {           
            var postIndices = CreateIndices(postorder);

            return buildTree(preorder, postIndices, 0, postorder.Length - 1, 0);
        }

        private TreeNode buildTree(int[] preorder, Dictionary<int, int> postIndices, int preStart, int preEnd, int postStart)
        {
            if (preStart > preEnd) return null;

            var currentValue = preorder[preStart];
            
            TreeNode left = null;
            TreeNode right = null;

            if (preStart != preEnd)
            {
                var left_val = preorder[preStart + 1];
                var mid = postIndices[left_val];
                var leftSize = mid - postStart + 1;
                left = buildTree(preorder, postIndices, preStart + 1, preStart + leftSize, postStart);
                right = buildTree(preorder, postIndices, preStart + leftSize + 1, preEnd, mid + 1);
            }

            return new TreeNode(currentValue, left, right);            
        }

        public Dictionary<int, index> CreateIndices(int[] values)
        {
            var ret= new Dictionary<int, index>();
            for (index i = 0; i < values.Length; i++) ret[values[i]] = i;
            return ret;
        }

        
    }


}
