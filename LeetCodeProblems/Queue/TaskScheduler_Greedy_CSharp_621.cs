using LeetCodeProblems.Interfaces.Medium;

namespace LeetCodeProblems.CSharp.Queue
{

    public class TaskScheduler_Greedy_CSharp_621 : ITaskScheduler_621
    {
        public int LeastInterval(char[] tasks, int n)
        {
            int[] taskFrequencies = new int[26];
            foreach (char task in tasks)
            {
                taskFrequencies[task - 'A']++;
            }

            Array.Sort(taskFrequencies);
            int maxFrequency = taskFrequencies[25];
            int idle = (maxFrequency - 1) * n;

            for (int i = 24; i >= 0; i--)
            {
                idle -= Math.Min(maxFrequency - 1, taskFrequencies[i]);
            }
            return Math.Max(0, idle) + tasks.Length;
        }
    }
}
