using LeetCodeProblems.Interfaces.Easy;
using LeetCodeProblems.Shared;

namespace LeetCodeProblems.CSharp.LinkedList
{
    public class IntersectionOfTwoLinkedListOptimizedCSharp_160 : IIntersectionOfTwoLinkedLists_160
    {
        public ListNode GetIntersectionNode(ListNode headA, ListNode headB)
        {
            var nodeA = headA;
            var nodeB = headB;

            while (nodeA != nodeB)
            {
                if (nodeA.next != null) nodeA = nodeA.next; 
                else nodeA = headB;

                if (nodeB.next != null) nodeB = nodeB.next;
                else nodeB = headA;
            }

            return nodeA;
        }
    }
}
