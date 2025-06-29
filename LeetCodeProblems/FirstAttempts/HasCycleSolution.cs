using LeetCodeProblems.Shared;

namespace LeetCodeProblems.FirstAttempts
{
    public class HasCycleSolution
    {
        // time complexity: O(n)
        // space complexity: O(n)
        public bool HasCycleUsingHashSet(ListNode head)
        {
            var hashSet = new HashSet<ListNode>();
            ListNode current = head;
            
            while(true)
            {
                if (current == null) return false;
                if (hashSet.Contains(current)) return true;
                else hashSet.Add(current);
                current = current.next;
            }

        }
    }
}
