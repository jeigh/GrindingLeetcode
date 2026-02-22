using LeetCodeProblems.CSharp.Tree;
using LeetCodeProblems.Interfaces.Medium;
using LeetCodeProblems.Shared;

namespace GrindingLeetCode.UnitTests.Medium
{
    [TestClass]
    public class DeleteLeavesWithAGivenValue_1325_Tests
    {
        public static IEnumerable<object[]> GetImplementations()
        {
            yield return new object[] { new DeleteLeavesWithGivenValue_CSharp_1325(), "C# Implementation" };
        }

        #region Helper Methods

        /// <summary>
        /// Creates a binary tree from level-order array (with nulls)
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
        /// Converts tree to level-order array for comparison
        /// </summary>
        private List<int?> ToLevelOrder(TreeNode root)
        {
            List<int?> result = new List<int?>();
            if (root == null) return result;

            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                TreeNode current = queue.Dequeue();

                if (current == null)
                {
                    result.Add(null);
                }
                else
                {
                    result.Add(current.val);
                    queue.Enqueue(current.left);
                    queue.Enqueue(current.right);
                }
            }

            // Remove trailing nulls
            while (result.Count > 0 && result[result.Count - 1] == null)
            {
                result.RemoveAt(result.Count - 1);
            }

            return result;
        }

