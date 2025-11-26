using LeetCodeProblems.Shared;

namespace LeetCodeProblems.Interfaces.Easy
{
    /// <summary>
    /// Given the head of a sorted linked list, delete all duplicates such that each element appears only once. Return the linked list sorted as well.
    /// </summary>
    public interface IRemoveDuplicatesFromSortedList_83
    {
        public ListNode DeleteDuplicates(ListNode head);
    }
}
