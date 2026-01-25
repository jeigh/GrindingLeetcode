using LeetCodeProblems.CSharp.Tree;
using LeetCodeProblems.Interfaces.Medium;
using LeetCodeProblems.Shared;

namespace GrindingLeetCode.UnitTests.Medium
{
    [TestClass]
    public class ValidateBinarySearchTree_98_Tests
    {
        public static IEnumerable<object[]> GetImplementations()
        {
            yield return new object[] { new ValidateBinarySearchTree_CSharp_DFS_98(), "C# DFS" };
            //yield return new object[] { new ValidateBinarySearchTree_CSharp_InOrder_Recursive_98(), "C# InOrder Recursive" };
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
        public void IsValidBST_Example1_ReturnsTrue(IValidateBinarySearchTree_98 solution, string solutionName)
        {
            // Input: root = [2,1,3]
            //      2
            //     / \
            //    1   3
            // Output: true

            // Arrange
            var root = CreateTree(new int?[] { 2, 1, 3 });

            // Act
            var result = solution.IsValidBST(root);

            // Assert
            Assert.IsTrue(result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsValidBST_Example2_ReturnsFalse(IValidateBinarySearchTree_98 solution, string solutionName)
        {
            // Input: root = [5,1,4,null,null,3,6]
            //      5
            //     / \
            //    1   4
            //       / \
            //      3   6
            // Output: false
            // Explanation: The root node's value is 5 but its right child's value is 4.

            // Arrange
            var root = CreateTree(new int?[] { 5, 1, 4, null, null, 3, 6 });

            // Act
            var result = solution.IsValidBST(root);

            // Assert
            Assert.IsFalse(result, $"Failed for {solutionName}");
        }

        #endregion

        #region Basic Tree Structures

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsValidBST_NullTree_ReturnsTrue(IValidateBinarySearchTree_98 solution, string solutionName)
        {
            // Input: root = []
            // Output: true
            // Explanation: An empty tree is a valid BST

            // Arrange
            TreeNode root = null;

            // Act
            var result = solution.IsValidBST(root);

            // Assert
            Assert.IsTrue(result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsValidBST_SingleNode_ReturnsTrue(IValidateBinarySearchTree_98 solution, string solutionName)
        {
            // Input: root = [1]
            // Output: true
            // Explanation: A single node is always a valid BST

            // Arrange
            var root = new TreeNode(1);

            // Act
            var result = solution.IsValidBST(root);

            // Assert
            Assert.IsTrue(result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsValidBST_TwoNodes_LeftChild_Valid_ReturnsTrue(IValidateBinarySearchTree_98 solution, string solutionName)
        {
            // Input:  5
            //        /
            //       3
            // Output: true

            // Arrange
            var root = CreateSimpleTree(5, left: 3);

            // Act
            var result = solution.IsValidBST(root);

            // Assert
            Assert.IsTrue(result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsValidBST_TwoNodes_LeftChild_Invalid_ReturnsFalse(IValidateBinarySearchTree_98 solution, string solutionName)
        {
            // Input:  3
            //        /
            //       5
            // Output: false
            // Explanation: Left child is greater than root

            // Arrange
            var root = CreateSimpleTree(3, left: 5);

            // Act
            var result = solution.IsValidBST(root);

            // Assert
            Assert.IsFalse(result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsValidBST_TwoNodes_RightChild_Valid_ReturnsTrue(IValidateBinarySearchTree_98 solution, string solutionName)
        {
            // Input:  3
            //          \
            //           5
            // Output: true

            // Arrange
            var root = CreateSimpleTree(3, right: 5);

            // Act
            var result = solution.IsValidBST(root);

            // Assert
            Assert.IsTrue(result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsValidBST_TwoNodes_RightChild_Invalid_ReturnsFalse(IValidateBinarySearchTree_98 solution, string solutionName)
        {
            // Input:  5
            //          \
            //           3
            // Output: false
            // Explanation: Right child is less than root

            // Arrange
            var root = CreateSimpleTree(5, right: 3);

            // Act
            var result = solution.IsValidBST(root);

            // Assert
            Assert.IsFalse(result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsValidBST_ThreeNodes_Valid_ReturnsTrue(IValidateBinarySearchTree_98 solution, string solutionName)
        {
            // Input:    5
            //          / \
            //         3   7
            // Output: true

            // Arrange
            var root = CreateSimpleTree(5, left: 3, right: 7);

            // Act
            var result = solution.IsValidBST(root);

            // Assert
            Assert.IsTrue(result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsValidBST_ThreeNodes_LeftViolation_ReturnsFalse(IValidateBinarySearchTree_98 solution, string solutionName)
        {
            // Input:    5
            //          / \
            //         7   8
            // Output: false
            // Explanation: Left child is greater than root

            // Arrange
            var root = CreateSimpleTree(5, left: 7, right: 8);

            // Act
            var result = solution.IsValidBST(root);

            // Assert
            Assert.IsFalse(result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsValidBST_ThreeNodes_RightViolation_ReturnsFalse(IValidateBinarySearchTree_98 solution, string solutionName)
        {
            // Input:    5
            //          / \
            //         2   3
            // Output: false
            // Explanation: Right child is less than root

            // Arrange
            var root = CreateSimpleTree(5, left: 2, right: 3);

            // Act
            var result = solution.IsValidBST(root);

            // Assert
            Assert.IsFalse(result, $"Failed for {solutionName}");
        }

        #endregion

        #region Perfect Binary Search Trees

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsValidBST_PerfectBST_7Nodes_ReturnsTrue(IValidateBinarySearchTree_98 solution, string solutionName)
        {
            // Input:       4
            //            /   \
            //           2     6
            //          / \   / \
            //         1   3 5   7
            // Output: true

            // Arrange
            var root = CreateTree(new int?[] { 4, 2, 6, 1, 3, 5, 7 });

            // Act
            var result = solution.IsValidBST(root);

            // Assert
            Assert.IsTrue(result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsValidBST_PerfectBST_15Nodes_ReturnsTrue(IValidateBinarySearchTree_98 solution, string solutionName)
        {
            // Input:              8
            //                /       \
            //               4         12
            //             /   \      /   \
            //            2     6    10    14
            //           / \   / \   / \   / \
            //          1   3 5   7 9  11 13 15
            // Output: true

            // Arrange
            var root = CreateTree(new int?[] { 8, 4, 12, 2, 6, 10, 14, 1, 3, 5, 7, 9, 11, 13, 15 });

            // Act
            var result = solution.IsValidBST(root);

            // Assert
            Assert.IsTrue(result, $"Failed for {solutionName}");
        }

        #endregion

        #region Subtree Violations

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsValidBST_LeftSubtreeViolation_ReturnsFalse(IValidateBinarySearchTree_98 solution, string solutionName)
        {
            // Input:       10
            //            /    \
            //           5      15
            //          / \
            //         3   12
            // Output: false
            // Explanation: 12 is in left subtree of 10, but 12 > 10

            // Arrange
            var root = CreateTree(new int?[] { 10, 5, 15, 3, 12 });

            // Act
            var result = solution.IsValidBST(root);

            // Assert
            Assert.IsFalse(result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsValidBST_RightSubtreeViolation_ReturnsFalse(IValidateBinarySearchTree_98 solution, string solutionName)
        {
            // Input:       10
            //            /    \
            //           5      15
            //                 /  \
            //                8   20
            // Output: false
            // Explanation: 8 is in right subtree of 10, but 8 < 10

            // Arrange
            var root = CreateTree(new int?[] { 10, 5, 15, null, null, 8, 20 });

            // Act
            var result = solution.IsValidBST(root);

            // Assert
            Assert.IsFalse(result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsValidBST_DeepLeftSubtreeViolation_ReturnsFalse(IValidateBinarySearchTree_98 solution, string solutionName)
        {
            // Input:         20
            //              /    \
            //            10      30
            //           /  \
            //          5    15
            //         /
            //        25
            // Output: false
            // Explanation: 25 is in left subtree of 20, but 25 > 20

            // Arrange
            var root = CreateTree(new int?[] { 20, 10, 30, 5, 15, null, null, 25 });

            // Act
            var result = solution.IsValidBST(root);

            // Assert
            Assert.IsFalse(result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsValidBST_DeepRightSubtreeViolation_ReturnsFalse(IValidateBinarySearchTree_98 solution, string solutionName)
        {
            // Input:         20
            //              /    \
            //            10      30
            //                   /  \
            //                  25   35
            //                         \
            //                          15
            // Output: false
            // Explanation: 15 is in right subtree of 20, but 15 < 20

            // Arrange
            var root = CreateTree(new int?[] { 20, 10, 30, null, null, 25, 35, null, null, null, 15 });

            // Act
            var result = solution.IsValidBST(root);

            // Assert
            Assert.IsFalse(result, $"Failed for {solutionName}");
        }

        #endregion

        #region Equal Values (BST does not allow duplicates in standard definition)

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsValidBST_EqualValueLeftChild_ReturnsFalse(IValidateBinarySearchTree_98 solution, string solutionName)
        {
            // Input:  5
            //        /
            //       5
            // Output: false
            // Explanation: BST requires left < root, not left <= root

            // Arrange
            var root = CreateSimpleTree(5, left: 5);

            // Act
            var result = solution.IsValidBST(root);

            // Assert
            Assert.IsFalse(result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsValidBST_EqualValueRightChild_ReturnsFalse(IValidateBinarySearchTree_98 solution, string solutionName)
        {
            // Input:  5
            //          \
            //           5
            // Output: false
            // Explanation: BST requires right > root, not right >= root

            // Arrange
            var root = CreateSimpleTree(5, right: 5);

            // Act
            var result = solution.IsValidBST(root);

            // Assert
            Assert.IsFalse(result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsValidBST_DuplicateValuesInTree_ReturnsFalse(IValidateBinarySearchTree_98 solution, string solutionName)
        {
            // Input:       5
            //            /   \
            //           3     7
            //          / \   
            //         2   5
            // Output: false
            // Explanation: Duplicate value 5

            // Arrange
            var root = CreateTree(new int?[] { 5, 3, 7, 2, 5 });

            // Act
            var result = solution.IsValidBST(root);

            // Assert
            Assert.IsFalse(result, $"Failed for {solutionName}");
        }

        #endregion

        #region Skewed Trees

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsValidBST_LeftSkewed_Increasing_ReturnsTrue(IValidateBinarySearchTree_98 solution, string solutionName)
        {
            // Input:      5
            //            /
            //           4
            //          /
            //         3
            //        /
            //       2
            //      /
            //     1
            // Output: true

            // Arrange
            var root = CreateTree(new int?[] { 5, 4, null, 3, null, 2, null, 1 });

            // Act
            var result = solution.IsValidBST(root);

            // Assert
            Assert.IsTrue(result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsValidBST_LeftSkewed_Decreasing_ReturnsFalse(IValidateBinarySearchTree_98 solution, string solutionName)
        {
            // Input:      1
            //            /
            //           2
            //          /
            //         3
            //        /
            //       4
            //      /
            //     5
            // Output: false
            // Explanation: Each left child is greater than parent

            // Arrange
            var root = CreateTree(new int?[] { 1, 2, null, 3, null, 4, null, 5 });

            // Act
            var result = solution.IsValidBST(root);

            // Assert
            Assert.IsFalse(result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsValidBST_RightSkewed_Increasing_ReturnsTrue(IValidateBinarySearchTree_98 solution, string solutionName)
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
            // Output: true

            // Arrange
            var root = CreateTree(new int?[] { 1, null, 2, null, 3, null, 4, null, 5 });

            // Act
            var result = solution.IsValidBST(root);

            // Assert
            Assert.IsTrue(result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsValidBST_RightSkewed_Decreasing_ReturnsFalse(IValidateBinarySearchTree_98 solution, string solutionName)
        {
            // Input:  5
            //          \
            //           4
            //            \
            //             3
            //              \
            //               2
            //                \
            //                 1
            // Output: false
            // Explanation: Each right child is less than parent

            // Arrange
            var root = CreateTree(new int?[] { 5, null, 4, null, 3, null, 2, null, 1 });

            // Act
            var result = solution.IsValidBST(root);

            // Assert
            Assert.IsFalse(result, $"Failed for {solutionName}");
        }

        #endregion

        #region Edge Cases - Integer Boundaries




        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsValidBST_NegativeValues_Valid_ReturnsTrue(IValidateBinarySearchTree_98 solution, string solutionName)
        {
            // Input:       0
            //            /   \
            //          -5     5
            //          / \   / \
            //        -8  -3 3   8
            // Output: true

            // Arrange
            var root = CreateTree(new int?[] { 0, -5, 5, -8, -3, 3, 8 });

            // Act
            var result = solution.IsValidBST(root);

            // Assert
            Assert.IsTrue(result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsValidBST_AllNegativeValues_Valid_ReturnsTrue(IValidateBinarySearchTree_98 solution, string solutionName)
        {
            // Input:       -4
            //            /    \
            //          -6     -2
            //          / \    / \
            //        -7  -5 -3  -1
            // Output: true

            // Arrange
            var root = CreateTree(new int?[] { -4, -6, -2, -7, -5, -3, -1 });

            // Act
            var result = solution.IsValidBST(root);

            // Assert
            Assert.IsTrue(result, $"Failed for {solutionName}");
        }

        #endregion

        #region Complex Valid Trees

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsValidBST_ComplexValidTree1_ReturnsTrue(IValidateBinarySearchTree_98 solution, string solutionName)
        {
            // Input:           10
            //               /      \
            //              5        15
            //            /   \        \
            //           3     7       20
            //          / \   / \
            //         1   4 6   8
            // Output: true

            // Arrange
            var root = CreateTree(new int?[] { 10, 5, 15, 3, 7, null, 20, 1, 4, 6, 8 });

            // Act
            var result = solution.IsValidBST(root);

            // Assert
            Assert.IsTrue(result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsValidBST_ComplexValidTree2_ReturnsTrue(IValidateBinarySearchTree_98 solution, string solutionName)
        {
            // Input:           20
            //               /      \
            //              10       30
            //            /   \     /   \
            //           5    15   25   35
            //          / \   /
            //         3   7 12
            // Output: true

            // Arrange
            var root = CreateTree(new int?[] { 20, 10, 30, 5, 15, 25, 35, 3, 7, 12 });

            // Act
            var result = solution.IsValidBST(root);

            // Assert
            Assert.IsTrue(result, $"Failed for {solutionName}");
        }

        #endregion

        #region Complex Invalid Trees

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsValidBST_ComplexInvalidTree1_ReturnsFalse(IValidateBinarySearchTree_98 solution, string solutionName)
        {
            // Input:           10
            //               /      \
            //              5        15
            //            /   \      /  \
            //           3     8    12   20
            //                / \
            //               6   11
            // Output: false
            // Explanation: 11 is in left subtree of 10 but 11 > 10

            // Arrange
            var root = CreateTree(new int?[] { 10, 5, 15, 3, 8, 12, 20, null, null, 6, 11 });

            // Act
            var result = solution.IsValidBST(root);

            // Assert
            Assert.IsFalse(result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsValidBST_ComplexInvalidTree2_ReturnsFalse(IValidateBinarySearchTree_98 solution, string solutionName)
        {
            // Input:           20
            //               /      \
            //              10       30
            //            /   \     /   \
            //           5    15   25   35
            //          / \   /          \
            //         3   7 18          22
            // Output: false
            // Explanation: 22 is in right subtree of 20 but in left path of 35, and 22 < 25 (parent of 35)

            // Arrange
            var root = CreateTree(new int?[] { 20, 10, 30, 5, 15, 25, 35, 3, 7, 18, null, null, null, null, 22 });

            // Act
            var result = solution.IsValidBST(root);

            // Assert
            Assert.IsFalse(result, $"Failed for {solutionName}");
        }

        #endregion

        #region Sparse Trees

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsValidBST_SparseTree_Valid_ReturnsTrue(IValidateBinarySearchTree_98 solution, string solutionName)
        {
            // Input:       10
            //            /    \
            //           5      15
            //            \       \
            //             7      20
            // Output: true

            // Arrange
            var root = CreateTree(new int?[] { 10, 5, 15, null, 7, null, 20 });

            // Act
            var result = solution.IsValidBST(root);

            // Assert
            Assert.IsTrue(result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsValidBST_SparseTree_Invalid_ReturnsFalse(IValidateBinarySearchTree_98 solution, string solutionName)
        {
            // Input:       10
            //            /    \
            //           5      15
            //            \       \
            //            12      20
            // Output: false
            // Explanation: 12 is in left subtree of 10 but 12 > 10

            // Arrange
            var root = CreateTree(new int?[] { 10, 5, 15, null, 12, null, 20 });

            // Act
            var result = solution.IsValidBST(root);

            // Assert
            Assert.IsFalse(result, $"Failed for {solutionName}");
        }

        #endregion

        #region Boundary Conditions

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsValidBST_LargeValidTree_ReturnsTrue(IValidateBinarySearchTree_98 solution, string solutionName)
        {
            // Input: Large valid BST (31 nodes)
            // Output: true

            // Arrange
            var root = CreateTree(new int?[] { 
                50, 25, 75, 12, 37, 62, 87, 6, 18, 31, 43, 56, 68, 81, 93,
                3, 9, 15, 21, 28, 34, 40, 46, 53, 59, 65, 71, 78, 84, 90, 96
            });

            // Act
            var result = solution.IsValidBST(root);

            // Assert
            Assert.IsTrue(result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsValidBST_VeryDeepLeftSkewed_Valid_ReturnsTrue(IValidateBinarySearchTree_98 solution, string solutionName)
        {
            // Deep left-skewed tree with 20 nodes (decreasing values)
            // Output: true

            // Arrange
            TreeNode root = new TreeNode(20);
            TreeNode current = root;
            for (int i = 19; i >= 1; i--)
            {
                current.left = new TreeNode(i);
                current = current.left;
            }

            // Act
            var result = solution.IsValidBST(root);

            // Assert
            Assert.IsTrue(result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsValidBST_VeryDeepRightSkewed_Valid_ReturnsTrue(IValidateBinarySearchTree_98 solution, string solutionName)
        {
            // Deep right-skewed tree with 20 nodes (increasing values)
            // Output: true

            // Arrange
            TreeNode root = new TreeNode(1);
            TreeNode current = root;
            for (int i = 2; i <= 20; i++)
            {
                current.right = new TreeNode(i);
                current = current.right;
            }

            // Act
            var result = solution.IsValidBST(root);

            // Assert
            Assert.IsTrue(result, $"Failed for {solutionName}");
        }

        #endregion

        #region Tricky Cases

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsValidBST_TrickyCase_RootEqualToIntMax_Invalid_ReturnsFalse(IValidateBinarySearchTree_98 solution, string solutionName)
        {
            // Input:  int.MaxValue
            //              \
            //          int.MaxValue
            // Output: false
            // Explanation: Duplicate values

            // Arrange
            var root = CreateSimpleTree(int.MaxValue, right: int.MaxValue);

            // Act
            var result = solution.IsValidBST(root);

            // Assert
            Assert.IsFalse(result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsValidBST_TrickyCase_RootEqualToIntMin_Invalid_ReturnsFalse(IValidateBinarySearchTree_98 solution, string solutionName)
        {
            // Input:      int.MinValue
            //            /
            //       int.MinValue
            // Output: false
            // Explanation: Duplicate values

            // Arrange
            var root = CreateSimpleTree(int.MinValue, left: int.MinValue);

            // Act
            var result = solution.IsValidBST(root);

            // Assert
            Assert.IsFalse(result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsValidBST_AlmostValid_OneNodeViolation_ReturnsFalse(IValidateBinarySearchTree_98 solution, string solutionName)
        {
            // Input:           10
            //               /      \
            //              5        15
            //            /   \      /  \
            //           2     7    12   20
            //          / \   / \   / \  / \
            //         1   3 6   8 11 13 19 21
            //                      \
            //                       9
            // Output: false
            // Explanation: 9 is in right subtree of 10 but < 10 (in left child of 12, violates BST for 15)

            // Arrange
            var root = CreateTree(new int?[] { 10, 5, 15, 2, 7, 12, 20, 1, 3, 6, 8, 11, 13, 19, 21, null, null, null, null, null, null, null, null, null, 9 });

            // Act
            var result = solution.IsValidBST(root);

            // Assert
            Assert.IsFalse(result, $"Failed for {solutionName}");
        }

        #endregion

        #region Property-Based Tests

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsValidBST_InOrderSequence_StrictlyIncreasing_ReturnsTrue(IValidateBinarySearchTree_98 solution, string solutionName)
        {
            // Any tree with strictly increasing in-order traversal is a valid BST
            // In-order of [1, 2, 3, 4, 5]

            // Arrange - Create balanced BST with values 1-5
            var root = CreateTree(new int?[] { 3, 2, 4, 1, null, null, 5 });

            // Act
            var result = solution.IsValidBST(root);

            // Assert
            Assert.IsTrue(result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsValidBST_InOrderSequence_NotStrictlyIncreasing_ReturnsFalse(IValidateBinarySearchTree_98 solution, string solutionName)
        {
            // In-order with duplicate: [1, 2, 2, 3, 4]

            // Arrange
            var root = CreateTree(new int?[] { 2, 2, 3, 1, null, null, 4 });

            // Act
            var result = solution.IsValidBST(root);

            // Assert
            Assert.IsFalse(result, $"Failed for {solutionName}");
        }

        #endregion
    }
}
