#include "gtest/gtest.h"
#include "ListNode.h"
#include "RemoveNthNodeFromLinkedList_19.h"
#include "TestHelpers.h"

using namespace LeetCodeTests;

class RemoveNthNodeFromLinkedList_19_Tests : public ::testing::Test {
protected:
    RemoveNthNodeFromLinkedList_19 solution;

    void TearDown() override {
        // Cleanup is handled by FreeLinkedList in each test
    }
};

#pragma region LeetCode Examples

// Test 1: LeetCode Example 1 - [1,2,3,4,5], n = 2
TEST_F(RemoveNthNodeFromLinkedList_19_Tests, RemoveNthFromEnd_Example1_RemovesSecondToLast) {
    // Arrange
    ListNode* head = CreateLinkedList({ 1, 2, 3, 4, 5 });

    // Act
    ListNode* result = solution.removeNthFromEnd(head, 2);

    // Assert: [1,2,3,5] - removed 4 (2nd from end)
    AssertLinkedListEquals({ 1, 2, 3, 5 }, result);

    // Cleanup
    FreeLinkedList(result);
}

// Test 2: LeetCode Example 2 - [1], n = 1
TEST_F(RemoveNthNodeFromLinkedList_19_Tests, RemoveNthFromEnd_Example2_RemovesOnlyNode) {
    // Arrange
    ListNode* head = CreateLinkedList({ 1 });

    // Act
    ListNode* result = solution.removeNthFromEnd(head, 1);

    // Assert: [] - list is empty
    ASSERT_EQ(nullptr, result);
}

// Test 3: LeetCode Example 3 - [1,2], n = 2
TEST_F(RemoveNthNodeFromLinkedList_19_Tests, RemoveNthFromEnd_Example3_RemovesFirstOfTwo) {
    // Arrange
    ListNode* head = CreateLinkedList({ 1, 2 });

    // Act
    ListNode* result = solution.removeNthFromEnd(head, 2);

    // Assert: [2] - removed first node
    AssertLinkedListEquals({ 2 }, result);

    // Cleanup
    FreeLinkedList(result);
}

#pragma endregion

#pragma region Remove Last Node

TEST_F(RemoveNthNodeFromLinkedList_19_Tests, RemoveNthFromEnd_RemoveLastNode_ThreeElements) {
    // Arrange: [1,2,3], n = 1
    ListNode* head = CreateLinkedList({ 1, 2, 3 });

    // Act
    ListNode* result = solution.removeNthFromEnd(head, 1);

    // Assert: [1,2]
    AssertLinkedListEquals({ 1, 2 }, result);

    // Cleanup
    FreeLinkedList(result);
}

TEST_F(RemoveNthNodeFromLinkedList_19_Tests, RemoveNthFromEnd_RemoveLastNode_FiveElements) {
    // Arrange: [1,2,3,4,5], n = 1
    ListNode* head = CreateLinkedList({ 1, 2, 3, 4, 5 });

    // Act
    ListNode* result = solution.removeNthFromEnd(head, 1);

    // Assert: [1,2,3,4]
    AssertLinkedListEquals({ 1, 2, 3, 4 }, result);

    // Cleanup
    FreeLinkedList(result);
}

TEST_F(RemoveNthNodeFromLinkedList_19_Tests, RemoveNthFromEnd_RemoveLastNode_TwoElements) {
    // Arrange: [1,2], n = 1
    ListNode* head = CreateLinkedList({ 1, 2 });

    // Act
    ListNode* result = solution.removeNthFromEnd(head, 1);

    // Assert: [1]
    AssertLinkedListEquals({ 1 }, result);

    // Cleanup
    FreeLinkedList(result);
}

#pragma endregion

#pragma region Remove First Node

TEST_F(RemoveNthNodeFromLinkedList_19_Tests, RemoveNthFromEnd_RemoveFirstNode_ThreeElements) {
    // Arrange: [1,2,3], n = 3
    ListNode* head = CreateLinkedList({ 1, 2, 3 });

    // Act
    ListNode* result = solution.removeNthFromEnd(head, 3);

    // Assert: [2,3]
    AssertLinkedListEquals({ 2, 3 }, result);

    // Cleanup
    FreeLinkedList(result);
}

TEST_F(RemoveNthNodeFromLinkedList_19_Tests, RemoveNthFromEnd_RemoveFirstNode_FiveElements) {
    // Arrange: [1,2,3,4,5], n = 5
    ListNode* head = CreateLinkedList({ 1, 2, 3, 4, 5 });

    // Act
    ListNode* result = solution.removeNthFromEnd(head, 5);

    // Assert: [2,3,4,5]
    AssertLinkedListEquals({ 2, 3, 4, 5 }, result);

    // Cleanup
    FreeLinkedList(result);
}

