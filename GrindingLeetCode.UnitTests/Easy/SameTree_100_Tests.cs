using LeetCodeProblems.CSharp.Tree;
using LeetCodeProblems.Interfaces.Easy;
using LeetCodeProblems.Shared;
using LeetCodeProblems.VisualBasic;

namespace GrindingLeetCode.UnitTests.Easy
{
    [TestClass]
    public class SameTree_100_Tests
    {
        public static IEnumerable<object[]> GetImplementations()
        {
            yield return new object[] { new SameTree_Recursive_CSharp_100(), "C# Recursive" };
            yield return new object[] { new SameTree_Stack_CSharp_100(), "C# Stack" };
            yield return new object[] { new SameTree_Queue_CSharp_100(), "C# BFS" };

            yield return new object[] { new SameTree_Recursive_VB_100(), "VB Recursive" };
            yield return new object[] { new SameTree_Stack_VB_100(), "VB Stack" };
            yield return new object[] { new SameTree_BFS_VB_100(), "VB BFS" };

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
        public void IsSameTree_Example1_ReturnsTrue(ISameTree_100 solution, string solutionName)
        {
            // Input: p = [1,2,3], q = [1,2,3]
            //    1         1
            //   / \       / \
            //  2   3     2   3
            // Output: true

            // Arrange
            var p = CreateTree(new int?[] { 1, 2, 3 });
            var q = CreateTree(new int?[] { 1, 2, 3 });

            // Act
            var result = solution.IsSameTree(p, q);

            // Assert
            Assert.IsTrue(result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsSameTree_Example2_ReturnsFalse(ISameTree_100 solution, string solutionName)
        {
            // Input: p = [1,2], q = [1,null,2]
            //    1         1
            //   /           \
            //  2             2
            // Output: false

            // Arrange
            var p = CreateTree(new int?[] { 1, 2 });
            var q = CreateTree(new int?[] { 1, null, 2 });

            // Act
            var result = solution.IsSameTree(p, q);

            // Assert
            Assert.IsFalse(result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsSameTree_Example3_ReturnsFalse(ISameTree_100 solution, string solutionName)
        {
            // Input: p = [1,2,1], q = [1,1,2]
            //    1         1
            //   / \       / \
            //  2   1     1   2
            // Output: false

            // Arrange
            var p = CreateTree(new int?[] { 1, 2, 1 });
            var q = CreateTree(new int?[] { 1, 1, 2 });

            // Act
            var result = solution.IsSameTree(p, q);

            // Assert
            Assert.IsFalse(result, $"Failed for {solutionName}");
        }

        #endregion

        #region Basic Tree Structures

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsSameTree_BothNull_ReturnsTrue(ISameTree_100 solution, string solutionName)
        {
            // Input: p = [], q = []
            // Output: true

            // Arrange
            TreeNode p = null;
            TreeNode q = null;

            // Act
            var result = solution.IsSameTree(p, q);

            // Assert
            Assert.IsTrue(result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsSameTree_OneNullOneNot_ReturnsFalse(ISameTree_100 solution, string solutionName)
        {
            // Input: p = [], q = [1]
            // Output: false

            // Arrange
            TreeNode p = null;
            var q = new TreeNode(1);

            // Act
            var result = solution.IsSameTree(p, q);

            // Assert
            Assert.IsFalse(result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsSameTree_SecondNullFirstNot_ReturnsFalse(ISameTree_100 solution, string solutionName)
        {
            // Input: p = [1], q = []
            // Output: false

            // Arrange
            var p = new TreeNode(1);
            TreeNode q = null;

            // Act
            var result = solution.IsSameTree(p, q);

            // Assert
            Assert.IsFalse(result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsSameTree_SingleNodeSame_ReturnsTrue(ISameTree_100 solution, string solutionName)
        {
            // Input: p = [1], q = [1]
            // Output: true

            // Arrange
            var p = new TreeNode(1);
            var q = new TreeNode(1);

            // Act
            var result = solution.IsSameTree(p, q);

            // Assert
            Assert.IsTrue(result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsSameTree_SingleNodeDifferent_ReturnsFalse(ISameTree_100 solution, string solutionName)
        {
            // Input: p = [1], q = [2]
            // Output: false

            // Arrange
            var p = new TreeNode(1);
            var q = new TreeNode(2);

            // Act
            var result = solution.IsSameTree(p, q);

            // Assert
            Assert.IsFalse(result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsSameTree_TwoNodesSame_ReturnsTrue(ISameTree_100 solution, string solutionName)
        {
            // Input: p = [1,2], q = [1,2]
            //    1         1
            //   /         /
            //  2         2
            // Output: true

            // Arrange
            var p = CreateTree(new int?[] { 1, 2 });
            var q = CreateTree(new int?[] { 1, 2 });

            // Act
            var result = solution.IsSameTree(p, q);

            // Assert
            Assert.IsTrue(result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsSameTree_ThreeNodesSame_ReturnsTrue(ISameTree_100 solution, string solutionName)
        {
            // Input: p = [2,1,3], q = [2,1,3]
            //    2         2
            //   / \       / \
            //  1   3     1   3
            // Output: true

            // Arrange
            var p = CreateSimpleTree(2, 1, 3);
            var q = CreateSimpleTree(2, 1, 3);

            // Act
            var result = solution.IsSameTree(p, q);

            // Assert
            Assert.IsTrue(result, $"Failed for {solutionName}");
        }

        #endregion

        #region Different Structures

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsSameTree_DifferentStructure_LeftVsRight_ReturnsFalse(ISameTree_100 solution, string solutionName)
        {
            // Input: p = [1,2,null], q = [1,null,2]
            //    1         1
            //   /           \
            //  2             2
            // Output: false

            // Arrange
            var p = CreateTree(new int?[] { 1, 2, null });
            var q = CreateTree(new int?[] { 1, null, 2 });

            // Act
            var result = solution.IsSameTree(p, q);

            // Assert
            Assert.IsFalse(result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsSameTree_DifferentHeight_ReturnsFalse(ISameTree_100 solution, string solutionName)
        {
            // Input: p = [1,2,3], q = [1,2,3,4]
            //    1           1
            //   / \         / \
            //  2   3       2   3
            //             /
            //            4
            // Output: false

            // Arrange
            var p = CreateTree(new int?[] { 1, 2, 3 });
            var q = CreateTree(new int?[] { 1, 2, 3, 4 });

            // Act
            var result = solution.IsSameTree(p, q);

            // Assert
            Assert.IsFalse(result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsSameTree_MissingLeftChild_ReturnsFalse(ISameTree_100 solution, string solutionName)
        {
            // Input: p = [1,null,2], q = [1,2,2]
            //    1         1
            //     \       / \
            //      2     2   2
            // Output: false

            // Arrange
            var p = CreateTree(new int?[] { 1, null, 2 });
            var q = CreateTree(new int?[] { 1, 2, 2 });

            // Act
            var result = solution.IsSameTree(p, q);

            // Assert
            Assert.IsFalse(result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsSameTree_MissingRightChild_ReturnsFalse(ISameTree_100 solution, string solutionName)
        {
            // Input: p = [1,2,null], q = [1,2,2]
            //    1         1
            //   /         / \
            //  2         2   2
            // Output: false

            // Arrange
            var p = CreateTree(new int?[] { 1, 2, null });
            var q = CreateTree(new int?[] { 1, 2, 2 });

            // Act
            var result = solution.IsSameTree(p, q);

            // Assert
            Assert.IsFalse(result, $"Failed for {solutionName}");
        }

        #endregion

        #region Different Values - Same Structure

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsSameTree_DifferentRootValues_ReturnsFalse(ISameTree_100 solution, string solutionName)
        {
            // Input: p = [1,2,3], q = [2,2,3]
            //    1         2
            //   / \       / \
            //  2   3     2   3
            // Output: false

            // Arrange
            var p = CreateSimpleTree(1, 2, 3);
            var q = CreateSimpleTree(2, 2, 3);

            // Act
            var result = solution.IsSameTree(p, q);

            // Assert
            Assert.IsFalse(result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsSameTree_DifferentLeftChildValue_ReturnsFalse(ISameTree_100 solution, string solutionName)
        {
            // Input: p = [1,2,3], q = [1,4,3]
            //    1         1
            //   / \       / \
            //  2   3     4   3
            // Output: false

            // Arrange
            var p = CreateSimpleTree(1, 2, 3);
            var q = CreateSimpleTree(1, 4, 3);

            // Act
            var result = solution.IsSameTree(p, q);

            // Assert
            Assert.IsFalse(result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsSameTree_DifferentRightChildValue_ReturnsFalse(ISameTree_100 solution, string solutionName)
        {
            // Input: p = [1,2,3], q = [1,2,5]
            //    1         1
            //   / \       / \
            //  2   3     2   5
            // Output: false

            // Arrange
            var p = CreateSimpleTree(1, 2, 3);
            var q = CreateSimpleTree(1, 2, 5);

            // Act
            var result = solution.IsSameTree(p, q);

            // Assert
            Assert.IsFalse(result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsSameTree_DifferentDeepValue_ReturnsFalse(ISameTree_100 solution, string solutionName)
        {
            // Input: p = [1,2,3,4,5,6,7], q = [1,2,3,4,5,6,8]
            //        1                 1
            //       / \               / \
            //      2   3             2   3
            //     / \ / \           / \ / \
            //    4  5 6  7         4  5 6  8
            // Output: false (different value at rightmost leaf)

            // Arrange
            var p = CreateTree(new int?[] { 1, 2, 3, 4, 5, 6, 7 });
            var q = CreateTree(new int?[] { 1, 2, 3, 4, 5, 6, 8 });

            // Act
            var result = solution.IsSameTree(p, q);

            // Assert
            Assert.IsFalse(result, $"Failed for {solutionName}");
        }

        #endregion

        #region Identical Trees - Various Structures

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsSameTree_IdenticalBalanced7Nodes_ReturnsTrue(ISameTree_100 solution, string solutionName)
        {
            // Input: p = [4,2,6,1,3,5,7], q = [4,2,6,1,3,5,7]
            //        4                 4
            //       / \               / \
            //      2   6             2   6
            //     / \ / \           / \ / \
            //    1  3 5  7         1  3 5  7
            // Output: true

            // Arrange
            var p = CreateTree(new int?[] { 4, 2, 6, 1, 3, 5, 7 });
            var q = CreateTree(new int?[] { 4, 2, 6, 1, 3, 5, 7 });

            // Act
            var result = solution.IsSameTree(p, q);

            // Assert
            Assert.IsTrue(result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsSameTree_IdenticalBalanced15Nodes_ReturnsTrue(ISameTree_100 solution, string solutionName)
        {
            // Perfect binary tree with 15 nodes
            // Output: true

            // Arrange
            var p = CreateTree(new int?[] { 8, 4, 12, 2, 6, 10, 14, 1, 3, 5, 7, 9, 11, 13, 15 });
            var q = CreateTree(new int?[] { 8, 4, 12, 2, 6, 10, 14, 1, 3, 5, 7, 9, 11, 13, 15 });

            // Act
            var result = solution.IsSameTree(p, q);

            // Assert
            Assert.IsTrue(result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsSameTree_IdenticalLeftSkewed_ReturnsTrue(ISameTree_100 solution, string solutionName)
        {
            // Input: p = [5,4,null,3,null,2,null,1], q = [5,4,null,3,null,2,null,1]
            //      5            5
            //     /            /
            //    4            4
            //   /            /
            //  3            3
            // /            /
            //2            2
            ///            /
            //1            1
            // Output: true

            // Arrange
            var p = CreateTree(new int?[] { 5, 4, null, 3, null, 2, null, 1 });
            var q = CreateTree(new int?[] { 5, 4, null, 3, null, 2, null, 1 });

            // Act
            var result = solution.IsSameTree(p, q);

            // Assert
            Assert.IsTrue(result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsSameTree_IdenticalRightSkewed_ReturnsTrue(ISameTree_100 solution, string solutionName)
        {
            // Input: p = [1,null,2,null,3,null,4,null,5], q = [1,null,2,null,3,null,4,null,5]
            // 1            1
            //  \            \
            //   2            2
            //    \            \
            //     3            3
            //      \            \
            //       4            4
            //        \            \
            //         5            5
            // Output: true

            // Arrange
            var p = CreateTree(new int?[] { 1, null, 2, null, 3, null, 4, null, 5 });
            var q = CreateTree(new int?[] { 1, null, 2, null, 3, null, 4, null, 5 });

            // Act
            var result = solution.IsSameTree(p, q);

            // Assert
            Assert.IsTrue(result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsSameTree_IdenticalSparseTree_ReturnsTrue(ISameTree_100 solution, string solutionName)
        {
            // Input: p = [8,4,12,null,6,10], q = [8,4,12,null,6,10]
            //     8            8
            //    / \          / \
            //   4   12       4   12
            //    \ /          \ /
            //     6 10         6 10
            // Output: true

            // Arrange
            var p = CreateTree(new int?[] { 8, 4, 12, null, 6, 10 });
            var q = CreateTree(new int?[] { 8, 4, 12, null, 6, 10 });

            // Act
            var result = solution.IsSameTree(p, q);

            // Assert
            Assert.IsTrue(result, $"Failed for {solutionName}");
        }

        #endregion

        #region Edge Cases - Values

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsSameTree_NegativeValues_ReturnsTrue(ISameTree_100 solution, string solutionName)
        {
            // Input: p = [0,-2,2,-3,-1,1,3], q = [0,-2,2,-3,-1,1,3]
            //        0                 0
            //       / \               / \
            //     -2   2            -2   2
            //     / \ / \           / \ / \
            //   -3 -1 1  3        -3 -1 1  3
            // Output: true

            // Arrange
            var p = CreateTree(new int?[] { 0, -2, 2, -3, -1, 1, 3 });
            var q = CreateTree(new int?[] { 0, -2, 2, -3, -1, 1, 3 });

            // Act
            var result = solution.IsSameTree(p, q);

            // Assert
            Assert.IsTrue(result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsSameTree_AllNegativeValues_ReturnsTrue(ISameTree_100 solution, string solutionName)
        {
            // Input: p = [-4,-6,-2,-7,-5,-3,-1], q = [-4,-6,-2,-7,-5,-3,-1]
            // Output: true

            // Arrange
            var p = CreateTree(new int?[] { -4, -6, -2, -7, -5, -3, -1 });
            var q = CreateTree(new int?[] { -4, -6, -2, -7, -5, -3, -1 });

            // Act
            var result = solution.IsSameTree(p, q);

            // Assert
            Assert.IsTrue(result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsSameTree_DuplicateValues_ReturnsTrue(ISameTree_100 solution, string solutionName)
        {
            // Input: p = [5,5,5,5,5], q = [5,5,5,5,5]
            //      5            5
            //     / \          / \
            //    5   5        5   5
            //   / \          / \
            //  5   5        5   5
            // Output: true

            // Arrange
            var p = CreateTree(new int?[] { 5, 5, 5, 5, 5 });
            var q = CreateTree(new int?[] { 5, 5, 5, 5, 5 });

            // Act
            var result = solution.IsSameTree(p, q);

            // Assert
            Assert.IsTrue(result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsSameTree_AllZeros_ReturnsTrue(ISameTree_100 solution, string solutionName)
        {
            // Input: p = [0,0,0], q = [0,0,0]
            //      0            0
            //     / \          / \
            //    0   0        0   0
            // Output: true

            // Arrange
            var p = CreateSimpleTree(0, 0, 0);
            var q = CreateSimpleTree(0, 0, 0);

            // Act
            var result = solution.IsSameTree(p, q);

            // Assert
            Assert.IsTrue(result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsSameTree_LargeValues_ReturnsTrue(ISameTree_100 solution, string solutionName)
        {
            // Input: p = [10000,-10000,10000], q = [10000,-10000,10000]
            // Output: true

            // Arrange
            var p = CreateSimpleTree(10000, -10000, 10000);
            var q = CreateSimpleTree(10000, -10000, 10000);

            // Act
            var result = solution.IsSameTree(p, q);

            // Assert
            Assert.IsTrue(result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsSameTree_DifferentNegativeValues_ReturnsFalse(ISameTree_100 solution, string solutionName)
        {
            // Input: p = [-1,-2,-3], q = [-1,-2,-4]
            // Output: false

            // Arrange
            var p = CreateSimpleTree(-1, -2, -3);
            var q = CreateSimpleTree(-1, -2, -4);

            // Act
            var result = solution.IsSameTree(p, q);

            // Assert
            Assert.IsFalse(result, $"Failed for {solutionName}");
        }

        #endregion

        #region Complex Trees

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsSameTree_ComplexIdentical_ReturnsTrue(ISameTree_100 solution, string solutionName)
        {
            // Input: p = [10,5,15,3,7,null,20,1,4,null,9], q = [10,5,15,3,7,null,20,1,4,null,9]
            //           10                     10
            //          /  \                   /  \
            //         5    15                5    15
            //        / \     \              / \     \
            //       3   7     20           3   7     20
            //      / \   \                / \   \
            //     1   4   9              1   4   9
            // Output: true

            // Arrange
            var p = CreateTree(new int?[] { 10, 5, 15, 3, 7, null, 20, 1, 4, null, 9 });
            var q = CreateTree(new int?[] { 10, 5, 15, 3, 7, null, 20, 1, 4, null, 9 });

            // Act
            var result = solution.IsSameTree(p, q);

            // Assert
            Assert.IsTrue(result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsSameTree_ComplexDifferent_ReturnsFalse(ISameTree_100 solution, string solutionName)
        {
            // Input: p = [10,5,15,3,7,null,20,1,4,null,9], q = [10,5,15,3,7,null,20,1,4,null,8]
            // Output: false (different deepest value: 9 vs 8)

            // Arrange
            var p = CreateTree(new int?[] { 10, 5, 15, 3, 7, null, 20, 1, 4, null, 9 });
            var q = CreateTree(new int?[] { 10, 5, 15, 3, 7, null, 20, 1, 4, null, 8 });

            // Act
            var result = solution.IsSameTree(p, q);

            // Assert
            Assert.IsFalse(result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsSameTree_ZigZagPattern_ReturnsFalse(ISameTree_100 solution, string solutionName)
        {
            // Input: p = [1,null,2,3], q = [1,2,null,null,3]
            //    1            1
            //     \          /
            //      2        2
            //     /          \
            //    3            3
            // Output: false (different structure)

            // Arrange
            var p = CreateTree(new int?[] { 1, null, 2, 3 });
            var q = CreateTree(new int?[] { 1, 2, null, null, 3 });

            // Act
            var result = solution.IsSameTree(p, q);

            // Assert
            Assert.IsFalse(result, $"Failed for {solutionName}");
        }

        #endregion

        #region Larger Trees

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsSameTree_LargeIdentical31Nodes_ReturnsTrue(ISameTree_100 solution, string solutionName)
        {
            // Perfect binary tree with 5 levels (31 nodes)
            // Output: true

            // Arrange
            var p = CreateTree(new int?[] { 
                16, 8, 24, 4, 12, 20, 28, 2, 6, 10, 14, 18, 22, 26, 30,
                1, 3, 5, 7, 9, 11, 13, 15, 17, 19, 21, 23, 25, 27, 29, 31
            });
            var q = CreateTree(new int?[] { 
                16, 8, 24, 4, 12, 20, 28, 2, 6, 10, 14, 18, 22, 26, 30,
                1, 3, 5, 7, 9, 11, 13, 15, 17, 19, 21, 23, 25, 27, 29, 31
            });

            // Act
            var result = solution.IsSameTree(p, q);

            // Assert
            Assert.IsTrue(result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsSameTree_LargeDifferent31Nodes_ReturnsFalse(ISameTree_100 solution, string solutionName)
        {
            // Perfect binary tree with 5 levels, one node different
            // Output: false

            // Arrange
            var p = CreateTree(new int?[] { 
                16, 8, 24, 4, 12, 20, 28, 2, 6, 10, 14, 18, 22, 26, 30,
                1, 3, 5, 7, 9, 11, 13, 15, 17, 19, 21, 23, 25, 27, 29, 31
            });
            var q = CreateTree(new int?[] { 
                16, 8, 24, 4, 12, 20, 28, 2, 6, 10, 14, 18, 22, 26, 30,
                1, 3, 5, 7, 9, 11, 13, 15, 17, 19, 21, 23, 25, 27, 29, 32  // Last node different
            });

            // Act
            var result = solution.IsSameTree(p, q);

            // Assert
            Assert.IsFalse(result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsSameTree_VeryDeepIdentical_ReturnsTrue(ISameTree_100 solution, string solutionName)
        {
            // Deep left-skewed tree (20 nodes)
            // Output: true

            // Arrange
            TreeNode p = new TreeNode(20);
            TreeNode currentP = p;
            for (int i = 19; i >= 1; i--)
            {
                currentP.left = new TreeNode(i);
                currentP = currentP.left;
            }

            TreeNode q = new TreeNode(20);
            TreeNode currentQ = q;
            for (int i = 19; i >= 1; i--)
            {
                currentQ.left = new TreeNode(i);
                currentQ = currentQ.left;
            }

            // Act
            var result = solution.IsSameTree(p, q);

            // Assert
            Assert.IsTrue(result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsSameTree_VeryDeepDifferent_ReturnsFalse(ISameTree_100 solution, string solutionName)
        {
            // Deep left-skewed tree, one deep node different
            // Output: false

            // Arrange
            TreeNode p = new TreeNode(20);
            TreeNode currentP = p;
            for (int i = 19; i >= 1; i--)
            {
                currentP.left = new TreeNode(i);
                currentP = currentP.left;
            }

            TreeNode q = new TreeNode(20);
            TreeNode currentQ = q;
            for (int i = 19; i >= 2; i--)
            {
                currentQ.left = new TreeNode(i);
                currentQ = currentQ.left;
            }
            currentQ.left = new TreeNode(999);  // Different value at deepest node

            // Act
            var result = solution.IsSameTree(p, q);

            // Assert
            Assert.IsFalse(result, $"Failed for {solutionName}");
        }

        #endregion

        #region Boundary Cases

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsSameTree_SymmetricTreesIdentical_ReturnsTrue(ISameTree_100 solution, string solutionName)
        {
            // Input: p = [1,2,2,3,4,4,3], q = [1,2,2,3,4,4,3]
            //        1                 1
            //       / \               / \
            //      2   2             2   2
            //     / \ / \           / \ / \
            //    3  4 4  3         3  4 4  3
            // Output: true

            // Arrange
            var p = CreateTree(new int?[] { 1, 2, 2, 3, 4, 4, 3 });
            var q = CreateTree(new int?[] { 1, 2, 2, 3, 4, 4, 3 });

            // Act
            var result = solution.IsSameTree(p, q);

            // Assert
            Assert.IsTrue(result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsSameTree_OneMissingNullNode_ReturnsFalse(ISameTree_100 solution, string solutionName)
        {
            // Input: p = [1,2,3,4,null,5,6], q = [1,2,3,null,null,5,6]
            //        1                 1
            //       / \               / \
            //      2   3             2   3
            //     /   / \               / \
            //    4   5   6             5   6
            // Output: false

            // Arrange
            var p = CreateTree(new int?[] { 1, 2, 3, 4, null, 5, 6 });
            var q = CreateTree(new int?[] { 1, 2, 3, null, null, 5, 6 });

            // Act
            var result = solution.IsSameTree(p, q);

            // Assert
            Assert.IsFalse(result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsSameTree_SameStructureAllNulls_ReturnsFalse(ISameTree_100 solution, string solutionName)
        {
            // Input: p = [1,null,null], q = [2,null,null]
            // Both have same structure (just root), but different values
            // Output: false

            // Arrange
            var p = new TreeNode(1);
            var q = new TreeNode(2);

            // Act
            var result = solution.IsSameTree(p, q);

            // Assert
            Assert.IsFalse(result, $"Failed for {solutionName}");
        }

        #endregion

        #region Property Tests

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsSameTree_TreeComparedWithItself_ReturnsTrue(ISameTree_100 solution, string solutionName)
        {
            // A tree compared with itself should always be true
            // Note: This creates two separate instances with same structure

            // Arrange
            var p = CreateTree(new int?[] { 1, 2, 3, 4, 5, 6, 7 });
            var q = CreateTree(new int?[] { 1, 2, 3, 4, 5, 6, 7 });

            // Act
            var result = solution.IsSameTree(p, q);

            // Assert
            Assert.IsTrue(result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsSameTree_Reflexive_SameReference_ReturnsTrue(ISameTree_100 solution, string solutionName)
        {
            // A tree compared with literally the same reference
            // Output: true

            // Arrange
            var p = CreateTree(new int?[] { 1, 2, 3 });
            var q = p;  // Same reference

            // Act
            var result = solution.IsSameTree(p, q);

            // Assert
            Assert.IsTrue(result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsSameTree_Symmetric_LeftRightSwapped_ReturnsFalse(ISameTree_100 solution, string solutionName)
        {
            // Mirror images should not be considered same
            // Input: p = [1,2,3], q = [1,3,2]
            //    1         1
            //   / \       / \
            //  2   3     3   2
            // Output: false

            // Arrange
            var p = CreateSimpleTree(1, 2, 3);
            var q = CreateSimpleTree(1, 3, 2);

            // Act
            var result = solution.IsSameTree(p, q);

            // Assert
            Assert.IsFalse(result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsSameTree_Transitive_IfPEqualQAndQEqualR_ThenPEqualR(ISameTree_100 solution, string solutionName)
        {
            // If p == q and q == r, then p == r (transitivity)
            // Output: all comparisons should be true

            // Arrange
            var p = CreateTree(new int?[] { 1, 2, 3 });
            var q = CreateTree(new int?[] { 1, 2, 3 });
            var r = CreateTree(new int?[] { 1, 2, 3 });

            // Act
            var pq = solution.IsSameTree(p, q);
            var qr = solution.IsSameTree(q, r);
            var pr = solution.IsSameTree(p, r);

            // Assert
            Assert.IsTrue(pq, $"Failed for {solutionName}");
            Assert.IsTrue(qr, $"Failed for {solutionName}");
            Assert.IsTrue(pr, $"Failed for {solutionName}");
        }

        #endregion
    }
}
