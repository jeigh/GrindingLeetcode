using LeetCodeProblems.CSharp.SlidingWindow;
using LeetCodeProblems.Interfaces.Medium;

namespace GrindingLeetCode.UnitTests.Medium
{
    [TestClass]
    public class MinimumSizeSubarraySum_209_Tests
    {
        public static IEnumerable<object[]> GetImplementations()
        {
            yield return new object[] { new MinimumSizeSubarraySumSlidingWindowCSSolution_209(), "SlidingWindow" };
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void MinSubArrayLen_Example1_Returns2(IMinimumSizeSubarraySum_209 solution, string solutionName)
        {
            // Arrange
            int target = 7;
            int[] nums = { 2, 3, 1, 2, 4, 3 };

            // Act
            int result = solution.MinSubArrayLen(target, nums);

            // Assert
            Assert.AreEqual(2, result, $"Failed for {solutionName}"); // [4,3] is the minimal subarray
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void MinSubArrayLen_Example2_Returns1(IMinimumSizeSubarraySum_209 solution, string solutionName)
        {
            // Arrange
            int target = 4;
            int[] nums = { 1, 4, 4 };

            // Act
            int result = solution.MinSubArrayLen(target, nums);

            // Assert
            Assert.AreEqual(1, result, $"Failed for {solutionName}"); // [4] is the minimal subarray
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void MinSubArrayLen_Example3_Returns0(IMinimumSizeSubarraySum_209 solution, string solutionName)
        {
            // Arrange
            int target = 11;
            int[] nums = { 1, 1, 1, 1, 1, 1, 1, 1 };

            // Act
            int result = solution.MinSubArrayLen(target, nums);

            // Assert
            Assert.AreEqual(0, result, $"Failed for {solutionName}"); // No subarray sums to >= 11
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void MinSubArrayLen_SingleElementEqualTarget_Returns1(IMinimumSizeSubarraySum_209 solution, string solutionName)
        {
            // Arrange
            int target = 5;
            int[] nums = { 5 };

            // Act
            int result = solution.MinSubArrayLen(target, nums);

            // Assert
            Assert.AreEqual(1, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void MinSubArrayLen_SingleElementLessThanTarget_Returns0(IMinimumSizeSubarraySum_209 solution, string solutionName)
        {
            // Arrange
            int target = 10;
            int[] nums = { 5 };

            // Act
            int result = solution.MinSubArrayLen(target, nums);

            // Assert
            Assert.AreEqual(0, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void MinSubArrayLen_SingleElementGreaterThanTarget_Returns1(IMinimumSizeSubarraySum_209 solution, string solutionName)
        {
            // Arrange
            int target = 5;
            int[] nums = { 10 };

            // Act
            int result = solution.MinSubArrayLen(target, nums);

            // Assert
            Assert.AreEqual(1, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void MinSubArrayLen_AllElementsEqualOne_ReturnsTargetIfPossible(IMinimumSizeSubarraySum_209 solution, string solutionName)
        {
            // Arrange
            int target = 5;
            int[] nums = { 1, 1, 1, 1, 1, 1, 1 };

            // Act
            int result = solution.MinSubArrayLen(target, nums);

            // Assert
            Assert.AreEqual(5, result, $"Failed for {solutionName}"); // Need exactly 5 ones
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void MinSubArrayLen_EntireArrayNeeded_ReturnsFullLength(IMinimumSizeSubarraySum_209 solution, string solutionName)
        {
            // Arrange
            int target = 15;
            int[] nums = { 1, 2, 3, 4, 5 };

            // Act
            int result = solution.MinSubArrayLen(target, nums);

            // Assert
            Assert.AreEqual(5, result, $"Failed for {solutionName}"); // Sum of all is 15
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void MinSubArrayLen_LargeNumbersAtEnd_ReturnsSmallLength(IMinimumSizeSubarraySum_209 solution, string solutionName)
        {
            // Arrange
            int target = 15;
            int[] nums = { 1, 2, 3, 4, 100 };

            // Act
            int result = solution.MinSubArrayLen(target, nums);

            // Assert
            Assert.AreEqual(1, result, $"Failed for {solutionName}"); // [100] >= 15
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void MinSubArrayLen_ConsecutiveNumbersNeeded_ReturnsCorrectLength(IMinimumSizeSubarraySum_209 solution, string solutionName)
        {
            // Arrange
            int target = 15;
            int[] nums = { 5, 1, 3, 5, 10, 7, 4, 9, 2, 8 };

            // Act
            int result = solution.MinSubArrayLen(target, nums);

            // Assert
            Assert.AreEqual(2, result, $"Failed for {solutionName}"); // [10,7] or similar
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void MinSubArrayLen_MultipleValidSubarrays_ReturnsMinimal(IMinimumSizeSubarraySum_209 solution, string solutionName)
        {
            // Arrange
            int target = 7;
            int[] nums = { 2, 3, 1, 2, 4, 3 };

            // Act
            int result = solution.MinSubArrayLen(target, nums);

            // Assert
            Assert.AreEqual(2, result, $"Failed for {solutionName}"); // [4,3] is minimal
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void MinSubArrayLen_TargetIsOne_Returns1(IMinimumSizeSubarraySum_209 solution, string solutionName)
        {
            // Arrange
            int target = 1;
            int[] nums = { 1, 2, 3, 4, 5 };

            // Act
            int result = solution.MinSubArrayLen(target, nums);

            // Assert
            Assert.AreEqual(1, result, $"Failed for {solutionName}"); // Any single element >= 1
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void MinSubArrayLen_LargeTarget_ReturnsCorrectOrZero(IMinimumSizeSubarraySum_209 solution, string solutionName)
        {
            // Arrange
            int target = 100;
            int[] nums = { 1, 2, 3, 4, 5 };

            // Act
            int result = solution.MinSubArrayLen(target, nums);

            // Assert
            Assert.AreEqual(0, result, $"Failed for {solutionName}"); // Sum of all is 15, less than 100
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void MinSubArrayLen_TwoElements_ReturnsCorrectLength(IMinimumSizeSubarraySum_209 solution, string solutionName)
        {
            // Arrange
            int target = 10;
            int[] nums = { 1, 9 };

            // Act
            int result = solution.MinSubArrayLen(target, nums);

            // Assert
            Assert.AreEqual(2, result, $"Failed for {solutionName}"); // Need both [1,9]
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void MinSubArrayLen_AlternatingLargeSmall_ReturnsCorrect(IMinimumSizeSubarraySum_209 solution, string solutionName)
        {
            // Arrange
            int target = 11;
            int[] nums = { 1, 2, 3, 4, 5 };

            // Act
            int result = solution.MinSubArrayLen(target, nums);

            // Assert
            Assert.AreEqual(3, result, $"Failed for {solutionName}"); // [3,4,5] or [2,4,5]
        }
    }
}