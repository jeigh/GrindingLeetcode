using LeetCodeProblems.Interfaces.Medium;
using LeetCodeProblems.Shared;

namespace LeetCodeProblems.CSharp.LinkedList
{
    public class CopyListWithRandomPointerCSharp_138 : ICopyListWithRandomPointer_138
    {
        public Node CopyRandomList(Node head)
        {
            if (head == null) return null;

            var hashMap = new Dictionary<Node, Node>();
            var current = head;

            while (current != null)
            {
                var copied = new Node(current.val);
                hashMap.Add(current, copied);
                current = current.next;
            }

            current = head;
            while (current != null)
            {
                if (current.next != null) hashMap[current].next = hashMap[current.next];
                if (current.random != null) hashMap[current].random = hashMap[current.random];
                current = current.next;
            }

            return hashMap[head];

        }
    }
}
