using LeetCodeProblems.Interfaces.Easy;

namespace LeetCodeProblems.CSharp.SlidingWindow
{
    public class SubstringsOfSizeThreeWithDistinctCharacters_1876 : ISubstringsOfSizeThreeWithDistinctCharacters_1876
    {
        public int CountGoodSubstrings(string s)
        {
            int goodCount = 0;
            for (int i = 0; i <= s.Length - 3; i++)
            {
                if (!HasRepeatingChars(s, i)) goodCount++;
            }
            return goodCount;
        }

        public bool HasRepeatingChars(string s, int start)
        {
            if (s[start] == s[start+1]) return true;
            if (s[start + 1] == s[start + 2]) return true;
            if (s[start] == s[start + 2]) return true;

            return false;
        }
    }
}
