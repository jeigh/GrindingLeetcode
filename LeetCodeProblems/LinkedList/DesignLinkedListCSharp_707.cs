using LeetCodeProblems.Interfaces.Medium;
using LeetCodeProblems.Shared;

namespace LeetCodeProblems.CSharp.LinkedList
{
    public class DesignLinkedListCSharp_707 : IDesignLinkedList_707
    {
        private int _count = 0;
        private ListNode? _head = null;
        private ListNode? _tail = null;

        private ListNode? TraverseTo(int index)
        {
            var current = _head;
            while (current != null && index > 0)
            {
                current = current.next;
                index--;
            }

            return current;

        }

        public void AddAtHead(int val)
        {
            _head = new ListNode(val, _head);
            if (_tail == null) _tail = _head;
            _count++;
        }

        public void AddAtIndex(int index, int val)
        {
            if (index < 0) return;
            if (_count == index) 
            { 
                AddAtTail(val); 
                return; 
            }
            if (index == 0) 
            { 
                AddAtHead(val); 
                return;  
            }
            if (_count >= index)
            {
                var prev = TraverseTo(index - 1);
                var temp = prev.next;
                prev.next = new ListNode(val, temp);
                _count++;
            }
        }

        public void AddAtTail(int val)
        {
            if (_tail == null) 
            { 
                _tail = new ListNode(val);
                _head = _tail;
                _count++;
                return;
            }

            if (_tail != null)
            {
                _tail.next = new ListNode(val);
                _tail = _tail.next;
                _count++;
                return;
            }
        }

        public void DeleteAtIndex(int index)
        {
            if (index < 0) return;
            if (index == 0)
            {
                _head = _head?.next;

                if (_head == null) _tail = null;

                _count--;
                return;
            }

            if (_count > index && _head != null)
            {
                var prev = TraverseTo(index - 1);
                
                if (prev.next == _tail)
                {
                    _tail = prev;
                    prev.next = null;
                }
                else
                    prev.next = prev?.next?.next;

                _count--;
                return;
            }

            if (index == _count - 1)
            {
                var penultimate = TraverseTo(index - 1);
                penultimate.next = null;
                _tail = penultimate;
                _count--;
            }
        }

        public int Get(int index)
        {
            if (index < 0) return -1;
            var target = TraverseTo(index);
            if (target == null) return -1;
            return target.val;
        }
    }
}
