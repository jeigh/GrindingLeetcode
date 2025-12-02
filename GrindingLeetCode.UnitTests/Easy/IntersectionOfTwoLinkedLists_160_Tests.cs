using LeetCodeProblems.CSharp.LinkedList;
using LeetCodeProblems.Interfaces.Easy;
using LeetCodeProblems.Shared;

namespace GrindingLeetCode.UnitTests.Easy
{
    [TestClass]
    public class IntersectionOfTwoLinkedLists_160_Tests
    {
        public static IEnumerable<object[]> GetImplementations()
        {
            yield return new object[] { new IntersectionOfTwoLinkedListsUsingHashmapCSharp_160(), "C#" };
            yield return new object[] { new IntersectionOfTwoLinkedListsCountFirstCSharp_160(), "CountFirst C#" };
            yield return new object[] { new IntersectionOfTwoLinkedListOptimizedCSharp_160(), "Optimized C#" };
        }

        #region Helper Methods

        /// <summary>
        /// Creates a simple linked list from an array of values
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
        /// Creates two intersecting lists where they share nodes starting at the intersection point
        /// </summary>
        /// <param name="listAValues">Values before intersection for list A</param>
        /// <param name="listBValues">Values before intersection for list B</param>
        /// <param name="intersectionValues">Values at and after intersection (shared nodes)</param>
        /// <returns>Tuple of (headA, headB, intersectionNode)</returns>
        private (ListNode headA, ListNode headB, ListNode intersection) CreateIntersectingLists(
            int[] listAValues, 
            int[] listBValues, 
            int[] intersectionValues)
        {
            // Create the intersection part first (shared nodes)
            ListNode intersection = null;
            if (intersectionValues != null && intersectionValues.Length > 0)
            {
                intersection = CreateList(intersectionValues);
            }

            // Create list A
            ListNode headA = null;
            if (listAValues != null && listAValues.Length > 0)
            {
                headA = CreateList(listAValues);
                ListNode current = headA;
                while (current.next != null)
                {
                    current = current.next;
                }
                current.next = intersection;
            }
            else
            {
                headA = intersection;
            }

            // Create list B
            ListNode headB = null;
            if (listBValues != null && listBValues.Length > 0)
            {
                headB = CreateList(listBValues);
                ListNode current = headB;
                while (current.next != null)
                {
                    current = current.next;
                }
                current.next = intersection;
            }
            else
            {
                headB = intersection;
            }

            return (headA, headB, intersection);
        }

        /// <summary>
        /// Verifies that the result node is the same object reference as expected
        /// </summary>
        private void AssertSameNode(ListNode expected, ListNode actual, string solutionName)
        {
            if (expected == null && actual == null)
            {
                return; // Both null is correct
            }

            Assert.IsNotNull(actual, $"Expected intersection node but got null for {solutionName}");
            Assert.AreSame(expected, actual, $"Expected same node reference for {solutionName}");
        }

        #endregion

