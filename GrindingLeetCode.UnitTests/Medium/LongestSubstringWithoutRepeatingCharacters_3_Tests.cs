using LeetCodeProblems.BruteForce;
using LeetCodeProblems.HashingOrArrays;
using LeetCodeProblems.Interfaces.Medium;
using LeetCodeProblems.SlidingWindow;
using LeetCodeProblems.VisualBasic.SlidingWindow;

namespace GrindingLeetCode.UnitTests.Medium
{
    [TestClass]
    public class LongestSubstringWithoutRepeatingCharacters_3_Tests
    {
        private static IEnumerable<object[]> GetSolutions()
        {
            yield return new object[] { new LongestSubstringWithoutRepeatsBruteForceSolution_3(), "BruteForce" };
            yield return new object[] { new LongestSubstringWithoutRepeatsHashSetSolution_3(), "HashMap" };
            yield return new object[] { new LongestSubstringWithoutRepeatsSlidingWindowSolution_3(), "SlidingWindow" };
            yield return new object[] { new LongestSubstringWithoutRepeatingCharactersVB_3(), "VisualBasic" };
        }

        [TestMethod]
        [DynamicData(nameof(GetSolutions), DynamicDataSourceType.Method)]
        public void LengthOfLongestSubstring_Example1_Returns3(ILongestSubstringWithoutRepeatingCharacters_3 solution, string solutionName)
        {
            // Arrange
            string s = "abcabcbb";

            // Act
            int result = solution.LengthOfLongestSubstring(s);

            // Assert
            Assert.AreEqual(3, result, $"Failed for {solutionName}"); // "abc"
        }

        [TestMethod]
        [DynamicData(nameof(GetSolutions), DynamicDataSourceType.Method)]
        public void LengthOfLongestSubstring_Example2_Returns1(ILongestSubstringWithoutRepeatingCharacters_3 solution, string solutionName)
        {
            // Arrange
            string s = "bbbbb";

            // Act
            int result = solution.LengthOfLongestSubstring(s);

            // Assert
            Assert.AreEqual(1, result, $"Failed for {solutionName}"); // "b"
        }

        [TestMethod]
        [DynamicData(nameof(GetSolutions), DynamicDataSourceType.Method)]
        public void LengthOfLongestSubstring_Example3_Returns3(ILongestSubstringWithoutRepeatingCharacters_3 solution, string solutionName)
        {
            // Arrange
            string s = "pwwkew";

            // Act
            int result = solution.LengthOfLongestSubstring(s);

            // Assert
            Assert.AreEqual(3, result, $"Failed for {solutionName}"); // "wke"
        }

