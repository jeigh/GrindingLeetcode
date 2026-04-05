namespace LeetCodeProblems.Interfaces.Medium
{
    /// <summary>
    /// LeetCode Problem 77: Combinations
    ///
    /// Given two integers n and k, return all possible combinations of k numbers
    /// chosen from the range [1, n].
    ///
    /// You may return the answer in any order.
    /// </summary>
    public interface ICombinations_77
    {
        IList<IList<int>> Combine(int n, int k);
    }
}
