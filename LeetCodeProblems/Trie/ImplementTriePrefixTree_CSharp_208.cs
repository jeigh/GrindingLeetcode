using LeetCodeProblems.HashingOrArrays;
using LeetCodeProblems.Interfaces.Medium;
using System.Diagnostics;

namespace LeetCodeProblems.CSharp.Trie
{
    public class TrieNode
    {
        public Dictionary<char, TrieNode> Nodes { get; set; } = new Dictionary<char, TrieNode>();
    }

    public class ImplementTriePrefixTree_CSharp_208 : IImplementTriePrefixTree_208
    {
        private const char EOW = '\0';
        private TrieNode _root = new TrieNode();

        public void Insert(string word)
        {
            TrieNode current = _root;
            foreach (char c in word)
            {
                
                if (current.Nodes.TryGetValue(c, out TrieNode next)) current = next;
                else 
                {
                    var temp = new TrieNode();
                    current.Nodes.Add(c, temp);
                    current = temp; 
                }
                
            }
            if (!current.Nodes.ContainsKey(EOW))
                current.Nodes.Add(EOW, null);
        }

        public bool Search(string word)
        {
            TrieNode current = _root;
            foreach (char c in word)
            {
                if (!current.Nodes.TryGetValue(c, out TrieNode next)) return false;
                else current = next;
            }

            if (current.Nodes.TryGetValue(EOW, out TrieNode next2)) return true;
            return false;
        }

        public bool StartsWith(string prefix)
        {
            TrieNode current = _root;
            foreach (char c in prefix)
            {
                if (!current.Nodes.TryGetValue(c, out TrieNode next)) return false;
                else current = next;
            }
            return true;

        }
    }
}
