using LeetCodeProblems.Interfaces.Easy;
using LeetCodeProblems.Shared;
using System.Text;

namespace LeetCodeProblems.CSharp.Tree
{
    public class SubtreeofAnotherTree_Serialization_CSharp_572 : ISubtreeOfAnotherTree_572
    {
        public bool IsSubtree(TreeNode root, TreeNode subroot)
        {
            var rootString = Serialize(root);
            var subRootString = Serialize(subroot);

            return rootString.Contains(subRootString);
        }

        private string Serialize(TreeNode root)
        {
            var sb = new StringBuilder();
            SerializeHelper(root, sb);
            return sb.ToString();
        }

        private void SerializeHelper(TreeNode root, StringBuilder sb)
        {
            sb.Append("(");
            if (root == null) sb.Append("#");
            else
            {
                sb.Append($"${root.val}");
                SerializeHelper(root.left, sb);
                SerializeHelper(root.right, sb);
            }
            sb.Append(")");
        }
    }
}
