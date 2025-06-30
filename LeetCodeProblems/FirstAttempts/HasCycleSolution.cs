using LeetCodeProblems.Shared;

namespace LeetCodeProblems.FirstAttempts
{
    public class HasCycleSolution
    {
        // time complexity: O(n)
        // space complexity: O(1)
        public bool HasCycleUsingFastAndSlowPointers(ListNode head)
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
