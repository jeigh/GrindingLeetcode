using LeetCodeProblems.CSharp.Queue;
using LeetCodeProblems.Interfaces.Medium;
using LeetCodeProblems.VisualBasic;

namespace GrindingLeetCode.UnitTests.Medium
{
    /// <summary>
    /// Unit tests for LeetCode Problem 1405: Longest Happy String
    ///
    /// Problem Description:
    /// A string is "happy" if it only contains 'a', 'b', 'c' and does not contain
    /// "aaa", "bbb", or "ccc" as a substring. Given counts a, b, c, return the
    /// longest possible happy string. Return "" if none is possible.
    /// </summary>
    [TestClass]
    public class LongestHappyString_1405_Tests
    {
        public static IEnumerable<object[]> GetImplementations()
        {
            yield return new object[] { new LongestHappyString_CSharp_1405(), "C# Implementation" };
            yield return new object[] { new LongestHappyString_VB_1405(), "VB Implementation" };
        }

        // Helper: returns true when result is a valid happy string using at most
        // the given counts of 'a', 'b', 'c' with no run of 3 identical characters.
        private static bool IsValidHappyString(string result, int a, int b, int c)
        {
            int[] limits = { a, b, c };
            int[] used = new int[3];

            foreach (char ch in result)
            {
                if (ch < 'a' || ch > 'c') return false;
                used[ch - 'a']++;
            }

            for (int i = 0; i < 3; i++)
            {
                if (used[i] > limits[i]) return false;
            }

            for (int i = 2; i < result.Length; i++)
            {
                if (result[i] == result[i - 1] && result[i] == result[i - 2])
                    return false;
            }

            return true;
        }

        // Helper: returns the maximum possible length of a valid happy string.
        // Each character can appear at most twice in a row; the total is bounded
        // by min(a, ceil(total/2)) style reasoning, but the simplest correct upper
        // bound used here is: we can never use more than 2*(sum of smaller two) + 2
        // of the dominant character. The result length should equal the expected value.
        private static int ExpectedMaxLength(int a, int b, int c)
        {
            int[] counts = { a, b, c };
            Array.Sort(counts);
            // dominant = counts[2], others sum = counts[0] + counts[1]
            int othersSum = counts[0] + counts[1];
            int dominant = counts[2];
            int dominantUsable = Math.Min(dominant, othersSum + 1) * 2 - (dominant > othersSum + 1 ? 0 : 0);
            // Simpler: each "slot" between two other chars fits at most 2 dominant
            // Max dominant usable = min(dominant, othersSum + 1) if we interleave with 1 each,
            // but pairs are allowed. Accurate formula:
            // slots = othersSum + 1, each slot fits at most 2 => max dominant = min(dominant, 2*(othersSum+1))
            // but we also can't exceed dominant itself.
            // Total = min(dominant, 2*(othersSum+1)) + othersSum -- but this is still an approximation.
            // For test purposes we only check length when the answer is deterministic (single char, zeros, etc.).
            return -1; // not used for length checks in general; helper kept for documentation
        }

        #region LeetCode Examples

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void LongestDiverseString_Example1_ReturnsValidHappyString(ILongestHappyString_1405 solution, string solutionName)
        {
            // Input: a = 1, b = 1, c = 7
            // One valid output: "ccaccbcc" (length 8) or similar

            // Arrange
            int a = 1, b = 1, c = 7;

            // Act
            string result = solution.LongestDiverseString(a, b, c);

            // Assert
            Assert.IsTrue(IsValidHappyString(result, a, b, c),
                $"Result '{result}' is not a valid happy string [{solutionName}]");
            Assert.AreEqual(8, result.Length,
                $"Expected length 8 for a=1,b=1,c=7 [{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void LongestDiverseString_Example2_ReturnsValidHappyString(ILongestHappyString_1405 solution, string solutionName)
        {
            // Input: a = 7, b = 1, c = 0
            // Optimal: "aabaa" (length 5) -- two a's, then b, then two more a's.

            // Arrange
            int a = 7, b = 1, c = 0;

            // Act
            string result = solution.LongestDiverseString(a, b, c);

            // Assert
            Assert.IsTrue(IsValidHappyString(result, a, b, c),
                $"Result '{result}' is not a valid happy string [{solutionName}]");
            Assert.AreEqual(5, result.Length,
                $"Expected length 5 for a=7,b=1,c=0 [{solutionName}]");
        }

        #endregion

        #region Edge Cases

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void LongestDiverseString_AllZero_ReturnsEmpty(ILongestHappyString_1405 solution, string solutionName)
        {
            // No characters available -- result must be empty.

            // Arrange / Act
            string result = solution.LongestDiverseString(0, 0, 0);

            // Assert
            Assert.AreEqual("", result,
                $"Expected empty string when all counts are 0 [{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void LongestDiverseString_SingleCharacterAvailable_ReturnsSingleChar(ILongestHappyString_1405 solution, string solutionName)
        {
            // Only one 'b' available -- only valid result is "b".

            // Arrange / Act
            string result = solution.LongestDiverseString(0, 1, 0);

            // Assert
            Assert.AreEqual("b", result,
                $"Expected \"b\" when only b=1 is available [{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void LongestDiverseString_TwoOfSameChar_ReturnsTwoChars(ILongestHappyString_1405 solution, string solutionName)
        {
            // Only two 'a's, nothing else -- max happy run without "aaa" is "aa".

            // Arrange / Act
            string result = solution.LongestDiverseString(2, 0, 0);

            // Assert
            Assert.AreEqual("aa", result,
                $"Expected \"aa\" when only a=2 is available [{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void LongestDiverseString_ThreeOfSameChar_ReturnsTwoChars(ILongestHappyString_1405 solution, string solutionName)
        {
            // Three 'a's, nothing to interleave -- cannot use all three, max is "aa".

            // Arrange / Act
            string result = solution.LongestDiverseString(3, 0, 0);

            // Assert
            Assert.AreEqual("aa", result,
                $"Expected \"aa\" when only a=3 with nothing to interleave [{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void LongestDiverseString_EqualCounts_ReturnsValidHappyString(ILongestHappyString_1405 solution, string solutionName)
        {
            // a=2, b=2, c=2 -- all chars equal, all 6 can be used.

            // Arrange
            int a = 2, b = 2, c = 2;

            // Act
            string result = solution.LongestDiverseString(a, b, c);

            // Assert
            Assert.IsTrue(IsValidHappyString(result, a, b, c),
                $"Result '{result}' is not a valid happy string [{solutionName}]");
            Assert.AreEqual(6, result.Length,
                $"Expected length 6 for a=2,b=2,c=2 [{solutionName}]");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void LongestDiverseString_LargeDominantCount_ReturnsValidHappyString(ILongestHappyString_1405 solution, string solutionName)
        {
            // a=100, b=1, c=1 -- 'a' dominates heavily.
            // Optimal: "aabaa caa" style = aa+b+aa+c+aa = 8 characters.
            // 'b' and 'c' each act as a separator allowing 2 more 'a's on each side.

            // Arrange
            int a = 100, b = 1, c = 1;

            // Act
            string result = solution.LongestDiverseString(a, b, c);

            // Assert
            Assert.IsTrue(IsValidHappyString(result, a, b, c),
                $"Result '{result}' is not a valid happy string [{solutionName}]");
            Assert.AreEqual(8, result.Length,
                $"Expected length 8 for a=100,b=1,c=1 [{solutionName}]");
        }

        #endregion
    }
}
