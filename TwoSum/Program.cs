using LeetCodeProblems.FirstAttempts;
using LeetCodeProblems.Shared;

namespace TwoSum
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var unit = new DiameterOfBinaryTreeSolution();


            int?[] input = [4, -7, -3, null, null, -9, -3, 9, -7, -4, null, 6, null, -6, -6, null, null, 0, 6, 5, null, 9, null, null, -1, -4, null, null, null, -2];
            TreeNode root = ToBinaryTree(input);

            var result = unit.DiameterOfBinaryTree(root); 

            Console.WriteLine(result);

            Console.WriteLine("debugger");

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
