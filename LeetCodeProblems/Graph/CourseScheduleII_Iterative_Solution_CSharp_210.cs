using LeetCodeProblems.Interfaces.Medium;

namespace LeetCodeProblems.CSharp.Graph
{
    public class CourseScheduleII_Iterative_Solution_CSharp_210 : ICourseScheduleII_210
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

            var stack = new Stack<(int, int)>();

            for (int i = 0; i < numCourses; i++)
                stack.Push((i, 0));

            while (stack.Count > 0)
            {
                (int courseNumber, int adjacencyOffset) = stack.Pop();
                

                if (adjacencyOffset == 0)
                {
                    if (visited.Contains(courseNumber)) continue;
                    if (visiting.Contains(courseNumber)) return Array.Empty<int>();
                    visiting.Add(courseNumber);
                }

                if (adjacencyOffset == prerequisitesById[courseNumber].Count)
                {
                    visiting.Remove(courseNumber);
                    visited.Add(courseNumber);
                    continue;
                }

                stack.Push((courseNumber, adjacencyOffset + 1));               
                stack.Push((prerequisitesById[courseNumber][adjacencyOffset], 0));
            }

            return visited.ToArray<int>();

        }
    }
}
