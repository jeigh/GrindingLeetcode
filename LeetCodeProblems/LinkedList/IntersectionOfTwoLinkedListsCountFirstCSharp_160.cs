using LeetCodeProblems.Interfaces.Easy;
using LeetCodeProblems.Shared;

namespace LeetCodeProblems.CSharp.LinkedList
{
    public class IntersectionOfTwoLinkedListsCountFirstCSharp_160 : IIntersectionOfTwoLinkedLists_160
    {
        public ListNode GetIntersectionNode(ListNode headA, ListNode headB)
        {
            var lenA = GetLength(headA);
            var lenB = GetLength(headB);

            var diff = lenA - lenB;

            var currentA = headA;
            var currentB = headB;

            for (var i = 0; i < diff; i++)
            {
                currentA = currentA.next;
            }

            for (var i = 0; i > diff; i--)
            {
                currentB = currentB.next;
            }

            while (currentA != currentB)
            {
                currentA = currentA.next;
                currentB = currentB.next;
            }

            return currentA;
        }

        private int GetLength(ListNode node)
        {
            var count = 0;
            while (node != null) 
            { 
                node = node.next;
                count++;
            }
            return count;
        }
    }
}
