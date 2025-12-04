using LeetCodeProblems.CSharp.LinkedList;
using LeetCodeProblems.Interfaces.Medium;

namespace GrindingLeetCode.UnitTests.Medium
{
    [TestClass]
    public class DesignLinkedList_707_Tests
    {
        public static IEnumerable<object[]> GetImplementations()
        {
            yield return new object[] { () => new DesignLinkedListCSharp_707(), "C#" };
        }

        #region Helper Methods

        /// <summary>
        /// Creates a fresh instance and populates it with values
        /// </summary>
        private IDesignLinkedList_707 CreateListWithValues(Func<IDesignLinkedList_707> factory, params int[] values)
        {
            var list = factory();
            foreach (var val in values)
            {
                list.AddAtTail(val);
            }
            return list;
        }

        /// <summary>
        /// Verifies the list contains expected values in order
        /// </summary>
        private void AssertListEquals(IDesignLinkedList_707 list, int[] expected, string solutionName)
        {
            for (int i = 0; i < expected.Length; i++)
            {
                int actual = list.Get(i);
                Assert.AreEqual(expected[i], actual, 
                    $"Expected {expected[i]} at index {i} but got {actual} for {solutionName}");
            }
            
            // Verify no extra elements
            Assert.AreEqual(-1, list.Get(expected.Length), 
                $"Expected -1 at index {expected.Length} (out of bounds) for {solutionName}");
        }

        #endregion

        #region LeetCode Example

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void DesignLinkedList_LeetCodeExample_WorksCorrectly(Func<IDesignLinkedList_707> factory, string solutionName)
        {
            // Arrange
            var myLinkedList = factory();

            // Act & Assert: ["MyLinkedList", "addAtHead", "addAtTail", "addAtIndex", "get", "deleteAtIndex", "get"]
            // [[], [1], [3], [1, 2], [1], [1], [1]]
            
            myLinkedList.AddAtHead(1);        // list: [1]
            myLinkedList.AddAtTail(3);        // list: [1, 3]
            myLinkedList.AddAtIndex(1, 2);    // list: [1, 2, 3]
            
            Assert.AreEqual(2, myLinkedList.Get(1), $"Failed at Get(1) for {solutionName}");
            
            myLinkedList.DeleteAtIndex(1);    // list: [1, 3]
            
            Assert.AreEqual(3, myLinkedList.Get(1), $"Failed at Get(1) after delete for {solutionName}");
        }

        #endregion

