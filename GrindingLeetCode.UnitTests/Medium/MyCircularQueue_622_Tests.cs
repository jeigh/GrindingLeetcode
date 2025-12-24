using LeetCodeProblems.CSharp.LinkedList;
using LeetCodeProblems.Interfaces.Medium;

namespace GrindingLeetCode.UnitTests.Medium
{
    [TestClass]
    public class MyCircularQueue_622_Tests
    {
        public static IEnumerable<object[]> GetImplementations()
        {
            yield return new object[] { (int k) => new MyCircularQueueCSharp_WithoutDummyNodes_622(k), "C#" };
        }

        #region Helper Methods

        /// <summary>
        /// Helper to verify queue state
        /// </summary>
        private void AssertQueueState(IMyCircularQueue_622 queue, bool expectedIsEmpty, bool expectedIsFull, 
            int expectedFront, int expectedRear, string solutionName)
        {
            Assert.AreEqual(expectedIsEmpty, queue.IsEmpty(), 
                $"IsEmpty mismatch for {solutionName}");
            Assert.AreEqual(expectedIsFull, queue.IsFull(), 
                $"IsFull mismatch for {solutionName}");
            Assert.AreEqual(expectedFront, queue.Front(), 
                $"Front mismatch for {solutionName}");
            Assert.AreEqual(expectedRear, queue.Rear(), 
                $"Rear mismatch for {solutionName}");
        }

        #endregion

        #region LeetCode Example

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void MyCircularQueue_LeetCodeExample1_WorksCorrectly(Func<int, IMyCircularQueue_622> factory, string solutionName)
        {
            // Example 1:
            // Input: ["MyCircularQueue", "enQueue", "enQueue", "enQueue", "enQueue", "Rear", "isFull", "deQueue", "enQueue", "Rear"]
            // [[3], [1], [2], [3], [4], [], [], [], [4], []]
            // Output: [null, true, true, true, false, 3, true, true, true, 4]

            // Arrange
            var myCircularQueue = factory(3);

            // Act & Assert
            Assert.IsTrue(myCircularQueue.EnQueue(1), $"EnQueue(1) failed for {solutionName}"); // return True
            Assert.IsTrue(myCircularQueue.EnQueue(2), $"EnQueue(2) failed for {solutionName}"); // return True
            Assert.IsTrue(myCircularQueue.EnQueue(3), $"EnQueue(3) failed for {solutionName}"); // return True
            Assert.IsFalse(myCircularQueue.EnQueue(4), $"EnQueue(4) should fail for {solutionName}"); // return False, queue is full
            Assert.AreEqual(3, myCircularQueue.Rear(), $"Rear should be 3 for {solutionName}"); // return 3
            Assert.IsTrue(myCircularQueue.IsFull(), $"IsFull should be true for {solutionName}"); // return True
            Assert.IsTrue(myCircularQueue.DeQueue(), $"DeQueue failed for {solutionName}"); // return True
            Assert.IsTrue(myCircularQueue.EnQueue(4), $"EnQueue(4) after dequeue failed for {solutionName}"); // return True
            Assert.AreEqual(4, myCircularQueue.Rear(), $"Rear should be 4 for {solutionName}"); // return 4
        }

        #endregion

