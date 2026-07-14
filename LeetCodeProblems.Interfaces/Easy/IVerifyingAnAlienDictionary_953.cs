namespace LeetCodeProblems.Interfaces.Easy
{
    /// <summary>
    /// LeetCode Problem 953: Verifying an Alien Dictionary
    ///
    /// Given a list of words and a string order representing the order of letters
    /// in an alien language, return true if words are sorted lexicographically
    /// in this alien language.
    /// </summary>
    public interface IVerifyingAnAlienDictionary_953
    {
        bool IsAlienSorted(string[] words, string order);
    }
}
