using LeetCodeProblems.BinarySearch;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static LeetCodeProblems.BinarySearch.TimebasedKeyValueStoreSolution_981;

namespace GrindingLeetCode.UnitTests.BinarySearch
{
    [TestClass]
    public class TimebasedKeyValueStoreSolution_981_Tests
    {
        private TimeMap _timeMap;

        [TestInitialize]
        public void Initialize()
        {
            _timeMap = new TimeMap();
        }

        [TestMethod]
        public void Basic_Example_From_leetcode()
        {
            TimeMap timeMap = new TimeMap();
            timeMap.Set("foo", "bar", 1);  // store the key "foo" and value "bar" along with timestamp = 1.
            var one = timeMap.Get("foo", 1);         // return "bar"
            var three = timeMap.Get("foo", 3);         // return "bar", since there is no value corresponding to foo at timestamp 3 and timestamp 2, then the only value is at timestamp 1 is "bar".
            timeMap.Set("foo", "bar2", 4); // store the key "foo" and value "bar2" along with timestamp = 4.
            var four = timeMap.Get("foo", 4);         // return "bar2"
            var five = timeMap.Get("foo", 5);         // return "bar2"

            Assert.AreEqual(one, "bar");
            Assert.AreEqual(three, "bar");
            Assert.AreEqual(four, "bar2");
            Assert.AreEqual(five, "bar2");

        }

        [TestMethod]
        public void Set_Get_BasicOperation_ReturnsCorrectValue()
        {
            // Arrange & Act
            _timeMap.Set("foo", "bar", 1);

            // Assert
            Assert.AreEqual("bar", _timeMap.Get("foo", 1));
        }

        [TestMethod]
        public void Get_NonExistentKey_ReturnsEmptyString()
        {
            // Act & Assert
            Assert.AreEqual("", _timeMap.Get("nonexistent", 1));
        }

        [TestMethod]
        public void Get_TimestampTooEarly_ReturnsEmptyString()
        {
            // Arrange
            _timeMap.Set("foo", "bar", 5);

            // Act & Assert
            Assert.AreEqual("", _timeMap.Get("foo", 1));
        }

        [TestMethod]
        public void Get_LaterTimestamp_ReturnsLatestValue()
        {
            // Arrange
            _timeMap.Set("foo", "bar", 1);

            // Act & Assert
            Assert.AreEqual("bar", _timeMap.Get("foo", 5));
        }

        [TestMethod]
        public void Get_MultipleSetsIncreasingOrder_ReturnsCorrectValues()
        {
            // Arrange
            _timeMap.Set("foo", "one", 1);
            _timeMap.Set("foo", "two", 2);
            _timeMap.Set("foo", "three", 3);

            // Act & Assert
            Assert.AreEqual("one", _timeMap.Get("foo", 1));
            Assert.AreEqual("two", _timeMap.Get("foo", 2));
            Assert.AreEqual("three", _timeMap.Get("foo", 3));
            
        }

        [TestMethod]
        public void Get_MultipleSetsReverseOrder_ReturnsCorrectValues()
        {
            // Arrange - Set values in non-sequential order
            _timeMap.Set("foo", "one", 1);
            _timeMap.Set("foo", "two", 2);

            _timeMap.Set("foo", "three", 3);

            // Act & Assert
            Assert.AreEqual("one", _timeMap.Get("foo", 1));
            Assert.AreEqual("two", _timeMap.Get("foo", 2));
            Assert.AreEqual("three", _timeMap.Get("foo", 3));
        }

        [TestMethod]
        public void Get_IntermediateTimestamp_ReturnsPreviousValue()
        {
            // Arrange
            _timeMap.Set("foo", "one", 1);
            _timeMap.Set("foo", "three", 3);

            // act
            var one = _timeMap.Get("foo", 2);

            // Act & Assert
            Assert.AreEqual("one", one);
        }

        [TestMethod]
        public void Set_Get_MultipleKeys_ReturnsCorrectValues()
        {
            // Arrange
            _timeMap.Set("foo", "bar", 1);
            _timeMap.Set("baz", "qux", 2);

            // Act & Assert
            Assert.AreEqual("bar", _timeMap.Get("foo", 1));
            Assert.AreEqual("qux", _timeMap.Get("baz", 2));
        }


        [TestMethod]
        public void LeetCodeExample1_ReturnsExpectedResults()
        {
            // Arrange
            _timeMap.Set("foo", "bar", 1);

            // Act & Assert
            Assert.AreEqual("bar", _timeMap.Get("foo", 1));
            Assert.AreEqual("bar", _timeMap.Get("foo", 3));

            _timeMap.Set("foo", "bar2", 4);

            Assert.AreEqual("bar2", _timeMap.Get("foo", 4));
            Assert.AreEqual("bar2", _timeMap.Get("foo", 5));
            Assert.AreEqual("bar", _timeMap.Get("foo", 1));
        }
    }
}