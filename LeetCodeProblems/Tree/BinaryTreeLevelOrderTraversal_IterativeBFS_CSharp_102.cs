using LeetCodeProblems.Interfaces.Medium;
using LeetCodeProblems.Shared;

namespace LeetCodeProblems.CSharp.Tree
{
    public class BinaryTreeLevelOrderTraversal_IterativeBFS_CSharp_102 : IBinaryTreeLevelOrderTraversal_102
    {
        // solved 2026-01-18
        public List<List<int>> LevelOrder(TreeNode root)
        {
            var response = new List<List<int>>();
            if (root == null) return response;
            
            var queue = new Queue<(int depth, TreeNode)>();
            queue.Enqueue((1, root));
            while (queue.Count > 0)
            {
                (int depth, TreeNode node) = queue.Dequeue();

                AddToResponse(response, depth, node.val);

                if (node.left != null)
                    queue.Enqueue((depth + 1, node.left));
                
                if (node.right != null)
                    queue.Enqueue((depth + 1, node.right));
            }

            return response;
        }

        private void AddToResponse(List<List<int>> response,  int depth, int value)
        {
            while (response.Count < depth) response.Add(new List<int>());
            response[depth - 1].Add(value);
        }
    }
}
