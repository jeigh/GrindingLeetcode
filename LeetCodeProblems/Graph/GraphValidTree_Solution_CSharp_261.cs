using LeetCodeProblems.Interfaces.Medium;

namespace LeetCodeProblems.CSharp.Graph
{
    public class GraphValidTree_Solution_CSharp_261 : IGraphValidTree_261
    {
        public bool ValidTree(int n, int[][] edges)
        {
            if (edges.Length != n - 1) return false;
            var edgesOf = new List<List<int>>();
            for (int i = 0; i < n; i++) edgesOf.Add(new List<int>());

            foreach (var edge in edges)
            {
                edgesOf[edge[0]].Add(edge[1]);
                edgesOf[edge[1]].Add(edge[0]);
            }

            var visited = new HashSet<int>();

            var stack = new Stack<(int current, int parent)>();
            stack.Push((0, -1));

            while (stack.Count > 0)
            {
                (int current, int parent) = stack.Pop();
                if (visited.Contains(current)) break;

                visited.Add(current);
                foreach(var item in edgesOf[current])
                {
                    if (item == parent) continue;
                    stack.Push((item, current));
                }
            }

            return n == visited.Count;
        }
    }
}
