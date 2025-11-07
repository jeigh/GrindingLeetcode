using LeetCodeProblems.Interfaces.Medium;

namespace LeetCodeProblems.SlidingWindow
{
    public class LongestRepeatingCharacterReplacementSlidingWindowSolution_424 : ILongestRepeatingCharacterReplacement_424
    {
        // i had to go review someone else's solution to come up with this
        // time complexity: O(n*m) where n is the length of s, and m is the number of unique characters.
        // space complexity: O(m) because of the hashmap
        public int CharacterReplacement(string s, int k)
        {
            var hashmap = new Dictionary<char, int>();
            int returnable = 0;
            int left = 0;
            int right = 0;
            var maximumHashmapValue = 0;
            while (right < s.Length)
            {
                char rightChar = s[right];
                char leftChar = s[left];
                AddOrIncrementToHashMap(hashmap, rightChar);

                int windowSize = right - left + 1;

                maximumHashmapValue = Math.Max(maximumHashmapValue, hashmap[rightChar]);

                while (windowSize - maximumHashmapValue > k)
                {
                    RemoveOrDecrementFromHashMap(hashmap, leftChar);

                    left++;
                    leftChar = s[left];
                    windowSize = right - left + 1;
                }

                returnable = Math.Max(returnable, windowSize);
                var currentSubstring = s.Substring(left, windowSize);
                right++;
            }

            return returnable;
        }

        private void RemoveOrDecrementFromHashMap(Dictionary<char, int> charCounts, char c)
        {
            //if (!charCounts.ContainsKey(c)) throw new ArgumentOutOfRangeException(nameof(c));
            if (charCounts.ContainsKey(c) && charCounts[c] == 1) charCounts.Remove(c);
            else if (charCounts.ContainsKey(c)) charCounts[c]--;
        }

        private void AddOrIncrementToHashMap(Dictionary<char, int> charCounts, char c)
        {
            if (charCounts.ContainsKey(c)) charCounts[c]++;
            else charCounts.Add(c, 1);

        }
    }
}
