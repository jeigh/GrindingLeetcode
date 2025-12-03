using LeetCodeProblems.CSharp.LinkedList;
using LeetCodeProblems.Shared;

namespace GrindingLeetCode.UnitTests.Easy
{
    [TestClass]
    public class RemoveDuplicatesFromSortedList_83_Tests
    {
        private RemoveDuplicatesFromSortedList_83 _solution;

        [TestInitialize]
        public void Initialize()
        {
            _solution = new RemoveDuplicatesFromSortedList_83();
        }

        #region Helper Methods

        private ListNode CreateLinkedList(int[] values)
        {
            if (values == null || values.Length == 0)
                return null;

            ListNode head = null;
            for (int i = values.Length - 1; i >= 0; i--)
            {
                head = new ListNode(values[i], head);
            }
            return head;
        }

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

        private void AssertLinkedListEquals(int[] expected, ListNode actual)
        {
            var actualArray = LinkedListToArray(actual);
            CollectionAssert.AreEqual(expected, actualArray);
        }

        #endregion

        #region LeetCode Examples

        [TestMethod]
        public void DeleteDuplicates_Example1_RemovesDuplicatesCorrectly()
        {
            // Arrange: [1,1,2]
            var head = CreateLinkedList(new[] { 1, 1, 2 });

            // Act
            var result = _solution.DeleteDuplicates(head);

            // Assert: [1,2]
            AssertLinkedListEquals(new[] { 1, 2 }, result);
        }

        [TestMethod]
        public void DeleteDuplicates_Example2_RemovesDuplicatesCorrectly()
        {
            // Arrange: [1,1,2,3,3]
            var head = CreateLinkedList(new[] { 1, 1, 2, 3, 3 });

            // Act
            var result = _solution.DeleteDuplicates(head);

            // Assert: [1,2,3]
            AssertLinkedListEquals(new[] { 1, 2, 3 }, result);
        }

        #endregion

        #region Edge Cases

