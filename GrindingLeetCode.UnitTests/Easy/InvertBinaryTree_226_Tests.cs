using LeetCodeProblems.CSharp.Tree;
using LeetCodeProblems.Interfaces.Easy;
using LeetCodeProblems.Shared;
using LeetCodeProblems.VisualBasic;

namespace GrindingLeetCode.UnitTests.Easy
{
    [TestClass]
    public class InvertBinaryTree_226_Tests
    {
        public static IEnumerable<object[]> GetImplementations()
        {
            yield return new object[] { new InvertBinaryTree_Recursive_CSharp_226(), "C# Recursive" };
            yield return new object[] { new InvertBinaryTree_Stack_CSharp_226(), "C# Stack" };
            yield return new object[] { new InvertBinaryTree_Recursive_VB_226(), "VB Recursive" };
            yield return new object[] { new InvertBinaryTree_Stack_VB_226(), "VB Stack" };
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
        /// Converts tree to level-order array for comparison
        /// </summary>
        private List<int?> TreeToLevelOrder(TreeNode root)
        {
            if (root == null) return new List<int?>();

            var result = new List<int?>();
            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                
                if (current == null)
                {
                    result.Add(null);
                }
                else
                {
                    result.Add(current.val);
                    queue.Enqueue(current.left);
                    queue.Enqueue(current.right);
                }
            }

            // Remove trailing nulls
            while (result.Count > 0 && result[result.Count - 1] == null)
            {
                result.RemoveAt(result.Count - 1);
            }

            return result;
        }

        /// <summary>
        /// Asserts that tree structure matches expected level-order representation
        /// </summary>
        private void AssertTreeEquals(int?[] expected, TreeNode actual, string solutionName)
        {
            var actualLevelOrder = TreeToLevelOrder(actual);
            var expectedList = new List<int?>(expected);

            // Remove trailing nulls from expected for comparison
            while (expectedList.Count > 0 && expectedList[expectedList.Count - 1] == null)
            {
                expectedList.RemoveAt(expectedList.Count - 1);
            }

            CollectionAssert.AreEqual(expectedList, actualLevelOrder, $"Failed for {solutionName}");
        }

        #endregion

