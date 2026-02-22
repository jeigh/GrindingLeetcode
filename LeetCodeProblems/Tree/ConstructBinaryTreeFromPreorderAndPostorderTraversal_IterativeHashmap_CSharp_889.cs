using LeetCodeProblems.Interfaces.Medium;
using LeetCodeProblems.Shared;
using index = System.Int32;


namespace LeetCodeProblems.CSharp.Tree
{
    public class ConstructBinaryTreeFromPreorderAndPostorderTraversal_IterativeHashmap_CSharp_889 : IConstructBinaryTreeFromPreorderAndPostorderTraversal_889
    {
        public TreeNode ConstructFromPrePost(int[] preorder, int[] postorder)
        {
            var stack = new Stack<(TreeNode? parent, index preIndex, bool isRight)>();
            var preIndices = CreateIndices(preorder);
            var postIndices = CreateIndices(postorder);
            TreeNode root = null;
            stack.Push((null, 0, true));
            while (stack.Count > 0)
            {
                (TreeNode? parent, index preIndex, bool isRight) = stack.Pop();

                var currentValue = preorder[preIndex];
                
                if (!preIndices.ContainsKey(currentValue)) continue;
                var postIndex = postIndices[currentValue];
                preIndices.Remove(currentValue);
                postIndices.Remove(currentValue);

                var node = new TreeNode(currentValue);

                if (parent == null) root = node;
                else if (isRight) parent.right = node;
                else parent.left = node;                

                int? leftNodeValue = null;
                index? leftPreIndex = null;
                if (preIndex + 1 < preorder.Length) 
                { 
                    leftNodeValue = preorder[preIndex + 1];
                    leftPreIndex = preIndices[leftNodeValue.Value];
                }

                index? rightPreIndex = null;
                int? rightNodeValue = null;
                index rightPostIndex = postIndex - 1;

                if (rightPostIndex >= 0 && postIndices.ContainsKey(postorder[rightPostIndex])) 
                { 
                    rightNodeValue = postorder[postIndex - 1];
                    rightPreIndex = preIndices[rightNodeValue.Value];
                }

                if (leftNodeValue.HasValue && rightNodeValue.HasValue && leftNodeValue.Value != rightNodeValue.Value)
                {
                    stack.Push((node, rightPreIndex!.Value, true));   // right
                    stack.Push((node, leftPreIndex!.Value, false));   // left
                }
                else if (leftNodeValue.HasValue && leftNodeValue == rightNodeValue)
                {
                    stack.Push((node, leftPreIndex!.Value, false));  // left
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
