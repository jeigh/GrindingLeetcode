#include "gtest/gtest.h"
#include "ListNode.h"
#include "ReverseList_206.h"
#include "TestHelpers.h"

using namespace LeetCodeTests;

class ReverseList_206_Tests : public ::testing::Test {
protected:
    ReverseList_206 solution;

    void TearDown() override {
        // Cleanup is handled by FreeLinkedList in each test
    }
};

// Test 1: Empty list (nullptr)
TEST_F(ReverseList_206_Tests, ReverseList_EmptyList_ReturnsNull) {
    // Arrange
    ListNode* head = nullptr;

    // Act
    ListNode* result = solution.reverseList(head);

    // Assert
    ASSERT_EQ(nullptr, result);
}

// Test 2: Single node
TEST_F(ReverseList_206_Tests, ReverseList_SingleNode_ReturnsSameNode) {
    // Arrange
    ListNode* head = CreateLinkedList({ 1 });

    // Act
    ListNode* result = solution.reverseList(head);

    // Assert
    AssertLinkedListEquals({ 1 }, result);

    // Cleanup
    FreeLinkedList(result);
}

// Test 3: Two nodes
TEST_F(ReverseList_206_Tests, ReverseList_TwoNodes_ReversesCorrectly) {
    // Arrange
    ListNode* head = CreateLinkedList({ 1, 2 });

    // Act
    ListNode* result = solution.reverseList(head);

    // Assert
    AssertLinkedListEquals({ 2, 1 }, result);

    // Cleanup
    FreeLinkedList(result);
}

// Test 4: Example from LeetCode - [1,2,3,4,5]
TEST_F(ReverseList_206_Tests, ReverseList_Example1_ReversesCorrectly) {
    // Arrange
    ListNode* head = CreateLinkedList({ 1, 2, 3, 4, 5 });

    // Act
    ListNode* result = solution.reverseList(head);

    // Assert
    AssertLinkedListEquals({ 5, 4, 3, 2, 1 }, result);

    // Cleanup
    FreeLinkedList(result);
}

// Test 5: Example from LeetCode - [1,2]
TEST_F(ReverseList_206_Tests, ReverseList_Example2_ReversesCorrectly) {
    // Arrange
    ListNode* head = CreateLinkedList({ 1, 2 });

    // Act
    ListNode* result = solution.reverseList(head);

    // Assert
    AssertLinkedListEquals({ 2, 1 }, result);

    // Cleanup
    FreeLinkedList(result);
}

// Test 6: Three nodes
TEST_F(ReverseList_206_Tests, ReverseList_ThreeNodes_ReversesCorrectly) {
    // Arrange
    ListNode* head = CreateLinkedList({ 1, 2, 3 });

    // Act
    ListNode* result = solution.reverseList(head);

    // Assert
    AssertLinkedListEquals({ 3, 2, 1 }, result);

    // Cleanup
    FreeLinkedList(result);
}

// Test 7: Longer list
TEST_F(ReverseList_206_Tests, ReverseList_LongerList_ReversesCorrectly) {
    // Arrange
    ListNode* head = CreateLinkedList({ 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });

    // Act
    ListNode* result = solution.reverseList(head);

    // Assert
    AssertLinkedListEquals({ 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 }, result);

    // Cleanup
    FreeLinkedList(result);
}

// Test 8: List with duplicate values
TEST_F(ReverseList_206_Tests, ReverseList_DuplicateValues_ReversesCorrectly) {
    // Arrange
    ListNode* head = CreateLinkedList({ 1, 2, 2, 3, 3, 3 });

    // Act
    ListNode* result = solution.reverseList(head);

    // Assert
    AssertLinkedListEquals({ 3, 3, 3, 2, 2, 1 }, result);

    // Cleanup
    FreeLinkedList(result);
}

// Test 9: All same values
TEST_F(ReverseList_206_Tests, ReverseList_AllSameValues_ReversesCorrectly) {
    // Arrange
    ListNode* head = CreateLinkedList({ 5, 5, 5, 5 });

    // Act
    ListNode* result = solution.reverseList(head);

    // Assert
    AssertLinkedListEquals({ 5, 5, 5, 5 }, result);

    // Cleanup
    FreeLinkedList(result);
}

// Test 10: List with negative values
TEST_F(ReverseList_206_Tests, ReverseList_NegativeValues_ReversesCorrectly) {
    // Arrange
    ListNode* head = CreateLinkedList({ -5, -4, -3, -2, -1 });

    // Act
    ListNode* result = solution.reverseList(head);

    // Assert
    AssertLinkedListEquals({ -1, -2, -3, -4, -5 }, result);

    // Cleanup
    FreeLinkedList(result);
}

// Test 11: List with mixed positive and negative values
TEST_F(ReverseList_206_Tests, ReverseList_MixedValues_ReversesCorrectly) {
    // Arrange
    ListNode* head = CreateLinkedList({ -2, -1, 0, 1, 2 });

    // Act
    ListNode* result = solution.reverseList(head);

    // Assert
    AssertLinkedListEquals({ 2, 1, 0, -1, -2 }, result);

    // Cleanup
    FreeLinkedList(result);
}

// Test 12: Large list (performance test)
TEST_F(ReverseList_206_Tests, ReverseList_LargeList_ReversesCorrectly) {
    // Arrange - Create a list with 100 elements
    ListNode* head = nullptr;
    ListNode* current = nullptr;

    for (int i = 1; i <= 100; i++) {
        ListNode* newNode = new ListNode(i);
        if (head == nullptr) {
            head = newNode;
            current = head;
        }
        else {
            current->next = newNode;
            current = newNode;
        }
    }

    // Act
    ListNode* result = solution.reverseList(head);

    // Assert - Check first, middle, and last values
    ASSERT_EQ(100, result->val);

    current = result;
    for (int i = 0; i < 49; i++) {
        current = current->next;
    }
    ASSERT_EQ(51, current->val);

    current = result;
    while (current->next != nullptr) {
        current = current->next;
    }
    ASSERT_EQ(1, current->val);

    // Cleanup
    FreeLinkedList(result);
}

// Test 13: Verify no memory leaks - reverse twice should give original
TEST_F(ReverseList_206_Tests, ReverseList_ReverseTwice_ReturnsOriginalOrder) {
    // Arrange
    ListNode* head = CreateLinkedList({ 1, 2, 3, 4, 5 });

    // Act
    ListNode* firstReverse = solution.reverseList(head);
    ListNode* secondReverse = solution.reverseList(firstReverse);

    // Assert
    AssertLinkedListEquals({ 1, 2, 3, 4, 5 }, secondReverse);

    // Cleanup
    FreeLinkedList(secondReverse);
}

// Test 14: List with zero
TEST_F(ReverseList_206_Tests, ReverseList_ListWithZero_ReversesCorrectly) {
    // Arrange
    ListNode* head = CreateLinkedList({ 0, 1, 2 });

    // Act
    ListNode* result = solution.reverseList(head);

    // Assert
    AssertLinkedListEquals({ 2, 1, 0 }, result);

    // Cleanup
    FreeLinkedList(result);
}

// Test 15: All zeros
TEST_F(ReverseList_206_Tests, ReverseList_AllZeros_ReversesCorrectly) {
    // Arrange
    ListNode* head = CreateLinkedList({ 0, 0, 0 });

    // Act
    ListNode* result = solution.reverseList(head);

    // Assert
    AssertLinkedListEquals({ 0, 0, 0 }, result);

    // Cleanup
    FreeLinkedList(result);
}