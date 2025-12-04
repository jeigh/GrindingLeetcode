using LeetCodeProblems.CSharp.LinkedList;
using LeetCodeProblems.Interfaces.Medium;
using LeetCodeProblems.Shared;

namespace GrindingLeetCode.UnitTests.Medium
{
    [TestClass]
    public class DeleteNodeInALinkedList_237_Tests
    {
        public static IEnumerable<object[]> GetImplementations()
        {
            yield return new object[] { new DeleteNodeInALinkedListCSharp_237() };
        }

        #region Helper Methods

        /// <summary>
        /// Creates a linked list from an array of values and returns both the head and a reference to a specific node
        /// </summary>
        /// <param name="values">Array of values for the list</param>
        /// <param name="nodeIndex">Index of the node to return (0-based)</param>
        /// <returns>Tuple of (head, nodeToDelete)</returns>
        private (ListNode head, ListNode nodeToDelete) CreateListAndGetNode(int[] values, int nodeIndex)
        {
            if (values == null || values.Length == 0)
                return (null, null);

            ListNode head = new ListNode(values[0]);
            ListNode current = head;
            ListNode targetNode = (nodeIndex == 0) ? head : null;

            for (int i = 1; i < values.Length; i++)
            {
                current.next = new ListNode(values[i]);
                current = current.next;

                if (i == nodeIndex)
                {
                    targetNode = current;
                }
            }

            return (head, targetNode);
        }

        /// <summary>
        /// Converts a linked list to an array for easy comparison
        /// </summary>
        private int[] LinkedListToArray(ListNode head)
        {
            var result = new List<int>();
            var current = head;
            while (current != null)
            {
                result.Add(current.val);
                current = current.next;
            }
            return result.ToArray();
        }

        /// <summary>
        /// Asserts that two linked lists have the same values
        /// </summary>
        private void AssertListEquals(int[] expected, ListNode actual)
        {
            var actualArray = LinkedListToArray(actual);
            CollectionAssert.AreEqual(expected, actualArray);
        }

