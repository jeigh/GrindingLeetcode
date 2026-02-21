using LeetCodeProblems.CSharp.Tree;
using LeetCodeProblems.Interfaces.Medium;
using LeetCodeProblems.Shared;
using LeetCodeProblems.VisualBasic;

namespace GrindingLeetCode.UnitTests.Medium
{
    [TestClass]
    public class ConstructBinaryTreeFromInorderAndPostorderTraversal_106_Tests
    {
        public static IEnumerable<object[]> GetImplementations()
        {
            yield return new object[] { new ConstructBinaryTreeFromInorderAndPostorderTraversal_RecursiveLimit_CSharp_106(), "C# Recursive LimitValue" };
            yield return new object[] { new ConstructBinaryTreeFromInorderAndPostorderTraversal_RecursiveHashmap_CSharp_106(), "C# Recursive Hashmap" };
            yield return new object[] { new ConstructBinaryTreeFromInorderAndPostorderTraversal_RecursiveThreadSafe_CSharp_106(), "C# Recursive TextBook" };
            yield return new object[] { new ConstructBinaryTreeFromInorderAndPostorderTraversal_IterativeThreadSafe_CSharp_106(), "C# Iterative TextBook" };
            yield return new object[] { new ConstructBinaryTreeFromInorderAndPostorderTraversal_IterativeHashmap_CSharp_106(), "C# Iterative Hashmap" };
            yield return new object[] { new ConstructBinaryTreeFromInorderAndPostorderTraversal_IterativeLimit_CSharp_106(), "C# Iterative LimitValue" };

            yield return new object[] { new ConstructBinaryTreeFromInorderAndPostorderTraversal_RecursiveHashmap_VB_106(), "VB Recursive Hashmap" };
            yield return new object[] { new ConstructBinaryTreeFromInorderAndPostorderTraversal_RecursiveThreadSafe_VB_106(), "VB Recursive TextBook" };
            yield return new object[] { new ConstructBinaryTreeFromInorderAndPostorderTraversal_RecursiveLimit_VB_106(), "VB Recursive LimitValue" };
        }

        #region Helper Methods

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
        /// Performs inorder traversal and returns the sequence
        /// </summary>
        private List<int> InorderTraversal(TreeNode root)
        {
            var result = new List<int>();
            if (root == null) return result;

            result.AddRange(InorderTraversal(root.left));
            result.Add(root.val);
            result.AddRange(InorderTraversal(root.right));

            return result;
        }

