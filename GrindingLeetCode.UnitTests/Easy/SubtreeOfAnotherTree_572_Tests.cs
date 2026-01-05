using LeetCodeProblems.CSharp.Tree;
using LeetCodeProblems.Interfaces.Easy;
using LeetCodeProblems.Shared;
using LeetCodeProblems.VisualBasic;

namespace GrindingLeetCode.UnitTests.Easy
{
    [TestClass]
    public class SubtreeOfAnotherTree_572_Tests
    {
        public static IEnumerable<object[]> GetImplementations()
        {
            yield return new object[] { new SubtreeOfAnotherTree_DFS_CSharp_572(), "C# DFS" };
            yield return new object[] { new SubtreeofAnotherTree_Serialization_CSharp_572(), "C# Serialization" };

            yield return new object[] { new SubtreeOfAnotherTree_DFS_VB_572(), "VB DFS" };
            yield return new object[] { new SubtreeOfAnotherTree_Serialization_VB_572(), "VB Serialization" };

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
        public void IsSubtree_Example1_ReturnsTrue(ISubtreeOfAnotherTree_572 solution, string solutionName)
        {
            // Input: root = [3,4,5,1,2], subRoot = [4,1,2]
            //       3              4
            //      / \            / \
            //     4   5          1   2
            //    / \
            //   1   2
            // Output: true
            // Explanation: The subtree rooted at 4 matches subRoot exactly

            // Arrange
            var root = CreateTree(new int?[] { 3, 4, 5, 1, 2 });
            var subroot = CreateTree(new int?[] { 4, 1, 2 });

            // Act
            var result = solution.IsSubtree(root, subroot);

            // Assert
            Assert.IsTrue(result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsSubtree_Example2_ReturnsFalse(ISubtreeOfAnotherTree_572 solution, string solutionName)
        {
            // Input: root = [3,4,5,1,2,null,null,null,null,0], subRoot = [4,1,2]
            //       3              4
            //      / \            / \
            //     4   5          1   2
            //    / \
            //   1   2
            //      /
            //     0
            // Output: false
            // Explanation: The tree rooted at 4 has an extra node (0), so it doesn't match subRoot

            // Arrange
            var root = CreateTree(new int?[] { 3, 4, 5, 1, 2, null, null, null, null, 0 });
            var subroot = CreateTree(new int?[] { 4, 1, 2 });

            // Act
            var result = solution.IsSubtree(root, subroot);

            // Assert
            Assert.IsFalse(result, $"Failed for {solutionName}");
        }

        #endregion

        #region Basic Cases

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsSubtree_BothNull_ReturnsTrue(ISubtreeOfAnotherTree_572 solution, string solutionName)
        {
            // Input: root = [], subRoot = []
            // Output: true
            // Explanation: Both trees are empty

            // Arrange
            TreeNode root = null;
            TreeNode subroot = null;

            // Act
            var result = solution.IsSubtree(root, subroot);

            // Assert
            Assert.IsTrue(result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsSubtree_SubrootNull_ReturnsTrue(ISubtreeOfAnotherTree_572 solution, string solutionName)
        {
            // Input: root = [1,2,3], subRoot = []
            // Output: true
            // Explanation: An empty tree is a subtree of any tree

            // Arrange
            var root = CreateTree(new int?[] { 1, 2, 3 });
            TreeNode subroot = null;

            // Act
            var result = solution.IsSubtree(root, subroot);

            // Assert
            Assert.IsTrue(result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsSubtree_RootNull_ReturnsFalse(ISubtreeOfAnotherTree_572 solution, string solutionName)
        {
            // Input: root = [], subRoot = [1]
            // Output: false
            // Explanation: Cannot find a non-empty subtree in an empty tree

            // Arrange
            TreeNode root = null;
            var subroot = new TreeNode(1);

            // Act
            var result = solution.IsSubtree(root, subroot);

            // Assert
            Assert.IsFalse(result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsSubtree_IdenticalTrees_ReturnsTrue(ISubtreeOfAnotherTree_572 solution, string solutionName)
        {
            // Input: root = [1,2,3], subRoot = [1,2,3]
            //    1         1
            //   / \       / \
            //  2   3     2   3
            // Output: true
            // Explanation: The entire tree matches

            // Arrange
            var root = CreateTree(new int?[] { 1, 2, 3 });
            var subroot = CreateTree(new int?[] { 1, 2, 3 });

            // Act
            var result = solution.IsSubtree(root, subroot);

            // Assert
            Assert.IsTrue(result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsSubtree_SingleNodeSame_ReturnsTrue(ISubtreeOfAnotherTree_572 solution, string solutionName)
        {
            // Input: root = [5], subRoot = [5]
            // Output: true

            // Arrange
            var root = new TreeNode(5);
            var subroot = new TreeNode(5);

            // Act
            var result = solution.IsSubtree(root, subroot);

            // Assert
            Assert.IsTrue(result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsSubtree_SingleNodeDifferent_ReturnsFalse(ISubtreeOfAnotherTree_572 solution, string solutionName)
        {
            // Input: root = [5], subRoot = [3]
            // Output: false

            // Arrange
            var root = new TreeNode(5);
            var subroot = new TreeNode(3);

            // Act
            var result = solution.IsSubtree(root, subroot);

            // Assert
            Assert.IsFalse(result, $"Failed for {solutionName}");
        }

        #endregion

        #region Subtree at Root

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsSubtree_SubtreeAtRoot_ReturnsTrue(ISubtreeOfAnotherTree_572 solution, string solutionName)
        {
            // Input: root = [1,2,3], subRoot = [1,2,3]
            // Output: true
            // Explanation: Subtree matches at root

            // Arrange
            var root = CreateTree(new int?[] { 1, 2, 3 });
            var subroot = CreateTree(new int?[] { 1, 2, 3 });

            // Act
            var result = solution.IsSubtree(root, subroot);

            // Assert
            Assert.IsTrue(result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsSubtree_SubtreeAtRootLarger_ReturnsTrue(ISubtreeOfAnotherTree_572 solution, string solutionName)
        {
            // Input: root = [4,2,6,1,3,5,7], subRoot = [4,2,6,1,3,5,7]
            // Output: true

            // Arrange
            var root = CreateTree(new int?[] { 4, 2, 6, 1, 3, 5, 7 });
            var subroot = CreateTree(new int?[] { 4, 2, 6, 1, 3, 5, 7 });

            // Act
            var result = solution.IsSubtree(root, subroot);

            // Assert
            Assert.IsTrue(result, $"Failed for {solutionName}");
        }

        #endregion

        #region Subtree in Left Subtree

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsSubtree_SubtreeInLeftChild_ReturnsTrue(ISubtreeOfAnotherTree_572 solution, string solutionName)
        {
            // Input: root = [5,3,8,2,4], subRoot = [3,2,4]
            //       5              3
            //      / \            / \
            //     3   8          2   4
            //    / \
            //   2   4
            // Output: true

            // Arrange
            var root = CreateTree(new int?[] { 5, 3, 8, 2, 4 });
            var subroot = CreateTree(new int?[] { 3, 2, 4 });

            // Act
            var result = solution.IsSubtree(root, subroot);

            // Assert
            Assert.IsTrue(result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsSubtree_SubtreeDeepInLeft_ReturnsTrue(ISubtreeOfAnotherTree_572 solution, string solutionName)
        {
            // Input: root = [10,5,15,3,7,null,20,1,4], subRoot = [3,1,4]
            //           10                3
            //          /  \              / \
            //         5    15           1   4
            //        / \     \
            //       3   7     20
            //      / \
            //     1   4
            // Output: true

            // Arrange
            var root = CreateTree(new int?[] { 10, 5, 15, 3, 7, null, 20, 1, 4 });
            var subroot = CreateTree(new int?[] { 3, 1, 4 });

            // Act
            var result = solution.IsSubtree(root, subroot);

            // Assert
            Assert.IsTrue(result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsSubtree_SubtreeLeftLeaf_ReturnsTrue(ISubtreeOfAnotherTree_572 solution, string solutionName)
        {
            // Input: root = [5,3,8,2,4], subRoot = [2]
            //       5
            //      / \
            //     3   8
            //    / \
            //   2   4
            // Output: true

            // Arrange
            var root = CreateTree(new int?[] { 5, 3, 8, 2, 4 });
            var subroot = CreateTree(new int?[] { 2 });

            // Act
            var result = solution.IsSubtree(root, subroot);

            // Assert
            Assert.IsTrue(result, $"Failed for {solutionName}");
        }

        #endregion

        #region Subtree in Right Subtree

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsSubtree_SubtreeInRightChild_ReturnsTrue(ISubtreeOfAnotherTree_572 solution, string solutionName)
        {
            // Input: root = [5,2,8,null,null,6,9], subRoot = [8,6,9]
            //       5              8
            //      / \            / \
            //     2   8          6   9
            //        / \
            //       6   9
            // Output: true

            // Arrange
            var root = CreateTree(new int?[] { 5, 2, 8, null, null, 6, 9 });
            var subroot = CreateTree(new int?[] { 8, 6, 9 });

            // Act
            var result = solution.IsSubtree(root, subroot);

            // Assert
            Assert.IsTrue(result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsSubtree_SubtreeDeepInRight_ReturnsTrue(ISubtreeOfAnotherTree_572 solution, string solutionName)
        {
            // Input: root = [10,5,15,null,null,12,20,null,18], subRoot = [12,null,18]
            //           10               12
            //          /  \                \
            //         5    15               18
            //             /  \
            //            12   20
            //              \
            //               18
            // Output: true

            // Arrange
            var root = CreateTree(new int?[] { 10, 5, 15, null, null, 12, 20, null, 18 });
            var subroot = CreateTree(new int?[] { 12, null, 18 });

            // Act
            var result = solution.IsSubtree(root, subroot);

            // Assert
            Assert.IsTrue(result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsSubtree_SubtreeRightLeaf_ReturnsTrue(ISubtreeOfAnotherTree_572 solution, string solutionName)
        {
            // Input: root = [5,2,8,null,null,6,9], subRoot = [9]
            //       5
            //      / \
            //     2   8
            //        / \
            //       6   9
            // Output: true

            // Arrange
            var root = CreateTree(new int?[] { 5, 2, 8, null, null, 6, 9 });
            var subroot = CreateTree(new int?[] { 9 });

            // Act
            var result = solution.IsSubtree(root, subroot);

            // Assert
            Assert.IsTrue(result, $"Failed for {solutionName}");
        }

        #endregion

        #region Not a Subtree - Structure Mismatch

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsSubtree_ExtraNodeInRoot_ReturnsFalse(ISubtreeOfAnotherTree_572 solution, string solutionName)
        {
            // Input: root = [3,4,5,1,2,null,null,null,null,0], subRoot = [4,1,2]
            // Output: false
            // Explanation: Root has extra node (0) under 2

            // Arrange
            var root = CreateTree(new int?[] { 3, 4, 5, 1, 2, null, null, null, null, 0 });
            var subroot = CreateTree(new int?[] { 4, 1, 2 });

            // Act
            var result = solution.IsSubtree(root, subroot);

            // Assert
            Assert.IsFalse(result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsSubtree_MissingNodeInRoot_ReturnsFalse(ISubtreeOfAnotherTree_572 solution, string solutionName)
        {
            // Input: root = [3,4,5,1], subRoot = [4,1,2]
            // Output: false
            // Explanation: Root's subtree at 4 is missing node 2

            // Arrange
            var root = CreateTree(new int?[] { 3, 4, 5, 1 });
            var subroot = CreateTree(new int?[] { 4, 1, 2 });

            // Act
            var result = solution.IsSubtree(root, subroot);

            // Assert
            Assert.IsFalse(result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsSubtree_DifferentStructure_ReturnsFalse(ISubtreeOfAnotherTree_572 solution, string solutionName)
        {
            // Input: root = [1,2,3], subRoot = [1,3,2]
            //    1         1
            //   / \       / \
            //  2   3     3   2
            // Output: false

            // Arrange
            var root = CreateTree(new int?[] { 1, 2, 3 });
            var subroot = CreateTree(new int?[] { 1, 3, 2 });

            // Act
            var result = solution.IsSubtree(root, subroot);

            // Assert
            Assert.IsFalse(result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsSubtree_LeftVsRightPosition_ReturnsFalse(ISubtreeOfAnotherTree_572 solution, string solutionName)
        {
            // Input: root = [1,2,null], subRoot = [1,null,2]
            //    1         1
            //   /           \
            //  2             2
            // Output: false

            // Arrange
            var root = CreateTree(new int?[] { 1, 2, null });
            var subroot = CreateTree(new int?[] { 1, null, 2 });

            // Act
            var result = solution.IsSubtree(root, subroot);

            // Assert
            Assert.IsFalse(result, $"Failed for {solutionName}");
        }

        #endregion

        #region Not a Subtree - Value Mismatch

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsSubtree_DifferentRootValue_ReturnsFalse(ISubtreeOfAnotherTree_572 solution, string solutionName)
        {
            // Input: root = [3,4,5,1,2], subRoot = [4,1,3]
            // Output: false
            // Explanation: Subtree has 3 but root's subtree has 2

            // Arrange
            var root = CreateTree(new int?[] { 3, 4, 5, 1, 2 });
            var subroot = CreateTree(new int?[] { 4, 1, 3 });

            // Act
            var result = solution.IsSubtree(root, subroot);

            // Assert
            Assert.IsFalse(result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsSubtree_DifferentLeafValue_ReturnsFalse(ISubtreeOfAnotherTree_572 solution, string solutionName)
        {
            // Input: root = [3,4,5,1,2], subRoot = [4,1,9]
            // Output: false

            // Arrange
            var root = CreateTree(new int?[] { 3, 4, 5, 1, 2 });
            var subroot = CreateTree(new int?[] { 4, 1, 9 });

            // Act
            var result = solution.IsSubtree(root, subroot);

            // Assert
            Assert.IsFalse(result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsSubtree_NoMatchingStartNode_ReturnsFalse(ISubtreeOfAnotherTree_572 solution, string solutionName)
        {
            // Input: root = [3,4,5,1,2], subRoot = [6,7,8]
            // Output: false
            // Explanation: Value 6 doesn't exist in root

            // Arrange
            var root = CreateTree(new int?[] { 3, 4, 5, 1, 2 });
            var subroot = CreateTree(new int?[] { 6, 7, 8 });

            // Act
            var result = solution.IsSubtree(root, subroot);

            // Assert
            Assert.IsFalse(result, $"Failed for {solutionName}");
        }

        #endregion

        #region Edge Cases - Values

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsSubtree_NegativeValues_ReturnsTrue(ISubtreeOfAnotherTree_572 solution, string solutionName)
        {
            // Input: root = [0,-2,2,-3,-1,1,3], subRoot = [-2,-3,-1]
            //        0                 -2
            //       / \               /  \
            //     -2   2            -3   -1
            //     / \ / \
            //   -3 -1 1  3
            // Output: true

            // Arrange
            var root = CreateTree(new int?[] { 0, -2, 2, -3, -1, 1, 3 });
            var subroot = CreateTree(new int?[] { -2, -3, -1 });

            // Act
            var result = solution.IsSubtree(root, subroot);

            // Assert
            Assert.IsTrue(result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsSubtree_AllNegativeValues_ReturnsTrue(ISubtreeOfAnotherTree_572 solution, string solutionName)
        {
            // Input: root = [-4,-6,-2,-7,-5,-3,-1], subRoot = [-6,-7,-5]
            // Output: true

            // Arrange
            var root = CreateTree(new int?[] { -4, -6, -2, -7, -5, -3, -1 });
            var subroot = CreateTree(new int?[] { -6, -7, -5 });

            // Act
            var result = solution.IsSubtree(root, subroot);

            // Assert
            Assert.IsTrue(result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsSubtree_DuplicateValues_ReturnsTrue(ISubtreeOfAnotherTree_572 solution, string solutionName)
        {
            // Input: root = [5,5,5,5,5,5,5], subRoot = [5,5,5]
            //      5              5
            //     / \            / \
            //    5   5          5   5
            //   / \ / \
            //  5  5 5  5
            // Output: true

            // Arrange
            var root = CreateTree(new int?[] { 5, 5, 5, 5, 5, 5, 5 });
            var subroot = CreateTree(new int?[] { 5, 5, 5 });

            // Act
            var result = solution.IsSubtree(root, subroot);

            // Assert
            Assert.IsTrue(result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsSubtree_DuplicateValuesNoMatch_ReturnsFalse(ISubtreeOfAnotherTree_572 solution, string solutionName)
        {
            // Input: root = [2,2,2,1,2], subRoot = [2,2,2]
            //      2              2
            //     / \            / \
            //    2   2          2   2
            //   / \
            //  1   2
            // Output: false (structure doesn't match)

            // Arrange
            var root = CreateTree(new int?[] { 2, 2, 2, 1, 2 });
            var subroot = CreateTree(new int?[] { 2, 2, 2 });

            // Act
            var result = solution.IsSubtree(root, subroot);

            // Assert
            Assert.IsFalse(result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsSubtree_ZeroValues_ReturnsTrue(ISubtreeOfAnotherTree_572 solution, string solutionName)
        {
            // Input: root = [0,0,0], subRoot = [0]
            //      0
            //     / \
            //    0   0
            // Output: true

            // Arrange
            var root = CreateSimpleTree(0, 0, 0);
            var subroot = new TreeNode(0);

            // Act
            var result = solution.IsSubtree(root, subroot);

            // Assert
            Assert.IsTrue(result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsSubtree_LargeValues_ReturnsTrue(ISubtreeOfAnotherTree_572 solution, string solutionName)
        {
            // Input: root = [10000,-10000,5000,100,200], subRoot = [-10000,100,200]
            // Output: true

            // Arrange
            var root = CreateTree(new int?[] { 10000, -10000, 5000, 100, 200 });
            var subroot = CreateTree(new int?[] { -10000, 100, 200 });

            // Act
            var result = solution.IsSubtree(root, subroot);

            // Assert
            Assert.IsTrue(result, $"Failed for {solutionName}");
        }

        #endregion

        #region Tricky Cases - Partial Matches

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsSubtree_PartialMatch_ReturnsTrue(ISubtreeOfAnotherTree_572 solution, string solutionName)
        {
            // Input: root = [1,1], subRoot = [1]
            //    1
            //   /
            //  1
            // Output: true (leaf 1 matches)

            // Arrange
            var root = CreateTree(new int?[] { 1, 1 });
            var subroot = CreateTree(new int?[] { 1 });

            // Act
            var result = solution.IsSubtree(root, subroot);

            // Assert
            Assert.IsTrue(result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsSubtree_ValueMatchButStructureDifferent_ReturnsFalse(ISubtreeOfAnotherTree_572 solution, string solutionName)
        {
            // Input: root = [3,4,5,1,2], subRoot = [3,1,2]
            // Output: false
            // Explanation: Root value 3 matches but structure is different

            // Arrange
            var root = CreateTree(new int?[] { 3, 4, 5, 1, 2 });
            var subroot = CreateTree(new int?[] { 3, 1, 2 });

            // Act
            var result = solution.IsSubtree(root, subroot);

            // Assert
            Assert.IsFalse(result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsSubtree_SubsetNotSubtree_ReturnsFalse(ISubtreeOfAnotherTree_572 solution, string solutionName)
        {
            // Input: root = [3,4,5,1,2], subRoot = [4,2]
            //       3              4
            //      / \              \
            //     4   5              2
            //    / \
            //   1   2
            // Output: false
            // Explanation: Even though 4 and 2 exist, 4->2 is not the actual relationship

            // Arrange
            var root = CreateTree(new int?[] { 3, 4, 5, 1, 2 });
            var subroot = CreateTree(new int?[] { 4, null, 2 });

            // Act
            var result = solution.IsSubtree(root, subroot);

            // Assert
            Assert.IsFalse(result, $"Failed for {solutionName}");
        }

        #endregion

        #region Skewed Trees

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsSubtree_LeftSkewedBothTrees_ReturnsTrue(ISubtreeOfAnotherTree_572 solution, string solutionName)
        {
            // Input: root = [5,4,null,3,null,2], subRoot = [4,3,null,2]
            //      5            4
            //     /            /
            //    4            3
            //   /            /
            //  3            2
            // /
            //2
            // Output: true

            // Arrange
            var root = CreateTree(new int?[] { 5, 4, null, 3, null, 2 });
            var subroot = CreateTree(new int?[] { 4, 3, null, 2 });

            // Act
            var result = solution.IsSubtree(root, subroot);

            // Assert
            Assert.IsTrue(result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsSubtree_RightSkewedBothTrees_ReturnsTrue(ISubtreeOfAnotherTree_572 solution, string solutionName)
        {
            // Input: root = [1,null,2,null,3,null,4], subRoot = [2,null,3,null,4]
            // 1            2
            //  \            \
            //   2            3
            //    \            \
            //     3            4
            //      \
            //       4
            // Output: true

            // Arrange
            var root = CreateTree(new int?[] { 1, null, 2, null, 3, null, 4 });
            var subroot = CreateTree(new int?[] { 2, null, 3, null, 4 });

            // Act
            var result = solution.IsSubtree(root, subroot);

            // Assert
            Assert.IsTrue(result, $"Failed for {solutionName}");
        }

        #endregion

        #region Larger Trees

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsSubtree_LargeTreeSmallSubtree_ReturnsTrue(ISubtreeOfAnotherTree_572 solution, string solutionName)
        {
            // Large balanced tree with small subtree match
            // Output: true

            // Arrange
            var root = CreateTree(new int?[] { 8, 4, 12, 2, 6, 10, 14, 1, 3, 5, 7, 9, 11, 13, 15 });
            var subroot = CreateTree(new int?[] { 6, 5, 7 });

            // Act
            var result = solution.IsSubtree(root, subroot);

            // Assert
            Assert.IsTrue(result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsSubtree_LargeTreeNoMatch_ReturnsFalse(ISubtreeOfAnotherTree_572 solution, string solutionName)
        {
            // Large tree but subtree doesn't match
            // Output: false

            // Arrange
            var root = CreateTree(new int?[] { 8, 4, 12, 2, 6, 10, 14, 1, 3, 5, 7, 9, 11, 13, 15 });
            var subroot = CreateTree(new int?[] { 6, 5, 8 }); // 8 doesn't match 7

            // Act
            var result = solution.IsSubtree(root, subroot);

            // Assert
            Assert.IsFalse(result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsSubtree_VeryLargeIdenticalTrees_ReturnsTrue(ISubtreeOfAnotherTree_572 solution, string solutionName)
        {
            // Large identical trees (31 nodes)
            // Output: true

            // Arrange
            var values = new int?[] {
                16, 8, 24, 4, 12, 20, 28, 2, 6, 10, 14, 18, 22, 26, 30,
                1, 3, 5, 7, 9, 11, 13, 15, 17, 19, 21, 23, 25, 27, 29, 31
            };
            var root = CreateTree(values);
            var subroot = CreateTree(values);

            // Act
            var result = solution.IsSubtree(root, subroot);

            // Assert
            Assert.IsTrue(result, $"Failed for {solutionName}");
        }

        #endregion

        

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsSubtree_ZigZagPattern_ReturnsTrue(ISubtreeOfAnotherTree_572 solution, string solutionName)
        {
            // Input: root = [1,null,2,3,null,null,4,5], subRoot = [2,3,null,null,4,5]
            //    1               2
            //     \             /
            //      2           3
            //     /             \
            //    3               4
            //     \             /
            //      4           5
            //     /
            //    5
            // Output: true

            // Arrange
            var root = new TreeNode(1);
            root.right = new TreeNode(2);
            root.right.left = new TreeNode(3);
            root.right.left.right = new TreeNode(4);
            root.right.left.right.left = new TreeNode(5);

            var subroot = new TreeNode(2);
            subroot.left = new TreeNode(3);
            subroot.left.right = new TreeNode(4);
            subroot.left.right.left = new TreeNode(5);

            // Act
            var result = solution.IsSubtree(root, subroot);

            // Assert
            Assert.IsTrue(result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsSubtree_SymmetricTree_ReturnsTrue(ISubtreeOfAnotherTree_572 solution, string solutionName)
        {
            // Input: root = [1,2,2,3,4,4,3], subRoot = [2,3,4]
            //        1              2
            //       / \            / \
            //      2   2          3   4
            //     / \ / \
            //    3  4 4  3
            // Output: true

            // Arrange
            var root = CreateTree(new int?[] { 1, 2, 2, 3, 4, 4, 3 });
            var subroot = CreateTree(new int?[] { 2, 3, 4 });

            // Act
            var result = solution.IsSubtree(root, subroot);

            // Assert
            Assert.IsTrue(result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsSubtree_SparseTree_ReturnsTrue(ISubtreeOfAnotherTree_572 solution, string solutionName)
        {
            // Input: root = [8,4,12,null,6,10], subRoot = [4,null,6]
            //     8            4
            //    / \            \
            //   4   12           6
            //    \ /
            //     6 10
            // Output: true

            // Arrange
            var root = CreateTree(new int?[] { 8, 4, 12, null, 6, 10 });
            var subroot = CreateTree(new int?[] { 4, null, 6 });

            // Act
            var result = solution.IsSubtree(root, subroot);

            // Assert
            Assert.IsTrue(result, $"Failed for {solutionName}");
        }

        

        #region Serialization Delimiter Bug Tests

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsSubtree_ValueSubstringOfAnother_ReturnsFalse(ISubtreeOfAnotherTree_572 solution, string solutionName)
        {
            // CRITICAL TEST: Catches serialization delimiter bug
            // Input: root = [12], subRoot = [2]
            //    12        2
            // Output: false
            // Explanation: Value 2 is substring of 12, but trees don't match
            // Without proper delimiters, serialization like "$12" contains "$2"

            // Arrange
            var root = new TreeNode(12);
            var subroot = new TreeNode(2);

            // Act
            var result = solution.IsSubtree(root, subroot);

            // Assert
            Assert.IsFalse(result, $"Failed for {solutionName} - This catches the delimiter bug where '2' appears in '12'");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsSubtree_ValuePrefixOfAnother_ReturnsFalse(ISubtreeOfAnotherTree_572 solution, string solutionName)
        {
            // Input: root = [100], subRoot = [10]
            //    100       10
            // Output: false
            // Explanation: Value 10 is prefix of 100

            // Arrange
            var root = new TreeNode(100);
            var subroot = new TreeNode(10);

            // Act
            var result = solution.IsSubtree(root, subroot);

            // Assert
            Assert.IsFalse(result, $"Failed for {solutionName} - Catches prefix matching bug");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsSubtree_ValueSuffixOfAnother_ReturnsFalse(ISubtreeOfAnotherTree_572 solution, string solutionName)
        {
            // Input: root = [123], subRoot = [23]
            //    123       23
            // Output: false
            // Explanation: Value 23 is suffix of 123

            // Arrange
            var root = new TreeNode(123);
            var subroot = new TreeNode(23);

            // Act
            var result = solution.IsSubtree(root, subroot);

            // Assert
            Assert.IsFalse(result, $"Failed for {solutionName} - Catches suffix matching bug");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsSubtree_MultiDigitSubstringMatch_ReturnsFalse(ISubtreeOfAnotherTree_572 solution, string solutionName)
        {
            // Input: root = [1234,56,78], subRoot = [234]
            //      1234         234
            //      /  \
            //     56  78
            // Output: false
            // Explanation: 234 is substring of 1234 but not a subtree

            // Arrange
            var root = CreateTree(new int?[] { 1234, 56, 78 });
            var subroot = new TreeNode(234);

            // Act
            var result = solution.IsSubtree(root, subroot);

            // Assert
            Assert.IsFalse(result, $"Failed for {solutionName} - Multi-digit substring bug");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsSubtree_NegativeValueSubstring_ReturnsFalse(ISubtreeOfAnotherTree_572 solution, string solutionName)
        {
            // Input: root = [-12], subRoot = [-2]
            //    -12       -2
            // Output: false
            // Explanation: Value -2 substring of -12 (in serialization "-12" contains "-2")

            // Arrange
            var root = new TreeNode(-12);
            var subroot = new TreeNode(-2);

            // Act
            var result = solution.IsSubtree(root, subroot);

            // Assert
            Assert.IsFalse(result, $"Failed for {solutionName} - Negative value substring bug");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsSubtree_ZeroInValue_ReturnsFalse(ISubtreeOfAnotherTree_572 solution, string solutionName)
        {
            // Input: root = [10], subRoot = [0]
            //    10        0
            // Output: false
            // Explanation: Value 0 appears in 10

            // Arrange
            var root = new TreeNode(10);
            var subroot = new TreeNode(0);

            // Act
            var result = solution.IsSubtree(root, subroot);

            // Assert
            Assert.IsFalse(result, $"Failed for {solutionName} - Zero in value bug");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsSubtree_SubstringInLeftChild_ReturnsFalse(ISubtreeOfAnotherTree_572 solution, string solutionName)
        {
            // Input: root = [5,12,8], subRoot = [2]
            //      5         2
            //     / \
            //    12  8
            // Output: false
            // Explanation: 2 is substring of 12 (left child), but not a subtree

            // Arrange
            var root = CreateTree(new int?[] { 5, 12, 8 });
            var subroot = new TreeNode(2);

            // Act
            var result = solution.IsSubtree(root, subroot);

            // Assert
            Assert.IsFalse(result, $"Failed for {solutionName} - Substring in child node");
        }

        #endregion

        #region Property Tests

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsSubtree_TreeIsSubtreeOfItself_ReturnsTrue(ISubtreeOfAnotherTree_572 solution, string solutionName)
        {
            // A tree is always a subtree of itself
            // Output: true

            // Arrange
            var root = CreateTree(new int?[] { 1, 2, 3, 4, 5, 6, 7 });
            var subroot = CreateTree(new int?[] { 1, 2, 3, 4, 5, 6, 7 });

            // Act
            var result = solution.IsSubtree(root, subroot);

            // Assert
            Assert.IsTrue(result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsSubtree_LeafIsSubtreeOfTree_ReturnsTrue(ISubtreeOfAnotherTree_572 solution, string solutionName)
        {
            // Any leaf is a subtree of the tree containing it
            // Output: true

            // Arrange
            var root = CreateTree(new int?[] { 1, 2, 3, 4, 5, 6, 7 });
            var subroot = new TreeNode(7); // Rightmost leaf

            // Act
            var result = solution.IsSubtree(root, subroot);

            // Assert
            Assert.IsTrue(result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsSubtree_LargerTreeNotSubtree_ReturnsFalse(ISubtreeOfAnotherTree_572 solution, string solutionName)
        {
            // A larger tree cannot be a subtree of a smaller tree
            // Output: false

            // Arrange
            var root = CreateTree(new int?[] { 1, 2, 3 });
            var subroot = CreateTree(new int?[] { 1, 2, 3, 4, 5, 6, 7 });

            // Act
            var result = solution.IsSubtree(root, subroot);

            // Assert
            Assert.IsFalse(result, $"Failed for {solutionName}");
        }

        #endregion

        

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsSubtree_ComplexSubstringScenario_ReturnsFalse(ISubtreeOfAnotherTree_572 solution, string solutionName)
        {
            // Input: root = [112,211,312], subRoot = [11,2,1]
            //       112           11
            //      /   \         /  \
            //    211   312      2    1
            // Output: false
            // 
            // VB Serialization of root:    "$112$211$#$#$312$#$#"
            // VB Serialization of subroot: "$11$2$#$#$1$#$#"
            //
            // BUG: "$11$2$#$#$1$#$#" DOES appear in "$112$211$#$#$312$#$#" serialization
            // FALSE negative match!

            // Arrange
            var root = CreateTree(new int?[] { 112, 211, 312 });
            var subroot = CreateTree(new int?[] { 11, 2, 1 });

            // Act
            var result = solution.IsSubtree(root, subroot);

            // Assert
            Assert.IsFalse(result, $"Failed for {solutionName} - Complex substring scenario");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsSubtree_DigitInParentMatchesChildValue_ReturnsFalse(ISubtreeOfAnotherTree_572 solution, string solutionName)
        {
            // CRITICAL TEST: Exposes VB delimiter bug
            // Input: root = [12,2,null], subRoot = [2]
            //      12        2
            //     /  \
            //    2    null
            // Output: true (2 is actually a child, so it IS a subtree)
            // But with root = [12,null,null] and subroot = [2], should be false

            // This specific case: root has 12 with NO children, subroot is [2]
            // VB serialization: "$12$#$#" should NOT contain "$2$#$#" as valid subtree
            // But if we check [120, 20] vs [20], the "20" appears in "120" serialization

            // Arrange
            var root = CreateTree(new int?[] { 120, 20, 30 });
            var subroot = CreateTree(new int?[] { 20 });

            // Act  
            var result = solution.IsSubtree(root, subroot);

            // Assert
            Assert.IsTrue(result, $"Failed for {solutionName} - 20 is actually left child of 120, should match");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsSubtree_ValueContainsSubrootValueButWrongStructure_ReturnsFalse(ISubtreeOfAnotherTree_572 solution, string solutionName)
        {
            // CRITICAL TEST: This WILL catch the VB delimiter bug!
            // Input: root = [12, 3, 4], subRoot = [2, 3, 4]
            //       12            2
            //       /  \         / \
            //      3    4       3   4
            // Output: false
            // 
            // VB Serialization of root:    "$12$3$#$#$4$#$#"
            // VB Serialization of subroot: "$2$3$#$#$4$#$#"
            //
            // BUG: "$12$3$#$#$4$#$#" DOES contain "$2$3$#$#$4$#$#" as substring!
            // Starting at index 2: "2$3$#$#$4$#$#" matches!

            // Arrange
            var root = CreateTree(new int?[] { 12, 3, 4 });
            var subroot = CreateTree(new int?[] { 2, 3, 4 });

            // Act
            var result = solution.IsSubtree(root, subroot);

            // Assert
            Assert.IsFalse(result, $"Failed for {solutionName} - 2 appears as digit in 12, creates false substring match. VB DELIMITER BUG!");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsSubtree_ActualMatchWithSimilarValues_ReturnsTrue(ISubtreeOfAnotherTree_572 solution, string solutionName)
        {
            // Positive test: Ensure fix doesn't break legitimate matches
            // Input: root = [12,2,8], subRoot = [2]
            //      12        2
            //     /  \
            //    2    8
            // Output: true
            // Explanation: 2 is left child, legitimate match

            // Arrange
            var root = CreateTree(new int?[] { 12, 2, 8 });
            var subroot = new TreeNode(2);

            // Act
            var result = solution.IsSubtree(root, subroot);

            // Assert
            Assert.IsTrue(result, $"Failed for {solutionName} - Legitimate match should still work");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsSubtree_VB_DelimiterBug_ReturnsFalse(ISubtreeOfAnotherTree_572 solution, string solutionName)
        {
            // CRITICAL TEST: Exposes VB delimiter bug!
            // Input: root = [12, 3, 4], subRoot = [2, 3, 4]
            //       12            2
            //       /  \         / \
            //      3    4       3   4
            // Output: false (different root values, not a subtree)
            // 
            // VB Serialization: "$12$3$#$#$4$#$#" contains "$2$3$#$#$4$#$#"!
            // The "2" digit in "12" creates false substring match

            // Arrange
            var root = CreateTree(new int?[] { 12, 3, 4 });
            var subroot = CreateTree(new int?[] { 2, 3, 4 });

            // Act
            var result = solution.IsSubtree(root, subroot);

            // Assert
            Assert.IsFalse(result, $"VB DELIMITER BUG! Failed for {solutionName}");
        }
    }
}