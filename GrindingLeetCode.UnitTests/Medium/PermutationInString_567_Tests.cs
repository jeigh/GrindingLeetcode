using LeetCodeProblems.CSharp.Failed;
using LeetCodeProblems.CSharp.HashingOrArrays;
using LeetCodeProblems.CSharp.SlidingWindow;
using LeetCodeProblems.Interfaces.Medium;
using LeetCodeProblems.VisualBasic.SlidingWindow;

namespace GrindingLeetCode.UnitTests.Medium
{
    [TestClass]
    public class PermutationInString_567_Tests
    {
        public static IEnumerable<object[]> GetImplementations()
        {
            yield return new object[] { new PermutationInStringHashMapSolution_567(), "HashMap" };
            yield return new object[] { new PermutationInStringFailedSolution_567(), "Failed" };
            yield return new object[] { new PermutationInStringSlidingWindowVB_567(), "VisualBasic" };
            yield return new object[] { new PermutationInStringSlidingWindow_567(), "SlidingWindow" };
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CheckInclusion_Example1_ReturnsTrue(IPermutationInString_567 solution, string solutionName)
        {
            // Arrange
            string s1 = "ab";
            string s2 = "eidbaooo";

            // Act
            bool result = solution.CheckInclusion(s1, s2);

            // Assert
            Assert.IsTrue(result, $"Failed for {solutionName}"); // "ba" is a permutation of "ab"
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CheckInclusion_Example2_ReturnsFalse(IPermutationInString_567 solution, string solutionName)
        {
            // Arrange
            string s1 = "ab";
            string s2 = "eidboaoo";

            // Act
            bool result = solution.CheckInclusion(s1, s2);

            // Assert
            Assert.IsFalse(result, $"Failed for {solutionName}"); // No permutation of "ab" exists in s2
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CheckInclusion_PermutationAtStart_ReturnsTrue(IPermutationInString_567 solution, string solutionName)
        {
            // Arrange
            string s1 = "abc";
            string s2 = "bca123";

            // Act
            bool result = solution.CheckInclusion(s1, s2);

            // Assert
            Assert.IsTrue(result, $"Failed for {solutionName}"); // "bca" is a permutation of "abc"
        }



        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CheckInclusion_S1LongerThanS2_ReturnsFalse(IPermutationInString_567 solution, string solutionName)
        {
            // Arrange
            string s1 = "abcdef";
            string s2 = "abc";

            // Act
            bool result = solution.CheckInclusion(s1, s2);

            // Assert
            Assert.IsFalse(result, $"Failed for {solutionName}"); // s1 is longer than s2
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CheckInclusion_ExactMatch_ReturnsTrue(IPermutationInString_567 solution, string solutionName)
        {
            // Arrange
            string s1 = "abc";
            string s2 = "abc";

            // Act
            bool result = solution.CheckInclusion(s1, s2);

            // Assert
            Assert.IsTrue(result, $"Failed for {solutionName}"); // Exact match
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CheckInclusion_SingleCharacter_ReturnsTrue(IPermutationInString_567 solution, string solutionName)
        {
            // Arrange
            string s1 = "a";
            string s2 = "bca";

            // Act
            bool result = solution.CheckInclusion(s1, s2);

            // Assert
            Assert.IsTrue(result, $"Failed for {solutionName}"); // "a" exists in s2
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CheckInclusion_SingleCharacterNotFound_ReturnsFalse(IPermutationInString_567 solution, string solutionName)
        {
            // Arrange
            string s1 = "z";
            string s2 = "abcdef";

            // Act
            bool result = solution.CheckInclusion(s1, s2);

            // Assert
            Assert.IsFalse(result, $"Failed for {solutionName}"); // "z" doesn't exist in s2
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CheckInclusion_RepeatingCharacters_ReturnsTrue(IPermutationInString_567 solution, string solutionName)
        {
            // Arrange
            string s1 = "aab";
            string s2 = "cbaebabacd";

            // Act
            bool result = solution.CheckInclusion(s1, s2);

            // Assert
            Assert.IsTrue(result, $"Failed for {solutionName}"); // "baa" is a permutation of "aab"
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CheckInclusion_RepeatingCharactersNotEnough_ReturnsFalse(IPermutationInString_567 solution, string solutionName)
        {
            // Arrange
            string s1 = "aaa";
            string s2 = "abaa";

            // Act
            bool result = solution.CheckInclusion(s1, s2);

            // Assert
            Assert.IsFalse(result, $"Failed for {solutionName}"); // Need 3 'a's consecutively
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CheckInclusion_AllSameCharacters_ReturnsTrue(IPermutationInString_567 solution, string solutionName)
        {
            // Arrange
            string s1 = "aaa";
            string s2 = "aaaaaaa";

            // Act
            bool result = solution.CheckInclusion(s1, s2);

            // Assert
            Assert.IsTrue(result, $"Failed for {solutionName}"); // Multiple "aaa" permutations exist
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CheckInclusion_PermutationInMiddle_ReturnsTrue(IPermutationInString_567 solution, string solutionName)
        {
            // Arrange
            string s1 = "abc";
            string s2 = "xyzacbdef";

            // Act
            bool result = solution.CheckInclusion(s1, s2);

            // Assert
            Assert.IsTrue(result, $"Failed for {solutionName}"); // "acb" is a permutation of "abc"
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CheckInclusion_SimilarButNotPermutation_ReturnsFalse(IPermutationInString_567 solution, string solutionName)
        {
            // Arrange
            string s1 = "abc";
            string s2 = "aabbcc";

            // Act
            bool result = solution.CheckInclusion(s1, s2);

            // Assert
            Assert.IsFalse(result, $"Failed for {solutionName}"); // Character counts don't match
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CheckInclusion_LongString_ReturnsTrue(IPermutationInString_567 solution, string solutionName)
        {
            // Arrange
            string s1 = "abc";
            string s2 = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaabcaaaaaaaaaaa";

            // Act
            bool result = solution.CheckInclusion(s1, s2);

            // Assert
            Assert.IsTrue(result, $"Failed for {solutionName}"); // "abc" exists in the long string
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CheckInclusion_MultiplePermutations_ReturnsTrue(IPermutationInString_567 solution, string solutionName)
        {
            // Arrange
            string s1 = "ab";
            string s2 = "baxyzab";

            // Act
            bool result = solution.CheckInclusion(s1, s2);

            // Assert
            Assert.IsTrue(result, $"Failed for {solutionName}"); // Both "ba" and "ab" are permutations
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CheckInclusion_AdjacentDuplicates_ReturnsTrue(IPermutationInString_567 solution, string solutionName)
        {
            // Arrange
            string s1 = "aab";
            string s2 = "aaba";

            // Act
            bool result = solution.CheckInclusion(s1, s2);

            // Assert
            Assert.IsTrue(result, $"Failed for {solutionName}"); // "aab" exists at start
        }
    }
}