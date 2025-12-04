using LeetCodeProblems.CSharp.LinkedList;
using LeetCodeProblems.Interfaces.Medium;
using LeetCodeProblems.Shared;
using LeetCodeProblems.VisualBasic.LinkedList;

namespace GrindingLeetCode.UnitTests.Medium
{
    [TestClass]
    public class RemoveNthNodeFromEndOfList_19_Tests
    {
        public static IEnumerable<object[]> GetImplementations()
        {
            yield return new object[] { new RemoveNthNodeFromEndOfListCSharp_19(), "C#" };
            yield return new object[] { new RemoveNthNodeFromEndOfListVB_19(), "VB" };
        }

        #region Helper Methods

        /// <summary>
        /// Creates a linked list from an array of values
        /// </summary>
        private ListNode CreateList(params int[] values)
        {
            if (values == null || values.Length == 0) return null;

            ListNode head = new ListNode(values[0]);
            ListNode current = head;

            for (int i = 1; i < values.Length; i++)
            {
                current.next = new ListNode(values[i]);
                current = current.next;
            }

            return head;
        }

        /// <summary>
        /// Converts a linked list to an array for easy comparison
        /// </summary>
        private int[] ToArray(ListNode head)
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
        private void AssertListEquals(int[] expected, ListNode actual, string solutionName)
        {
            var actualArray = ToArray(actual);
            CollectionAssert.AreEqual(expected, actualArray, $"Failed for {solutionName}");
        }

        #endregion

