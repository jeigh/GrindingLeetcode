using LeetCodeProblems.Interfaces.Easy;

namespace LeetCodeProblems.CSharp.Graph
{
    public class VerifyingAnAlienDictionary_CSharp_953 : IVerifyingAnAlienDictionary_953
    {


        public bool IsAlienSorted(string[] words, string order)
        {
            var hashMap = CreateHashmapFromString(order);

            string previousWord = null;
            foreach (var word in words)
            {                    
                if (previousWord != null)
                {
                    if (!firstIsBeforeLast(previousWord, word, hashMap)) return false;
                }

                previousWord = word;
            }
            return true;
        }

        private bool firstIsBeforeLast(string first, string last, Dictionary<char, int> hashMap)
        {
            if (first.Length == 0 && last.Length != 0) return false;

            for (var i = 0; i < first.Length; i++)
            {
                if (i >= last.Length) return false;
                if (hashMap[first[i]] > hashMap[last[i]]) return false;
                if (hashMap[first[i]] < hashMap[last[i]]) return true;
            }
            return true;
        }

        private Dictionary<char, int> CreateHashmapFromString(string order)
        {
            var hashmap = new Dictionary<char, int>();
            for (int i = 0; i < order.Length; i++)
            {
                hashmap[order[i]] = i;
            }
            return hashmap;
        }
    }
}
