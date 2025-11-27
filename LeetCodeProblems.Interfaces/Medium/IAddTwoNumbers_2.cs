using LeetCodeProblems.Shared;

namespace LeetCodeProblems.Interfaces.Medium
{
    /// <summary>
    /// You are given two non-empty linked lists representing two non-negative integers. The digits are stored in reverse order, and each of their nodes contains a single digit. Add the two numbers and return the sum as a linked list.
    /// 
    /// You may assume the two numbers do not contain any leading zero, except the number 0 itself.
    /// </summary>
    public interface IAddTwoNumbers_2
    {
        ListNode AddTwoNumbers(ListNode l1, ListNode l2);
    }
}