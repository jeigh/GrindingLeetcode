using LeetCodeProblems.Shared;

namespace LeetCodeProblems.FirstAttempts
{
    public class ReverseListSolution
    {
        // time complexity: O(n)
        // space complexity: O(1)
        public ListNode ReverseList(ListNode head)
        {
            if (head == null) return null;
            ListNode currentNode = head;
            ListNode prevNode = null;

            while (true)
            {
                ListNode nextNode = currentNode.next;
                currentNode.next = prevNode;

                prevNode = currentNode;
                if (nextNode != null) currentNode = nextNode;
                else return currentNode;
            }
        }
    }
}
