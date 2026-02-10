using LeetCodeProblems.Interfaces.Medium;
using LeetCodeProblems.Shared;

namespace LeetCodeProblems.CSharp.Tree
{
    using index = int;

    // solved 2026-02-07
    public class ConstructBinaryTreeFromPreorderAndInorderTraversal_IterativeHashMap_CSharp_105 : IConstructBinaryTreeFromPreorderAndInorderTraversal_105
    {

        public TreeNode BuildTree(int[] preorder, int[] inorder)
        {
            if (inorder.Length == 0) return null;
            var inorderIndices = GenerateInorderIndices(inorder);
            var stack = new Stack<(TreeNode parent, index inStart, index inEnd, bool isRight)>();
            stack.Push((null, 0, inorder.Length - 1, false));
            index preIndex = 0;
            TreeNode root = null;
            while (stack.Count > 0)
            {
                (TreeNode parent, index inStart, index inEnd, bool isRight) = stack.Pop();

                if (inStart > inEnd) continue;
                if (preIndex >= preorder.Length) continue;

                var currentValue = preorder[preIndex++];
                var currentNode = new TreeNode(currentValue);

                if (parent == null) root = currentNode;
                else if (isRight) parent.right = currentNode;
                else parent.left = currentNode;

                var inIndex = inorderIndices[currentValue];

                // right
                stack.Push((currentNode, inIndex + 1, inEnd, true));

                // left
                stack.Push((currentNode, inStart, inIndex - 1, false));
            }

            return root;
        }

        public Dictionary<int, index> GenerateInorderIndices(int[] inorder)
        {
            var returnable = new Dictionary<int, index>();
            for (index i = 0; i < inorder.Length; i++) returnable[inorder[i]] = i;
            return returnable;
        }
    }
}
