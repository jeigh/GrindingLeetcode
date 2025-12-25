using LeetCodeProblems.CSharp.Tree;
using LeetCodeProblems.Interfaces.Easy;
using LeetCodeProblems.Shared;
using LeetCodeProblems.VisualBasic;

namespace GrindingLeetCode.UnitTests.Easy
{
    [TestClass]
    public class BinaryTreePostOrderTraversal_145_Tests
    {
        public static IEnumerable<object[]> GetImplementations()
        {
            yield return new object[] { new BinaryTreePostOrderTraversal_UsingReversal_CSharp_145(), "C# Reversal" };
            yield return new object[] { new BinaryTreePostOrderTraversal_TwoVisits_CSharp_145(), "C# Two-Visit" };
            yield return new object[] { new BinaryTreePostOrderTraversal_Reversal_VB_145(), "VB Reversal" };
            yield return new object[] { new BinaryTreePostOrderTraversal_TwoVisits_VB_145(), "VB Two-Visit" };
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
        public void PostOrderTraversal_Example1_ReturnsCorrectOrder(IBinaryTreePostOrderTraversal_145 solution, string solutionName)
        {
            // Input: root = [1,null,2,3]
            //    1
            //     \
            //      2
            //     /
            //    3
            // Output: [3,2,1]

            // Arrange
            var root = CreateTree(new int?[] { 1, null, 2, 3 });

            // Act
            var result = solution.PostOrderTraversal(root);

            // Assert
            CollectionAssert.AreEqual(new[] { 3, 2, 1 }, result.ToArray(), $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void PostOrderTraversal_Example2_EmptyTree_ReturnsEmpty(IBinaryTreePostOrderTraversal_145 solution, string solutionName)
        {
            // Input: root = []
            // Output: []

            // Arrange
            TreeNode root = null;

            // Act
            var result = solution.PostOrderTraversal(root);

            // Assert
            Assert.AreEqual(0, result.Count, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void PostOrderTraversal_Example3_SingleNode_ReturnsSingleElement(IBinaryTreePostOrderTraversal_145 solution, string solutionName)
        {
            // Input: root = [1]
            // Output: [1]

            // Arrange
            var root = new TreeNode(1);

            // Act
            var result = solution.PostOrderTraversal(root);

            // Assert
            CollectionAssert.AreEqual(new[] { 1 }, result.ToArray(), $"Failed for {solutionName}");
        }

        #endregion

        #region Basic Tree Structures

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void PostOrderTraversal_SingleNode_ReturnsNode(IBinaryTreePostOrderTraversal_145 solution, string solutionName)
        {
            // Arrange
            var root = new TreeNode(5);

            // Act
            var result = solution.PostOrderTraversal(root);

            // Assert
            CollectionAssert.AreEqual(new[] { 5 }, result.ToArray(), $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void PostOrderTraversal_TwoNodesLeftChild_ReturnsCorrectOrder(IBinaryTreePostOrderTraversal_145 solution, string solutionName)
        {
            // Tree:  2
            //       /
            //      1
            // Postorder: [1, 2]

            // Arrange
            var root = CreateSimpleTree(2, left: 1);

            // Act
            var result = solution.PostOrderTraversal(root);

            // Assert
            CollectionAssert.AreEqual(new[] { 1, 2 }, result.ToArray(), $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void PostOrderTraversal_TwoNodesRightChild_ReturnsCorrectOrder(IBinaryTreePostOrderTraversal_145 solution, string solutionName)
        {
            // Tree:  1
            //         \
            //          2
            // Postorder: [2, 1]

            // Arrange
            var root = CreateSimpleTree(1, right: 2);

            // Act
            var result = solution.PostOrderTraversal(root);

            // Assert
            CollectionAssert.AreEqual(new[] { 2, 1 }, result.ToArray(), $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void PostOrderTraversal_ThreeNodesComplete_ReturnsCorrectOrder(IBinaryTreePostOrderTraversal_145 solution, string solutionName)
        {
            // Tree:    2
            //         / \
            //        1   3
            // Postorder: [1, 3, 2]

            // Arrange
            var root = CreateSimpleTree(2, left: 1, right: 3);

            // Act
            var result = solution.PostOrderTraversal(root);

            // Assert
            CollectionAssert.AreEqual(new[] { 1, 3, 2 }, result.ToArray(), $"Failed for {solutionName}");
        }

        #endregion

        #region Balanced Trees

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void PostOrderTraversal_BalancedTree7Nodes_ReturnsCorrectOrder(IBinaryTreePostOrderTraversal_145 solution, string solutionName)
        {
            // Tree:       4
            //           /   \
            //          2     6
            //         / \   / \
            //        1   3 5   7
            // Postorder: [1, 3, 2, 5, 7, 6, 4]

            // Arrange
            var root = CreateTree(new int?[] { 4, 2, 6, 1, 3, 5, 7 });

            // Act
            var result = solution.PostOrderTraversal(root);

            // Assert
            CollectionAssert.AreEqual(new[] { 1, 3, 2, 5, 7, 6, 4 }, result.ToArray(), $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void PostOrderTraversal_BalancedTree15Nodes_ReturnsCorrectOrder(IBinaryTreePostOrderTraversal_145 solution, string solutionName)
        {
            // Tree:              8
            //                /       \
            //               4         12
            //             /   \      /   \
            //            2     6    10    14
            //           / \   / \   / \   / \
            //          1   3 5   7 9  11 13 15
            // Postorder: [1, 3, 2, 5, 7, 6, 4, 9, 11, 10, 13, 15, 14, 12, 8]

            // Arrange
            var root = CreateTree(new int?[] { 8, 4, 12, 2, 6, 10, 14, 1, 3, 5, 7, 9, 11, 13, 15 });

            // Act
            var result = solution.PostOrderTraversal(root);

            // Assert
            CollectionAssert.AreEqual(new[] { 1, 3, 2, 5, 7, 6, 4, 9, 11, 10, 13, 15, 14, 12, 8 }, 
                result.ToArray(), $"Failed for {solutionName}");
        }

        #endregion

        #region Left-Skewed Trees

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void PostOrderTraversal_LeftSkewedTree3Nodes_ReturnsCorrectOrder(IBinaryTreePostOrderTraversal_145 solution, string solutionName)
        {
            // Tree:      3
            //           /
            //          2
            //         /
            //        1
            // Postorder: [1, 2, 3]

            // Arrange
            var root = CreateTree(new int?[] { 3, 2, null, 1 });

            // Act
            var result = solution.PostOrderTraversal(root);

            // Assert
            CollectionAssert.AreEqual(new[] { 1, 2, 3 }, result.ToArray(), $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void PostOrderTraversal_LeftSkewedTree5Nodes_ReturnsCorrectOrder(IBinaryTreePostOrderTraversal_145 solution, string solutionName)
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
            // Postorder: [1, 2, 3, 4, 5]

            // Arrange
            var root = CreateTree(new int?[] { 5, 4, null, 3, null, 2, null, 1 });

            // Act
            var result = solution.PostOrderTraversal(root);

            // Assert
            CollectionAssert.AreEqual(new[] { 1, 2, 3, 4, 5 }, result.ToArray(), $"Failed for {solutionName}");
        }

        #endregion

        #region Right-Skewed Trees

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void PostOrderTraversal_RightSkewedTree3Nodes_ReturnsCorrectOrder(IBinaryTreePostOrderTraversal_145 solution, string solutionName)
        {
            // Tree:  1
            //         \
            //          2
            //           \
            //            3
            // Postorder: [3, 2, 1]

            // Arrange
            var root = CreateTree(new int?[] { 1, null, 2, null, 3 });

            // Act
            var result = solution.PostOrderTraversal(root);

            // Assert
            CollectionAssert.AreEqual(new[] { 3, 2, 1 }, result.ToArray(), $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void PostOrderTraversal_RightSkewedTree5Nodes_ReturnsCorrectOrder(IBinaryTreePostOrderTraversal_145 solution, string solutionName)
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
            // Postorder: [5, 4, 3, 2, 1]

            // Arrange
            var root = CreateTree(new int?[] { 1, null, 2, null, 3, null, 4, null, 5 });

            // Act
            var result = solution.PostOrderTraversal(root);

            // Assert
            CollectionAssert.AreEqual(new[] { 5, 4, 3, 2, 1 }, result.ToArray(), $"Failed for {solutionName}");
        }

        #endregion

        #region Unbalanced Trees

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void PostOrderTraversal_UnbalancedLeftHeavy_ReturnsCorrectOrder(IBinaryTreePostOrderTraversal_145 solution, string solutionName)
        {
            // Tree:        5
            //            /   \
            //           3     6
            //          / \
            //         2   4
            //        /
            //       1
            // Postorder: [1, 2, 4, 3, 6, 5]

            // Arrange
            var root = CreateTree(new int?[] { 5, 3, 6, 2, 4, null, null, 1 });

            // Act
            var result = solution.PostOrderTraversal(root);

            // Assert
            CollectionAssert.AreEqual(new[] { 1, 2, 4, 3, 6, 5 }, result.ToArray(), $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void PostOrderTraversal_UnbalancedRightHeavy_ReturnsCorrectOrder(IBinaryTreePostOrderTraversal_145 solution, string solutionName)
        {
            // Tree:    1
            //         / \
            //        0   3
            //           / \
            //          2   4
            //               \
            //                5
            // Postorder: [0, 2, 5, 4, 3, 1]

            // Arrange
            var root = CreateTree(new int?[] { 1, 0, 3, null, null, 2, 4, null, null, null, 5 });

            // Act
            var result = solution.PostOrderTraversal(root);

            // Assert
            CollectionAssert.AreEqual(new[] { 0, 2, 5, 4, 3, 1 }, result.ToArray(), $"Failed for {solutionName}");
        }

        #endregion

        #region Edge Cases - Values

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void PostOrderTraversal_NegativeValues_ReturnsCorrectOrder(IBinaryTreePostOrderTraversal_145 solution, string solutionName)
        {
            // Tree:      0
            //          /   \
            //        -2     2
            //        / \   / \
            //      -3 -1  1  3
            // Postorder: [-3, -1, -2, 1, 3, 2, 0]

            // Arrange
            var root = CreateTree(new int?[] { 0, -2, 2, -3, -1, 1, 3 });

            // Act
            var result = solution.PostOrderTraversal(root);

            // Assert
            CollectionAssert.AreEqual(new[] { -3, -1, -2, 1, 3, 2, 0 }, result.ToArray(), $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void PostOrderTraversal_AllNegativeValues_ReturnsCorrectOrder(IBinaryTreePostOrderTraversal_145 solution, string solutionName)
        {
            // Tree:      -4
            //           /   \
            //         -6    -2
            //         / \   / \
            //       -7 -5 -3 -1
            // Postorder: [-7, -5, -6, -3, -1, -2, -4]

            // Arrange
            var root = CreateTree(new int?[] { -4, -6, -2, -7, -5, -3, -1 });

            // Act
            var result = solution.PostOrderTraversal(root);

            // Assert
            CollectionAssert.AreEqual(new[] { -7, -5, -6, -3, -1, -2, -4 }, result.ToArray(), $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void PostOrderTraversal_DuplicateValues_ReturnsCorrectOrder(IBinaryTreePostOrderTraversal_145 solution, string solutionName)
        {
            // Tree:      2
            //           / \
            //          2   2
            //         / \
            //        1   2
            // Postorder: [1, 2, 2, 2, 2]

            // Arrange
            var root = CreateTree(new int?[] { 2, 2, 2, 1, 2 });

            // Act
            var result = solution.PostOrderTraversal(root);

            // Assert
            CollectionAssert.AreEqual(new[] { 1, 2, 2, 2, 2 }, result.ToArray(), $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void PostOrderTraversal_AllSameValues_ReturnsCorrectOrder(IBinaryTreePostOrderTraversal_145 solution, string solutionName)
        {
            // Tree:      5
            //           / \
            //          5   5
            //         / \
            //        5   5
            // Postorder: [5, 5, 5, 5, 5]

            // Arrange
            var root = CreateTree(new int?[] { 5, 5, 5, 5, 5 });

            // Act
            var result = solution.PostOrderTraversal(root);

            // Assert
            CollectionAssert.AreEqual(new[] { 5, 5, 5, 5, 5 }, result.ToArray(), $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void PostOrderTraversal_ZeroValue_ReturnsCorrectOrder(IBinaryTreePostOrderTraversal_145 solution, string solutionName)
        {
            // Tree:      0
            //           / \
            //          0   0
            // Postorder: [0, 0, 0]

            // Arrange
            var root = CreateSimpleTree(0, left: 0, right: 0);

            // Act
            var result = solution.PostOrderTraversal(root);

            // Assert
            CollectionAssert.AreEqual(new[] { 0, 0, 0 }, result.ToArray(), $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void PostOrderTraversal_LargeValues_ReturnsCorrectOrder(IBinaryTreePostOrderTraversal_145 solution, string solutionName)
        {
            // Tree:      1000
            //           /     \
            //         100    10000
            // Postorder: [100, 10000, 1000]

            // Arrange
            var root = CreateSimpleTree(1000, left: 100, right: 10000);

            // Act
            var result = solution.PostOrderTraversal(root);

            // Assert
            CollectionAssert.AreEqual(new[] { 100, 10000, 1000 }, result.ToArray(), $"Failed for {solutionName}");
        }

        #endregion

        #region Complex Trees

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void PostOrderTraversal_ComplexTree_ReturnsCorrectOrder(IBinaryTreePostOrderTraversal_145 solution, string solutionName)
        {
            // Tree:           10
            //              /      \
            //             5        15
            //           /   \        \
            //          3     7       20
            //         / \     \
            //        1   4     9
            // Postorder: [1, 4, 3, 9, 7, 5, 20, 15, 10]

            // Arrange
            var root = CreateTree(new int?[] { 10, 5, 15, 3, 7, null, 20, 1, 4, null, 9 });

            // Act
            var result = solution.PostOrderTraversal(root);

            // Assert
            CollectionAssert.AreEqual(new[] { 1, 4, 3, 9, 7, 5, 20, 15, 10 }, result.ToArray(), $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void PostOrderTraversal_SparseTree_ReturnsCorrectOrder(IBinaryTreePostOrderTraversal_145 solution, string solutionName)
        {
            // Tree:       8
            //           /   \
            //          4     12
            //           \   /
            //            6 10
            // Postorder: [6, 4, 10, 12, 8]

            // Arrange
            var root = CreateTree(new int?[] { 8, 4, 12, null, 6, 10 });

            // Act
            var result = solution.PostOrderTraversal(root);

            // Assert
            CollectionAssert.AreEqual(new[] { 6, 4, 10, 12, 8 }, result.ToArray(), $"Failed for {solutionName}");
        }

        #endregion

        #region Larger Trees

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void PostOrderTraversal_LargeBalancedTree_ReturnsCorrectOrder(IBinaryTreePostOrderTraversal_145 solution, string solutionName)
        {
            // Create a larger balanced tree with 31 nodes (5 levels)
            // Postorder: Left subtree -> Right subtree -> Root

            // Arrange
            var root = CreateTree(new int?[] { 
                16, 8, 24, 4, 12, 20, 28, 2, 6, 10, 14, 18, 22, 26, 30,
                1, 3, 5, 7, 9, 11, 13, 15, 17, 19, 21, 23, 25, 27, 29, 31
            });

            // Act
            var result = solution.PostOrderTraversal(root);

            // Assert - Postorder traversal pattern (left, right, root for each subtree)
            var expected = new[] { 1, 3, 2, 5, 7, 6, 4, 9, 11, 10, 13, 15, 14, 12, 8, 
                                   17, 19, 18, 21, 23, 22, 20, 25, 27, 26, 29, 31, 30, 28, 24, 16 };
            CollectionAssert.AreEqual(expected, result.ToArray(), $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void PostOrderTraversal_DeepLeftSkewed_ReturnsCorrectOrder(IBinaryTreePostOrderTraversal_145 solution, string solutionName)
        {
            // Create a deep left-skewed tree (10 nodes)
            // Postorder: [1, 2, 3, 4, 5, 6, 7, 8, 9, 10]

            // Arrange
            TreeNode root = new TreeNode(10);
            TreeNode current = root;
            for (int i = 9; i >= 1; i--)
            {
                current.left = new TreeNode(i);
                current = current.left;
            }

            // Act
            var result = solution.PostOrderTraversal(root);

            // Assert
            var expected = Enumerable.Range(1, 10).ToArray();
            CollectionAssert.AreEqual(expected, result.ToArray(), $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void PostOrderTraversal_DeepRightSkewed_ReturnsCorrectOrder(IBinaryTreePostOrderTraversal_145 solution, string solutionName)
        {
            // Create a deep right-skewed tree (10 nodes)
            // Postorder: [10, 9, 8, 7, 6, 5, 4, 3, 2, 1]

            // Arrange
            TreeNode root = new TreeNode(1);
            TreeNode current = root;
            for (int i = 2; i <= 10; i++)
            {
                current.right = new TreeNode(i);
                current = current.right;
            }

            // Act
            var result = solution.PostOrderTraversal(root);

            // Assert
            var expected = new[] { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 };
            CollectionAssert.AreEqual(expected, result.ToArray(), $"Failed for {solutionName}");
        }

        #endregion

        #region Special Patterns

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void PostOrderTraversal_ZigZagPattern_ReturnsCorrectOrder(IBinaryTreePostOrderTraversal_145 solution, string solutionName)
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
            // Postorder: [5, 4, 3, 2, 1]

            // Arrange
            var root = new TreeNode(1);
            root.right = new TreeNode(2);
            root.right.left = new TreeNode(3);
            root.right.left.right = new TreeNode(4);
            root.right.left.right.left = new TreeNode(5);

            // Act
            var result = solution.PostOrderTraversal(root);

            // Assert
            CollectionAssert.AreEqual(new[] { 5, 4, 3, 2, 1 }, result.ToArray(), $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void PostOrderTraversal_OnlyLeftChildren_ReturnsCorrectOrder(IBinaryTreePostOrderTraversal_145 solution, string solutionName)
        {
            // Tree:       10
            //            /
            //           9
            //          /
            //         8
            //        /
            //       7
            // Postorder: [7, 8, 9, 10]

            // Arrange
            var root = new TreeNode(10);
            root.left = new TreeNode(9);
            root.left.left = new TreeNode(8);
            root.left.left.left = new TreeNode(7);

            // Act
            var result = solution.PostOrderTraversal(root);

            // Assert
            CollectionAssert.AreEqual(new[] { 7, 8, 9, 10 }, result.ToArray(), $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void PostOrderTraversal_OnlyRightChildren_ReturnsCorrectOrder(IBinaryTreePostOrderTraversal_145 solution, string solutionName)
        {
            // Tree:  7
            //         \
            //          8
            //           \
            //            9
            //             \
            //              10
            // Postorder: [10, 9, 8, 7]

            // Arrange
            var root = new TreeNode(7);
            root.right = new TreeNode(8);
            root.right.right = new TreeNode(9);
            root.right.right.right = new TreeNode(10);

            // Act
            var result = solution.PostOrderTraversal(root);

            // Assert
            CollectionAssert.AreEqual(new[] { 10, 9, 8, 7 }, result.ToArray(), $"Failed for {solutionName}");
        }

        #endregion

        #region Comparison with Other Traversals

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void PostOrderTraversal_ComparedToOtherTraversals_DifferentOrder(IBinaryTreePostOrderTraversal_145 solution, string solutionName)
        {
            // Tree:    5
            //         / \
            //        3   7
            //       / \
            //      2   4
            // Postorder:  [2, 4, 3, 7, 5]
            // Preorder:   [5, 3, 2, 4, 7]
            // Inorder:    [2, 3, 4, 5, 7]

            // Arrange
            var root = CreateTree(new int?[] { 5, 3, 7, 2, 4 });

            // Act
            var result = solution.PostOrderTraversal(root);

            // Assert
            CollectionAssert.AreEqual(new[] { 2, 4, 3, 7, 5 }, result.ToArray(), $"Failed for {solutionName}");
            
            // Verify it's NOT preorder
            CollectionAssert.AreNotEqual(new[] { 5, 3, 2, 4, 7 }, result.ToArray(), 
                $"Should not be preorder for {solutionName}");
            
            // Verify it's NOT inorder
            CollectionAssert.AreNotEqual(new[] { 2, 3, 4, 5, 7 }, result.ToArray(), 
                $"Should not be inorder for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void PostOrderTraversal_RootAlwaysLast(IBinaryTreePostOrderTraversal_145 solution, string solutionName)
        {
            // Verify that root is always the last element (defining property of postorder)
            
            // Arrange - Multiple different trees
            var root1 = CreateSimpleTree(100, left: 1, right: 2);
            var root2 = CreateTree(new int?[] { 50, 25, 75, 10, 30, 60, 80 });
            var root3 = CreateTree(new int?[] { -5, -10, 5 });

            // Act
            var result1 = solution.PostOrderTraversal(root1);
            var result2 = solution.PostOrderTraversal(root2);
            var result3 = solution.PostOrderTraversal(root3);

            // Assert - Last element should be the root
            Assert.AreEqual(100, result1[result1.Count - 1], $"Root should be last for {solutionName}");
            Assert.AreEqual(50, result2[result2.Count - 1], $"Root should be last for {solutionName}");
            Assert.AreEqual(-5, result3[result3.Count - 1], $"Root should be last for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void PostOrderTraversal_LeftSubtreeBeforeRightSubtree(IBinaryTreePostOrderTraversal_145 solution, string solutionName)
        {
            // Verify that all left subtree nodes appear before all right subtree nodes
            // (another defining property of postorder)
            
            // Tree:    10
            //         /  \
            //        5    15
            //       / \   / \
            //      3  7  12 20
            // Postorder: [3, 7, 5, 12, 20, 15, 10]
            // All left subtree nodes [3,7,5] appear before right subtree nodes [12,20,15]

            // Arrange
            var root = CreateTree(new int?[] { 10, 5, 15, 3, 7, 12, 20 });

            // Act
            var result = solution.PostOrderTraversal(root);

            // Assert
            CollectionAssert.AreEqual(new[] { 3, 7, 5, 12, 20, 15, 10 }, result.ToArray(), 
                $"Failed for {solutionName}");
            
            // Verify left subtree nodes come before right subtree nodes
            var leftSubtreeValues = new[] { 3, 5, 7 };
            var rightSubtreeValues = new[] { 12, 15, 20 };
            
            int lastLeftIndex = -1;
            int firstRightIndex = int.MaxValue;
            
            for (int i = 0; i < result.Count; i++)
            {
                if (leftSubtreeValues.Contains(result[i]))
                    lastLeftIndex = Math.Max(lastLeftIndex, i);
                if (rightSubtreeValues.Contains(result[i]))
                    firstRightIndex = Math.Min(firstRightIndex, i);
            }
            
            Assert.IsTrue(lastLeftIndex < firstRightIndex, 
                $"All left subtree nodes should appear before right subtree nodes for {solutionName}");
        }

        #endregion

        #region Boundary Cases

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void PostOrderTraversal_MaxConstraintSize_ReturnsCorrectOrder(IBinaryTreePostOrderTraversal_145 solution, string solutionName)
        {
            // Create a reasonably large tree (50 nodes)
            
            // Arrange - Create a complete tree with 50 nodes
            var values = Enumerable.Range(1, 50).Cast<int?>().ToArray();
            TreeNode root = CreateTree(values);

            // Act
            var result = solution.PostOrderTraversal(root);

            // Assert - Verify we have all 50 nodes
            Assert.AreEqual(50, result.Count, $"Should have 50 nodes for {solutionName}");
            
            // Verify last element is root
            Assert.AreEqual(1, result[result.Count - 1], $"Root should be last for {solutionName}");
            
            // Verify all values are present
            var resultSet = new HashSet<int>(result);
            Assert.AreEqual(50, resultSet.Count, $"All unique values should be present for {solutionName}");
        }

        #endregion
    }
}
