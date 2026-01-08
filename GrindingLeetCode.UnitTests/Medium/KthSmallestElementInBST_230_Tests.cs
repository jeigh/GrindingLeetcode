using LeetCodeProblems.CSharp.Tree;
using LeetCodeProblems.Interfaces.Medium;
using LeetCodeProblems.Shared;

namespace GrindingLeetCode.UnitTests.Medium
{
    [TestClass]
    public class KthSmallestElementInBST_230_Tests
    {
        public static IEnumerable<object[]> GetImplementations()
        {
            yield return new object[] { new KthSmallestElementInBST_InOrder_CSharp_230(), "C# InOrder" };
            yield return new object[] { new KthSmallestElementInBST_RecursiveDFS_CSharp_230(), "C# Recursive DFS" };
            yield return new object[] { new KthSmallestElementInBST_IterativeDFS_CSharp_230(), "C# Iterative DFS" };
            yield return new object[] { new KthSmallestElementInBST_Morris_CSharp_230(), "C# Morris Traversal" };
        }

        #region Helper Methods

        /// <summary>
        /// Creates a binary search tree from an array representation (level-order with nulls)
        /// </summary>
        private TreeNode CreateBST(int?[] values)
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
        /// Helper to create a simple BST manually
        /// </summary>
        private TreeNode CreateSimpleBST(int root, int? left = null, int? right = null)
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
        public void KthSmallest_Example1_Returns1(IKthSmallestElementInBST_230 solution, string solutionName)
        {
            // Input: root = [3,1,4,null,2], k = 1
            //    3
            //   / \
            //  1   4
            //   \
            //    2
            // Output: 1
            // Explanation: The 1st smallest element is 1

            // Arrange
            var root = CreateBST(new int?[] { 3, 1, 4, null, 2 });
            int k = 1;

            // Act
            var result = solution.KthSmallest(root, k);

            // Assert
            Assert.AreEqual(1, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void KthSmallest_Example2_Returns3(IKthSmallestElementInBST_230 solution, string solutionName)
        {
            // Input: root = [5,3,6,2,4,null,null,1], k = 3
            //        5
            //       / \
            //      3   6
            //     / \
            //    2   4
            //   /
            //  1
            // Output: 3
            // Explanation: The 3rd smallest element is 3

            // Arrange
            var root = CreateBST(new int?[] { 5, 3, 6, 2, 4, null, null, 1 });
            int k = 3;

            // Act
            var result = solution.KthSmallest(root, k);

            // Assert
            Assert.AreEqual(3, result, $"Failed for {solutionName}");
        }

        #endregion

        #region Single Node Tests

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void KthSmallest_SingleNode_K1_ReturnsRootValue(IKthSmallestElementInBST_230 solution, string solutionName)
        {
            // Input: root = [5], k = 1
            // Output: 5

            // Arrange
            var root = new TreeNode(5);
            int k = 1;

            // Act
            var result = solution.KthSmallest(root, k);

            // Assert
            Assert.AreEqual(5, result, $"Failed for {solutionName}");
        }

        #endregion

        #region Two Node Tests

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void KthSmallest_TwoNodes_K1_ReturnsSmaller(IKthSmallestElementInBST_230 solution, string solutionName)
        {
            // Input: root = [2,1], k = 1
            //    2
            //   /
            //  1
            // Output: 1

            // Arrange
            var root = CreateBST(new int?[] { 2, 1 });
            int k = 1;

            // Act
            var result = solution.KthSmallest(root, k);

            // Assert
            Assert.AreEqual(1, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void KthSmallest_TwoNodes_K2_ReturnsLarger(IKthSmallestElementInBST_230 solution, string solutionName)
        {
            // Input: root = [2,1], k = 2
            //    2
            //   /
            //  1
            // Output: 2

            // Arrange
            var root = CreateBST(new int?[] { 2, 1 });
            int k = 2;

            // Act
            var result = solution.KthSmallest(root, k);

            // Assert
            Assert.AreEqual(2, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void KthSmallest_TwoNodesRightChild_K1_ReturnsRoot(IKthSmallestElementInBST_230 solution, string solutionName)
        {
            // Input: root = [1,null,2], k = 1
            //  1
            //   \
            //    2
            // Output: 1

            // Arrange
            var root = CreateBST(new int?[] { 1, null, 2 });
            int k = 1;

            // Act
            var result = solution.KthSmallest(root, k);

            // Assert
            Assert.AreEqual(1, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void KthSmallest_TwoNodesRightChild_K2_ReturnsRightChild(IKthSmallestElementInBST_230 solution, string solutionName)
        {
            // Input: root = [1,null,2], k = 2
            //  1
            //   \
            //    2
            // Output: 2

            // Arrange
            var root = CreateBST(new int?[] { 1, null, 2 });
            int k = 2;

            // Act
            var result = solution.KthSmallest(root, k);

            // Assert
            Assert.AreEqual(2, result, $"Failed for {solutionName}");
        }

        #endregion

        #region Three Node Tests

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void KthSmallest_ThreeNodes_K1_ReturnsSmallest(IKthSmallestElementInBST_230 solution, string solutionName)
        {
            // Input: root = [2,1,3], k = 1
            //    2
            //   / \
            //  1   3
            // Output: 1

            // Arrange
            var root = CreateSimpleBST(2, left: 1, right: 3);
            int k = 1;

            // Act
            var result = solution.KthSmallest(root, k);

            // Assert
            Assert.AreEqual(1, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void KthSmallest_ThreeNodes_K2_ReturnsMiddle(IKthSmallestElementInBST_230 solution, string solutionName)
        {
            // Input: root = [2,1,3], k = 2
            //    2
            //   / \
            //  1   3
            // Output: 2

            // Arrange
            var root = CreateSimpleBST(2, left: 1, right: 3);
            int k = 2;

            // Act
            var result = solution.KthSmallest(root, k);

            // Assert
            Assert.AreEqual(2, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void KthSmallest_ThreeNodes_K3_ReturnsLargest(IKthSmallestElementInBST_230 solution, string solutionName)
        {
            // Input: root = [2,1,3], k = 3
            //    2
            //   / \
            //  1   3
            // Output: 3

            // Arrange
            var root = CreateSimpleBST(2, left: 1, right: 3);
            int k = 3;

            // Act
            var result = solution.KthSmallest(root, k);

            // Assert
            Assert.AreEqual(3, result, $"Failed for {solutionName}");
        }

        #endregion

        #region Skewed Trees

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void KthSmallest_LeftSkewedTree_K1_ReturnsSmallest(IKthSmallestElementInBST_230 solution, string solutionName)
        {
            // Input: root = [5,4,null,3,null,2,null,1], k = 1
            //      5
            //     /
            //    4
            //   /
            //  3
            // /
            //2
            ///
            //1
            // Output: 1

            // Arrange
            var root = CreateBST(new int?[] { 5, 4, null, 3, null, 2, null, 1 });
            int k = 1;

            // Act
            var result = solution.KthSmallest(root, k);

            // Assert
            Assert.AreEqual(1, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void KthSmallest_LeftSkewedTree_K3_ReturnsThird(IKthSmallestElementInBST_230 solution, string solutionName)
        {
            // Input: root = [5,4,null,3,null,2,null,1], k = 3
            // Output: 3

            // Arrange
            var root = CreateBST(new int?[] { 5, 4, null, 3, null, 2, null, 1 });
            int k = 3;

            // Act
            var result = solution.KthSmallest(root, k);

            // Assert
            Assert.AreEqual(3, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void KthSmallest_LeftSkewedTree_K5_ReturnsLargest(IKthSmallestElementInBST_230 solution, string solutionName)
        {
            // Input: root = [5,4,null,3,null,2,null,1], k = 5
            // Output: 5

            // Arrange
            var root = CreateBST(new int?[] { 5, 4, null, 3, null, 2, null, 1 });
            int k = 5;

            // Act
            var result = solution.KthSmallest(root, k);

            // Assert
            Assert.AreEqual(5, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void KthSmallest_RightSkewedTree_K1_ReturnsSmallest(IKthSmallestElementInBST_230 solution, string solutionName)
        {
            // Input: root = [1,null,2,null,3,null,4,null,5], k = 1
            // 1
            //  \
            //   2
            //    \
            //     3
            //      \
            //       4
            //        \
            //         5
            // Output: 1

            // Arrange
            var root = CreateBST(new int?[] { 1, null, 2, null, 3, null, 4, null, 5 });
            int k = 1;

            // Act
            var result = solution.KthSmallest(root, k);

            // Assert
            Assert.AreEqual(1, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void KthSmallest_RightSkewedTree_K3_ReturnsThird(IKthSmallestElementInBST_230 solution, string solutionName)
        {
            // Input: root = [1,null,2,null,3,null,4,null,5], k = 3
            // Output: 3

            // Arrange
            var root = CreateBST(new int?[] { 1, null, 2, null, 3, null, 4, null, 5 });
            int k = 3;

            // Act
            var result = solution.KthSmallest(root, k);

            // Assert
            Assert.AreEqual(3, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void KthSmallest_RightSkewedTree_K5_ReturnsLargest(IKthSmallestElementInBST_230 solution, string solutionName)
        {
            // Input: root = [1,null,2,null,3,null,4,null,5], k = 5
            // Output: 5

            // Arrange
            var root = CreateBST(new int?[] { 1, null, 2, null, 3, null, 4, null, 5 });
            int k = 5;

            // Act
            var result = solution.KthSmallest(root, k);

            // Assert
            Assert.AreEqual(5, result, $"Failed for {solutionName}");
        }

        #endregion

        #region Balanced BST Tests

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void KthSmallest_BalancedBST_K1_ReturnsSmallest(IKthSmallestElementInBST_230 solution, string solutionName)
        {
            // Input: root = [4,2,6,1,3,5,7], k = 1
            //       4
            //      / \
            //     2   6
            //    / \ / \
            //   1  3 5  7
            // Output: 1

            // Arrange
            var root = CreateBST(new int?[] { 4, 2, 6, 1, 3, 5, 7 });
            int k = 1;

            // Act
            var result = solution.KthSmallest(root, k);

            // Assert
            Assert.AreEqual(1, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void KthSmallest_BalancedBST_K4_ReturnsRoot(IKthSmallestElementInBST_230 solution, string solutionName)
        {
            // Input: root = [4,2,6,1,3,5,7], k = 4
            // Output: 4

            // Arrange
            var root = CreateBST(new int?[] { 4, 2, 6, 1, 3, 5, 7 });
            int k = 4;

            // Act
            var result = solution.KthSmallest(root, k);

            // Assert
            Assert.AreEqual(4, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void KthSmallest_BalancedBST_K7_ReturnsLargest(IKthSmallestElementInBST_230 solution, string solutionName)
        {
            // Input: root = [4,2,6,1,3,5,7], k = 7
            // Output: 7

            // Arrange
            var root = CreateBST(new int?[] { 4, 2, 6, 1, 3, 5, 7 });
            int k = 7;

            // Act
            var result = solution.KthSmallest(root, k);

            // Assert
            Assert.AreEqual(7, result, $"Failed for {solutionName}");
        }

        #endregion

        #region Large BST Tests

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void KthSmallest_LargeBalancedBST_K1_ReturnsSmallest(IKthSmallestElementInBST_230 solution, string solutionName)
        {
            // Input: Balanced BST with 15 nodes
            //             8
            //          /     \
            //         4       12
            //        / \     /  \
            //       2   6   10   14
            //      / \ / \ / \  / \
            //     1  3 5 7 9 11 13 15
            // k = 1
            // Output: 1

            // Arrange
            var root = CreateBST(new int?[] { 8, 4, 12, 2, 6, 10, 14, 1, 3, 5, 7, 9, 11, 13, 15 });
            int k = 1;

            // Act
            var result = solution.KthSmallest(root, k);

            // Assert
            Assert.AreEqual(1, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void KthSmallest_LargeBalancedBST_K8_ReturnsMiddle(IKthSmallestElementInBST_230 solution, string solutionName)
        {
            // Input: Same tree, k = 8
            // Output: 8

            // Arrange
            var root = CreateBST(new int?[] { 8, 4, 12, 2, 6, 10, 14, 1, 3, 5, 7, 9, 11, 13, 15 });
            int k = 8;

            // Act
            var result = solution.KthSmallest(root, k);

            // Assert
            Assert.AreEqual(8, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void KthSmallest_LargeBalancedBST_K15_ReturnsLargest(IKthSmallestElementInBST_230 solution, string solutionName)
        {
            // Input: Same tree, k = 15
            // Output: 15

            // Arrange
            var root = CreateBST(new int?[] { 8, 4, 12, 2, 6, 10, 14, 1, 3, 5, 7, 9, 11, 13, 15 });
            int k = 15;

            // Act
            var result = solution.KthSmallest(root, k);

            // Assert
            Assert.AreEqual(15, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void KthSmallest_LargeBalancedBST_K5_ReturnsCorrectValue(IKthSmallestElementInBST_230 solution, string solutionName)
        {
            // Input: Same tree, k = 5
            // Output: 5

            // Arrange
            var root = CreateBST(new int?[] { 8, 4, 12, 2, 6, 10, 14, 1, 3, 5, 7, 9, 11, 13, 15 });
            int k = 5;

            // Act
            var result = solution.KthSmallest(root, k);

            // Assert
            Assert.AreEqual(5, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void KthSmallest_LargeBalancedBST_K10_ReturnsCorrectValue(IKthSmallestElementInBST_230 solution, string solutionName)
        {
            // Input: Same tree, k = 10
            // Output: 10

            // Arrange
            var root = CreateBST(new int?[] { 8, 4, 12, 2, 6, 10, 14, 1, 3, 5, 7, 9, 11, 13, 15 });
            int k = 10;

            // Act
            var result = solution.KthSmallest(root, k);

            // Assert
            Assert.AreEqual(10, result, $"Failed for {solutionName}");
        }

        #endregion

        #region Unbalanced BST Tests

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void KthSmallest_UnbalancedBST_LeftHeavy_K3(IKthSmallestElementInBST_230 solution, string solutionName)
        {
            // Input: root = [10,5,15,2,7,null,null,1,null,6,8], k = 3
            //        10
            //       /  \
            //      5    15
            //     / \
            //    2   7
            //   /   / \
            //  1   6   8
            // Output: 3 (inorder: 1,2,5,6,7,8,10,15 -> 3rd is 5)

            // Arrange
            var root = CreateBST(new int?[] { 10, 5, 15, 2, 7, null, null, 1, null, 6, 8 });
            int k = 3;

            // Act
            var result = solution.KthSmallest(root, k);

            // Assert
            Assert.AreEqual(5, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void KthSmallest_UnbalancedBST_RightHeavy_K5(IKthSmallestElementInBST_230 solution, string solutionName)
        {
            // Input: root = [5,2,null,1,3,null,null,null,null,null,4], k = 5
            //      5
            //     /
            //    2
            //   / \
            //  1   3
            //       \
            //        4
            // Output: 5 (inorder: 1,2,3,4,5 -> 5th is 5)

            // Arrange
            var root = CreateBST(new int?[] { 5, 2, null, 1, 3, null, 4 });
            int k = 5;

            // Act
            var result = solution.KthSmallest(root, k);

            // Assert
            Assert.AreEqual(5, result, $"Failed for {solutionName}");
        }

        #endregion

        #region Edge Cases with Values

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void KthSmallest_ConsecutiveValues_K2_ReturnsSecond(IKthSmallestElementInBST_230 solution, string solutionName)
        {
            // Input: root = [2,1,3], k = 2
            //    2
            //   / \
            //  1   3
            // Output: 2

            // Arrange
            var root = CreateSimpleBST(2, left: 1, right: 3);
            int k = 2;

            // Act
            var result = solution.KthSmallest(root, k);

            // Assert
            Assert.AreEqual(2, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void KthSmallest_NonConsecutiveValues_K3_ReturnsCorrectValue(IKthSmallestElementInBST_230 solution, string solutionName)
        {
            // Input: root = [10,5,15,2,7,12,20], k = 3
            //       10
            //      /  \
            //     5    15
            //    / \  /  \
            //   2  7 12  20
            // Output: 7 (inorder: 2,5,7,10,12,15,20 -> 3rd is 7)

            // Arrange
            var root = CreateBST(new int?[] { 10, 5, 15, 2, 7, 12, 20 });
            int k = 3;

            // Act
            var result = solution.KthSmallest(root, k);

            // Assert
            Assert.AreEqual(7, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void KthSmallest_LargeGaps_K4_ReturnsCorrectValue(IKthSmallestElementInBST_230 solution, string solutionName)
        {
            // Input: root = [100,50,150,25,75,125,175], k = 4
            //         100
            //        /   \
            //       50   150
            //      / \   / \
            //     25 75 125 175
            // Output: 100 (inorder: 25,50,75,100,125,150,175 -> 4th is 100)

            // Arrange
            var root = CreateBST(new int?[] { 100, 50, 150, 25, 75, 125, 175 });
            int k = 4;

            // Act
            var result = solution.KthSmallest(root, k);

            // Assert
            Assert.AreEqual(100, result, $"Failed for {solutionName}");
        }

        #endregion

        #region Various K Values

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void KthSmallest_MultipleQueries_SameBST_DifferentK(IKthSmallestElementInBST_230 solution, string solutionName)
        {
            // Input: root = [5,3,6,2,4,null,null,1], multiple k values
            //        5
            //       / \
            //      3   6
            //     / \
            //    2   4
            //   /
            //  1
            // Inorder: 1,2,3,4,5,6

            // Arrange
            var root = CreateBST(new int?[] { 5, 3, 6, 2, 4, null, null, 1 });

            // Act & Assert
            Assert.AreEqual(1, solution.KthSmallest(root, 1), $"Failed for k=1, {solutionName}");
            Assert.AreEqual(2, solution.KthSmallest(root, 2), $"Failed for k=2, {solutionName}");
            Assert.AreEqual(3, solution.KthSmallest(root, 3), $"Failed for k=3, {solutionName}");
            Assert.AreEqual(4, solution.KthSmallest(root, 4), $"Failed for k=4, {solutionName}");
            Assert.AreEqual(5, solution.KthSmallest(root, 5), $"Failed for k=5, {solutionName}");
            Assert.AreEqual(6, solution.KthSmallest(root, 6), $"Failed for k=6, {solutionName}");
        }

        #endregion

        #region Asymmetric Trees

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void KthSmallest_OnlyLeftSubtree_K2_ReturnsCorrectValue(IKthSmallestElementInBST_230 solution, string solutionName)
        {
            // Input: root = [10,5,null,3,7], k = 2
            //      10
            //     /
            //    5
            //   / \
            //  3   7
            // Output: 5 (inorder: 3,5,7,10 -> 2nd is 5)

            // Arrange
            var root = CreateBST(new int?[] { 10, 5, null, 3, 7 });
            int k = 2;

            // Act
            var result = solution.KthSmallest(root, k);

            // Assert
            Assert.AreEqual(5, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void KthSmallest_OnlyRightSubtree_K2_ReturnsCorrectValue(IKthSmallestElementInBST_230 solution, string solutionName)
        {
            // Input: root = [5,null,10,null,null,8,12], k = 2
            //      5
            //       \
            //       10
            //      /  \
            //     8   12
            // Output: 8 (inorder: 5,8,10,12 -> 2nd is 8)

            // Arrange
            var root = CreateBST(new int?[] { 5, null, 10, 8, 12 });
            int k = 2;

            // Act
            var result = solution.KthSmallest(root, k);

            // Assert
            Assert.AreEqual(8, result, $"Failed for {solutionName}");
        }

        #endregion

        #region Deep Trees

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void KthSmallest_DeepLeftChain_K3_ReturnsCorrectValue(IKthSmallestElementInBST_230 solution, string solutionName)
        {
            // Input: root = [10,9,null,8,null,7,null,6,null,5], k = 3
            //        10
            //       /
            //      9
            //     /
            //    8
            //   /
            //  7
            // /
            //6
            ///
            //5
            // Output: 7 (inorder: 5,6,7,8,9,10 -> 3rd is 7)

            // Arrange
            var root = CreateBST(new int?[] { 10, 9, null, 8, null, 7, null, 6, null, 5 });
            int k = 3;

            // Act
            var result = solution.KthSmallest(root, k);

            // Assert
            Assert.AreEqual(7, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void KthSmallest_DeepRightChain_K3_ReturnsCorrectValue(IKthSmallestElementInBST_230 solution, string solutionName)
        {
            // Input: root = [1,null,2,null,3,null,4,null,5,null,6], k = 3
            // 1
            //  \
            //   2
            //    \
            //     3
            //      \
            //       4
            //        \
            //         5
            //          \
            //           6
            // Output: 3 (inorder: 1,2,3,4,5,6 -> 3rd is 3)

            // Arrange
            var root = CreateBST(new int?[] { 1, null, 2, null, 3, null, 4, null, 5, null, 6 });
            int k = 3;

            // Act
            var result = solution.KthSmallest(root, k);

            // Assert
            Assert.AreEqual(3, result, $"Failed for {solutionName}");
        }

        #endregion

        #region Complex Structure Tests

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void KthSmallest_ComplexTree_K7_ReturnsCorrectValue(IKthSmallestElementInBST_230 solution, string solutionName)
        {
            // Input: root = [20,10,30,5,15,25,35,3,7,12,18], k = 7
            //           20
            //         /    \
            //       10      30
            //      /  \    /  \
            //     5   15  25  35
            //    / \  / \
            //   3  7 12 18
            // Inorder: 3,5,7,10,12,15,18,20,25,30,35 -> 7th is 18

            // Arrange
            var root = CreateBST(new int?[] { 20, 10, 30, 5, 15, 25, 35, 3, 7, 12, 18 });
            int k = 7;

            // Act
            var result = solution.KthSmallest(root, k);

            // Assert
            Assert.AreEqual(18, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void KthSmallest_ComplexTree_K1_ReturnsSmallest(IKthSmallestElementInBST_230 solution, string solutionName)
        {
            // Same tree, k = 1
            // Output: 3

            // Arrange
            var root = CreateBST(new int?[] { 20, 10, 30, 5, 15, 25, 35, 3, 7, 12, 18 });
            int k = 1;

            // Act
            var result = solution.KthSmallest(root, k);

            // Assert
            Assert.AreEqual(3, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void KthSmallest_ComplexTree_K11_ReturnsLargest(IKthSmallestElementInBST_230 solution, string solutionName)
        {
            // Same tree, k = 11
            // Output: 35

            // Arrange
            var root = CreateBST(new int?[] { 20, 10, 30, 5, 15, 25, 35, 3, 7, 12, 18 });
            int k = 11;

            // Act
            var result = solution.KthSmallest(root, k);

            // Assert
            Assert.AreEqual(35, result, $"Failed for {solutionName}");
        }

        #endregion

        #region Minimum/Maximum Element Tests

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void KthSmallest_K1_AlwaysReturnsMinimumElement(IKthSmallestElementInBST_230 solution, string solutionName)
        {
            // Various trees, k = 1 should always return the leftmost (minimum) element

            // Tree 1: [4,2,6,1,3,5,7]
            var root1 = CreateBST(new int?[] { 4, 2, 6, 1, 3, 5, 7 });
            Assert.AreEqual(1, solution.KthSmallest(root1, 1), $"Failed for tree1, {solutionName}");

            // Tree 2: [10,5,15]
            var root2 = CreateBST(new int?[] { 10, 5, 15 });
            Assert.AreEqual(5, solution.KthSmallest(root2, 1), $"Failed for tree2, {solutionName}");

            // Tree 3: [100,50,150,25]
            var root3 = CreateBST(new int?[] { 100, 50, 150, 25 });
            Assert.AreEqual(25, solution.KthSmallest(root3, 1), $"Failed for tree3, {solutionName}");
        }

        #endregion
    }
}
