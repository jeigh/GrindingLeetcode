using LeetCodeProblems.Shared;

namespace LeetCodeProblems.Interfaces.Medium
{
    /// <summary>
    /// Given the head of a linked list, remove the nth node from the end of the list and return its head.
    /// </summary>
    public interface IRemoveNthNodeFromEndOfList_19
    {
        ListNode RemoveNthFromEnd(ListNode head, int n);
    }
}