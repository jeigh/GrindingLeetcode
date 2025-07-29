using LeetCodeProblems;
using LeetCodeProblems.Shared;
using System.Diagnostics;

namespace TwoSum
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var unit = new NonCyclicalNumbersSolution();

            var result = unit.IsHappy(19);

            Console.Write(result);

        }

        public static TreeNode ToBinaryTree(int?[] values)
        {
            if (values == null || values.Length == 0 || values[0] == null) return null;

            TreeNode root = new TreeNode(values[0].Value);
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            int i = 1;

            while (queue.Count > 0 && i < values.Length)
            {
                TreeNode current = queue.Dequeue();

                // Left child
                if (i < values.Length && values[i] != null)
                {
                    current.left = new TreeNode(values[i].Value);
                    queue.Enqueue(current.left);
                }
                i++;

                // Right child
                if (i < values.Length && values[i] != null)
                {
                    current.right = new TreeNode(values[i].Value);
                    queue.Enqueue(current.right);
                }
                i++;
            }
            return root;
        }


        private static ListNode toLinkedList(int[] values)
        {
            ListNode head1 = null;
            
            for (int i = values.Length - 1; i >= 0; i--)
            {
                head1 = new ListNode(values[i], head1);
            }
            return head1;
        }
    }
}