        #region LeetCode Examples

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void RemoveNthFromEnd_Example1_RemovesSecondToLast(IRemoveNthNodeFromEndOfList_19 solution, string solutionName)
        {
            // Arrange: [1,2,3,4,5], n = 2
            ListNode head = CreateList(1, 2, 3, 4, 5);

            // Act
            ListNode result = solution.RemoveNthFromEnd(head, 2);

            // Assert: [1,2,3,5] - removed 4 (2nd from end)
            AssertListEquals(new[] { 1, 2, 3, 5 }, result, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void RemoveNthFromEnd_Example2_RemovesOnlyNode(IRemoveNthNodeFromEndOfList_19 solution, string solutionName)
        {
            // Arrange: [1], n = 1
            ListNode head = CreateList(1);

            // Act
            ListNode result = solution.RemoveNthFromEnd(head, 1);

            // Assert: [] - list is empty
            Assert.IsNull(result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void RemoveNthFromEnd_Example3_RemovesFirstOfTwo(IRemoveNthNodeFromEndOfList_19 solution, string solutionName)
        {
            // Arrange: [1,2], n = 2
            ListNode head = CreateList(1, 2);

            // Act
            ListNode result = solution.RemoveNthFromEnd(head, 2);

            // Assert: [2] - removed first node
            AssertListEquals(new[] { 2 }, result, solutionName);
        }

        #endregion

        #region Bug Exposure Tests

        /// <summary>
        /// This test exposes the VB implementation bug where it returns the wrong head
        /// when removing the first node from a list with 3+ elements.
        /// VB returns the original head (which includes the deleted node),
        /// while C# correctly returns dummy.next (the new head).
        /// </summary>
        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void RemoveNthFromEnd_RemoveFirstOfThree_ExposesVBBug(IRemoveNthNodeFromEndOfList_19 solution, string solutionName)
        {
            // Arrange: [1,2,3], n = 3 (remove first node)
            ListNode head = CreateList(1, 2, 3);

            // Act
            ListNode result = solution.RemoveNthFromEnd(head, 3);

            // Assert: [2,3] - VB will incorrectly return [1,2,3]
            AssertListEquals(new[] { 2, 3 }, result, solutionName);
        }

        /// <summary>
        /// Another test case that exposes the VB bug with a longer list.
        /// When removing the first node, VB returns the original head pointer
        /// instead of the new head (dummy.next).
        /// </summary>
        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void RemoveNthFromEnd_RemoveFirstOfFour_ExposesVBBug(IRemoveNthNodeFromEndOfList_19 solution, string solutionName)
        {
            // Arrange: [10,20,30,40], n = 4 (remove first node)
            ListNode head = CreateList(10, 20, 30, 40);

            // Act
            ListNode result = solution.RemoveNthFromEnd(head, 4);

            // Assert: [20,30,40] - VB will incorrectly return [10,20,30,40]
            AssertListEquals(new[] { 20, 30, 40 }, result, solutionName);
        }

        #endregion

        #region Remove Last Node

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void RemoveNthFromEnd_RemoveLastNode_ThreeElements(IRemoveNthNodeFromEndOfList_19 solution, string solutionName)
        {
            // Arrange: [1,2,3], n = 1
            ListNode head = CreateList(1, 2, 3);

            // Act
            ListNode result = solution.RemoveNthFromEnd(head, 1);

            // Assert: [1,2]
            AssertListEquals(new[] { 1, 2 }, result, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void RemoveNthFromEnd_RemoveLastNode_FiveElements(IRemoveNthNodeFromEndOfList_19 solution, string solutionName)
        {
            // Arrange: [1,2,3,4,5], n = 1
            ListNode head = CreateList(1, 2, 3, 4, 5);

            // Act
            ListNode result = solution.RemoveNthFromEnd(head, 1);

            // Assert: [1,2,3,4]
            AssertListEquals(new[] { 1, 2, 3, 4 }, result, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void RemoveNthFromEnd_RemoveLastNode_TwoElements(IRemoveNthNodeFromEndOfList_19 solution, string solutionName)
        {
            // Arrange: [1,2], n = 1
            ListNode head = CreateList(1, 2);

            // Act
            ListNode result = solution.RemoveNthFromEnd(head, 1);

            // Assert: [1]
            AssertListEquals(new[] { 1 }, result, solutionName);
        }

        #endregion

        #region Remove First Node

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void RemoveNthFromEnd_RemoveFirstNode_ThreeElements(IRemoveNthNodeFromEndOfList_19 solution, string solutionName)
        {
            // Arrange: [1,2,3], n = 3
            ListNode head = CreateList(1, 2, 3);

            // Act
            ListNode result = solution.RemoveNthFromEnd(head, 3);

            // Assert: [2,3]
            AssertListEquals(new[] { 2, 3 }, result, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void RemoveNthFromEnd_RemoveFirstNode_FiveElements(IRemoveNthNodeFromEndOfList_19 solution, string solutionName)
        {
            // Arrange: [1,2,3,4,5], n = 5
            ListNode head = CreateList(1, 2, 3, 4, 5);

            // Act
            ListNode result = solution.RemoveNthFromEnd(head, 5);

            // Assert: [2,3,4,5]
            AssertListEquals(new[] { 2, 3, 4, 5 }, result, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void RemoveNthFromEnd_RemoveFirstNode_TenElements(IRemoveNthNodeFromEndOfList_19 solution, string solutionName)
        {
            // Arrange: [1,2,3,4,5,6,7,8,9,10], n = 10
            ListNode head = CreateList(1, 2, 3, 4, 5, 6, 7, 8, 9, 10);

            // Act
            ListNode result = solution.RemoveNthFromEnd(head, 10);

            // Assert: [2,3,4,5,6,7,8,9,10]
            AssertListEquals(new[] { 2, 3, 4, 5, 6, 7, 8, 9, 10 }, result, solutionName);
        }

        #endregion

        #region Remove Middle Nodes

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void RemoveNthFromEnd_RemoveMiddleNode_ThreeElements(IRemoveNthNodeFromEndOfList_19 solution, string solutionName)
        {
            // Arrange: [1,2,3], n = 2
            ListNode head = CreateList(1, 2, 3);

            // Act
            ListNode result = solution.RemoveNthFromEnd(head, 2);

            // Assert: [1,3]
            AssertListEquals(new[] { 1, 3 }, result, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void RemoveNthFromEnd_RemoveThirdFromEnd_FiveElements(IRemoveNthNodeFromEndOfList_19 solution, string solutionName)
        {
            // Arrange: [1,2,3,4,5], n = 3
            ListNode head = CreateList(1, 2, 3, 4, 5);

            // Act
            ListNode result = solution.RemoveNthFromEnd(head, 3);

            // Assert: [1,2,4,5] - removed 3
            AssertListEquals(new[] { 1, 2, 4, 5 }, result, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void RemoveNthFromEnd_RemoveFourthFromEnd_SevenElements(IRemoveNthNodeFromEndOfList_19 solution, string solutionName)
        {
            // Arrange: [1,2,3,4,5,6,7], n = 4
            ListNode head = CreateList(1, 2, 3, 4, 5, 6, 7);

            // Act
            ListNode result = solution.RemoveNthFromEnd(head, 4);

            // Assert: [1,2,3,5,6,7] - removed 4
            AssertListEquals(new[] { 1, 2, 3, 5, 6, 7 }, result, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void RemoveNthFromEnd_RemoveFifthFromEnd_TenElements(IRemoveNthNodeFromEndOfList_19 solution, string solutionName)
        {
            // Arrange: [1,2,3,4,5,6,7,8,9,10], n = 5
            ListNode head = CreateList(1, 2, 3, 4, 5, 6, 7, 8, 9, 10);

            // Act
            ListNode result = solution.RemoveNthFromEnd(head, 5);

            // Assert: [1,2,3,4,5,7,8,9,10] - removed 6
            AssertListEquals(new[] { 1, 2, 3, 4, 5, 7, 8, 9, 10 }, result, solutionName);
        }

        #endregion

        #region Single Element Lists

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void RemoveNthFromEnd_SingleElement_ReturnsNull(IRemoveNthNodeFromEndOfList_19 solution, string solutionName)
        {
            // Arrange: [5], n = 1
            ListNode head = CreateList(5);

            // Act
            ListNode result = solution.RemoveNthFromEnd(head, 1);

            // Assert: null
            Assert.IsNull(result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void RemoveNthFromEnd_SingleElementNegativeValue_ReturnsNull(IRemoveNthNodeFromEndOfList_19 solution, string solutionName)
        {
            // Arrange: [-1], n = 1
            ListNode head = CreateList(-1);

            // Act
            ListNode result = solution.RemoveNthFromEnd(head, 1);

            // Assert: null
            Assert.IsNull(result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void RemoveNthFromEnd_SingleElementLargeValue_ReturnsNull(IRemoveNthNodeFromEndOfList_19 solution, string solutionName)
        {
            // Arrange: [100], n = 1
            ListNode head = CreateList(100);

            // Act
            ListNode result = solution.RemoveNthFromEnd(head, 1);

            // Assert: null
            Assert.IsNull(result, $"Failed for {solutionName}");
        }

        #endregion

        #region Two Element Lists

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void RemoveNthFromEnd_TwoElements_RemoveFirst(IRemoveNthNodeFromEndOfList_19 solution, string solutionName)
        {
            // Arrange: [1,2], n = 2
            ListNode head = CreateList(1, 2);

            // Act
            ListNode result = solution.RemoveNthFromEnd(head, 2);

            // Assert: [2]
            AssertListEquals(new[] { 2 }, result, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void RemoveNthFromEnd_TwoElements_RemoveSecond(IRemoveNthNodeFromEndOfList_19 solution, string solutionName)
        {
            // Arrange: [1,2], n = 1
            ListNode head = CreateList(1, 2);

            // Act
            ListNode result = solution.RemoveNthFromEnd(head, 1);

            // Assert: [1]
            AssertListEquals(new[] { 1 }, result, solutionName);
        }

        #endregion

        #region Different Value Patterns

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void RemoveNthFromEnd_AllSameValues_RemovesCorrectPosition(IRemoveNthNodeFromEndOfList_19 solution, string solutionName)
        {
            // Arrange: [5,5,5,5,5], n = 3
            ListNode head = CreateList(5, 5, 5, 5, 5);

            // Act
            ListNode result = solution.RemoveNthFromEnd(head, 3);

            // Assert: [5,5,5,5]
            AssertListEquals(new[] { 5, 5, 5, 5 }, result, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void RemoveNthFromEnd_WithNegativeNumbers_RemovesCorrectly(IRemoveNthNodeFromEndOfList_19 solution, string solutionName)
        {
            // Arrange: [-5,-3,-1,0,1,3,5], n = 4
            ListNode head = CreateList(-5, -3, -1, 0, 1, 3, 5);

            // Act
            ListNode result = solution.RemoveNthFromEnd(head, 4);

            // Assert: [-5,-3,-1,1,3,5] - removed 0
            AssertListEquals(new[] { -5, -3, -1, 1, 3, 5 }, result, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void RemoveNthFromEnd_WithZeros_RemovesCorrectly(IRemoveNthNodeFromEndOfList_19 solution, string solutionName)
        {
            // Arrange: [0,0,1,2,3], n = 2
            ListNode head = CreateList(0, 0, 1, 2, 3);

            // Act
            ListNode result = solution.RemoveNthFromEnd(head, 2);

            // Assert: [0,0,1,3] - removed 2
            AssertListEquals(new[] { 0, 0, 1, 3 }, result, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void RemoveNthFromEnd_LargeNumbers_RemovesCorrectly(IRemoveNthNodeFromEndOfList_19 solution, string solutionName)
        {
            // Arrange: [100,200,300,400,500], n = 3
            ListNode head = CreateList(100, 200, 300, 400, 500);

            // Act
            ListNode result = solution.RemoveNthFromEnd(head, 3);

            // Assert: [100,200,400,500] - removed 300
            AssertListEquals(new[] { 100, 200, 400, 500 }, result, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void RemoveNthFromEnd_DescendingOrder_RemovesCorrectly(IRemoveNthNodeFromEndOfList_19 solution, string solutionName)
        {
            // Arrange: [10,9,8,7,6,5,4,3,2,1], n = 7
            ListNode head = CreateList(10, 9, 8, 7, 6, 5, 4, 3, 2, 1);

            // Act
            ListNode result = solution.RemoveNthFromEnd(head, 7);

            AssertListEquals(new[] { 10, 9, 8, 6, 5, 4, 3, 2, 1 }, result, solutionName);
        }

        #endregion

        #region Longer Lists

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void RemoveNthFromEnd_LongList_RemovesNearBeginning(IRemoveNthNodeFromEndOfList_19 solution, string solutionName)
        {
            // Arrange: [1,2,3,4,5,6,7,8,9,10,11,12,13,14,15], n = 14
            ListNode head = CreateList(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15);

            // Act
            ListNode result = solution.RemoveNthFromEnd(head, 14);

            // Assert: [1,3,4,5,6,7,8,9,10,11,12,13,14,15] - removed 2
            AssertListEquals(new[] { 1, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 }, result, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void RemoveNthFromEnd_LongList_RemovesInMiddle(IRemoveNthNodeFromEndOfList_19 solution, string solutionName)
        {
            // Arrange: [1,2,3,4,5,6,7,8,9,10,11,12,13,14,15], n = 8
            ListNode head = CreateList(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15);

            // Act
            ListNode result = solution.RemoveNthFromEnd(head, 8);

            // Assert: [1,2,3,4,5,6,7,9,10,11,12,13,14,15] - removed 8
            AssertListEquals(new[] { 1, 2, 3, 4, 5, 6, 7, 9, 10, 11, 12, 13, 14, 15 }, result, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void RemoveNthFromEnd_LongList_RemovesNearEnd(IRemoveNthNodeFromEndOfList_19 solution, string solutionName)
        {
            // Arrange: [1,2,3,4,5,6,7,8,9,10,11,12,13,14,15], n = 2
            ListNode head = CreateList(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15);

            // Act
            ListNode result = solution.RemoveNthFromEnd(head, 2);

            // Assert: [1,2,3,4,5,6,7,8,9,10,11,12,13,15] - removed 14
            AssertListEquals(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 15 }, result, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void RemoveNthFromEnd_TwentyElements_RemovesCorrectly(IRemoveNthNodeFromEndOfList_19 solution, string solutionName)
        {
            // Arrange: [1..20], n = 10
            ListNode head = CreateList(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20);

            // Act
            ListNode result = solution.RemoveNthFromEnd(head, 10);

            // Assert: removes 11 (10th from end)
            AssertListEquals(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 12, 13, 14, 15, 16, 17, 18, 19, 20 }, result, solutionName);
        }

        #endregion

        #region Boundary Cases

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void RemoveNthFromEnd_MaxConstraintSize_RemovesFirst(IRemoveNthNodeFromEndOfList_19 solution, string solutionName)
        {
            // Arrange: 30 elements, n = 30 (remove first)
            var values = Enumerable.Range(1, 30).ToArray();
            ListNode head = CreateList(values);

            // Act
            ListNode result = solution.RemoveNthFromEnd(head, 30);

            // Assert: [2,3,4,...,30]
            var expected = Enumerable.Range(2, 29).ToArray();
            AssertListEquals(expected, result, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void RemoveNthFromEnd_MaxConstraintSize_RemovesLast(IRemoveNthNodeFromEndOfList_19 solution, string solutionName)
        {
            // Arrange: 30 elements, n = 1 (remove last)
            var values = Enumerable.Range(1, 30).ToArray();
            ListNode head = CreateList(values);

            // Act
            ListNode result = solution.RemoveNthFromEnd(head, 1);

            // Assert: [1,2,3,...,29]
            var expected = Enumerable.Range(1, 29).ToArray();
            AssertListEquals(expected, result, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void RemoveNthFromEnd_MaxConstraintSize_RemovesMiddle(IRemoveNthNodeFromEndOfList_19 solution, string solutionName)
        {
            // Arrange: 30 elements, n = 15 (remove 16th element)
            var values = Enumerable.Range(1, 30).ToArray();
            ListNode head = CreateList(values);

            // Act
            ListNode result = solution.RemoveNthFromEnd(head, 15);

            // Assert: removes 16
            var expected = Enumerable.Range(1, 30).Where(x => x != 16).ToArray();
            AssertListEquals(expected, result, solutionName);
        }

        #endregion

        #region Sequential Patterns

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void RemoveNthFromEnd_EvenNumbers_RemovesCorrectly(IRemoveNthNodeFromEndOfList_19 solution, string solutionName)
        {
            // Arrange: [2,4,6,8,10,12,14], n = 4
            ListNode head = CreateList(2, 4, 6, 8, 10, 12, 14);

            // Act
            ListNode result = solution.RemoveNthFromEnd(head, 4);

            // Assert: [2,4,6,10,12,14] - removed 8
            AssertListEquals(new[] { 2, 4, 6, 10, 12, 14 }, result, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void RemoveNthFromEnd_OddNumbers_RemovesCorrectly(IRemoveNthNodeFromEndOfList_19 solution, string solutionName)
        {
            // Arrange: [1,3,5,7,9,11,13], n = 6
            ListNode head = CreateList(1, 3, 5, 7, 9, 11, 13);

            // Act
            ListNode result = solution.RemoveNthFromEnd(head, 6);

            // Assert: [1,5,7,9,11,13] - removed 3
            AssertListEquals(new[] { 1, 5, 7, 9, 11, 13 }, result, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void RemoveNthFromEnd_PowersOfTwo_RemovesCorrectly(IRemoveNthNodeFromEndOfList_19 solution, string solutionName)
        {
            // Arrange: [1,2,4,8,16,32,64], n = 3
            ListNode head = CreateList(1, 2, 4, 8, 16, 32, 64);

            // Act
            ListNode result = solution.RemoveNthFromEnd(head, 3);

            // Assert: [1,2,4,8,32,64] - removed 16
            AssertListEquals(new[] { 1, 2, 4, 8, 32, 64 }, result, solutionName);
        }

        #endregion

        #region Duplicates

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void RemoveNthFromEnd_WithDuplicates_RemovesCorrectPosition(IRemoveNthNodeFromEndOfList_19 solution, string solutionName)
        {
            // Arrange: [1,2,2,3,3,3,4], n = 4
            ListNode head = CreateList(1, 2, 2, 3, 3, 3, 4);

            // Act
            ListNode result = solution.RemoveNthFromEnd(head, 4);

            // Assert: [1,2,2,3,3,4] - removed one of the 3's
            AssertListEquals(new[] { 1, 2, 2, 3, 3, 4 }, result, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void RemoveNthFromEnd_AllDuplicates_RemovesCorrectPosition(IRemoveNthNodeFromEndOfList_19 solution, string solutionName)
        {
            // Arrange: [7,7,7,7,7,7], n = 4
            ListNode head = CreateList(7, 7, 7, 7, 7, 7);

            // Act
            ListNode result = solution.RemoveNthFromEnd(head, 4);

            // Assert: [7,7,7,7,7] - 5 elements remaining
            AssertListEquals(new[] { 7, 7, 7, 7, 7 }, result, solutionName);
        }

        #endregion
    }
}