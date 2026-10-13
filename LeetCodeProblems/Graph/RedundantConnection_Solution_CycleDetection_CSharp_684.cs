using LeetCodeProblems.Interfaces.Medium;

namespace LeetCodeProblems.CSharp.Graph
{
    public class RedundantConnection_Solution_CycleDetection_CSharp_684 : IRedundantConnection_684
    {
        public int[] FindRedundantConnection(int[][] edges)
        {
            var adjacencies = new List<List<int>>();
            for (int i = 0; i <= edges.Length; i++) adjacencies.Add(new List<int>());

            foreach (int[] edge in edges)
            {
                var first = edge[0];
                var second = edge[1];

                adjacencies[first].Add(second);
                adjacencies[second].Add(first);

                var visited = new HashSet<int>();
                if (HasCycle(first, -1, visited, adjacencies)) return new int[] { first, second };
            }
            return new int[2] { 0, 0 };
            
        }

        public bool HasCycle(int node, int parent, HashSet<int> visited, List<List<int>> adjacencies)
        {
            if (visited.Contains(node)) return true;
            visited.Add(node);

            foreach (var adj in adjacencies[node])
            {
                if (adj == parent) continue;
                if (HasCycle(adj, node, visited, adjacencies)) return true;
            }
            return false;
        }

    }
}
