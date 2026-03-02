using LeetCodeProblems.CSharp.HashingOrArrays;
using LeetCodeProblems.CSharp.Queue;
using LeetCodeProblems.Interfaces.Easy;
using LeetCodeProblems.VisualBasic;

namespace GrindingLeetCode.UnitTests.Easy
{
    [TestClass]
    public class KthLargestElementInAStream_703_Tests
    {
        public static IEnumerable<object[]> GetImplementations()
        {
            yield return new object[] { typeof(KthLargest_List_703), "C# List" };
            yield return new object[] { typeof(KthLargestInAStream_PriorityQueue_CSharp_703), "C# PriorityQueue" };
            yield return new object[] { typeof(KthLargestInAStream_PriorityQueue_VB_703), "VB PriorityQueue" };
        }

        #region Helper Methods

        private IKthLargestElementInAStream_703 CreateInstance(Type implementationType, int k, int[] nums)
        {
            if (implementationType == typeof(KthLargest_List_703))
                return new KthLargest_List_703(k, nums);
            else if (implementationType == typeof(KthLargestInAStream_PriorityQueue_CSharp_703))
                return new KthLargestInAStream_PriorityQueue_CSharp_703(k, nums);
            else if (implementationType == typeof(KthLargestInAStream_PriorityQueue_VB_703))
                return new KthLargestInAStream_PriorityQueue_VB_703(k, nums);
            else
                throw new ArgumentException($"Unknown implementation type: {implementationType.Name}");
        }

        #endregion

        #region LeetCode Examples

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void KthLargest_Example1_ReturnsCorrectSequence(Type implementationType, string solutionName)
        {
            // Input: ["KthLargest", "add", "add", "add", "add", "add"]
            //        [[3, [4, 5, 8, 2]], [3], [5], [10], [9], [4]]
            // Output: [null, 4, 5, 5, 8, 8]
            // Explanation:
            // KthLargest kthLargest = new KthLargest(3, [4, 5, 8, 2]);
            // kthLargest.add(3);   // return 4
            // kthLargest.add(5);   // return 5
            // kthLargest.add(10);  // return 5
            // kthLargest.add(9);   // return 8
            // kthLargest.add(4);   // return 8

            // Arrange
            int k = 3;
            int[] nums = { 4, 5, 8, 2 };
            var kthLargest = CreateInstance(implementationType, k, nums);

            // Act & Assert
            Assert.AreEqual(4, kthLargest.Add(3), $"Failed for {solutionName}");
            Assert.AreEqual(5, kthLargest.Add(5), $"Failed for {solutionName}");
            Assert.AreEqual(5, kthLargest.Add(10), $"Failed for {solutionName}");
            Assert.AreEqual(8, kthLargest.Add(9), $"Failed for {solutionName}");
            Assert.AreEqual(8, kthLargest.Add(4), $"Failed for {solutionName}");
        }

        #endregion

