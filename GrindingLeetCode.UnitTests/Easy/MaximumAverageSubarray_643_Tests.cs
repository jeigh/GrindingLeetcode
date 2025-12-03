using LeetCodeProblems;
using LeetCodeProblems.Interfaces.Easy;

namespace GrindingLeetCode.UnitTests.Easy
{
    [TestClass]
    public class MaximumAverageSubarray_643_Tests
    {
        public static IEnumerable<object[]> GetImplementations()
        {
            yield return new object[] { new MaximumAverageSubarrayICSharp_643() };
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void FindMaxAverage_Example1_ReturnsTwelvePointFive(IMaximumAverageSubarray_643 solution)
        {
            // Arrange
            int[] nums = { 1, 12, -5, -6, 50, 3 };
            int k = 4;

            // Act
            double result = solution.FindMaxAverage(nums, k);

            // Assert
            Assert.AreEqual(12.75, result, 0.00001);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void FindMaxAverage_Example2_ReturnsFive(IMaximumAverageSubarray_643 solution)
        {
            // Arrange
            int[] nums = { 5 };
            int k = 1;

            // Act
            double result = solution.FindMaxAverage(nums, k);

            // Assert
            Assert.AreEqual(5.0, result, 0.00001);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void FindMaxAverage_AllPositiveNumbers_ReturnsCorrectAverage(IMaximumAverageSubarray_643 solution)
        {
            // Arrange
            int[] nums = { 1, 2, 3, 4, 5 };
            int k = 3;

            // Act
            double result = solution.FindMaxAverage(nums, k);

            // Assert - subarray [3,4,5] has max average of 4.0
            Assert.AreEqual(4.0, result, 0.00001);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void FindMaxAverage_AllNegativeNumbers_ReturnsLeastNegativeAverage(IMaximumAverageSubarray_643 solution)
        {
            // Arrange
            int[] nums = { -1, -2, -3, -4, -5 };
            int k = 2;

            // Act
            double result = solution.FindMaxAverage(nums, k);

            // Assert - subarray [-1,-2] has max (least negative) average of -1.5
            Assert.AreEqual(-1.5, result, 0.00001);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void FindMaxAverage_MixedPositiveAndNegative_ReturnsCorrectAverage(IMaximumAverageSubarray_643 solution)
        {
            // Arrange
            int[] nums = { -10, 5, 6, -2, 3 };
            int k = 2;

            // Act
            double result = solution.FindMaxAverage(nums, k);

            // Assert - subarray [5,6] has max average of 5.5
            Assert.AreEqual(5.5, result, 0.00001);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void FindMaxAverage_KEqualArrayLength_ReturnsAverageOfAllElements(IMaximumAverageSubarray_643 solution)
        {
            // Arrange
            int[] nums = { 2, 4, 6, 8 };
            int k = 4;

            // Act
            double result = solution.FindMaxAverage(nums, k);

            // Assert - average of all elements = 20/4 = 5.0
            Assert.AreEqual(5.0, result, 0.00001);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void FindMaxAverage_IdenticalValues_ReturnsValueAsAverage(IMaximumAverageSubarray_643 solution)
        {
            // Arrange
            int[] nums = { 7, 7, 7, 7, 7 };
            int k = 3;

            // Act
            double result = solution.FindMaxAverage(nums, k);

            // Assert - all subarrays have same average of 7.0
            Assert.AreEqual(7.0, result, 0.00001);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void FindMaxAverage_WindowSizeOne_ReturnsMaxElement(IMaximumAverageSubarray_643 solution)
        {
            // Arrange
            int[] nums = { 3, -1, 4, 1, -5, 9 };
            int k = 1;

            // Act
            double result = solution.FindMaxAverage(nums, k);

            // Assert - max element is 9
            Assert.AreEqual(9.0, result, 0.00001);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void FindMaxAverage_MaxAtBeginning_ReturnsCorrectAverage(IMaximumAverageSubarray_643 solution)
        {
            // Arrange
            int[] nums = { 10, 9, 1, 1, 1 };
            int k = 2;

            // Act
            double result = solution.FindMaxAverage(nums, k);

            // Assert - subarray [10,9] has max average of 9.5
            Assert.AreEqual(9.5, result, 0.00001);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void FindMaxAverage_MaxAtEnd_ReturnsCorrectAverage(IMaximumAverageSubarray_643 solution)
        {
            // Arrange
            int[] nums = { 1, 1, 1, 9, 10 };
            int k = 2;

            // Act
            double result = solution.FindMaxAverage(nums, k);

            // Assert - subarray [9,10] has max average of 9.5
            Assert.AreEqual(9.5, result, 0.00001);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void FindMaxAverage_ZeroValues_HandlesCorrectly(IMaximumAverageSubarray_643 solution)
        {
            // Arrange
            int[] nums = { 0, 1, 2, 0, 3 };
            int k = 2;

            // Act
            double result = solution.FindMaxAverage(nums, k);

            // Assert - subarray [0,3] has max average of 1.5
            Assert.AreEqual(1.5, result, 0.00001);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void FindMaxAverage_LargeNumbers_HandlesCorrectly(IMaximumAverageSubarray_643 solution)
        {
            // Arrange
            int[] nums = { 10000, -10000, 10000, -10000, 10000 };
            int k = 2;

            // Act
            double result = solution.FindMaxAverage(nums, k);

            // Assert - subarray [10000, -10000] or [-10000, 10000] has average of 0.0
            Assert.AreEqual(0.0, result, 0.00001);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void FindMaxAverage_AlternatingHighLow_ReturnsCorrectAverage(IMaximumAverageSubarray_643 solution)
        {
            // Arrange
            int[] nums = { 100, 1, 100, 1, 100 };
            int k = 3;

            // Act
            double result = solution.FindMaxAverage(nums, k);

            // Assert - subarray [1,100,1] or [100,1,100] has average of 67.0 or 67.33...
            Assert.AreEqual(67.0, result, 0.00001);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void FindMaxAverage_TwoElementArray_KTwo_ReturnsAverage(IMaximumAverageSubarray_643 solution)
        {
            // Arrange
            int[] nums = { 3, 7 };
            int k = 2;

            // Act
            double result = solution.FindMaxAverage(nums, k);

            // Assert - only one subarray [3,7] with average 5.0
            Assert.AreEqual(5.0, result, 0.00001);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void FindMaxAverage_DecreasingSequence_ReturnsFirstWindow(IMaximumAverageSubarray_643 solution)
        {
            // Arrange
            int[] nums = { 10, 9, 8, 7, 6, 5 };
            int k = 3;

            // Act
            double result = solution.FindMaxAverage(nums, k);

            // Assert - first window [10,9,8] has max average of 9.0
            Assert.AreEqual(9.0, result, 0.00001);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void FindMaxAverage_IncreasingSequence_ReturnsLastWindow(IMaximumAverageSubarray_643 solution)
        {
            // Arrange
            int[] nums = { 1, 2, 3, 4, 5, 6 };
            int k = 3;

            // Act
            double result = solution.FindMaxAverage(nums, k);

            // Assert - last window [4,5,6] has max average of 5.0
            Assert.AreEqual(5.0, result, 0.00001);
        }
    }
}