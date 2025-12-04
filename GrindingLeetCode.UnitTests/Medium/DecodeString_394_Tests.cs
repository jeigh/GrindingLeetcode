using LeetCodeProblems.CSharp.Stack;
using LeetCodeProblems.Interfaces.Medium;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GrindingLeetCode.UnitTests.Medium
{
    [TestClass]
    public class DecodeString_394_Tests
    {
        public static IEnumerable<object[]> GetImplementations()
        {
            yield return new object[] { new DecodeString_394() };
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void DecodeString_Example1_ReturnsAaabc(IDecodeString_394 solution)
        {
            // Arrange
            string s = "3[a]2[bc]";

            // Act
            string result = solution.DecodeString(s);

            // Assert
            Assert.AreEqual("aaabcbc", result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void DecodeString_Example2_ReturnsAccaccacc(IDecodeString_394 solution)
        {
            // Arrange
            string s = "3[a2[c]]";

            // Act
            string result = solution.DecodeString(s);

            // Assert
            Assert.AreEqual("accaccacc", result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void DecodeString_Example3_ReturnsAbccdcdcdef(IDecodeString_394 solution)
        {
            // Arrange
            string s = "2[abc]3[cd]ef";

            // Act
            string result = solution.DecodeString(s);

            // Assert
            Assert.AreEqual("abcabccdcdcdef", result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void DecodeString_NoEncoding_ReturnsOriginal(IDecodeString_394 solution)
        {
            // Arrange
            string s = "abc";

            // Act
            string result = solution.DecodeString(s);

            // Assert
            Assert.AreEqual("abc", result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void DecodeString_SingleCharacterEncoded_ReturnsRepeated(IDecodeString_394 solution)
        {
            // Arrange
            string s = "3[a]";

            // Act
            string result = solution.DecodeString(s);

            // Assert
            Assert.AreEqual("aaa", result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void DecodeString_MultipleCharactersEncoded_ReturnsRepeated(IDecodeString_394 solution)
        {
            // Arrange
            string s = "2[abc]";

            // Act
            string result = solution.DecodeString(s);

            // Assert
            Assert.AreEqual("abcabc", result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void DecodeString_NestedOnce_ReturnsCorrect(IDecodeString_394 solution)
        {
            // Arrange
            string s = "2[a2[b]]";

            // Act
            string result = solution.DecodeString(s);

            // Assert
            Assert.AreEqual("abbabb", result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void DecodeString_DeeplyNested_ReturnsCorrect(IDecodeString_394 solution)
        {
            // Arrange
            string s = "2[2[2[a]]]";

            // Act
            string result = solution.DecodeString(s);

            // Assert
            Assert.AreEqual("aaaaaaaa", result); // 2 * 2 * 2 * a = 8 a's
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void DecodeString_TwoDigitNumber_ReturnsCorrect(IDecodeString_394 solution)
        {
            // Arrange
            string s = "10[a]";

            // Act
            string result = solution.DecodeString(s);

            // Assert
            Assert.AreEqual("aaaaaaaaaa", result); // 10 a's
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void DecodeString_ThreeDigitNumber_ReturnsCorrect(IDecodeString_394 solution)
        {
            // Arrange
            string s = "100[a]";

            // Act
            string result = solution.DecodeString(s);

            // Assert
            Assert.AreEqual(new string('a', 100), result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void DecodeString_MultipleEncodedSections_ReturnsCorrect(IDecodeString_394 solution)
        {
            // Arrange
            string s = "2[a]3[b]";

            // Act
            string result = solution.DecodeString(s);

            // Assert
            Assert.AreEqual("aabbb", result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void DecodeString_EncodedWithPrefix_ReturnsCorrect(IDecodeString_394 solution)
        {
            // Arrange
            string s = "a2[b]";

            // Act
            string result = solution.DecodeString(s);

            // Assert
            Assert.AreEqual("abb", result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void DecodeString_EncodedWithSuffix_ReturnsCorrect(IDecodeString_394 solution)
        {
            // Arrange
            string s = "2[a]b";

            // Act
            string result = solution.DecodeString(s);

            // Assert
            Assert.AreEqual("aab", result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void DecodeString_EncodedWithPrefixAndSuffix_ReturnsCorrect(IDecodeString_394 solution)
        {
            // Arrange
            string s = "a2[b]c";

            // Act
            string result = solution.DecodeString(s);

            // Assert
            Assert.AreEqual("abbc", result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void DecodeString_SingleRepetition_ReturnsCorrect(IDecodeString_394 solution)
        {
            // Arrange
            string s = "1[abc]";

            // Act
            string result = solution.DecodeString(s);

            // Assert
            Assert.AreEqual("abc", result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void DecodeString_NestedWithDifferentNumbers_ReturnsCorrect(IDecodeString_394 solution)
        {
            // Arrange
            string s = "3[a2[b]c]";

            // Act
            string result = solution.DecodeString(s);

            // Assert
            Assert.AreEqual("abbcabbcabbc", result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void DecodeString_ConsecutiveNested_ReturnsCorrect(IDecodeString_394 solution)
        {
            // Arrange
            string s = "2[a]2[b]";

            // Act
            string result = solution.DecodeString(s);

            // Assert
            Assert.AreEqual("aabb", result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void DecodeString_ComplexNesting_ReturnsCorrect(IDecodeString_394 solution)
        {
            // Arrange
            string s = "2[a2[b2[c]]]";

            // Act
            string result = solution.DecodeString(s);

            // Assert
            Assert.AreEqual("abccbccabccbcc", result); // 2 * (a + 2 * (b + 2 * c))
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void DecodeString_EmptyBrackets_ReturnsCorrect(IDecodeString_394 solution)
        {
            // Arrange - Note: Based on constraints, this shouldn't happen, but testing edge case
            string s = "a3[]b";

            // Act
            string result = solution.DecodeString(s);

            // Assert
            Assert.AreEqual("ab", result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void DecodeString_MultipleNestedLevels_ReturnsCorrect(IDecodeString_394 solution)
        {
            // Arrange
            string s = "3[z]2[2[y]pq4[2[jk]e1[f]]]ef";

            // Act
            string result = solution.DecodeString(s);

            // Assert
            // zzz + 2 * (yypq + 4 * (jkjkef)) + ef
            // zzz + 2 * (yypqjkjkefjkjkefjkjkefjkjkef)
            Assert.AreEqual("zzzyypqjkjkefjkjkefjkjkefjkjkefyypqjkjkefjkjkefjkjkefjkjkefef", result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void DecodeString_OnlyNumbers_NoLetters_ReturnsEmpty(IDecodeString_394 solution)
        {
            // Arrange - Malformed but testing
            string s = "10[]";

            // Act
            string result = solution.DecodeString(s);

            // Assert
            Assert.AreEqual("", result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void DecodeString_LongString_ReturnsCorrect(IDecodeString_394 solution)
        {
            // Arrange
            string s = "abc3[cd]xyz";

            // Act
            string result = solution.DecodeString(s);

            // Assert
            Assert.AreEqual("abccdcdcdxyz", result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void DecodeString_NestedAtEnd_ReturnsCorrect(IDecodeString_394 solution)
        {
            // Arrange
            string s = "abc2[de2[f]]";

            // Act
            string result = solution.DecodeString(s);

            // Assert
            Assert.AreEqual("abcdeffdeff", result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void DecodeString_NestedAtStart_ReturnsCorrect(IDecodeString_394 solution)
        {
            // Arrange
            string s = "2[a2[b]]xyz";

            // Act
            string result = solution.DecodeString(s);

            // Assert
            Assert.AreEqual("abbabbxyz", result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void DecodeString_MultipleAdjacentEncoded_ReturnsCorrect(IDecodeString_394 solution)
        {
            // Arrange
            string s = "2[a]2[b]2[c]";

            // Act
            string result = solution.DecodeString(s);

            // Assert
            Assert.AreEqual("aabbcc", result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void DecodeString_SingleLetter_ReturnsLetter(IDecodeString_394 solution)
        {
            // Arrange
            string s = "a";

            // Act
            string result = solution.DecodeString(s);

            // Assert
            Assert.AreEqual("a", result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void DecodeString_NestedDifferentDepths_ReturnsCorrect(IDecodeString_394 solution)
        {
            // Arrange
            string s = "2[abc]3[cd]ef";

            // Act
            string result = solution.DecodeString(s);

            // Assert
            Assert.AreEqual("abcabccdcdcdef", result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void DecodeString_LargeMultiplier_ReturnsCorrect(IDecodeString_394 solution)
        {
            // Arrange
            string s = "20[a]";

            // Act
            string result = solution.DecodeString(s);

            // Assert
            Assert.AreEqual(new string('a', 20), result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void DecodeString_MixedCase_PreservesCase(IDecodeString_394 solution)
        {
            // Arrange
            string s = "2[Ab]";

            // Act
            string result = solution.DecodeString(s);

            // Assert
            Assert.AreEqual("AbAb", result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void DecodeString_TripleNesting_ReturnsCorrect(IDecodeString_394 solution)
        {
            // Arrange
            string s = "2[2[2[a]b]c]";

            // Act
            string result = solution.DecodeString(s);

            // Assert
            Assert.AreEqual("aabaabcaabaabc", result);
        }
    }
}