        #region Get Method Tests

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Get_EmptyList_ReturnsMinusOne(Func<IDesignLinkedList_707> factory, string solutionName)
        {
            // Arrange
            var list = factory();

            // Act & Assert
            Assert.AreEqual(-1, list.Get(0), $"Failed for {solutionName}");
            Assert.AreEqual(-1, list.Get(5), $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Get_NegativeIndex_ReturnsMinusOne(Func<IDesignLinkedList_707> factory, string solutionName)
        {
            // Arrange
            var list = CreateListWithValues(factory, 1, 2, 3);

            // Act & Assert
            Assert.AreEqual(-1, list.Get(-1), $"Failed for {solutionName}");
            Assert.AreEqual(-1, list.Get(-5), $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Get_IndexOutOfBounds_ReturnsMinusOne(Func<IDesignLinkedList_707> factory, string solutionName)
        {
            // Arrange
            var list = CreateListWithValues(factory, 1, 2, 3);

            // Act & Assert
            Assert.AreEqual(-1, list.Get(3), $"Failed for {solutionName}");
            Assert.AreEqual(-1, list.Get(10), $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Get_ValidIndices_ReturnsCorrectValues(Func<IDesignLinkedList_707> factory, string solutionName)
        {
            // Arrange
            var list = CreateListWithValues(factory, 10, 20, 30, 40, 50);

            // Act & Assert
            Assert.AreEqual(10, list.Get(0), $"Failed for {solutionName}");
            Assert.AreEqual(20, list.Get(1), $"Failed for {solutionName}");
            Assert.AreEqual(30, list.Get(2), $"Failed for {solutionName}");
            Assert.AreEqual(40, list.Get(3), $"Failed for {solutionName}");
            Assert.AreEqual(50, list.Get(4), $"Failed for {solutionName}");
        }

        #endregion

        #region AddAtHead Tests

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void AddAtHead_EmptyList_AddsElement(Func<IDesignLinkedList_707> factory, string solutionName)
        {
            // Arrange
            var list = factory();

            // Act
            list.AddAtHead(5);

            // Assert
            AssertListEquals(list, new[] { 5 }, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void AddAtHead_MultipleElements_AddsInReverseOrder(Func<IDesignLinkedList_707> factory, string solutionName)
        {
            // Arrange
            var list = factory();

            // Act
            list.AddAtHead(3);  // [3]
            list.AddAtHead(2);  // [2, 3]
            list.AddAtHead(1);  // [1, 2, 3]

            // Assert
            AssertListEquals(list, new[] { 1, 2, 3 }, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void AddAtHead_ToExistingList_PrependsCorrectly(Func<IDesignLinkedList_707> factory, string solutionName)
        {
            // Arrange
            var list = CreateListWithValues(factory, 2, 3, 4);

            // Act
            list.AddAtHead(1);

            // Assert
            AssertListEquals(list, new[] { 1, 2, 3, 4 }, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void AddAtHead_NegativeValue_AddsCorrectly(Func<IDesignLinkedList_707> factory, string solutionName)
        {
            // Arrange
            var list = CreateListWithValues(factory, 1, 2);

            // Act
            list.AddAtHead(-5);

            // Assert
            AssertListEquals(list, new[] { -5, 1, 2 }, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void AddAtHead_Zero_AddsCorrectly(Func<IDesignLinkedList_707> factory, string solutionName)
        {
            // Arrange
            var list = CreateListWithValues(factory, 1, 2);

            // Act
            list.AddAtHead(0);

            // Assert
            AssertListEquals(list, new[] { 0, 1, 2 }, solutionName);
        }

        #endregion

        #region AddAtTail Tests

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void AddAtTail_EmptyList_AddsElement(Func<IDesignLinkedList_707> factory, string solutionName)
        {
            // Arrange
            var list = factory();

            // Act
            list.AddAtTail(5);

            // Assert
            AssertListEquals(list, new[] { 5 }, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void AddAtTail_MultipleElements_AddsInOrder(Func<IDesignLinkedList_707> factory, string solutionName)
        {
            // Arrange
            var list = factory();

            // Act
            list.AddAtTail(1);  // [1]
            list.AddAtTail(2);  // [1, 2]
            list.AddAtTail(3);  // [1, 2, 3]

            // Assert
            AssertListEquals(list, new[] { 1, 2, 3 }, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void AddAtTail_ToExistingList_AppendsCorrectly(Func<IDesignLinkedList_707> factory, string solutionName)
        {
            // Arrange
            var list = CreateListWithValues(factory, 1, 2, 3);

            // Act
            list.AddAtTail(4);

            // Assert
            AssertListEquals(list, new[] { 1, 2, 3, 4 }, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void AddAtTail_NegativeValue_AddsCorrectly(Func<IDesignLinkedList_707> factory, string solutionName)
        {
            // Arrange
            var list = CreateListWithValues(factory, 1, 2);

            // Act
            list.AddAtTail(-5);

            // Assert
            AssertListEquals(list, new[] { 1, 2, -5 }, solutionName);
        }

        #endregion

        #region AddAtIndex Tests

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void AddAtIndex_AtZero_PrependsToEmptyList(Func<IDesignLinkedList_707> factory, string solutionName)
        {
            // Arrange
            var list = factory();

            // Act
            list.AddAtIndex(0, 5);

            // Assert
            AssertListEquals(list, new[] { 5 }, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void AddAtIndex_AtZero_PrependsToList(Func<IDesignLinkedList_707> factory, string solutionName)
        {
            // Arrange
            var list = CreateListWithValues(factory, 2, 3, 4);

            // Act
            list.AddAtIndex(0, 1);

            // Assert
            AssertListEquals(list, new[] { 1, 2, 3, 4 }, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void AddAtIndex_InMiddle_InsertsCorrectly(Func<IDesignLinkedList_707> factory, string solutionName)
        {
            // Arrange
            var list = CreateListWithValues(factory, 1, 3, 4);

            // Act
            list.AddAtIndex(1, 2);

            // Assert
            AssertListEquals(list, new[] { 1, 2, 3, 4 }, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void AddAtIndex_AtEnd_AppendsToList(Func<IDesignLinkedList_707> factory, string solutionName)
        {
            // Arrange
            var list = CreateListWithValues(factory, 1, 2, 3);

            // Act - Adding at index equal to length appends
            list.AddAtIndex(3, 4);

            // Assert
            AssertListEquals(list, new[] { 1, 2, 3, 4 }, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void AddAtIndex_BeyondEnd_DoesNotInsert(Func<IDesignLinkedList_707> factory, string solutionName)
        {
            // Arrange
            var list = CreateListWithValues(factory, 1, 2, 3);

            // Act - Adding beyond length should not insert
            list.AddAtIndex(10, 99);

            // Assert - List should remain unchanged
            AssertListEquals(list, new[] { 1, 2, 3 }, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void AddAtIndex_NegativeIndex_DoesNotInsert(Func<IDesignLinkedList_707> factory, string solutionName)
        {
            // Arrange
            var list = CreateListWithValues(factory, 1, 2, 3);

            // Act
            list.AddAtIndex(-1, 99);

            // Assert - List should remain unchanged
            AssertListEquals(list, new[] { 1, 2, 3 }, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void AddAtIndex_MultipleInsertions_WorksCorrectly(Func<IDesignLinkedList_707> factory, string solutionName)
        {
            // Arrange
            var list = CreateListWithValues(factory, 1, 5);

            // Act
            list.AddAtIndex(1, 2);  // [1, 2, 5]
            list.AddAtIndex(2, 3);  // [1, 2, 3, 5]
            list.AddAtIndex(3, 4);  // [1, 2, 3, 4, 5]

            // Assert
            AssertListEquals(list, new[] { 1, 2, 3, 4, 5 }, solutionName);
        }

        #endregion

        #region DeleteAtIndex Tests

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void DeleteAtIndex_EmptyList_DoesNothing(Func<IDesignLinkedList_707> factory, string solutionName)
        {
            // Arrange
            var list = factory();

            // Act
            list.DeleteAtIndex(0);

            // Assert
            Assert.AreEqual(-1, list.Get(0), $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void DeleteAtIndex_SingleElement_RemovesElement(Func<IDesignLinkedList_707> factory, string solutionName)
        {
            // Arrange
            var list = CreateListWithValues(factory, 1);

            // Act
            list.DeleteAtIndex(0);

            // Assert
            Assert.AreEqual(-1, list.Get(0), $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void DeleteAtIndex_AtHead_RemovesFirstElement(Func<IDesignLinkedList_707> factory, string solutionName)
        {
            // Arrange
            var list = CreateListWithValues(factory, 1, 2, 3, 4);

            // Act
            list.DeleteAtIndex(0);

            // Assert
            AssertListEquals(list, new[] { 2, 3, 4 }, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void DeleteAtIndex_AtTail_RemovesLastElement(Func<IDesignLinkedList_707> factory, string solutionName)
        {
            // Arrange
            var list = CreateListWithValues(factory, 1, 2, 3, 4);

            // Act
            list.DeleteAtIndex(3);

            // Assert
            AssertListEquals(list, new[] { 1, 2, 3 }, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void DeleteAtIndex_InMiddle_RemovesCorrectElement(Func<IDesignLinkedList_707> factory, string solutionName)
        {
            // Arrange
            var list = CreateListWithValues(factory, 1, 2, 3, 4, 5);

            // Act
            list.DeleteAtIndex(2);

            // Assert
            AssertListEquals(list, new[] { 1, 2, 4, 5 }, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void DeleteAtIndex_NegativeIndex_DoesNothing(Func<IDesignLinkedList_707> factory, string solutionName)
        {
            // Arrange
            var list = CreateListWithValues(factory, 1, 2, 3);

            // Act
            list.DeleteAtIndex(-1);

            // Assert
            AssertListEquals(list, new[] { 1, 2, 3 }, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void DeleteAtIndex_OutOfBounds_DoesNothing(Func<IDesignLinkedList_707> factory, string solutionName)
        {
            // Arrange
            var list = CreateListWithValues(factory, 1, 2, 3);

            // Act
            list.DeleteAtIndex(10);

            // Assert
            AssertListEquals(list, new[] { 1, 2, 3 }, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void DeleteAtIndex_MultipleDeletions_WorksCorrectly(Func<IDesignLinkedList_707> factory, string solutionName)
        {
            // Arrange
            var list = CreateListWithValues(factory, 1, 2, 3, 4, 5);

            // Act
            list.DeleteAtIndex(2);  // [1, 2, 4, 5]
            list.DeleteAtIndex(0);  // [2, 4, 5]
            list.DeleteAtIndex(2);  // [2, 4]

            // Assert
            AssertListEquals(list, new[] { 2, 4 }, solutionName);
        }

        #endregion

        #region Critical Edge Case Tests - Bug Scenarios

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void DeleteAtIndex_Bug1_NonZeroIndex_ShouldDecrementCount(Func<IDesignLinkedList_707> factory, string solutionName)
        {
            // This test exposes Bug #1: DeleteAtIndex doesn't decrement _count for non-zero indices
            // Arrange
            var list = CreateListWithValues(factory, 1, 2, 3, 4, 5);

            // Act - Delete at middle (non-zero index)
            list.DeleteAtIndex(2);  // Should remove 3, list becomes [1, 2, 4, 5]

            // Assert - Try to add at the end (which should now be index 4, not 5)
            list.AddAtIndex(4, 99);  // Should append if count is correct
            AssertListEquals(list, new[] { 1, 2, 4, 5, 99 }, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void DeleteAtIndex_Bug2_DeleteTail_ShouldUpdateTailPointer(Func<IDesignLinkedList_707> factory, string solutionName)
        {
            // This test exposes Bug #2: DeleteAtIndex doesn't update _tail when deleting last node
            // Arrange
            var list = CreateListWithValues(factory, 1, 2, 3);

            // Act - Delete the tail
            list.DeleteAtIndex(2);  // Remove 3, _tail should now point to node(2)

            // Try to add at tail - if _tail wasn't updated, this will fail
            list.AddAtTail(4);

            // Assert
            AssertListEquals(list, new[] { 1, 2, 4 }, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void DeleteAtIndex_Bug3_DeleteAllNodes_ShouldSetTailToNull(Func<IDesignLinkedList_707> factory, string solutionName)
        {
            // This test exposes Bug #2 variant: When list becomes empty, _tail should be null
            // Arrange
            var list = CreateListWithValues(factory, 1);

            // Act - Delete the only element
            list.DeleteAtIndex(0);  // List becomes empty, both _head and _tail should be null

            // Try to add a new element - if _tail is dangling, this could fail
            list.AddAtTail(99);

            // Assert
            AssertListEquals(list, new[] { 99 }, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void DeleteAtIndex_Bug4_AtCountIndex_ShouldNotDelete(Func<IDesignLinkedList_707> factory, string solutionName)
        {
            // This test exposes Bug #3: Boundary check allows deleting at index == _count
            // Arrange
            var list = CreateListWithValues(factory, 1, 2, 3);  // Count = 3

            // Act - Try to delete at index 3 (which is out of bounds)
            list.DeleteAtIndex(3);  // Should do nothing (index 3 doesn't exist)

            // Assert - List should be unchanged
            AssertListEquals(list, new[] { 1, 2, 3 }, solutionName);
        }

        #endregion

        #region Mixed Operations Tests

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void MixedOperations_AddAndDelete_WorksCorrectly(Func<IDesignLinkedList_707> factory, string solutionName)
        {
            // Arrange
            var list = factory();

            // Act
            list.AddAtHead(1);
            list.AddAtTail(3);
            list.AddAtIndex(1, 2);
            AssertListEquals(list, new[] { 1, 2, 3 }, solutionName);

            list.DeleteAtIndex(1);
            AssertListEquals(list, new[] { 1, 3 }, solutionName);

            list.AddAtHead(0);
            AssertListEquals(list, new[] { 0, 1, 3 }, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void MixedOperations_BuildAndDestroyList_WorksCorrectly(Func<IDesignLinkedList_707> factory, string solutionName)
        {
            // Arrange
            var list = factory();

            // Build list: [1, 2, 3, 4, 5]
            for (int i = 1; i <= 5; i++)
            {
                list.AddAtTail(i);
            }
            AssertListEquals(list, new[] { 1, 2, 3, 4, 5 }, solutionName);

            // Destroy list from head
            for (int i = 0; i < 5; i++)
            {
                list.DeleteAtIndex(0);
            }

            // Assert empty
            Assert.AreEqual(-1, list.Get(0), $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void MixedOperations_AlternatingAddDelete_WorksCorrectly(Func<IDesignLinkedList_707> factory, string solutionName)
        {
            // Arrange
            var list = factory();

            // Act
            list.AddAtHead(1);      // [1]
            list.AddAtTail(2);      // [1, 2]
            list.DeleteAtIndex(0);  // [2]
            list.AddAtHead(3);      // [3, 2]
            list.AddAtIndex(1, 4);  // [3, 4, 2]

            // Assert
            AssertListEquals(list, new[] { 3, 4, 2 }, solutionName);
        }

        #endregion

        #region Edge Cases

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void EdgeCase_LargeList_WorksCorrectly(Func<IDesignLinkedList_707> factory, string solutionName)
        {
            // Arrange
            var list = factory();
            int size = 100;

            // Act - Build large list
            for (int i = 0; i < size; i++)
            {
                list.AddAtTail(i);
            }

            // Assert - Verify all elements
            for (int i = 0; i < size; i++)
            {
                Assert.AreEqual(i, list.Get(i), $"Failed at index {i} for {solutionName}");
            }
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void EdgeCase_DuplicateValues_WorksCorrectly(Func<IDesignLinkedList_707> factory, string solutionName)
        {
            // Arrange
            var list = factory();

            // Act - Add duplicate values
            list.AddAtTail(5);
            list.AddAtTail(5);
            list.AddAtTail(5);

            // Assert
            AssertListEquals(list, new[] { 5, 5, 5 }, solutionName);

            // Delete one
            list.DeleteAtIndex(1);
            AssertListEquals(list, new[] { 5, 5 }, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void EdgeCase_AllNegativeValues_WorksCorrectly(Func<IDesignLinkedList_707> factory, string solutionName)
        {
            // Arrange
            var list = factory();

            // Act
            list.AddAtTail(-1);
            list.AddAtTail(-2);
            list.AddAtTail(-3);

            // Assert
            AssertListEquals(list, new[] { -1, -2, -3 }, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void EdgeCase_ZeroValues_WorksCorrectly(Func<IDesignLinkedList_707> factory, string solutionName)
        {
            // Arrange
            var list = factory();

            // Act
            list.AddAtHead(0);
            list.AddAtTail(0);
            list.AddAtIndex(1, 0);

            // Assert
            AssertListEquals(list, new[] { 0, 0, 0 }, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void EdgeCase_AddDeleteSameIndex_WorksCorrectly(Func<IDesignLinkedList_707> factory, string solutionName)
        {
            // Arrange
            var list = CreateListWithValues(factory, 1, 2, 3);

            // Act - Add then immediately delete at same position
            list.AddAtIndex(1, 99);   // [1, 99, 2, 3]
            list.DeleteAtIndex(1);    // [1, 2, 3]

            // Assert
            AssertListEquals(list, new[] { 1, 2, 3 }, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void EdgeCase_RapidHeadOperations_WorksCorrectly(Func<IDesignLinkedList_707> factory, string solutionName)
        {
            // Arrange
            var list = factory();

            // Act - Rapid head operations
            for (int i = 0; i < 10; i++)
            {
                list.AddAtHead(i);
            }

            // Assert - Elements should be in reverse order: [9,8,7,6,5,4,3,2,1,0]
            for (int i = 0; i < 10; i++)
            {
                Assert.AreEqual(9 - i, list.Get(i), $"Failed at index {i} for {solutionName}");
            }
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void EdgeCase_AlternatingEnds_WorksCorrectly(Func<IDesignLinkedList_707> factory, string solutionName)
        {
            // Arrange
            var list = factory();

            // Act - Alternate adding at head and tail
            list.AddAtHead(2);  // [2]
            list.AddAtTail(3);  // [2, 3]
            list.AddAtHead(1);  // [1, 2, 3]
            list.AddAtTail(4);  // [1, 2, 3, 4]

            // Assert
            AssertListEquals(list, new[] { 1, 2, 3, 4 }, solutionName);
        }

        #endregion
    }
}