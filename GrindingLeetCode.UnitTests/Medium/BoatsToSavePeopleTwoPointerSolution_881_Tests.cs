using LeetCodeProblems.TwoPointers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GrindingLeetCode.UnitTests.Medium
{
    [TestClass]
    public class BoatsToSavePeopleTwoPointerSolution_881_Tests
    {
        private BoatsToSavePeopleTwoPointerSolution_881 _solution;

        [TestInitialize]
        public void Initialize()
        {
            _solution = new BoatsToSavePeopleTwoPointerSolution_881();
        }

        [TestMethod]
        public void NumRescueBoats_Example1_ReturnsThree()
        {
            int[] people = { 3, 2, 2, 1 };
            int limit = 3;
            int result = _solution.NumRescueBoats(people, limit);
            Assert.AreEqual(3, result);
        }

        [TestMethod]
        public void NumRescueBoats_Example2_ReturnsFour()
        {
            int[] people = { 3, 5, 3, 4 };
            int limit = 5;
            int result = _solution.NumRescueBoats(people, limit);
            Assert.AreEqual(4, result);
        }

        [TestMethod]
        public void NumRescueBoats_AllOnes_PairsCorrectly()
        {
            int[] people = { 1, 1, 1, 1 };
            int limit = 2;
            int result = _solution.NumRescueBoats(people, limit);
            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void NumRescueBoats_MixedWeights_ReturnsCorrect()
        {
            int[] people = { 1, 2, 2, 3 };
            int limit = 3;
            int result = _solution.NumRescueBoats(people, limit);
            Assert.AreEqual(3, result);
        }

        [TestMethod]
        public void NumRescueBoats_SinglePerson_ReturnsOne()
        {
            int[] people = { 2 };
            int limit = 3;
            int result = _solution.NumRescueBoats(people, limit);
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void NumRescueBoats_EmptyArray_ReturnsZero()
        {
            int[] people = { };
            int limit = 5;
            int result = _solution.NumRescueBoats(people, limit);
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void NumRescueBoats_AllEqualToLimit_EachNeedsBoat()
        {
            int[] people = { 5, 5, 5 };
            int limit = 5;
            int result = _solution.NumRescueBoats(people, limit);
            Assert.AreEqual(3, result);
        }

        [TestMethod]
        public void NumRescueBoats_LargeAndSmallCombination_ReturnsMinimalBoats()
        {
            int[] people = { 2, 3, 3, 4, 1, 2 };
            int limit = 5;
            int result = _solution.NumRescueBoats(people, limit);
            // one optimal packing: (1,4), (2,3), (2,3) => 3 boats
            Assert.AreEqual(3, result);
        }
    }
}