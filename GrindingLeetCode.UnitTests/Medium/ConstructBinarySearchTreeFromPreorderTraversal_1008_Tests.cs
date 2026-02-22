using LeetCodeProblems.CSharp.Tree;
using LeetCodeProblems.Interfaces.Medium;
using LeetCodeProblems.Shared;

namespace GrindingLeetCode.UnitTests.Medium
{
    [TestClass]
    public class ConstructBinarySearchTreeFromPreorderTraversal_1008_Tests
    {
        public static IEnumerable<object[]> GetImplementations()
        {
            yield return new object[] { new ConstructBinarySearchTreeFromPreorderTraversal_CSharp_1008(), "C# Implementation" };
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
        /// Performs inorder traversal and returns the sequence (should be sorted for BST)
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
        /// Verifies that the tree is a valid BST
        /// </summary>
        private bool IsBST(TreeNode root, int? minValue = null, int? maxValue = null)
        {
            if (root == null) return true;

            if (minValue.HasValue && root.val <= minValue.Value) return false;
            if (maxValue.HasValue && root.val >= maxValue.Value) return false;

            return IsBST(root.left, minValue, root.val) && IsBST(root.right, root.val, maxValue);
        }

        /// <summary>
        /// Verifies that the preorder traversal matches expected
        /// </summary>
        private void AssertTreeStructure(TreeNode root, int[] expectedPreorder, string solutionName)
        {
            var actualPreorder = PreorderTraversal(root);
            CollectionAssert.AreEqual(expectedPreorder, actualPreorder.ToArray(),
                $"Preorder mismatch for {solutionName}");

            // Verify BST property
            Assert.IsTrue(IsBST(root), $"Tree is not a valid BST for {solutionName}");

            // Verify inorder is sorted
            var inorder = InorderTraversal(root);
            var sortedInorder = new List<int>(inorder);
            sortedInorder.Sort();
            CollectionAssert.AreEqual(sortedInorder, inorder, 
                $"Inorder traversal is not sorted for {solutionName}");
        }

        /// <summary>
        /// Counts total nodes in the tree
        /// </summary>
        private int CountNodes(TreeNode root)
        {
            if (root == null) return 0;
            return 1 + CountNodes(root.left) + CountNodes(root.right);
        }

        #endregion

        #region LeetCode Examples

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void BstFromPreorder_Example1_ReturnsCorrectBST(IConstructBinarySearchTreeFromPreorderTraversal_1008 solution, string solutionName)
        {
            // Input: preorder = [8,5,1,7,10,12]
            // Output: [8,5,10,1,7,null,12]
            //       8
            //      / \
            //     5   10
            //    / \    \
            //   1   7   12

            // Arrange
            int[] preorder = { 8, 5, 1, 7, 10, 12 };

            // Act
            var result = solution.BstFromPreorder(preorder);

            // Assert
            Assert.IsNotNull(result, $"Result should not be null for {solutionName}");
            AssertTreeStructure(result, preorder, solutionName);
            Assert.AreEqual(8, result.val, $"Root value for {solutionName}");
            Assert.AreEqual(5, result.left.val, $"Left child value for {solutionName}");
            Assert.AreEqual(10, result.right.val, $"Right child value for {solutionName}");
            Assert.AreEqual(6, CountNodes(result), $"Node count for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void BstFromPreorder_Example2_SingleNode_ReturnsCorrectBST(IConstructBinarySearchTreeFromPreorderTraversal_1008 solution, string solutionName)
        {
            // Input: preorder = [1]
            // Output: [1]

            // Arrange
            int[] preorder = { 1 };

            // Act
            var result = solution.BstFromPreorder(preorder);

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
        public void BstFromPreorder_SingleNodeZero_ReturnsCorrectBST(IConstructBinarySearchTreeFromPreorderTraversal_1008 solution, string solutionName)
        {
            // Arrange
            int[] preorder = { 0 };

            // Act
            var result = solution.BstFromPreorder(preorder);

            // Assert
            Assert.IsNotNull(result, $"Failed for {solutionName}");
            Assert.AreEqual(0, result.val, $"Failed for {solutionName}");
            Assert.IsNull(result.left, $"Failed for {solutionName}");
            Assert.IsNull(result.right, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void BstFromPreorder_SingleNodeLarge_ReturnsCorrectBST(IConstructBinarySearchTreeFromPreorderTraversal_1008 solution, string solutionName)
        {
            // Arrange
            int[] preorder = { 1000 };

            // Act
            var result = solution.BstFromPreorder(preorder);

            // Assert
            Assert.IsNotNull(result, $"Failed for {solutionName}");
            Assert.AreEqual(1000, result.val, $"Failed for {solutionName}");
        }

        #endregion

        #region Two Node Trees

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void BstFromPreorder_TwoNodes_LeftChild_ReturnsCorrectBST(IConstructBinarySearchTreeFromPreorderTraversal_1008 solution, string solutionName)
        {
            // BST:  10
            //       /
            //      5
            // Preorder: [10, 5]

            // Arrange
            int[] preorder = { 10, 5 };

            // Act
            var result = solution.BstFromPreorder(preorder);

            // Assert
            AssertTreeStructure(result, preorder, solutionName);
            Assert.AreEqual(10, result.val, $"Failed for {solutionName}");
            Assert.AreEqual(5, result.left.val, $"Failed for {solutionName}");
            Assert.IsNull(result.right, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void BstFromPreorder_TwoNodes_RightChild_ReturnsCorrectBST(IConstructBinarySearchTreeFromPreorderTraversal_1008 solution, string solutionName)
        {
            // BST:  5
            //         \
            //         10
            // Preorder: [5, 10]

            // Arrange
            int[] preorder = { 5, 10 };

            // Act
            var result = solution.BstFromPreorder(preorder);

            // Assert
            AssertTreeStructure(result, preorder, solutionName);
            Assert.AreEqual(5, result.val, $"Failed for {solutionName}");
            Assert.IsNull(result.left, $"Failed for {solutionName}");
            Assert.AreEqual(10, result.right.val, $"Failed for {solutionName}");
        }

        #endregion

        #region Three Node Trees

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void BstFromPreorder_ThreeNodes_Balanced_ReturnsCorrectBST(IConstructBinarySearchTreeFromPreorderTraversal_1008 solution, string solutionName)
        {
            // BST:    10
            //        /  \
            //       5   15
            // Preorder: [10, 5, 15]

            // Arrange
            int[] preorder = { 10, 5, 15 };

            // Act
            var result = solution.BstFromPreorder(preorder);

            // Assert
            AssertTreeStructure(result, preorder, solutionName);
            Assert.AreEqual(10, result.val, $"Failed for {solutionName}");
            Assert.AreEqual(5, result.left.val, $"Failed for {solutionName}");
            Assert.AreEqual(15, result.right.val, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void BstFromPreorder_ThreeNodes_LeftSkewed_ReturnsCorrectBST(IConstructBinarySearchTreeFromPreorderTraversal_1008 solution, string solutionName)
        {
            // BST:     15
            //         /
            //        10
            //       /
            //      5
            // Preorder: [15, 10, 5]

            // Arrange
            int[] preorder = { 15, 10, 5 };

            // Act
            var result = solution.BstFromPreorder(preorder);

            // Assert
            AssertTreeStructure(result, preorder, solutionName);
            Assert.AreEqual(15, result.val, $"Failed for {solutionName}");
            Assert.AreEqual(10, result.left.val, $"Failed for {solutionName}");
            Assert.AreEqual(5, result.left.left.val, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void BstFromPreorder_ThreeNodes_RightSkewed_ReturnsCorrectBST(IConstructBinarySearchTreeFromPreorderTraversal_1008 solution, string solutionName)
        {
            // BST:  5
            //        \
            //        10
            //          \
            //          15
            // Preorder: [5, 10, 15]

            // Arrange
            int[] preorder = { 5, 10, 15 };

            // Act
            var result = solution.BstFromPreorder(preorder);

            // Assert
            AssertTreeStructure(result, preorder, solutionName);
            Assert.AreEqual(5, result.val, $"Failed for {solutionName}");
            Assert.AreEqual(10, result.right.val, $"Failed for {solutionName}");
            Assert.AreEqual(15, result.right.right.val, $"Failed for {solutionName}");
        }

        #endregion

        #region Perfect BSTs

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void BstFromPreorder_PerfectBST_7Nodes_ReturnsCorrectBST(IConstructBinarySearchTreeFromPreorderTraversal_1008 solution, string solutionName)
        {
            // BST:        50
            //           /    \
            //          30     70
            //         /  \   /  \
            //        20  40 60  80
            // Preorder: [50, 30, 20, 40, 70, 60, 80]

            // Arrange
            int[] preorder = { 50, 30, 20, 40, 70, 60, 80 };

            // Act
            var result = solution.BstFromPreorder(preorder);

            // Assert
            AssertTreeStructure(result, preorder, solutionName);
            Assert.AreEqual(7, CountNodes(result), $"Node count for {solutionName}");
            Assert.AreEqual(50, result.val, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void BstFromPreorder_PerfectBST_15Nodes_ReturnsCorrectBST(IConstructBinarySearchTreeFromPreorderTraversal_1008 solution, string solutionName)
        {
            // Perfect BST with 15 nodes
            // Preorder: [50, 30, 20, 10, 25, 40, 35, 45, 70, 60, 55, 65, 80, 75, 85]

            // Arrange
            int[] preorder = { 50, 30, 20, 10, 25, 40, 35, 45, 70, 60, 55, 65, 80, 75, 85 };

            // Act
            var result = solution.BstFromPreorder(preorder);

            // Assert
            AssertTreeStructure(result, preorder, solutionName);
            Assert.AreEqual(15, CountNodes(result), $"Node count for {solutionName}");
            Assert.AreEqual(50, result.val, $"Failed for {solutionName}");
        }

        #endregion

        #region Skewed BSTs

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void BstFromPreorder_LeftSkewed_5Nodes_ReturnsCorrectBST(IConstructBinarySearchTreeFromPreorderTraversal_1008 solution, string solutionName)
        {
            // BST:      50
            //          /
            //         40
            //        /
            //       30
            //      /
            //     20
            //    /
            //   10
            // Preorder: [50, 40, 30, 20, 10]

            // Arrange
            int[] preorder = { 50, 40, 30, 20, 10 };

            // Act
            var result = solution.BstFromPreorder(preorder);

            // Assert
            AssertTreeStructure(result, preorder, solutionName);
            Assert.AreEqual(5, CountNodes(result), $"Node count for {solutionName}");
            Assert.IsNull(result.right, $"Right should be null for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void BstFromPreorder_RightSkewed_5Nodes_ReturnsCorrectBST(IConstructBinarySearchTreeFromPreorderTraversal_1008 solution, string solutionName)
        {
            // BST:  10
            //         \
            //         20
            //           \
            //           30
            //             \
            //             40
            //               \
            //               50
            // Preorder: [10, 20, 30, 40, 50]

            // Arrange
            int[] preorder = { 10, 20, 30, 40, 50 };

            // Act
            var result = solution.BstFromPreorder(preorder);

            // Assert
            AssertTreeStructure(result, preorder, solutionName);
            Assert.AreEqual(5, CountNodes(result), $"Node count for {solutionName}");
            Assert.IsNull(result.left, $"Left should be null for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void BstFromPreorder_LeftSkewed_10Nodes_ReturnsCorrectBST(IConstructBinarySearchTreeFromPreorderTraversal_1008 solution, string solutionName)
        {
            // Deep left-skewed BST
            // Preorder: [100, 90, 80, 70, 60, 50, 40, 30, 20, 10]

            // Arrange
            int[] preorder = { 100, 90, 80, 70, 60, 50, 40, 30, 20, 10 };

            // Act
            var result = solution.BstFromPreorder(preorder);

            // Assert
            AssertTreeStructure(result, preorder, solutionName);
            Assert.AreEqual(10, CountNodes(result), $"Node count for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void BstFromPreorder_RightSkewed_10Nodes_ReturnsCorrectBST(IConstructBinarySearchTreeFromPreorderTraversal_1008 solution, string solutionName)
        {
            // Deep right-skewed BST
            // Preorder: [10, 20, 30, 40, 50, 60, 70, 80, 90, 100]

            // Arrange
            int[] preorder = { 10, 20, 30, 40, 50, 60, 70, 80, 90, 100 };

            // Act
            var result = solution.BstFromPreorder(preorder);

            // Assert
            AssertTreeStructure(result, preorder, solutionName);
            Assert.AreEqual(10, CountNodes(result), $"Node count for {solutionName}");
        }

        #endregion

        #region Asymmetric BSTs

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void BstFromPreorder_AsymmetricBST1_ReturnsCorrectBST(IConstructBinarySearchTreeFromPreorderTraversal_1008 solution, string solutionName)
        {
            // BST:            50
            //               /    \
            //             30      70
            //            /  \       \
            //          20   40      80
            //         /              \
            //        10              90
            // Preorder: [50, 30, 20, 10, 40, 70, 80, 90]

            // Arrange
            int[] preorder = { 50, 30, 20, 10, 40, 70, 80, 90 };

            // Act
            var result = solution.BstFromPreorder(preorder);

            // Assert
            AssertTreeStructure(result, preorder, solutionName);
            Assert.AreEqual(8, CountNodes(result), $"Node count for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void BstFromPreorder_AsymmetricBST2_ReturnsCorrectBST(IConstructBinarySearchTreeFromPreorderTraversal_1008 solution, string solutionName)
        {
            // BST:            100
            //               /     \
            //             50      150
            //            /       /    \
            //          25      125   175
            //         /  \           /  \
            //        10  40        160  190
            // Preorder: [100, 50, 25, 10, 40, 150, 125, 175, 160, 190]

            // Arrange
            int[] preorder = { 100, 50, 25, 10, 40, 150, 125, 175, 160, 190 };

            // Act
            var result = solution.BstFromPreorder(preorder);

            // Assert
            AssertTreeStructure(result, preorder, solutionName);
            Assert.AreEqual(10, CountNodes(result), $"Node count for {solutionName}");
        }

        #endregion

        #region Boundary Cases

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void BstFromPreorder_MinMaxValues_ReturnsCorrectBST(IConstructBinarySearchTreeFromPreorderTraversal_1008 solution, string solutionName)
        {
            // BST with boundary values (Note: LC 1008 constraint is 1 <= preorder[i] <= 1000)
            // Preorder: [500, 1, 1000]

            // Arrange
            int[] preorder = { 500, 1, 1000 };

            // Act
            var result = solution.BstFromPreorder(preorder);

            // Assert
            AssertTreeStructure(result, preorder, solutionName);
            Assert.AreEqual(500, result.val, $"Failed for {solutionName}");
            Assert.AreEqual(1, result.left.val, $"Failed for {solutionName}");
            Assert.AreEqual(1000, result.right.val, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void BstFromPreorder_LargeBalancedBST_ReturnsCorrectBST(IConstructBinarySearchTreeFromPreorderTraversal_1008 solution, string solutionName)
        {
            // Large balanced BST (31 nodes)
            // Preorder: [500, 250, 125, 62, 31, 93, 187, 156, 218, 375, 312, 281, 343, 437, 406, 468, 750, 625, 562, 531, 593, 687, 656, 718, 875, 812, 781, 843, 937, 906, 968]

            // Arrange
            int[] preorder = { 500, 250, 125, 62, 31, 93, 187, 156, 218, 375, 312, 281, 343, 437, 406, 468, 750, 625, 562, 531, 593, 687, 656, 718, 875, 812, 781, 843, 937, 906, 968 };

            // Act
            var result = solution.BstFromPreorder(preorder);

            // Assert
            AssertTreeStructure(result, preorder, solutionName);
            Assert.AreEqual(31, CountNodes(result), $"Node count for {solutionName}");
            Assert.AreEqual(500, result.val, $"Root value for {solutionName}");
        }

        #endregion

        #region Complex Real-World Scenarios

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void BstFromPreorder_ComplexBST1_ReturnsCorrectBST(IConstructBinarySearchTreeFromPreorderTraversal_1008 solution, string solutionName)
        {
            // BST:              500
            //                /       \
            //              250       750
            //             /   \     /   \
            //           125  375  625   875
            //          /    /       \     \
            //         50  300       700   950
            // Preorder: [500, 250, 125, 50, 375, 300, 750, 625, 700, 875, 950]

            // Arrange
            int[] preorder = { 500, 250, 125, 50, 375, 300, 750, 625, 700, 875, 950 };

            // Act
            var result = solution.BstFromPreorder(preorder);

            // Assert
            AssertTreeStructure(result, preorder, solutionName);
            Assert.AreEqual(11, CountNodes(result), $"Node count for {solutionName}");
            Assert.AreEqual(500, result.val, $"Root value for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void BstFromPreorder_ComplexBST2_ReturnsCorrectBST(IConstructBinarySearchTreeFromPreorderTraversal_1008 solution, string solutionName)
        {
            // Mixed structure BST
            // Preorder: [100, 50, 25, 10, 30, 75, 60, 90, 150, 125, 110, 140, 175, 160, 190]

            // Arrange
            int[] preorder = { 100, 50, 25, 10, 30, 75, 60, 90, 150, 125, 110, 140, 175, 160, 190 };

            // Act
            var result = solution.BstFromPreorder(preorder);

            // Assert
            AssertTreeStructure(result, preorder, solutionName);
            Assert.AreEqual(15, CountNodes(result), $"Node count for {solutionName}");
        }

        #endregion

        #region Property-Based Tests

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void BstFromPreorder_VerifyBSTProperty_AllNodes(IConstructBinarySearchTreeFromPreorderTraversal_1008 solution, string solutionName)
        {
            // BST property: left < root < right for all nodes
            // Preorder: [50, 30, 20, 40, 70, 60, 80]

            // Arrange
            int[] preorder = { 50, 30, 20, 40, 70, 60, 80 };

            // Act
            var result = solution.BstFromPreorder(preorder);

            // Assert
            Assert.IsTrue(IsBST(result), $"BST property violated for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void BstFromPreorder_VerifyPreorderProperty_ReturnsCorrectBST(IConstructBinarySearchTreeFromPreorderTraversal_1008 solution, string solutionName)
        {
            // Preorder always visits root first, then left subtree, then right subtree

            // Arrange
            int[] preorder = { 50, 30, 20, 40, 70, 60, 80 };

            // Act
            var result = solution.BstFromPreorder(preorder);

            // Assert
            var actualPreorder = PreorderTraversal(result);
            Assert.AreEqual(preorder[0], actualPreorder[0],
                $"First element in preorder should be root for {solutionName}");
            CollectionAssert.AreEqual(preorder, actualPreorder.ToArray(),
                $"Preorder property violated for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void BstFromPreorder_VerifyInorderIsSorted_ReturnsCorrectBST(IConstructBinarySearchTreeFromPreorderTraversal_1008 solution, string solutionName)
        {
            // Inorder traversal of BST should be sorted

            // Arrange
            int[] preorder = { 50, 30, 20, 40, 70, 60, 80 };

            // Act
            var result = solution.BstFromPreorder(preorder);

            // Assert
            var inorder = InorderTraversal(result);
            var sortedInorder = new List<int>(inorder);
            sortedInorder.Sort();
            CollectionAssert.AreEqual(sortedInorder, inorder,
                $"Inorder is not sorted for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void BstFromPreorder_NodeCountMatchesArrayLength_ReturnsCorrectBST(IConstructBinarySearchTreeFromPreorderTraversal_1008 solution, string solutionName)
        {
            // The number of nodes in the tree should match array length

            // Arrange
            int[] preorder = { 50, 30, 20, 10, 25, 40, 35, 45, 70, 60, 55, 65, 80, 75, 85 };

            // Act
            var result = solution.BstFromPreorder(preorder);

            // Assert
            Assert.AreEqual(preorder.Length, CountNodes(result),
                $"Node count should match array length for {solutionName}");
        }

        #endregion

        #region Sequential Values

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void BstFromPreorder_SequentialAscending_ReturnsCorrectBST(IConstructBinarySearchTreeFromPreorderTraversal_1008 solution, string solutionName)
        {
            // Sequential ascending values (right-skewed)
            // Preorder: [1, 2, 3, 4, 5, 6, 7, 8, 9, 10]

            // Arrange
            int[] preorder = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            // Act
            var result = solution.BstFromPreorder(preorder);

            // Assert
            AssertTreeStructure(result, preorder, solutionName);
            Assert.AreEqual(10, CountNodes(result), $"Node count for {solutionName}");
            Assert.IsNull(result.left, $"Should be right-skewed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void BstFromPreorder_SequentialDescending_ReturnsCorrectBST(IConstructBinarySearchTreeFromPreorderTraversal_1008 solution, string solutionName)
        {
            // Sequential descending values (left-skewed)
            // Preorder: [10, 9, 8, 7, 6, 5, 4, 3, 2, 1]

            // Arrange
            int[] preorder = { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 };

            // Act
            var result = solution.BstFromPreorder(preorder);

            // Assert
            AssertTreeStructure(result, preorder, solutionName);
            Assert.AreEqual(10, CountNodes(result), $"Node count for {solutionName}");
            Assert.IsNull(result.right, $"Should be left-skewed for {solutionName}");
        }

        #endregion

        #region Large Value Spreads

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void BstFromPreorder_LargeValueSpread_ReturnsCorrectBST(IConstructBinarySearchTreeFromPreorderTraversal_1008 solution, string solutionName)
        {
            // Large spread of values
            // Preorder: [500, 100, 10, 200, 900, 700, 999]

            // Arrange
            int[] preorder = { 500, 100, 10, 200, 900, 700, 999 };

            // Act
            var result = solution.BstFromPreorder(preorder);

            // Assert
            AssertTreeStructure(result, preorder, solutionName);
            Assert.AreEqual(7, CountNodes(result), $"Node count for {solutionName}");
        }

        #endregion

        #region Duplicate Prevention Tests

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void BstFromPreorder_NoDuplicates_AllUnique_ReturnsCorrectBST(IConstructBinarySearchTreeFromPreorderTraversal_1008 solution, string solutionName)
        {
            // Verify all values are unique (BST property)
            // Preorder: [50, 25, 75, 12, 37, 62, 87]

            // Arrange
            int[] preorder = { 50, 25, 75, 12, 37, 62, 87 };

            // Act
            var result = solution.BstFromPreorder(preorder);

            // Assert
            var inorder = InorderTraversal(result);
            var uniqueValues = new HashSet<int>(inorder);
            Assert.AreEqual(inorder.Count, uniqueValues.Count,
                $"Duplicate values found for {solutionName}");
        }

        #endregion
    }
}
