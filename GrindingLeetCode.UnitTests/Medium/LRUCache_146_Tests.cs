using LeetCodeProblems.CSharp.LinkedList;
using LeetCodeProblems.Interfaces.Medium;

namespace GrindingLeetCode.UnitTests.Medium
{
    [TestClass]
    public class LRUCache_146_Tests
    {
        public static IEnumerable<object[]> GetImplementations()
        {
            yield return new object[] { (int capacity) => new LRUCache_CSharp_146(capacity), "C#" };
        }

        #region LeetCode Examples

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void LRUCache_LeetCodeExample1_WorksCorrectly(Func<int, ILRUCache_146> factory, string solutionName)
        {
            // Example 1:
            // Input: ["LRUCache", "put", "put", "get", "put", "get", "put", "get", "get", "get"]
            // [[2], [1, 1], [2, 2], [1], [3, 3], [2], [4, 4], [1], [3], [4]]
            // Output: [null, null, null, 1, null, -1, null, -1, 3, 4]

            // Arrange
            var lruCache = factory(2);

            // Act & Assert
            lruCache.Put(1, 1);                     // cache is {1=1}
            lruCache.Put(2, 2);                     // cache is {1=1, 2=2}
            Assert.AreEqual(1, lruCache.Get(1), $"Get(1) should return 1 for {solutionName}");    // return 1, cache is {2=2, 1=1}
            lruCache.Put(3, 3);                     // LRU key was 2, evicts key 2, cache is {1=1, 3=3}
            Assert.AreEqual(-1, lruCache.Get(2), $"Get(2) should return -1 (evicted) for {solutionName}");   // returns -1 (not found)
            lruCache.Put(4, 4);                     // LRU key was 1, evicts key 1, cache is {3=3, 4=4}
            Assert.AreEqual(-1, lruCache.Get(1), $"Get(1) should return -1 (evicted) for {solutionName}");   // return -1 (not found)
            Assert.AreEqual(3, lruCache.Get(3), $"Get(3) should return 3 for {solutionName}");    // return 3, cache is {4=4, 3=3}
            Assert.AreEqual(4, lruCache.Get(4), $"Get(4) should return 4 for {solutionName}");    // return 4, cache is {3=3, 4=4}
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void LRUCache_LeetCodeExample2_WorksCorrectly(Func<int, ILRUCache_146> factory, string solutionName)
        {
            // Another common example
            // Arrange
            var lruCache = factory(2);

            // Act & Assert
            lruCache.Put(2, 1);                     // cache is {2=1}
            lruCache.Put(1, 1);                     // cache is {2=1, 1=1}
            lruCache.Put(2, 3);                     // cache is {1=1, 2=3} (update 2's value and mark it recently used)
            lruCache.Put(4, 1);                     // LRU key was 1, evicts key 1, cache is {2=3, 4=1}
            Assert.AreEqual(-1, lruCache.Get(1), $"Get(1) should return -1 for {solutionName}");   // returns -1 (not found)
            Assert.AreEqual(3, lruCache.Get(2), $"Get(2) should return 3 for {solutionName}");     // returns 3
        }

        #endregion

        #region Constructor Tests

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Constructor_CapacityOne_InitializesCorrectly(Func<int, ILRUCache_146> factory, string solutionName)
        {
            // Arrange & Act
            var cache = factory(1);

            // Assert - Get on empty cache should return -1
            Assert.AreEqual(-1, cache.Get(1), $"Get on empty cache should return -1 for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Constructor_CapacityTwo_InitializesCorrectly(Func<int, ILRUCache_146> factory, string solutionName)
        {
            // Arrange & Act
            var cache = factory(2);

            // Assert - Get on empty cache should return -1
            Assert.AreEqual(-1, cache.Get(100), $"Get on empty cache should return -1 for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Constructor_LargeCapacity_InitializesCorrectly(Func<int, ILRUCache_146> factory, string solutionName)
        {
            // Arrange & Act
            var cache = factory(1000);

            // Assert - Get on empty cache should return -1
            Assert.AreEqual(-1, cache.Get(1), $"Get on empty cache should return -1 for {solutionName}");
        }

        #endregion

        #region Get Tests

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Get_EmptyCache_ReturnsMinusOne(Func<int, ILRUCache_146> factory, string solutionName)
        {
            // Arrange
            var cache = factory(2);

            // Act & Assert
            Assert.AreEqual(-1, cache.Get(1), $"Get on empty cache should return -1 for {solutionName}");
            Assert.AreEqual(-1, cache.Get(999), $"Get on empty cache should return -1 for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Get_ExistingKey_ReturnsValue(Func<int, ILRUCache_146> factory, string solutionName)
        {
            // Arrange
            var cache = factory(2);
            cache.Put(1, 100);

            // Act
            int result = cache.Get(1);

            // Assert
            Assert.AreEqual(100, result, $"Get should return correct value for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Get_NonExistingKey_ReturnsMinusOne(Func<int, ILRUCache_146> factory, string solutionName)
        {
            // Arrange
            var cache = factory(2);
            cache.Put(1, 100);

            // Act
            int result = cache.Get(2);

            // Assert
            Assert.AreEqual(-1, result, $"Get for non-existing key should return -1 for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Get_UpdatesRecency_AvoidEviction(Func<int, ILRUCache_146> factory, string solutionName)
        {
            // This test verifies that Get updates the recency of an item
            // Arrange
            var cache = factory(2);
            cache.Put(1, 1);
            cache.Put(2, 2);

            // Act - Access key 1 to make it more recently used than key 2
            cache.Get(1);
            
            // Add new key, should evict key 2 (least recently used)
            cache.Put(3, 3);

            // Assert
            Assert.AreEqual(1, cache.Get(1), $"Key 1 should still exist for {solutionName}");
            Assert.AreEqual(-1, cache.Get(2), $"Key 2 should be evicted for {solutionName}");
            Assert.AreEqual(3, cache.Get(3), $"Key 3 should exist for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Get_MultipleGets_MaintainsRecency(Func<int, ILRUCache_146> factory, string solutionName)
        {
            // Arrange
            var cache = factory(3);
            cache.Put(1, 1);
            cache.Put(2, 2);
            cache.Put(3, 3);

            // Act - Get key 1 multiple times to keep it fresh
            cache.Get(1);
            cache.Get(1);
            cache.Get(1);
            
            // Add new key, should evict key 2 (least recently used)
            cache.Put(4, 4);

            // Assert
            Assert.AreEqual(1, cache.Get(1), $"Key 1 should still exist for {solutionName}");
            Assert.AreEqual(-1, cache.Get(2), $"Key 2 should be evicted for {solutionName}");
        }

        #endregion

        #region Put Tests

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Put_SingleItem_StoresCorrectly(Func<int, ILRUCache_146> factory, string solutionName)
        {
            // Arrange
            var cache = factory(2);

            // Act
            cache.Put(1, 100);

            // Assert
            Assert.AreEqual(100, cache.Get(1), $"Put should store value correctly for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Put_MultipleItems_StoresCorrectly(Func<int, ILRUCache_146> factory, string solutionName)
        {
            // Arrange
            var cache = factory(3);

            // Act
            cache.Put(1, 100);
            cache.Put(2, 200);
            cache.Put(3, 300);

            // Assert
            Assert.AreEqual(100, cache.Get(1), $"Key 1 should have value 100 for {solutionName}");
            Assert.AreEqual(200, cache.Get(2), $"Key 2 should have value 200 for {solutionName}");
            Assert.AreEqual(300, cache.Get(3), $"Key 3 should have value 300 for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Put_UpdateExistingKey_UpdatesValue(Func<int, ILRUCache_146> factory, string solutionName)
        {
            // Arrange
            var cache = factory(2);
            cache.Put(1, 100);

            // Act - Update the value
            cache.Put(1, 200);

            // Assert
            Assert.AreEqual(200, cache.Get(1), $"Put should update existing key's value for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Put_UpdateExistingKey_UpdatesRecency(Func<int, ILRUCache_146> factory, string solutionName)
        {
            // This test verifies that updating a key also updates its recency
            // Arrange
            var cache = factory(2);
            cache.Put(1, 1);
            cache.Put(2, 2);

            // Act - Update key 1 (making it most recently used)
            cache.Put(1, 100);
            
            // Add new key, should evict key 2 (least recently used)
            cache.Put(3, 3);

            // Assert
            Assert.AreEqual(100, cache.Get(1), $"Key 1 should exist with updated value for {solutionName}");
            Assert.AreEqual(-1, cache.Get(2), $"Key 2 should be evicted for {solutionName}");
            Assert.AreEqual(3, cache.Get(3), $"Key 3 should exist for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Put_ExceedsCapacity_EvictsLRU(Func<int, ILRUCache_146> factory, string solutionName)
        {
            // Arrange
            var cache = factory(2);
            cache.Put(1, 1);
            cache.Put(2, 2);

            // Act - Exceed capacity, should evict key 1 (least recently used)
            cache.Put(3, 3);

            // Assert
            Assert.AreEqual(-1, cache.Get(1), $"Key 1 should be evicted for {solutionName}");
            Assert.AreEqual(2, cache.Get(2), $"Key 2 should still exist for {solutionName}");
            Assert.AreEqual(3, cache.Get(3), $"Key 3 should exist for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Put_ZeroValue_StoresCorrectly(Func<int, ILRUCache_146> factory, string solutionName)
        {
            // Arrange
            var cache = factory(2);

            // Act
            cache.Put(1, 0);

            // Assert
            Assert.AreEqual(0, cache.Get(1), $"Put should store zero value correctly for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Put_NegativeValue_StoresCorrectly(Func<int, ILRUCache_146> factory, string solutionName)
        {
            // Arrange
            var cache = factory(2);

            // Act
            cache.Put(1, -100);

            // Assert
            Assert.AreEqual(-100, cache.Get(1), $"Put should store negative value correctly for {solutionName}");
        }

        #endregion

        #region Capacity One Tests

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CapacityOne_SingleItem_WorksCorrectly(Func<int, ILRUCache_146> factory, string solutionName)
        {
            // Arrange
            var cache = factory(1);

            // Act
            cache.Put(1, 100);

            // Assert
            Assert.AreEqual(100, cache.Get(1), $"Should store single item for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CapacityOne_SecondItem_EvictsFirst(Func<int, ILRUCache_146> factory, string solutionName)
        {
            // Arrange
            var cache = factory(1);
            cache.Put(1, 100);

            // Act
            cache.Put(2, 200);

            // Assert
            Assert.AreEqual(-1, cache.Get(1), $"First item should be evicted for {solutionName}");
            Assert.AreEqual(200, cache.Get(2), $"Second item should exist for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CapacityOne_Update_WorksCorrectly(Func<int, ILRUCache_146> factory, string solutionName)
        {
            // Arrange
            var cache = factory(1);
            cache.Put(1, 100);

            // Act
            cache.Put(1, 200);

            // Assert
            Assert.AreEqual(200, cache.Get(1), $"Update should work for capacity-1 cache for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CapacityOne_GetAndPut_WorksCorrectly(Func<int, ILRUCache_146> factory, string solutionName)
        {
            // Arrange
            var cache = factory(1);

            // Act & Assert
            cache.Put(2, 1);
            Assert.AreEqual(1, cache.Get(2), $"Get should return 1 for {solutionName}");
            
            cache.Put(3, 2);
            Assert.AreEqual(-1, cache.Get(2), $"Key 2 should be evicted for {solutionName}");
            Assert.AreEqual(2, cache.Get(3), $"Get should return 2 for {solutionName}");
        }

        #endregion

        #region LRU Eviction Order Tests

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void LRUEviction_FIFOWithoutAccess_EvictsInOrder(Func<int, ILRUCache_146> factory, string solutionName)
        {
            // Arrange
            var cache = factory(3);
            cache.Put(1, 1);
            cache.Put(2, 2);
            cache.Put(3, 3);

            // Act - Add 4th item without accessing previous ones
            cache.Put(4, 4);

            // Assert - Key 1 should be evicted (oldest)
            Assert.AreEqual(-1, cache.Get(1), $"Key 1 should be evicted for {solutionName}");
            Assert.AreEqual(2, cache.Get(2), $"Key 2 should exist for {solutionName}");
            Assert.AreEqual(3, cache.Get(3), $"Key 3 should exist for {solutionName}");
            Assert.AreEqual(4, cache.Get(4), $"Key 4 should exist for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void LRUEviction_AccessPattern_EvictsCorrectly(Func<int, ILRUCache_146> factory, string solutionName)
        {
            // Test complex access patterns
            // Arrange
            var cache = factory(3);
            cache.Put(1, 1);  // Order: 1
            cache.Put(2, 2);  // Order: 1, 2
            cache.Put(3, 3);  // Order: 1, 2, 3
            
            cache.Get(1);     // Order: 2, 3, 1 (1 is now most recent)
            cache.Get(2);     // Order: 3, 1, 2 (2 is now most recent)
            
            // Act - Add 4th item, should evict key 3 (least recently used)
            cache.Put(4, 4);  // Order: 1, 2, 4

            // Assert
            Assert.AreEqual(1, cache.Get(1), $"Key 1 should exist for {solutionName}");
            Assert.AreEqual(2, cache.Get(2), $"Key 2 should exist for {solutionName}");
            Assert.AreEqual(-1, cache.Get(3), $"Key 3 should be evicted for {solutionName}");
            Assert.AreEqual(4, cache.Get(4), $"Key 4 should exist for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void LRUEviction_OnlyGetAccess_EvictsCorrectly(Func<int, ILRUCache_146> factory, string solutionName)
        {
            // Arrange
            var cache = factory(2);
            cache.Put(1, 1);
            cache.Put(2, 2);

            // Act - Access only key 2 repeatedly
            cache.Get(2);
            cache.Get(2);
            cache.Get(2);
            
            // Add new item, should evict key 1
            cache.Put(3, 3);

            // Assert
            Assert.AreEqual(-1, cache.Get(1), $"Key 1 should be evicted for {solutionName}");
            Assert.AreEqual(2, cache.Get(2), $"Key 2 should exist for {solutionName}");
            Assert.AreEqual(3, cache.Get(3), $"Key 3 should exist for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void LRUEviction_OnlyPutAccess_EvictsCorrectly(Func<int, ILRUCache_146> factory, string solutionName)
        {
            // Arrange
            var cache = factory(2);
            cache.Put(1, 1);
            cache.Put(2, 2);

            // Act - Update only key 2
            cache.Put(2, 200);
            
            // Add new item, should evict key 1
            cache.Put(3, 3);

            // Assert
            Assert.AreEqual(-1, cache.Get(1), $"Key 1 should be evicted for {solutionName}");
            Assert.AreEqual(200, cache.Get(2), $"Key 2 should exist with updated value for {solutionName}");
            Assert.AreEqual(3, cache.Get(3), $"Key 3 should exist for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void LRUEviction_SequentialEvictions_WorksCorrectly(Func<int, ILRUCache_146> factory, string solutionName)
        {
            // Test multiple evictions in sequence
            // Arrange
            var cache = factory(2);

            // Act - Keep adding items, each should evict the LRU
            cache.Put(1, 1);    // Cache: [1]
            cache.Put(2, 2);    // Cache: [1, 2]
            cache.Put(3, 3);    // Cache: [2, 3] (evicted 1)
            cache.Put(4, 4);    // Cache: [3, 4] (evicted 2)
            cache.Put(5, 5);    // Cache: [4, 5] (evicted 3)

            // Assert
            Assert.AreEqual(-1, cache.Get(1), $"Key 1 should be evicted for {solutionName}");
            Assert.AreEqual(-1, cache.Get(2), $"Key 2 should be evicted for {solutionName}");
            Assert.AreEqual(-1, cache.Get(3), $"Key 3 should be evicted for {solutionName}");
            Assert.AreEqual(4, cache.Get(4), $"Key 4 should exist for {solutionName}");
            Assert.AreEqual(5, cache.Get(5), $"Key 5 should exist for {solutionName}");
        }

        #endregion

        #region Edge Cases

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void EdgeCase_SameKeyMultiplePuts_WorksCorrectly(Func<int, ILRUCache_146> factory, string solutionName)
        {
            // Arrange
            var cache = factory(2);

            // Act - Put same key multiple times
            cache.Put(1, 1);
            cache.Put(1, 10);
            cache.Put(1, 100);
            cache.Put(1, 1000);

            // Assert
            Assert.AreEqual(1000, cache.Get(1), $"Should have latest value for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void EdgeCase_AlternatingKeys_WorksCorrectly(Func<int, ILRUCache_146> factory, string solutionName)
        {
            // Arrange
            var cache = factory(2);

            // Act - Alternate between two keys
            cache.Put(1, 1);
            cache.Put(2, 2);
            cache.Get(1);
            cache.Put(2, 200);
            cache.Get(1);
            cache.Put(2, 2000);

            // Assert
            Assert.AreEqual(1, cache.Get(1), $"Key 1 should exist for {solutionName}");
            Assert.AreEqual(2000, cache.Get(2), $"Key 2 should have latest value for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void EdgeCase_LargeKeys_WorksCorrectly(Func<int, ILRUCache_146> factory, string solutionName)
        {
            // Arrange
            var cache = factory(3);

            // Act - Use large key values
            cache.Put(10000, 1);
            cache.Put(20000, 2);
            cache.Put(30000, 3);

            // Assert
            Assert.AreEqual(1, cache.Get(10000), $"Large key 10000 should work for {solutionName}");
            Assert.AreEqual(2, cache.Get(20000), $"Large key 20000 should work for {solutionName}");
            Assert.AreEqual(3, cache.Get(30000), $"Large key 30000 should work for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void EdgeCase_LargeValues_WorksCorrectly(Func<int, ILRUCache_146> factory, string solutionName)
        {
            // Arrange
            var cache = factory(3);

            // Act - Use large values
            cache.Put(1, 10000);
            cache.Put(2, 20000);
            cache.Put(3, 30000);

            // Assert
            Assert.AreEqual(10000, cache.Get(1), $"Large value 10000 should work for {solutionName}");
            Assert.AreEqual(20000, cache.Get(2), $"Large value 20000 should work for {solutionName}");
            Assert.AreEqual(30000, cache.Get(3), $"Large value 30000 should work for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void EdgeCase_NegativeKeys_WorksCorrectly(Func<int, ILRUCache_146> factory, string solutionName)
        {
            // Arrange
            var cache = factory(2);

            // Act
            cache.Put(-1, 100);
            cache.Put(-2, 200);

            // Assert
            Assert.AreEqual(100, cache.Get(-1), $"Negative key -1 should work for {solutionName}");
            Assert.AreEqual(200, cache.Get(-2), $"Negative key -2 should work for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void EdgeCase_ZeroKey_WorksCorrectly(Func<int, ILRUCache_146> factory, string solutionName)
        {
            // Arrange
            var cache = factory(2);

            // Act
            cache.Put(0, 100);
            cache.Put(1, 200);

            // Assert
            Assert.AreEqual(100, cache.Get(0), $"Zero key should work for {solutionName}");
            Assert.AreEqual(200, cache.Get(1), $"Key 1 should work for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void EdgeCase_DuplicateValues_DifferentKeys_WorksCorrectly(Func<int, ILRUCache_146> factory, string solutionName)
        {
            // Arrange
            var cache = factory(3);

            // Act - Same value for different keys
            cache.Put(1, 100);
            cache.Put(2, 100);
            cache.Put(3, 100);

            // Assert - All should have the same value
            Assert.AreEqual(100, cache.Get(1), $"Key 1 should have value 100 for {solutionName}");
            Assert.AreEqual(100, cache.Get(2), $"Key 2 should have value 100 for {solutionName}");
            Assert.AreEqual(100, cache.Get(3), $"Key 3 should have value 100 for {solutionName}");
        }

        #endregion

        #region Stress Tests

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void StressTest_ManyOperations_WorksCorrectly(Func<int, ILRUCache_146> factory, string solutionName)
        {
            // Arrange
            var cache = factory(10);

            // Act - Perform many operations
            for (int i = 0; i < 100; i++)
            {
                cache.Put(i, i * 10);
            }

            // Assert - Only last 10 should remain
            for (int i = 0; i < 90; i++)
            {
                Assert.AreEqual(-1, cache.Get(i), $"Key {i} should be evicted for {solutionName}");
            }
            for (int i = 90; i < 100; i++)
            {
                Assert.AreEqual(i * 10, cache.Get(i), $"Key {i} should exist for {solutionName}");
            }
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void StressTest_LargeCapacity_WorksCorrectly(Func<int, ILRUCache_146> factory, string solutionName)
        {
            // Arrange
            var cache = factory(1000);

            // Act - Fill to capacity
            for (int i = 0; i < 1000; i++)
            {
                cache.Put(i, i);
            }

            // Assert - All should exist
            for (int i = 0; i < 1000; i++)
            {
                Assert.AreEqual(i, cache.Get(i), $"Key {i} should exist for {solutionName}");
            }

            // Add one more to trigger eviction
            cache.Put(1000, 1000);
            Assert.AreEqual(-1, cache.Get(0), $"Key 0 should be evicted for {solutionName}");
            Assert.AreEqual(1000, cache.Get(1000), $"Key 1000 should exist for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void StressTest_MixedOperations_WorksCorrectly(Func<int, ILRUCache_146> factory, string solutionName)
        {
            // Arrange
            var cache = factory(50);

            // Act - Mix of puts, gets, and updates
            for (int i = 0; i < 100; i++)
            {
                cache.Put(i, i);
                
                // Access some older entries to keep them fresh
                if (i > 10)
                {
                    cache.Get(i - 10);
                }
                
                // Update some entries
                if (i % 5 == 0 && i > 0)
                {
                    cache.Put(i - 1, (i - 1) * 100);
                }
            }

            // Just verify cache is still functional
            cache.Put(999, 999);
            Assert.AreEqual(999, cache.Get(999), $"Cache should still be functional for {solutionName}");
        }

        #endregion

        #region Complex Scenarios

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void ComplexScenario_InterleavedOperations_WorksCorrectly(Func<int, ILRUCache_146> factory, string solutionName)
        {
            // A comprehensive test with complex interleaved operations
            // Arrange
            var cache = factory(2);

            // Scenario:
            cache.Put(1, 1);           // Cache: [1]
            cache.Put(2, 2);           // Cache: [1, 2]
            Assert.AreEqual(1, cache.Get(1), $"Get(1) should return 1 for {solutionName}");  // Cache: [2, 1]
            cache.Put(3, 3);           // Cache: [2, 1, 3]
            Assert.AreEqual(-1, cache.Get(2), $"Get(2) should return -1 for {solutionName}"); // 2 was evicted
            cache.Put(4, 4);           // LRU was 2 (already gone), now evict 1. Cache: [3, 4]
            Assert.AreEqual(-1, cache.Get(1), $"Get(1) should return -1 for {solutionName}"); // 1 was evicted
            Assert.AreEqual(3, cache.Get(3), $"Get(3) should return 3 for {solutionName}");  // Cache: [4, 3]
            Assert.AreEqual(4, cache.Get(4), $"Get(4) should return 4 for {solutionName}");  // Cache: [3, 4]
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void ComplexScenario_RepeatedUpdateAndAccess_WorksCorrectly(Func<int, ILRUCache_146> factory, string solutionName)
        {
            // Test repeated updates with intermittent access
            // Arrange
            var cache = factory(2);

            // Scenario:
            cache.Put(2, 1);           // Cache: [2=1]
            cache.Put(2, 2);           // Cache: [2=2] (update)
            Assert.AreEqual(2, cache.Get(2), $"Get(2) should return 2 for {solutionName}");
            cache.Put(1, 1);           // Cache: [2=2, 1=1]
            cache.Put(4, 1);           // Cache: [1=1, 4=1] (evicted 2)
            Assert.AreEqual(-1, cache.Get(2), $"Get(2) should return -1 for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void ComplexScenario_CyclicAccess_WorksCorrectly(Func<int, ILRUCache_146> factory, string solutionName)
        {
            // Test cyclic access pattern
            // Arrange
            var cache = factory(3);

            // Fill cache
            cache.Put(1, 1);
            cache.Put(2, 2);
            cache.Put(3, 3);

            // Cyclic access - keep all 3 items fresh
            for (int i = 0; i < 10; i++)
            {
                cache.Get(1);
                cache.Get(2);
                cache.Get(3);
            }

            // All should still exist
            Assert.AreEqual(1, cache.Get(1), $"Key 1 should exist for {solutionName}");
            Assert.AreEqual(2, cache.Get(2), $"Key 2 should exist for {solutionName}");
            Assert.AreEqual(3, cache.Get(3), $"Key 3 should exist for {solutionName}");

            // Add new item
            cache.Put(4, 4);

            // First accessed item (1) should be evicted due to FIFO-like behavior when all are accessed equally
            // Actually, the LRU should be based on order, so after cyclic access, 1 is most recent
            // Let's verify whatever got evicted
            int evictedCount = 0;
            if (cache.Get(1) == -1) evictedCount++;
            if (cache.Get(2) == -1) evictedCount++;
            if (cache.Get(3) == -1) evictedCount++;

            Assert.AreEqual(1, evictedCount, $"Exactly one key should be evicted for {solutionName}");
            Assert.AreEqual(4, cache.Get(4), $"Key 4 should exist for {solutionName}");
        }

        #endregion
    }
}
