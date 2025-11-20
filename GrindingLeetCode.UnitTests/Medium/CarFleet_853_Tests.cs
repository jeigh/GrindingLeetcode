using LeetCodeProblems.CSharp.Stack;
using LeetCodeProblems.Interfaces.Medium;
using LeetCodeProblems.VisualBasic;


namespace GrindingLeetCode.UnitTests.Medium
{
    [TestClass]
    public class CarFleet_853_Tests
    {
        public static IEnumerable<object[]> GetImplementations()
        {
            yield return new object[] { new CarFleetCSharp_853() };
            yield return new object[] { new CarFleetVB_853() };
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CarFleet_Example1_ReturnsThree(ICarFleet_853 solution)
        {
            // Arrange
            int target = 12;
            int[] position = { 10, 8, 0, 5, 3 };
            int[] speed = { 2, 4, 1, 1, 3 };

            // Act
            int result = solution.CarFleet(target, position, speed);

            // Assert
            Assert.AreEqual(3, result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CarFleet_Example2_ReturnsOne(ICarFleet_853 solution)
        {
            // Arrange
            int target = 10;
            int[] position = { 3 };
            int[] speed = { 3 };

            // Act
            int result = solution.CarFleet(target, position, speed);

            // Assert
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CarFleet_Example3_ReturnsOne(ICarFleet_853 solution)
        {
            // Arrange
            int target = 100;
            int[] position = { 0, 2, 4 };
            int[] speed = { 4, 2, 1 };

            // Act
            int result = solution.CarFleet(target, position, speed);

            // Assert
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CarFleet_SingleCar_ReturnsOne(ICarFleet_853 solution)
        {
            // Arrange
            int target = 10;
            int[] position = { 5 };
            int[] speed = { 1 };

            // Act
            int result = solution.CarFleet(target, position, speed);

            // Assert
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CarFleet_TwoCarsFormFleet_ReturnsOne(ICarFleet_853 solution)
        {
            // Arrange
            int target = 10;
            int[] position = { 0, 5 };
            int[] speed = { 2, 1 };

            // Act
            int result = solution.CarFleet(target, position, speed);

            // Assert
            Assert.AreEqual(1, result); // Car at 0 catches up to car at 5
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CarFleet_TwoCarsNeverMeet_ReturnsTwo(ICarFleet_853 solution)
        {
            // Arrange
            int target = 10;
            int[] position = { 0, 5 };
            int[] speed = { 1, 2 };

            // Act
            int result = solution.CarFleet(target, position, speed);

            // Assert
            Assert.AreEqual(2, result); // Front car is faster, they never meet
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CarFleet_AllCarsSameSpeed_SamePosition_ReturnsNumberOfCars(ICarFleet_853 solution)
        {
            // Arrange
            int target = 20;
            int[] position = { 0, 5, 10, 15 };
            int[] speed = { 2, 2, 2, 2 };

            // Act
            int result = solution.CarFleet(target, position, speed);

            // Assert
            Assert.AreEqual(4, result); // All cars maintain their positions
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CarFleet_AllCarsFormOneFleet_ReturnsOne(ICarFleet_853 solution)
        {
            // Arrange
            int target = 10;
            int[] position = { 0, 1, 2 };
            int[] speed = { 3, 2, 1 };

            // Act
            int result = solution.CarFleet(target, position, speed);

            // Assert
            Assert.AreEqual(1, result); // All cars catch up to slowest
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CarFleet_NoFleetFormation_ReturnsNumberOfCars(ICarFleet_853 solution)
        {
            // Arrange
            int target = 10;
            int[] position = { 0, 1, 2 };
            int[] speed = { 1, 2, 3 };

            // Act
            int result = solution.CarFleet(target, position, speed);

            // Assert
            Assert.AreEqual(3, result); // Each car travels independently
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CarFleet_CarAlreadyAtTarget_ReturnsCorrectFleets(ICarFleet_853 solution)
        {
            // Arrange
            int target = 10;
            int[] position = { 10, 5 };
            int[] speed = { 0, 1 };

            // Act
            int result = solution.CarFleet(target, position, speed);

            // Assert
            Assert.AreEqual(1, result); // Car at target and car approaching form one fleet
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CarFleet_VerySlowFrontCar_AllCatchUp(ICarFleet_853 solution)
        {
            // Arrange
            int target = 100;
            int[] position = { 90, 80, 70, 60 };
            int[] speed = { 1, 5, 10, 15 };

            // Act
            int result = solution.CarFleet(target, position, speed);

            // Assert
            Assert.AreEqual(1, result); // All cars catch up to the slowest front car
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CarFleet_VeryFastFrontCar_NoFleetFormation(ICarFleet_853 solution)
        {
            // Arrange
            int target = 100;
            int[] position = { 90, 80, 70, 60 };
            int[] speed = { 100, 1, 1, 1 };

            // Act
            int result = solution.CarFleet(target, position, speed);

            // Assert
            Assert.AreEqual(4, result); 
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CarFleet_AlternatingFastSlow_ReturnsCorrectFleets(ICarFleet_853 solution)
        {
            // Arrange
            int target = 20;
            int[] position = { 0, 5, 10, 15 };
            int[] speed = { 10, 1, 10, 1 };

            // Act
            int result = solution.CarFleet(target, position, speed);

            // Assert
            Assert.AreEqual(2, result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CarFleet_CarsVeryCloseToTarget_ReturnsCorrectFleets(ICarFleet_853 solution)
        {
            // Arrange
            int target = 10;
            int[] position = { 9, 8, 7 };
            int[] speed = { 10, 10, 10 };

            // Act
            int result = solution.CarFleet(target, position, speed);

            // Assert
            Assert.AreEqual(3, result); // All arrive at same time but as separate fleets
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CarFleet_LargeTarget_ReturnsCorrectFleets(ICarFleet_853 solution)
        {
            // Arrange
            int target = 1000;
            int[] position = { 0, 100, 200 };
            int[] speed = { 1, 2, 3 };

            // Act
            int result = solution.CarFleet(target, position, speed);

            // Assert
            Assert.AreEqual(3, result); // Each maintains independent arrival
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CarFleet_ProgressiveSpeeds_ReturnsCorrectFleets(ICarFleet_853 solution)
        {
            // Arrange
            int target = 12;
            int[] position = { 0, 3, 6, 9 };
            int[] speed = { 4, 3, 2, 1 };

            // Act
            int result = solution.CarFleet(target, position, speed);

            // Assert
            Assert.AreEqual(1, result); // All catch up to slowest car at position 9
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CarFleet_ClosePositionsDifferentSpeeds_ReturnsCorrectFleets(ICarFleet_853 solution)
        {
            // Arrange
            int target = 10;
            int[] position = { 6, 8 };
            int[] speed = { 3, 2 };

            // Act
            int result = solution.CarFleet(target, position, speed);

            // Assert
            Assert.AreEqual(2, result); // Car at 6 doesn't catch car at 8
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CarFleet_ReverseSortedPositions_ReturnsCorrectFleets(ICarFleet_853 solution)
        {
            // Arrange
            int target = 20;
            int[] position = { 15, 10, 5, 0 };
            int[] speed = { 1, 2, 3, 4 };

            // Act
            int result = solution.CarFleet(target, position, speed);

            // Assert
            Assert.AreEqual(1, result); 
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CarFleet_UnsortedPositions_ReturnsCorrectFleets(ICarFleet_853 solution)
        {
            // Arrange
            int target = 10;
            int[] position = { 8, 3, 7, 4, 6, 5 };
            int[] speed = { 4, 4, 4, 4, 4, 4 };

            // Act
            int result = solution.CarFleet(target, position, speed);

            // Assert
            Assert.AreEqual(6, result); // All same speed, all independent
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CarFleet_TwoFleetsForming_ReturnsTwo(ICarFleet_853 solution)
        {
            // Arrange
            int target = 10;
            int[] position = { 0, 2, 7, 8 };
            int[] speed = { 2, 1, 10, 1 };

            // Act
            int result = solution.CarFleet(target, position, speed);

            // Assert
            Assert.AreEqual(2, result); // Two separate fleets form
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CarFleet_SequentialCatchup_ReturnsCorrectFleets(ICarFleet_853 solution)
        {
            // Arrange
            int target = 100;
            int[] position = { 0, 20, 40, 60, 80 };
            int[] speed = { 25, 20, 15, 10, 5 };

            // Act
            int result = solution.CarFleet(target, position, speed);

            // Assert
            Assert.AreEqual(1, result); // All eventually catch up to the slowest
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CarFleet_MinimumSpeed_ReturnsCorrectFleets(ICarFleet_853 solution)
        {
            // Arrange
            int target = 10;
            int[] position = { 0, 5 };
            int[] speed = { 1, 1 };

            // Act
            int result = solution.CarFleet(target, position, speed);

            // Assert
            Assert.AreEqual(2, result); // Same speed, different positions
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CarFleet_MaximumSpeed_ReturnsCorrectFleets(ICarFleet_853 solution)
        {
            // Arrange
            int target = 1000000;
            int[] position = { 0, 500000 };
            int[] speed = { 1000000, 1000000 };

            // Act
            int result = solution.CarFleet(target, position, speed);

            // Assert
            Assert.AreEqual(2, result); // Both arrive at same time independently
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CarFleet_ComplexScenario_MultipleFleets(ICarFleet_853 solution)
        {
            // Arrange
            int target = 50;
            int[] position = { 0, 10, 20, 30, 40 };
            int[] speed = { 5, 4, 3, 2, 1 };

            // Act
            int result = solution.CarFleet(target, position, speed);

            // Assert
            Assert.AreEqual(1, result); // All cars catch up progressively
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CarFleet_RealWorldScenario_Highway(ICarFleet_853 solution)
        {
            // Arrange - Simulating highway scenario
            int target = 100;
            int[] position = { 10, 20, 30, 40, 50, 60, 70, 80, 90 };
            int[] speed = { 8, 7, 6, 5, 4, 3, 2, 1, 1 };

            // Act
            int result = solution.CarFleet(target, position, speed);

            // Assert
            Assert.AreEqual(2, result); 
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CarFleet_CarsJustMeetAtTarget_ReturnsCorrectFleets(ICarFleet_853 solution)
        {
            // Arrange
            int target = 10;
            int[] position = { 0, 5 };
            int[] speed = { 5, 2 }; // Both arrive at time 2

            // Act
            int result = solution.CarFleet(target, position, speed);

            // Assert
            Assert.AreEqual(1, result); // They meet exactly at target
        }
    }
}