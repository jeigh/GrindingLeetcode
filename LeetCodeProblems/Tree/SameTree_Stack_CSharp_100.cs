using LeetCodeProblems.Interfaces.Easy;
using LeetCodeProblems.Shared;

namespace LeetCodeProblems.CSharp.Tree
{
    // solved 2025-12-24
    public class SameTree_Stack_CSharp_100 : ISameTree_100
    {
        public bool IsSameTree(TreeNode p, TreeNode q)
        {
            var stack = new Stack<(TreeNode? pNode, TreeNode? qNode)>();
            stack.Push((p, q));

            while (stack.Count > 0)
            {
                (var pNode, var qNode) = stack.Pop();
                if (pNode == null && qNode == null) continue;
                if (pNode?.val != qNode?.val) return false;

                stack.Push((pNode?.left, qNode?.left));
                stack.Push((pNode?.right, qNode?.right));
            }
            return true;
        }
    }
}
