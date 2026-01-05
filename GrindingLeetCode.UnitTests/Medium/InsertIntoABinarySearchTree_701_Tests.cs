using LeetCodeProblems.CSharp.Tree;
using LeetCodeProblems.Interfaces.Medium;
using LeetCodeProblems.Shared;

namespace GrindingLeetCode.UnitTests.Medium
{
    [TestClass]
    public class InsertIntoABinarySearchTree_701_Tests
    {
        public static IEnumerable<object[]> GetImplementations()
        {
            yield return new object[] { new InsertIntoABinarySearchTree_Recursion_CSharp_701(), "C# Recursion" };
            yield return new object[] { new InsertIntoABinarySearchTree_Iterative_CSharp_701(), "C# Iterative" };
        }

        #region Helper Methods

        /// <summary>
        /// Creates a binary search tree from an array representation (level-order with nulls)
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
        /// Performs in-order traversal to get sorted values from BST
        /// </summary>
        private List<int> InorderTraversal(TreeNode root)
        {
            List<int> result = new List<int>();
            if (root == null) return result;

            result.AddRange(InorderTraversal(root.left));
            result.Add(root.val);
            result.AddRange(InorderTraversal(root.right));

            return result;
        }

        /// <summary>
        /// Verifies that a tree is a valid BST
        /// </summary>
        private bool IsValidBST(TreeNode root, long min = long.MinValue, long max = long.MaxValue)
        {
            if (root == null) return true;
            if (root.val <= min || root.val >= max) return false;
            return IsValidBST(root.left, min, root.val) && IsValidBST(root.right, root.val, max);
        }

