using LeetCodeProblems.Interfaces.Medium;
using System.Runtime.InteropServices;

namespace LeetCodeProblems.CSharp.Failed
{
    public class PermutationInStringFailedSolution_567 : IPermutationInString_567
    {
        // this has a time complexity of O(n * m²), so not ideal
        public bool CheckInclusion(string s1, string s2)
        {
            var s1HashMap = GenerateHashmap(s1);
            var windowSize = s1.Length;

            var l = 0;
            while (l <= s2.Length - windowSize)
            {
                string substring = s2.Substring(l, windowSize);

                if (IsPermutationOf(substring, s1HashMap)) return true;

                l++;
            }
            return false;
        }

        private bool IsPermutationOf(string checkThis, Dictionary<char, int> forThat)
        {
            var dictCopy = new Dictionary<char, int>(forThat);

            foreach (char c in checkThis)
            {
                if (!dictCopy.ContainsKey(c) || dictCopy[c] == 0) return false;
                dictCopy[c]--;
            }

            foreach (var count in dictCopy.Values)
            {
                if (count != 0) return false;
            }

            return true;
        }

        private Dictionary<char, int> GenerateHashmap(string s1)
        {
            var s2HashMap = new Dictionary<char, int>();
            foreach (char c in s1)
            {
                if (s2HashMap.ContainsKey(c)) s2HashMap[c] += 1;
                else s2HashMap[c] = 1;
            }
            return s2HashMap;
        }


    }
}
