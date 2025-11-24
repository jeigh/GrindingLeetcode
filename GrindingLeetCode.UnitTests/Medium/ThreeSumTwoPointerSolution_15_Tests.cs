using LeetCodeProblems.TwoPointers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace GrindingLeetCode.UnitTests.Medium
{
    [TestClass]
    public class ThreeSumTwoPointerSolution_15_Tests
    {
        private ThreeSumTwoPointerSolution_15 _solution;

        [TestInitialize]
        public void Initialize()
        {
            _solution = new ThreeSumTwoPointerSolution_15();
        }

        private static List<List<int>> NormalizeResult(IList<IList<int>> result)
        {
            return result
                .Select(triplet => triplet.OrderBy(x => x).ToList())
                .OrderBy(triplet => string.Join(",", triplet))
                .ToList();
        }

        [TestMethod]
        public void ThreeSum_Example1_ReturnsExpectedTriplets()
        {
            int[] nums = { -1, 0, 1, 2, -1, -4 };
            var expected = new List<IList<int>>
            {
                new List<int> { -1, -1, 2 },
                new List<int> { -1, 0, 1 }
            };

            var result = _solution.ThreeSum(nums);
            var normalizedResult = NormalizeResult(result);
            var normalizedExpected = NormalizeResult(expected);

            Assert.AreEqual(normalizedExpected.Count, normalizedResult.Count);
            for (int i = 0; i < normalizedExpected.Count; i++)
                CollectionAssert.AreEqual(normalizedExpected[i], normalizedResult[i]);
        }

        [TestMethod]
        public void ThreeSum_AllZeros_ReturnsSingleTriplet()
        {
            int[] nums = { 0, 0, 0, 0 };
            var expected = new List<IList<int>> { new List<int> { 0, 0, 0 } };

            var result = _solution.ThreeSum(nums);
            var normalizedResult = NormalizeResult(result);
            var normalizedExpected = NormalizeResult(expected);

            Assert.AreEqual(normalizedExpected.Count, normalizedResult.Count);
            CollectionAssert.AreEqual(normalizedExpected[0], normalizedResult[0]);
        }

        [TestMethod]
        public void ThreeSum_NoTriplets_ReturnsEmptyList()
        {
            int[] nums = { 1, 2, 3, 4 };
            var result = _solution.ThreeSum(nums);
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public void ThreeSum_EmptyArray_ReturnsEmptyList()
        {
            int[] nums = { };
            var result = _solution.ThreeSum(nums);
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public void ThreeSum_SingleElement_ReturnsEmptyList()
        {
            int[] nums = { 0 };
            var result = _solution.ThreeSum(nums);
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public void ThreeSum_MultipleTriplets_ReturnsAllUniqueTriplets()
        {
            int[] nums = { -2, -1, 0, 1, 2 };
            var expected = new List<IList<int>>
            {
                new List<int> { -2, 0, 2 },
                new List<int> { -1, 0, 1 }
            };

            var result = _solution.ThreeSum(nums);
            var normalizedResult = NormalizeResult(result);
            var normalizedExpected = NormalizeResult(expected);

            Assert.AreEqual(normalizedExpected.Count, normalizedResult.Count);
            for (int i = 0; i < normalizedExpected.Count; i++)
                CollectionAssert.AreEqual(normalizedExpected[i], normalizedResult[i]);
        }

        [TestMethod]
        public void ThreeSum_DuplicatesHandled_ReturnsUniqueTriplet()
        {
            int[] nums = { -2, 0, 0, 2, 2 };
            var expected = new List<IList<int>> { new List<int> { -2, 0, 2 } };

            var result = _solution.ThreeSum(nums);
            var normalizedResult = NormalizeResult(result);
            var normalizedExpected = NormalizeResult(expected);

            Assert.AreEqual(normalizedExpected.Count, normalizedResult.Count);
            CollectionAssert.AreEqual(normalizedExpected[0], normalizedResult[0]);
        }
    }
}