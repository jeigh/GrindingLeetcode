using LeetCodeProblems.Shared;
using System.Text;

namespace LeetCodeProblems
{
    public class LongestSubstringWithoutRepeats
    {
        // this was my first attempt
        // time complexity: O(n^3), space complexity: O(n)
        public int LengthOfLongestSubstringBruteForce(string s)
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

        // I came up with this after reading a description of the optimal solution.
        // time complexity: O(n), space complexity O(m), where n is the length of s, and m is the maximum number of characters in the hashset.
        public int LengthOfLongestSubstringSlidingWindow(string s)
        {
            if (string.IsNullOrEmpty(s)) return 0;

            int maxLength = 0;
            int left = 0;

            var charSet = new HashSet<int>();

            for (int right = left + 1; right < s.Length; right++)
            {

                while (charSet.Contains(s[right]))
                {
                    left++;
                    charSet.Remove(s[right]);
                }

                charSet.Add(s[right]);
                var currentLength = right - left;
                maxLength = Math.Max(maxLength, currentLength);
            }

            return maxLength;
        }



        // this is kinda the same solution, but with a HashMap instead of a HashSet.
        // I think it's more difficult to read
        public int LengthOfLongestSubstringDictionary(string s)
        {
            if (string.IsNullOrEmpty(s)) return 0;

            int maxLength = 0;
            int start = 0;
            Dictionary<char, int> charIndexMap = new Dictionary<char, int>();

            for (int end = 0; end < s.Length; end++)
            {
                if (charIndexMap.ContainsKey(s[end]))
                    start = Math.Max(start, charIndexMap[s[end]] + 1);

                charIndexMap[s[end]] = end;
                maxLength = Math.Max(maxLength, end - start + 1);
            }

            return maxLength;
        }


    }
}