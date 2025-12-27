using LeetCodeProblems.CSharp.Tree;
using LeetCodeProblems.Interfaces.Easy;
using LeetCodeProblems.Shared;
using LeetCodeProblems.VisualBasic;


namespace GrindingLeetCode.UnitTests.Easy
{
    [TestClass]
    public class BalancedBinaryTree_110_Tests
    {
        public static IEnumerable<object[]> GetImplementations()
        {
            yield return new object[] { new BalancedBinaryTree_Recursive_CSharp_110(), "C# Recursive" };
            yield return new object[] { new BalancedBinaryTree_HashMap_CSharp_110(), "C# HashMap" };
            yield return new object[] { new BalancedBinaryTree_HashMap_VB_110(), "VB HashMap" };
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
        public void IsBalanced_Example1_ReturnsTrue(IBalancedBinaryTree_110 solution, string solutionName)
        {
            // Input: root = [3,9,20,null,null,15,7]
            //       3
            //      / \
            //     9  20
            //       /  \
            //      15   7
            // Output: true
            // Explanation: Left height = 1, Right height = 2, difference = 1

            // Arrange
            var root = CreateTree(new int?[] { 3, 9, 20, null, null, 15, 7 });

            // Act
            var result = solution.IsBalanced(root);

            // Assert
            Assert.IsTrue(result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsBalanced_Example2_ReturnsFalse(IBalancedBinaryTree_110 solution, string solutionName)
        {
            // Input: root = [1,2,2,3,3,null,null,4,4]
            //          1
            //         / \
            //        2   2
            //       / \
            //      3   3
            //     / \
            //    4   4
            // Output: false
            // Explanation: Left subtree height = 3, right = 1, difference = 2

            // Arrange
            var root = CreateTree(new int?[] { 1, 2, 2, 3, 3, null, null, 4, 4 });

            // Act
            var result = solution.IsBalanced(root);

            // Assert
            Assert.IsFalse(result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsBalanced_Example3_ReturnsTrue(IBalancedBinaryTree_110 solution, string solutionName)
        {
            // Input: root = []
            // Output: true
            // Explanation: Empty tree is balanced

            // Arrange
            TreeNode root = null;

            // Act
            var result = solution.IsBalanced(root);

            // Assert
            Assert.IsTrue(result, $"Failed for {solutionName}");
        }

        #endregion

        #region Basic Tree Structures

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsBalanced_NullTree_ReturnsTrue(IBalancedBinaryTree_110 solution, string solutionName)
        {
            // Empty tree is considered balanced

            // Arrange
            TreeNode root = null;

            // Act
            var result = solution.IsBalanced(root);

            // Assert
            Assert.IsTrue(result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsBalanced_SingleNode_ReturnsTrue(IBalancedBinaryTree_110 solution, string solutionName)
        {
            // Single node is balanced

            // Arrange
            var root = new TreeNode(1);

            // Act
            var result = solution.IsBalanced(root);

            // Assert
            Assert.IsTrue(result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsBalanced_TwoNodesLeftChild_ReturnsTrue(IBalancedBinaryTree_110 solution, string solutionName)
        {
            // Tree:  2
            //       /
            //      1
            // Balanced: left height = 1, right height = 0, diff = 1

            // Arrange
            var root = CreateSimpleTree(2, left: 1);

            // Act
            var result = solution.IsBalanced(root);

            // Assert
            Assert.IsTrue(result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsBalanced_TwoNodesRightChild_ReturnsTrue(IBalancedBinaryTree_110 solution, string solutionName)
        {
            // Tree:  1
            //         \
            //          2
            // Balanced: left height = 0, right height = 1, diff = 1

            // Arrange
            var root = CreateSimpleTree(1, right: 2);

            // Act
            var result = solution.IsBalanced(root);

            // Assert
            Assert.IsTrue(result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsBalanced_ThreeNodesComplete_ReturnsTrue(IBalancedBinaryTree_110 solution, string solutionName)
        {
            // Tree:    2
            //         / \
            //        1   3
            // Balanced: left height = 1, right height = 1, diff = 0

            // Arrange
            var root = CreateSimpleTree(2, left: 1, right: 3);

            // Act
            var result = solution.IsBalanced(root);

            // Assert
            Assert.IsTrue(result, $"Failed for {solutionName}");
        }

        #endregion

        #region Balanced Trees

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsBalanced_PerfectTree7Nodes_ReturnsTrue(IBalancedBinaryTree_110 solution, string solutionName)
        {
            // Tree:       4
            //           /   \
            //          2     6
            //         / \   / \
            //        1   3 5   7
            // Perfect binary tree is balanced

            // Arrange
            var root = CreateTree(new int?[] { 4, 2, 6, 1, 3, 5, 7 });

            // Act
            var result = solution.IsBalanced(root);

            // Assert
            Assert.IsTrue(result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsBalanced_PerfectTree15Nodes_ReturnsTrue(IBalancedBinaryTree_110 solution, string solutionName)
        {
            // Tree:              8
            //                /       \
            //               4         12
            //             /   \      /   \
            //            2     6    10    14
            //           / \   / \   / \   / \
            //          1   3 5   7 9  11 13 15
            // Perfect binary tree is balanced

            // Arrange
            var root = CreateTree(new int?[] { 8, 4, 12, 2, 6, 10, 14, 1, 3, 5, 7, 9, 11, 13, 15 });

            // Act
            var result = solution.IsBalanced(root);

            // Assert
            Assert.IsTrue(result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsBalanced_PerfectTree31Nodes_ReturnsTrue(IBalancedBinaryTree_110 solution, string solutionName)
        {
            // Perfect binary tree with 5 levels (31 nodes)

            // Arrange
            var root = CreateTree(new int?[] { 
                16, 8, 24, 4, 12, 20, 28, 2, 6, 10, 14, 18, 22, 26, 30,
                1, 3, 5, 7, 9, 11, 13, 15, 17, 19, 21, 23, 25, 27, 29, 31
            });

            // Act
            var result = solution.IsBalanced(root);

            // Assert
            Assert.IsTrue(result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsBalanced_CompleteButNotPerfect_ReturnsTrue(IBalancedBinaryTree_110 solution, string solutionName)
        {
            // Tree:       4
            //           /   \
            //          2     6
            //         / \   /
            //        1   3 5
            // Complete tree is balanced

            // Arrange
            var root = CreateTree(new int?[] { 4, 2, 6, 1, 3, 5 });

            // Act
            var result = solution.IsBalanced(root);

            // Assert
            Assert.IsTrue(result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsBalanced_AlmostComplete_ReturnsTrue(IBalancedBinaryTree_110 solution, string solutionName)
        {
            // Tree:       4
            //           /   \
            //          2     6
            //         /     / \
            //        1     5   7
            // Still balanced (height difference = 1)

            // Arrange
            var root = CreateTree(new int?[] { 4, 2, 6, 1, null, 5, 7 });

            // Act
            var result = solution.IsBalanced(root);

            // Assert
            Assert.IsTrue(result, $"Failed for {solutionName}");
        }

        #endregion

        #region Left-Skewed Unbalanced Trees

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsBalanced_LeftSkewed3Nodes_ReturnsFalse(IBalancedBinaryTree_110 solution, string solutionName)
        {
            // Tree:      3
            //           /
            //          2
            //         /
            //        1
            // Left height = 2, right height = 0, diff = 2

            // Arrange
            var root = CreateTree(new int?[] { 3, 2, null, 1 });

            // Act
            var result = solution.IsBalanced(root);

            // Assert
            Assert.IsFalse(result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsBalanced_LeftSkewed5Nodes_ReturnsFalse(IBalancedBinaryTree_110 solution, string solutionName)
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
            // Completely unbalanced

            // Arrange
            var root = CreateTree(new int?[] { 5, 4, null, 3, null, 2, null, 1 });

            // Act
            var result = solution.IsBalanced(root);

            // Assert
            Assert.IsFalse(result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsBalanced_LeftSkewed10Nodes_ReturnsFalse(IBalancedBinaryTree_110 solution, string solutionName)
        {
            // Deep left-skewed tree (10 nodes)

            // Arrange
            TreeNode root = new TreeNode(10);
            TreeNode current = root;
            for (int i = 9; i >= 1; i--)
            {
                current.left = new TreeNode(i);
                current = current.left;
            }

            // Act
            var result = solution.IsBalanced(root);

            // Assert
            Assert.IsFalse(result, $"Failed for {solutionName}");
        }

        #endregion

        #region Right-Skewed Unbalanced Trees

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsBalanced_RightSkewed3Nodes_ReturnsFalse(IBalancedBinaryTree_110 solution, string solutionName)
        {
            // Tree:  1
            //         \
            //          2
            //           \
            //            3
            // Left height = 0, right height = 2, diff = 2

            // Arrange
            var root = CreateTree(new int?[] { 1, null, 2, null, 3 });

            // Act
            var result = solution.IsBalanced(root);

            // Assert
            Assert.IsFalse(result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsBalanced_RightSkewed5Nodes_ReturnsFalse(IBalancedBinaryTree_110 solution, string solutionName)
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
            // Completely unbalanced

            // Arrange
            var root = CreateTree(new int?[] { 1, null, 2, null, 3, null, 4, null, 5 });

            // Act
            var result = solution.IsBalanced(root);

            // Assert
            Assert.IsFalse(result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsBalanced_RightSkewed10Nodes_ReturnsFalse(IBalancedBinaryTree_110 solution, string solutionName)
        {
            // Deep right-skewed tree (10 nodes)

            // Arrange
            TreeNode root = new TreeNode(1);
            TreeNode current = root;
            for (int i = 2; i <= 10; i++)
            {
                current.right = new TreeNode(i);
                current = current.right;
            }

            // Act
            var result = solution.IsBalanced(root);

            // Assert
            Assert.IsFalse(result, $"Failed for {solutionName}");
        }

        #endregion

        #region Unbalanced at Root

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsBalanced_UnbalancedAtRoot_LeftHeavy_ReturnsFalse(IBalancedBinaryTree_110 solution, string solutionName)
        {
            // Tree:        5
            //            /   \
            //           3     6
            //          / \
            //         2   4
            //        /
            //       1
            // Left subtree height = 3, right = 1, diff = 2

            // Arrange
            var root = CreateTree(new int?[] { 5, 3, 6, 2, 4, null, null, 1 });

            // Act
            var result = solution.IsBalanced(root);

            // Assert
            Assert.IsFalse(result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsBalanced_UnbalancedAtRoot_RightHeavy_ReturnsFalse(IBalancedBinaryTree_110 solution, string solutionName)
        {
            // Tree:    1
            //         / \
            //        2   3
            //           / \
            //          4   5
            //               \
            //                6
            // Left subtree height = 1, right = 3, diff = 2

            // Arrange
            var root = CreateTree(new int?[] { 1, 2, 3, null, null, 4, 5, null, null, null, 6 });

            // Act
            var result = solution.IsBalanced(root);

            // Assert
            Assert.IsFalse(result, $"Failed for {solutionName}");
        }

        #endregion

        #region Unbalanced in Subtree

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsBalanced_UnbalancedInLeftSubtree_ReturnsFalse(IBalancedBinaryTree_110 solution, string solutionName)
        {
            // Tree:        10
            //            /    \
            //           5      15
            //          / \
            //         3   7
            //        /
            //       2
            //      /
            //     1
            // Root is balanced but left subtree is not

            // Arrange
            var root = CreateTree(new int?[] { 10, 5, 15, 3, 7, null, null, 2, null, null, null, 1 });

            // Act
            var result = solution.IsBalanced(root);

            // Assert
            Assert.IsFalse(result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsBalanced_UnbalancedInRightSubtree_ReturnsFalse(IBalancedBinaryTree_110 solution, string solutionName)
        {
            // Tree:        10
            //            /    \
            //           5      15
            //                 /  \
            //                12  20
            //                     \
            //                     25
            //                      \
            //                      30
            // Root is balanced but right subtree is not

            // Arrange
            var root = CreateTree(new int?[] { 10, 5, 15, null, null, 12, 20, null, null, null, 25, null, 30 });

            // Act
            var result = solution.IsBalanced(root);

            // Assert
            Assert.IsFalse(result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsBalanced_UnbalancedDeepInTree_ReturnsFalse(IBalancedBinaryTree_110 solution, string solutionName)
        {
            // Tree:           10
            //              /      \
            //             5        15
            //           /   \
            //          3     7
            //         /
            //        2
            //       /
            //      1
            // Unbalanced deep in left-left subtree

            // Arrange
            var root = CreateTree(new int?[] { 10, 5, 15, 3, 7, null, null, 2, null, null, null, 1 });

            // Act
            var result = solution.IsBalanced(root);

            // Assert
            Assert.IsFalse(result, $"Failed for {solutionName}");
        }

        #endregion

        #region Boundary Cases - Balanced

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsBalanced_MaxDifferenceOfOne_LeftHeavier_ReturnsTrue(IBalancedBinaryTree_110 solution, string solutionName)
        {
            // Tree:       4
            //           /   \
            //          2     5
            //         / \
            //        1   3
            // Left height = 2, right height = 1, diff = 1 (balanced)

            // Arrange
            var root = CreateTree(new int?[] { 4, 2, 5, 1, 3 });

            // Act
            var result = solution.IsBalanced(root);

            // Assert
            Assert.IsTrue(result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsBalanced_MaxDifferenceOfOne_RightHeavier_ReturnsTrue(IBalancedBinaryTree_110 solution, string solutionName)
        {
            // Tree:       2
            //           /   \
            //          1     4
            //               / \
            //              3   5
            // Left height = 1, right height = 2, diff = 1 (balanced)

            // Arrange
            var root = CreateTree(new int?[] { 2, 1, 4, null, null, 3, 5 });

            // Act
            var result = solution.IsBalanced(root);

            // Assert
            Assert.IsTrue(result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsBalanced_ComplexButBalanced_ReturnsTrue(IBalancedBinaryTree_110 solution, string solutionName)
        {
            // Tree:            8
            //               /     \
            //              4       12
            //            /   \    /  \
            //           2     6  10  14
            //          /     /    \    \
            //         1     5     11   15
            // All height differences <= 1

            // Arrange
            var root = CreateTree(new int?[] { 8, 4, 12, 2, 6, 10, 14, 1, null, 5, null, null, 11, null, 15 });

            // Act
            var result = solution.IsBalanced(root);

            // Assert
            Assert.IsTrue(result, $"Failed for {solutionName}");
        }

        #endregion

        #region Edge Cases - Values

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsBalanced_NegativeValues_ReturnsCorrect(IBalancedBinaryTree_110 solution, string solutionName)
        {
            // Tree:       0
            //           /   \
            //         -2     2
            //         / \   / \
            //       -3 -1  1  3
            // Balanced tree with negative values

            // Arrange
            var root = CreateTree(new int?[] { 0, -2, 2, -3, -1, 1, 3 });

            // Act
            var result = solution.IsBalanced(root);

            // Assert
            Assert.IsTrue(result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsBalanced_AllNegativeValues_UnbalancedTree_ReturnsFalse(IBalancedBinaryTree_110 solution, string solutionName)
        {
            // Tree:       -4
            //            /
            //          -6
            //          /
            //        -7
            // Unbalanced with all negative values

            // Arrange
            var root = CreateTree(new int?[] { -4, -6, null, -7 });

            // Act
            var result = solution.IsBalanced(root);

            // Assert
            Assert.IsFalse(result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsBalanced_DuplicateValues_ReturnsCorrect(IBalancedBinaryTree_110 solution, string solutionName)
        {
            // Tree:      5
            //           / \
            //          5   5
            //         / \
            //        5   5
            // Balanced tree with duplicate values

            // Arrange
            var root = CreateTree(new int?[] { 5, 5, 5, 5, 5 });

            // Act
            var result = solution.IsBalanced(root);

            // Assert
            Assert.IsTrue(result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsBalanced_ZeroValues_ReturnsTrue(IBalancedBinaryTree_110 solution, string solutionName)
        {
            // Tree:      0
            //           / \
            //          0   0
            // Balanced tree with all zeros

            // Arrange
            var root = CreateSimpleTree(0, left: 0, right: 0);

            // Act
            var result = solution.IsBalanced(root);

            // Assert
            Assert.IsTrue(result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsBalanced_LargeValues_ReturnsTrue(IBalancedBinaryTree_110 solution, string solutionName)
        {
            // Tree:      10000
            //           /     \
            //       -10000   10000
            // Balanced tree with large values

            // Arrange
            var root = CreateSimpleTree(10000, left: -10000, right: 10000);

            // Act
            var result = solution.IsBalanced(root);

            // Assert
            Assert.IsTrue(result, $"Failed for {solutionName}");
        }

        #endregion

        #region Complex Patterns

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsBalanced_ZigZagPattern_ReturnsFalse(IBalancedBinaryTree_110 solution, string solutionName)
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
            // Unbalanced zigzag

            // Arrange
            var root = new TreeNode(1);
            root.right = new TreeNode(2);
            root.right.left = new TreeNode(3);
            root.right.left.right = new TreeNode(4);
            root.right.left.right.left = new TreeNode(5);

            // Act
            var result = solution.IsBalanced(root);

            // Assert
            Assert.IsFalse(result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsBalanced_SymmetricBalancedTree_ReturnsTrue(IBalancedBinaryTree_110 solution, string solutionName)
        {
            // Tree:      1
            //           / \
            //          2   2
            //         / \ / \
            //        3  4 4  3
            // Perfectly symmetric and balanced

            // Arrange
            var root = CreateTree(new int?[] { 1, 2, 2, 3, 4, 4, 3 });

            // Act
            var result = solution.IsBalanced(root);

            // Assert
            Assert.IsTrue(result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsBalanced_VShape_ReturnsTrue(IBalancedBinaryTree_110 solution, string solutionName)
        {
            // Tree:       4
            //           /   \
            //          2     6
            //         /       \
            //        1         7
            // V-shaped, still balanced

            // Arrange
            var root = CreateTree(new int?[] { 4, 2, 6, 1, null, null, 7 });

            // Act
            var result = solution.IsBalanced(root);

            // Assert
            Assert.IsTrue(result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsBalanced_SparseButBalanced_ReturnsTrue(IBalancedBinaryTree_110 solution, string solutionName)
        {
            // Tree:       8
            //           /   \
            //          4     12
            //           \   /
            //            6 10
            // Sparse but balanced

            // Arrange
            var root = CreateTree(new int?[] { 8, 4, 12, null, 6, 10 });

            // Act
            var result = solution.IsBalanced(root);

            // Assert
            Assert.IsTrue(result, $"Failed for {solutionName}");
        }

        #endregion

        #region Larger Trees

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsBalanced_LargeBalancedTree63Nodes_ReturnsTrue(IBalancedBinaryTree_110 solution, string solutionName)
        {
            // Perfect binary tree with 6 levels (63 nodes)

            // Arrange
            var values = new List<int?>();
            for (int i = 1; i <= 63; i++)
            {
                values.Add(i);
            }
            var root = CreateTree(values.ToArray());

            // Act
            var result = solution.IsBalanced(root);

            // Assert
            Assert.IsTrue(result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsBalanced_VeryDeepLeftSkewed20Nodes_ReturnsFalse(IBalancedBinaryTree_110 solution, string solutionName)
        {
            // Deep left-skewed tree (20 nodes)

            // Arrange
            TreeNode root = new TreeNode(20);
            TreeNode current = root;
            for (int i = 19; i >= 1; i--)
            {
                current.left = new TreeNode(i);
                current = current.left;
            }

            // Act
            var result = solution.IsBalanced(root);

            // Assert
            Assert.IsFalse(result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsBalanced_VeryDeepRightSkewed20Nodes_ReturnsFalse(IBalancedBinaryTree_110 solution, string solutionName)
        {
            // Deep right-skewed tree (20 nodes)

            // Arrange
            TreeNode root = new TreeNode(1);
            TreeNode current = root;
            for (int i = 2; i <= 20; i++)
            {
                current.right = new TreeNode(i);
                current = current.right;
            }

            // Act
            var result = solution.IsBalanced(root);

            // Assert
            Assert.IsFalse(result, $"Failed for {solutionName}");
        }

        #endregion

        #region Specific Unbalanced Patterns

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsBalanced_BalancedRootUnbalancedSubtree_ReturnsFalse(IBalancedBinaryTree_110 solution, string solutionName)
        {
            // Tree:        5
            //            /   \
            //           3     7
            //          /
            //         2
            //        /
            //       1
            // Root appears balanced but left subtree is not

            // Arrange
            var root = CreateTree(new int?[] { 5, 3, 7, 2, null, null, null, 1 });

            // Act
            var result = solution.IsBalanced(root);

            // Assert
            Assert.IsFalse(result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsBalanced_OneLevelDifference_AtBoundary_ReturnsTrue(IBalancedBinaryTree_110 solution, string solutionName)
        {
            // Tree:        4
            //            /   \
            //           2     6
            //          / \   /
            //         1   3 5
            // Height difference exactly 1 at root

            // Arrange
            var root = CreateTree(new int?[] { 4, 2, 6, 1, 3, 5 });

            // Act
            var result = solution.IsBalanced(root);

            // Assert
            Assert.IsTrue(result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsBalanced_TwoLevelsDifference_ReturnsFalse(IBalancedBinaryTree_110 solution, string solutionName)
        {
            // Tree:        4
            //            /   \
            //           2     5
            //          / \
            //         1   3
            //        /
            //       0
            // Left height = 3, right height = 1, diff = 2

            // Arrange
            var root = CreateTree(new int?[] { 4, 2, 5, 1, 3, null, null, 0 });

            // Act
            var result = solution.IsBalanced(root);

            // Assert
            Assert.IsFalse(result, $"Failed for {solutionName}");
        }

        #endregion

        #region Property-Based Tests

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsBalanced_AllSingleNodes_ReturnsTrue(IBalancedBinaryTree_110 solution, string solutionName)
        {
            // Any single node should be balanced regardless of value

            // Arrange
            var testValues = new[] { -10000, -1, 0, 1, 42, 1000, 10000 };

            foreach (var value in testValues)
            {
                var root = new TreeNode(value);

                // Act
                var result = solution.IsBalanced(root);

                // Assert
                Assert.IsTrue(result, $"Failed for value {value} with {solutionName}");
            }
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsBalanced_AllPerfectTreesAreBalanced(IBalancedBinaryTree_110 solution, string solutionName)
        {
            // Test perfect trees of different heights

            // Arrange & Act & Assert
            // Height 1 (1 node)
            var tree1 = new TreeNode(1);
            Assert.IsTrue(solution.IsBalanced(tree1), $"Failed for height 1 with {solutionName}");

            // Height 2 (3 nodes)
            var tree2 = CreateTree(new int?[] { 2, 1, 3 });
            Assert.IsTrue(solution.IsBalanced(tree2), $"Failed for height 2 with {solutionName}");

            // Height 3 (7 nodes)
            var tree3 = CreateTree(new int?[] { 4, 2, 6, 1, 3, 5, 7 });
            Assert.IsTrue(solution.IsBalanced(tree3), $"Failed for height 3 with {solutionName}");

            // Height 4 (15 nodes)
            var tree4 = CreateTree(new int?[] { 8, 4, 12, 2, 6, 10, 14, 1, 3, 5, 7, 9, 11, 13, 15 });
            Assert.IsTrue(solution.IsBalanced(tree4), $"Failed for height 4 with {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsBalanced_AllCompletelySkewedTreesAreUnbalanced(IBalancedBinaryTree_110 solution, string solutionName)
        {
            // Any fully skewed tree with 3+ nodes should be unbalanced

            // Left-skewed with 3 nodes
            var leftSkewed = CreateTree(new int?[] { 3, 2, null, 1 });
            Assert.IsFalse(solution.IsBalanced(leftSkewed), $"Failed for left-skewed with {solutionName}");

            // Right-skewed with 3 nodes
            var rightSkewed = CreateTree(new int?[] { 1, null, 2, null, 3 });
            Assert.IsFalse(solution.IsBalanced(rightSkewed), $"Failed for right-skewed with {solutionName}");
        }

        #endregion

        #region Edge Cases - Special Structures

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsBalanced_OnlyLeftPath_ReturnsTrue(IBalancedBinaryTree_110 solution, string solutionName)
        {
            // Tree:    2
            //         /
            //        1
            // Single path is balanced (height diff = 1)

            // Arrange
            var root = CreateSimpleTree(2, left: 1);

            // Act
            var result = solution.IsBalanced(root);

            // Assert
            Assert.IsTrue(result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsBalanced_OnlyRightPath_ReturnsTrue(IBalancedBinaryTree_110 solution, string solutionName)
        {
            // Tree:  1
            //         \
            //          2
            // Single path is balanced (height diff = 1)

            // Arrange
            var root = CreateSimpleTree(1, right: 2);

            // Act
            var result = solution.IsBalanced(root);

            // Assert
            Assert.IsTrue(result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsBalanced_CompleteTreeMissingOneNode_ReturnsTrue(IBalancedBinaryTree_110 solution, string solutionName)
        {
            // Tree:       4
            //           /   \
            //          2     6
            //         / \   /
            //        1   3 5
            // Complete tree missing one leaf - still balanced

            // Arrange
            var root = CreateTree(new int?[] { 4, 2, 6, 1, 3, 5 });

            // Act
            var result = solution.IsBalanced(root);

            // Assert
            Assert.IsTrue(result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsBalanced_AllNodesOnOneSide_ReturnsFalse(IBalancedBinaryTree_110 solution, string solutionName)
        {
            // Tree:      5
            //           /
            //          4
            //         /
            //        3
            //       /
            //      2
            // All nodes on left side

            // Arrange
            var root = CreateTree(new int?[] { 5, 4, null, 3, null, 2 });

            // Act
            var result = solution.IsBalanced(root);

            // Assert
            Assert.IsFalse(result, $"Failed for {solutionName}");
        }

        #endregion
    }
}
