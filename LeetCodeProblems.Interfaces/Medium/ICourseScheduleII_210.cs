namespace LeetCodeProblems.Interfaces.Medium
{
    /// <summary>
    /// LeetCode Problem 210: Course Schedule II
    ///
    /// There are numCourses courses labeled 0 to numCourses-1.
    /// prerequisites[i] = [ai, bi] means bi must be completed before ai.
    /// Return any valid ordering of courses that allows you to finish all of them.
    /// If it is impossible to finish all courses, return an empty array.
    /// </summary>
    public interface ICourseScheduleII_210
    {
        int[] FindOrder(int numCourses, int[][] prerequisites);
    }
}