        #region LeetCode Examples

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void GetIntersectionNode_Example1_ReturnsIntersectionNode(IIntersectionOfTwoLinkedLists_160 solution, string solutionName)
        {
            // Arrange: listA = [4,1,8,4,5], listB = [5,6,1,8,4,5]
            // Intersection at node with value 8
            var (headA, headB, intersection) = CreateIntersectingLists(
                new[] { 4, 1 },      // A's unique part
                new[] { 5, 6, 1 },   // B's unique part
                new[] { 8, 4, 5 }    // Shared part
            );

            // Act
            ListNode result = solution.GetIntersectionNode(headA, headB);

            // Assert
            AssertSameNode(intersection, result, solutionName);
            Assert.AreEqual(8, result.val, $"Intersection node should have value 8 for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void GetIntersectionNode_Example2_ReturnsIntersectionNode(IIntersectionOfTwoLinkedLists_160 solution, string solutionName)
        {
            // Arrange: listA = [1,9,1,2,4], listB = [3,2,4]
            // Intersection at node with value 2
            var (headA, headB, intersection) = CreateIntersectingLists(
                new[] { 1, 9, 1 },   // A's unique part
                new[] { 3 },         // B's unique part
                new[] { 2, 4 }       // Shared part
            );

            // Act
            ListNode result = solution.GetIntersectionNode(headA, headB);

            // Assert
            AssertSameNode(intersection, result, solutionName);
            Assert.AreEqual(2, result.val, $"Intersection node should have value 2 for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void GetIntersectionNode_Example3_NoIntersection_ReturnsNull(IIntersectionOfTwoLinkedLists_160 solution, string solutionName)
        {
            // Arrange: listA = [2,6,4], listB = [1,5] - no intersection
            ListNode headA = CreateList(2, 6, 4);
            ListNode headB = CreateList(1, 5);

            // Act
            ListNode result = solution.GetIntersectionNode(headA, headB);

            // Assert
            Assert.IsNull(result, $"Should return null when no intersection for {solutionName}");
        }

        #endregion

        #region No Intersection Cases

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void GetIntersectionNode_BothNull_ReturnsNull(IIntersectionOfTwoLinkedLists_160 solution, string solutionName)
        {
            // Arrange
            ListNode headA = null;
            ListNode headB = null;

            // Act
            ListNode result = solution.GetIntersectionNode(headA, headB);

            // Assert
            Assert.IsNull(result, $"Should return null when both lists are null for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void GetIntersectionNode_FirstNull_ReturnsNull(IIntersectionOfTwoLinkedLists_160 solution, string solutionName)
        {
            // Arrange
            ListNode headA = null;
            ListNode headB = CreateList(1, 2, 3);

            // Act
            ListNode result = solution.GetIntersectionNode(headA, headB);

            // Assert
            Assert.IsNull(result, $"Should return null when first list is null for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void GetIntersectionNode_SecondNull_ReturnsNull(IIntersectionOfTwoLinkedLists_160 solution, string solutionName)
        {
            // Arrange
            ListNode headA = CreateList(1, 2, 3);
            ListNode headB = null;

            // Act
            ListNode result = solution.GetIntersectionNode(headA, headB);

            // Assert
            Assert.IsNull(result, $"Should return null when second list is null for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void GetIntersectionNode_DifferentLengthsNoIntersection_ReturnsNull(IIntersectionOfTwoLinkedLists_160 solution, string solutionName)
        {
            // Arrange
            ListNode headA = CreateList(1, 2, 3, 4, 5);
            ListNode headB = CreateList(6, 7);

            // Act
            ListNode result = solution.GetIntersectionNode(headA, headB);

            // Assert
            Assert.IsNull(result, $"Should return null for different lengths with no intersection for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void GetIntersectionNode_SameLengthNoIntersection_ReturnsNull(IIntersectionOfTwoLinkedLists_160 solution, string solutionName)
        {
            // Arrange
            ListNode headA = CreateList(1, 2, 3);
            ListNode headB = CreateList(4, 5, 6);

            // Act
            ListNode result = solution.GetIntersectionNode(headA, headB);

            // Assert
            Assert.IsNull(result, $"Should return null for same length with no intersection for {solutionName}");
        }

        #endregion

        #region Intersection at Head

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void GetIntersectionNode_IntersectionAtHead_BothListsIdentical(IIntersectionOfTwoLinkedLists_160 solution, string solutionName)
        {
            // Arrange: Both lists are entirely the same
            var (headA, headB, intersection) = CreateIntersectingLists(
                Array.Empty<int>(),      // A has no unique part
                Array.Empty<int>(),      // B has no unique part
                new[] { 1, 2, 3 }        // Both start at intersection
            );

            // Act
            ListNode result = solution.GetIntersectionNode(headA, headB);

            // Assert
            AssertSameNode(intersection, result, solutionName);
            Assert.AreEqual(1, result.val, $"Should return first node for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void GetIntersectionNode_IntersectionAtHeadOfShorter(IIntersectionOfTwoLinkedLists_160 solution, string solutionName)
        {
            // Arrange: List B starts where A has unique nodes
            var (headA, headB, intersection) = CreateIntersectingLists(
                new[] { 1, 2, 3 },       // A has unique part
                Array.Empty<int>(),      // B has no unique part
                new[] { 4, 5 }           // Shared part
            );

            // Act
            ListNode result = solution.GetIntersectionNode(headA, headB);

            // Assert
            AssertSameNode(intersection, result, solutionName);
            Assert.AreEqual(4, result.val, $"Should find intersection at value 4 for {solutionName}");
        }

        #endregion

        #region Intersection at End

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void GetIntersectionNode_IntersectionAtLastNode(IIntersectionOfTwoLinkedLists_160 solution, string solutionName)
        {
            // Arrange: Only last node is shared
            var (headA, headB, intersection) = CreateIntersectingLists(
                new[] { 1, 2, 3 },
                new[] { 4, 5, 6 },
                new[] { 7 }              // Single shared node at end
            );

            // Act
            ListNode result = solution.GetIntersectionNode(headA, headB);

            // Assert
            AssertSameNode(intersection, result, solutionName);
            Assert.AreEqual(7, result.val, $"Should find intersection at last node for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void GetIntersectionNode_IntersectionAtSecondToLast(IIntersectionOfTwoLinkedLists_160 solution, string solutionName)
        {
            // Arrange: Last two nodes are shared
            var (headA, headB, intersection) = CreateIntersectingLists(
                new[] { 1, 2 },
                new[] { 3, 4, 5 },
                new[] { 6, 7 }           // Last two nodes shared
            );

            // Act
            ListNode result = solution.GetIntersectionNode(headA, headB);

            // Assert
            AssertSameNode(intersection, result, solutionName);
            Assert.AreEqual(6, result.val, $"Should find intersection at second to last for {solutionName}");
        }

        #endregion

        #region Different Length Lists

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void GetIntersectionNode_FirstMuchLonger_FindsIntersection(IIntersectionOfTwoLinkedLists_160 solution, string solutionName)
        {
            // Arrange: A is much longer than B before intersection
            var (headA, headB, intersection) = CreateIntersectingLists(
                new[] { 1, 2, 3, 4, 5, 6, 7 },
                new[] { 8 },
                new[] { 9, 10 }
            );

            // Act
            ListNode result = solution.GetIntersectionNode(headA, headB);

            // Assert
            AssertSameNode(intersection, result, solutionName);
            Assert.AreEqual(9, result.val, $"Should find intersection for much longer first list for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void GetIntersectionNode_SecondMuchLonger_FindsIntersection(IIntersectionOfTwoLinkedLists_160 solution, string solutionName)
        {
            // Arrange: B is much longer than A before intersection
            var (headA, headB, intersection) = CreateIntersectingLists(
                new[] { 1 },
                new[] { 2, 3, 4, 5, 6, 7, 8 },
                new[] { 9, 10 }
            );

            // Act
            ListNode result = solution.GetIntersectionNode(headA, headB);

            // Assert
            AssertSameNode(intersection, result, solutionName);
            Assert.AreEqual(9, result.val, $"Should find intersection for much longer second list for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void GetIntersectionNode_OneDifferenceInLength_FindsIntersection(IIntersectionOfTwoLinkedLists_160 solution, string solutionName)
        {
            // Arrange: Length differs by only 1
            var (headA, headB, intersection) = CreateIntersectingLists(
                new[] { 1, 2 },
                new[] { 3 },
                new[] { 4, 5, 6 }
            );

            // Act
            ListNode result = solution.GetIntersectionNode(headA, headB);

            // Assert
            AssertSameNode(intersection, result, solutionName);
            Assert.AreEqual(4, result.val, $"Should find intersection with length diff of 1 for {solutionName}");
        }

        #endregion

        #region Single Node Cases

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void GetIntersectionNode_BothSingleNodeSame_ReturnsNode(IIntersectionOfTwoLinkedLists_160 solution, string solutionName)
        {
            // Arrange: Both lists are the same single node
            ListNode shared = new ListNode(5);
            ListNode headA = shared;
            ListNode headB = shared;

            // Act
            ListNode result = solution.GetIntersectionNode(headA, headB);

            // Assert
            AssertSameNode(shared, result, solutionName);
            Assert.AreEqual(5, result.val, $"Should return the shared single node for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void GetIntersectionNode_BothSingleNodeDifferent_ReturnsNull(IIntersectionOfTwoLinkedLists_160 solution, string solutionName)
        {
            // Arrange: Both lists are single nodes but different
            ListNode headA = new ListNode(1);
            ListNode headB = new ListNode(2);

            // Act
            ListNode result = solution.GetIntersectionNode(headA, headB);

            // Assert
            Assert.IsNull(result, $"Should return null for different single nodes for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void GetIntersectionNode_OneSingleNodeIntersects_FindsIntersection(IIntersectionOfTwoLinkedLists_160 solution, string solutionName)
        {
            // Arrange: A is single node, B has multiple nodes leading to A
            var (headA, headB, intersection) = CreateIntersectingLists(
                Array.Empty<int>(),
                new[] { 1, 2, 3 },
                new[] { 4 }              // Single intersection node
            );

            // Act
            ListNode result = solution.GetIntersectionNode(headA, headB);

            // Assert
            AssertSameNode(intersection, result, solutionName);
            Assert.AreEqual(4, result.val, $"Should find single node intersection for {solutionName}");
        }

        #endregion

        #region Edge Cases with Values

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void GetIntersectionNode_DuplicateValues_FindsCorrectNode(IIntersectionOfTwoLinkedLists_160 solution, string solutionName)
        {
            // Arrange: Same values appear in both lists but only share nodes at intersection
            var (headA, headB, intersection) = CreateIntersectingLists(
                new[] { 5, 5 },          // A has value 5
                new[] { 5 },             // B also has value 5
                new[] { 5, 6 }           // Intersection also starts with 5
            );

            // Act
            ListNode result = solution.GetIntersectionNode(headA, headB);

            // Assert: Should find the intersection node, not just same value
            AssertSameNode(intersection, result, solutionName);
            // Verify it's the correct node by checking it's the same reference
            Assert.AreSame(intersection, result, $"Should return actual intersection node, not just matching value for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void GetIntersectionNode_AllSameValues_FindsCorrectIntersection(IIntersectionOfTwoLinkedLists_160 solution, string solutionName)
        {
            // Arrange: All nodes have same value but different references
            var (headA, headB, intersection) = CreateIntersectingLists(
                new[] { 1, 1, 1 },
                new[] { 1, 1 },
                new[] { 1, 1, 1 }
            );

            // Act
            ListNode result = solution.GetIntersectionNode(headA, headB);

            // Assert: Must be same object reference, not just same value
            AssertSameNode(intersection, result, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void GetIntersectionNode_NegativeValues_FindsIntersection(IIntersectionOfTwoLinkedLists_160 solution, string solutionName)
        {
            // Arrange: Lists with negative values
            var (headA, headB, intersection) = CreateIntersectingLists(
                new[] { -1, -2 },
                new[] { -3, -4, -5 },
                new[] { -6, -7 }
            );

            // Act
            ListNode result = solution.GetIntersectionNode(headA, headB);

            // Assert
            AssertSameNode(intersection, result, solutionName);
            Assert.AreEqual(-6, result.val, $"Should find intersection with negative values for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void GetIntersectionNode_ZeroValues_FindsIntersection(IIntersectionOfTwoLinkedLists_160 solution, string solutionName)
        {
            // Arrange: Lists with zero values
            var (headA, headB, intersection) = CreateIntersectingLists(
                new[] { 0, 1 },
                new[] { 2, 0 },
                new[] { 0, 3 }
            );

            // Act
            ListNode result = solution.GetIntersectionNode(headA, headB);

            // Assert
            AssertSameNode(intersection, result, solutionName);
            Assert.AreEqual(0, result.val, $"Should find intersection with zero values for {solutionName}");
        }

        #endregion

        #region Long Lists

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void GetIntersectionNode_LongLists_FindsIntersection(IIntersectionOfTwoLinkedLists_160 solution, string solutionName)
        {
            // Arrange: Long lists with intersection
            var listAValues = Enumerable.Range(1, 50).ToArray();
            var listBValues = Enumerable.Range(51, 30).ToArray();
            var intersectionValues = Enumerable.Range(100, 20).ToArray();
            
            var (headA, headB, intersection) = CreateIntersectingLists(
                listAValues,
                listBValues,
                intersectionValues
            );

            // Act
            ListNode result = solution.GetIntersectionNode(headA, headB);

            // Assert
            AssertSameNode(intersection, result, solutionName);
            Assert.AreEqual(100, result.val, $"Should find intersection in long lists for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void GetIntersectionNode_VeryLongListsNoIntersection_ReturnsNull(IIntersectionOfTwoLinkedLists_160 solution, string solutionName)
        {
            // Arrange: Very long lists with no intersection
            var listAValues = Enumerable.Range(1, 100).ToArray();
            var listBValues = Enumerable.Range(101, 100).ToArray();
            
            ListNode headA = CreateList(listAValues);
            ListNode headB = CreateList(listBValues);

            // Act
            ListNode result = solution.GetIntersectionNode(headA, headB);

            // Assert
            Assert.IsNull(result, $"Should return null for very long lists with no intersection for {solutionName}");
        }

        #endregion

        #region Special Patterns

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void GetIntersectionNode_AscendingValues_FindsIntersection(IIntersectionOfTwoLinkedLists_160 solution, string solutionName)
        {
            // Arrange: Strictly ascending values
            var (headA, headB, intersection) = CreateIntersectingLists(
                new[] { 1, 3, 5 },
                new[] { 2, 4 },
                new[] { 6, 7, 8 }
            );

            // Act
            ListNode result = solution.GetIntersectionNode(headA, headB);

            // Assert
            AssertSameNode(intersection, result, solutionName);
            Assert.AreEqual(6, result.val, $"Should find intersection in ascending pattern for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void GetIntersectionNode_DescendingValues_FindsIntersection(IIntersectionOfTwoLinkedLists_160 solution, string solutionName)
        {
            // Arrange: Descending values
            var (headA, headB, intersection) = CreateIntersectingLists(
                new[] { 10, 9, 8 },
                new[] { 7, 6 },
                new[] { 5, 4, 3 }
            );

            // Act
            ListNode result = solution.GetIntersectionNode(headA, headB);

            // Assert
            AssertSameNode(intersection, result, solutionName);
            Assert.AreEqual(5, result.val, $"Should find intersection in descending pattern for {solutionName}");
        }

        #endregion
    }
}