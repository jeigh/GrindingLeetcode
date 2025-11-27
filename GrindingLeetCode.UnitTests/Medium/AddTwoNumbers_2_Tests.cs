using LeetCodeProblems.CSharp.LinkedList;
using LeetCodeProblems.Interfaces.Medium;
using LeetCodeProblems.Shared;
using LeetCodeProblems.VisualBasic.LinkedList;

namespace GrindingLeetCode.UnitTests.Medium
{
    [TestClass]
    public class AddTwoNumbers_2_Tests
    {
        public static IEnumerable<object[]> GetImplementations()
        {
            //yield return new object[] { new AddTwoUsingRecursionCSharp_2(), "C# Recursive" };
            //yield return new object[] { new AddTwoUsingBigIntegerCSharp_2(), "C# BigInteger" };
            yield return new object[] { new AddTwoNumbersVB_2(), "VB" };
        }

        #region Helper Methods

        /// <summary>
        /// Creates a linked list from an array of digits (in reverse order as per problem spec)
        /// </summary>
        private ListNode CreateList(params int[] digits)
        {
            if (digits == null || digits.Length == 0) return null;

            ListNode head = new ListNode(digits[0]);
            ListNode current = head;

            for (int i = 1; i < digits.Length; i++)
            {
                current.next = new ListNode(digits[i]);
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
        public void AddTwoNumbers_Example1_Returns807(IAddTwoNumbers_2 solution, string solutionName)
        {
            // Arrange: 342 + 465 = 807 (stored as 2->4->3 and 5->6->4)
            ListNode l1 = CreateList(2, 4, 3);
            ListNode l2 = CreateList(5, 6, 4);

            // Act
            ListNode result = solution.AddTwoNumbers(l1, l2);

            // Assert: 7->0->8
            AssertListEquals(new[] { 7, 0, 8 }, result, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void AddTwoNumbers_Example2_ZeroPlusZero_ReturnsZero(IAddTwoNumbers_2 solution, string solutionName)
        {
            // Arrange: 0 + 0 = 0
            ListNode l1 = CreateList(0);
            ListNode l2 = CreateList(0);

            // Act
            ListNode result = solution.AddTwoNumbers(l1, l2);

            // Assert: 0
            AssertListEquals(new[] { 0 }, result, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void AddTwoNumbers_Example3_LargeDifferentLengths_ReturnsCorrectSum(IAddTwoNumbers_2 solution, string solutionName)
        {
            // Arrange: 9999999 + 9999 = 10009998 (stored reversed)
            ListNode l1 = CreateList(9, 9, 9, 9, 9, 9, 9);
            ListNode l2 = CreateList(9, 9, 9, 9);

            // Act
            ListNode result = solution.AddTwoNumbers(l1, l2);

            // Assert: 8->9->9->9->0->0->0->1
            AssertListEquals(new[] { 8, 9, 9, 9, 0, 0, 0, 1 }, result, solutionName);
        }

        #endregion

        #region Basic Cases

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void AddTwoNumbers_SingleDigitNoCarry_ReturnsSum(IAddTwoNumbers_2 solution, string solutionName)
        {
            // Arrange: 2 + 3 = 5
            ListNode l1 = CreateList(2);
            ListNode l2 = CreateList(3);

            // Act
            ListNode result = solution.AddTwoNumbers(l1, l2);

            // Assert: 5
            AssertListEquals(new[] { 5 }, result, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void AddTwoNumbers_SingleDigitWithCarry_ReturnsTwoDigits(IAddTwoNumbers_2 solution, string solutionName)
        {
            // Arrange: 5 + 5 = 10
            ListNode l1 = CreateList(5);
            ListNode l2 = CreateList(5);

            // Act
            ListNode result = solution.AddTwoNumbers(l1, l2);

            // Assert: 0->1
            AssertListEquals(new[] { 0, 1 }, result, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void AddTwoNumbers_TwoDigitsNoCarry_ReturnsSum(IAddTwoNumbers_2 solution, string solutionName)
        {
            // Arrange: 12 + 23 = 35 (stored as 2->1 and 3->2)
            ListNode l1 = CreateList(2, 1);
            ListNode l2 = CreateList(3, 2);

            // Act
            ListNode result = solution.AddTwoNumbers(l1, l2);

            // Assert: 5->3
            AssertListEquals(new[] { 5, 3 }, result, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void AddTwoNumbers_TwoDigitsWithCarry_ReturnsCorrectSum(IAddTwoNumbers_2 solution, string solutionName)
        {
            // Arrange: 89 + 99 = 188 (stored as 9->8 and 9->9)
            ListNode l1 = CreateList(9, 8);
            ListNode l2 = CreateList(9, 9);

            // Act
            ListNode result = solution.AddTwoNumbers(l1, l2);

            // Assert: 8->8->1
            AssertListEquals(new[] { 8, 8, 1 }, result, solutionName);
        }

        #endregion

        #region Carry Propagation

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void AddTwoNumbers_CarryPropagatesMultipleDigits_ReturnsCorrectSum(IAddTwoNumbers_2 solution, string solutionName)
        {
            // Arrange: 999 + 1 = 1000 (stored as 9->9->9 and 1)
            ListNode l1 = CreateList(9, 9, 9);
            ListNode l2 = CreateList(1);

            // Act
            ListNode result = solution.AddTwoNumbers(l1, l2);

            // Assert: 0->0->0->1
            AssertListEquals(new[] { 0, 0, 0, 1 }, result, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void AddTwoNumbers_CarryAtEnd_ReturnsExtraDigit(IAddTwoNumbers_2 solution, string solutionName)
        {
            // Arrange: 99 + 1 = 100 (stored as 9->9 and 1)
            ListNode l1 = CreateList(9, 9);
            ListNode l2 = CreateList(1);

            // Act
            ListNode result = solution.AddTwoNumbers(l1, l2);

            // Assert: 0->0->1
            AssertListEquals(new[] { 0, 0, 1 }, result, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void AddTwoNumbers_BothAllNines_ReturnsCorrectSum(IAddTwoNumbers_2 solution, string solutionName)
        {
            // Arrange: 99 + 99 = 198 (stored as 9->9 and 9->9)
            ListNode l1 = CreateList(9, 9);
            ListNode l2 = CreateList(9, 9);

            // Act
            ListNode result = solution.AddTwoNumbers(l1, l2);

            // Assert: 8->9->1
            AssertListEquals(new[] { 8, 9, 1 }, result, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void AddTwoNumbers_CarryInMiddle_ReturnsCorrectSum(IAddTwoNumbers_2 solution, string solutionName)
        {
            // Arrange: 195 + 6 = 201 (stored as 5->9->1 and 6)
            ListNode l1 = CreateList(5, 9, 1);
            ListNode l2 = CreateList(6);

            // Act
            ListNode result = solution.AddTwoNumbers(l1, l2);

            // Assert: 1->0->2
            AssertListEquals(new[] { 1, 0, 2 }, result, solutionName);
        }

        #endregion

        #region Different Lengths

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void AddTwoNumbers_FirstLongerThanSecond_ReturnsCorrectSum(IAddTwoNumbers_2 solution, string solutionName)
        {
            // Arrange: 12345 + 67 = 12412 (stored reversed)
            ListNode l1 = CreateList(5, 4, 3, 2, 1);
            ListNode l2 = CreateList(7, 6);

            // Act
            ListNode result = solution.AddTwoNumbers(l1, l2);

            // Assert: 2->1->4->2->1
            AssertListEquals(new[] { 2, 1, 4, 2, 1 }, result, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void AddTwoNumbers_SecondLongerThanFirst_ReturnsCorrectSum(IAddTwoNumbers_2 solution, string solutionName)
        {
            // Arrange: 67 + 12345 = 12412 (stored reversed)
            ListNode l1 = CreateList(7, 6);
            ListNode l2 = CreateList(5, 4, 3, 2, 1);

            // Act
            ListNode result = solution.AddTwoNumbers(l1, l2);

            // Assert: 2->1->4->2->1
            AssertListEquals(new[] { 2, 1, 4, 2, 1 }, result, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void AddTwoNumbers_OneSingleDigitOtherMultiple_ReturnsCorrectSum(IAddTwoNumbers_2 solution, string solutionName)
        {
            // Arrange: 5 + 123 = 128 (stored as 5 and 3->2->1)
            ListNode l1 = CreateList(5);
            ListNode l2 = CreateList(3, 2, 1);

            // Act
            ListNode result = solution.AddTwoNumbers(l1, l2);

            // Assert: 8->2->1
            AssertListEquals(new[] { 8, 2, 1 }, result, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void AddTwoNumbers_VeryDifferentLengths_ReturnsCorrectSum(IAddTwoNumbers_2 solution, string solutionName)
        {
            // Arrange: 9 + 9999999 = 10000008 (stored reversed)
            ListNode l1 = CreateList(9);
            ListNode l2 = CreateList(9, 9, 9, 9, 9, 9, 9);

            // Act
            ListNode result = solution.AddTwoNumbers(l1, l2);

            // Assert: 8->0->0->0->0->0->0->1
            AssertListEquals(new[] { 8, 0, 0, 0, 0, 0, 0, 1 }, result, solutionName);
        }

        #endregion

        #region Zero Cases

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void AddTwoNumbers_ZeroPlusNumber_ReturnsNumber(IAddTwoNumbers_2 solution, string solutionName)
        {
            // Arrange: 0 + 123 = 123
            ListNode l1 = CreateList(0);
            ListNode l2 = CreateList(3, 2, 1);

            // Act
            ListNode result = solution.AddTwoNumbers(l1, l2);

            // Assert: 3->2->1
            AssertListEquals(new[] { 3, 2, 1 }, result, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void AddTwoNumbers_NumberPlusZero_ReturnsNumber(IAddTwoNumbers_2 solution, string solutionName)
        {
            // Arrange: 456 + 0 = 456
            ListNode l1 = CreateList(6, 5, 4);
            ListNode l2 = CreateList(0);

            // Act
            ListNode result = solution.AddTwoNumbers(l1, l2);

            // Assert: 6->5->4
            AssertListEquals(new[] { 6, 5, 4 }, result, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void AddTwoNumbers_WithZerosInMiddle_ReturnsCorrectSum(IAddTwoNumbers_2 solution, string solutionName)
        {
            // Arrange: 102 + 203 = 305 (stored as 2->0->1 and 3->0->2)
            ListNode l1 = CreateList(2, 0, 1);
            ListNode l2 = CreateList(3, 0, 2);

            // Act
            ListNode result = solution.AddTwoNumbers(l1, l2);

            // Assert: 5->0->3
            AssertListEquals(new[] { 5, 0, 3 }, result, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void AddTwoNumbers_ResultHasZerosInMiddle_ReturnsCorrectSum(IAddTwoNumbers_2 solution, string solutionName)
        {
            // Arrange: 101 + 909 = 1010 (stored as 1->0->1 and 9->0->9)
            ListNode l1 = CreateList(1, 0, 1);
            ListNode l2 = CreateList(9, 0, 9);

            // Act
            ListNode result = solution.AddTwoNumbers(l1, l2);

            // Assert: 0->1->0->1
            AssertListEquals(new[] { 0, 1, 0, 1 }, result, solutionName);
        }

        #endregion

        #region Edge Cases

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void AddTwoNumbers_BothSingleDigitMax_ReturnsCorrectSum(IAddTwoNumbers_2 solution, string solutionName)
        {
            // Arrange: 9 + 9 = 18
            ListNode l1 = CreateList(9);
            ListNode l2 = CreateList(9);

            // Act
            ListNode result = solution.AddTwoNumbers(l1, l2);

            // Assert: 8->1
            AssertListEquals(new[] { 8, 1 }, result, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void AddTwoNumbers_AllDigitsMax_ReturnsCorrectSum(IAddTwoNumbers_2 solution, string solutionName)
        {
            // Arrange: 9999 + 9999 = 19998
            ListNode l1 = CreateList(9, 9, 9, 9);
            ListNode l2 = CreateList(9, 9, 9, 9);

            // Act
            ListNode result = solution.AddTwoNumbers(l1, l2);

            // Assert: 8->9->9->9->1
            AssertListEquals(new[] { 8, 9, 9, 9, 1 }, result, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void AddTwoNumbers_AlternatingDigits_ReturnsCorrectSum(IAddTwoNumbers_2 solution, string solutionName)
        {
            // Arrange: 135 + 246 = 381 (stored as 5->3->1 and 6->4->2)
            ListNode l1 = CreateList(5, 3, 1);
            ListNode l2 = CreateList(6, 4, 2);

            // Act
            ListNode result = solution.AddTwoNumbers(l1, l2);

            // Assert: 1->8->3
            AssertListEquals(new[] { 1, 8, 3 }, result, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void AddTwoNumbers_SameNumber_ReturnsDouble(IAddTwoNumbers_2 solution, string solutionName)
        {
            // Arrange: 555 + 555 = 1110 (stored as 5->5->5 and 5->5->5)
            ListNode l1 = CreateList(5, 5, 5);
            ListNode l2 = CreateList(5, 5, 5);

            // Act
            ListNode result = solution.AddTwoNumbers(l1, l2);

            // Assert: 0->1->1->1
            AssertListEquals(new[] { 0, 1, 1, 1 }, result, solutionName);
        }

        #endregion

        #region Large Numbers

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void AddTwoNumbers_LargeNumbers_ReturnsCorrectSum(IAddTwoNumbers_2 solution, string solutionName)
        {
            // Arrange: 123456789 + 987654321 = 1111111110 (stored reversed)
            ListNode l1 = CreateList(9, 8, 7, 6, 5, 4, 3, 2, 1);
            ListNode l2 = CreateList(1, 2, 3, 4, 5, 6, 7, 8, 9);

            // Act
            ListNode result = solution.AddTwoNumbers(l1, l2);

            // Assert: 0->1->1->1->1->1->1->1->1->1
            AssertListEquals(new[] { 0, 1, 1, 1, 1, 1, 1, 1, 1, 1 }, result, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void AddTwoNumbers_VeryLargeNumbers_ReturnsCorrectSum(IAddTwoNumbers_2 solution, string solutionName)
        {
            // Arrange: 99999999 + 1 = 100000000 (stored reversed)
            ListNode l1 = CreateList(9, 9, 9, 9, 9, 9, 9, 9);
            ListNode l2 = CreateList(1);

            // Act
            ListNode result = solution.AddTwoNumbers(l1, l2);

            // Assert: 0->0->0->0->0->0->0->0->1
            AssertListEquals(new[] { 0, 0, 0, 0, 0, 0, 0, 0, 1 }, result, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void AddTwoNumbers_ManyDigitsNoCarry_ReturnsCorrectSum(IAddTwoNumbers_2 solution, string solutionName)
        {
            // Arrange: 11111111 + 22222222 = 33333333 (stored reversed)
            ListNode l1 = CreateList(1, 1, 1, 1, 1, 1, 1, 1);
            ListNode l2 = CreateList(2, 2, 2, 2, 2, 2, 2, 2);

            // Act
            ListNode result = solution.AddTwoNumbers(l1, l2);

            // Assert: 3->3->3->3->3->3->3->3
            AssertListEquals(new[] { 3, 3, 3, 3, 3, 3, 3, 3 }, result, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void AddTwoNumbers_ManyDigitsWithCarries_ReturnsCorrectSum(IAddTwoNumbers_2 solution, string solutionName)
        {
            // Arrange: 88888888 + 11111111 = 99999999 (stored reversed)
            ListNode l1 = CreateList(8, 8, 8, 8, 8, 8, 8, 8);
            ListNode l2 = CreateList(1, 1, 1, 1, 1, 1, 1, 1);

            // Act
            ListNode result = solution.AddTwoNumbers(l1, l2);

            // Assert: 9->9->9->9->9->9->9->9
            AssertListEquals(new[] { 9, 9, 9, 9, 9, 9, 9, 9 }, result, solutionName);
        }

        #endregion

        #region Specific Patterns

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void AddTwoNumbers_PowerOfTen_ReturnsCorrectSum(IAddTwoNumbers_2 solution, string solutionName)
        {
            // Arrange: 1000 + 1 = 1001 (stored as 0->0->0->1 and 1)
            ListNode l1 = CreateList(0, 0, 0, 1);
            ListNode l2 = CreateList(1);

            // Act
            ListNode result = solution.AddTwoNumbers(l1, l2);

            // Assert: 1->0->0->1
            AssertListEquals(new[] { 1, 0, 0, 1 }, result, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void AddTwoNumbers_ConsecutiveNumbers_ReturnsCorrectSum(IAddTwoNumbers_2 solution, string solutionName)
        {
            // Arrange: 12345 + 12346 = 24691 (stored reversed)
            ListNode l1 = CreateList(5, 4, 3, 2, 1);
            ListNode l2 = CreateList(6, 4, 3, 2, 1);

            // Act
            ListNode result = solution.AddTwoNumbers(l1, l2);

            // Assert: 1->9->6->4->2
            AssertListEquals(new[] { 1, 9, 6, 4, 2 }, result, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void AddTwoNumbers_Palindrome_ReturnsCorrectSum(IAddTwoNumbers_2 solution, string solutionName)
        {
            // Arrange: 121 + 121 = 242 (stored as 1->2->1 and 1->2->1)
            ListNode l1 = CreateList(1, 2, 1);
            ListNode l2 = CreateList(1, 2, 1);

            // Act
            ListNode result = solution.AddTwoNumbers(l1, l2);

            // Assert: 2->4->2
            AssertListEquals(new[] { 2, 4, 2 }, result, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void AddTwoNumbers_OneWithTrailingZeros_ReturnsCorrectSum(IAddTwoNumbers_2 solution, string solutionName)
        {
            // Arrange: 100 + 25 = 125 (stored as 0->0->1 and 5->2)
            ListNode l1 = CreateList(0, 0, 1);
            ListNode l2 = CreateList(5, 2);

            // Act
            ListNode result = solution.AddTwoNumbers(l1, l2);

            // Assert: 5->2->1
            AssertListEquals(new[] { 5, 2, 1 }, result, solutionName);
        }

        #endregion
    }
}