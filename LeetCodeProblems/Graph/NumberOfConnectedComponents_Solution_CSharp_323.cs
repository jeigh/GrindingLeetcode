using LeetCodeProblems.Interfaces.Medium;

namespace LeetCodeProblems.CSharp.Graph
{
    public class NumberOfConnectedComponents_Solution_CSharp_323 : INumberOfConnectedComponents_323
    {
        // time complexity: O(V + E), where V = n and E = edges.Length
        // space complexity: O(V + E) for the adjacency list, visited set, and recursion stack
        public int CountComponents(int n, int[][] edges)
        {
            int returnable = 0;

            var connections = new List<List<int>>();
            for (int i = 0; i < n; i++) connections.Add(new List<int>());
            foreach (var edge in edges)
            {
                connections[edge[0]].Add(edge[1]);
                connections[edge[1]].Add(edge[0]);
            }

            var visited = new HashSet<int>();
            for (int i = 0; i < n; i++)
            {
                if (visited.Contains(i)) continue;
                returnable++;
                recurse(visited, connections, i);
            }
            
            return returnable;            
        }

        private void recurse(HashSet<int> visited, List<List<int>> connections, int i)
        {
            if (visited.Contains(i)) return;
            visited.Add(i);

            foreach (int item in connections[i])
                recurse(visited, connections, item);

        }
    }
}
