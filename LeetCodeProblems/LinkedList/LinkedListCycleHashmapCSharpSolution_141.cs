using LeetCodeProblems.Interfaces.Easy;
using LeetCodeProblems.Shared;

namespace LeetCodeProblems.CSharp.LinkedList
{
    public class LinkedListCycleHashmapCSharpSolution_141 : ILinkedListCycle_141
    {
        // time complexity: O(n)
        // space complexity: O(n)
        public bool HasCycle(ListNode head)
        {
            var hashSet = new HashSet<ListNode>();
            ListNode current = head;

            while (true)
            {
                if (current == null) return false;
                if (hashSet.Contains(current)) return true;
                else hashSet.Add(current);
                current = current.next;
            }
        }
    }
}
