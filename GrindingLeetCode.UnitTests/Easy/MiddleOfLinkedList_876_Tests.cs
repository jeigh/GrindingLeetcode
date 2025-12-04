using LeetCodeProblems.CSharp.LinkedList;
using LeetCodeProblems.Interfaces.Easy;
using LeetCodeProblems.Shared;
using LeetCodeProblems.VisualBasic.LinkedList;

namespace GrindingLeetCode.UnitTests.Easy
{
    [TestClass]
    public class MiddleOfLinkedList_876_Tests
    {
        public static IEnumerable<object[]> GetImplementations()
        {
            yield return new object[] { new MiddleOfLinkedListCSharp_876(), "C#" };
            yield return new object[] { new MiddleOfLinkedListVB_876(), "VB" };
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

        #region LeetCode Examples

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void MiddleNode_Example1_ReturnsMiddleNodeOddLength(IMiddleOfLinkedList_876 solution, string solutionName)
        {
            // Arrange: [1,2,3,4,5]
            var head = CreateLinkedList(new[] { 1, 2, 3, 4, 5 });

            // Act
            var result = solution.MiddleNode(head);

            // Assert: [3,4,5] - middle node is 3
            AssertLinkedListEquals(new[] { 3, 4, 5 }, result, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void MiddleNode_Example2_ReturnsSecondMiddleNodeEvenLength(IMiddleOfLinkedList_876 solution, string solutionName)
        {
            // Arrange: [1,2,3,4,5,6]
            var head = CreateLinkedList(new[] { 1, 2, 3, 4, 5, 6 });

            // Act
            var result = solution.MiddleNode(head);

            // Assert: [4,5,6] - when two middle nodes exist, return the second one
            AssertLinkedListEquals(new[] { 4, 5, 6 }, result, solutionName);
        }

        #endregion

        #region Edge Cases

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void MiddleNode_SingleElement_ReturnsSameNode(IMiddleOfLinkedList_876 solution, string solutionName)
        {
            // Arrange: [1]
            var head = CreateLinkedList(new[] { 1 });

            // Act
            var result = solution.MiddleNode(head);

            // Assert: [1]
            AssertLinkedListEquals(new[] { 1 }, result, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void MiddleNode_TwoElements_ReturnsSecondElement(IMiddleOfLinkedList_876 solution, string solutionName)
        {
            // Arrange: [1,2]
            var head = CreateLinkedList(new[] { 1, 2 });

            // Act
            var result = solution.MiddleNode(head);

            // Assert: [2] - second middle node
            AssertLinkedListEquals(new[] { 2 }, result, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void MiddleNode_ThreeElements_ReturnsMiddleElement(IMiddleOfLinkedList_876 solution, string solutionName)
        {
            // Arrange: [1,2,3]
            var head = CreateLinkedList(new[] { 1, 2, 3 });

            // Act
            var result = solution.MiddleNode(head);

            // Assert: [2,3]
            AssertLinkedListEquals(new[] { 2, 3 }, result, solutionName);
        }

        #endregion

        #region Odd Length Lists

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void MiddleNode_SevenElements_ReturnsMiddleNode(IMiddleOfLinkedList_876 solution, string solutionName)
        {
            // Arrange: [1,2,3,4,5,6,7]
            var head = CreateLinkedList(new[] { 1, 2, 3, 4, 5, 6, 7 });

            // Act
            var result = solution.MiddleNode(head);

            // Assert: [4,5,6,7] - middle is 4th element (index 3)
            AssertLinkedListEquals(new[] { 4, 5, 6, 7 }, result, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void MiddleNode_NineElements_ReturnsMiddleNode(IMiddleOfLinkedList_876 solution, string solutionName)
        {
            // Arrange: [1,2,3,4,5,6,7,8,9]
            var head = CreateLinkedList(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 });

            // Act
            var result = solution.MiddleNode(head);

            // Assert: [5,6,7,8,9] - middle is 5th element (index 4)
            AssertLinkedListEquals(new[] { 5, 6, 7, 8, 9 }, result, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void MiddleNode_ElevenElements_ReturnsMiddleNode(IMiddleOfLinkedList_876 solution, string solutionName)
        {
            // Arrange: [1,2,3,4,5,6,7,8,9,10,11]
            var head = CreateLinkedList(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 });

            // Act
            var result = solution.MiddleNode(head);

            // Assert: [6,7,8,9,10,11] - middle is 6th element (index 5)
            AssertLinkedListEquals(new[] { 6, 7, 8, 9, 10, 11 }, result, solutionName);
        }

        #endregion

        #region Even Length Lists

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void MiddleNode_FourElements_ReturnsSecondMiddle(IMiddleOfLinkedList_876 solution, string solutionName)
        {
            // Arrange: [1,2,3,4]
            var head = CreateLinkedList(new[] { 1, 2, 3, 4 });

            // Act
            var result = solution.MiddleNode(head);

            // Assert: [3,4] - second middle node
            AssertLinkedListEquals(new[] { 3, 4 }, result, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void MiddleNode_EightElements_ReturnsSecondMiddle(IMiddleOfLinkedList_876 solution, string solutionName)
        {
            // Arrange: [1,2,3,4,5,6,7,8]
            var head = CreateLinkedList(new[] { 1, 2, 3, 4, 5, 6, 7, 8 });

            // Act
            var result = solution.MiddleNode(head);

            // Assert: [5,6,7,8] - second middle node (5th element)
            AssertLinkedListEquals(new[] { 5, 6, 7, 8 }, result, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void MiddleNode_TenElements_ReturnsSecondMiddle(IMiddleOfLinkedList_876 solution, string solutionName)
        {
            // Arrange: [1,2,3,4,5,6,7,8,9,10]
            var head = CreateLinkedList(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });

            // Act
            var result = solution.MiddleNode(head);

            // Assert: [6,7,8,9,10] - second middle node (6th element)
            AssertLinkedListEquals(new[] { 6, 7, 8, 9, 10 }, result, solutionName);
        }

        #endregion

        #region Different Value Patterns

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void MiddleNode_WithNegativeNumbers_ReturnsMiddleNode(IMiddleOfLinkedList_876 solution, string solutionName)
        {
            // Arrange: [-5,-3,-1,0,1,3,5]
            var head = CreateLinkedList(new[] { -5, -3, -1, 0, 1, 3, 5 });

            // Act
            var result = solution.MiddleNode(head);

            // Assert: [0,1,3,5]
            AssertLinkedListEquals(new[] { 0, 1, 3, 5 }, result, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void MiddleNode_WithDuplicates_ReturnsMiddleNode(IMiddleOfLinkedList_876 solution, string solutionName)
        {
            // Arrange: [1,1,2,2,3,3]
            var head = CreateLinkedList(new[] { 1, 1, 2, 2, 3, 3 });

            // Act
            var result = solution.MiddleNode(head);

            // Assert: [2,3,3] - second middle node
            AssertLinkedListEquals(new[] { 2, 3, 3 }, result, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void MiddleNode_AllSameValues_ReturnsMiddleNode(IMiddleOfLinkedList_876 solution, string solutionName)
        {
            // Arrange: [5,5,5,5,5]
            var head = CreateLinkedList(new[] { 5, 5, 5, 5, 5 });

            // Act
            var result = solution.MiddleNode(head);

            // Assert: [5,5,5]
            AssertLinkedListEquals(new[] { 5, 5, 5 }, result, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void MiddleNode_WithZeros_ReturnsMiddleNode(IMiddleOfLinkedList_876 solution, string solutionName)
        {
            // Arrange: [0,0,1,2,3]
            var head = CreateLinkedList(new[] { 0, 0, 1, 2, 3 });

            // Act
            var result = solution.MiddleNode(head);

            // Assert: [1,2,3]
            AssertLinkedListEquals(new[] { 1, 2, 3 }, result, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void MiddleNode_LargeNumbers_ReturnsMiddleNode(IMiddleOfLinkedList_876 solution, string solutionName)
        {
            // Arrange: [100,200,300,400,500]
            var head = CreateLinkedList(new[] { 100, 200, 300, 400, 500 });

            // Act
            var result = solution.MiddleNode(head);

            // Assert: [300,400,500]
            AssertLinkedListEquals(new[] { 300, 400, 500 }, result, solutionName);
        }

        #endregion

        #region Boundary Cases

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void MiddleNode_MaxConstraintSize_OddLength_ReturnsMiddleNode(IMiddleOfLinkedList_876 solution, string solutionName)
        {
            // Arrange: [1,2,3,...,99,100,101] - 101 elements (odd)
            var values = Enumerable.Range(1, 101).ToArray();
            var head = CreateLinkedList(values);

            // Act
            var result = solution.MiddleNode(head);

            // Assert: middle should start at element 51 (index 50)
            var expected = Enumerable.Range(51, 51).ToArray();
            AssertLinkedListEquals(expected, result, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void MiddleNode_MaxConstraintSize_EvenLength_ReturnsSecondMiddle(IMiddleOfLinkedList_876 solution, string solutionName)
        {
            // Arrange: [1,2,3,...,99,100] - 100 elements (even)
            var values = Enumerable.Range(1, 100).ToArray();
            var head = CreateLinkedList(values);

            // Act
            var result = solution.MiddleNode(head);

            // Assert: second middle should start at element 51 (index 50)
            var expected = Enumerable.Range(51, 50).ToArray();
            AssertLinkedListEquals(expected, result, solutionName);
        }

        #endregion

        #region Sequential Values

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void MiddleNode_SequentialAscending_ReturnsMiddleNode(IMiddleOfLinkedList_876 solution, string solutionName)
        {
            // Arrange: [10,20,30,40,50,60,70]
            var head = CreateLinkedList(new[] { 10, 20, 30, 40, 50, 60, 70 });

            // Act
            var result = solution.MiddleNode(head);

            // Assert: [40,50,60,70]
            AssertLinkedListEquals(new[] { 40, 50, 60, 70 }, result, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void MiddleNode_SequentialDescending_ReturnsMiddleNode(IMiddleOfLinkedList_876 solution, string solutionName)
        {
            // Arrange: [70,60,50,40,30,20,10]
            var head = CreateLinkedList(new[] { 70, 60, 50, 40, 30, 20, 10 });

            // Act
            var result = solution.MiddleNode(head);

            // Assert: [40,30,20,10]
            AssertLinkedListEquals(new[] { 40, 30, 20, 10 }, result, solutionName);
        }

        #endregion

        #region Verify Original List Unchanged

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void MiddleNode_DoesNotModifyOriginalList(IMiddleOfLinkedList_876 solution, string solutionName)
        {
            // Arrange: [1,2,3,4,5]
            var head = CreateLinkedList(new[] { 1, 2, 3, 4, 5 });
            var originalValues = LinkedListToArray(head);

            // Act
            var result = solution.MiddleNode(head);

            // Assert: Original list should remain unchanged
            AssertLinkedListEquals(originalValues, head, solutionName);
            AssertLinkedListEquals(new[] { 3, 4, 5 }, result, solutionName);
        }

        #endregion
    }
}