using LeetCodeProblems.CSharp.Tree;
using LeetCodeProblems.Interfaces.Medium;
using LeetCodeProblems.Shared;

namespace GrindingLeetCode.UnitTests.Medium
{
    [TestClass]
    public class CountGoodNodesInBinaryTree_1448_Tests
    {
        public static IEnumerable<object[]> GetImplementations()
        {
            yield return new object[] { new CountGoodNodesInBinaryTree_CSharp_DFS_1448(), "DFS Recursive" };
            yield return new object[] { new CountGoodNodesInBinaryTree_CSharp_DFS_Iterative_1448(), "DFS Iterative" };
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
        public void GoodNodes_Example1_Returns4(ICountGoodNodesInBinaryTree_1448 solution, string solutionName)
        {
            // Input: root = [3,1,4,3,null,1,5]
            //        3
            //       / \
            //      1   4
            //     /   / \
            //    3   1   5
            // Output: 4
            // Explanation: Nodes in blue are good.
            // Root Node (3) is always a good node.
            // Node 4 -> (3,4) is the maximum value in the path starting from the root.
            // Node 5 -> (3,4,5) is the maximum value in the path
            // Node 3 -> (3,1,3) is the maximum value in the path.

            // Arrange
            var root = CreateTree(new int?[] { 3, 1, 4, 3, null, 1, 5 });

            // Act
            var result = solution.GoodNodes(root);

            // Assert
            Assert.AreEqual(4, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void GoodNodes_Example2_Returns3(ICountGoodNodesInBinaryTree_1448 solution, string solutionName)
        {
            // Input: root = [3,3,null,4,2]
            //      3
            //     /
            //    3
            //   / \
            //  4   2
            // Output: 3
            // Explanation: Node 2 -> (3, 3, 2) is not good, because "3" is higher than it.

            // Arrange
            var root = CreateTree(new int?[] { 3, 3, null, 4, 2 });

            // Act
            var result = solution.GoodNodes(root);

            // Assert
            Assert.AreEqual(3, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void GoodNodes_Example3_Returns1(ICountGoodNodesInBinaryTree_1448 solution, string solutionName)
        {
            // Input: root = [1]
            // Output: 1
            // Explanation: Root is considered good.

            // Arrange
            var root = CreateTree(new int?[] { 1 });

            // Act
            var result = solution.GoodNodes(root);

            // Assert
            Assert.AreEqual(1, result, $"Failed for {solutionName}");
        }

        #endregion

        #region Basic Tree Structures

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void GoodNodes_SingleNode_Returns1(ICountGoodNodesInBinaryTree_1448 solution, string solutionName)
        {
            // Input: root = [5]
            // Output: 1
            // Explanation: Root is always good

            // Arrange
            var root = new TreeNode(5);

            // Act
            var result = solution.GoodNodes(root);

            // Assert
            Assert.AreEqual(1, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void GoodNodes_TwoNodes_LeftChildSmaller_Returns1(ICountGoodNodesInBinaryTree_1448 solution, string solutionName)
        {
            // Input:  5
            //        /
            //       3
            // Output: 1
            // Explanation: Only root is good (3 < 5)

            // Arrange
            var root = CreateSimpleTree(5, left: 3);

            // Act
            var result = solution.GoodNodes(root);

            // Assert
            Assert.AreEqual(1, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void GoodNodes_TwoNodes_LeftChildLarger_Returns2(ICountGoodNodesInBinaryTree_1448 solution, string solutionName)
        {
            // Input:  3
            //        /
            //       5
            // Output: 2
            // Explanation: Both nodes are good (5 >= 3)

            // Arrange
            var root = CreateSimpleTree(3, left: 5);

            // Act
            var result = solution.GoodNodes(root);

            // Assert
            Assert.AreEqual(2, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void GoodNodes_TwoNodes_RightChildSmaller_Returns1(ICountGoodNodesInBinaryTree_1448 solution, string solutionName)
        {
            // Input:  5
            //          \
            //           3
            // Output: 1
            // Explanation: Only root is good (3 < 5)

            // Arrange
            var root = CreateSimpleTree(5, right: 3);

            // Act
            var result = solution.GoodNodes(root);

            // Assert
            Assert.AreEqual(1, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void GoodNodes_TwoNodes_RightChildLarger_Returns2(ICountGoodNodesInBinaryTree_1448 solution, string solutionName)
        {
            // Input:  3
            //          \
            //           5
            // Output: 2
            // Explanation: Both nodes are good (5 >= 3)

            // Arrange
            var root = CreateSimpleTree(3, right: 5);

            // Act
            var result = solution.GoodNodes(root);

            // Assert
            Assert.AreEqual(2, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void GoodNodes_ThreeNodes_BothChildrenSmaller_Returns1(ICountGoodNodesInBinaryTree_1448 solution, string solutionName)
        {
            // Input:    5
            //          / \
            //         3   4
            // Output: 1
            // Explanation: Only root is good

            // Arrange
            var root = CreateSimpleTree(5, left: 3, right: 4);

            // Act
            var result = solution.GoodNodes(root);

            // Assert
            Assert.AreEqual(1, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void GoodNodes_ThreeNodes_BothChildrenLarger_Returns3(ICountGoodNodesInBinaryTree_1448 solution, string solutionName)
        {
            // Input:    3
            //          / \
            //         5   6
            // Output: 3
            // Explanation: All nodes are good

            // Arrange
            var root = CreateSimpleTree(3, left: 5, right: 6);

            // Act
            var result = solution.GoodNodes(root);

            // Assert
            Assert.AreEqual(3, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void GoodNodes_ThreeNodes_EqualValues_Returns3(ICountGoodNodesInBinaryTree_1448 solution, string solutionName)
        {
            // Input:    5
            //          / \
            //         5   5
            // Output: 3
            // Explanation: All nodes are good (equal counts as good)

            // Arrange
            var root = CreateSimpleTree(5, left: 5, right: 5);

            // Act
            var result = solution.GoodNodes(root);

            // Assert
            Assert.AreEqual(3, result, $"Failed for {solutionName}");
        }

        #endregion

        #region Increasing Path Tests

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void GoodNodes_IncreasingLeftPath_AllNodesGood(ICountGoodNodesInBinaryTree_1448 solution, string solutionName)
        {
            // Input:      1
            //            /
            //           2
            //          /
            //         3
            //        /
            //       4
            // Output: 4
            // Explanation: All nodes form an increasing path

            // Arrange
            var root = CreateTree(new int?[] { 1, 2, null, 3, null, 4 });

            // Act
            var result = solution.GoodNodes(root);

            // Assert
            Assert.AreEqual(4, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void GoodNodes_IncreasingRightPath_AllNodesGood(ICountGoodNodesInBinaryTree_1448 solution, string solutionName)
        {
            // Input:  1
            //          \
            //           2
            //            \
            //             3
            //              \
            //               4
            // Output: 4
            // Explanation: All nodes form an increasing path

            // Arrange
            var root = CreateTree(new int?[] { 1, null, 2, null, 3, null, 4 });

            // Act
            var result = solution.GoodNodes(root);

            // Assert
            Assert.AreEqual(4, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void GoodNodes_NonDecreasingPath_AllNodesGood(ICountGoodNodesInBinaryTree_1448 solution, string solutionName)
        {
            // Input:      3
            //            /
            //           3
            //          /
            //         3
            //        /
            //       3
            // Output: 4
            // Explanation: All nodes equal, all good

            // Arrange
            var root = CreateTree(new int?[] { 3, 3, null, 3, null, 3 });

            // Act
            var result = solution.GoodNodes(root);

            // Assert
            Assert.AreEqual(4, result, $"Failed for {solutionName}");
        }

        #endregion

        #region Decreasing Path Tests

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void GoodNodes_DecreasingLeftPath_OnlyRootGood(ICountGoodNodesInBinaryTree_1448 solution, string solutionName)
        {
            // Input:      10
            //            /
            //           8
            //          /
            //         6
            //        /
            //       4
            // Output: 1
            // Explanation: Only root is good

            // Arrange
            var root = CreateTree(new int?[] { 10, 8, null, 6, null, 4 });

            // Act
            var result = solution.GoodNodes(root);

            // Assert
            Assert.AreEqual(1, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void GoodNodes_DecreasingRightPath_OnlyRootGood(ICountGoodNodesInBinaryTree_1448 solution, string solutionName)
        {
            // Input:  10
            //          \
            //           8
            //            \
            //             6
            //              \
            //               4
            // Output: 1
            // Explanation: Only root is good

            // Arrange
            var root = CreateTree(new int?[] { 10, null, 8, null, 6, null, 4 });

            // Act
            var result = solution.GoodNodes(root);

            // Assert
            Assert.AreEqual(1, result, $"Failed for {solutionName}");
        }

        #endregion

        #region Mixed Increasing/Decreasing Paths

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void GoodNodes_ZigZagIncreasing_MultipleGoodNodes(ICountGoodNodesInBinaryTree_1448 solution, string solutionName)
        {
            // Input:    1
            //            \
            //             3
            //            /
            //           2
            //            \
            //             4
            // Output: 3
            // Explanation: 1, 3, and 4 are good (2 < 3)

            // Arrange
            var root = new TreeNode(1);
            root.right = new TreeNode(3);
            root.right.left = new TreeNode(2);
            root.right.left.right = new TreeNode(4);

            // Act
            var result = solution.GoodNodes(root);

            // Assert
            Assert.AreEqual(3, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void GoodNodes_UpDownPattern_CountsCorrectly(ICountGoodNodesInBinaryTree_1448 solution, string solutionName)
        {
            // Input:      5
            //            /
            //           3
            //          /
            //         4
            //        /
            //       2

            // Arrange
            var root = CreateTree(new int?[] { 5, 3, null, 4, null, 2 });

            // Act
            var result = solution.GoodNodes(root);

            // Assert
            Assert.AreEqual(1, result, $"Failed for {solutionName}");
        }

        #endregion

        #region Balanced Trees

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void GoodNodes_BalancedTree_AllIncreasing_AllGood(ICountGoodNodesInBinaryTree_1448 solution, string solutionName)
        {
            // Input:       1
            //            /   \
            //           2     3
            //          / \   / \
            //         4   5 6   7
            // Output: 7
            // Explanation: All nodes are good (all increasing from root)

            // Arrange
            var root = CreateTree(new int?[] { 1, 2, 3, 4, 5, 6, 7 });

            // Act
            var result = solution.GoodNodes(root);

            // Assert
            Assert.AreEqual(7, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void GoodNodes_BalancedTree_MixedValues_CountsCorrectly(ICountGoodNodesInBinaryTree_1448 solution, string solutionName)
        {
            // Input:       5
            //            /   \
            //           3     7
            //          / \   / \
            //         2   4 6   8
            // Output: 4
            

            // Arrange
            var root = CreateTree(new int?[] { 5, 3, 7, 2, 4, 6, 8 });

            // Act
            var result = solution.GoodNodes(root);

            // Assert
            Assert.AreEqual(3, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void GoodNodes_PerfectBinarySearchTree_CountsCorrectly(ICountGoodNodesInBinaryTree_1448 solution, string solutionName)
        {
            // Input:       4
            //            /   \
            //           2     6
            //          / \   / \
            //         1   3 5   7

            // Arrange
            var root = CreateTree(new int?[] { 4, 2, 6, 1, 3, 5, 7 });

            // Act
            var result = solution.GoodNodes(root);

            // Assert
            Assert.AreEqual(3, result, $"Failed for {solutionName}");
        }

        #endregion

        #region Edge Cases - Values

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void GoodNodes_NegativeValues_CountsCorrectly(ICountGoodNodesInBinaryTree_1448 solution, string solutionName)
        {
            // Input:       -1
            //            /    \
            //          -2     -3
            //          / \    / \
            //        -4  -1  -5  0

            // Arrange
            var root = CreateTree(new int?[] { -1, -2, -3, -4, -1, -5, 0 });

            // Act
            var result = solution.GoodNodes(root);

            // Assert
            Assert.AreEqual(3, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void GoodNodes_AllNegativeValues_CountsCorrectly(ICountGoodNodesInBinaryTree_1448 solution, string solutionName)
        {
            // Input:       -5
            //            /    \
            //          -3     -7
            //          / \    / \
            //        -2  -4 -6  -8
            // Output: 3
            // Explanation: -5, -3, -2 are good (-3 > -5, -2 > -3)

            // Arrange
            var root = CreateTree(new int?[] { -5, -3, -7, -2, -4, -6, -8 });

            // Act
            var result = solution.GoodNodes(root);

            // Assert
            Assert.AreEqual(3, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void GoodNodes_ZeroRoot_CountsCorrectly(ICountGoodNodesInBinaryTree_1448 solution, string solutionName)
        {
            // Input:       0
            //            /   \
            //          -1     1
            //          / \   / \
            //        -2   0 0   2

            // Arrange
            var root = CreateTree(new int?[] { 0, -1, 1, -2, 0, 0, 2 });

            // Act
            var result = solution.GoodNodes(root);

            // Assert
            Assert.AreEqual(4, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void GoodNodes_LargeValues_CountsCorrectly(ICountGoodNodesInBinaryTree_1448 solution, string solutionName)
        {
            // Input:       10000
            //            /       \
            //         9999      10001
            //          / \       / \
            //      9998 10000 10000 10002
            // Output: 5
            // Explanation: 10000(root), 10000(left), 10001, 10000(right), 10002 are good

            // Arrange
            var root = CreateTree(new int?[] { 10000, 9999, 10001, 9998, 10000, 10000, 10002 });

            // Act
            var result = solution.GoodNodes(root);

            // Assert
            Assert.AreEqual(4, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void GoodNodes_MinMaxValues_CountsCorrectly(ICountGoodNodesInBinaryTree_1448 solution, string solutionName)
        {
            // Input:          0
            //              /     \
            //          -10000   10000
            //           / \      / \
            //       -5000  0    0  5000
            // Output: 5
            // Explanation: 0(root), 0(left), 10000, 0(right), 5000 are good

            // Arrange
            var root = CreateTree(new int?[] { 0, -10000, 10000, -5000, 0, 0, 5000 });

            // Act
            var result = solution.GoodNodes(root);

            // Assert
            Assert.AreEqual(3, result, $"Failed for {solutionName}");
        }

        #endregion

        #region Duplicate Values

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void GoodNodes_AllSameValues_AllNodesGood(ICountGoodNodesInBinaryTree_1448 solution, string solutionName)
        {
            // Input:       5
            //            /   \
            //           5     5
            //          / \   / \
            //         5   5 5   5
            // Output: 7
            // Explanation: All nodes are good (all equal)

            // Arrange
            var root = CreateTree(new int?[] { 5, 5, 5, 5, 5, 5, 5 });

            // Act
            var result = solution.GoodNodes(root);

            // Assert
            Assert.AreEqual(7, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void GoodNodes_DuplicatesInPath_CountsCorrectly(ICountGoodNodesInBinaryTree_1448 solution, string solutionName)
        {
            // Input:      5
            //            /
            //           5
            //          /
            //         5
            //        /
            //       3
            // Output: 3
            // Explanation: All 5s are good, 3 is not

            // Arrange
            var root = CreateTree(new int?[] { 5, 5, null, 5, null, 3 });

            // Act
            var result = solution.GoodNodes(root);

            // Assert
            Assert.AreEqual(3, result, $"Failed for {solutionName}");
        }

        #endregion

        #region Complex Trees

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void GoodNodes_AsymmetricTree_CountsCorrectly(ICountGoodNodesInBinaryTree_1448 solution, string solutionName)
        {
            // Input:           10
            //               /      \
            //              5        15
            //            /   \        \
            //           3     7       20
            //          / \     \
            //         1   4     9
            // Output: 7
            

            // Arrange
            var root = CreateTree(new int?[] { 10, 5, 15, 3, 7, null, 20, 1, 4, null, 9 });

            // Act
            var result = solution.GoodNodes(root);

            // Assert
            Assert.AreEqual(3, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void GoodNodes_DeepTree_CountsCorrectly(ICountGoodNodesInBinaryTree_1448 solution, string solutionName)
        {
            // Input: Deep tree with 15 nodes
            //              8
            //            /   \
            //           4     12
            //          / \    / \
            //         2   6  10  14
            //        /\  /\ /\  /\
            //       1 3 5 7 9 11 13 15
            // Output: 8
            // Explanation: 8, 12, 14, 15, 6, 7, 11, 13 are good

            // Arrange
            var root = CreateTree(new int?[] { 8, 4, 12, 2, 6, 10, 14, 1, 3, 5, 7, 9, 11, 13, 15 });

            // Act
            var result = solution.GoodNodes(root);

            // Assert
            Assert.AreEqual(4, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void GoodNodes_SparseTree_CountsCorrectly(ICountGoodNodesInBinaryTree_1448 solution, string solutionName)
        {
            // Input:       8
            //            /   \
            //           4     12
            //            \   /
            //             6 10

            // Arrange
            var root = CreateTree(new int?[] { 8, 4, 12, null, 6, 10 });

            // Act
            var result = solution.GoodNodes(root);

            // Assert
            Assert.AreEqual(2, result, $"Failed for {solutionName}");
        }

        #endregion

        #region Path-Specific Tests

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void GoodNodes_DifferentPathsDifferentMaxValues_CountsIndependently(ICountGoodNodesInBinaryTree_1448 solution, string solutionName)
        {
            // Input:       5
            //            /   \
            //           8     3
            //          / \   / \
            //         7   9 2   4
            // Output: 5
            

            // Arrange
            var root = CreateTree(new int?[] { 5, 8, 3, 7, 9, 2, 4 });

            // Act
            var result = solution.GoodNodes(root);

            // Assert
            Assert.AreEqual(3, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void GoodNodes_LongPathWithPeaks_CountsOnlyIncreasing(ICountGoodNodesInBinaryTree_1448 solution, string solutionName)
        {
            // Input:      10
            //            /
            //           5
            //          /
            //         8
            //        /
            //       3
            //      /
            //     9

            // Arrange
            var root = CreateTree(new int?[] { 10, 5, null, 8, null, 3, null, 9 });

            // Act
            var result = solution.GoodNodes(root);

            // Assert
            Assert.AreEqual(1, result, $"Failed for {solutionName}");
        }

        #endregion

        #region Large Trees

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void GoodNodes_VeryDeepLeftSkewed_Increasing_AllGood(ICountGoodNodesInBinaryTree_1448 solution, string solutionName)
        {
            // Deep left-skewed tree with increasing values (20 nodes)
            // Output: 20

            // Arrange
            TreeNode root = new TreeNode(1);
            TreeNode current = root;
            for (int i = 2; i <= 20; i++)
            {
                current.left = new TreeNode(i);
                current = current.left;
            }

            // Act
            var result = solution.GoodNodes(root);

            // Assert
            Assert.AreEqual(20, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void GoodNodes_VeryDeepLeftSkewed_Decreasing_OnlyRootGood(ICountGoodNodesInBinaryTree_1448 solution, string solutionName)
        {
            // Deep left-skewed tree with decreasing values (20 nodes)
            // Output: 1

            // Arrange
            TreeNode root = new TreeNode(20);
            TreeNode current = root;
            for (int i = 19; i >= 1; i--)
            {
                current.left = new TreeNode(i);
                current = current.left;
            }

            // Act
            var result = solution.GoodNodes(root);

            // Assert
            Assert.AreEqual(1, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void GoodNodes_VeryDeepRightSkewed_Increasing_AllGood(ICountGoodNodesInBinaryTree_1448 solution, string solutionName)
        {
            // Deep right-skewed tree with increasing values (20 nodes)
            // Output: 20

            // Arrange
            TreeNode root = new TreeNode(1);
            TreeNode current = root;
            for (int i = 2; i <= 20; i++)
            {
                current.right = new TreeNode(i);
                current = current.right;
            }

            // Act
            var result = solution.GoodNodes(root);

            // Assert
            Assert.AreEqual(20, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void GoodNodes_LargePerfectTree_CountsCorrectly(ICountGoodNodesInBinaryTree_1448 solution, string solutionName)
        {
            // Arrange
            var root = CreateTree(new int?[] { 
                16, 8, 24, 4, 12, 20, 28, 2, 6, 10, 14, 18, 22, 26, 30,
                1, 3, 5, 7, 9, 11, 13, 15, 17, 19, 21, 23, 25, 27, 29, 31
            });

            // Act
            var result = solution.GoodNodes(root);

            // Assert
            Assert.AreEqual(5, result, $"Failed for {solutionName}");
        }

        #endregion

        #region Boundary and Special Cases

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void GoodNodes_AlternatingValues_CountsCorrectly(ICountGoodNodesInBinaryTree_1448 solution, string solutionName)
        {
            // Input:      5
            //            /
            //           10
            //          /
            //         5
            //        /
            //       10
            // Output: 3
            // Explanation: 5, 10, 10 are good

            // Arrange
            var root = CreateTree(new int?[] { 5, 10, null, 5, null, 10 });

            // Act
            var result = solution.GoodNodes(root);

            // Assert
            Assert.AreEqual(3, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void GoodNodes_MaxAtDifferentLevels_CountsCorrectly(ICountGoodNodesInBinaryTree_1448 solution, string solutionName)
        {
            // Input:       3
            //            /   \
            //           9     2
            //          / \   / \
            //         5  10 1   4

            // Arrange
            var root = CreateTree(new int?[] { 3, 9, 2, 5, 10, 1, 4 });

            // Act
            var result = solution.GoodNodes(root);

            // Assert
            Assert.AreEqual(4, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void GoodNodes_OnlyLeafNodesGood_CountsCorrectly(ICountGoodNodesInBinaryTree_1448 solution, string solutionName)
        {
            // Input:       10
            //            /    \
            //           5      8
            //          / \    / \
            //         12  15 20  25
            // Output: 5
            // Explanation: Only root and all leaf nodes are good

            // Arrange
            var root = CreateTree(new int?[] { 10, 5, 8, 12, 15, 20, 25 });

            // Act
            var result = solution.GoodNodes(root);

            // Assert
            Assert.AreEqual(5, result, $"Failed for {solutionName}");
        }

        #endregion

        #region Property-Based Tests

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void GoodNodes_RootAlwaysGood_DifferentRootValues(ICountGoodNodesInBinaryTree_1448 solution, string solutionName)
        {
            // Root is always good regardless of value

            // Arrange
            var testValues = new[] { -10000, -1, 0, 1, 42, 1000, 10000 };

            foreach (var value in testValues)
            {
                var root = new TreeNode(value);

                // Act
                var result = solution.GoodNodes(root);

                // Assert
                Assert.AreEqual(1, result, $"Failed for value {value} with {solutionName}");
            }
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void GoodNodes_StrictlyIncreasingSequence_AllGood(ICountGoodNodesInBinaryTree_1448 solution, string solutionName)
        {
            // Any path with strictly increasing values should have all nodes good

            // Arrange - Create a path: 1 -> 2 -> 3 -> 4 -> 5
            var root = new TreeNode(1);
            root.left = new TreeNode(2);
            root.left.left = new TreeNode(3);
            root.left.left.left = new TreeNode(4);
            root.left.left.left.left = new TreeNode(5);

            // Act
            var result = solution.GoodNodes(root);

            // Assert
            Assert.AreEqual(5, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void GoodNodes_StrictlyDecreasingSequence_OnlyRootGood(ICountGoodNodesInBinaryTree_1448 solution, string solutionName)
        {
            // Any path with strictly decreasing values should have only root good

            // Arrange - Create a path: 5 -> 4 -> 3 -> 2 -> 1
            var root = new TreeNode(5);
            root.left = new TreeNode(4);
            root.left.left = new TreeNode(3);
            root.left.left.left = new TreeNode(2);
            root.left.left.left.left = new TreeNode(1);

            // Act
            var result = solution.GoodNodes(root);

            // Assert
            Assert.AreEqual(1, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void GoodNodes_BalancedTreeAllSameValue_AllNodesGood(ICountGoodNodesInBinaryTree_1448 solution, string solutionName)
        {
            // When all nodes have the same value, all should be good

            // Arrange
            var root = CreateTree(new int?[] { 7, 7, 7, 7, 7, 7, 7 });

            // Act
            var result = solution.GoodNodes(root);

            // Assert
            Assert.AreEqual(7, result, $"Failed for {solutionName}");
        }

        #endregion
    }
}
