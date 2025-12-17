using LeetCodeProblems.Interfaces.Medium;

namespace LeetCodeProblems.CSharp.LinkedList
{
    public class DoubleListNode : IDoubleListNode
    {
        public DoubleListNode Next { get; private set; }

        public DoubleListNode Prev { get; private set; }
        public int Value { get; set; }

        public void SetNext(DoubleListNode? nextNode)
        {
            this.Next = nextNode;
            if (nextNode != null) nextNode.Prev = this;
        }
        public void SetPrev(DoubleListNode? prevNode)
        {
            this.Prev = prevNode;
            if (prevNode != null) prevNode.Next = this;
        }
    }

    public class MyCircularQueueCSharp_WithoutDummyNodes_622 : IMyCircularQueue_622
    {
        public DoubleListNode? _leftMostNode;
        public DoubleListNode? _rightMostNode;
        public int _count = 0;
        public int _k = 0;

        public MyCircularQueueCSharp_WithoutDummyNodes_622(int k)
        {
            _k = k;
        }

        public bool DeQueue()
        {
            if (IsEmpty()) return false;
            if (_count == 1)
            {
                _leftMostNode = null;
                _rightMostNode = null;

                _count = 0;
                return true;
            }

            _leftMostNode = _leftMostNode.Next;
            _leftMostNode.SetPrev(null);
            
            _count--;
            return true;
        }

        public bool EnQueue(int value)
        {
            if (IsFull()) return false;
            var newNode = new DoubleListNode();
            newNode.Value = value;

            if (_count == 0)
            {
                _leftMostNode = newNode;
                _rightMostNode = newNode;
                
                _count++;
                return true;
            }

            _rightMostNode.SetNext(newNode);
            _rightMostNode = newNode;
            _count++;
            return true;
        }

        public int Front()
        {
            if ( _leftMostNode != null) return _leftMostNode.Value;
            return -1;
        }

        public bool IsEmpty() => _count == 0;

        public bool IsFull() => _count == _k;

        public int Rear()
        {
            if (_rightMostNode == null) return -1;
            return _rightMostNode.Value;
        }
    }
}
