using LeetCodeProblems.Interfaces.Medium;
using LeetCodeProblems.Shared;

namespace LeetCodeProblems.CSharp.Tree
{
    // this is what I came up without researching the problem.  Satisfies the req, but not the follow up:
    // "Could you implement next() and hasNext() to run in average O(1) time and use O(h) memory, where h is the height of the tree?"
    public class BinarySearchTreeIterator_InOrderSuccessorSearch_CSharp_173 : IBinarySearchTreeIterator_173
    {
        private TreeNode _root;
        private TreeNode _current;
        private TreeNode _sentinel;
        private const int SENTINEL_VAL = Int32.MinValue;

        public BinarySearchTreeIterator_InOrderSuccessorSearch_CSharp_173(TreeNode root)
        {
            _root = root;          
            _sentinel = _root;
            while (_sentinel.left != null) _sentinel = _sentinel.left;
            _sentinel = new TreeNode(SENTINEL_VAL, null, _sentinel);
            _current = _sentinel;
        }

        public bool HasNext()
        {
            if (_current.right != null) return true;
            if (_root.val > _current.val) return true;

            var temp = _root;
            while (temp.right  != null) 
            { 
                temp = temp.right;
                if (temp.val > _current.val) return true;
            }
            return false;
        }

        public int Next()
        {
            if (!HasNext()) return -1;
            var currentVal = _current.val;

            var successor = _current.right;
            if (successor != null)
                while (successor.left != null) successor = successor.left;
            else
            {
                var curr = _root;

                while (_current != curr)
                {
                    if (currentVal > curr.val) curr = curr.right;
                    if (currentVal < curr.val)
                    {
                        successor = curr;
                        curr = curr.left;
                    }
                }
            }

            _current = successor;
            return successor.val;
        }
    }
}
