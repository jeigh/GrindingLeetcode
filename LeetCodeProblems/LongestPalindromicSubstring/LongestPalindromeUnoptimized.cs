namespace LeetCodeProblems.LongestPalindromicSubstring
{

    public class LongestPalindromeUnoptimized : ILongestPalindrome
    {
        /// beats 19.08 on leetcode;   I like the readability of this, dispite it not being the fastest.

        public string LongestPalindrome(string s)
        {
            if (s.Length == 1) return s;
            int previousPalindromeLength = 0;
            string returnable = string.Empty;
            int left = 0;
            var continueOuterLoop = left < s.Length;
            while (continueOuterLoop)
            {
                int right = s.Length - 1;
                var continueInnerLoop = right >= left;
                while (continueInnerLoop)
                {
                    if (IsPalindrome(s, left, right))
                    {
                        var newPalindromeLength = CalculateMaxLength(left, right);
                        if (newPalindromeLength > previousPalindromeLength)
                        {
                            previousPalindromeLength = newPalindromeLength;
                            returnable = s.Substring(left, newPalindromeLength);
                        }
                    }

                    continueInnerLoop = --right >= left;
                }
                continueOuterLoop = ++left < s.Length;
            }
            return returnable;
        }

        private int CalculateMaxLength(int left, int right) =>
            right - left + 1;
        

        private bool IsPalindrome(string s, int start, int end)
        {
            while (start < end)
            {
                if (s[start] != s[end]) return false;
                start++;
                end--;
            }
            return true;
        }
    }
}
