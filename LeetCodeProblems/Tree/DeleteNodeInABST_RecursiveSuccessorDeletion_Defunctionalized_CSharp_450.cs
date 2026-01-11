using LeetCodeProblems.Interfaces.Medium;
using LeetCodeProblems.Shared;

namespace LeetCodeProblems.CSharp.Tree
{
    public class DeleteNodeInABST_RecursiveSuccessorDeletion_Defunctionalized_CSharp_450 : IDeleteNodeInABST_450
    {
        public TreeNode DeleteNode(TreeNode root, int key)
        {
            return new DeleteFrame(root, key).Recurse();
        }

        private class DeleteFrame
        {
            private readonly TreeNode _node;
            private readonly int _key;

            public DeleteFrame(TreeNode node, int key)
            {
                _node = node;
                _key = key;
            }

            public TreeNode Recurse()
            {
                DeleteFrame frame = null;
                if (_node == null) return null;

                if (_key > _node.val)
                {
                    frame = new DeleteFrame(_node.right, _key);
                    _node.right = frame.Recurse();
                    return _node;
                }

                if (_key < _node.val)
                {
                    frame = new DeleteFrame(_node.left, _key);
                    _node.left = frame.Recurse();
                    return _node;
                }

                if (_node.left == null) return _node.right;
                if (_node.right == null) return _node.left;

                var successor = FindMinNode(_node.right);
                
                _node.val = successor.val;
                
                frame = new DeleteFrame(_node.right, _node.val);
                _node.right = frame.Recurse();

                return _node;
            }

            private TreeNode FindMinNode(TreeNode node)
            {
                var current = node;
                while (current.left != null) current = current.left;
                return current;
            }
        }
    }
}
