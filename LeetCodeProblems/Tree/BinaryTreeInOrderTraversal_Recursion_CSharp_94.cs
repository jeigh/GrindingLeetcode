using LeetCodeProblems.Interfaces.Easy;
using LeetCodeProblems.Shared;
using System.ComponentModel.Design.Serialization;

namespace LeetCodeProblems.CSharp.Tree
{
    public class BinaryTreeInOrderTraversal_Recursion_CSharp_94 : IBinaryTreeInorderTraversal_94
    {
        public IList<int> InorderTraversal(TreeNode root)
        {
            if (root == null) return new List<int>();

            var result = InorderTraversal(root.left).ToList();
            result.Add(root.val);
            
            List<int> result2 = InorderTraversal(root.right).ToList();
            result.AddRange(result2);

            return result.ToList();
        }


    }
}
