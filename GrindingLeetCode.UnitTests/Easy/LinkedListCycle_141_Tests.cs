using LeetCodeProblems.CSharp.LinkedList;
using LeetCodeProblems.Interfaces.Easy;
using LeetCodeProblems.Shared;
using LeetCodeProblems.VisualBasic.LinkedList;

namespace GrindingLeetCode.UnitTests.Easy
{
    [TestClass]
    public class LinkedListCycle_141_Tests
    {
        public static IEnumerable<object[]> GetImplementations()
        {
            yield return new object[] { new FloydsTortoiseAndHareCSharp_141() };
            yield return new object[] { new LinkedListCycleHashmapCSharpSolution_141() };
            yield return new object[] { new LinkedListCycleHashSetSolutionVB_141() };
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
        /// Creates a linked list with a cycle at the specified position
        /// </summary>
        /// <param name="values">Values for the list</param>
        /// <param name="pos">Position where tail connects to (0-based index). Use -1 for no cycle.</param>
        /// <returns>Head of the linked list</returns>
        private ListNode CreateListWithCycle(int[] values, int pos)
        {
            if (values == null || values.Length == 0) return null;

            ListNode head = new ListNode(values[0]);
            ListNode current = head;
            ListNode cycleNode = (pos == 0) ? head : null;

            for (int i = 1; i < values.Length; i++)
            {
                current.next = new ListNode(values[i]);
                current = current.next;

                if (i == pos)
                {
                    cycleNode = current;
                }
            }

            // Create the cycle if pos is valid
            if (pos >= 0 && pos < values.Length)
            {
                current.next = cycleNode;
            }

            return head;
        }

        #endregion

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void HasCycle_Example1_CycleAtPosition1_ReturnsTrue(ILinkedListCycle_141 solution)
        {
            // Arrange
            // [3,2,0,-4], pos = 1
            ListNode head = CreateListWithCycle(new[] { 3, 2, 0, -4 }, 1);

            // Act
            bool result = solution.HasCycle(head);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void HasCycle_Example2_CycleAtPosition0_ReturnsTrue(ILinkedListCycle_141 solution)
        {
            // Arrange
            // [1,2], pos = 0
            ListNode head = CreateListWithCycle(new[] { 1, 2 }, 0);

            // Act
            bool result = solution.HasCycle(head);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void HasCycle_Example3_NoCycle_ReturnsFalse(ILinkedListCycle_141 solution)
        {
            // Arrange
            // [1], pos = -1
            ListNode head = CreateListWithCycle(new[] { 1 }, -1);

            // Act
            bool result = solution.HasCycle(head);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void HasCycle_NullHead_ReturnsFalse(ILinkedListCycle_141 solution)
        {
            // Arrange
            ListNode head = null;

            // Act
            bool result = solution.HasCycle(head);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void HasCycle_SingleNodeNoCycle_ReturnsFalse(ILinkedListCycle_141 solution)
        {
            // Arrange
            ListNode head = new ListNode(1);

            // Act
            bool result = solution.HasCycle(head);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void HasCycle_SingleNodeWithSelfCycle_ReturnsTrue(ILinkedListCycle_141 solution)
        {
            // Arrange
            ListNode head = new ListNode(1);
            head.next = head; // Cycle to itself

            // Act
            bool result = solution.HasCycle(head);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void HasCycle_TwoNodesNoCycle_ReturnsFalse(ILinkedListCycle_141 solution)
        {
            // Arrange
            ListNode head = CreateList(1, 2);

            // Act
            bool result = solution.HasCycle(head);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void HasCycle_TwoNodesCycleToFirst_ReturnsTrue(ILinkedListCycle_141 solution)
        {
            // Arrange
            ListNode head = CreateListWithCycle(new[] { 1, 2 }, 0);

            // Act
            bool result = solution.HasCycle(head);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void HasCycle_TwoNodesCycleToSecond_ReturnsTrue(ILinkedListCycle_141 solution)
        {
            // Arrange
            ListNode head = CreateListWithCycle(new[] { 1, 2 }, 1);

            // Act
            bool result = solution.HasCycle(head);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void HasCycle_LongListNoCycle_ReturnsFalse(ILinkedListCycle_141 solution)
        {
            // Arrange
            ListNode head = CreateList(1, 2, 3, 4, 5, 6, 7, 8, 9, 10);

            // Act
            bool result = solution.HasCycle(head);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void HasCycle_LongListCycleAtMiddle_ReturnsTrue(ILinkedListCycle_141 solution)
        {
            // Arrange
            ListNode head = CreateListWithCycle(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, 5);

            // Act
            bool result = solution.HasCycle(head);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void HasCycle_LongListCycleAtEnd_ReturnsTrue(ILinkedListCycle_141 solution)
        {
            // Arrange
            ListNode head = CreateListWithCycle(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, 9);

            // Act
            bool result = solution.HasCycle(head);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void HasCycle_LongListCycleAtBeginning_ReturnsTrue(ILinkedListCycle_141 solution)
        {
            // Arrange
            ListNode head = CreateListWithCycle(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, 0);

            // Act
            bool result = solution.HasCycle(head);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void HasCycle_ThreeNodesNoCycle_ReturnsFalse(ILinkedListCycle_141 solution)
        {
            // Arrange
            ListNode head = CreateList(1, 2, 3);

            // Act
            bool result = solution.HasCycle(head);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void HasCycle_ThreeNodesCycleToFirst_ReturnsTrue(ILinkedListCycle_141 solution)
        {
            // Arrange
            ListNode head = CreateListWithCycle(new[] { 1, 2, 3 }, 0);

            // Act
            bool result = solution.HasCycle(head);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void HasCycle_ThreeNodesCycleToMiddle_ReturnsTrue(ILinkedListCycle_141 solution)
        {
            // Arrange
            ListNode head = CreateListWithCycle(new[] { 1, 2, 3 }, 1);

            // Act
            bool result = solution.HasCycle(head);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void HasCycle_ThreeNodesCycleToLast_ReturnsTrue(ILinkedListCycle_141 solution)
        {
            // Arrange
            ListNode head = CreateListWithCycle(new[] { 1, 2, 3 }, 2);

            // Act
            bool result = solution.HasCycle(head);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void HasCycle_NegativeValues_CycleExists_ReturnsTrue(ILinkedListCycle_141 solution)
        {
            // Arrange
            ListNode head = CreateListWithCycle(new[] { -5, -3, -1, 0, 2 }, 2);

            // Act
            bool result = solution.HasCycle(head);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void HasCycle_NegativeValues_NoCycle_ReturnsFalse(ILinkedListCycle_141 solution)
        {
            // Arrange
            ListNode head = CreateList(-5, -3, -1, 0, 2);

            // Act
            bool result = solution.HasCycle(head);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void HasCycle_DuplicateValues_CycleExists_ReturnsTrue(ILinkedListCycle_141 solution)
        {
            // Arrange
            ListNode head = CreateListWithCycle(new[] { 1, 1, 1, 1, 1 }, 2);

            // Act
            bool result = solution.HasCycle(head);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void HasCycle_DuplicateValues_NoCycle_ReturnsFalse(ILinkedListCycle_141 solution)
        {
            // Arrange
            ListNode head = CreateList(1, 1, 1, 1, 1);

            // Act
            bool result = solution.HasCycle(head);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void HasCycle_ZeroValues_CycleExists_ReturnsTrue(ILinkedListCycle_141 solution)
        {
            // Arrange
            ListNode head = CreateListWithCycle(new[] { 0, 0, 0 }, 0);

            // Act
            bool result = solution.HasCycle(head);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void HasCycle_ZeroValues_NoCycle_ReturnsFalse(ILinkedListCycle_141 solution)
        {
            // Arrange
            ListNode head = CreateList(0, 0, 0);

            // Act
            bool result = solution.HasCycle(head);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void HasCycle_FourNodesCycleToSecond_ReturnsTrue(ILinkedListCycle_141 solution)
        {
            // Arrange
            ListNode head = CreateListWithCycle(new[] { 10, 20, 30, 40 }, 1);

            // Act
            bool result = solution.HasCycle(head);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void HasCycle_FourNodesCycleToThird_ReturnsTrue(ILinkedListCycle_141 solution)
        {
            // Arrange
            ListNode head = CreateListWithCycle(new[] { 10, 20, 30, 40 }, 2);

            // Act
            bool result = solution.HasCycle(head);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void HasCycle_FiveNodesNoCycle_ReturnsFalse(ILinkedListCycle_141 solution)
        {
            // Arrange
            ListNode head = CreateList(1, 2, 3, 4, 5);

            // Act
            bool result = solution.HasCycle(head);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void HasCycle_LargeCycle_ReturnsTrue(ILinkedListCycle_141 solution)
        {
            // Arrange
            int[] values = new int[100];
            for (int i = 0; i < 100; i++)
            {
                values[i] = i + 1;
            }
            ListNode head = CreateListWithCycle(values, 50);

            // Act
            bool result = solution.HasCycle(head);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void HasCycle_LargeNoCycle_ReturnsFalse(ILinkedListCycle_141 solution)
        {
            // Arrange
            int[] values = new int[100];
            for (int i = 0; i < 100; i++)
            {
                values[i] = i + 1;
            }
            ListNode head = CreateList(values);

            // Act
            bool result = solution.HasCycle(head);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void HasCycle_SmallCycleAtEnd_ReturnsTrue(ILinkedListCycle_141 solution)
        {
            // Arrange
            ListNode head = CreateListWithCycle(new[] { 1, 2, 3, 4, 5, 6 }, 4);

            // Act
            bool result = solution.HasCycle(head);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void HasCycle_SmallCycleNearBeginning_ReturnsTrue(ILinkedListCycle_141 solution)
        {
            // Arrange
            ListNode head = CreateListWithCycle(new[] { 1, 2, 3, 4, 5, 6 }, 1);

            // Act
            bool result = solution.HasCycle(head);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void HasCycle_MixedPositiveAndNegative_CycleExists_ReturnsTrue(ILinkedListCycle_141 solution)
        {
            // Arrange
            ListNode head = CreateListWithCycle(new[] { -10, -5, 0, 5, 10 }, 2);

            // Act
            bool result = solution.HasCycle(head);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void HasCycle_MixedPositiveAndNegative_NoCycle_ReturnsFalse(ILinkedListCycle_141 solution)
        {
            // Arrange
            ListNode head = CreateList(-10, -5, 0, 5, 10);

            // Act
            bool result = solution.HasCycle(head);

            // Assert
            Assert.IsFalse(result);
        }
    }
}
