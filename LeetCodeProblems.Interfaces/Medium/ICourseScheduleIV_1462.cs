namespace LeetCodeProblems.Interfaces.Medium
{
    /// <summary>
    /// LeetCode Problem 1462: Course Schedule IV
    ///
    /// There are numCourses courses labeled 0 to numCourses-1.
    /// prerequisites[i] = [ai, bi] means course ai must be taken before course bi
    /// (a direct prerequisite).
    /// For each query [uj, vj] in queries, determine whether uj is a prerequisite
    /// of vj — either directly, or transitively through a chain of other courses.
    /// Return a list of booleans, one per query, in the same order as queries.
    /// </summary>
    public interface ICourseScheduleIV_1462
    {
        IList<bool> CheckIfPrerequisite(int numCourses, int[][] prerequisites, int[][] queries);
    }
}
