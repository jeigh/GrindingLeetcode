using LeetCodeProblems.CSharp.Tree;
using LeetCodeProblems.Interfaces.Easy;
using LeetCodeProblems.Shared;
using LeetCodeProblems.VisualBasic;

namespace GrindingLeetCode.UnitTests.Easy
{
    [TestClass]
    public class DiameterOfBinaryTree_543_Tests
    {
        public static IEnumerable<object[]> GetImplementations()
        {
            //yield return new object[] { new DiameterOfBinaryTree_Recursive_CSharp_543(), "Recursive" };
            //yield return new object[] { new DiameterOfBinaryTree_StackHashmap_Csharp_543(), "Stack+HashMap" };

            yield return new object[] { new DiameterOfBinaryTree_Recursive_VB_543(), "Recursive" };
            //yield return new object[] { new DiameterOfBinaryTree_StackHashmap_Csharp_543(), "Stack+HashMap" };

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
        public void DiameterOfBinaryTree_Example1_Returns3(IDiameterOfBinaryTree_543 solution, string solutionName)
        {
            // Input: root = [1,2,3,4,5]
            //       1
            //      / \
            //     2   3
            //    / \
            //   4   5
            // Output: 3
            // Explanation: The diameter is the path [4,2,1,3] or [5,2,1,3] (3 edges)

            // Arrange
            var root = CreateTree(new int?[] { 1, 2, 3, 4, 5 });

            // Act
            var result = solution.DiameterOfBinaryTree(root);

            // Assert
            Assert.AreEqual(3, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void DiameterOfBinaryTree_Example2_Returns1(IDiameterOfBinaryTree_543 solution, string solutionName)
        {
            // Input: root = [1,2]
            //   1
            //  /
            // 2
            // Output: 1

            // Arrange
            var root = CreateTree(new int?[] { 1, 2 });

            // Act
            var result = solution.DiameterOfBinaryTree(root);

            // Assert
            Assert.AreEqual(1, result, $"Failed for {solutionName}");
        }

        #endregion

        #region Basic Tree Structures

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void DiameterOfBinaryTree_NullTree_Returns0(IDiameterOfBinaryTree_543 solution, string solutionName)
        {
            // Input: root = []
            // Output: 0

            // Arrange
            TreeNode root = null;

            // Act
            var result = solution.DiameterOfBinaryTree(root);

            // Assert
            Assert.AreEqual(0, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void DiameterOfBinaryTree_SingleNode_Returns0(IDiameterOfBinaryTree_543 solution, string solutionName)
        {
            // Input: root = [1]
            // Output: 0
            // Explanation: No edges exist

            // Arrange
            var root = new TreeNode(1);

            // Act
            var result = solution.DiameterOfBinaryTree(root);

            // Assert
            Assert.AreEqual(0, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void DiameterOfBinaryTree_TwoNodesLeftChild_Returns1(IDiameterOfBinaryTree_543 solution, string solutionName)
        {
            // Input:  2
            //        /
            //       1
            // Output: 1

            // Arrange
            var root = CreateSimpleTree(2, left: 1);

            // Act
            var result = solution.DiameterOfBinaryTree(root);

            // Assert
            Assert.AreEqual(1, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void DiameterOfBinaryTree_TwoNodesRightChild_Returns1(IDiameterOfBinaryTree_543 solution, string solutionName)
        {
            // Input:  1
            //          \
            //           2
            // Output: 1

            // Arrange
            var root = CreateSimpleTree(1, right: 2);

            // Act
            var result = solution.DiameterOfBinaryTree(root);

            // Assert
            Assert.AreEqual(1, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void DiameterOfBinaryTree_ThreeNodesComplete_Returns2(IDiameterOfBinaryTree_543 solution, string solutionName)
        {
            // Input:    2
            //          / \
            //         1   3
            // Output: 2
            // Explanation: Path is [1,2,3] (2 edges)

            // Arrange
            var root = CreateSimpleTree(2, left: 1, right: 3);

            // Act
            var result = solution.DiameterOfBinaryTree(root);

            // Assert
            Assert.AreEqual(2, result, $"Failed for {solutionName}");
        }

        #endregion

        #region Balanced Trees

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void DiameterOfBinaryTree_BalancedTree7Nodes_Returns4(IDiameterOfBinaryTree_543 solution, string solutionName)
        {
            // Input:       4
            //            /   \
            //           2     6
            //          / \   / \
            //         1   3 5   7
            // Output: 4
            // Explanation: Path could be [1,2,4,6,7] or [3,2,4,6,5] etc. (4 edges)

            // Arrange
            var root = CreateTree(new int?[] { 4, 2, 6, 1, 3, 5, 7 });

            // Act
            var result = solution.DiameterOfBinaryTree(root);

            // Assert
            Assert.AreEqual(4, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void DiameterOfBinaryTree_BalancedTree15Nodes_Returns6(IDiameterOfBinaryTree_543 solution, string solutionName)
        {
            // Input:              8
            //                /       \
            //               4         12
            //             /   \      /   \
            //            2     6    10    14
            //           / \   / \   / \   / \
            //          1   3 5   7 9  11 13 15
            // Output: 6
            // Explanation: Longest path goes through 3 levels on each side (6 edges)

            // Arrange
            var root = CreateTree(new int?[] { 8, 4, 12, 2, 6, 10, 14, 1, 3, 5, 7, 9, 11, 13, 15 });

            // Act
            var result = solution.DiameterOfBinaryTree(root);

            // Assert
            Assert.AreEqual(6, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void DiameterOfBinaryTree_PerfectTree31Nodes_Returns8(IDiameterOfBinaryTree_543 solution, string solutionName)
        {
            // Perfect binary tree with 5 levels (31 nodes)
            // Output: 8
            // Explanation: Diameter is depth of left subtree + depth of right subtree

            // Arrange
            var root = CreateTree(new int?[] { 
                16, 8, 24, 4, 12, 20, 28, 2, 6, 10, 14, 18, 22, 26, 30,
                1, 3, 5, 7, 9, 11, 13, 15, 17, 19, 21, 23, 25, 27, 29, 31
            });

            // Act
            var result = solution.DiameterOfBinaryTree(root);

            // Assert
            Assert.AreEqual(8, result, $"Failed for {solutionName}");
        }

        #endregion

        #region Left-Skewed Trees

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void DiameterOfBinaryTree_LeftSkewed3Nodes_Returns2(IDiameterOfBinaryTree_543 solution, string solutionName)
        {
            // Input:      3
            //            /
            //           2
            //          /
            //         1
            // Output: 2

            // Arrange
            var root = CreateTree(new int?[] { 3, 2, null, 1 });

            // Act
            var result = solution.DiameterOfBinaryTree(root);

            // Assert
            Assert.AreEqual(2, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void DiameterOfBinaryTree_LeftSkewed5Nodes_Returns4(IDiameterOfBinaryTree_543 solution, string solutionName)
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
            // Output: 4

            // Arrange
            var root = CreateTree(new int?[] { 5, 4, null, 3, null, 2, null, 1 });

            // Act
            var result = solution.DiameterOfBinaryTree(root);

            // Assert
            Assert.AreEqual(4, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void DiameterOfBinaryTree_LeftSkewed10Nodes_Returns9(IDiameterOfBinaryTree_543 solution, string solutionName)
        {
            // Deep left-skewed tree
            // Output: 9

            // Arrange
            TreeNode root = new TreeNode(10);
            TreeNode current = root;
            for (int i = 9; i >= 1; i--)
            {
                current.left = new TreeNode(i);
                current = current.left;
            }

            // Act
            var result = solution.DiameterOfBinaryTree(root);

            // Assert
            Assert.AreEqual(9, result, $"Failed for {solutionName}");
        }

        #endregion

        #region Right-Skewed Trees

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void DiameterOfBinaryTree_RightSkewed3Nodes_Returns2(IDiameterOfBinaryTree_543 solution, string solutionName)
        {
            // Input:  1
            //          \
            //           2
            //            \
            //             3
            // Output: 2

            // Arrange
            var root = CreateTree(new int?[] { 1, null, 2, null, 3 });

            // Act
            var result = solution.DiameterOfBinaryTree(root);

            // Assert
            Assert.AreEqual(2, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void DiameterOfBinaryTree_RightSkewed5Nodes_Returns4(IDiameterOfBinaryTree_543 solution, string solutionName)
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
            // Output: 4

            // Arrange
            var root = CreateTree(new int?[] { 1, null, 2, null, 3, null, 4, null, 5 });

            // Act
            var result = solution.DiameterOfBinaryTree(root);

            // Assert
            Assert.AreEqual(4, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void DiameterOfBinaryTree_RightSkewed10Nodes_Returns9(IDiameterOfBinaryTree_543 solution, string solutionName)
        {
            // Deep right-skewed tree
            // Output: 9

            // Arrange
            TreeNode root = new TreeNode(1);
            TreeNode current = root;
            for (int i = 2; i <= 10; i++)
            {
                current.right = new TreeNode(i);
                current = current.right;
            }

            // Act
            var result = solution.DiameterOfBinaryTree(root);

            // Assert
            Assert.AreEqual(9, result, $"Failed for {solutionName}");
        }

        #endregion

        #region Unbalanced Trees - Diameter Not Through Root

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void DiameterOfBinaryTree_DiameterInLeftSubtree_Returns4(IDiameterOfBinaryTree_543 solution, string solutionName)
        {
            // Input:        1
            //             /   \
            //            2     3
            //           / \
            //          4   5
            //         / \
            //        6   7
            // Output: 4
            // Explanation: Diameter is [6,4,2,5] or [7,4,2,5] (doesn't go through root)

            // Arrange
            var root = CreateTree(new int?[] { 1, 2, 3, 4, 5, null, null, 6, 7 });

            // Act
            var result = solution.DiameterOfBinaryTree(root);

            // Assert
            Assert.AreEqual(4, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void DiameterOfBinaryTree_DiameterInRightSubtree_Returns4(IDiameterOfBinaryTree_543 solution, string solutionName)
        {
            // Input:        1
            //             /   \
            //            2     3
            //                 / \
            //                4   5
            //               / \
            //              6   7
            // Output: 4
            // Explanation: Diameter is [6,4,3,5] or [7,4,3,5] (doesn't go through root)

            // Arrange
            var root = CreateTree(new int?[] { 1, 2, 3, null, null, 4, 5, 6, 7 });

            // Act
            var result = solution.DiameterOfBinaryTree(root);

            // Assert
            Assert.AreEqual(4, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void DiameterOfBinaryTree_DeepLeftSubtreeShallowRight_Returns5(IDiameterOfBinaryTree_543 solution, string solutionName)
        {
            // Input:            1
            //                 /   \
            //                2     3
            //               / \
            //              4   5
            //             /
            //            6
            //           /
            //          7
            // Output: 5
            // Explanation: Diameter is [7,6,4,2,5] (5 edges)

            // Arrange
            var root = CreateTree(new int?[] { 1, 2, 3, 4, 5, null, null, 6, null, null, null, 7 });

            // Act
            var result = solution.DiameterOfBinaryTree(root);

            // Assert
            Assert.AreEqual(5, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void DiameterOfBinaryTree_UnbalancedMixed_ReturnsCorrectDiameter(IDiameterOfBinaryTree_543 solution, string solutionName)
        {
            // Input:          1
            //               /   \
            //              2     3
            //             / \     \
            //            4   5     6
            //           /           \
            //          7             8
            //         /               \
            //        9                 10
            // Output: 8
            // Explanation: Path from [9,7,4,2,5] or [9,7,4,2,1,3,6,8,10]

            // Arrange
            var root = CreateTree(new int?[] { 1, 2, 3, 4, 5, null, 6, 7, null, null, null, null, 8, 9, null, null, 10 });

            // Act
            var result = solution.DiameterOfBinaryTree(root);

            // Assert
            Assert.AreEqual(8, result, $"Failed for {solutionName}");
        }

        #endregion

        #region Edge Cases - Values

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void DiameterOfBinaryTree_NegativeValues_ReturnsCorrectDiameter(IDiameterOfBinaryTree_543 solution, string solutionName)
        {
            // Input:       0
            //            /   \
            //          -2     2
            //          / \   / \
            //        -3 -1  1  3
            // Output: 4

            // Arrange
            var root = CreateTree(new int?[] { 0, -2, 2, -3, -1, 1, 3 });

            // Act
            var result = solution.DiameterOfBinaryTree(root);

            // Assert
            Assert.AreEqual(4, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void DiameterOfBinaryTree_AllNegativeValues_ReturnsCorrectDiameter(IDiameterOfBinaryTree_543 solution, string solutionName)
        {
            // Input:       -4
            //            /    \
            //          -6     -2
            //          / \    / \
            //        -7 -5  -3 -1
            // Output: 4

            // Arrange
            var root = CreateTree(new int?[] { -4, -6, -2, -7, -5, -3, -1 });

            // Act
            var result = solution.DiameterOfBinaryTree(root);

            // Assert
            Assert.AreEqual(4, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void DiameterOfBinaryTree_DuplicateValues_ReturnsCorrectDiameter(IDiameterOfBinaryTree_543 solution, string solutionName)
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
            var result = solution.DiameterOfBinaryTree(root);

            // Assert
            Assert.AreEqual(3, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void DiameterOfBinaryTree_ZeroValues_ReturnsCorrectDiameter(IDiameterOfBinaryTree_543 solution, string solutionName)
        {
            // Input:      0
            //            / \
            //           0   0
            // Output: 2

            // Arrange
            var root = CreateSimpleTree(0, left: 0, right: 0);

            // Act
            var result = solution.DiameterOfBinaryTree(root);

            // Assert
            Assert.AreEqual(2, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void DiameterOfBinaryTree_LargeValues_ReturnsCorrectDiameter(IDiameterOfBinaryTree_543 solution, string solutionName)
        {
            // Input:      10000
            //            /     \
            //         -10000  10000
            // Output: 2

            // Arrange
            var root = CreateSimpleTree(10000, left: -10000, right: 10000);

            // Act
            var result = solution.DiameterOfBinaryTree(root);

            // Assert
            Assert.AreEqual(2, result, $"Failed for {solutionName}");
        }

        #endregion

        #region Complex Trees

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void DiameterOfBinaryTree_ComplexAsymmetric_ReturnsCorrectDiameter(IDiameterOfBinaryTree_543 solution, string solutionName)
        {
            // Input:           10
            //               /      \
            //              5        15
            //            /   \        \
            //           3     7       20
            //          / \     \
            //         1   4     9
            // Output: 5
            // Explanation: Path [1,3,5,7,9] (5 edges)

            // Arrange
            var root = CreateTree(new int?[] { 10, 5, 15, 3, 7, null, 20, 1, 4, null, 9 });

            // Act
            var result = solution.DiameterOfBinaryTree(root);

            // Assert
            Assert.AreEqual(5, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void DiameterOfBinaryTree_SparseTree_ReturnsCorrectDiameter(IDiameterOfBinaryTree_543 solution, string solutionName)
        {
            // Input:       8
            //            /   \
            //           4     12
            //            \   /
            //             6 10
            // Output: 4
            // Explanation: Path [6,4,8,12,10] (4 edges)

            // Arrange
            var root = CreateTree(new int?[] { 8, 4, 12, null, 6, 10 });

            // Act
            var result = solution.DiameterOfBinaryTree(root);

            // Assert
            Assert.AreEqual(4, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void DiameterOfBinaryTree_OnlyLeftSubtreeDeep_ReturnsCorrectDiameter(IDiameterOfBinaryTree_543 solution, string solutionName)
        {
            // Input:        10
            //              /
            //             5
            //            / \
            //           3   7
            //          /     \
            //         1       9
            // Output: 4
            // Explanation: Path [1,3,5,7,9] (4 edges)

            // Arrange
            var root = CreateTree(new int?[] { 10, 5, null, 3, 7, 1, null, null, 9 });

            // Act
            var result = solution.DiameterOfBinaryTree(root);

            // Assert
            Assert.AreEqual(4, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void DiameterOfBinaryTree_OnlyRightSubtreeDeep_ReturnsCorrectDiameter(IDiameterOfBinaryTree_543 solution, string solutionName)
        {
            // Input:     5
            //             \
            //              15
            //             /  \
            //            12  20
            //           /      \
            //          10       25
            // Output: 4
            // Explanation: Path [10,12,15,20,25] (4 edges)

            // Arrange
            var root = CreateTree(new int?[] { 5, null, 15, 12, 20, 10, null, null, 25 });

            // Act
            var result = solution.DiameterOfBinaryTree(root);

            // Assert
            Assert.AreEqual(4, result, $"Failed for {solutionName}");
        }

        #endregion

        #region Special Patterns

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void DiameterOfBinaryTree_ZigZagPattern_ReturnsCorrectDiameter(IDiameterOfBinaryTree_543 solution, string solutionName)
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
            // Output: 4

            // Arrange
            var root = new TreeNode(1);
            root.right = new TreeNode(2);
            root.right.left = new TreeNode(3);
            root.right.left.right = new TreeNode(4);
            root.right.left.right.left = new TreeNode(5);

            // Act
            var result = solution.DiameterOfBinaryTree(root);

            // Assert
            Assert.AreEqual(4, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void DiameterOfBinaryTree_SymmetricTree_ReturnsCorrectDiameter(IDiameterOfBinaryTree_543 solution, string solutionName)
        {
            // Input:      1
            //            / \
            //           2   2
            //          / \ / \
            //         3  4 4  3
            // Output: 4
            // Explanation: Path goes through root, 2 edges on each side

            // Arrange
            var root = CreateTree(new int?[] { 1, 2, 2, 3, 4, 4, 3 });

            // Act
            var result = solution.DiameterOfBinaryTree(root);

            // Assert
            Assert.AreEqual(4, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void DiameterOfBinaryTree_VShape_ReturnsCorrectDiameter(IDiameterOfBinaryTree_543 solution, string solutionName)
        {
            // Input:       4
            //            /   \
            //           2     6
            //          /       \
            //         1         7
            // Output: 4
            // Explanation: Path [1,2,4,6,7] (4 edges)

            // Arrange
            var root = CreateTree(new int?[] { 4, 2, 6, 1, null, null, 7 });

            // Act
            var result = solution.DiameterOfBinaryTree(root);

            // Assert
            Assert.AreEqual(4, result, $"Failed for {solutionName}");
        }

        #endregion

        #region Larger Trees

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void DiameterOfBinaryTree_VeryDeepLeftSkewed_ReturnsCorrectDiameter(IDiameterOfBinaryTree_543 solution, string solutionName)
        {
            // Deep left-skewed tree (20 nodes)
            // Output: 19

            // Arrange
            TreeNode root = new TreeNode(20);
            TreeNode current = root;
            for (int i = 19; i >= 1; i--)
            {
                current.left = new TreeNode(i);
                current = current.left;
            }

            // Act
            var result = solution.DiameterOfBinaryTree(root);

            // Assert
            Assert.AreEqual(19, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void DiameterOfBinaryTree_VeryDeepRightSkewed_ReturnsCorrectDiameter(IDiameterOfBinaryTree_543 solution, string solutionName)
        {
            // Deep right-skewed tree (20 nodes)
            // Output: 19

            // Arrange
            TreeNode root = new TreeNode(1);
            TreeNode current = root;
            for (int i = 2; i <= 20; i++)
            {
                current.right = new TreeNode(i);
                current = current.right;
            }

            // Act
            var result = solution.DiameterOfBinaryTree(root);

            // Assert
            Assert.AreEqual(19, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void DiameterOfBinaryTree_LargeBalancedTree_ReturnsCorrectDiameter(IDiameterOfBinaryTree_543 solution, string solutionName)
        {
            // Perfect binary tree with 6 levels (63 nodes)
            // Output: 10
            // Explanation: 5 edges from left + 5 edges from right

            // Arrange
            var values = new List<int?>();
            for (int i = 1; i <= 63; i++)
            {
                values.Add(i);
            }
            var root = CreateTree(values.ToArray());

            // Act
            var result = solution.DiameterOfBinaryTree(root);

            // Assert
            Assert.AreEqual(10, result, $"Failed for {solutionName}");
        }

        #endregion

        #region Boundary Cases

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void DiameterOfBinaryTree_OneChildPerNode_LeftThenRight_ReturnsCorrectDiameter(IDiameterOfBinaryTree_543 solution, string solutionName)
        {
            // Input:     1
            //           /
            //          2
            //           \
            //            3
            //           /
            //          4
            // Output: 3

            // Arrange
            var root = new TreeNode(1);
            root.left = new TreeNode(2);
            root.left.right = new TreeNode(3);
            root.left.right.left = new TreeNode(4);

            // Act
            var result = solution.DiameterOfBinaryTree(root);

            // Assert
            Assert.AreEqual(3, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void DiameterOfBinaryTree_LongLeftBranchShortRightBranch_ReturnsCorrectDiameter(IDiameterOfBinaryTree_543 solution, string solutionName)
        {
            // Input:       1
            //            /   \
            //           2     3
            //          /
            //         4
            //        /
            //       5
            // Output: 4
            // Explanation: Path [5,4,2,1,3] (4 edges)

            // Arrange
            var root = CreateTree(new int?[] { 1, 2, 3, 4, null, null, null, 5 });

            // Act
            var result = solution.DiameterOfBinaryTree(root);

            // Assert
            Assert.AreEqual(4, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void DiameterOfBinaryTree_ShortLeftBranchLongRightBranch_ReturnsCorrectDiameter(IDiameterOfBinaryTree_543 solution, string solutionName)
        {
            // Input:     1
            //           / \
            //          2   3
            //               \
            //                4
            //                 \
            //                  5
            // Output: 4
            // Explanation: Path [2,1,3,4,5] (4 edges)

            // Arrange
            var root = CreateTree(new int?[] { 1, 2, 3, null, null, null, 4, null, 5 });

            // Act
            var result = solution.DiameterOfBinaryTree(root);

            // Assert
            Assert.AreEqual(4, result, $"Failed for {solutionName}");
        }

        #endregion

        #region Property Tests

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void DiameterOfBinaryTree_SingleNodeDifferentValues_AlwaysReturns0(IDiameterOfBinaryTree_543 solution, string solutionName)
        {
            // Any single node should have diameter 0

            // Arrange
            var testValues = new[] { -10000, -1, 0, 1, 42, 1000, 10000 };

            foreach (var value in testValues)
            {
                var root = new TreeNode(value);

                // Act
                var result = solution.DiameterOfBinaryTree(root);

                // Assert
                Assert.AreEqual(0, result, $"Failed for value {value} with {solutionName}");
            }
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void DiameterOfBinaryTree_SkewedTreesComparison_SameDiameter(IDiameterOfBinaryTree_543 solution, string solutionName)
        {
            // Left-skewed and right-skewed trees of same height should have same diameter

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
            var leftDiameter = solution.DiameterOfBinaryTree(leftSkewed);
            var rightDiameter = solution.DiameterOfBinaryTree(rightSkewed);

            // Assert
            Assert.AreEqual(leftDiameter, rightDiameter, $"Failed for {solutionName}");
            Assert.AreEqual(4, leftDiameter, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void DiameterOfBinaryTree_DiameterLessThanOrEqualTwiceHeight(IDiameterOfBinaryTree_543 solution, string solutionName)
        {
            // Property: diameter <= 2 * (height - 1)
            // For a balanced tree with 7 nodes, height is 3, diameter should be <= 4

            // Arrange
            var root = CreateTree(new int?[] { 4, 2, 6, 1, 3, 5, 7 });

            // Act
            var diameter = solution.DiameterOfBinaryTree(root);

            // Assert
            Assert.IsTrue(diameter <= 4, $"Diameter {diameter} should be <= 4 for {solutionName}");
            Assert.AreEqual(4, diameter, $"Failed for {solutionName}");
        }

        #endregion
    }
}
