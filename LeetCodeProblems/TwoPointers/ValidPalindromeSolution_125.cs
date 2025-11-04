namespace LeetCodeProblems.TwoPointers
{
    public class ValidPalindromeSolution_125
    {
        // this was my first attempt.   Time Complexity: O(n), Space Complexity: O(1)

        public bool IsPalindrome(string s)
        {
            HashSet<char> validChars = new HashSet<char> ("abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789");
            int l = 0;
            int r = s.Length  - 1;
            while(l < r)
            {
                while (!validChars.Contains(s[l]) && l < r) l++;
                while (!validChars.Contains(s[r]) && r > l) r--;
                if (l > r) break;

                if (char.ToUpperInvariant(s[l]) != char.ToUpperInvariant(s[r])) return false;

                l++;
                r--;
            }
            
            return true;
        }
    }
}
