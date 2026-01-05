using LeetCodeProblems.CSharp.Tree;
using LeetCodeProblems.Interfaces.Easy;
using LeetCodeProblems.Shared;
using LeetCodeProblems.VisualBasic;

namespace GrindingLeetCode.UnitTests.Easy
{
    [TestClass]
    public class TwoSumIV_653_Tests
    {
        public static IEnumerable<object[]> GetImplementations()
        {
            yield return new object[] { new TwoSumIV_FlattenFirst_CSharp_653(), "C# Flatten First (Two Pointer)" };
            yield return new object[] { new TwoSumIV_HashMap_CSharp_653(), "C# HashMap" };
            
            yield return new object[] { new TwoSumIV_FlattenFirst_VB_653(), "VB Flatten First (Two Pointer)" };
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

        #endregion

        #region LeetCode Examples

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void FindTarget_Example1_ReturnsTrue(ITwoSumIV_653 solution, string solutionName)
        {
            // Input: root = [5,3,6,2,4,null,7], k = 9
            //       5
            //      / \
            //     3   6
            //    / \   \
            //   2   4   7
            // Output: true
            // Explanation: 2 + 7 = 9

            // Arrange
            var root = CreateTree(new int?[] { 5, 3, 6, 2, 4, null, 7 });
            int k = 9;

            // Act
            var result = solution.FindTarget(root, k);

            // Assert
            Assert.IsTrue(result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void FindTarget_Example2_ReturnsFalse(ITwoSumIV_653 solution, string solutionName)
        {
            // Input: root = [5,3,6,2,4,null,7], k = 28
            //       5
            //      / \
            //     3   6
            //    / \   \
            //   2   4   7
            // Output: false
            // Explanation: No two nodes sum to 28

            // Arrange
            var root = CreateTree(new int?[] { 5, 3, 6, 2, 4, null, 7 });
            int k = 28;

            // Act
            var result = solution.FindTarget(root, k);

            // Assert
            Assert.IsFalse(result, $"Failed for {solutionName}");
        }

        #endregion

        #region Basic Cases

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void FindTarget_EmptyTree_ReturnsFalse(ITwoSumIV_653 solution, string solutionName)
        {
            // Input: root = [], k = 0
            // Output: false

            // Arrange
            TreeNode root = null;
            int k = 0;

            // Act
            var result = solution.FindTarget(root, k);

            // Assert
            Assert.IsFalse(result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void FindTarget_SingleNode_ReturnsFalse(ITwoSumIV_653 solution, string solutionName)
        {
            // Input: root = [1], k = 2
            // Output: false
            // Explanation: Need two different nodes

            // Arrange
            var root = new TreeNode(1);
            int k = 2;

            // Act
            var result = solution.FindTarget(root, k);

            // Assert
            Assert.IsFalse(result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void FindTarget_TwoNodesMatch_ReturnsTrue(ITwoSumIV_653 solution, string solutionName)
        {
            // Input: root = [1,null,2], k = 3
            //    1
            //     \
            //      2
            // Output: true

            // Arrange
            var root = CreateTree(new int?[] { 1, null, 2 });
            int k = 3;

            // Act
            var result = solution.FindTarget(root, k);

            // Assert
            Assert.IsTrue(result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void FindTarget_TwoNodesNoMatch_ReturnsFalse(ITwoSumIV_653 solution, string solutionName)
        {
            // Input: root = [1,null,2], k = 4
            //    1
            //     \
            //      2
            // Output: false

            // Arrange
            var root = CreateTree(new int?[] { 1, null, 2 });
            int k = 4;

            // Act
            var result = solution.FindTarget(root, k);

            // Assert
            Assert.IsFalse(result, $"Failed for {solutionName}");
        }

        #endregion

        #region Balanced BST Cases

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void FindTarget_BalancedBST_PairAtLeaves_ReturnsTrue(ITwoSumIV_653 solution, string solutionName)
        {
            // Input: root = [4,2,6,1,3,5,7], k = 8
            //       4
            //      / \
            //     2   6
            //    / \ / \
            //   1  3 5  7
            // Output: true (1 + 7 = 8 or 3 + 5 = 8)

            // Arrange
            var root = CreateTree(new int?[] { 4, 2, 6, 1, 3, 5, 7 });
            int k = 8;

            // Act
            var result = solution.FindTarget(root, k);

            // Assert
            Assert.IsTrue(result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void FindTarget_BalancedBST_PairRootAndLeaf_ReturnsTrue(ITwoSumIV_653 solution, string solutionName)
        {
            // Input: root = [4,2,6,1,3,5,7], k = 11
            //       4
            //      / \
            //     2   6
            //    / \ / \
            //   1  3 5  7
            // Output: true (4 + 7 = 11)

            // Arrange
            var root = CreateTree(new int?[] { 4, 2, 6, 1, 3, 5, 7 });
            int k = 11;

            // Act
            var result = solution.FindTarget(root, k);

            // Assert
            Assert.IsTrue(result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void FindTarget_BalancedBST_NoMatch_ReturnsFalse(ITwoSumIV_653 solution, string solutionName)
        {
            // Input: root = [4,2,6,1,3,5,7], k = 20
            //       4
            //      / \
            //     2   6
            //    / \ / \
            //   1  3 5  7
            // Output: false

            // Arrange
            var root = CreateTree(new int?[] { 4, 2, 6, 1, 3, 5, 7 });
            int k = 20;

            // Act
            var result = solution.FindTarget(root, k);

            // Assert
            Assert.IsFalse(result, $"Failed for {solutionName}");
        }

        #endregion

        #region Skewed Trees

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void FindTarget_LeftSkewedTree_ReturnsTrue(ITwoSumIV_653 solution, string solutionName)
        {
            // Input: root = [5,4,null,3,null,2,null,1], k = 6
            //      5
            //     /
            //    4
            //   /
            //  3
            // /
            //2
            ///
            //1
            // Output: true (2 + 4 = 6 or 1 + 5 = 6)

            // Arrange
            var root = CreateTree(new int?[] { 5, 4, null, 3, null, 2, null, 1 });
            int k = 6;

            // Act
            var result = solution.FindTarget(root, k);

            // Assert
            Assert.IsTrue(result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void FindTarget_RightSkewedTree_ReturnsTrue(ITwoSumIV_653 solution, string solutionName)
        {
            // Input: root = [1,null,2,null,3,null,4,null,5], k = 7
            // 1
            //  \
            //   2
            //    \
            //     3
            //      \
            //       4
            //        \
            //         5
            // Output: true (2 + 5 = 7 or 3 + 4 = 7)

            // Arrange
            var root = CreateTree(new int?[] { 1, null, 2, null, 3, null, 4, null, 5 });
            int k = 7;

            // Act
            var result = solution.FindTarget(root, k);

            // Assert
            Assert.IsTrue(result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void FindTarget_LeftSkewedTree_ReturnsFalse(ITwoSumIV_653 solution, string solutionName)
        {
            // Input: root = [5,4,null,3,null,2,null,1], k = 100
            // Output: false

            // Arrange
            var root = CreateTree(new int?[] { 5, 4, null, 3, null, 2, null, 1 });
            int k = 100;

            // Act
            var result = solution.FindTarget(root, k);

            // Assert
            Assert.IsFalse(result, $"Failed for {solutionName}");
        }

        #endregion

        #region Edge Cases - Values

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void FindTarget_NegativeValues_ReturnsTrue(ITwoSumIV_653 solution, string solutionName)
        {
            // Input: root = [0,-2,2,-3,-1,1,3], k = 0
            //        0
            //       / \
            //     -2   2
            //     / \ / \
            //   -3 -1 1  3
            // Output: true (-2 + 2 = 0 or -1 + 1 = 0)

            // Arrange
            var root = CreateTree(new int?[] { 0, -2, 2, -3, -1, 1, 3 });
            int k = 0;

            // Act
            var result = solution.FindTarget(root, k);

            // Assert
            Assert.IsTrue(result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void FindTarget_AllNegativeValues_ReturnsTrue(ITwoSumIV_653 solution, string solutionName)
        {
            // Input: root = [-4,-6,-2,-7,-5,-3,-1], k = -11
            //       -4
            //       / \
            //     -6  -2
            //     / \ / \
            //   -7 -5-3 -1
            // Output: true (-7 + -4 = -11 or -6 + -5 = -11)

            // Arrange
            var root = CreateTree(new int?[] { -4, -6, -2, -7, -5, -3, -1 });
            int k = -11;

            // Act
            var result = solution.FindTarget(root, k);

            // Assert
            Assert.IsTrue(result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void FindTarget_TargetIsZero_ReturnsTrue(ITwoSumIV_653 solution, string solutionName)
        {
            // Input: root = [5,-5,10,-10,1,8,15], k = 0
            // Output: true (-5 + 5 = 0 or -10 + 10 = 0)

            // Arrange
            var root = CreateTree(new int?[] { 5, -5, 10, -10, 1, 8, 15 });
            int k = 0;

            // Act
            var result = solution.FindTarget(root, k);

            // Assert
            Assert.IsTrue(result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void FindTarget_LargeValues_ReturnsTrue(ITwoSumIV_653 solution, string solutionName)
        {
            // Input: root = [1000,500,1500,250,750,1250,1750], k = 2500
            // Output: true (1000 + 1500 = 2500 or 750 + 1750 = 2500)

            // Arrange
            var root = CreateTree(new int?[] { 1000, 500, 1500, 250, 750, 1250, 1750 });
            int k = 2500;

            // Act
            var result = solution.FindTarget(root, k);

            // Assert
            Assert.IsTrue(result, $"Failed for {solutionName}");
        }

        #endregion

        #region Duplicate Values

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void FindTarget_DuplicateValues_CannotUseSameNode_ReturnsFalse(ITwoSumIV_653 solution, string solutionName)
        {
            // Input: root = [2,2,2], k = 4
            //      2
            //     / \
            //    2   2
            // Output: true (2 + 2 = 4, using two different nodes)

            // Arrange
            var root = CreateTree(new int?[] { 2, 2, 2 });
            int k = 4;

            // Act
            var result = solution.FindTarget(root, k);

            // Assert
            Assert.IsTrue(result, $"Failed for {solutionName} - Can use two different nodes with same value");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void FindTarget_SingleNodeDoubleValue_ReturnsFalse(ITwoSumIV_653 solution, string solutionName)
        {
            // Input: root = [5], k = 10
            // Output: false
            // Explanation: Cannot use the same node twice

            // Arrange
            var root = new TreeNode(5);
            int k = 10;

            // Act
            var result = solution.FindTarget(root, k);

            // Assert
            Assert.IsFalse(result, $"Failed for {solutionName} - Cannot use same node twice");
        }

        #endregion

        #region Target Sum Edge Cases

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void FindTarget_SmallestPossibleSum_ReturnsTrue(ITwoSumIV_653 solution, string solutionName)
        {
            // Find smallest sum in tree

            // Arrange
            var root = CreateTree(new int?[] { 4, 2, 6, 1, 3, 5, 7 });
            int k = 3; // 1 + 2 = 3

            // Act
            var result = solution.FindTarget(root, k);

            // Assert
            Assert.IsTrue(result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void FindTarget_LargestPossibleSum_ReturnsTrue(ITwoSumIV_653 solution, string solutionName)
        {
            // Find largest sum in tree

            // Arrange
            var root = CreateTree(new int?[] { 4, 2, 6, 1, 3, 5, 7 });
            int k = 13; // 6 + 7 = 13

            // Act
            var result = solution.FindTarget(root, k);

            // Assert
            Assert.IsTrue(result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void FindTarget_SumTooSmall_ReturnsFalse(ITwoSumIV_653 solution, string solutionName)
        {
            // Target smaller than smallest possible sum

            // Arrange
            var root = CreateTree(new int?[] { 4, 2, 6, 1, 3, 5, 7 });
            int k = 2; // Smallest sum is 1 + 2 = 3

            // Act
            var result = solution.FindTarget(root, k);

            // Assert
            Assert.IsFalse(result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void FindTarget_SumTooLarge_ReturnsFalse(ITwoSumIV_653 solution, string solutionName)
        {
            // Target larger than largest possible sum

            // Arrange
            var root = CreateTree(new int?[] { 4, 2, 6, 1, 3, 5, 7 });
            int k = 14; // Largest sum is 6 + 7 = 13

            // Act
            var result = solution.FindTarget(root, k);

            // Assert
            Assert.IsFalse(result, $"Failed for {solutionName}");
        }

        #endregion

        #region Complex Tree Structures

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void FindTarget_ComplexTree_MultipleValidPairs_ReturnsTrue(ITwoSumIV_653 solution, string solutionName)
        {
            // Multiple pairs sum to target

            // Arrange
            var root = CreateTree(new int?[] { 10, 5, 15, 3, 7, 13, 18, 1, 4, 6, 9 });
            int k = 16; // Multiple pairs: 7+9, 3+13, 1+15, etc.

            // Act
            var result = solution.FindTarget(root, k);

            // Assert
            Assert.IsTrue(result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void FindTarget_SparseTree_ReturnsTrue(ITwoSumIV_653 solution, string solutionName)
        {
            // Sparse tree with many nulls

            // Arrange
            var root = CreateTree(new int?[] { 8, 4, 12, null, 6, 10, null, 5, 7 });
            int k = 15; // 5 + 10 = 15 or 8 + 7 = 15

            // Act
            var result = solution.FindTarget(root, k);

            // Assert
            Assert.IsTrue(result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void FindTarget_SparseTree_ReturnsFalse(ITwoSumIV_653 solution, string solutionName)
        {
            // Sparse tree, no match

            // Arrange
            var root = CreateTree(new int?[] { 8, 4, 12, null, 6, 10 });
            int k = 100;

            // Act
            var result = solution.FindTarget(root, k);

            // Assert
            Assert.IsFalse(result, $"Failed for {solutionName}");
        }

        #endregion

        #region Larger Trees

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void FindTarget_LargeBalancedTree_ReturnsTrue(ITwoSumIV_653 solution, string solutionName)
        {
            // Large balanced tree (15 nodes)

            // Arrange
            var root = CreateTree(new int?[] { 8, 4, 12, 2, 6, 10, 14, 1, 3, 5, 7, 9, 11, 13, 15 });
            int k = 16; // Many pairs: 1+15, 2+14, 3+13, 4+12, 5+11, 6+10, 7+9

            // Act
            var result = solution.FindTarget(root, k);

            // Assert
            Assert.IsTrue(result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void FindTarget_LargeBalancedTree_ReturnsFalse(ITwoSumIV_653 solution, string solutionName)
        {
            // Large balanced tree, no match

            // Arrange
            var root = CreateTree(new int?[] { 8, 4, 12, 2, 6, 10, 14, 1, 3, 5, 7, 9, 11, 13, 15 });
            int k = 31; // Max sum is 14 + 15 = 29

            // Act
            var result = solution.FindTarget(root, k);

            // Assert
            Assert.IsFalse(result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void FindTarget_DeepTree_ReturnsTrue(ITwoSumIV_653 solution, string solutionName)
        {
            // Deep tree with many levels

            // Arrange
            TreeNode root = new TreeNode(10);
            TreeNode current = root;
            for (int i = 9; i >= 1; i--)
            {
                current.left = new TreeNode(i);
                current = current.left;
            }
            current = root;
            for (int i = 11; i <= 19; i++)
            {
                current.right = new TreeNode(i);
                current = current.right;
            }

            int k = 20; // 1 + 19 = 20

            // Act
            var result = solution.FindTarget(root, k);

            // Assert
            Assert.IsTrue(result, $"Failed for {solutionName}");
        }

        #endregion

        #region Special Patterns

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void FindTarget_ConsecutiveNumbers_ReturnsTrue(ITwoSumIV_653 solution, string solutionName)
        {
            // Tree with consecutive numbers

            // Arrange
            var root = CreateTree(new int?[] { 5, 4, 6, 3, null, null, 7, 2, null, null, 8, 1 });
            int k = 9; // 1 + 8 = 9 or 2 + 7 = 9, etc.

            // Act
            var result = solution.FindTarget(root, k);

            // Assert
            Assert.IsTrue(result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void FindTarget_PowersOfTwo_ReturnsTrue(ITwoSumIV_653 solution, string solutionName)
        {
            // Tree with powers of 2

            // Arrange
            var root = CreateTree(new int?[] { 8, 4, 16, 2, null, null, 32, 1 });
            int k = 40; // 8 + 32 = 40

            // Act
            var result = solution.FindTarget(root, k);

            // Assert
            Assert.IsTrue(result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void FindTarget_AdjacentNodes_ReturnsTrue(ITwoSumIV_653 solution, string solutionName)
        {
            // Test with parent and child summing to target

            // Arrange
            var root = CreateTree(new int?[] { 3, 2, 4 });
            int k = 5; // 2 + 3 = 5 or 3 + 2 = 5 (parent + left child)

            // Act
            var result = solution.FindTarget(root, k);

            // Assert
            Assert.IsTrue(result, $"Failed for {solutionName}");
        }

        #endregion

        #region Boundary Values

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void FindTarget_VeryLargeK_ReturnsFalse(ITwoSumIV_653 solution, string solutionName)
        {
            // Target much larger than any possible sum

            // Arrange
            var root = CreateTree(new int?[] { 5, 3, 7, 1, 4, 6, 9 });
            int k = 1000000;

            // Act
            var result = solution.FindTarget(root, k);

            // Assert
            Assert.IsFalse(result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void FindTarget_VerySmallK_ReturnsFalse(ITwoSumIV_653 solution, string solutionName)
        {
            // Target much smaller than any possible sum

            // Arrange
            var root = CreateTree(new int?[] { 5, 3, 7, 1, 4, 6, 9 });
            int k = -1000000;

            // Act
            var result = solution.FindTarget(root, k);

            // Assert
            Assert.IsFalse(result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void FindTarget_ThreeNodes_ReturnsTrue(ITwoSumIV_653 solution, string solutionName)
        {
            // Simple three-node tree

            // Arrange
            var root = CreateTree(new int?[] { 2, 1, 3 });
            int k = 4; // 1 + 3 = 4

            // Act
            var result = solution.FindTarget(root, k);

            // Assert
            Assert.IsTrue(result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void FindTarget_ThreeNodes_ReturnsFalse(ITwoSumIV_653 solution, string solutionName)
        {
            // Simple three-node tree, no match

            // Arrange
            var root = CreateTree(new int?[] { 2, 1, 3 });
            int k = 10;

            // Act
            var result = solution.FindTarget(root, k);

            // Assert
            Assert.IsFalse(result, $"Failed for {solutionName}");
        }

        #endregion

        #region Performance Edge Cases

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void FindTarget_ManyNodesConsecutive_ReturnsTrue(ITwoSumIV_653 solution, string solutionName)
        {
            // Build BST with consecutive values 1-31

            // Arrange
            var root = CreateTree(new int?[] { 
                16, 8, 24, 4, 12, 20, 28, 2, 6, 10, 14, 18, 22, 26, 30,
                1, 3, 5, 7, 9, 11, 13, 15, 17, 19, 21, 23, 25, 27, 29, 31
            });
            int k = 32; // 1 + 31 = 32

            // Act
            var result = solution.FindTarget(root, k);

            // Assert
            Assert.IsTrue(result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void FindTarget_AllPairsDoNotMatch_ReturnsFalse(ITwoSumIV_653 solution, string solutionName)
        {
            // Tree where no two nodes sum to target

            // Arrange
            var root = CreateTree(new int?[] { 10, 5, 15, 3, 7, 13, 17 });
            int k = 1; // No two values sum to 1

            // Act
            var result = solution.FindTarget(root, k);

            // Assert
            Assert.IsFalse(result, $"Failed for {solutionName}");
        }

        #endregion
    }
}
