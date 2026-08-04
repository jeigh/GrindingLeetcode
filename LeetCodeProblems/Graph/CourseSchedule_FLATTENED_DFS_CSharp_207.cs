using LeetCodeProblems.Interfaces.Medium;

namespace LeetCodeProblems.CSharp.Graph
{
    public class CourseSchedule_FLATTENED_DFS_CSharp_207 : ICourseSchedule_207
    {
        // time complexity: O(V + E)
        // space complexity: O(V + E)
        public bool CanFinish(int numCourses, int[][] prerequisites)
        {
            var visited = new HashSet<int>();
            var visiting = new HashSet<int>();
            var adjacencies = new List<int>[numCourses];

            for (int i = 0; i < numCourses; i++) adjacencies[i] = new List<int>();

            foreach (var prereq in prerequisites)
            {
                var depender = prereq[1];
                var dependee = prereq[0];

                adjacencies[depender].Add(dependee);
            }

            for (int i = 0; i < numCourses; i++)
            {
                if (!recurse(visited, visiting, adjacencies, i, 0)) return false;
            }
            return true;
        }

        private bool recurse(HashSet<int> visited, HashSet<int> visiting, List<int>[] listOfAdjacencyLists, int courseNumber, int adjacency)
        {
            if (adjacency == 0)
            {
                if (visited.Contains(courseNumber)) return true;
                if (visiting.Contains(courseNumber)) return false;
                visiting.Add(courseNumber);
            }

            List<int> thisCoursesAdjacencies = listOfAdjacencyLists[courseNumber];
            if (adjacency == thisCoursesAdjacencies.Count)
            {
                visiting.Remove(courseNumber);
                visited.Add(courseNumber);
                return true;
            }

            if (!recurse(visited, visiting, listOfAdjacencyLists, thisCoursesAdjacencies[adjacency], 0)) return false;

            return recurse(visited, visiting, listOfAdjacencyLists, courseNumber, adjacency + 1);
        }

    }


}
