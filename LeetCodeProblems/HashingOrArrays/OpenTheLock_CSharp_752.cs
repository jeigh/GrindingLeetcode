using LeetCodeProblems.HashingOrArrays;
using LeetCodeProblems.Interfaces.Medium;

namespace LeetCodeProblems.CSharp.HashingOrArrays
{
    public class OpenTheLock_CSharp_752 : IOpenTheLock_752
    {
        public int OpenLock(string[] deadends, string target)
        {
            if (deadends.Contains(target)) return -1;
            if (deadends.Contains("0000")) return -1;

            var hashSet = new HashSet<string>();
            foreach (var item in deadends)
            {
                if (!hashSet.Contains(item)) hashSet.Add(item);
            }

            Queue<(string currentValue, int currentDistance)> queue = new();

            queue.Enqueue(("0000", 0));
            hashSet.Add("0000");
                        
            while (queue.Count > 0)
            {
                (string currentValue, int currentDistance) = queue.Dequeue();

                if (currentValue == target) return currentDistance;
                if (!hashSet.Contains(currentValue)) hashSet.Add(currentValue);
                
                var edges = GetEdges(currentValue, hashSet);

                foreach (var edge in edges)
                {
                    queue.Enqueue((edge, currentDistance + 1));
                }
            }
            return -1;
        }


        private List<string> GetEdges(string current, HashSet<string> hashSet)
        {
            var returnable = new List<string>();
            for (int i = 0; i < 4; i++)
            {
                var digit = current[i] - '0';
                var minusOne = (digit - 1 + 10) % 10;
                ReplaceCharAndAddToResponse(current, hashSet, returnable, i, minusOne);

                var plusOne = (digit + 1) % 10;
                ReplaceCharAndAddToResponse(current, hashSet, returnable, i, plusOne);
            }

            return returnable;
        }

        private static void ReplaceCharAndAddToResponse(string current, HashSet<string> hashSet, List<string> returnable, int i, int minusOne)
        {
            var charCurrent = current.ToCharArray();
            charCurrent[i] = (char)(minusOne + '0');
            string temp = new String(charCurrent);
            if (!hashSet.Contains(temp)) 
            { 
                hashSet.Add(temp);
                returnable.Add(temp); 
            }
        }
    }
}
