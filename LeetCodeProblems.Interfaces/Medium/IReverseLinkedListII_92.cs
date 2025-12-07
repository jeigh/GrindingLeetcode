using LeetCodeProblems.Shared;

namespace LeetCodeProblems.Interfaces.Medium
{
    /// <summary>
    /// Given the head of a singly linked list and two integers left and right where left <= right, reverse the nodes of the list from position left to position right, and return the reversed list.
    /// </summary>
    public interface IReverseLinkedListII_92
    {
        ListNode ReverseBetween(ListNode head, int left, int right);
    }
}