using LeetCodeProblems.CSharp.LinkedList;
using LeetCodeProblems.Interfaces.Easy;
using LeetCodeProblems.Shared;
using LeetCodeProblems.VisualBasic.LinkedList;

namespace GrindingLeetCode.UnitTests.Easy
{
    [TestClass]
    public class MergeTwoLists_21_Tests
    {
        public static IEnumerable<object[]> GetImplementations()
        {
           // yield return new object[] { new MergeTwoListsCSharp_21() };
            yield return new object[] { new MergeTwoListsVB_21() };
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
        private void AssertListEquals(int[] expected, ListNode actual)
        {
            var actualArray = ToArray(actual);
            CollectionAssert.AreEqual(expected, actualArray);
        }

        #endregion

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void MergeTwoLists_Example1_ReturnsMergedList(IMergeTwoLists_21 solution)
        {
            // Arrange
            ListNode list1 = CreateList(1, 2, 4);
            ListNode list2 = CreateList(1, 3, 4);

            // Act
            ListNode result = solution.MergeTwoLists(list1, list2);

            // Assert
            AssertListEquals(new[] { 1, 1, 2, 3, 4, 4 }, result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void MergeTwoLists_Example2_BothEmpty_ReturnsNull(IMergeTwoLists_21 solution)
        {
            // Arrange
            ListNode list1 = null;
            ListNode list2 = null;

            // Act
            ListNode result = solution.MergeTwoLists(list1, list2);

            // Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void MergeTwoLists_Example3_FirstEmptySecondSingle_ReturnsSecond(IMergeTwoLists_21 solution)
        {
            // Arrange
            ListNode list1 = null;
            ListNode list2 = CreateList(0);

            // Act
            ListNode result = solution.MergeTwoLists(list1, list2);

            // Assert
            AssertListEquals(new[] { 0 }, result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void MergeTwoLists_FirstEmptySecondHasMultiple_ReturnsSecond(IMergeTwoLists_21 solution)
        {
            // Arrange
            ListNode list1 = null;
            ListNode list2 = CreateList(1, 2, 3);

            // Act
            ListNode result = solution.MergeTwoLists(list1, list2);

            // Assert
            AssertListEquals(new[] { 1, 2, 3 }, result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void MergeTwoLists_SecondEmptyFirstHasMultiple_ReturnsFirst(IMergeTwoLists_21 solution)
        {
            // Arrange
            ListNode list1 = CreateList(1, 2, 3);
            ListNode list2 = null;

            // Act
            ListNode result = solution.MergeTwoLists(list1, list2);

            // Assert
            AssertListEquals(new[] { 1, 2, 3 }, result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void MergeTwoLists_BothSingleNode_ReturnsMerged(IMergeTwoLists_21 solution)
        {
            // Arrange
            ListNode list1 = CreateList(1);
            ListNode list2 = CreateList(2);

            // Act
            ListNode result = solution.MergeTwoLists(list1, list2);

            // Assert
            AssertListEquals(new[] { 1, 2 }, result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void MergeTwoLists_FirstAllSmallerThanSecond_ReturnsConcatenated(IMergeTwoLists_21 solution)
        {
            // Arrange
            ListNode list1 = CreateList(1, 2, 3);
            ListNode list2 = CreateList(4, 5, 6);

            // Act
            ListNode result = solution.MergeTwoLists(list1, list2);

            // Assert
            AssertListEquals(new[] { 1, 2, 3, 4, 5, 6 }, result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void MergeTwoLists_SecondAllSmallerThanFirst_ReturnsConcatenated(IMergeTwoLists_21 solution)
        {
            // Arrange
            ListNode list1 = CreateList(4, 5, 6);
            ListNode list2 = CreateList(1, 2, 3);

            // Act
            ListNode result = solution.MergeTwoLists(list1, list2);

            // Assert
            AssertListEquals(new[] { 1, 2, 3, 4, 5, 6 }, result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void MergeTwoLists_AlternatingValues_ReturnsInterleavedMerge(IMergeTwoLists_21 solution)
        {
            // Arrange
            ListNode list1 = CreateList(1, 3, 5);
            ListNode list2 = CreateList(2, 4, 6);

            // Act
            ListNode result = solution.MergeTwoLists(list1, list2);

            // Assert
            AssertListEquals(new[] { 1, 2, 3, 4, 5, 6 }, result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void MergeTwoLists_DuplicateValues_ReturnsMergedWithDuplicates(IMergeTwoLists_21 solution)
        {
            // Arrange
            ListNode list1 = CreateList(1, 1, 2, 3);
            ListNode list2 = CreateList(1, 2, 2, 3);

            // Act
            ListNode result = solution.MergeTwoLists(list1, list2);

            // Assert
            AssertListEquals(new[] { 1, 1, 1, 2, 2, 2, 3, 3 }, result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void MergeTwoLists_AllSameValues_ReturnsMergedList(IMergeTwoLists_21 solution)
        {
            // Arrange
            ListNode list1 = CreateList(5, 5, 5);
            ListNode list2 = CreateList(5, 5);

            // Act
            ListNode result = solution.MergeTwoLists(list1, list2);

            // Assert
            AssertListEquals(new[] { 5, 5, 5, 5, 5 }, result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void MergeTwoLists_FirstLongerThanSecond_ReturnsMergedList(IMergeTwoLists_21 solution)
        {
            // Arrange
            ListNode list1 = CreateList(1, 2, 3, 4, 5, 6);
            ListNode list2 = CreateList(2, 3);

            // Act
            ListNode result = solution.MergeTwoLists(list1, list2);

            // Assert
            AssertListEquals(new[] { 1, 2, 2, 3, 3, 4, 5, 6 }, result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void MergeTwoLists_SecondLongerThanFirst_ReturnsMergedList(IMergeTwoLists_21 solution)
        {
            // Arrange
            ListNode list1 = CreateList(2, 3);
            ListNode list2 = CreateList(1, 2, 3, 4, 5, 6);

            // Act
            ListNode result = solution.MergeTwoLists(list1, list2);

            // Assert
            AssertListEquals(new[] { 1, 2, 2, 3, 3, 4, 5, 6 }, result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void MergeTwoLists_NegativeNumbers_ReturnsMergedList(IMergeTwoLists_21 solution)
        {
            // Arrange
            ListNode list1 = CreateList(-5, -3, -1);
            ListNode list2 = CreateList(-4, -2, 0);

            // Act
            ListNode result = solution.MergeTwoLists(list1, list2);

            // Assert
            AssertListEquals(new[] { -5, -4, -3, -2, -1, 0 }, result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void MergeTwoLists_MixedPositiveAndNegative_ReturnsMergedList(IMergeTwoLists_21 solution)
        {
            // Arrange
            ListNode list1 = CreateList(-2, 0, 2);
            ListNode list2 = CreateList(-1, 1, 3);

            // Act
            ListNode result = solution.MergeTwoLists(list1, list2);

            // Assert
            AssertListEquals(new[] { -2, -1, 0, 1, 2, 3 }, result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void MergeTwoLists_LargeValues_ReturnsMergedList(IMergeTwoLists_21 solution)
        {
            // Arrange
            ListNode list1 = CreateList(100, 200, 300);
            ListNode list2 = CreateList(150, 250, 350);

            // Act
            ListNode result = solution.MergeTwoLists(list1, list2);

            // Assert
            AssertListEquals(new[] { 100, 150, 200, 250, 300, 350 }, result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void MergeTwoLists_ZeroValues_ReturnsMergedList(IMergeTwoLists_21 solution)
        {
            // Arrange
            ListNode list1 = CreateList(0, 0, 0);
            ListNode list2 = CreateList(0, 0);

            // Act
            ListNode result = solution.MergeTwoLists(list1, list2);

            // Assert
            AssertListEquals(new[] { 0, 0, 0, 0, 0 }, result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void MergeTwoLists_FirstEndsHigherThanSecondBegins_ReturnsMergedList(IMergeTwoLists_21 solution)
        {
            // Arrange
            ListNode list1 = CreateList(1, 2, 10);
            ListNode list2 = CreateList(3, 4, 5);

            // Act
            ListNode result = solution.MergeTwoLists(list1, list2);

            // Assert
            AssertListEquals(new[] { 1, 2, 3, 4, 5, 10 }, result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void MergeTwoLists_ComplexPattern_ReturnsMergedList(IMergeTwoLists_21 solution)
        {
            // Arrange
            ListNode list1 = CreateList(1, 2, 4, 7, 9);
            ListNode list2 = CreateList(0, 3, 5, 6, 8, 10);

            // Act
            ListNode result = solution.MergeTwoLists(list1, list2);

            // Assert
            AssertListEquals(new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void MergeTwoLists_FirstSingleSecondMultiple_ReturnsMergedList(IMergeTwoLists_21 solution)
        {
            // Arrange
            ListNode list1 = CreateList(5);
            ListNode list2 = CreateList(1, 2, 3, 4, 6, 7);

            // Act
            ListNode result = solution.MergeTwoLists(list1, list2);

            // Assert
            AssertListEquals(new[] { 1, 2, 3, 4, 5, 6, 7 }, result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void MergeTwoLists_SecondSingleFirstMultiple_ReturnsMergedList(IMergeTwoLists_21 solution)
        {
            // Arrange
            ListNode list1 = CreateList(1, 2, 3, 4, 6, 7);
            ListNode list2 = CreateList(5);

            // Act
            ListNode result = solution.MergeTwoLists(list1, list2);

            // Assert
            AssertListEquals(new[] { 1, 2, 3, 4, 5, 6, 7 }, result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void MergeTwoLists_LongLists_ReturnsMergedList(IMergeTwoLists_21 solution)
        {
            // Arrange
            ListNode list1 = CreateList(1, 3, 5, 7, 9, 11, 13, 15, 17, 19);
            ListNode list2 = CreateList(2, 4, 6, 8, 10, 12, 14, 16, 18, 20);

            // Act
            ListNode result = solution.MergeTwoLists(list1, list2);

            // Assert
            AssertListEquals(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 }, result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void MergeTwoLists_FirstHasLargerGaps_ReturnsMergedList(IMergeTwoLists_21 solution)
        {
            // Arrange
            ListNode list1 = CreateList(1, 10, 20);
            ListNode list2 = CreateList(2, 3, 4, 5);

            // Act
            ListNode result = solution.MergeTwoLists(list1, list2);

            // Assert
            AssertListEquals(new[] { 1, 2, 3, 4, 5, 10, 20 }, result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void MergeTwoLists_SameStartDifferentEnd_ReturnsMergedList(IMergeTwoLists_21 solution)
        {
            // Arrange
            ListNode list1 = CreateList(1, 2, 3, 10);
            ListNode list2 = CreateList(1, 2, 3, 5);

            // Act
            ListNode result = solution.MergeTwoLists(list1, list2);

            // Assert
            AssertListEquals(new[] { 1, 1, 2, 2, 3, 3, 5, 10 }, result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void MergeTwoLists_IdenticalLists_ReturnsDoubledList(IMergeTwoLists_21 solution)
        {
            // Arrange
            ListNode list1 = CreateList(1, 2, 3);
            ListNode list2 = CreateList(1, 2, 3);

            // Act
            ListNode result = solution.MergeTwoLists(list1, list2);

            // Assert
            AssertListEquals(new[] { 1, 1, 2, 2, 3, 3 }, result);
        }
    }
}
