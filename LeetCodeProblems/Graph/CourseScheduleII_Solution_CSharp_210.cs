using LeetCodeProblems.Interfaces.Medium;

namespace LeetCodeProblems.CSharp.Graph
{
    public class CourseScheduleII_Solution_CSharp_210 : ICourseScheduleII_210
    {
        public int[] FindOrder(int numCourses, int[][] prerequisites)
        {
            List<int> visiting = new List<int>();
            List<int> visited = new List<int>();
            List<IList<int>> prerequisitesById = new List<IList<int>>();
            for (int i = 0; i < numCourses; i++)
                prerequisitesById.Add(new List<int>());
                

            foreach (var item in prerequisites)
            {
                var course = item[0];
                var prerequisiteCourse = item[1];

                prerequisitesById[course].Add(prerequisiteCourse);
            }

            for (int i = 0; i < numCourses; i++)
            {
                if (!recurse(visited, visiting, prerequisitesById, i)) return Array.Empty<int>();
            }

            return visited.ToArray<int>();
        }

        private bool recurse(List<int> visited, List<int> visiting, List<IList<int>> prerequisitesById, int course)
        {
            if (visited.Contains(course)) return true;
            if (visiting.Contains(course)) return false;

            visiting.Add(course);
            foreach (var item in prerequisitesById[course])
            {
                if (!recurse(visited, visiting, prerequisitesById, item)) return false;
            }
            visiting.Remove(course);
            visited.Add(course);

            return true;
        }
    }
}
