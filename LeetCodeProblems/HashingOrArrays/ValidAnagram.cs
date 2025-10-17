namespace LeetCodeProblems.HashingOrArrays
{
    public class ValidAnagram_Bespoke 
    {
        // this was my first attempt and is also reasonably efficient
        // time complexity: O(n+m) where n and m are the lengths of the strings
        // space complexity: O(1) or more precisely O(k) where k is the number of unique characters in the strings)

        public bool IsAnagram(string s, string t)
        {
            var firstDictionary = ConstructDictionary(s);
            var secondDictionary = ConstructDictionary(t);

            if (DictionariesAreEqual(firstDictionary, secondDictionary)) return true;

            return false;
        }

        private Dictionary<char, int> ConstructDictionary(string t)
        {
            var returnable = new Dictionary<char, int>();
            foreach (char c in t)
            {
                if (returnable.ContainsKey(c)) returnable[c]++;
                else returnable[c] = 1;
            }

            return returnable;
        }

        private bool DictionariesAreEqual(Dictionary<char, int> dict1, Dictionary<char, int> dict2)
        {
            if (dict1.Count != dict2.Count) return false;
            foreach (var kvp in dict1)
            {
                if (!dict2.TryGetValue(kvp.Key, out int value)) return false;
                if (kvp.Value != value) return false;
            }

            return true;
        }
    }
}
