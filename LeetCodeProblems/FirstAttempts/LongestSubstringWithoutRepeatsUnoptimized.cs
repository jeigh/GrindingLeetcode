using LeetCodeProblems.Shared;
using System.Text;

namespace LeetCodeProblems.FirstAttempts
{
    public class LongestSubstringWithoutRepeatsUnoptimized : ILongestSubstringWithoutRepeats
    {
        public int LengthOfLongestSubstring(string s)
        {
            string longestSubstring = string.Empty;
            StringBuilder currentString = new StringBuilder(string.Empty);

            char c  = '\0';
            int offset = 0;

            while (s.Length > 0)
            {
                c = s[offset];

                if (!currentString.ToString().Contains(c))
                {
                    currentString.Append(c);

                    if (currentString.Length > longestSubstring.Length)
                        longestSubstring = currentString.ToString();

                    if (offset == s.Length - 1) break;
                    offset += 1;
                }
                else 
                {
                    currentString = new StringBuilder(string.Empty);
                    offset = 0;

                    s = s.Substring(1);
                }
            }
            return longestSubstring.Length;
        }
    }
}