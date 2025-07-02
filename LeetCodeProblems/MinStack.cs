namespace LeetCodeProblems
{
    public class MinStack
    {
        // I created this before I realized I could have used a second stack for _minvalue.  Oh well...
        // time complexity: O(1) for all methods
        // space complexity: O(n)

        private Stack<int> _stack;
        private List<int> _minValue;

        public MinStack()
        {
            _stack = new Stack<int>();
            _minValue = new List<int>();
        }

        public void Push(int val)
        {
            var newMinValue = 0;
            if (_minValue.Count > 0)
                newMinValue = Math.Min(val, _minValue.Last());
            else
                newMinValue = val;

                _minValue.Add(newMinValue);
            _stack.Push(val);
        }

        public void Pop()
        {
            var peeked = _stack.Peek();
            _minValue.RemoveAt(_minValue.Count - 1);
            _stack.Pop();
        }

        public int Top()
        {
            return _stack.Peek();
        }

        public int GetMin()
        {
            return _minValue.Last();
        }
    }
}
