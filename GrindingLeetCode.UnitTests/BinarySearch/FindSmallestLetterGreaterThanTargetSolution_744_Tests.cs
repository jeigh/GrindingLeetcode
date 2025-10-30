using LeetCodeProblems.BinarySearch;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GrindingLeetCode.UnitTests.BinarySearch
{
    [TestClass]
    public class FindSmallestLetterGreaterThanTargetSolution_744_Tests
    {
        private FindSmallestLetterGreaterThanTargetSolution_744 _solution;

        [TestInitialize]
        public void Initialize()
        {
            _solution = new FindSmallestLetterGreaterThanTargetSolution_744();
        }

        [TestMethod]
        public void NextGreatestLetter_TargetBetweenLetters_ReturnsNextLetter()
        {
            // Arrange
            char[] letters = { 'c', 'f', 'j' };
            char target = 'a';

            // Act
            char result = _solution.NextGreatestLetter(letters, target);

            // Assert
            Assert.AreEqual('c', result);
        }

        [TestMethod]
        public void NextGreatestLetter_TargetPresentInArray_ReturnsNextLargerLetter()
        {
            // Arrange
            char[] letters = { 'c', 'f', 'j' };
            char target = 'c';

            // Act
            char result = _solution.NextGreatestLetter(letters, target);

            // Assert
            Assert.AreEqual('f', result);
        }

        [TestMethod]
        public void NextGreatestLetter_TargetGreaterThanAllLetters_ReturnsFirstLetter()
        {
            // Arrange
            char[] letters = { 'c', 'f', 'j' };
            char target = 'j';

            // Act
            char result = _solution.NextGreatestLetter(letters, target);

            // Assert
            Assert.AreEqual('c', result);
        }

        [TestMethod]
        public void NextGreatestLetter_TargetBetweenLettersInArray_ReturnsNextLetter()
        {
            // Arrange
            char[] letters = { 'c', 'f', 'j' };
            char target = 'd';

            // Act
            char result = _solution.NextGreatestLetter(letters, target);

            // Assert
            Assert.AreEqual('f', result);
        }

        [TestMethod]
        public void NextGreatestLetter_WithDuplicateLetters_ReturnsCorrectLetter()
        {
            // Arrange
            char[] letters = { 'c', 'c', 'f', 'f', 'j' };
            char target = 'c';

            // Act
            char result = _solution.NextGreatestLetter(letters, target);

            // Assert
            Assert.AreEqual('f', result);
        }

        [TestMethod]
        public void NextGreatestLetter_SingleLetterArray_ReturnsOnlyLetter()
        {
            // Arrange
            char[] letters = { 'c' };
            char target = 'z';

            // Act
            char result = _solution.NextGreatestLetter(letters, target);

            // Assert
            Assert.AreEqual('c', result);
        }

        [TestMethod]
        public void NextGreatestLetter_SingleLetterArrayWithTargetEqual_ReturnsOnlyLetter()
        {
            // Arrange
            char[] letters = { 'c' };
            char target = 'c';

            // Act
            char result = _solution.NextGreatestLetter(letters, target);

            // Assert
            Assert.AreEqual('c', result);
        }

        [TestMethod]
        public void NextGreatestLetter_TargetBetweenDuplicates_ReturnsCorrectLetter()
        {
            // Arrange
            char[] letters = { 'a', 'a', 'c', 'c', 'e', 'f' };
            char target = 'b';

            // Act
            char result = _solution.NextGreatestLetter(letters, target);

            // Assert
            Assert.AreEqual('c', result);
        }

        [TestMethod]
        public void NextGreatestLetter_AllSameLetterArray_ReturnsThatLetter()
        {
            // Arrange
            char[] letters = { 'a', 'a', 'a', 'a' };
            char target = 'z';

            // Act
            char result = _solution.NextGreatestLetter(letters, target);

            // Assert
            Assert.AreEqual('a', result);
        }

        [TestMethod]
        public void NextGreatestLetter_AllSameLetterArrayWithTargetEqual_ReturnsThatLetter()
        {
            // Arrange
            char[] letters = { 'a', 'a', 'a', 'a' };
            char target = 'a';

            // Act
            char result = _solution.NextGreatestLetter(letters, target);

            // Assert
            Assert.AreEqual('a', result);
        }
    }
}