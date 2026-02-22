using LeetCodeProblems.Interfaces.Medium;
using LeetCodeProblems.Shared;
using index = System.Int32;


namespace LeetCodeProblems.CSharp.Tree
{
    public class ConstructBinaryTreeFromPreorderAndPostorderTraversal_RecursiveCononical_CSharp_889 : IConstructBinaryTreeFromPreorderAndPostorderTraversal_889
    {
        public TreeNode ConstructFromPrePost(int[] preorder, int[] postorder)
        {
            var postorderIndices = CreateIndexHashmap(postorder);
            return BuildTree(preorder, postorderIndices, 0, preorder.Length, 0, postorder.Length);
        }

        private TreeNode BuildTree(int[] preorder, Dictionary<int, index> postorderIndices, index preStart, index preEnd, index postStart, index postEnd)
        {
            if (preStart >= preEnd) return null;
            if (postStart >= postEnd) return null;

            int rootVal = preorder[preStart];
            
            TreeNode root = new TreeNode(rootVal);
            if (preStart == preEnd - 1) return root;

            int leftChildVal = preorder[preStart + 1];
            int leftChildPostIndex = postorderIndices[leftChildVal];
            int leftSize = leftChildPostIndex - postStart + 1;

            index leftPreStart = preStart + 1;
            index leftPreEnd = preStart + leftSize + 1;
            index rightPreStart = preStart + leftSize + 1;
            index rightPreEnd = preEnd;

            index leftPostStart = postStart;
            index leftPostEnd = leftChildPostIndex + 1;
            index rightPostStart = leftChildPostIndex + 1;
            index rightPostEnd = postEnd - 1;

            root.left = BuildTree(preorder, postorderIndices, leftPreStart, leftPreEnd, leftPostStart, leftPostEnd);
            root.right = BuildTree(preorder, postorderIndices, rightPreStart, rightPreEnd, rightPostStart, rightPostEnd);

            return root;
        }

        private Dictionary<int, index> CreateIndexHashmap(int[] source)
        {
            var dict = new Dictionary<int, index>();
            for (int i = 0; i < source.Length; i++) dict[source[i]] = i;
            return dict;
        }
    }


}
