using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace LeetCodeProblems.HashingOrArrays
{
    public class GroupAnagramsSolution_OOP_49
    {
        public class anagram_dna
        {
            private Dictionary<char, int> counts = new Dictionary<char, int>();

            public anagram_dna(string str)
            {
                foreach(char c in str)
                {
                    if (counts.TryGetValue(c, out int value)) counts[c]++;
                    else counts.Add(c, 1);
                }
            }

            public override int GetHashCode()
            {
                int hash = 17;
                foreach (var kvp in counts.OrderBy(kvp => kvp.Key))
                {
                    hash = hash * 31 + kvp.Key.GetHashCode();
                    hash = hash * 31 + kvp.Value.GetHashCode();
                }
                return hash;
            }

            public override bool Equals(object obj)
            {
                if (obj is not anagram_dna other) return false;
                if (counts.Count != other.counts.Count) return false;
                foreach (var kvp in counts)
                {
                    if (!other.counts.TryGetValue(kvp.Key, out int val) || val != kvp.Value)
                        return false;
                }
                return true;
            }
        }

        public IList<IList<string>> GroupAnagrams(string[] strs)
        {
            var dictionary_of_anagrams = new Dictionary<anagram_dna, IList<string>>();

            foreach (var str in strs)
            {
                var anagramdna = new anagram_dna(str);
                if (dictionary_of_anagrams.ContainsKey(anagramdna)) dictionary_of_anagrams[anagramdna].Add(str);
                else dictionary_of_anagrams.Add(anagramdna, new List<string>() { str });
            }

            var returnable = new List<IList<string>>();

            foreach(KeyValuePair<anagram_dna, IList<string>> item in  dictionary_of_anagrams)
            {
                returnable.Add(item.Value);
            }

            return returnable;
        }
    }
}
