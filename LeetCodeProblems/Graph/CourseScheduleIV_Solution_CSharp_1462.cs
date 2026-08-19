using LeetCodeProblems.Interfaces.Medium;

namespace LeetCodeProblems.CSharp.Graph
{
    public class CourseScheduleIV_Solution_CSharp_1462 : ICourseScheduleIV_1462
    {

        public IList<bool> CheckIfPrerequisite(int numCourses, int[][] prerequisites, int[][] queries)
        {
            var response = new List<bool>();
            List<HashSet<int>> directDependencies = new List<HashSet<int>>();
            for (int i = 0; i < numCourses; i++)
                directDependencies.Add(new HashSet<int>());

            HydrateDirectDependencies(directDependencies, prerequisites, numCourses);

            HashSet<int> visited = new();
            List<HashSet<int>> transativeDependencies = new();
            for (int i = 0; i < numCourses; i++)
                transativeDependencies.Add(new HashSet<int>());

            for (int i = 0; i < numCourses; i++)
                HydrateTransitiveDependencies(directDependencies, i, visited, transativeDependencies);

            for (int i = 0; i < queries.Length; i++)
            {
                var queryCourse = queries[i][0];
                var queryPrerequisite = queries[i][1];

                if (transativeDependencies[queryPrerequisite].Contains(queryCourse)) response.Add(true);
                else response.Add(false);
            }
            return response;
        }

        private void HydrateDirectDependencies(List<HashSet<int>> directDependencies, int[][] prerequisites, int numCourses)
        {
            foreach(var prereq in prerequisites)
                directDependencies[prereq[1]].Add(prereq[0]);
        }

        private void HydrateTransitiveDependencies(List<HashSet<int>> directDependencies, int course, HashSet<int> visited, List<HashSet<int>> transativeDependencies)
        {
            if (visited.Contains(course)) return;
            visited.Add(course);

            transativeDependencies[course].UnionWith(directDependencies[course]);
            foreach(var q in directDependencies[course])
            {
                HydrateTransitiveDependencies(directDependencies, q, visited, transativeDependencies);
                transativeDependencies[course].UnionWith(transativeDependencies[q]);
            }
        }
    }
}
