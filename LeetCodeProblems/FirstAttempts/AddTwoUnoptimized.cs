using LeetCodeProblems.Shared;
using System.Numerics;
using System.Text;

namespace LeetCodeProblems.FirstAttempts
{
    public class AddTwoUnoptimized : IAddTwo
    {
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
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
    }
}
