using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;
using System.Security.AccessControl;

namespace LeetCodeProblems
{
    // this is the brute force solution that I came up with after understanding the problem
    // i'm pretty sure this does what's expected, but runs too slowly when ran on large inputs.
    // time complexity: O(n^3) (because of the triple-nested loops),  space complexity: O(n)
    public class LongestRepeatingCharacterReplacementSolution
    {
        public int CharacterReplacementBruteForce(string s, int k)
        {
            int returnable = 0;
            int left = 0;
            int right = 0;

            while(right < s.Length)
            {
                while (right < s.Length)
                {
                    var hashmap = new Dictionary<char, int>();
                    var currentSubstring = s.Substring(left, right - left + 1);
                    foreach (char c in currentSubstring)
                    {
                        AddOrIncrementToHashMap(hashmap, c);
                    }
                    
                    if (hashmap.Count <= k+1) 
                    {
                        char mostFrequentChar = (from KeyValuePair<char, int> kvp in hashmap orderby kvp.Value descending select kvp.Key).First();
                        var currentSwapCount = 0;

                        foreach(char c in currentSubstring.ToCharArray())
                        {
                            if (c != mostFrequentChar) currentSwapCount++;
                        }

                        if (currentSwapCount <= k)
                            returnable = Math.Max(returnable, currentSubstring.Length);

                    }

                    right++;
                }

                left++;
                right = left;
            }
            return returnable;
        }

        private void AddOrIncrementToHashMap(Dictionary<char, int> charCounts, char c)
        {
            if (charCounts.ContainsKey(c)) charCounts[c]++;
            else charCounts.Add(c, 1);

        }

        private void RemoveOrDecrementFromHashMap(Dictionary<char, int> charCounts, char c)
        {
            //if (!charCounts.ContainsKey(c)) throw new ArgumentOutOfRangeException(nameof(c));
            if (charCounts.ContainsKey(c) && charCounts[c] == 1) charCounts.Remove(c);
            else if (charCounts.ContainsKey(c)) charCounts[c]--;
        }



        // i had to go review someone else's solution to come up with this
        // time complexity: O(n*m) where n is the length of s, and m is the number of unique characters.
        // space complexity: O(m) because of the hashmap
        public int CharacterReplacementSlidingWindow(string s, int k)
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
    }
}
