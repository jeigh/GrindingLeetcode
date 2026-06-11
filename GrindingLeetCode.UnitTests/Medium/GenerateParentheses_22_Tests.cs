using LeetCodeProblems.CSharp.Backtracking;
using LeetCodeProblems.Interfaces.Medium;
using LeetCodeProblems.VisualBasic.Backtracking;

namespace GrindingLeetCode.UnitTests.Medium
{
    /// <summary>
    /// Unit tests for LeetCode Problem 22: Generate Parentheses
    ///
    /// Problem Description:
    /// Given n pairs of parentheses, write a function to generate all combinations
    /// of well-formed parentheses.
    /// </summary>
    [TestClass]
    public class GenerateParentheses_22_Tests
    {
        public static IEnumerable<object[]> GetImplementations()
        {
            yield return new object[] { new GenerateParentheses_Backtracking_CSharp_22(), "C# Backtracking" };
            yield return new object[] { new GenerateParentheses_Backtracking_VB_22(), "VB Backtracking" };
            yield break;
        }

        #region Helper Methods

        private static List<string> Normalize(IList<string> result)
            => result.OrderBy(s => s).ToList();

        private static bool IsValid(string s)
        {
            int balance = 0;
            foreach (char c in s)
            {
                if (c == '(') balance++;
                else balance--;
                if (balance < 0) return false;
            }
            return balance == 0;
        }

        #endregion

        #region LeetCode Examples

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void GenerateParenthesis_N1_ReturnsOnePair(IGenerateParentheses_22 solution, string solutionName)
        {
            // Input: n = 1
            // Output: ["()"]

            var result = solution.GenerateParenthesis(1);

            CollectionAssert.AreEqual(new List<string> { "()" }, Normalize(result),
                $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void GenerateParenthesis_N2_ReturnsTwoCombinations(IGenerateParentheses_22 solution, string solutionName)
        {
            // Input: n = 2
            // Output: ["(())", "()()"]

            var result = solution.GenerateParenthesis(2);

            CollectionAssert.AreEqual(Normalize(new List<string> { "(())", "()()" }), Normalize(result),
                $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void GenerateParenthesis_N3_ReturnsFiveCombinations(IGenerateParentheses_22 solution, string solutionName)
        {
            // Input: n = 3
            // Output: ["((()))", "(()())", "(())()", "()(())", "()()()"]

            var result = solution.GenerateParenthesis(3);

            var expected = new List<string> { "((()))", "(()())", "(())()", "()(())", "()()()" };
            CollectionAssert.AreEqual(Normalize(expected), Normalize(result),
                $"[{solutionName}]");
        }

        #endregion

        #region Count Tests (Catalan Numbers)

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void GenerateParenthesis_N1_ReturnsCount1(IGenerateParentheses_22 solution, string solutionName)
        {
            Assert.AreEqual(1, solution.GenerateParenthesis(1).Count, $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void GenerateParenthesis_N2_ReturnsCount2(IGenerateParentheses_22 solution, string solutionName)
        {
            Assert.AreEqual(2, solution.GenerateParenthesis(2).Count, $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void GenerateParenthesis_N3_ReturnsCount5(IGenerateParentheses_22 solution, string solutionName)
        {
            Assert.AreEqual(5, solution.GenerateParenthesis(3).Count, $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void GenerateParenthesis_N4_ReturnsCount14(IGenerateParentheses_22 solution, string solutionName)
        {
            Assert.AreEqual(14, solution.GenerateParenthesis(4).Count, $"[{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void GenerateParenthesis_N5_ReturnsCount42(IGenerateParentheses_22 solution, string solutionName)
        {
            Assert.AreEqual(42, solution.GenerateParenthesis(5).Count, $"[{solutionName}]");
        }

        #endregion

        #region Property Tests

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void GenerateParenthesis_AllStringsHaveCorrectLength(IGenerateParentheses_22 solution, string solutionName)
        {
            // Every result string must have exactly 2*n characters.
            int n = 4;
            var result = solution.GenerateParenthesis(n);

            foreach (var s in result)
                Assert.AreEqual(n * 2, s.Length,
                    $"String \"{s}\" has wrong length [{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void GenerateParenthesis_AllStringsAreValid(IGenerateParentheses_22 solution, string solutionName)
        {
            // Every result string must be a valid balanced parentheses sequence.
            var result = solution.GenerateParenthesis(4);

            foreach (var s in result)
                Assert.IsTrue(IsValid(s),
                    $"String \"{s}\" is not valid [{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void GenerateParenthesis_NoDuplicates(IGenerateParentheses_22 solution, string solutionName)
        {
            var result = solution.GenerateParenthesis(4);
            var distinct = result.Distinct().ToList();

            Assert.AreEqual(result.Count, distinct.Count,
                $"Result contains duplicate strings [{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void GenerateParenthesis_AllStringsContainOnlyParentheses(IGenerateParentheses_22 solution, string solutionName)
        {
            var result = solution.GenerateParenthesis(3);

            foreach (var s in result)
                Assert.IsTrue(s.All(c => c == '(' || c == ')'),
                    $"String \"{s}\" contains invalid characters [{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void GenerateParenthesis_AllStringsHaveEqualOpenAndClose(IGenerateParentheses_22 solution, string solutionName)
        {
            int n = 3;
            var result = solution.GenerateParenthesis(n);

            foreach (var s in result)
            {
                int open = s.Count(c => c == '(');
                int close = s.Count(c => c == ')');
                Assert.AreEqual(n, open, $"String \"{s}\" has wrong open count [{solutionName}]");
                Assert.AreEqual(n, close, $"String \"{s}\" has wrong close count [{solutionName}]");
            }
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void GenerateParenthesis_AllStringsValid_LargerInput(IGenerateParentheses_22 solution, string solutionName)
        {
            var result = solution.GenerateParenthesis(5);

            foreach (var s in result)
                Assert.IsTrue(IsValid(s),
                    $"String \"{s}\" is not valid [{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void GenerateParenthesis_NoDuplicates_LargerInput(IGenerateParentheses_22 solution, string solutionName)
        {
            var result = solution.GenerateParenthesis(5);
            var distinct = result.Distinct().ToList();

            Assert.AreEqual(result.Count, distinct.Count,
                $"Result contains duplicate strings [{solutionName}]");
        }

        #endregion
    }
}
