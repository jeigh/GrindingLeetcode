using LeetCodeProblems.CSharp.Queue;
using LeetCodeProblems.Interfaces.Medium;

namespace GrindingLeetCode.UnitTests.Medium
{
    [TestClass]
    public class KthClosestPointsToOrigin_973_Tests
    { 
        public static IEnumerable<object[]> GetImplementations()
        {
            yield return new object[] { new KthClosestPointsToOrigin_CSharp_973(), "C# PriorityQueue" };
        }

        #region Helper Methods

        private void AssertPointsEqual(int[][] expected, int[][] actual, string solutionName)
        {
            Assert.AreEqual(expected.Length, actual.Length, $"Different number of points for {solutionName}");

            // Sort both arrays by x then y for comparison (order doesn't matter in result)
            var sortedExpected = expected.OrderBy(p => p[0]).ThenBy(p => p[1]).ToArray();
            var sortedActual = actual.OrderBy(p => p[0]).ThenBy(p => p[1]).ToArray();

            for (int i = 0; i < sortedExpected.Length; i++)
            {
                Assert.AreEqual(sortedExpected[i][0], sortedActual[i][0], 
                    $"Point {i} x-coordinate mismatch for {solutionName}");
                Assert.AreEqual(sortedExpected[i][1], sortedActual[i][1], 
                    $"Point {i} y-coordinate mismatch for {solutionName}");
            }
        }

        private double DistanceSquared(int[] point)
        {
            return point[0] * point[0] + point[1] * point[1];
        }

        #endregion

