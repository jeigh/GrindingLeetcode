using LeetCodeProblems.FirstAttempts;
using LeetCodeProblems.Shared;

namespace TwoSum
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var unit = new MergeTwoListsSolution();

            int[] values1 = [1, 2, 4];
            int[] values2 = [1, 3, 5];
            var list1 = toLinkedList(values1);
            var list2 = toLinkedList(values2);

            var result = unit.MergeTwoLists(list1, list2);



            Console.WriteLine(result);

            Console.WriteLine("debugger");

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
