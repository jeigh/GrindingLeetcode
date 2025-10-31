using LeetCodeProblems.HashingOrArrays;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GrindingLeetCode.UnitTests.HashingOrArrays
{
    [TestClass]
    public class LongestCommonPrefixSolution_14_Tests
    {
        private LongestCommonprefixSolution_14 _solution;

        [TestInitialize]
        public void Initialize()
        {
            _solution = new LongestCommonprefixSolution_14();
        }

        [TestMethod]
        public void LongestCommonPrefix_Example_ReturnsFl()
        {
            string[] strs = { "flower", "flow", "flight" };
            string result = _solution.LongestCommonPrefix(strs);
            Assert.AreEqual("fl", result);
        }

        [TestMethod]
        public void LongestCommonPrefix_NoCommonPrefix_ReturnsEmptyString()
        {
            string[] strs = { "dog", "racecar", "car" };
            string result = _solution.LongestCommonPrefix(strs);
            Assert.AreEqual("", result);
        }

        [TestMethod]
        public void LongestCommonPrefix_AllStringsIdentical_ReturnsFullString()
        {
            string[] strs = { "test", "test", "test" };
            string result = _solution.LongestCommonPrefix(strs);
            Assert.AreEqual("test", result);
        }

        [TestMethod]
        public void LongestCommonPrefix_EmptyArray_ReturnsEmptyString()
        {
            string[] strs = { };
            string result = _solution.LongestCommonPrefix(strs);
            Assert.AreEqual("", result);
        }

        [TestMethod]
        public void EmptyString()
        {
            string[] strs = { "", "yodog" };
            string result = _solution.LongestCommonPrefix(strs);
            Assert.AreEqual("", result);
        }

        [TestMethod]
        public void LongestCommonPrefix_SingleString_ReturnsThatString()
        {
            string[] strs = { "alone" };
            string result = _solution.LongestCommonPrefix(strs);
            Assert.AreEqual("alone", result);
        }

        [TestMethod]
        public void LongestCommonPrefix_ContainsEmptyString_ReturnsEmptyString()
        {
            string[] strs = { "prefix", "" };
            string result = _solution.LongestCommonPrefix(strs);
            Assert.AreEqual("", result);
        }

        [TestMethod]
        public void LongestCommonPrefix_PartialMatch_ReturnsCorrectPrefix()
        {
            string[] strs = { "interview", "internet", "internal", "interval" };
            string result = _solution.LongestCommonPrefix(strs);
            Assert.AreEqual("inter", result);
        }
    }
}