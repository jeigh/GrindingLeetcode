using LeetCodeProblems.CSharp.Queue;
using LeetCodeProblems.Interfaces.Medium;

namespace GrindingLeetCode.UnitTests.Medium
{
    /// <summary>
    /// Unit tests for LeetCode Problem 767: Reorganize String
    ///
    /// Problem Description:
    /// Given a string s, rearrange the characters of s so that any two adjacent
    /// characters are not the same. Return any possible rearrangement of s or return ""
    /// if not possible.
    /// </summary>
    [TestClass]
    public class ReorganizeString_767_Tests
    {
        public static IEnumerable<object[]> GetImplementations()
        {
            yield return new object[] { new ReorganizeString_CSharp_767(), "C# Implementation" };
        }

        // Helper: verifies no two adjacent characters are equal and
        // the result contains the same characters as the input.
        private static bool IsValidReorganization(string input, string output)
        {
            if (output.Length != input.Length)
                return false;

            int[] expected = new int[26];
            int[] actual = new int[26];
            foreach (char c in input) expected[c - 'a']++;
            foreach (char c in output) actual[c - 'a']++;
            for (int i = 0; i < 26; i++)
            {
                if (expected[i] != actual[i])
                    return false;
            }

            for (int i = 1; i < output.Length; i++)
            {
                if (output[i] == output[i - 1])
                    return false;
            }

            return true;
        }

        #region LeetCode Examples

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void ReorganizeString_Example1_ReturnsValidRearrangement(IReorganizeString_767 solution, string solutionName)
        {
            // Example 1:
            // Input: s = "aab"
            // Output: "aba"

            // Arrange
            string s = "aab";

            // Act
            string result = solution.ReorganizeString(s);

            // Assert
            Assert.IsTrue(IsValidReorganization(s, result), $"Invalid reorganization '{result}' for input '{s}' [{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void ReorganizeString_Example2_ReturnsEmpty(IReorganizeString_767 solution, string solutionName)
        {
            // Example 2:
            // Input: s = "aaab"
            // Output: "" (not possible)

            // Arrange
            string s = "aaab";

            // Act
            string result = solution.ReorganizeString(s);

            // Assert
            Assert.AreEqual("", result, $"Expected empty string for impossible input '{s}' [{solutionName}]");
        }

        #endregion

        #region Edge Cases

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void ReorganizeString_SingleCharacter_ReturnsSameCharacter(IReorganizeString_767 solution, string solutionName)
        {
            // A single character is trivially valid.
            string s = "a";

            string result = solution.ReorganizeString(s);

            Assert.AreEqual("a", result, $"Failed for single-char input [{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void ReorganizeString_TwoSameCharacters_ReturnsEmpty(IReorganizeString_767 solution, string solutionName)
        {
            // Two identical characters cannot be reorganized.
            string s = "aa";

            string result = solution.ReorganizeString(s);

            Assert.AreEqual("", result, $"Expected empty string for '{s}' [{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void ReorganizeString_TwoDifferentCharacters_ReturnsValidRearrangement(IReorganizeString_767 solution, string solutionName)
        {
            string s = "ab";

            string result = solution.ReorganizeString(s);

            Assert.IsTrue(IsValidReorganization(s, result), $"Invalid reorganization '{result}' for input '{s}' [{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void ReorganizeString_AllSameCharacters_ReturnsEmpty(IReorganizeString_767 solution, string solutionName)
        {
            string s = "aaaa";

            string result = solution.ReorganizeString(s);

            Assert.AreEqual("", result, $"Expected empty string for '{s}' [{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void ReorganizeString_AlreadyReorganized_ReturnsValidRearrangement(IReorganizeString_767 solution, string solutionName)
        {
            // "abab" is already valid; result must also be valid.
            string s = "abab";

            string result = solution.ReorganizeString(s);

            Assert.IsTrue(IsValidReorganization(s, result), $"Invalid reorganization '{result}' for input '{s}' [{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void ReorganizeString_MaxFrequencyAtBoundary_ReturnsValidRearrangement(IReorganizeString_767 solution, string solutionName)
        {
            // "aabc": frequency of 'a' is 2, length is 4; max allowed freq = ceil(4/2) = 2 -- just possible.
            string s = "aabc";

            string result = solution.ReorganizeString(s);

            Assert.IsTrue(IsValidReorganization(s, result), $"Invalid reorganization '{result}' for input '{s}' [{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void ReorganizeString_MaxFrequencyExceededByOne_ReturnsEmpty(IReorganizeString_767 solution, string solutionName)
        {
            // "aaabc": frequency of 'a' is 3, length is 5; max allowed freq = 3 -- possible.
            // "aaaab": frequency of 'a' is 4, length is 5; max allowed freq = 3 -- NOT possible.
            string s = "aaaab";

            string result = solution.ReorganizeString(s);

            Assert.AreEqual("", result, $"Expected empty string for '{s}' [{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void ReorganizeString_LongerString_ReturnsValidRearrangement(IReorganizeString_767 solution, string solutionName)
        {
            string s = "vvvlo";

            string result = solution.ReorganizeString(s);

            Assert.IsTrue(IsValidReorganization(s, result), $"Invalid reorganization '{result}' for input '{s}' [{solutionName}]");
        }

        #endregion
    }
}
