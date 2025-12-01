using LeetCodeProblems.Interfaces.Medium;
using LeetCodeProblems.Shared;

namespace LeetCodeProblems.CSharp.LinkedList
{
    public class RemoveNthNodeFromEndOfListCSharp_19 : IRemoveNthNodeFromEndOfList_19
    {
        public ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            if (head == null) return null;
            if (n <= 0) throw new ApplicationException("n must be greater than zero.");

            var dummy = new ListNode(0, head);
            var left = dummy;
            var right = head;

            for (int i = 0; i < n; i++)
            {
                if (right != null)
                    right = right.next;
                else
                    throw new ApplicationException("n must be less than linked list length.");
            }
            
            while(right != null)
            {
                left = left.next;
                right = right.next;
            }

            left.next = left.next.next;

            return dummy.next;
        }
    }
}
