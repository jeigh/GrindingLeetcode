using LeetCodeProblems.CSharp.BinarySearch;
using LeetCodeProblems.CSharp.BruteForce;
using LeetCodeProblems.CSharp.SlidingWindow;
using LeetCodeProblems.Interfaces.Medium;

namespace GrindingLeetCode.UnitTests.Medium
{
    [TestClass]
    public class FindKClosestElements_658_Tests
    {
        public static IEnumerable<object[]> GetImplementations()
        {
            yield return new object[] { new FindKClosestElementsSlidingWindow_658() };
            yield return new object[] { new FindKClosestElementsBruteForce_658() };
            yield return new object[] { new FindKClosestElementLowerBoundBinarySearch_658() };
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void FindClosestElements_Example1_ReturnsCorrectElements(IFindKClosestElements_658 solution)
        {
            // Arrange
            int[] arr = { 1, 2, 3, 4, 5 };
            int k = 4;
            int x = 3;

            // Act
            IList<int> result = solution.FindClosestElements(arr, k, x);

            // Assert - closest 4 elements to 3 are [1,2,3,4]
            CollectionAssert.AreEqual(new[] { 1, 2, 3, 4 }, result.ToArray());
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void FindClosestElements_Example2_ReturnsCorrectElements(IFindKClosestElements_658 solution)
        {
            // Arrange
            int[] arr = { 1, 2, 3, 4, 5 };
            int k = 4;
            int x = -1;

            // Act
            IList<int> result = solution.FindClosestElements(arr, k, x);

            // Assert - closest 4 elements to -1 are [1,2,3,4]
            CollectionAssert.AreEqual(new[] { 1, 2, 3, 4 }, result.ToArray());
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void FindClosestElements_XAtBeginning_ReturnsFirstKElements(IFindKClosestElements_658 solution)
        {
            // Arrange
            int[] arr = { 1, 2, 3, 4, 5, 6, 7 };
            int k = 3;
            int x = 0;

            // Act
            IList<int> result = solution.FindClosestElements(arr, k, x);

            // Assert - closest 3 elements to 0 are [1,2,3]
            CollectionAssert.AreEqual(new[] { 1, 2, 3 }, result.ToArray());
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void FindClosestElements_XAtEnd_ReturnsLastKElements(IFindKClosestElements_658 solution)
        {
            // Arrange
            int[] arr = { 1, 2, 3, 4, 5, 6, 7 };
            int k = 3;
            int x = 10;

            // Act
            IList<int> result = solution.FindClosestElements(arr, k, x);

            // Assert - closest 3 elements to 10 are [5,6,7]
            CollectionAssert.AreEqual(new[] { 5, 6, 7 }, result.ToArray());
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void FindClosestElements_XInArray_ReturnsElementsAroundX(IFindKClosestElements_658 solution)
        {
            // Arrange
            int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int k = 3;
            int x = 5;

            // Act
            IList<int> result = solution.FindClosestElements(arr, k, x);

            // Assert - closest 3 elements to 5 are [4,5,6]
            CollectionAssert.AreEqual(new[] { 4, 5, 6 }, result.ToArray());
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void FindClosestElements_XNotInArray_ReturnsClosestElements(IFindKClosestElements_658 solution)
        {
            // Arrange
            int[] arr = { 1, 3, 5, 7, 9 };
            int k = 3;
            int x = 6;

            // Act
            IList<int> result = solution.FindClosestElements(arr, k, x);

            // Assert - closest 3 elements to 6 are [5,7,9]
            CollectionAssert.AreEqual(new[] { 3, 5, 7 }, result.ToArray());
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void FindClosestElements_KEqualsArrayLength_ReturnsEntireArray(IFindKClosestElements_658 solution)
        {
            // Arrange
            int[] arr = { 1, 2, 3, 4 };
            int k = 4;
            int x = 5;

            // Act
            IList<int> result = solution.FindClosestElements(arr, k, x);

            // Assert - all elements are returned
            CollectionAssert.AreEqual(new[] { 1, 2, 3, 4 }, result.ToArray());
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void FindClosestElements_SingleElement_ReturnsThatElement(IFindKClosestElements_658 solution)
        {
            // Arrange
            int[] arr = { 5 };
            int k = 1;
            int x = 3;

            // Act
            IList<int> result = solution.FindClosestElements(arr, k, x);

            // Assert
            CollectionAssert.AreEqual(new[] { 5 }, result.ToArray());
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void FindClosestElements_TieBreaker_ReturnsSmallerElement(IFindKClosestElements_658 solution)
        {
            // Arrange
            int[] arr = { 1, 1, 2, 3, 4, 5 };
            int k = 4;
            int x = 3;

            // Act
            IList<int> result = solution.FindClosestElements(arr, k, x);

            // Assert - when tied, prefer smaller element
            CollectionAssert.AreEqual(new[] { 1, 2, 3, 4 }, result.ToArray());
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void FindClosestElements_NegativeNumbers_WorksCorrectly(IFindKClosestElements_658 solution)
        {
            // Arrange
            int[] arr = { -5, -3, -1, 0, 1, 3, 5 };
            int k = 3;
            int x = 0;

            // Act
            IList<int> result = solution.FindClosestElements(arr, k, x);

            // Assert - closest 3 elements to 0 are [-1,0,1]
            CollectionAssert.AreEqual(new[] { -1, 0, 1 }, result.ToArray());
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void FindClosestElements_DuplicateElements_HandlesCorrectly(IFindKClosestElements_658 solution)
        {
            // Arrange
            int[] arr = { 1, 2, 2, 2, 3, 4 };
            int k = 3;
            int x = 2;

            // Act
            IList<int> result = solution.FindClosestElements(arr, k, x);

            // Assert - returns the closest 3 elements including duplicates
            CollectionAssert.AreEqual(new[] { 2, 2, 2 }, result.ToArray());
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void FindClosestElements_LargeArray_ReturnsMiddleWindow(IFindKClosestElements_658 solution)
        {
            // Arrange
            int[] arr = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int k = 5;
            int x = 5;

            // Act
            IList<int> result = solution.FindClosestElements(arr, k, x);

            // Assert - closest 5 elements to 5 are [3,4,5,6,7]
            CollectionAssert.AreEqual(new[] { 3, 4, 5, 6, 7 }, result.ToArray());
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void FindClosestElements_XBetweenTwoElements_ReturnsCorrectWindow(IFindKClosestElements_658 solution)
        {
            // Arrange
            int[] arr = { 1, 3, 5, 7, 9, 11 };
            int k = 4;
            int x = 6;

            // Act
            IList<int> result = solution.FindClosestElements(arr, k, x);

            // Assert - closest 4 elements to 6: distances are |1-6|=5, |3-6|=3, |5-6|=1, |7-6|=1, |9-6|=3, |11-6|=5
            // So [3,5,7,9] or [5,7] are closest, prefer left when tied
            CollectionAssert.AreEqual(new[] { 3, 5, 7, 9 }, result.ToArray());
        }
    }
}