using LeetCodeProblems.Interfaces.Medium;
using LeetCodeProblems.Shared;

namespace LeetCodeProblems.CSharp.Tree
{
    public class BinaryTreeRightSideView_RecursiveInOrder_CSharp_199 : IBinaryTreeRightSideView_199
    {
        public List<int> RightSideView(TreeNode root)
        {
            var returnable = new List<int>();
            if (root == null) return returnable;
            var depth = 0;
            var responseCollection = new List<int>();
            InOrder(root, depth, responseCollection);
            return responseCollection;
        }

        private void InOrder(TreeNode node, int depth, List<int> responseCollection)
        {
            if (node == null) return;
            InOrder(node.left, depth + 1, responseCollection);

            while (responseCollection.Count < depth + 1) responseCollection.Add(node.val);
            responseCollection[depth] = node.val;

            InOrder(node.right, depth + 1, responseCollection);
        }
    }
}
