using LeetCodeProblems.CSharp.Tree;
using LeetCodeProblems.Interfaces.Medium;
using LeetCodeProblems.Shared;
using LeetCodeProblems.VisualBasic;

namespace GrindingLeetCode.UnitTests.Medium
{
    [TestClass]
    public class HouseRobberIII_337_Tests
    {
        public static IEnumerable<object[]> GetImplementations()
        {
            yield return new object[] { new HouseRobberIII_CSharp_337(), "C# Implementation" };
            yield return new object[] { new HouseRobberIII_VB_337(), "VB Implementation" };
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

        #endregion

        #region LeetCode Examples

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Rob_Example1_ReturnsMaxRobbedAmount(IHouseRobberIII_337 solution, string solutionName)
        {
            // Input: root = [3,2,3,null,3,null,1]
            //       3
            //      / \
            //     2   3
            //      \   \
            //       3   1
            // Output: 7
            // Explanation: Maximum amount = 3 + 3 + 1 = 7

            // Arrange
            var root = CreateTree(new int?[] { 3, 2, 3, null, 3, null, 1 });

            // Act
            int result = solution.Rob(root);

            // Assert
            Assert.AreEqual(7, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Rob_Example2_ReturnsMaxRobbedAmount(IHouseRobberIII_337 solution, string solutionName)
        {
            // Input: root = [3,4,5,1,3,null,1]
            //       3
            //      / \
            //     4   5
            //    / \   \
            //   1   3   1
            // Output: 9
            // Explanation: Maximum amount = 4 + 5 = 9

            // Arrange
            var root = CreateTree(new int?[] { 3, 4, 5, 1, 3, null, 1 });

            // Act
            int result = solution.Rob(root);

            // Assert
            Assert.AreEqual(9, result, $"Failed for {solutionName}");
        }

        #endregion

        #region Single Node Trees

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Rob_SingleNodePositive_ReturnsNodeValue(IHouseRobberIII_337 solution, string solutionName)
        {
            // Tree: [5]
            // Output: 5

            // Arrange
            var root = new TreeNode(5);

            // Act
            int result = solution.Rob(root);

            // Assert
            Assert.AreEqual(5, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Rob_SingleNodeZero_ReturnsZero(IHouseRobberIII_337 solution, string solutionName)
        {
            // Tree: [0]
            // Output: 0

            // Arrange
            var root = new TreeNode(0);

            // Act
            int result = solution.Rob(root);

            // Assert
            Assert.AreEqual(0, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Rob_SingleNodeLargeValue_ReturnsNodeValue(IHouseRobberIII_337 solution, string solutionName)
        {
            // Tree: [10000]
            // Output: 10000

            // Arrange
            var root = new TreeNode(10000);

            // Act
            int result = solution.Rob(root);

            // Assert
            Assert.AreEqual(10000, result, $"Failed for {solutionName}");
        }

        #endregion

        #region Two/Three Node Trees

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Rob_TwoNodes_LeftChild_RobsRoot(IHouseRobberIII_337 solution, string solutionName)
        {
            // Tree:  10
            //       /
            //      5
            // Output: 10 (rob root only)

            // Arrange
            var root = CreateTree(new int?[] { 10, 5 });

            // Act
            int result = solution.Rob(root);

            // Assert
            Assert.AreEqual(10, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Rob_TwoNodes_LeftChildLarger_RobsChild(IHouseRobberIII_337 solution, string solutionName)
        {
            // Tree:  5
            //       /
            //      10
            // Output: 10 (rob child instead)

            // Arrange
            var root = CreateTree(new int?[] { 5, 10 });

            // Act
            int result = solution.Rob(root);

            // Assert
            Assert.AreEqual(10, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Rob_TwoNodes_RightChild_RobsRoot(IHouseRobberIII_337 solution, string solutionName)
        {
            // Tree:  10
            //         \
            //          5
            // Output: 10 (rob root only)

            // Arrange
            var root = CreateTree(new int?[] { 10, null, 5 });

            // Act
            int result = solution.Rob(root);

            // Assert
            Assert.AreEqual(10, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Rob_ThreeNodes_RobsRootAndBothChildren_Balanced(IHouseRobberIII_337 solution, string solutionName)
        {
            // Tree:    5
            //         / \
            //        10  10
            // Output: 20 (rob both children, skip root)

            // Arrange
            var root = CreateTree(new int?[] { 5, 10, 10 });

            // Act
            int result = solution.Rob(root);

            // Assert
            Assert.AreEqual(20, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Rob_ThreeNodes_RobsRoot_ChildrenSmall(IHouseRobberIII_337 solution, string solutionName)
        {
            // Tree:    20
            //         / \
            //        5   5
            // Output: 20 (rob root only)

            // Arrange
            var root = CreateTree(new int?[] { 20, 5, 5 });

            // Act
            int result = solution.Rob(root);

            // Assert
            Assert.AreEqual(20, result, $"Failed for {solutionName}");
        }

        #endregion

        #region Perfect Binary Trees

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Rob_PerfectTree_7Nodes_AllOnes_ReturnsOptimal(IHouseRobberIII_337 solution, string solutionName)
        {
            // Tree:        1
            //            /   \
            //           1     1
            //          / \   / \
            //         1   1 1   1
            

            // Arrange
            var root = CreateTree(new int?[] { 1, 1, 1, 1, 1, 1, 1 });

            // Act
            int result = solution.Rob(root);

            // Assert
            Assert.AreEqual(5, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Rob_PerfectTree_7Nodes_MixedValues_ReturnsOptimal(IHouseRobberIII_337 solution, string solutionName)
        {
            // Tree:        10
            //            /    \
            //           5      5
            //          / \    / \
            //         1   1  1   1
            // Output: 14 (rob root 10 + leaves 1+1+1+1 = 14)

            // Arrange
            var root = CreateTree(new int?[] { 10, 5, 5, 1, 1, 1, 1 });

            // Act
            int result = solution.Rob(root);

            // Assert
            Assert.AreEqual(14, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Rob_PerfectTree_15Nodes_ReturnsOptimal(IHouseRobberIII_337 solution, string solutionName)
        {
            // Tree:                  20
            //                    /       \
            //                  10         10
            //                /    \      /   \
            //               5      5    5     5
            //              / \    / \  / \   / \
            //             2   2  2  2 2  2  2   2
            

            // Arrange
            var root = CreateTree(new int?[] { 20, 10, 10, 5, 5, 5, 5, 2, 2, 2, 2, 2, 2, 2, 2 });

            // Act
            int result = solution.Rob(root);

            // Assert
            Assert.AreEqual(40, result, $"Failed for {solutionName}");
        }

        #endregion

        #region Skewed Trees

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Rob_LeftSkewed_AlternatingLarge_ReturnsOptimal(IHouseRobberIII_337 solution, string solutionName)
        {
            // Tree:      100
            //           /
            //          1
            //         /
            //        100
            //       /
            //      1
            //     /
            //    100
            // Output: 300 (rob 100, 100, 100)

            // Arrange
            var root = CreateTree(new int?[] { 100, 1, null, 100, null, 1, null, 100 });

            // Act
            int result = solution.Rob(root);

            // Assert
            Assert.AreEqual(300, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Rob_LeftSkewed_DecreasingValues_ReturnsOptimal(IHouseRobberIII_337 solution, string solutionName)
        {
            // Tree:      50
            //           /
            //          40
            //         /
            //        30
            //       /
            //      20
            //     /
            //    10
            // Output: 90 (rob 50, 30, 10)

            // Arrange
            var root = CreateTree(new int?[] { 50, 40, null, 30, null, 20, null, 10 });

            // Act
            int result = solution.Rob(root);

            // Assert
            Assert.AreEqual(90, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Rob_RightSkewed_AlternatingLarge_ReturnsOptimal(IHouseRobberIII_337 solution, string solutionName)
        {
            // Tree:  1
            //         \
            //         100
            //           \
            //            1
            //             \
            //             100
            //               \
            //               1


            // Arrange
            var root = CreateTree(new int?[] { 1, null, 100, null, 1, null, 100, null, 1 });

            // Act
            int result = solution.Rob(root);

            // Assert
            Assert.AreEqual(200, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Rob_RightSkewed_IncreasingValues_ReturnsOptimal(IHouseRobberIII_337 solution, string solutionName)
        {
            // Tree:  10
            //         \
            //         20
            //           \
            //           30
            //             \
            //             40
            //               \
            //               50
            // Output: 90 (rob 10, 30, 50)

            // Arrange
            var root = CreateTree(new int?[] { 10, null, 20, null, 30, null, 40, null, 50 });

            // Act
            int result = solution.Rob(root);

            // Assert
            Assert.AreEqual(90, result, $"Failed for {solutionName}");
        }

        #endregion

        #region Complex Scenarios

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Rob_AsymmetricTree_DeepLeft_ReturnsOptimal(IHouseRobberIII_337 solution, string solutionName)
        {
            // Tree:            20
            //               /      \
            //             15        5
            //            /  \        \
            //          10    8       3
            //         /
            //        5
            // Output: 41 (rob root 20 + grandchildren 10, 8, 3 = 41)
            // Alternative: skip root, rob 15 = 20 (with its optimal), rob 5 = 5 (with its optimal) = 20 + 5 = 25

            // Arrange
            var root = CreateTree(new int?[] { 20, 15, 5, 10, 8, null, 3, 5 });

            // Act
            int result = solution.Rob(root);

            // Assert
            Assert.AreEqual(41, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Rob_AsymmetricTree_DeepRight_ReturnsOptimal(IHouseRobberIII_337 solution, string solutionName)
        {
            // Tree:        5
            //            /   \
            //           3     20
            //          /     /  \
            //         2     15   10
            //                     \
            //                      8
            // Output: 33 (rob 5, 15, 10 = 30 or 20, 2, 8 = 30 or 5, 2, 15, 8 = 30... wait
            // Let me recalculate: Rob root 5, then grandchildren 15, 10 = 5 + 15 + 10 = 30
            // Or skip root, rob 3, 20 = 23, then rob their children? 3's child is 2, 20's children are 15, 10
            // Can't rob 3 and 2 together, so if rob 3, can't rob 2. If rob 20, can't rob 15, 10.
            // So: rob 3, 20 = 23, or rob 2, 15, 10 = 27, or rob 5, 2, 15, 10 = 32? No, can't rob 5 and 3/20.
            // Actually: rob 5 (skip children), rob grandchildren 2, 15, 10 = 5 + 2 + 15 + 10 = 32
            // Or: rob 3, 20 = 23, rob 3's children (none directly robable), rob 20's grandchild 8 = 23 + 8 = 31

            // Arrange
            var root = CreateTree(new int?[] { 5, 3, 20, 2, null, 15, 10, null, null, null, null, null, 8 });

            // Act
            int result = solution.Rob(root);

            // Assert
            Assert.AreEqual(32, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Rob_AllZeros_ReturnsZero(IHouseRobberIII_337 solution, string solutionName)
        {
            // Tree:      0
            //          /   \
            //         0     0
            //        / \   / \
            //       0   0 0   0
            // Output: 0

            // Arrange
            var root = CreateTree(new int?[] { 0, 0, 0, 0, 0, 0, 0 });

            // Act
            int result = solution.Rob(root);

            // Assert
            Assert.AreEqual(0, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Rob_RootLargerThanAllOthers_RobsRoot(IHouseRobberIII_337 solution, string solutionName)
        {
            // Tree:        1000
            //            /      \
            //           1         1
            //          / \       / \
            //         1   1     1   1
            // Output: 1004 (rob root 1000 + leaves 1+1+1+1 = 1004)

            // Arrange
            var root = CreateTree(new int?[] { 1000, 1, 1, 1, 1, 1, 1 });

            // Act
            int result = solution.Rob(root);

            // Assert
            Assert.AreEqual(1004, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Rob_ChildrenLargerThanRoot_RobsChildren(IHouseRobberIII_337 solution, string solutionName)
        {
            // Tree:        10
            //            /    \
            //          100    100
            //          / \    / \
            //         1   1  1   1
            // Output: 200 (rob children 100 + 100 = 200)
            // Alternative: rob root 10 + grandchildren 1+1+1+1 = 14
            // Note: Cannot rob both children AND grandchildren (violates non-adjacent constraint)

            // Arrange
            var root = CreateTree(new int?[] { 10, 100, 100, 1, 1, 1, 1 });

            // Act
            int result = solution.Rob(root);

            // Assert
            Assert.AreEqual(200, result, $"Failed for {solutionName}");
        }

        #endregion

        #region Deep Trees

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Rob_DeepBalancedTree_ReturnsOptimal(IHouseRobberIII_337 solution, string solutionName)
        {
            // Deep tree with 31 nodes (height 4)
            // All nodes value 1
            // Tree:                      1
            //                      /           \
            //                    1               1
            //                 /     \         /     \
            //               1        1       1       1
            //              / \      / \     / \     / \
            //             1   1    1   1   1   1   1   1
            //            /\  /\   /\  /\  /\  /\  /\  /\
            //           1 1 1 1  1 1 1 1 1 1 1 1 1 1 1 1
            // Output: 16 (rob all bottom level)

            // Arrange
            var values = new int?[31];
            for (int i = 0; i < 31; i++) values[i] = 1;
            var root = CreateTree(values);

            // Act
            int result = solution.Rob(root);

            // Assert
            Assert.AreEqual(21, result, $"Failed for {solutionName}");
        }

        #endregion

        #region Edge Cases

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Rob_NullTree_ReturnsZero(IHouseRobberIII_337 solution, string solutionName)
        {
            // Tree: null
            // Output: 0

            // Arrange
            TreeNode root = null;

            // Act
            int result = solution.Rob(root);

            // Assert
            Assert.AreEqual(0, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Rob_OnlyLeftSubtree_ReturnsOptimal(IHouseRobberIII_337 solution, string solutionName)
        {
            // Tree:      10
            //           /
            //          5
            //         / \
            //        2   3
            // Output: 12 (rob 10 + 2 + 3 = 15 or rob 5 + nothing = 5, actually rob 10, 2, 3 = 15)
            // Wait: if rob 10, skip children 5, rob grandchildren 2, 3 = 10 + 2 + 3 = 15
            // Or: skip 10, rob 5, skip grandchildren = 5
            // So: 15

            // Arrange
            var root = CreateTree(new int?[] { 10, 5, null, 2, 3 });

            // Act
            int result = solution.Rob(root);

            // Assert
            Assert.AreEqual(15, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Rob_OnlyRightSubtree_ReturnsOptimal(IHouseRobberIII_337 solution, string solutionName)
        {
            // Tree:  10
            //          \
            //          5
            //         / \
            //        2   3
            // Output: 15 (rob 10 + 2 + 3)

            // Arrange
            var root = CreateTree(new int?[] { 10, null, 5, 2, 3 });

            // Act
            int result = solution.Rob(root);

            // Assert
            Assert.AreEqual(15, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Rob_LargeValues_NoOverflow_ReturnsOptimal(IHouseRobberIII_337 solution, string solutionName)
        {
            // Tree with large values to test overflow handling
            // Tree:        9999
            //            /      \
            //         9999      9999
            // Output: 19998 (rob both children)

            // Arrange
            var root = CreateTree(new int?[] { 9999, 9999, 9999 });

            // Act
            int result = solution.Rob(root);

            // Assert
            Assert.AreEqual(19998, result, $"Failed for {solutionName}");
        }

        #endregion

        #region Specific Pattern Tests

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Rob_ZigZagPattern_ReturnsOptimal(IHouseRobberIII_337 solution, string solutionName)
        {
            // Tree where optimal path zigzags
            // Tree:        5
            //            /   \
            //           20    10
            //          /  \     \
            //         1    1     15
            // Output: 35 (rob 20 + 15 = 35 or rob 5 + 1 + 1 + 15 = 22, so 35)

            // Arrange
            var root = CreateTree(new int?[] { 5, 20, 10, 1, 1, null, 15 });

            // Act
            int result = solution.Rob(root);

            // Assert
            Assert.AreEqual(35, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Rob_BalancedChoice_RootVsChildren_ReturnsOptimal(IHouseRobberIII_337 solution, string solutionName)
        {
            // Tree where robbing root vs children is exactly balanced
            // Tree:        15
            //            /    \
            //           7      8
            //          / \    / \
            //         3   4  5   6
            // Rob root: 15 + 3 + 4 + 5 + 6 = 33
            // Rob children: 7 + 8 = 15, but then can rob grandchildren? No.
            // Or skip root, rob children 7 + 8, then rob their grandchildren? No, that violates constraint.
            // Actually: rob root 15, rob grandchildren 3+4+5+6 = 15 + 18 = 33
            // Or: rob children 7 + 8 = 15
            // Output: 33

            // Arrange
            var root = CreateTree(new int?[] { 15, 7, 8, 3, 4, 5, 6 });

            // Act
            int result = solution.Rob(root);

            // Assert
            Assert.AreEqual(33, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Rob_SparseTree_ReturnsOptimal(IHouseRobberIII_337 solution, string solutionName)
        {
            // Sparse tree with missing nodes
            // Tree:        10
            //            /    \
            //           5     null
            //          / \
            //      null  3
            //           / \
            //          1   2
            // Output: 13 (rob 10 + 3 = 13 or rob 5 + 1 + 2 = 8, so 13)

            // Arrange
            var root = CreateTree(new int?[] { 10, 5, null, null, 3, 1, 2 });

            // Act
            int result = solution.Rob(root);

            // Assert
            Assert.AreEqual(13, result, $"Failed for {solutionName}");
        }

        #endregion

        #region Property-Based Tests

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Rob_ResultNeverNegative_WithPositiveValues(IHouseRobberIII_337 solution, string solutionName)
        {
            // Verify result is always >= 0 for positive values

            // Arrange
            var root = CreateTree(new int?[] { 1, 2, 3, 4, 5, 6, 7 });

            // Act
            int result = solution.Rob(root);

            // Assert
            Assert.IsTrue(result >= 0, $"Result should be non-negative for {solutionName}");
            Assert.IsTrue(result > 0, $"Result should be positive with positive values for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Rob_ResultAtLeastMaxSingleNode_Property(IHouseRobberIII_337 solution, string solutionName)
        {
            // Result should be at least the max value of any single node

            // Arrange
            var root = CreateTree(new int?[] { 10, 5, 20, 1, 2, 15, 25 });
            int maxNode = 25;

            // Act
            int result = solution.Rob(root);

            // Assert
            Assert.IsTrue(result >= maxNode, 
                $"Result should be at least max single node value for {solutionName}");
        }

        #endregion
    }
}
