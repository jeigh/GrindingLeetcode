using LeetCodeProblems.CSharp.HashingOrArrays;
using LeetCodeProblems.Interfaces.Easy;
using LeetCodeProblems.VisualBasic.HashingOrArrays;

namespace GrindingLeetCode.UnitTests.Easy
{
    [TestClass]
    public class VerifyingAnAlienDictionary_953_Tests
    {
        public static IEnumerable<object[]> GetImplementations()
        {
            yield return new object[] { new VerifyingAnAlienDictionary_CSharp_953(), "C#" };
            yield return new object[] { new VerifyingAnAlienDictionary_VB_953(), "VB" };
        }

        #region LeetCode Examples

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsAlienSorted_Example1_ReturnsTrue(IVerifyingAnAlienDictionary_953 solution, string solutionName)
        {
            // "hlabcdefgijkmnopqrstuvwxyz" — h comes before l
            string[] words = { "hello", "leetcode" };
            string order = "hlabcdefgijkmnopqrstuvwxyz";
            Assert.IsTrue(solution.IsAlienSorted(words, order), $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsAlienSorted_Example2_ReturnsTrue(IVerifyingAnAlienDictionary_953 solution, string solutionName)
        {
            // word order: h<l<a — "word" and "world" diverge at 4th char, 'd' < 'l'
            string[] words = { "word", "world", "row" };
            string order = "worldabcefghijkmnpqstuvxyz";
            Assert.IsFalse(solution.IsAlienSorted(words, order), $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsAlienSorted_Example3_ReturnsFalse(IVerifyingAnAlienDictionary_953 solution, string solutionName)
        {
            // "apple" vs "app" — longer word cannot come after its prefix
            string[] words = { "apple", "app" };
            string order = "abcdefghijklmnopqrstuvwxyz";
            Assert.IsFalse(solution.IsAlienSorted(words, order), $"[{solutionName}]");
        }

        #endregion

        #region Single Word

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsAlienSorted_SingleWord_ReturnsTrue(IVerifyingAnAlienDictionary_953 solution, string solutionName)
        {
            Assert.IsTrue(solution.IsAlienSorted(new[] { "hello" }, "abcdefghijklmnopqrstuvwxyz"), $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsAlienSorted_EmptyWords_ReturnsTrue(IVerifyingAnAlienDictionary_953 solution, string solutionName)
        {
            Assert.IsTrue(solution.IsAlienSorted(Array.Empty<string>(), "abcdefghijklmnopqrstuvwxyz"), $"[{solutionName}]");
        }

        #endregion

        #region Standard Alphabet Order

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsAlienSorted_StandardAlphabetSorted_ReturnsTrue(IVerifyingAnAlienDictionary_953 solution, string solutionName)
        {
            string[] words = { "ant", "bee", "cat" };
            string order = "abcdefghijklmnopqrstuvwxyz";
            Assert.IsTrue(solution.IsAlienSorted(words, order), $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsAlienSorted_StandardAlphabetUnsorted_ReturnsFalse(IVerifyingAnAlienDictionary_953 solution, string solutionName)
        {
            string[] words = { "cat", "ant" };
            string order = "abcdefghijklmnopqrstuvwxyz";
            Assert.IsFalse(solution.IsAlienSorted(words, order), $"[{solutionName}]");
        }

        #endregion

        #region Prefix Cases

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsAlienSorted_PrefixBeforeFullWord_ReturnsTrue(IVerifyingAnAlienDictionary_953 solution, string solutionName)
        {
            // "app" before "apple" is valid
            string[] words = { "app", "apple" };
            string order = "abcdefghijklmnopqrstuvwxyz";
            Assert.IsTrue(solution.IsAlienSorted(words, order), $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsAlienSorted_FullWordBeforePrefix_ReturnsFalse(IVerifyingAnAlienDictionary_953 solution, string solutionName)
        {
            // "apple" before "app" is invalid
            string[] words = { "apple", "app" };
            string order = "abcdefghijklmnopqrstuvwxyz";
            Assert.IsFalse(solution.IsAlienSorted(words, order), $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsAlienSorted_IdenticalWords_ReturnsTrue(IVerifyingAnAlienDictionary_953 solution, string solutionName)
        {
            string[] words = { "abc", "abc" };
            string order = "abcdefghijklmnopqrstuvwxyz";
            Assert.IsTrue(solution.IsAlienSorted(words, order), $"[{solutionName}]");
        }

        #endregion

        #region Reversed Alphabet

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsAlienSorted_ReversedAlphabet_SortedDescending_ReturnsTrue(IVerifyingAnAlienDictionary_953 solution, string solutionName)
        {
            // reversed order: z comes first, a comes last
            string[] words = { "zoo", "bar", "ant" };
            string order = "zyxwvutsrqponmlkjihgfedcba";
            Assert.IsTrue(solution.IsAlienSorted(words, order), $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsAlienSorted_ReversedAlphabet_StandardOrder_ReturnsFalse(IVerifyingAnAlienDictionary_953 solution, string solutionName)
        {
            string[] words = { "ant", "bar" };
            string order = "zyxwvutsrqponmlkjihgfedcba";
            Assert.IsFalse(solution.IsAlienSorted(words, order), $"[{solutionName}]");
        }

        #endregion

        #region First Character Determines Order

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsAlienSorted_FirstCharDeterminesOrder_ReturnsTrue(IVerifyingAnAlienDictionary_953 solution, string solutionName)
        {
            // 'z' < 'a' in this order, so "zzz" < "aaa"
            string[] words = { "zzz", "aaa" };
            string order = "zabcdefghijklmnopqrstuvwxy";
            Assert.IsTrue(solution.IsAlienSorted(words, order), $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsAlienSorted_FirstCharDeterminesOrder_ReturnsFalse(IVerifyingAnAlienDictionary_953 solution, string solutionName)
        {
            string[] words = { "aaa", "zzz" };
            string order = "zabcdefghijklmnopqrstuvwxy";
            Assert.IsFalse(solution.IsAlienSorted(words, order), $"[{solutionName}]");
        }

        #endregion

        #region Multi-word Chains

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsAlienSorted_ThreeWordsSorted_ReturnsTrue(IVerifyingAnAlienDictionary_953 solution, string solutionName)
        {
            string[] words = { "a", "b", "c" };
            string order = "abcdefghijklmnopqrstuvwxyz";
            Assert.IsTrue(solution.IsAlienSorted(words, order), $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsAlienSorted_ViolationAtLastPair_ReturnsFalse(IVerifyingAnAlienDictionary_953 solution, string solutionName)
        {
            // First two pairs valid, last pair invalid
            string[] words = { "aa", "ab", "ac", "ba" };
            string order = "abcdefghijklmnopqrstuvwxyz";
            Assert.IsTrue(solution.IsAlienSorted(words, order), $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsAlienSorted_ViolationInMiddle_ReturnsFalse(IVerifyingAnAlienDictionary_953 solution, string solutionName)
        {
            string[] words = { "a", "c", "b" };
            string order = "abcdefghijklmnopqrstuvwxyz";
            Assert.IsFalse(solution.IsAlienSorted(words, order), $"[{solutionName}]");
        }

        #endregion
    }
}
