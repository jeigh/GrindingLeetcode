namespace LeetCodeProblems.Interfaces.Medium
{
    /// <summary>
    /// LeetCode Problem 211: Design Add and Search Words Data Structure
    ///
    /// Implement the WordDictionary class:
    ///   AddWord(word)  — adds word to the data structure
    ///   Search(word)   — returns true if any string in the structure matches word,
    ///                    where '.' matches any single letter
    /// </summary>
    public interface IDesignAddAndSearchWordDataStructure_211
    {
        void AddWord(string word);
        bool Search(string word);
    }
}
