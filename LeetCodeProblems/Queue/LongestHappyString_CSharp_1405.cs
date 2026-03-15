using LeetCodeProblems.Interfaces.Medium;
using System.Text;

namespace LeetCodeProblems.CSharp.Queue
{
    public class LongestHappyString_CSharp_1405 : ILongestHappyString_1405
    {
        public string LongestDiverseString(int a, int b, int c)
        {
            var happy = new StringBuilder();
            var window = new Queue<char>();
            var queue = new PriorityQueue<char, (int negRemaining, int tickLastUsed)>();

            if (a > 0) queue.Enqueue('a', (-a, -3));
            if (b > 0) queue.Enqueue('b', (-b, -3));
            if (c > 0) queue.Enqueue('c', (-c, -3));

            int tick = 0;
            const int windowSize = 3;
            while (queue.TryDequeue(out char element, out (int negRemaining, int tickLastUsed) priority))
            {
                bool onlyContainsElement = OnlyContainsElement(window, element);
                if (onlyContainsElement && window.Count >= windowSize - 1)
                {
                    if (!queue.TryDequeue(out char nextElement, out (int negRemaining, int tickLastUsed) nextPriority)) break;
                    queue.Enqueue(element, priority);
                    element = nextElement;
                    priority = nextPriority;
                }

                happy.Append(element);
                if (priority.negRemaining < -1) queue.Enqueue(element, (priority.negRemaining + 1, tick));
                window.Enqueue(element);
                if (window.Count == windowSize) window.Dequeue();
                tick++;
            }

            return happy.ToString();
        }

        private static bool OnlyContainsElement(Queue<char> window, char element)
        {
            bool onlyContainsElement = true;
            foreach (var item in window)
            {
                if (item != element)
                {
                    onlyContainsElement = false;
                    break;
                }
            }

            return onlyContainsElement;
        }
    }
}
