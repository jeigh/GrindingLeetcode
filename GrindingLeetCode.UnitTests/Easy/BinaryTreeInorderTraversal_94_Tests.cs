using LeetCodeProblems.CSharp.Tree;
using LeetCodeProblems.Interfaces.Easy;
using LeetCodeProblems.Shared;
using LeetCodeProblems.VisualBasic;

namespace GrindingLeetCode.UnitTests.Easy
{
    [TestClass]
    public class BinaryTreeInorderTraversal_94_Tests
    {
        public static IEnumerable<object[]> GetImplementations()
        {
            yield return new object[] { new BinaryTreeInOrderTraversal_Recursion_CSharp_94(), "C# Recursion" };
            yield return new object[] { new BinaryTreeInOrderTraversal_Stack_CSharp_94(), "C# Stack" };
            yield return new object[] { new BinaryTreeInOrderTraversal_Recursive_VB_94(), "VB Recursion" };
            yield return new object[] { new BinaryTreeInOrderTraversal_Stack_VB_94(), "VB Stack" };
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

        #endregion

        #region LeetCode Examples

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void InorderTraversal_Example1_ReturnsCorrectOrder(IBinaryTreeInorderTraversal_94 solution, string solutionName)
        {
            // Input: root = [1,null,2,3]
            //    1
            //     \
            //      2
            //     /
            //    3
            // Output: [1,3,2]

            // Arrange
            var root = CreateTree(new int?[] { 1, null, 2, 3 });

            // Act
            var result = solution.InorderTraversal(root);

            // Assert
            CollectionAssert.AreEqual(new[] { 1, 3, 2 }, result.ToArray(), $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void InorderTraversal_Example2_EmptyTree_ReturnsEmpty(IBinaryTreeInorderTraversal_94 solution, string solutionName)
        {
            // Input: root = []
            // Output: []

            // Arrange
            TreeNode root = null;

            // Act
            var result = solution.InorderTraversal(root);

            // Assert
            Assert.AreEqual(0, result.Count, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void InorderTraversal_Example3_SingleNode_ReturnsSingleElement(IBinaryTreeInorderTraversal_94 solution, string solutionName)
        {
            // Input: root = [1]
            // Output: [1]

            // Arrange
            var root = new TreeNode(1);

            // Act
            var result = solution.InorderTraversal(root);

            // Assert
            CollectionAssert.AreEqual(new[] { 1 }, result.ToArray(), $"Failed for {solutionName}");
        }

        #endregion

        #region Basic Tree Structures

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void InorderTraversal_SingleNode_ReturnsNode(IBinaryTreeInorderTraversal_94 solution, string solutionName)
        {
            // Arrange
            var root = new TreeNode(5);

            // Act
            var result = solution.InorderTraversal(root);

            // Assert
            CollectionAssert.AreEqual(new[] { 5 }, result.ToArray(), $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void InorderTraversal_TwoNodesLeftChild_ReturnsCorrectOrder(IBinaryTreeInorderTraversal_94 solution, string solutionName)
        {
            // Tree:  2
            //       /
            //      1
            // Inorder: [1, 2]

            // Arrange
            var root = CreateSimpleTree(2, left: 1);

            // Act
            var result = solution.InorderTraversal(root);

            // Assert
            CollectionAssert.AreEqual(new[] { 1, 2 }, result.ToArray(), $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void InorderTraversal_TwoNodesRightChild_ReturnsCorrectOrder(IBinaryTreeInorderTraversal_94 solution, string solutionName)
        {
            // Tree:  1
            //         \
            //          2
            // Inorder: [1, 2]

            // Arrange
            var root = CreateSimpleTree(1, right: 2);

            // Act
            var result = solution.InorderTraversal(root);

            // Assert
            CollectionAssert.AreEqual(new[] { 1, 2 }, result.ToArray(), $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void InorderTraversal_ThreeNodesComplete_ReturnsCorrectOrder(IBinaryTreeInorderTraversal_94 solution, string solutionName)
        {
            // Tree:    2
            //         / \
            //        1   3
            // Inorder: [1, 2, 3]

            // Arrange
            var root = CreateSimpleTree(2, left: 1, right: 3);

            // Act
            var result = solution.InorderTraversal(root);

            // Assert
            CollectionAssert.AreEqual(new[] { 1, 2, 3 }, result.ToArray(), $"Failed for {solutionName}");
        }

        #endregion

        #region Balanced Trees

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void InorderTraversal_BalancedTree7Nodes_ReturnsCorrectOrder(IBinaryTreeInorderTraversal_94 solution, string solutionName)
        {
            // Tree:       4
            //           /   \
            //          2     6
            //         / \   / \
            //        1   3 5   7
            // Inorder: [1, 2, 3, 4, 5, 6, 7]

            // Arrange
            var root = CreateTree(new int?[] { 4, 2, 6, 1, 3, 5, 7 });

            // Act
            var result = solution.InorderTraversal(root);

            // Assert
            CollectionAssert.AreEqual(new[] { 1, 2, 3, 4, 5, 6, 7 }, result.ToArray(), $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void InorderTraversal_BalancedTree15Nodes_ReturnsCorrectOrder(IBinaryTreeInorderTraversal_94 solution, string solutionName)
        {
            // Tree:              8
            //                /       \
            //               4         12
            //             /   \      /   \
            //            2     6    10    14
            //           / \   / \   / \   / \
            //          1   3 5   7 9  11 13 15
            // Inorder: [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15]

            // Arrange
            var root = CreateTree(new int?[] { 8, 4, 12, 2, 6, 10, 14, 1, 3, 5, 7, 9, 11, 13, 15 });

            // Act
            var result = solution.InorderTraversal(root);

            // Assert
            CollectionAssert.AreEqual(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 }, 
                result.ToArray(), $"Failed for {solutionName}");
        }

        #endregion

        #region Left-Skewed Trees

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void InorderTraversal_LeftSkewedTree3Nodes_ReturnsCorrectOrder(IBinaryTreeInorderTraversal_94 solution, string solutionName)
        {
            // Tree:      3
            //           /
            //          2
            //         /
            //        1
            // Inorder: [1, 2, 3]

            // Arrange
            var root = CreateTree(new int?[] { 3, 2, null, 1 });

            // Act
            var result = solution.InorderTraversal(root);

            // Assert
            CollectionAssert.AreEqual(new[] { 1, 2, 3 }, result.ToArray(), $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void InorderTraversal_LeftSkewedTree5Nodes_ReturnsCorrectOrder(IBinaryTreeInorderTraversal_94 solution, string solutionName)
        {
            // Tree:          5
            //               /
            //              4
            //             /
            //            3
            //           /
            //          2
            //         /
            //        1
            // Inorder: [1, 2, 3, 4, 5]

            // Arrange
            var root = CreateTree(new int?[] { 5, 4, null, 3, null, 2, null, 1 });

            // Act
            var result = solution.InorderTraversal(root);

            // Assert
            CollectionAssert.AreEqual(new[] { 1, 2, 3, 4, 5 }, result.ToArray(), $"Failed for {solutionName}");
        }

        #endregion

        #region Right-Skewed Trees

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void InorderTraversal_RightSkewedTree3Nodes_ReturnsCorrectOrder(IBinaryTreeInorderTraversal_94 solution, string solutionName)
        {
            // Tree:  1
            //         \
            //          2
            //           \
            //            3
            // Inorder: [1, 2, 3]

            // Arrange
            var root = CreateTree(new int?[] { 1, null, 2, null, 3 });

            // Act
            var result = solution.InorderTraversal(root);

            // Assert
            CollectionAssert.AreEqual(new[] { 1, 2, 3 }, result.ToArray(), $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void InorderTraversal_RightSkewedTree5Nodes_ReturnsCorrectOrder(IBinaryTreeInorderTraversal_94 solution, string solutionName)
        {
            // Tree:  1
            //         \
            //          2
            //           \
            //            3
            //             \
            //              4
            //               \
            //                5
            // Inorder: [1, 2, 3, 4, 5]

            // Arrange
            var root = CreateTree(new int?[] { 1, null, 2, null, 3, null, 4, null, 5 });

            // Act
            var result = solution.InorderTraversal(root);

            // Assert
            CollectionAssert.AreEqual(new[] { 1, 2, 3, 4, 5 }, result.ToArray(), $"Failed for {solutionName}");
        }

        #endregion

        #region Unbalanced Trees

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void InorderTraversal_UnbalancedLeftHeavy_ReturnsCorrectOrder(IBinaryTreeInorderTraversal_94 solution, string solutionName)
        {
            // Tree:        5
            //            /   \
            //           3     6
            //          / \
            //         2   4
            //        /
            //       1
            // Inorder: [1, 2, 3, 4, 5, 6]

            // Arrange
            var root = CreateTree(new int?[] { 5, 3, 6, 2, 4, null, null, 1 });

            // Act
            var result = solution.InorderTraversal(root);

            // Assert
            CollectionAssert.AreEqual(new[] { 1, 2, 3, 4, 5, 6 }, result.ToArray(), $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void InorderTraversal_UnbalancedRightHeavy_ReturnsCorrectOrder(IBinaryTreeInorderTraversal_94 solution, string solutionName)
        {
            // Tree:    1
            //         / \
            //        0   3
            //           / \
            //          2   4
            //               \
            //                5
            // Inorder: [0, 1, 2, 3, 4, 5]

            // Arrange
            var root = CreateTree(new int?[] { 1, 0, 3, null, null, 2, 4, null, null, null, 5 });

            // Act
            var result = solution.InorderTraversal(root);

            // Assert
            CollectionAssert.AreEqual(new[] { 0, 1, 2, 3, 4, 5 }, result.ToArray(), $"Failed for {solutionName}");
        }

        #endregion

        #region Edge Cases - Values

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void InorderTraversal_NegativeValues_ReturnsCorrectOrder(IBinaryTreeInorderTraversal_94 solution, string solutionName)
        {
            // Tree:      0
            //          /   \
            //        -2     2
            //        / \   / \
            //      -3 -1  1  3
            // Inorder: [-3, -2, -1, 0, 1, 2, 3]

            // Arrange
            var root = CreateTree(new int?[] { 0, -2, 2, -3, -1, 1, 3 });

            // Act
            var result = solution.InorderTraversal(root);

            // Assert
            CollectionAssert.AreEqual(new[] { -3, -2, -1, 0, 1, 2, 3 }, result.ToArray(), $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void InorderTraversal_AllNegativeValues_ReturnsCorrectOrder(IBinaryTreeInorderTraversal_94 solution, string solutionName)
        {
            // Tree:      -4
            //           /   \
            //         -6    -2
            //         / \   / \
            //       -7 -5 -3 -1
            // Inorder: [-7, -6, -5, -4, -3, -2, -1]

            // Arrange
            var root = CreateTree(new int?[] { -4, -6, -2, -7, -5, -3, -1 });

            // Act
            var result = solution.InorderTraversal(root);

            // Assert
            CollectionAssert.AreEqual(new[] { -7, -6, -5, -4, -3, -2, -1 }, result.ToArray(), $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void InorderTraversal_DuplicateValues_ReturnsCorrectOrder(IBinaryTreeInorderTraversal_94 solution, string solutionName)
        {
            // Tree:      2
            //           / \
            //          2   2
            //         / \
            //        1   2
            // Inorder: [1, 2, 2, 2, 2]

            // Arrange
            var root = CreateTree(new int?[] { 2, 2, 2, 1, 2 });

            // Act
            var result = solution.InorderTraversal(root);

            // Assert
            CollectionAssert.AreEqual(new[] { 1, 2, 2, 2, 2 }, result.ToArray(), $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void InorderTraversal_AllSameValues_ReturnsCorrectOrder(IBinaryTreeInorderTraversal_94 solution, string solutionName)
        {
            // Tree:      5
            //           / \
            //          5   5
            //         / \
            //        5   5
            // Inorder: [5, 5, 5, 5, 5]

            // Arrange
            var root = CreateTree(new int?[] { 5, 5, 5, 5, 5 });

            // Act
            var result = solution.InorderTraversal(root);

            // Assert
            CollectionAssert.AreEqual(new[] { 5, 5, 5, 5, 5 }, result.ToArray(), $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void InorderTraversal_ZeroValue_ReturnsCorrectOrder(IBinaryTreeInorderTraversal_94 solution, string solutionName)
        {
            // Tree:      0
            //           / \
            //          0   0
            // Inorder: [0, 0, 0]

            // Arrange
            var root = CreateSimpleTree(0, left: 0, right: 0);

            // Act
            var result = solution.InorderTraversal(root);

            // Assert
            CollectionAssert.AreEqual(new[] { 0, 0, 0 }, result.ToArray(), $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void InorderTraversal_LargeValues_ReturnsCorrectOrder(IBinaryTreeInorderTraversal_94 solution, string solutionName)
        {
            // Tree:      1000
            //           /     \
            //         100    10000
            // Inorder: [100, 1000, 10000]

            // Arrange
            var root = CreateSimpleTree(1000, left: 100, right: 10000);

            // Act
            var result = solution.InorderTraversal(root);

            // Assert
            CollectionAssert.AreEqual(new[] { 100, 1000, 10000 }, result.ToArray(), $"Failed for {solutionName}");
        }

        #endregion

        #region Complex Trees

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void InorderTraversal_ComplexTree_ReturnsCorrectOrder(IBinaryTreeInorderTraversal_94 solution, string solutionName)
        {
            // Tree:           10
            //              /      \
            //             5        15
            //           /   \        \
            //          3     7       20
            //         / \     \
            //        1   4     9
            // Inorder: [1, 3, 4, 5, 7, 9, 10, 15, 20]

            // Arrange
            var root = CreateTree(new int?[] { 10, 5, 15, 3, 7, null, 20, 1, 4, null, 9 });

            // Act
            var result = solution.InorderTraversal(root);

            // Assert
            CollectionAssert.AreEqual(new[] { 1, 3, 4, 5, 7, 9, 10, 15, 20 }, result.ToArray(), $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void InorderTraversal_SparseTree_ReturnsCorrectOrder(IBinaryTreeInorderTraversal_94 solution, string solutionName)
        {
            // Tree:       8
            //           /   \
            //          4     12
            //           \   /
            //            6 10
            // Inorder: [4, 6, 8, 10, 12]

            // Arrange
            var root = CreateTree(new int?[] { 8, 4, 12, null, 6, 10 });

            // Act
            var result = solution.InorderTraversal(root);

            // Assert
            CollectionAssert.AreEqual(new[] { 4, 6, 8, 10, 12 }, result.ToArray(), $"Failed for {solutionName}");
        }

        #endregion

        #region Larger Trees

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void InorderTraversal_LargeBalancedTree_ReturnsCorrectOrder(IBinaryTreeInorderTraversal_94 solution, string solutionName)
        {
            // Create a larger balanced tree with 31 nodes (5 levels)
            // Inorder should be: [1, 2, 3, ..., 31]

            // Arrange
            var root = CreateTree(new int?[] { 
                16, 8, 24, 4, 12, 20, 28, 2, 6, 10, 14, 18, 22, 26, 30,
                1, 3, 5, 7, 9, 11, 13, 15, 17, 19, 21, 23, 25, 27, 29, 31
            });

            // Act
            var result = solution.InorderTraversal(root);

            // Assert
            var expected = Enumerable.Range(1, 31).ToArray();
            CollectionAssert.AreEqual(expected, result.ToArray(), $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void InorderTraversal_DeepLeftSkewed_ReturnsCorrectOrder(IBinaryTreeInorderTraversal_94 solution, string solutionName)
        {
            // Create a deep left-skewed tree (10 nodes)
            // Inorder: [1, 2, 3, 4, 5, 6, 7, 8, 9, 10]

            // Arrange
            TreeNode root = new TreeNode(10);
            TreeNode current = root;
            for (int i = 9; i >= 1; i--)
            {
                current.left = new TreeNode(i);
                current = current.left;
            }

            // Act
            var result = solution.InorderTraversal(root);

            // Assert
            var expected = Enumerable.Range(1, 10).ToArray();
            CollectionAssert.AreEqual(expected, result.ToArray(), $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void InorderTraversal_DeepRightSkewed_ReturnsCorrectOrder(IBinaryTreeInorderTraversal_94 solution, string solutionName)
        {
            // Create a deep right-skewed tree (10 nodes)
            // Inorder: [1, 2, 3, 4, 5, 6, 7, 8, 9, 10]

            // Arrange
            TreeNode root = new TreeNode(1);
            TreeNode current = root;
            for (int i = 2; i <= 10; i++)
            {
                current.right = new TreeNode(i);
                current = current.right;
            }

            // Act
            var result = solution.InorderTraversal(root);

            // Assert
            var expected = Enumerable.Range(1, 10).ToArray();
            CollectionAssert.AreEqual(expected, result.ToArray(), $"Failed for {solutionName}");
        }

        #endregion

        #region Special Patterns

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void InorderTraversal_ZigZagPattern_ReturnsCorrectOrder(IBinaryTreeInorderTraversal_94 solution, string solutionName)
        {
            // Tree:    1
            //           \
            //            2
            //           /
            //          3
            //           \
            //            4
            //           /
            //          5
            // Inorder: [1, 3, 5, 4, 2]

            // Arrange
            var root = new TreeNode(1);
            root.right = new TreeNode(2);
            root.right.left = new TreeNode(3);
            root.right.left.right = new TreeNode(4);
            root.right.left.right.left = new TreeNode(5);

            // Act
            var result = solution.InorderTraversal(root);

            // Assert
            CollectionAssert.AreEqual(new[] { 1, 3, 5, 4, 2 }, result.ToArray(), $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void InorderTraversal_OnlyLeftChildren_ReturnsCorrectOrder(IBinaryTreeInorderTraversal_94 solution, string solutionName)
        {
            // Tree:       10
            //            /
            //           9
            //          /
            //         8
            //        /
            //       7
            // Inorder: [7, 8, 9, 10]

            // Arrange
            var root = new TreeNode(10);
            root.left = new TreeNode(9);
            root.left.left = new TreeNode(8);
            root.left.left.left = new TreeNode(7);

            // Act
            var result = solution.InorderTraversal(root);

            // Assert
            CollectionAssert.AreEqual(new[] { 7, 8, 9, 10 }, result.ToArray(), $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void InorderTraversal_OnlyRightChildren_ReturnsCorrectOrder(IBinaryTreeInorderTraversal_94 solution, string solutionName)
        {
            // Tree:  7
            //         \
            //          8
            //           \
            //            9
            //             \
            //              10
            // Inorder: [7, 8, 9, 10]

            // Arrange
            var root = new TreeNode(7);
            root.right = new TreeNode(8);
            root.right.right = new TreeNode(9);
            root.right.right.right = new TreeNode(10);

            // Act
            var result = solution.InorderTraversal(root);

            // Assert
            CollectionAssert.AreEqual(new[] { 7, 8, 9, 10 }, result.ToArray(), $"Failed for {solutionName}");
        }

        #endregion
    }
}
