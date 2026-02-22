using LeetCodeProblems.CSharp.Tree;
using LeetCodeProblems.Interfaces.Medium;
using LeetCodeProblems.Shared;
using LeetCodeProblems.VisualBasic;

namespace GrindingLeetCode.UnitTests.Medium
{
    [TestClass]
    public class ConstructBinaryTreeFromPreorderAndPostorderTraversal_889_Tests
    {
        public static IEnumerable<object[]> GetImplementations()
        {
            //yield return new object[] { new ConstructBinaryTreeFromPreorderAndPostorderTraversal_RecursiveHashmap_CSharp_889(), "C# Recursive Hashmap" };
            //yield return new object[] { new ConstructBinaryTreeFromPreorderAndPostorderTraversal_RecursiveNeetcode_CSharp_889(), "C# Recursive Neetcode" };
            //yield return new object[] { new ConstructBinaryTreeFromPreorderAndPostorderTraversal_RecursiveCononical_CSharp_889(), "C# Recursive Canonical" };

            //yield return new object[] { new ConstructBinaryTreeFromPreorderAndPostorderTraversal_IterativeHashmap_CSharp_889(), "C# Iterative Hashmap" };
            yield return new object[] { new ConstructBinaryTreeFromPreorderAndPostorderTraversal_IterativeNeetcode_CSharp_889(), "C# Iterative Neetcode" };
            //yield return new object[] { new ConstructBinaryTreeFromPreorderAndPostorderTraversal_IterativeCononical_CSharp_889(), "C# Iterative Canonical" };

            //yield return new object[] { new ConstructBinaryTreeFromPreorderAndPostorderTraversal_RecursiveHashmap_VB_889(), "VB Recursive Hashmap" };
            //yield return new object[] { new ConstructBinaryTreeFromPreorderAndPostorderTraversal_RecursiveNeetcode_VB_889(), "VB Recursive Neetcode" };
            //yield return new object[] { new ConstructBinaryTreeFromPreorderAndPostorderTraversal_RecursiveCononical_VB_889(), "VB Recursive Canonical" };

            //yield return new object[] { new ConstructBinaryTreeFromPreorderAndPostorderTraversal_IterativeHashmap_VB_889(), "VB Iterative Hashmap" };
            //yield return new object[] { new ConstructBinaryTreeFromPreorderAndPostorderTraversal_IterativeNeetcode_VB_889(), "VB Iterative Neetcode" };
            //yield return new object[] { new ConstructBinaryTreeFromPreorderAndPostorderTraversal_IterativeCononical_VB_889(), "VB Iterative Canonical" };

        }

        #region Helper Methods

        /// <summary>
        /// Performs preorder traversal and returns the sequence
        /// </summary>
        private List<int> PreorderTraversal(TreeNode root)
        {
            var result = new List<int>();
            if (root == null) return result;

            result.Add(root.val);
            result.AddRange(PreorderTraversal(root.left));
            result.AddRange(PreorderTraversal(root.right));

            return result;
        }

        /// <summary>
        /// Performs postorder traversal and returns the sequence
        /// </summary>
        private List<int> PostorderTraversal(TreeNode root)
        {
            var result = new List<int>();
            if (root == null) return result;

            result.AddRange(PostorderTraversal(root.left));
            result.AddRange(PostorderTraversal(root.right));
            result.Add(root.val);

            return result;
        }

        /// <summary>
        /// Verifies that the tree structure matches expected preorder and postorder traversals
        /// </summary>
        private void AssertTreeStructure(TreeNode root, int[] expectedPreorder, int[] expectedPostorder, string solutionName)
        {
            var actualPreorder = PreorderTraversal(root);
            var actualPostorder = PostorderTraversal(root);

            CollectionAssert.AreEqual(expectedPreorder, actualPreorder.ToArray(),
                $"Preorder mismatch for {solutionName}");
            CollectionAssert.AreEqual(expectedPostorder, actualPostorder.ToArray(),
                $"Postorder mismatch for {solutionName}");
        }

        /// <summary>
        /// Counts total nodes in the tree
        /// </summary>
        private int CountNodes(TreeNode root)
        {
            if (root == null) return 0;
            return 1 + CountNodes(root.left) + CountNodes(root.right);
        }

