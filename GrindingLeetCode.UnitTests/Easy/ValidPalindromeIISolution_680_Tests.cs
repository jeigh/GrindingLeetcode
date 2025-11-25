using LeetCodeProblems.TwoPointers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GrindingLeetCode.UnitTests.Easy
{
    [TestClass]
    public class ValidPalindromeIISolution_680_Tests
    {
        private ValidPalindromeIISolution_680 _solution;

        [TestInitialize]
        public void Initialize()
        {
            _solution = new ValidPalindromeIISolution_680();
        }

        [TestMethod]
        public void ValidPalindrome_Example1_ReturnsTrue()
        {
            string s = "aba";
            Assert.IsTrue(_solution.ValidPalindrome(s));
        }

        [TestMethod]
        public void ValidPalindrome_Example2_ReturnsTrue()
        {
            string s = "abca";
            Assert.IsTrue(_solution.ValidPalindrome(s));
        }

        [TestMethod]
        public void ValidPalindrome_Example3_ReturnsFalse()
        {
            string s = "abc";
            Assert.IsFalse(_solution.ValidPalindrome(s));
        }

        [TestMethod]
        public void ValidPalindrome_EmptyString_ReturnsTrue()
        {
            string s = "";
            Assert.IsTrue(_solution.ValidPalindrome(s));
        }

        [TestMethod]
        public void ValidPalindrome_SingleCharacter_ReturnsTrue()
        {
            string s = "x";
            Assert.IsTrue(_solution.ValidPalindrome(s));
        }

        [TestMethod]
        public void ValidPalindrome_TwoCharactersSame_ReturnsTrue()
        {
            string s = "cc";
            Assert.IsTrue(_solution.ValidPalindrome(s));
        }

        [TestMethod]
        public void ValidPalindrome_TwoCharactersDifferent_ReturnsTrue()
        {
            string s = "ca";
            Assert.IsTrue(_solution.ValidPalindrome(s));
        }

        [TestMethod]
        public void ValidPalindrome_RemoveOneInMiddle_ReturnsTrue()
        {
            string s = "deeee";
            Assert.IsTrue(_solution.ValidPalindrome(s));
        }

        [TestMethod]
        public void ValidPalindrome_RemoveOneAtStart_ReturnsTrue()
        {
            string s = "ececabbacec";
            Assert.IsTrue(_solution.ValidPalindrome(s));
        }

        [TestMethod]
        public void ValidPalindrome_NotPossibleWithOneRemoval_ReturnsFalse()
        {
            string s = "abcdef";
            Assert.IsFalse(_solution.ValidPalindrome(s));
        }
    }
}