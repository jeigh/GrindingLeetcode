using LeetCodeProblems.TwoPointers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GrindingLeetCode.UnitTests.TwoPointers
{
    [TestClass]
    public class ValidPalindromeSolution_125_Tests
    {
        private ValidPalindromeSolution_125 _solution;

        [TestInitialize]
        public void Initialize()
        {
            _solution = new ValidPalindromeSolution_125();
        }

        [TestMethod]
        public void IsPalindrome_Example1_ReturnsTrue()
        {
            string s = "A man, a plan, a canal: Panama";
            Assert.IsTrue(_solution.IsPalindrome(s));
        }

        [TestMethod]
        public void IsPalindrome_Example2_ReturnsFalse()
        {
            string s = "race a car";
            Assert.IsFalse(_solution.IsPalindrome(s));
        }

        [TestMethod]
        public void IsPalindrome_EmptyString_ReturnsTrue()
        {
            string s = "";
            Assert.IsTrue(_solution.IsPalindrome(s));
        }

        [TestMethod]
        public void IsPalindrome_OnlyNonAlphanumeric_ReturnsTrue()
        {
            string s = ".,;:!";
            Assert.IsTrue(_solution.IsPalindrome(s));
        }

        [TestMethod]
        public void IsPalindrome_SingleCharacter_ReturnsTrue()
        {
            string s = "z";
            Assert.IsTrue(_solution.IsPalindrome(s));
        }

        [TestMethod]
        public void IsPalindrome_MixedCasePalindrome_ReturnsTrue()
        {
            string s = "Noon";
            Assert.IsTrue(_solution.IsPalindrome(s));
        }

        [TestMethod]
        public void IsPalindrome_NumericPalindrome_ReturnsTrue()
        {
            string s = "12321";
            Assert.IsTrue(_solution.IsPalindrome(s));
        }

        [TestMethod]
        public void IsPalindrome_NumericNonPalindrome_ReturnsFalse()
        {
            string s = "12345";
            Assert.IsFalse(_solution.IsPalindrome(s));
        }

        [TestMethod]
        public void IsPalindrome_AlphanumericPalindrome_ReturnsTrue()
        {
            string s = "1a2b2a1";
            Assert.IsTrue(_solution.IsPalindrome(s));
        }

        [TestMethod]
        public void IsPalindrome_AlphanumericNonPalindrome_ReturnsFalse()
        {
            string s = "1a2b3c";
            Assert.IsFalse(_solution.IsPalindrome(s));
        }
    }
}