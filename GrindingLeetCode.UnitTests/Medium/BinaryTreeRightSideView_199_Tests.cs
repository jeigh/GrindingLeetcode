using LeetCodeProblems.CSharp.Tree;
using LeetCodeProblems.Interfaces.Medium;
using LeetCodeProblems.Shared;
using LeetCodeProblems.VisualBasic;

namespace GrindingLeetCode.UnitTests.Medium
{
    [TestClass]
    public class BinaryTreeRightSideView_199_Tests
    {
        public static IEnumerable<object[]> GetImplementations()
        {
            //yield return new object[] { new BinaryTreeRightSideView_IterativeInOrder_CSharp_199(), "C# Iterative In-Order" };
            //yield return new object[] { new BinaryTreeRightSideView_RecursiveInOrder_CSharp_199(), "C# Recursive In-Order" };
            yield return new object[] { new BinaryTreeRightSideView_IterativeInOrder_VB_199(), "VB Iterative In-Order" };
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
        public void RightSideView_Example1_ReturnsCorrectView(IBinaryTreeRightSideView_199 solution, string solutionName)
        {
            // Input: root = [1,2,3,null,5,null,4]
            //       1         <--- Looking from right, see 1
            //      / \
            //     2   3       <--- See 3 (rightmost at level 1)
            //      \   \
            //       5   4     <--- See 4 (rightmost at level 2)
            // Output: [1,3,4]

            // Arrange
            var root = CreateTree(new int?[] { 1, 2, 3, null, 5, null, 4 });

            // Act
            var result = solution.RightSideView(root);

            // Assert
            CollectionAssert.AreEqual(new[] { 1, 3, 4 }, result.ToArray(), $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void RightSideView_Example2_ReturnsCorrectView(IBinaryTreeRightSideView_199 solution, string solutionName)
        {
            // Input: root = [1,null,3]
            //    1          <--- See 1
            //     \
            //      3        <--- See 3
            // Output: [1,3]

            // Arrange
            var root = CreateTree(new int?[] { 1, null, 3 });

            // Act
            var result = solution.RightSideView(root);

            // Assert
            CollectionAssert.AreEqual(new[] { 1, 3 }, result.ToArray(), $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void RightSideView_Example3_EmptyTree_ReturnsEmpty(IBinaryTreeRightSideView_199 solution, string solutionName)
        {
            // Input: root = []
            // Output: []

            // Arrange
            TreeNode root = null;

            // Act
            var result = solution.RightSideView(root);

            // Assert
            Assert.AreEqual(0, result.Count, $"Failed for {solutionName}");
        }

        #endregion

        #region Basic Tree Structures

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void RightSideView_SingleNode_ReturnsSingleValue(IBinaryTreeRightSideView_199 solution, string solutionName)
        {
            // Tree:  5
            // Right Side View: [5]

            // Arrange
            var root = new TreeNode(5);

            // Act
            var result = solution.RightSideView(root);

            // Assert
            CollectionAssert.AreEqual(new[] { 5 }, result.ToArray(), $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void RightSideView_TwoNodesLeftChild_ReturnsRootThenLeft(IBinaryTreeRightSideView_199 solution, string solutionName)
        {
            // Tree:  2
            //       /
            //      1
            // Right Side View: [2, 1]

            // Arrange
            var root = CreateSimpleTree(2, left: 1);

            // Act
            var result = solution.RightSideView(root);

            // Assert
            CollectionAssert.AreEqual(new[] { 2, 1 }, result.ToArray(), $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void RightSideView_TwoNodesRightChild_ReturnsRootThenRight(IBinaryTreeRightSideView_199 solution, string solutionName)
        {
            // Tree:  1
            //         \
            //          2
            // Right Side View: [1, 2]

            // Arrange
            var root = CreateSimpleTree(1, right: 2);

            // Act
            var result = solution.RightSideView(root);

            // Assert
            CollectionAssert.AreEqual(new[] { 1, 2 }, result.ToArray(), $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void RightSideView_ThreeNodesComplete_ReturnsRootThenRight(IBinaryTreeRightSideView_199 solution, string solutionName)
        {
            // Tree:    2
            //         / \
            //        1   3
            // Right Side View: [2, 3]

            // Arrange
            var root = CreateSimpleTree(2, left: 1, right: 3);

            // Act
            var result = solution.RightSideView(root);

            // Assert
            CollectionAssert.AreEqual(new[] { 2, 3 }, result.ToArray(), $"Failed for {solutionName}");
        }

        #endregion

        #region Balanced Trees

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void RightSideView_BalancedTree7Nodes_ReturnsRightmostPerLevel(IBinaryTreeRightSideView_199 solution, string solutionName)
        {
            // Tree:       4
            //           /   \
            //          2     6
            //         / \   / \
            //        1   3 5   7
            // Right Side View: [4, 6, 7]

            // Arrange
            var root = CreateTree(new int?[] { 4, 2, 6, 1, 3, 5, 7 });

            // Act
            var result = solution.RightSideView(root);

            // Assert
            CollectionAssert.AreEqual(new[] { 4, 6, 7 }, result.ToArray(), $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void RightSideView_BalancedTree15Nodes_ReturnsRightmostPerLevel(IBinaryTreeRightSideView_199 solution, string solutionName)
        {
            // Tree:              8
            //                /       \
            //               4         12
            //             /   \      /   \
            //            2     6    10    14
            //           / \   / \   / \   / \
            //          1   3 5   7 9  11 13 15
            // Right Side View: [8, 12, 14, 15]

            // Arrange
            var root = CreateTree(new int?[] { 8, 4, 12, 2, 6, 10, 14, 1, 3, 5, 7, 9, 11, 13, 15 });

            // Act
            var result = solution.RightSideView(root);

            // Assert
            CollectionAssert.AreEqual(new[] { 8, 12, 14, 15 }, result.ToArray(), $"Failed for {solutionName}");
        }

        #endregion

        #region Skewed Trees

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void RightSideView_LeftSkewedTree_ReturnsAllNodes(IBinaryTreeRightSideView_199 solution, string solutionName)
        {
            // Tree:      5
            //           /
            //          4
            //         /
            //        3
            //       /
            //      2
            //     /
            //    1
            // Right Side View: [5, 4, 3, 2, 1]

            // Arrange
            var root = CreateTree(new int?[] { 5, 4, null, 3, null, 2, null, 1 });

            // Act
            var result = solution.RightSideView(root);

            // Assert
            CollectionAssert.AreEqual(new[] { 5, 4, 3, 2, 1 }, result.ToArray(), $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void RightSideView_RightSkewedTree_ReturnsAllNodes(IBinaryTreeRightSideView_199 solution, string solutionName)
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
            // Right Side View: [1, 2, 3, 4, 5]

            // Arrange
            var root = CreateTree(new int?[] { 1, null, 2, null, 3, null, 4, null, 5 });

            // Act
            var result = solution.RightSideView(root);

            // Assert
            CollectionAssert.AreEqual(new[] { 1, 2, 3, 4, 5 }, result.ToArray(), $"Failed for {solutionName}");
        }

        #endregion

        #region Left Deeper Than Right

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void RightSideView_LeftSubtreeDeeperThanRight_ReturnsLeftLeaf(IBinaryTreeRightSideView_199 solution, string solutionName)
        {
            // Tree:        5
            //            /   \
            //           3     6
            //          / \
            //         2   4
            //        /
            //       1
            // Right Side View: [5, 6, 4, 1]
            // Note: At depth 3, only left subtree has a node (1), so it's visible

            // Arrange
            var root = CreateTree(new int?[] { 5, 3, 6, 2, 4, null, null, 1 });

            // Act
            var result = solution.RightSideView(root);

            // Assert
            CollectionAssert.AreEqual(new[] { 5, 6, 4, 1 }, result.ToArray(), $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void RightSideView_LeftDeepWithMultipleLevels_ReturnsCorrectView(IBinaryTreeRightSideView_199 solution, string solutionName)
        {
            // Tree:        10
            //            /    \
            //           5     15
            //          / \
            //         3   7
            //        /
            //       1
            //        \
            //         2
            // Right Side View: [10, 15, 7, 1, 2]

            // Arrange
            var root = CreateTree(new int?[] { 10, 5, 15, 3, 7, null, null, 1, null, null, null, null, 2 });

            // Act
            var result = solution.RightSideView(root);

            // Assert
            CollectionAssert.AreEqual(new[] { 10, 15, 7, 1, 2 }, result.ToArray(), $"Failed for {solutionName}");
        }

        #endregion

        #region Sparse Trees

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void RightSideView_SparseTree_ReturnsCorrectView(IBinaryTreeRightSideView_199 solution, string solutionName)
        {
            // Tree:       8
            //           /   \
            //          4     12
            //           \   /
            //            6 10
            // Right Side View: [8, 12, 10]

            // Arrange
            var root = CreateTree(new int?[] { 8, 4, 12, null, 6, 10 });

            // Act
            var result = solution.RightSideView(root);

            // Assert
            CollectionAssert.AreEqual(new[] { 8, 12, 10 }, result.ToArray(), $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void RightSideView_SparseWithOnlyLeftAtBottom_ReturnsLeftNode(IBinaryTreeRightSideView_199 solution, string solutionName)
        {
            // Tree:           10
            //              /      \
            //             5        15
            //           /            
            //          3             
            //           \           
            //            4         
            // Right Side View: [10, 15, 3, 4]

            // Arrange
            var root = CreateTree(new int?[] { 10, 5, 15, 3, null, null, null, null, 4 });

            // Act
            var result = solution.RightSideView(root);

            // Assert
            CollectionAssert.AreEqual(new[] { 10, 15, 3, 4 }, result.ToArray(), $"Failed for {solutionName}");
        }

        #endregion

        #region Edge Cases - Values

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void RightSideView_NegativeValues_ReturnsCorrectView(IBinaryTreeRightSideView_199 solution, string solutionName)
        {
            // Tree:      0
            //          /   \
            //        -2     2
            //        / \   / \
            //      -3 -1  1  3
            // Right Side View: [0, 2, 3]

            // Arrange
            var root = CreateTree(new int?[] { 0, -2, 2, -3, -1, 1, 3 });

            // Act
            var result = solution.RightSideView(root);

            // Assert
            CollectionAssert.AreEqual(new[] { 0, 2, 3 }, result.ToArray(), $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void RightSideView_AllNegativeValues_ReturnsCorrectView(IBinaryTreeRightSideView_199 solution, string solutionName)
        {
            // Tree:      -4
            //           /   \
            //         -6    -2
            //         / \   / \
            //       -7 -5 -3 -1
            // Right Side View: [-4, -2, -1]

            // Arrange
            var root = CreateTree(new int?[] { -4, -6, -2, -7, -5, -3, -1 });

            // Act
            var result = solution.RightSideView(root);

            // Assert
            CollectionAssert.AreEqual(new[] { -4, -2, -1 }, result.ToArray(), $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void RightSideView_DuplicateValues_ReturnsCorrectView(IBinaryTreeRightSideView_199 solution, string solutionName)
        {
            // Tree:      2
            //           / \
            //          2   2
            //         / \
            //        1   2
            // Right Side View: [2, 2, 2]

            // Arrange
            var root = CreateTree(new int?[] { 2, 2, 2, 1, 2 });

            // Act
            var result = solution.RightSideView(root);

            // Assert
            CollectionAssert.AreEqual(new[] { 2, 2, 2 }, result.ToArray(), $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void RightSideView_AllSameValues_ReturnsCorrectView(IBinaryTreeRightSideView_199 solution, string solutionName)
        {
            // Tree:      5
            //           / \
            //          5   5
            //         / \
            //        5   5
            // Right Side View: [5, 5, 5]

            // Arrange
            var root = CreateTree(new int?[] { 5, 5, 5, 5, 5 });

            // Act
            var result = solution.RightSideView(root);

            // Assert
            CollectionAssert.AreEqual(new[] { 5, 5, 5 }, result.ToArray(), $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void RightSideView_ZeroValue_ReturnsCorrectView(IBinaryTreeRightSideView_199 solution, string solutionName)
        {
            // Tree:      0
            //           / \
            //          0   0
            // Right Side View: [0, 0]

            // Arrange
            var root = CreateSimpleTree(0, left: 0, right: 0);

            // Act
            var result = solution.RightSideView(root);

            // Assert
            CollectionAssert.AreEqual(new[] { 0, 0 }, result.ToArray(), $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void RightSideView_LargeValues_ReturnsCorrectView(IBinaryTreeRightSideView_199 solution, string solutionName)
        {
            // Tree:      1000
            //           /     \
            //         100    10000
            // Right Side View: [1000, 10000]

            // Arrange
            var root = CreateSimpleTree(1000, left: 100, right: 10000);

            // Act
            var result = solution.RightSideView(root);

            // Assert
            CollectionAssert.AreEqual(new[] { 1000, 10000 }, result.ToArray(), $"Failed for {solutionName}");
        }

        #endregion

        #region Complex Trees

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void RightSideView_ComplexTree_ReturnsCorrectView(IBinaryTreeRightSideView_199 solution, string solutionName)
        {
            // Tree:           10
            //              /      \
            //             5        15
            //           /   \        \
            //          3     7       20
            //         / \     \
            //        1   4     9
            // Right Side View: [10, 15, 20, 9]

            // Arrange
            var root = CreateTree(new int?[] { 10, 5, 15, 3, 7, null, 20, 1, 4, null, 9 });

            // Act
            var result = solution.RightSideView(root);

            // Assert
            CollectionAssert.AreEqual(new[] { 10, 15, 20, 9 }, result.ToArray(), $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void RightSideView_AsymmetricTree_ReturnsCorrectView(IBinaryTreeRightSideView_199 solution, string solutionName)
        {
            // Tree:           1
            //              /    \
            //             2      3
            //            /        \
            //           4          5
            //          /            \
            //         6              7
            // Right Side View: [1, 3, 5, 7]

            // Arrange
            var root = CreateTree(new int?[] { 1, 2, 3, 4, null, null, 5, 6, null, null, 7 });

            // Act
            var result = solution.RightSideView(root);

            // Assert
            CollectionAssert.AreEqual(new[] { 1, 3, 5, 7 }, result.ToArray(), $"Failed for {solutionName}");
        }

        #endregion

        #region Larger Trees

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void RightSideView_LargeBalancedTree31Nodes_ReturnsCorrectView(IBinaryTreeRightSideView_199 solution, string solutionName)
        {
            // Perfect binary tree with 5 levels (31 nodes)
            // Right Side View should have 5 elements (one per level)

            // Arrange
            var root = CreateTree(new int?[] { 
                16, 8, 24, 4, 12, 20, 28, 2, 6, 10, 14, 18, 22, 26, 30,
                1, 3, 5, 7, 9, 11, 13, 15, 17, 19, 21, 23, 25, 27, 29, 31
            });

            // Act
            var result = solution.RightSideView(root);

            // Assert
            CollectionAssert.AreEqual(new[] { 16, 24, 28, 30, 31 }, result.ToArray(), $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void RightSideView_DeepLeftSkewed10Nodes_ReturnsAllNodes(IBinaryTreeRightSideView_199 solution, string solutionName)
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
            var result = solution.RightSideView(root);

            // Assert
            var expected = new[] { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 };
            CollectionAssert.AreEqual(expected, result.ToArray(), $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void RightSideView_DeepRightSkewed10Nodes_ReturnsAllNodes(IBinaryTreeRightSideView_199 solution, string solutionName)
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
            var result = solution.RightSideView(root);

            // Assert
            var expected = Enumerable.Range(1, 10).ToArray();
            CollectionAssert.AreEqual(expected, result.ToArray(), $"Failed for {solutionName}");
        }

        #endregion

        #region Special Patterns

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void RightSideView_ZigZagPattern_ReturnsCorrectView(IBinaryTreeRightSideView_199 solution, string solutionName)
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
            // Right Side View: [1, 2, 3, 4, 5]

            // Arrange
            var root = new TreeNode(1);
            root.right = new TreeNode(2);
            root.right.left = new TreeNode(3);
            root.right.left.right = new TreeNode(4);
            root.right.left.right.left = new TreeNode(5);

            // Act
            var result = solution.RightSideView(root);

            // Assert
            CollectionAssert.AreEqual(new[] { 1, 2, 3, 4, 5 }, result.ToArray(), $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void RightSideView_AlternatingLeftRight_ReturnsCorrectView(IBinaryTreeRightSideView_199 solution, string solutionName)
        {
            // Tree:        1
            //            /   \
            //           2     3
            //          /     /
            //         4     5
            //          \   /
            //           6 7
            // Right Side View: [1, 3, 5, 7]

            // Arrange
            var root = CreateTree(new int?[] { 1, 2, 3, 4, null, 5, null, null, 6, 7 });

            // Act
            var result = solution.RightSideView(root);

            // Assert
            CollectionAssert.AreEqual(new[] { 1, 3, 5, 7 }, result.ToArray(), $"Failed for {solutionName}");
        }

        #endregion

        #region Property Tests

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void RightSideView_FirstElementAlwaysRoot(IBinaryTreeRightSideView_199 solution, string solutionName)
        {
            // Verify that first element is always the root value

            // Arrange - Multiple different trees
            var root1 = CreateSimpleTree(100, left: 1, right: 2);
            var root2 = CreateTree(new int?[] { 50, 25, 75, 10, 30, 60, 80 });
            var root3 = CreateTree(new int?[] { -5, -10, 5 });

            // Act
            var result1 = solution.RightSideView(root1);
            var result2 = solution.RightSideView(root2);
            var result3 = solution.RightSideView(root3);

            // Assert
            Assert.AreEqual(100, result1[0], $"First element should be root for {solutionName}");
            Assert.AreEqual(50, result2[0], $"First element should be root for {solutionName}");
            Assert.AreEqual(-5, result3[0], $"First element should be root for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void RightSideView_ResultSizeEqualsTreeHeight(IBinaryTreeRightSideView_199 solution, string solutionName)
        {
            // Verify that result size equals tree height (number of levels)

            // Arrange - Tree with known height of 3
            var root = CreateTree(new int?[] { 4, 2, 6, 1, 3, 5, 7 });

            // Act
            var result = solution.RightSideView(root);

            // Assert
            Assert.AreEqual(3, result.Count, $"Result size should equal tree height for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void RightSideView_OnlyRightChildren_ReturnsAllValues(IBinaryTreeRightSideView_199 solution, string solutionName)
        {
            // For a tree with only right children, all nodes should be visible

            // Arrange
            var root = CreateTree(new int?[] { 7, null, 8, null, 9, null, 10 });

            // Act
            var result = solution.RightSideView(root);

            // Assert
            CollectionAssert.AreEqual(new[] { 7, 8, 9, 10 }, result.ToArray(), $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void RightSideView_OnlyLeftChildren_ReturnsAllValues(IBinaryTreeRightSideView_199 solution, string solutionName)
        {
            // For a tree with only left children, all nodes should be visible (from right side)

            // Arrange
            var root = CreateTree(new int?[] { 10, 9, null, 8, null, 7 });

            // Act
            var result = solution.RightSideView(root);

            // Assert
            CollectionAssert.AreEqual(new[] { 10, 9, 8, 7 }, result.ToArray(), $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void RightSideView_AllValuesUnique_InResult(IBinaryTreeRightSideView_199 solution, string solutionName)
        {
            // For a tree with unique values, result should have all unique values

            // Arrange
            var root = CreateTree(new int?[] { 1, 2, 3, 4, 5, 6, 7 });

            // Act
            var result = solution.RightSideView(root);

            // Assert
            var distinctCount = result.Distinct().Count();
            Assert.AreEqual(result.Count, distinctCount, $"All values in result should be unique for {solutionName}");
        }

        #endregion

        #region Boundary Cases

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void RightSideView_MaxConstraintSize_ReturnsCorrectView(IBinaryTreeRightSideView_199 solution, string solutionName)
        {
            // Create a reasonably large tree (50 nodes)

            // Arrange
            var values = Enumerable.Range(1, 50).Cast<int?>().ToArray();
            TreeNode root = CreateTree(values);

            // Act
            var result = solution.RightSideView(root);

            // Assert
            // For a complete binary tree with 50 nodes, height is ceil(log2(51)) = 6
            Assert.IsTrue(result.Count > 0, $"Should have results for {solutionName}");
            Assert.AreEqual(1, result[0], $"First element should be root for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void RightSideView_TwoLevelTree_ReturnsTwo(IBinaryTreeRightSideView_199 solution, string solutionName)
        {
            // Simple two-level tree

            // Arrange
            var root = CreateTree(new int?[] { 1, 2, 3, 4, 5 });

            // Act
            var result = solution.RightSideView(root);

            // Assert
            CollectionAssert.AreEqual(new[] { 1, 3, 5 }, result.ToArray(), $"Failed for {solutionName}");
        }

        #endregion

        #region Comparison with Level Order

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void RightSideView_ComparedToLevelOrder_IsRightmostPerLevel(IBinaryTreeRightSideView_199 solution, string solutionName)
        {
            // Right side view should be the last element of each level in level order traversal

            // Arrange
            var root = CreateTree(new int?[] { 1, 2, 3, 4, 5, 6, 7 });

            // Act
            var rightView = solution.RightSideView(root);

            // Assert
            // Level order would be: [[1], [2, 3], [4, 5, 6, 7]]
            // Right side view: [1, 3, 7] - last element of each level
            CollectionAssert.AreEqual(new[] { 1, 3, 7 }, rightView.ToArray(), $"Failed for {solutionName}");
        }

        #endregion
    }
}
