using LeetCodeProblems.HashingOrArrays;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GrindingLeetCode.UnitTests.HashingOrArrays
{
    [TestClass]
    public class ValidAnagramSolution_242_Tests
    {
        private ValidAnagramSolution_242 _solution;

        [TestInitialize]
        public void Initialize()
        {
            _solution = new ValidAnagramSolution_242();
        }

        [TestMethod]
        public void IsAnagram_IdenticalStrings_ReturnsTrue()
        {
            Assert.IsTrue(_solution.IsAnagram("abc", "abc"));
        }

        [TestMethod]
        public void IsAnagram_AnagramStrings_ReturnsTrue()
        {
            Assert.IsTrue(_solution.IsAnagram("anagram", "nagaram"));
        }

        [TestMethod]
        public void IsAnagram_DifferentLengthStrings_ReturnsFalse()
        {
            Assert.IsFalse(_solution.IsAnagram("rat", "carp"));
        }

        [TestMethod]
        public void IsAnagram_NotAnagram_ReturnsFalse()
        {
            Assert.IsFalse(_solution.IsAnagram("hello", "bello"));
        }

        [TestMethod]
        public void IsAnagram_EmptyStrings_ReturnsTrue()
        {
            Assert.IsTrue(_solution.IsAnagram("", ""));
        }

        [TestMethod]
        public void IsAnagram_OneEmptyOneNonEmpty_ReturnsFalse()
        {
            Assert.IsFalse(_solution.IsAnagram("", "a"));
        }
    }
}