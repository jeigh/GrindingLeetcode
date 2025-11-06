namespace LeetCodeProblems.TwoPointers
{
    public class ValidPalindromeIISolution_680
    {
        // space complexity:  O(1)
        // time complexity:  O(n)
        public bool ValidPalindrome(string s)
        {
            var left = 0;
            var right = s.Length - 1;
            while (left < right)
            {
                if (s[left] == s[right])
                {
                    left++;
                    right--;
                }
                else if (IsPalindrome(s, left, right - 1)) return true;
                else if (IsPalindrome(s, left + 1, right)) return true;
                else return false;
            }
            return true;
        }

        public bool IsPalindrome(string s, int left, int right)
        {
            while (left < right)
            {
                if (s[left] == s[right])
                {
                    right--;
                    left++;
                }
                else
                {
                    return false;
                }
            }
            return true;
        }
    }
}
