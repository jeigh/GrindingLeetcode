using LeetCodeProblems;

namespace GrindingLeetCode.UnitTests.Easy
{
    [TestClass]
    public class ImplementQueueUsingStacks_232_Tests
    {
        [TestMethod]
        public void MyQueue_Example1_WorksCorrectly()
        {
            // Arrange
            var myQueue = new ImplementQueueUsingStacks_232();

            // Act & Assert - LeetCode Example
            myQueue.Push(1);
            myQueue.Push(2);
            Assert.AreEqual(1, myQueue.Peek());   // returns 1
            Assert.AreEqual(1, myQueue.Pop());    // returns 1
            Assert.IsFalse(myQueue.Empty());      // returns false
        }

        [TestMethod]
        public void Push_SingleElement_CanBeRetrieved()
        {
            // Arrange
            var myQueue = new ImplementQueueUsingStacks_232();

            // Act
            myQueue.Push(5);

            // Assert
            Assert.AreEqual(5, myQueue.Peek());
            Assert.IsFalse(myQueue.Empty());
        }

        [TestMethod]
        public void Push_MultipleElements_MaintainsFIFOOrder()
        {
            // Arrange
            var myQueue = new ImplementQueueUsingStacks_232();

            // Act
            myQueue.Push(1);
            myQueue.Push(2);
            myQueue.Push(3);

            // Assert - First in, first out
            Assert.AreEqual(1, myQueue.Pop());
            Assert.AreEqual(2, myQueue.Pop());
            Assert.AreEqual(3, myQueue.Pop());
        }

        [TestMethod]
        public void Pop_RemovesFrontElement_ReturnsValue()
        {
            // Arrange
            var myQueue = new ImplementQueueUsingStacks_232();
            myQueue.Push(10);
            myQueue.Push(20);

            // Act
            int popped = myQueue.Pop();

            // Assert
            Assert.AreEqual(10, popped);
            Assert.AreEqual(20, myQueue.Peek());
        }

        [TestMethod]
        public void Peek_DoesNotRemoveElement()
        {
            // Arrange
            var myQueue = new ImplementQueueUsingStacks_232();
            myQueue.Push(7);

            // Act
            int peek1 = myQueue.Peek();
            int peek2 = myQueue.Peek();

            // Assert - Peek should return same value without removing
            Assert.AreEqual(7, peek1);
            Assert.AreEqual(7, peek2);
            Assert.IsFalse(myQueue.Empty());
        }

        [TestMethod]
        public void Empty_NewQueue_ReturnsTrue()
        {
            // Arrange
            var myQueue = new ImplementQueueUsingStacks_232();

            // Act
            bool isEmpty = myQueue.Empty();

            // Assert
            Assert.IsTrue(isEmpty);
        }

        [TestMethod]
        public void Empty_AfterPushAndPop_ReturnsTrue()
        {
            // Arrange
            var myQueue = new ImplementQueueUsingStacks_232();
            myQueue.Push(1);
            myQueue.Pop();

            // Act
            bool isEmpty = myQueue.Empty();

            // Assert
            Assert.IsTrue(isEmpty);
        }

        [TestMethod]
        public void Empty_WithElements_ReturnsFalse()
        {
            // Arrange
            var myQueue = new ImplementQueueUsingStacks_232();
            myQueue.Push(1);

            // Act
            bool isEmpty = myQueue.Empty();

            // Assert
            Assert.IsFalse(isEmpty);
        }

        [TestMethod]
        public void PushPopSequence_AlternatingOperations_WorksCorrectly()
        {
            // Arrange
            var myQueue = new ImplementQueueUsingStacks_232();

            // Act & Assert
            myQueue.Push(1);
            Assert.AreEqual(1, myQueue.Pop());
            
            myQueue.Push(2);
            myQueue.Push(3);
            Assert.AreEqual(2, myQueue.Pop());
            
            myQueue.Push(4);
            Assert.AreEqual(3, myQueue.Peek());
            Assert.AreEqual(3, myQueue.Pop());
            Assert.AreEqual(4, myQueue.Pop());
            
            Assert.IsTrue(myQueue.Empty());
        }

