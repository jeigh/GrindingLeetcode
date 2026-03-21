namespace LeetCodeProblems.Interfaces.Medium
{
    /// <summary>
    /// LeetCode Problem 40: Combination Sum II
    ///
    /// Given a collection of candidate numbers (candidates) and a target number
    /// (target), find all unique combinations in candidates where the candidate
    /// numbers sum to target.
    ///
    /// Each number in candidates may only be used once in the combination.
    /// The solution set must not contain duplicate combinations.
    /// </summary>
    public interface ICombinationSumII_40
    {
        IList<IList<int>> CombinationSum2(int[] candidates, int target);
    }
}
