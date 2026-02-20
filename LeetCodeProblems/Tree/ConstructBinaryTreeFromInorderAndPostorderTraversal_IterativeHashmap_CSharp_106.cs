using LeetCodeProblems.Interfaces.Medium;
using LeetCodeProblems.Shared;
using index = System.Int32;


namespace LeetCodeProblems.CSharp.Tree
{
    public class ConstructBinaryTreeFromInorderAndPostorderTraversal_IterativeHashmap_CSharp_106 : IConstructBinaryTreeFromInOrderAndPostOrderTraversal_106
    {
        public TreeNode BuildTree(int[] inorder, int[] postorder)
        {
            Dictionary<int, index> inorderIndices = GenerateIndices(inorder);
            index postIndex = inorderIndices.Count - 1;
            var stack = new Stack<(TreeNode parent, index inStart, index inEnd, bool isRight)>();
            stack.Push((null, 0, inorder.Length, true));
            TreeNode root = null;
            while (stack.Count > 0)
            {
                (TreeNode parent, index inStart, index inEnd, bool isRight) = stack.Pop();

                if (inStart >= inEnd) continue;
                if (postIndex < 0) continue;

                var currentValue = postorder[postIndex--];
                var node = new TreeNode(currentValue);
                var inIndex = inorderIndices[currentValue];

                if (parent == null) root = node;
                else if (isRight) parent.right = node;
                else parent.left = node;

                stack.Push((node, inStart, inIndex, false));    // left
                stack.Push((node, inIndex + 1, inEnd, true));   // right
            }

            return root;
        }

        private Dictionary<int, int> GenerateIndices(int[] inorder)
        {
            var ret = new Dictionary<int, index>();
            for (index i = 0; i < inorder.Length; i++) ret[inorder[i]] = i;
            return ret;
        }
    }
}
