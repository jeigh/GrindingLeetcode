using LeetCodeProblems.CSharp.HashingOrArrays;
using LeetCodeProblems.Interfaces.Medium;

namespace GrindingLeetCode.UnitTests.Medium
{
    [TestClass]
    public class LongestConsecutive_128_Tests
    {
        public static IEnumerable<object[]> GetImplementations()
        {
            yield return new object[] { new LongestConsecutiveSolution_128(), "C# Sorting" };
            // Uncomment as each additional implementation is written.
            //yield return new object[] { new LargestConsecutive_UnionFind_CSharp_128(), "C# UnionFind" };

            yield break;
        }

        #region LongestConsecutive

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void LongestConsecutive_Example1_Returns4(ILongestConsecutiveSequence_128 solution, string solutionName)
        {
            int[] nums = { 100, 4, 200, 1, 3, 2 };
            int result = solution.LongestConsecutive(nums);
            Assert.AreEqual(4, result, $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void LongestConsecutive_Example2_Returns9(ILongestConsecutiveSequence_128 solution, string solutionName)
        {
            int[] nums = { 0, 3, 7, 2, 5, 8, 4, 6, 0, 1 };
            int result = solution.LongestConsecutive(nums);
            Assert.AreEqual(9, result, $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void LongestConsecutive_EmptyArray_Returns0(ILongestConsecutiveSequence_128 solution, string solutionName)
        {
            int[] nums = { };
            int result = solution.LongestConsecutive(nums);
            Assert.AreEqual(0, result, $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void LongestConsecutive_SingleElement_Returns1(ILongestConsecutiveSequence_128 solution, string solutionName)
        {
            int[] nums = { 42 };
            int result = solution.LongestConsecutive(nums);
            Assert.AreEqual(1, result, $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void LongestConsecutive_AllSameElements_Returns1(ILongestConsecutiveSequence_128 solution, string solutionName)
        {
            int[] nums = { 5, 5, 5, 5 };
            int result = solution.LongestConsecutive(nums);
            Assert.AreEqual(1, result, $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void LongestConsecutive_NegativeNumbers_ReturnsCorrectLength(ILongestConsecutiveSequence_128 solution, string solutionName)
        {
            int[] nums = { -2, -1, 0, 1, 2 };
            int result = solution.LongestConsecutive(nums);
            Assert.AreEqual(5, result, $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void LongestConsecutive_MultipleConsecutiveGroups_ReturnsLongest(ILongestConsecutiveSequence_128 solution, string solutionName)
        {
            int[] nums = { 10, 5, 12, 3, 55, 30, 4, 11, 2 };
            int result = solution.LongestConsecutive(nums);
            Assert.AreEqual(4, result, $"[{solutionName}]"); // 2,3,4,5
        }

        #endregion

        #region LongestConsecutiveOptimized (concrete-class-specific extra method, not part of the interface)

        [TestMethod]
        public void LongestConsecutiveOptimized_Example1_Returns4()
        {
            var solution = new LongestConsecutiveSolution_128();
            int[] nums = { 100, 4, 200, 1, 3, 2 };
            int result = solution.LongestConsecutiveOptimized(nums);
            Assert.AreEqual(4, result);
        }

        [TestMethod]
        public void LongestConsecutiveOptimized_EmptyArray_Returns0()
        {
            var solution = new LongestConsecutiveSolution_128();
            int[] nums = { };
            int result = solution.LongestConsecutiveOptimized(nums);
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void LongestConsecutiveOptimized_AllSameElements_Returns1()
        {
            var solution = new LongestConsecutiveSolution_128();
            int[] nums = { 7, 7, 7 };
            int result = solution.LongestConsecutiveOptimized(nums);
            Assert.AreEqual(1, result);
        }

        #endregion
    }
}
