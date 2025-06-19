using LeetCodeProblems.Shared;
using System.Numerics;
using System.Text;

namespace LeetCodeProblems.FirstAttempts
{
    public class AddTwoUnoptimized
    {

        // I kinda feel like I cheesed the system using biginteger here,
        // but there were no constraints about not using it, and
        // I feel it's the most readable and maintainable solution, so here it is....
        // Time Complexity: O(n+m), Space Complexity: O(n+m), where n and m are the lengths of each of the two linked lists.
        public ListNode AddTwoNumbersSlow(ListNode l1, ListNode l2)
        {
            BigInteger first = Convert(l1);
            BigInteger second = Convert(l2);

            BigInteger sum = first + second;
            return Convert(sum);
        }

        private ListNode Convert(BigInteger number)
        {
            var digits = number.ToString().ToCharArray();
            Stack<char> stack = new Stack<char>(digits);
            ListNode first = new ListNode();
            Recurse(stack, first);
            return first;
        }

        private void Recurse(Stack<char> digits, ListNode current)
        {
            if (digits.Count == 0) return;
            
            char popped = digits.Pop();
            current.val = int.Parse(popped.ToString());
            

            if (digits.Count > 0)
            {
                current.next = new ListNode();
                Recurse(digits, current.next);
            }
                
        }

        private BigInteger Convert(ListNode listNode)
        {
            var current = listNode;
            StringBuilder holdsTheNumber = new StringBuilder();
            while (current?.val != null)
            {
                holdsTheNumber.Insert(0, current.val);
                current = current.next;
            }
            return BigInteger.Parse(holdsTheNumber.ToString());
        }



        // this is the optimized version
        // time complexity: O(m) where m is the length of the longer list.
        // space complexity: O(m) where m is the length of the longer list.
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            return GetNext(l1, l2, 0)!;
        }

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
            else if (carry > 0) result.next = new ListNode(carry);
            return result;
        }

    }
}
