using LeetCodeProblems.HashingOrArrays;

namespace GrindingLeetCode.UnitTests.HashingOrArrays
{
    [TestClass]
    public class RemoveDuplicatesFromSortedArrayHashSetSolution_26_Tests
    {
        private RemoveDuplicatesFromSortedArrayHashsetSolution_26 _solution;

        [TestInitialize]
        public void Initialize()
        {
            _solution = new RemoveDuplicatesFromSortedArrayHashsetSolution_26();
        }

        [TestMethod]
        public void RemoveDuplicates_Example1_RemovesDuplicates()
        {
            int[] nums = { 1, 1, 2 };
            int k = _solution.RemoveDuplicates(nums);
            Assert.AreEqual(2, k);
            CollectionAssert.AreEqual(new[] { 1, 2 }, nums[..k]);
        }

        [TestMethod]
        public void RemoveDuplicates_Example2_RemovesDuplicates()
        {
            int[] nums = { 0,0,1,1,1,2,2,3,3,4 };
            int k = _solution.RemoveDuplicates(nums);
            Assert.AreEqual(5, k);
            CollectionAssert.AreEqual(new[] { 0, 1, 2, 3, 4 }, nums[..k]);
        }

        [TestMethod]
        public void RemoveDuplicates_NoDuplicates_ReturnsOriginalLength()
        {
            int[] nums = { 1, 2, 3, 4, 5 };
            int k = _solution.RemoveDuplicates(nums);
            Assert.AreEqual(5, k);
            CollectionAssert.AreEqual(new[] { 1, 2, 3, 4, 5 }, nums[..k]);
        }

        [TestMethod]
        public void RemoveDuplicates_AllDuplicates_ReturnsOne()
        {
            int[] nums = { 7, 7, 7, 7 };
            int k = _solution.RemoveDuplicates(nums);
            Assert.AreEqual(1, k);
            CollectionAssert.AreEqual(new[] { 7 }, nums[..k]);
        }

        [TestMethod]
        public void RemoveDuplicates_EmptyArray_ReturnsZero()
        {
            int[] nums = { };
            int k = _solution.RemoveDuplicates(nums);
            Assert.AreEqual(0, k);
        }

        [TestMethod]
        public void RemoveDuplicates_SingleElement_ReturnsOne()
        {
            int[] nums = { 42 };
            int k = _solution.RemoveDuplicates(nums);
            Assert.AreEqual(1, k);
            CollectionAssert.AreEqual(new[] { 42 }, nums[..k]);
        }
    }


}