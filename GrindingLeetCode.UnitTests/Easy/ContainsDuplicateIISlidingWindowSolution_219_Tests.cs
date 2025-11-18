using LeetCodeProblems;
using LeetCodeProblems.Interfaces.Easy;


namespace GrindingLeetCode.UnitTests.Easy
{
    [TestClass]
    public class ContainsDuplicateIIHashSetSolution_219_Tests
    {
        public static IEnumerable<object[]> GetImplementations()
        {
            yield return new object[] { new LeetCodeProblems.HashingOrArrays.ContainsDuplicateIIHashSetSolution_219() };
            yield return new object[] { new LeetCodeProblems.VisualBasic.HashingOrArrays.ContainsDuplicateIIHashSetSolution_219() };
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void ContainsNearbyDuplicate_DuplicateWithinK_ReturnsTrue(IContainsDuplicateII_219 solution)
        {
            int[] nums = { 1, 2, 3, 1 };
            int k = 3;
            Assert.IsTrue(solution.ContainsNearbyDuplicate(nums, k));
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void ContainsNearbyDuplicate_AdjacentDuplicates_KEquals1_ReturnsTrue(IContainsDuplicateII_219 solution)
        {
            int[] nums = { 1, 0, 1, 1 };
            int k = 1;
            Assert.IsTrue(solution.ContainsNearbyDuplicate(nums, k));
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void ContainsNearbyDuplicate_NoDuplicateWithinK_ReturnsFalse(IContainsDuplicateII_219 solution)
        {
            int[] nums = { 1, 2, 3, 1, 2, 3 };
            int k = 2;
            Assert.IsFalse(solution.ContainsNearbyDuplicate(nums, k));
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void ContainsNearbyDuplicate_DuplicateDistanceGreaterThanK_ReturnsFalse(IContainsDuplicateII_219 solution)
        {
            int[] nums = { 1, 2, 3, 1 };
            int k = 2;
            Assert.IsFalse(solution.ContainsNearbyDuplicate(nums, k));
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void ContainsNearbyDuplicate_EmptyArray_ReturnsFalse(IContainsDuplicateII_219 solution)
        {
            int[] nums = { };
            int k = 5;
            Assert.IsFalse(solution.ContainsNearbyDuplicate(nums, k));
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void ContainsNearbyDuplicate_SingleElement_ReturnsFalse(IContainsDuplicateII_219 solution)
        {
            int[] nums = { 42 };
            int k = 1;
            Assert.IsFalse(solution.ContainsNearbyDuplicate(nums, k));
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void ContainsNearbyDuplicate_KZero_NoPairsAllowed_ReturnsFalse(IContainsDuplicateII_219 solution)
        {
            int[] nums = { 1, 1 };
            int k = 0;
            Assert.IsFalse(solution.ContainsNearbyDuplicate(nums, k));
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void ContainsNearbyDuplicate_LargeK_BehavesAsUnbounded_ReturnsTrue(IContainsDuplicateII_219 solution)
        {
            int[] nums = { 4, 1, 2, 3, 4 };
            int k = 100;
            Assert.IsTrue(solution.ContainsNearbyDuplicate(nums, k));
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void ContainsNearbyDuplicate_NegativeValues_ReturnsTrue(IContainsDuplicateII_219 solution)
        {
            int[] nums = { -1, -2, -1 };
            int k = 2;
            Assert.IsTrue(solution.ContainsNearbyDuplicate(nums, k));
        }
    }
}