        /// <summary>
        /// Checks if a value exists in the BST
        /// </summary>
        private bool Contains(TreeNode root, int val)
        {
            if (root == null) return false;
            if (root.val == val) return true;
            if (val < root.val) return Contains(root.left, val);
            return Contains(root.right, val);
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
        public void InsertIntoBST_Example1_InsertsCorrectly(IInsertIntoABinarySearchTree_701 solution, string solutionName)
        {
            // Input: root = [4,2,7,1,3], val = 5
            //       4               4
            //      / \             / \
            //     2   7    =>     2   7
            //    / \             / \ /
            //   1   3           1  3 5
            // Output: [4,2,7,1,3,5]

            // Arrange
            var root = CreateTree(new int?[] { 4, 2, 7, 1, 3 });
            int val = 5;

            // Act
            var result = solution.InsertIntoBST(root, val);

            // Assert
            Assert.IsTrue(IsValidBST(result), $"Failed for {solutionName} - Result is not a valid BST");
            Assert.IsTrue(Contains(result, val), $"Failed for {solutionName} - Value {val} not found in tree");
            Assert.AreEqual(6, CountNodes(result), $"Failed for {solutionName} - Node count mismatch");

            var inorder = InorderTraversal(result);
            CollectionAssert.AreEqual(new[] { 1, 2, 3, 4, 5, 7 }, inorder.ToArray(), $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void InsertIntoBST_Example2_InsertsAtRoot(IInsertIntoABinarySearchTree_701 solution, string solutionName)
        {
            // Input: root = [40,20,60,10,30,50,70], val = 25
            //         40                  40
            //        /  \                /  \
            //       20   60      =>     20   60
            //      / \   / \           / \   / \
            //     10 30 50 70         10 30 50 70
            //                            /
            //                           25
            // Output: [40,20,60,10,30,50,70,null,null,25]

            // Arrange
            var root = CreateTree(new int?[] { 40, 20, 60, 10, 30, 50, 70 });
            int val = 25;

            // Act
            var result = solution.InsertIntoBST(root, val);

            // Assert
            Assert.IsTrue(IsValidBST(result), $"Failed for {solutionName} - Result is not a valid BST");
            Assert.IsTrue(Contains(result, val), $"Failed for {solutionName} - Value {val} not found in tree");
            Assert.AreEqual(8, CountNodes(result), $"Failed for {solutionName} - Node count mismatch");

            var inorder = InorderTraversal(result);
            CollectionAssert.AreEqual(new[] { 10, 20, 25, 30, 40, 50, 60, 70 }, inorder.ToArray(), $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void InsertIntoBST_Example3_InsertsAtLeaf(IInsertIntoABinarySearchTree_701 solution, string solutionName)
        {
            // Input: root = [4,2,7,1,3,null,null,null,null,null,null], val = 5
            //       4               4
            //      / \             / \
            //     2   7    =>     2   7
            //    / \             / \
            //   1   3           1  3
            //                        \
            //                         5
            // Output: [4,2,7,1,3,null,null,null,null,5]

            // Arrange
            var root = CreateTree(new int?[] { 4, 2, 7, 1, 3 });
            int val = 5;

            // Act
            var result = solution.InsertIntoBST(root, val);

            // Assert
            Assert.IsTrue(IsValidBST(result), $"Failed for {solutionName} - Result is not a valid BST");
            Assert.IsTrue(Contains(result, val), $"Failed for {solutionName} - Value {val} not found in tree");

            var inorder = InorderTraversal(result);
            CollectionAssert.AreEqual(new[] { 1, 2, 3, 4, 5, 7 }, inorder.ToArray(), $"Failed for {solutionName}");
        }

        #endregion

        #region Empty and Single Node Cases

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void InsertIntoBST_EmptyTree_CreatesRoot(IInsertIntoABinarySearchTree_701 solution, string solutionName)
        {
            // Input: root = [], val = 5
            // Output: [5]

            // Arrange
            TreeNode root = null;
            int val = 5;

            // Act
            var result = solution.InsertIntoBST(root, val);

            // Assert
            Assert.IsNotNull(result, $"Failed for {solutionName} - Result should not be null");
            Assert.AreEqual(val, result.val, $"Failed for {solutionName} - Root value mismatch");
            Assert.IsNull(result.left, $"Failed for {solutionName} - Left child should be null");
            Assert.IsNull(result.right, $"Failed for {solutionName} - Right child should be null");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void InsertIntoBST_SingleNodeInsertSmaller_InsertsLeft(IInsertIntoABinarySearchTree_701 solution, string solutionName)
        {
            // Input: root = [5], val = 3
            //    5
            // Output: [5,3]
            //    5
            //   /
            //  3

            // Arrange
            var root = new TreeNode(5);
            int val = 3;

            // Act
            var result = solution.InsertIntoBST(root, val);

            // Assert
            Assert.IsTrue(IsValidBST(result), $"Failed for {solutionName} - Result is not a valid BST");
            Assert.AreEqual(5, result.val, $"Failed for {solutionName} - Root value should remain 5");
            Assert.IsNotNull(result.left, $"Failed for {solutionName} - Left child should not be null");
            Assert.AreEqual(3, result.left.val, $"Failed for {solutionName} - Left child value mismatch");
            Assert.IsNull(result.right, $"Failed for {solutionName} - Right child should be null");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void InsertIntoBST_SingleNodeInsertLarger_InsertsRight(IInsertIntoABinarySearchTree_701 solution, string solutionName)
        {
            // Input: root = [5], val = 7
            //    5
            // Output: [5,null,7]
            //    5
            //     \
            //      7

            // Arrange
            var root = new TreeNode(5);
            int val = 7;

            // Act
            var result = solution.InsertIntoBST(root, val);

            // Assert
            Assert.IsTrue(IsValidBST(result), $"Failed for {solutionName} - Result is not a valid BST");
            Assert.AreEqual(5, result.val, $"Failed for {solutionName} - Root value should remain 5");
            Assert.IsNull(result.left, $"Failed for {solutionName} - Left child should be null");
            Assert.IsNotNull(result.right, $"Failed for {solutionName} - Right child should not be null");
            Assert.AreEqual(7, result.right.val, $"Failed for {solutionName} - Right child value mismatch");
        }

        #endregion

        #region Insert at Different Positions

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void InsertIntoBST_InsertAsLeftLeaf_InsertsCorrectly(IInsertIntoABinarySearchTree_701 solution, string solutionName)
        {
            // Input: root = [4,2,7,1,3], val = 0
            //       4
            //      / \
            //     2   7
            //    / \
            //   1   3
            // Insert 0 (smallest value)

            // Arrange
            var root = CreateTree(new int?[] { 4, 2, 7, 1, 3 });
            int val = 0;

            // Act
            var result = solution.InsertIntoBST(root, val);

            // Assert
            Assert.IsTrue(IsValidBST(result), $"Failed for {solutionName} - Result is not a valid BST");
            Assert.IsTrue(Contains(result, val), $"Failed for {solutionName} - Value {val} not found in tree");

            var inorder = InorderTraversal(result);
            CollectionAssert.AreEqual(new[] { 0, 1, 2, 3, 4, 7 }, inorder.ToArray(), $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void InsertIntoBST_InsertAsRightLeaf_InsertsCorrectly(IInsertIntoABinarySearchTree_701 solution, string solutionName)
        {
            // Input: root = [4,2,7,1,3], val = 10
            //       4
            //      / \
            //     2   7
            //    / \
            //   1   3
            // Insert 10 (largest value)

            // Arrange
            var root = CreateTree(new int?[] { 4, 2, 7, 1, 3 });
            int val = 10;

            // Act
            var result = solution.InsertIntoBST(root, val);

            // Assert
            Assert.IsTrue(IsValidBST(result), $"Failed for {solutionName} - Result is not a valid BST");
            Assert.IsTrue(Contains(result, val), $"Failed for {solutionName} - Value {val} not found in tree");

            var inorder = InorderTraversal(result);
            CollectionAssert.AreEqual(new[] { 1, 2, 3, 4, 7, 10 }, inorder.ToArray(), $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void InsertIntoBST_InsertBetweenNodes_InsertsCorrectly(IInsertIntoABinarySearchTree_701 solution, string solutionName)
        {
            // Input: root = [10,5,15,2,7,null,20], val = 6
            //       10
            //      /  \
            //     5    15
            //    / \     \
            //   2   7    20
            // Insert 6 (between 5 and 7)

            // Arrange
            var root = CreateTree(new int?[] { 10, 5, 15, 2, 7, null, 20 });
            int val = 6;

            // Act
            var result = solution.InsertIntoBST(root, val);

            // Assert
            Assert.IsTrue(IsValidBST(result), $"Failed for {solutionName} - Result is not a valid BST");
            Assert.IsTrue(Contains(result, val), $"Failed for {solutionName} - Value {val} not found in tree");

            var inorder = InorderTraversal(result);
            CollectionAssert.AreEqual(new[] { 2, 5, 6, 7, 10, 15, 20 }, inorder.ToArray(), $"Failed for {solutionName}");
        }

        #endregion

        #region Skewed Trees

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void InsertIntoBST_LeftSkewedTree_InsertsCorrectly(IInsertIntoABinarySearchTree_701 solution, string solutionName)
        {
            // Input: root = [5,4,null,3,null,2,null,1], val = 0
            //      5
            //     /
            //    4
            //   /
            //  3
            // /
            //2
            ///
            //1
            // Insert 0 (extend the chain)

            // Arrange
            var root = CreateTree(new int?[] { 5, 4, null, 3, null, 2, null, 1 });
            int val = 0;

            // Act
            var result = solution.InsertIntoBST(root, val);

            // Assert
            Assert.IsTrue(IsValidBST(result), $"Failed for {solutionName} - Result is not a valid BST");
            Assert.IsTrue(Contains(result, val), $"Failed for {solutionName} - Value {val} not found in tree");

            var inorder = InorderTraversal(result);
            CollectionAssert.AreEqual(new[] { 0, 1, 2, 3, 4, 5 }, inorder.ToArray(), $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void InsertIntoBST_RightSkewedTree_InsertsCorrectly(IInsertIntoABinarySearchTree_701 solution, string solutionName)
        {
            // Input: root = [1,null,2,null,3,null,4,null,5], val = 6
            // 1
            //  \
            //   2
            //    \
            //     3
            //      \
            //       4
            //        \
            //         5
            // Insert 6 (extend the chain)

            // Arrange
            var root = CreateTree(new int?[] { 1, null, 2, null, 3, null, 4, null, 5 });
            int val = 6;

            // Act
            var result = solution.InsertIntoBST(root, val);

            // Assert
            Assert.IsTrue(IsValidBST(result), $"Failed for {solutionName} - Result is not a valid BST");
            Assert.IsTrue(Contains(result, val), $"Failed for {solutionName} - Value {val} not found in tree");

            var inorder = InorderTraversal(result);
            CollectionAssert.AreEqual(new[] { 1, 2, 3, 4, 5, 6 }, inorder.ToArray(), $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void InsertIntoBST_LeftSkewedTreeInsertMiddle_InsertsCorrectly(IInsertIntoABinarySearchTree_701 solution, string solutionName)
        {
            // Left-skewed tree, insert in the middle to balance slightly

            // Arrange
            var root = CreateTree(new int?[] { 5, 4, null, 3, null, 2, null, 1 });
            int val = 3; // Insert value that already balances it somewhat
            val = 6; // Insert at the right to create a right branch

            // Act
            var result = solution.InsertIntoBST(root, val);

            // Assert
            Assert.IsTrue(IsValidBST(result), $"Failed for {solutionName} - Result is not a valid BST");
            Assert.IsTrue(Contains(result, val), $"Failed for {solutionName} - Value {val} not found in tree");

            var inorder = InorderTraversal(result);
            CollectionAssert.AreEqual(new[] { 1, 2, 3, 4, 5, 6 }, inorder.ToArray(), $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void InsertIntoBST_RightSkewedTreeInsertMiddle_InsertsCorrectly(IInsertIntoABinarySearchTree_701 solution, string solutionName)
        {
            // Right-skewed tree, insert at the left to create a left branch

            // Arrange
            var root = CreateTree(new int?[] { 1, null, 2, null, 3, null, 4, null, 5 });
            int val = 0;

            // Act
            var result = solution.InsertIntoBST(root, val);

            // Assert
            Assert.IsTrue(IsValidBST(result), $"Failed for {solutionName} - Result is not a valid BST");
            Assert.IsTrue(Contains(result, val), $"Failed for {solutionName} - Value {val} not found in tree");

            var inorder = InorderTraversal(result);
            CollectionAssert.AreEqual(new[] { 0, 1, 2, 3, 4, 5 }, inorder.ToArray(), $"Failed for {solutionName}");
        }

        #endregion

        #region Balanced Trees

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void InsertIntoBST_PerfectBalancedTree_InsertsCorrectly(IInsertIntoABinarySearchTree_701 solution, string solutionName)
        {
            // Input: root = [4,2,6,1,3,5,7], val = 8
            //       4
            //      / \
            //     2   6
            //    / \ / \
            //   1  3 5  7

            // Arrange
            var root = CreateTree(new int?[] { 4, 2, 6, 1, 3, 5, 7 });
            int val = 8;

            // Act
            var result = solution.InsertIntoBST(root, val);

            // Assert
            Assert.IsTrue(IsValidBST(result), $"Failed for {solutionName} - Result is not a valid BST");
            Assert.IsTrue(Contains(result, val), $"Failed for {solutionName} - Value {val} not found in tree");

            var inorder = InorderTraversal(result);
            CollectionAssert.AreEqual(new[] { 1, 2, 3, 4, 5, 6, 7, 8 }, inorder.ToArray(), $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void InsertIntoBST_LargeBalancedTree_InsertsCorrectly(IInsertIntoABinarySearchTree_701 solution, string solutionName)
        {
            // Larger balanced tree with 15 nodes, insert 16

            // Arrange
            var root = CreateTree(new int?[] { 8, 4, 12, 2, 6, 10, 14, 1, 3, 5, 7, 9, 11, 13, 15 });
            int val = 16;

            // Act
            var result = solution.InsertIntoBST(root, val);

            // Assert
            Assert.IsTrue(IsValidBST(result), $"Failed for {solutionName} - Result is not a valid BST");
            Assert.IsTrue(Contains(result, val), $"Failed for {solutionName} - Value {val} not found in tree");

            var expected = Enumerable.Range(1, 16).ToArray();
            var inorder = InorderTraversal(result);
            CollectionAssert.AreEqual(expected, inorder.ToArray(), $"Failed for {solutionName}");
        }

        #endregion

        #region Edge Cases - Values

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void InsertIntoBST_NegativeValues_InsertsCorrectly(IInsertIntoABinarySearchTree_701 solution, string solutionName)
        {
            // Input: root = [0,-2,2,-3,-1,1,3], val = -4
            //        0
            //       / \
            //     -2   2
            //     / \ / \
            //   -3 -1 1  3

            // Arrange
            var root = CreateTree(new int?[] { 0, -2, 2, -3, -1, 1, 3 });
            int val = -4;

            // Act
            var result = solution.InsertIntoBST(root, val);

            // Assert
            Assert.IsTrue(IsValidBST(result), $"Failed for {solutionName} - Result is not a valid BST");
            Assert.IsTrue(Contains(result, val), $"Failed for {solutionName} - Value {val} not found in tree");

            var inorder = InorderTraversal(result);
            CollectionAssert.AreEqual(new[] { -4, -3, -2, -1, 0, 1, 2, 3 }, inorder.ToArray(), $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void InsertIntoBST_AllNegativeValues_InsertsCorrectly(IInsertIntoABinarySearchTree_701 solution, string solutionName)
        {
            // Input: root = [-4,-6,-2,-7,-5,-3,-1], val = -8
            //       -4
            //       / \
            //     -6  -2
            //     / \ / \
            //   -7 -5-3 -1

            // Arrange
            var root = CreateTree(new int?[] { -4, -6, -2, -7, -5, -3, -1 });
            int val = -8;

            // Act
            var result = solution.InsertIntoBST(root, val);

            // Assert
            Assert.IsTrue(IsValidBST(result), $"Failed for {solutionName} - Result is not a valid BST");
            Assert.IsTrue(Contains(result, val), $"Failed for {solutionName} - Value {val} not found in tree");

            var inorder = InorderTraversal(result);
            CollectionAssert.AreEqual(new[] { -8, -7, -6, -5, -4, -3, -2, -1 }, inorder.ToArray(), $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void InsertIntoBST_InsertZero_InsertsCorrectly(IInsertIntoABinarySearchTree_701 solution, string solutionName)
        {
            // Insert zero into a tree with negative and positive values

            // Arrange
            var root = CreateTree(new int?[] { 5, -5, 10, -10, 1, 8, 15 });
            int val = 0;

            // Act
            var result = solution.InsertIntoBST(root, val);

            // Assert
            Assert.IsTrue(IsValidBST(result), $"Failed for {solutionName} - Result is not a valid BST");
            Assert.IsTrue(Contains(result, val), $"Failed for {solutionName} - Value {val} not found in tree");

            var inorder = InorderTraversal(result);
            CollectionAssert.AreEqual(new[] { -10, -5, 0, 1, 5, 8, 10, 15 }, inorder.ToArray(), $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void InsertIntoBST_LargeValue_InsertsCorrectly(IInsertIntoABinarySearchTree_701 solution, string solutionName)
        {
            // Insert very large value

            // Arrange
            var root = CreateTree(new int?[] { 100, 50, 150, 25, 75, 125, 175 });
            int val = 10000;

            // Act
            var result = solution.InsertIntoBST(root, val);

            // Assert
            Assert.IsTrue(IsValidBST(result), $"Failed for {solutionName} - Result is not a valid BST");
            Assert.IsTrue(Contains(result, val), $"Failed for {solutionName} - Value {val} not found in tree");

            var inorder = InorderTraversal(result);
            CollectionAssert.AreEqual(new[] { 25, 50, 75, 100, 125, 150, 175, 10000 }, inorder.ToArray(), $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void InsertIntoBST_SmallValue_InsertsCorrectly(IInsertIntoABinarySearchTree_701 solution, string solutionName)
        {
            // Insert very small value

            // Arrange
            var root = CreateTree(new int?[] { 100, 50, 150, 25, 75, 125, 175 });
            int val = -10000;

            // Act
            var result = solution.InsertIntoBST(root, val);

            // Assert
            Assert.IsTrue(IsValidBST(result), $"Failed for {solutionName} - Result is not a valid BST");
            Assert.IsTrue(Contains(result, val), $"Failed for {solutionName} - Value {val} not found in tree");

            var inorder = InorderTraversal(result);
            CollectionAssert.AreEqual(new[] { -10000, 25, 50, 75, 100, 125, 150, 175 }, inorder.ToArray(), $"Failed for {solutionName}");
        }

        #endregion

        #region Complex Trees

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void InsertIntoBST_ComplexUnbalanced_InsertsCorrectly(IInsertIntoABinarySearchTree_701 solution, string solutionName)
        {
            // Complex unbalanced tree

            // Arrange
            var root = CreateTree(new int?[] { 10, 5, 15, 3, 7, null, 20, 1, 4, 6, 9 });
            int val = 8;

            // Act
            var result = solution.InsertIntoBST(root, val);

            // Assert
            Assert.IsTrue(IsValidBST(result), $"Failed for {solutionName} - Result is not a valid BST");
            Assert.IsTrue(Contains(result, val), $"Failed for {solutionName} - Value {val} not found in tree");

            var inorder = InorderTraversal(result);
            CollectionAssert.AreEqual(new[] { 1, 3, 4, 5, 6, 7, 8, 9, 10, 15, 20 }, inorder.ToArray(), $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void InsertIntoBST_SparseTree_InsertsCorrectly(IInsertIntoABinarySearchTree_701 solution, string solutionName)
        {
            // Sparse tree with many null nodes

            // Arrange
            var root = CreateTree(new int?[] { 8, 4, 12, null, 6, 10 });
            int val = 5;

            // Act
            var result = solution.InsertIntoBST(root, val);

            // Assert
            Assert.IsTrue(IsValidBST(result), $"Failed for {solutionName} - Result is not a valid BST");
            Assert.IsTrue(Contains(result, val), $"Failed for {solutionName} - Value {val} not found in tree");

            var inorder = InorderTraversal(result);
            CollectionAssert.AreEqual(new[] { 4, 5, 6, 8, 10, 12 }, inorder.ToArray(), $"Failed for {solutionName}");
        }

        #endregion

        #region Sequential Insertions

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void InsertIntoBST_MultipleInsertionsAscending_CreatesValidBST(IInsertIntoABinarySearchTree_701 solution, string solutionName)
        {
            // Insert multiple values in ascending order

            // Arrange
            TreeNode root = null;
            int[] values = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            // Act
            foreach (int val in values)
            {
                root = solution.InsertIntoBST(root, val);
            }

            // Assert
            Assert.IsTrue(IsValidBST(root), $"Failed for {solutionName} - Result is not a valid BST");
            Assert.AreEqual(values.Length, CountNodes(root), $"Failed for {solutionName} - Node count mismatch");

            var inorder = InorderTraversal(root);
            CollectionAssert.AreEqual(values, inorder.ToArray(), $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void InsertIntoBST_MultipleInsertionsDescending_CreatesValidBST(IInsertIntoABinarySearchTree_701 solution, string solutionName)
        {
            // Insert multiple values in descending order

            // Arrange
            TreeNode root = null;
            int[] values = { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 };

            // Act
            foreach (int val in values)
            {
                root = solution.InsertIntoBST(root, val);
            }

            // Assert
            Assert.IsTrue(IsValidBST(root), $"Failed for {solutionName} - Result is not a valid BST");
            Assert.AreEqual(values.Length, CountNodes(root), $"Failed for {solutionName} - Node count mismatch");

            var inorder = InorderTraversal(root);
            CollectionAssert.AreEqual(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, inorder.ToArray(), $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void InsertIntoBST_MultipleInsertionsRandom_CreatesValidBST(IInsertIntoABinarySearchTree_701 solution, string solutionName)
        {
            // Insert multiple values in random order

            // Arrange
            TreeNode root = null;
            int[] values = { 5, 3, 7, 1, 9, 2, 8, 4, 6, 10 };

            // Act
            foreach (int val in values)
            {
                root = solution.InsertIntoBST(root, val);
            }

            // Assert
            Assert.IsTrue(IsValidBST(root), $"Failed for {solutionName} - Result is not a valid BST");
            Assert.AreEqual(values.Length, CountNodes(root), $"Failed for {solutionName} - Node count mismatch");

            var inorder = InorderTraversal(root);
            CollectionAssert.AreEqual(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, inorder.ToArray(), $"Failed for {solutionName}");
        }

        #endregion

        #region Boundary Cases

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void InsertIntoBST_InsertConstraintMinValue_InsertsCorrectly(IInsertIntoABinarySearchTree_701 solution, string solutionName)
        {
            // According to LeetCode constraints: -10^4 <= val <= 10^4

            // Arrange
            var root = CreateTree(new int?[] { 0, -5000, 5000 });
            int val = -10000;

            // Act
            var result = solution.InsertIntoBST(root, val);

            // Assert
            Assert.IsTrue(IsValidBST(result), $"Failed for {solutionName} - Result is not a valid BST");
            Assert.IsTrue(Contains(result, val), $"Failed for {solutionName} - Value {val} not found in tree");

            var inorder = InorderTraversal(result);
            CollectionAssert.AreEqual(new[] { -10000, -5000, 0, 5000 }, inorder.ToArray(), $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void InsertIntoBST_InsertConstraintMaxValue_InsertsCorrectly(IInsertIntoABinarySearchTree_701 solution, string solutionName)
        {
            // According to LeetCode constraints: -10^4 <= val <= 10^4

            // Arrange
            var root = CreateTree(new int?[] { 0, -5000, 5000 });
            int val = 10000;

            // Act
            var result = solution.InsertIntoBST(root, val);

            // Assert
            Assert.IsTrue(IsValidBST(result), $"Failed for {solutionName} - Result is not a valid BST");
            Assert.IsTrue(Contains(result, val), $"Failed for {solutionName} - Value {val} not found in tree");

            var inorder = InorderTraversal(result);
            CollectionAssert.AreEqual(new[] { -5000, 0, 5000, 10000 }, inorder.ToArray(), $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void InsertIntoBST_TwoNodeTreeInsertMiddle_InsertsCorrectly(IInsertIntoABinarySearchTree_701 solution, string solutionName)
        {
            // Two node tree, insert value between them

            // Arrange
            var root = new TreeNode(10);
            root.right = new TreeNode(20);
            int val = 15;

            // Act
            var result = solution.InsertIntoBST(root, val);

            // Assert
            Assert.IsTrue(IsValidBST(result), $"Failed for {solutionName} - Result is not a valid BST");
            Assert.IsTrue(Contains(result, val), $"Failed for {solutionName} - Value {val} not found in tree");

            var inorder = InorderTraversal(result);
            CollectionAssert.AreEqual(new[] { 10, 15, 20 }, inorder.ToArray(), $"Failed for {solutionName}");
        }

        #endregion

        #region Property-Based Tests

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void InsertIntoBST_PreservesExistingNodes_InsertsCorrectly(IInsertIntoABinarySearchTree_701 solution, string solutionName)
        {
            // Verify that all existing nodes remain in the tree

            // Arrange
            var root = CreateTree(new int?[] { 4, 2, 6, 1, 3, 5, 7 });
            var originalInorder = InorderTraversal(root);
            int val = 8;

            // Act
            var result = solution.InsertIntoBST(root, val);

            // Assert
            var newInorder = InorderTraversal(result);
            foreach (int existingVal in originalInorder)
            {
                Assert.IsTrue(newInorder.Contains(existingVal), 
                    $"Failed for {solutionName} - Existing value {existingVal} not found after insertion");
            }
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void InsertIntoBST_NodeCountIncreasesByOne_InsertsCorrectly(IInsertIntoABinarySearchTree_701 solution, string solutionName)
        {
            // Verify that node count increases by exactly one

            // Arrange
            var root = CreateTree(new int?[] { 4, 2, 6, 1, 3, 5, 7 });
            int originalCount = CountNodes(root);
            int val = 8;

            // Act
            var result = solution.InsertIntoBST(root, val);

            // Assert
            int newCount = CountNodes(result);
            Assert.AreEqual(originalCount + 1, newCount, 
                $"Failed for {solutionName} - Node count should increase by exactly 1");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void InsertIntoBST_MaintainsBSTProperty_InsertsCorrectly(IInsertIntoABinarySearchTree_701 solution, string solutionName)
        {
            // Verify that BST property is maintained after insertion

            // Arrange
            var root = CreateTree(new int?[] { 50, 30, 70, 20, 40, 60, 80 });
            int[] valuesToInsert = { 10, 25, 35, 45, 55, 65, 75, 85 };

            // Act & Assert
            foreach (int val in valuesToInsert)
            {
                root = solution.InsertIntoBST(root, val);
                Assert.IsTrue(IsValidBST(root), 
                    $"Failed for {solutionName} - BST property violated after inserting {val}");
            }
        }

        #endregion

        #region Stress Tests

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void InsertIntoBST_DeepTree_InsertsCorrectly(IInsertIntoABinarySearchTree_701 solution, string solutionName)
        {
            // Create a deep tree and insert a value

            // Arrange
            TreeNode root = new TreeNode(50);
            TreeNode current = root;
            for (int i = 49; i >= 30; i--)
            {
                current.left = new TreeNode(i);
                current = current.left;
            }
            current = root;
            for (int i = 51; i <= 70; i++)
            {
                current.right = new TreeNode(i);
                current = current.right;
            }

            int val = 25;

            // Act
            var result = solution.InsertIntoBST(root, val);

            // Assert
            Assert.IsTrue(IsValidBST(result), $"Failed for {solutionName} - Result is not a valid BST");
            Assert.IsTrue(Contains(result, val), $"Failed for {solutionName} - Value {val} not found in tree");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void InsertIntoBST_BuildTreeFromScratch_CreatesValidBST(IInsertIntoABinarySearchTree_701 solution, string solutionName)
        {
            // Build a complete tree from scratch using only insertions

            // Arrange
            TreeNode root = null;
            int[] values = { 50, 30, 70, 20, 40, 60, 80, 10, 25, 35, 45, 55, 65, 75, 85 };

            // Act
            foreach (int val in values)
            {
                root = solution.InsertIntoBST(root, val);
            }

            // Assert
            Assert.IsTrue(IsValidBST(root), $"Failed for {solutionName} - Result is not a valid BST");
            Assert.AreEqual(values.Length, CountNodes(root), $"Failed for {solutionName} - Node count mismatch");

            var inorder = InorderTraversal(root);
            var expected = values.OrderBy(x => x).ToArray();
            CollectionAssert.AreEqual(expected, inorder.ToArray(), $"Failed for {solutionName}");
        }

        #endregion
    }
}
