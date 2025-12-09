using LeetCodeProblems.Interfaces.Medium;
using LeetCodeProblems.Shared;

namespace LeetCodeProblems.CSharp.LinkedList
{
    public class ReverseLinkedListII_ReversalAndReconnectCSharp_92 : IReverseLinkedListII_92
    {
        public ListNode ReverseBetween(ListNode head, int left, int right)
        {
            var dummy = new ListNode(0, head);
            var leftNode = dummy;
            var current = head;

            for (var i = 0; i < left - 1; i++)
            {
                leftNode = current;
                current = current.next;
            }

            ListNode? prev = null;
            var remainingIterationCount = right - left + 1;
            while (remainingIterationCount > 0)
            {
                var temp = current.next;

                current.next = prev;
                prev = current;
                current = temp;

                remainingIterationCount--;
            }

            leftNode.next.next = current;
            leftNode.next = prev;

            return dummy.next;
        }
    }
}