        #region Single Element Stream - K=1

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void KthLargest_K1_EmptyArray_ReturnsAddedValues(Type implementationType, string solutionName)
        {
            // k = 1, empty initial array
            // Each add should return the largest (only) element

            // Arrange
            int k = 1;
            int[] nums = { };
            var kthLargest = CreateInstance(implementationType, k, nums);

            // Act & Assert
            Assert.AreEqual(5, kthLargest.Add(5), $"Failed for {solutionName}");
            Assert.AreEqual(10, kthLargest.Add(10), $"Failed for {solutionName}");
            Assert.AreEqual(10, kthLargest.Add(3), $"Failed for {solutionName}");
            Assert.AreEqual(10, kthLargest.Add(7), $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void KthLargest_K1_WithInitialValues_ReturnsLargest(Type implementationType, string solutionName)
        {
            // k = 1, initial array [3, 5, 2]
            // Should always return the current largest

            // Arrange
            int k = 1;
            int[] nums = { 3, 5, 2 };
            var kthLargest = CreateInstance(implementationType, k, nums);

            // Act & Assert
            Assert.AreEqual(5, kthLargest.Add(1), $"Failed for {solutionName}");
            Assert.AreEqual(6, kthLargest.Add(6), $"Failed for {solutionName}");
            Assert.AreEqual(6, kthLargest.Add(4), $"Failed for {solutionName}");
            Assert.AreEqual(10, kthLargest.Add(10), $"Failed for {solutionName}");
        }

        #endregion

        #region K Equals Array Size

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void KthLargest_KEqualsSizeThree_ReturnsSmallest(Type implementationType, string solutionName)
        {
            // k = 3, initial array of size 3
            // Kth largest = smallest element

            // Arrange
            int k = 3;
            int[] nums = { 5, 10, 15 };
            var kthLargest = CreateInstance(implementationType, k, nums);

            // Act & Assert
            Assert.AreEqual(10, kthLargest.Add(20), $"Failed for {solutionName}");
            Assert.AreEqual(15, kthLargest.Add(25), $"Failed for {solutionName}");
            Assert.AreEqual(15, kthLargest.Add(12), $"Failed for {solutionName}");
        }

        #endregion

        #region Empty Initial Array

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void KthLargest_EmptyArray_K2_BuildsStream(Type implementationType, string solutionName)
        {
            // k = 2, empty initial array
            // Build up the stream from scratch

            // Arrange
            int k = 2;
            int[] nums = { };
            var kthLargest = CreateInstance(implementationType, k, nums);

            // Act & Assert - List returns 0 when k > count, PriorityQueue returns min element
            var result1 = kthLargest.Add(3);
            var result2 = kthLargest.Add(5);
            var result3 = kthLargest.Add(10);
            var result4 = kthLargest.Add(2);

            Assert.AreEqual(3, result2, $"After 2 elements, 2nd largest should be 3 for {solutionName}");
            Assert.AreEqual(5, result3, $"After 3 elements, 2nd largest should be 5 for {solutionName}");
            Assert.AreEqual(5, result4, $"After 4 elements, 2nd largest should be 5 for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void KthLargest_EmptyArray_K3_BuildsGradually(Type implementationType, string solutionName)
        {
            // k = 3, empty array, build up gradually

            // Arrange
            int k = 3;
            int[] nums = { };
            var kthLargest = CreateInstance(implementationType, k, nums);

            // Act & Assert
            var result1 = kthLargest.Add(1);
            var result2 = kthLargest.Add(2);
            var result3 = kthLargest.Add(3);
            var result4 = kthLargest.Add(4);
            var result5 = kthLargest.Add(5);

            Assert.AreEqual(1, result3, $"After 3 elements, 3rd largest should be 1 for {solutionName}");
            Assert.AreEqual(2, result4, $"After 4 elements, 3rd largest should be 2 for {solutionName}");
            Assert.AreEqual(3, result5, $"After 5 elements, 3rd largest should be 3 for {solutionName}");
        }

        #endregion

        #region Duplicate Values

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void KthLargest_DuplicateValues_K2_HandlesCorrectly(Type implementationType, string solutionName)
        {
            // k = 2, with duplicate values

            // Arrange
            int k = 2;
            int[] nums = { 5, 5, 5 };
            var kthLargest = CreateInstance(implementationType, k, nums);

            // Act & Assert
            Assert.AreEqual(5, kthLargest.Add(5), $"Failed for {solutionName}");
            Assert.AreEqual(5, kthLargest.Add(3), $"Failed for {solutionName}");
            Assert.AreEqual(5, kthLargest.Add(10), $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void KthLargest_AllDuplicates_K3_ReturnsConstant(Type implementationType, string solutionName)
        {
            // All values are the same

            // Arrange
            int k = 3;
            int[] nums = { 7, 7, 7, 7 };
            var kthLargest = CreateInstance(implementationType, k, nums);

            // Act & Assert
            Assert.AreEqual(7, kthLargest.Add(7), $"Failed for {solutionName}");
            Assert.AreEqual(7, kthLargest.Add(7), $"Failed for {solutionName}");
            Assert.AreEqual(7, kthLargest.Add(7), $"Failed for {solutionName}");
        }

        #endregion

        #region Ascending/Descending Order

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void KthLargest_AddInAscendingOrder_K2_ReturnsCorrect(Type implementationType, string solutionName)
        {
            // Add values in ascending order

            // Arrange
            int k = 2;
            int[] nums = { 1, 2, 3 };
            var kthLargest = CreateInstance(implementationType, k, nums);

            // Act & Assert
            Assert.AreEqual(3, kthLargest.Add(4), $"Failed for {solutionName}");
            Assert.AreEqual(4, kthLargest.Add(5), $"Failed for {solutionName}");
            Assert.AreEqual(5, kthLargest.Add(6), $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void KthLargest_AddInDescendingOrder_K2_ReturnsCorrect(Type implementationType, string solutionName)
        {
            // Add values in descending order

            // Arrange
            int k = 2;
            int[] nums = { 10, 8, 6 };
            var kthLargest = CreateInstance(implementationType, k, nums);

            // Act & Assert
            Assert.AreEqual(8, kthLargest.Add(4), $"Failed for {solutionName}");
            Assert.AreEqual(8, kthLargest.Add(2), $"Failed for {solutionName}");
            Assert.AreEqual(8, kthLargest.Add(1), $"Failed for {solutionName}");
        }

        #endregion

        #region Negative Numbers

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void KthLargest_NegativeNumbers_K2_HandlesCorrectly(Type implementationType, string solutionName)
        {
            // Test with negative numbers

            // Arrange
            int k = 2;
            int[] nums = { -5, -2, -10 };
            var kthLargest = CreateInstance(implementationType, k, nums);

            // Act & Assert
            Assert.AreEqual(-3, kthLargest.Add(-3), $"Failed for {solutionName}");
            Assert.AreEqual(-2, kthLargest.Add(0), $"Failed for {solutionName}");
            Assert.AreEqual(-2, kthLargest.Add(-7), $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void KthLargest_MixedPositiveNegative_K3_HandlesCorrectly(Type implementationType, string solutionName)
        {
            // Mix of positive and negative numbers

            // Arrange
            int k = 3;
            int[] nums = { -1, 5, -3, 2 };
            var kthLargest = CreateInstance(implementationType, k, nums);

            // Act & Assert
            Assert.AreEqual(0, kthLargest.Add(0), $"Failed for {solutionName}");
            Assert.AreEqual(0, kthLargest.Add(-2), $"Failed for {solutionName}");
            Assert.AreEqual(2, kthLargest.Add(10), $"Failed for {solutionName}");
        }

        #endregion

        #region Large K Values

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void KthLargest_LargeK_ReturnsSmallestInitially(Type implementationType, string solutionName)
        {
            // k = 5 with only 3 elements initially

            // Arrange
            int k = 5;
            int[] nums = { 10, 20, 30 };
            var kthLargest = CreateInstance(implementationType, k, nums);

            // Act & Assert
            var result1 = kthLargest.Add(15);
            var result2 = kthLargest.Add(5);
            var result3 = kthLargest.Add(25);

            // After all adds: [5, 10, 15, 20, 25, 30], 5th largest = 10
            Assert.AreEqual(10, result3, $"Failed for {solutionName}");
        }

        #endregion

        #region Single Initial Value

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void KthLargest_SingleInitialValue_K1_Works(Type implementationType, string solutionName)
        {
            // k = 1, single initial value

            // Arrange
            int k = 1;
            int[] nums = { 100 };
            var kthLargest = CreateInstance(implementationType, k, nums);

            // Act & Assert
            Assert.AreEqual(100, kthLargest.Add(50), $"Failed for {solutionName}");
            Assert.AreEqual(100, kthLargest.Add(75), $"Failed for {solutionName}");
            Assert.AreEqual(200, kthLargest.Add(200), $"Failed for {solutionName}");
            Assert.AreEqual(200, kthLargest.Add(150), $"Failed for {solutionName}");
        }

        #endregion

        #region Edge Cases with Zeros

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void KthLargest_WithZeros_K2_HandlesCorrectly(Type implementationType, string solutionName)
        {
            // Test with zeros in the stream

            // Arrange
            int k = 2;
            int[] nums = { 0, 5, -1 };
            var kthLargest = CreateInstance(implementationType, k, nums);

            // Act & Assert
            Assert.AreEqual(0, kthLargest.Add(0), $"Failed for {solutionName}");
            Assert.AreEqual(5, kthLargest.Add(10), $"Failed for {solutionName}");
            Assert.AreEqual(5, kthLargest.Add(3), $"Failed for {solutionName}");
        }

        #endregion

        #region Large Arrays

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void KthLargest_LargeInitialArray_K5_HandlesCorrectly(Type implementationType, string solutionName)
        {
            // Large initial array

            // Arrange
            int k = 5;
            int[] nums = { 10, 20, 30, 40, 50, 60, 70, 80, 90, 100 };
            var kthLargest = CreateInstance(implementationType, k, nums);

            // Act & Assert
            Assert.AreEqual(60, kthLargest.Add(55), $"Failed for {solutionName}");
            Assert.AreEqual(65, kthLargest.Add(65), $"Failed for {solutionName}");
            Assert.AreEqual(70, kthLargest.Add(75), $"Failed for {solutionName}");
        }

        #endregion

        #region Random Order

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void KthLargest_RandomOrder_K3_HandlesCorrectly(Type implementationType, string solutionName)
        {
            // Add values in random order

            // Arrange
            int k = 3;
            int[] nums = { 7, 2, 9, 1 };
            var kthLargest = CreateInstance(implementationType, k, nums);

            // Act & Assert
            Assert.AreEqual(5, kthLargest.Add(5), $"Failed for {solutionName}");
            Assert.AreEqual(5, kthLargest.Add(3), $"Failed for {solutionName}");
            Assert.AreEqual(7, kthLargest.Add(8), $"Failed for {solutionName}");
            Assert.AreEqual(8, kthLargest.Add(10), $"Failed for {solutionName}");
        }

        #endregion

        #region Stress Test

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void KthLargest_ManyOperations_K10_RemainsStable(Type implementationType, string solutionName)
        {
            // Many add operations

            // Arrange
            int k = 10;
            int[] nums = { 50, 100, 150, 200, 250, 300, 350, 400, 450, 500 };
            var kthLargest = CreateInstance(implementationType, k, nums);

            // Act & Assert
            for (int i = 1; i <= 20; i++)
            {
                int result = kthLargest.Add(i * 25);
                Assert.IsTrue(result > 0, $"Result should be positive at iteration {i} for {solutionName}");
            }
        }

        #endregion
    }
}
