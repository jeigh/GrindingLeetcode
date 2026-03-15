using LeetCodeProblems.HashingOrArrays;
using LeetCodeProblems.Interfaces.Medium;

namespace LeetCodeProblems.CSharp.Queue
{
    public class SingleThreadedCpu_TwoQueues_1834 : ISingleThreadedCpu_1834
    {
        public class Task
        {
            public Task(int enqueueAt, int processTime, int initialIndex)
            {
                EnqueueAt = enqueueAt;
                ProcessTime = processTime;
                InitialIndex = initialIndex;
            }

            public int EnqueueAt { get; set; }
            public int ProcessTime { get; set; }
            public int InitialIndex { get; set; }
        }
        
        public int[] GetOrder(int[][] tasks)
        {
            List<int> returnable = new();
            var enqueueQueue = new PriorityQueue<Task, int>();
            var processingQueue = new PriorityQueue<Task, (int, int)>();

            for (int i = 0; i < tasks.Length; i++)
            {
                Task newTask = new Task(tasks[i][0], tasks[i][1], i);
                enqueueQueue.Enqueue(newTask, newTask.EnqueueAt);
            }

            long time = 0;
            while (enqueueQueue.Count > 0 || processingQueue.Count > 0)
            {
                while (enqueueQueue.Count > 0 && enqueueQueue.Peek().EnqueueAt <= time)
                {
                    var dequeued = enqueueQueue.Dequeue();
                    processingQueue.Enqueue(dequeued, (dequeued.ProcessTime, dequeued.InitialIndex));
                }
                if (processingQueue.Count > 0)
                {
                    var item = processingQueue.Dequeue();
                    returnable.Add(item.InitialIndex);
                    time += item.ProcessTime;
                    continue;
                }
                time++;
            }
            return returnable.ToArray();
        }
    }
}
