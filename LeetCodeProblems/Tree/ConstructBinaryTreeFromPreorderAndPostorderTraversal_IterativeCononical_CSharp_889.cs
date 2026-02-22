using LeetCodeProblems.Interfaces.Medium;
using LeetCodeProblems.Shared;
using index = System.Int32;

namespace LeetCodeProblems.CSharp.Tree
{
    public class ConstructBinaryTreeFromPreorderAndPostorderTraversal_IterativeCononical_CSharp_889 : IConstructBinaryTreeFromPreorderAndPostorderTraversal_889
    {
        public TreeNode ConstructFromPrePost(int[] preorder, int[] postorder)
        {
            var stack = new Stack<(TreeNode? parent, index preStart, index preEnd, index postStart, index postEnd, bool isRight)>();
            Dictionary<int, index> postOrderIndices = CreateIndices(postorder);
            stack.Push((null, 0, preorder.Length, 0, postorder.Length, false));
            TreeNode root = null;
            while (stack.Count > 0)
            {
                var sf = stack.Pop();

                if (sf.preStart >= sf.preEnd) continue;
                if (sf.postStart >= sf.postEnd) continue;

                var currentValue = preorder[sf.preStart];
                var node = new TreeNode(currentValue);

                if (sf.parent == null) root = node;
                else if (sf.isRight) sf.parent.right = node;
                else sf.parent.left = node;

                if (sf.preStart == sf.preEnd - 1) continue;

                var nextPreorderValue = preorder[sf.preStart + 1];
                var postIndexOfNextPreorderValue = postOrderIndices[nextPreorderValue];
                var leftSize = postIndexOfNextPreorderValue - sf.postStart + 1;

                index leftPreStart = sf.preStart + 1;
                index leftPreEnd = sf.preStart + leftSize + 1;
                index rightPreStart = sf.preStart + leftSize + 1;
                index rightPreEnd = sf.preEnd;

                index leftPostStart = sf.postStart;
                index leftPostEnd = postIndexOfNextPreorderValue + 1;
                index rightPostStart = postIndexOfNextPreorderValue + 1;
                index rightPostEnd = sf.postEnd - 1;

                stack.Push((node, leftPreStart, leftPreEnd, leftPostStart, leftPostEnd, false));
                stack.Push((node, rightPreStart, rightPreEnd, rightPostStart, rightPostEnd, true));
            }

            return root;
        }

        private Dictionary<int, index> CreateIndices(int[] postorder)
        {
            var returnable = new Dictionary<int, index>();
            for (index i = 0; i < postorder.Length; i++) returnable[postorder[i]] = i;
            return returnable;
        }
    }


}