        [TestMethod]
        public void Push_ManyElements_MaintainsOrder()
        {
            // Arrange
            var myQueue = new ImplementQueueUsingStacks_232();

            // Act
            for (int i = 1; i <= 10; i++)
            {
                myQueue.Push(i);
            }

            // Assert - Should pop in same order as pushed (FIFO)
            for (int i = 1; i <= 10; i++)
            {
                Assert.AreEqual(i, myQueue.Pop());
            }
            Assert.IsTrue(myQueue.Empty());
        }

        [TestMethod]
        public void Peek_AfterMultiplePushes_ReturnsFirstPushed()
        {
            // Arrange
            var myQueue = new ImplementQueueUsingStacks_232();
            myQueue.Push(1);
            myQueue.Push(2);
            myQueue.Push(3);

            // Act
            int front = myQueue.Peek();

            // Assert
            Assert.AreEqual(1, front);
        }

        [TestMethod]
        public void Pop_AllElements_QueueBecomesEmpty()
        {
            // Arrange
            var myQueue = new ImplementQueueUsingStacks_232();
            myQueue.Push(1);
            myQueue.Push(2);
            myQueue.Push(3);

            // Act
            myQueue.Pop();
            myQueue.Pop();
            myQueue.Pop();

            // Assert
            Assert.IsTrue(myQueue.Empty());
        }

        [TestMethod]
        public void PushPop_SingleElement_ReturnsCorrectValue()
        {
            // Arrange
            var myQueue = new ImplementQueueUsingStacks_232();

            // Act
            myQueue.Push(42);
            int result = myQueue.Pop();

            // Assert
            Assert.AreEqual(42, result);
            Assert.IsTrue(myQueue.Empty());
        }

        [TestMethod]
        public void Peek_MultipleCalls_ReturnsSameValue()
        {
            // Arrange
            var myQueue = new ImplementQueueUsingStacks_232();
            myQueue.Push(100);
            myQueue.Push(200);

            // Act
            int peek1 = myQueue.Peek();
            int peek2 = myQueue.Peek();
            int peek3 = myQueue.Peek();

            // Assert
            Assert.AreEqual(100, peek1);
            Assert.AreEqual(100, peek2);
            Assert.AreEqual(100, peek3);
        }

        [TestMethod]
        public void ComplexSequence_MixedOperations_WorksCorrectly()
        {
            // Arrange
            var myQueue = new ImplementQueueUsingStacks_232();

            // Act & Assert - Complex sequence
            myQueue.Push(1);
            myQueue.Push(2);
            Assert.AreEqual(1, myQueue.Peek());
            Assert.AreEqual(1, myQueue.Pop());
            Assert.IsFalse(myQueue.Empty());
            Assert.AreEqual(2, myQueue.Peek());
            myQueue.Push(3);
            Assert.AreEqual(2, myQueue.Peek());
            Assert.AreEqual(2, myQueue.Pop());
            Assert.AreEqual(3, myQueue.Pop());
            Assert.IsTrue(myQueue.Empty());
        }

        [TestMethod]
        public void Push_NegativeNumbers_WorksCorrectly()
        {
            // Arrange
            var myQueue = new ImplementQueueUsingStacks_232();

            // Act
            myQueue.Push(-5);
            myQueue.Push(-10);
            myQueue.Push(0);

            // Assert
            Assert.AreEqual(-5, myQueue.Pop());
            Assert.AreEqual(-10, myQueue.Pop());
            Assert.AreEqual(0, myQueue.Pop());
        }

        [TestMethod]
        public void Push_DuplicateValues_MaintainsAll()
        {
            // Arrange
            var myQueue = new ImplementQueueUsingStacks_232();

            // Act
            myQueue.Push(5);
            myQueue.Push(5);
            myQueue.Push(5);

            // Assert
            Assert.AreEqual(5, myQueue.Pop());
            Assert.AreEqual(5, myQueue.Pop());
            Assert.AreEqual(5, myQueue.Peek());
            Assert.IsFalse(myQueue.Empty());
        }

