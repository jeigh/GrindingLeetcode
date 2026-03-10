using LeetCodeProblems.Interfaces.Medium;

namespace LeetCodeProblems.CSharp.Queue
{
    public class TaskScheduler_TwoQueues_CSharp_621 : ITaskScheduler_621
    {
        public int LeastInterval(char[] tasks, int n)
        {
            var counts = new Dictionary<char, int>();
            for (char c = 'A'; c <= 'Z'; c++) counts[c] = 0;
            foreach (var task in tasks) counts[task]++;
            

            var maxHeap = new PriorityQueue<int, int>();
            for (char c = 'A'; c <= 'Z'; c++)
            {
                if (counts[c] > 0) maxHeap.Enqueue(counts[c], -counts[c]);
            }

            int time = 0;
            var queue = new Queue<(int count, int nextAvailableTime)>();
            while (maxHeap.Count > 0 || queue.Count > 0)
            {
                if (queue.Count > 0 && time >= queue.Peek().nextAvailableTime)
                {
                    var temp = queue.Dequeue();
                    maxHeap.Enqueue(temp.count, -temp.count);
                }
                if (maxHeap.Count > 0)
                {
                    int newCount = maxHeap.Dequeue() - 1;
                    if (newCount > 0) queue.Enqueue((newCount, time + n + 1));
                }
                time++;
            }
            return time;
        }
    }
}
