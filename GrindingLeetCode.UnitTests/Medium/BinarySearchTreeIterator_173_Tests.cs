using LeetCodeProblems.CSharp.Tree;
using LeetCodeProblems.Interfaces.Medium;
using LeetCodeProblems.Shared;
using LeetCodeProblems.VisualBasic;

namespace GrindingLeetCode.UnitTests.Medium
{
    [TestClass]
    public class BinarySearchTreeIterator_173_Tests
    {
        public static IEnumerable<object[]> GetImplementations()
        {
            yield return new object[] {
                (Func<TreeNode, IBinarySearchTreeIterator_173>)(root => new BinarySearchTreeIterator_InOrderSuccessorSearch_CSharp_173(root)),
                "C# InorderSuccessorSearch"
            };
            yield return new object[] {
                (Func<TreeNode, IBinarySearchTreeIterator_173>)(root => new BinarySearchTreeIterator_Stack_CSharp_173(root)),
                "C# Stack"
            };
            yield return new object[] {
                (Func<TreeNode, IBinarySearchTreeIterator_173>)(root => new BinarySearchTreeIterator_InOrderSuccessor_VB_173(root)),
                "VB InorderSuccessorSearch"
            };
            yield return new object[] {
                (Func<TreeNode, IBinarySearchTreeIterator_173>)(root => new BinarySearchTreeIterator_Stack_VB_173(root)),
                "VB Stack"
            };
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
        public void BSTIterator_LeetCodeExample1_ReturnsInorderSequence(Func<TreeNode, IBinarySearchTreeIterator_173> factory, string solutionName)
        {
            // Input: ["BSTIterator", "next", "next", "hasNext", "next", "hasNext", "next", "hasNext", "next", "hasNext"]
            // [[[7, 3, 15, null, null, 9, 20]], [], [], [], [], [], [], [], [], []]
            // Output: [null, 3, 7, true, 9, true, 15, true, 20, false]
            //
            //       7
            //      / \
            //     3   15
            //        /  \
            //       9    20

            // Arrange
            var root = CreateBST(new int?[] { 7, 3, 15, null, null, 9, 20 });
            var iterator = factory(root);

            // Act & Assert
            Assert.AreEqual(3, iterator.Next(), $"Failed for {solutionName}: First Next() should return 3");
            Assert.AreEqual(7, iterator.Next(), $"Failed for {solutionName}: Second Next() should return 7");
            Assert.IsTrue(iterator.HasNext(), $"Failed for {solutionName}: HasNext() should return true");
            Assert.AreEqual(9, iterator.Next(), $"Failed for {solutionName}: Third Next() should return 9");
            Assert.IsTrue(iterator.HasNext(), $"Failed for {solutionName}: HasNext() should return true");
            Assert.AreEqual(15, iterator.Next(), $"Failed for {solutionName}: Fourth Next() should return 15");
            Assert.IsTrue(iterator.HasNext(), $"Failed for {solutionName}: HasNext() should return true");
            Assert.AreEqual(20, iterator.Next(), $"Failed for {solutionName}: Fifth Next() should return 20");
            Assert.IsFalse(iterator.HasNext(), $"Failed for {solutionName}: HasNext() should return false after all elements consumed");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void BSTIterator_LeetCodeExample2_SimpleTree_WorksCorrectly(Func<TreeNode, IBinarySearchTreeIterator_173> factory, string solutionName)
        {
            // Simple tree example
            //     2
            //    / \
            //   1   3

            // Arrange
            var root = CreateSimpleBST(2, left: 1, right: 3);
            var iterator = factory(root);

            // Act & Assert
            Assert.AreEqual(1, iterator.Next(), $"Failed for {solutionName}: First Next() should return 1");
            Assert.AreEqual(2, iterator.Next(), $"Failed for {solutionName}: Second Next() should return 2");
            Assert.AreEqual(3, iterator.Next(), $"Failed for {solutionName}: Third Next() should return 3");
            Assert.IsFalse(iterator.HasNext(), $"Failed for {solutionName}: HasNext() should return false after all elements");
        }

        #endregion

        #region Basic Tree Structures

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void BSTIterator_SingleNode_ReturnsOneValue(Func<TreeNode, IBinarySearchTreeIterator_173> factory, string solutionName)
        {
            // Arrange
            var root = new TreeNode(5);
            var iterator = factory(root);

            // Act & Assert
            Assert.IsTrue(iterator.HasNext(), $"Failed for {solutionName}: Should have next element");
            Assert.AreEqual(5, iterator.Next(), $"Failed for {solutionName}: Should return single value");
            Assert.IsFalse(iterator.HasNext(), $"Failed for {solutionName}: Should not have more elements");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void BSTIterator_TwoNodesLeftChild_ReturnsInorder(Func<TreeNode, IBinarySearchTreeIterator_173> factory, string solutionName)
        {
            //   2
            //  /
            // 1

            // Arrange
            var root = new TreeNode(2);
            root.left = new TreeNode(1);
            var iterator = factory(root);

            // Act & Assert
            Assert.AreEqual(1, iterator.Next(), $"Failed for {solutionName}: First should be 1");
            Assert.AreEqual(2, iterator.Next(), $"Failed for {solutionName}: Second should be 2");
            Assert.IsFalse(iterator.HasNext(), $"Failed for {solutionName}: Should not have more elements");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void BSTIterator_TwoNodesRightChild_ReturnsInorder(Func<TreeNode, IBinarySearchTreeIterator_173> factory, string solutionName)
        {
            // 1
            //  \
            //   2

            // Arrange
            var root = new TreeNode(1);
            root.right = new TreeNode(2);
            var iterator = factory(root);

            // Act & Assert
            Assert.AreEqual(1, iterator.Next(), $"Failed for {solutionName}: First should be 1");
            Assert.AreEqual(2, iterator.Next(), $"Failed for {solutionName}: Second should be 2");
            Assert.IsFalse(iterator.HasNext(), $"Failed for {solutionName}: Should not have more elements");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void BSTIterator_ThreeNodesComplete_ReturnsInorder(Func<TreeNode, IBinarySearchTreeIterator_173> factory, string solutionName)
        {
            //   2
            //  / \
            // 1   3

            // Arrange
            var root = CreateSimpleBST(2, left: 1, right: 3);
            var iterator = factory(root);

            // Act & Assert
            Assert.AreEqual(1, iterator.Next(), $"Failed for {solutionName}: First should be 1");
            Assert.AreEqual(2, iterator.Next(), $"Failed for {solutionName}: Second should be 2");
            Assert.AreEqual(3, iterator.Next(), $"Failed for {solutionName}: Third should be 3");
            Assert.IsFalse(iterator.HasNext(), $"Failed for {solutionName}: Should not have more elements");
        }

        #endregion

        #region Balanced BST Tests

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void BSTIterator_BalancedBST7Nodes_ReturnsInorder(Func<TreeNode, IBinarySearchTreeIterator_173> factory, string solutionName)
        {
            //       4
            //      / \
            //     2   6
            //    / \ / \
            //   1  3 5  7

            // Arrange
            var root = CreateBST(new int?[] { 4, 2, 6, 1, 3, 5, 7 });
            var iterator = factory(root);
            var expected = new[] { 1, 2, 3, 4, 5, 6, 7 };

            // Act & Assert
            for (int i = 0; i < expected.Length; i++)
            {
                Assert.IsTrue(iterator.HasNext(), $"Failed for {solutionName}: Should have next at position {i}");
                Assert.AreEqual(expected[i], iterator.Next(), $"Failed for {solutionName}: Value mismatch at position {i}");
            }
            Assert.IsFalse(iterator.HasNext(), $"Failed for {solutionName}: Should not have more elements");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void BSTIterator_BalancedBST15Nodes_ReturnsInorder(Func<TreeNode, IBinarySearchTreeIterator_173> factory, string solutionName)
        {
            //             8
            //          /     \
            //         4       12
            //        / \     /  \
            //       2   6   10   14
            //      / \ / \ / \  / \
            //     1  3 5 7 9 11 13 15

            // Arrange
            var root = CreateBST(new int?[] { 8, 4, 12, 2, 6, 10, 14, 1, 3, 5, 7, 9, 11, 13, 15 });
            var iterator = factory(root);
            var expected = Enumerable.Range(1, 15).ToArray();

            // Act & Assert
            for (int i = 0; i < expected.Length; i++)
            {
                Assert.IsTrue(iterator.HasNext(), $"Failed for {solutionName}: Should have next at position {i}");
                Assert.AreEqual(expected[i], iterator.Next(), $"Failed for {solutionName}: Value mismatch at position {i}");
            }
            Assert.IsFalse(iterator.HasNext(), $"Failed for {solutionName}: Should not have more elements");
        }

        #endregion

        #region Skewed BST Tests

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void BSTIterator_LeftSkewedTree_ReturnsInorder(Func<TreeNode, IBinarySearchTreeIterator_173> factory, string solutionName)
        {
            //      5
            //     /
            //    4
            //   /
            //  3
            // /
            //2
            ///
            //1

            // Arrange
            var root = CreateBST(new int?[] { 5, 4, null, 3, null, 2, null, 1 });
            var iterator = factory(root);
            var expected = new[] { 1, 2, 3, 4, 5 };

            // Act & Assert
            for (int i = 0; i < expected.Length; i++)
            {
                Assert.IsTrue(iterator.HasNext(), $"Failed for {solutionName}: Should have next at position {i}");
                Assert.AreEqual(expected[i], iterator.Next(), $"Failed for {solutionName}: Value mismatch at position {i}");
            }
            Assert.IsFalse(iterator.HasNext(), $"Failed for {solutionName}: Should not have more elements");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void BSTIterator_RightSkewedTree_ReturnsInorder(Func<TreeNode, IBinarySearchTreeIterator_173> factory, string solutionName)
        {
            // 1
            //  \
            //   2
            //    \
            //     3
            //      \
            //       4
            //        \
            //         5

            // Arrange
            var root = CreateBST(new int?[] { 1, null, 2, null, 3, null, 4, null, 5 });
            var iterator = factory(root);
            var expected = new[] { 1, 2, 3, 4, 5 };

            // Act & Assert
            for (int i = 0; i < expected.Length; i++)
            {
                Assert.IsTrue(iterator.HasNext(), $"Failed for {solutionName}: Should have next at position {i}");
                Assert.AreEqual(expected[i], iterator.Next(), $"Failed for {solutionName}: Value mismatch at position {i}");
            }
            Assert.IsFalse(iterator.HasNext(), $"Failed for {solutionName}: Should not have more elements");
        }

        #endregion

        #region HasNext Behavior Tests

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void HasNext_CalledMultipleTimes_ReturnsSameResult(Func<TreeNode, IBinarySearchTreeIterator_173> factory, string solutionName)
        {
            // Arrange
            var root = CreateSimpleBST(2, left: 1, right: 3);
            var iterator = factory(root);

            // Act & Assert - HasNext should not consume elements
            Assert.IsTrue(iterator.HasNext(), $"Failed for {solutionName}: First HasNext should return true");
            Assert.IsTrue(iterator.HasNext(), $"Failed for {solutionName}: Second HasNext should return true");
            Assert.IsTrue(iterator.HasNext(), $"Failed for {solutionName}: Third HasNext should return true");
            
            // Next should still return the first element
            Assert.AreEqual(1, iterator.Next(), $"Failed for {solutionName}: Next should return 1");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void HasNext_AtEnd_ReturnsFalse(Func<TreeNode, IBinarySearchTreeIterator_173> factory, string solutionName)
        {
            // Arrange
            var root = CreateSimpleBST(2, left: 1, right: 3);
            var iterator = factory(root);

            // Act - Consume all elements
            iterator.Next(); // 1
            iterator.Next(); // 2
            iterator.Next(); // 3

            // Assert
            Assert.IsFalse(iterator.HasNext(), $"Failed for {solutionName}: HasNext at end should return false");
            Assert.IsFalse(iterator.HasNext(), $"Failed for {solutionName}: HasNext called again should still return false");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void HasNext_InterleavedWithNext_WorksCorrectly(Func<TreeNode, IBinarySearchTreeIterator_173> factory, string solutionName)
        {
            // Arrange
            var root = CreateBST(new int?[] { 4, 2, 6, 1, 3, 5, 7 });
            var iterator = factory(root);

            // Act & Assert - Interleave HasNext and Next calls
            Assert.IsTrue(iterator.HasNext(), $"Failed for {solutionName}: Should have next (1st check)");
            Assert.AreEqual(1, iterator.Next(), $"Failed for {solutionName}: Should return 1");
            
            Assert.IsTrue(iterator.HasNext(), $"Failed for {solutionName}: Should have next (2nd check)");
            Assert.IsTrue(iterator.HasNext(), $"Failed for {solutionName}: Should have next (2nd check repeated)");
            Assert.AreEqual(2, iterator.Next(), $"Failed for {solutionName}: Should return 2");
            
            Assert.AreEqual(3, iterator.Next(), $"Failed for {solutionName}: Should return 3");
            Assert.IsTrue(iterator.HasNext(), $"Failed for {solutionName}: Should have next (3rd check)");
            
            Assert.AreEqual(4, iterator.Next(), $"Failed for {solutionName}: Should return 4");
            Assert.AreEqual(5, iterator.Next(), $"Failed for {solutionName}: Should return 5");
            Assert.AreEqual(6, iterator.Next(), $"Failed for {solutionName}: Should return 6");
            Assert.IsTrue(iterator.HasNext(), $"Failed for {solutionName}: Should have next (4th check)");
            
            Assert.AreEqual(7, iterator.Next(), $"Failed for {solutionName}: Should return 7");
            Assert.IsFalse(iterator.HasNext(), $"Failed for {solutionName}: Should not have more elements");
        }

        #endregion

        #region Edge Cases

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void BSTIterator_NegativeValues_ReturnsInorder(Func<TreeNode, IBinarySearchTreeIterator_173> factory, string solutionName)
        {
            //        0
            //      /   \
            //    -2     2
            //    / \   / \
            //  -3 -1  1  3

            // Arrange
            var root = CreateBST(new int?[] { 0, -2, 2, -3, -1, 1, 3 });
            var iterator = factory(root);
            var expected = new[] { -3, -2, -1, 0, 1, 2, 3 };

            // Act & Assert
            for (int i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i], iterator.Next(), $"Failed for {solutionName}: Value mismatch at position {i}");
            }
            Assert.IsFalse(iterator.HasNext(), $"Failed for {solutionName}: Should not have more elements");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void BSTIterator_AllNegativeValues_ReturnsInorder(Func<TreeNode, IBinarySearchTreeIterator_173> factory, string solutionName)
        {
            //       -4
            //       / \
            //     -6  -2
            //     / \ / \
            //   -7 -5-3 -1

            // Arrange
            var root = CreateBST(new int?[] { -4, -6, -2, -7, -5, -3, -1 });
            var iterator = factory(root);
            var expected = new[] { -7, -6, -5, -4, -3, -2, -1 };

            // Act & Assert
            for (int i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i], iterator.Next(), $"Failed for {solutionName}: Value mismatch at position {i}");
            }
            Assert.IsFalse(iterator.HasNext(), $"Failed for {solutionName}: Should not have more elements");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void BSTIterator_LargeValues_ReturnsInorder(Func<TreeNode, IBinarySearchTreeIterator_173> factory, string solutionName)
        {
            //         100
            //        /   \
            //       50   150
            //      / \   / \
            //     25 75 125 175

            // Arrange
            var root = CreateBST(new int?[] { 100, 50, 150, 25, 75, 125, 175 });
            var iterator = factory(root);
            var expected = new[] { 25, 50, 75, 100, 125, 150, 175 };

            // Act & Assert
            for (int i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i], iterator.Next(), $"Failed for {solutionName}: Value mismatch at position {i}");
            }
            Assert.IsFalse(iterator.HasNext(), $"Failed for {solutionName}: Should not have more elements");
        }

        #endregion

        #region Complex BST Tests

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void BSTIterator_ComplexUnbalancedBST_ReturnsInorder(Func<TreeNode, IBinarySearchTreeIterator_173> factory, string solutionName)
        {
            //           10
            //          /  \
            //         5    15
            //        / \     \
            //       3   7     20
            //      / \   \
            //     1   4   9

            // Arrange
            var root = CreateBST(new int?[] { 10, 5, 15, 3, 7, null, 20, 1, 4, null, 9 });
            var iterator = factory(root);
            var expected = new[] { 1, 3, 4, 5, 7, 9, 10, 15, 20 };

            // Act & Assert
            for (int i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i], iterator.Next(), $"Failed for {solutionName}: Value mismatch at position {i}");
            }
            Assert.IsFalse(iterator.HasNext(), $"Failed for {solutionName}: Should not have more elements");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void BSTIterator_SparseTree_ReturnsInorder(Func<TreeNode, IBinarySearchTreeIterator_173> factory, string solutionName)
        {
            //       8
            //      / \
            //     4   12
            //      \  /
            //       6 10

            // Arrange
            var root = CreateBST(new int?[] { 8, 4, 12, null, 6, 10 });
            var iterator = factory(root);
            var expected = new[] { 4, 6, 8, 10, 12 };

            // Act & Assert
            for (int i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i], iterator.Next(), $"Failed for {solutionName}: Value mismatch at position {i}");
            }
            Assert.IsFalse(iterator.HasNext(), $"Failed for {solutionName}: Should not have more elements");
        }

        #endregion

        #region Iterator Consistency Tests

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void BSTIterator_MultipleIterators_AreIndependent(Func<TreeNode, IBinarySearchTreeIterator_173> factory, string solutionName)
        {
            // Arrange
            var root = CreateSimpleBST(2, left: 1, right: 3);
            var iterator1 = factory(root);
            var iterator2 = factory(root);

            // Act - Advance first iterator
            Assert.AreEqual(1, iterator1.Next(), $"Failed for {solutionName}: Iterator1 first value");
            Assert.AreEqual(2, iterator1.Next(), $"Failed for {solutionName}: Iterator1 second value");

            // Assert - Second iterator should start from beginning
            Assert.AreEqual(1, iterator2.Next(), $"Failed for {solutionName}: Iterator2 first value");
            Assert.AreEqual(2, iterator2.Next(), $"Failed for {solutionName}: Iterator2 second value");
            Assert.AreEqual(3, iterator2.Next(), $"Failed for {solutionName}: Iterator2 third value");

            // First iterator should still have one element
            Assert.IsTrue(iterator1.HasNext(), $"Failed for {solutionName}: Iterator1 should have next");
            Assert.AreEqual(3, iterator1.Next(), $"Failed for {solutionName}: Iterator1 third value");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void BSTIterator_OnlyCallsNext_WorksCorrectly(Func<TreeNode, IBinarySearchTreeIterator_173> factory, string solutionName)
        {
            // Test that iterator works without ever calling HasNext

            // Arrange
            var root = CreateBST(new int?[] { 4, 2, 6, 1, 3, 5, 7 });
            var iterator = factory(root);
            var expected = new[] { 1, 2, 3, 4, 5, 6, 7 };

            // Act & Assert - Never call HasNext
            for (int i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i], iterator.Next(), $"Failed for {solutionName}: Value mismatch at position {i}");
            }
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void BSTIterator_OnlyCallsHasNext_WorksCorrectly(Func<TreeNode, IBinarySearchTreeIterator_173> factory, string solutionName)
        {
            // Arrange
            var root = CreateSimpleBST(2, left: 1, right: 3);
            var iterator = factory(root);

            // Act & Assert - Call HasNext many times without Next
            for (int i = 0; i < 10; i++)
            {
                Assert.IsTrue(iterator.HasNext(), $"Failed for {solutionName}: HasNext call {i} should return true");
            }

            // Now consume all elements
            iterator.Next(); // 1
            iterator.Next(); // 2
            iterator.Next(); // 3

            // HasNext should now return false
            Assert.IsFalse(iterator.HasNext(), $"Failed for {solutionName}: HasNext should return false after consuming all");
        }

        #endregion

        #region Larger Tree Tests

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void BSTIterator_LargeBalancedTree31Nodes_ReturnsInorder(Func<TreeNode, IBinarySearchTreeIterator_173> factory, string solutionName)
        {
            // Perfect binary tree with 5 levels (31 nodes)

            // Arrange
            var root = CreateBST(new int?[] { 
                16, 8, 24, 4, 12, 20, 28, 2, 6, 10, 14, 18, 22, 26, 30,
                1, 3, 5, 7, 9, 11, 13, 15, 17, 19, 21, 23, 25, 27, 29, 31
            });
            var iterator = factory(root);
            var expected = Enumerable.Range(1, 31).ToArray();

            // Act & Assert
            for (int i = 0; i < expected.Length; i++)
            {
                Assert.IsTrue(iterator.HasNext(), $"Failed for {solutionName}: Should have next at position {i}");
                Assert.AreEqual(expected[i], iterator.Next(), $"Failed for {solutionName}: Value mismatch at position {i}");
            }
            Assert.IsFalse(iterator.HasNext(), $"Failed for {solutionName}: Should not have more elements");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void BSTIterator_DeepLeftSkewed20Nodes_ReturnsInorder(Func<TreeNode, IBinarySearchTreeIterator_173> factory, string solutionName)
        {
            // Deep left-skewed tree (20 nodes)

            // Arrange
            TreeNode root = new TreeNode(20);
            TreeNode current = root;
            for (int i = 19; i >= 1; i--)
            {
                current.left = new TreeNode(i);
                current = current.left;
            }

            var iterator = factory(root);
            var expected = Enumerable.Range(1, 20).ToArray();

            // Act & Assert
            for (int i = 0; i < expected.Length; i++)
            {
                Assert.IsTrue(iterator.HasNext(), $"Failed for {solutionName}: Should have next at position {i}");
                Assert.AreEqual(expected[i], iterator.Next(), $"Failed for {solutionName}: Value mismatch at position {i}");
            }
            Assert.IsFalse(iterator.HasNext(), $"Failed for {solutionName}: Should not have more elements");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void BSTIterator_DeepRightSkewed20Nodes_ReturnsInorder(Func<TreeNode, IBinarySearchTreeIterator_173> factory, string solutionName)
        {
            // Deep right-skewed tree (20 nodes)

            // Arrange
            TreeNode root = new TreeNode(1);
            TreeNode current = root;
            for (int i = 2; i <= 20; i++)
            {
                current.right = new TreeNode(i);
                current = current.right;
            }

            var iterator = factory(root);
            var expected = Enumerable.Range(1, 20).ToArray();

            // Act & Assert
            for (int i = 0; i < expected.Length; i++)
            {
                Assert.IsTrue(iterator.HasNext(), $"Failed for {solutionName}: Should have next at position {i}");
                Assert.AreEqual(expected[i], iterator.Next(), $"Failed for {solutionName}: Value mismatch at position {i}");
            }
            Assert.IsFalse(iterator.HasNext(), $"Failed for {solutionName}: Should not have more elements");
        }

        #endregion

        #region Stress Tests

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void BSTIterator_ConsumeHalfCheckHasNext_WorksCorrectly(Func<TreeNode, IBinarySearchTreeIterator_173> factory, string solutionName)
        {
            // Arrange
            var root = CreateBST(new int?[] { 8, 4, 12, 2, 6, 10, 14, 1, 3, 5, 7, 9, 11, 13, 15 });
            var iterator = factory(root);

            // Act - Consume half the elements
            for (int i = 1; i <= 7; i++)
            {
                Assert.AreEqual(i, iterator.Next(), $"Failed for {solutionName}: Value mismatch at position {i}");
            }

            // Assert - Should still have more elements
            Assert.IsTrue(iterator.HasNext(), $"Failed for {solutionName}: Should have more elements");

            // Consume rest
            for (int i = 8; i <= 15; i++)
            {
                Assert.AreEqual(i, iterator.Next(), $"Failed for {solutionName}: Value mismatch at position {i}");
            }

            Assert.IsFalse(iterator.HasNext(), $"Failed for {solutionName}: Should not have more elements");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void BSTIterator_AlternateHasNextAndNext_WorksCorrectly(Func<TreeNode, IBinarySearchTreeIterator_173> factory, string solutionName)
        {
            // Arrange
            var root = CreateBST(new int?[] { 4, 2, 6, 1, 3, 5, 7 });
            var iterator = factory(root);
            var expected = new[] { 1, 2, 3, 4, 5, 6, 7 };

            // Act & Assert - Strictly alternate between HasNext and Next
            for (int i = 0; i < expected.Length; i++)
            {
                Assert.IsTrue(iterator.HasNext(), $"Failed for {solutionName}: HasNext should be true at position {i}");
                Assert.AreEqual(expected[i], iterator.Next(), $"Failed for {solutionName}: Value mismatch at position {i}");
            }

            Assert.IsFalse(iterator.HasNext(), $"Failed for {solutionName}: Final HasNext should be false");
        }

        #endregion

        #region Verification Against Inorder Traversal

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void BSTIterator_MatchesInorderTraversal_Simple(Func<TreeNode, IBinarySearchTreeIterator_173> factory, string solutionName)
        {
            // Arrange
            var root = CreateBST(new int?[] { 4, 2, 6, 1, 3, 5, 7 });
            var expected = InorderTraversal(root);
            var iterator = factory(root);

            // Act & Assert
            for (int i = 0; i < expected.Count; i++)
            {
                Assert.IsTrue(iterator.HasNext(), $"Failed for {solutionName}: Should have next at position {i}");
                Assert.AreEqual(expected[i], iterator.Next(), $"Failed for {solutionName}: Value mismatch at position {i}");
            }
            Assert.IsFalse(iterator.HasNext(), $"Failed for {solutionName}: Should not have more elements");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void BSTIterator_MatchesInorderTraversal_Complex(Func<TreeNode, IBinarySearchTreeIterator_173> factory, string solutionName)
        {
            // Arrange
            var root = CreateBST(new int?[] { 20, 10, 30, 5, 15, 25, 35, 3, 7, 12, 18 });
            var expected = InorderTraversal(root);
            var iterator = factory(root);

            // Act & Assert
            for (int i = 0; i < expected.Count; i++)
            {
                Assert.IsTrue(iterator.HasNext(), $"Failed for {solutionName}: Should have next at position {i}");
                Assert.AreEqual(expected[i], iterator.Next(), $"Failed for {solutionName}: Value mismatch at position {i}");
            }
            Assert.IsFalse(iterator.HasNext(), $"Failed for {solutionName}: Should not have more elements");
        }

        #endregion
    }
}
