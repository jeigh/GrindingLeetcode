using LeetCodeProblems;
using LeetCodeProblems.Interfaces.Easy;
using LeetCodeProblems.VisualBasic;

namespace GrindingLeetCode.UnitTests.Easy
{
    [TestClass]
    public class ValidParenthesesSolution_20_Tests
    {
        public static IEnumerable<object[]> GetImplementations()
        {
            yield return new object[] { new ValidParenthesesCSharpSolution_20() };
            yield return new object[] { new ValidParenthesesVBStackSolution_20() };
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsValid_Example1_ReturnsTrue(IValidParentheses_20 solution)
        {
            // Arrange
            string s = "()";

            // Act
            bool result = solution.IsValid(s);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsValid_Example2_ReturnsTrue(IValidParentheses_20 solution)
        {
            // Arrange
            string s = "()[]{}";

            // Act
            bool result = solution.IsValid(s);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsValid_Example3_ReturnsFalse(IValidParentheses_20 solution)
        {
            // Arrange
            string s = "(]";

            // Act
            bool result = solution.IsValid(s);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsValid_NestedParentheses_ReturnsTrue(IValidParentheses_20 solution)
        {
            // Arrange
            string s = "{[()]}";

            // Act
            bool result = solution.IsValid(s);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsValid_MismatchedBrackets_ReturnsFalse(IValidParentheses_20 solution)
        {
            // Arrange
            string s = "([)]";

            // Act
            bool result = solution.IsValid(s);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsValid_OnlyOpeningBrackets_ReturnsFalse(IValidParentheses_20 solution)
        {
            // Arrange
            string s = "(((";

            // Act
            bool result = solution.IsValid(s);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsValid_OnlyClosingBrackets_ReturnsFalse(IValidParentheses_20 solution)
        {
            // Arrange
            string s = ")))";

            // Act
            bool result = solution.IsValid(s);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsValid_EmptyString_ReturnsTrue(IValidParentheses_20 solution)
        {
            // Arrange
            string s = "";

            // Act
            bool result = solution.IsValid(s);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsValid_SingleOpenBracket_ReturnsFalse(IValidParentheses_20 solution)
        {
            // Arrange
            string s = "(";

            // Act
            bool result = solution.IsValid(s);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsValid_SingleCloseBracket_ReturnsFalse(IValidParentheses_20 solution)
        {
            // Arrange
            string s = ")";

            // Act
            bool result = solution.IsValid(s);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsValid_ComplexNested_ReturnsTrue(IValidParentheses_20 solution)
        {
            // Arrange
            string s = "{[({[]})]}";

            // Act
            bool result = solution.IsValid(s);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsValid_WrongOrder_ReturnsFalse(IValidParentheses_20 solution)
        {
            // Arrange
            string s = "}{";

            // Act
            bool result = solution.IsValid(s);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsValid_MultipleValidPairs_ReturnsTrue(IValidParentheses_20 solution)
        {
            // Arrange
            string s = "()()()";

            // Act
            bool result = solution.IsValid(s);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsValid_DifferentBracketTypes_ReturnsTrue(IValidParentheses_20 solution)
        {
            // Arrange
            string s = "(){}[]";

            // Act
            bool result = solution.IsValid(s);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsValid_DeeplyNested_ReturnsTrue(IValidParentheses_20 solution)
        {
            // Arrange
            string s = "(((())))";

            // Act
            bool result = solution.IsValid(s);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsValid_MismatchedTypes_ReturnsFalse(IValidParentheses_20 solution)
        {
            // Arrange
            string s = "(]";

            // Act
            bool result = solution.IsValid(s);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsValid_ExtraClosing_ReturnsFalse(IValidParentheses_20 solution)
        {
            // Arrange
            string s = "())";

            // Act
            bool result = solution.IsValid(s);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsValid_ExtraOpening_ReturnsFalse(IValidParentheses_20 solution)
        {
            // Arrange
            string s = "(()";

            // Act
            bool result = solution.IsValid(s);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsValid_AllBracketTypes_ReturnsTrue(IValidParentheses_20 solution)
        {
            // Arrange
            string s = "{[()]}{}[]()";

            // Act
            bool result = solution.IsValid(s);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsValid_ReverseOrder_ReturnsFalse(IValidParentheses_20 solution)
        {
            // Arrange
            string s = "][}{)(";

            // Act
            bool result = solution.IsValid(s);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsValid_ComplexInvalid_ReturnsFalse(IValidParentheses_20 solution)
        {
            // Arrange
            string s = "([)]{}";

            // Act
            bool result = solution.IsValid(s);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsValid_LongValidString_ReturnsTrue(IValidParentheses_20 solution)
        {
            // Arrange
            string s = "()[]{}()[]{}()[]{}";

            // Act
            bool result = solution.IsValid(s);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsValid_AlternatingTypes_ReturnsTrue(IValidParentheses_20 solution)
        {
            // Arrange
            string s = "({[({[({[]})]})]})";

            // Act
            bool result = solution.IsValid(s);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void IsValid_UnevenPairs_ReturnsFalse(IValidParentheses_20 solution)
        {
            // Arrange
            string s = "((()";

            // Act
            bool result = solution.IsValid(s);

            // Assert
            Assert.IsFalse(result);
        }
    }
}