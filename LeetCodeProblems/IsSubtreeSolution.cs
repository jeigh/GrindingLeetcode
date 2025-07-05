namespace LeetCodeProblems
{
    public class IsSubtreeSolution
    {
        // time complexity: O(n*m), where n and m are the number of nodes in each tree.
        // space complexity: O(h1+h2) where h1 is the height of the root, and h2 is the height of subroot
        public bool IsSubtree(TreeNode root, TreeNode subroot)
        {
            if (subroot == null) return true;
            if (root == null && subroot == null) return true;
            if (root != null && subroot == null) return false;
            if (root == null && subroot != null) return false;
            
            if (IsSameTree(root, subroot)) return true;

            var leftIsSubtree = IsSubtree(root.left, subroot);
            var rightIsSubtree = IsSubtree(root.right, subroot);

            if (leftIsSubtree || rightIsSubtree) return true;
            return false;            
        }

        private bool IsSameTree(TreeNode q, TreeNode p)
        {
            if (q == null && p == null) return true;
            if (q != null && p == null) return false;
            if (q == null && p != null) return false;
            if (q.val != p.val) return false;

            var left = IsSameTree(q.left, p.left);
            var right = IsSameTree(q.right, p.right);

            return left && right;
        }
    }
}
