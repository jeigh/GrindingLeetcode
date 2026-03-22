using LeetCodeProblems.CSharp.Backtracking;
using LeetCodeProblems.CSharp.BruteForce;
using LeetCodeProblems.Interfaces.Easy;
using LeetCodeProblems.VisualBasic.Backtracking;




namespace GrindingLeetCode.UnitTests.Easy
{
    /// <summary>
    /// Unit tests for LeetCode Problem 1863: Sum of All Subset XOR Totals
    ///
    /// Problem Description:
    /// Return the sum of XOR totals for every subset of nums.
    /// The XOR total of a subset is the bitwise XOR of all its elements (0 if empty).
    /// </summary>
    [TestClass]
    public class SubsetXORSum_1863_Tests
    {
        public static IEnumerable<object[]> GetImplementations()
        {
            yield return new object[] { new SubsetXORSum_CSharp_Recursive_1863(), "C# Recursive Implementation" };
            yield return new object[] { new SubsetXORSum_CSharp_Iterative_1863(), "C# Iterative Implementation" };

            yield return new object[] { new SubsetXorSum_Recursive_VB_1863(), "VB Recursive Implementation" };
            yield return new object[] { new SubsetXorSum_Iterative_VB_1863(), "VB Iterative Implementation" };
        }

        #region LeetCode Examples

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void SubsetXORSum_Example1_Returns6(ISubsetXORSum_1863 solution, string solutionName)
        {
            // Input: nums = [1,3]
            // Subsets and their XOR totals:
            //   []      -> 0
            //   [1]     -> 1
            //   [3]     -> 3
            //   [1,3]   -> 1 XOR 3 = 2
            // Sum = 0 + 1 + 3 + 2 = 6
            // Output: 6

            int[] nums = [1, 3];

            int result = solution.SubsetXORSum(nums);

            Assert.AreEqual(6, result, $"Expected 6 for [1,3] [{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void SubsetXORSum_Example2_Returns28(ISubsetXORSum_1863 solution, string solutionName)
        {
            // Input: nums = [5,1,6]
            // Subsets and their XOR totals:
            //   []        -> 0
            //   [5]       -> 5
            //   [1]       -> 1
            //   [6]       -> 6
            //   [5,1]     -> 4
            //   [5,6]     -> 3
            //   [1,6]     -> 7
            //   [5,1,6]   -> 2
            // Sum = 0+5+1+6+4+3+7+2 = 28
            // Output: 28

            int[] nums = [5, 1, 6];

            int result = solution.SubsetXORSum(nums);

            Assert.AreEqual(28, result, $"Expected 28 for [5,1,6] [{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void SubsetXORSum_Example3_Returns480(ISubsetXORSum_1863 solution, string solutionName)
        {
            // Input: nums = [3,4,5,6,7,8]
            // Output: 480

            int[] nums = [3, 4, 5, 6, 7, 8];

            int result = solution.SubsetXORSum(nums);

            Assert.AreEqual(480, result, $"Expected 480 for [3,4,5,6,7,8] [{solutionName}]");
        }

        #endregion

        #region Edge Cases

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void SubsetXORSum_SingleElement_ReturnsThatElement(ISubsetXORSum_1863 solution, string solutionName)
        {
            // Subsets: [] -> 0, [5] -> 5. Sum = 5.
            int[] nums = [5];

            int result = solution.SubsetXORSum(nums);

            Assert.AreEqual(5, result, $"Expected 5 for single element [5] [{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void SubsetXORSum_TwoIdenticalElements_ReturnsTwiceTheValue(ISubsetXORSum_1863 solution, string solutionName)
        {
            // nums = [3,3]
            // Subsets: [] -> 0, [3] -> 3, [3] -> 3, [3,3] -> 0. Sum = 6.
            int[] nums = [3, 3];

            int result = solution.SubsetXORSum(nums);

            Assert.AreEqual(6, result, $"Expected 6 for [3,3] [{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void SubsetXORSum_AllZeroes_ReturnsZero(ISubsetXORSum_1863 solution, string solutionName)
        {
            // XOR of any combination of 0s is 0. Sum = 0.
            int[] nums = [0, 0, 0];

            int result = solution.SubsetXORSum(nums);

            Assert.AreEqual(0, result, $"Expected 0 for [0,0,0] [{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void SubsetXORSum_PowersOfTwo_NoXORCancellation(ISubsetXORSum_1863 solution, string solutionName)
        {
            // nums = [1,2]
            // Subsets: [] -> 0, [1] -> 1, [2] -> 2, [1,2] -> 3. Sum = 6.
            int[] nums = [1, 2];

            int result = solution.SubsetXORSum(nums);

            Assert.AreEqual(6, result, $"Expected 6 for [1,2] [{solutionName}]");
        }

        #endregion
    }
}
