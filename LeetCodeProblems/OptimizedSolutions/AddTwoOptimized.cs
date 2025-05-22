using LeetCodeProblems.Shared;

namespace LeetCodeProblems.OptimizedSolutions
{
    public class AddTwoOptimized : IAddTwo
    {
        private ListNode? GetNext(ListNode? l1, ListNode? l2, int carry)
        {
            int l1val = 0;
            int l2val = 0;

            if (l1 == null && l2 == null) return null;
            if (l1?.val != null) l1val = l1.val;
            if (l2?.val != null) l2val = l2.val;

            int sum = l1val + l2val + carry;

            int remainder = sum % 10;
            carry = sum / 10;

            ListNode result = new();
            result.val = remainder;
            ListNode? necks = GetNext(l1?.next, l2?.next, carry);
            if (necks != null) result.next = necks;
            else if (carry > 0)  result.next = new ListNode(carry);
            return result;
        }

        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            return GetNext(l1, l2, 0)!;
        }
    }
}
