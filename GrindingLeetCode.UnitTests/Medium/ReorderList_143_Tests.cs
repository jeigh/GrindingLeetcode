using LeetCodeProblems.CSharp.LinkedList;
using LeetCodeProblems.Interfaces.Medium;
using LeetCodeProblems.Shared;
using LeetCodeProblems.VisualBasic;

namespace GrindingLeetCode.UnitTests.Medium
{
    [TestClass]
    public class ReorderList_143_Tests
    {
        public static IEnumerable<object[]> GetImplementations()
        {
            yield return new object[] { new ReorderListCSharp_143(), "C#" };
            yield return new object[] { new ReorderListVB_143(), "VB" };
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
        /// Asserts that the linked list has expected values in order
        /// </summary>
        private void AssertListEquals(int[] expected, ListNode actual, string solutionName)
        {
            var actualArray = ToArray(actual);
            CollectionAssert.AreEqual(expected, actualArray, $"Failed for {solutionName}");
        }

        /// <summary>
        /// Verifies that the list has no cycles (important for reorder operations)
        /// </summary>
        private void AssertNoCycle(ListNode head, string solutionName)
        {
            var visited = new HashSet<ListNode>();
            var current = head;

            while (current != null)
            {
                Assert.IsFalse(visited.Contains(current), 
                    $"Cycle detected in list for {solutionName}");
                visited.Add(current);
                current = current.next;
            }
        }

        #endregion

        #region LeetCode Examples

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void ReorderList_Example1_ReordersCorrectly(IReorderList_143 solution, string solutionName)
        {
            // Arrange: [1,2,3,4]
            ListNode head = CreateList(1, 2, 3, 4);

            // Act
            solution.ReorderList(head);

            // Assert: [1,4,2,3]
            AssertListEquals(new[] { 1, 4, 2, 3 }, head, solutionName);
            AssertNoCycle(head, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void ReorderList_Example2_ReordersCorrectly(IReorderList_143 solution, string solutionName)
        {
            // Arrange: [1,2,3,4,5]
            ListNode head = CreateList(1, 2, 3, 4, 5);

            // Act
            solution.ReorderList(head);

            // Assert: [1,5,2,4,3]
            AssertListEquals(new[] { 1, 5, 2, 4, 3 }, head, solutionName);
            AssertNoCycle(head, solutionName);
        }

        #endregion

        #region Single and Two Element Lists

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void ReorderList_NullList_DoesNothing(IReorderList_143 solution, string solutionName)
        {
            // Arrange
            ListNode head = null;

            // Act
            solution.ReorderList(head);

            // Assert - Should not throw
            Assert.IsNull(head, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void ReorderList_SingleElement_RemainsUnchanged(IReorderList_143 solution, string solutionName)
        {
            // Arrange: [1]
            ListNode head = CreateList(1);

            // Act
            solution.ReorderList(head);

            // Assert: [1]
            AssertListEquals(new[] { 1 }, head, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void ReorderList_TwoElements_RemainsUnchanged(IReorderList_143 solution, string solutionName)
        {
            // Arrange: [1,2]
            ListNode head = CreateList(1, 2);

            // Act
            solution.ReorderList(head);

            // Assert: [1,2] - With 2 elements, no reordering needed
            AssertListEquals(new[] { 1, 2 }, head, solutionName);
        }

        #endregion

        #region Small Lists (3-6 elements)

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void ReorderList_ThreeElements_ReordersCorrectly(IReorderList_143 solution, string solutionName)
        {
            // Arrange: [1,2,3]
            ListNode head = CreateList(1, 2, 3);

            // Act
            solution.ReorderList(head);

            // Assert: [1,3,2]
            AssertListEquals(new[] { 1, 3, 2 }, head, solutionName);
            AssertNoCycle(head, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void ReorderList_FiveElements_ReordersCorrectly(IReorderList_143 solution, string solutionName)
        {
            // Arrange: [1,2,3,4,5]
            ListNode head = CreateList(1, 2, 3, 4, 5);

            // Act
            solution.ReorderList(head);

            // Assert: [1,5,2,4,3]
            AssertListEquals(new[] { 1, 5, 2, 4, 3 }, head, solutionName);
            AssertNoCycle(head, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void ReorderList_SixElements_ReordersCorrectly(IReorderList_143 solution, string solutionName)
        {
            // Arrange: [1,2,3,4,5,6]
            ListNode head = CreateList(1, 2, 3, 4, 5, 6);

            // Act
            solution.ReorderList(head);

            // Assert: [1,6,2,5,3,4]
            AssertListEquals(new[] { 1, 6, 2, 5, 3, 4 }, head, solutionName);
            AssertNoCycle(head, solutionName);
        }

        #endregion

        #region Even Length Lists

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void ReorderList_EightElements_ReordersCorrectly(IReorderList_143 solution, string solutionName)
        {
            // Arrange: [1,2,3,4,5,6,7,8]
            ListNode head = CreateList(1, 2, 3, 4, 5, 6, 7, 8);

            // Act
            solution.ReorderList(head);

            // Assert: [1,8,2,7,3,6,4,5]
            AssertListEquals(new[] { 1, 8, 2, 7, 3, 6, 4, 5 }, head, solutionName);
            AssertNoCycle(head, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void ReorderList_TenElements_ReordersCorrectly(IReorderList_143 solution, string solutionName)
        {
            // Arrange: [1,2,3,4,5,6,7,8,9,10]
            ListNode head = CreateList(1, 2, 3, 4, 5, 6, 7, 8, 9, 10);

            // Act
            solution.ReorderList(head);

            // Assert: [1,10,2,9,3,8,4,7,5,6]
            AssertListEquals(new[] { 1, 10, 2, 9, 3, 8, 4, 7, 5, 6 }, head, solutionName);
            AssertNoCycle(head, solutionName);
        }

        #endregion

        #region Odd Length Lists

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void ReorderList_SevenElements_ReordersCorrectly(IReorderList_143 solution, string solutionName)
        {
            // Arrange: [1,2,3,4,5,6,7]
            ListNode head = CreateList(1, 2, 3, 4, 5, 6, 7);

            // Act
            solution.ReorderList(head);

            // Assert: [1,7,2,6,3,5,4]
            AssertListEquals(new[] { 1, 7, 2, 6, 3, 5, 4 }, head, solutionName);
            AssertNoCycle(head, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void ReorderList_NineElements_ReordersCorrectly(IReorderList_143 solution, string solutionName)
        {
            // Arrange: [1,2,3,4,5,6,7,8,9]
            ListNode head = CreateList(1, 2, 3, 4, 5, 6, 7, 8, 9);

            // Act
            solution.ReorderList(head);

            // Assert: [1,9,2,8,3,7,4,6,5]
            AssertListEquals(new[] { 1, 9, 2, 8, 3, 7, 4, 6, 5 }, head, solutionName);
            AssertNoCycle(head, solutionName);
        }

        #endregion

        #region Different Value Patterns

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void ReorderList_NegativeValues_ReordersCorrectly(IReorderList_143 solution, string solutionName)
        {
            // Arrange: [-5,-3,-1,0,1,3]
            ListNode head = CreateList(-5, -3, -1, 0, 1, 3);

            // Act
            solution.ReorderList(head);

            // Assert: [-5,3,-3,1,-1,0]
            AssertListEquals(new[] { -5, 3, -3, 1, -1, 0 }, head, solutionName);
            AssertNoCycle(head, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void ReorderList_AllSameValues_ReordersCorrectly(IReorderList_143 solution, string solutionName)
        {
            // Arrange: [5,5,5,5,5]
            ListNode head = CreateList(5, 5, 5, 5, 5);

            // Act
            solution.ReorderList(head);

            // Assert: [5,5,5,5,5] - Structure changes but values stay same
            AssertListEquals(new[] { 5, 5, 5, 5, 5 }, head, solutionName);
            AssertNoCycle(head, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void ReorderList_WithZeros_ReordersCorrectly(IReorderList_143 solution, string solutionName)
        {
            // Arrange: [0,1,0,2,0,3]
            ListNode head = CreateList(0, 1, 0, 2, 0, 3);

            // Act
            solution.ReorderList(head);

            // Assert: [0,3,1,0,0,2]
            AssertListEquals(new[] { 0, 3, 1, 0, 0, 2 }, head, solutionName);
            AssertNoCycle(head, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void ReorderList_LargeValues_ReordersCorrectly(IReorderList_143 solution, string solutionName)
        {
            // Arrange: [100,200,300,400,500]
            ListNode head = CreateList(100, 200, 300, 400, 500);

            // Act
            solution.ReorderList(head);

            // Assert: [100,500,200,400,300]
            AssertListEquals(new[] { 100, 500, 200, 400, 300 }, head, solutionName);
            AssertNoCycle(head, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void ReorderList_DescendingOrder_ReordersCorrectly(IReorderList_143 solution, string solutionName)
        {
            // Arrange: [10,9,8,7,6,5,4,3,2,1]
            ListNode head = CreateList(10, 9, 8, 7, 6, 5, 4, 3, 2, 1);

            // Act
            solution.ReorderList(head);

            // Assert: [10,1,9,2,8,3,7,4,6,5]
            AssertListEquals(new[] { 10, 1, 9, 2, 8, 3, 7, 4, 6, 5 }, head, solutionName);
            AssertNoCycle(head, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void ReorderList_AlternatingPattern_ReordersCorrectly(IReorderList_143 solution, string solutionName)
        {
            // Arrange: [1,-1,2,-2,3,-3]
            ListNode head = CreateList(1, -1, 2, -2, 3, -3);

            // Act
            solution.ReorderList(head);

            // Assert: [1,-3,-1,3,2,-2]
            AssertListEquals(new[] { 1, -3, -1, 3, 2, -2 }, head, solutionName);
            AssertNoCycle(head, solutionName);
        }

        #endregion

        #region Longer Lists

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void ReorderList_FifteenElements_ReordersCorrectly(IReorderList_143 solution, string solutionName)
        {
            // Arrange: [1,2,3,4,5,6,7,8,9,10,11,12,13,14,15]
            ListNode head = CreateList(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15);

            // Act
            solution.ReorderList(head);

            // Assert: [1,15,2,14,3,13,4,12,5,11,6,10,7,9,8]
            AssertListEquals(new[] { 1, 15, 2, 14, 3, 13, 4, 12, 5, 11, 6, 10, 7, 9, 8 }, head, solutionName);
            AssertNoCycle(head, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void ReorderList_TwentyElements_ReordersCorrectly(IReorderList_143 solution, string solutionName)
        {
            // Arrange: [1..20]
            ListNode head = CreateList(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20);

            // Act
            solution.ReorderList(head);

            // Assert: [1,20,2,19,3,18,4,17,5,16,6,15,7,14,8,13,9,12,10,11]
            AssertListEquals(new[] { 1, 20, 2, 19, 3, 18, 4, 17, 5, 16, 6, 15, 7, 14, 8, 13, 9, 12, 10, 11 }, 
                head, solutionName);
            AssertNoCycle(head, solutionName);
        }

        #endregion

        #region Edge Cases - Verification Tests

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void ReorderList_VerifyInPlaceModification(IReorderList_143 solution, string solutionName)
        {
            // Arrange: [1,2,3,4,5]
            ListNode head = CreateList(1, 2, 3, 4, 5);
            
            // Store original node references
            var originalNodes = new List<ListNode>();
            var current = head;
            while (current != null)
            {
                originalNodes.Add(current);
                current = current.next;
            }

            // Act
            solution.ReorderList(head);

            // Assert - All nodes should still be the same objects (in-place modification)
            var reorderedNodes = new HashSet<ListNode>();
            current = head;
            while (current != null)
            {
                reorderedNodes.Add(current);
                current = current.next;
            }

            Assert.AreEqual(originalNodes.Count, reorderedNodes.Count, 
                $"Node count should remain the same for {solutionName}");
            
            foreach (var node in originalNodes)
            {
                Assert.IsTrue(reorderedNodes.Contains(node), 
                    $"All original nodes should still be present for {solutionName}");
            }
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void ReorderList_VerifyNoValueModification(IReorderList_143 solution, string solutionName)
        {
            // Arrange: [1,2,3,4,5,6]
            ListNode head = CreateList(1, 2, 3, 4, 5, 6);
            
            // Store original values
            var originalValues = ToArray(head);
            var originalValueSet = new HashSet<int>(originalValues);

            // Act
            solution.ReorderList(head);

            // Assert - All values should still exist (though reordered)
            var reorderedValues = ToArray(head);
            var reorderedValueSet = new HashSet<int>(reorderedValues);

            Assert.AreEqual(originalValues.Length, reorderedValues.Length, 
                $"List length should remain the same for {solutionName}");
            
            CollectionAssert.AreEquivalent(originalValues, reorderedValues, 
                $"Same values should exist (just reordered) for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void ReorderList_VerifyListTermination(IReorderList_143 solution, string solutionName)
        {
            // Arrange: [1,2,3,4,5,6,7]
            ListNode head = CreateList(1, 2, 3, 4, 5, 6, 7);

            // Act
            solution.ReorderList(head);

            // Assert - List should properly terminate (last node's next should be null)
            var current = head;
            int count = 0;
            int maxIterations = 100; // Safety limit

            while (current != null && count < maxIterations)
            {
                if (current.next == null)
                {
                    // Found the end
                    Assert.AreEqual(4, current.val, 
                        $"Last node should have value 4 for this test for {solutionName}");
                    return;
                }
                current = current.next;
                count++;
            }

            Assert.Fail($"List does not properly terminate or has a cycle for {solutionName}");
        }

        #endregion

        #region Boundary Cases

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void ReorderList_MaxConstraintSize_ReordersCorrectly(IReorderList_143 solution, string solutionName)
        {
            // Arrange: 50 elements (reasonable test size)
            var values = Enumerable.Range(1, 50).ToArray();
            ListNode head = CreateList(values);

            // Act
            solution.ReorderList(head);

            // Assert - Verify pattern: first, last, second, second-to-last, etc.
            var expected = new List<int>();
            int left = 0, right = 49;
            while (left <= right)
            {
                expected.Add(values[left]);
                if (left != right)
                    expected.Add(values[right]);
                left++;
                right--;
            }

            AssertListEquals(expected.ToArray(), head, solutionName);
            AssertNoCycle(head, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void ReorderList_PowerOfTwo_ReordersCorrectly(IReorderList_143 solution, string solutionName)
        {
            // Arrange: 16 elements (power of 2)
            ListNode head = CreateList(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16);

            // Act
            solution.ReorderList(head);

            // Assert: [1,16,2,15,3,14,4,13,5,12,6,11,7,10,8,9]
            AssertListEquals(new[] { 1, 16, 2, 15, 3, 14, 4, 13, 5, 12, 6, 11, 7, 10, 8, 9 }, 
                head, solutionName);
            AssertNoCycle(head, solutionName);
        }

        #endregion
    }
}
