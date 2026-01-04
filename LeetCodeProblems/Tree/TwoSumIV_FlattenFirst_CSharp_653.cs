using LeetCodeProblems.Interfaces.Easy;
using LeetCodeProblems.Shared;

namespace LeetCodeProblems.CSharp.Tree
{
    public class TwoSumIV_FlattenFirst_CSharp_653 : ITwoSumIV_653
    {
        public bool FindTarget(TreeNode root, int k)
        {
            var flattened = InorderTraversal(root);

            var left = 0;
            var right = flattened.Length - 1;

            while (left < right)
            {
                if (flattened[left] + flattened[right] > k) right--;
                else if (flattened[left] + flattened[right] < k) left++;
                else return true;
            }
            return false;
        }

        private int[] InorderTraversal(TreeNode root)
        {
            List<int> result = [];
            if (root == null) return result.ToArray();
            var stack = new Stack<TreeNode>();
            var current = root;            
            
            while (current != null || stack.Count > 0)
            {
                while (current != null)
                {
                    stack.Push(current);
                    current = current.left;
                }

                current = stack.Pop();
                result.Add(current.val);
                current = current.right;
            }

            return result.ToArray();
        }
    }
}
