using LeetCodeProblems.HashingOrArrays;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace GrindingLeetCode.UnitTests.Medium
{
    [TestClass]
    public class GroupAnagramsSolution_49_Tests
    {
        private GroupAnagramsSolution_OOP_49 _solution;

        [TestInitialize]
        public void Initialize()
        {
            _solution = new GroupAnagramsSolution_OOP_49();
        }

        private static List<List<string>> NormalizeResult(IList<IList<string>> result)
        {
            // Sort each group and the list of groups for comparison
            return result.Select(group => group.OrderBy(s => s).ToList())
                         .OrderBy(group => group.FirstOrDefault() ?? "")
                         .ToList();
        }

        [TestMethod]
        public void GroupAnagrams_Example1_ReturnsCorrectGroups()
        {
            string[] strs = { "eat", "tea", "tan", "ate", "nat", "bat" };
            var expected = new List<IList<string>>
            {
                new List<string> { "bat" },
                new List<string> { "nat", "tan" },
                new List<string> { "ate", "eat", "tea" }
            };

            var result = _solution.GroupAnagrams(strs);
            var normalizedResult = NormalizeResult(result);
            var normalizedExpected = NormalizeResult(expected);

            Assert.AreEqual(normalizedExpected.Count, normalizedResult.Count);
            for (int i = 0; i < normalizedExpected.Count; i++)
            {
                CollectionAssert.AreEquivalent(normalizedExpected[i], normalizedResult[i]);
            }
        }

        [TestMethod]
        public void GroupAnagrams_EmptyArray_ReturnsEmptyList()
        {
            string[] strs = { };
            var result = _solution.GroupAnagrams(strs);
            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public void GroupAnagrams_SingleString_ReturnsSingleGroup()
        {
            string[] strs = { "abc" };
            var result = _solution.GroupAnagrams(strs);
            Assert.AreEqual(1, result.Count);
            CollectionAssert.AreEquivalent(new[] { "abc" }, result[0].ToArray());
        }

        [TestMethod]
        public void GroupAnagrams_AllAnagrams_ReturnsSingleGroup()
        {
            string[] strs = { "abc", "bca", "cab", "bac", "acb", "cba" };
            var result = _solution.GroupAnagrams(strs);
            Assert.AreEqual(1, result.Count);
            CollectionAssert.AreEquivalent(strs, result[0].ToArray());
        }

        [TestMethod]
        public void GroupAnagrams_NoAnagrams_ReturnsSeparateGroups()
        {
            string[] strs = { "a", "b", "c" };
            var result = _solution.GroupAnagrams(strs);
            Assert.AreEqual(3, result.Count);
            var allStrings = result.SelectMany(g => g).ToList();
            CollectionAssert.AreEquivalent(new[] { "a", "b", "c" }, allStrings);
        }

        [TestMethod]
        public void GroupAnagrams_AnagramsWithEmptyString_ReturnsCorrectGroups()
        {
            string[] strs = { "", "" };
            var result = _solution.GroupAnagrams(strs);
            Assert.AreEqual(1, result.Count);
            CollectionAssert.AreEquivalent(new[] { "", "" }, result[0].ToArray());
        }
    }
}