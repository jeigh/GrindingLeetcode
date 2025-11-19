using LeetCodeProblems.HashingOrArrays;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GrindingLeetCode.UnitTests.Easy
{
    [TestClass]
    public class MyHashMapSolution_706_Tests
    {
        private MyHashMapSolution_706.MyHashMap _map;

        [TestInitialize]
        public void Initialize()
        {
            _map = new MyHashMapSolution_706.MyHashMap();
        }

        [TestMethod]
        public void Put_And_Get_BasicUsage()
        {
            _map.Put(1, 1);
            _map.Put(2, 2);
            Assert.AreEqual(1, _map.Get(1));
            Assert.AreEqual(2, _map.Get(2));
            Assert.AreEqual(-1, _map.Get(3));
        }

        [TestMethod]
        public void Put_OverwriteValue()
        {
            _map.Put(1, 1);
            Assert.AreEqual(1, _map.Get(1));
            _map.Put(1, 10);
            Assert.AreEqual(10, _map.Get(1));
        }

        [TestMethod]
        public void Remove_RemovesKey()
        {
            _map.Put(1, 1);
            _map.Put(2, 2);
            _map.Remove(1);
            Assert.AreEqual(-1, _map.Get(1));
            Assert.AreEqual(2, _map.Get(2));
        }

        [TestMethod]
        public void Remove_NonExistentKey_DoesNothing()
        {
            _map.Put(1, 1);
            _map.Remove(2); // Should not throw
            Assert.AreEqual(1, _map.Get(1));
        }

        [TestMethod]
        public void Put_MultipleKeysWithSameHash()
        {
            // 1 and 1001 will collide in the default hash function (mod 1000)
            _map.Put(1, 1);
            _map.Put(1001, 1001);
            Assert.AreEqual(1, _map.Get(1));
            Assert.AreEqual(1001, _map.Get(1001));
            _map.Remove(1);
            Assert.AreEqual(-1, _map.Get(1));
            Assert.AreEqual(1001, _map.Get(1001));
        }

        [TestMethod]
        public void Get_EmptyMap_ReturnsMinusOne()
        {
            Assert.AreEqual(-1, _map.Get(42));
        }

        [TestMethod]
        public void Remove_EmptyMap_DoesNotThrow()
        {
            _map.Remove(42);
            Assert.AreEqual(-1, _map.Get(42));
        }
    }
}