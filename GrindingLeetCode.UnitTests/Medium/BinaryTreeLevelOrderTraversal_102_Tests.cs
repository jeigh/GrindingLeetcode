using LeetCodeProblems.CSharp.Tree;
using LeetCodeProblems.Interfaces.Medium;
using LeetCodeProblems.Shared;

namespace GrindingLeetCode.UnitTests.Medium
{
    [TestClass]
    public class BinaryTreeLevelOrderTraversal_102_Tests
    {
        public static IEnumerable<object[]> GetImplementations()
        {
            yield return new object[] { new BinaryTreeLevelOrderTraversal_IterativeBFS_CSharp_102(), "C# Iterative BFS" };
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
        /// Asserts that level-order result matches expected
        /// </summary>
        private void AssertLevelOrderEquals(int[][] expected, List<List<int>> actual, string solutionName)
        {
            Assert.AreEqual(expected.Length, actual.Count, $"Different number of levels for {solutionName}");
            
            for (int i = 0; i < expected.Length; i++)
            {
                CollectionAssert.AreEqual(expected[i], actual[i].ToArray(), 
                    $"Level {i} mismatch for {solutionName}");
            }
        }

        #endregion

        #region LeetCode Examples

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void LevelOrder_Example1_ReturnsCorrectLevels(IBinaryTreeLevelOrderTraversal_102 solution, string solutionName)
        {
            // Input: root = [3,9,20,null,null,15,7]
            //       3
            //      / \
            //     9  20
            //       /  \
            //      15   7
            // Output: [[3],[9,20],[15,7]]

            // Arrange
            var root = CreateTree(new int?[] { 3, 9, 20, null, null, 15, 7 });

            // Act
            var result = solution.LevelOrder(root);

            // Assert
            var expected = new int[][] 
            {
                new int[] { 3 },
                new int[] { 9, 20 },
                new int[] { 15, 7 }
            };
            AssertLevelOrderEquals(expected, result, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void LevelOrder_Example2_SingleNode_ReturnsOneLevel(IBinaryTreeLevelOrderTraversal_102 solution, string solutionName)
        {
            // Input: root = [1]
            // Output: [[1]]

            // Arrange
            var root = new TreeNode(1);

            // Act
            var result = solution.LevelOrder(root);

            // Assert
            var expected = new int[][] { new int[] { 1 } };
            AssertLevelOrderEquals(expected, result, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void LevelOrder_Example3_EmptyTree_ReturnsEmpty(IBinaryTreeLevelOrderTraversal_102 solution, string solutionName)
        {
            // Input: root = []
            // Output: []

            // Arrange
            TreeNode root = null;

            // Act
            var result = solution.LevelOrder(root);

            // Assert
            Assert.AreEqual(0, result.Count, $"Failed for {solutionName}");
        }

        #endregion

        #region Basic Tree Structures

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void LevelOrder_TwoNodesLeftChild_ReturnsTwoLevels(IBinaryTreeLevelOrderTraversal_102 solution, string solutionName)
        {
            // Tree:  2
            //       /
            //      1
            // Level Order: [[2], [1]]

            // Arrange
            var root = CreateSimpleTree(2, left: 1);

            // Act
            var result = solution.LevelOrder(root);

            // Assert
            var expected = new int[][] 
            {
                new int[] { 2 },
                new int[] { 1 }
            };
            AssertLevelOrderEquals(expected, result, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void LevelOrder_TwoNodesRightChild_ReturnsTwoLevels(IBinaryTreeLevelOrderTraversal_102 solution, string solutionName)
        {
            // Tree:  1
            //         \
            //          2
            // Level Order: [[1], [2]]

            // Arrange
            var root = CreateSimpleTree(1, right: 2);

            // Act
            var result = solution.LevelOrder(root);

            // Assert
            var expected = new int[][] 
            {
                new int[] { 1 },
                new int[] { 2 }
            };
            AssertLevelOrderEquals(expected, result, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void LevelOrder_ThreeNodesComplete_ReturnsCorrectLevels(IBinaryTreeLevelOrderTraversal_102 solution, string solutionName)
        {
            // Tree:    2
            //         / \
            //        1   3
            // Level Order: [[2], [1, 3]]

            // Arrange
            var root = CreateSimpleTree(2, left: 1, right: 3);

            // Act
            var result = solution.LevelOrder(root);

            // Assert
            var expected = new int[][] 
            {
                new int[] { 2 },
                new int[] { 1, 3 }
            };
            AssertLevelOrderEquals(expected, result, solutionName);
        }

        #endregion

        #region Balanced Trees

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void LevelOrder_BalancedTree7Nodes_ReturnsCorrectLevels(IBinaryTreeLevelOrderTraversal_102 solution, string solutionName)
        {
            // Tree:       4
            //           /   \
            //          2     6
            //         / \   / \
            //        1   3 5   7
            // Level Order: [[4], [2, 6], [1, 3, 5, 7]]

            // Arrange
            var root = CreateTree(new int?[] { 4, 2, 6, 1, 3, 5, 7 });

            // Act
            var result = solution.LevelOrder(root);

            // Assert
            var expected = new int[][] 
            {
                new int[] { 4 },
                new int[] { 2, 6 },
                new int[] { 1, 3, 5, 7 }
            };
            AssertLevelOrderEquals(expected, result, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void LevelOrder_BalancedTree15Nodes_ReturnsCorrectLevels(IBinaryTreeLevelOrderTraversal_102 solution, string solutionName)
        {
            // Tree:              8
            //                /       \
            //               4         12
            //             /   \      /   \
            //            2     6    10    14
            //           / \   / \   / \   / \
            //          1   3 5   7 9  11 13 15
            // Level Order: [[8], [4, 12], [2, 6, 10, 14], [1, 3, 5, 7, 9, 11, 13, 15]]

            // Arrange
            var root = CreateTree(new int?[] { 8, 4, 12, 2, 6, 10, 14, 1, 3, 5, 7, 9, 11, 13, 15 });

            // Act
            var result = solution.LevelOrder(root);

            // Assert
            var expected = new int[][] 
            {
                new int[] { 8 },
                new int[] { 4, 12 },
                new int[] { 2, 6, 10, 14 },
                new int[] { 1, 3, 5, 7, 9, 11, 13, 15 }
            };
            AssertLevelOrderEquals(expected, result, solutionName);
        }

        #endregion

        #region Skewed Trees

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void LevelOrder_LeftSkewedTree3Nodes_ReturnsCorrectLevels(IBinaryTreeLevelOrderTraversal_102 solution, string solutionName)
        {
            // Tree:      3
            //           /
            //          2
            //         /
            //        1
            // Level Order: [[3], [2], [1]]

            // Arrange
            var root = CreateTree(new int?[] { 3, 2, null, 1 });

            // Act
            var result = solution.LevelOrder(root);

            // Assert
            var expected = new int[][] 
            {
                new int[] { 3 },
                new int[] { 2 },
                new int[] { 1 }
            };
            AssertLevelOrderEquals(expected, result, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void LevelOrder_LeftSkewedTree5Nodes_ReturnsCorrectLevels(IBinaryTreeLevelOrderTraversal_102 solution, string solutionName)
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
            // Level Order: [[5], [4], [3], [2], [1]]

            // Arrange
            var root = CreateTree(new int?[] { 5, 4, null, 3, null, 2, null, 1 });

            // Act
            var result = solution.LevelOrder(root);

            // Assert
            var expected = new int[][] 
            {
                new int[] { 5 },
                new int[] { 4 },
                new int[] { 3 },
                new int[] { 2 },
                new int[] { 1 }
            };
            AssertLevelOrderEquals(expected, result, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void LevelOrder_RightSkewedTree3Nodes_ReturnsCorrectLevels(IBinaryTreeLevelOrderTraversal_102 solution, string solutionName)
        {
            // Tree:  1
            //         \
            //          2
            //           \
            //            3
            // Level Order: [[1], [2], [3]]

            // Arrange
            var root = CreateTree(new int?[] { 1, null, 2, null, 3 });

            // Act
            var result = solution.LevelOrder(root);

            // Assert
            var expected = new int[][] 
            {
                new int[] { 1 },
                new int[] { 2 },
                new int[] { 3 }
            };
            AssertLevelOrderEquals(expected, result, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void LevelOrder_RightSkewedTree5Nodes_ReturnsCorrectLevels(IBinaryTreeLevelOrderTraversal_102 solution, string solutionName)
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
            // Level Order: [[1], [2], [3], [4], [5]]

            // Arrange
            var root = CreateTree(new int?[] { 1, null, 2, null, 3, null, 4, null, 5 });

            // Act
            var result = solution.LevelOrder(root);

            // Assert
            var expected = new int[][] 
            {
                new int[] { 1 },
                new int[] { 2 },
                new int[] { 3 },
                new int[] { 4 },
                new int[] { 5 }
            };
            AssertLevelOrderEquals(expected, result, solutionName);
        }

        #endregion

        #region Unbalanced Trees

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void LevelOrder_UnbalancedLeftHeavy_ReturnsCorrectLevels(IBinaryTreeLevelOrderTraversal_102 solution, string solutionName)
        {
            // Tree:        5
            //            /   \
            //           3     6
            //          / \
            //         2   4
            //        /
            //       1
            // Level Order: [[5], [3, 6], [2, 4], [1]]

            // Arrange
            var root = CreateTree(new int?[] { 5, 3, 6, 2, 4, null, null, 1 });

            // Act
            var result = solution.LevelOrder(root);

            // Assert
            var expected = new int[][] 
            {
                new int[] { 5 },
                new int[] { 3, 6 },
                new int[] { 2, 4 },
                new int[] { 1 }
            };
            AssertLevelOrderEquals(expected, result, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void LevelOrder_UnbalancedRightHeavy_ReturnsCorrectLevels(IBinaryTreeLevelOrderTraversal_102 solution, string solutionName)
        {
            // Tree:    1
            //         / \
            //        0   3
            //           / \
            //          2   4
            //               \
            //                5
            // Level Order: [[1], [0, 3], [2, 4], [5]]

            // Arrange
            var root = CreateTree(new int?[] { 1, 0, 3, null, null, 2, 4, null, null, null, 5 });

            // Act
            var result = solution.LevelOrder(root);

            // Assert
            var expected = new int[][] 
            {
                new int[] { 1 },
                new int[] { 0, 3 },
                new int[] { 2, 4 },
                new int[] { 5 }
            };
            AssertLevelOrderEquals(expected, result, solutionName);
        }

        #endregion

        #region Sparse Trees

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void LevelOrder_SparseTree_ReturnsCorrectLevels(IBinaryTreeLevelOrderTraversal_102 solution, string solutionName)
        {
            // Tree:       8
            //           /   \
            //          4     12
            //           \   /
            //            6 10
            // Level Order: [[8], [4, 12], [6, 10]]

            // Arrange
            var root = CreateTree(new int?[] { 8, 4, 12, null, 6, 10 });

            // Act
            var result = solution.LevelOrder(root);

            // Assert
            var expected = new int[][] 
            {
                new int[] { 8 },
                new int[] { 4, 12 },
                new int[] { 6, 10 }
            };
            AssertLevelOrderEquals(expected, result, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void LevelOrder_SparseTreeManyGaps_ReturnsCorrectLevels(IBinaryTreeLevelOrderTraversal_102 solution, string solutionName)
        {
            // Tree:           10
            //              /      \
            //             5        15
            //           /            \
            //          3             20
            //           \           /
            //            4         18
            // Level Order: [[10], [5, 15], [3, 20], [4, 18]]

            // Arrange
            var root = CreateTree(new int?[] { 10, 5, 15, 3, null, null, 20, null, 4, 18 });

            // Act
            var result = solution.LevelOrder(root);

            // Assert
            var expected = new int[][] 
            {
                new int[] { 10 },
                new int[] { 5, 15 },
                new int[] { 3, 20 },
                new int[] { 4, 18 }
            };
            AssertLevelOrderEquals(expected, result, solutionName);
        }

        #endregion

        #region Edge Cases - Values

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void LevelOrder_NegativeValues_ReturnsCorrectLevels(IBinaryTreeLevelOrderTraversal_102 solution, string solutionName)
        {
            // Tree:      0
            //          /   \
            //        -2     2
            //        / \   / \
            //      -3 -1  1  3
            // Level Order: [[0], [-2, 2], [-3, -1, 1, 3]]

            // Arrange
            var root = CreateTree(new int?[] { 0, -2, 2, -3, -1, 1, 3 });

            // Act
            var result = solution.LevelOrder(root);

            // Assert
            var expected = new int[][] 
            {
                new int[] { 0 },
                new int[] { -2, 2 },
                new int[] { -3, -1, 1, 3 }
            };
            AssertLevelOrderEquals(expected, result, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void LevelOrder_AllNegativeValues_ReturnsCorrectLevels(IBinaryTreeLevelOrderTraversal_102 solution, string solutionName)
        {
            // Tree:      -4
            //           /   \
            //         -6    -2
            //         / \   / \
            //       -7 -5 -3 -1
            // Level Order: [[-4], [-6, -2], [-7, -5, -3, -1]]

            // Arrange
            var root = CreateTree(new int?[] { -4, -6, -2, -7, -5, -3, -1 });

            // Act
            var result = solution.LevelOrder(root);

            // Assert
            var expected = new int[][] 
            {
                new int[] { -4 },
                new int[] { -6, -2 },
                new int[] { -7, -5, -3, -1 }
            };
            AssertLevelOrderEquals(expected, result, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void LevelOrder_DuplicateValues_ReturnsCorrectLevels(IBinaryTreeLevelOrderTraversal_102 solution, string solutionName)
        {
            // Tree:      2
            //           / \
            //          2   2
            //         / \
            //        1   2
            // Level Order: [[2], [2, 2], [1, 2]]

            // Arrange
            var root = CreateTree(new int?[] { 2, 2, 2, 1, 2 });

            // Act
            var result = solution.LevelOrder(root);

            // Assert
            var expected = new int[][] 
            {
                new int[] { 2 },
                new int[] { 2, 2 },
                new int[] { 1, 2 }
            };
            AssertLevelOrderEquals(expected, result, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void LevelOrder_AllSameValues_ReturnsCorrectLevels(IBinaryTreeLevelOrderTraversal_102 solution, string solutionName)
        {
            // Tree:      5
            //           / \
            //          5   5
            //         / \
            //        5   5
            // Level Order: [[5], [5, 5], [5, 5]]

            // Arrange
            var root = CreateTree(new int?[] { 5, 5, 5, 5, 5 });

            // Act
            var result = solution.LevelOrder(root);

            // Assert
            var expected = new int[][] 
            {
                new int[] { 5 },
                new int[] { 5, 5 },
                new int[] { 5, 5 }
            };
            AssertLevelOrderEquals(expected, result, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void LevelOrder_ZeroValue_ReturnsCorrectLevels(IBinaryTreeLevelOrderTraversal_102 solution, string solutionName)
        {
            // Tree:      0
            //           / \
            //          0   0
            // Level Order: [[0], [0, 0]]

            // Arrange
            var root = CreateSimpleTree(0, left: 0, right: 0);

            // Act
            var result = solution.LevelOrder(root);

            // Assert
            var expected = new int[][] 
            {
                new int[] { 0 },
                new int[] { 0, 0 }
            };
            AssertLevelOrderEquals(expected, result, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void LevelOrder_LargeValues_ReturnsCorrectLevels(IBinaryTreeLevelOrderTraversal_102 solution, string solutionName)
        {
            // Tree:      1000
            //           /     \
            //         100    10000
            // Level Order: [[1000], [100, 10000]]

            // Arrange
            var root = CreateSimpleTree(1000, left: 100, right: 10000);

            // Act
            var result = solution.LevelOrder(root);

            // Assert
            var expected = new int[][] 
            {
                new int[] { 1000 },
                new int[] { 100, 10000 }
            };
            AssertLevelOrderEquals(expected, result, solutionName);
        }

        #endregion

        #region Complex Trees

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void LevelOrder_ComplexTree_ReturnsCorrectLevels(IBinaryTreeLevelOrderTraversal_102 solution, string solutionName)
        {
            // Tree:           10
            //              /      \
            //             5        15
            //           /   \        \
            //          3     7       20
            //         / \     \
            //        1   4     9
            // Level Order: [[10], [5, 15], [3, 7, 20], [1, 4, 9]]

            // Arrange
            var root = CreateTree(new int?[] { 10, 5, 15, 3, 7, null, 20, 1, 4, null, 9 });

            // Act
            var result = solution.LevelOrder(root);

            // Assert
            var expected = new int[][] 
            {
                new int[] { 10 },
                new int[] { 5, 15 },
                new int[] { 3, 7, 20 },
                new int[] { 1, 4, 9 }
            };
            AssertLevelOrderEquals(expected, result, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void LevelOrder_VeryWideLevel_ReturnsCorrectLevels(IBinaryTreeLevelOrderTraversal_102 solution, string solutionName)
        {
            // Tree with 8 nodes at the bottom level
            //              8
            //          /       \
            //         4         12
            //        / \       /  \
            //       2   6    10   14
            //      / \ / \  / \  / \
            //     1  3 5 7 9 11 13 15
            // Level Order: [[8], [4, 12], [2, 6, 10, 14], [1, 3, 5, 7, 9, 11, 13, 15]]

            // Arrange
            var root = CreateTree(new int?[] { 8, 4, 12, 2, 6, 10, 14, 1, 3, 5, 7, 9, 11, 13, 15 });

            // Act
            var result = solution.LevelOrder(root);

            // Assert
            Assert.AreEqual(4, result.Count, $"Should have 4 levels for {solutionName}");
            Assert.AreEqual(8, result[3].Count, $"Bottom level should have 8 nodes for {solutionName}");
        }

        #endregion

        #region Larger Trees

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void LevelOrder_LargeBalancedTree31Nodes_ReturnsCorrectLevels(IBinaryTreeLevelOrderTraversal_102 solution, string solutionName)
        {
            // Perfect binary tree with 5 levels (31 nodes)

            // Arrange
            var root = CreateTree(new int?[] { 
                16, 8, 24, 4, 12, 20, 28, 2, 6, 10, 14, 18, 22, 26, 30,
                1, 3, 5, 7, 9, 11, 13, 15, 17, 19, 21, 23, 25, 27, 29, 31
            });

            // Act
            var result = solution.LevelOrder(root);

            // Assert
            Assert.AreEqual(5, result.Count, $"Should have 5 levels for {solutionName}");
            Assert.AreEqual(1, result[0].Count, $"Level 0 should have 1 node for {solutionName}");
            Assert.AreEqual(2, result[1].Count, $"Level 1 should have 2 nodes for {solutionName}");
            Assert.AreEqual(4, result[2].Count, $"Level 2 should have 4 nodes for {solutionName}");
            Assert.AreEqual(8, result[3].Count, $"Level 3 should have 8 nodes for {solutionName}");
            Assert.AreEqual(16, result[4].Count, $"Level 4 should have 16 nodes for {solutionName}");
            
            // Verify root
            Assert.AreEqual(16, result[0][0], $"Root should be 16 for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void LevelOrder_DeepLeftSkewed10Nodes_ReturnsCorrectLevels(IBinaryTreeLevelOrderTraversal_102 solution, string solutionName)
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
            var result = solution.LevelOrder(root);

            // Assert
            Assert.AreEqual(10, result.Count, $"Should have 10 levels for {solutionName}");
            for (int i = 0; i < 10; i++)
            {
                Assert.AreEqual(1, result[i].Count, $"Level {i} should have 1 node for {solutionName}");
            }
            
            // Verify values descend from 10 to 1
            for (int i = 0; i < 10; i++)
            {
                Assert.AreEqual(10 - i, result[i][0], $"Level {i} value mismatch for {solutionName}");
            }
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void LevelOrder_DeepRightSkewed10Nodes_ReturnsCorrectLevels(IBinaryTreeLevelOrderTraversal_102 solution, string solutionName)
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
            var result = solution.LevelOrder(root);

            // Assert
            Assert.AreEqual(10, result.Count, $"Should have 10 levels for {solutionName}");
            for (int i = 0; i < 10; i++)
            {
                Assert.AreEqual(1, result[i].Count, $"Level {i} should have 1 node for {solutionName}");
            }
            
            // Verify values ascend from 1 to 10
            for (int i = 0; i < 10; i++)
            {
                Assert.AreEqual(i + 1, result[i][0], $"Level {i} value mismatch for {solutionName}");
            }
        }

        #endregion

        #region Special Patterns

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void LevelOrder_ZigZagPattern_ReturnsCorrectLevels(IBinaryTreeLevelOrderTraversal_102 solution, string solutionName)
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
            // Level Order: [[1], [2], [3], [4], [5]]

            // Arrange
            var root = new TreeNode(1);
            root.right = new TreeNode(2);
            root.right.left = new TreeNode(3);
            root.right.left.right = new TreeNode(4);
            root.right.left.right.left = new TreeNode(5);

            // Act
            var result = solution.LevelOrder(root);

            // Assert
            var expected = new int[][] 
            {
                new int[] { 1 },
                new int[] { 2 },
                new int[] { 3 },
                new int[] { 4 },
                new int[] { 5 }
            };
            AssertLevelOrderEquals(expected, result, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void LevelOrder_OneLevelWithManyNodes_ReturnsCorrectLevels(IBinaryTreeLevelOrderTraversal_102 solution, string solutionName)
        {
            // Tree with root and 7 children at level 1 (sparse representation)
            // This tests handling of a very wide but shallow tree

            // Arrange
            var root = new TreeNode(1);
            root.left = new TreeNode(2);
            root.right = new TreeNode(3);
            root.left.left = new TreeNode(4);
            root.left.right = new TreeNode(5);
            root.right.left = new TreeNode(6);
            root.right.right = new TreeNode(7);

            // Act
            var result = solution.LevelOrder(root);

            // Assert
            var expected = new int[][] 
            {
                new int[] { 1 },
                new int[] { 2, 3 },
                new int[] { 4, 5, 6, 7 }
            };
            AssertLevelOrderEquals(expected, result, solutionName);
        }

        #endregion

        #region Property Tests

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void LevelOrder_FirstLevelAlwaysRoot(IBinaryTreeLevelOrderTraversal_102 solution, string solutionName)
        {
            // Verify that first level always contains only the root

            // Arrange - Multiple different trees
            var root1 = CreateSimpleTree(100, left: 1, right: 2);
            var root2 = CreateTree(new int?[] { 50, 25, 75, 10, 30, 60, 80 });
            var root3 = CreateTree(new int?[] { -5, -10, 5 });

            // Act
            var result1 = solution.LevelOrder(root1);
            var result2 = solution.LevelOrder(root2);
            var result3 = solution.LevelOrder(root3);

            // Assert
            Assert.AreEqual(1, result1[0].Count, $"First level should have 1 node for {solutionName}");
            Assert.AreEqual(100, result1[0][0], $"First level should be root for {solutionName}");
            
            Assert.AreEqual(1, result2[0].Count, $"First level should have 1 node for {solutionName}");
            Assert.AreEqual(50, result2[0][0], $"First level should be root for {solutionName}");
            
            Assert.AreEqual(1, result3[0].Count, $"First level should have 1 node for {solutionName}");
            Assert.AreEqual(-5, result3[0][0], $"First level should be root for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void LevelOrder_AllNodesAppear_ExactlyOnce(IBinaryTreeLevelOrderTraversal_102 solution, string solutionName)
        {
            // Verify that all nodes appear exactly once across all levels

            // Arrange
            var root = CreateTree(new int?[] { 4, 2, 6, 1, 3, 5, 7 });

            // Act
            var result = solution.LevelOrder(root);

            // Assert
            var allNodes = result.SelectMany(level => level).ToList();
            Assert.AreEqual(7, allNodes.Count, $"Should have 7 nodes total for {solutionName}");
            
            // Verify all unique
            var uniqueNodes = allNodes.Distinct().ToList();
            Assert.AreEqual(7, uniqueNodes.Count, $"All nodes should be unique for {solutionName}");
            
            // Verify contains expected values
            var expected = new HashSet<int> { 1, 2, 3, 4, 5, 6, 7 };
            Assert.IsTrue(uniqueNodes.All(n => expected.Contains(n)), $"Should contain correct values for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void LevelOrder_LevelSizesMatch_PowerOfTwo_ForPerfectTree(IBinaryTreeLevelOrderTraversal_102 solution, string solutionName)
        {
            // For a perfect binary tree, each level should have 2^level nodes

            // Arrange - Perfect tree with 3 levels (7 nodes)
            var root = CreateTree(new int?[] { 4, 2, 6, 1, 3, 5, 7 });

            // Act
            var result = solution.LevelOrder(root);

            // Assert
            Assert.AreEqual(3, result.Count, $"Should have 3 levels for {solutionName}");
            Assert.AreEqual(1, result[0].Count, $"Level 0 should have 1 node (2^0) for {solutionName}");
            Assert.AreEqual(2, result[1].Count, $"Level 1 should have 2 nodes (2^1) for {solutionName}");
            Assert.AreEqual(4, result[2].Count, $"Level 2 should have 4 nodes (2^2) for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void LevelOrder_ChildrenAppear_AfterParents(IBinaryTreeLevelOrderTraversal_102 solution, string solutionName)
        {
            // Verify that children always appear in later levels than parents

            // Arrange
            var root = CreateTree(new int?[] { 10, 5, 15, 3, 7, 12, 20 });

            // Act
            var result = solution.LevelOrder(root);

            // Assert
            // Level 0: [10]
            // Level 1: [5, 15] - children of 10
            // Level 2: [3, 7, 12, 20] - children of 5 and 15
            
            Assert.AreEqual(3, result.Count, $"Should have 3 levels for {solutionName}");
            
            // 10's children (5, 15) appear in level 1
            Assert.IsTrue(result[1].Contains(5), $"5 should be in level 1 for {solutionName}");
            Assert.IsTrue(result[1].Contains(15), $"15 should be in level 1 for {solutionName}");
            
            // 5's children (3, 7) and 15's children (12, 20) appear in level 2
            Assert.IsTrue(result[2].Contains(3), $"3 should be in level 2 for {solutionName}");
            Assert.IsTrue(result[2].Contains(7), $"7 should be in level 2 for {solutionName}");
            Assert.IsTrue(result[2].Contains(12), $"12 should be in level 2 for {solutionName}");
            Assert.IsTrue(result[2].Contains(20), $"20 should be in level 2 for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void LevelOrder_LeftToRight_OrderWithinLevel(IBinaryTreeLevelOrderTraversal_102 solution, string solutionName)
        {
            // Verify that nodes appear left-to-right within each level

            // Arrange
            var root = CreateTree(new int?[] { 1, 2, 3, 4, 5, 6, 7 });

            // Act
            var result = solution.LevelOrder(root);

            // Assert
            // Level 1: left child (2) should come before right child (3)
            Assert.AreEqual(2, result[1][0], $"Left child should come first in level 1 for {solutionName}");
            Assert.AreEqual(3, result[1][1], $"Right child should come second in level 1 for {solutionName}");
            
            // Level 2: 4, 5 (children of 2) should come before 6, 7 (children of 3)
            Assert.AreEqual(4, result[2][0], $"First should be leftmost grandchild for {solutionName}");
            Assert.AreEqual(5, result[2][1], $"Second should be next grandchild for {solutionName}");
            Assert.AreEqual(6, result[2][2], $"Third should be next grandchild for {solutionName}");
            Assert.AreEqual(7, result[2][3], $"Fourth should be rightmost grandchild for {solutionName}");
        }

        #endregion

        #region Boundary Cases

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void LevelOrder_MaxConstraintSize_ReturnsCorrectLevels(IBinaryTreeLevelOrderTraversal_102 solution, string solutionName)
        {
            // Create a reasonably large tree (50 nodes)

            // Arrange
            var values = Enumerable.Range(1, 50).Cast<int?>().ToArray();
            TreeNode root = CreateTree(values);

            // Act
            var result = solution.LevelOrder(root);

            // Assert
            // Verify all 50 nodes are present
            var allNodes = result.SelectMany(level => level).ToList();
            Assert.AreEqual(50, allNodes.Count, $"Should have 50 nodes total for {solutionName}");
            
            // Verify first level is root
            Assert.AreEqual(1, result[0][0], $"Root should be 1 for {solutionName}");
            
            // Verify all values are present
            var nodeSet = new HashSet<int>(allNodes);
            Assert.AreEqual(50, nodeSet.Count, $"All 50 values should be unique for {solutionName}");
        }

        #endregion
    }
}
