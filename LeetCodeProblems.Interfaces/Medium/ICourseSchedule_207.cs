namespace LeetCodeProblems.Interfaces.Medium
{
    /// <summary>
    /// LeetCode Problem 207: Course Schedule
    ///
    /// There are numCourses courses labeled 0 to numCourses-1.
    /// prerequisites[i] = [ai, bi] means course bi must be completed before ai.
    /// Return true if it is possible to finish all courses, false if a cycle exists.
    /// </summary>
    public interface ICourseSchedule_207
    {
        bool CanFinish(int numCourses, int[][] prerequisites);
    }
}
