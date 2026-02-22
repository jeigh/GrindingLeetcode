using LeetCodeProblems.HashingOrArrays;
using LeetCodeProblems.Interfaces.Medium;
using LeetCodeProblems.Shared;
using System.ComponentModel.Design.Serialization;
using index = System.Int32;


namespace LeetCodeProblems.CSharp.Tree
{
    public class ConstructBinaryTreeFromPreorderAndPostorderTraversal_IterativeNeetcode_CSharp_889 : IConstructBinaryTreeFromPreorderAndPostorderTraversal_889
    {
        public TreeNode ConstructFromPrePost(int[] preorder, int[] postorder)
        {
            var stack = new Stack<(TreeNode? parent, index preStart, index preEnd, index postIndex, bool isRight)>();
            var postIndices = CreateIndices(postorder);
            TreeNode root = null;
            stack.Push((null, 0, preorder.Length, 0, false));
            while (stack.Count > 0)
            {
                (TreeNode? parent, index preStart, index preEnd, index postStart, bool isRight) = stack.Pop();

                if (preStart >= preEnd) continue;

                var currentValue = preorder[preStart];
                var node = new TreeNode(currentValue);

                if (root == null) root = node;
                else if (isRight) parent!.right = node;
                else parent!.left = node;

                if (preStart != preEnd - 1)
                {
                    int leftValue = preorder[preStart + 1];
                    index leftValuePostIndex = postIndices[leftValue];
                    int leftSize = leftValuePostIndex - postStart + 1;

                    index leftPreStart = preStart + 1;
                    index leftPreEnd = preStart + leftSize + 1;
                    index rightPreStart = preStart + leftSize + 1;
                    index rightPreEnd = preEnd;

                    index leftPostStart = postStart;
                    index rightPostStart = leftSize + postStart; 

                    stack.Push((node, leftPreStart, leftPreEnd, leftPostStart, false));
                    stack.Push((node, rightPreStart, rightPreEnd, rightPostStart, true));
                }
            }
            return root;
        }

        private Dictionary<int, int> CreateIndices(int[] collection)
        {
            var ret = new Dictionary<int, index>();
            for (index i = 0; i < collection.Length; i++) ret[collection[i]] = i;
            return ret;
        }
    }


}
