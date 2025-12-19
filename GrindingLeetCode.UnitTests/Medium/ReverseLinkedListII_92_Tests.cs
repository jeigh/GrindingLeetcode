using LeetCodeProblems.CSharp.LinkedList;
using LeetCodeProblems.Interfaces.Medium;
using LeetCodeProblems.Shared;
using LeetCodeProblems.VisualBasic.LinkedList;

namespace GrindingLeetCode.UnitTests.Medium
{
    [TestClass]
    public class ReverseLinkedListII_92_Tests
    {
        public static IEnumerable<object[]> GetImplementations()
        {
            //yield return new object[] { new ReverseLinkedListII_MoveToFrontCSharp_92(), "C# Move-To-Front approach" };
            //yield return new object[] { new ReverseLinkedListII_ReversalAndReconnectCSharp_92(), "C# Reversal + Reconnection approach" };
            //yield return new object[] { new ReverseLinkedListII_ReversalAndReconnectionVB_92(), "VB Reversal + Reconnection approach" };
            yield return new object[] { new ReverseLinkedListII_MoveToFrontVB_92(), "VB Move-to-front approach" };
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
        public void ReverseBetween_Example1_ReversesMiddleThreeNodes(IReverseLinkedListII_92 solution, string solutionName)
        {
            // Arrange: [1,2,3,4,5], left = 2, right = 4
            ListNode head = CreateList(1, 2, 3, 4, 5);

            // Act
            ListNode result = solution.ReverseBetween(head, 2, 4);

            // Assert: [1,4,3,2,5]
            AssertListEquals(new[] { 1, 4, 3, 2, 5 }, result, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void ReverseBetween_Example2_ReversesSingleNode(IReverseLinkedListII_92 solution, string solutionName)
        {
            // Arrange: [5], left = 1, right = 1
            ListNode head = CreateList(5);

            // Act
            ListNode result = solution.ReverseBetween(head, 1, 1);

            // Assert: [5] - no change
            AssertListEquals(new[] { 5 }, result, solutionName);
        }

        #endregion

        #region Reverse Entire List

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void ReverseBetween_ReverseEntireList_TwoNodes(IReverseLinkedListII_92 solution, string solutionName)
        {
            // Arrange: [1,2], left = 1, right = 2
            ListNode head = CreateList(1, 2);

            // Act
            ListNode result = solution.ReverseBetween(head, 1, 2);

            // Assert: [2,1]
            AssertListEquals(new[] { 2, 1 }, result, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void ReverseBetween_ReverseEntireList_ThreeNodes(IReverseLinkedListII_92 solution, string solutionName)
        {
            // Arrange: [1,2,3], left = 1, right = 3
            ListNode head = CreateList(1, 2, 3);

            // Act
            ListNode result = solution.ReverseBetween(head, 1, 3);

            // Assert: [3,2,1]
            AssertListEquals(new[] { 3, 2, 1 }, result, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void ReverseBetween_ReverseEntireList_FiveNodes(IReverseLinkedListII_92 solution, string solutionName)
        {
            // Arrange: [1,2,3,4,5], left = 1, right = 5
            ListNode head = CreateList(1, 2, 3, 4, 5);

            // Act
            ListNode result = solution.ReverseBetween(head, 1, 5);

            // Assert: [5,4,3,2,1]
            AssertListEquals(new[] { 5, 4, 3, 2, 1 }, result, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void ReverseBetween_ReverseEntireList_TenNodes(IReverseLinkedListII_92 solution, string solutionName)
        {
            // Arrange: [1,2,3,4,5,6,7,8,9,10], left = 1, right = 10
            ListNode head = CreateList(1, 2, 3, 4, 5, 6, 7, 8, 9, 10);

            // Act
            ListNode result = solution.ReverseBetween(head, 1, 10);

            // Assert: [10,9,8,7,6,5,4,3,2,1]
            AssertListEquals(new[] { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 }, result, solutionName);
        }

        #endregion

        #region Reverse From Start

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void ReverseBetween_ReverseFromStart_FirstTwo(IReverseLinkedListII_92 solution, string solutionName)
        {
            // Arrange: [1,2,3,4,5], left = 1, right = 2
            ListNode head = CreateList(1, 2, 3, 4, 5);

            // Act
            ListNode result = solution.ReverseBetween(head, 1, 2);

            // Assert: [2,1,3,4,5]
            AssertListEquals(new[] { 2, 1, 3, 4, 5 }, result, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void ReverseBetween_ReverseFromStart_FirstThree(IReverseLinkedListII_92 solution, string solutionName)
        {
            // Arrange: [1,2,3,4,5], left = 1, right = 3
            ListNode head = CreateList(1, 2, 3, 4, 5);

            // Act
            ListNode result = solution.ReverseBetween(head, 1, 3);

            // Assert: [3,2,1,4,5]
            AssertListEquals(new[] { 3, 2, 1, 4, 5 }, result, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void ReverseBetween_ReverseFromStart_FirstFour(IReverseLinkedListII_92 solution, string solutionName)
        {
            // Arrange: [1,2,3,4,5], left = 1, right = 4
            ListNode head = CreateList(1, 2, 3, 4, 5);

            // Act
            ListNode result = solution.ReverseBetween(head, 1, 4);

            // Assert: [4,3,2,1,5]
            AssertListEquals(new[] { 4, 3, 2, 1, 5 }, result, solutionName);
        }

        #endregion

        #region Reverse To End

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void ReverseBetween_ReverseToEnd_LastTwo(IReverseLinkedListII_92 solution, string solutionName)
        {
            // Arrange: [1,2,3,4,5], left = 4, right = 5
            ListNode head = CreateList(1, 2, 3, 4, 5);

            // Act
            ListNode result = solution.ReverseBetween(head, 4, 5);

            // Assert: [1,2,3,5,4]
            AssertListEquals(new[] { 1, 2, 3, 5, 4 }, result, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void ReverseBetween_ReverseToEnd_LastThree(IReverseLinkedListII_92 solution, string solutionName)
        {
            // Arrange: [1,2,3,4,5], left = 3, right = 5
            ListNode head = CreateList(1, 2, 3, 4, 5);

            // Act
            ListNode result = solution.ReverseBetween(head, 3, 5);

            // Assert: [1,2,5,4,3]
            AssertListEquals(new[] { 1, 2, 5, 4, 3 }, result, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void ReverseBetween_ReverseToEnd_LastFour(IReverseLinkedListII_92 solution, string solutionName)
        {
            // Arrange: [1,2,3,4,5], left = 2, right = 5
            ListNode head = CreateList(1, 2, 3, 4, 5);

            // Act
            ListNode result = solution.ReverseBetween(head, 2, 5);

            // Assert: [1,5,4,3,2]
            AssertListEquals(new[] { 1, 5, 4, 3, 2 }, result, solutionName);
        }

        #endregion

        #region Reverse Middle Sections

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void ReverseBetween_ReverseMiddle_TwoNodes(IReverseLinkedListII_92 solution, string solutionName)
        {
            // Arrange: [1,2,3,4,5], left = 2, right = 3
            ListNode head = CreateList(1, 2, 3, 4, 5);

            // Act
            ListNode result = solution.ReverseBetween(head, 2, 3);

            // Assert: [1,3,2,4,5]
            AssertListEquals(new[] { 1, 3, 2, 4, 5 }, result, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void ReverseBetween_ReverseMiddle_ThreeNodesInMiddle(IReverseLinkedListII_92 solution, string solutionName)
        {
            // Arrange: [1,2,3,4,5,6,7], left = 3, right = 5
            ListNode head = CreateList(1, 2, 3, 4, 5, 6, 7);

            // Act
            ListNode result = solution.ReverseBetween(head, 3, 5);

            // Assert: [1,2,5,4,3,6,7]
            AssertListEquals(new[] { 1, 2, 5, 4, 3, 6, 7 }, result, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void ReverseBetween_ReverseMiddle_FourNodesInMiddle(IReverseLinkedListII_92 solution, string solutionName)
        {
            // Arrange: [1,2,3,4,5,6,7,8], left = 3, right = 6
            ListNode head = CreateList(1, 2, 3, 4, 5, 6, 7, 8);

            // Act
            ListNode result = solution.ReverseBetween(head, 3, 6);

            // Assert: [1,2,6,5,4,3,7,8]
            AssertListEquals(new[] { 1, 2, 6, 5, 4, 3, 7, 8 }, result, solutionName);
        }

        #endregion

        #region Single Node Reversals (left == right)

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void ReverseBetween_SingleNodeReversal_FirstNode(IReverseLinkedListII_92 solution, string solutionName)
        {
            // Arrange: [1,2,3,4,5], left = 1, right = 1
            ListNode head = CreateList(1, 2, 3, 4, 5);

            // Act
            ListNode result = solution.ReverseBetween(head, 1, 1);

            // Assert: [1,2,3,4,5] - no change
            AssertListEquals(new[] { 1, 2, 3, 4, 5 }, result, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void ReverseBetween_SingleNodeReversal_MiddleNode(IReverseLinkedListII_92 solution, string solutionName)
        {
            // Arrange: [1,2,3,4,5], left = 3, right = 3
            ListNode head = CreateList(1, 2, 3, 4, 5);

            // Act
            ListNode result = solution.ReverseBetween(head, 3, 3);

            // Assert: [1,2,3,4,5] - no change
            AssertListEquals(new[] { 1, 2, 3, 4, 5 }, result, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void ReverseBetween_SingleNodeReversal_LastNode(IReverseLinkedListII_92 solution, string solutionName)
        {
            // Arrange: [1,2,3,4,5], left = 5, right = 5
            ListNode head = CreateList(1, 2, 3, 4, 5);

            // Act
            ListNode result = solution.ReverseBetween(head, 5, 5);

            // Assert: [1,2,3,4,5] - no change
            AssertListEquals(new[] { 1, 2, 3, 4, 5 }, result, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void ReverseBetween_SingleNodeList_NoChange(IReverseLinkedListII_92 solution, string solutionName)
        {
            // Arrange: [1], left = 1, right = 1
            ListNode head = CreateList(1);

            // Act
            ListNode result = solution.ReverseBetween(head, 1, 1);

            // Assert: [1] - no change
            AssertListEquals(new[] { 1 }, result, solutionName);
        }

        #endregion

        #region Two Node Lists

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void ReverseBetween_TwoNodeList_ReverseBoth(IReverseLinkedListII_92 solution, string solutionName)
        {
            // Arrange: [1,2], left = 1, right = 2
            ListNode head = CreateList(1, 2);

            // Act
            ListNode result = solution.ReverseBetween(head, 1, 2);

            // Assert: [2,1]
            AssertListEquals(new[] { 2, 1 }, result, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void ReverseBetween_TwoNodeList_ReverseFirst(IReverseLinkedListII_92 solution, string solutionName)
        {
            // Arrange: [1,2], left = 1, right = 1
            ListNode head = CreateList(1, 2);

            // Act
            ListNode result = solution.ReverseBetween(head, 1, 1);

            // Assert: [1,2] - no change
            AssertListEquals(new[] { 1, 2 }, result, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void ReverseBetween_TwoNodeList_ReverseSecond(IReverseLinkedListII_92 solution, string solutionName)
        {
            // Arrange: [1,2], left = 2, right = 2
            ListNode head = CreateList(1, 2);

            // Act
            ListNode result = solution.ReverseBetween(head, 2, 2);

            // Assert: [1,2] - no change
            AssertListEquals(new[] { 1, 2 }, result, solutionName);
        }

        #endregion

        #region Different Value Patterns

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void ReverseBetween_NegativeValues_ReversesCorrectly(IReverseLinkedListII_92 solution, string solutionName)
        {
            // Arrange: [-5,-4,-3,-2,-1], left = 2, right = 4
            ListNode head = CreateList(-5, -4, -3, -2, -1);

            // Act
            ListNode result = solution.ReverseBetween(head, 2, 4);

            // Assert: [-5,-2,-3,-4,-1]
            AssertListEquals(new[] { -5, -2, -3, -4, -1 }, result, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void ReverseBetween_MixedValues_ReversesCorrectly(IReverseLinkedListII_92 solution, string solutionName)
        {
            // Arrange: [-2,-1,0,1,2], left = 2, right = 4
            ListNode head = CreateList(-2, -1, 0, 1, 2);

            // Act
            ListNode result = solution.ReverseBetween(head, 2, 4);

            // Assert: [-2,1,0,-1,2]
            AssertListEquals(new[] { -2, 1, 0, -1, 2 }, result, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void ReverseBetween_WithZeros_ReversesCorrectly(IReverseLinkedListII_92 solution, string solutionName)
        {
            // Arrange: [0,0,1,2,3], left = 1, right = 3
            ListNode head = CreateList(0, 0, 1, 2, 3);

            // Act
            ListNode result = solution.ReverseBetween(head, 1, 3);

            // Assert: [1,0,0,2,3]
            AssertListEquals(new[] { 1, 0, 0, 2, 3 }, result, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void ReverseBetween_AllSameValues_ReversesCorrectly(IReverseLinkedListII_92 solution, string solutionName)
        {
            // Arrange: [5,5,5,5,5], left = 2, right = 4
            ListNode head = CreateList(5, 5, 5, 5, 5);

            // Act
            ListNode result = solution.ReverseBetween(head, 2, 4);

            // Assert: [5,5,5,5,5] - looks the same but order reversed
            AssertListEquals(new[] { 5, 5, 5, 5, 5 }, result, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void ReverseBetween_LargeNumbers_ReversesCorrectly(IReverseLinkedListII_92 solution, string solutionName)
        {
            // Arrange: [100,200,300,400,500], left = 2, right = 4
            ListNode head = CreateList(100, 200, 300, 400, 500);

            // Act
            ListNode result = solution.ReverseBetween(head, 2, 4);

            // Assert: [100,400,300,200,500]
            AssertListEquals(new[] { 100, 400, 300, 200, 500 }, result, solutionName);
        }

        #endregion

        #region Longer Lists

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void ReverseBetween_TenElements_ReverseMiddleFive(IReverseLinkedListII_92 solution, string solutionName)
        {
            // Arrange: [1,2,3,4,5,6,7,8,9,10], left = 3, right = 7
            ListNode head = CreateList(1, 2, 3, 4, 5, 6, 7, 8, 9, 10);

            // Act
            ListNode result = solution.ReverseBetween(head, 3, 7);

            // Assert: [1,2,7,6,5,4,3,8,9,10]
            AssertListEquals(new[] { 1, 2, 7, 6, 5, 4, 3, 8, 9, 10 }, result, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void ReverseBetween_FifteenElements_ReverseFromSecondToFourteenth(IReverseLinkedListII_92 solution, string solutionName)
        {
            // Arrange: [1,2,3,4,5,6,7,8,9,10,11,12,13,14,15], left = 2, right = 14
            ListNode head = CreateList(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15);

            // Act
            ListNode result = solution.ReverseBetween(head, 2, 14);

            // Assert: [1,14,13,12,11,10,9,8,7,6,5,4,3,2,15]
            AssertListEquals(new[] { 1, 14, 13, 12, 11, 10, 9, 8, 7, 6, 5, 4, 3, 2, 15 }, result, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void ReverseBetween_TwentyElements_ReverseMiddleTen(IReverseLinkedListII_92 solution, string solutionName)
        {
            // Arrange: [1..20], left = 6, right = 15
            ListNode head = CreateList(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20);

            // Act
            ListNode result = solution.ReverseBetween(head, 6, 15);

            // Assert: [1,2,3,4,5,15,14,13,12,11,10,9,8,7,6,16,17,18,19,20]
            AssertListEquals(new[] { 1, 2, 3, 4, 5, 15, 14, 13, 12, 11, 10, 9, 8, 7, 6, 16, 17, 18, 19, 20 }, result, solutionName);
        }

        #endregion

        #region Adjacent Positions

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void ReverseBetween_AdjacentPositions_FirstTwo(IReverseLinkedListII_92 solution, string solutionName)
        {
            // Arrange: [1,2,3,4,5], left = 1, right = 2
            ListNode head = CreateList(1, 2, 3, 4, 5);

            // Act
            ListNode result = solution.ReverseBetween(head, 1, 2);

            // Assert: [2,1,3,4,5]
            AssertListEquals(new[] { 2, 1, 3, 4, 5 }, result, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void ReverseBetween_AdjacentPositions_SecondAndThird(IReverseLinkedListII_92 solution, string solutionName)
        {
            // Arrange: [1,2,3,4,5], left = 2, right = 3
            ListNode head = CreateList(1, 2, 3, 4, 5);

            // Act
            ListNode result = solution.ReverseBetween(head, 2, 3);

            // Assert: [1,3,2,4,5]
            AssertListEquals(new[] { 1, 3, 2, 4, 5 }, result, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void ReverseBetween_AdjacentPositions_ThirdAndFourth(IReverseLinkedListII_92 solution, string solutionName)
        {
            // Arrange: [1,2,3,4,5], left = 3, right = 4
            ListNode head = CreateList(1, 2, 3, 4, 5);

            // Act
            ListNode result = solution.ReverseBetween(head, 3, 4);

            // Assert: [1,2,4,3,5]
            AssertListEquals(new[] { 1, 2, 4, 3, 5 }, result, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void ReverseBetween_AdjacentPositions_LastTwo(IReverseLinkedListII_92 solution, string solutionName)
        {
            // Arrange: [1,2,3,4,5], left = 4, right = 5
            ListNode head = CreateList(1, 2, 3, 4, 5);

            // Act
            ListNode result = solution.ReverseBetween(head, 4, 5);

            // Assert: [1,2,3,5,4]
            AssertListEquals(new[] { 1, 2, 3, 5, 4 }, result, solutionName);
        }

        #endregion

        #region Edge Cases with Three Nodes

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void ReverseBetween_ThreeNodeList_ReverseAll(IReverseLinkedListII_92 solution, string solutionName)
        {
            // Arrange: [1,2,3], left = 1, right = 3
            ListNode head = CreateList(1, 2, 3);

            // Act
            ListNode result = solution.ReverseBetween(head, 1, 3);

            // Assert: [3,2,1]
            AssertListEquals(new[] { 3, 2, 1 }, result, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void ReverseBetween_ThreeNodeList_ReverseFirstTwo(IReverseLinkedListII_92 solution, string solutionName)
        {
            // Arrange: [1,2,3], left = 1, right = 2
            ListNode head = CreateList(1, 2, 3);

            // Act
            ListNode result = solution.ReverseBetween(head, 1, 2);

            // Assert: [2,1,3]
            AssertListEquals(new[] { 2, 1, 3 }, result, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void ReverseBetween_ThreeNodeList_ReverseLastTwo(IReverseLinkedListII_92 solution, string solutionName)
        {
            // Arrange: [1,2,3], left = 2, right = 3
            ListNode head = CreateList(1, 2, 3);

            // Act
            ListNode result = solution.ReverseBetween(head, 2, 3);

            // Assert: [1,3,2]
            AssertListEquals(new[] { 1, 3, 2 }, result, solutionName);
        }

        #endregion

        #region Boundary Constraints

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void ReverseBetween_MaxConstraint_ReverseAllFiveHundred(IReverseLinkedListII_92 solution, string solutionName)
        {
            // Arrange: [1..500], left = 1, right = 500
            var values = Enumerable.Range(1, 500).ToArray();
            ListNode head = CreateList(values);

            // Act
            ListNode result = solution.ReverseBetween(head, 1, 500);

            // Assert: [500..1]
            var expected = Enumerable.Range(1, 500).Reverse().ToArray();
            AssertListEquals(expected, result, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void ReverseBetween_LargeList_ReverseMiddleSection(IReverseLinkedListII_92 solution, string solutionName)
        {
            // Arrange: [1..100], left = 25, right = 75
            var values = Enumerable.Range(1, 100).ToArray();
            ListNode head = CreateList(values);

            // Act
            ListNode result = solution.ReverseBetween(head, 25, 75);

            // Assert: [1..24, 75..25, 76..100]
            var expected = Enumerable.Range(1, 24)
                .Concat(Enumerable.Range(25, 51).Reverse())
                .Concat(Enumerable.Range(76, 25))
                .ToArray();
            AssertListEquals(expected, result, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void ReverseBetween_LargeList_ReverseLargeMiddle(IReverseLinkedListII_92 solution, string solutionName)
        {
            // Arrange: [1..200], left = 10, right = 190
            var values = Enumerable.Range(1, 200).ToArray();
            ListNode head = CreateList(values);

            // Act
            ListNode result = solution.ReverseBetween(head, 10, 190);

            // Assert: [1..9, 190..10, 191..200]
            var expected = Enumerable.Range(1, 9)
                .Concat(Enumerable.Range(10, 181).Reverse())
                .Concat(Enumerable.Range(191, 10))
                .ToArray();
            AssertListEquals(expected, result, solutionName);
        }

        #endregion

        #region Special Patterns

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void ReverseBetween_DescendingOrder_ReversesMiddle(IReverseLinkedListII_92 solution, string solutionName)
        {
            // Arrange: [10,9,8,7,6,5,4,3,2,1], left = 3, right = 7
            ListNode head = CreateList(10, 9, 8, 7, 6, 5, 4, 3, 2, 1);

            // Act
            ListNode result = solution.ReverseBetween(head, 3, 7);

            // Assert: [10,9,4,5,6,7,8,3,2,1]
            AssertListEquals(new[] { 10, 9, 4, 5, 6, 7, 8, 3, 2, 1 }, result, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void ReverseBetween_AlternatingValues_ReversesMiddle(IReverseLinkedListII_92 solution, string solutionName)
        {
            // Arrange: [1,10,2,9,3,8,4,7,5,6], left = 3, right = 8
            ListNode head = CreateList(1, 10, 2, 9, 3, 8, 4, 7, 5, 6);

            // Act
            ListNode result = solution.ReverseBetween(head, 3, 8);

            // Assert: [1,10,7,4,8,3,9,2,5,6]
            AssertListEquals(new[] { 1, 10, 7, 4, 8, 3, 9, 2, 5, 6 }, result, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void ReverseBetween_WithDuplicates_ReversesCorrectly(IReverseLinkedListII_92 solution, string solutionName)
        {
            // Arrange: [1,2,2,3,3,3,4,4,4,4], left = 3, right = 8
            ListNode head = CreateList(1, 2, 2, 3, 3, 3, 4, 4, 4, 4);

            // Act
            ListNode result = solution.ReverseBetween(head, 3, 8);

            // Assert: [1,2,4,4,3,3,3,2,4,4]
            AssertListEquals(new[] { 1, 2, 4, 4, 3, 3, 3, 2, 4, 4 }, result, solutionName);
        }

        #endregion

        #region Multiple Reversal Positions

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void ReverseBetween_NearBeginning_Position2To4(IReverseLinkedListII_92 solution, string solutionName)
        {
            // Arrange: [1,2,3,4,5,6,7,8,9,10], left = 2, right = 4
            ListNode head = CreateList(1, 2, 3, 4, 5, 6, 7, 8, 9, 10);

            // Act
            ListNode result = solution.ReverseBetween(head, 2, 4);

            // Assert: [1,4,3,2,5,6,7,8,9,10]
            AssertListEquals(new[] { 1, 4, 3, 2, 5, 6, 7, 8, 9, 10 }, result, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void ReverseBetween_NearEnd_Position7To9(IReverseLinkedListII_92 solution, string solutionName)
        {
            // Arrange: [1,2,3,4,5,6,7,8,9,10], left = 7, right = 9
            ListNode head = CreateList(1, 2, 3, 4, 5, 6, 7, 8, 9, 10);

            // Act
            ListNode result = solution.ReverseBetween(head, 7, 9);

            // Assert: [1,2,3,4,5,6,9,8,7,10]
            AssertListEquals(new[] { 1, 2, 3, 4, 5, 6, 9, 8, 7, 10 }, result, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void ReverseBetween_ExactMiddle_Position4To7(IReverseLinkedListII_92 solution, string solutionName)
        {
            // Arrange: [1,2,3,4,5,6,7,8,9,10], left = 4, right = 7
            ListNode head = CreateList(1, 2, 3, 4, 5, 6, 7, 8, 9, 10);

            // Act
            ListNode result = solution.ReverseBetween(head, 4, 7);

            // Assert: [1,2,3,7,6,5,4,8,9,10]
            AssertListEquals(new[] { 1, 2, 3, 7, 6, 5, 4, 8, 9, 10 }, result, solutionName);
        }

        #endregion
    }
}
