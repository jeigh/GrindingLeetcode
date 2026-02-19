using LeetCodeProblems.Interfaces.Medium;
using LeetCodeProblems.Shared;
using index = System.Int32;


namespace LeetCodeProblems.CSharp.Tree
{
    public class ConstructBinaryTreeFromInorderAndPostorderTraversal_IterativeThreadSafe_CSharp_106 : IConstructBinaryTreeFromInOrderAndPostOrderTraversal_106
    {
        public TreeNode BuildTree(int[] inorder, int[] postorder)
        {
            var stack = new Stack<(TreeNode parent, index postStart, index postEnd, index inStart, index inEnd, bool isRight)>();
            stack.Push((null, 0, postorder.Length, 0, inorder.Length, true));
            TreeNode root = null;
            while (stack.Count > 0)
            {
                (TreeNode parent, index postStart, index postEnd, index inStart, index inEnd, bool isRight) = stack.Pop();
                if (postStart >= postEnd) continue;
                if (inStart >= inEnd) continue;

                var currentValue = postorder[postEnd - 1];

                TreeNode node = new TreeNode(currentValue);
            
                if (parent == null) root = node;
                else if (isRight) parent.right = node;
                else parent.left = node;
                
                var inIndex = GetIndex(inorder, inStart, inEnd ,currentValue);
                var leftSize = inIndex - inStart;

                index leftInStart = inStart;
                index leftInEnd = inIndex;
                index rightInStart = inIndex + 1;
                index rightInEnd = inEnd;

                index leftPostStart = postStart;
                index leftPostEnd = postStart + leftSize;
                index rightPostStart = postStart + leftSize;
                index rightPostEnd = postEnd - 1;

                // left
                stack.Push((node, leftPostStart, leftPostEnd, leftInStart, leftInEnd, false));

                // right
                stack.Push((node, rightPostStart, rightPostEnd, rightInStart, rightInEnd, true));
            }

            return root;
        }

        private index GetIndex(int[] inorder, int inStart, int inEnd, int currentValue)
        {
            for (index i = inStart; i < inEnd; i++) if (inorder[i] == currentValue) return i;
            throw new Exception("Off by 1");
        }
    }
}
