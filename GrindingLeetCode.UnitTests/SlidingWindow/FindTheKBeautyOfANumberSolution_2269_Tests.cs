using LeetCodeProblems.CSharp.SlidingWindow;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GrindingLeetCode.UnitTests.SlidingWindow
{
    [TestClass]
    public class FindTheKBeautyOfANumberSolution_2269_Tests
    {
        private FindTheKBeautyOfANumberSolution_2269 _solution;

        [TestInitialize]
        public void Initialize()
        {
            _solution = new FindTheKBeautyOfANumberSolution_2269();
        }

        [TestMethod]
        public void DivisorSubstrings_Example1_Returns2()
        {
            // Arrange
            int num = 240;
            int k = 2;

            // Act
            int result = _solution.DivisorSubstrings(num, k);

            // Assert
            Assert.AreEqual(2, result); // "24" and "40" are divisors
        }

        [TestMethod]
        public void DivisorSubstrings_Example2_Returns4()
        {
            // Arrange
            int num = 430043;
            int k = 2;

            // Act
            int result = _solution.DivisorSubstrings(num, k);

            // Assert
            Assert.AreEqual(2, result); // "43", "30", "00", "04", "43" - but "00" and "04" (leading zero = 4) are not divisors
        }

        [TestMethod]
        public void DivisorSubstrings_WithLeadingZeros_HandlesCorrectly()
        {
            // Arrange
            int num = 100;
            int k = 2;

            // Act
            int result = _solution.DivisorSubstrings(num, k);

            // Assert
            Assert.AreEqual(1, result); // "10" is divisor, "00" is 0 which is not a divisor
        }

        [TestMethod]
        public void DivisorSubstrings_WithZeroSubstring_Excludes()
        {
            // Arrange
            int num = 1000;
            int k = 2;

            // Act
            int result = _solution.DivisorSubstrings(num, k);

            // Assert
            Assert.AreEqual(1, result); // Only "10" is divisor, "00" appears twice but is 0
        }

        [TestMethod]
        public void DivisorSubstrings_SingleDigit_Returns1IfDivisor()
        {
            // Arrange
            int num = 4;
            int k = 1;

            // Act
            int result = _solution.DivisorSubstrings(num, k);

            // Assert
            Assert.AreEqual(1, result); // "4" divides 4
        }

        [TestMethod]
        public void DivisorSubstrings_KEqualsLength_Returns1IfDivisor()
        {
            // Arrange
            int num = 12;
            int k = 2;

            // Act
            int result = _solution.DivisorSubstrings(num, k);

            // Assert
            Assert.AreEqual(1, result); // "12" divides 12, "2" divides 12 (but k=2, so we check "12" only)
        }

        [TestMethod]
        public void DivisorSubstrings_NoDivisors_Returns0()
        {
            // Arrange
            int num = 13;
            int k = 2;

            // Act
            int result = _solution.DivisorSubstrings(num, k);

            // Assert
            Assert.AreEqual(1, result); 
        }

        [TestMethod]
        public void DivisorSubstrings_AllSubstringsDivide_ReturnsAllCount()
        {
            // Arrange
            int num = 1111;
            int k = 1;

            // Act
            int result = _solution.DivisorSubstrings(num, k);

            // Assert
            Assert.AreEqual(4, result); // All four "1"s divide 1111
        }

        [TestMethod]
        public void DivisorSubstrings_LargeNumber_WorksCorrectly()
        {
            // Arrange
            int num = 123456;
            int k = 3;

            // Act
            int result = _solution.DivisorSubstrings(num, k);

            // Assert
            // Substrings: "123", "234", "345", "456"
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void DivisorSubstrings_RepeatingDigits_CountsEachOccurrence()
        {
            // Arrange
            int num = 2020;
            int k = 2;

            // Act
            int result = _solution.DivisorSubstrings(num, k);

            // Assert
            // Substrings: "20", "02", "20"
            // 2020 % 20 = 0 (divisor appears twice), 2020 % 2 = 0 (leading zero, "02" = 2)
            Assert.AreEqual(3, result);
        }

        [TestMethod]
        public void DivisorSubstrings_MinimumValue_HandlesCorrectly()
        {
            // Arrange
            int num = 1;
            int k = 1;

            // Act
            int result = _solution.DivisorSubstrings(num, k);

            // Assert
            Assert.AreEqual(1, result); // "1" divides 1
        }
    }
}