TEST_F(RemoveNthNodeFromLinkedList_19_Tests, RemoveNthFromEnd_RemoveFirstNode_TenElements) {
    // Arrange: [1,2,3,4,5,6,7,8,9,10], n = 10
    ListNode* head = CreateLinkedList({ 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });

    // Act
    ListNode* result = solution.removeNthFromEnd(head, 10);

    // Assert: [2,3,4,5,6,7,8,9,10]
    AssertLinkedListEquals({ 2, 3, 4, 5, 6, 7, 8, 9, 10 }, result);

    // Cleanup
    FreeLinkedList(result);
}

#pragma endregion

#pragma region Remove Middle Nodes

TEST_F(RemoveNthNodeFromLinkedList_19_Tests, RemoveNthFromEnd_RemoveMiddleNode_ThreeElements) {
    // Arrange: [1,2,3], n = 2
    ListNode* head = CreateLinkedList({ 1, 2, 3 });

    // Act
    ListNode* result = solution.removeNthFromEnd(head, 2);

    // Assert: [1,3]
    AssertLinkedListEquals({ 1, 3 }, result);

    // Cleanup
    FreeLinkedList(result);
}

TEST_F(RemoveNthNodeFromLinkedList_19_Tests, RemoveNthFromEnd_RemoveThirdFromEnd_FiveElements) {
    // Arrange: [1,2,3,4,5], n = 3
    ListNode* head = CreateLinkedList({ 1, 2, 3, 4, 5 });

    // Act
    ListNode* result = solution.removeNthFromEnd(head, 3);

    // Assert: [1,2,4,5] - removed 3
    AssertLinkedListEquals({ 1, 2, 4, 5 }, result);

    // Cleanup
    FreeLinkedList(result);
}

TEST_F(RemoveNthNodeFromLinkedList_19_Tests, RemoveNthFromEnd_RemoveFourthFromEnd_SevenElements) {
    // Arrange: [1,2,3,4,5,6,7], n = 4
    ListNode* head = CreateLinkedList({ 1, 2, 3, 4, 5, 6, 7 });

    // Act
    ListNode* result = solution.removeNthFromEnd(head, 4);

    // Assert: [1,2,3,5,6,7] - removed 4
    AssertLinkedListEquals({ 1, 2, 3, 5, 6, 7 }, result);

    // Cleanup
    FreeLinkedList(result);
}

TEST_F(RemoveNthNodeFromLinkedList_19_Tests, RemoveNthFromEnd_RemoveFifthFromEnd_TenElements) {
    // Arrange: [1,2,3,4,5,6,7,8,9,10], n = 5
    ListNode* head = CreateLinkedList({ 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });

    // Act
    ListNode* result = solution.removeNthFromEnd(head, 5);

    // Assert: [1,2,3,4,5,7,8,9,10] - removed 6
    AssertLinkedListEquals({ 1, 2, 3, 4, 5, 7, 8, 9, 10 }, result);

    // Cleanup
    FreeLinkedList(result);
}

#pragma endregion

#pragma region Single Element Lists

TEST_F(RemoveNthNodeFromLinkedList_19_Tests, RemoveNthFromEnd_SingleElement_ReturnsNull) {
    // Arrange: [5], n = 1
    ListNode* head = CreateLinkedList({ 5 });

    // Act
    ListNode* result = solution.removeNthFromEnd(head, 1);

    // Assert: null
    ASSERT_EQ(nullptr, result);
}

TEST_F(RemoveNthNodeFromLinkedList_19_Tests, RemoveNthFromEnd_SingleElementNegativeValue_ReturnsNull) {
    // Arrange: [-1], n = 1
    ListNode* head = CreateLinkedList({ -1 });

    // Act
    ListNode* result = solution.removeNthFromEnd(head, 1);

    // Assert: null
    ASSERT_EQ(nullptr, result);
}

TEST_F(RemoveNthNodeFromLinkedList_19_Tests, RemoveNthFromEnd_SingleElementLargeValue_ReturnsNull) {
    // Arrange: [100], n = 1
    ListNode* head = CreateLinkedList({ 100 });

    // Act
    ListNode* result = solution.removeNthFromEnd(head, 1);

    // Assert: null
    ASSERT_EQ(nullptr, result);
}

#pragma endregion

#pragma region Two Element Lists

TEST_F(RemoveNthNodeFromLinkedList_19_Tests, RemoveNthFromEnd_TwoElements_RemoveFirst) {
    // Arrange: [1,2], n = 2
    ListNode* head = CreateLinkedList({ 1, 2 });

    // Act
    ListNode* result = solution.removeNthFromEnd(head, 2);

    // Assert: [2]
    AssertLinkedListEquals({ 2 }, result);

    // Cleanup
    FreeLinkedList(result);
}

