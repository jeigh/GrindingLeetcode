using LeetCodeProblems.Interfaces.Medium;
using LeetCodeProblems.Shared;

namespace LeetCodeProblems.CSharp.HashingOrArrays
{
    public class CloneGraph_CSharp_133 : ICloneGraph_133
    {
        // time complexity: O(n + e) where n = nodes, e = edges
        // space complexity: O(n)
        public GraphNode? CloneGraph(GraphNode? node)
        {
            var hashMap = new Dictionary<GraphNode, GraphNode>();

            return recurse(node, hashMap);
        }

        private GraphNode? recurse(GraphNode? node, Dictionary<GraphNode, GraphNode> hashMap)
        {
            if (node == null) return null;
            if (hashMap.ContainsKey(node)) return hashMap[node];

            var newNode = new GraphNode();
            newNode.val = node.val;
            hashMap.Add(node, newNode);

            if (node.neighbors == null) return newNode;

            foreach (var neighbor in node.neighbors)
            {
                var addable = recurse(neighbor, hashMap);
                newNode.neighbors.Add(addable);
            }

            return newNode;
        }


    }
}
