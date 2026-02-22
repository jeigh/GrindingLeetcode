using LeetCodeProblems.Interfaces.Medium;
using LeetCodeProblems.Shared;
using index = System.Int32;


namespace LeetCodeProblems.CSharp.Tree
{
    public class ConstructBinaryTreeFromPreorderAndPostorderTraversal_RecursiveHashmap_CSharp_889 : IConstructBinaryTreeFromPreorderAndPostorderTraversal_889
    {
        public TreeNode ConstructFromPrePost(int[] preorder, int[] postorder)
        {
            var postorderIndices = CreateIndexHashmap(postorder);
            var preorderIndices = CreateIndexHashmap(preorder);
            index preIndex = 0;
            var processedValues = new HashSet<int>(preorder.Length);

            return BuildTree(preorder, postorder, postorderIndices, ref preIndex, processedValues, preorderIndices);
        }

        public TreeNode BuildTree(int[] preorder, int[] postorder, Dictionary<int, index> postorderIndices, ref index preIndex, HashSet<int> processedValues, Dictionary<int, index> preorderIndices)
        {
            var currentValue = preorder[preIndex++];
            if (processedValues.Contains(currentValue)) return null;

            processedValues.Add(currentValue);
            var postIndex = postorderIndices[currentValue];

            int? leftNodeValue = null;
            if (preIndex != preorder.Length)  leftNodeValue = preorder[preIndex];

            int? rightNodeValue = null;
            if (postIndex != 0 && !processedValues.Contains(postorder[postIndex - 1])) 
                rightNodeValue = postorder[postIndex - 1];
            
            TreeNode left = null;
            TreeNode right = null;

            if (leftNodeValue.HasValue && rightNodeValue.HasValue && leftNodeValue.Value != rightNodeValue.Value)
            {
                left = BuildTree(preorder, postorder, postorderIndices, ref preIndex, processedValues, preorderIndices);
                preIndex = preorderIndices[rightNodeValue.Value];
                right = BuildTree(preorder, postorder, postorderIndices, ref preIndex, processedValues, preorderIndices);
            }
            else if (leftNodeValue.HasValue && leftNodeValue == rightNodeValue)
                left = BuildTree(preorder, postorder, postorderIndices, ref preIndex, processedValues, preorderIndices);


            return new TreeNode(currentValue, left, right);
        }

        private Dictionary<int, index> CreateIndexHashmap(int[] source)
        {
            var dict = new Dictionary<int, index>();
            for (int i = 0; i < source.Length; i++) dict[source[i]] = i;
            return dict;
        }
    }


}
