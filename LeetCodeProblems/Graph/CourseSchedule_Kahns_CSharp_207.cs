using LeetCodeProblems.Interfaces.Medium;

namespace LeetCodeProblems.CSharp.Graph
{
    public class CourseSchedule_Kahns_CSharp_207 : ICourseSchedule_207
    {
        public bool CanFinish(int numCourses, int[][] prerequisites)
        {
            int[] indegree = new int[numCourses];
            List<List<int>> adjacencies = new List<List<int>>();
            for (int i = 0; i < numCourses; i++)
                adjacencies.Add(new List<int>());

            foreach (var prereqPair in prerequisites)
            {
                var depender = prereqPair[0];
                var dependee = prereqPair[1];

                indegree[depender]++;
                adjacencies[dependee].Add(depender);
            }

            var queue = EnqueueFirstCourses(numCourses, indegree);
            int finish = 0;
            while (queue.Count > 0)
            {
                int node = queue.Dequeue();
                finish++;
                foreach(var adjacentNode in adjacencies[node])
                {
                    indegree[adjacentNode]--;
                    if (indegree[adjacentNode] == 0)
                    {
                        queue.Enqueue(adjacentNode);
                    }
                }

            }
            return finish == numCourses;
        }

        private Queue<int> EnqueueFirstCourses(int numCourses, int[] indegree)
        {
            Queue<int> queue = new Queue<int>();
            for (int i = 0; i < numCourses; i++)
                if (indegree[i] == 0)
                    queue.Enqueue(i);
            return queue;
        }
    }
}