        [TestMethod]
        public void PushPopPush_RefillAfterEmpty_WorksCorrectly()
        {
            // Arrange
            var myQueue = new ImplementQueueUsingStacks_232();

            // Act & Assert - Empty, fill, empty, fill again
            myQueue.Push(1);
            myQueue.Pop();
            Assert.IsTrue(myQueue.Empty());

            myQueue.Push(2);
            myQueue.Push(3);
            Assert.AreEqual(2, myQueue.Peek());
            Assert.IsFalse(myQueue.Empty());
        }

        [TestMethod]
        public void Peek_AfterPop_ReturnsNewFront()
        {
            // Arrange
            var myQueue = new ImplementQueueUsingStacks_232();
            myQueue.Push(1);
            myQueue.Push(2);
            myQueue.Push(3);

            // Act
            myQueue.Pop();
            int newFront = myQueue.Peek();

            // Assert
            Assert.AreEqual(2, newFront);
        }

        [TestMethod]
        public void LargeNumbers_WorksCorrectly()
        {
            // Arrange
            var myQueue = new ImplementQueueUsingStacks_232();

            // Act
            myQueue.Push(int.MaxValue);
            myQueue.Push(int.MinValue);

            // Assert
            Assert.AreEqual(int.MaxValue, myQueue.Pop());
            Assert.AreEqual(int.MinValue, myQueue.Peek());
        }

        [TestMethod]
        public void FIFOBehavior_VerifyQueueSemantics()
        {
            // Arrange
            var myQueue = new ImplementQueueUsingStacks_232();

            // Act
            myQueue.Push(1);
            myQueue.Push(2);
            myQueue.Push(3);
            myQueue.Push(4);
            myQueue.Push(5);

            // Assert - FIFO: first pushed should be first popped
            Assert.AreEqual(1, myQueue.Pop());
            Assert.AreEqual(2, myQueue.Pop());
            
            myQueue.Push(6);
            myQueue.Push(7);
            
            Assert.AreEqual(3, myQueue.Pop());
            Assert.AreEqual(4, myQueue.Pop());
            Assert.AreEqual(5, myQueue.Pop());
            Assert.AreEqual(6, myQueue.Pop());
            Assert.AreEqual(7, myQueue.Pop());
            Assert.IsTrue(myQueue.Empty());
        }

        [TestMethod]
        public void PeekPop_Interleaved_MaintainsConsistency()
        {
            // Arrange
            var myQueue = new ImplementQueueUsingStacks_232();
            myQueue.Push(10);
            myQueue.Push(20);
            myQueue.Push(30);

            // Act & Assert
            Assert.AreEqual(10, myQueue.Peek());
            Assert.AreEqual(10, myQueue.Pop());
            Assert.AreEqual(20, myQueue.Peek());
            myQueue.Push(40);
            Assert.AreEqual(20, myQueue.Peek());
            Assert.AreEqual(20, myQueue.Pop());
            Assert.AreEqual(30, myQueue.Peek());
        }

        [TestMethod]
        public void RepeatPushPop_StressTest_WorksCorrectly()
        {
            // Arrange
            var myQueue = new ImplementQueueUsingStacks_232();

            // Act & Assert - Repeated operations
            for (int i = 0; i < 50; i++)
            {
                myQueue.Push(i);
            }

            for (int i = 0; i < 50; i++)
            {
                Assert.AreEqual(i, myQueue.Pop());
            }

            Assert.IsTrue(myQueue.Empty());
        }

        [TestMethod]
        public void PushAfterPartialPop_MaintainsCorrectOrder()
        {
            // Arrange
            var myQueue = new ImplementQueueUsingStacks_232();

            // Act
            myQueue.Push(1);
            myQueue.Push(2);
            myQueue.Push(3);
            myQueue.Pop(); // Remove 1
            myQueue.Push(4);
            myQueue.Push(5);

            // Assert - Order should be: 2, 3, 4, 5
            Assert.AreEqual(2, myQueue.Pop());
            Assert.AreEqual(3, myQueue.Pop());
            Assert.AreEqual(4, myQueue.Pop());
            Assert.AreEqual(5, myQueue.Pop());
            Assert.IsTrue(myQueue.Empty());
        }
    }
}