using LeetCodeProblems.Interfaces.Medium;
using LeetCodeProblems.Shared;

namespace LeetCodeProblems.CSharp.LinkedList
{
    public class DeleteNodeInALinkedListCSharp_237 : IDeleteNodeInALinkedList_237
    {
        public void DeleteNode(ListNode node)
        {
            if (node.next == null) node = null;
            else
            {
                var nextNode = node.next;
                node.next = nextNode.next;
                node.val = nextNode.val;
                nextNode = null;
            }
        }
    }
}
