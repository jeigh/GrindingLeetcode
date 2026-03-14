namespace LeetCodeProblems.Interfaces.Medium
{
    /// <summary>
    /// LeetCode 78: Subsets
    ///
    /// Given an integer array nums of unique elements, return all possible subsets
    /// (the power set). The solution set must not contain duplicate subsets.
    /// Return the solution in any order.
    /// </summary>
    public interface ISubsets_78
    {
        IList<IList<int>> Subsets(int[] nums);
    }
}
