using LeetCodeProblems.AddTwo;

namespace TwoSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var solution = new AddTwoUnoptimized();

            var val = solution.AddTwoNumbers(
                new ListNode(2, new ListNode(4, new ListNode(3))),
                new ListNode(5, new ListNode(6, new ListNode(4)))
            );

            Console.WriteLine("debugger");

        }
    }
}
