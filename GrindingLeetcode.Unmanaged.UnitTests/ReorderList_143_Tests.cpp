#include "gtest/gtest.h"
#include "../LeetCodeProblems.UnmanagedCpp/ReorderList_143.h"
#include "../LeetCodeProblems.UnmanagedCpp/ListNode.h"
#include "TestHelpers.h"

using namespace LeetCodeTests;

class ReorderList_143_Tests : public ::testing::Test {
protected:
    ReorderList_143 solution;

    void SetUp() override {
        // Called before each test
    }

    void TearDown() override {
        // Called after each test
    }
};

// LeetCode Examples

TEST_F(ReorderList_143_Tests, Example1_ReordersCorrectly) {
    // Arrange: [1,2,3,4]
    ListNode* head = CreateLinkedList({ 1, 2, 3, 4 });

    // Act
    solution.reorderList(head);

    // Assert: [1,4,2,3]
    AssertLinkedListEquals({ 1, 4, 2, 3 }, head);

    // Cleanup
    FreeLinkedList(head);
}

TEST_F(ReorderList_143_Tests, Example2_ReordersCorrectly) {
    // Arrange: [1,2,3,4,5]
    ListNode* head = CreateLinkedList({ 1, 2, 3, 4, 5 });

    // Act
    solution.reorderList(head);

    // Assert: [1,5,2,4,3]
    AssertLinkedListEquals({ 1, 5, 2, 4, 3 }, head);

    // Cleanup
    FreeLinkedList(head);
}

// Edge Cases

TEST_F(ReorderList_143_Tests, SingleElement_RemainsUnchanged) {
    // Arrange: [1]
    ListNode* head = CreateLinkedList({ 1 });

    // Act
    solution.reorderList(head);

    // Assert: [1]
    AssertLinkedListEquals({ 1 }, head);

    // Cleanup
    FreeLinkedList(head);
}

TEST_F(ReorderList_143_Tests, TwoElements_RemainsUnchanged) {
    // Arrange: [1,2]
    ListNode* head = CreateLinkedList({ 1, 2 });

    // Act
    solution.reorderList(head);

    // Assert: [1,2] - no reordering needed
    AssertLinkedListEquals({ 1, 2 }, head);

    // Cleanup
    FreeLinkedList(head);
}

TEST_F(ReorderList_143_Tests, ThreeElements_ReordersCorrectly) {
    // Arrange: [1,2,3]
    ListNode* head = CreateLinkedList({ 1, 2, 3 });

    // Act
    solution.reorderList(head);

    // Assert: [1,3,2]
    AssertLinkedListEquals({ 1, 3, 2 }, head);

    // Cleanup
    FreeLinkedList(head);
}

// Even Length Lists

TEST_F(ReorderList_143_Tests, SixElements_ReordersCorrectly) {
    // Arrange: [1,2,3,4,5,6]
    ListNode* head = CreateLinkedList({ 1, 2, 3, 4, 5, 6 });

    // Act
    solution.reorderList(head);

    // Assert: [1,6,2,5,3,4]
    AssertLinkedListEquals({ 1, 6, 2, 5, 3, 4 }, head);

    // Cleanup
    FreeLinkedList(head);
}

TEST_F(ReorderList_143_Tests, EightElements_ReordersCorrectly) {
    // Arrange: [1,2,3,4,5,6,7,8]
    ListNode* head = CreateLinkedList({ 1, 2, 3, 4, 5, 6, 7, 8 });

    // Act
    solution.reorderList(head);

    // Assert: [1,8,2,7,3,6,4,5]
    AssertLinkedListEquals({ 1, 8, 2, 7, 3, 6, 4, 5 }, head);

    // Cleanup
    FreeLinkedList(head);
}

// Odd Length Lists

TEST_F(ReorderList_143_Tests, SevenElements_ReordersCorrectly) {
    // Arrange: [1,2,3,4,5,6,7]
    ListNode* head = CreateLinkedList({ 1, 2, 3, 4, 5, 6, 7 });

    // Act
    solution.reorderList(head);

    // Assert: [1,7,2,6,3,5,4]
    AssertLinkedListEquals({ 1, 7, 2, 6, 3, 5, 4 }, head);

    // Cleanup
    FreeLinkedList(head);
}

