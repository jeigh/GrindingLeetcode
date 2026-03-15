using LeetCodeProblems.Interfaces.Medium;
using System.Text;

namespace LeetCodeProblems.CSharp.Queue
{
    public class ReorganizeString_CSharp_767 : IReorganizeString_767
    {
        public string ReorganizeString(string s)
        {
            var charCounts = GetCharCounts(s);
            var queue = GenerateQueue(charCounts);
            
            char? lastCharUsed = null;
            StringBuilder responseString = new StringBuilder();
            while (queue.TryDequeue(out char element, out int priority))
            {
                if (lastCharUsed.HasValue && lastCharUsed.Value == element)
                {
                    if (!queue.TryDequeue(out char element2, out int priority2)) return String.Empty;
                    responseString.Append(element2);
                    if (priority2 < -1) queue.Enqueue(element2, priority2 + 1);
                    lastCharUsed = element2;

                    queue.Enqueue(element, priority);
                }
                else
                {
                    if (priority < -1) queue.Enqueue(element, priority + 1);
                    responseString.Append(element);
                    lastCharUsed = element;
                }
            }
            return responseString.ToString();
        }

        public PriorityQueue<char, int> GenerateQueue(Dictionary<char, int> dict)
        {
            var ret = new PriorityQueue<char, int>();
            foreach (var kvp in dict)
            {
                ret.Enqueue(kvp.Key, -kvp.Value);
            }
            return ret;
        }

        public Dictionary<char, int> GetCharCounts(string s)
        {
            var returnable = new Dictionary<char, int>();

            foreach (char c in s)
            {
                if (returnable.ContainsKey(c)) returnable[c]++;
                else returnable.Add(c, 1);
            }

            return returnable;
        }
    }
}
