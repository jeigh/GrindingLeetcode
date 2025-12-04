using LeetCodeProblems.CSharp.LinkedList;
using LeetCodeProblems.Interfaces.Easy;
using LeetCodeProblems.Shared;
using LeetCodeProblems.VisualBasic.LinkedList;

namespace GrindingLeetCode.UnitTests.Easy
{
    [TestClass]
    public class ReverseLinkedList_206_Tests
    {
        public static IEnumerable<object[]> GetImplementations()
        {
            yield return new object[] { new ReverseListCSharp_206(), "C#" };
            yield return new object[] { new ReverseLinkedListVB_206(), "VB" };
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

        private void AssertLinkedListEquals(int[] expected, ListNode actual, string solutionName)
        {
            var actualArray = LinkedListToArray(actual);
            CollectionAssert.AreEqual(expected, actualArray, $"Failed for {solutionName}");
        }

        #endregion

        #region Tests

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void ReverseList_Example1_ReversesCorrectly(IReverseLinkedList_206 solution, string solutionName)
        {
            // Arrange: [1,2,3,4,5]
            var head = CreateLinkedList(new[] { 1, 2, 3, 4, 5 });

            // Act
            var result = solution.ReverseList(head);

            // Assert: [5,4,3,2,1]
            AssertLinkedListEquals(new[] { 5, 4, 3, 2, 1 }, result, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void ReverseList_Example2_ReversesCorrectly(IReverseLinkedList_206 solution, string solutionName)
        {
            // Arrange: [1,2]
            var head = CreateLinkedList(new[] { 1, 2 });

            // Act
            var result = solution.ReverseList(head);

            // Assert: [2,1]
            AssertLinkedListEquals(new[] { 2, 1 }, result, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void ReverseList_EmptyList_ReturnsNull(IReverseLinkedList_206 solution, string solutionName)
        {
            // Arrange
            ListNode head = null;

            // Act
            var result = solution.ReverseList(head);

            // Assert
            Assert.IsNull(result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void ReverseList_SingleElement_ReturnsSameElement(IReverseLinkedList_206 solution, string solutionName)
        {
            // Arrange: [1]
            var head = CreateLinkedList(new[] { 1 });

            // Act
            var result = solution.ReverseList(head);

            // Assert: [1]
            AssertLinkedListEquals(new[] { 1 }, result, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void ReverseList_TwoElements_ReversesCorrectly(IReverseLinkedList_206 solution, string solutionName)
        {
            // Arrange: [5,10]
            var head = CreateLinkedList(new[] { 5, 10 });

            // Act
            var result = solution.ReverseList(head);

            // Assert: [10,5]
            AssertLinkedListEquals(new[] { 10, 5 }, result, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void ReverseList_ThreeElements_ReversesCorrectly(IReverseLinkedList_206 solution, string solutionName)
        {
            // Arrange: [1,2,3]
            var head = CreateLinkedList(new[] { 1, 2, 3 });

            // Act
            var result = solution.ReverseList(head);

            // Assert: [3,2,1]
            AssertLinkedListEquals(new[] { 3, 2, 1 }, result, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void ReverseList_WithNegativeNumbers_ReversesCorrectly(IReverseLinkedList_206 solution, string solutionName)
        {
            // Arrange: [-1,-2,-3]
            var head = CreateLinkedList(new[] { -1, -2, -3 });

            // Act
            var result = solution.ReverseList(head);

            // Assert: [-3,-2,-1]
            AssertLinkedListEquals(new[] { -3, -2, -1 }, result, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void ReverseList_WithDuplicates_ReversesCorrectly(IReverseLinkedList_206 solution, string solutionName)
        {
            // Arrange: [1,2,2,3,3,3]
            var head = CreateLinkedList(new[] { 1, 2, 2, 3, 3, 3 });

            // Act
            var result = solution.ReverseList(head);

            // Assert: [3,3,3,2,2,1]
            AssertLinkedListEquals(new[] { 3, 3, 3, 2, 2, 1 }, result, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void ReverseList_LongerList_ReversesCorrectly(IReverseLinkedList_206 solution, string solutionName)
        {
            // Arrange: [1,2,3,4,5,6,7,8,9,10]
            var head = CreateLinkedList(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });

            // Act
            var result = solution.ReverseList(head);

            // Assert: [10,9,8,7,6,5,4,3,2,1]
            AssertLinkedListEquals(new[] { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 }, result, solutionName);
        }

        #endregion
    }
}
