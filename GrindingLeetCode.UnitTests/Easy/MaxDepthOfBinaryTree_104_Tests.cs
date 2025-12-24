using LeetCodeProblems.CSharp.Tree;
using LeetCodeProblems.Interfaces.Easy;
using LeetCodeProblems.Shared;
using LeetCodeProblems.VisualBasic;

namespace GrindingLeetCode.UnitTests.Easy
{
    [TestClass]
    public class MaxDepthOfBinaryTree_104_Tests
    {
        public static IEnumerable<object[]> GetImplementations()
        {
            yield return new object[] { new MaxDepthOfBinaryTree_Recursive_CSharp_104(), "C# Recursive" };
            yield return new object[] { new MaxDepthOfBinaryTree_Stack_CSharp_104(), "C# Stack" };
            yield return new object[] { new MaxDepthOfBinaryTree_Recursive_VB_104(), "VB Recursive" };
            yield return new object[] { new MaxDepthOfBinaryTree_Stack_VB_104(), "VB Stack" };
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
        public void MaxDepth_Example1_Returns3(IMaxDepthOfBinaryTree_104 solution, string solutionName)
        {
            // Input: root = [3,9,20,null,null,15,7]
            //       3
            //      / \
            //     9  20
            //       /  \
            //      15   7
            // Output: 3

            // Arrange
            var root = CreateTree(new int?[] { 3, 9, 20, null, null, 15, 7 });

            // Act
            var result = solution.MaxDepth(root);

            // Assert
            Assert.AreEqual(3, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void MaxDepth_Example2_Returns2(IMaxDepthOfBinaryTree_104 solution, string solutionName)
        {
            // Input: root = [1,null,2]
            //   1
            //    \
            //     2
            // Output: 2

            // Arrange
            var root = CreateTree(new int?[] { 1, null, 2 });

            // Act
            var result = solution.MaxDepth(root);

            // Assert
            Assert.AreEqual(2, result, $"Failed for {solutionName}");
        }

        #endregion

        #region Basic Tree Structures

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void MaxDepth_NullTree_Returns0(IMaxDepthOfBinaryTree_104 solution, string solutionName)
        {
            // Input: root = []
            // Output: 0

            // Arrange
            TreeNode root = null;

            // Act
            var result = solution.MaxDepth(root);

            // Assert
            Assert.AreEqual(0, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void MaxDepth_SingleNode_Returns1(IMaxDepthOfBinaryTree_104 solution, string solutionName)
        {
            // Input: root = [5]
            // Output: 1

            // Arrange
            var root = new TreeNode(5);

            // Act
            var result = solution.MaxDepth(root);

            // Assert
            Assert.AreEqual(1, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void MaxDepth_TwoNodesLeftChild_Returns2(IMaxDepthOfBinaryTree_104 solution, string solutionName)
        {
            // Input:  2
            //        /
            //       1
            // Output: 2

            // Arrange
            var root = CreateSimpleTree(2, left: 1);

            // Act
            var result = solution.MaxDepth(root);

            // Assert
            Assert.AreEqual(2, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void MaxDepth_TwoNodesRightChild_Returns2(IMaxDepthOfBinaryTree_104 solution, string solutionName)
        {
            // Input:  1
            //          \
            //           2
            // Output: 2

            // Arrange
            var root = CreateSimpleTree(1, right: 2);

            // Act
            var result = solution.MaxDepth(root);

            // Assert
            Assert.AreEqual(2, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void MaxDepth_ThreeNodesComplete_Returns2(IMaxDepthOfBinaryTree_104 solution, string solutionName)
        {
            // Input:    2
            //          / \
            //         1   3
            // Output: 2

            // Arrange
            var root = CreateSimpleTree(2, left: 1, right: 3);

            // Act
            var result = solution.MaxDepth(root);

            // Assert
            Assert.AreEqual(2, result, $"Failed for {solutionName}");
        }

        #endregion

        #region Balanced Trees

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void MaxDepth_BalancedTree7Nodes_Returns3(IMaxDepthOfBinaryTree_104 solution, string solutionName)
        {
            // Input:       4
            //            /   \
            //           2     6
            //          / \   / \
            //         1   3 5   7
            // Output: 3

            // Arrange
            var root = CreateTree(new int?[] { 4, 2, 6, 1, 3, 5, 7 });

            // Act
            var result = solution.MaxDepth(root);

            // Assert
            Assert.AreEqual(3, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void MaxDepth_BalancedTree15Nodes_Returns4(IMaxDepthOfBinaryTree_104 solution, string solutionName)
        {
            // Input:              8
            //                /       \
            //               4         12
            //             /   \      /   \
            //            2     6    10    14
            //           / \   / \   / \   / \
            //          1   3 5   7 9  11 13 15
            // Output: 4

            // Arrange
            var root = CreateTree(new int?[] { 8, 4, 12, 2, 6, 10, 14, 1, 3, 5, 7, 9, 11, 13, 15 });

            // Act
            var result = solution.MaxDepth(root);

            // Assert
            Assert.AreEqual(4, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void MaxDepth_BalancedTree31Nodes_Returns5(IMaxDepthOfBinaryTree_104 solution, string solutionName)
        {
            // Complete balanced tree with 5 levels
            // Output: 5

            // Arrange
            var root = CreateTree(new int?[] { 
                16, 8, 24, 4, 12, 20, 28, 2, 6, 10, 14, 18, 22, 26, 30,
                1, 3, 5, 7, 9, 11, 13, 15, 17, 19, 21, 23, 25, 27, 29, 31
            });

            // Act
            var result = solution.MaxDepth(root);

            // Assert
            Assert.AreEqual(5, result, $"Failed for {solutionName}");
        }

        #endregion

        #region Left-Skewed Trees

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void MaxDepth_LeftSkewedTree3Nodes_Returns3(IMaxDepthOfBinaryTree_104 solution, string solutionName)
        {
            // Input:      3
            //            /
            //           2
            //          /
            //         1
            // Output: 3

            // Arrange
            var root = CreateTree(new int?[] { 3, 2, null, 1 });

            // Act
            var result = solution.MaxDepth(root);

            // Assert
            Assert.AreEqual(3, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void MaxDepth_LeftSkewedTree5Nodes_Returns5(IMaxDepthOfBinaryTree_104 solution, string solutionName)
        {
            // Input:          5
            //                /
            //               4
            //              /
            //             3
            //            /
            //           2
            //          /
            //         1
            // Output: 5

            // Arrange
            var root = CreateTree(new int?[] { 5, 4, null, 3, null, 2, null, 1 });

            // Act
            var result = solution.MaxDepth(root);

            // Assert
            Assert.AreEqual(5, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void MaxDepth_LeftSkewedTree10Nodes_Returns10(IMaxDepthOfBinaryTree_104 solution, string solutionName)
        {
            // Deep left-skewed tree
            // Output: 10

            // Arrange
            TreeNode root = new TreeNode(10);
            TreeNode current = root;
            for (int i = 9; i >= 1; i--)
            {
                current.left = new TreeNode(i);
                current = current.left;
            }

            // Act
            var result = solution.MaxDepth(root);

            // Assert
            Assert.AreEqual(10, result, $"Failed for {solutionName}");
        }

        #endregion

        #region Right-Skewed Trees

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void MaxDepth_RightSkewedTree3Nodes_Returns3(IMaxDepthOfBinaryTree_104 solution, string solutionName)
        {
            // Input:  1
            //          \
            //           2
            //            \
            //             3
            // Output: 3

            // Arrange
            var root = CreateTree(new int?[] { 1, null, 2, null, 3 });

            // Act
            var result = solution.MaxDepth(root);

            // Assert
            Assert.AreEqual(3, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void MaxDepth_RightSkewedTree5Nodes_Returns5(IMaxDepthOfBinaryTree_104 solution, string solutionName)
        {
            // Input:  1
            //          \
            //           2
            //            \
            //             3
            //              \
            //               4
            //                \
            //                 5
            // Output: 5

            // Arrange
            var root = CreateTree(new int?[] { 1, null, 2, null, 3, null, 4, null, 5 });

            // Act
            var result = solution.MaxDepth(root);

            // Assert
            Assert.AreEqual(5, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void MaxDepth_RightSkewedTree10Nodes_Returns10(IMaxDepthOfBinaryTree_104 solution, string solutionName)
        {
            // Deep right-skewed tree
            // Output: 10

            // Arrange
            TreeNode root = new TreeNode(1);
            TreeNode current = root;
            for (int i = 2; i <= 10; i++)
            {
                current.right = new TreeNode(i);
                current = current.right;
            }

            // Act
            var result = solution.MaxDepth(root);

            // Assert
            Assert.AreEqual(10, result, $"Failed for {solutionName}");
        }

        #endregion

        #region Unbalanced Trees

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void MaxDepth_UnbalancedLeftHeavy_Returns4(IMaxDepthOfBinaryTree_104 solution, string solutionName)
        {
            // Input:        5
            //             /   \
            //            3     6
            //           / \
            //          2   4
            //         /
            //        1
            // Output: 4

            // Arrange
            var root = CreateTree(new int?[] { 5, 3, 6, 2, 4, null, null, 1 });

            // Act
            var result = solution.MaxDepth(root);

            // Assert
            Assert.AreEqual(4, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void MaxDepth_UnbalancedRightHeavy_Returns4(IMaxDepthOfBinaryTree_104 solution, string solutionName)
        {
            // Input:    1
            //          / \
            //         0   3
            //            / \
            //           2   4
            //                \
            //                 5
            // Output: 4

            // Arrange
            var root = CreateTree(new int?[] { 1, 0, 3, null, null, 2, 4, null, null, null, 5 });

            // Act
            var result = solution.MaxDepth(root);

            // Assert
            Assert.AreEqual(4, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void MaxDepth_UnbalancedMixed_ReturnsMaxDepth(IMaxDepthOfBinaryTree_104 solution, string solutionName)
        {
            // Input:           10
            //               /      \
            //              5        15
            //            /   \        \
            //           3     7       20
            //          / \     \     /  \
            //         1   4     9   18  22
            //                      /
            //                     17
            // Output: 5

            // Arrange
            var root = CreateTree(new int?[] { 10, 5, 15, 3, 7, null, 20, 1, 4, null, 9, 18, 22, null, null, null, null, null, null, 17 });

            // Act
            var result = solution.MaxDepth(root);

            // Assert
            Assert.AreEqual(5, result, $"Failed for {solutionName}");
        }

        #endregion

        #region Edge Cases - Values

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void MaxDepth_NegativeValues_ReturnsCorrectDepth(IMaxDepthOfBinaryTree_104 solution, string solutionName)
        {
            // Input:       0
            //            /   \
            //          -2     2
            //          / \   / \
            //        -3 -1  1  3
            // Output: 3

            // Arrange
            var root = CreateTree(new int?[] { 0, -2, 2, -3, -1, 1, 3 });

            // Act
            var result = solution.MaxDepth(root);

            // Assert
            Assert.AreEqual(3, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void MaxDepth_AllNegativeValues_ReturnsCorrectDepth(IMaxDepthOfBinaryTree_104 solution, string solutionName)
        {
            // Input:       -4
            //            /    \
            //          -6     -2
            //          / \    / \
            //        -7 -5  -3 -1
            // Output: 3

            // Arrange
            var root = CreateTree(new int?[] { -4, -6, -2, -7, -5, -3, -1 });

            // Act
            var result = solution.MaxDepth(root);

            // Assert
            Assert.AreEqual(3, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void MaxDepth_DuplicateValues_ReturnsCorrectDepth(IMaxDepthOfBinaryTree_104 solution, string solutionName)
        {
            // Input:      2
            //            / \
            //           2   2
            //          / \
            //         1   2
            // Output: 3

            // Arrange
            var root = CreateTree(new int?[] { 2, 2, 2, 1, 2 });

            // Act
            var result = solution.MaxDepth(root);

            // Assert
            Assert.AreEqual(3, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void MaxDepth_AllSameValues_ReturnsCorrectDepth(IMaxDepthOfBinaryTree_104 solution, string solutionName)
        {
            // Input:      5
            //            / \
            //           5   5
            //          / \
            //         5   5
            // Output: 3

            // Arrange
            var root = CreateTree(new int?[] { 5, 5, 5, 5, 5 });

            // Act
            var result = solution.MaxDepth(root);

            // Assert
            Assert.AreEqual(3, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void MaxDepth_ZeroValue_ReturnsCorrectDepth(IMaxDepthOfBinaryTree_104 solution, string solutionName)
        {
            // Input:      0
            //            / \
            //           0   0
            // Output: 2

            // Arrange
            var root = CreateSimpleTree(0, left: 0, right: 0);

            // Act
            var result = solution.MaxDepth(root);

            // Assert
            Assert.AreEqual(2, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void MaxDepth_LargeValues_ReturnsCorrectDepth(IMaxDepthOfBinaryTree_104 solution, string solutionName)
        {
            // Input:      1000
            //            /    \
            //          100   10000
            // Output: 2

            // Arrange
            var root = CreateSimpleTree(1000, left: 100, right: 10000);

            // Act
            var result = solution.MaxDepth(root);

            // Assert
            Assert.AreEqual(2, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void MaxDepth_MinMaxIntValues_ReturnsCorrectDepth(IMaxDepthOfBinaryTree_104 solution, string solutionName)
        {
            // Input:        0
            //            /     \
            //       -100000   100000
            // Output: 2

            // Arrange
            var root = CreateSimpleTree(0, left: -100000, right: 100000);

            // Act
            var result = solution.MaxDepth(root);

            // Assert
            Assert.AreEqual(2, result, $"Failed for {solutionName}");
        }

        #endregion

        #region Complex Trees

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void MaxDepth_ComplexTree_ReturnsCorrectDepth(IMaxDepthOfBinaryTree_104 solution, string solutionName)
        {
            // Input:           10
            //               /      \
            //              5        15
            //            /   \        \
            //           3     7       20
            //          / \     \
            //         1   4     9
            // Output: 4

            // Arrange
            var root = CreateTree(new int?[] { 10, 5, 15, 3, 7, null, 20, 1, 4, null, 9 });

            // Act
            var result = solution.MaxDepth(root);

            // Assert
            Assert.AreEqual(4, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void MaxDepth_SparseTree_ReturnsCorrectDepth(IMaxDepthOfBinaryTree_104 solution, string solutionName)
        {
            // Input:       8
            //            /   \
            //           4     12
            //            \   /
            //             6 10
            // Output: 3

            // Arrange
            var root = CreateTree(new int?[] { 8, 4, 12, null, 6, 10 });

            // Act
            var result = solution.MaxDepth(root);

            // Assert
            Assert.AreEqual(3, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void MaxDepth_OnlyLeftSubtree_ReturnsCorrectDepth(IMaxDepthOfBinaryTree_104 solution, string solutionName)
        {
            // Input:        10
            //              /
            //             5
            //            / \
            //           3   7
            //          /
            //         1
            // Output: 4

            // Arrange
            var root = CreateTree(new int?[] { 10, 5, null, 3, 7, 1 });

            // Act
            var result = solution.MaxDepth(root);

            // Assert
            Assert.AreEqual(4, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void MaxDepth_OnlyRightSubtree_ReturnsCorrectDepth(IMaxDepthOfBinaryTree_104 solution, string solutionName)
        {
            // Input:     5
            //             \
            //              15
            //             /  \
            //            12  20
            //                 \
            //                  25
            // Output: 4

            // Arrange
            var root = CreateTree(new int?[] { 5, null, 15, 12, 20, null, null, null, 25 });

            // Act
            var result = solution.MaxDepth(root);

            // Assert
            Assert.AreEqual(4, result, $"Failed for {solutionName}");
        }

        #endregion

        #region Special Patterns

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void MaxDepth_ZigZagPattern_ReturnsCorrectDepth(IMaxDepthOfBinaryTree_104 solution, string solutionName)
        {
            // Input:    1
            //            \
            //             2
            //            /
            //           3
            //            \
            //             4
            //            /
            //           5
            // Output: 5

            // Arrange
            var root = new TreeNode(1);
            root.right = new TreeNode(2);
            root.right.left = new TreeNode(3);
            root.right.left.right = new TreeNode(4);
            root.right.left.right.left = new TreeNode(5);

            // Act
            var result = solution.MaxDepth(root);

            // Assert
            Assert.AreEqual(5, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void MaxDepth_SymmetricTree_ReturnsCorrectDepth(IMaxDepthOfBinaryTree_104 solution, string solutionName)
        {
            // Input:      1
            //            / \
            //           2   2
            //          / \ / \
            //         3  4 4  3
            // Output: 3

            // Arrange
            var root = CreateTree(new int?[] { 1, 2, 2, 3, 4, 4, 3 });

            // Act
            var result = solution.MaxDepth(root);

            // Assert
            Assert.AreEqual(3, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void MaxDepth_AlternatingChildren_ReturnsCorrectDepth(IMaxDepthOfBinaryTree_104 solution, string solutionName)
        {
            // Input:       1
            //             /
            //            2
            //             \
            //              3
            //             /
            //            4
            //             \
            //              5
            // Output: 5

            // Arrange
            var root = new TreeNode(1);
            root.left = new TreeNode(2);
            root.left.right = new TreeNode(3);
            root.left.right.left = new TreeNode(4);
            root.left.right.left.right = new TreeNode(5);

            // Act
            var result = solution.MaxDepth(root);

            // Assert
            Assert.AreEqual(5, result, $"Failed for {solutionName}");
        }

        #endregion

        #region Larger Trees

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void MaxDepth_VeryDeepLeftSkewed_ReturnsCorrectDepth(IMaxDepthOfBinaryTree_104 solution, string solutionName)
        {
            // Deep left-skewed tree (50 nodes)
            // Output: 50

            // Arrange
            TreeNode root = new TreeNode(50);
            TreeNode current = root;
            for (int i = 49; i >= 1; i--)
            {
                current.left = new TreeNode(i);
                current = current.left;
            }

            // Act
            var result = solution.MaxDepth(root);

            // Assert
            Assert.AreEqual(50, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void MaxDepth_VeryDeepRightSkewed_ReturnsCorrectDepth(IMaxDepthOfBinaryTree_104 solution, string solutionName)
        {
            // Deep right-skewed tree (50 nodes)
            // Output: 50

            // Arrange
            TreeNode root = new TreeNode(1);
            TreeNode current = root;
            for (int i = 2; i <= 50; i++)
            {
                current.right = new TreeNode(i);
                current = current.right;
            }

            // Act
            var result = solution.MaxDepth(root);

            // Assert
            Assert.AreEqual(50, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void MaxDepth_LargeBalancedTree_ReturnsCorrectDepth(IMaxDepthOfBinaryTree_104 solution, string solutionName)
        {
            // Create a larger balanced tree with 63 nodes (6 levels)
            // Output: 6

            // Arrange
            var values = new List<int?>();
            for (int i = 1; i <= 63; i++)
            {
                values.Add(i);
            }
            var root = CreateTree(values.ToArray());

            // Act
            var result = solution.MaxDepth(root);

            // Assert
            Assert.AreEqual(6, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void MaxDepth_CompleteTreeHeight6_ReturnsCorrectDepth(IMaxDepthOfBinaryTree_104 solution, string solutionName)
        {
            // Complete tree with 6 levels (127 nodes when complete)
            // Output: 6

            // Arrange
            var values = new List<int?>();
            for (int i = 1; i <= 127; i++)
            {
                values.Add(i);
            }
            var root = CreateTree(values.ToArray());

            // Act
            var result = solution.MaxDepth(root);

            // Assert
            Assert.AreEqual(7, result, $"Failed for {solutionName}");
        }

        #endregion

        #region Boundary Cases

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void MaxDepth_OnlyRootWithOneLeftLeaf_Returns2(IMaxDepthOfBinaryTree_104 solution, string solutionName)
        {
            // Input:  1
            //        /
            //       2
            // Output: 2

            // Arrange
            var root = new TreeNode(1, new TreeNode(2), null);

            // Act
            var result = solution.MaxDepth(root);

            // Assert
            Assert.AreEqual(2, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void MaxDepth_OnlyRootWithOneRightLeaf_Returns2(IMaxDepthOfBinaryTree_104 solution, string solutionName)
        {
            // Input:  1
            //          \
            //           2
            // Output: 2

            // Arrange
            var root = new TreeNode(1, null, new TreeNode(2));

            // Act
            var result = solution.MaxDepth(root);

            // Assert
            Assert.AreEqual(2, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void MaxDepth_LeftDepth3RightDepth1_Returns4(IMaxDepthOfBinaryTree_104 solution, string solutionName)
        {
            // Input:       1
            //            /   \
            //           2     3
            //          /
            //         4
            //        /
            //       5
            // Output: 4

            // Arrange
            var root = CreateTree(new int?[] { 1, 2, 3, 4, null, null, null, 5 });

            // Act
            var result = solution.MaxDepth(root);

            // Assert
            Assert.AreEqual(4, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void MaxDepth_LeftDepth1RightDepth3_Returns4(IMaxDepthOfBinaryTree_104 solution, string solutionName)
        {
            // Input:     1
            //           / \
            //          2   3
            //               \
            //                4
            //                 \
            //                  5
            // Output: 4

            // Arrange
            var root = CreateTree(new int?[] { 1, 2, 3, null, null, null, 4, null, 5 });

            // Act
            var result = solution.MaxDepth(root);

            // Assert
            Assert.AreEqual(4, result, $"Failed for {solutionName}");
        }

        #endregion

        #region Property Tests

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void MaxDepth_SingleNodeTree_DepthAlways1(IMaxDepthOfBinaryTree_104 solution, string solutionName)
        {
            // Any single node should have depth 1

            // Arrange
            var testValues = new[] { -1000, -1, 0, 1, 42, 1000, 9999 };

            foreach (var value in testValues)
            {
                var root = new TreeNode(value);

                // Act
                var result = solution.MaxDepth(root);

                // Assert
                Assert.AreEqual(1, result, $"Failed for value {value} with {solutionName}");
            }
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void MaxDepth_CompareSkewedTrees_SameDepth(IMaxDepthOfBinaryTree_104 solution, string solutionName)
        {
            // Left-skewed and right-skewed trees of same height should return same depth

            // Arrange
            TreeNode leftSkewed = new TreeNode(5);
            TreeNode currentLeft = leftSkewed;
            for (int i = 4; i >= 1; i--)
            {
                currentLeft.left = new TreeNode(i);
                currentLeft = currentLeft.left;
            }

            TreeNode rightSkewed = new TreeNode(1);
            TreeNode currentRight = rightSkewed;
            for (int i = 2; i <= 5; i++)
            {
                currentRight.right = new TreeNode(i);
                currentRight = currentRight.right;
            }

            // Act
            var leftDepth = solution.MaxDepth(leftSkewed);
            var rightDepth = solution.MaxDepth(rightSkewed);

            // Assert
            Assert.AreEqual(leftDepth, rightDepth, $"Failed for {solutionName}");
            Assert.AreEqual(5, leftDepth, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void MaxDepth_BalancedVsUnbalanced_DifferentDepths(IMaxDepthOfBinaryTree_104 solution, string solutionName)
        {
            // Balanced tree with 7 nodes has depth 3
            // Unbalanced (skewed) tree with 7 nodes has depth 7

            // Arrange
            var balanced = CreateTree(new int?[] { 4, 2, 6, 1, 3, 5, 7 });
            
            TreeNode unbalanced = new TreeNode(1);
            TreeNode current = unbalanced;
            for (int i = 2; i <= 7; i++)
            {
                current.right = new TreeNode(i);
                current = current.right;
            }

            // Act
            var balancedDepth = solution.MaxDepth(balanced);
            var unbalancedDepth = solution.MaxDepth(unbalanced);

            // Assert
            Assert.AreEqual(3, balancedDepth, $"Failed for {solutionName}");
            Assert.AreEqual(7, unbalancedDepth, $"Failed for {solutionName}");
            Assert.IsTrue(unbalancedDepth > balancedDepth, $"Failed for {solutionName}");
        }

        #endregion
    }
}
