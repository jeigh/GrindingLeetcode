using LeetCodeProblems.HashingOrArrays;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GrindingLeetCode.UnitTests
{
    [TestClass]
    public class SortColorsSolution_75_Tests
    {
        private SortColorsSolution_75 _solution;

        [TestInitialize]
        public void Initialize()
        {
            _solution = new SortColorsSolution_75();
        }

        [TestMethod]
        public void SortColors_Example1_SortsCorrectly()
        {
            int[] nums = { 2, 0, 2, 1, 1, 0 };
            _solution.SortColors(nums);
            CollectionAssert.AreEqual(new[] { 0, 0, 1, 1, 2, 2 }, nums);
        }

        [TestMethod]
        public void SortColors_Example1200_SortsCorrectly()
        {
            int[] nums = { 1,2,0, 0 };
            _solution.SortColors(nums);
            CollectionAssert.AreEqual(new[] { 0, 0, 1, 2 }, nums);
        }


        [TestMethod]
        public void SortColors_Example201_SortsCorrectly()
        {
            int[] nums = { 2, 0, 1 };
            _solution.SortColors(nums);
            CollectionAssert.AreEqual(new[] { 0,1,2}, nums);
        }



        [TestMethod]
        public void SortColors_AlreadySorted_RemainsUnchanged()
        {
            int[] nums = { 0, 0, 1, 1, 2, 2 };
            _solution.SortColors(nums);
            CollectionAssert.AreEqual(new[] { 0, 0, 1, 1, 2, 2 }, nums);
        }

        [TestMethod]
        public void SortColors_AllZeros()
        {
            int[] nums = { 0, 0, 0 };
            _solution.SortColors(nums);
            CollectionAssert.AreEqual(new[] { 0, 0, 0 }, nums);
        }

        [TestMethod]
        public void SortColors_AllOnes()
        {
            int[] nums = { 1, 1, 1 };
            _solution.SortColors(nums);
            CollectionAssert.AreEqual(new[] { 1, 1, 1 }, nums);
        }

        [TestMethod]
        public void SortColors_AllTwos()
        {
            int[] nums = { 2, 2, 2 };
            _solution.SortColors(nums);
            CollectionAssert.AreEqual(new[] { 2, 2, 2 }, nums);
        }

        [TestMethod]
        public void SortColors_EmptyArray()
        {
            int[] nums = { };
            _solution.SortColors(nums);
            CollectionAssert.AreEqual(new int[0], nums);
        }

        [TestMethod]
        public void SortColors_SingleElement()
        {
            int[] nums = { 1 };
            _solution.SortColors(nums);
            CollectionAssert.AreEqual(new[] { 1 }, nums);
        }

        [TestMethod]
        public void SortColors_TwoElements()
        {
            int[] nums = { 2, 0 };
            _solution.SortColors(nums);
            CollectionAssert.AreEqual(new[] { 0, 2 }, nums);
        }

        [TestMethod]
        public void SortColors_MixedOrder()
        {
            int[] nums = { 1, 2, 0, 2, 1, 0, 1 };
            _solution.SortColors(nums);
            CollectionAssert.AreEqual(new[] { 0, 0, 1, 1, 1, 2, 2 }, nums);
        }
    }
}