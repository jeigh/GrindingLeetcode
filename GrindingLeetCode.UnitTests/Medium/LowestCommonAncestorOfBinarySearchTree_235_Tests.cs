using LeetCodeProblems.CSharp.Tree;
using LeetCodeProblems.Interfaces.Medium;
using LeetCodeProblems.Shared;
using LeetCodeProblems.VisualBasic;

namespace GrindingLeetCode.UnitTests.Medium
{
    [TestClass]
    public class LowestCommonAncestorOfBinarySearchTree_235_Tests
    {
        public static IEnumerable<object[]> GetImplementations()
        {
            //yield return new object[] { new LowestCommonAncestorOfBinarySearchTree_Recursion_CSharp_235(), "C# Recursion" };
            yield return new object[] { new LowestCommonAncestorOfBinarySearchTree_Iterative_CSharp_235(), "C# Iterative" };
            //yield return new object[] { new LowestCommonAncestorOfBinarySearchTree_Recursion_VB_235(), "VB Recursion" };
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
        /// Finds a node with the given value in the tree
        /// </summary>
        private TreeNode FindNode(TreeNode root, int value)
        {
            if (root == null) return null;
            if (root.val == value) return root;

            TreeNode left = FindNode(root.left, value);
            if (left != null) return left;

            return FindNode(root.right, value);
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
        public void LowestCommonAncestor_Example1_Returns6(ILowestCommonAncestorOfBinarySearchTree_235 solution, string solutionName)
        {
            // Input: root = [6,2,8,0,4,7,9,null,null,3,5], p = 2, q = 8
            //         6
            //       /   \
            //      2     8
            //     / \   / \
            //    0   4 7   9
            //       / \
            //      3   5
            // Output: 6
            // Explanation: The LCA of nodes 2 and 8 is 6.

            // Arrange
            var root = CreateBST(new int?[] { 6, 2, 8, 0, 4, 7, 9, null, null, 3, 5 });
            var p = FindNode(root, 2);
            var q = FindNode(root, 8);

            // Act
            var result = solution.LowestCommonAncestor(root, p, q);

            // Assert
            Assert.IsNotNull(result, $"Failed for {solutionName}");
            Assert.AreEqual(6, result.val, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void LowestCommonAncestor_Example2_Returns2(ILowestCommonAncestorOfBinarySearchTree_235 solution, string solutionName)
        {
            // Input: root = [6,2,8,0,4,7,9,null,null,3,5], p = 2, q = 4
            //         6
            //       /   \
            //      2     8
            //     / \   / \
            //    0   4 7   9
            //       / \
            //      3   5
            // Output: 2
            // Explanation: The LCA of nodes 2 and 4 is 2, since a node can be a descendant of itself.

            // Arrange
            var root = CreateBST(new int?[] { 6, 2, 8, 0, 4, 7, 9, null, null, 3, 5 });
            var p = FindNode(root, 2);
            var q = FindNode(root, 4);

            // Act
            var result = solution.LowestCommonAncestor(root, p, q);

            // Assert
            Assert.IsNotNull(result, $"Failed for {solutionName}");
            Assert.AreEqual(2, result.val, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void LowestCommonAncestor_Example3_Returns2(ILowestCommonAncestorOfBinarySearchTree_235 solution, string solutionName)
        {
            // Input: root = [2,1], p = 2, q = 1
            //    2
            //   /
            //  1
            // Output: 2

            // Arrange
            var root = CreateBST(new int?[] { 2, 1 });
            var p = FindNode(root, 2);
            var q = FindNode(root, 1);

            // Act
            var result = solution.LowestCommonAncestor(root, p, q);

            // Assert
            Assert.IsNotNull(result, $"Failed for {solutionName}");
            Assert.AreEqual(2, result.val, $"Failed for {solutionName}");
        }

        #endregion

        #region Basic BST Cases

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void LowestCommonAncestor_ThreeNodeBST_RootIsLCA(ILowestCommonAncestorOfBinarySearchTree_235 solution, string solutionName)
        {
            // Input: root = [5,3,7], p = 3, q = 7
            //      5
            //     / \
            //    3   7
            // Output: 5

            // Arrange
            var root = CreateSimpleBST(5, left: 3, right: 7);
            var p = FindNode(root, 3);
            var q = FindNode(root, 7);

            // Act
            var result = solution.LowestCommonAncestor(root, p, q);

            // Assert
            Assert.IsNotNull(result, $"Failed for {solutionName}");
            Assert.AreEqual(5, result.val, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void LowestCommonAncestor_TwoNodeBST_LeftChild(ILowestCommonAncestorOfBinarySearchTree_235 solution, string solutionName)
        {
            // Input: root = [5,3], p = 5, q = 3
            //      5
            //     /
            //    3
            // Output: 5

            // Arrange
            var root = CreateSimpleBST(5, left: 3);
            var p = FindNode(root, 5);
            var q = FindNode(root, 3);

            // Act
            var result = solution.LowestCommonAncestor(root, p, q);

            // Assert
            Assert.IsNotNull(result, $"Failed for {solutionName}");
            Assert.AreEqual(5, result.val, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void LowestCommonAncestor_TwoNodeBST_RightChild(ILowestCommonAncestorOfBinarySearchTree_235 solution, string solutionName)
        {
            // Input: root = [5,null,7], p = 5, q = 7
            //      5
            //       \
            //        7
            // Output: 5

            // Arrange
            var root = CreateSimpleBST(5, right: 7);
            var p = FindNode(root, 5);
            var q = FindNode(root, 7);

            // Act
            var result = solution.LowestCommonAncestor(root, p, q);

            // Assert
            Assert.IsNotNull(result, $"Failed for {solutionName}");
            Assert.AreEqual(5, result.val, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void LowestCommonAncestor_SameNode_ReturnsNode(ILowestCommonAncestorOfBinarySearchTree_235 solution, string solutionName)
        {
            // Input: root = [5,3,7], p = 5, q = 5
            //      5
            //     / \
            //    3   7
            // Output: 5 (a node is an ancestor of itself)

            // Arrange
            var root = CreateSimpleBST(5, left: 3, right: 7);
            var p = FindNode(root, 5);
            var q = p; // Same node

            // Act
            var result = solution.LowestCommonAncestor(root, p, q);

            // Assert
            Assert.IsNotNull(result, $"Failed for {solutionName}");
            Assert.AreEqual(5, result.val, $"Failed for {solutionName}");
            Assert.AreSame(p, result, $"Should return the exact same node for {solutionName}");
        }

        #endregion

        #region Node is Ancestor of Other

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void LowestCommonAncestor_OneIsAncestorOfOther_ReturnsAncestor(ILowestCommonAncestorOfBinarySearchTree_235 solution, string solutionName)
        {
            // Input: root = [6,2,8,0,4], p = 2, q = 0
            //      6
            //     / \
            //    2   8
            //   / \
            //  0   4
            // Output: 2 (2 is ancestor of 0)

            // Arrange
            var root = CreateBST(new int?[] { 6, 2, 8, 0, 4 });
            var p = FindNode(root, 2);
            var q = FindNode(root, 0);

            // Act
            var result = solution.LowestCommonAncestor(root, p, q);

            // Assert
            Assert.IsNotNull(result, $"Failed for {solutionName}");
            Assert.AreEqual(2, result.val, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void LowestCommonAncestor_RightSubtree_OneIsAncestorOfOther(ILowestCommonAncestorOfBinarySearchTree_235 solution, string solutionName)
        {
            // Input: root = [6,2,8,null,null,7,9], p = 8, q = 9
            //      6
            //     / \
            //    2   8
            //       / \
            //      7   9
            // Output: 8 (8 is ancestor of 9)

            // Arrange
            var root = CreateBST(new int?[] { 6, 2, 8, null, null, 7, 9 });
            var p = FindNode(root, 8);
            var q = FindNode(root, 9);

            // Act
            var result = solution.LowestCommonAncestor(root, p, q);

            // Assert
            Assert.IsNotNull(result, $"Failed for {solutionName}");
            Assert.AreEqual(8, result.val, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void LowestCommonAncestor_DeepNesting_OneIsAncestorOfOther(ILowestCommonAncestorOfBinarySearchTree_235 solution, string solutionName)
        {
            // Input: root = [6,2,8,0,4,null,null,null,null,3,5], p = 2, q = 3
            //      6
            //     / \
            //    2   8
            //   / \
            //  0   4
            //     / \
            //    3   5
            // Output: 2 (2 is ancestor of 3)

            // Arrange
            var root = CreateBST(new int?[] { 6, 2, 8, 0, 4, null, null, null, null, 3, 5 });
            var p = FindNode(root, 2);
            var q = FindNode(root, 3);

            // Act
            var result = solution.LowestCommonAncestor(root, p, q);

            // Assert
            Assert.IsNotNull(result, $"Failed for {solutionName}");
            Assert.AreEqual(2, result.val, $"Failed for {solutionName}");
        }

        #endregion

        #region Both in Left Subtree

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void LowestCommonAncestor_BothInLeftSubtree_ReturnsLeftNode(ILowestCommonAncestorOfBinarySearchTree_235 solution, string solutionName)
        {
            // Input: root = [6,2,8,0,4,null,null,null,null,3,5], p = 0, q = 4
            //      6
            //     / \
            //    2   8
            //   / \
            //  0   4
            //     / \
            //    3   5
            // Output: 2

            // Arrange
            var root = CreateBST(new int?[] { 6, 2, 8, 0, 4, null, null, null, null, 3, 5 });
            var p = FindNode(root, 0);
            var q = FindNode(root, 4);

            // Act
            var result = solution.LowestCommonAncestor(root, p, q);

            // Assert
            Assert.IsNotNull(result, $"Failed for {solutionName}");
            Assert.AreEqual(2, result.val, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void LowestCommonAncestor_BothDeepInLeftSubtree(ILowestCommonAncestorOfBinarySearchTree_235 solution, string solutionName)
        {
            // Input: root = [6,2,8,0,4,null,null,null,null,3,5], p = 3, q = 5
            //      6
            //     / \
            //    2   8
            //   / \
            //  0   4
            //     / \
            //    3   5
            // Output: 4

            // Arrange
            var root = CreateBST(new int?[] { 6, 2, 8, 0, 4, null, null, null, null, 3, 5 });
            var p = FindNode(root, 3);
            var q = FindNode(root, 5);

            // Act
            var result = solution.LowestCommonAncestor(root, p, q);

            // Assert
            Assert.IsNotNull(result, $"Failed for {solutionName}");
            Assert.AreEqual(4, result.val, $"Failed for {solutionName}");
        }

        #endregion

        #region Both in Right Subtree

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void LowestCommonAncestor_BothInRightSubtree_ReturnsRightNode(ILowestCommonAncestorOfBinarySearchTree_235 solution, string solutionName)
        {
            // Input: root = [6,2,8,null,null,7,9], p = 7, q = 9
            //      6
            //     / \
            //    2   8
            //       / \
            //      7   9
            // Output: 8

            // Arrange
            var root = CreateBST(new int?[] { 6, 2, 8, null, null, 7, 9 });
            var p = FindNode(root, 7);
            var q = FindNode(root, 9);

            // Act
            var result = solution.LowestCommonAncestor(root, p, q);

            // Assert
            Assert.IsNotNull(result, $"Failed for {solutionName}");
            Assert.AreEqual(8, result.val, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void LowestCommonAncestor_BothDeepInRightSubtree(ILowestCommonAncestorOfBinarySearchTree_235 solution, string solutionName)
        {
            // Input: root = [10,5,15,null,null,12,20,null,null,null,null,18,25], p = 18, q = 25
            //       10
            //      /  \
            //     5    15
            //         /  \
            //        12   20
            //            /  \
            //           18   25
            // Output: 20

            // Arrange
            var root = CreateBST(new int?[] { 10, 5, 15, null, null, 12, 20, null, null, 18, 25 });
            var p = FindNode(root, 18);
            var q = FindNode(root, 25);

            // Act
            var result = solution.LowestCommonAncestor(root, p, q);

            // Assert
            Assert.IsNotNull(result, $"Failed for {solutionName}");
            Assert.AreEqual(20, result.val, $"Failed for {solutionName}");
        }

        #endregion

        #region Split at Root

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void LowestCommonAncestor_SplitAtRoot_ReturnsRoot(ILowestCommonAncestorOfBinarySearchTree_235 solution, string solutionName)
        {
            // Input: root = [10,5,15], p = 5, q = 15
            //      10
            //     /  \
            //    5    15
            // Output: 10

            // Arrange
            var root = CreateSimpleBST(10, left: 5, right: 15);
            var p = FindNode(root, 5);
            var q = FindNode(root, 15);

            // Act
            var result = solution.LowestCommonAncestor(root, p, q);

            // Assert
            Assert.IsNotNull(result, $"Failed for {solutionName}");
            Assert.AreEqual(10, result.val, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void LowestCommonAncestor_DeepNodesOnDifferentSides(ILowestCommonAncestorOfBinarySearchTree_235 solution, string solutionName)
        {
            // Input: root = [6,2,8,0,4,7,9,null,null,3,5], p = 0, q = 5
            //      6
            //     / \
            //    2   8
            //   / \ / \
            //  0  4 7  9
            //    / \
            //   3   5
            // Output: 2

            // Arrange
            var root = CreateBST(new int?[] { 6, 2, 8, 0, 4, 7, 9, null, null, 3, 5 });
            var p = FindNode(root, 0);
            var q = FindNode(root, 5);

            // Act
            var result = solution.LowestCommonAncestor(root, p, q);

            // Assert
            Assert.IsNotNull(result, $"Failed for {solutionName}");
            Assert.AreEqual(2, result.val, $"Failed for {solutionName}");
        }

        #endregion

        #region Skewed BST

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void LowestCommonAncestor_LeftSkewedBST(ILowestCommonAncestorOfBinarySearchTree_235 solution, string solutionName)
        {
            // Input: root = [5,4,null,3,null,2,null,1], p = 4, q = 1
            //      5
            //     /
            //    4
            //   /
            //  3
            // /
            //2
            ///
            //1
            // Output: 4

            // Arrange
            var root = CreateBST(new int?[] { 5, 4, null, 3, null, 2, null, 1 });
            var p = FindNode(root, 4);
            var q = FindNode(root, 1);

            // Act
            var result = solution.LowestCommonAncestor(root, p, q);

            // Assert
            Assert.IsNotNull(result, $"Failed for {solutionName}");
            Assert.AreEqual(4, result.val, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void LowestCommonAncestor_RightSkewedBST(ILowestCommonAncestorOfBinarySearchTree_235 solution, string solutionName)
        {
            // Input: root = [1,null,2,null,3,null,4,null,5], p = 2, q = 5
            // 1
            //  \
            //   2
            //    \
            //     3
            //      \
            //       4
            //        \
            //         5
            // Output: 2

            // Arrange
            var root = CreateBST(new int?[] { 1, null, 2, null, 3, null, 4, null, 5 });
            var p = FindNode(root, 2);
            var q = FindNode(root, 5);

            // Act
            var result = solution.LowestCommonAncestor(root, p, q);

            // Assert
            Assert.IsNotNull(result, $"Failed for {solutionName}");
            Assert.AreEqual(2, result.val, $"Failed for {solutionName}");
        }

        #endregion

        #region Large BST

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void LowestCommonAncestor_LargeBalancedBST(ILowestCommonAncestorOfBinarySearchTree_235 solution, string solutionName)
        {
            // Input: Balanced BST with 15 nodes
            //             8
            //          /     \
            //         4       12
            //        / \     /  \
            //       2   6   10   14
            //      / \ / \ / \  / \
            //     1  3 5 7 9 11 13 15
            // p = 1, q = 7
            // Output: 4

            // Arrange
            var root = CreateBST(new int?[] { 8, 4, 12, 2, 6, 10, 14, 1, 3, 5, 7, 9, 11, 13, 15 });
            var p = FindNode(root, 1);
            var q = FindNode(root, 7);

            // Act
            var result = solution.LowestCommonAncestor(root, p, q);

            // Assert
            Assert.IsNotNull(result, $"Failed for {solutionName}");
            Assert.AreEqual(4, result.val, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void LowestCommonAncestor_LargeBST_NodesOnDifferentSides(ILowestCommonAncestorOfBinarySearchTree_235 solution, string solutionName)
        {
            // Input: Same tree, p = 3, q = 13
            // Output: 8 (root)

            // Arrange
            var root = CreateBST(new int?[] { 8, 4, 12, 2, 6, 10, 14, 1, 3, 5, 7, 9, 11, 13, 15 });
            var p = FindNode(root, 3);
            var q = FindNode(root, 13);

            // Act
            var result = solution.LowestCommonAncestor(root, p, q);

            // Assert
            Assert.IsNotNull(result, $"Failed for {solutionName}");
            Assert.AreEqual(8, result.val, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void LowestCommonAncestor_LargeBST_BothInRightSubtree(ILowestCommonAncestorOfBinarySearchTree_235 solution, string solutionName)
        {
            // Input: Same tree, p = 9, q = 15
            // Output: 12

            // Arrange
            var root = CreateBST(new int?[] { 8, 4, 12, 2, 6, 10, 14, 1, 3, 5, 7, 9, 11, 13, 15 });
            var p = FindNode(root, 9);
            var q = FindNode(root, 15);

            // Act
            var result = solution.LowestCommonAncestor(root, p, q);

            // Assert
            Assert.IsNotNull(result, $"Failed for {solutionName}");
            Assert.AreEqual(12, result.val, $"Failed for {solutionName}");
        }

        #endregion

        #region Edge Cases with Values

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void LowestCommonAncestor_NegativeValues(ILowestCommonAncestorOfBinarySearchTree_235 solution, string solutionName)
        {
            // Input: root = [0,-2,2,-3,-1,1,3], p = -3, q = -1
            //        0
            //      /   \
            //    -2     2
            //    / \   / \
            //  -3  -1 1   3
            // Output: -2

            // Arrange
            var root = CreateBST(new int?[] { 0, -2, 2, -3, -1, 1, 3 });
            var p = FindNode(root, -3);
            var q = FindNode(root, -1);

            // Act
            var result = solution.LowestCommonAncestor(root, p, q);

            // Assert
            Assert.IsNotNull(result, $"Failed for {solutionName}");
            Assert.AreEqual(-2, result.val, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void LowestCommonAncestor_MixedSignValues(ILowestCommonAncestorOfBinarySearchTree_235 solution, string solutionName)
        {
            // Input: root = [0,-5,5], p = -5, q = 5
            //      0
            //     / \
            //   -5   5
            // Output: 0

            // Arrange
            var root = CreateSimpleBST(0, left: -5, right: 5);
            var p = FindNode(root, -5);
            var q = FindNode(root, 5);

            // Act
            var result = solution.LowestCommonAncestor(root, p, q);

            // Assert
            Assert.IsNotNull(result, $"Failed for {solutionName}");
            Assert.AreEqual(0, result.val, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void LowestCommonAncestor_LargeValues(ILowestCommonAncestorOfBinarySearchTree_235 solution, string solutionName)
        {
            // Input: root = [100,50,150,25,75,125,175], p = 25, q = 75
            //         100
            //        /   \
            //       50   150
            //      / \   / \
            //     25 75 125 175
            // Output: 50

            // Arrange
            var root = CreateBST(new int?[] { 100, 50, 150, 25, 75, 125, 175 });
            var p = FindNode(root, 25);
            var q = FindNode(root, 75);

            // Act
            var result = solution.LowestCommonAncestor(root, p, q);

            // Assert
            Assert.IsNotNull(result, $"Failed for {solutionName}");
            Assert.AreEqual(50, result.val, $"Failed for {solutionName}");
        }

        #endregion

        #region Consecutive Values

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void LowestCommonAncestor_ConsecutiveValues(ILowestCommonAncestorOfBinarySearchTree_235 solution, string solutionName)
        {
            // Input: root = [2,1,3], p = 1, q = 3
            //      2
            //     / \
            //    1   3
            // Output: 2

            // Arrange
            var root = CreateSimpleBST(2, left: 1, right: 3);
            var p = FindNode(root, 1);
            var q = FindNode(root, 3);

            // Act
            var result = solution.LowestCommonAncestor(root, p, q);

            // Assert
            Assert.IsNotNull(result, $"Failed for {solutionName}");
            Assert.AreEqual(2, result.val, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void LowestCommonAncestor_NonConsecutiveWithGaps(ILowestCommonAncestorOfBinarySearchTree_235 solution, string solutionName)
        {
            // Input: root = [10,5,15,2,7,12,20], p = 2, q = 7
            //       10
            //      /  \
            //     5    15
            //    / \  /  \
            //   2  7 12  20
            // Output: 5

            // Arrange
            var root = CreateBST(new int?[] { 10, 5, 15, 2, 7, 12, 20 });
            var p = FindNode(root, 2);
            var q = FindNode(root, 7);

            // Act
            var result = solution.LowestCommonAncestor(root, p, q);

            // Assert
            Assert.IsNotNull(result, $"Failed for {solutionName}");
            Assert.AreEqual(5, result.val, $"Failed for {solutionName}");
        }

        #endregion

        #region Boundary Cases

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void LowestCommonAncestor_LeafNodes_BothLeaves(ILowestCommonAncestorOfBinarySearchTree_235 solution, string solutionName)
        {
            // Input: root = [5,3,7,2,4,6,8], p = 2, q = 4
            //      5
            //     / \
            //    3   7
            //   / \ / \
            //  2  4 6  8
            // Output: 3

            // Arrange
            var root = CreateBST(new int?[] { 5, 3, 7, 2, 4, 6, 8 });
            var p = FindNode(root, 2);
            var q = FindNode(root, 4);

            // Act
            var result = solution.LowestCommonAncestor(root, p, q);

            // Assert
            Assert.IsNotNull(result, $"Failed for {solutionName}");
            Assert.AreEqual(3, result.val, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void LowestCommonAncestor_RootAndLeaf(ILowestCommonAncestorOfBinarySearchTree_235 solution, string solutionName)
        {
            // Input: root = [5,3,7,2,4,6,8], p = 5, q = 2
            //      5
            //     / \
            //    3   7
            //   / \ / \
            //  2  4 6  8
            // Output: 5

            // Arrange
            var root = CreateBST(new int?[] { 5, 3, 7, 2, 4, 6, 8 });
            var p = FindNode(root, 5);
            var q = FindNode(root, 2);

            // Act
            var result = solution.LowestCommonAncestor(root, p, q);

            // Assert
            Assert.IsNotNull(result, $"Failed for {solutionName}");
            Assert.AreEqual(5, result.val, $"Failed for {solutionName}");
        }

        #endregion

        #region Parameter Order Invariance

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void LowestCommonAncestor_ParameterOrderDoesNotMatter(ILowestCommonAncestorOfBinarySearchTree_235 solution, string solutionName)
        {
            // Verify that LCA(p, q) == LCA(q, p)

            // Arrange
            var root = CreateBST(new int?[] { 6, 2, 8, 0, 4, 7, 9 });
            var p = FindNode(root, 2);
            var q = FindNode(root, 8);

            // Act
            var result1 = solution.LowestCommonAncestor(root, p, q);
            var result2 = solution.LowestCommonAncestor(root, q, p);

            // Assert
            Assert.IsNotNull(result1, $"Failed for {solutionName}");
            Assert.IsNotNull(result2, $"Failed for {solutionName}");
            Assert.AreEqual(result1.val, result2.val, $"Parameter order should not matter for {solutionName}");
            Assert.AreSame(result1, result2, $"Should return exact same node reference for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void LowestCommonAncestor_MultipleCallsSameNodes_ReturnsSameResult(ILowestCommonAncestorOfBinarySearchTree_235 solution, string solutionName)
        {
            // Verify consistency of results

            // Arrange
            var root = CreateBST(new int?[] { 6, 2, 8, 0, 4, 7, 9 });
            var p = FindNode(root, 0);
            var q = FindNode(root, 4);

            // Act
            var result1 = solution.LowestCommonAncestor(root, p, q);
            var result2 = solution.LowestCommonAncestor(root, p, q);
            var result3 = solution.LowestCommonAncestor(root, p, q);

            // Assert
            Assert.AreEqual(result1.val, result2.val, $"Multiple calls should return same result for {solutionName}");
            Assert.AreEqual(result2.val, result3.val, $"Multiple calls should return same result for {solutionName}");
            Assert.AreSame(result1, result2, $"Should return same node reference for {solutionName}");
            Assert.AreSame(result2, result3, $"Should return same node reference for {solutionName}");
        }

        #endregion

        #region Property Tests

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void LowestCommonAncestor_ResultIsOnPathBetweenNodes(ILowestCommonAncestorOfBinarySearchTree_235 solution, string solutionName)
        {
            // Property: The LCA should be on the path from root to both p and q
            // For BST: LCA.val should be between p.val and q.val (or equal to one of them)

            // Arrange
            var root = CreateBST(new int?[] { 6, 2, 8, 0, 4, 7, 9, null, null, 3, 5 });
            var p = FindNode(root, 0);
            var q = FindNode(root, 5);

            // Act
            var result = solution.LowestCommonAncestor(root, p, q);

            // Assert
            int min = Math.Min(p.val, q.val);
            int max = Math.Max(p.val, q.val);
            Assert.IsTrue(result.val >= min && result.val <= max, 
                $"LCA value {result.val} should be between {min} and {max} for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void LowestCommonAncestor_TransitiveProperty(ILowestCommonAncestorOfBinarySearchTree_235 solution, string solutionName)
        {
            // Property: If LCA(p, q) = r and LCA(q, s) = r, then LCA(p, s) should also involve r

            // Arrange
            var root = CreateBST(new int?[] { 6, 2, 8, 0, 4, 7, 9, null, null, 3, 5 });
            var p = FindNode(root, 0);
            var q = FindNode(root, 4);
            var s = FindNode(root, 5);

            // Act
            var lcaPQ = solution.LowestCommonAncestor(root, p, q);
            var lcaQS = solution.LowestCommonAncestor(root, q, s);
            var lcaPS = solution.LowestCommonAncestor(root, p, s);

            // Assert
            Assert.AreEqual(2, lcaPQ.val, $"LCA(0, 4) should be 2 for {solutionName}");
            Assert.AreEqual(4, lcaQS.val, $"LCA(4, 5) should be 4 for {solutionName}");
            Assert.AreEqual(2, lcaPS.val, $"LCA(0, 5) should be 2 for {solutionName}");
        }

        #endregion
    }
}
