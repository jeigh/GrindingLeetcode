using LeetCodeProblems.CSharp.Tree;
using LeetCodeProblems.Interfaces.Medium;
using LeetCodeProblems.Shared;
using LeetCodeProblems.VisualBasic;

namespace GrindingLeetCode.UnitTests.Medium
{
    [TestClass]
    public class InorderSuccessorInBST_285_Tests
    {
        public static IEnumerable<object[]> GetImplementations()
        {
            yield return new object[] { new InorderSuccessorInBST_CSharp_285(), "C#" };
            yield return new object[] { new InOrderSuccessorInBST_VB_285(), "VB" };
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
        /// Finds a node with the specified value in the tree
        /// </summary>
        private TreeNode FindNode(TreeNode root, int val)
        {
            if (root == null) return null;
            if (root.val == val) return root;
            
            TreeNode left = FindNode(root.left, val);
            if (left != null) return left;
            
            return FindNode(root.right, val);
        }

        #endregion

        #region LeetCode Examples

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void InorderSuccessor_Example1_ReturnsCorrectSuccessor(IInorderSuccessorInBST_285 solution, string solutionName)
        {
            // Input: root = [2,1,3], p = 1
            //    2
            //   / \
            //  1   3
            // Output: 2

            // Arrange
            var root = CreateTree(new int?[] { 2, 1, 3 });
            var p = FindNode(root, 1);

            // Act
            var result = solution.InorderSuccessor(root, p);

            // Assert
            Assert.IsNotNull(result, $"Failed for {solutionName}");
            Assert.AreEqual(2, result.val, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void InorderSuccessor_Example2_ReturnsNull(IInorderSuccessorInBST_285 solution, string solutionName)
        {
            // Input: root = [5,3,6,2,4,null,null,1], p = 6
            //       5
            //      / \
            //     3   6
            //    / \
            //   2   4
            //  /
            // 1
            // Output: null (6 has no successor)

            // Arrange
            var root = CreateTree(new int?[] { 5, 3, 6, 2, 4, null, null, 1 });
            var p = FindNode(root, 6);

            // Act
            var result = solution.InorderSuccessor(root, p);

            // Assert
            Assert.IsNull(result, $"Failed for {solutionName}");
        }

        #endregion

        #region Basic Cases

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void InorderSuccessor_NullNode_ReturnsNull(IInorderSuccessorInBST_285 solution, string solutionName)
        {
            // Input: p = null
            // Output: null

            // Arrange
            var root = CreateTree(new int?[] { 2, 1, 3 });

            // Act
            var result = solution.InorderSuccessor(root, null);

            // Assert
            Assert.IsNull(result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void InorderSuccessor_SingleNode_ReturnsNull(IInorderSuccessorInBST_285 solution, string solutionName)
        {
            // Input: root = [5], p = 5
            // Output: null (only node has no successor)

            // Arrange
            var root = new TreeNode(5);

            // Act
            var result = solution.InorderSuccessor(root, root);

            // Assert
            Assert.IsNull(result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void InorderSuccessor_TwoNodesLeftChild_ReturnsRoot(IInorderSuccessorInBST_285 solution, string solutionName)
        {
            // Input: root = [2,1], p = 1
            //    2
            //   /
            //  1
            // Output: 2

            // Arrange
            var root = CreateTree(new int?[] { 2, 1 });
            var p = FindNode(root, 1);

            // Act
            var result = solution.InorderSuccessor(root, p);

            // Assert
            Assert.IsNotNull(result, $"Failed for {solutionName}");
            Assert.AreEqual(2, result.val, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void InorderSuccessor_TwoNodesRightChild_ReturnsNull(IInorderSuccessorInBST_285 solution, string solutionName)
        {
            // Input: root = [1,null,2], p = 2
            //    1
            //     \
            //      2
            // Output: null (2 is largest)

            // Arrange
            var root = CreateTree(new int?[] { 1, null, 2 });
            var p = FindNode(root, 2);

            // Act
            var result = solution.InorderSuccessor(root, p);

            // Assert
            Assert.IsNull(result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void InorderSuccessor_ThreeNodes_LeftToRoot(IInorderSuccessorInBST_285 solution, string solutionName)
        {
            // Input: root = [2,1,3], p = 1
            // Output: 2

            // Arrange
            var root = CreateTree(new int?[] { 2, 1, 3 });
            var p = FindNode(root, 1);

            // Act
            var result = solution.InorderSuccessor(root, p);

            // Assert
            Assert.IsNotNull(result, $"Failed for {solutionName}");
            Assert.AreEqual(2, result.val, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void InorderSuccessor_ThreeNodes_RootToRight(IInorderSuccessorInBST_285 solution, string solutionName)
        {
            // Input: root = [2,1,3], p = 2
            // Output: 3

            // Arrange
            var root = CreateTree(new int?[] { 2, 1, 3 });
            var p = FindNode(root, 2);

            // Act
            var result = solution.InorderSuccessor(root, p);

            // Assert
            Assert.IsNotNull(result, $"Failed for {solutionName}");
            Assert.AreEqual(3, result.val, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void InorderSuccessor_ThreeNodes_RightToNull(IInorderSuccessorInBST_285 solution, string solutionName)
        {
            // Input: root = [2,1,3], p = 3
            // Output: null (3 is largest)

            // Arrange
            var root = CreateTree(new int?[] { 2, 1, 3 });
            var p = FindNode(root, 3);

            // Act
            var result = solution.InorderSuccessor(root, p);

            // Assert
            Assert.IsNull(result, $"Failed for {solutionName}");
        }

        #endregion

        #region Node Has Right Subtree (Case 1)

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void InorderSuccessor_NodeWithRightChild_ReturnsRightChild(IInorderSuccessorInBST_285 solution, string solutionName)
        {
            // Input: root = [2,1,3], p = 1 (but 1 has no right child)
            // Input: root = [3,1,5,null,2,4], p = 3
            //       3
            //      / \
            //     1   5
            //      \ /
            //      2 4
            // Output: 4 (leftmost in right subtree)

            // Arrange
            var root = CreateTree(new int?[] { 3, 1, 5, null, 2, 4 });
            var p = FindNode(root, 3);

            // Act
            var result = solution.InorderSuccessor(root, p);

            // Assert
            Assert.IsNotNull(result, $"Failed for {solutionName}");
            Assert.AreEqual(4, result.val, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void InorderSuccessor_NodeWithRightSubtree_ReturnsLeftmost(IInorderSuccessorInBST_285 solution, string solutionName)
        {
            // Input: root = [10,5,15,3,7,12,20,1,4,6,9], p = 5
            //           10
            //          /  \
            //         5    15
            //        / \   / \
            //       3   7 12 20
            //      / \ / \
            //     1  4 6  9
            // Output: 6 (leftmost in 5's right subtree)

            // Arrange
            var root = CreateTree(new int?[] { 10, 5, 15, 3, 7, 12, 20, 1, 4, 6, 9 });
            var p = FindNode(root, 5);

            // Act
            var result = solution.InorderSuccessor(root, p);

            // Assert
            Assert.IsNotNull(result, $"Failed for {solutionName}");
            Assert.AreEqual(6, result.val, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void InorderSuccessor_NodeWithOnlyRightChild_ReturnsRightChild(IInorderSuccessorInBST_285 solution, string solutionName)
        {
            // Input: root = [2,1,4,null,null,3], p = 2
            //       2
            //      / \
            //     1   4
            //        /
            //       3
            // Output: 3

            // Arrange
            var root = CreateTree(new int?[] { 2, 1, 4, null, null, 3 });
            var p = FindNode(root, 2);

            // Act
            var result = solution.InorderSuccessor(root, p);

            // Assert
            Assert.IsNotNull(result, $"Failed for {solutionName}");
            Assert.AreEqual(3, result.val, $"Failed for {solutionName}");
        }

        #endregion

        #region Node Has No Right Subtree (Case 2)

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void InorderSuccessor_NoRightSubtree_SuccessorIsParent(IInorderSuccessorInBST_285 solution, string solutionName)
        {
            // Input: root = [5,3,7,2,4], p = 4
            //       5
            //      / \
            //     3   7
            //    / \
            //   2   4
            // Output: 5 (first ancestor where p is in left subtree)

            // Arrange
            var root = CreateTree(new int?[] { 5, 3, 7, 2, 4 });
            var p = FindNode(root, 4);

            // Act
            var result = solution.InorderSuccessor(root, p);

            // Assert
            Assert.IsNotNull(result, $"Failed for {solutionName}");
            Assert.AreEqual(5, result.val, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void InorderSuccessor_NoRightSubtree_SuccessorIsAncestor(IInorderSuccessorInBST_285 solution, string solutionName)
        {
            // Input: root = [10,5,15,3,7,12,20,1,4], p = 4
            //           10
            //          /  \
            //         5    15
            //        / \   / \
            //       3   7 12 20
            //      / \
            //     1   4
            // Output: 5 (ancestor where 4 is in left subtree)

            // Arrange
            var root = CreateTree(new int?[] { 10, 5, 15, 3, 7, 12, 20, 1, 4 });
            var p = FindNode(root, 4);

            // Act
            var result = solution.InorderSuccessor(root, p);

            // Assert
            Assert.IsNotNull(result, $"Failed for {solutionName}");
            Assert.AreEqual(5, result.val, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void InorderSuccessor_NoRightSubtree_DeepInLeftSubtree(IInorderSuccessorInBST_285 solution, string solutionName)
        {
            // Input: root = [10,5,15,3,7,12,20,1], p = 1
            //           10
            //          /  \
            //         5    15
            //        / \   / \
            //       3   7 12 20
            //      /
            //     1
            // Output: 3

            // Arrange
            var root = CreateTree(new int?[] { 10, 5, 15, 3, 7, 12, 20, 1 });
            var p = FindNode(root, 1);

            // Act
            var result = solution.InorderSuccessor(root, p);

            // Assert
            Assert.IsNotNull(result, $"Failed for {solutionName}");
            Assert.AreEqual(3, result.val, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void InorderSuccessor_RightmostNode_ReturnsNull(IInorderSuccessorInBST_285 solution, string solutionName)
        {
            // Input: root = [10,5,15,3,7,12,20], p = 20
            //           10
            //          /  \
            //         5    15
            //        / \   / \
            //       3   7 12 20
            // Output: null (20 is the largest node)

            // Arrange
            var root = CreateTree(new int?[] { 10, 5, 15, 3, 7, 12, 20 });
            var p = FindNode(root, 20);

            // Act
            var result = solution.InorderSuccessor(root, p);

            // Assert
            Assert.IsNull(result, $"Failed for {solutionName}");
        }

        #endregion

        #region Skewed Trees

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void InorderSuccessor_LeftSkewed_ReturnsCorrectSuccessor(IInorderSuccessorInBST_285 solution, string solutionName)
        {
            // Input: root = [5,4,null,3,null,2,null,1], p = 2
            //      5
            //     /
            //    4
            //   /
            //  3
            // /
            //2
            ///
            //1
            // Output: 3

            // Arrange
            var root = CreateTree(new int?[] { 5, 4, null, 3, null, 2, null, 1 });
            var p = FindNode(root, 2);

            // Act
            var result = solution.InorderSuccessor(root, p);

            // Assert
            Assert.IsNotNull(result, $"Failed for {solutionName}");
            Assert.AreEqual(3, result.val, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void InorderSuccessor_RightSkewed_ReturnsCorrectSuccessor(IInorderSuccessorInBST_285 solution, string solutionName)
        {
            // Input: root = [1,null,2,null,3,null,4,null,5], p = 3
            // 1
            //  \
            //   2
            //    \
            //     3
            //      \
            //       4
            //        \
            //         5
            // Output: 4

            // Arrange
            var root = CreateTree(new int?[] { 1, null, 2, null, 3, null, 4, null, 5 });
            var p = FindNode(root, 3);

            // Act
            var result = solution.InorderSuccessor(root, p);

            // Assert
            Assert.IsNotNull(result, $"Failed for {solutionName}");
            Assert.AreEqual(4, result.val, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void InorderSuccessor_LeftSkewed_Largest_ReturnsNull(IInorderSuccessorInBST_285 solution, string solutionName)
        {
            // Input: root = [5,4,null,3,null,2,null,1], p = 5
            // Output: null (5 is root and largest)

            // Arrange
            var root = CreateTree(new int?[] { 5, 4, null, 3, null, 2, null, 1 });
            var p = FindNode(root, 5);

            // Act
            var result = solution.InorderSuccessor(root, p);

            // Assert
            Assert.IsNull(result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void InorderSuccessor_RightSkewed_Largest_ReturnsNull(IInorderSuccessorInBST_285 solution, string solutionName)
        {
            // Input: root = [1,null,2,null,3,null,4,null,5], p = 5
            // Output: null (5 is largest)

            // Arrange
            var root = CreateTree(new int?[] { 1, null, 2, null, 3, null, 4, null, 5 });
            var p = FindNode(root, 5);

            // Act
            var result = solution.InorderSuccessor(root, p);

            // Assert
            Assert.IsNull(result, $"Failed for {solutionName}");
        }

        #endregion

        #region Balanced Trees

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void InorderSuccessor_BalancedTree_RootSuccessor(IInorderSuccessorInBST_285 solution, string solutionName)
        {
            // Input: root = [4,2,6,1,3,5,7], p = 4
            //       4
            //      / \
            //     2   6
            //    / \ / \
            //   1  3 5  7
            // Output: 5 (leftmost in right subtree)

            // Arrange
            var root = CreateTree(new int?[] { 4, 2, 6, 1, 3, 5, 7 });
            var p = FindNode(root, 4);

            // Act
            var result = solution.InorderSuccessor(root, p);

            // Assert
            Assert.IsNotNull(result, $"Failed for {solutionName}");
            Assert.AreEqual(5, result.val, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void InorderSuccessor_BalancedTree_VariousNodes(IInorderSuccessorInBST_285 solution, string solutionName)
        {
            // Test multiple nodes in balanced tree
            // Input: root = [8,4,12,2,6,10,14,1,3,5,7,9,11,13,15]
            //               8
            //             /   \
            //           4       12
            //         /  \     /  \
            //        2    6   10   14
            //       / \  / \ / \  / \
            //      1  3 5  7 9 11 13 15

            // Arrange
            var root = CreateTree(new int?[] { 8, 4, 12, 2, 6, 10, 14, 1, 3, 5, 7, 9, 11, 13, 15 });

            // Test cases: (node, expected successor)
            var testCases = new[]
            {
                (1, 2),
                (2, 3),
                (3, 4),
                (4, 5),
                (5, 6),
                (6, 7),
                (7, 8),
                (8, 9),
                (9, 10),
                (10, 11),
                (11, 12),
                (12, 13),
                (13, 14),
                (14, 15),
                (15, -1) // No successor
            };

            foreach (var (nodeVal, expectedSuccessorVal) in testCases)
            {
                // Act
                var p = FindNode(root, nodeVal);
                var result = solution.InorderSuccessor(root, p);

                // Assert
                if (expectedSuccessorVal == -1)
                {
                    Assert.IsNull(result, $"Failed for {solutionName}: Node {nodeVal} should have no successor");
                }
                else
                {
                    Assert.IsNotNull(result, $"Failed for {solutionName}: Node {nodeVal} should have successor");
                    Assert.AreEqual(expectedSuccessorVal, result.val, 
                        $"Failed for {solutionName}: Node {nodeVal} successor should be {expectedSuccessorVal}");
                }
            }
        }

        #endregion

        #region Edge Cases - Values

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void InorderSuccessor_NegativeValues_ReturnsCorrectSuccessor(IInorderSuccessorInBST_285 solution, string solutionName)
        {
            // Input: root = [0,-2,2,-3,-1,1,3], p = -2
            //        0
            //       / \
            //     -2   2
            //     / \ / \
            //   -3 -1 1  3
            // Output: -1

            // Arrange
            var root = CreateTree(new int?[] { 0, -2, 2, -3, -1, 1, 3 });
            var p = FindNode(root, -2);

            // Act
            var result = solution.InorderSuccessor(root, p);

            // Assert
            Assert.IsNotNull(result, $"Failed for {solutionName}");
            Assert.AreEqual(-1, result.val, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void InorderSuccessor_AllNegativeValues_ReturnsCorrectSuccessor(IInorderSuccessorInBST_285 solution, string solutionName)
        {
            // Input: root = [-4,-6,-2,-7,-5,-3,-1], p = -5
            //       -4
            //       / \
            //     -6  -2
            //     / \ / \
            //   -7 -5-3 -1
            // Output: -4

            // Arrange
            var root = CreateTree(new int?[] { -4, -6, -2, -7, -5, -3, -1 });
            var p = FindNode(root, -5);

            // Act
            var result = solution.InorderSuccessor(root, p);

            // Assert
            Assert.IsNotNull(result, $"Failed for {solutionName}");
            Assert.AreEqual(-4, result.val, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void InorderSuccessor_LargeValues_ReturnsCorrectSuccessor(IInorderSuccessorInBST_285 solution, string solutionName)
        {
            // Input: root = [10000,5000,15000], p = 5000
            // Output: 10000

            // Arrange
            var root = CreateTree(new int?[] { 10000, 5000, 15000 });
            var p = FindNode(root, 5000);

            // Act
            var result = solution.InorderSuccessor(root, p);

            // Assert
            Assert.IsNotNull(result, $"Failed for {solutionName}");
            Assert.AreEqual(10000, result.val, $"Failed for {solutionName}");
        }

        #endregion

        #region Complex Scenarios

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void InorderSuccessor_ComplexTree_MultipleAncestors(IInorderSuccessorInBST_285 solution, string solutionName)
        {
            // Deep node requiring traversal through multiple ancestors
            // Input: root = [20,10,30,5,15,25,35,3,7,12,18], p = 7
            //           20
            //          /  \
            //        10    30
            //       / \    / \
            //      5  15  25 35
            //     / \ / \
            //    3  7 12 18
            // Output: 10 (first ancestor where 7 is in left subtree)

            // Arrange
            var root = CreateTree(new int?[] { 20, 10, 30, 5, 15, 25, 35, 3, 7, 12, 18 });
            var p = FindNode(root, 7);

            // Act
            var result = solution.InorderSuccessor(root, p);

            // Assert
            Assert.IsNotNull(result, $"Failed for {solutionName}");
            Assert.AreEqual(10, result.val, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void InorderSuccessor_SparseTree_ReturnsCorrectSuccessor(IInorderSuccessorInBST_285 solution, string solutionName)
        {
            // Sparse tree with many nulls
            // Input: root = [8,4,12,null,6,10,null,5,7], p = 5
            //       8
            //      / \
            //     4   12
            //      \ /
            //      6 10
            //     / \
            //    5   7
            // Output: 6

            // Arrange
            var root = CreateTree(new int?[] { 8, 4, 12, null, 6, 10, null, 5, 7 });
            var p = FindNode(root, 5);

            // Act
            var result = solution.InorderSuccessor(root, p);

            // Assert
            Assert.IsNotNull(result, $"Failed for {solutionName}");
            Assert.AreEqual(6, result.val, $"Failed for {solutionName}");
        }

        #endregion

        #region Root Node Cases

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void InorderSuccessor_RootWithRightSubtree_ReturnsLeftmostInRight(IInorderSuccessorInBST_285 solution, string solutionName)
        {
            // Input: root = [5,3,8,1,4,7,10,null,null,null,null,6], p = 5
            //       5
            //      / \
            //     3   8
            //    / \ / \
            //   1  4 7 10
            //        /
            //       6
            // Output: 6 (leftmost in right subtree)

            // Arrange
            var root = CreateTree(new int?[] { 5, 3, 8, 1, 4, 7, 10, null, null, null, null, 6 });
            var p = FindNode(root, 5);

            // Act
            var result = solution.InorderSuccessor(root, p);

            // Assert
            Assert.IsNotNull(result, $"Failed for {solutionName}");
            Assert.AreEqual(6, result.val, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void InorderSuccessor_RootWithOnlyLeftSubtree_ReturnsNull(IInorderSuccessorInBST_285 solution, string solutionName)
        {
            // Input: root = [5,3,null,1,4], p = 5
            //       5
            //      /
            //     3
            //    / \
            //   1   4
            // Output: null (root is largest)

            // Arrange
            var root = CreateTree(new int?[] { 5, 3, null, 1, 4 });
            var p = FindNode(root, 5);

            // Act
            var result = solution.InorderSuccessor(root, p);

            // Assert
            Assert.IsNull(result, $"Failed for {solutionName}");
        }

        #endregion
    }
}
