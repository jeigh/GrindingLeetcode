using LeetCodeProblems.Shared;

namespace LeetCodeProblems.Interfaces.Easy
{
    /// <summary>
    /// Given the heads of two singly linked-lists headA and headB, return the node at which the two lists intersect. If the two linked lists have no intersection at all, return null.
    /// 
    /// The test cases are generated such that there are no cycles anywhere in the entire linked structure.
    /// 
    /// Note that the linked lists must retain their original structure after the function returns.
    /// </summary>
    public interface IIntersectionOfTwoLinkedLists_160
    {
        ListNode GetIntersectionNode(ListNode headA, ListNode headB);
    }
}
