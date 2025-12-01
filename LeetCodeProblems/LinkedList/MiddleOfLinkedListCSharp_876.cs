using LeetCodeProblems.Interfaces.Easy;
using LeetCodeProblems.Shared;

namespace LeetCodeProblems.CSharp.LinkedList
{
    public class MiddleOfLinkedListCSharp_876 : IMiddleOfLinkedList_876
    {
        public ListNode MiddleNode(ListNode node)
        {
            var fast = node;
            var slow = node;

            while (fast != null && fast.next != null)
            {
                fast = fast.next.next; 
                slow = slow.next;
            }

            return slow;
        }
    }
}
