using LeetCodeProblems.Interfaces.Medium;
using LeetCodeProblems.Shared;

namespace LeetCodeProblems.CSharp.LinkedList
{
    public class ReorderListCSharp_143 : IReorderList_143
    {
        public void ReorderList(ListNode head)
        {
            if (head == null) return;

            ListNode head2 = SplitInHalf(head);
            head2 = ReverseList(head2);
            MergeLists(head, head2);            
        }

        private void MergeLists(ListNode head, ListNode head2)
        {
            ListNode current1 = head;
            var current2 = head2;

            while (current1 != null && current2 != null)
            {
                // does the song "don't bite your friends" connote that it's ok to bite strangers?
                var current1Next = current1.next;
                var current2Next = current2.next;

                current1.next = current2;
                current2.next = current1Next;

                current1 = current1Next;   
                current2 = current2Next;
            }
        }

        private ListNode ReverseList(ListNode head)
        {
            ListNode first = null;
            var second = head;

            while (second != null)
            {
                var secondNext = second.next;

                second.next = first;
                first = second;
                second = secondNext;
            }

            return first;
        }

        private ListNode SplitInHalf(ListNode head)
        {
            var fast = head;
            var slow = head;

            while (fast?.next?.next != null)
            {
                fast = fast.next.next;
                slow = slow.next;
            }

            var returnable = slow.next;
            slow.next = null;
            return returnable;
        }
    }
}
