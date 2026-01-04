using LeetCodeProblems.Interfaces.Easy;
using LeetCodeProblems.Shared;

namespace LeetCodeProblems.CSharp.Tree
{
    public class TwoSumIV_HashMap_CSharp_653 : ITwoSumIV_653
    {
        public bool FindTarget(TreeNode root, int k)
        {
            if (root == null) return false;
            var hashset = new HashSet<int>();
            var stack = new Stack<TreeNode>();
            stack.Push(root);

            while (stack.Count > 0)
            {
                var popped = stack.Pop();

                var searchVal = k - popped.val;
                if (hashset.Contains(searchVal)) return true;
                hashset.Add(popped.val);

                if (popped.left != null) stack.Push(popped.left);
                if (popped.right != null) stack.Push(popped.right);
            }

            return false;
        }
    }
}
