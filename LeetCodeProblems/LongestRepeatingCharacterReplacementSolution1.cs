namespace LeetCodeProblems
{
    public class PermutationInStringSolution
    {
        // this has a time complexity of O(n * m²), so not ideal
        public bool CheckInclusionFirstAttempt(string s1, string s2)
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

        // this is the optimized solution o(n) time complexity and O(1) space complexity
        public bool CheckInclusionSlidingWindow(string s1, string s2)
        {
            if (s1.Length > s2.Length) return false;

            int[] s1Count = new int[26];
            int[] s2Count = new int[26];

            for (int i = 0; i < s1.Length; i++)
            {
                s1Count[s1[i] - 'a']++;
                s2Count[s2[i] - 'a']++;
            }

            int matches = 0;
            for (int i = 0; i < 26; i++)
            {
                if (s1Count[i] == s2Count[i]) matches++;
            }

            int windowStart = 0;
            for (int windowEnd = s1.Length; windowEnd < s2.Length; windowEnd++)
            {
                if (matches == 26) return true;

                int index = s2[windowEnd] - 'a';
                s2Count[index]++;

                if (s1Count[index] == s2Count[index]) matches++;
                else if (s1Count[index] + 1 == s2Count[index]) matches--;                

                index = s2[windowStart] - 'a';
                s2Count[index]--;
                
                if (s1Count[index] == s2Count[index]) matches++;
                else if (s1Count[index] - 1 == s2Count[index]) matches--;
                
                windowStart++;
            }

            return matches == 26;
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
