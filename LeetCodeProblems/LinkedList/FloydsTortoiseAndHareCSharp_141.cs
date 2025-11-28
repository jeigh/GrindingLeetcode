using LeetCodeProblems.Interfaces.Easy;
using LeetCodeProblems.Shared;

namespace LeetCodeProblems.CSharp.LinkedList
{
    public class FloydsTortoiseAndHareCSharp_141 : ILinkedListCycle_141
    {
        // time complexity: O(n)
        // space complexity: O(1)
        public bool HasCycle(ListNode head)
        {
            if (head == null) return false;
            if (head?.next == null) return false;
            
            ListNode? fast = head;
            ListNode? slow = head;

            while (true)
            {
                fast = fast?.next?.next;
                slow = slow?.next;

                if (fast == null) return false;
                if (fast == slow) return true;
            }
        }
    }
}
