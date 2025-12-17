using LeetCodeProblems.Interfaces.Medium;

namespace LeetCodeProblems.CSharp.LinkedList
{
    public class DoubleListNodeWithKey
    {
        public int Key { get; set; }

        public DoubleListNodeWithKey Next { get; set; }

        public DoubleListNodeWithKey Prev { get; set; }

        public int Value { get; set; }

        public DoubleListNodeWithKey(int key)
        {
            Key = key;
        }
    }

    public class LRUCache_CSharp_146 : ILRUCache_146
    {
        // right = newest
        // left = oldest

        private DoubleListNodeWithKey _leftDummy = null;
        private DoubleListNodeWithKey _rightDummy = null;
        private Dictionary<int, DoubleListNodeWithKey> _hashMap = new();
        private int _maxCapacity = 0;

        public LRUCache_CSharp_146(int capacity) 
        {
            _leftDummy = new DoubleListNodeWithKey(-1);
            _rightDummy = new DoubleListNodeWithKey(-1);

            _leftDummy.Next = _rightDummy;
            _rightDummy.Prev = _leftDummy;

            _maxCapacity = capacity;
        }

        public int Get(int key)
        {
            if (!_hashMap.ContainsKey(key)) return -1;
            var hit = _hashMap[key];
            MoveToFront(hit);
            return hit.Value;
        }

        private void MoveToFront(DoubleListNodeWithKey? listNode)
        {
            if (listNode == null) return;
            if (listNode.Next == _rightDummy) return; 

            var originalPrev = listNode?.Prev;
            var originalNext = listNode?.Next;

            var newPrev = _rightDummy.Prev;
            var newNext = _rightDummy;

            if (originalPrev != null) originalPrev.Next = originalNext;
            if (originalNext != null) originalNext.Prev = originalPrev;

            if (newPrev != null) newPrev.Next = listNode;
            listNode.Prev = newPrev;

            if (newNext != null) newNext.Prev = listNode;
            listNode.Next = newNext;
        }

        private void RemoveOldest()
        {
            var oldest = _leftDummy.Next;
            var secondOldest = _leftDummy.Next?.Next;

            oldest.Next = null;
            oldest.Prev = null;

            _leftDummy.Next = secondOldest;
            if (secondOldest != null) secondOldest.Prev = _leftDummy;

            _hashMap.Remove(oldest.Key);
        }

        public void Put(int key, int value)
        {
            if (_hashMap.TryGetValue(key, out DoubleListNodeWithKey? temp))
            {
                temp.Value = value;
                MoveToFront(temp);
                return;
            }

            DoubleListNodeWithKey newNode = new DoubleListNodeWithKey(key);
            newNode.Value = value;

            MoveToFront(newNode);

            _hashMap.Add(key, newNode);
            if (_hashMap.Count > _maxCapacity)
                RemoveOldest();
        }
    }
}
