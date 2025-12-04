using LeetCodeProblems.CSharp.Stack;
using LeetCodeProblems.Interfaces.Medium;

namespace GrindingLeetCode.UnitTests.Medium
{
    [TestClass]
    public class StockSpanner_901_Tests
    {
        private IStockSpanner_901 _stockSpanner;

        [TestInitialize]
        public void Initialize()
        {
            _stockSpanner = new StockSpannerCSharp_901();
        }

        [TestMethod]
        public void Next_Example1_ReturnsExpectedSpans()
        {
            // Act & Assert
            Assert.AreEqual(1, _stockSpanner.Next(100)); // First day, span is always 1
            Assert.AreEqual(1, _stockSpanner.Next(80));  // 80 < 100, so span is 1
            Assert.AreEqual(1, _stockSpanner.Next(60));  // 60 < 80, so span is 1
            Assert.AreEqual(2, _stockSpanner.Next(70));  // 70 > 60, includes 60 and 70, span is 2
            Assert.AreEqual(1, _stockSpanner.Next(60));  // 60 < 70, so span is 1
            Assert.AreEqual(4, _stockSpanner.Next(75));  // 75 > 60, 70, 60, includes these + itself, span is 4
            Assert.AreEqual(6, _stockSpanner.Next(85));  // 85 > all previous, span is 6
        }