        #region LeetCode Examples

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void KClosest_Example1_ReturnsClosestPoints(IKthClosestPointsToOrigin_973 solution, string solutionName)
        {
            // Input: points = [[1,3],[-2,2]], k = 1
            // Output: [[-2,2]]
            // Explanation: 
            // Distance from (1,3) to origin: sqrt(1^2 + 3^2) = sqrt(10)
            // Distance from (-2,2) to origin: sqrt(4 + 4) = sqrt(8)
            // Since sqrt(8) < sqrt(10), (-2,2) is closer

            // Arrange
            int[][] points = { new[] { 1, 3 }, new[] { -2, 2 } };
            int k = 1;

            // Act
            int[][] result = solution.KClosest(points, k);

            // Assert
            var expected = new int[][] { new[] { -2, 2 } };
            AssertPointsEqual(expected, result, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void KClosest_Example2_ReturnsClosestPoints(IKthClosestPointsToOrigin_973 solution, string solutionName)
        {
            // Input: points = [[3,3],[5,-1],[-2,4]], k = 2
            // Output: [[3,3],[-2,4]]
            // Explanation:
            // Distance (3,3): sqrt(9+9) = sqrt(18)
            // Distance (5,-1): sqrt(25+1) = sqrt(26)
            // Distance (-2,4): sqrt(4+16) = sqrt(20)
            // Two closest are (3,3) and (-2,4)

            // Arrange
            int[][] points = { new[] { 3, 3 }, new[] { 5, -1 }, new[] { -2, 4 } };
            int k = 2;

            // Act
            int[][] result = solution.KClosest(points, k);

            // Assert
            var expected = new int[][] { new[] { 3, 3 }, new[] { -2, 4 } };
            AssertPointsEqual(expected, result, solutionName);
        }

        #endregion

        #region Single Point

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void KClosest_SinglePoint_K1_ReturnsThatPoint(IKthClosestPointsToOrigin_973 solution, string solutionName)
        {
            // Arrange
            int[][] points = { new[] { 1, 1 } };
            int k = 1;

            // Act
            int[][] result = solution.KClosest(points, k);

            // Assert
            var expected = new int[][] { new[] { 1, 1 } };
            AssertPointsEqual(expected, result, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void KClosest_SinglePoint_AtOrigin_ReturnsThatPoint(IKthClosestPointsToOrigin_973 solution, string solutionName)
        {
            // Arrange
            int[][] points = { new[] { 0, 0 } };
            int k = 1;

            // Act
            int[][] result = solution.KClosest(points, k);

            // Assert
            var expected = new int[][] { new[] { 0, 0 } };
            AssertPointsEqual(expected, result, solutionName);
        }

        #endregion

        #region K Equals Array Size

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void KClosest_KEqualsArraySize_ReturnsAllPoints(IKthClosestPointsToOrigin_973 solution, string solutionName)
        {
            // Arrange
            int[][] points = { new[] { 1, 1 }, new[] { 2, 2 }, new[] { 3, 3 } };
            int k = 3;

            // Act
            int[][] result = solution.KClosest(points, k);

            // Assert
            var expected = new int[][] { new[] { 1, 1 }, new[] { 2, 2 }, new[] { 3, 3 } };
            AssertPointsEqual(expected, result, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void KClosest_KEqualsArraySize_5Points_ReturnsAll(IKthClosestPointsToOrigin_973 solution, string solutionName)
        {
            // Arrange
            int[][] points = { 
                new[] { 1, 0 }, 
                new[] { 0, 1 }, 
                new[] { -1, 0 }, 
                new[] { 0, -1 },
                new[] { 1, 1 }
            };
            int k = 5;

            // Act
            int[][] result = solution.KClosest(points, k);

            // Assert
            Assert.AreEqual(5, result.Length, $"Should return all 5 points for {solutionName}");
        }

        #endregion

        #region Points on Axes

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void KClosest_PointsOnAxes_ReturnsClosest(IKthClosestPointsToOrigin_973 solution, string solutionName)
        {
            // Arrange - Points on x and y axes
            int[][] points = { 
                new[] { 1, 0 },  // Distance: 1
                new[] { 0, 2 },  // Distance: 2
                new[] { 3, 0 },  // Distance: 3
                new[] { 0, 4 }   // Distance: 4
            };
            int k = 2;

            // Act
            int[][] result = solution.KClosest(points, k);

            // Assert
            var expected = new int[][] { new[] { 1, 0 }, new[] { 0, 2 } };
            AssertPointsEqual(expected, result, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void KClosest_AllPointsOnXAxis_ReturnsClosest(IKthClosestPointsToOrigin_973 solution, string solutionName)
        {
            // Arrange
            int[][] points = { 
                new[] { 5, 0 }, 
                new[] { 1, 0 }, 
                new[] { 3, 0 }, 
                new[] { 2, 0 }
            };
            int k = 2;

            // Act
            int[][] result = solution.KClosest(points, k);

            // Assert
            var expected = new int[][] { new[] { 1, 0 }, new[] { 2, 0 } };
            AssertPointsEqual(expected, result, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void KClosest_AllPointsOnYAxis_ReturnsClosest(IKthClosestPointsToOrigin_973 solution, string solutionName)
        {
            // Arrange
            int[][] points = { 
                new[] { 0, 5 }, 
                new[] { 0, 1 }, 
                new[] { 0, 3 }, 
                new[] { 0, 2 }
            };
            int k = 2;

            // Act
            int[][] result = solution.KClosest(points, k);

            // Assert
            var expected = new int[][] { new[] { 0, 1 }, new[] { 0, 2 } };
            AssertPointsEqual(expected, result, solutionName);
        }

        #endregion

        #region Origin and Near Origin

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void KClosest_IncludesOrigin_ReturnsOriginFirst(IKthClosestPointsToOrigin_973 solution, string solutionName)
        {
            // Arrange
            int[][] points = { 
                new[] { 0, 0 },  // Distance: 0
                new[] { 1, 1 },  // Distance: sqrt(2)
                new[] { 2, 2 }   // Distance: sqrt(8)
            };
            int k = 2;

            // Act
            int[][] result = solution.KClosest(points, k);

            // Assert
            var expected = new int[][] { new[] { 0, 0 }, new[] { 1, 1 } };
            AssertPointsEqual(expected, result, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void KClosest_MultiplePointsAtOrigin_ReturnsAll(IKthClosestPointsToOrigin_973 solution, string solutionName)
        {
            // Arrange
            int[][] points = { 
                new[] { 0, 0 }, 
                new[] { 0, 0 }, 
                new[] { 5, 5 }
            };
            int k = 2;

            // Act
            int[][] result = solution.KClosest(points, k);

            // Assert
            var expected = new int[][] { new[] { 0, 0 }, new[] { 0, 0 } };
            AssertPointsEqual(expected, result, solutionName);
        }

        #endregion

        #region Equal Distances

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void KClosest_EqualDistances_ReturnsAnyK(IKthClosestPointsToOrigin_973 solution, string solutionName)
        {
            // Arrange - All points at same distance (circle with radius sqrt(2))
            int[][] points = { 
                new[] { 1, 1 },   // Distance: sqrt(2)
                new[] { -1, 1 },  // Distance: sqrt(2)
                new[] { 1, -1 },  // Distance: sqrt(2)
                new[] { -1, -1 }  // Distance: sqrt(2)
            };
            int k = 2;

            // Act
            int[][] result = solution.KClosest(points, k);

            // Assert - Any 2 points are valid since all have same distance
            Assert.AreEqual(2, result.Length, $"Should return exactly 2 points for {solutionName}");
            
            // Verify all returned points are from original set
            foreach (var point in result)
            {
                Assert.IsTrue(
                    points.Any(p => p[0] == point[0] && p[1] == point[1]),
                    $"Returned point [{point[0]},{point[1]}] not in original set for {solutionName}");
            }
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void KClosest_TwoEqualDistances_K1_ReturnsOne(IKthClosestPointsToOrigin_973 solution, string solutionName)
        {
            // Arrange - Two points with equal distance
            int[][] points = { 
                new[] { 1, 0 },  // Distance: 1
                new[] { 0, 1 }   // Distance: 1
            };
            int k = 1;

            // Act
            int[][] result = solution.KClosest(points, k);

            // Assert - Either point is valid
            Assert.AreEqual(1, result.Length, $"Should return exactly 1 point for {solutionName}");
            Assert.IsTrue(
                (result[0][0] == 1 && result[0][1] == 0) || (result[0][0] == 0 && result[0][1] == 1),
                $"Should return one of the two equal-distance points for {solutionName}");
        }

        #endregion

        #region Negative Coordinates

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void KClosest_NegativeCoordinates_ReturnsClosest(IKthClosestPointsToOrigin_973 solution, string solutionName)
        {
            // Arrange
            int[][] points = { 
                new[] { -5, -5 }, // Distance: sqrt(50)
                new[] { -1, -1 }, // Distance: sqrt(2)
                new[] { -3, -3 }  // Distance: sqrt(18)
            };
            int k = 2;

            // Act
            int[][] result = solution.KClosest(points, k);

            // Assert
            var expected = new int[][] { new[] { -1, -1 }, new[] { -3, -3 } };
            AssertPointsEqual(expected, result, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void KClosest_MixedQuadrants_ReturnsClosest(IKthClosestPointsToOrigin_973 solution, string solutionName)
        {
            // Arrange - Points in all four quadrants
            int[][] points = { 
                new[] { 1, 1 },   // Q1, Distance: sqrt(2)
                new[] { -1, 1 },  // Q2, Distance: sqrt(2)
                new[] { -1, -1 }, // Q3, Distance: sqrt(2)
                new[] { 1, -1 },  // Q4, Distance: sqrt(2)
                new[] { 5, 5 }    // Q1, Distance: sqrt(50)
            };
            int k = 4;

            // Act
            int[][] result = solution.KClosest(points, k);

            // Assert - First 4 points all have distance sqrt(2)
            var expected = new int[][] { 
                new[] { 1, 1 }, 
                new[] { -1, 1 }, 
                new[] { -1, -1 }, 
                new[] { 1, -1 } 
            };
            AssertPointsEqual(expected, result, solutionName);
        }

        #endregion

        #region Large Coordinates

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void KClosest_LargeCoordinates_ReturnsClosest(IKthClosestPointsToOrigin_973 solution, string solutionName)
        {
            // Arrange
            int[][] points = { 
                new[] { 10000, 10000 }, // Distance: sqrt(200000000)
                new[] { 1, 1 },         // Distance: sqrt(2)
                new[] { 100, 100 }      // Distance: sqrt(20000)
            };
            int k = 2;

            // Act
            int[][] result = solution.KClosest(points, k);

            // Assert
            var expected = new int[][] { new[] { 1, 1 }, new[] { 100, 100 } };
            AssertPointsEqual(expected, result, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void KClosest_NegativeLargeCoordinates_ReturnsClosest(IKthClosestPointsToOrigin_973 solution, string solutionName)
        {
            // Arrange
            int[][] points = { 
                new[] { -10000, -10000 }, 
                new[] { -1, -1 }, 
                new[] { -100, -100 }
            };
            int k = 1;

            // Act
            int[][] result = solution.KClosest(points, k);

            // Assert
            var expected = new int[][] { new[] { -1, -1 } };
            AssertPointsEqual(expected, result, solutionName);
        }

        #endregion

        #region Pythagorean Triples

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void KClosest_PythagoreanTriple_3_4_5_ReturnsClosest(IKthClosestPointsToOrigin_973 solution, string solutionName)
        {
            // Arrange - (3,4) has distance 5, others farther
            int[][] points = { 
                new[] { 3, 4 },  // Distance: 5
                new[] { 6, 8 },  // Distance: 10
                new[] { 1, 1 }   // Distance: sqrt(2)
            };
            int k = 2;

            // Act
            int[][] result = solution.KClosest(points, k);

            // Assert
            var expected = new int[][] { new[] { 1, 1 }, new[] { 3, 4 } };
            AssertPointsEqual(expected, result, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void KClosest_PythagoreanTriple_5_12_13_ReturnsClosest(IKthClosestPointsToOrigin_973 solution, string solutionName)
        {
            // Arrange
            int[][] points = { 
                new[] { 5, 12 },  // Distance: 13
                new[] { 3, 4 },   // Distance: 5
                new[] { 8, 15 }   // Distance: 17
            };
            int k = 2;

            // Act
            int[][] result = solution.KClosest(points, k);

            // Assert
            var expected = new int[][] { new[] { 3, 4 }, new[] { 5, 12 } };
            AssertPointsEqual(expected, result, solutionName);
        }

        #endregion

        #region Duplicate Points

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void KClosest_DuplicatePoints_ReturnsBoth(IKthClosestPointsToOrigin_973 solution, string solutionName)
        {
            // Arrange
            int[][] points = { 
                new[] { 1, 1 }, 
                new[] { 1, 1 }, 
                new[] { 5, 5 }
            };
            int k = 2;

            // Act
            int[][] result = solution.KClosest(points, k);

            // Assert
            var expected = new int[][] { new[] { 1, 1 }, new[] { 1, 1 } };
            AssertPointsEqual(expected, result, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void KClosest_MultipleDuplicates_ReturnsAllClosest(IKthClosestPointsToOrigin_973 solution, string solutionName)
        {
            // Arrange
            int[][] points = { 
                new[] { 2, 2 }, 
                new[] { 2, 2 }, 
                new[] { 2, 2 }, 
                new[] { 10, 10 }
            };
            int k = 3;

            // Act
            int[][] result = solution.KClosest(points, k);

            // Assert
            var expected = new int[][] { new[] { 2, 2 }, new[] { 2, 2 }, new[] { 2, 2 } };
            AssertPointsEqual(expected, result, solutionName);
        }

        #endregion

        #region Sparse and Dense Regions

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void KClosest_SparseFarPoints_ReturnsClosest(IKthClosestPointsToOrigin_973 solution, string solutionName)
        {
            // Arrange - Few points, all relatively far
            // Distance (10,0) = 10
            // Distance (0,20) = 20
            // Distance (15,15) = sqrt(450) = 21.21
            // Distance (30,0) = 30
            int[][] points = { 
                new[] { 10, 0 }, 
                new[] { 0, 20 }, 
                new[] { 15, 15 }, 
                new[] { 30, 0 }
            };
            int k = 2;

            // Act
            int[][] result = solution.KClosest(points, k);

            // Assert
            var expected = new int[][] { new[] { 10, 0 }, new[] { 0, 20 } };
            AssertPointsEqual(expected, result, solutionName);
        }

        #endregion

        #region Property Tests

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void KClosest_VerifyAllReturnedAreClosest(IKthClosestPointsToOrigin_973 solution, string solutionName)
        {
            // Verify that all returned points are indeed among the k closest

            // Arrange
            int[][] points = { 
                new[] { 1, 1 },  // sqrt(2)
                new[] { 2, 2 },  // sqrt(8)
                new[] { 3, 3 },  // sqrt(18)
                new[] { 4, 4 },  // sqrt(32)
                new[] { 5, 5 }   // sqrt(50)
            };
            int k = 3;

            // Act
            int[][] result = solution.KClosest(points, k);

            // Assert
            Assert.AreEqual(3, result.Length, $"Should return exactly 3 points for {solutionName}");

            // Calculate max distance in result
            double maxDistInResult = result.Max(p => DistanceSquared(p));
            
            // Verify no point outside result has smaller distance
            var resultSet = new HashSet<(int, int)>(result.Select(p => (p[0], p[1])));
            foreach (var point in points)
            {
                if (!resultSet.Contains((point[0], point[1])))
                {
                    // Point not in result should have distance >= max distance in result
                    Assert.IsTrue(DistanceSquared(point) >= maxDistInResult,
                        $"Point [{point[0]},{point[1]}] outside result is closer than points in result for {solutionName}");
                }
            }
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void KClosest_ResultCountAlwaysEqualsK(IKthClosestPointsToOrigin_973 solution, string solutionName)
        {
            // Verify result always has exactly k points

            // Arrange
            var testCases = new[]
            {
                (new int[][] { new[] { 1, 1 }, new[] { 2, 2 }, new[] { 3, 3 } }, 1),
                (new int[][] { new[] { 1, 1 }, new[] { 2, 2 }, new[] { 3, 3 } }, 2),
                (new int[][] { new[] { 1, 1 }, new[] { 2, 2 }, new[] { 3, 3 } }, 3),
                (new int[][] { new[] { 1, 0 }, new[] { 0, 1 }, new[] { 2, 0 }, new[] { 0, 2 }, new[] { 1, 1 } }, 3)
            };

            foreach (var (testPoints, testK) in testCases)
            {
                // Act
                int[][] result = solution.KClosest(testPoints, testK);

                // Assert
                Assert.AreEqual(testK, result.Length, 
                    $"Result should have exactly {testK} points for {solutionName}");
            }
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void KClosest_AllReturnedPointsFromOriginal(IKthClosestPointsToOrigin_973 solution, string solutionName)
        {
            // Verify all returned points exist in original array

            // Arrange
            int[][] points = { 
                new[] { 1, 2 }, 
                new[] { 3, 4 }, 
                new[] { 5, 6 }, 
                new[] { 7, 8 }
            };
            int k = 2;

            // Act
            int[][] result = solution.KClosest(points, k);

            // Assert
            var originalSet = new HashSet<(int, int)>(points.Select(p => (p[0], p[1])));
            
            foreach (var point in result)
            {
                Assert.IsTrue(originalSet.Contains((point[0], point[1])),
                    $"Returned point [{point[0]},{point[1]}] not in original set for {solutionName}");
            }
        }

        #endregion

        #region Boundary Values

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void KClosest_MaxCoordinates_HandlesCorrectly(IKthClosestPointsToOrigin_973 solution, string solutionName)
        {
            // Arrange - Points at boundary values
            int[][] points = { 
                new[] { 10000, 10000 }, 
                new[] { -10000, -10000 }, 
                new[] { 1, 1 }, 
                new[] { -1, -1 }
            };
            int k = 2;

            // Act
            int[][] result = solution.KClosest(points, k);

            // Assert
            var expected = new int[][] { new[] { 1, 1 }, new[] { -1, -1 } };
            AssertPointsEqual(expected, result, solutionName);
        }

        #endregion

        #region Circle Patterns

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void KClosest_PointsOnSameCircle_ReturnsAnyK(IKthClosestPointsToOrigin_973 solution, string solutionName)
        {
            // Arrange - Points on circle of radius 5
            int[][] points = { 
                new[] { 3, 4 },   // Distance: 5
                new[] { 4, 3 },   // Distance: 5
                new[] { -3, 4 },  // Distance: 5
                new[] { 3, -4 },  // Distance: 5
                new[] { 0, 5 },   // Distance: 5
                new[] { 5, 0 }    // Distance: 5
            };
            int k = 3;

            // Act
            int[][] result = solution.KClosest(points, k);

            // Assert - Any 3 points valid since all at same distance
            Assert.AreEqual(3, result.Length, $"Should return exactly 3 points for {solutionName}");
            
            foreach (var point in result)
            {
                double dist = Math.Sqrt(DistanceSquared(point));
                Assert.AreEqual(5.0, dist, 0.01, 
                    $"All returned points should be at distance 5 for {solutionName}");
            }
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void KClosest_ConcentricCircles_ReturnsInnerCircle(IKthClosestPointsToOrigin_973 solution, string solutionName)
        {
            // Arrange - Points on concentric circles
            int[][] points = { 
                // Inner circle (radius 1)
                new[] { 1, 0 }, 
                new[] { 0, 1 }, 
                // Middle circle (radius 2)
                new[] { 2, 0 }, 
                new[] { 0, 2 }, 
                // Outer circle (radius 3)
                new[] { 3, 0 }, 
                new[] { 0, 3 }
            };
            int k = 2;

            // Act
            int[][] result = solution.KClosest(points, k);

            // Assert - Should return inner circle points
            var expected = new int[][] { new[] { 1, 0 }, new[] { 0, 1 } };
            AssertPointsEqual(expected, result, solutionName);
        }

        #endregion
    }
}
