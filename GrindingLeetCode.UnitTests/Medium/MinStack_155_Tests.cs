using LeetCodeProblems;
using LeetCodeProblems.Interfaces.Medium;
using LeetCodeProblems.VisualBasic.Stack;

namespace GrindingLeetCode.UnitTests.Medium
{
    [TestClass]
    public class MinStack_155_Tests
    {
        public static IEnumerable<object[]> GetImplementations()
        {
            //yield return new object[] { new MinStack_155() };
            yield return new object[] { new MinStackVBSolution_155() };
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void MinStack_Example1_WorksCorrectly(IMinStack_155 minStack)
        {
            // Arrange & Act
            minStack.Push(-2);
            minStack.Push(0);
            minStack.Push(-3);

            // Assert
            Assert.AreEqual(-3, minStack.GetMin()); // return -3
            minStack.Pop();
            Assert.AreEqual(0, minStack.Top());      // return 0
            Assert.AreEqual(-2, minStack.GetMin()); // return -2
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Push_SingleElement_GetMinReturnsIt(IMinStack_155 minStack)
        {
            // Act
            minStack.Push(5);

            // Assert
            Assert.AreEqual(5, minStack.GetMin());
            Assert.AreEqual(5, minStack.Top());
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Push_MultipleElements_GetMinReturnsSmallest(IMinStack_155 minStack)
        {
            // Act
            minStack.Push(10);
            minStack.Push(5);
            minStack.Push(20);

            // Assert
            Assert.AreEqual(5, minStack.GetMin());
            Assert.AreEqual(20, minStack.Top());
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Push_DecreasingOrder_GetMinUpdatesCorrectly(IMinStack_155 minStack)
        {
            // Act & Assert
            minStack.Push(10);
            Assert.AreEqual(10, minStack.GetMin());

            minStack.Push(5);
            Assert.AreEqual(5, minStack.GetMin());

            minStack.Push(1);
            Assert.AreEqual(1, minStack.GetMin());
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Push_IncreasingOrder_GetMinStaysTheSame(IMinStack_155 minStack)
        {
            // Act & Assert
            minStack.Push(1);
            Assert.AreEqual(1, minStack.GetMin());

            minStack.Push(5);
            Assert.AreEqual(1, minStack.GetMin());

            minStack.Push(10);
            Assert.AreEqual(1, minStack.GetMin());
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Pop_RemovesTopElement_UpdatesMinCorrectly(IMinStack_155 minStack)
        {
            // Arrange
            minStack.Push(5);
            minStack.Push(1);
            minStack.Push(10);

            // Act
            minStack.Pop(); // Remove 10

            // Assert
            Assert.AreEqual(1, minStack.Top());
            Assert.AreEqual(1, minStack.GetMin());
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Pop_RemovesMinElement_UpdatesMinToNextSmallest(IMinStack_155 minStack)
        {
            // Arrange
            minStack.Push(5);
            minStack.Push(1);
            minStack.Push(10);

            // Act
            minStack.Pop(); // Remove 10
            minStack.Pop(); // Remove 1 (the min)

            // Assert
            Assert.AreEqual(5, minStack.Top());
            Assert.AreEqual(5, minStack.GetMin());
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Top_DoesNotRemoveElement(IMinStack_155 minStack)
        {
            // Arrange
            minStack.Push(7);
            minStack.Push(3);

            // Act
            int top1 = minStack.Top();
            int top2 = minStack.Top();

            // Assert
            Assert.AreEqual(3, top1);
            Assert.AreEqual(3, top2);
            Assert.AreEqual(3, minStack.GetMin());
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void GetMin_CalledMultipleTimes_ReturnsSameValue(IMinStack_155 minStack)
        {
            // Arrange
            minStack.Push(10);
            minStack.Push(5);
            minStack.Push(20);

            // Act
            int min1 = minStack.GetMin();
            int min2 = minStack.GetMin();
            int min3 = minStack.GetMin();

            // Assert
            Assert.AreEqual(5, min1);
            Assert.AreEqual(5, min2);
            Assert.AreEqual(5, min3);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void NegativeNumbers_WorksCorrectly(IMinStack_155 minStack)
        {
            // Act
            minStack.Push(-5);
            minStack.Push(-10);
            minStack.Push(-3);

            // Assert
            Assert.AreEqual(-10, minStack.GetMin());
            Assert.AreEqual(-3, minStack.Top());
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void MixedPositiveNegative_GetMinWorksCorrectly(IMinStack_155 minStack)
        {
            // Act
            minStack.Push(10);
            minStack.Push(-5);
            minStack.Push(20);
            minStack.Push(-10);

            // Assert
            Assert.AreEqual(-10, minStack.GetMin());
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void DuplicateMinValues_HandlesCorrectly(IMinStack_155 minStack)
        {
            // Act
            minStack.Push(5);
            minStack.Push(1);
            minStack.Push(1);
            minStack.Push(1);

            // Assert
            Assert.AreEqual(1, minStack.GetMin());
            
            minStack.Pop();
            Assert.AreEqual(1, minStack.GetMin());
            
            minStack.Pop();
            Assert.AreEqual(1, minStack.GetMin());
            
            minStack.Pop();
            Assert.AreEqual(5, minStack.GetMin());
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void AllSameValues_GetMinReturnsValue(IMinStack_155 minStack)
        {
            // Act
            minStack.Push(3);
            minStack.Push(3);
            minStack.Push(3);

            // Assert
            Assert.AreEqual(3, minStack.GetMin());
            Assert.AreEqual(3, minStack.Top());
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void ComplexSequence_PushPopMixed_WorksCorrectly(IMinStack_155 minStack)
        {
            // Act & Assert
            minStack.Push(5);
            Assert.AreEqual(5, minStack.GetMin());
            
            minStack.Push(3);
            Assert.AreEqual(3, minStack.GetMin());
            
            minStack.Push(7);
            Assert.AreEqual(3, minStack.GetMin());
            
            minStack.Pop(); // Remove 7
            Assert.AreEqual(3, minStack.GetMin());
            
            minStack.Pop(); // Remove 3
            Assert.AreEqual(5, minStack.GetMin());
            
            minStack.Push(1);
            Assert.AreEqual(1, minStack.GetMin());
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void ZeroValue_HandlesCorrectly(IMinStack_155 minStack)
        {
            // Act
            minStack.Push(0);
            minStack.Push(5);
            minStack.Push(-3);

            // Assert
            Assert.AreEqual(-3, minStack.GetMin());
            
            minStack.Pop();
            Assert.AreEqual(0, minStack.GetMin());
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void LargeNumbers_WorksCorrectly(IMinStack_155 minStack)
        {
            // Act
            minStack.Push(int.MaxValue);
            minStack.Push(int.MinValue);
            minStack.Push(0);

            // Assert
            Assert.AreEqual(int.MinValue, minStack.GetMin());
            Assert.AreEqual(0, minStack.Top());
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void PushPopSequence_MaintainsCorrectMin(IMinStack_155 minStack)
        {
            // Act & Assert
            minStack.Push(10);
            minStack.Push(20);
            minStack.Push(5);
            Assert.AreEqual(5, minStack.GetMin());
            
            minStack.Pop(); // Remove 5
            Assert.AreEqual(10, minStack.GetMin());
            
            minStack.Push(3);
            Assert.AreEqual(3, minStack.GetMin());
            
            minStack.Push(30);
            Assert.AreEqual(3, minStack.GetMin());
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void TopAfterPop_ReturnsNewTop(IMinStack_155 minStack)
        {
            // Arrange
            minStack.Push(1);
            minStack.Push(2);
            minStack.Push(3);

            // Act
            minStack.Pop();
            int newTop = minStack.Top();

            // Assert
            Assert.AreEqual(2, newTop);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void MinChangesAfterMultiplePops(IMinStack_155 minStack)
        {
            // Arrange
            minStack.Push(5);
            minStack.Push(3);
            minStack.Push(7);
            minStack.Push(1);
            minStack.Push(9);

            // Act & Assert
            Assert.AreEqual(1, minStack.GetMin());
            
            minStack.Pop(); // Remove 9
            Assert.AreEqual(1, minStack.GetMin());
            
            minStack.Pop(); // Remove 1
            Assert.AreEqual(3, minStack.GetMin());
            
            minStack.Pop(); // Remove 7
            Assert.AreEqual(3, minStack.GetMin());
            
            minStack.Pop(); // Remove 3
            Assert.AreEqual(5, minStack.GetMin());
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void AlternatingMinMax_TracksMinCorrectly(IMinStack_155 minStack)
        {
            // Act
            minStack.Push(100);
            minStack.Push(1);
            minStack.Push(200);
            minStack.Push(2);
            minStack.Push(300);

            // Assert
            Assert.AreEqual(1, minStack.GetMin());
            Assert.AreEqual(300, minStack.Top());
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void StressTest_ManyOperations_WorksCorrectly(IMinStack_155 minStack)
        {
            // Act - Push many values
            for (int i = 100; i >= 1; i--)
            {
                minStack.Push(i);
            }

            // Assert - Min should be 1
            Assert.AreEqual(1, minStack.GetMin());
            Assert.AreEqual(1, minStack.Top());

            // Pop half
            for (int i = 0; i < 50; i++)
            {
                minStack.Pop();
            }

            // Assert - Min should be 51
            Assert.AreEqual(51, minStack.GetMin());
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void MinAtBottom_StaysMinThroughoutPushes(IMinStack_155 minStack)
        {
            // Act
            minStack.Push(1);
            Assert.AreEqual(1, minStack.GetMin());

            for (int i = 2; i <= 10; i++)
            {
                minStack.Push(i);
                Assert.AreEqual(1, minStack.GetMin());
            }
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void MinAtTop_PopUpdatesMinCorrectly(IMinStack_155 minStack)
        {
            // Arrange
            minStack.Push(10);
            minStack.Push(9);
            minStack.Push(8);
            minStack.Push(7);

            // Act & Assert
            Assert.AreEqual(7, minStack.GetMin());
            minStack.Pop();
            
            Assert.AreEqual(8, minStack.GetMin());
            minStack.Pop();
            
            Assert.AreEqual(9, minStack.GetMin());
            minStack.Pop();
            
            Assert.AreEqual(10, minStack.GetMin());
        }
    }
}