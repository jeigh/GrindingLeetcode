using LeetCodeProblems.CSharp.Trie;
using LeetCodeProblems.Interfaces.Medium;
using LeetCodeProblems.VisualBasic.Trie;

namespace GrindingLeetCode.UnitTests.Medium
{
    [TestClass]
    public class DesignAddAndSearchWordDataStructure_211_Tests
    {
        public static IEnumerable<object[]> GetImplementations()
        {
            yield return new object[] { new DesignAddAndSearchWordDataStructure_CSharp_211(), "C# Trie" };
        }

        #region LeetCode Example

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void WordDictionary_LeetCodeExample_AllOperationsCorrect(IDesignAddAndSearchWordDataStructure_211 dict, string solutionName)
        {
            dict.AddWord("bad");
            dict.AddWord("dad");
            dict.AddWord("mad");
            Assert.IsFalse(dict.Search("pad"), $"[{solutionName}]");
            Assert.IsTrue(dict.Search("bad"), $"[{solutionName}]");
            Assert.IsTrue(dict.Search(".ad"), $"[{solutionName}]");
            Assert.IsTrue(dict.Search("b.."), $"[{solutionName}]");
        }

        #endregion

        #region Exact Search — No Wildcards

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Search_EmptyDictionary_ReturnsFalse(IDesignAddAndSearchWordDataStructure_211 dict, string solutionName)
        {
            Assert.IsFalse(dict.Search("anything"), $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Search_ExactMatch_ReturnsTrue(IDesignAddAndSearchWordDataStructure_211 dict, string solutionName)
        {
            dict.AddWord("hello");
            Assert.IsTrue(dict.Search("hello"), $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Search_WordNotAdded_ReturnsFalse(IDesignAddAndSearchWordDataStructure_211 dict, string solutionName)
        {
            dict.AddWord("hello");
            Assert.IsFalse(dict.Search("world"), $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Search_PrefixOnly_ReturnsFalse(IDesignAddAndSearchWordDataStructure_211 dict, string solutionName)
        {
            dict.AddWord("hello");
            Assert.IsFalse(dict.Search("hell"), $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Search_ExtensionOfWord_ReturnsFalse(IDesignAddAndSearchWordDataStructure_211 dict, string solutionName)
        {
            dict.AddWord("he");
            Assert.IsFalse(dict.Search("hello"), $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Search_SingleChar_ReturnsTrue(IDesignAddAndSearchWordDataStructure_211 dict, string solutionName)
        {
            dict.AddWord("a");
            Assert.IsTrue(dict.Search("a"), $"[{solutionName}]");
        }

        #endregion

        #region Wildcard — Single Dot

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Search_SingleDot_MatchesAnyChar(IDesignAddAndSearchWordDataStructure_211 dict, string solutionName)
        {
            dict.AddWord("a");
            Assert.IsTrue(dict.Search("."), $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Search_SingleDot_NoMatchIfEmpty(IDesignAddAndSearchWordDataStructure_211 dict, string solutionName)
        {
            Assert.IsFalse(dict.Search("."), $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Search_DotAtStart_MatchesFirstChar(IDesignAddAndSearchWordDataStructure_211 dict, string solutionName)
        {
            dict.AddWord("cat");
            Assert.IsTrue(dict.Search(".at"), $"[{solutionName}]");
            Assert.IsFalse(dict.Search(".og"), $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Search_DotAtEnd_MatchesLastChar(IDesignAddAndSearchWordDataStructure_211 dict, string solutionName)
        {
            dict.AddWord("cat");
            Assert.IsTrue(dict.Search("ca."), $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Search_DotInMiddle_MatchesMiddleChar(IDesignAddAndSearchWordDataStructure_211 dict, string solutionName)
        {
            dict.AddWord("cat");
            Assert.IsTrue(dict.Search("c.t"), $"[{solutionName}]");
        }

        #endregion

        #region Wildcard — All Dots

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Search_AllDots_MatchesWordOfSameLength(IDesignAddAndSearchWordDataStructure_211 dict, string solutionName)
        {
            dict.AddWord("abc");
            Assert.IsTrue(dict.Search("..."), $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Search_AllDots_WrongLength_ReturnsFalse(IDesignAddAndSearchWordDataStructure_211 dict, string solutionName)
        {
            dict.AddWord("abc");
            Assert.IsFalse(dict.Search("...."), $"[{solutionName}]");
            Assert.IsFalse(dict.Search(".."), $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Search_AllDots_MatchesAnyWordOfSameLength(IDesignAddAndSearchWordDataStructure_211 dict, string solutionName)
        {
            dict.AddWord("bad");
            dict.AddWord("dad");
            dict.AddWord("mad");
            Assert.IsTrue(dict.Search("..."), $"[{solutionName}]");
        }

        #endregion

        #region Wildcard — Multiple Words

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Search_DotMatchesOneOfMultipleWords(IDesignAddAndSearchWordDataStructure_211 dict, string solutionName)
        {
            dict.AddWord("cat");
            dict.AddWord("bat");
            dict.AddWord("rat");
            Assert.IsTrue(dict.Search(".at"), $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Search_DotNoMatchAmongMultipleWords(IDesignAddAndSearchWordDataStructure_211 dict, string solutionName)
        {
            dict.AddWord("cat");
            dict.AddWord("bat");
            Assert.IsFalse(dict.Search(".og"), $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Search_WordsOfDifferentLengths_DotOnlyMatchesSameLength(IDesignAddAndSearchWordDataStructure_211 dict, string solutionName)
        {
            dict.AddWord("a");
            dict.AddWord("ab");
            dict.AddWord("abc");
            Assert.IsTrue(dict.Search(".."), $"[{solutionName}]");
            Assert.IsFalse(dict.Search("...."), $"[{solutionName}]");
        }

        #endregion

        #region Shared Prefixes

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Search_SharedPrefix_ExactAndWildcard(IDesignAddAndSearchWordDataStructure_211 dict, string solutionName)
        {
            dict.AddWord("car");
            dict.AddWord("card");
            Assert.IsTrue(dict.Search("car"), $"[{solutionName}] exact");
            Assert.IsTrue(dict.Search("car."), $"[{solutionName}] wildcard");
            Assert.IsFalse(dict.Search("car.."), $"[{solutionName}] too long");
        }

        #endregion
    }
}
