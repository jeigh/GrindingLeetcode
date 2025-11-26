using LeetCodeProblems.Shared;

namespace LeetCodeProblems.Interfaces.Easy
{
    /// <summary>
    /// You are given the heads of two sorted linked lists list1 and list2.
    /// 
    /// Merge the two lists into one sorted list.The list should be made by splicing together the nodes of the first two lists.
    /// 
    /// Return the head of the merged linked list.
    /// </summary>
    public interface IMergeTwoLists_21
    {
        ListNode MergeTwoLists(ListNode list1, ListNode list2);
    }
}
