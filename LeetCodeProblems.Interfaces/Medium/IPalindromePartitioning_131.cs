namespace LeetCodeProblems.Interfaces.Medium
{
    /// <summary>
    /// LeetCode Problem 131: Palindrome Partitioning
    ///
    /// Given a string s, partition s such that every substring of the partition
    /// is a palindrome. Return all possible palindrome partitionings of s.
    /// </summary>
    public interface IPalindromePartitioning_131
    {
        IList<IList<string>> Partition(string s);
    }
}