        [TestMethod]
        public void DeleteDuplicates_EmptyList_ReturnsNull()
        {
            // Arrange
            ListNode head = null;

            // Act
            var result = _solution.DeleteDuplicates(head);

            // Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void DeleteDuplicates_SingleElement_ReturnsSameElement()
        {
            // Arrange: [1]
            var head = CreateLinkedList(new[] { 1 });

            // Act
            var result = _solution.DeleteDuplicates(head);

            // Assert: [1]
            AssertLinkedListEquals(new[] { 1 }, result);
        }

        [TestMethod]
        public void DeleteDuplicates_NoDuplicates_ReturnsOriginalList()
        {
            // Arrange: [1,2,3,4,5]
            var head = CreateLinkedList(new[] { 1, 2, 3, 4, 5 });

            // Act
            var result = _solution.DeleteDuplicates(head);

            // Assert: [1,2,3,4,5]
            AssertLinkedListEquals(new[] { 1, 2, 3, 4, 5 }, result);
        }

        [TestMethod]
        public void DeleteDuplicates_AllDuplicates_ReturnsSingleElement()
        {
            // Arrange: [1,1,1,1,1]
            var head = CreateLinkedList(new[] { 1, 1, 1, 1, 1 });

            // Act
            var result = _solution.DeleteDuplicates(head);

            // Assert: [1]
            AssertLinkedListEquals([ 1 ], result);
        }

        [TestMethod]
        public void DeleteDuplicates_TwoIdenticalElements_ReturnsOneElement()
        {
            // Arrange: [2,2]
            var head = CreateLinkedList(new[] { 2, 2 });

            // Act
            var result = _solution.DeleteDuplicates(head);

            // Assert: [2]
            AssertLinkedListEquals(new[] { 2 }, result);
        }

        #endregion

        #region Various Duplicate Patterns

        [TestMethod]
        public void DeleteDuplicates_DuplicatesAtBeginning_RemovesCorrectly()
        {
            // Arrange: [1,1,1,2,3,4]
            var head = CreateLinkedList(new[] { 1, 1, 1, 2, 3, 4 });

            // Act
            var result = _solution.DeleteDuplicates(head);

            // Assert: [1,2,3,4]
            AssertLinkedListEquals(new[] { 1, 2, 3, 4 }, result);
        }

        [TestMethod]
        public void DeleteDuplicates_DuplicatesInMiddle_RemovesCorrectly()
        {
            // Arrange: [1,2,2,2,3]
            var head = CreateLinkedList(new[] { 1, 2, 2, 2, 3 });

            // Act
            var result = _solution.DeleteDuplicates(head);

            // Assert: [1,2,3]
            AssertLinkedListEquals(new[] { 1, 2, 3 }, result);
        }

        [TestMethod]
        public void DeleteDuplicates_DuplicatesAtEnd_RemovesCorrectly()
        {
            // Arrange: [1,2,3,3,3,3]
            var head = CreateLinkedList(new[] { 1, 2, 3, 3, 3, 3 });

            // Act
            var result = _solution.DeleteDuplicates(head);

            // Assert: [1,2,3]
            AssertLinkedListEquals(new[] { 1, 2, 3 }, result);
        }

        [TestMethod]
        public void DeleteDuplicates_MultipleDuplicateGroups_RemovesAllCorrectly()
        {
            // Arrange: [1,1,2,2,3,3,4,4]
            var head = CreateLinkedList(new[] { 1, 1, 2, 2, 3, 3, 4, 4 });

            // Act
            var result = _solution.DeleteDuplicates(head);

            // Assert: [1,2,3,4]
            AssertLinkedListEquals(new[] { 1, 2, 3, 4 }, result);
        }

        [TestMethod]
        public void DeleteDuplicates_AlternatingDuplicates_RemovesCorrectly()
        {
            // Arrange: [1,1,2,3,3,4,5,5]
            var head = CreateLinkedList(new[] { 1, 1, 2, 3, 3, 4, 5, 5 });

            // Act
            var result = _solution.DeleteDuplicates(head);

            // Assert: [1,2,3,4,5]
            AssertLinkedListEquals(new[] { 1, 2, 3, 4, 5 }, result);
        }

        #endregion

        #region Negative Numbers

        [TestMethod]
        public void DeleteDuplicates_WithNegativeNumbers_RemovesCorrectly()
        {
            // Arrange: [-3,-3,-1,0,0,1,1]
            var head = CreateLinkedList(new[] { -3, -3, -1, 0, 0, 1, 1 });

            // Act
            var result = _solution.DeleteDuplicates(head);

            // Assert: [-3,-1,0,1]
            AssertLinkedListEquals(new[] { -3, -1, 0, 1 }, result);
        }

        [TestMethod]
        public void DeleteDuplicates_AllNegativeDuplicates_RemovesCorrectly()
        {
            // Arrange: [-5,-5,-5]
            var head = CreateLinkedList(new[] { -5, -5, -5 });

            // Act
            var result = _solution.DeleteDuplicates(head);

            // Assert: [-5]
            AssertLinkedListEquals(new[] { -5 }, result);
        }

        #endregion

        #region Longer Lists

        [TestMethod]
        public void DeleteDuplicates_LongerList_RemovesCorrectly()
        {
            // Arrange: [1,1,1,2,2,3,4,4,5,6,6,6,7]
            var head = CreateLinkedList(new[] { 1, 1, 1, 2, 2, 3, 4, 4, 5, 6, 6, 6, 7 });

            // Act
            var result = _solution.DeleteDuplicates(head);

            // Assert: [1,2,3,4,5,6,7]
            AssertLinkedListEquals(new[] { 1, 2, 3, 4, 5, 6, 7 }, result);
        }

        [TestMethod]
        public void DeleteDuplicates_LongListNoDuplicates_ReturnsOriginal()
        {
            // Arrange: [1,2,3,4,5,6,7,8,9,10]
            var head = CreateLinkedList(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });

            // Act
            var result = _solution.DeleteDuplicates(head);

            // Assert: [1,2,3,4,5,6,7,8,9,10]
            AssertLinkedListEquals(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, result);
        }

        #endregion

        #region Zero Values

        [TestMethod]
        public void DeleteDuplicates_WithZeros_RemovesCorrectly()
        {
            // Arrange: [0,0,1,1,2]
            var head = CreateLinkedList(new[] { 0, 0, 1, 1, 2 });

            // Act
            var result = _solution.DeleteDuplicates(head);

            // Assert: [0,1,2]
            AssertLinkedListEquals(new[] { 0, 1, 2 }, result);
        }

        [TestMethod]
        public void DeleteDuplicates_AllZeros_ReturnsSingleZero()
        {
            // Arrange: [0,0,0,0]
            var head = CreateLinkedList(new[] { 0, 0, 0, 0 });

            // Act
            var result = _solution.DeleteDuplicates(head);

            // Assert: [0]
            AssertLinkedListEquals(new[] { 0 }, result);
        }

        #endregion
    }
}