        #endregion

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void DeleteNode_Example1_DeletesNode5(IDeleteNodeInALinkedList_237 solution)
        {
            // Arrange: [4,5,1,9], node = 5
            var (head, nodeToDelete) = CreateListAndGetNode(new[] { 4, 5, 1, 9 }, 1);

            // Act
            solution.DeleteNode(nodeToDelete);

            // Assert: [4,1,9]
            AssertListEquals(new[] { 4, 1, 9 }, head);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void DeleteNode_Example2_DeletesNode1(IDeleteNodeInALinkedList_237 solution)
        {
            // Arrange: [4,5,1,9], node = 1
            var (head, nodeToDelete) = CreateListAndGetNode(new[] { 4, 5, 1, 9 }, 2);

            // Act
            solution.DeleteNode(nodeToDelete);

            // Assert: [4,5,9]
            AssertListEquals(new[] { 4, 5, 9 }, head);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void DeleteNode_DeleteFirstNode_WorksCorrectly(IDeleteNodeInALinkedList_237 solution)
        {
            // Arrange: [1,2,3,4], node = 1 (first node)
            var (head, nodeToDelete) = CreateListAndGetNode(new[] { 1, 2, 3, 4 }, 0);

            // Act
            solution.DeleteNode(nodeToDelete);

            // Assert: [2,3,4]
            AssertListEquals(new[] { 2, 3, 4 }, head);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void DeleteNode_DeleteMiddleNode_WorksCorrectly(IDeleteNodeInALinkedList_237 solution)
        {
            // Arrange: [1,2,3,4,5], node = 3 (middle node)
            var (head, nodeToDelete) = CreateListAndGetNode(new[] { 1, 2, 3, 4, 5 }, 2);

            // Act
            solution.DeleteNode(nodeToDelete);

            // Assert: [1,2,4,5]
            AssertListEquals(new[] { 1, 2, 4, 5 }, head);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void DeleteNode_DeleteSecondToLastNode_WorksCorrectly(IDeleteNodeInALinkedList_237 solution)
        {
            // Arrange: [1,2,3,4], node = 3 (second to last)
            var (head, nodeToDelete) = CreateListAndGetNode(new[] { 1, 2, 3, 4 }, 2);

            // Act
            solution.DeleteNode(nodeToDelete);

            // Assert: [1,2,4]
            AssertListEquals(new[] { 1, 2, 4 }, head);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void DeleteNode_TwoNodeList_DeleteFirst_WorksCorrectly(IDeleteNodeInALinkedList_237 solution)
        {
            // Arrange: [1,2], node = 1
            var (head, nodeToDelete) = CreateListAndGetNode(new[] { 1, 2 }, 0);

            // Act
            solution.DeleteNode(nodeToDelete);

            // Assert: [2]
            AssertListEquals(new[] { 2 }, head);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void DeleteNode_ThreeNodeList_DeleteMiddle_WorksCorrectly(IDeleteNodeInALinkedList_237 solution)
        {
            // Arrange: [1,2,3], node = 2
            var (head, nodeToDelete) = CreateListAndGetNode(new[] { 1, 2, 3 }, 1);

            // Act
            solution.DeleteNode(nodeToDelete);

            // Assert: [1,3]
            AssertListEquals(new[] { 1, 3 }, head);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void DeleteNode_WithNegativeValues_DeletesCorrectly(IDeleteNodeInALinkedList_237 solution)
        {
            // Arrange: [-1,-2,-3,-4], node = -2
            var (head, nodeToDelete) = CreateListAndGetNode(new[] { -1, -2, -3, -4 }, 1);

            // Act
            solution.DeleteNode(nodeToDelete);

            // Assert: [-1,-3,-4]
            AssertListEquals(new[] { -1, -3, -4 }, head);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void DeleteNode_WithZeros_DeletesCorrectly(IDeleteNodeInALinkedList_237 solution)
        {
            // Arrange: [0,1,0,2], node = 0 (second one, index 2)
            var (head, nodeToDelete) = CreateListAndGetNode(new[] { 0, 1, 0, 2 }, 2);

            // Act
            solution.DeleteNode(nodeToDelete);

            // Assert: [0,1,2]
            AssertListEquals(new[] { 0, 1, 2 }, head);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void DeleteNode_LongList_DeleteNodeInMiddle_WorksCorrectly(IDeleteNodeInALinkedList_237 solution)
        {
            // Arrange: [1,2,3,4,5,6,7,8,9,10], node = 5
            var (head, nodeToDelete) = CreateListAndGetNode(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, 4);

            // Act
            solution.DeleteNode(nodeToDelete);

            // Assert: [1,2,3,4,6,7,8,9,10]
            AssertListEquals(new[] { 1, 2, 3, 4, 6, 7, 8, 9, 10 }, head);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void DeleteNode_LongList_DeleteFirstNode_WorksCorrectly(IDeleteNodeInALinkedList_237 solution)
        {
            // Arrange: [1,2,3,4,5,6,7,8,9,10], node = 1 (first)
            var (head, nodeToDelete) = CreateListAndGetNode(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, 0);

            // Act
            solution.DeleteNode(nodeToDelete);

            // Assert: [2,3,4,5,6,7,8,9,10]
            AssertListEquals(new[] { 2, 3, 4, 5, 6, 7, 8, 9, 10 }, head);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void DeleteNode_LongList_DeleteNearEnd_WorksCorrectly(IDeleteNodeInALinkedList_237 solution)
        {
            // Arrange: [1,2,3,4,5,6,7,8,9,10], node = 9 (second to last)
            var (head, nodeToDelete) = CreateListAndGetNode(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, 8);

            // Act
            solution.DeleteNode(nodeToDelete);

            // Assert: [1,2,3,4,5,6,7,8,10]
            AssertListEquals(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 10 }, head);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void DeleteNode_ListWithDuplicateValues_DeletesCorrectNode(IDeleteNodeInALinkedList_237 solution)
        {
            // Arrange: [5,5,5,5], delete the second 5 (index 1)
            var (head, nodeToDelete) = CreateListAndGetNode(new[] { 5, 5, 5, 5 }, 1);

            // Act
            solution.DeleteNode(nodeToDelete);

            // Assert: [5,5,5] - should have 3 nodes with value 5
            AssertListEquals(new[] { 5, 5, 5 }, head);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void DeleteNode_MixedPositiveAndNegative_DeletesCorrectly(IDeleteNodeInALinkedList_237 solution)
        {
            // Arrange: [-5,10,-3,20,-1], node = -3
            var (head, nodeToDelete) = CreateListAndGetNode(new[] { -5, 10, -3, 20, -1 }, 2);

            // Act
            solution.DeleteNode(nodeToDelete);

            // Assert: [-5,10,20,-1]
            AssertListEquals(new[] { -5, 10, 20, -1 }, head);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void DeleteNode_LargeValues_DeletesCorrectly(IDeleteNodeInALinkedList_237 solution)
        {
            // Arrange: [1000,2000,3000,4000], node = 2000
            var (head, nodeToDelete) = CreateListAndGetNode(new[] { 1000, 2000, 3000, 4000 }, 1);

            // Act
            solution.DeleteNode(nodeToDelete);

            // Assert: [1000,3000,4000]
            AssertListEquals(new[] { 1000, 3000, 4000 }, head);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void DeleteNode_SequentialValues_DeleteMiddle_WorksCorrectly(IDeleteNodeInALinkedList_237 solution)
        {
            // Arrange: [1,2,3,4,5,6], node = 3
            var (head, nodeToDelete) = CreateListAndGetNode(new[] { 1, 2, 3, 4, 5, 6 }, 2);

            // Act
            solution.DeleteNode(nodeToDelete);

            // Assert: [1,2,4,5,6]
            AssertListEquals(new[] { 1, 2, 4, 5, 6 }, head);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void DeleteNode_NonSequentialValues_DeletesCorrectly(IDeleteNodeInALinkedList_237 solution)
        {
            // Arrange: [10,50,30,70,20], node = 30
            var (head, nodeToDelete) = CreateListAndGetNode(new[] { 10, 50, 30, 70, 20 }, 2);

            // Act
            solution.DeleteNode(nodeToDelete);

            // Assert: [10,50,70,20]
            AssertListEquals(new[] { 10, 50, 70, 20 }, head);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void DeleteNode_AlternatingValues_DeletesCorrectly(IDeleteNodeInALinkedList_237 solution)
        {
            // Arrange: [1,-1,2,-2,3,-3], node = 2
            var (head, nodeToDelete) = CreateListAndGetNode(new[] { 1, -1, 2, -2, 3, -3 }, 2);

            // Act
            solution.DeleteNode(nodeToDelete);

            // Assert: [1,-1,-2,3,-3]
            AssertListEquals(new[] { 1, -1, -2, 3, -3 }, head);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void DeleteNode_FourNodes_DeleteSecond_WorksCorrectly(IDeleteNodeInALinkedList_237 solution)
        {
            // Arrange: [7,14,21,28], node = 14
            var (head, nodeToDelete) = CreateListAndGetNode(new[] { 7, 14, 21, 28 }, 1);

            // Act
            solution.DeleteNode(nodeToDelete);

            // Assert: [7,21,28]
            AssertListEquals(new[] { 7, 21, 28 }, head);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void DeleteNode_FiveNodes_DeleteThird_WorksCorrectly(IDeleteNodeInALinkedList_237 solution)
        {
            // Arrange: [10,20,30,40,50], node = 30
            var (head, nodeToDelete) = CreateListAndGetNode(new[] { 10, 20, 30, 40, 50 }, 2);

            // Act
            solution.DeleteNode(nodeToDelete);

            // Assert: [10,20,40,50]
            AssertListEquals(new[] { 10, 20, 40, 50 }, head);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void DeleteNode_WithZeroInMiddle_DeletesZero(IDeleteNodeInALinkedList_237 solution)
        {
            // Arrange: [1,0,2], node = 0
            var (head, nodeToDelete) = CreateListAndGetNode(new[] { 1, 0, 2 }, 1);

            // Act
            solution.DeleteNode(nodeToDelete);

            // Assert: [1,2]
            AssertListEquals(new[] { 1, 2 }, head);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void DeleteNode_DescendingOrder_DeletesCorrectly(IDeleteNodeInALinkedList_237 solution)
        {
            // Arrange: [10,8,6,4,2], node = 6
            var (head, nodeToDelete) = CreateListAndGetNode(new[] { 10, 8, 6, 4, 2 }, 2);

            // Act
            solution.DeleteNode(nodeToDelete);

            // Assert: [10,8,4,2]
            AssertListEquals(new[] { 10, 8, 4, 2 }, head);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void DeleteNode_RandomOrder_DeletesCorrectly(IDeleteNodeInALinkedList_237 solution)
        {
            // Arrange: [15,3,9,22,1], node = 9
            var (head, nodeToDelete) = CreateListAndGetNode(new[] { 15, 3, 9, 22, 1 }, 2);

            // Act
            solution.DeleteNode(nodeToDelete);

            // Assert: [15,3,22,1]
            AssertListEquals(new[] { 15, 3, 22, 1 }, head);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void DeleteNode_VeryLongList_DeletesCorrectly(IDeleteNodeInALinkedList_237 solution)
        {
            // Arrange: List of 20 elements, delete element at index 10
            int[] values = new int[20];
            for (int i = 0; i < 20; i++)
            {
                values[i] = (i + 1) * 10;
            }
            var (head, nodeToDelete) = CreateListAndGetNode(values, 10);

            // Act
            solution.DeleteNode(nodeToDelete);

            // Assert: Should have 19 elements
            var result = LinkedListToArray(head);
            Assert.AreEqual(19, result.Length);
            Assert.IsFalse(result.Contains(110)); // Value at index 10 was 110
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void DeleteNode_EnsuresListSizeDecreasesBy1(IDeleteNodeInALinkedList_237 solution)
        {
            // Arrange: [1,2,3,4,5]
            var (head, nodeToDelete) = CreateListAndGetNode(new[] { 1, 2, 3, 4, 5 }, 2);
            int originalLength = LinkedListToArray(head).Length;

            // Act
            solution.DeleteNode(nodeToDelete);

            // Assert
            int newLength = LinkedListToArray(head).Length;
            Assert.AreEqual(originalLength - 1, newLength);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void DeleteNode_EnsuresOrderBeforeNodePreserved(IDeleteNodeInALinkedList_237 solution)
        {
            // Arrange: [10,20,30,40,50], delete 30 (index 2)
            var (head, nodeToDelete) = CreateListAndGetNode(new[] { 10, 20, 30, 40, 50 }, 2);

            // Act
            solution.DeleteNode(nodeToDelete);

            // Assert: First two elements should remain 10, 20
            var result = LinkedListToArray(head);
            Assert.AreEqual(10, result[0]);
            Assert.AreEqual(20, result[1]);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void DeleteNode_EnsuresOrderAfterNodePreserved(IDeleteNodeInALinkedList_237 solution)
        {
            // Arrange: [10,20,30,40,50], delete 30 (index 2)
            var (head, nodeToDelete) = CreateListAndGetNode(new[] { 10, 20, 30, 40, 50 }, 2);

            // Act
            solution.DeleteNode(nodeToDelete);

            // Assert: Last two elements should remain 40, 50 (now at indices 2, 3)
            var result = LinkedListToArray(head);
            Assert.AreEqual(40, result[2]);
            Assert.AreEqual(50, result[3]);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void DeleteNode_DeletedValueNoLongerInList(IDeleteNodeInALinkedList_237 solution)
        {
            // Arrange: [5,10,15,20,25], delete 15
            var (head, nodeToDelete) = CreateListAndGetNode(new[] { 5, 10, 15, 20, 25 }, 2);
            int deletedValue = nodeToDelete.val;

            // Act
            solution.DeleteNode(nodeToDelete);

            // Assert: 15 should not exist in the list
            var result = LinkedListToArray(head);
            Assert.IsFalse(result.Contains(deletedValue));
        }
    }
}
