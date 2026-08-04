using LeetCodeProblems.Interfaces.Medium;

namespace LeetCodeProblems.CSharp.Graph
{

    public class CourseSchedule_DFS_CSharp_207 : ICourseSchedule_207
    {
        // time complexity: O(V + E) — each course and prerequisite edge visited at most once
        // space complexity: O(V + E) — adjacency list plus visited/visiting sets
        public bool CanFinish(int numCourses, int[][] prerequisites)
        {
            var visited = new HashSet<int>();
            var visiting = new HashSet<int>();
            var adjacencies = new List<int>[numCourses];

            for(int i = 0; i < numCourses; i++) adjacencies[i] = new List<int>();

            foreach (var prereq in prerequisites)
            {
                var depender = prereq[1];
                var dependee = prereq[0];
                
                adjacencies[depender].Add(dependee);
            }

            for (int i = 0; i < numCourses; i++)
            {
                if (!recurse(visited, visiting, adjacencies, i)) return false;                
            }
            return true;
        }

        private bool recurse(HashSet<int> visited, HashSet<int> visiting, List<int>[] adjacencies, int course)
        {
            if (visited.Contains(course)) return true;
            if (visiting.Contains(course)) return false;

            visiting.Add(course);
            foreach(var adjacency in adjacencies[course])
            {
                if (!recurse(visited, visiting, adjacencies, adjacency)) return false;
            }

            visiting.Remove(course);
            visited.Add(course);
            return true;
        }
    }


}
