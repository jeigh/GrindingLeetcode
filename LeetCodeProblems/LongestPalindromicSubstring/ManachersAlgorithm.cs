namespace LeetCodeProblems.LongestPalindromicSubstring
{
    public class ManachersAlgorithm : ILongestPalindrome
    {
        // I didn't come up with this solution...    but it is the fastest solution and is apparently well known enought to have its own name
        // O(n) time complexity, O(n) space complexity
        // https://en.wikipedia.org/wiki/Longest_palindromic_substring#Manacher's_algorithm


        public string LongestPalindrome(string s)
        {
            string s_prime = "#";
            foreach (char c in s)
            {
                s_prime += c;
                s_prime += "#";
            }

            int n = s_prime.Length;
            int[] palindromeRadii = new int[n];
            int center = 0;
            int radius = 0;

            for (int i = 0; i < n; i++)
            {
                int mirror = 2 * center - i;

                if (radius > i)
                    palindromeRadii[i] =
                        System.Math.Min(radius - i, palindromeRadii[mirror]);

                while (i + 1 + palindromeRadii[i] < n &&
                       i - 1 - palindromeRadii[i] >= 0 &&
                       s_prime[i + 1 + palindromeRadii[i]] ==
                           s_prime[i - 1 - palindromeRadii[i]])
                    palindromeRadii[i]++;

                if (i + palindromeRadii[i] > radius)
                {
                    center = i;
                    radius = i + palindromeRadii[i];
                }
            }

            int maxLength = 0;
            int centerIndex = 0;
            for (int i = 0; i < n; i++)
            {
                if (palindromeRadii[i] > maxLength)
                {
                    maxLength = palindromeRadii[i];
                    centerIndex = i;
                }
            }

            int startIndex = (centerIndex - maxLength) / 2;
            return s.Substring(startIndex, maxLength);
        }
    }
}
