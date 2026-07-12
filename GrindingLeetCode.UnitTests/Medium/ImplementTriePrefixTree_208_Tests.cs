using LeetCodeProblems.CSharp.Trie;
using LeetCodeProblems.Interfaces.Medium;
using LeetCodeProblems.VisualBasic.Trie;

namespace GrindingLeetCode.UnitTests.Medium
{
    [TestClass]
    public class ImplementTriePrefixTree_208_Tests
    {
        public static IEnumerable<object[]> GetImplementations()
        {
            //yield return new object[] { new ImplementTriePrefixTree_CSharp_208(), "C# Trie" };
            yield return new object[] { new ImplementTriePrefixTree_VB_208(), "VB Trie" };
        }

        #region LeetCode Example

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Trie_LeetCodeExample_AllOperationsCorrect(IImplementTriePrefixTree_208 trie, string solutionName)
        {
            // Insert "apple"
            trie.Insert("apple");
            Assert.IsTrue(trie.Search("apple"), $"[{solutionName}] search apple after insert");
            Assert.IsFalse(trie.Search("app"), $"[{solutionName}] search app before insert");
            Assert.IsTrue(trie.StartsWith("app"), $"[{solutionName}] startsWith app");
            trie.Insert("app");
            Assert.IsTrue(trie.Search("app"), $"[{solutionName}] search app after insert");
        }

        #endregion

        #region Search — Word Not Present

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Search_EmptyTrie_ReturnsFalse(IImplementTriePrefixTree_208 trie, string solutionName)
        {
            Assert.IsFalse(trie.Search("anything"), $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Search_WordNotInserted_ReturnsFalse(IImplementTriePrefixTree_208 trie, string solutionName)
        {
            trie.Insert("hello");
            Assert.IsFalse(trie.Search("world"), $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Search_PrefixOfInsertedWord_ReturnsFalse(IImplementTriePrefixTree_208 trie, string solutionName)
        {
            trie.Insert("hello");
            Assert.IsFalse(trie.Search("hell"), $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Search_ExtensionOfInsertedWord_ReturnsFalse(IImplementTriePrefixTree_208 trie, string solutionName)
        {
            trie.Insert("he");
            Assert.IsFalse(trie.Search("hello"), $"[{solutionName}]");
        }

        #endregion

        #region Search — Word Present

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Search_InsertedWord_ReturnsTrue(IImplementTriePrefixTree_208 trie, string solutionName)
        {
            trie.Insert("hello");
            Assert.IsTrue(trie.Search("hello"), $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Search_SingleChar_ReturnsTrue(IImplementTriePrefixTree_208 trie, string solutionName)
        {
            trie.Insert("a");
            Assert.IsTrue(trie.Search("a"), $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Search_MultipleWordsInserted_EachFound(IImplementTriePrefixTree_208 trie, string solutionName)
        {
            trie.Insert("cat");
            trie.Insert("car");
            trie.Insert("card");
            Assert.IsTrue(trie.Search("cat"), $"[{solutionName}]");
            Assert.IsTrue(trie.Search("car"), $"[{solutionName}]");
            Assert.IsTrue(trie.Search("card"), $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Search_DuplicateInsert_ReturnsTrue(IImplementTriePrefixTree_208 trie, string solutionName)
        {
            trie.Insert("abc");
            trie.Insert("abc");
            Assert.IsTrue(trie.Search("abc"), $"[{solutionName}]");
        }

        #endregion

        #region StartsWith — Prefix Not Present

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void StartsWith_EmptyTrie_ReturnsFalse(IImplementTriePrefixTree_208 trie, string solutionName)
        {
            Assert.IsFalse(trie.StartsWith("a"), $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void StartsWith_UnrelatedWord_ReturnsFalse(IImplementTriePrefixTree_208 trie, string solutionName)
        {
            trie.Insert("hello");
            Assert.IsFalse(trie.StartsWith("world"), $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void StartsWith_LongerThanInsertedWord_ReturnsFalse(IImplementTriePrefixTree_208 trie, string solutionName)
        {
            trie.Insert("he");
            Assert.IsFalse(trie.StartsWith("hello"), $"[{solutionName}]");
        }

        #endregion

        #region StartsWith — Prefix Present

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void StartsWith_ExactWord_ReturnsTrue(IImplementTriePrefixTree_208 trie, string solutionName)
        {
            trie.Insert("hello");
            Assert.IsTrue(trie.StartsWith("hello"), $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void StartsWith_SingleChar_ReturnsTrue(IImplementTriePrefixTree_208 trie, string solutionName)
        {
            trie.Insert("hello");
            Assert.IsTrue(trie.StartsWith("h"), $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void StartsWith_SharedPrefix_ReturnsTrue(IImplementTriePrefixTree_208 trie, string solutionName)
        {
            trie.Insert("car");
            trie.Insert("card");
            trie.Insert("care");
            Assert.IsTrue(trie.StartsWith("car"), $"[{solutionName}]");
            Assert.IsTrue(trie.StartsWith("ca"), $"[{solutionName}]");
            Assert.IsTrue(trie.StartsWith("c"), $"[{solutionName}]");
        }

        #endregion

        #region Search vs StartsWith Distinction

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void SearchVsStartsWith_PrefixOnly_StartsWithTrueSearchFalse(IImplementTriePrefixTree_208 trie, string solutionName)
        {
            trie.Insert("apple");
            Assert.IsTrue(trie.StartsWith("app"), $"[{solutionName}] startsWith");
            Assert.IsFalse(trie.Search("app"), $"[{solutionName}] search");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void SearchVsStartsWith_BothInserted_BothTrue(IImplementTriePrefixTree_208 trie, string solutionName)
        {
            trie.Insert("app");
            trie.Insert("apple");
            Assert.IsTrue(trie.Search("app"), $"[{solutionName}] search app");
            Assert.IsTrue(trie.Search("apple"), $"[{solutionName}] search apple");
            Assert.IsTrue(trie.StartsWith("app"), $"[{solutionName}] startsWith app");
            Assert.IsTrue(trie.StartsWith("appl"), $"[{solutionName}] startsWith appl");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void SearchVsStartsWith_WordIsPrefix_OfAnother(IImplementTriePrefixTree_208 trie, string solutionName)
        {
            trie.Insert("do");
            trie.Insert("dog");
            trie.Insert("dodge");
            Assert.IsTrue(trie.Search("do"), $"[{solutionName}]");
            Assert.IsTrue(trie.Search("dog"), $"[{solutionName}]");
            Assert.IsFalse(trie.Search("d"), $"[{solutionName}]");
            Assert.IsTrue(trie.StartsWith("d"), $"[{solutionName}]");
            Assert.IsTrue(trie.StartsWith("do"), $"[{solutionName}]");
            Assert.IsTrue(trie.StartsWith("dog"), $"[{solutionName}]");
        }

        #endregion
    }
}
