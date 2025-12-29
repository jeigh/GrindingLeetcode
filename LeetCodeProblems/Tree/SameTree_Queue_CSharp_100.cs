using LeetCodeProblems.Interfaces.Easy;
using LeetCodeProblems.Shared;

namespace LeetCodeProblems.CSharp.Tree
{
    // solved 2025-12-24
    public class SameTree_Queue_CSharp_100 : ISameTree_100
    {
        public bool IsSameTree(TreeNode p, TreeNode q)
        {
            var queue = new Queue<(TreeNode?, TreeNode?)>();
            queue.Enqueue((p, q));

            while (queue.Count > 0)
            {
                (var pNode, var qNode) = queue.Dequeue();
                if (pNode == null && qNode == null) continue;
                if (pNode?.val != qNode?.val) return false;

                queue.Enqueue((pNode?.left, qNode?.left));
                queue.Enqueue((pNode?.right, qNode?.right));
                
            }
            return true;
        }
    }
}
