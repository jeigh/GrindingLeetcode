namespace LeetCodeProblems.CSharp.HashingOrArrays
{
    public class PermutationInStringHashMapSolution_567
    {
        // incremental improvement:  this has a time complexity of O(n * m), so not ideal
        public bool CheckInclusionImproved(string s1, string s2)
        {
            var s1HashMap = GenerateHashmap(s1);
            var windowSize = s1.Length;

            var l = 0;
            while (l <= s2.Length - windowSize)
            {
                if (IsPermutationOf(s2, windowSize, l, s1HashMap)) return true;

                l++;
            }
            return false;
        }

        private bool IsPermutationOf(string sourceString, int windowSize, int leftOffset, Dictionary<char, int> forThat)
        {
            var dictCopy = new Dictionary<char, int>(forThat);

            for (int i = leftOffset; i < windowSize + leftOffset; i++)
            {
                var c = sourceString[i];
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
