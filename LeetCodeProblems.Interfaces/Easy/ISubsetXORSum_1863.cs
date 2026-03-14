namespace LeetCodeProblems.Interfaces.Easy
{
    /// <summary>
    /// LeetCode 1863: Sum of All Subset XOR Totals
    ///
    /// The XOR total of an array is defined as the bitwise XOR of all its elements,
    /// or 0 if the array is empty.
    ///
    /// Given an array nums, return the sum of all XOR totals for every subset of nums.
    /// Note: subsets with the same elements should be counted multiple times.
    /// An array a is a subset of an array b if a can be obtained from b by deleting
    /// some (possibly zero) elements of b.
    /// </summary>
    public interface ISubsetXORSum_1863
    {
        int SubsetXORSum(int[] nums);
    }
}
