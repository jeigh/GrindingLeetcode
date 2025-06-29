using LeetCodeProblems.Shared;

namespace LeetCodeProblems.FirstAttempts
{
    public class MergeTwoListsSolution
    {
        // time complexity: O(n+m)
        // space complexity: O(n+m)

        public ListNode MergeTwoLists(ListNode list1, ListNode list2)
        {
            if (list1 == null) return list2;
            if (list2 == null) return list1;

            var result = new ListNode();

            var currentNode = result;
            var firstListNode = list1;
            var secondListNode = list2;
            ListNode prevResult = null;

            while (!(firstListNode == null && secondListNode == null))
            {
                if (prevResult != null) 
                    prevResult.next = currentNode;

                if (secondListNode == null || firstListNode != null && firstListNode.val <= secondListNode.val)
                {
                    currentNode.val = firstListNode!.val;
                    firstListNode = firstListNode?.next;
                }

                else if (firstListNode == null || secondListNode != null && firstListNode.val > secondListNode.val)
                {
                    currentNode.val = secondListNode!.val;
                    secondListNode = secondListNode?.next;
                }
                
                prevResult = currentNode;
                currentNode = new ListNode();
            }
            
            return result;
        }
    }
}
