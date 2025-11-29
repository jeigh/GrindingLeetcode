using LeetCodeProblems.Interfaces.Medium;

namespace LeetCodeProblems.CSharp.Stack
{
    public class StockSpannerCSharp_901 : IStockSpanner_901
    {
        private Stack<(int price, int span)> _stack = new Stack<(int price, int span)>();

        public int Next(int price)
        {
            if (_stack.Count == 0)
            {
                _stack.Push((price, 1));
                return 1;
            }

            var span = 1;
            while (_stack.Count > 0 && _stack.Peek().price <= price)
            {
                var popped = _stack.Pop();
                span += popped.span;
            }
            _stack.Push((price, span));
            return span;
        }
    }
}