TEST_F(ReorderList_143_Tests, NineElements_ReordersCorrectly) {
    // Arrange: [1,2,3,4,5,6,7,8,9]
    ListNode* head = CreateLinkedList({ 1, 2, 3, 4, 5, 6, 7, 8, 9 });

    // Act
    solution.reorderList(head);

    // Assert: [1,9,2,8,3,7,4,6,5]
    AssertLinkedListEquals({ 1, 9, 2, 8, 3, 7, 4, 6, 5 }, head);

    // Cleanup
    FreeLinkedList(head);
}

// Different Value Patterns

TEST_F(ReorderList_143_Tests, NegativeNumbers_ReordersCorrectly) {
    // Arrange: [-5,-3,-1,0,1,3,5]
    ListNode* head = CreateLinkedList({ -5, -3, -1, 0, 1, 3, 5 });

    // Act
    solution.reorderList(head);

    // Assert: [-5,5,-3,3,-1,1,0]
    AssertLinkedListEquals({ -5, 5, -3, 3, -1, 1, 0 }, head);

    // Cleanup
    FreeLinkedList(head);
}

TEST_F(ReorderList_143_Tests, WithDuplicates_ReordersCorrectly) {
    // Arrange: [1,1,2,2,3,3]
    ListNode* head = CreateLinkedList({ 1, 1, 2, 2, 3, 3 });

    // Act
    solution.reorderList(head);

    // Assert: [1,3,1,3,2,2]
    AssertLinkedListEquals({ 1, 3, 1, 3, 2, 2 }, head);

    // Cleanup
    FreeLinkedList(head);
}

TEST_F(ReorderList_143_Tests, AllSameValues_ReordersCorrectly) {
    // Arrange: [5,5,5,5,5]
    ListNode* head = CreateLinkedList({ 5, 5, 5, 5, 5 });

    // Act
    solution.reorderList(head);

    // Assert: [5,5,5,5,5]
    AssertLinkedListEquals({ 5, 5, 5, 5, 5 }, head);

    // Cleanup
    FreeLinkedList(head);
}

TEST_F(ReorderList_143_Tests, AllZeros_ReordersCorrectly) {
    // Arrange: [0,0,0,0]
    ListNode* head = CreateLinkedList({ 0, 0, 0, 0 });

    // Act
    solution.reorderList(head);

    // Assert: [0,0,0,0]
    AssertLinkedListEquals({ 0, 0, 0, 0 }, head);

    // Cleanup
    FreeLinkedList(head);
}

// Sequential Patterns

TEST_F(ReorderList_143_Tests, SequentialNumbers_ReordersCorrectly) {
    // Arrange: [1,2,3,4,5,6,7,8,9,10]
    ListNode* head = CreateLinkedList({ 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });

    // Act
    solution.reorderList(head);

    // Assert: [1,10,2,9,3,8,4,7,5,6]
    AssertLinkedListEquals({ 1, 10, 2, 9, 3, 8, 4, 7, 5, 6 }, head);

    // Cleanup
    FreeLinkedList(head);
}

TEST_F(ReorderList_143_Tests, ReverseSequentialNumbers_ReordersCorrectly) {
    // Arrange: [10,9,8,7,6,5,4,3,2,1]
    ListNode* head = CreateLinkedList({ 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 });

    // Act
    solution.reorderList(head);

    // Assert: [10,1,9,2,8,3,7,4,6,5]
    AssertLinkedListEquals({ 10, 1, 9, 2, 8, 3, 7, 4, 6, 5 }, head);

    // Cleanup
    FreeLinkedList(head);
}

// Large Values

TEST_F(ReorderList_143_Tests, LargeValues_ReordersCorrectly) {
    // Arrange: [100,200,300,400,500]
    ListNode* head = CreateLinkedList({ 100, 200, 300, 400, 500 });

    // Act
    solution.reorderList(head);

    // Assert: [100,500,200,400,300]
    AssertLinkedListEquals({ 100, 500, 200, 400, 300 }, head);

    // Cleanup
    FreeLinkedList(head);
}

