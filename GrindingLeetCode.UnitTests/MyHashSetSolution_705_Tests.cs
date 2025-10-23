using LeetCodeProblems.HashingOrArrays;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GrindingLeetCode.UnitTests
{
    [TestClass]
    public class MyHashSetSolution_705_Tests
    {
        private MyHashSetSolution_705.MyHashSet _set;

        [TestInitialize]
        public void Initialize()
        {
            _set = new MyHashSetSolution_705.MyHashSet();
        }

        [TestMethod]
        public void Add_Contains_ReturnsTrue()
        {
            _set.Add(1);
            Assert.IsTrue(_set.Contains(1));
        }

        [TestMethod]
        public void Add_Duplicate_DoesNotAffectSet()
        {
            _set.Add(2);
            _set.Add(2);
            Assert.IsTrue(_set.Contains(2));
        }

        [TestMethod]
        public void Remove_Element_RemovesSuccessfully()
        {
            _set.Add(3);
            Assert.IsTrue(_set.Contains(3));
            _set.Remove(3);
            Assert.IsFalse(_set.Contains(3));
        }

        [TestMethod]
        public void Contains_NonExistent_ReturnsFalse()
        {
            Assert.IsFalse(_set.Contains(99));
        }

        [TestMethod]
        public void Add_MultipleElements_ContainsAll()
        {
            _set.Add(10);
            _set.Add(20);
            _set.Add(30);
            Assert.IsTrue(_set.Contains(10));
            Assert.IsTrue(_set.Contains(20));
            Assert.IsTrue(_set.Contains(30));
        }

        [TestMethod]
        public void Remove_NonExistent_DoesNotThrow()
        {
            _set.Remove(100);
            Assert.IsFalse(_set.Contains(100));
        }

        [TestMethod]
        public void Add_Remove_AddAgain_WorksCorrectly()
        {
            _set.Add(5);
            _set.Remove(5);
            Assert.IsFalse(_set.Contains(5));
            _set.Add(5);
            Assert.IsTrue(_set.Contains(5));
        }
    }
}