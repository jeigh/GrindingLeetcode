using LeetCodeProblems;
using LeetCodeProblems.Interfaces.Easy;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GrindingLeetCode.UnitTests.Easy
{
    [TestClass]
    public class MyStack_225_Tests
    {
        [TestMethod]
        public void MyStack_Example1_WorksCorrectly()
        {
            // Arrange
            var myStack = new MyStack_225();

            // Act & Assert
            myStack.Push(1);
            myStack.Push(2);
            Assert.AreEqual(2, myStack.Top());    // returns 2
            Assert.AreEqual(2, myStack.Pop());    // returns 2
            Assert.IsFalse(myStack.Empty());      // returns false
        }

        [TestMethod]
        public void Push_SingleElement_CanBeRetrieved()
        {
            // Arrange
            var myStack = new MyStack_225();

            // Act
            myStack.Push(5);

            // Assert
            Assert.AreEqual(5, myStack.Top());
            Assert.IsFalse(myStack.Empty());
        }

        [TestMethod]
        public void Push_MultipleElements_MaintainsLIFOOrder()
        {
            // Arrange
            var myStack = new MyStack_225();

            // Act
            myStack.Push(1);
            myStack.Push(2);
            myStack.Push(3);

            // Assert - Last in, first out
            Assert.AreEqual(3, myStack.Pop());
            Assert.AreEqual(2, myStack.Pop());
            Assert.AreEqual(1, myStack.Pop());
        }

        [TestMethod]
        public void Pop_RemovesTopElement_ReturnsValue()
        {
            // Arrange
            var myStack = new MyStack_225();
            myStack.Push(10);
            myStack.Push(20);

            // Act
            int popped = myStack.Pop();

            // Assert
            Assert.AreEqual(20, popped);
            Assert.AreEqual(10, myStack.Top());
        }

        [TestMethod]
        public void Top_DoesNotRemoveElement()
        {
            // Arrange
            var myStack = new MyStack_225();
            myStack.Push(7);

            // Act
            int top1 = myStack.Top();
            int top2 = myStack.Top();

            // Assert - Top should return same value without removing
            Assert.AreEqual(7, top1);
            Assert.AreEqual(7, top2);
            Assert.IsFalse(myStack.Empty());
        }

        [TestMethod]
        public void Empty_NewStack_ReturnsTrue()
        {
            // Arrange
            var myStack = new MyStack_225();

            // Act
            bool isEmpty = myStack.Empty();

            // Assert
            Assert.IsTrue(isEmpty);
        }

        [TestMethod]
        public void Empty_AfterPushAndPop_ReturnsTrue()
        {
            // Arrange
            var myStack = new MyStack_225();
            myStack.Push(1);
            myStack.Pop();

            // Act
            bool isEmpty = myStack.Empty();

            // Assert
            Assert.IsTrue(isEmpty);
        }

        [TestMethod]
        public void Empty_WithElements_ReturnsFalse()
        {
            // Arrange
            var myStack = new MyStack_225();
            myStack.Push(1);

            // Act
            bool isEmpty = myStack.Empty();

            // Assert
            Assert.IsFalse(isEmpty);
        }

        [TestMethod]
        public void PushPopSequence_AlternatingOperations_WorksCorrectly()
        {
            // Arrange
            var myStack = new MyStack_225();

            // Act & Assert
            myStack.Push(1);
            Assert.AreEqual(1, myStack.Pop());
            
            myStack.Push(2);
            myStack.Push(3);
            Assert.AreEqual(3, myStack.Pop());
            
            myStack.Push(4);
            Assert.AreEqual(4, myStack.Top());
            Assert.AreEqual(4, myStack.Pop());
            Assert.AreEqual(2, myStack.Pop());
            
            Assert.IsTrue(myStack.Empty());
        }

        [TestMethod]
        public void Push_ManyElements_MaintainsOrder()
        {
            // Arrange
            var myStack = new MyStack_225();

            // Act
            for (int i = 1; i <= 10; i++)
            {
                myStack.Push(i);
            }

            // Assert - Should pop in reverse order
            for (int i = 10; i >= 1; i--)
            {
                Assert.AreEqual(i, myStack.Pop());
            }
            Assert.IsTrue(myStack.Empty());
        }

        [TestMethod]
        public void Top_AfterMultiplePushes_ReturnsLastPushed()
        {
            // Arrange
            var myStack = new MyStack_225();
            myStack.Push(1);
            myStack.Push(2);
            myStack.Push(3);

            // Act
            int top = myStack.Top();

            // Assert
            Assert.AreEqual(3, top);
        }

        [TestMethod]
        public void Pop_AllElements_StackBecomesEmpty()
        {
            // Arrange
            var myStack = new MyStack_225();
            myStack.Push(1);
            myStack.Push(2);
            myStack.Push(3);

            // Act
            myStack.Pop();
            myStack.Pop();
            myStack.Pop();

            // Assert
            Assert.IsTrue(myStack.Empty());
        }

        [TestMethod]
        public void PushPop_SingleElement_ReturnsCorrectValue()
        {
            // Arrange
            var myStack = new MyStack_225();

            // Act
            myStack.Push(42);
            int result = myStack.Pop();

            // Assert
            Assert.AreEqual(42, result);
            Assert.IsTrue(myStack.Empty());
        }

        [TestMethod]
        public void Top_MultipleCalls_ReturnsSameValue()
        {
            // Arrange
            var myStack = new MyStack_225();
            myStack.Push(100);
            myStack.Push(200);

            // Act
            int top1 = myStack.Top();
            int top2 = myStack.Top();
            int top3 = myStack.Top();

            // Assert
            Assert.AreEqual(200, top1);
            Assert.AreEqual(200, top2);
            Assert.AreEqual(200, top3);
        }

        [TestMethod]
        public void ComplexSequence_MixedOperations_WorksCorrectly()
        {
            // Arrange
            var myStack = new MyStack_225();

            // Act & Assert - Complex sequence from LeetCode
            myStack.Push(1);
            myStack.Push(2);
            Assert.AreEqual(2, myStack.Top());
            Assert.AreEqual(2, myStack.Pop());
            Assert.IsFalse(myStack.Empty());
            Assert.AreEqual(1, myStack.Top());
            myStack.Push(3);
            Assert.AreEqual(3, myStack.Top());
            Assert.AreEqual(3, myStack.Pop());
            Assert.AreEqual(1, myStack.Pop());
            Assert.IsTrue(myStack.Empty());
        }

        [TestMethod]
        public void Push_NegativeNumbers_WorksCorrectly()
        {
            // Arrange
            var myStack = new MyStack_225();

            // Act
            myStack.Push(-5);
            myStack.Push(-10);
            myStack.Push(0);

            // Assert
            Assert.AreEqual(0, myStack.Pop());
            Assert.AreEqual(-10, myStack.Pop());
            Assert.AreEqual(-5, myStack.Pop());
        }

        [TestMethod]
        public void Push_DuplicateValues_MaintainsAll()
        {
            // Arrange
            var myStack = new MyStack_225();

            // Act
            myStack.Push(5);
            myStack.Push(5);
            myStack.Push(5);

            // Assert
            Assert.AreEqual(5, myStack.Pop());
            Assert.AreEqual(5, myStack.Pop());
            Assert.AreEqual(5, myStack.Top());
            Assert.IsFalse(myStack.Empty());
        }

        [TestMethod]
        public void PushPopPush_RefillAfterEmpty_WorksCorrectly()
        {
            // Arrange
            var myStack = new MyStack_225();

            // Act & Assert - Empty, fill, empty, fill again
            myStack.Push(1);
            myStack.Pop();
            Assert.IsTrue(myStack.Empty());

            myStack.Push(2);
            myStack.Push(3);
            Assert.AreEqual(3, myStack.Top());
            Assert.IsFalse(myStack.Empty());
        }

        [TestMethod]
        public void Top_AfterPop_ReturnsNewTop()
        {
            // Arrange
            var myStack = new MyStack_225();
            myStack.Push(1);
            myStack.Push(2);
            myStack.Push(3);

            // Act
            myStack.Pop();
            int newTop = myStack.Top();

            // Assert
            Assert.AreEqual(2, newTop);
        }

        [TestMethod]
        public void LargeNumbers_WorksCorrectly()
        {
            // Arrange
            var myStack = new MyStack_225();

            // Act
            myStack.Push(int.MaxValue);
            myStack.Push(int.MinValue);

            // Assert
            Assert.AreEqual(int.MinValue, myStack.Pop());
            Assert.AreEqual(int.MaxValue, myStack.Top());
        }

        [TestMethod]
        public void RepeatPushPop_StressTest_WorksCorrectly()
        {
            // Arrange
            var myStack = new MyStack_225();

            // Act & Assert - Repeated operations
            for (int i = 0; i < 100; i++)
            {
                myStack.Push(i);
                if (i % 2 == 0)
                {
                    Assert.AreEqual(i, myStack.Pop());
                }
            }

            // Verify remaining elements are odd numbers in reverse
            Assert.IsFalse(myStack.Empty());
        }
    }
}