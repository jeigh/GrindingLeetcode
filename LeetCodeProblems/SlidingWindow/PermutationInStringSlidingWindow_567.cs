using LeetCodeProblems.Interfaces.Medium;

namespace LeetCodeProblems.CSharp.SlidingWindow
{
    public class PermutationInStringSlidingWindow_567 : IPermutationInString_567
    {
        private Dictionary<char, int> CreateHashmapFromAlphabet()
        {
            var allowableCharacters = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
            var hashmap = new Dictionary<char, int>();
            foreach (char c in allowableCharacters)
            {
                hashmap[c] = 0;
            }
            return hashmap;
        }

        private void PopulateHashmapFromString(string s, Dictionary<char, int> hashmap)
        {
            foreach (char c in s)
            {
                hashmap[c]++;
            }            
        }

        bool DictionariesAreEqual(Dictionary<char, int> dict1, Dictionary<char, int> dict2)
        {
            if (dict1.Count != dict2.Count)
                return false;

            foreach (var kvp in dict1)
            {
                if (!dict2.TryGetValue(kvp.Key, out int value))
                    return false;

                if (value != kvp.Value)
                    return false;
            }
            return true;
        }

        // this was my hand written solution after having read an explaination of how it should run.  
        // surprisinly, leetcode says it performs better than most other submissions
        // time complexity: O(n) space complexity:  O(1)

        public bool CheckInclusion(string s1, string s2)
        {
            if (s1.Length > s2.Length) return false;

            var windowSize = s1.Length;
            var left = 0;
            var right = left + windowSize;

            var s1Counts = CreateHashmapFromAlphabet();
            var s2Counts = CreateHashmapFromAlphabet();

            PopulateHashmapFromString(s1, s1Counts);
            
            var currentWindow = s2.Substring(left, windowSize);
            PopulateHashmapFromString(currentWindow, s2Counts);

            while (right < s2.Length + 1)
            {
                if (DictionariesAreEqual(s1Counts, s2Counts)) return true;

                if (left + windowSize == s2.Length) break;

                right++;
                left++;
                
                var charLeavingWindow = s2[left - 1];
                var charEnteringWindow = s2[right - 1];

                s2Counts[charLeavingWindow]--;
                s2Counts[charEnteringWindow]++;
            }
            return false;
        }


    }
}

