using LeetCodeProblems.CSharp.Tree;
using LeetCodeProblems.Interfaces.Medium;
using LeetCodeProblems.Shared;
using LeetCodeProblems.VisualBasic;

namespace GrindingLeetCode.UnitTests.Medium
{
    [TestClass]
    public class ConstructBinaryTreeFromPreorderAndInorderTraversal_105_Tests
    {
        public static IEnumerable<object[]> GetImplementations()
        {
            yield return new object[] { new ConstructBinaryTreeFromPreorderAndInorderTraversal_ThreadSafe_CSharp_105(), "C# Recursive" };
            yield return new object[] { new ConstructBinaryTreeFromPreorderAndInorderTraversal_LimitValue_CSharp_105(), "C# Recursive Five params" };
            yield return new object[] { new ConstructBinaryTreeFromPreorderAndInorderTraversal_HashMap_CSharp_105(), "C# Recursive + Hashmap" };
            yield return new object[] { new ConstructBinaryTreeFromPreorderAndInorderTraversal_IterativeHashMap_CSharp_105(), "C# Iterative + Hashmap" };

            yield return new object[] { new ConstructBinaryTreeFromPreorderAndInorderTraversal_LimitValue_VB_105(), "VB Recursive Five Params" };
            yield return new object[] { new ConstructBinaryTreeFromPreorderAndInorderTraversal_RecursiveThreadSafe_VB_105(), "VB Recursive SixParams" };
            yield return new object[] { new ConstructBinaryTreeFromPreorderAndInorderTraversal_IterativeHashmap_VB_105(), "VB Iterative + Hashmap" };
            yield return new object[] { new ConstructBinaryTreeFromPreorderAndInorderTraversal_RecursiveHashMap_VB_105(), "VB Recursive + Hashmap" };
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
        /// Verifies that the tree structure matches expected preorder and inorder traversals
        /// </summary>
        private void AssertTreeStructure(TreeNode root, int[] expectedPreorder, int[] expectedInorder, string solutionName)
        {
            var actualPreorder = PreorderTraversal(root);
            var actualInorder = InorderTraversal(root);

            CollectionAssert.AreEqual(expectedPreorder, actualPreorder.ToArray(), 
                $"Preorder mismatch for {solutionName}");
            CollectionAssert.AreEqual(expectedInorder, actualInorder.ToArray(), 
                $"Inorder mismatch for {solutionName}");
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
        public void BuildTree_Example1_ReturnsCorrectTree(IConstructBinaryTreeFromPreorderAndInorderTraversal_105 solution, string solutionName)
        {
            // Input: preorder = [3,9,20,15,7], inorder = [9,3,15,20,7]
            //      3
            //     / \
            //    9  20
            //      /  \
            //     15   7
            // Output: [3,9,20,null,null,15,7]

            // Arrange
            int[] preorder = { 3, 9, 20, 15, 7 };
            int[] inorder = { 9, 3, 15, 20, 7 };

            // Act
            var result = solution.BuildTree(preorder, inorder);

            // Assert
            Assert.IsNotNull(result, $"Result should not be null for {solutionName}");
            AssertTreeStructure(result, preorder, inorder, solutionName);
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
        public void BuildTree_Example2_SingleNode_ReturnsCorrectTree(IConstructBinaryTreeFromPreorderAndInorderTraversal_105 solution, string solutionName)
        {
            // Input: preorder = [-1], inorder = [-1]
            // Output: [-1]

            // Arrange
            int[] preorder = { -1 };
            int[] inorder = { -1 };

            // Act
            var result = solution.BuildTree(preorder, inorder);

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
        public void BuildTree_SingleNodePositive_ReturnsCorrectTree(IConstructBinaryTreeFromPreorderAndInorderTraversal_105 solution, string solutionName)
        {
            // Arrange
            int[] preorder = { 5 };
            int[] inorder = { 5 };

            // Act
            var result = solution.BuildTree(preorder, inorder);

            // Assert
            Assert.IsNotNull(result, $"Failed for {solutionName}");
            Assert.AreEqual(5, result.val, $"Failed for {solutionName}");
            Assert.IsNull(result.left, $"Failed for {solutionName}");
            Assert.IsNull(result.right, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void BuildTree_SingleNodeZero_ReturnsCorrectTree(IConstructBinaryTreeFromPreorderAndInorderTraversal_105 solution, string solutionName)
        {
            // Arrange
            int[] preorder = { 0 };
            int[] inorder = { 0 };

            // Act
            var result = solution.BuildTree(preorder, inorder);

            // Assert
            Assert.IsNotNull(result, $"Failed for {solutionName}");
            Assert.AreEqual(0, result.val, $"Failed for {solutionName}");
        }

        #endregion

        #region Two Node Trees

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void BuildTree_TwoNodes_LeftChild_ReturnsCorrectTree(IConstructBinaryTreeFromPreorderAndInorderTraversal_105 solution, string solutionName)
        {
            // Tree:  2
            //       /
            //      1
            // Preorder: [2, 1], Inorder: [1, 2]

            // Arrange
            int[] preorder = { 2, 1 };
            int[] inorder = { 1, 2 };

            // Act
            var result = solution.BuildTree(preorder, inorder);

            // Assert
            AssertTreeStructure(result, preorder, inorder, solutionName);
            Assert.AreEqual(2, result.val, $"Failed for {solutionName}");
            Assert.AreEqual(1, result.left.val, $"Failed for {solutionName}");
            Assert.IsNull(result.right, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void BuildTree_TwoNodes_RightChild_ReturnsCorrectTree(IConstructBinaryTreeFromPreorderAndInorderTraversal_105 solution, string solutionName)
        {
            // Tree:  1
            //         \
            //          2
            // Preorder: [1, 2], Inorder: [1, 2]

            // Arrange
            int[] preorder = { 1, 2 };
            int[] inorder = { 1, 2 };

            // Act
            var result = solution.BuildTree(preorder, inorder);

            // Assert
            AssertTreeStructure(result, preorder, inorder, solutionName);
            Assert.AreEqual(1, result.val, $"Failed for {solutionName}");
            Assert.IsNull(result.left, $"Failed for {solutionName}");
            Assert.AreEqual(2, result.right.val, $"Failed for {solutionName}");
        }

        #endregion

        #region Three Node Trees

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void BuildTree_ThreeNodes_Balanced_ReturnsCorrectTree(IConstructBinaryTreeFromPreorderAndInorderTraversal_105 solution, string solutionName)
        {
            // Tree:    2
            //         / \
            //        1   3
            // Preorder: [2, 1, 3], Inorder: [1, 2, 3]

            // Arrange
            int[] preorder = { 2, 1, 3 };
            int[] inorder = { 1, 2, 3 };

            // Act
            var result = solution.BuildTree(preorder, inorder);

            // Assert
            AssertTreeStructure(result, preorder, inorder, solutionName);
            Assert.AreEqual(2, result.val, $"Failed for {solutionName}");
            Assert.AreEqual(1, result.left.val, $"Failed for {solutionName}");
            Assert.AreEqual(3, result.right.val, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void BuildTree_ThreeNodes_LeftSkewed_ReturnsCorrectTree(IConstructBinaryTreeFromPreorderAndInorderTraversal_105 solution, string solutionName)
        {
            // Tree:      3
            //           /
            //          2
            //         /
            //        1
            // Preorder: [3, 2, 1], Inorder: [1, 2, 3]

            // Arrange
            int[] preorder = { 3, 2, 1 };
            int[] inorder = { 1, 2, 3 };

            // Act
            var result = solution.BuildTree(preorder, inorder);

            // Assert
            AssertTreeStructure(result, preorder, inorder, solutionName);
            Assert.AreEqual(3, result.val, $"Failed for {solutionName}");
            Assert.AreEqual(2, result.left.val, $"Failed for {solutionName}");
            Assert.AreEqual(1, result.left.left.val, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void BuildTree_ThreeNodes_RightSkewed_ReturnsCorrectTree(IConstructBinaryTreeFromPreorderAndInorderTraversal_105 solution, string solutionName)
        {
            // Tree:  1
            //         \
            //          2
            //           \
            //            3
            // Preorder: [1, 2, 3], Inorder: [1, 2, 3]

            // Arrange
            int[] preorder = { 1, 2, 3 };
            int[] inorder = { 1, 2, 3 };

            // Act
            var result = solution.BuildTree(preorder, inorder);

            // Assert
            AssertTreeStructure(result, preorder, inorder, solutionName);
            Assert.AreEqual(1, result.val, $"Failed for {solutionName}");
            Assert.AreEqual(2, result.right.val, $"Failed for {solutionName}");
            Assert.AreEqual(3, result.right.right.val, $"Failed for {solutionName}");
        }

        #endregion

        #region Perfect Binary Trees

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void BuildTree_PerfectTree_7Nodes_ReturnsCorrectTree(IConstructBinaryTreeFromPreorderAndInorderTraversal_105 solution, string solutionName)
        {
            // Tree:        4
            //            /   \
            //           2     6
            //          / \   / \
            //         1   3 5   7
            // Preorder: [4, 2, 1, 3, 6, 5, 7]
            // Inorder:  [1, 2, 3, 4, 5, 6, 7]

            // Arrange
            int[] preorder = { 4, 2, 1, 3, 6, 5, 7 };
            int[] inorder = { 1, 2, 3, 4, 5, 6, 7 };

            // Act
            var result = solution.BuildTree(preorder, inorder);

            // Assert
            AssertTreeStructure(result, preorder, inorder, solutionName);
            Assert.AreEqual(7, CountNodes(result), $"Node count for {solutionName}");
            Assert.AreEqual(4, result.val, $"Failed for {solutionName}");
            Assert.AreEqual(2, result.left.val, $"Failed for {solutionName}");
            Assert.AreEqual(6, result.right.val, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void BuildTree_PerfectTree_15Nodes_ReturnsCorrectTree(IConstructBinaryTreeFromPreorderAndInorderTraversal_105 solution, string solutionName)
        {
            // Tree:               8
            //                /       \
            //               4         12
            //             /   \      /   \
            //            2     6    10    14
            //           / \   / \   / \   / \
            //          1   3 5   7 9  11 13 15
            // Preorder: [8,4,2,1,3,6,5,7,12,10,9,11,14,13,15]
            // Inorder:  [1,2,3,4,5,6,7,8,9,10,11,12,13,14,15]

            // Arrange
            int[] preorder = { 8, 4, 2, 1, 3, 6, 5, 7, 12, 10, 9, 11, 14, 13, 15 };
            int[] inorder = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };

            // Act
            var result = solution.BuildTree(preorder, inorder);

            // Assert
            AssertTreeStructure(result, preorder, inorder, solutionName);
            Assert.AreEqual(15, CountNodes(result), $"Node count for {solutionName}");
            Assert.AreEqual(8, result.val, $"Failed for {solutionName}");
        }

        #endregion

        #region Left Skewed Trees

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void BuildTree_LeftSkewed_5Nodes_ReturnsCorrectTree(IConstructBinaryTreeFromPreorderAndInorderTraversal_105 solution, string solutionName)
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
            // Preorder: [5, 4, 3, 2, 1]
            // Inorder:  [1, 2, 3, 4, 5]

            // Arrange
            int[] preorder = { 5, 4, 3, 2, 1 };
            int[] inorder = { 1, 2, 3, 4, 5 };

            // Act
            var result = solution.BuildTree(preorder, inorder);

            // Assert
            AssertTreeStructure(result, preorder, inorder, solutionName);
            Assert.AreEqual(5, CountNodes(result), $"Node count for {solutionName}");
            Assert.IsNull(result.right, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void BuildTree_LeftSkewed_10Nodes_ReturnsCorrectTree(IConstructBinaryTreeFromPreorderAndInorderTraversal_105 solution, string solutionName)
        {
            // Deep left-skewed tree
            // Preorder: [10, 9, 8, 7, 6, 5, 4, 3, 2, 1]
            // Inorder:  [1, 2, 3, 4, 5, 6, 7, 8, 9, 10]

            // Arrange
            int[] preorder = { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 };
            int[] inorder = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            // Act
            var result = solution.BuildTree(preorder, inorder);

            // Assert
            AssertTreeStructure(result, preorder, inorder, solutionName);
            Assert.AreEqual(10, CountNodes(result), $"Node count for {solutionName}");
        }

        #endregion

        #region Right Skewed Trees

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void BuildTree_RightSkewed_5Nodes_ReturnsCorrectTree(IConstructBinaryTreeFromPreorderAndInorderTraversal_105 solution, string solutionName)
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
            // Preorder: [1, 2, 3, 4, 5]
            // Inorder:  [1, 2, 3, 4, 5]

            // Arrange
            int[] preorder = { 1, 2, 3, 4, 5 };
            int[] inorder = { 1, 2, 3, 4, 5 };

            // Act
            var result = solution.BuildTree(preorder, inorder);

            // Assert
            AssertTreeStructure(result, preorder, inorder, solutionName);
            Assert.AreEqual(5, CountNodes(result), $"Node count for {solutionName}");
            Assert.IsNull(result.left, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void BuildTree_RightSkewed_10Nodes_ReturnsCorrectTree(IConstructBinaryTreeFromPreorderAndInorderTraversal_105 solution, string solutionName)
        {
            // Deep right-skewed tree
            // Preorder: [1, 2, 3, 4, 5, 6, 7, 8, 9, 10]
            // Inorder:  [1, 2, 3, 4, 5, 6, 7, 8, 9, 10]

            // Arrange
            int[] preorder = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int[] inorder = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            // Act
            var result = solution.BuildTree(preorder, inorder);

            // Assert
            AssertTreeStructure(result, preorder, inorder, solutionName);
            Assert.AreEqual(10, CountNodes(result), $"Node count for {solutionName}");
        }

        #endregion

        #region Asymmetric Trees

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void BuildTree_AsymmetricTree1_ReturnsCorrectTree(IConstructBinaryTreeFromPreorderAndInorderTraversal_105 solution, string solutionName)
        {
            // Tree:           10
            //               /    \
            //              5      15
            //            /   \      \
            //           3     7     20
            //          / \
            //         1   4
            // Preorder: [10, 5, 3, 1, 4, 7, 15, 20]
            // Inorder:  [1, 3, 4, 5, 7, 10, 15, 20]

            // Arrange
            int[] preorder = { 10, 5, 3, 1, 4, 7, 15, 20 };
            int[] inorder = { 1, 3, 4, 5, 7, 10, 15, 20 };

            // Act
            var result = solution.BuildTree(preorder, inorder);

            // Assert
            AssertTreeStructure(result, preorder, inorder, solutionName);
            Assert.AreEqual(8, CountNodes(result), $"Node count for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void BuildTree_AsymmetricTree2_ReturnsCorrectTree(IConstructBinaryTreeFromPreorderAndInorderTraversal_105 solution, string solutionName)
        {
            // Tree:        20
            //            /    \
            //          10      30
            //         /      /    \
            //        5      25    35
            //       / \            \
            //      3   7           40
            // Preorder: [20, 10, 5, 3, 7, 30, 25, 35, 40]
            // Inorder:  [3, 5, 7, 10, 20, 25, 30, 35, 40]

            // Arrange
            int[] preorder = { 20, 10, 5, 3, 7, 30, 25, 35, 40 };
            int[] inorder = { 3, 5, 7, 10, 20, 25, 30, 35, 40 };

            // Act
            var result = solution.BuildTree(preorder, inorder);

            // Assert
            AssertTreeStructure(result, preorder, inorder, solutionName);
            Assert.AreEqual(9, CountNodes(result), $"Node count for {solutionName}");
        }

        #endregion

        #region Edge Cases - Negative Values

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void BuildTree_NegativeValues_ReturnsCorrectTree(IConstructBinaryTreeFromPreorderAndInorderTraversal_105 solution, string solutionName)
        {
            // Tree:       0
            //           /   \
            //         -5     5
            //         / \   / \
            //       -8  -3 3   8
            // Preorder: [0, -5, -8, -3, 5, 3, 8]
            // Inorder:  [-8, -5, -3, 0, 3, 5, 8]

            // Arrange
            int[] preorder = { 0, -5, -8, -3, 5, 3, 8 };
            int[] inorder = { -8, -5, -3, 0, 3, 5, 8 };

            // Act
            var result = solution.BuildTree(preorder, inorder);

            // Assert
            AssertTreeStructure(result, preorder, inorder, solutionName);
            Assert.AreEqual(0, result.val, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void BuildTree_AllNegativeValues_ReturnsCorrectTree(IConstructBinaryTreeFromPreorderAndInorderTraversal_105 solution, string solutionName)
        {
            // Tree:       -4
            //           /    \
            //         -6     -2
            //         / \    / \
            //       -7  -5 -3  -1
            // Preorder: [-4, -6, -7, -5, -2, -3, -1]
            // Inorder:  [-7, -6, -5, -4, -3, -2, -1]

            // Arrange
            int[] preorder = { -4, -6, -7, -5, -2, -3, -1 };
            int[] inorder = { -7, -6, -5, -4, -3, -2, -1 };

            // Act
            var result = solution.BuildTree(preorder, inorder);

            // Assert
            AssertTreeStructure(result, preorder, inorder, solutionName);
            Assert.AreEqual(-4, result.val, $"Failed for {solutionName}");
        }

        #endregion

        #region Edge Cases - Duplicate Values (Not Allowed but Testing Behavior)

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void BuildTree_UniqueValues_LargeTree_ReturnsCorrectTree(IConstructBinaryTreeFromPreorderAndInorderTraversal_105 solution, string solutionName)
        {
            // Large tree with unique values
            // Preorder: [50, 25, 12, 6, 18, 37, 31, 43, 75, 62, 87]
            // Inorder:  [6, 12, 18, 25, 31, 37, 43, 50, 62, 75, 87]

            // Arrange
            int[] preorder = { 50, 25, 12, 6, 18, 37, 31, 43, 75, 62, 87 };
            int[] inorder = { 6, 12, 18, 25, 31, 37, 43, 50, 62, 75, 87 };

            // Act
            var result = solution.BuildTree(preorder, inorder);

            // Assert
            AssertTreeStructure(result, preorder, inorder, solutionName);
            Assert.AreEqual(11, CountNodes(result), $"Node count for {solutionName}");
        }

        #endregion

        #region Complex Real-World Scenarios

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void BuildTree_ComplexTree1_ReturnsCorrectTree(IConstructBinaryTreeFromPreorderAndInorderTraversal_105 solution, string solutionName)
        {
            // Tree:            100
            //               /      \
            //             50        150
            //            /  \      /   \
            //          25   75   125   175
            //         /    /  \       /   \
            //       10    60  80    160   190
            // Preorder: [100, 50, 25, 10, 75, 60, 80, 150, 125, 175, 160, 190]
            // Inorder:  [10, 25, 50, 60, 75, 80, 100, 125, 150, 160, 175, 190]

            // Arrange
            int[] preorder = { 100, 50, 25, 10, 75, 60, 80, 150, 125, 175, 160, 190 };
            int[] inorder = { 10, 25, 50, 60, 75, 80, 100, 125, 150, 160, 175, 190 };

            // Act
            var result = solution.BuildTree(preorder, inorder);

            // Assert
            AssertTreeStructure(result, preorder, inorder, solutionName);
            Assert.AreEqual(12, CountNodes(result), $"Node count for {solutionName}");
            Assert.AreEqual(100, result.val, $"Root value for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void BuildTree_ComplexTree2_ReturnsCorrectTree(IConstructBinaryTreeFromPreorderAndInorderTraversal_105 solution, string solutionName)
        {
            // Tree with mixed structure
            // Preorder: [5, 3, 2, 1, 4, 8, 7, 6, 10, 9]
            // Inorder:  [1, 2, 3, 4, 5, 6, 7, 8, 9, 10]

            // Arrange
            int[] preorder = { 5, 3, 2, 1, 4, 8, 7, 6, 10, 9 };
            int[] inorder = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            // Act
            var result = solution.BuildTree(preorder, inorder);

            // Assert
            AssertTreeStructure(result, preorder, inorder, solutionName);
            Assert.AreEqual(10, CountNodes(result), $"Node count for {solutionName}");
        }

        #endregion

        #region Sparse Trees

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void BuildTree_SparseTree1_ReturnsCorrectTree(IConstructBinaryTreeFromPreorderAndInorderTraversal_105 solution, string solutionName)
        {
            // Tree:       10
            //            /    \
            //           5      15
            //            \       \
            //             7      20
            // Preorder: [10, 5, 7, 15, 20]
            // Inorder:  [5, 7, 10, 15, 20]

            // Arrange
            int[] preorder = { 10, 5, 7, 15, 20 };
            int[] inorder = { 5, 7, 10, 15, 20 };

            // Act
            var result = solution.BuildTree(preorder, inorder);

            // Assert
            AssertTreeStructure(result, preorder, inorder, solutionName);
            Assert.AreEqual(5, CountNodes(result), $"Node count for {solutionName}");
            Assert.IsNull(result.left.left, $"Failed for {solutionName}");
            Assert.IsNull(result.right.left, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void BuildTree_SparseTree2_ReturnsCorrectTree(IConstructBinaryTreeFromPreorderAndInorderTraversal_105 solution, string solutionName)
        {
            // Tree:       10
            //            /    \
            //           5      15
            //          /       /
            //         3      12
            // Preorder: [10, 5, 3, 15, 12]
            // Inorder:  [3, 5, 10, 12, 15]

            // Arrange
            int[] preorder = { 10, 5, 3, 15, 12 };
            int[] inorder = { 3, 5, 10, 12, 15 };

            // Act
            var result = solution.BuildTree(preorder, inorder);

            // Assert
            AssertTreeStructure(result, preorder, inorder, solutionName);
            Assert.AreEqual(5, CountNodes(result), $"Node count for {solutionName}");
        }

        #endregion

        #region Boundary Cases

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void BuildTree_MaxIntValue_ReturnsCorrectTree(IConstructBinaryTreeFromPreorderAndInorderTraversal_105 solution, string solutionName)
        {
            // Tree with int.MaxValue
            // Preorder: [0, int.MinValue, int.MaxValue]
            // Inorder:  [int.MinValue, 0, int.MaxValue]

            // Arrange
            int[] preorder = { 0, int.MinValue, int.MaxValue };
            int[] inorder = { int.MinValue, 0, int.MaxValue };

            // Act
            var result = solution.BuildTree(preorder, inorder);

            // Assert
            AssertTreeStructure(result, preorder, inorder, solutionName);
            Assert.AreEqual(0, result.val, $"Failed for {solutionName}");
            Assert.AreEqual(int.MinValue, result.left.val, $"Failed for {solutionName}");
            Assert.AreEqual(int.MaxValue, result.right.val, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void BuildTree_LargeBalancedTree_ReturnsCorrectTree(IConstructBinaryTreeFromPreorderAndInorderTraversal_105 solution, string solutionName)
        {
            // Large balanced tree (31 nodes)
            // Preorder: [50, 25, 12, 6, 3, 9, 18, 15, 21, 37, 31, 28, 34, 43, 40, 46, 75, 62, 56, 53, 59, 68, 65, 71, 87, 81, 78, 84, 93, 90, 96]
            // Inorder:  [3, 6, 9, 12, 15, 18, 21, 25, 28, 31, 34, 37, 40, 43, 46, 50, 53, 56, 59, 62, 65, 68, 71, 75, 78, 81, 84, 87, 90, 93, 96]

            // Arrange
            int[] preorder = { 50, 25, 12, 6, 3, 9, 18, 15, 21, 37, 31, 28, 34, 43, 40, 46, 75, 62, 56, 53, 59, 68, 65, 71, 87, 81, 78, 84, 93, 90, 96 };
            int[] inorder = { 3, 6, 9, 12, 15, 18, 21, 25, 28, 31, 34, 37, 40, 43, 46, 50, 53, 56, 59, 62, 65, 68, 71, 75, 78, 81, 84, 87, 90, 93, 96 };

            // Act
            var result = solution.BuildTree(preorder, inorder);

            // Assert
            AssertTreeStructure(result, preorder, inorder, solutionName);
            Assert.AreEqual(31, CountNodes(result), $"Node count for {solutionName}");
            Assert.AreEqual(50, result.val, $"Root value for {solutionName}");
        }

        #endregion

        #region Property-Based Tests

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void BuildTree_VerifyPreorderProperty_ReturnsCorrectTree(IConstructBinaryTreeFromPreorderAndInorderTraversal_105 solution, string solutionName)
        {
            // Preorder always visits root first, then left subtree, then right subtree

            // Arrange
            int[] preorder = { 10, 5, 3, 7, 15, 12, 20 };
            int[] inorder = { 3, 5, 7, 10, 12, 15, 20 };

            // Act
            var result = solution.BuildTree(preorder, inorder);

            // Assert
            var actualPreorder = PreorderTraversal(result);
            Assert.AreEqual(preorder[0], actualPreorder[0], 
                $"First element in preorder should be root for {solutionName}");
            CollectionAssert.AreEqual(preorder, actualPreorder.ToArray(), 
                $"Preorder property violated for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void BuildTree_VerifyInorderProperty_ReturnsCorrectTree(IConstructBinaryTreeFromPreorderAndInorderTraversal_105 solution, string solutionName)
        {
            // Inorder visits left subtree, then root, then right subtree

            // Arrange
            int[] preorder = { 10, 5, 3, 7, 15, 12, 20 };
            int[] inorder = { 3, 5, 7, 10, 12, 15, 20 };

            // Act
            var result = solution.BuildTree(preorder, inorder);

            // Assert
            var actualInorder = InorderTraversal(result);
            CollectionAssert.AreEqual(inorder, actualInorder.ToArray(), 
                $"Inorder property violated for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void BuildTree_NodeCountMatchesArrayLength_ReturnsCorrectTree(IConstructBinaryTreeFromPreorderAndInorderTraversal_105 solution, string solutionName)
        {
            // The number of nodes in the tree should match array length

            // Arrange
            int[] preorder = { 8, 4, 2, 1, 3, 6, 5, 7, 12, 10, 9, 11, 14, 13, 15 };
            int[] inorder = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };

            // Act
            var result = solution.BuildTree(preorder, inorder);

            // Assert
            Assert.AreEqual(preorder.Length, CountNodes(result), 
                $"Node count should match array length for {solutionName}");
        }

        #endregion
    }
}
