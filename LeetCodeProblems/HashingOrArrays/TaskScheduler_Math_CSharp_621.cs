using LeetCodeProblems.HashingOrArrays;
using LeetCodeProblems.Interfaces.Medium;

namespace LeetCodeProblems.Hashing
{

    public class TaskScheduler_Math_CSharp_621 : ITaskScheduler_621
    {
        public int LeastInterval(char[] tasks, int n)
        {
            var hashMap = new Dictionary<char, int>(26);
            foreach (var task in tasks)
            {
                if (hashMap.TryGetValue(task, out int value)) hashMap[task] = ++value;
                else hashMap[task] = 1;
            }

            var queue = new PriorityQueue<char, int>(hashMap.Count);
            KeyValuePair<char, int>? max;
            foreach (KeyValuePair<char, int> kvp in hashMap)
            {
                queue.Enqueue(kvp.Key, -kvp.Value);
            }

            queue.TryDequeue(out char mostFrequentTask, out int negativePriority);
            int countOfMostFrequentTask = -negativePriority;

            int tasksWithMaxFrequency = 1;
            while (queue.TryDequeue(out char element, out int priority))
            {
                if (-priority == countOfMostFrequentTask)
                    tasksWithMaxFrequency++;
                else
                    break; 
            }

            int minIntervals = (countOfMostFrequentTask - 1) * (n + 1) + tasksWithMaxFrequency;

            return Math.Max(minIntervals, tasks.Length);
        }
    }
}
