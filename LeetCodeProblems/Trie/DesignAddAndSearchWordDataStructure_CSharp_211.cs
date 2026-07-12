using LeetCodeProblems.Interfaces.Medium;

namespace LeetCodeProblems.CSharp.Trie
{
    public class DesignAddAndSearchWordDataStructure_CSharp_211 : IDesignAddAndSearchWordDataStructure_211
    {

        public class TrieNode
        {
            public Dictionary<char, TrieNode> Nodes { get; set; } = new Dictionary<char, TrieNode>();
        }

        private TrieNode _root = new TrieNode();
        const char WILDCARD = '.';
        const char EOW = '\0';

        public void AddWord(string word)
        {
            var current = _root;

            foreach (char c in word)
            {
                if (!current!.Nodes.TryGetValue(c, out TrieNode nextNode)) 
                {
                    nextNode = new TrieNode();
                    current.Nodes.Add(c, nextNode);
                }
                current = nextNode;
            }

            if (!current!.Nodes.TryGetValue(EOW, out TrieNode lastNode))
            {
                lastNode = new TrieNode();
                current.Nodes.Add(EOW, lastNode);
            }
        }

        private bool Search(string word, int wordIndex, TrieNode current)
        {
            if (wordIndex == word.Length)
            {
                if (current.Nodes.TryGetValue(EOW, out TrieNode lastNode)) return true;
                return false;
            }

            if (word[wordIndex] == WILDCARD)
            {
                foreach (var kvp in current.Nodes)
                {
                    if (Search(word, wordIndex + 1, kvp.Value)) return true;
                }
                return false;
            }

            if (current.Nodes.TryGetValue(word[wordIndex], out TrieNode nextNode))
            {
                return Search(word, wordIndex + 1, nextNode);
            }
            return false;
        }

        public bool Search(string word) => Search(word, 0, _root);
    }
}