        [TestMethod]
        public void Next_SinglePrice_ReturnsOne()
        {
            // Act
            int result = _stockSpanner.Next(50);

            // Assert
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void Next_AllIncreasing_ReturnsIncrementalSpans()
        {
            // Act & Assert
            Assert.AreEqual(1, _stockSpanner.Next(10));
            Assert.AreEqual(2, _stockSpanner.Next(20));
            Assert.AreEqual(3, _stockSpanner.Next(30));
            Assert.AreEqual(4, _stockSpanner.Next(40));
            Assert.AreEqual(5, _stockSpanner.Next(50));
        }

        [TestMethod]
        public void Next_AllDecreasing_ReturnsAllOnes()
        {
            // Act & Assert
            Assert.AreEqual(1, _stockSpanner.Next(100));
            Assert.AreEqual(1, _stockSpanner.Next(90));
            Assert.AreEqual(1, _stockSpanner.Next(80));
            Assert.AreEqual(1, _stockSpanner.Next(70));
            Assert.AreEqual(1, _stockSpanner.Next(60));
        }

        [TestMethod]
        public void Next_AllEqualPrices_ReturnsIncrementalSpans()
        {
            // Act & Assert
            Assert.AreEqual(1, _stockSpanner.Next(50));
            Assert.AreEqual(2, _stockSpanner.Next(50));
            Assert.AreEqual(3, _stockSpanner.Next(50));
            Assert.AreEqual(4, _stockSpanner.Next(50));
        }

        [TestMethod]
        public void Next_AlternatingHighLow_ReturnsCorrectSpans()
        {
            // Act & Assert
            Assert.AreEqual(1, _stockSpanner.Next(100));
            Assert.AreEqual(1, _stockSpanner.Next(50));
            Assert.AreEqual(2, _stockSpanner.Next(90));
            Assert.AreEqual(1, _stockSpanner.Next(40));
            Assert.AreEqual(2, _stockSpanner.Next(80));
        }

        [TestMethod]
        public void Next_TwoPricesSecondLower_ReturnsCorrectSpans()
        {
            // Act & Assert
            Assert.AreEqual(1, _stockSpanner.Next(100));
            Assert.AreEqual(1, _stockSpanner.Next(80));
        }

        [TestMethod]
        public void Next_TwoPricesSecondHigher_ReturnsCorrectSpans()
        {
            // Act & Assert
            Assert.AreEqual(1, _stockSpanner.Next(50));
            Assert.AreEqual(2, _stockSpanner.Next(75));
        }

        [TestMethod]
        public void Next_TwoPricesEqual_ReturnsCorrectSpans()
        {
            // Act & Assert
            Assert.AreEqual(1, _stockSpanner.Next(60));
            Assert.AreEqual(2, _stockSpanner.Next(60));
        }

        [TestMethod]
        public void Next_LongDecreasingThenHigh_ReturnsLargeSpan()
        {
            // Act & Assert
            Assert.AreEqual(1, _stockSpanner.Next(90));
            Assert.AreEqual(1, _stockSpanner.Next(80));
            Assert.AreEqual(1, _stockSpanner.Next(70));
            Assert.AreEqual(1, _stockSpanner.Next(60));
            Assert.AreEqual(1, _stockSpanner.Next(50));
            Assert.AreEqual(6, _stockSpanner.Next(95)); // All previous prices <= 95
        }

        [TestMethod]
        public void Next_VPattern_ReturnsCorrectSpans()
        {
            // Act & Assert - prices go down then up
            Assert.AreEqual(1, _stockSpanner.Next(80));
            Assert.AreEqual(1, _stockSpanner.Next(60));
            Assert.AreEqual(1, _stockSpanner.Next(40));
            Assert.AreEqual(2, _stockSpanner.Next(50)); // 50 > 40
            Assert.AreEqual(4, _stockSpanner.Next(70)); // 70 > 50, 40
            Assert.AreEqual(6, _stockSpanner.Next(90)); // 90 > all previous
        }

        [TestMethod]
        public void Next_MountainPattern_ReturnsCorrectSpans()
        {
            // Act & Assert - prices go up then down
            Assert.AreEqual(1, _stockSpanner.Next(40));
            Assert.AreEqual(2, _stockSpanner.Next(60));
            Assert.AreEqual(3, _stockSpanner.Next(80));
            Assert.AreEqual(4, _stockSpanner.Next(100)); // Peak
            Assert.AreEqual(1, _stockSpanner.Next(90));  // Going down
            Assert.AreEqual(1, _stockSpanner.Next(70));
        }

        [TestMethod]
        public void Next_MultipleEqualSequences_ReturnsCorrectSpans()
        {
            // Act & Assert
            Assert.AreEqual(1, _stockSpanner.Next(70));
            Assert.AreEqual(2, _stockSpanner.Next(70));
            Assert.AreEqual(3, _stockSpanner.Next(70));
            Assert.AreEqual(1, _stockSpanner.Next(60));
            Assert.AreEqual(5, _stockSpanner.Next(70)); // Includes all previous 70s and the 60
        }

        [TestMethod]
        public void Next_SmallIncrements_ReturnsIncrementalSpans()
        {
            // Act & Assert
            Assert.AreEqual(1, _stockSpanner.Next(50));
            Assert.AreEqual(2, _stockSpanner.Next(51));
            Assert.AreEqual(3, _stockSpanner.Next(52));
            Assert.AreEqual(4, _stockSpanner.Next(53));
        }

        [TestMethod]
        public void Next_LargeJumps_ReturnsCorrectSpans()
        {
            // Act & Assert
            Assert.AreEqual(1, _stockSpanner.Next(10));
            Assert.AreEqual(2, _stockSpanner.Next(50));
            Assert.AreEqual(3, _stockSpanner.Next(100));
            Assert.AreEqual(1, _stockSpanner.Next(20));
            Assert.AreEqual(5, _stockSpanner.Next(150));
        }

        [TestMethod]
        public void Next_PlateauPattern_ReturnsCorrectSpans()
        {
            // Act & Assert
            Assert.AreEqual(1, _stockSpanner.Next(50));
            Assert.AreEqual(2, _stockSpanner.Next(70));
            Assert.AreEqual(3, _stockSpanner.Next(70));
            Assert.AreEqual(4, _stockSpanner.Next(70));
            Assert.AreEqual(5, _stockSpanner.Next(90));
        }

        [TestMethod]
        public void Next_AlternatingSingleHighLow_ReturnsOnesAndTwos()
        {
            // Act & Assert
            Assert.AreEqual(1, _stockSpanner.Next(100));
            Assert.AreEqual(1, _stockSpanner.Next(80));
            Assert.AreEqual(2, _stockSpanner.Next(90));
            Assert.AreEqual(1, _stockSpanner.Next(70));
            Assert.AreEqual(2, _stockSpanner.Next(85));
        }

        [TestMethod]
        public void Next_GradualIncreaseWithDips_ReturnsCorrectSpans()
        {
            // Act & Assert
            Assert.AreEqual(1, _stockSpanner.Next(50));
            Assert.AreEqual(2, _stockSpanner.Next(60));
            Assert.AreEqual(1, _stockSpanner.Next(55));
            Assert.AreEqual(4, _stockSpanner.Next(65)); // 65 > 55, 60 (no), but > 55
            Assert.AreEqual(1, _stockSpanner.Next(63));
            Assert.AreEqual(6, _stockSpanner.Next(70)); // 70 > all previous
        }

        [TestMethod]
        public void Next_ConsecutiveHighPrices_ReturnsCorrectSpans()
        {
            // Act & Assert
            Assert.AreEqual(1, _stockSpanner.Next(10));
            Assert.AreEqual(1, _stockSpanner.Next(5));
            Assert.AreEqual(1, _stockSpanner.Next(3));
            Assert.AreEqual(4, _stockSpanner.Next(20)); // Higher than all previous
            Assert.AreEqual(5, _stockSpanner.Next(25)); // Higher than all previous
        }

        [TestMethod]
        public void Next_MinimumPrice_ReturnsOne()
        {
            // Act
            int result = _stockSpanner.Next(1);

            // Assert
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void Next_MaximumPrice_ReturnsCorrectSpan()
        {
            // Act & Assert - Using reasonable stock prices
            Assert.AreEqual(1, _stockSpanner.Next(1000));
            Assert.AreEqual(2, _stockSpanner.Next(5000));
            Assert.AreEqual(3, _stockSpanner.Next(10000));
        }

        [TestMethod]
        public void Next_RepeatingPattern_ReturnsCorrectSpans()
        {
            // Act & Assert
            Assert.AreEqual(1, _stockSpanner.Next(80));
            Assert.AreEqual(1, _stockSpanner.Next(60));
            Assert.AreEqual(2, _stockSpanner.Next(70));
            Assert.AreEqual(1, _stockSpanner.Next(60));
            Assert.AreEqual(4, _stockSpanner.Next(75));
        }

        [TestMethod]
        public void Next_LongSequence_HandlesCorrectly()
        {
            // Act & Assert
            Assert.AreEqual(1, _stockSpanner.Next(31));
            Assert.AreEqual(2, _stockSpanner.Next(41));
            Assert.AreEqual(3, _stockSpanner.Next(48));
            Assert.AreEqual(4, _stockSpanner.Next(59));
            Assert.AreEqual(5, _stockSpanner.Next(79));
            Assert.AreEqual(1, _stockSpanner.Next(75));
            Assert.AreEqual(1, _stockSpanner.Next(71));
            Assert.AreEqual(3, _stockSpanner.Next(76));
            Assert.AreEqual(9, _stockSpanner.Next(80));
        }

        [TestMethod]
        public void Next_SlightlyLowerAfterHigh_ReturnsOne()
        {
            // Act & Assert
            Assert.AreEqual(1, _stockSpanner.Next(100));
            Assert.AreEqual(1, _stockSpanner.Next(99));
        }

        [TestMethod]
        public void Next_MultipleInstancesIndependent_WorkCorrectly()
        {
            // Arrange - Create second independent instance
            IStockSpanner_901 stockSpanner2 = new StockSpannerCSharp_901();

            // Act & Assert - Each instance should be independent
            Assert.AreEqual(1, _stockSpanner.Next(100));
            Assert.AreEqual(1, stockSpanner2.Next(50));
            
            Assert.AreEqual(2, _stockSpanner.Next(110));
            Assert.AreEqual(2, stockSpanner2.Next(60));
            
            Assert.AreEqual(1, _stockSpanner.Next(90));
            Assert.AreEqual(3, stockSpanner2.Next(70));
        }

        [TestMethod]
        public void Next_ZigZagPattern_ReturnsCorrectSpans()
        {
            // Act & Assert
            Assert.AreEqual(1, _stockSpanner.Next(50));
            Assert.AreEqual(2, _stockSpanner.Next(70));
            Assert.AreEqual(1, _stockSpanner.Next(60));
            Assert.AreEqual(4, _stockSpanner.Next(80));
            Assert.AreEqual(1, _stockSpanner.Next(75));
            Assert.AreEqual(6, _stockSpanner.Next(85));
        }

        [TestMethod]
        public void Next_StaircasePattern_ReturnsCorrectSpans()
        {
            // Act & Assert
            Assert.AreEqual(1, _stockSpanner.Next(10));
            Assert.AreEqual(2, _stockSpanner.Next(10));
            Assert.AreEqual(3, _stockSpanner.Next(20));
            Assert.AreEqual(4, _stockSpanner.Next(20));
            Assert.AreEqual(5, _stockSpanner.Next(30));
        }

        [TestMethod]
        public void Next_ComplexRealWorldScenario_ReturnsCorrectSpans()
        {
            // Act & Assert - Simulating realistic stock price movements
            Assert.AreEqual(1, _stockSpanner.Next(100)); // Day 1
            Assert.AreEqual(1, _stockSpanner.Next(95));  // Day 2: slight dip
            Assert.AreEqual(2, _stockSpanner.Next(98));  // Day 3: recovery
            Assert.AreEqual(1, _stockSpanner.Next(97));  // Day 4: slight dip
            Assert.AreEqual(4, _stockSpanner.Next(99));  // Day 5: near high
            Assert.AreEqual(6, _stockSpanner.Next(105)); // Day 6: new high!
            Assert.AreEqual(1, _stockSpanner.Next(103)); // Day 7: profit taking
            Assert.AreEqual(1, _stockSpanner.Next(101)); // Day 8: continued decline
            Assert.AreEqual(3, _stockSpanner.Next(104)); // Day 9: bounce back
            Assert.AreEqual(10, _stockSpanner.Next(110));// Day 10: breakout!
        }
    }
}