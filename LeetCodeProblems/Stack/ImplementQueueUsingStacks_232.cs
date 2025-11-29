using LeetCodeProblems.Interfaces.Easy;

namespace LeetCodeProblems
{
    public class ImplementQueueUsingStacks_232 : IImplementQueueUsingStacks_232
    {
        public Stack<int> stack = new();
        public Stack<int> stack2 = new();  

        public bool Empty()
        {
            return stack.Count == 0;
        }

        public int Peek()
        {
            while (stack.Count > 1)
            {
                stack2.Push(stack.Pop());
            }
            var returnable = stack.Peek();
            while (stack2.Count > 0)
            {
                stack.Push(stack2.Pop());
            }
            return returnable;
        }

        public int Pop()
        {
            while (stack.Count > 1)
            {
                stack2.Push(stack.Pop());
            }
            var returnable = stack.Pop();
            while (stack2.Count > 0)
            {
                stack.Push(stack2.Pop());
            }
            return returnable;

        }

        public void Push(int x)
        {
            stack.Push(x);
        }
    }
}
