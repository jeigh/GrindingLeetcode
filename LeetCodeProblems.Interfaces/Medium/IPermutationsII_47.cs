namespace LeetCodeProblems.Interfaces.Medium
{
    /// <summary>
    /// LeetCode Problem 47: Permutations II
    ///
    /// Given a collection of numbers, nums, that might contain duplicates,
    /// return all possible unique permutations in any order.
    /// </summary>
    public interface IPermutationsII_47
    {
        IList<IList<int>> Permute(int[] nums);
    }
}
