using LeetCodeProblems.Interfaces.Easy;
using LeetCodeProblems.Shared;

namespace LeetCodeProblems.CSharp.Tree
{
    // solved on 2025-12-17
    public class DiameterOfBinaryTree_StackHashmap_Csharp_543 : IDiameterOfBinaryTree_543
    {        
        public int DiameterOfBinaryTree(TreeNode root)
        {
            if (root == null) return 0;

            var stack = new Stack<TreeNode>();
            var hashMap = new Dictionary<TreeNode, (int height, int diameter)>();
            stack.Push(root);

            while (stack.Count > 0)
            {
                TreeNode node = stack.Peek();

                if (node.left != null && !hashMap.ContainsKey(node.left))
                    stack.Push(node.left);

                else if (node.right != null && !hashMap.ContainsKey(node.right))
                    stack.Push(node.right);

                else
                    PopAndUpdateHeightAndDiameter(stack, hashMap);
            }

            return hashMap[root].diameter;
        }

        private void PopAndUpdateHeightAndDiameter(Stack<TreeNode> stack, Dictionary<TreeNode, (int height, int diameter)> hashMap)
        {
            var current = stack.Pop();

            int leftHeight = 0;
            int rightHeight = 0;
            int leftDiameter = 0;
            int rightDiameter = 0;

            if (current.right != null)
                (rightHeight, rightDiameter) = hashMap[current.right];

            if (current.left != null)
                (leftHeight, leftDiameter)= hashMap[current.left];

            int maxDiameterOfChildren = Math.Max(leftDiameter, rightDiameter);

            int newHeight = Math.Max(leftHeight, rightHeight) + 1;
            int newDiameter = Math.Max(maxDiameterOfChildren, leftHeight + rightHeight);

            hashMap[current] = (newHeight, newDiameter);
        }



















        private void REFERENCE_PopAndUpdateHeightAndDiameter(Stack<TreeNode> stack, Dictionary<TreeNode, (int height, int diameter)> hashMap)
        {
            TreeNode node = stack.Pop();
                        
            int leftHeight = 0, leftDiameter = 0;
            
            if (node.left != null && hashMap.TryGetValue(node.left, out (int height, int diameter) value1))
                (leftHeight, leftDiameter) = value1;

            int rightHeight = 0, rightDiameter = 0;
            if (node.right != null && hashMap.TryGetValue(node.right, out (int height, int diameter) value))
                (rightHeight, rightDiameter) = value;

            int height = 1 + Math.Max(leftHeight, rightHeight);

            var maxDiameterOfChildren = Math.Max(leftDiameter, rightDiameter);
            int diameter = Math.Max(leftHeight + rightHeight, maxDiameterOfChildren);

            hashMap[node] = (height, diameter);
        }
    }


    public class DiameterOfBinaryTree_StackNoHashmap_Csharp_543 : IDiameterOfBinaryTree_543
    {
        public int DiameterOfBinaryTree(TreeNode root)
        {
            throw new NotImplementedException();
        }
    }

}
