using LeetCodeProblems.CSharp.BruteForce;
using LeetCodeProblems.CSharp.Failed;
using LeetCodeProblems.CSharp.Unconventional;
using LeetCodeProblems.Interfaces;

namespace GrindingLeetCode.UnitTests.Failed
{
    [TestClass]
    public class FindMedianSortedArrays_4_Tests
    {
        public static IEnumerable<object[]> GetImplementations()
        {
            yield return new object[] { new FindMedianSortedArraysSolution_AI_4() };
            yield return new object[] { new FindMedianSortedArraysSolution_4() };
            yield return new object[] { new FindMedianSortedArraysUnoptimized_4() };
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void FindMedianSortedArrays_Example1_ReturnsTwoPointZero(IFindMedianSortedArrays_4 solution)
        {
            // Arrange
            int[] nums1 = { 1, 3 };
            int[] nums2 = { 2 };

            // Act
            double result = solution.FindMedianSortedArrays(nums1, nums2);

            // Assert - merged array is [1,2,3], median is 2
            Assert.AreEqual(2.0, result, 0.00001);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void FindMedianSortedArrays_Example2_ReturnsTwoPointFive(IFindMedianSortedArrays_4 solution)
        {
            // Arrange
            int[] nums1 = { 1, 2 };
            int[] nums2 = { 3, 4 };

            // Act
            double result = solution.FindMedianSortedArrays(nums1, nums2);

            // Assert - merged array is [1,2,3,4], median is (2+3)/2 = 2.5
            Assert.AreEqual(2.5, result, 0.00001);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void FindMedianSortedArrays_FirstArrayEmpty_ReturnsMedianOfSecond(IFindMedianSortedArrays_4 solution)
        {
            // Arrange
            int[] nums1 = { };
            int[] nums2 = { 1, 2, 3, 4, 5 };

            // Act
            double result = solution.FindMedianSortedArrays(nums1, nums2);

            // Assert - median of [1,2,3,4,5] is 3
            Assert.AreEqual(3.0, result, 0.00001);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void FindMedianSortedArrays_SecondArrayEmpty_ReturnsMedianOfFirst(IFindMedianSortedArrays_4 solution)
        {
            // Arrange
            int[] nums1 = { 2, 4, 6, 8 };
            int[] nums2 = { };

            // Act
            double result = solution.FindMedianSortedArrays(nums1, nums2);

            // Assert - median of [2,4,6,8] is (4+6)/2 = 5.0
            Assert.AreEqual(5.0, result, 0.00001);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void FindMedianSortedArrays_SingleElementEach_ReturnsAverage(IFindMedianSortedArrays_4 solution)
        {
            // Arrange
            int[] nums1 = { 1 };
            int[] nums2 = { 2 };

            // Act
            double result = solution.FindMedianSortedArrays(nums1, nums2);

            // Assert - merged is [1,2], median is (1+2)/2 = 1.5
            Assert.AreEqual(1.5, result, 0.00001);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void FindMedianSortedArrays_DifferentLengths_ReturnsCorrectMedian(IFindMedianSortedArrays_4 solution)
        {
            // Arrange
            int[] nums1 = { 1, 3, 5 };
            int[] nums2 = { 2, 4, 6, 8, 10 };

            // Act
            double result = solution.FindMedianSortedArrays(nums1, nums2);

            // Assert - merged is [1,2,3,4,5,6,8,10], median is 4.5
            Assert.AreEqual(4.5, result, 0.00001);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void FindMedianSortedArrays_AllSameValues_ReturnsThatValue(IFindMedianSortedArrays_4 solution)
        {
            // Arrange
            int[] nums1 = { 5, 5, 5 };
            int[] nums2 = { 5, 5 };

            // Act
            double result = solution.FindMedianSortedArrays(nums1, nums2);

            // Assert - all values are 5, median is 5.0
            Assert.AreEqual(5.0, result, 0.00001);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void FindMedianSortedArrays_NegativeNumbers_ReturnsCorrectMedian(IFindMedianSortedArrays_4 solution)
        {
            // Arrange
            int[] nums1 = { -5, -3, -1 };
            int[] nums2 = { -4, -2, 0 };

            // Act
            double result = solution.FindMedianSortedArrays(nums1, nums2);

            // Assert - merged is [-5,-4,-3,-2,-1,0], median is (-3+-2)/2 = -2.5
            Assert.AreEqual(-2.5, result, 0.00001);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void FindMedianSortedArrays_MixedPositiveNegative_ReturnsCorrectMedian(IFindMedianSortedArrays_4 solution)
        {
            // Arrange
            int[] nums1 = { -3, 1, 4 };
            int[] nums2 = { -2, 0, 2 };

            // Act
            double result = solution.FindMedianSortedArrays(nums1, nums2);

            // Assert - merged is [-3,-2,0,1,2,4], median is (0+1)/2 = 0.5
            Assert.AreEqual(0.5, result, 0.00001);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void FindMedianSortedArrays_NonOverlappingRanges_ReturnsCorrectMedian(IFindMedianSortedArrays_4 solution)
        {
            // Arrange
            int[] nums1 = { 1, 2, 3 };
            int[] nums2 = { 10, 11, 12 };

            // Act
            double result = solution.FindMedianSortedArrays(nums1, nums2);

            // Assert - merged is [1,2,3,10,11,12], median is (3+10)/2 = 6.5
            Assert.AreEqual(6.5, result, 0.00001);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void FindMedianSortedArrays_OverlappingValues_ReturnsCorrectMedian(IFindMedianSortedArrays_4 solution)
        {
            // Arrange
            int[] nums1 = { 1, 3, 5, 7 };
            int[] nums2 = { 2, 3, 5, 8 };

            // Act
            double result = solution.FindMedianSortedArrays(nums1, nums2);

            // Assert - merged is [1,2,3,3,5,5,7,8], median is (3+5)/2 = 4.0
            Assert.AreEqual(4.0, result, 0.00001);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void FindMedianSortedArrays_LargeNumbers_ReturnsCorrectMedian(IFindMedianSortedArrays_4 solution)
        {
            // Arrange
            int[] nums1 = { 100000, 200000 };
            int[] nums2 = { 150000, 250000 };

            // Act
            double result = solution.FindMedianSortedArrays(nums1, nums2);

            // Assert - merged is [100000,150000,200000,250000], median is (150000+200000)/2 = 175000
            Assert.AreEqual(175000.0, result, 0.00001);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void FindMedianSortedArrays_OddTotalLength_ReturnsCenterElement(IFindMedianSortedArrays_4 solution)
        {
            // Arrange
            int[] nums1 = { 1, 2 };
            int[] nums2 = { 3, 4, 5 };

            // Act
            double result = solution.FindMedianSortedArrays(nums1, nums2);

            // Assert - merged is [1,2,3,4,5], median is 3
            Assert.AreEqual(3.0, result, 0.00001);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void FindMedianSortedArrays_EvenTotalLength_ReturnsAverageOfMiddleTwo(IFindMedianSortedArrays_4 solution)
        {
            // Arrange
            int[] nums1 = { 1, 2, 3 };
            int[] nums2 = { 4, 5, 6 };

            // Act
            double result = solution.FindMedianSortedArrays(nums1, nums2);

            // Assert - merged is [1,2,3,4,5,6], median is (3+4)/2 = 3.5
            Assert.AreEqual(3.5, result, 0.00001);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void FindMedianSortedArrays_DuplicatesAcrossArrays_ReturnsCorrectMedian(IFindMedianSortedArrays_4 solution)
        {
            // Arrange
            int[] nums1 = { 1, 1, 3, 3 };
            int[] nums2 = { 1, 1, 3, 3 };

            // Act
            double result = solution.FindMedianSortedArrays(nums1, nums2);

            // Assert - merged is [1,1,1,1,3,3,3,3], median is (1+3)/2 = 2.0
            Assert.AreEqual(2.0, result, 0.00001);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void FindMedianSortedArrays_ZeroValues_HandlesCorrectly(IFindMedianSortedArrays_4 solution)
        {
            // Arrange
            int[] nums1 = { -1, 0, 1 };
            int[] nums2 = { 0, 0, 2 };

            // Act
            double result = solution.FindMedianSortedArrays(nums1, nums2);

            // Assert - merged is [-1,0,0,0,1,2], median is (0+0)/2 = 0.0
            Assert.AreEqual(0.0, result, 0.00001);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void FindMedianSortedArrays_VeryDifferentSizes_ReturnsCorrectMedian(IFindMedianSortedArrays_4 solution)
        {
            // Arrange
            int[] nums1 = { 1 };
            int[] nums2 = { 2, 3, 4, 5, 6, 7 };

            // Act
            double result = solution.FindMedianSortedArrays(nums1, nums2);

            // Assert - merged is [1,2,3,4,5,6,7], median is 4
            Assert.AreEqual(4.0, result, 0.00001);
        }
    }
}