        #region LeetCode Examples

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void InvertTree_Example1_InvertsCorrectly(IInvertBinaryTree_226 solution, string solutionName)
        {
            // Input: root = [4,2,7,1,3,6,9]
            //       4
            //      / \
            //     2   7
            //    / \ / \
            //   1  3 6  9
            //
            // Output: [4,7,2,9,6,3,1]
            //       4
            //      / \
            //     7   2
            //    / \ / \
            //   9  6 3  1

            // Arrange
            var root = CreateTree(new int?[] { 4, 2, 7, 1, 3, 6, 9 });

            // Act
            var result = solution.InvertTree(root);

            // Assert
            AssertTreeEquals(new int?[] { 4, 7, 2, 9, 6, 3, 1 }, result, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void InvertTree_Example2_InvertsCorrectly(IInvertBinaryTree_226 solution, string solutionName)
        {
            // Input: root = [2,1,3]
            //     2
            //    / \
            //   1   3
            //
            // Output: [2,3,1]
            //     2
            //    / \
            //   3   1

            // Arrange
            var root = CreateTree(new int?[] { 2, 1, 3 });

            // Act
            var result = solution.InvertTree(root);

            // Assert
            AssertTreeEquals(new int?[] { 2, 3, 1 }, result, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void InvertTree_Example3_EmptyTree_ReturnsNull(IInvertBinaryTree_226 solution, string solutionName)
        {
            // Input: root = []
            // Output: []

            // Arrange
            TreeNode root = null;

            // Act
            var result = solution.InvertTree(root);

            // Assert
            Assert.IsNull(result, $"Failed for {solutionName}");
        }

        #endregion

        #region Basic Tree Structures

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void InvertTree_SingleNode_ReturnsSameNode(IInvertBinaryTree_226 solution, string solutionName)
        {
            // Arrange
            var root = new TreeNode(5);

            // Act
            var result = solution.InvertTree(root);

            // Assert
            Assert.AreEqual(5, result.val, $"Failed for {solutionName}");
            Assert.IsNull(result.left, $"Failed for {solutionName}");
            Assert.IsNull(result.right, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void InvertTree_TwoNodesLeftChild_InvertsCorrectly(IInvertBinaryTree_226 solution, string solutionName)
        {
            // Input:  2        Output:  2
            //        /                   \
            //       1                     1

            // Arrange
            var root = CreateSimpleTree(2, left: 1);

            // Act
            var result = solution.InvertTree(root);

            // Assert
            AssertTreeEquals(new int?[] { 2, null, 1 }, result, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void InvertTree_TwoNodesRightChild_InvertsCorrectly(IInvertBinaryTree_226 solution, string solutionName)
        {
            // Input:  1        Output:  1
            //          \                /
            //           2              2

            // Arrange
            var root = CreateSimpleTree(1, right: 2);

            // Act
            var result = solution.InvertTree(root);

            // Assert
            AssertTreeEquals(new int?[] { 1, 2 }, result, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void InvertTree_ThreeNodesComplete_InvertsCorrectly(IInvertBinaryTree_226 solution, string solutionName)
        {
            // Input:    2        Output:    2
            //          / \                 / \
            //         1   3               3   1

            // Arrange
            var root = CreateSimpleTree(2, left: 1, right: 3);

            // Act
            var result = solution.InvertTree(root);

            // Assert
            AssertTreeEquals(new int?[] { 2, 3, 1 }, result, solutionName);
        }

        #endregion

        #region Balanced Trees

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void InvertTree_BalancedTree7Nodes_InvertsCorrectly(IInvertBinaryTree_226 solution, string solutionName)
        {
            // Input:       4              Output:       4
            //            /   \                        /   \
            //           2     6                      6     2
            //          / \   / \                    / \   / \
            //         1   3 5   7                  7   5 3   1

            // Arrange
            var root = CreateTree(new int?[] { 4, 2, 6, 1, 3, 5, 7 });

            // Act
            var result = solution.InvertTree(root);

            // Assert
            AssertTreeEquals(new int?[] { 4, 6, 2, 7, 5, 3, 1 }, result, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void InvertTree_BalancedTree15Nodes_InvertsCorrectly(IInvertBinaryTree_226 solution, string solutionName)
        {
            // Large balanced tree inversion

            // Arrange
            var root = CreateTree(new int?[] { 8, 4, 12, 2, 6, 10, 14, 1, 3, 5, 7, 9, 11, 13, 15 });

            // Act
            var result = solution.InvertTree(root);

            // Assert
            AssertTreeEquals(new int?[] { 8, 12, 4, 14, 10, 6, 2, 15, 13, 11, 9, 7, 5, 3, 1 }, result, solutionName);
        }

        #endregion

        #region Left-Skewed Trees

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void InvertTree_LeftSkewedTree3Nodes_InvertsToRightSkewed(IInvertBinaryTree_226 solution, string solutionName)
        {
            // Input:      3        Output:  3
            //            /                   \
            //           2                     2
            //          /                       \
            //         1                         1

            // Arrange
            var root = CreateTree(new int?[] { 3, 2, null, 1 });

            // Act
            var result = solution.InvertTree(root);

            // Assert
            AssertTreeEquals(new int?[] { 3, null, 2, null, 1 }, result, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void InvertTree_LeftSkewedTree5Nodes_InvertsToRightSkewed(IInvertBinaryTree_226 solution, string solutionName)
        {
            // Input:          5        Output:  5
            //                /                   \
            //               4                     4
            //              /                       \
            //             3                         3
            //            /                           \
            //           2                             2
            //          /                               \
            //         1                                 1

            // Arrange
            var root = CreateTree(new int?[] { 5, 4, null, 3, null, 2, null, 1 });

            // Act
            var result = solution.InvertTree(root);

            // Assert
            AssertTreeEquals(new int?[] { 5, null, 4, null, 3, null, 2, null, 1 }, result, solutionName);
        }

        #endregion

        #region Right-Skewed Trees

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void InvertTree_RightSkewedTree3Nodes_InvertsToLeftSkewed(IInvertBinaryTree_226 solution, string solutionName)
        {
            // Input:  1        Output:      1
            //          \                   /
            //           2                 2
            //            \               /
            //             3             3

            // Arrange
            var root = CreateTree(new int?[] { 1, null, 2, null, 3 });

            // Act
            var result = solution.InvertTree(root);

            // Assert
            AssertTreeEquals(new int?[] { 1, 2, null, 3 }, result, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void InvertTree_RightSkewedTree5Nodes_InvertsToLeftSkewed(IInvertBinaryTree_226 solution, string solutionName)
        {
            // Input:  1        Output:          1
            //          \                        /
            //           2                      2
            //            \                    /
            //             3                  3
            //              \                /
            //               4              4
            //                \            /
            //                 5          5

            // Arrange
            var root = CreateTree(new int?[] { 1, null, 2, null, 3, null, 4, null, 5 });

            // Act
            var result = solution.InvertTree(root);

            // Assert
            AssertTreeEquals(new int?[] { 1, 2, null, 3, null, 4, null, 5 }, result, solutionName);
        }

        #endregion

        #region Unbalanced Trees

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void InvertTree_UnbalancedLeftHeavy_InvertsCorrectly(IInvertBinaryTree_226 solution, string solutionName)
        {
            // Input:        5              Output:        5
            //             /   \                         /   \
            //            3     6                       6     3
            //           / \                                 / \
            //          2   4                               4   2
            //         /                                         \
            //        1                                           1

            // Arrange
            var root = CreateTree(new int?[] { 5, 3, 6, 2, 4, null, null, 1 });

            // Act
            var result = solution.InvertTree(root);

            // Assert - After inversion: right becomes null, left becomes (3 with children 4,2 and 2 has right child 1)
            AssertTreeEquals(new int?[] { 5, 6, 3, null, null, 4, 2, null, null, null, 1 }, result, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void InvertTree_UnbalancedRightHeavy_InvertsCorrectly(IInvertBinaryTree_226 solution, string solutionName)
        {
            // Input:    1              Output:    1
            //          / \                       / \
            //         0   3                     3   0
            //            / \                   / \
            //           2   4                 4   2
            //                \               /
            //                 5             5

            // Arrange
            var root = CreateTree(new int?[] { 1, 0, 3, null, null, 2, 4, null, null, null, 5 });

            // Act
            var result = solution.InvertTree(root);

            // Assert
            AssertTreeEquals(new int?[] { 1, 3, 0, 4, 2, null, null, 5 }, result, solutionName);
        }

        #endregion

        #region Edge Cases - Values

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void InvertTree_NegativeValues_InvertsCorrectly(IInvertBinaryTree_226 solution, string solutionName)
        {
            // Input:       0              Output:       0
            //            /   \                        /   \
            //          -2     2                      2    -2
            //          / \   / \                    / \   / \
            //        -3 -1  1  3                  3   1 -1 -3

            // Arrange
            var root = CreateTree(new int?[] { 0, -2, 2, -3, -1, 1, 3 });

            // Act
            var result = solution.InvertTree(root);

            // Assert
            AssertTreeEquals(new int?[] { 0, 2, -2, 3, 1, -1, -3 }, result, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void InvertTree_AllNegativeValues_InvertsCorrectly(IInvertBinaryTree_226 solution, string solutionName)
        {
            // Input:       -4              Output:       -4
            //            /    \                        /    \
            //          -6     -2                     -2     -6
            //          / \    / \                    / \    / \
            //        -7 -5  -3 -1                  -1 -3  -5 -7

            // Arrange
            var root = CreateTree(new int?[] { -4, -6, -2, -7, -5, -3, -1 });

            // Act
            var result = solution.InvertTree(root);

            // Assert
            AssertTreeEquals(new int?[] { -4, -2, -6, -1, -3, -5, -7 }, result, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void InvertTree_DuplicateValues_InvertsCorrectly(IInvertBinaryTree_226 solution, string solutionName)
        {
            // Input:      2              Output:      2
            //            / \                         / \
            //           2   2                       2   2
            //          / \                             / \
            //         1   2                           2   1

            // Arrange
            var root = CreateTree(new int?[] { 2, 2, 2, 1, 2 });

            // Act
            var result = solution.InvertTree(root);

            // Assert - Level 2 left child (2) gets no children, right child (2) gets children [2,1]
            AssertTreeEquals(new int?[] { 2, 2, 2, null, null, 2, 1 }, result, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void InvertTree_AllSameValues_InvertsCorrectly(IInvertBinaryTree_226 solution, string solutionName)
        {
            // Input:      5              Output:      5
            //            / \                         / \
            //           5   5                       5   5
            //          / \                             / \
            //         5   5                           5   5

            // Arrange
            var root = CreateTree(new int?[] { 5, 5, 5, 5, 5 });

            // Act
            var result = solution.InvertTree(root);

            // Assert - Symmetric tree remains symmetric, need null placeholders for right subtree's missing children
            AssertTreeEquals(new int?[] { 5, 5, 5, null, null, 5, 5 }, result, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void InvertTree_ZeroValue_InvertsCorrectly(IInvertBinaryTree_226 solution, string solutionName)
        {
            // Input:      0              Output:      0
            //            / \                         / \
            //           0   0                       0   0

            // Arrange
            var root = CreateSimpleTree(0, left: 0, right: 0);

            // Act
            var result = solution.InvertTree(root);

            // Assert
            AssertTreeEquals(new int?[] { 0, 0, 0 }, result, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void InvertTree_LargeValues_InvertsCorrectly(IInvertBinaryTree_226 solution, string solutionName)
        {
            // Input:      1000            Output:      1000
            //            /    \                       /    \
            //          100   10000                 10000   100

            // Arrange
            var root = CreateSimpleTree(1000, left: 100, right: 10000);

            // Act
            var result = solution.InvertTree(root);

            // Assert
            AssertTreeEquals(new int?[] { 1000, 10000, 100 }, result, solutionName);
        }

        #endregion

        #region Complex Trees

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void InvertTree_ComplexTree_InvertsCorrectly(IInvertBinaryTree_226 solution, string solutionName)
        {
            // Input:           10              Output:           10
            //               /      \                          /      \
            //              5        15                       15        5
            //            /   \        \                     /        /   \
            //           3     7       20                   20       7     3
            //          / \     \                                   /     / \
            //         1   4     9                                 9     4   1

            // Arrange
            var root = CreateTree(new int?[] { 10, 5, 15, 3, 7, null, 20, 1, 4, null, 9 });

            // Act
            var result = solution.InvertTree(root);

            // Assert - After inversion, structure has 15 as left with 20 as left child, 5 as right with 7,3 as children
            AssertTreeEquals(new int?[] { 10, 15, 5, 20, null, 7, 3, null, null, 9, null, 4, 1 }, result, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void InvertTree_SparseTree_InvertsCorrectly(IInvertBinaryTree_226 solution, string solutionName)
        {
            // Input:       8              Output:       8
            //            /   \                        /   \
            //           4     12                    12     4
            //            \   /                      \     /
            //             6 10                      10   6

            // Arrange
            var root = CreateTree(new int?[] { 8, 4, 12, null, 6, 10 });

            // Act
            var result = solution.InvertTree(root);

            // Assert - After swap: left becomes 12 with no left (null), right child 10
            //                      right becomes 4 with left child 6, no right (null)
            AssertTreeEquals(new int?[] { 8, 12, 4, null, 10, 6 }, result, solutionName);
        }

        #endregion

        #region Larger Trees

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void InvertTree_LargeBalancedTree_InvertsCorrectly(IInvertBinaryTree_226 solution, string solutionName)
        {
            // Create a larger balanced tree with 31 nodes (5 levels)

            // Arrange
            var root = CreateTree(new int?[] { 
                16, 8, 24, 4, 12, 20, 28, 2, 6, 10, 14, 18, 22, 26, 30,
                1, 3, 5, 7, 9, 11, 13, 15, 17, 19, 21, 23, 25, 27, 29, 31
            });

            // Act
            var result = solution.InvertTree(root);

            // Assert - After inversion, left and right subtrees are swapped at every level
            var expected = new int?[] { 
                16, 24, 8, 28, 20, 12, 4, 30, 26, 22, 18, 14, 10, 6, 2,
                31, 29, 27, 25, 23, 21, 19, 17, 15, 13, 11, 9, 7, 5, 3, 1
            };
            AssertTreeEquals(expected, result, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void InvertTree_DeepLeftSkewed_InvertsToDeepRightSkewed(IInvertBinaryTree_226 solution, string solutionName)
        {
            // Create a deep left-skewed tree (10 nodes)

            // Arrange
            TreeNode root = new TreeNode(10);
            TreeNode current = root;
            for (int i = 9; i >= 1; i--)
            {
                current.left = new TreeNode(i);
                current = current.left;
            }

            // Act
            var result = solution.InvertTree(root);

            // Assert - Should become right-skewed
            Assert.AreEqual(10, result.val);
            Assert.IsNull(result.left);
            Assert.IsNotNull(result.right);
            
            // Verify all nodes are now on the right
            current = result;
            for (int i = 9; i >= 1; i--)
            {
                current = current.right;
                Assert.IsNotNull(current, $"Node {i} should exist for {solutionName}");
                Assert.AreEqual(i, current.val, $"Failed for {solutionName}");
                Assert.IsNull(current.left, $"Left should be null for {solutionName}");
            }
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void InvertTree_DeepRightSkewed_InvertsToDeepLeftSkewed(IInvertBinaryTree_226 solution, string solutionName)
        {
            // Create a deep right-skewed tree (10 nodes)

            // Arrange
            TreeNode root = new TreeNode(1);
            TreeNode current = root;
            for (int i = 2; i <= 10; i++)
            {
                current.right = new TreeNode(i);
                current = current.right;
            }

            // Act
            var result = solution.InvertTree(root);

            // Assert - Should become left-skewed
            Assert.AreEqual(1, result.val);
            Assert.IsNull(result.right);
            Assert.IsNotNull(result.left);
            
            // Verify all nodes are now on the left
            current = result;
            for (int i = 2; i <= 10; i++)
            {
                current = current.left;
                Assert.IsNotNull(current, $"Node {i} should exist for {solutionName}");
                Assert.AreEqual(i, current.val, $"Failed for {solutionName}");
                Assert.IsNull(current.right, $"Right should be null for {solutionName}");
            }
        }

        #endregion

        #region Special Patterns

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void InvertTree_ZigZagPattern_InvertsCorrectly(IInvertBinaryTree_226 solution, string solutionName)
        {
            // Input:    1              Output:    1
            //            \                        /
            //             2                      2
            //            /                        \
            //           3                          3
            //            \                        /
            //             4                      4
            //            /                        \
            //           5                          5

            // Arrange
            var root = new TreeNode(1);
            root.right = new TreeNode(2);
            root.right.left = new TreeNode(3);
            root.right.left.right = new TreeNode(4);
            root.right.left.right.left = new TreeNode(5);

            // Act
            var result = solution.InvertTree(root);

            // Assert
            Assert.AreEqual(1, result.val);
            Assert.IsNotNull(result.left);
            Assert.IsNull(result.right);
            Assert.AreEqual(2, result.left.val);
            Assert.IsNotNull(result.left.right);
            Assert.AreEqual(3, result.left.right.val);
            Assert.IsNotNull(result.left.right.left);
            Assert.AreEqual(4, result.left.right.left.val);
            Assert.IsNotNull(result.left.right.left.right);
            Assert.AreEqual(5, result.left.right.left.right.val);
        }

        #endregion

        #region Property Tests

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void InvertTree_InvertTwice_ReturnsOriginal(IInvertBinaryTree_226 solution, string solutionName)
        {
            // Inverting twice should return to original structure

            // Arrange
            var root = CreateTree(new int?[] { 4, 2, 7, 1, 3, 6, 9 });
            var originalStructure = TreeToLevelOrder(root);

            // Act
            var invertedOnce = solution.InvertTree(root);
            var invertedTwice = solution.InvertTree(invertedOnce);

            // Assert
            var finalStructure = TreeToLevelOrder(invertedTwice);
            CollectionAssert.AreEqual(originalStructure, finalStructure, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void InvertTree_PreservesNodeCount(IInvertBinaryTree_226 solution, string solutionName)
        {
            // Inversion should preserve the number of nodes

            // Arrange
            var root = CreateTree(new int?[] { 4, 2, 7, 1, 3, 6, 9 });
            var originalCount = TreeToLevelOrder(root).Count(x => x != null);

            // Act
            var result = solution.InvertTree(root);

            // Assert
            var resultCount = TreeToLevelOrder(result).Count(x => x != null);
            Assert.AreEqual(originalCount, resultCount, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void InvertTree_PreservesAllValues(IInvertBinaryTree_226 solution, string solutionName)
        {
            // Inversion should preserve all node values (just changes structure)

            // Arrange
            var root = CreateTree(new int?[] { 4, 2, 7, 1, 3, 6, 9 });
            var originalValues = TreeToLevelOrder(root).Where(x => x != null).OrderBy(x => x).ToList();

            // Act
            var result = solution.InvertTree(root);

            // Assert
            var resultValues = TreeToLevelOrder(result).Where(x => x != null).OrderBy(x => x).ToList();
            CollectionAssert.AreEqual(originalValues, resultValues, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void InvertTree_SymmetricTree_RemainsSymmetric(IInvertBinaryTree_226 solution, string solutionName)
        {
            // A symmetric tree should remain symmetric after inversion

            // Arrange - Symmetric tree
            var root = CreateTree(new int?[] { 1, 2, 2, 3, 4, 4, 3 });

            // Act
            var result = solution.InvertTree(root);

            // Assert - Check if still symmetric
            AssertTreeEquals(new int?[] { 1, 2, 2, 3, 4, 4, 3 }, result, solutionName);
        }

        #endregion

        #region Boundary Cases

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void InvertTree_MaxConstraintSize_InvertsCorrectly(IInvertBinaryTree_226 solution, string solutionName)
        {
            // Create a reasonably large tree (50 nodes)

            // Arrange
            var values = Enumerable.Range(1, 50).Cast<int?>().ToArray();
            TreeNode root = CreateTree(values);
            var originalCount = TreeToLevelOrder(root).Count(x => x != null);

            // Act
            var result = solution.InvertTree(root);

            // Assert - Verify we still have all nodes
            var resultCount = TreeToLevelOrder(result).Count(x => x != null);
            Assert.AreEqual(originalCount, resultCount, $"Should have same node count for {solutionName}");
            Assert.AreEqual(50, resultCount, $"Should have 50 nodes for {solutionName}");
            
            // Verify root is the same
            Assert.AreEqual(1, result.val, $"Root should still be 1 for {solutionName}");
        }

        #endregion
    }
}