        #region Constructor Tests

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Constructor_SizeOne_InitializesCorrectly(Func<int, IMyCircularQueue_622> factory, string solutionName)
        {
            // Arrange & Act
            var queue = factory(1);

            // Assert
            AssertQueueState(queue, true, false, -1, -1, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Constructor_SizeThree_InitializesCorrectly(Func<int, IMyCircularQueue_622> factory, string solutionName)
        {
            // Arrange & Act
            var queue = factory(3);

            // Assert
            AssertQueueState(queue, true, false, -1, -1, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Constructor_LargeSize_InitializesCorrectly(Func<int, IMyCircularQueue_622> factory, string solutionName)
        {
            // Arrange & Act
            var queue = factory(1000);

            // Assert
            AssertQueueState(queue, true, false, -1, -1, solutionName);
        }

        #endregion

        #region EnQueue Tests

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void EnQueue_SingleElement_Succeeds(Func<int, IMyCircularQueue_622> factory, string solutionName)
        {
            // Arrange
            var queue = factory(3);

            // Act
            bool result = queue.EnQueue(5);

            // Assert
            Assert.IsTrue(result, $"EnQueue should succeed for {solutionName}");
            AssertQueueState(queue, false, false, 5, 5, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void EnQueue_FillQueue_Succeeds(Func<int, IMyCircularQueue_622> factory, string solutionName)
        {
            // Arrange
            var queue = factory(3);

            // Act
            Assert.IsTrue(queue.EnQueue(1), $"EnQueue(1) failed for {solutionName}");
            Assert.IsTrue(queue.EnQueue(2), $"EnQueue(2) failed for {solutionName}");
            Assert.IsTrue(queue.EnQueue(3), $"EnQueue(3) failed for {solutionName}");

            // Assert
            AssertQueueState(queue, false, true, 1, 3, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void EnQueue_WhenFull_ReturnsFalse(Func<int, IMyCircularQueue_622> factory, string solutionName)
        {
            // Arrange
            var queue = factory(2);
            queue.EnQueue(1);
            queue.EnQueue(2);

            // Act
            bool result = queue.EnQueue(3);

            // Assert
            Assert.IsFalse(result, $"EnQueue should fail when full for {solutionName}");
            AssertQueueState(queue, false, true, 1, 2, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void EnQueue_NegativeValue_Succeeds(Func<int, IMyCircularQueue_622> factory, string solutionName)
        {
            // Arrange
            var queue = factory(3);

            // Act
            bool result = queue.EnQueue(-5);

            // Assert
            Assert.IsTrue(result, $"EnQueue with negative value should succeed for {solutionName}");
            Assert.AreEqual(-5, queue.Front(), $"Front should be -5 for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void EnQueue_Zero_Succeeds(Func<int, IMyCircularQueue_622> factory, string solutionName)
        {
            // Arrange
            var queue = factory(3);

            // Act
            bool result = queue.EnQueue(0);

            // Assert
            Assert.IsTrue(result, $"EnQueue with zero should succeed for {solutionName}");
            Assert.AreEqual(0, queue.Front(), $"Front should be 0 for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void EnQueue_SizeOneQueue_WorksCorrectly(Func<int, IMyCircularQueue_622> factory, string solutionName)
        {
            // Arrange
            var queue = factory(1);

            // Act
            Assert.IsTrue(queue.EnQueue(42), $"EnQueue should succeed for {solutionName}");

            // Assert
            AssertQueueState(queue, false, true, 42, 42, solutionName);

            // Try to enqueue again - should fail
            Assert.IsFalse(queue.EnQueue(99), $"Second EnQueue should fail for {solutionName}");
        }

        #endregion

        #region DeQueue Tests

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void DeQueue_EmptyQueue_ReturnsFalse(Func<int, IMyCircularQueue_622> factory, string solutionName)
        {
            // Arrange
            var queue = factory(3);

            // Act
            bool result = queue.DeQueue();

            // Assert
            Assert.IsFalse(result, $"DeQueue on empty queue should fail for {solutionName}");
            AssertQueueState(queue, true, false, -1, -1, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void DeQueue_SingleElement_SucceedsAndEmptiesQueue(Func<int, IMyCircularQueue_622> factory, string solutionName)
        {
            // Arrange
            var queue = factory(3);
            queue.EnQueue(5);

            // Act
            bool result = queue.DeQueue();

            // Assert
            Assert.IsTrue(result, $"DeQueue should succeed for {solutionName}");
            AssertQueueState(queue, true, false, -1, -1, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void DeQueue_MultipleElements_RemovesFIFO(Func<int, IMyCircularQueue_622> factory, string solutionName)
        {
            // Arrange
            var queue = factory(3);
            queue.EnQueue(1);
            queue.EnQueue(2);
            queue.EnQueue(3);

            // Act & Assert - Dequeue in FIFO order
            Assert.IsTrue(queue.DeQueue(), $"First DeQueue failed for {solutionName}");
            Assert.AreEqual(2, queue.Front(), $"Front should be 2 after first dequeue for {solutionName}");
            Assert.AreEqual(3, queue.Rear(), $"Rear should be 3 after first dequeue for {solutionName}");

            Assert.IsTrue(queue.DeQueue(), $"Second DeQueue failed for {solutionName}");
            Assert.AreEqual(3, queue.Front(), $"Front should be 3 after second dequeue for {solutionName}");
            Assert.AreEqual(3, queue.Rear(), $"Rear should be 3 after second dequeue for {solutionName}");

            Assert.IsTrue(queue.DeQueue(), $"Third DeQueue failed for {solutionName}");
            AssertQueueState(queue, true, false, -1, -1, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void DeQueue_AllElements_ThenEnQueue_WorksCorrectly(Func<int, IMyCircularQueue_622> factory, string solutionName)
        {
            // Arrange
            var queue = factory(2);
            queue.EnQueue(1);
            queue.EnQueue(2);

            // Act - Empty the queue
            queue.DeQueue();
            queue.DeQueue();

            // Try to enqueue again
            Assert.IsTrue(queue.EnQueue(3), $"EnQueue after emptying should succeed for {solutionName}");
            Assert.AreEqual(3, queue.Front(), $"Front should be 3 for {solutionName}");
        }

        #endregion

        #region Front Tests

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Front_EmptyQueue_ReturnsMinusOne(Func<int, IMyCircularQueue_622> factory, string solutionName)
        {
            // Arrange
            var queue = factory(3);

            // Act
            int result = queue.Front();

            // Assert
            Assert.AreEqual(-1, result, $"Front on empty queue should return -1 for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Front_SingleElement_ReturnsElement(Func<int, IMyCircularQueue_622> factory, string solutionName)
        {
            // Arrange
            var queue = factory(3);
            queue.EnQueue(42);

            // Act
            int result = queue.Front();

            // Assert
            Assert.AreEqual(42, result, $"Front should return 42 for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Front_MultipleElements_ReturnsFirst(Func<int, IMyCircularQueue_622> factory, string solutionName)
        {
            // Arrange
            var queue = factory(3);
            queue.EnQueue(10);
            queue.EnQueue(20);
            queue.EnQueue(30);

            // Act
            int result = queue.Front();

            // Assert
            Assert.AreEqual(10, result, $"Front should return first element (10) for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Front_DoesNotModifyQueue(Func<int, IMyCircularQueue_622> factory, string solutionName)
        {
            // Arrange
            var queue = factory(3);
            queue.EnQueue(1);
            queue.EnQueue(2);

            // Act - Call Front multiple times
            int first = queue.Front();
            int second = queue.Front();
            int third = queue.Front();

            // Assert - All should return the same value
            Assert.AreEqual(1, first, $"First call to Front failed for {solutionName}");
            Assert.AreEqual(1, second, $"Second call to Front failed for {solutionName}");
            Assert.AreEqual(1, third, $"Third call to Front failed for {solutionName}");
            Assert.IsFalse(queue.IsEmpty(), $"Queue should not be empty for {solutionName}");
        }

        #endregion

        #region Rear Tests

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Rear_EmptyQueue_ReturnsMinusOne(Func<int, IMyCircularQueue_622> factory, string solutionName)
        {
            // Arrange
            var queue = factory(3);

            // Act
            int result = queue.Rear();

            // Assert
            Assert.AreEqual(-1, result, $"Rear on empty queue should return -1 for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Rear_SingleElement_ReturnsElement(Func<int, IMyCircularQueue_622> factory, string solutionName)
        {
            // Arrange
            var queue = factory(3);
            queue.EnQueue(42);

            // Act
            int result = queue.Rear();

            // Assert
            Assert.AreEqual(42, result, $"Rear should return 42 for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Rear_MultipleElements_ReturnsLast(Func<int, IMyCircularQueue_622> factory, string solutionName)
        {
            // Arrange
            var queue = factory(3);
            queue.EnQueue(10);
            queue.EnQueue(20);
            queue.EnQueue(30);

            // Act
            int result = queue.Rear();

            // Assert
            Assert.AreEqual(30, result, $"Rear should return last element (30) for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Rear_DoesNotModifyQueue(Func<int, IMyCircularQueue_622> factory, string solutionName)
        {
            // Arrange
            var queue = factory(3);
            queue.EnQueue(1);
            queue.EnQueue(2);

            // Act - Call Rear multiple times
            int first = queue.Rear();
            int second = queue.Rear();
            int third = queue.Rear();

            // Assert - All should return the same value
            Assert.AreEqual(2, first, $"First call to Rear failed for {solutionName}");
            Assert.AreEqual(2, second, $"Second call to Rear failed for {solutionName}");
            Assert.AreEqual(2, third, $"Third call to Rear failed for {solutionName}");
            Assert.IsFalse(queue.IsEmpty(), $"Queue should not be empty for {solutionName}");
        }

        #endregion

        #region IsEmpty Tests

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsEmpty_NewQueue_ReturnsTrue(Func<int, IMyCircularQueue_622> factory, string solutionName)
        {
            // Arrange
            var queue = factory(3);

            // Act
            bool result = queue.IsEmpty();

            // Assert
            Assert.IsTrue(result, $"New queue should be empty for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsEmpty_AfterEnQueue_ReturnsFalse(Func<int, IMyCircularQueue_622> factory, string solutionName)
        {
            // Arrange
            var queue = factory(3);
            queue.EnQueue(1);

            // Act
            bool result = queue.IsEmpty();

            // Assert
            Assert.IsFalse(result, $"Queue with elements should not be empty for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsEmpty_AfterEnQueueAndDeQueue_ReturnsTrue(Func<int, IMyCircularQueue_622> factory, string solutionName)
        {
            // Arrange
            var queue = factory(3);
            queue.EnQueue(1);
            queue.DeQueue();

            // Act
            bool result = queue.IsEmpty();

            // Assert
            Assert.IsTrue(result, $"Queue should be empty after dequeueing all elements for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsEmpty_PartiallyFilled_ReturnsFalse(Func<int, IMyCircularQueue_622> factory, string solutionName)
        {
            // Arrange
            var queue = factory(5);
            queue.EnQueue(1);
            queue.EnQueue(2);

            // Act
            bool result = queue.IsEmpty();

            // Assert
            Assert.IsFalse(result, $"Partially filled queue should not be empty for {solutionName}");
        }

        #endregion

        #region IsFull Tests

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsFull_NewQueue_ReturnsFalse(Func<int, IMyCircularQueue_622> factory, string solutionName)
        {
            // Arrange
            var queue = factory(3);

            // Act
            bool result = queue.IsFull();

            // Assert
            Assert.IsFalse(result, $"New queue should not be full for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsFull_PartiallyFilled_ReturnsFalse(Func<int, IMyCircularQueue_622> factory, string solutionName)
        {
            // Arrange
            var queue = factory(3);
            queue.EnQueue(1);

            // Act
            bool result = queue.IsFull();

            // Assert
            Assert.IsFalse(result, $"Partially filled queue should not be full for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsFull_CompletelyFilled_ReturnsTrue(Func<int, IMyCircularQueue_622> factory, string solutionName)
        {
            // Arrange
            var queue = factory(3);
            queue.EnQueue(1);
            queue.EnQueue(2);
            queue.EnQueue(3);

            // Act
            bool result = queue.IsFull();

            // Assert
            Assert.IsTrue(result, $"Completely filled queue should be full for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsFull_AfterDeQueue_ReturnsFalse(Func<int, IMyCircularQueue_622> factory, string solutionName)
        {
            // Arrange
            var queue = factory(3);
            queue.EnQueue(1);
            queue.EnQueue(2);
            queue.EnQueue(3);
            queue.DeQueue();

            // Act
            bool result = queue.IsFull();

            // Assert
            Assert.IsFalse(result, $"Queue should not be full after dequeue for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsFull_SizeOne_WorksCorrectly(Func<int, IMyCircularQueue_622> factory, string solutionName)
        {
            // Arrange
            var queue = factory(1);

            // Act & Assert
            Assert.IsFalse(queue.IsFull(), $"Empty queue of size 1 should not be full for {solutionName}");

            queue.EnQueue(42);
            Assert.IsTrue(queue.IsFull(), $"Queue of size 1 with 1 element should be full for {solutionName}");

            queue.DeQueue();
            Assert.IsFalse(queue.IsFull(), $"Empty queue of size 1 should not be full after dequeue for {solutionName}");
        }

        #endregion

        #region Circular Behavior Tests

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CircularBehavior_WrapAround_WorksCorrectly(Func<int, IMyCircularQueue_622> factory, string solutionName)
        {
            // This tests that the queue properly wraps around to use freed space at the front
            // Arrange
            var queue = factory(3);

            // Fill queue: [1, 2, 3]
            queue.EnQueue(1);
            queue.EnQueue(2);
            queue.EnQueue(3);
            Assert.IsTrue(queue.IsFull(), $"Queue should be full for {solutionName}");

            // Remove two elements: [_, _, 3] (conceptually, front and rear pointers have moved)
            queue.DeQueue(); // Remove 1
            queue.DeQueue(); // Remove 2

            // Add two more elements - should wrap around: [4, 5, 3]
            Assert.IsTrue(queue.EnQueue(4), $"EnQueue(4) should succeed for {solutionName}");
            Assert.IsTrue(queue.EnQueue(5), $"EnQueue(5) should succeed for {solutionName}");

            // Verify FIFO order
            Assert.AreEqual(3, queue.Front(), $"Front should be 3 for {solutionName}");
            Assert.AreEqual(5, queue.Rear(), $"Rear should be 5 for {solutionName}");
            Assert.IsTrue(queue.IsFull(), $"Queue should be full again for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CircularBehavior_MultipleWraps_WorksCorrectly(Func<int, IMyCircularQueue_622> factory, string solutionName)
        {
            // Test multiple wrap-around cycles
            // Arrange
            var queue = factory(3);

            // First cycle: Fill, dequeue all
            queue.EnQueue(1);
            queue.EnQueue(2);
            queue.EnQueue(3);
            queue.DeQueue();
            queue.DeQueue();
            queue.DeQueue();

            // Second cycle: Fill again
            queue.EnQueue(4);
            queue.EnQueue(5);
            queue.EnQueue(6);

            // Assert
            Assert.AreEqual(4, queue.Front(), $"Front should be 4 for {solutionName}");
            Assert.AreEqual(6, queue.Rear(), $"Rear should be 6 for {solutionName}");
            Assert.IsTrue(queue.IsFull(), $"Queue should be full for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CircularBehavior_AlternatingEnqueueDequeue_WorksCorrectly(Func<int, IMyCircularQueue_622> factory, string solutionName)
        {
            // Arrange
            var queue = factory(3);

            // Fill queue
            queue.EnQueue(1);
            queue.EnQueue(2);
            queue.EnQueue(3);

            // Alternate dequeue and enqueue operations
            Assert.IsTrue(queue.DeQueue(), $"DeQueue should succeed for {solutionName}"); // Remove 1
            Assert.AreEqual(2, queue.Front(), $"Front should be 2 for {solutionName}");

            Assert.IsTrue(queue.EnQueue(4), $"EnQueue(4) should succeed for {solutionName}"); // Add 4
            Assert.AreEqual(4, queue.Rear(), $"Rear should be 4 for {solutionName}");

            Assert.IsTrue(queue.DeQueue(), $"DeQueue should succeed for {solutionName}"); // Remove 2
            Assert.AreEqual(3, queue.Front(), $"Front should be 3 for {solutionName}");

            Assert.IsTrue(queue.EnQueue(5), $"EnQueue(5) should succeed for {solutionName}"); // Add 5
            Assert.AreEqual(5, queue.Rear(), $"Rear should be 5 for {solutionName}");

            // Verify final state: [3, 4, 5]
            Assert.AreEqual(3, queue.Front(), $"Final front should be 3 for {solutionName}");
            Assert.AreEqual(5, queue.Rear(), $"Final rear should be 5 for {solutionName}");
            Assert.IsTrue(queue.IsFull(), $"Queue should be full for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CircularBehavior_FillEmptyFillPattern_WorksCorrectly(Func<int, IMyCircularQueue_622> factory, string solutionName)
        {
            // Arrange
            var queue = factory(2);

            // Pattern 1: Fill
            queue.EnQueue(1);
            queue.EnQueue(2);
            Assert.IsTrue(queue.IsFull(), $"Queue should be full for {solutionName}");

            // Pattern 2: Empty
            queue.DeQueue();
            queue.DeQueue();
            Assert.IsTrue(queue.IsEmpty(), $"Queue should be empty for {solutionName}");

            // Pattern 3: Fill again (tests wrap-around)
            queue.EnQueue(3);
            queue.EnQueue(4);
            Assert.IsTrue(queue.IsFull(), $"Queue should be full again for {solutionName}");
            Assert.AreEqual(3, queue.Front(), $"Front should be 3 for {solutionName}");
            Assert.AreEqual(4, queue.Rear(), $"Rear should be 4 for {solutionName}");
        }

        #endregion

        #region Edge Cases

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void EdgeCase_SizeOneQueue_AllOperations_WorkCorrectly(Func<int, IMyCircularQueue_622> factory, string solutionName)
        {
            // Arrange
            var queue = factory(1);

            // Test all operations on size-1 queue
            Assert.IsTrue(queue.IsEmpty(), $"Should be empty initially for {solutionName}");
            Assert.IsFalse(queue.IsFull(), $"Should not be full initially for {solutionName}");
            Assert.AreEqual(-1, queue.Front(), $"Front should be -1 when empty for {solutionName}");
            Assert.AreEqual(-1, queue.Rear(), $"Rear should be -1 when empty for {solutionName}");

            // Add element
            Assert.IsTrue(queue.EnQueue(42), $"EnQueue should succeed for {solutionName}");
            Assert.IsFalse(queue.IsEmpty(), $"Should not be empty for {solutionName}");
            Assert.IsTrue(queue.IsFull(), $"Should be full for {solutionName}");
            Assert.AreEqual(42, queue.Front(), $"Front should be 42 for {solutionName}");
            Assert.AreEqual(42, queue.Rear(), $"Rear should be 42 for {solutionName}");

            // Try to add another - should fail
            Assert.IsFalse(queue.EnQueue(99), $"EnQueue should fail when full for {solutionName}");

            // Remove element
            Assert.IsTrue(queue.DeQueue(), $"DeQueue should succeed for {solutionName}");
            Assert.IsTrue(queue.IsEmpty(), $"Should be empty after dequeue for {solutionName}");
            Assert.IsFalse(queue.IsFull(), $"Should not be full after dequeue for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void EdgeCase_RepeatedOperations_WorksCorrectly(Func<int, IMyCircularQueue_622> factory, string solutionName)
        {
            // Arrange
            var queue = factory(3);

            // Perform many operations to test robustness
            for (int i = 0; i < 10; i++)
            {
                queue.EnQueue(i);
                queue.EnQueue(i + 1);
                queue.EnQueue(i + 2);
                Assert.IsTrue(queue.IsFull(), $"Queue should be full at iteration {i} for {solutionName}");

                queue.DeQueue();
                queue.DeQueue();
                Assert.IsFalse(queue.IsFull(), $"Queue should not be full after dequeues at iteration {i} for {solutionName}");
            }
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void EdgeCase_LargeQueue_WorksCorrectly(Func<int, IMyCircularQueue_622> factory, string solutionName)
        {
            // Arrange
            var queue = factory(100);

            // Fill the queue
            for (int i = 0; i < 100; i++)
            {
                Assert.IsTrue(queue.EnQueue(i), $"EnQueue({i}) should succeed for {solutionName}");
            }

            // Verify full
            Assert.IsTrue(queue.IsFull(), $"Queue should be full for {solutionName}");
            Assert.AreEqual(0, queue.Front(), $"Front should be 0 for {solutionName}");
            Assert.AreEqual(99, queue.Rear(), $"Rear should be 99 for {solutionName}");

            // Dequeue all
            for (int i = 0; i < 100; i++)
            {
                Assert.AreEqual(i, queue.Front(), $"Front should be {i} for {solutionName}");
                Assert.IsTrue(queue.DeQueue(), $"DeQueue at {i} should succeed for {solutionName}");
            }

            // Verify empty
            Assert.IsTrue(queue.IsEmpty(), $"Queue should be empty for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void EdgeCase_DuplicateValues_WorksCorrectly(Func<int, IMyCircularQueue_622> factory, string solutionName)
        {
            // Arrange
            var queue = factory(3);

            // Enqueue duplicate values
            queue.EnQueue(5);
            queue.EnQueue(5);
            queue.EnQueue(5);

            // Assert - All values are 5
            Assert.AreEqual(5, queue.Front(), $"Front should be 5 for {solutionName}");
            Assert.AreEqual(5, queue.Rear(), $"Rear should be 5 for {solutionName}");

            // Dequeue and verify
            queue.DeQueue();
            Assert.AreEqual(5, queue.Front(), $"Front should still be 5 for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void EdgeCase_NegativeAndPositiveValues_WorksCorrectly(Func<int, IMyCircularQueue_622> factory, string solutionName)
        {
            // Arrange
            var queue = factory(5);

            // Enqueue mix of negative and positive values
            queue.EnQueue(-10);
            queue.EnQueue(-5);
            queue.EnQueue(0);
            queue.EnQueue(5);
            queue.EnQueue(10);

            // Verify order
            Assert.AreEqual(-10, queue.Front(), $"Front should be -10 for {solutionName}");
            Assert.AreEqual(10, queue.Rear(), $"Rear should be 10 for {solutionName}");

            // Dequeue and check FIFO
            queue.DeQueue();
            Assert.AreEqual(-5, queue.Front(), $"Front should be -5 after dequeue for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void EdgeCase_MaxIntValues_WorksCorrectly(Func<int, IMyCircularQueue_622> factory, string solutionName)
        {
            // Arrange
            var queue = factory(3);

            // Enqueue max int values
            queue.EnQueue(int.MaxValue);
            queue.EnQueue(int.MinValue);
            queue.EnQueue(0);

            // Assert
            Assert.AreEqual(int.MaxValue, queue.Front(), $"Front should be int.MaxValue for {solutionName}");
            Assert.AreEqual(0, queue.Rear(), $"Rear should be 0 for {solutionName}");
        }

        #endregion

        #region Stress Tests

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void StressTest_ManyOperations_WorksCorrectly(Func<int, IMyCircularQueue_622> factory, string solutionName)
        {
            // Arrange
            var queue = factory(10);

            // Perform many mixed operations
            for (int cycle = 0; cycle < 50; cycle++)
            {
                // Fill partially
                for (int i = 0; i < 5; i++)
                {
                    queue.EnQueue(cycle * 10 + i);
                }

                // Remove some
                for (int i = 0; i < 3; i++)
                {
                    queue.DeQueue();
                }

                // Add more
                for (int i = 5; i < 8; i++)
                {
                    queue.EnQueue(cycle * 10 + i);
                }
            }

            // Just verify queue is still functional
            Assert.IsFalse(queue.IsEmpty(), $"Queue should not be empty after stress test for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void StressTest_AlternatingFullEmpty_WorksCorrectly(Func<int, IMyCircularQueue_622> factory, string solutionName)
        {
            // Arrange
            var queue = factory(5);

            // Alternate between filling and emptying the queue multiple times
            for (int cycle = 0; cycle < 20; cycle++)
            {
                // Fill
                for (int i = 0; i < 5; i++)
                {
                    Assert.IsTrue(queue.EnQueue(cycle * 5 + i), 
                        $"EnQueue failed at cycle {cycle}, index {i} for {solutionName}");
                }
                Assert.IsTrue(queue.IsFull(), $"Queue should be full at cycle {cycle} for {solutionName}");

                // Empty
                for (int i = 0; i < 5; i++)
                {
                    Assert.IsTrue(queue.DeQueue(), 
                        $"DeQueue failed at cycle {cycle}, index {i} for {solutionName}");
                }
                Assert.IsTrue(queue.IsEmpty(), $"Queue should be empty at cycle {cycle} for {solutionName}");
            }
        }

        #endregion

        #region Complex Scenarios

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void ComplexScenario_VariousOperations_WorksCorrectly(Func<int, IMyCircularQueue_622> factory, string solutionName)
        {
            // This is a comprehensive test combining many operations
            // Arrange
            var queue = factory(5);

            // Start with basic operations
            Assert.IsTrue(queue.IsEmpty(), $"Should start empty for {solutionName}");
            Assert.IsTrue(queue.EnQueue(10), $"EnQueue(10) failed for {solutionName}");
            Assert.AreEqual(10, queue.Front(), $"Front should be 10 for {solutionName}");
            Assert.AreEqual(10, queue.Rear(), $"Rear should be 10 for {solutionName}");

            // Fill it up
            queue.EnQueue(20);
            queue.EnQueue(30);
            queue.EnQueue(40);
            queue.EnQueue(50);
            Assert.IsTrue(queue.IsFull(), $"Should be full for {solutionName}");

            // Try to add when full
            Assert.IsFalse(queue.EnQueue(60), $"EnQueue should fail when full for {solutionName}");

            // Remove some and add some
            queue.DeQueue(); // Remove 10
            queue.DeQueue(); // Remove 20
            Assert.AreEqual(30, queue.Front(), $"Front should be 30 for {solutionName}");
            Assert.IsTrue(queue.EnQueue(60), $"EnQueue(60) should succeed for {solutionName}");
            Assert.IsTrue(queue.EnQueue(70), $"EnQueue(70) should succeed for {solutionName}");
            Assert.IsTrue(queue.IsFull(), $"Should be full again for {solutionName}");
            Assert.AreEqual(70, queue.Rear(), $"Rear should be 70 for {solutionName}");

            // Verify order: [30, 40, 50, 60, 70]
            queue.DeQueue(); // 30
            Assert.AreEqual(40, queue.Front(), $"Front should be 40 for {solutionName}");
            queue.DeQueue(); // 40
            Assert.AreEqual(50, queue.Front(), $"Front should be 50 for {solutionName}");
            queue.DeQueue(); // 50
            Assert.AreEqual(60, queue.Front(), $"Front should be 60 for {solutionName}");
            queue.DeQueue(); // 60
            Assert.AreEqual(70, queue.Front(), $"Front should be 70 for {solutionName}");
            Assert.AreEqual(70, queue.Rear(), $"Rear should be 70 for {solutionName}");
            queue.DeQueue(); // 70
            Assert.IsTrue(queue.IsEmpty(), $"Should be empty at end for {solutionName}");
        }

        #endregion
    }
}
