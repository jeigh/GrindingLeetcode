using LeetCodeProblems.CSharp.Backtracking;
using LeetCodeProblems.Interfaces.Medium;
using LeetCodeProblems.VisualBasic.Backtracking;

namespace GrindingLeetCode.UnitTests.Medium
{
    [TestClass]
    public class LetterCombinations_17_Tests
    {
        public static IEnumerable<object[]> GetImplementations()
        {
            yield return new object[] { new LetterCombinations_Backtracking_CSharp_17(), "C# Backtracking" };
            yield return new object[] { new LetterCombinations_Backtracking_VB_17(), "VB Backtracking" };
        }

        #region Helper Methods

        private static readonly Dictionary<char, string> PhoneMap = new()
        {
            ['2'] = "abc", ['3'] = "def", ['4'] = "ghi", ['5'] = "jkl",
            ['6'] = "mno", ['7'] = "pqrs", ['8'] = "tuv", ['9'] = "wxyz"
        };

        private static void AssertCombinations(IList<string> expected, IList<string> actual, string solutionName) =>
            CollectionAssert.AreEquivalent(expected.ToList(), actual.ToList(), $"[{solutionName}]");

        private static bool IsValidCombination(string digits, string combo)
        {
            if (combo.Length != digits.Length) return false;
            for (int i = 0; i < digits.Length; i++)
                if (!PhoneMap[digits[i]].Contains(combo[i])) return false;
            return true;
        }

        #endregion

        #region LeetCode Examples

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void LetterCombinations_Example1_23_ReturnsAllCombinations(ILetterCombinations_17 solution, string solutionName)
        {
            // Input: digits = "23"
            // Output: ["ad","ae","af","bd","be","bf","cd","ce","cf"]
            var expected = new List<string> { "ad", "ae", "af", "bd", "be", "bf", "cd", "ce", "cf" };
            AssertCombinations(expected, solution.LetterCombinations("23"), solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void LetterCombinations_Example2_EmptyString_ReturnsEmpty(ILetterCombinations_17 solution, string solutionName)
        {
            // Input: digits = ""
            // Output: []
            Assert.AreEqual(0, solution.LetterCombinations("").Count, $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void LetterCombinations_Example3_SingleDigit2_ReturnsABC(ILetterCombinations_17 solution, string solutionName)
        {
            // Input: digits = "2"
            // Output: ["a","b","c"]
            var expected = new List<string> { "a", "b", "c" };
            AssertCombinations(expected, solution.LetterCombinations("2"), solutionName);
        }

        #endregion

        #region Single Digit

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void LetterCombinations_SingleDigit3_ReturnsDEF(ILetterCombinations_17 solution, string solutionName)
        {
            AssertCombinations(new List<string> { "d", "e", "f" }, solution.LetterCombinations("3"), solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void LetterCombinations_SingleDigit7_ReturnsFourLetters(ILetterCombinations_17 solution, string solutionName)
        {
            // 7 maps to "pqrs" — four letters
            AssertCombinations(new List<string> { "p", "q", "r", "s" }, solution.LetterCombinations("7"), solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void LetterCombinations_SingleDigit8_ReturnsTUV(ILetterCombinations_17 solution, string solutionName)
        {
            AssertCombinations(new List<string> { "t", "u", "v" }, solution.LetterCombinations("8"), solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void LetterCombinations_SingleDigit9_ReturnsFourLetters(ILetterCombinations_17 solution, string solutionName)
        {
            // 9 maps to "wxyz" — four letters
            AssertCombinations(new List<string> { "w", "x", "y", "z" }, solution.LetterCombinations("9"), solutionName);
        }

        #endregion

        #region Count Checks

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void LetterCombinations_TwoDigits_CountIs9(ILetterCombinations_17 solution, string solutionName)
        {
            // 3 letters × 3 letters = 9
            Assert.AreEqual(9, solution.LetterCombinations("23").Count, $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void LetterCombinations_TwoDigitsWithFourLetterKey_CountIs12(ILetterCombinations_17 solution, string solutionName)
        {
            // 7 (pqrs=4) × 3 (abc=3) = 12
            Assert.AreEqual(12, solution.LetterCombinations("72").Count, $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void LetterCombinations_TwoFourLetterDigits_CountIs16(ILetterCombinations_17 solution, string solutionName)
        {
            // 7 (pqrs=4) × 9 (wxyz=4) = 16
            Assert.AreEqual(16, solution.LetterCombinations("79").Count, $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void LetterCombinations_ThreeDigits_CountIs27(ILetterCombinations_17 solution, string solutionName)
        {
            // 3 × 3 × 3 = 27
            Assert.AreEqual(27, solution.LetterCombinations("234").Count, $"[{solutionName}]");
        }

        #endregion

        #region Combination Length

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void LetterCombinations_AllCombinationsHaveSameLengthAsInput(ILetterCombinations_17 solution, string solutionName)
        {
            var result = solution.LetterCombinations("234");
            foreach (var combo in result)
                Assert.AreEqual(3, combo.Length, $"[{solutionName}] combination '{combo}' has wrong length");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void LetterCombinations_SingleDigitCombinationsHaveLength1(ILetterCombinations_17 solution, string solutionName)
        {
            var result = solution.LetterCombinations("5");
            foreach (var combo in result)
                Assert.AreEqual(1, combo.Length, $"[{solutionName}]");
        }

        #endregion

        #region Validity

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void LetterCombinations_AllCombinationsUseCorrectLetters(ILetterCombinations_17 solution, string solutionName)
        {
            const string digits = "23";
            var result = solution.LetterCombinations(digits);
            foreach (var combo in result)
                Assert.IsTrue(IsValidCombination(digits, combo), $"[{solutionName}] '{combo}' uses letters not mapped from '{digits}'");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void LetterCombinations_NoDuplicates(ILetterCombinations_17 solution, string solutionName)
        {
            var result = solution.LetterCombinations("23");
            Assert.AreEqual(result.Count, result.Distinct().Count(), $"[{solutionName}] result contains duplicate combinations");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void LetterCombinations_ThreeDigits_AllCombinationsUseCorrectLetters(ILetterCombinations_17 solution, string solutionName)
        {
            const string digits = "789";
            var result = solution.LetterCombinations(digits);
            foreach (var combo in result)
                Assert.IsTrue(IsValidCombination(digits, combo), $"[{solutionName}] '{combo}' uses letters not mapped from '{digits}'");
        }

        #endregion

        #region Specific Combinations

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void LetterCombinations_79_ContainsWP(ILetterCombinations_17 solution, string solutionName)
        {
            var result = solution.LetterCombinations("79");
            CollectionAssert.Contains(result.ToList(), "pw", $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void LetterCombinations_22_ReturnsAllPairs(ILetterCombinations_17 solution, string solutionName)
        {
            // 2→abc, so "22" → all pairs of {a,b,c}
            var expected = new List<string> { "aa", "ab", "ac", "ba", "bb", "bc", "ca", "cb", "cc" };
            AssertCombinations(expected, solution.LetterCombinations("22"), solutionName);
        }

        #endregion
    }
}
