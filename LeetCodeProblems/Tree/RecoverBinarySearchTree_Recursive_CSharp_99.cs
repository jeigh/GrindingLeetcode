using LeetCodeProblems.Interfaces.Medium;
using LeetCodeProblems.Shared;

namespace LeetCodeProblems.CSharp.Tree
{
    // solved 2026-01-17
    public class RecoverBinarySearchTree_Recursive_CSharp_99 : IRecoverBinarySearchTree_99
    {
        private TreeNode _first;
        private TreeNode _last;
        private TreeNode _previous;

        public void RecoverTree(TreeNode root)
        {
            _first = null;
            _last = null;
            _previous = null;
        

            InOrderTraversal(root);
            Swap();
        }

        private void Swap()
        {
            var temp = _first.val;
            _first.val = _last.val;
            _last.val = temp;
        }

        private void InOrderTraversal(TreeNode node)
        {
            if (node == null) return;

            InOrderTraversal(node.left);

            if (_previous != null &&  _previous.val > node.val)
            {
                if (_first == null)
                {
                    _first = _previous;
                    _last = node;

                }
                else
                {
                    _last = node;
                }
            }

            _previous = node;

            InOrderTraversal(node.right);
        }



    }
}
