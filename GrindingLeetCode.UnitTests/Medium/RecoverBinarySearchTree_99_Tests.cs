using LeetCodeProblems.CSharp.Tree;
using LeetCodeProblems.Interfaces.Medium;
using LeetCodeProblems.Shared;
using LeetCodeProblems.VisualBasic;

namespace GrindingLeetCode.UnitTests.Medium
{
    [TestClass]
    public class RecoverBinarySearchTree_99_Tests
    {
        public static IEnumerable<object[]> GetImplementations()
        {
            yield return new object[] { new RecoverBinarySearchTree_Iterative_CSharp_99(), "C# Iterative" };
            yield return new object[] { new RecoverBinarySearchTree_Recursive_CSharp_99(), "C# Recursive" };

            yield return new object[] { new RecoverBinarySearchTree_Iterative_VB_99(), "VB Iterative" };
            yield return new object[] { new RecoverBinarySearchTree_Recursive_VB_99(), "VB Recursive" };
        }

        #region Helper Methods

        /// <summary>
        /// Creates a binary tree from an array representation (level-order with nulls)
        /// </summary>
        private TreeNode CreateTree(int?[] values)
        {
            if (values == null || values.Length == 0 || values[0] == null)
                return null;

            TreeNode root = new TreeNode(values[0].Value);
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            int index = 1;

            while (queue.Count > 0 && index < values.Length)
            {
                TreeNode current = queue.Dequeue();

                // Left child
                if (index < values.Length && values[index] != null)
                {
                    current.left = new TreeNode(values[index].Value);
                    queue.Enqueue(current.left);
                }
                index++;

                // Right child
                if (index < values.Length && values[index] != null)
                {
                    current.right = new TreeNode(values[index].Value);
                    queue.Enqueue(current.right);
                }
                index++;
            }

            return root;
        }

        /// <summary>
        /// Helper to create a simple tree manually
        /// </summary>
        private TreeNode CreateSimpleTree(int root, int? left = null, int? right = null)
        {
            return new TreeNode(
                root,
                left.HasValue ? new TreeNode(left.Value) : null,
                right.HasValue ? new TreeNode(right.Value) : null
            );
        }

        /// <summary>
        /// Performs in-order traversal to get sorted values from BST
        /// </summary>
        private List<int> InorderTraversal(TreeNode root)
        {
            var result = new List<int>();
            if (root == null) return result;

            result.AddRange(InorderTraversal(root.left));
            result.Add(root.val);
            result.AddRange(InorderTraversal(root.right));

            return result;
        }

        /// <summary>
        /// Verifies that a tree is a valid BST
        /// </summary>
        private bool IsValidBST(TreeNode root, long min = long.MinValue, long max = long.MaxValue)
        {
            if (root == null) return true;
            if (root.val <= min || root.val >= max) return false;
            return IsValidBST(root.left, min, root.val) && IsValidBST(root.right, root.val, max);
        }

        /// <summary>
        /// Verifies the inorder traversal is sorted
        /// </summary>
        private bool IsInorderSorted(TreeNode root)
        {
            var inorder = InorderTraversal(root);
            for (int i = 1; i < inorder.Count; i++)
            {
                if (inorder[i] <= inorder[i - 1])
                    return false;
            }
            return true;
        }

        #endregion

