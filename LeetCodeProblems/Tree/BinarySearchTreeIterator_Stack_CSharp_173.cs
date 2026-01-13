using LeetCodeProblems.Interfaces.Medium;
using LeetCodeProblems.Shared;

namespace LeetCodeProblems.CSharp.Tree
{
    public class BinarySearchTreeIterator_Stack_CSharp_173 : IBinarySearchTreeIterator_173
    {
        private Stack<TreeNode> _stack = new();
        private TreeNode _root;

        public BinarySearchTreeIterator_Stack_CSharp_173(TreeNode root)
        {
            _root = root;
            PushLeftBranchToStack(root);
        }

        private void PushLeftBranchToStack(TreeNode node)
        {
            while (node != null)
            {
                _stack.Push(node);
                node = node.left;
            }            
        }

        public bool HasNext() => _stack.Count > 0;

        public int Next()
        {
            var current = _stack.Pop();
            if (current.right != null) PushLeftBranchToStack(current.right);
            return current.val;
        }
    }
}
