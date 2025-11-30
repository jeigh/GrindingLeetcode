using LeetCodeProblems.Interfaces.Easy;
using LeetCodeProblems.Shared;

namespace LeetCodeProblems.CSharp.LinkedList
{
    public class IntersectionOfTwoLinkedListsUsingHashmapCSharp_160 : IIntersectionOfTwoLinkedLists_160
    {
        public ListNode GetIntersectionNode(ListNode headA, ListNode headB)
        {
            var hashSet = new HashSet<ListNode>();
            var current = headA;

            while (current != null)
            {
                hashSet.Add(current);
                current = current.next;
            }

            current = headB;
            while (!hashSet.Contains(current) && current != null)
            {
                current = current.next;                
            }
            return current;
        }
    }
}
