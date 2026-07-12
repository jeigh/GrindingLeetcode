namespace LeetCodeProblems.Interfaces.Medium
{
    /// <summary>
    /// LeetCode Problem 208: Implement Trie (Prefix Tree)
    ///
    /// Implement the Trie class:
    ///   Insert(word)    — inserts word into the trie
    ///   Search(word)    — returns true if word is in the trie
    ///   StartsWith(prefix) — returns true if any word in the trie starts with prefix
    /// </summary>
    public interface IImplementTriePrefixTree_208
    {
        void Insert(string word);
        bool Search(string word);
        bool StartsWith(string prefix);
    }
}
