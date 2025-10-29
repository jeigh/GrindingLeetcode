using LeetCodeProblems;

namespace GrindingLeetCode.UnitTests
{
    [TestClass]
    public class ThresSumSolution_15_Tests
    {
        private ThreeSumBespokeSolution_15 _solution;

        [TestInitialize]
        public void Initialize()
        {
            _solution = new ThreeSumBespokeSolution_15();
        }

        private static List<List<int>> NormalizeResult(IList<IList<int>> result)
        {
            // Sort each triplet and the list of triplets for comparison
            return result.Select(triplet => triplet.OrderBy(x => x).ToList())
                         .OrderBy(triplet => string.Join(",", triplet))
                         .ToList();
        }

        [TestMethod]
        public void ThreeSum_Example1_ReturnsCorrectTriplets()
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
            {
                CollectionAssert.AreEqual(normalizedExpected[i], normalizedResult[i]);
            }
        }

        [TestMethod]
        public void ThreeSum_NoTriplets_ReturnsEmptyList()
        {
            int[] nums = { 1, 2, 3, 4 };
            var result = _solution.ThreeSum(nums);
            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public void ThreeSum_EmptyArray_ReturnsEmptyList()
        {
            int[] nums = { };
            var result = _solution.ThreeSum(nums);
            Assert.AreEqual(0, result.Count);
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
        public void ThreeSum_MultipleTripletsWithDuplicates_ReturnsUniqueTriplets()
        {
            int[] nums = { -2, 0, 0, 2, 2 };
            var expected = new List<IList<int>> { new List<int> { -2, 0, 2 } };
            var result = _solution.ThreeSum(nums);
            var normalizedResult = NormalizeResult(result);
            var normalizedExpected = NormalizeResult(expected);
            Assert.AreEqual(normalizedExpected.Count, normalizedResult.Count);
            CollectionAssert.AreEqual(normalizedExpected[0], normalizedResult[0]);
        }

        [TestMethod]
        public void ThreeSum_NegativeAndPositiveNumbers_ReturnsCorrectTriplets()
        {
            int[] nums = { -2, -1, 1, 2, 0 };
            var expected = new List<IList<int>>
            {
                new List<int> { -2, 0, 2 },
                //new List<int> { -2, 1, 1 },
                new List<int> { -1, 0, 1 }
            };
            var result = _solution.ThreeSum(nums);
            var normalizedResult = NormalizeResult(result);
            var normalizedExpected = NormalizeResult(expected);
            Assert.AreEqual(normalizedExpected.Count, normalizedResult.Count);
            // Each expected triplet should be present in the result
            foreach (var triplet in normalizedExpected)
            {
                Assert.IsTrue(normalizedResult.Any(r => r.SequenceEqual(triplet)));
            }
        }
    }
}