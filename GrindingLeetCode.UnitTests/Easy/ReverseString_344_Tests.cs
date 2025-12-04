using LeetCodeProblems.TwoPointers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GrindingLeetCode.UnitTests.Easy
{
    [TestClass]
    public class ReverseString_344_Tests
    {
        private ReverseString_344 _solution;

        [TestInitialize]
        public void Initialize()
        {
            _solution = new ReverseString_344();
        }

        [TestMethod]
        public void ReverseString_EvenLength_ReversesCorrectly()
        {
            char[] input = { 'h', 'e', 'l', 'l', 'o', '!' };
            _solution.ReverseString(input);
            CollectionAssert.AreEqual(new[] { '!', 'o', 'l', 'l', 'e', 'h' }, input);
        }

        [TestMethod]
        public void ReverseString_OddLength_ReversesCorrectly()
        {
            char[] input = { 'a', 'b', 'c', 'd', 'e' };
            _solution.ReverseString(input);
            CollectionAssert.AreEqual(new[] { 'e', 'd', 'c', 'b', 'a' }, input);
        }

        [TestMethod]
        public void ReverseString_SingleCharacter_NoChange()
        {
            char[] input = { 'z' };
            _solution.ReverseString(input);
            CollectionAssert.AreEqual(new[] { 'z' }, input);
        }

        [TestMethod]
        public void ReverseString_EmptyArray_NoChange()
        {
            char[] input = { };
            _solution.ReverseString(input);
            CollectionAssert.AreEqual(new char[0], input);
        }

        [TestMethod]
        public void ReverseString_Palindrome_NoChangeInContent()
        {
            char[] input = { 'r', 'a', 'c', 'e', 'c', 'a', 'r' };
            _solution.ReverseString(input);
            CollectionAssert.AreEqual(new[] { 'r', 'a', 'c', 'e', 'c', 'a', 'r' }, input);
        }
    }
}