        #region LeetCode Examples

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void RecoverTree_Example1_SwapsCorrectly(IRecoverBinarySearchTree_99 solution, string solutionName)
        {
            // Input: root = [1,3,null,null,2]
            //   1
            //  /
            // 3
            //  \
            //   2
            // Output: [3,1,null,null,2]
            //   3
            //  /
            // 1
            //  \
            //   2
            // Explanation: 3 and 1 are swapped

            // Arrange
            var root = CreateTree(new int?[] { 1, 3, null, null, 2 });

            // Act
            solution.RecoverTree(root);

            // Assert
            Assert.IsTrue(IsValidBST(root), $"Tree should be valid BST for {solutionName}");
            Assert.IsTrue(IsInorderSorted(root), $"Inorder traversal should be sorted for {solutionName}");
            var inorder = InorderTraversal(root);
            CollectionAssert.AreEqual(new[] { 1, 2, 3 }, inorder.ToArray(), $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void RecoverTree_Example2_SwapsCorrectly(IRecoverBinarySearchTree_99 solution, string solutionName)
        {
            // Input: root = [3,1,4,null,null,2]
            //   3
            //  / \
            // 1   4
            //    /
            //   2
            // Output: [2,1,4,null,null,3]
            //   2
            //  / \
            // 1   4
            //    /
            //   3
            // Explanation: 2 and 3 are swapped

            // Arrange
            var root = CreateTree(new int?[] { 3, 1, 4, null, null, 2 });

            // Act
            solution.RecoverTree(root);

            // Assert
            Assert.IsTrue(IsValidBST(root), $"Tree should be valid BST for {solutionName}");
            Assert.IsTrue(IsInorderSorted(root), $"Inorder traversal should be sorted for {solutionName}");
            var inorder = InorderTraversal(root);
            CollectionAssert.AreEqual(new[] { 1, 2, 3, 4 }, inorder.ToArray(), $"Failed for {solutionName}");
        }

        #endregion

        #region Two Node Swaps - Adjacent

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void RecoverTree_AdjacentSwap_RootAndLeftChild(IRecoverBinarySearchTree_99 solution, string solutionName)
        {
            // Tree: [1,2,3] (2 and 1 swapped)
            //   1
            //  / \
            // 2   3
            // Expected after recovery: [2,1,3]

            // Arrange
            var root = CreateSimpleTree(1, left: 2, right: 3);

            // Act
            solution.RecoverTree(root);

            // Assert
            Assert.IsTrue(IsValidBST(root), $"Failed for {solutionName}");
            Assert.IsTrue(IsInorderSorted(root), $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void RecoverTree_AdjacentSwap_RootAndRightChild(IRecoverBinarySearchTree_99 solution, string solutionName)
        {
            // Tree: [3,1,2] (3 and 2 swapped)
            //   3
            //  / \
            // 1   2
            // Expected after recovery: [2,1,3]

            // Arrange
            var root = CreateSimpleTree(3, left: 1, right: 2);

            // Act
            solution.RecoverTree(root);

            // Assert
            Assert.IsTrue(IsValidBST(root), $"Failed for {solutionName}");
            Assert.IsTrue(IsInorderSorted(root), $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void RecoverTree_AdjacentSwap_LeftAndRightChild(IRecoverBinarySearchTree_99 solution, string solutionName)
        {
            // Tree: [2,3,1] (3 and 1 swapped)
            //   2
            //  / \
            // 3   1
            // Expected after recovery: [2,1,3]

            // Arrange
            var root = CreateSimpleTree(2, left: 3, right: 1);

            // Act
            solution.RecoverTree(root);

            // Assert
            Assert.IsTrue(IsValidBST(root), $"Failed for {solutionName}");
            Assert.IsTrue(IsInorderSorted(root), $"Failed for {solutionName}");
        }

        #endregion

        #region Two Node Swaps - Non-Adjacent

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void RecoverTree_NonAdjacentSwap_FirstAndLast(IRecoverBinarySearchTree_99 solution, string solutionName)
        {
            // Tree: [4,2,6,1,3,5,7] but 1 and 7 are swapped
            // Corrupted: [4,2,6,7,3,5,1]
            //       4
            //      / \
            //     2   6
            //    / \ / \
            //   7  3 5  1

            // Arrange
            var root = CreateTree(new int?[] { 4, 2, 6, 7, 3, 5, 1 });

            // Act
            solution.RecoverTree(root);

            // Assert
            Assert.IsTrue(IsValidBST(root), $"Failed for {solutionName}");
            Assert.IsTrue(IsInorderSorted(root), $"Failed for {solutionName}");
            var inorder = InorderTraversal(root);
            CollectionAssert.AreEqual(new[] { 1, 2, 3, 4, 5, 6, 7 }, inorder.ToArray(), $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void RecoverTree_NonAdjacentSwap_LeftmostAndRightmost(IRecoverBinarySearchTree_99 solution, string solutionName)
        {
            // Tree: [8,4,12,2,6,10,14,1,3,5,7,9,11,13,15]
            // Swap 1 and 15
            // Corrupted: [8,4,12,2,6,10,14,15,3,5,7,9,11,13,1]

            // Arrange
            var root = CreateTree(new int?[] { 8, 4, 12, 2, 6, 10, 14, 15, 3, 5, 7, 9, 11, 13, 1 });

            // Act
            solution.RecoverTree(root);

            // Assert
            Assert.IsTrue(IsValidBST(root), $"Failed for {solutionName}");
            Assert.IsTrue(IsInorderSorted(root), $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void RecoverTree_NonAdjacentSwap_RootAndLeaf(IRecoverBinarySearchTree_99 solution, string solutionName)
        {
            // Tree: [4,2,6,1,3,5,7]
            // Swap 4 and 1
            // Corrupted: [1,2,6,4,3,5,7]

            // Arrange
            var root = CreateTree(new int?[] { 1, 2, 6, 4, 3, 5, 7 });

            // Act
            solution.RecoverTree(root);

            // Assert
            Assert.IsTrue(IsValidBST(root), $"Failed for {solutionName}");
            Assert.IsTrue(IsInorderSorted(root), $"Failed for {solutionName}");
        }

        #endregion

        #region Small Trees

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void RecoverTree_TwoNodes_Swapped(IRecoverBinarySearchTree_99 solution, string solutionName)
        {
            // Tree: [2,1] (swapped)
            //   2
            //  /
            // 1
            // Should remain valid (already correct) or swap if needed

            // Arrange
            var root = CreateTree(new int?[] { 1, 2 });

            // Act
            solution.RecoverTree(root);

            // Assert
            Assert.IsTrue(IsValidBST(root), $"Failed for {solutionName}");
            Assert.IsTrue(IsInorderSorted(root), $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void RecoverTree_ThreeNodes_RootAndLeft_Swapped(IRecoverBinarySearchTree_99 solution, string solutionName)
        {
            // Tree: [2,1,3] but actually [1,2,3] swapped
            //   1
            //  / \
            // 2   3

            // Arrange
            var root = CreateSimpleTree(1, left: 2, right: 3);

            // Act
            solution.RecoverTree(root);

            // Assert
            Assert.IsTrue(IsValidBST(root), $"Failed for {solutionName}");
            Assert.IsTrue(IsInorderSorted(root), $"Failed for {solutionName}");
        }

        #endregion

        #region Larger Balanced Trees

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void RecoverTree_BalancedTree_SwapLeftmostTwoNodes(IRecoverBinarySearchTree_99 solution, string solutionName)
        {
            // Tree: [4,2,6,1,3,5,7]
            // Swap 1 and 2
            // Corrupted: [4,2,6,2,3,5,7] -> [4,1,6,2,3,5,7]

            // Arrange - create with 2 and 1 swapped
            var root = CreateTree(new int?[] { 4, 1, 6, 2, 3, 5, 7 });

            // Act
            solution.RecoverTree(root);

            // Assert
            Assert.IsTrue(IsValidBST(root), $"Failed for {solutionName}");
            Assert.IsTrue(IsInorderSorted(root), $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void RecoverTree_BalancedTree_SwapRightmostTwoNodes(IRecoverBinarySearchTree_99 solution, string solutionName)
        {
            // Tree: [4,2,6,1,3,5,7]
            // Swap 6 and 7
            // Corrupted: [4,2,7,1,3,5,6]

            // Arrange
            var root = CreateTree(new int?[] { 4, 2, 7, 1, 3, 5, 6 });

            // Act
            solution.RecoverTree(root);

            // Assert
            Assert.IsTrue(IsValidBST(root), $"Failed for {solutionName}");
            Assert.IsTrue(IsInorderSorted(root), $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void RecoverTree_LargeBalancedTree_SwapMiddleNodes(IRecoverBinarySearchTree_99 solution, string solutionName)
        {
            // Tree: [8,4,12,2,6,10,14,1,3,5,7,9,11,13,15]
            // Swap 6 and 10
            // Corrupted: [8,4,12,2,10,6,14,1,3,5,7,9,11,13,15]

            // Arrange
            var root = CreateTree(new int?[] { 8, 4, 12, 2, 10, 6, 14, 1, 3, 5, 7, 9, 11, 13, 15 });

            // Act
            solution.RecoverTree(root);

            // Assert
            Assert.IsTrue(IsValidBST(root), $"Failed for {solutionName}");
            Assert.IsTrue(IsInorderSorted(root), $"Failed for {solutionName}");
        }

        #endregion

        #region Skewed Trees

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void RecoverTree_LeftSkewed_SwapTopTwo(IRecoverBinarySearchTree_99 solution, string solutionName)
        {
            // Tree: [5,4,null,3,null,2,null,1]
            // Swap 5 and 4
            // Corrupted: [4,5,null,3,null,2,null,1]

            // Arrange
            var root = CreateTree(new int?[] { 4, 5, null, 3, null, 2, null, 1 });

            // Act
            solution.RecoverTree(root);

            // Assert
            Assert.IsTrue(IsValidBST(root), $"Failed for {solutionName}");
            Assert.IsTrue(IsInorderSorted(root), $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void RecoverTree_RightSkewed_SwapTopTwo(IRecoverBinarySearchTree_99 solution, string solutionName)
        {
            // Tree: [1,null,2,null,3,null,4,null,5]
            // Swap 1 and 2
            // Corrupted: [2,null,1,null,3,null,4,null,5]

            // Arrange
            var root = CreateTree(new int?[] { 2, null, 1, null, 3, null, 4, null, 5 });

            // Act
            solution.RecoverTree(root);

            // Assert
            Assert.IsTrue(IsValidBST(root), $"Failed for {solutionName}");
            Assert.IsTrue(IsInorderSorted(root), $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void RecoverTree_LeftSkewed_SwapEnds(IRecoverBinarySearchTree_99 solution, string solutionName)
        {
            // Tree: [5,4,null,3,null,2,null,1]
            // Swap 5 and 1
            // Corrupted: [1,4,null,3,null,2,null,5]

            // Arrange
            var root = CreateTree(new int?[] { 1, 4, null, 3, null, 2, null, 5 });

            // Act
            solution.RecoverTree(root);

            // Assert
            Assert.IsTrue(IsValidBST(root), $"Failed for {solutionName}");
            Assert.IsTrue(IsInorderSorted(root), $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void RecoverTree_RightSkewed_SwapEnds(IRecoverBinarySearchTree_99 solution, string solutionName)
        {
            // Tree: [1,null,2,null,3,null,4,null,5]
            // Swap 1 and 5
            // Corrupted: [5,null,2,null,3,null,4,null,1]

            // Arrange
            var root = CreateTree(new int?[] { 5, null, 2, null, 3, null, 4, null, 1 });

            // Act
            solution.RecoverTree(root);

            // Assert
            Assert.IsTrue(IsValidBST(root), $"Failed for {solutionName}");
            Assert.IsTrue(IsInorderSorted(root), $"Failed for {solutionName}");
        }

        #endregion

        #region Edge Cases - Values

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void RecoverTree_NegativeValues_SwapsCorrectly(IRecoverBinarySearchTree_99 solution, string solutionName)
        {
            // Tree: [0,-2,2,-3,-1,1,3]
            // Swap -2 and 2
            // Corrupted: [0,2,-2,-3,-1,1,3]

            // Arrange
            var root = CreateTree(new int?[] { 0, 2, -2, -3, -1, 1, 3 });

            // Act
            solution.RecoverTree(root);

            // Assert
            Assert.IsTrue(IsValidBST(root), $"Failed for {solutionName}");
            Assert.IsTrue(IsInorderSorted(root), $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void RecoverTree_AllNegativeValues_SwapsCorrectly(IRecoverBinarySearchTree_99 solution, string solutionName)
        {
            // Tree: [-4,-6,-2,-7,-5,-3,-1]
            // Swap -6 and -2
            // Corrupted: [-4,-2,-6,-7,-5,-3,-1]

            // Arrange
            var root = CreateTree(new int?[] { -4, -2, -6, -7, -5, -3, -1 });

            // Act
            solution.RecoverTree(root);

            // Assert
            Assert.IsTrue(IsValidBST(root), $"Failed for {solutionName}");
            Assert.IsTrue(IsInorderSorted(root), $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void RecoverTree_WithZero_SwapsCorrectly(IRecoverBinarySearchTree_99 solution, string solutionName)
        {
            // Tree: [2,0,4,-1,1,3,5]
            // Swap 0 and 4
            // Corrupted: [2,4,0,-1,1,3,5]

            // Arrange
            var root = CreateTree(new int?[] { 2, 4, 0, -1, 1, 3, 5 });

            // Act
            solution.RecoverTree(root);

            // Assert
            Assert.IsTrue(IsValidBST(root), $"Failed for {solutionName}");
            Assert.IsTrue(IsInorderSorted(root), $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void RecoverTree_LargeValues_SwapsCorrectly(IRecoverBinarySearchTree_99 solution, string solutionName)
        {
            // Tree: [1000,500,1500,250,750,1250,1750]
            // Swap 500 and 1500
            // Corrupted: [1000,1500,500,250,750,1250,1750]

            // Arrange
            var root = CreateTree(new int?[] { 1000, 1500, 500, 250, 750, 1250, 1750 });

            // Act
            solution.RecoverTree(root);

            // Assert
            Assert.IsTrue(IsValidBST(root), $"Failed for {solutionName}");
            Assert.IsTrue(IsInorderSorted(root), $"Failed for {solutionName}");
        }

        #endregion

        #region Complex Structures

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void RecoverTree_UnbalancedTree_SwapAcrossSubtrees(IRecoverBinarySearchTree_99 solution, string solutionName)
        {
            // Tree: [10,5,15,3,7,12,20,1,4,6,9]
            // Swap 5 and 12
            // Corrupted: [10,12,15,3,7,5,20,1,4,6,9]

            // Arrange
            var root = CreateTree(new int?[] { 10, 12, 15, 3, 7, 5, 20, 1, 4, 6, 9 });

            // Act
            solution.RecoverTree(root);

            // Assert
            Assert.IsTrue(IsValidBST(root), $"Failed for {solutionName}");
            Assert.IsTrue(IsInorderSorted(root), $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void RecoverTree_SparseTree_SwapsCorrectly(IRecoverBinarySearchTree_99 solution, string solutionName)
        {
            // Tree: [8,4,12,null,6,10]
            // Swap 6 and 10
            // Corrupted: [8,4,12,null,10,6]

            // Arrange
            var root = CreateTree(new int?[] { 8, 4, 12, null, 10, 6 });

            // Act
            solution.RecoverTree(root);

            // Assert
            Assert.IsTrue(IsValidBST(root), $"Failed for {solutionName}");
            Assert.IsTrue(IsInorderSorted(root), $"Failed for {solutionName}");
        }

        #endregion

        #region Swap Patterns

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void RecoverTree_SwapParentAndChild_LeftChild(IRecoverBinarySearchTree_99 solution, string solutionName)
        {
            // Tree: [5,3,7,2,4,6,8]
            // Swap 5 and 3 (parent and left child)
            // Corrupted: [3,5,7,2,4,6,8]

            // Arrange
            var root = CreateTree(new int?[] { 3, 5, 7, 2, 4, 6, 8 });

            // Act
            solution.RecoverTree(root);

            // Assert
            Assert.IsTrue(IsValidBST(root), $"Failed for {solutionName}");
            Assert.IsTrue(IsInorderSorted(root), $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void RecoverTree_SwapParentAndChild_RightChild(IRecoverBinarySearchTree_99 solution, string solutionName)
        {
            // Tree: [5,3,7,2,4,6,8]
            // Swap 5 and 7 (parent and right child)
            // Corrupted: [7,3,5,2,4,6,8]

            // Arrange
            var root = CreateTree(new int?[] { 7, 3, 5, 2, 4, 6, 8 });

            // Act
            solution.RecoverTree(root);

            // Assert
            Assert.IsTrue(IsValidBST(root), $"Failed for {solutionName}");
            Assert.IsTrue(IsInorderSorted(root), $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void RecoverTree_SwapGrandparentAndGrandchild(IRecoverBinarySearchTree_99 solution, string solutionName)
        {
            // Tree: [5,3,7,2,4,6,8]
            // Swap 5 and 2 (grandparent and grandchild)
            // Corrupted: [2,3,7,5,4,6,8]

            // Arrange
            var root = CreateTree(new int?[] { 2, 3, 7, 5, 4, 6, 8 });

            // Act
            solution.RecoverTree(root);

            // Assert
            Assert.IsTrue(IsValidBST(root), $"Failed for {solutionName}");
            Assert.IsTrue(IsInorderSorted(root), $"Failed for {solutionName}");
        }

        #endregion

        #region Boundary Cases

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void RecoverTree_VeryLargeTree_SwapsCorrectly(IRecoverBinarySearchTree_99 solution, string solutionName)
        {
            // Tree: [16,8,24,4,12,20,28,2,6,10,14,18,22,26,30,1,3,5,7,9,11,13,15,17,19,21,23,25,27,29,31]
            // Swap 10 and 20
            // Corrupted: [16,8,24,4,12,10,28,2,6,20,14,18,22,26,30,1,3,5,7,9,11,13,15,17,19,21,23,25,27,29,31]

            // Arrange
            var root = CreateTree(new int?[] { 
                16, 8, 24, 4, 12, 10, 28, 2, 6, 20, 14, 18, 22, 26, 30,
                1, 3, 5, 7, 9, 11, 13, 15, 17, 19, 21, 23, 25, 27, 29, 31
            });

            // Act
            solution.RecoverTree(root);

            // Assert
            Assert.IsTrue(IsValidBST(root), $"Failed for {solutionName}");
            Assert.IsTrue(IsInorderSorted(root), $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void RecoverTree_ConsecutiveValues_SwapsCorrectly(IRecoverBinarySearchTree_99 solution, string solutionName)
        {
            // Tree with consecutive values: [8,4,12,2,6,10,14,1,3,5,7,9,11,13,15]
            // Swap 8 and 9 (consecutive values)
            // Corrupted: [9,4,12,2,6,10,14,1,3,5,7,8,11,13,15]

            // Arrange
            var root = CreateTree(new int?[] { 9, 4, 12, 2, 6, 10, 14, 1, 3, 5, 7, 8, 11, 13, 15 });

            // Act
            solution.RecoverTree(root);

            // Assert
            Assert.IsTrue(IsValidBST(root), $"Failed for {solutionName}");
            Assert.IsTrue(IsInorderSorted(root), $"Failed for {solutionName}");
        }

        #endregion

        #region Property Tests

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void RecoverTree_PreservesTreeStructure(IRecoverBinarySearchTree_99 solution, string solutionName)
        {
            // Verify that only values are swapped, not the tree structure

            // Arrange
            var root = CreateTree(new int?[] { 4, 2, 6, 7, 3, 5, 1 }); // 7 and 1 swapped
            var originalNodeCount = CountNodes(root);

            // Act
            solution.RecoverTree(root);

            // Assert
            var newNodeCount = CountNodes(root);
            Assert.AreEqual(originalNodeCount, newNodeCount, $"Node count should be preserved for {solutionName}");
            Assert.IsTrue(IsValidBST(root), $"Failed for {solutionName}");
        }

        private int CountNodes(TreeNode root)
        {
            if (root == null) return 0;
            return 1 + CountNodes(root.left) + CountNodes(root.right);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void RecoverTree_ResultIsValidBST(IRecoverBinarySearchTree_99 solution, string solutionName)
        {
            // Test multiple scenarios to ensure result is always a valid BST

            // Test case 1
            var root1 = CreateTree(new int?[] { 1, 3, null, null, 2 });
            solution.RecoverTree(root1);
            Assert.IsTrue(IsValidBST(root1), $"Case 1 failed for {solutionName}");

            // Test case 2
            var root2 = CreateTree(new int?[] { 3, 1, 4, null, null, 2 });
            solution.RecoverTree(root2);
            Assert.IsTrue(IsValidBST(root2), $"Case 2 failed for {solutionName}");

            // Test case 3
            var root3 = CreateTree(new int?[] { 4, 2, 6, 7, 3, 5, 1 });
            solution.RecoverTree(root3);
            Assert.IsTrue(IsValidBST(root3), $"Case 3 failed for {solutionName}");
        }

        #endregion
    }
}
