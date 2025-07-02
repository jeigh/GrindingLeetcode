namespace LeetCodeProblems
{
    public class MaxDepthSolution
    {
        // space complexity: O(h), time complexity: O(n)
        public int MaxDepth(TreeNode root)
        {
            if (root == null) return 0;
            
            return Math.Max(MaxDepth(root.left) + 1, MaxDepth(root.right) + 1);
        }
    }
}