TEST_F(RemoveNthNodeFromLinkedList_19_Tests, RemoveNthFromEnd_TwoElements_RemoveSecond) {
    // Arrange: [1,2], n = 1
    ListNode* head = CreateLinkedList({ 1, 2 });

    // Act
    ListNode* result = solution.removeNthFromEnd(head, 1);

    // Assert: [1]
    AssertLinkedListEquals({ 1 }, result);

    // Cleanup
    FreeLinkedList(result);
}

#pragma endregion

#pragma region Different Value Patterns

TEST_F(RemoveNthNodeFromLinkedList_19_Tests, RemoveNthFromEnd_AllSameValues_RemovesCorrectPosition) {
    // Arrange: [5,5,5,5,5], n = 3
    ListNode* head = CreateLinkedList({ 5, 5, 5, 5, 5 });

    // Act
    ListNode* result = solution.removeNthFromEnd(head, 3);

    // Assert: [5,5,5,5]
    AssertLinkedListEquals({ 5, 5, 5, 5 }, result);

    // Cleanup
    FreeLinkedList(result);
}

TEST_F(RemoveNthNodeFromLinkedList_19_Tests, RemoveNthFromEnd_WithNegativeNumbers_RemovesCorrectly) {
    // Arrange: [-5,-3,-1,0,1,3,5], n = 4
    ListNode* head = CreateLinkedList({ -5, -3, -1, 0, 1, 3, 5 });

    // Act
    ListNode* result = solution.removeNthFromEnd(head, 4);

    // Assert: [-5,-3,-1,1,3,5] - removed 0
    AssertLinkedListEquals({ -5, -3, -1, 1, 3, 5 }, result);

    // Cleanup
    FreeLinkedList(result);
}

TEST_F(RemoveNthNodeFromLinkedList_19_Tests, RemoveNthFromEnd_WithZeros_RemovesCorrectly) {
    // Arrange: [0,0,1,2,3], n = 2
    ListNode* head = CreateLinkedList({ 0, 0, 1, 2, 3 });

    // Act
    ListNode* result = solution.removeNthFromEnd(head, 2);

    // Assert: [0,0,1,3] - removed 2
    AssertLinkedListEquals({ 0, 0, 1, 3 }, result);

    // Cleanup
    FreeLinkedList(result);
}

TEST_F(RemoveNthNodeFromLinkedList_19_Tests, RemoveNthFromEnd_LargeNumbers_RemovesCorrectly) {
    // Arrange: [100,200,300,400,500], n = 3
    ListNode* head = CreateLinkedList({ 100, 200, 300, 400, 500 });

    // Act
    ListNode* result = solution.removeNthFromEnd(head, 3);

    // Assert: [100,200,400,500] - removed 300
    AssertLinkedListEquals({ 100, 200, 400, 500 }, result);

    // Cleanup
    FreeLinkedList(result);
}

#pragma endregion

#pragma region Longer Lists

TEST_F(RemoveNthNodeFromLinkedList_19_Tests, RemoveNthFromEnd_LongList_RemovesNearBeginning) {
    // Arrange: [1,2,3,4,5,6,7,8,9,10,11,12,13,14,15], n = 14
    ListNode* head = CreateLinkedList({ 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 });

    // Act
    ListNode* result = solution.removeNthFromEnd(head, 14);

    // Assert: [1,3,4,5,6,7,8,9,10,11,12,13,14,15] - removed 2
    AssertLinkedListEquals({ 1, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 }, result);

    // Cleanup
    FreeLinkedList(result);
}

TEST_F(RemoveNthNodeFromLinkedList_19_Tests, RemoveNthFromEnd_LongList_RemovesInMiddle) {
    // Arrange: [1,2,3,4,5,6,7,8,9,10,11,12,13,14,15], n = 8
    ListNode* head = CreateLinkedList({ 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 });

    // Act
    ListNode* result = solution.removeNthFromEnd(head, 8);

    // Assert: [1,2,3,4,5,6,7,9,10,11,12,13,14,15] - removed 8
    AssertLinkedListEquals({ 1, 2, 3, 4, 5, 6, 7, 9, 10, 11, 12, 13, 14, 15 }, result);

    // Cleanup
    FreeLinkedList(result);
}

TEST_F(RemoveNthNodeFromLinkedList_19_Tests, RemoveNthFromEnd_LongList_RemovesNearEnd) {
    // Arrange: [1,2,3,4,5,6,7,8,9,10,11,12,13,14,15], n = 2
    ListNode* head = CreateLinkedList({ 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 });

    // Act
    ListNode* result = solution.removeNthFromEnd(head, 2);

    // Assert: [1,2,3,4,5,6,7,8,9,10,11,12,13,15] - removed 14
    AssertLinkedListEquals({ 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 15 }, result);

    // Cleanup
    FreeLinkedList(result);
}

