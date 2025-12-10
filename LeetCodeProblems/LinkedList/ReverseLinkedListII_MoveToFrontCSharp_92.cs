using LeetCodeProblems.Interfaces.Medium;
using LeetCodeProblems.Shared;

namespace LeetCodeProblems.CSharp.LinkedList
{
    public class ReverseLinkedListII_MoveToFrontCSharp_92 : IReverseLinkedListII_92
    {
        public ListNode ReverseBetween(ListNode head, int left, int right)
        {
            var dummy = new ListNode(0, head);
            var prev = dummy;

            for (var i = 0; i < left - 1; i++)
            {
                prev = prev.next;
            }

            var current = prev.next;

            var remainingIterationCount = right - left;
            while (remainingIterationCount > 0)
            {
                var temp = current.next;

                current.next = temp.next;
                temp.next = prev.next;

                prev.next = temp;

                remainingIterationCount--;
            }

            return dummy.next;
        }
    }
}