TEST_F(ReorderList_143_Tests, MixedLargeAndSmallValues_ReordersCorrectly) {
    // Arrange: [1,1000,2,2000,3,3000]
    ListNode* head = CreateLinkedList({ 1, 1000, 2, 2000, 3, 3000 });

    // Act
    solution.reorderList(head);

    // Assert: [1,3000,1000,3,2,2000]
    AssertLinkedListEquals({ 1, 3000, 1000, 3, 2, 2000 }, head);

    // Cleanup
    FreeLinkedList(head);
}

// Verify List Structure Integrity

TEST_F(ReorderList_143_Tests, NoMemoryLeaks_AllNodesReachable) {
    // Arrange: [1,2,3,4,5,6]
    ListNode* head = CreateLinkedList({ 1, 2, 3, 4, 5, 6 });

    // Act
    solution.reorderList(head);

    // Assert: All 6 nodes should still be reachable
    int nodeCount = 0;
    ListNode* current = head;
    while (current != nullptr) {
        nodeCount++;
        current = current->next;
    }
    ASSERT_EQ(6, nodeCount);

    // Cleanup
    FreeLinkedList(head);
}

TEST_F(ReorderList_143_Tests, NoCircularReferences_ListTerminates) {
    // Arrange: [1,2,3,4,5]
    ListNode* head = CreateLinkedList({ 1, 2, 3, 4, 5 });

    // Act
    solution.reorderList(head);

    // Assert: List should terminate (not circular)
    ListNode* current = head;
    int maxIterations = 100; // Safety limit
    int iterations = 0;
    
    while (current != nullptr && iterations < maxIterations) {
        current = current->next;
        iterations++;
    }
    
    ASSERT_LT(iterations, maxIterations) << "List appears to be circular";
    ASSERT_EQ(nullptr, current) << "List should end with nullptr";

    // Cleanup
    FreeLinkedList(head);
}

// Pattern Verification Tests

TEST_F(ReorderList_143_Tests, FirstElementStaysFirst) {
    // Arrange: [100,2,3,4,5]
    ListNode* head = CreateLinkedList({ 100, 2, 3, 4, 5 });

    // Act
    solution.reorderList(head);

    // Assert: First element should be 100
    ASSERT_EQ(100, head->val);

    // Cleanup
    FreeLinkedList(head);
}

TEST_F(ReorderList_143_Tests, LastElementBecomesSecond) {
    // Arrange: [1,2,3,4,999]
    ListNode* head = CreateLinkedList({ 1, 2, 3, 4, 999 });

    // Act
    solution.reorderList(head);

    // Assert: Second element should be 999 (the last element)
    ASSERT_EQ(999, head->next->val);

    // Cleanup
    FreeLinkedList(head);
}

TEST_F(ReorderList_143_Tests, AlternatingPattern_EvenLength) {
    // Arrange: [1,2,3,4,5,6]
    ListNode* head = CreateLinkedList({ 1, 2, 3, 4, 5, 6 });

    // Act
    solution.reorderList(head);

    // Assert: Pattern should be from start, from end, from start, from end...
    std::vector<int> result = LinkedListToVector(head);
    ASSERT_EQ(6, result.size());
    ASSERT_EQ(1, result[0]); // L0
    ASSERT_EQ(6, result[1]); // Ln
    ASSERT_EQ(2, result[2]); // L1
    ASSERT_EQ(5, result[3]); // Ln-1
    ASSERT_EQ(3, result[4]); // L2
    ASSERT_EQ(4, result[5]); // Ln-2

    // Cleanup
    FreeLinkedList(head);
}

TEST_F(ReorderList_143_Tests, AlternatingPattern_OddLength) {
    // Arrange: [1,2,3,4,5]
    ListNode* head = CreateLinkedList({ 1, 2, 3, 4, 5 });

    // Act
    solution.reorderList(head);

    // Assert: Pattern should be from start, from end, from start, from end...
    std::vector<int> result = LinkedListToVector(head);
    ASSERT_EQ(5, result.size());
    ASSERT_EQ(1, result[0]); // L0
    ASSERT_EQ(5, result[1]); // Ln
    ASSERT_EQ(2, result[2]); // L1
    ASSERT_EQ(4, result[3]); // Ln-1
    ASSERT_EQ(3, result[4]); // L2 (middle element)

    // Cleanup
    FreeLinkedList(head);
}