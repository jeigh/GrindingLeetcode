using LeetCodeProblems.Interfaces.Easy;
using System.Collections;

namespace LeetCodeProblems
{
    public class ImplementStackUsingQueues_225 : IImplementStackUsingQueues_225
    {
        private PriorityQueue<int, int> myQueue = new();

        public ImplementStackUsingQueues_225()
        {
        }

        public bool Empty()
        {
            return myQueue.Count == 0;
        }

        public int Pop()
        {
            return myQueue.Dequeue();
        }

        public void Push(int x)
        {
            myQueue.Enqueue(x, -myQueue.Count);
        }

        public int Top()
        {
            return myQueue.Peek();
        }
    }
}
