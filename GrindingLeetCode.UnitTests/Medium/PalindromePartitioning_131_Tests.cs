using LeetCodeProblems.CSharp.Backtracking;
using LeetCodeProblems.Interfaces.Medium;
using LeetCodeProblems.VisualBasic.Backtracking;

namespace GrindingLeetCode.UnitTests.Medium
{
    [TestClass]
    public class PalindromePartitioning_131_Tests
    {
        public static IEnumerable<object[]> GetImplementations()
        {
            yield return new object[] { new PalindromePartitioning_Backtracking_CSharp_131(), "C# Backtracking" };
            yield return new object[] { new PalindromePartitioning_Backtracking_VB_131(), "VB Backtracking" };
        }

        #region Helper Methods

        private static IEnumerable<string> Normalize(IList<IList<string>> partitions) =>
            partitions.Select(p => string.Join(",", p)).OrderBy(s => s);

        private static void AssertPartitions(IList<IList<string>> expected, IList<IList<string>> actual, string solutionName)
        {
            CollectionAssert.AreEqual(
                Normalize(expected).ToList(),
                Normalize(actual).ToList(),
                $"[{solutionName}]");
        }

        #endregion

        #region LeetCode Examples

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Partition_Example1_AAB_ReturnsCorrectPartitions(IPalindromePartitioning_131 solution, string solutionName)
        {
            // Input: s = "aab"
            // Output: [["a","a","b"],["aa","b"]]
            var expected = new List<IList<string>>
            {
                new List<string> { "a", "a", "b" },
                new List<string> { "aa", "b" }
            };
            AssertPartitions(expected, solution.Partition("aab"), solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Partition_Example2_SingleChar_ReturnsSinglePartition(IPalindromePartitioning_131 solution, string solutionName)
        {
            // Input: s = "a"
            // Output: [["a"]]
            var expected = new List<IList<string>> { new List<string> { "a" } };
            AssertPartitions(expected, solution.Partition("a"), solutionName);
        }

        #endregion

        #region Single Character

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Partition_SingleChar_CountIsOne(IPalindromePartitioning_131 solution, string solutionName)
        {
            var result = solution.Partition("z");
            Assert.AreEqual(1, result.Count, $"[{solutionName}]");
            Assert.AreEqual("z", result[0][0], $"[{solutionName}]");
        }

        #endregion

        #region Two Characters

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Partition_TwoSameChars_ReturnsTwoPartitions(IPalindromePartitioning_131 solution, string solutionName)
        {
            // "aa" → [["a","a"], ["aa"]]
            var expected = new List<IList<string>>
            {
                new List<string> { "a", "a" },
                new List<string> { "aa" }
            };
            AssertPartitions(expected, solution.Partition("aa"), solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Partition_TwoDifferentChars_ReturnsOnePartition(IPalindromePartitioning_131 solution, string solutionName)
        {
            // "ab" → [["a","b"]] — "ab" is not a palindrome
            var expected = new List<IList<string>>
            {
                new List<string> { "a", "b" }
            };
            AssertPartitions(expected, solution.Partition("ab"), solutionName);
        }

        #endregion

        #region Three Characters

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Partition_ThreeUniqueChars_ReturnsOnlyIndividualChars(IPalindromePartitioning_131 solution, string solutionName)
        {
            // "abc" → [["a","b","c"]] — no multi-char palindromes
            var expected = new List<IList<string>>
            {
                new List<string> { "a", "b", "c" }
            };
            AssertPartitions(expected, solution.Partition("abc"), solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Partition_Palindrome_ABA_ReturnsTwoPartitions(IPalindromePartitioning_131 solution, string solutionName)
        {
            // "aba" → [["a","b","a"], ["aba"]]
            var expected = new List<IList<string>>
            {
                new List<string> { "a", "b", "a" },
                new List<string> { "aba" }
            };
            AssertPartitions(expected, solution.Partition("aba"), solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Partition_AllSameChars_AAA_ReturnsFourPartitions(IPalindromePartitioning_131 solution, string solutionName)
        {
            // "aaa" → [["a","a","a"], ["a","aa"], ["aa","a"], ["aaa"]]
            var expected = new List<IList<string>>
            {
                new List<string> { "a", "a", "a" },
                new List<string> { "a", "aa" },
                new List<string> { "aa", "a" },
                new List<string> { "aaa" }
            };
            AssertPartitions(expected, solution.Partition("aaa"), solutionName);
        }

        #endregion

        #region Longer Strings

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Partition_ABBA_ReturnsThreePartitions(IPalindromePartitioning_131 solution, string solutionName)
        {
            // "abba" → [["a","b","b","a"], ["a","bb","a"], ["abba"]]
            var expected = new List<IList<string>>
            {
                new List<string> { "a", "b", "b", "a" },
                new List<string> { "a", "bb", "a" },
                new List<string> { "abba" }
            };
            AssertPartitions(expected, solution.Partition("abba"), solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Partition_AABB_ReturnsCorrectPartitions(IPalindromePartitioning_131 solution, string solutionName)
        {
            // "aabb" → [["a","a","b","b"], ["a","a","bb"], ["aa","b","b"], ["aa","bb"]]
            var expected = new List<IList<string>>
            {
                new List<string> { "a", "a", "b", "b" },
                new List<string> { "a", "a", "bb" },
                new List<string> { "aa", "b", "b" },
                new List<string> { "aa", "bb" }
            };
            AssertPartitions(expected, solution.Partition("aabb"), solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Partition_EveryPartitionCountIsCorrect(IPalindromePartitioning_131 solution, string solutionName)
        {
            // "aab" has exactly 2 valid partitions
            Assert.AreEqual(2, solution.Partition("aab").Count, $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Partition_AllSubstringsArePalindromes(IPalindromePartitioning_131 solution, string solutionName)
        {
            var result = solution.Partition("aab");
            foreach (var partition in result)
                foreach (var substr in partition)
                    Assert.IsTrue(IsPalindrome(substr), $"[{solutionName}] '{substr}' is not a palindrome");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Partition_AllSubstringsJoinToOriginal(IPalindromePartitioning_131 solution, string solutionName)
        {
            const string s = "aab";
            var result = solution.Partition(s);
            foreach (var partition in result)
                Assert.AreEqual(s, string.Concat(partition), $"[{solutionName}] partition does not reconstruct the original string");
        }

        #endregion

        #region Invariant Tests

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Partition_NoDuplicatePartitions(IPalindromePartitioning_131 solution, string solutionName)
        {
            var result = solution.Partition("aab");
            var normalized = result.Select(p => string.Join(",", p)).ToList();
            Assert.AreEqual(normalized.Count, normalized.Distinct().Count(), $"[{solutionName}] result contains duplicate partitions");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Partition_LongerInput_AllSubstringsArePalindromes(IPalindromePartitioning_131 solution, string solutionName)
        {
            var result = solution.Partition("abba");
            foreach (var partition in result)
                foreach (var substr in partition)
                    Assert.IsTrue(IsPalindrome(substr), $"[{solutionName}] '{substr}' is not a palindrome");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Partition_LongerInput_AllSubstringsJoinToOriginal(IPalindromePartitioning_131 solution, string solutionName)
        {
            const string s = "abba";
            var result = solution.Partition(s);
            foreach (var partition in result)
                Assert.AreEqual(s, string.Concat(partition), $"[{solutionName}] partition does not reconstruct the original string");
        }

        #endregion

        #region Private Helpers

        private static bool IsPalindrome(string s)
        {
            int l = 0, r = s.Length - 1;
            while (l < r)
                if (s[l++] != s[r--]) return false;
            return true;
        }

        #endregion
    }
}
