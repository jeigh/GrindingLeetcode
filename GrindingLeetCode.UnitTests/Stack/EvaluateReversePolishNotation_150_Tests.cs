using LeetCodeProblems.CSharp.Stack;
using LeetCodeProblems.Interfaces.Medium;
using LeetCodeProblems.VisualBasic.Stack;

namespace GrindingLeetCode.UnitTests.Stack
{
    [TestClass]
    public class EvaluateReversePolishNotation_150_Tests
    {
        public static IEnumerable<object[]> GetImplementations()
        {
            //yield return new object[] { new EvaluateReversePolishNotationCSharp_150() };
            yield return new object[] { new EvaluateReversePolishNotationVB_150() };
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void EvalRPN_Example1_Returns9(IEvaluateReversePolishNotationCSharp_150 solution)
        {
            // Arrange
            string[] tokens = { "2", "1", "+", "3", "*" };

            // Act
            int result = solution.EvalRPN(tokens);

            // Assert - ((2 + 1) * 3) = 9
            Assert.AreEqual(9, result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void EvalRPN_Example2_Returns6(IEvaluateReversePolishNotationCSharp_150 solution)
        {
            // Arrange
            string[] tokens = { "4", "13", "5", "/", "+" };

            // Act
            int result = solution.EvalRPN(tokens);

            // Assert - (4 + (13 / 5)) = 4 + 2 = 6
            Assert.AreEqual(6, result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void EvalRPN_Example3_Returns22(IEvaluateReversePolishNotationCSharp_150 solution)
        {
            // Arrange
            string[] tokens = { "10", "6", "9", "3", "+", "-11", "*", "/", "*", "17", "+", "5", "+" };

            // Act
            int result = solution.EvalRPN(tokens);

            // Assert - Complex expression = 22
            Assert.AreEqual(22, result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void EvalRPN_SingleNumber_ReturnsNumber(IEvaluateReversePolishNotationCSharp_150 solution)
        {
            // Arrange
            string[] tokens = { "42" };

            // Act
            int result = solution.EvalRPN(tokens);

            // Assert
            Assert.AreEqual(42, result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void EvalRPN_SimpleAddition_ReturnsSum(IEvaluateReversePolishNotationCSharp_150 solution)
        {
            // Arrange
            string[] tokens = { "3", "4", "+" };

            // Act
            int result = solution.EvalRPN(tokens);

            // Assert - 3 + 4 = 7
            Assert.AreEqual(7, result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void EvalRPN_SimpleSubtraction_ReturnsDifference(IEvaluateReversePolishNotationCSharp_150 solution)
        {
            // Arrange
            string[] tokens = { "10", "3", "-" };

            // Act
            int result = solution.EvalRPN(tokens);

            // Assert - 10 - 3 = 7
            Assert.AreEqual(7, result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void EvalRPN_SimpleMultiplication_ReturnsProduct(IEvaluateReversePolishNotationCSharp_150 solution)
        {
            // Arrange
            string[] tokens = { "5", "6", "*" };

            // Act
            int result = solution.EvalRPN(tokens);

            // Assert - 5 * 6 = 30
            Assert.AreEqual(30, result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void EvalRPN_SimpleDivision_ReturnsQuotient(IEvaluateReversePolishNotationCSharp_150 solution)
        {
            // Arrange
            string[] tokens = { "15", "3", "/" };

            // Act
            int result = solution.EvalRPN(tokens);

            // Assert - 15 / 3 = 5
            Assert.AreEqual(5, result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void EvalRPN_DivisionTruncatesTowardZero_Positive(IEvaluateReversePolishNotationCSharp_150 solution)
        {
            // Arrange
            string[] tokens = { "7", "2", "/" };

            // Act
            int result = solution.EvalRPN(tokens);

            // Assert - 7 / 2 = 3 (truncates toward zero)
            Assert.AreEqual(3, result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void EvalRPN_NegativeNumbers_WorksCorrectly(IEvaluateReversePolishNotationCSharp_150 solution)
        {
            // Arrange
            string[] tokens = { "-5", "3", "+" };

            // Act
            int result = solution.EvalRPN(tokens);

            // Assert - -5 + 3 = -2
            Assert.AreEqual(-2, result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void EvalRPN_NegativeResult_ReturnsNegative(IEvaluateReversePolishNotationCSharp_150 solution)
        {
            // Arrange
            string[] tokens = { "3", "5", "-" };

            // Act
            int result = solution.EvalRPN(tokens);

            // Assert - 3 - 5 = -2
            Assert.AreEqual(-2, result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void EvalRPN_MultipleOperations_InSequence(IEvaluateReversePolishNotationCSharp_150 solution)
        {
            // Arrange
            string[] tokens = { "2", "3", "+", "4", "*" };

            // Act
            int result = solution.EvalRPN(tokens);

            // Assert - ((2 + 3) * 4) = 20
            Assert.AreEqual(20, result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void EvalRPN_NestedOperations_WorksCorrectly(IEvaluateReversePolishNotationCSharp_150 solution)
        {
            // Arrange
            string[] tokens = { "5", "1", "2", "+", "4", "*", "+", "3", "-" };

            // Act
            int result = solution.EvalRPN(tokens);

            // Assert - (5 + ((1 + 2) * 4)) - 3 = 5 + 12 - 3 = 14
            Assert.AreEqual(14, result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void EvalRPN_AllAdditions_ReturnsSum(IEvaluateReversePolishNotationCSharp_150 solution)
        {
            // Arrange
            string[] tokens = { "1", "2", "+", "3", "+", "4", "+" };

            // Act
            int result = solution.EvalRPN(tokens);

            // Assert - ((1 + 2) + 3) + 4 = 10
            Assert.AreEqual(10, result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void EvalRPN_AllSubtractions_ReturnsResult(IEvaluateReversePolishNotationCSharp_150 solution)
        {
            // Arrange
            string[] tokens = { "10", "5", "-", "2", "-" };

            // Act
            int result = solution.EvalRPN(tokens);

            // Assert - (10 - 5) - 2 = 3
            Assert.AreEqual(3, result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void EvalRPN_AllMultiplications_ReturnsProduct(IEvaluateReversePolishNotationCSharp_150 solution)
        {
            // Arrange
            string[] tokens = { "2", "3", "*", "4", "*" };

            // Act
            int result = solution.EvalRPN(tokens);

            // Assert - (2 * 3) * 4 = 24
            Assert.AreEqual(24, result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void EvalRPN_AllDivisions_ReturnsQuotient(IEvaluateReversePolishNotationCSharp_150 solution)
        {
            // Arrange
            string[] tokens = { "100", "5", "/", "2", "/" };

            // Act
            int result = solution.EvalRPN(tokens);

            // Assert - (100 / 5) / 2 = 10
            Assert.AreEqual(10, result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void EvalRPN_ZeroResult_ReturnsZero(IEvaluateReversePolishNotationCSharp_150 solution)
        {
            // Arrange
            string[] tokens = { "5", "5", "-" };

            // Act
            int result = solution.EvalRPN(tokens);

            // Assert - 5 - 5 = 0
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void EvalRPN_WithZero_OperationsWorkCorrectly(IEvaluateReversePolishNotationCSharp_150 solution)
        {
            // Arrange
            string[] tokens = { "0", "5", "+", "3", "*" };

            // Act
            int result = solution.EvalRPN(tokens);

            // Assert - (0 + 5) * 3 = 15
            Assert.AreEqual(15, result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void EvalRPN_MultiplyByZero_ReturnsZero(IEvaluateReversePolishNotationCSharp_150 solution)
        {
            // Arrange
            string[] tokens = { "5", "0", "*" };

            // Act
            int result = solution.EvalRPN(tokens);

            // Assert - 5 * 0 = 0
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void EvalRPN_LargeNumbers_WorksCorrectly(IEvaluateReversePolishNotationCSharp_150 solution)
        {
            // Arrange
            string[] tokens = { "1000", "500", "+" };

            // Act
            int result = solution.EvalRPN(tokens);

            // Assert - 1000 + 500 = 1500
            Assert.AreEqual(1500, result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void EvalRPN_MixedOperators_ComplexExpression(IEvaluateReversePolishNotationCSharp_150 solution)
        {
            // Arrange
            string[] tokens = { "3", "4", "+", "2", "*", "7", "/" };

            // Act
            int result = solution.EvalRPN(tokens);

            // Assert - ((3 + 4) * 2) / 7 = 14 / 7 = 2
            Assert.AreEqual(2, result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void EvalRPN_NegativeOperands_BothNegative(IEvaluateReversePolishNotationCSharp_150 solution)
        {
            // Arrange
            string[] tokens = { "-3", "-5", "+" };

            // Act
            int result = solution.EvalRPN(tokens);

            // Assert - -3 + -5 = -8
            Assert.AreEqual(-8, result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void EvalRPN_NegativeMultiplication_ReturnsPositive(IEvaluateReversePolishNotationCSharp_150 solution)
        {
            // Arrange
            string[] tokens = { "-3", "-4", "*" };

            // Act
            int result = solution.EvalRPN(tokens);

            // Assert - -3 * -4 = 12
            Assert.AreEqual(12, result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void EvalRPN_NegativeDivision_TruncatesTowardZero(IEvaluateReversePolishNotationCSharp_150 solution)
        {
            // Arrange
            string[] tokens = { "-7", "2", "/" };

            // Act
            int result = solution.EvalRPN(tokens);

            // Assert - -7 / 2 = -3 (truncates toward zero)
            Assert.AreEqual(-3, result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void EvalRPN_LongExpression_EvaluatesCorrectly(IEvaluateReversePolishNotationCSharp_150 solution)
        {
            // Arrange
            string[] tokens = { "1", "2", "+", "3", "+", "4", "+", "5", "+" };

            // Act
            int result = solution.EvalRPN(tokens);

            // Assert - (((1 + 2) + 3) + 4) + 5 = 15
            Assert.AreEqual(15, result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void EvalRPN_SubtractionWithNegativeResult_Large(IEvaluateReversePolishNotationCSharp_150 solution)
        {
            // Arrange
            string[] tokens = { "10", "100", "-" };

            // Act
            int result = solution.EvalRPN(tokens);

            // Assert - 10 - 100 = -90
            Assert.AreEqual(-90, result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void EvalRPN_DivisionResultingInOne_ReturnsOne(IEvaluateReversePolishNotationCSharp_150 solution)
        {
            // Arrange
            string[] tokens = { "5", "5", "/" };

            // Act
            int result = solution.EvalRPN(tokens);

            // Assert - 5 / 5 = 1
            Assert.AreEqual(1, result);
        }
    }
}