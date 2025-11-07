using LeetCodeProblems.Interfaces.Medium;

namespace LeetCodeProblems.SlidingWindow
{
    public class LongestSubstringWithoutRepeatsSlidingWindowSolution_3 : ILongestSubstringWithoutRepeatingCharacters_3
    {
        // I came up with this after reading a description of the optimal solution.
        // time complexity: O(n), space complexity O(m), where n is the length of s, and m is the maximum number of characters in the hashset.
        public int LengthOfLongestSubstring(string s)
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

    }
}