        /// <summary>
        /// Verifies that the tree structure matches expected inorder and postorder traversals
        /// </summary>
        private void AssertTreeStructure(TreeNode root, int[] expectedInorder, int[] expectedPostorder, string solutionName)
        {
            var actualInorder = InorderTraversal(root);
            var actualPostorder = PostorderTraversal(root);

            CollectionAssert.AreEqual(expectedInorder, actualInorder.ToArray(),
                $"Inorder mismatch for {solutionName}");
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
        public void BuildTree_Example1_ReturnsCorrectTree(IConstructBinaryTreeFromInOrderAndPostOrderTraversal_106 solution, string solutionName)
        {
            // Input: inorder = [9,3,15,20,7], postorder = [9,15,7,20,3]
            //      3
            //     / \
            //    9  20
            //      /  \
            //     15   7
            // Output: [3,9,20,null,null,15,7]

            // Arrange
            int[] inorder = { 9, 3, 15, 20, 7 };
            int[] postorder = { 9, 15, 7, 20, 3 };

            // Act
            var result = solution.BuildTree(inorder, postorder);

            // Assert
            Assert.IsNotNull(result, $"Result should not be null for {solutionName}");
            AssertTreeStructure(result, inorder, postorder, solutionName);
            Assert.AreEqual(3, result.val, $"Root value for {solutionName}");
            Assert.AreEqual(9, result.left.val, $"Left child value for {solutionName}");
            Assert.AreEqual(20, result.right.val, $"Right child value for {solutionName}");
            Assert.IsNull(result.left.left, $"Left-left should be null for {solutionName}");
            Assert.IsNull(result.left.right, $"Left-right should be null for {solutionName}");
            Assert.AreEqual(15, result.right.left.val, $"Right-left value for {solutionName}");
            Assert.AreEqual(7, result.right.right.val, $"Right-right value for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void BuildTree_Example2_SingleNode_ReturnsCorrectTree(IConstructBinaryTreeFromInOrderAndPostOrderTraversal_106 solution, string solutionName)
        {
            // Input: inorder = [-1], postorder = [-1]
            // Output: [-1]

            // Arrange
            int[] inorder = { -1 };
            int[] postorder = { -1 };

            // Act
            var result = solution.BuildTree(inorder, postorder);

            // Assert
            Assert.IsNotNull(result, $"Result should not be null for {solutionName}");
            Assert.AreEqual(-1, result.val, $"Root value for {solutionName}");
            Assert.IsNull(result.left, $"Left child should be null for {solutionName}");
            Assert.IsNull(result.right, $"Right child should be null for {solutionName}");
        }

        #endregion

        #region Single Node Trees

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void BuildTree_SingleNodePositive_ReturnsCorrectTree(IConstructBinaryTreeFromInOrderAndPostOrderTraversal_106 solution, string solutionName)
        {
            // Arrange
            int[] inorder = { 5 };
            int[] postorder = { 5 };

            // Act
            var result = solution.BuildTree(inorder, postorder);

            // Assert
            Assert.IsNotNull(result, $"Failed for {solutionName}");
            Assert.AreEqual(5, result.val, $"Failed for {solutionName}");
            Assert.IsNull(result.left, $"Failed for {solutionName}");
            Assert.IsNull(result.right, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void BuildTree_SingleNodeZero_ReturnsCorrectTree(IConstructBinaryTreeFromInOrderAndPostOrderTraversal_106 solution, string solutionName)
        {
            // Arrange
            int[] inorder = { 0 };
            int[] postorder = { 0 };

            // Act
            var result = solution.BuildTree(inorder, postorder);

            // Assert
            Assert.IsNotNull(result, $"Failed for {solutionName}");
            Assert.AreEqual(0, result.val, $"Failed for {solutionName}");
        }

        #endregion

        #region Two Node Trees

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void BuildTree_TwoNodes_LeftChild_ReturnsCorrectTree(IConstructBinaryTreeFromInOrderAndPostOrderTraversal_106 solution, string solutionName)
        {
            // Tree:  2
            //       /
            //      1
            // Inorder: [1, 2], Postorder: [1, 2]

            // Arrange
            int[] inorder = { 1, 2 };
            int[] postorder = { 1, 2 };

            // Act
            var result = solution.BuildTree(inorder, postorder);

            // Assert
            AssertTreeStructure(result, inorder, postorder, solutionName);
            Assert.AreEqual(2, result.val, $"Failed for {solutionName}");
            Assert.AreEqual(1, result.left.val, $"Failed for {solutionName}");
            Assert.IsNull(result.right, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void BuildTree_TwoNodes_RightChild_ReturnsCorrectTree(IConstructBinaryTreeFromInOrderAndPostOrderTraversal_106 solution, string solutionName)
        {
            // Tree:  1
            //         \
            //          2
            // Inorder: [1, 2], Postorder: [2, 1]

            // Arrange
            int[] inorder = { 1, 2 };
            int[] postorder = { 2, 1 };

            // Act
            var result = solution.BuildTree(inorder, postorder);

            // Assert
            AssertTreeStructure(result, inorder, postorder, solutionName);
            Assert.AreEqual(1, result.val, $"Failed for {solutionName}");
            Assert.IsNull(result.left, $"Failed for {solutionName}");
            Assert.AreEqual(2, result.right.val, $"Failed for {solutionName}");
        }

        #endregion

        #region Three Node Trees

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void BuildTree_ThreeNodes_Balanced_ReturnsCorrectTree(IConstructBinaryTreeFromInOrderAndPostOrderTraversal_106 solution, string solutionName)
        {
            // Tree:    2
            //         / \
            //        1   3
            // Inorder: [1, 2, 3], Postorder: [1, 3, 2]

            // Arrange
            int[] inorder = { 1, 2, 3 };
            int[] postorder = { 1, 3, 2 };

            // Act
            var result = solution.BuildTree(inorder, postorder);

            // Assert
            AssertTreeStructure(result, inorder, postorder, solutionName);
            Assert.AreEqual(2, result.val, $"Failed for {solutionName}");
            Assert.AreEqual(1, result.left.val, $"Failed for {solutionName}");
            Assert.AreEqual(3, result.right.val, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void BuildTree_ThreeNodes_LeftSkewed_ReturnsCorrectTree(IConstructBinaryTreeFromInOrderAndPostOrderTraversal_106 solution, string solutionName)
        {
            // Tree:      3
            //           /
            //          2
            //         /
            //        1
            // Inorder: [1, 2, 3], Postorder: [1, 2, 3]

            // Arrange
            int[] inorder = { 1, 2, 3 };
            int[] postorder = { 1, 2, 3 };

            // Act
            var result = solution.BuildTree(inorder, postorder);

            // Assert
            AssertTreeStructure(result, inorder, postorder, solutionName);
            Assert.AreEqual(3, result.val, $"Failed for {solutionName}");
            Assert.AreEqual(2, result.left.val, $"Failed for {solutionName}");
            Assert.AreEqual(1, result.left.left.val, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void BuildTree_ThreeNodes_RightSkewed_ReturnsCorrectTree(IConstructBinaryTreeFromInOrderAndPostOrderTraversal_106 solution, string solutionName)
        {
            // Tree:  1
            //         \
            //          2
            //           \
            //            3
            // Inorder: [1, 2, 3], Postorder: [3, 2, 1]

            // Arrange
            int[] inorder = { 1, 2, 3 };
            int[] postorder = { 3, 2, 1 };

            // Act
            var result = solution.BuildTree(inorder, postorder);

            // Assert
            AssertTreeStructure(result, inorder, postorder, solutionName);
            Assert.AreEqual(1, result.val, $"Failed for {solutionName}");
            Assert.AreEqual(2, result.right.val, $"Failed for {solutionName}");
            Assert.AreEqual(3, result.right.right.val, $"Failed for {solutionName}");
        }

        #endregion

        #region Perfect Binary Trees

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void BuildTree_PerfectTree_7Nodes_ReturnsCorrectTree(IConstructBinaryTreeFromInOrderAndPostOrderTraversal_106 solution, string solutionName)
        {
            // Tree:        4
            //            /   \
            //           2     6
            //          / \   / \
            //         1   3 5   7
            // Inorder:  [1, 2, 3, 4, 5, 6, 7]
            // Postorder: [1, 3, 2, 5, 7, 6, 4]

            // Arrange
            int[] inorder = { 1, 2, 3, 4, 5, 6, 7 };
            int[] postorder = { 1, 3, 2, 5, 7, 6, 4 };

            // Act
            var result = solution.BuildTree(inorder, postorder);

            // Assert
            AssertTreeStructure(result, inorder, postorder, solutionName);
            Assert.AreEqual(7, CountNodes(result), $"Node count for {solutionName}");
            Assert.AreEqual(4, result.val, $"Failed for {solutionName}");
            Assert.AreEqual(2, result.left.val, $"Failed for {solutionName}");
            Assert.AreEqual(6, result.right.val, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void BuildTree_PerfectTree_15Nodes_ReturnsCorrectTree(IConstructBinaryTreeFromInOrderAndPostOrderTraversal_106 solution, string solutionName)
        {
            // Tree:               8
            //                /       \
            //               4         12
            //             /   \      /   \
            //            2     6    10    14
            //           / \   / \   / \   / \
            //          1   3 5   7 9  11 13 15
            // Inorder:  [1,2,3,4,5,6,7,8,9,10,11,12,13,14,15]
            // Postorder: [1,3,2,5,7,6,4,9,11,10,13,15,14,12,8]

            // Arrange
            int[] inorder = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
            int[] postorder = { 1, 3, 2, 5, 7, 6, 4, 9, 11, 10, 13, 15, 14, 12, 8 };

            // Act
            var result = solution.BuildTree(inorder, postorder);

            // Assert
            AssertTreeStructure(result, inorder, postorder, solutionName);
            Assert.AreEqual(15, CountNodes(result), $"Node count for {solutionName}");
            Assert.AreEqual(8, result.val, $"Failed for {solutionName}");
        }

        #endregion

        #region Left Skewed Trees

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void BuildTree_LeftSkewed_5Nodes_ReturnsCorrectTree(IConstructBinaryTreeFromInOrderAndPostOrderTraversal_106 solution, string solutionName)
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
            // Inorder:  [1, 2, 3, 4, 5]
            // Postorder: [1, 2, 3, 4, 5]

            // Arrange
            int[] inorder = { 1, 2, 3, 4, 5 };
            int[] postorder = { 1, 2, 3, 4, 5 };

            // Act
            var result = solution.BuildTree(inorder, postorder);

            // Assert
            AssertTreeStructure(result, inorder, postorder, solutionName);
            Assert.AreEqual(5, CountNodes(result), $"Node count for {solutionName}");
            Assert.IsNull(result.right, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void BuildTree_LeftSkewed_10Nodes_ReturnsCorrectTree(IConstructBinaryTreeFromInOrderAndPostOrderTraversal_106 solution, string solutionName)
        {
            // Deep left-skewed tree
            // Inorder:  [1, 2, 3, 4, 5, 6, 7, 8, 9, 10]
            // Postorder: [1, 2, 3, 4, 5, 6, 7, 8, 9, 10]

            // Arrange
            int[] inorder = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int[] postorder = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            // Act
            var result = solution.BuildTree(inorder, postorder);

            // Assert
            AssertTreeStructure(result, inorder, postorder, solutionName);
            Assert.AreEqual(10, CountNodes(result), $"Node count for {solutionName}");
        }

        #endregion

        #region Right Skewed Trees

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void BuildTree_RightSkewed_5Nodes_ReturnsCorrectTree(IConstructBinaryTreeFromInOrderAndPostOrderTraversal_106 solution, string solutionName)
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
            // Inorder:  [1, 2, 3, 4, 5]
            // Postorder: [5, 4, 3, 2, 1]

            // Arrange
            int[] inorder = { 1, 2, 3, 4, 5 };
            int[] postorder = { 5, 4, 3, 2, 1 };

            // Act
            var result = solution.BuildTree(inorder, postorder);

            // Assert
            AssertTreeStructure(result, inorder, postorder, solutionName);
            Assert.AreEqual(5, CountNodes(result), $"Node count for {solutionName}");
            Assert.IsNull(result.left, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void BuildTree_RightSkewed_10Nodes_ReturnsCorrectTree(IConstructBinaryTreeFromInOrderAndPostOrderTraversal_106 solution, string solutionName)
        {
            // Deep right-skewed tree
            // Inorder:  [1, 2, 3, 4, 5, 6, 7, 8, 9, 10]
            // Postorder: [10, 9, 8, 7, 6, 5, 4, 3, 2, 1]

            // Arrange
            int[] inorder = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int[] postorder = { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 };

            // Act
            var result = solution.BuildTree(inorder, postorder);

            // Assert
            AssertTreeStructure(result, inorder, postorder, solutionName);
            Assert.AreEqual(10, CountNodes(result), $"Node count for {solutionName}");
        }

        #endregion

        #region Asymmetric Trees

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void BuildTree_AsymmetricTree1_ReturnsCorrectTree(IConstructBinaryTreeFromInOrderAndPostOrderTraversal_106 solution, string solutionName)
        {
            // Tree:           10
            //               /    \
            //              5      15
            //            /   \      \
            //           3     7     20
            //          / \
            //         1   4
            // Inorder:  [1, 3, 4, 5, 7, 10, 15, 20]
            // Postorder: [1, 4, 3, 7, 5, 20, 15, 10]

            // Arrange
            int[] inorder = { 1, 3, 4, 5, 7, 10, 15, 20 };
            int[] postorder = { 1, 4, 3, 7, 5, 20, 15, 10 };

            // Act
            var result = solution.BuildTree(inorder, postorder);

            // Assert
            AssertTreeStructure(result, inorder, postorder, solutionName);
            Assert.AreEqual(8, CountNodes(result), $"Node count for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void BuildTree_AsymmetricTree2_ReturnsCorrectTree(IConstructBinaryTreeFromInOrderAndPostOrderTraversal_106 solution, string solutionName)
        {
            // Tree:        20
            //            /    \
            //          10      30
            //         /      /    \
            //        5      25    35
            //       / \            \
            //      3   7           40
            // Inorder:  [3, 5, 7, 10, 20, 25, 30, 35, 40]
            // Postorder: [3, 7, 5, 10, 25, 40, 35, 30, 20]

            // Arrange
            int[] inorder = { 3, 5, 7, 10, 20, 25, 30, 35, 40 };
            int[] postorder = { 3, 7, 5, 10, 25, 40, 35, 30, 20 };

            // Act
            var result = solution.BuildTree(inorder, postorder);

            // Assert
            AssertTreeStructure(result, inorder, postorder, solutionName);
            Assert.AreEqual(9, CountNodes(result), $"Node count for {solutionName}");
        }

        #endregion

        #region Edge Cases - Negative Values

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void BuildTree_NegativeValues_ReturnsCorrectTree(IConstructBinaryTreeFromInOrderAndPostOrderTraversal_106 solution, string solutionName)
        {
            // Tree:       0
            //           /   \
            //         -5     5
            //         / \   / \
            //       -8  -3 3   8
            // Inorder:  [-8, -5, -3, 0, 3, 5, 8]
            // Postorder: [-8, -3, -5, 3, 8, 5, 0]

            // Arrange
            int[] inorder = { -8, -5, -3, 0, 3, 5, 8 };
            int[] postorder = { -8, -3, -5, 3, 8, 5, 0 };

            // Act
            var result = solution.BuildTree(inorder, postorder);

            // Assert
            AssertTreeStructure(result, inorder, postorder, solutionName);
            Assert.AreEqual(0, result.val, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void BuildTree_AllNegativeValues_ReturnsCorrectTree(IConstructBinaryTreeFromInOrderAndPostOrderTraversal_106 solution, string solutionName)
        {
            // Tree:       -4
            //           /    \
            //         -6     -2
            //         / \    / \
            //       -7  -5 -3  -1
            // Inorder:  [-7, -6, -5, -4, -3, -2, -1]
            // Postorder: [-7, -5, -6, -3, -1, -2, -4]

            // Arrange
            int[] inorder = { -7, -6, -5, -4, -3, -2, -1 };
            int[] postorder = { -7, -5, -6, -3, -1, -2, -4 };

            // Act
            var result = solution.BuildTree(inorder, postorder);

            // Assert
            AssertTreeStructure(result, inorder, postorder, solutionName);
            Assert.AreEqual(-4, result.val, $"Failed for {solutionName}");
        }

        #endregion

        #region Complex Real-World Scenarios

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void BuildTree_ComplexTree1_ReturnsCorrectTree(IConstructBinaryTreeFromInOrderAndPostOrderTraversal_106 solution, string solutionName)
        {
            // Tree:            100
            //               /      \
            //             50        150
            //            /  \      /   \
            //          25   75   125   175
            //         /    /  \       /   \
            //       10    60  80    160   190
            // Inorder:  [10, 25, 50, 60, 75, 80, 100, 125, 150, 160, 175, 190]
            // Postorder: [10, 25, 60, 80, 75, 50, 125, 160, 190, 175, 150, 100]

            // Arrange
            int[] inorder = { 10, 25, 50, 60, 75, 80, 100, 125, 150, 160, 175, 190 };
            int[] postorder = { 10, 25, 60, 80, 75, 50, 125, 160, 190, 175, 150, 100 };

            // Act
            var result = solution.BuildTree(inorder, postorder);

            // Assert
            AssertTreeStructure(result, inorder, postorder, solutionName);
            Assert.AreEqual(12, CountNodes(result), $"Node count for {solutionName}");
            Assert.AreEqual(100, result.val, $"Root value for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void BuildTree_ComplexTree2_ReturnsCorrectTree(IConstructBinaryTreeFromInOrderAndPostOrderTraversal_106 solution, string solutionName)
        {
            // Tree with mixed structure
            //              5
            //            /   \
            //           3     8
            //          / \   / \
            //         2   4 7   9
            //        /     /     \
            //       1     6      10
            // Inorder:  [1, 2, 3, 4, 5, 6, 7, 8, 9, 10]
            // Postorder: [1, 2, 4, 3, 6, 7, 10, 9, 8, 5]

            // Arrange
            int[] inorder = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int[] postorder = { 1, 2, 4, 3, 6, 7, 10, 9, 8, 5 };

            // Act
            var result = solution.BuildTree(inorder, postorder);

            // Assert
            AssertTreeStructure(result, inorder, postorder, solutionName);
            Assert.AreEqual(10, CountNodes(result), $"Node count for {solutionName}");
        }

        #endregion

        #region Sparse Trees

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void BuildTree_SparseTree1_ReturnsCorrectTree(IConstructBinaryTreeFromInOrderAndPostOrderTraversal_106 solution, string solutionName)
        {
            // Tree:       10
            //            /    \
            //           5      15
            //            \       \
            //             7      20
            // Inorder:  [5, 7, 10, 15, 20]
            // Postorder: [7, 5, 20, 15, 10]

            // Arrange
            int[] inorder = { 5, 7, 10, 15, 20 };
            int[] postorder = { 7, 5, 20, 15, 10 };

            // Act
            var result = solution.BuildTree(inorder, postorder);

            // Assert
            AssertTreeStructure(result, inorder, postorder, solutionName);
            Assert.AreEqual(5, CountNodes(result), $"Node count for {solutionName}");
            Assert.IsNull(result.left.left, $"Failed for {solutionName}");
            Assert.IsNull(result.right.left, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void BuildTree_SparseTree2_ReturnsCorrectTree(IConstructBinaryTreeFromInOrderAndPostOrderTraversal_106 solution, string solutionName)
        {
            // Tree:       10
            //            /    \
            //           5      15
            //          /       /
            //         3      12
            // Inorder:  [3, 5, 10, 12, 15]
            // Postorder: [3, 5, 12, 15, 10]

            // Arrange
            int[] inorder = { 3, 5, 10, 12, 15 };
            int[] postorder = { 3, 5, 12, 15, 10 };

            // Act
            var result = solution.BuildTree(inorder, postorder);

            // Assert
            AssertTreeStructure(result, inorder, postorder, solutionName);
            Assert.AreEqual(5, CountNodes(result), $"Node count for {solutionName}");
        }

        #endregion

        #region Boundary Cases

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void BuildTree_MaxIntValue_ReturnsCorrectTree(IConstructBinaryTreeFromInOrderAndPostOrderTraversal_106 solution, string solutionName)
        {
            // Tree with int.MaxValue
            // Inorder:  [int.MinValue, 0, int.MaxValue]
            // Postorder: [int.MinValue, int.MaxValue, 0]

            // Arrange
            int[] inorder = { int.MinValue, 0, int.MaxValue };
            int[] postorder = { int.MinValue, int.MaxValue, 0 };

            // Act
            var result = solution.BuildTree(inorder, postorder);

            // Assert
            AssertTreeStructure(result, inorder, postorder, solutionName);
            Assert.AreEqual(0, result.val, $"Failed for {solutionName}");
            Assert.AreEqual(int.MinValue, result.left.val, $"Failed for {solutionName}");
            Assert.AreEqual(int.MaxValue, result.right.val, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void BuildTree_LargeBalancedTree_ReturnsCorrectTree(IConstructBinaryTreeFromInOrderAndPostOrderTraversal_106 solution, string solutionName)
        {
            // Large balanced tree (31 nodes)
            // Inorder:  [3, 6, 9, 12, 15, 18, 21, 25, 28, 31, 34, 37, 40, 43, 46, 50, 53, 56, 59, 62, 65, 68, 71, 75, 78, 81, 84, 87, 90, 93, 96]
            // Postorder: [3, 9, 6, 15, 21, 18, 12, 28, 34, 31, 40, 46, 43, 37, 25, 53, 59, 56, 65, 71, 68, 62, 78, 84, 81, 90, 96, 93, 87, 75, 50]

            // Arrange
            int[] inorder = { 3, 6, 9, 12, 15, 18, 21, 25, 28, 31, 34, 37, 40, 43, 46, 50, 53, 56, 59, 62, 65, 68, 71, 75, 78, 81, 84, 87, 90, 93, 96 };
            int[] postorder = { 3, 9, 6, 15, 21, 18, 12, 28, 34, 31, 40, 46, 43, 37, 25, 53, 59, 56, 65, 71, 68, 62, 78, 84, 81, 90, 96, 93, 87, 75, 50 };

            // Act
            var result = solution.BuildTree(inorder, postorder);

            // Assert
            AssertTreeStructure(result, inorder, postorder, solutionName);
            Assert.AreEqual(31, CountNodes(result), $"Node count for {solutionName}");
            Assert.AreEqual(50, result.val, $"Root value for {solutionName}");
        }

        #endregion

        #region Property-Based Tests

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void BuildTree_VerifyPostorderProperty_ReturnsCorrectTree(IConstructBinaryTreeFromInOrderAndPostOrderTraversal_106 solution, string solutionName)
        {
            // Postorder always visits left subtree, then right subtree, then root (root is LAST)

            // Arrange
            int[] inorder = { 3, 5, 7, 10, 12, 15, 20 };
            int[] postorder = { 3, 7, 5, 12, 20, 15, 10 };

            // Act
            var result = solution.BuildTree(inorder, postorder);

            // Assert
            var actualPostorder = PostorderTraversal(result);
            Assert.AreEqual(postorder[postorder.Length - 1], actualPostorder[actualPostorder.Count - 1],
                $"Last element in postorder should be root for {solutionName}");
            CollectionAssert.AreEqual(postorder, actualPostorder.ToArray(),
                $"Postorder property violated for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void BuildTree_VerifyInorderProperty_ReturnsCorrectTree(IConstructBinaryTreeFromInOrderAndPostOrderTraversal_106 solution, string solutionName)
        {
            // Inorder visits left subtree, then root, then right subtree

            // Arrange
            int[] inorder = { 3, 5, 7, 10, 12, 15, 20 };
            int[] postorder = { 3, 7, 5, 12, 20, 15, 10 };

            // Act
            var result = solution.BuildTree(inorder, postorder);

            // Assert
            var actualInorder = InorderTraversal(result);
            CollectionAssert.AreEqual(inorder, actualInorder.ToArray(),
                $"Inorder property violated for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void BuildTree_NodeCountMatchesArrayLength_ReturnsCorrectTree(IConstructBinaryTreeFromInOrderAndPostOrderTraversal_106 solution, string solutionName)
        {
            // The number of nodes in the tree should match array length

            // Arrange
            int[] inorder = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
            int[] postorder = { 1, 3, 2, 5, 7, 6, 4, 9, 11, 10, 13, 15, 14, 12, 8 };

            // Act
            var result = solution.BuildTree(inorder, postorder);

            // Assert
            Assert.AreEqual(inorder.Length, CountNodes(result),
                $"Node count should match array length for {solutionName}");
        }

        #endregion

        #region Comparison with LC 105 (Preorder+Inorder)

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void BuildTree_CompareWithPreorderVersion_SameInorder_DifferentTraversalOrder(IConstructBinaryTreeFromInOrderAndPostOrderTraversal_106 solution, string solutionName)
        {
            // For the same tree structure:
            // Inorder is same for both LC 105 and LC 106
            // Preorder: root first (LC 105)
            // Postorder: root last (LC 106)
            //
            // Tree:        4
            //            /   \
            //           2     6
            //          / \   / \
            //         1   3 5   7

            // Arrange
            int[] inorder = { 1, 2, 3, 4, 5, 6, 7 };
            int[] postorder = { 1, 3, 2, 5, 7, 6, 4 }; // Root (4) is LAST
            // For comparison: preorder would be [4, 2, 1, 3, 6, 5, 7] (Root is FIRST)

            // Act
            var result = solution.BuildTree(inorder, postorder);

            // Assert
            AssertTreeStructure(result, inorder, postorder, solutionName);
            var actualPostorder = PostorderTraversal(result);
            Assert.AreEqual(4, actualPostorder[actualPostorder.Count - 1], 
                $"Root should be last in postorder for {solutionName}");
        }

        #endregion

        #region ZigZag Pattern

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void BuildTree_ZigZagPattern_ReturnsCorrectTree(IConstructBinaryTreeFromInOrderAndPostOrderTraversal_106 solution, string solutionName)
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
            // Inorder:  [1, 3, 5, 4, 2]
            // Postorder: [5, 4, 3, 2, 1]

            // Arrange
            int[] inorder = { 1, 3, 5, 4, 2 };
            int[] postorder = { 5, 4, 3, 2, 1 };

            // Act
            var result = solution.BuildTree(inorder, postorder);

            // Assert
            AssertTreeStructure(result, inorder, postorder, solutionName);
            Assert.AreEqual(5, CountNodes(result), $"Node count for {solutionName}");
        }

        #endregion
    }
}