        [TestMethod]
        [DynamicData(nameof(GetSolutions), DynamicDataSourceType.Method)]
        public void LengthOfLongestSubstring_EmptyString_Returns0(ILongestSubstringWithoutRepeatingCharacters_3 solution, string solutionName)
        {
            // Arrange
            string s = "";

            // Act
            int result = solution.LengthOfLongestSubstring(s);

            // Assert
            Assert.AreEqual(0, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetSolutions), DynamicDataSourceType.Method)]
        public void LengthOfLongestSubstring_SingleCharacter_Returns1(ILongestSubstringWithoutRepeatingCharacters_3 solution, string solutionName)
        {
            // Arrange
            string s = "a";

            // Act
            int result = solution.LengthOfLongestSubstring(s);

            // Assert
            Assert.AreEqual(1, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetSolutions), DynamicDataSourceType.Method)]
        public void LengthOfLongestSubstring_AllUnique_ReturnsFullLength(ILongestSubstringWithoutRepeatingCharacters_3 solution, string solutionName)
        {
            // Arrange
            string s = "abcdef";

            // Act
            int result = solution.LengthOfLongestSubstring(s);

            // Assert
            Assert.AreEqual(6, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetSolutions), DynamicDataSourceType.Method)]
        public void LengthOfLongestSubstring_TwoCharacters_Returns2(ILongestSubstringWithoutRepeatingCharacters_3 solution, string solutionName)
        {
            // Arrange
            string s = "ab";

            // Act
            int result = solution.LengthOfLongestSubstring(s);

            // Assert
            Assert.AreEqual(2, result, $"Failed for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetSolutions), DynamicDataSourceType.Method)]
        public void LengthOfLongestSubstring_LongestAtEnd_ReturnsCorrect(ILongestSubstringWithoutRepeatingCharacters_3 solution, string solutionName)
        {
            // Arrange
            string s = "aabcdefg";

            // Act
            int result = solution.LengthOfLongestSubstring(s);

            // Assert
            Assert.AreEqual(7, result, $"Failed for {solutionName}"); // "abcdefg"
        }

        [TestMethod]
        [DynamicData(nameof(GetSolutions), DynamicDataSourceType.Method)]
        public void LengthOfLongestSubstring_LongestAtBeginning_ReturnsCorrect(ILongestSubstringWithoutRepeatingCharacters_3 solution, string solutionName)
        {
            // Arrange
            string s = "abcdefaa";

            // Act
            int result = solution.LengthOfLongestSubstring(s);

            // Assert
            Assert.AreEqual(6, result, $"Failed for {solutionName}"); // "abcdef"
        }

        [TestMethod]
        [DynamicData(nameof(GetSolutions), DynamicDataSourceType.Method)]
        public void LengthOfLongestSubstring_WithSpaces_Returns3(ILongestSubstringWithoutRepeatingCharacters_3 solution, string solutionName)
        {
            // Arrange
            string s = "a b c a";

            // Act
            int result = solution.LengthOfLongestSubstring(s);

            // Assert
            Assert.AreEqual(3, result, $"Failed for {solutionName}"); // "a b" or " bc"
        }

        [TestMethod]
        [DynamicData(nameof(GetSolutions), DynamicDataSourceType.Method)]
        public void LengthOfLongestSubstring_SpecialCharacters_ReturnsCorrect(ILongestSubstringWithoutRepeatingCharacters_3 solution, string solutionName)
        {
            // Arrange
            string s = "!@#!@#";

            // Act
            int result = solution.LengthOfLongestSubstring(s);

            // Assert
            Assert.AreEqual(3, result, $"Failed for {solutionName}"); // "!@#"
        }

        [TestMethod]
        [DynamicData(nameof(GetSolutions), DynamicDataSourceType.Method)]
        public void LengthOfLongestSubstring_Numbers_ReturnsCorrect(ILongestSubstringWithoutRepeatingCharacters_3 solution, string solutionName)
        {
            // Arrange
            string s = "12345123";

            // Act
            int result = solution.LengthOfLongestSubstring(s);

            // Assert
            Assert.AreEqual(5, result, $"Failed for {solutionName}"); // "12345"
        }

        [TestMethod]
        [DynamicData(nameof(GetSolutions), DynamicDataSourceType.Method)]
        public void LengthOfLongestSubstring_AlternatingPattern_ReturnsCorrect(ILongestSubstringWithoutRepeatingCharacters_3 solution, string solutionName)
        {
            // Arrange
            string s = "abababab";

            // Act
            int result = solution.LengthOfLongestSubstring(s);

            // Assert
            Assert.AreEqual(2, result, $"Failed for {solutionName}"); // "ab"
        }

        [TestMethod]
        [DynamicData(nameof(GetSolutions), DynamicDataSourceType.Method)]
        public void LengthOfLongestSubstring_ComplexPattern_ReturnsCorrect(ILongestSubstringWithoutRepeatingCharacters_3 solution, string solutionName)
        {
            // Arrange
            string s = "dvdf";

            // Act
            int result = solution.LengthOfLongestSubstring(s);

            // Assert
            Assert.AreEqual(3, result, $"Failed for {solutionName}"); // "vdf"
        }

        [TestMethod]
        [DynamicData(nameof(GetSolutions), DynamicDataSourceType.Method)]
        public void LengthOfLongestSubstring_LongRepeatingSequence_ReturnsCorrect(ILongestSubstringWithoutRepeatingCharacters_3 solution, string solutionName)
        {
            // Arrange
            string s = "anviaj";

            // Act
            int result = solution.LengthOfLongestSubstring(s);

            // Assert
            Assert.AreEqual(5, result, $"Failed for {solutionName}"); // "nviaj"
        }

        [TestMethod]
        [DynamicData(nameof(GetSolutions), DynamicDataSourceType.Method)]
        public void LengthOfLongestSubstring_ConsecutiveDuplicates_ReturnsCorrect(ILongestSubstringWithoutRepeatingCharacters_3 solution, string solutionName)
        {
            // Arrange
            string s = "aab";

            // Act
            int result = solution.LengthOfLongestSubstring(s);

            // Assert
            Assert.AreEqual(2, result, $"Failed for {solutionName}"); // "ab"
        }

        [TestMethod]
        [DynamicData(nameof(GetSolutions), DynamicDataSourceType.Method)]
        public void LengthOfLongestSubstring_TwoCharactersRepeating_Returns2(ILongestSubstringWithoutRepeatingCharacters_3 solution, string solutionName)
        {
            // Arrange
            string s = "au";

            // Act
            int result = solution.LengthOfLongestSubstring(s);

            // Assert
            Assert.AreEqual(2, result, $"Failed for {solutionName}");
        }
    }
}