namespace LeetCodeProblems.Interfaces.Medium
{
    /// <summary>
    /// LeetCode Problem 46: Permutations
    ///
    /// Given an array nums of distinct integers, return all the possible
    /// permutations. You can return the answer in any order.
    /// </summary>
    public interface IPermutations_46
    {
        IList<IList<int>> Permute(int[] nums);
    }
}
