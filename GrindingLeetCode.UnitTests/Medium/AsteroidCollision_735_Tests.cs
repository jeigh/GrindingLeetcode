using LeetCodeProblems.CSharp.Stack;
using LeetCodeProblems.Interfaces.Medium;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GrindingLeetCode.UnitTests.Medium
{
    [TestClass]
    public class AsteroidCollision_735_Tests
    {
        public static IEnumerable<object[]> GetImplementations()
        {
            yield return new object[] { new AsteroidCollision_735() };
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void AsteroidCollision_Example1_ReturnsExpectedResult(IAsteroidCollision_735 solution)
        {
            // Arrange
            int[] asteroids = { 5, 10, -5 };
            int[] expected = { 5, 10 };

            // Act
            int[] result = solution.AsteroidCollision(asteroids);

            // Assert
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void AsteroidCollision_Example2_AllExplode(IAsteroidCollision_735 solution)
        {
            // Arrange
            int[] asteroids = { 8, -8 };
            int[] expected = { };

            // Act
            int[] result = solution.AsteroidCollision(asteroids);

            // Assert
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void AsteroidCollision_Example3_LeftWins(IAsteroidCollision_735 solution)
        {
            // Arrange
            int[] asteroids = { 10, 2, -5 };
            int[] expected = { 10 };

            // Act
            int[] result = solution.AsteroidCollision(asteroids);

            // Assert
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void AsteroidCollision_NoCollision_AllMovingRight(IAsteroidCollision_735 solution)
        {
            // Arrange
            int[] asteroids = { 1, 2, 3, 4, 5 };
            int[] expected = { 1, 2, 3, 4, 5 };

            // Act
            int[] result = solution.AsteroidCollision(asteroids);

            // Assert
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void AsteroidCollision_NoCollision_AllMovingLeft(IAsteroidCollision_735 solution)
        {
            // Arrange
            int[] asteroids = { -5, -4, -3, -2, -1 };
            int[] expected = { -5, -4, -3, -2, -1 };

            // Act
            int[] result = solution.AsteroidCollision(asteroids);

            // Assert
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void AsteroidCollision_LeftMovingFollowedByRightMoving_NoCollision(IAsteroidCollision_735 solution)
        {
            // Arrange
            int[] asteroids = { -2, -1, 1, 2 };
            int[] expected = { -2, -1, 1, 2 };

            // Act
            int[] result = solution.AsteroidCollision(asteroids);

            // Assert
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void AsteroidCollision_RightWinsAll(IAsteroidCollision_735 solution)
        {
            // Arrange
            int[] asteroids = { 10, -1, -2, -3 };
            int[] expected = { 10 };

            // Act
            int[] result = solution.AsteroidCollision(asteroids);

            // Assert
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void AsteroidCollision_LeftWinsAll(IAsteroidCollision_735 solution)
        {
            // Arrange
            int[] asteroids = { 1, 2, 3, -10 };
            int[] expected = { -10 };

            // Act
            int[] result = solution.AsteroidCollision(asteroids);

            // Assert
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void AsteroidCollision_MultipleCollisions_ChainReaction(IAsteroidCollision_735 solution)
        {
            // Arrange
            int[] asteroids = { 5, 10, -5 };
            int[] expected = { 5, 10 };

            // Act
            int[] result = solution.AsteroidCollision(asteroids);

            // Assert
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void AsteroidCollision_SingleAsteroid_Right(IAsteroidCollision_735 solution)
        {
            // Arrange
            int[] asteroids = { 5 };
            int[] expected = { 5 };

            // Act
            int[] result = solution.AsteroidCollision(asteroids);

            // Assert
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void AsteroidCollision_SingleAsteroid_Left(IAsteroidCollision_735 solution)
        {
            // Arrange
            int[] asteroids = { -5 };
            int[] expected = { -5 };

            // Act
            int[] result = solution.AsteroidCollision(asteroids);

            // Assert
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void AsteroidCollision_ComplexScenario_MixedResults(IAsteroidCollision_735 solution)
        {
            // Arrange
            int[] asteroids = { -2, -1, 1, 2, -3 };
            int[] expected = { -2, -1, -3 };

            // Act
            int[] result = solution.AsteroidCollision(asteroids);

            // Assert
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void AsteroidCollision_LargeAsteroidDestroysMany(IAsteroidCollision_735 solution)
        {
            // Arrange
            int[] asteroids = { 1, 2, 3, 4, 5, -20 };
            int[] expected = { -20 };

            // Act
            int[] result = solution.AsteroidCollision(asteroids);

            // Assert
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void AsteroidCollision_EqualSizeBothExplode(IAsteroidCollision_735 solution)
        {
            // Arrange
            int[] asteroids = { 5, -5 };
            int[] expected = { };

            // Act
            int[] result = solution.AsteroidCollision(asteroids);

            // Assert
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void AsteroidCollision_MultipleEqualCollisions(IAsteroidCollision_735 solution)
        {
            // Arrange
            int[] asteroids = { 10, -10, 5, -5 };
            int[] expected = { };

            // Act
            int[] result = solution.AsteroidCollision(asteroids);

            // Assert
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void AsteroidCollision_ChainReactionComplete(IAsteroidCollision_735 solution)
        {
            // Arrange
            int[] asteroids = { 3, 5, -4, -10 };
            int[] expected = { -10 };

            // Act
            int[] result = solution.AsteroidCollision(asteroids);

            // Assert
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void AsteroidCollision_SomeRightSomeLeftSurvive(IAsteroidCollision_735 solution)
        {
            // Arrange
            int[] asteroids = { -2, 2, 1, -2 };
            int[] expected = { -2 };

            // Act
            int[] result = solution.AsteroidCollision(asteroids);

            // Assert
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void AsteroidCollision_OnlySurvivorsNoCollision(IAsteroidCollision_735 solution)
        {
            // Arrange
            int[] asteroids = { -10, -5, 1, 2, 3 };
            int[] expected = { -10, -5, 1, 2, 3 };

            // Act
            int[] result = solution.AsteroidCollision(asteroids);

            // Assert
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void AsteroidCollision_TwoAsteroidsRightWins(IAsteroidCollision_735 solution)
        {
            // Arrange
            int[] asteroids = { 10, -5 };
            int[] expected = { 10 };

            // Act
            int[] result = solution.AsteroidCollision(asteroids);

            // Assert
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void AsteroidCollision_TwoAsteroidsLeftWins(IAsteroidCollision_735 solution)
        {
            // Arrange
            int[] asteroids = { 5, -10 };
            int[] expected = { -10 };

            // Act
            int[] result = solution.AsteroidCollision(asteroids);

            // Assert
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void AsteroidCollision_AlternatingPattern(IAsteroidCollision_735 solution)
        {
            // Arrange
            int[] asteroids = { 10, -5, 5, -10 };
            int[] expected = {  };

            // Act
            int[] result = solution.AsteroidCollision(asteroids);

            // Assert
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void AsteroidCollision_LargerExample_MixedResults(IAsteroidCollision_735 solution)
        {
            // Arrange
            int[] asteroids = { -2, -2, 1, -2 };
            int[] expected = { -2, -2, -2 };

            // Act
            int[] result = solution.AsteroidCollision(asteroids);

            // Assert
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void AsteroidCollision_AllExplodeInChain(IAsteroidCollision_735 solution)
        {
            // Arrange
            int[] asteroids = { 1, -1, 2, -2 };
            int[] expected = { };

            // Act
            int[] result = solution.AsteroidCollision(asteroids);

            // Assert
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void AsteroidCollision_MultipleLeftDestroyMultipleRight(IAsteroidCollision_735 solution)
        {
            // Arrange
            int[] asteroids = { 2, 1, -3, 4 };
            int[] expected = { -3, 4 };

            // Act
            int[] result = solution.AsteroidCollision(asteroids);

            // Assert
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void AsteroidCollision_LargeAsteroidSizes_WorksCorrectly(IAsteroidCollision_735 solution)
        {
            // Arrange
            int[] asteroids = { 1000, -999 };
            int[] expected = { 1000 };

            // Act
            int[] result = solution.AsteroidCollision(asteroids);

            // Assert
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void AsteroidCollision_ConsecutiveEqualCollisions(IAsteroidCollision_735 solution)
        {
            // Arrange
            int[] asteroids = { 3, -3, 5, -5, 7, -7 };
            int[] expected = { };

            // Act
            int[] result = solution.AsteroidCollision(asteroids);

            // Assert
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void AsteroidCollision_PartialDestruction(IAsteroidCollision_735 solution)
        {
            // Arrange
            int[] asteroids = { 5, 10, -15, 3, -8, 9 };
            int[] expected = { -15, -8, 9 };

            // Act
            int[] result = solution.AsteroidCollision(asteroids);

            // Assert
            CollectionAssert.AreEqual(expected, result);
        }
    }
}