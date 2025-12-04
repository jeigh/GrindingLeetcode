using LeetCodeProblems.TwoPointers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GrindingLeetCode.UnitTests.Easy
{
    [TestClass]
    public class MergeStringsAlternatelySolution_1768_Tests
    {
        private MergeStringsAlternatelySolution_1768 _solution;

        [TestInitialize]
        public void Initialize()
        {
            _solution = new MergeStringsAlternatelySolution_1768();
        }

        [TestMethod]
        public void MergeAlternately_Example1_ReturnsCorrectResult()
        {
            string word1 = "abc";
            string word2 = "pqr";
            string result = _solution.MergeAlternately(word1, word2);
            Assert.AreEqual("apbqcr", result);
        }

        [TestMethod]
        public void MergeAlternately_Word1Longer_AppendsRest()
        {
            string word1 = "ab";
            string word2 = "pqrs";
            string result = _solution.MergeAlternately(word1, word2);
            Assert.AreEqual("apbqrs", result);
        }

        [TestMethod]
        public void MergeAlternately_Word2Longer_AppendsRest()
        {
            string word1 = "abcd";
            string word2 = "pq";
            string result = _solution.MergeAlternately(word1, word2);
            Assert.AreEqual("apbqcd", result);
        }

        [TestMethod]
        public void MergeAlternately_OneEmpty_ReturnsOther()
        {
            string word1 = "";
            string word2 = "xyz";
            string result = _solution.MergeAlternately(word1, word2);
            Assert.AreEqual("xyz", result);

            word1 = "abc";
            word2 = "";
            result = _solution.MergeAlternately(word1, word2);
            Assert.AreEqual("abc", result);
        }

        [TestMethod]
        public void MergeAlternately_BothEmpty_ReturnsEmpty()
        {
            string word1 = "";
            string word2 = "";
            string result = _solution.MergeAlternately(word1, word2);
            Assert.AreEqual("", result);
        }

        [TestMethod]
        public void MergeAlternately_SingleCharacterEach()
        {
            string word1 = "a";
            string word2 = "b";
            string result = _solution.MergeAlternately(word1, word2);
            Assert.AreEqual("ab", result);
        }

        [TestMethod]
        public void MergeAlternately_SpecialCharacters()
        {
            string word1 = "A!";
            string word2 = "1@";
            string result = _solution.MergeAlternately(word1, word2);
            Assert.AreEqual("A1!@", result);
        }
    }
}