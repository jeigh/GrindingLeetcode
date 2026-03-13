namespace LeetCodeProblems.Interfaces.Medium
{
    /// <summary>
    /// LeetCode 1405: Longest Happy String
    ///
    /// A string s is called happy if it satisfies all the following conditions:
    ///   - s only contains the letters 'a', 'b', and 'c'.
    ///   - s does not contain "aaa", "bbb", or "ccc" as a substring.
    ///   - s contains at most a copies of the letter 'a'.
    ///   - s contains at most b copies of the letter 'b'.
    ///   - s contains at most c copies of the letter 'c'.
    ///
    /// Given three integers a, b, and c, return the longest possible happy string.
    /// If there are multiple longest happy strings, return any of them.
    /// If there is no such string, return the empty string "".
    /// </summary>
    public interface ILongestHappyString_1405
    {
        string LongestDiverseString(int a, int b, int c);
    }
}
