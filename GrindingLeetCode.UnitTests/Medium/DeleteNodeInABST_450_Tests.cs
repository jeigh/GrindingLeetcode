using LeetCodeProblems.CSharp.Tree;
using LeetCodeProblems.Interfaces.Medium;
using LeetCodeProblems.Shared;
using LeetCodeProblems.VisualBasic;

namespace GrindingLeetCode.UnitTests.Medium
{
    [TestClass]
    public class DeleteNodeInABST_450_Tests
    {
        public static IEnumerable<object[]> GetImplementations()
        {
            //yield return new object[] { new DeleteNodeInABST_Iterative_CSharp_450(), "C# Iterative" };

            yield return new object[] { new DeleteNodeInABST_RecursiveSuccessorDeletion_CSharp_450(), "C# Recursive Successor Deletion" };
            yield return new object[] { new DeleteNodeInABST_LeftTreeDemotion_CSharp_450(), "C# Left Tree Demotion" };
            yield return new object[] { new DeleteNodeInABST_DirectSuccessorPromotion_CSharp_450(), "C# Direct Successor Promotion" };

            yield return new object[] { new DeleteNodeInABST_RecursiveSuccessorDeletion_Defunctionalized_CSharp_450(), "C# Defunctionalized" };

            yield return new object[] { new DeleteNodeInABST_RecursiveSuccessorDeletion_VB_450(), "VB Recursive Successor Deletion" };
            yield return new object[] { new DeleteNodeInABST_DirectSuccessorPromotion_VB_450(), "VB Direct Successor Promotion" };
            yield return new object[] { new DeleteNodeInABST_LeftTreeDemotion_VB_450(), "VB Left Tree Demotion" };
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
        public void DeleteNode_Example1_DeletesLeafNode(IDeleteNodeInABST_450 solution, string solutionName)
        {
            // Input: root = [5,3,6,2,4,null,7], key = 3
            //       5                5
            //      / \              / \
            //     3   6     =>     4   6
            //    / \   \          /     \
            //   2   4   7        2       7
            // Output: [5,4,6,2,null,null,7]

            // Arrange
            var root = CreateTree(new int?[] { 5, 3, 6, 2, 4, null, 7 });
            int key = 3;

            // Act
            var result = solution.DeleteNode(root, key);

            // Assert
            Assert.IsTrue(IsValidBST(result), $"Failed for {solutionName} - Result is not a valid BST");
            Assert.IsFalse(Contains(result, key), $"Failed for {solutionName} - Key {key} should be deleted");
            Assert.AreEqual(5, CountNodes(result), $"Failed for {solutionName} - Node count mismatch");

            var inorder = InorderTraversal(result);
            CollectionAssert.AreEqual(new[] { 2, 4, 5, 6, 7 }, inorder.ToArray(), $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void DeleteNode_Example2_KeyNotFound(IDeleteNodeInABST_450 solution, string solutionName)
        {
            // Input: root = [5,3,6,2,4,null,7], key = 0
            // Output: [5,3,6,2,4,null,7]
            // Explanation: The tree does not contain a node with value 0

            // Arrange
            var root = CreateTree(new int?[] { 5, 3, 6, 2, 4, null, 7 });
            var originalInorder = InorderTraversal(root);
            int key = 0;

            // Act
            var result = solution.DeleteNode(root, key);

            // Assert
            Assert.IsTrue(IsValidBST(result), $"Failed for {solutionName} - Result is not a valid BST");
            Assert.AreEqual(6, CountNodes(result), $"Failed for {solutionName} - Node count should remain same");

            var inorder = InorderTraversal(result);
            CollectionAssert.AreEqual(originalInorder.ToArray(), inorder.ToArray(), $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void DeleteNode_Example3_EmptyTree(IDeleteNodeInABST_450 solution, string solutionName)
        {
            // Input: root = [], key = 0
            // Output: []

            // Arrange
            TreeNode root = null;
            int key = 0;

            // Act
            var result = solution.DeleteNode(root, key);

            // Assert
            Assert.IsNull(result, $"Failed for {solutionName} - Result should be null");
        }

        #endregion

        #region Delete Leaf Nodes

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void DeleteNode_DeleteLeftLeaf_RemovesCorrectly(IDeleteNodeInABST_450 solution, string solutionName)
        {
            // Delete a leaf node on the left

            // Arrange
            var root = CreateTree(new int?[] { 4, 2, 6, 1, 3, 5, 7 });
            int key = 1;

            // Act
            var result = solution.DeleteNode(root, key);

            // Assert
            Assert.IsTrue(IsValidBST(result), $"Failed for {solutionName} - Result is not a valid BST");
            Assert.IsFalse(Contains(result, key), $"Failed for {solutionName} - Key {key} should be deleted");

            var inorder = InorderTraversal(result);
            CollectionAssert.AreEqual(new[] { 2, 3, 4, 5, 6, 7 }, inorder.ToArray(), $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void DeleteNode_DeleteRightLeaf_RemovesCorrectly(IDeleteNodeInABST_450 solution, string solutionName)
        {
            // Delete a leaf node on the right

            // Arrange
            var root = CreateTree(new int?[] { 4, 2, 6, 1, 3, 5, 7 });
            int key = 7;

            // Act
            var result = solution.DeleteNode(root, key);

            // Assert
            Assert.IsTrue(IsValidBST(result), $"Failed for {solutionName} - Result is not a valid BST");
            Assert.IsFalse(Contains(result, key), $"Failed for {solutionName} - Key {key} should be deleted");

            var inorder = InorderTraversal(result);
            CollectionAssert.AreEqual(new[] { 1, 2, 3, 4, 5, 6 }, inorder.ToArray(), $"Failed for {solutionName}");
        }

        #endregion

        #region Delete Node with One Child

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void DeleteNode_NodeWithOnlyLeftChild_RemovesCorrectly(IDeleteNodeInABST_450 solution, string solutionName)
        {
            // Delete a node that has only left child

            // Arrange
            var root = CreateTree(new int?[] { 5, 3, 6, 2, null, null, 7 });
            int key = 3; // Has only left child (2)

            // Act
            var result = solution.DeleteNode(root, key);

            // Assert
            Assert.IsTrue(IsValidBST(result), $"Failed for {solutionName} - Result is not a valid BST");
            Assert.IsFalse(Contains(result, key), $"Failed for {solutionName} - Key {key} should be deleted");

            var inorder = InorderTraversal(result);
            CollectionAssert.AreEqual(new[] { 2, 5, 6, 7 }, inorder.ToArray(), $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void DeleteNode_NodeWithOnlyRightChild_RemovesCorrectly(IDeleteNodeInABST_450 solution, string solutionName)
        {
            // Delete a node that has only right child

            // Arrange
            var root = CreateTree(new int?[] { 5, 3, 6, null, 4, null, 7 });
            int key = 3; // Has only right child (4)

            // Act
            var result = solution.DeleteNode(root, key);

            // Assert
            Assert.IsTrue(IsValidBST(result), $"Failed for {solutionName} - Result is not a valid BST");
            Assert.IsFalse(Contains(result, key), $"Failed for {solutionName} - Key {key} should be deleted");

            var inorder = InorderTraversal(result);
            CollectionAssert.AreEqual(new[] { 4, 5, 6, 7 }, inorder.ToArray(), $"Failed for {solutionName}");
        }

        #endregion

        #region Delete Node with Two Children

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void DeleteNode_NodeWithTwoChildren_RemovesCorrectly(IDeleteNodeInABST_450 solution, string solutionName)
        {
            // Delete a node with two children

            // Arrange
            var root = CreateTree(new int?[] { 5, 3, 6, 2, 4, null, 7 });
            int key = 3; // Has both children

            // Act
            var result = solution.DeleteNode(root, key);

            // Assert
            Assert.IsTrue(IsValidBST(result), $"Failed for {solutionName} - Result is not a valid BST");
            Assert.IsFalse(Contains(result, key), $"Failed for {solutionName} - Key {key} should be deleted");

            var inorder = InorderTraversal(result);
            CollectionAssert.AreEqual(new[] { 2, 4, 5, 6, 7 }, inorder.ToArray(), $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void DeleteNode_NodeWithTwoChildrenComplex_RemovesCorrectly(IDeleteNodeInABST_450 solution, string solutionName)
        {
            // Delete a node with two children in a more complex tree

            // Arrange
            var root = CreateTree(new int?[] { 10, 5, 15, 3, 7, 12, 20, 1, 4, 6, 9 });
            int key = 5; // Has two children with subtrees

            // Act
            var result = solution.DeleteNode(root, key);

            // Assert
            Assert.IsTrue(IsValidBST(result), $"Failed for {solutionName} - Result is not a valid BST");
            Assert.IsFalse(Contains(result, key), $"Failed for {solutionName} - Key {key} should be deleted");

            var inorder = InorderTraversal(result);
            CollectionAssert.AreEqual(new[] { 1, 3, 4, 6, 7, 9, 10, 12, 15, 20 }, inorder.ToArray(), $"Failed for {solutionName}");
        }

        #endregion

        #region Delete Root Node

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void DeleteNode_DeleteRoot_SingleNode_ReturnsNull(IDeleteNodeInABST_450 solution, string solutionName)
        {
            // Delete the only node in the tree (root)

            // Arrange
            var root = new TreeNode(5);
            int key = 5;

            // Act
            var result = solution.DeleteNode(root, key);

            // Assert
            Assert.IsNull(result, $"Failed for {solutionName} - Result should be null");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void DeleteNode_DeleteRootWithLeftChild_PromotesLeftChild(IDeleteNodeInABST_450 solution, string solutionName)
        {
            // Delete root that has only left child

            // Arrange
            var root = new TreeNode(5);
            root.left = new TreeNode(3);
            int key = 5;

            // Act
            var result = solution.DeleteNode(root, key);

            // Assert
            Assert.IsTrue(IsValidBST(result), $"Failed for {solutionName} - Result is not a valid BST");
            Assert.IsFalse(Contains(result, key), $"Failed for {solutionName} - Key {key} should be deleted");
            Assert.AreEqual(3, result.val, $"Failed for {solutionName} - New root should be 3");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void DeleteNode_DeleteRootWithRightChild_PromotesRightChild(IDeleteNodeInABST_450 solution, string solutionName)
        {
            // Delete root that has only right child

            // Arrange
            var root = new TreeNode(5);
            root.right = new TreeNode(7);
            int key = 5;

            // Act
            var result = solution.DeleteNode(root, key);

            // Assert
            Assert.IsTrue(IsValidBST(result), $"Failed for {solutionName} - Result is not a valid BST");
            Assert.IsFalse(Contains(result, key), $"Failed for {solutionName} - Key {key} should be deleted");
            Assert.AreEqual(7, result.val, $"Failed for {solutionName} - New root should be 7");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void DeleteNode_DeleteRootWithTwoChildren_RemovesCorrectly(IDeleteNodeInABST_450 solution, string solutionName)
        {
            // Delete root that has two children

            // Arrange
            var root = CreateTree(new int?[] { 5, 3, 7, 2, 4, 6, 8 });
            int key = 5;

            // Act
            var result = solution.DeleteNode(root, key);

            // Assert
            Assert.IsTrue(IsValidBST(result), $"Failed for {solutionName} - Result is not a valid BST");
            Assert.IsFalse(Contains(result, key), $"Failed for {solutionName} - Key {key} should be deleted");

            var inorder = InorderTraversal(result);
            CollectionAssert.AreEqual(new[] { 2, 3, 4, 6, 7, 8 }, inorder.ToArray(), $"Failed for {solutionName}");
        }

        #endregion

        #region Skewed Trees

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void DeleteNode_LeftSkewedTree_DeletesCorrectly(IDeleteNodeInABST_450 solution, string solutionName)
        {
            // Delete from a left-skewed tree

            // Arrange
            var root = CreateTree(new int?[] { 5, 4, null, 3, null, 2, null, 1 });
            int key = 3;

            // Act
            var result = solution.DeleteNode(root, key);

            // Assert
            Assert.IsTrue(IsValidBST(result), $"Failed for {solutionName} - Result is not a valid BST");
            Assert.IsFalse(Contains(result, key), $"Failed for {solutionName} - Key {key} should be deleted");

            var inorder = InorderTraversal(result);
            CollectionAssert.AreEqual(new[] { 1, 2, 4, 5 }, inorder.ToArray(), $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void DeleteNode_RightSkewedTree_DeletesCorrectly(IDeleteNodeInABST_450 solution, string solutionName)
        {
            // Delete from a right-skewed tree

            // Arrange
            var root = CreateTree(new int?[] { 1, null, 2, null, 3, null, 4, null, 5 });
            int key = 3;

            // Act
            var result = solution.DeleteNode(root, key);

            // Assert
            Assert.IsTrue(IsValidBST(result), $"Failed for {solutionName} - Result is not a valid BST");
            Assert.IsFalse(Contains(result, key), $"Failed for {solutionName} - Key {key} should be deleted");

            var inorder = InorderTraversal(result);
            CollectionAssert.AreEqual(new[] { 1, 2, 4, 5 }, inorder.ToArray(), $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void DeleteNode_LeftSkewedTree_DeleteRoot_RemovesCorrectly(IDeleteNodeInABST_450 solution, string solutionName)
        {
            // Delete root from left-skewed tree

            // Arrange
            var root = CreateTree(new int?[] { 5, 4, null, 3, null, 2, null, 1 });
            int key = 5;

            // Act
            var result = solution.DeleteNode(root, key);

            // Assert
            Assert.IsTrue(IsValidBST(result), $"Failed for {solutionName} - Result is not a valid BST");
            Assert.IsFalse(Contains(result, key), $"Failed for {solutionName} - Key {key} should be deleted");

            var inorder = InorderTraversal(result);
            CollectionAssert.AreEqual(new[] { 1, 2, 3, 4 }, inorder.ToArray(), $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void DeleteNode_RightSkewedTree_DeleteRoot_RemovesCorrectly(IDeleteNodeInABST_450 solution, string solutionName)
        {
            // Delete root from right-skewed tree

            // Arrange
            var root = CreateTree(new int?[] { 1, null, 2, null, 3, null, 4, null, 5 });
            int key = 1;

            // Act
            var result = solution.DeleteNode(root, key);

            // Assert
            Assert.IsTrue(IsValidBST(result), $"Failed for {solutionName} - Result is not a valid BST");
            Assert.IsFalse(Contains(result, key), $"Failed for {solutionName} - Key {key} should be deleted");

            var inorder = InorderTraversal(result);
            CollectionAssert.AreEqual(new[] { 2, 3, 4, 5 }, inorder.ToArray(), $"Failed for {solutionName}");
        }

        #endregion

        #region Balanced Trees

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void DeleteNode_BalancedTree_DeleteMiddle_RemovesCorrectly(IDeleteNodeInABST_450 solution, string solutionName)
        {
            // Delete from a balanced tree

            // Arrange
            var root = CreateTree(new int?[] { 8, 4, 12, 2, 6, 10, 14, 1, 3, 5, 7, 9, 11, 13, 15 });
            int key = 6;

            // Act
            var result = solution.DeleteNode(root, key);

            // Assert
            Assert.IsTrue(IsValidBST(result), $"Failed for {solutionName} - Result is not a valid BST");
            Assert.IsFalse(Contains(result, key), $"Failed for {solutionName} - Key {key} should be deleted");

            var expected = new[] { 1, 2, 3, 4, 5, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
            var inorder = InorderTraversal(result);
            CollectionAssert.AreEqual(expected, inorder.ToArray(), $"Failed for {solutionName}");
        }

        #endregion

        #region Edge Cases - Values

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void DeleteNode_NegativeValues_DeletesCorrectly(IDeleteNodeInABST_450 solution, string solutionName)
        {
            // Delete from tree with negative values

            // Arrange
            var root = CreateTree(new int?[] { 0, -2, 2, -3, -1, 1, 3 });
            int key = -2;

            // Act
            var result = solution.DeleteNode(root, key);

            // Assert
            Assert.IsTrue(IsValidBST(result), $"Failed for {solutionName} - Result is not a valid BST");
            Assert.IsFalse(Contains(result, key), $"Failed for {solutionName} - Key {key} should be deleted");

            var inorder = InorderTraversal(result);
            CollectionAssert.AreEqual(new[] { -3, -1, 0, 1, 2, 3 }, inorder.ToArray(), $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void DeleteNode_AllNegativeValues_DeletesCorrectly(IDeleteNodeInABST_450 solution, string solutionName)
        {
            // Delete from tree with all negative values

            // Arrange
            var root = CreateTree(new int?[] { -4, -6, -2, -7, -5, -3, -1 });
            int key = -4;

            // Act
            var result = solution.DeleteNode(root, key);

            // Assert
            Assert.IsTrue(IsValidBST(result), $"Failed for {solutionName} - Result is not a valid BST");
            Assert.IsFalse(Contains(result, key), $"Failed for {solutionName} - Key {key} should be deleted");

            var inorder = InorderTraversal(result);
            CollectionAssert.AreEqual(new[] { -7, -6, -5, -3, -2, -1 }, inorder.ToArray(), $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void DeleteNode_DeleteZero_DeletesCorrectly(IDeleteNodeInABST_450 solution, string solutionName)
        {
            // Delete zero from tree

            // Arrange
            var root = CreateTree(new int?[] { 5, -5, 10, -10, 0, 8, 15 });
            int key = 0;

            // Act
            var result = solution.DeleteNode(root, key);

            // Assert
            Assert.IsTrue(IsValidBST(result), $"Failed for {solutionName} - Result is not a valid BST");
            Assert.IsFalse(Contains(result, key), $"Failed for {solutionName} - Key {key} should be deleted");

            var inorder = InorderTraversal(result);
            CollectionAssert.AreEqual(new[] { -10, -5, 5, 8, 10, 15 }, inorder.ToArray(), $"Failed for {solutionName}");
        }

        #endregion

        #region Sequential Deletions

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void DeleteNode_MultipleSequentialDeletions_MaintainsBST(IDeleteNodeInABST_450 solution, string solutionName)
        {
            // Delete multiple nodes sequentially

            // Arrange
            var root = CreateTree(new int?[] { 8, 4, 12, 2, 6, 10, 14, 1, 3, 5, 7, 9, 11, 13, 15 });
            int[] keysToDelete = { 6, 10, 14 };

            // Act
            foreach (int key in keysToDelete)
            {
                root = solution.DeleteNode(root, key);
            }

            // Assert
            Assert.IsTrue(IsValidBST(root), $"Failed for {solutionName} - Result is not a valid BST");
            foreach (int key in keysToDelete)
            {
                Assert.IsFalse(Contains(root, key), $"Failed for {solutionName} - Key {key} should be deleted");
            }

            var inorder = InorderTraversal(root);
            CollectionAssert.AreEqual(new[] { 1, 2, 3, 4, 5, 7, 8, 9, 11, 12, 13, 15 }, inorder.ToArray(), $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void DeleteNode_DeleteAllNodesOneByOne_ReturnsNull(IDeleteNodeInABST_450 solution, string solutionName)
        {
            // Delete all nodes from tree one by one

            // Arrange
            var root = CreateTree(new int?[] { 4, 2, 6, 1, 3, 5, 7 });
            int[] keysToDelete = { 1, 2, 3, 4, 5, 6, 7 };

            // Act
            foreach (int key in keysToDelete)
            {
                root = solution.DeleteNode(root, key);
            }

            // Assert
            Assert.IsNull(root, $"Failed for {solutionName} - Result should be null after deleting all nodes");
        }

        #endregion

        #region Complex Scenarios

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void DeleteNode_DeleteNodeWithComplexSubtree_RemovesCorrectly(IDeleteNodeInABST_450 solution, string solutionName)
        {
            // Delete node with complex subtree structure

            // Arrange
            var root = CreateTree(new int?[] { 20, 10, 30, 5, 15, 25, 35, 3, 7, 12, 18 });
            int key = 10; // Node with complex left and right subtrees

            // Act
            var result = solution.DeleteNode(root, key);

            // Assert
            Assert.IsTrue(IsValidBST(result), $"Failed for {solutionName} - Result is not a valid BST");
            Assert.IsFalse(Contains(result, key), $"Failed for {solutionName} - Key {key} should be deleted");

            var inorder = InorderTraversal(result);
            CollectionAssert.AreEqual(new[] { 3, 5, 7, 12, 15, 18, 20, 25, 30, 35 }, inorder.ToArray(), $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void DeleteNode_SparseTree_DeletesCorrectly(IDeleteNodeInABST_450 solution, string solutionName)
        {
            // Delete from sparse tree

            // Arrange
            var root = CreateTree(new int?[] { 8, 4, 12, null, 6, 10, null, 5 });
            int key = 4;

            // Act
            var result = solution.DeleteNode(root, key);

            // Assert
            Assert.IsTrue(IsValidBST(result), $"Failed for {solutionName} - Result is not a valid BST");
            Assert.IsFalse(Contains(result, key), $"Failed for {solutionName} - Key {key} should be deleted");

            var inorder = InorderTraversal(result);
            CollectionAssert.AreEqual(new[] { 5, 6, 8, 10, 12 }, inorder.ToArray(), $"Failed for {solutionName}");
        }

        #endregion

        #region Boundary Conditions

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void DeleteNode_DeleteMinValue_RemovesCorrectly(IDeleteNodeInABST_450 solution, string solutionName)
        {
            // Delete the minimum value in the tree

            // Arrange
            var root = CreateTree(new int?[] { 8, 4, 12, 2, 6, 10, 14, 1, 3, 5, 7, 9, 11, 13, 15 });
            int key = 1; // Minimum value

            // Act
            var result = solution.DeleteNode(root, key);

            // Assert
            Assert.IsTrue(IsValidBST(result), $"Failed for {solutionName} - Result is not a valid BST");
            Assert.IsFalse(Contains(result, key), $"Failed for {solutionName} - Key {key} should be deleted");

            var inorder = InorderTraversal(result);
            var expected = Enumerable.Range(2, 14).ToArray();
            CollectionAssert.AreEqual(expected, inorder.ToArray(), $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void DeleteNode_DeleteMaxValue_RemovesCorrectly(IDeleteNodeInABST_450 solution, string solutionName)
        {
            // Delete the maximum value in the tree

            // Arrange
            var root = CreateTree(new int?[] { 8, 4, 12, 2, 6, 10, 14, 1, 3, 5, 7, 9, 11, 13, 15 });
            int key = 15; // Maximum value

            // Act
            var result = solution.DeleteNode(root, key);

            // Assert
            Assert.IsTrue(IsValidBST(result), $"Failed for {solutionName} - Result is not a valid BST");
            Assert.IsFalse(Contains(result, key), $"Failed for {solutionName} - Key {key} should be deleted");

            var inorder = InorderTraversal(result);
            var expected = Enumerable.Range(1, 14).ToArray();
            CollectionAssert.AreEqual(expected, inorder.ToArray(), $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void DeleteNode_TwoNodeTree_DeletesCorrectly(IDeleteNodeInABST_450 solution, string solutionName)
        {
            // Two node tree, delete one

            // Arrange
            var root = new TreeNode(10);
            root.left = new TreeNode(5);
            int key = 5;

            // Act
            var result = solution.DeleteNode(root, key);

            // Assert
            Assert.IsTrue(IsValidBST(result), $"Failed for {solutionName} - Result is not a valid BST");
            Assert.IsFalse(Contains(result, key), $"Failed for {solutionName} - Key {key} should be deleted");
            Assert.AreEqual(10, result.val, $"Failed for {solutionName} - Root should be 10");
            Assert.AreEqual(1, CountNodes(result), $"Failed for {solutionName} - Should have 1 node left");
        }

        #endregion

        #region Property-Based Tests

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void DeleteNode_PreservesOtherNodes_DeletesCorrectly(IDeleteNodeInABST_450 solution, string solutionName)
        {
            // Verify that all other nodes remain in the tree

            // Arrange
            var root = CreateTree(new int?[] { 4, 2, 6, 1, 3, 5, 7 });
            var originalInorder = InorderTraversal(root);
            int key = 2;

            // Act
            var result = solution.DeleteNode(root, key);

            // Assert
            var newInorder = InorderTraversal(result);
            foreach (int val in originalInorder)
            {
                if (val != key)
                {
                    Assert.IsTrue(newInorder.Contains(val),
                        $"Failed for {solutionName} - Value {val} should still exist after deleting {key}");
                }
            }
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void DeleteNode_NodeCountDecreasesByOne_DeletesCorrectly(IDeleteNodeInABST_450 solution, string solutionName)
        {
            // Verify that node count decreases by exactly one

            // Arrange
            var root = CreateTree(new int?[] { 4, 2, 6, 1, 3, 5, 7 });
            int originalCount = CountNodes(root);
            int key = 6;

            // Act
            var result = solution.DeleteNode(root, key);

            // Assert
            int newCount = CountNodes(result);
            Assert.AreEqual(originalCount - 1, newCount,
                $"Failed for {solutionName} - Node count should decrease by exactly 1");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void DeleteNode_MaintainsBSTProperty_AfterMultipleDeletions(IDeleteNodeInABST_450 solution, string solutionName)
        {
            // Verify that BST property is maintained after multiple deletions

            // Arrange
            var root = CreateTree(new int?[] { 50, 30, 70, 20, 40, 60, 80, 10, 25, 35, 45, 55, 65, 75, 85 });
            int[] keysToDelete = { 20, 40, 60, 80 };

            // Act & Assert
            foreach (int key in keysToDelete)
            {
                root = solution.DeleteNode(root, key);
                Assert.IsTrue(IsValidBST(root),
                    $"Failed for {solutionName} - BST property violated after deleting {key}");
            }
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void DeleteNode_InorderRemainsSorted_AfterDeletion(IDeleteNodeInABST_450 solution, string solutionName)
        {
            // Verify that in-order traversal remains sorted after deletion

            // Arrange
            var root = CreateTree(new int?[] { 50, 30, 70, 20, 40, 60, 80 });
            int key = 30;

            // Act
            var result = solution.DeleteNode(root, key);

            // Assert
            var inorder = InorderTraversal(result);
            var sorted = inorder.OrderBy(x => x).ToList();
            CollectionAssert.AreEqual(sorted, inorder, $"Failed for {solutionName} - In-order traversal should be sorted");
        }

        #endregion

        #region Stress Tests

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void DeleteNode_LargeTree_DeletesCorrectly(IDeleteNodeInABST_450 solution, string solutionName)
        {
            // Delete from a large tree

            // Arrange
            var root = CreateTree(new int?[] {
                50, 25, 75, 12, 37, 62, 87, 6, 18, 31, 43, 56, 68, 81, 93,
                3, 9, 15, 21, 28, 34, 40, 46, 53, 59, 65, 71, 78, 84, 90, 96
            });
            int key = 37;

            // Act
            var result = solution.DeleteNode(root, key);

            // Assert
            Assert.IsTrue(IsValidBST(result), $"Failed for {solutionName} - Result is not a valid BST");
            Assert.IsFalse(Contains(result, key), $"Failed for {solutionName} - Key {key} should be deleted");
            Assert.AreEqual(30, CountNodes(result), $"Failed for {solutionName} - Node count mismatch");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void DeleteNode_DeepTree_DeletesCorrectly(IDeleteNodeInABST_450 solution, string solutionName)
        {
            // Delete from a deep tree

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

            int key = 40;

            // Act
            var result = solution.DeleteNode(root, key);

            // Assert
            Assert.IsTrue(IsValidBST(result), $"Failed for {solutionName} - Result is not a valid BST");
            Assert.IsFalse(Contains(result, key), $"Failed for {solutionName} - Key {key} should be deleted");
        }

        #endregion

        #region Successor/Predecessor Edge Cases

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void DeleteNode_NodeWithSuccessorAsDirectChild_DeletesCorrectly(IDeleteNodeInABST_450 solution, string solutionName)
        {
            // Delete node where in-order successor is direct right child

            // Arrange
            var root = CreateTree(new int?[] { 5, 3, 7, 2, 4, 6, 8 });
            int key = 5; // Successor is 6 (direct right->left)

            // Act
            var result = solution.DeleteNode(root, key);

            // Assert
            Assert.IsTrue(IsValidBST(result), $"Failed for {solutionName} - Result is not a valid BST");
            Assert.IsFalse(Contains(result, key), $"Failed for {solutionName} - Key {key} should be deleted");

            var inorder = InorderTraversal(result);
            CollectionAssert.AreEqual(new[] { 2, 3, 4, 6, 7, 8 }, inorder.ToArray(), $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void DeleteNode_NodeWithSuccessorDeepInRightSubtree_DeletesCorrectly(IDeleteNodeInABST_450 solution, string solutionName)
        {
            // Delete node where successor is deep in right subtree

            // Arrange
            var root = CreateTree(new int?[] { 10, 5, 20, 3, 7, 15, 25, null, null, null, null, 12, 18 });
            int key = 10; // Successor is 12 (deep in right subtree)

            // Act
            var result = solution.DeleteNode(root, key);

            // Assert
            Assert.IsTrue(IsValidBST(result), $"Failed for {solutionName} - Result is not a valid BST");
            Assert.IsFalse(Contains(result, key), $"Failed for {solutionName} - Key {key} should be deleted");

            var inorder = InorderTraversal(result);
            CollectionAssert.AreEqual(new[] { 3, 5, 7, 12, 15, 18, 20, 25 }, inorder.ToArray(), $"Failed for {solutionName}");
        }

        #endregion
    }
}
