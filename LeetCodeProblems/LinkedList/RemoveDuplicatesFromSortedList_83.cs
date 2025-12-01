using LeetCodeProblems.HashingOrArrays;
using LeetCodeProblems.Interfaces.Easy;
using LeetCodeProblems.Shared;

namespace LeetCodeProblems.CSharp.LinkedList
{
    public class RemoveDuplicatesFromSortedList_83 : IRemoveDuplicatesFromSortedList_83
    {
        public ListNode DeleteDuplicates(ListNode head)
        {
            if (head == null) return null;

            ListNode current = head;

            while (current != null && current.next != null)
            {
                if (current.val == current.next.val)
                    current.next = current.next.next;
                else
                    current = current.next;
            }

            return head;
        }
    }
}