        /// <summary>
        /// Verifies tree structure matches specific expected structure
        /// </summary>
        private void AssertNodeValue(TreeNode node, int? expectedValue, string nodeName, string solutionName)
        {
            if (expectedValue == null)
            {
                Assert.IsNull(node, $"{nodeName} should be null for {solutionName}");
            }
            else
            {
                Assert.IsNotNull(node, $"{nodeName} should not be null for {solutionName}");
                Assert.AreEqual(expectedValue.Value, node.val,
                    $"{nodeName} value mismatch for {solutionName}");
            }
        }

        #endregion

        #region LeetCode Examples

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void ConstructFromPrePost_Example1_ReturnsCorrectTree(IConstructBinaryTreeFromPreorderAndPostorderTraversal_889 solution, string solutionName)
        {
            // Input: preorder = [1,2,4,5,3,6,7], postorder = [4,5,2,6,7,3,1]
            //      1
            //     / \
            //    2   3
            //   / \ / \
            //  4  5 6  7
            // Output: [1,2,3,4,5,6,7]

            // Arrange
            int[] preorder = { 1, 2, 4, 5, 3, 6, 7 };
            int[] postorder = { 4, 5, 2, 6, 7, 3, 1 };

            // Act
            var result = solution.ConstructFromPrePost(preorder, postorder);

            // Assert
            Assert.IsNotNull(result, $"Result should not be null for {solutionName}");
            AssertTreeStructure(result, preorder, postorder, solutionName);
            Assert.AreEqual(1, result.val, $"Root value for {solutionName}");
            Assert.AreEqual(7, CountNodes(result), $"Node count for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void ConstructFromPrePost_Example2_SingleNode_ReturnsCorrectTree(IConstructBinaryTreeFromPreorderAndPostorderTraversal_889 solution, string solutionName)
        {
            // Input: preorder = [1], postorder = [1]
            // Output: [1]

            // Arrange
            int[] preorder = { 1 };
            int[] postorder = { 1 };

            // Act
            var result = solution.ConstructFromPrePost(preorder, postorder);

            // Assert
            Assert.IsNotNull(result, $"Result should not be null for {solutionName}");
            Assert.AreEqual(1, result.val, $"Root value for {solutionName}");
            Assert.IsNull(result.left, $"Left child should be null for {solutionName}");
            Assert.IsNull(result.right, $"Right child should be null for {solutionName}");
        }

        #endregion

        #region Single Node Trees

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void ConstructFromPrePost_SingleNodePositive_ReturnsCorrectTree(IConstructBinaryTreeFromPreorderAndPostorderTraversal_889 solution, string solutionName)
        {
            // Arrange
            int[] preorder = { 5 };
            int[] postorder = { 5 };

            // Act
            var result = solution.ConstructFromPrePost(preorder, postorder);

            // Assert
            Assert.IsNotNull(result, $"Failed for {solutionName}");
            Assert.AreEqual(5, result.val, $"Failed for {solutionName}");
            Assert.IsNull(result.left, $"Failed for {solutionName}");
            Assert.IsNull(result.right, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void ConstructFromPrePost_SingleNodeZero_ReturnsCorrectTree(IConstructBinaryTreeFromPreorderAndPostorderTraversal_889 solution, string solutionName)
        {
            // Arrange
            int[] preorder = { 0 };
            int[] postorder = { 0 };

            // Act
            var result = solution.ConstructFromPrePost(preorder, postorder);

            // Assert
            Assert.IsNotNull(result, $"Failed for {solutionName}");
            Assert.AreEqual(0, result.val, $"Failed for {solutionName}");
        }

        #endregion

        #region Two Node Trees

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void ConstructFromPrePost_TwoNodes_LeftChild_ReturnsCorrectTree(IConstructBinaryTreeFromPreorderAndPostorderTraversal_889 solution, string solutionName)
        {
            // Tree:  2
            //       /
            //      1
            // Preorder: [2, 1], Postorder: [1, 2]

            // Arrange
            int[] preorder = { 2, 1 };
            int[] postorder = { 1, 2 };

            // Act
            var result = solution.ConstructFromPrePost(preorder, postorder);

            // Assert
            AssertTreeStructure(result, preorder, postorder, solutionName);
            Assert.AreEqual(2, result.val, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void ConstructFromPrePost_TwoNodes_RightChild_ReturnsCorrectTree(IConstructBinaryTreeFromPreorderAndPostorderTraversal_889 solution, string solutionName)
        {
            // Tree:  1
            //         \
            //          2
            // Preorder: [1, 2], Postorder: [2, 1]

            // Arrange
            int[] preorder = { 1, 2 };
            int[] postorder = { 2, 1 };

            // Act
            var result = solution.ConstructFromPrePost(preorder, postorder);

            // Assert
            AssertTreeStructure(result, preorder, postorder, solutionName);
            Assert.AreEqual(1, result.val, $"Failed for {solutionName}");
        }

        #endregion

        #region Three Node Trees

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void ConstructFromPrePost_ThreeNodes_Balanced_ReturnsCorrectTree(IConstructBinaryTreeFromPreorderAndPostorderTraversal_889 solution, string solutionName)
        {
            // Tree:    2
            //         / \
            //        1   3
            // Preorder: [2, 1, 3], Postorder: [1, 3, 2]

            // Arrange
            int[] preorder = { 2, 1, 3 };
            int[] postorder = { 1, 3, 2 };

            // Act
            var result = solution.ConstructFromPrePost(preorder, postorder);

            // Assert
            AssertTreeStructure(result, preorder, postorder, solutionName);
            Assert.AreEqual(2, result.val, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void ConstructFromPrePost_ThreeNodes_LeftSkewed_ReturnsCorrectTree(IConstructBinaryTreeFromPreorderAndPostorderTraversal_889 solution, string solutionName)
        {
            // Tree:      3
            //           /
            //          2
            //         /
            //        1
            // Preorder: [3, 2, 1], Postorder: [1, 2, 3]

            // Arrange
            int[] preorder = { 3, 2, 1 };
            int[] postorder = { 1, 2, 3 };

            // Act
            var result = solution.ConstructFromPrePost(preorder, postorder);

            // Assert
            AssertTreeStructure(result, preorder, postorder, solutionName);
            Assert.AreEqual(3, result.val, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void ConstructFromPrePost_ThreeNodes_RightSkewed_ReturnsCorrectTree(IConstructBinaryTreeFromPreorderAndPostorderTraversal_889 solution, string solutionName)
        {
            // Tree:  1
            //         \
            //          2
            //           \
            //            3
            // Preorder: [1, 2, 3], Postorder: [3, 2, 1]

            // Arrange
            int[] preorder = { 1, 2, 3 };
            int[] postorder = { 3, 2, 1 };

            // Act
            var result = solution.ConstructFromPrePost(preorder, postorder);

            // Assert
            AssertTreeStructure(result, preorder, postorder, solutionName);
            Assert.AreEqual(1, result.val, $"Failed for {solutionName}");
        }

        #endregion

        #region Perfect Binary Trees

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void ConstructFromPrePost_PerfectTree_7Nodes_ReturnsCorrectTree(IConstructBinaryTreeFromPreorderAndPostorderTraversal_889 solution, string solutionName)
        {
            // Tree:        4
            //            /   \
            //           2     6
            //          / \   / \
            //         1   3 5   7
            // Preorder:  [4, 2, 1, 3, 6, 5, 7]
            // Postorder: [1, 3, 2, 5, 7, 6, 4]

            // Arrange
            int[] preorder = { 4, 2, 1, 3, 6, 5, 7 };
            int[] postorder = { 1, 3, 2, 5, 7, 6, 4 };

            // Act
            var result = solution.ConstructFromPrePost(preorder, postorder);

            // Assert
            AssertTreeStructure(result, preorder, postorder, solutionName);
            Assert.AreEqual(7, CountNodes(result), $"Node count for {solutionName}");
            Assert.AreEqual(4, result.val, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void ConstructFromPrePost_PerfectTree_15Nodes_ReturnsCorrectTree(IConstructBinaryTreeFromPreorderAndPostorderTraversal_889 solution, string solutionName)
        {
            // Tree:               8
            //                /       \
            //               4         12
            //             /   \      /   \
            //            2     6    10    14
            //           / \   / \   / \   / \
            //          1   3 5   7 9  11 13 15
            // Preorder:  [8, 4, 2, 1, 3, 6, 5, 7, 12, 10, 9, 11, 14, 13, 15]
            // Postorder: [1, 3, 2, 5, 7, 6, 4, 9, 11, 10, 13, 15, 14, 12, 8]

            // Arrange
            int[] preorder = { 8, 4, 2, 1, 3, 6, 5, 7, 12, 10, 9, 11, 14, 13, 15 };
            int[] postorder = { 1, 3, 2, 5, 7, 6, 4, 9, 11, 10, 13, 15, 14, 12, 8 };

            // Act
            var result = solution.ConstructFromPrePost(preorder, postorder);

            // Assert
            AssertTreeStructure(result, preorder, postorder, solutionName);
            Assert.AreEqual(15, CountNodes(result), $"Node count for {solutionName}");
            Assert.AreEqual(8, result.val, $"Failed for {solutionName}");
        }

        #endregion

        #region Left Skewed Trees

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void ConstructFromPrePost_LeftSkewed_5Nodes_ReturnsCorrectTree(IConstructBinaryTreeFromPreorderAndPostorderTraversal_889 solution, string solutionName)
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
            // Preorder:  [5, 4, 3, 2, 1]
            // Postorder: [1, 2, 3, 4, 5]

            // Arrange
            int[] preorder = { 5, 4, 3, 2, 1 };
            int[] postorder = { 1, 2, 3, 4, 5 };

            // Act
            var result = solution.ConstructFromPrePost(preorder, postorder);

            // Assert
            AssertTreeStructure(result, preorder, postorder, solutionName);
            Assert.AreEqual(5, CountNodes(result), $"Node count for {solutionName}");
            Assert.IsNull(result.right, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void ConstructFromPrePost_LeftSkewed_10Nodes_ReturnsCorrectTree(IConstructBinaryTreeFromPreorderAndPostorderTraversal_889 solution, string solutionName)
        {
            // Deep left-skewed tree
            // Preorder:  [10, 9, 8, 7, 6, 5, 4, 3, 2, 1]
            // Postorder: [1, 2, 3, 4, 5, 6, 7, 8, 9, 10]

            // Arrange
            int[] preorder = { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 };
            int[] postorder = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            // Act
            var result = solution.ConstructFromPrePost(preorder, postorder);

            // Assert
            AssertTreeStructure(result, preorder, postorder, solutionName);
            Assert.AreEqual(10, CountNodes(result), $"Node count for {solutionName}");
        }

        #endregion

        #region Right Skewed Trees

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void ConstructFromPrePost_RightSkewed_5Nodes_ReturnsCorrectTree(IConstructBinaryTreeFromPreorderAndPostorderTraversal_889 solution, string solutionName)
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
            // Preorder:  [1, 2, 3, 4, 5]
            // Postorder: [5, 4, 3, 2, 1]

            // Arrange
            int[] preorder = { 1, 2, 3, 4, 5 };
            int[] postorder = { 5, 4, 3, 2, 1 };

            // Act
            var result = solution.ConstructFromPrePost(preorder, postorder);

            // Assert
            AssertTreeStructure(result, preorder, postorder, solutionName);
            Assert.AreEqual(5, CountNodes(result), $"Node count for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void ConstructFromPrePost_RightSkewed_10Nodes_ReturnsCorrectTree(IConstructBinaryTreeFromPreorderAndPostorderTraversal_889 solution, string solutionName)
        {
            // Deep right-skewed tree
            // Preorder:  [1, 2, 3, 4, 5, 6, 7, 8, 9, 10]
            // Postorder: [10, 9, 8, 7, 6, 5, 4, 3, 2, 1]

            // Arrange
            int[] preorder = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int[] postorder = { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 };

            // Act
            var result = solution.ConstructFromPrePost(preorder, postorder);

            // Assert
            AssertTreeStructure(result, preorder, postorder, solutionName);
            Assert.AreEqual(10, CountNodes(result), $"Node count for {solutionName}");
        }

        #endregion

        #region Asymmetric Trees

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void ConstructFromPrePost_AsymmetricTree1_ReturnsCorrectTree(IConstructBinaryTreeFromPreorderAndPostorderTraversal_889 solution, string solutionName)
        {
            // Tree:           10
            //               /    \
            //              5      15
            //            /   \      \
            //           3     7     20
            //          / \
            //         1   4
            // Preorder:  [10, 5, 3, 1, 4, 7, 15, 20]
            // Postorder: [1, 4, 3, 7, 5, 20, 15, 10]

            // Arrange
            int[] preorder = { 10, 5, 3, 1, 4, 7, 15, 20 };
            int[] postorder = { 1, 4, 3, 7, 5, 20, 15, 10 };

            // Act
            var result = solution.ConstructFromPrePost(preorder, postorder);

            // Assert
            AssertTreeStructure(result, preorder, postorder, solutionName);
            Assert.AreEqual(8, CountNodes(result), $"Node count for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void ConstructFromPrePost_AsymmetricTree2_ReturnsCorrectTree(IConstructBinaryTreeFromPreorderAndPostorderTraversal_889 solution, string solutionName)
        {
            // Tree:        20
            //            /    \
            //          10      30
            //         /      /    \
            //        5      25    35
            //       / \            \
            //      3   7           40
            // Preorder:  [20, 10, 5, 3, 7, 30, 25, 35, 40]
            // Postorder: [3, 7, 5, 10, 25, 40, 35, 30, 20]

            // Arrange
            int[] preorder = { 20, 10, 5, 3, 7, 30, 25, 35, 40 };
            int[] postorder = { 3, 7, 5, 10, 25, 40, 35, 30, 20 };

            // Act
            var result = solution.ConstructFromPrePost(preorder, postorder);

            // Assert
            AssertTreeStructure(result, preorder, postorder, solutionName);
            Assert.AreEqual(9, CountNodes(result), $"Node count for {solutionName}");
        }

        #endregion

        #region Edge Cases - Negative Values

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void ConstructFromPrePost_NegativeValues_ReturnsCorrectTree(IConstructBinaryTreeFromPreorderAndPostorderTraversal_889 solution, string solutionName)
        {
            // Tree:       0
            //           /   \
            //         -5     5
            //         / \   / \
            //       -8  -3 3   8
            // Preorder:  [0, -5, -8, -3, 5, 3, 8]
            // Postorder: [-8, -3, -5, 3, 8, 5, 0]

            // Arrange
            int[] preorder = { 0, -5, -8, -3, 5, 3, 8 };
            int[] postorder = { -8, -3, -5, 3, 8, 5, 0 };

            // Act
            var result = solution.ConstructFromPrePost(preorder, postorder);

            // Assert
            AssertTreeStructure(result, preorder, postorder, solutionName);
            Assert.AreEqual(0, result.val, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void ConstructFromPrePost_AllNegativeValues_ReturnsCorrectTree(IConstructBinaryTreeFromPreorderAndPostorderTraversal_889 solution, string solutionName)
        {
            // Tree:       -4
            //           /    \
            //         -6     -2
            //         / \    / \
            //       -7  -5 -3  -1
            // Preorder:  [-4, -6, -7, -5, -2, -3, -1]
            // Postorder: [-7, -5, -6, -3, -1, -2, -4]

            // Arrange
            int[] preorder = { -4, -6, -7, -5, -2, -3, -1 };
            int[] postorder = { -7, -5, -6, -3, -1, -2, -4 };

            // Act
            var result = solution.ConstructFromPrePost(preorder, postorder);

            // Assert
            AssertTreeStructure(result, preorder, postorder, solutionName);
            Assert.AreEqual(-4, result.val, $"Failed for {solutionName}");
        }

        #endregion

        #region Complex Real-World Scenarios

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void ConstructFromPrePost_ComplexTree1_ReturnsCorrectTree(IConstructBinaryTreeFromPreorderAndPostorderTraversal_889 solution, string solutionName)
        {
            // Tree:            100
            //               /      \
            //             50        150
            //            /  \      /   \
            //          25   75   125   175
            //         /    /  \       /   \
            //       10    60  80    160   190
            // Preorder:  [100, 50, 25, 10, 75, 60, 80, 150, 125, 175, 160, 190]
            // Postorder: [10, 25, 60, 80, 75, 50, 125, 160, 190, 175, 150, 100]

            // Arrange
            int[] preorder = { 100, 50, 25, 10, 75, 60, 80, 150, 125, 175, 160, 190 };
            int[] postorder = { 10, 25, 60, 80, 75, 50, 125, 160, 190, 175, 150, 100 };

            // Act
            var result = solution.ConstructFromPrePost(preorder, postorder);

            // Assert
            AssertTreeStructure(result, preorder, postorder, solutionName);
            Assert.AreEqual(12, CountNodes(result), $"Node count for {solutionName}");
            Assert.AreEqual(100, result.val, $"Root value for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void ConstructFromPrePost_ComplexTree2_ReturnsCorrectTree(IConstructBinaryTreeFromPreorderAndPostorderTraversal_889 solution, string solutionName)
        {
            // Tree with mixed structure
            //              5
            //            /   \
            //           3     8
            //          / \   / \
            //         2   4 7   9
            //        /     /     \
            //       1     6      10
            // Preorder:  [5, 3, 2, 1, 4, 8, 7, 6, 9, 10]
            // Postorder: [1, 2, 4, 3, 6, 7, 10, 9, 8, 5]

            // Arrange
            int[] preorder = { 5, 3, 2, 1, 4, 8, 7, 6, 9, 10 };
            int[] postorder = { 1, 2, 4, 3, 6, 7, 10, 9, 8, 5 };

            // Act
            var result = solution.ConstructFromPrePost(preorder, postorder);

            // Assert
            AssertTreeStructure(result, preorder, postorder, solutionName);
            Assert.AreEqual(10, CountNodes(result), $"Node count for {solutionName}");
        }

        #endregion

        #region Sparse Trees

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void ConstructFromPrePost_SparseTree1_ReturnsCorrectTree(IConstructBinaryTreeFromPreorderAndPostorderTraversal_889 solution, string solutionName)
        {
            // Tree:       10
            //            /    \
            //           5      15
            //            \       \
            //             7      20
            // Preorder:  [10, 5, 7, 15, 20]
            // Postorder: [7, 5, 20, 15, 10]

            // Arrange
            int[] preorder = { 10, 5, 7, 15, 20 };
            int[] postorder = { 7, 5, 20, 15, 10 };

            // Act
            var result = solution.ConstructFromPrePost(preorder, postorder);

            // Assert
            AssertTreeStructure(result, preorder, postorder, solutionName);
            Assert.AreEqual(5, CountNodes(result), $"Node count for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void ConstructFromPrePost_SparseTree2_ReturnsCorrectTree(IConstructBinaryTreeFromPreorderAndPostorderTraversal_889 solution, string solutionName)
        {
            // Tree:       10
            //            /    \
            //           5      15
            //          /       /
            //         3      12
            // Preorder:  [10, 5, 3, 15, 12]
            // Postorder: [3, 5, 12, 15, 10]

            // Arrange
            int[] preorder = { 10, 5, 3, 15, 12 };
            int[] postorder = { 3, 5, 12, 15, 10 };

            // Act
            var result = solution.ConstructFromPrePost(preorder, postorder);

            // Assert
            AssertTreeStructure(result, preorder, postorder, solutionName);
            Assert.AreEqual(5, CountNodes(result), $"Node count for {solutionName}");
        }

        #endregion

        #region Boundary Cases

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void ConstructFromPrePost_MaxIntValue_ReturnsCorrectTree(IConstructBinaryTreeFromPreorderAndPostorderTraversal_889 solution, string solutionName)
        {
            // Tree with int.MaxValue
            // Preorder:  [0, int.MinValue, int.MaxValue]
            // Postorder: [int.MinValue, int.MaxValue, 0]

            // Arrange
            int[] preorder = { 0, int.MinValue, int.MaxValue };
            int[] postorder = { int.MinValue, int.MaxValue, 0 };

            // Act
            var result = solution.ConstructFromPrePost(preorder, postorder);

            // Assert
            AssertTreeStructure(result, preorder, postorder, solutionName);
            Assert.AreEqual(0, result.val, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void ConstructFromPrePost_LargeBalancedTree_ReturnsCorrectTree(IConstructBinaryTreeFromPreorderAndPostorderTraversal_889 solution, string solutionName)
        {
            // Large balanced tree (31 nodes)
            // Preorder:  [50, 25, 12, 6, 3, 9, 18, 15, 21, 37, 31, 28, 34, 43, 40, 46, 75, 62, 56, 53, 59, 68, 65, 71, 87, 81, 78, 84, 93, 90, 96]
            // Postorder: [3, 9, 6, 15, 21, 18, 12, 28, 34, 31, 40, 46, 43, 37, 25, 53, 59, 56, 65, 71, 68, 62, 78, 84, 81, 90, 96, 93, 87, 75, 50]

            // Arrange
            int[] preorder = { 50, 25, 12, 6, 3, 9, 18, 15, 21, 37, 31, 28, 34, 43, 40, 46, 75, 62, 56, 53, 59, 68, 65, 71, 87, 81, 78, 84, 93, 90, 96 };
            int[] postorder = { 3, 9, 6, 15, 21, 18, 12, 28, 34, 31, 40, 46, 43, 37, 25, 53, 59, 56, 65, 71, 68, 62, 78, 84, 81, 90, 96, 93, 87, 75, 50 };

            // Act
            var result = solution.ConstructFromPrePost(preorder, postorder);

            // Assert
            AssertTreeStructure(result, preorder, postorder, solutionName);
            Assert.AreEqual(31, CountNodes(result), $"Node count for {solutionName}");
            Assert.AreEqual(50, result.val, $"Root value for {solutionName}");
        }

        #endregion

        #region Property-Based Tests

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void ConstructFromPrePost_VerifyPreorderProperty_ReturnsCorrectTree(IConstructBinaryTreeFromPreorderAndPostorderTraversal_889 solution, string solutionName)
        {
            // Preorder always visits root first, then left subtree, then right subtree (root is FIRST)

            // Arrange
            int[] preorder = { 10, 5, 3, 7, 15, 12, 20 };
            int[] postorder = { 3, 7, 5, 12, 20, 15, 10 };

            // Act
            var result = solution.ConstructFromPrePost(preorder, postorder);

            // Assert
            var actualPreorder = PreorderTraversal(result);
            Assert.AreEqual(preorder[0], actualPreorder[0],
                $"First element in preorder should be root for {solutionName}");
            CollectionAssert.AreEqual(preorder, actualPreorder.ToArray(),
                $"Preorder property violated for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void ConstructFromPrePost_VerifyPostorderProperty_ReturnsCorrectTree(IConstructBinaryTreeFromPreorderAndPostorderTraversal_889 solution, string solutionName)
        {
            // Postorder visits left subtree, then right subtree, then root (root is LAST)

            // Arrange
            int[] preorder = { 10, 5, 3, 7, 15, 12, 20 };
            int[] postorder = { 3, 7, 5, 12, 20, 15, 10 };

            // Act
            var result = solution.ConstructFromPrePost(preorder, postorder);

            // Assert
            var actualPostorder = PostorderTraversal(result);
            Assert.AreEqual(postorder[postorder.Length - 1], actualPostorder[actualPostorder.Count - 1],
                $"Last element in postorder should be root for {solutionName}");
            CollectionAssert.AreEqual(postorder, actualPostorder.ToArray(),
                $"Postorder property violated for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void ConstructFromPrePost_NodeCountMatchesArrayLength_ReturnsCorrectTree(IConstructBinaryTreeFromPreorderAndPostorderTraversal_889 solution, string solutionName)
        {
            // The number of nodes in the tree should match array length

            // Arrange
            int[] preorder = { 8, 4, 2, 1, 3, 6, 5, 7, 12, 10, 9, 11, 14, 13, 15 };
            int[] postorder = { 1, 3, 2, 5, 7, 6, 4, 9, 11, 10, 13, 15, 14, 12, 8 };

            // Act
            var result = solution.ConstructFromPrePost(preorder, postorder);

            // Assert
            Assert.AreEqual(preorder.Length, CountNodes(result),
                $"Node count should match array length for {solutionName}");
        }

        #endregion

        #region Comparison with LC 105 and LC 106

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void ConstructFromPrePost_CompareWithOtherProblems_SameTree_DifferentTraversals(IConstructBinaryTreeFromPreorderAndPostorderTraversal_889 solution, string solutionName)
        {
            // For the same tree structure:
            // LC 105 uses Preorder + Inorder
            // LC 106 uses Inorder + Postorder
            // LC 889 uses Preorder + Postorder
            //
            // Tree:        4
            //            /   \
            //           2     6
            //          / \   / \
            //         1   3 5   7

            // Arrange
            int[] preorder = { 4, 2, 1, 3, 6, 5, 7 }; // Root is FIRST
            int[] postorder = { 1, 3, 2, 5, 7, 6, 4 }; // Root is LAST

            // Act
            var result = solution.ConstructFromPrePost(preorder, postorder);

            // Assert
            AssertTreeStructure(result, preorder, postorder, solutionName);
            Assert.AreEqual(4, result.val, $"Root should be 4 for {solutionName}");
        }

        #endregion

        #region ZigZag Pattern

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void ConstructFromPrePost_ZigZagPattern_ReturnsCorrectTree(IConstructBinaryTreeFromPreorderAndPostorderTraversal_889 solution, string solutionName)
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
            // Preorder:  [1, 2, 3, 4, 5]
            // Postorder: [5, 4, 3, 2, 1]

            // Arrange
            int[] preorder = { 1, 2, 3, 4, 5 };
            int[] postorder = { 5, 4, 3, 2, 1 };

            // Act
            var result = solution.ConstructFromPrePost(preorder, postorder);

            // Assert
            AssertTreeStructure(result, preorder, postorder, solutionName);
            Assert.AreEqual(5, CountNodes(result), $"Node count for {solutionName}");
        }

        #endregion

        #region Multiple Valid Solutions

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void ConstructFromPrePost_MultipleValidSolutions_AcceptsAnyValid(IConstructBinaryTreeFromPreorderAndPostorderTraversal_889 solution, string solutionName)
        {
            // Note: When a node has only one child, preorder and postorder alone cannot
            // determine if it's a left or right child. Multiple valid trees exist.
            // The solution should return ANY valid tree that matches the traversals.

            // Arrange
            int[] preorder = { 1, 2, 3 };
            int[] postorder = { 3, 2, 1 };

            // Act
            var result = solution.ConstructFromPrePost(preorder, postorder);

            // Assert - Verify the result matches the given traversals
            AssertTreeStructure(result, preorder, postorder, solutionName);
            Assert.AreEqual(3, CountNodes(result), $"Node count for {solutionName}");
        }

        #endregion

        #region Sequential Values

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void ConstructFromPrePost_SequentialValues_ReturnsCorrectTree(IConstructBinaryTreeFromPreorderAndPostorderTraversal_889 solution, string solutionName)
        {
            // Tree with sequential values 1-7
            // Preorder:  [4, 2, 1, 3, 6, 5, 7]
            // Postorder: [1, 3, 2, 5, 7, 6, 4]

            // Arrange
            int[] preorder = { 4, 2, 1, 3, 6, 5, 7 };
            int[] postorder = { 1, 3, 2, 5, 7, 6, 4 };

            // Act
            var result = solution.ConstructFromPrePost(preorder, postorder);

            // Assert
            AssertTreeStructure(result, preorder, postorder, solutionName);
            Assert.AreEqual(7, CountNodes(result), $"Node count for {solutionName}");
        }

        #endregion

        #region Unique Value Distribution

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void ConstructFromPrePost_LargeValuesSpread_ReturnsCorrectTree(IConstructBinaryTreeFromPreorderAndPostorderTraversal_889 solution, string solutionName)
        {
            // Tree with large, spread out values
            // Preorder:  [1000, 500, 250, 750, 1500, 1250, 1750]
            // Postorder: [250, 750, 500, 1250, 1750, 1500, 1000]

            // Arrange
            int[] preorder = { 1000, 500, 250, 750, 1500, 1250, 1750 };
            int[] postorder = { 250, 750, 500, 1250, 1750, 1500, 1000 };

            // Act
            var result = solution.ConstructFromPrePost(preorder, postorder);

            // Assert
            AssertTreeStructure(result, preorder, postorder, solutionName);
            Assert.AreEqual(7, CountNodes(result), $"Node count for {solutionName}");
            Assert.AreEqual(1000, result.val, $"Root value for {solutionName}");
        }

        #endregion

        #region Deep Asymmetric Trees

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void ConstructFromPrePost_DeepLeftHeavy_ReturnsCorrectTree(IConstructBinaryTreeFromPreorderAndPostorderTraversal_889 solution, string solutionName)
        {
            // Tree with deeper left subtree
            //        10
            //       /  \
            //      5    15
            //     / \
            //    3   7
            //   / \
            //  2   4
            // Preorder:  [10, 5, 3, 2, 4, 7, 15]
            // Postorder: [2, 4, 3, 7, 5, 15, 10]

            // Arrange
            int[] preorder = { 10, 5, 3, 2, 4, 7, 15 };
            int[] postorder = { 2, 4, 3, 7, 5, 15, 10 };

            // Act
            var result = solution.ConstructFromPrePost(preorder, postorder);

            // Assert
            AssertTreeStructure(result, preorder, postorder, solutionName);
            Assert.AreEqual(7, CountNodes(result), $"Node count for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void ConstructFromPrePost_DeepRightHeavy_ReturnsCorrectTree(IConstructBinaryTreeFromPreorderAndPostorderTraversal_889 solution, string solutionName)
        {
            // Tree with deeper right subtree
            //    5
            //   / \
            //  3   10
            //     / \
            //    8  12
            //       / \
            //      11 13
            // Preorder:  [5, 3, 10, 8, 12, 11, 13]
            // Postorder: [3, 8, 11, 13, 12, 10, 5]

            // Arrange
            int[] preorder = { 5, 3, 10, 8, 12, 11, 13 };
            int[] postorder = { 3, 8, 11, 13, 12, 10, 5 };

            // Act
            var result = solution.ConstructFromPrePost(preorder, postorder);

            // Assert
            AssertTreeStructure(result, preorder, postorder, solutionName);
            Assert.AreEqual(7, CountNodes(result), $"Node count for {solutionName}");
        }

        #endregion
    }
}
