using LeetCodeProblems.HashingOrArrays;
using LeetCodeProblems.Interfaces.Medium;

namespace LeetCodeProblems.CSharp.Backtracking
{
    public class PalindromePartitioning_Backtracking_CSharp_131 : IPalindromePartitioning_131
    {
        public IList<IList<string>> Partition(string s)
        {
            var current = new List<string>();
            var result = new List<IList<string>>();

            recurse(s, 0, current, result);

            return result;
        }

        private void recurse(string s, int startIndex, List<string> current, List<IList<string>> result)
        {
            if (startIndex == s.Length)
            {
                result.Add(current.ToList());
                return;
            }

            for(int endIndex = startIndex; endIndex < s.Length; endIndex++)
            {
                if (isPalindrome(s, startIndex, endIndex))
                {
                    var substr = s.Substring(startIndex, endIndex - startIndex + 1);

                    current.Add(substr);
                    recurse(s, endIndex + 1, current, result);
                    current.RemoveAt(current.Count - 1);
                }
            }            
        }

        private bool isPalindrome(string s, int left, int right)
        {
            if (left >= right) return true;
            if (s[left] == s[right]) return isPalindrome(s, left + 1, right - 1);
            return false;
        }
    }
}
