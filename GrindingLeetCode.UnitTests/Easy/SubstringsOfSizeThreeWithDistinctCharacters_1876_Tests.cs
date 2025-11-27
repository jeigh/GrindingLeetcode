using LeetCodeProblems.CSharp.SlidingWindow;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GrindingLeetCode.UnitTests.Easy
{
    [TestClass]
    public class SubstringsOfSizeThreeWithDistinctCharacters_1876_Tests
    {
        private SubstringsOfSizeThreeWithDistinctCharacters_1876 _solution;

        [TestInitialize]
        public void Initialize()
        {
            _solution = new SubstringsOfSizeThreeWithDistinctCharacters_1876();
        }

        [TestMethod]
        public void CountGoodSubstrings_Example1_Returns1()
        {
            // Arrange
            string s = "xyzzaz";

            // Act
            int result = _solution.CountGoodSubstrings(s);

            // Assert
            Assert.AreEqual(1, result); // Only "xyz" has all distinct characters
        }

        [TestMethod]
        public void CountGoodSubstrings_Example2_Returns4()
        {
            // Arrange
            string s = "aababcabc";

            // Act
            int result = _solution.CountGoodSubstrings(s);

            // Assert
            Assert.AreEqual(4, result); // "bab", "abc", "bca", "cab" have all distinct characters
        }

        [TestMethod]
        public void CountGoodSubstrings_AllDistinct_ReturnsCorrectCount()
        {
            // Arrange
            string s = "abcdef";

            // Act
            int result = _solution.CountGoodSubstrings(s);

            // Assert
            Assert.AreEqual(4, result); // "abc", "bcd", "cde", "def"
        }

        [TestMethod]
        public void CountGoodSubstrings_NoDistinct_Returns0()
        {
            // Arrange
            string s = "aaa";

            // Act
            int result = _solution.CountGoodSubstrings(s);

            // Assert
            Assert.AreEqual(0, result); // No substrings with all distinct characters
        }

        [TestMethod]
        public void CountGoodSubstrings_TwoRepeating_Returns0()
        {
            // Arrange
            string s = "aabaa";

            // Act
            int result = _solution.CountGoodSubstrings(s);

            // Assert
            Assert.AreEqual(0, result); // "aab", "aba", "baa" all have repeating characters
        }

        [TestMethod]
        public void CountGoodSubstrings_ExactlyThreeCharacters_AllDistinct_Returns1()
        {
            // Arrange
            string s = "abc";

            // Act
            int result = _solution.CountGoodSubstrings(s);

            // Assert
            Assert.AreEqual(1, result); // Only "abc"
        }

        [TestMethod]
        public void CountGoodSubstrings_ExactlyThreeCharacters_WithRepeating_Returns0()
        {
            // Arrange
            string s = "aab";

            // Act
            int result = _solution.CountGoodSubstrings(s);

            // Assert
            Assert.AreEqual(0, result); // "aab" has repeating 'a'
        }

        [TestMethod]
        public void CountGoodSubstrings_LessThanThreeCharacters_Returns0()
        {
            // Arrange
            string s = "ab";

            // Act
            int result = _solution.CountGoodSubstrings(s);

            // Assert
            Assert.AreEqual(0, result); // Not enough characters for a substring of size 3
        }

        [TestMethod]
        public void CountGoodSubstrings_EmptyString_Returns0()
        {
            // Arrange
            string s = "";

            // Act
            int result = _solution.CountGoodSubstrings(s);

            // Assert
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void CountGoodSubstrings_SingleCharacter_Returns0()
        {
            // Arrange
            string s = "a";

            // Act
            int result = _solution.CountGoodSubstrings(s);

            // Assert
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void CountGoodSubstrings_AllSameCharacters_Returns0()
        {
            // Arrange
            string s = "aaaaa";

            // Act
            int result = _solution.CountGoodSubstrings(s);

            // Assert
            Assert.AreEqual(0, result); // All substrings have repeating characters
        }

        [TestMethod]
        public void CountGoodSubstrings_AlternatingPattern_ReturnsCorrectCount()
        {
            // Arrange
            string s = "abcabc";

            // Act
            int result = _solution.CountGoodSubstrings(s);

            // Assert
            Assert.AreEqual(4, result); // "abc", "bca", "cab", "abc"
        }

        [TestMethod]
        public void CountGoodSubstrings_MixedGoodAndBad_ReturnsCorrectCount()
        {
            // Arrange
            string s = "abcabcbb";

            // Act
            int result = _solution.CountGoodSubstrings(s);

            // Assert
            Assert.AreEqual(4, result); // "abc", "bca", "cab", "abc" (skip "bcb", "cbb")
        }

        [TestMethod]
        public void CountGoodSubstrings_WithDoubleLetters_ReturnsCorrectCount()
        {
            // Arrange
            string s = "aabbcc";

            // Act
            int result = _solution.CountGoodSubstrings(s);

            // Assert
            Assert.AreEqual(0, result); // "aab", "abb", "bbc", "bcc" all have repeating characters
        }

        [TestMethod]
        public void CountGoodSubstrings_LongStringAllDistinct_ReturnsCorrectCount()
        {
            // Arrange
            string s = "abcdefgh";

            // Act
            int result = _solution.CountGoodSubstrings(s);

            // Assert
            Assert.AreEqual(6, result); // "abc", "bcd", "cde", "def", "efg", "fgh"
        }
    }
}