        /// <summary>
        /// Checks if a tree contains any leaf nodes with the target value
        /// </summary>
        private bool ContainsLeafWithValue(TreeNode root, int target)
        {
            if (root == null) return false;
            if (root.left == null && root.right == null)
            {
                return root.val == target;
            }
            return ContainsLeafWithValue(root.left, target) || ContainsLeafWithValue(root.right, target);
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
        /// Checks if a value exists anywhere in the tree
        /// </summary>
        private bool Contains(TreeNode root, int val)
        {
            if (root == null) return false;
            if (root.val == val) return true;
            return Contains(root.left, val) || Contains(root.right, val);
        }

        /// <summary>
        /// Gets all values in the tree (preorder)
        /// </summary>
        private List<int> GetAllValues(TreeNode root)
        {
            List<int> result = new List<int>();
            if (root == null) return result;
            
            result.Add(root.val);
            result.AddRange(GetAllValues(root.left));
            result.AddRange(GetAllValues(root.right));
            
            return result;
        }

        #endregion

        #region LeetCode Examples

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void RemoveLeafNodes_Example1_RemovesLeavesCorrectly(IDeleteLeavesWithAGivenValue_1325 solution, string solutionName)
        {
            // Input: root = [1,2,3,2,null,2,4], target = 2
            //       1              1
            //      / \              \
            //     2   3      =>      3
            //    /   / \              \
            //   2   2   4              4
            // Output: [1,null,3,null,4]
            // After removing leaf 2's, the parent 2 also becomes a leaf and is removed

            // Arrange
            var root = CreateTree(new int?[] { 1, 2, 3, 2, null, 2, 4 });
            int target = 2;

            // Act
            var result = solution.RemoveLeafNodes(root, target);

            // Assert
            Assert.IsNotNull(result, $"Result should not be null for {solutionName}");
            Assert.IsFalse(ContainsLeafWithValue(result, target), 
                $"No leaf should have value {target} for {solutionName}");
            
            // Verify specific structure after cascading deletion
            Assert.AreEqual(1, result.val);
            Assert.IsNull(result.left, "Left subtree should be removed after cascading deletion");
            Assert.AreEqual(3, result.right.val);
            Assert.IsNull(result.right.left);
            Assert.AreEqual(4, result.right.right.val);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void RemoveLeafNodes_Example2_RemovesAllNodesReturnsNull(IDeleteLeavesWithAGivenValue_1325 solution, string solutionName)
        {
            // Input: root = [1,3,3,3,2], target = 3
            //       1
            //      / \
            //     3   3
            //    / \
            //   3   2
            // Output: [1,null,null,2]
            // After removing leaves, new leaves appear

            // Arrange
            var root = CreateTree(new int?[] { 1, 3, 3, 3, 2 });
            int target = 3;

            // Act
            var result = solution.RemoveLeafNodes(root, target);

            // Assert
            Assert.IsNotNull(result, $"Result should not be null for {solutionName}");
            Assert.IsFalse(ContainsLeafWithValue(result, target),
                $"No leaf should have value {target} for {solutionName}");
            Assert.AreEqual(1, result.val);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void RemoveLeafNodes_Example3_AllNodesAreTargetReturnsNull(IDeleteLeavesWithAGivenValue_1325 solution, string solutionName)
        {
            // Input: root = [1,1,1], target = 1
            //       1
            //      / \
            //     1   1
            // Output: []
            // All nodes will eventually become leaves and be removed

            // Arrange
            var root = CreateTree(new int?[] { 1, 1, 1 });
            int target = 1;

            // Act
            var result = solution.RemoveLeafNodes(root, target);

            // Assert
            Assert.IsNull(result, $"Result should be null (all nodes removed) for {solutionName}");
        }

        #endregion

        #region Single Node Trees

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void RemoveLeafNodes_SingleNodeMatchesTarget_ReturnsNull(IDeleteLeavesWithAGivenValue_1325 solution, string solutionName)
        {
            // Arrange
            var root = new TreeNode(5);
            int target = 5;

            // Act
            var result = solution.RemoveLeafNodes(root, target);

            // Assert
            Assert.IsNull(result, $"Single node matching target should be removed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void RemoveLeafNodes_SingleNodeDoesNotMatchTarget_ReturnsNode(IDeleteLeavesWithAGivenValue_1325 solution, string solutionName)
        {
            // Arrange
            var root = new TreeNode(5);
            int target = 3;

            // Act
            var result = solution.RemoveLeafNodes(root, target);

            // Assert
            Assert.IsNotNull(result, $"Single node not matching target should remain for {solutionName}");
            Assert.AreEqual(5, result.val);
        }

        #endregion

        #region Two/Three Node Trees

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void RemoveLeafNodes_TwoNodes_BothLeaves_RemovesBoth(IDeleteLeavesWithAGivenValue_1325 solution, string solutionName)
        {
            // Tree:  2
            //       /
            //      2
            // Target: 2
            // Result: null (both removed)

            // Arrange
            var root = CreateTree(new int?[] { 2, 2 });
            int target = 2;

            // Act
            var result = solution.RemoveLeafNodes(root, target);

            // Assert
            Assert.IsNull(result, $"All nodes should be removed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void RemoveLeafNodes_TwoNodes_OnlyLeafMatches_RemovesLeaf(IDeleteLeavesWithAGivenValue_1325 solution, string solutionName)
        {
            // Tree:  5
            //       /
            //      2
            // Target: 2
            // Result: [5]

            // Arrange
            var root = CreateTree(new int?[] { 5, 2 });
            int target = 2;

            // Act
            var result = solution.RemoveLeafNodes(root, target);

            // Assert
            Assert.IsNotNull(result, $"Root should remain for {solutionName}");
            Assert.AreEqual(5, result.val);
            Assert.IsNull(result.left);
            Assert.IsNull(result.right);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void RemoveLeafNodes_ThreeNodes_BothLeavesMatch_RemovesLeaves(IDeleteLeavesWithAGivenValue_1325 solution, string solutionName)
        {
            // Tree:    5
            //         / \
            //        2   2
            // Target: 2
            // Result: [5]

            // Arrange
            var root = CreateTree(new int?[] { 5, 2, 2 });
            int target = 2;

            // Act
            var result = solution.RemoveLeafNodes(root, target);

            // Assert
            Assert.IsNotNull(result, $"Root should remain for {solutionName}");
            Assert.AreEqual(5, result.val);
            Assert.IsNull(result.left);
            Assert.IsNull(result.right);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void RemoveLeafNodes_ThreeNodes_AllMatch_RemovesAll(IDeleteLeavesWithAGivenValue_1325 solution, string solutionName)
        {
            // Tree:    2
            //         / \
            //        2   2
            // Target: 2
            // Result: null

            // Arrange
            var root = CreateTree(new int?[] { 2, 2, 2 });
            int target = 2;

            // Act
            var result = solution.RemoveLeafNodes(root, target);

            // Assert
            Assert.IsNull(result, $"All nodes should be removed for {solutionName}");
        }

        #endregion

        #region Cascading Deletions

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void RemoveLeafNodes_CascadingDeletions_RemovesMultipleLevels(IDeleteLeavesWithAGivenValue_1325 solution, string solutionName)
        {
            // Tree:      3
            //          /   \
            //         3     3
            //        / \
            //       3   3
            // Target: 3
            // Result: null (cascading deletions)

            // Arrange
            var root = CreateTree(new int?[] { 3, 3, 3, 3, 3 });
            int target = 3;

            // Act
            var result = solution.RemoveLeafNodes(root, target);

            // Assert
            Assert.IsNull(result, $"All nodes should be removed via cascading for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void RemoveLeafNodes_CascadingWithStopNode_StopsAtNonTarget(IDeleteLeavesWithAGivenValue_1325 solution, string solutionName)
        {
            // Tree:      5
            //          /   \
            //         3     3
            //        / \
            //       3   3
            // Target: 3
            // Result: [5] (stops at 5)

            // Arrange
            var root = CreateTree(new int?[] { 5, 3, 3, 3, 3 });
            int target = 3;

            // Act
            var result = solution.RemoveLeafNodes(root, target);

            // Assert
            Assert.IsNotNull(result, $"Root should remain for {solutionName}");
            Assert.AreEqual(5, result.val);
            Assert.IsNull(result.left);
            Assert.IsNull(result.right);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void RemoveLeafNodes_DeepCascading_RemovesAllTargets(IDeleteLeavesWithAGivenValue_1325 solution, string solutionName)
        {
            // Tree:          7
            //              /   \
            //             2     2
            //            / \   / \
            //           2   2 2   2
            //          /
            //         2
            // Target: 2
            // Result: [7]

            // Arrange
            var root = CreateTree(new int?[] { 7, 2, 2, 2, 2, 2, 2, 2 });
            int target = 2;

            // Act
            var result = solution.RemoveLeafNodes(root, target);

            // Assert
            Assert.IsNotNull(result, $"Root should remain for {solutionName}");
            Assert.AreEqual(7, result.val);
            Assert.IsNull(result.left);
            Assert.IsNull(result.right);
        }

        #endregion

        #region Asymmetric Trees

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void RemoveLeafNodes_LeftHeavyTree_RemovesLeavesCorrectly(IDeleteLeavesWithAGivenValue_1325 solution, string solutionName)
        {
            // Tree:        10
            //            /    \
            //           5      15
            //          / \
            //         2   7
            //        /
            //       2
            // Target: 2
            // Result: [10,5,15,null,7]

            // Arrange
            var root = CreateTree(new int?[] { 10, 5, 15, 2, 7, null, null, 2 });
            int target = 2;

            // Act
            var result = solution.RemoveLeafNodes(root, target);

            // Assert
            Assert.IsNotNull(result, $"Tree should not be null for {solutionName}");
            Assert.IsFalse(ContainsLeafWithValue(result, target));
            Assert.AreEqual(10, result.val);
            Assert.AreEqual(5, result.left.val);
            Assert.AreEqual(15, result.right.val);
            Assert.AreEqual(7, result.left.right.val);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void RemoveLeafNodes_RightHeavyTree_RemovesLeavesCorrectly(IDeleteLeavesWithAGivenValue_1325 solution, string solutionName)
        {
            // Tree:    10
            //         /  \
            //        5    15
            //            /  \
            //           12  20
            //                 \
            //                 2
            // Target: 2
            // Result: [10,5,15,null,null,12,20]

            // Arrange
            var root = CreateTree(new int?[] { 10, 5, 15, null, null, 12, 20, null, null, null, null, null, 2 });
            int target = 2;

            // Act
            var result = solution.RemoveLeafNodes(root, target);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsFalse(ContainsLeafWithValue(result, target));
            Assert.AreEqual(10, result.val);
        }

        #endregion

        #region Skewed Trees

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void RemoveLeafNodes_LeftSkewed_AllMatch_RemovesAll(IDeleteLeavesWithAGivenValue_1325 solution, string solutionName)
        {
            // Tree:      3
            //           /
            //          3
            //         /
            //        3
            //       /
            //      3
            // Target: 3

            // Arrange
            var root = CreateTree(new int?[] { 3, 3, null, 3, null, 3 });
            int target = 3;

            // Act
            var result = solution.RemoveLeafNodes(root, target);

            // Assert
            Assert.IsNull(result, $"All nodes should be removed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void RemoveLeafNodes_RightSkewed_AllMatch_RemovesAll(IDeleteLeavesWithAGivenValue_1325 solution, string solutionName)
        {
            // Tree:  3
            //         \
            //          3
            //           \
            //            3
            //             \
            //              3
            // Target: 3

            // Arrange
            var root = CreateTree(new int?[] { 3, null, 3, null, 3, null, 3 });
            int target = 3;

            // Act
            var result = solution.RemoveLeafNodes(root, target);

            // Assert
            Assert.IsNull(result, $"All nodes should be removed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void RemoveLeafNodes_LeftSkewed_OnlyLeafMatches(IDeleteLeavesWithAGivenValue_1325 solution, string solutionName)
        {
            // Tree:      5
            //           /
            //          4
            //         /
            //        3
            //       /
            //      2
            // Target: 2

            // Arrange
            var root = CreateTree(new int?[] { 5, 4, null, 3, null, 2 });
            int target = 2;

            // Act
            var result = solution.RemoveLeafNodes(root, target);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsFalse(ContainsLeafWithValue(result, target));
            Assert.AreEqual(3, CountNodes(result));
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void RemoveLeafNodes_RightSkewed_OnlyLeafMatches(IDeleteLeavesWithAGivenValue_1325 solution, string solutionName)
        {
            // Tree:  2
            //         \
            //          3
            //           \
            //            4
            //             \
            //              5
            // Target: 5

            // Arrange
            var root = CreateTree(new int?[] { 2, null, 3, null, 4, null, 5 });
            int target = 5;

            // Act
            var result = solution.RemoveLeafNodes(root, target);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsFalse(ContainsLeafWithValue(result, target));
            Assert.AreEqual(3, CountNodes(result));
        }

        #endregion

        #region No Deletions

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void RemoveLeafNodes_NoLeavesMatchTarget_TreeUnchanged(IDeleteLeavesWithAGivenValue_1325 solution, string solutionName)
        {
            // Tree:      5
            //          /   \
            //         3     7
            //        / \   / \
            //       2   4 6   8
            // Target: 10 (no matches)

            // Arrange
            var root = CreateTree(new int?[] { 5, 3, 7, 2, 4, 6, 8 });
            var originalValues = GetAllValues(root);
            int target = 10;

            // Act
            var result = solution.RemoveLeafNodes(root, target);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(originalValues.Count, CountNodes(result));
            CollectionAssert.AreEqual(originalValues, GetAllValues(result));
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void RemoveLeafNodes_TargetOnlyInInternalNodes_TreeUnchanged(IDeleteLeavesWithAGivenValue_1325 solution, string solutionName)
        {
            // Tree:      2
            //          /   \
            //         3     4
            //        / \   / \
            //       5   6 7   8
            // Target: 2 (only in root, not a leaf)

            // Arrange
            var root = CreateTree(new int?[] { 2, 3, 4, 5, 6, 7, 8 });
            var originalCount = CountNodes(root);
            int target = 2;

            // Act
            var result = solution.RemoveLeafNodes(root, target);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(originalCount, CountNodes(result));
            Assert.AreEqual(2, result.val);
        }

        #endregion

        #region Complex Scenarios

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void RemoveLeafNodes_MultipleTargetLeaves_RemovesAllTargets(IDeleteLeavesWithAGivenValue_1325 solution, string solutionName)
        {
            // Tree:          10
            //              /    \
            //             5      15
            //            / \    /  \
            //           2   7  12  20
            //          /      /
            //         2      2
            // Target: 2

            // Arrange
            var root = CreateTree(new int?[] { 10, 5, 15, 2, 7, 12, 20, 2, null, null, null, 2 });
            int target = 2;

            // Act
            var result = solution.RemoveLeafNodes(root, target);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsFalse(ContainsLeafWithValue(result, target));
            Assert.IsFalse(Contains(result, target));
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void RemoveLeafNodes_AlternatingPattern_RemovesCorrectly(IDeleteLeavesWithAGivenValue_1325 solution, string solutionName)
        {
            // Tree:        5
            //            /   \
            //           3     3
            //          / \   / \
            //         5   5 5   5
            // Target: 5

            // Arrange
            var root = CreateTree(new int?[] { 5, 3, 3, 5, 5, 5, 5 });
            int target = 5;

            // Act
            var result = solution.RemoveLeafNodes(root, target);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsFalse(ContainsLeafWithValue(result, target));
            // After removing leaves, 3's become leaves and remain
            Assert.AreEqual(3, CountNodes(result));
        }

        #endregion

        #region Boundary Values

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void RemoveLeafNodes_MinValue_RemovesCorrectly(IDeleteLeavesWithAGivenValue_1325 solution, string solutionName)
        {
            // Tree with value 1 (minimum per constraints)
            // Tree:    5
            //         / \
            //        1   1
            // Target: 1

            // Arrange
            var root = CreateTree(new int?[] { 5, 1, 1 });
            int target = 1;

            // Act
            var result = solution.RemoveLeafNodes(root, target);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(5, result.val);
            Assert.IsNull(result.left);
            Assert.IsNull(result.right);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void RemoveLeafNodes_MaxValue_RemovesCorrectly(IDeleteLeavesWithAGivenValue_1325 solution, string solutionName)
        {
            // Tree with value 1000 (maximum per constraints)
            // Tree:     500
            //          /   \
            //       1000  1000
            // Target: 1000

            // Arrange
            var root = CreateTree(new int?[] { 500, 1000, 1000 });
            int target = 1000;

            // Act
            var result = solution.RemoveLeafNodes(root, target);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(500, result.val);
            Assert.IsNull(result.left);
            Assert.IsNull(result.right);
        }

        #endregion

        #region Property-Based Tests

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void RemoveLeafNodes_NoLeafHasTargetValue_AfterRemoval(IDeleteLeavesWithAGivenValue_1325 solution, string solutionName)
        {
            // Verify that no leaf in result tree has the target value

            // Arrange
            var root = CreateTree(new int?[] { 1, 2, 3, 2, null, 2, 4 });
            int target = 2;

            // Act
            var result = solution.RemoveLeafNodes(root, target);

            // Assert
            Assert.IsFalse(ContainsLeafWithValue(result, target),
                $"Result should not contain any leaf with target value for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void RemoveLeafNodes_PreservesNonTargetNodes_Correctly(IDeleteLeavesWithAGivenValue_1325 solution, string solutionName)
        {
            // Verify that non-target values are preserved

            // Arrange
            var root = CreateTree(new int?[] { 1, 2, 3, 4, 5, 6, 7 });
            int target = 10; // No matches

            // Act
            var result = solution.RemoveLeafNodes(root, target);

            // Assert
            Assert.AreEqual(7, CountNodes(result), $"All nodes should be preserved for {solutionName}");
        }

        #endregion

        #region Large Trees

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void RemoveLeafNodes_LargeTree_RemovesTargetsCorrectly(IDeleteLeavesWithAGivenValue_1325 solution, string solutionName)
        {
            // Large tree with multiple levels
            // Tree:              50
            //                /       \
            //              25         75
            //            /    \      /   \
            //           10    30   60    90
            //          /  \   /\   /\    /\
            //         5  15 25 35 55 65 80 95
            // Target: 25

            // Arrange
            var root = CreateTree(new int?[] { 50, 25, 75, 10, 30, 60, 90, 5, 15, 25, 35, 55, 65, 80, 95 });
            int target = 25;

            // Act
            var result = solution.RemoveLeafNodes(root, target);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsFalse(ContainsLeafWithValue(result, target));
        }

        #endregion

        #region Empty Tree

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void RemoveLeafNodes_NullTree_ReturnsNull(IDeleteLeavesWithAGivenValue_1325 solution, string solutionName)
        {
            // Arrange
            TreeNode root = null;
            int target = 5;

            // Act
            var result = solution.RemoveLeafNodes(root, target);

            // Assert
            Assert.IsNull(result, $"Null tree should return null for {solutionName}");
        }

        #endregion
    }
}
