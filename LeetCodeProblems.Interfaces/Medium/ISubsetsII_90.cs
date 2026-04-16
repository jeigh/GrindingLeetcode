namespace LeetCodeProblems.Interfaces.Medium
{
    /// <summary>
    /// LeetCode Problem 90: Subsets II
    ///
    /// Given an integer array nums that may contain duplicates, return all possible
    /// subsets (the power set). The solution set must not contain duplicate subsets.
    /// Return the solution in any order.
    /// </summary>
    public interface ISubsetsII_90
    {
        IList<IList<int>> SubsetsWithDup(int[] nums);
    }
}