TEST_F(RemoveNthNodeFromLinkedList_19_Tests, RemoveNthFromEnd_TwentyElements_RemovesCorrectly) {
    // Arrange: [1..20], n = 10
    ListNode* head = CreateLinkedList({ 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 });

    // Act
    ListNode* result = solution.removeNthFromEnd(head, 10);

    // Assert: removes 11 (10th from end)
    AssertLinkedListEquals({ 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 12, 13, 14, 15, 16, 17, 18, 19, 20 }, result);

    // Cleanup
    FreeLinkedList(result);
}

#pragma endregion

#pragma region Boundary Cases

TEST_F(RemoveNthNodeFromLinkedList_19_Tests, RemoveNthFromEnd_MaxConstraintSize_RemovesFirst) {
    // Arrange: 30 elements, n = 30 (remove first)
    ListNode* head = nullptr;
    ListNode* current = nullptr;

    for (int i = 1; i <= 30; i++) {
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
    ListNode* result = solution.removeNthFromEnd(head, 30);

    // Assert: [2,3,4,...,30]
    ASSERT_EQ(2, result->val);

    current = result;
    for (int i = 0; i < 28; i++) {
        current = current->next;
    }
    ASSERT_EQ(30, current->val);

    // Cleanup
    FreeLinkedList(result);
}

TEST_F(RemoveNthNodeFromLinkedList_19_Tests, RemoveNthFromEnd_MaxConstraintSize_RemovesLast) {
    // Arrange: 30 elements, n = 1 (remove last)
    ListNode* head = nullptr;
    ListNode* current = nullptr;

    for (int i = 1; i <= 30; i++) {
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
    ListNode* result = solution.removeNthFromEnd(head, 1);

    // Assert: [1,2,3,...,29]
    ASSERT_EQ(1, result->val);

    current = result;
    while (current->next != nullptr) {
        current = current->next;
    }
    ASSERT_EQ(29, current->val);

    // Cleanup
    FreeLinkedList(result);
}

#pragma endregion

#pragma region Error Cases

TEST_F(RemoveNthNodeFromLinkedList_19_Tests, RemoveNthFromEnd_NullHead_ReturnsNull) {
    // Arrange
    ListNode* head = nullptr;

    // Act
    ListNode* result = solution.removeNthFromEnd(head, 1);

    // Assert
    ASSERT_EQ(nullptr, result);
}

TEST_F(RemoveNthNodeFromLinkedList_19_Tests, RemoveNthFromEnd_NTooBig_ReturnsNull) {
    // Arrange: [1,2,3], n = 5 (larger than list)
    ListNode* head = CreateLinkedList({ 1, 2, 3 });

    // Act
    ListNode* result = solution.removeNthFromEnd(head, 5);

    // Assert: Should return nullptr when n is too large
    ASSERT_EQ(nullptr, result);

    // Note: Original list may need cleanup depending on implementation
    // For safety, attempt cleanup if result is not nullptr
    if (result != nullptr) {
        FreeLinkedList(result);
    }
    else {
        FreeLinkedList(head);
    }
}

TEST_F(RemoveNthNodeFromLinkedList_19_Tests, RemoveNthFromEnd_NZero_ReturnsNull) {
    // Arrange: [1,2,3], n = 0
    ListNode* head = CreateLinkedList({ 1, 2, 3 });

    // Act
    ListNode* result = solution.removeNthFromEnd(head, 0);

    // Assert: n = 0 is invalid
    ASSERT_EQ(nullptr, result);

    // Cleanup
    if (result != nullptr) {
        FreeLinkedList(result);
    }
    else {
        FreeLinkedList(head);
    }
}

#pragma endregion

#pragma region Duplicates

TEST_F(RemoveNthNodeFromLinkedList_19_Tests, RemoveNthFromEnd_WithDuplicates_RemovesCorrectPosition) {
    // Arrange: [1,2,2,3,3,3,4], n = 4
    ListNode* head = CreateLinkedList({ 1, 2, 2, 3, 3, 3, 4 });

    // Act
    ListNode* result = solution.removeNthFromEnd(head, 4);

    // Assert: [1,2,2,3,3,4] - removed one of the 3's
    AssertLinkedListEquals({ 1, 2, 2, 3, 3, 4 }, result);

    // Cleanup
    FreeLinkedList(result);
}

TEST_F(RemoveNthNodeFromLinkedList_19_Tests, RemoveNthFromEnd_AllDuplicates_RemovesCorrectPosition) {
    // Arrange: [7,7,7,7,7,7], n = 4
    ListNode* head = CreateLinkedList({ 7, 7, 7, 7, 7, 7 });

    // Act
    ListNode* result = solution.removeNthFromEnd(head, 4);

    // Assert: [7,7,7,7,7] - 5 elements remaining
    AssertLinkedListEquals({ 7, 7, 7, 7, 7 }, result);

    // Cleanup
    FreeLinkedList(result);
}

#pragma endregion