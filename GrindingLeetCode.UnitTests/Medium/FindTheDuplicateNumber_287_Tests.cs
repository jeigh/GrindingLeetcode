using LeetCodeProblems.CSharp.LinkedList;
using LeetCodeProblems.Interfaces.Medium;

namespace GrindingLeetCode.UnitTests.Medium
{
    [TestClass]
    public class FindTheDuplicateNumber_287_Tests
    {
        public static IEnumerable<object[]> GetImplementations()
        {
            //yield return new object[] { new FindTheDuplicateNumberUsingLinkedListCSharp_287(), "C# OOP" };
            yield return new object[] { new FindTheDuplicateNumberTerseCSharp_287(), "C# Terse" };
        }

        #region LeetCode Examples

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void FindDuplicate_Example1_ReturnsDuplicate(IFindTheDuplicateNumber_287 solution, string solutionName)
        {
            // Arrange: [1,3,4,2,2]
            int[] nums = { 1, 3, 4, 2, 2 };

            // Act
            int result = solution.FindDuplicate(nums);

            // Assert: duplicate is 2
            Assert.AreEqual(2, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void FindDuplicate_Example2_ReturnsDuplicate(IFindTheDuplicateNumber_287 solution, string solutionName)
        {
            // Arrange: [3,1,3,4,2]
            int[] nums = { 3, 1, 3, 4, 2 };

            // Act
            int result = solution.FindDuplicate(nums);

            // Assert: duplicate is 3
            Assert.AreEqual(3, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void FindDuplicate_Example3_ReturnsDuplicate(IFindTheDuplicateNumber_287 solution, string solutionName)
        {
            // Arrange: [3,3,3,3,3]
            int[] nums = { 3, 3, 3, 3, 3 };

            // Act
            int result = solution.FindDuplicate(nums);

            // Assert: duplicate is 3
            Assert.AreEqual(3, result, $"Failed for {solutionName}");
        }

        #endregion

        #region Small Arrays

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void FindDuplicate_TwoElements_OneDuplicate_ReturnsDuplicate(IFindTheDuplicateNumber_287 solution, string solutionName)
        {
            // Arrange: [1,1]
            int[] nums = { 1, 1 };

            // Act
            int result = solution.FindDuplicate(nums);

            // Assert: duplicate is 1
            Assert.AreEqual(1, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void FindDuplicate_ThreeElements_ReturnsDuplicate(IFindTheDuplicateNumber_287 solution, string solutionName)
        {
            // Arrange: [2,1,2]
            int[] nums = { 2, 1, 2 };

            // Act
            int result = solution.FindDuplicate(nums);

            // Assert: duplicate is 2
            Assert.AreEqual(2, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void FindDuplicate_FourElements_ReturnsDuplicate(IFindTheDuplicateNumber_287 solution, string solutionName)
        {
            // Arrange: [3,1,2,3]
            int[] nums = { 3, 1, 2, 3 };

            // Act
            int result = solution.FindDuplicate(nums);

            // Assert: duplicate is 3
            Assert.AreEqual(3, result, $"Failed for {solutionName}");
        }

        #endregion

        #region Duplicate at Different Positions

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void FindDuplicate_DuplicateAtStart_ReturnsDuplicate(IFindTheDuplicateNumber_287 solution, string solutionName)
        {
            // Arrange: [1,1,2,3,4,5]
            int[] nums = { 1, 1, 2, 3, 4, 5 };

            // Act
            int result = solution.FindDuplicate(nums);

            // Assert: duplicate is 1
            Assert.AreEqual(1, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void FindDuplicate_DuplicateAtEnd_ReturnsDuplicate(IFindTheDuplicateNumber_287 solution, string solutionName)
        {
            // Arrange: [1,2,3,4,5,5]
            int[] nums = { 1, 2, 3, 4, 5, 5 };

            // Act
            int result = solution.FindDuplicate(nums);

            // Assert: duplicate is 5
            Assert.AreEqual(5, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void FindDuplicate_DuplicateInMiddle_ReturnsDuplicate(IFindTheDuplicateNumber_287 solution, string solutionName)
        {
            // Arrange: [1,2,3,3,4,5]
            int[] nums = { 1, 2, 3, 3, 4, 5 };

            // Act
            int result = solution.FindDuplicate(nums);

            // Assert: duplicate is 3
            Assert.AreEqual(3, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void FindDuplicate_DuplicateFarApart_ReturnsDuplicate(IFindTheDuplicateNumber_287 solution, string solutionName)
        {
            // Arrange: [2,5,1,4,3,2,6,7]
            int[] nums = { 2, 5, 1, 4, 3, 2, 6, 7 };

            // Act
            int result = solution.FindDuplicate(nums);

            // Assert: duplicate is 2
            Assert.AreEqual(2, result, $"Failed for {solutionName}");
        }

        #endregion

        #region Multiple Occurrences of Duplicate

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void FindDuplicate_ThreeOccurrences_ReturnsDuplicate(IFindTheDuplicateNumber_287 solution, string solutionName)
        {
            // Arrange: [4,3,1,4,2,4]
            int[] nums = { 4, 3, 1, 4, 2, 4 };

            // Act
            int result = solution.FindDuplicate(nums);

            // Assert: duplicate is 4
            Assert.AreEqual(4, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void FindDuplicate_FourOccurrences_ReturnsDuplicate(IFindTheDuplicateNumber_287 solution, string solutionName)
        {
            // Arrange: [2,2,2,2,3,4,5]
            int[] nums = { 2, 2, 2, 2, 3, 4, 5 };

            // Act
            int result = solution.FindDuplicate(nums);

            // Assert: duplicate is 2
            Assert.AreEqual(2, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void FindDuplicate_AllSameNumber_ReturnsDuplicate(IFindTheDuplicateNumber_287 solution, string solutionName)
        {
            // Arrange: [7,7,7,7,7,7,7,1]
            int[] nums = { 7, 7, 7, 7, 7, 7, 7, 1 };

            // Act
            int result = solution.FindDuplicate(nums);

            // Assert: duplicate is 7
            Assert.AreEqual(7, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void FindDuplicate_MostlyDuplicates_ReturnsDuplicate(IFindTheDuplicateNumber_287 solution, string solutionName)
        {
            // Arrange: [5,5,5,5,5,1,2,3,4]
            int[] nums = { 5, 5, 5, 5, 5, 1, 2, 3, 4 };

            // Act
            int result = solution.FindDuplicate(nums);

            // Assert: duplicate is 5
            Assert.AreEqual(5, result, $"Failed for {solutionName}");
        }

        #endregion

        #region Different Value Patterns

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void FindDuplicate_SequentialNumbers_ReturnsDuplicate(IFindTheDuplicateNumber_287 solution, string solutionName)
        {
            // Arrange: [1,2,3,4,5,6,6,7,8]
            int[] nums = { 1, 2, 3, 4, 5, 6, 6, 7, 8 };

            // Act
            int result = solution.FindDuplicate(nums);

            // Assert: duplicate is 6
            Assert.AreEqual(6, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void FindDuplicate_ReverseOrder_ReturnsDuplicate(IFindTheDuplicateNumber_287 solution, string solutionName)
        {
            // Arrange: [5,4,3,2,1,3]
            int[] nums = { 5, 4, 3, 2, 1, 3 };

            // Act
            int result = solution.FindDuplicate(nums);

            // Assert: duplicate is 3
            Assert.AreEqual(3, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void FindDuplicate_RandomOrder_ReturnsDuplicate(IFindTheDuplicateNumber_287 solution, string solutionName)
        {
            // Arrange: [5,2,8,1,4,7,3,6,4]
            int[] nums = { 5, 2, 8, 1, 4, 7, 3, 6, 4 };

            // Act
            int result = solution.FindDuplicate(nums);

            // Assert: duplicate is 4
            Assert.AreEqual(4, result, $"Failed for {solutionName}");
        }

        #endregion

        #region Edge Cases with Specific Values

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void FindDuplicate_DuplicateIsOne_ReturnsDuplicate(IFindTheDuplicateNumber_287 solution, string solutionName)
        {
            // Arrange: [1,1,2,3,4,5,6]
            int[] nums = { 1, 1, 2, 3, 4, 5, 6 };

            // Act
            int result = solution.FindDuplicate(nums);

            // Assert: duplicate is 1
            Assert.AreEqual(1, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void FindDuplicate_DuplicateIsN_ReturnsDuplicate(IFindTheDuplicateNumber_287 solution, string solutionName)
        {
            // Arrange: [6,1,2,3,4,5,6]
            int[] nums = { 6, 1, 2, 3, 4, 5, 6 };

            // Act
            int result = solution.FindDuplicate(nums);

            // Assert: duplicate is 6
            Assert.AreEqual(6, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void FindDuplicate_DuplicateIsMiddleValue_ReturnsDuplicate(IFindTheDuplicateNumber_287 solution, string solutionName)
        {
            // Arrange: [1,2,5,3,4,5,6,7]
            int[] nums = { 1, 2, 5, 3, 4, 5, 6, 7 };

            // Act
            int result = solution.FindDuplicate(nums);

            // Assert: duplicate is 5
            Assert.AreEqual(5, result, $"Failed for {solutionName}");
        }

        #endregion

        #region Medium-Sized Arrays

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void FindDuplicate_TenElements_ReturnsDuplicate(IFindTheDuplicateNumber_287 solution, string solutionName)
        {
            // Arrange: [1,2,3,4,5,6,7,8,9,5]
            int[] nums = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 5 };

            // Act
            int result = solution.FindDuplicate(nums);

            // Assert: duplicate is 5
            Assert.AreEqual(5, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void FindDuplicate_FifteenElements_ReturnsDuplicate(IFindTheDuplicateNumber_287 solution, string solutionName)
        {
            // Arrange: [1,2,3,4,5,6,7,8,9,10,11,12,13,14,7]
            int[] nums = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 7 };

            // Act
            int result = solution.FindDuplicate(nums);

            // Assert: duplicate is 7
            Assert.AreEqual(7, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void FindDuplicate_TwentyElements_ReturnsDuplicate(IFindTheDuplicateNumber_287 solution, string solutionName)
        {
            // Arrange: [1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,10]
            int[] nums = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 10 };

            // Act
            int result = solution.FindDuplicate(nums);

            // Assert: duplicate is 10
            Assert.AreEqual(10, result, $"Failed for {solutionName}");
        }

        #endregion

        #region Complex Patterns

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void FindDuplicate_AlternatingPattern_ReturnsDuplicate(IFindTheDuplicateNumber_287 solution, string solutionName)
        {
            // Arrange: [1,3,5,7,2,4,6,8,3]
            int[] nums = { 1, 3, 5, 7, 2, 4, 6, 8, 3 };

            // Act
            int result = solution.FindDuplicate(nums);

            // Assert: duplicate is 3
            Assert.AreEqual(3, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void FindDuplicate_ShuffledWithDuplicate_ReturnsDuplicate(IFindTheDuplicateNumber_287 solution, string solutionName)
        {
            // Arrange: [8,4,2,6,1,5,3,7,2]
            int[] nums = { 8, 4, 2, 6, 1, 5, 3, 7, 2 };

            // Act
            int result = solution.FindDuplicate(nums);

            // Assert: duplicate is 2
            Assert.AreEqual(2, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void FindDuplicate_MostlyOrdered_ReturnsDuplicate(IFindTheDuplicateNumber_287 solution, string solutionName)
        {
            // Arrange: [1,2,3,4,5,7,8,9,10,6,6]
            int[] nums = { 1, 2, 3, 4, 5, 7, 8, 9, 10, 6, 6 };

            // Act
            int result = solution.FindDuplicate(nums);

            // Assert: duplicate is 6
            Assert.AreEqual(6, result, $"Failed for {solutionName}");
        }

        #endregion

        #region Specific LeetCode Edge Cases

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void FindDuplicate_CycleDetectionPattern1_ReturnsDuplicate(IFindTheDuplicateNumber_287 solution, string solutionName)
        {
            // Arrange: Pattern that creates specific cycle
            int[] nums = { 2, 5, 9, 6, 9, 3, 8, 9, 7, 1 };

            // Act
            int result = solution.FindDuplicate(nums);

            // Assert: duplicate is 9
            Assert.AreEqual(9, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void FindDuplicate_CycleDetectionPattern2_ReturnsDuplicate(IFindTheDuplicateNumber_287 solution, string solutionName)
        {
            // Arrange: Another cycle pattern
            int[] nums = { 1, 4, 6, 6, 6, 6, 6 };

            // Act
            int result = solution.FindDuplicate(nums);

            // Assert: duplicate is 6
            Assert.AreEqual(6, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void FindDuplicate_TwoPairs_ReturnsDuplicate(IFindTheDuplicateNumber_287 solution, string solutionName)
        {
            // Arrange: [2,2,2,1,3]
            // Note: Problem guarantees only ONE duplicate number
            int[] nums = { 2, 2, 2, 1, 3 };

            // Act
            int result = solution.FindDuplicate(nums);

            // Assert: duplicate is 2
            Assert.AreEqual(2, result, $"Failed for {solutionName}");
        }

        #endregion

        #region Large Arrays

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void FindDuplicate_FiftyElements_ReturnsDuplicate(IFindTheDuplicateNumber_287 solution, string solutionName)
        {
            // Arrange: Create array with 50 elements, duplicate is 25
            int[] nums = new int[51];
            for (int i = 0; i < 50; i++)
            {
                nums[i] = i + 1;
            }
            nums[50] = 25; // Ensure 25 is the duplicate

            // Act
            int result = solution.FindDuplicate(nums);

            // Assert: duplicate is 25
            Assert.AreEqual(25, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void FindDuplicate_HundredElements_DuplicateAtStart_ReturnsDuplicate(IFindTheDuplicateNumber_287 solution, string solutionName)
        {
            // Arrange: Large array with duplicate being 1
            int[] nums = new int[101];
            nums[0] = 1;
            for (int i = 1; i <= 100; i++)
            {
                nums[i] = i;
            }

            // Act
            int result = solution.FindDuplicate(nums);

            // Assert: duplicate is 1
            Assert.AreEqual(1, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void FindDuplicate_HundredElements_DuplicateAtEnd_ReturnsDuplicate(IFindTheDuplicateNumber_287 solution, string solutionName)
        {
            // Arrange: Large array with duplicate being 99
            int[] nums = new int[101];
            for (int i = 0; i < 99; i++)
            {
                nums[i] = i + 1;
            }
            nums[99] = 99;
            nums[100] = 99;

            // Act
            int result = solution.FindDuplicate(nums);

            // Assert: duplicate is 99
            Assert.AreEqual(99, result, $"Failed for {solutionName}");
        }

        #endregion

        #region Special Sequences

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void FindDuplicate_ConsecutiveDuplicates_ReturnsDuplicate(IFindTheDuplicateNumber_287 solution, string solutionName)
        {
            // Arrange: [1,2,3,3,4,5,6]
            int[] nums = { 1, 2, 3, 3, 4, 5, 6 };

            // Act
            int result = solution.FindDuplicate(nums);

            // Assert: duplicate is 3
            Assert.AreEqual(3, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void FindDuplicate_DuplicatesSeparatedByMany_ReturnsDuplicate(IFindTheDuplicateNumber_287 solution, string solutionName)
        {
            // Arrange: [1,7,3,4,5,6,2,8,9,10,7]
            int[] nums = { 1, 7, 3, 4, 5, 6, 2, 8, 9, 10, 7 };

            // Act
            int result = solution.FindDuplicate(nums);

            // Assert: duplicate is 7
            Assert.AreEqual(7, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void FindDuplicate_MirrorPattern_ReturnsDuplicate(IFindTheDuplicateNumber_287 solution, string solutionName)
        {
            // Arrange: [1,2,3,4,5,5,4,3,2]
            int[] nums = { 1, 2, 3, 4, 5, 5, 4, 3, 2 };

            // Act
            int result = solution.FindDuplicate(nums);

            // Assert: duplicate could be 2, 3, 4, or 5 depending on which appears twice
            // In this case, all of 2,3,4,5 appear twice, but we need n+1 elements for n range
            // Let's fix this: [1,2,3,4,5,4,6,7,8]
            nums = new int[] { 1, 2, 3, 4, 5, 4, 6, 7, 8 };
            result = solution.FindDuplicate(nums);
            Assert.AreEqual(4, result, $"Failed for {solutionName}");
        }

        #endregion

        #region Boundary Values

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void FindDuplicate_MinimumSize_ReturnsDuplicate(IFindTheDuplicateNumber_287 solution, string solutionName)
        {
            // Arrange: Minimum possible size n=1, array size 2
            int[] nums = { 1, 1 };

            // Act
            int result = solution.FindDuplicate(nums);

            // Assert: duplicate is 1
            Assert.AreEqual(1, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void FindDuplicate_NearlySorted_ReturnsDuplicate(IFindTheDuplicateNumber_287 solution, string solutionName)
        {
            // Arrange: Nearly sorted with one duplicate
            int[] nums = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 15 };

            // Act
            int result = solution.FindDuplicate(nums);

            // Assert: duplicate is 15
            Assert.AreEqual(15, result, $"Failed for {solutionName}");
        }

        #endregion
    }
}
