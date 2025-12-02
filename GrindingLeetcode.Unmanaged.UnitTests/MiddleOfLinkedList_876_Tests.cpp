#include "gtest/gtest.h"
#include "../LeetCodeProblems.UnmanagedCpp/MiddleOfLinkedList_876.h"
#include "../LeetCodeProblems.UnmanagedCpp/ListNode.h"
#include "TestHelpers.h"

using namespace LeetCodeTests;

class MiddleOfLinkedList_876_Tests : public ::testing::Test {
protected:
    MiddleOfLinkedListCpp_876 solution;

    void SetUp() override {
        // Called before each test
    }

    void TearDown() override {
        // Called after each test
    }
};

// LeetCode Examples

TEST_F(MiddleOfLinkedList_876_Tests, Example1_ReturnsMiddleNodeOddLength) {
    // Arrange: [1,2,3,4,5]
    ListNode* head = CreateLinkedList({ 1, 2, 3, 4, 5 });

    // Act
    ListNode* result = solution.middleNode(head);

    // Assert: [3,4,5] - middle node is 3
    AssertLinkedListEquals({ 3, 4, 5 }, result);

    // Cleanup
    FreeLinkedList(head);
}

TEST_F(MiddleOfLinkedList_876_Tests, Example2_ReturnsSecondMiddleNodeEvenLength) {
    // Arrange: [1,2,3,4,5,6]
    ListNode* head = CreateLinkedList({ 1, 2, 3, 4, 5, 6 });

    // Act
    ListNode* result = solution.middleNode(head);

    // Assert: [4,5,6] - when two middle nodes exist, return the second one
    AssertLinkedListEquals({ 4, 5, 6 }, result);

    // Cleanup
    FreeLinkedList(head);
}

// Edge Cases

TEST_F(MiddleOfLinkedList_876_Tests, SingleElement_ReturnsSameNode) {
    // Arrange: [1]
    ListNode* head = CreateLinkedList({ 1 });

    // Act
    ListNode* result = solution.middleNode(head);

    // Assert: [1]
    AssertLinkedListEquals({ 1 }, result);

    // Cleanup
    FreeLinkedList(head);
}

TEST_F(MiddleOfLinkedList_876_Tests, TwoElements_ReturnsSecondElement) {
    // Arrange: [1,2]
    ListNode* head = CreateLinkedList({ 1, 2 });

    // Act
    ListNode* result = solution.middleNode(head);

    // Assert: [2] - second middle node
    AssertLinkedListEquals({ 2 }, result);

    // Cleanup
    FreeLinkedList(head);
}

TEST_F(MiddleOfLinkedList_876_Tests, ThreeElements_ReturnsMiddleElement) {
    // Arrange: [1,2,3]
    ListNode* head = CreateLinkedList({ 1, 2, 3 });

    // Act
    ListNode* result = solution.middleNode(head);

    // Assert: [2,3]
    AssertLinkedListEquals({ 2, 3 }, result);

    // Cleanup
    FreeLinkedList(head);
}

// Odd Length Lists

TEST_F(MiddleOfLinkedList_876_Tests, SevenElements_ReturnsMiddleNode) {
    // Arrange: [1,2,3,4,5,6,7]
    ListNode* head = CreateLinkedList({ 1, 2, 3, 4, 5, 6, 7 });

    // Act
    ListNode* result = solution.middleNode(head);

    // Assert: [4,5,6,7]
    AssertLinkedListEquals({ 4, 5, 6, 7 }, result);

    // Cleanup
    FreeLinkedList(head);
}

// Even Length Lists

TEST_F(MiddleOfLinkedList_876_Tests, FourElements_ReturnsSecondMiddle) {
    // Arrange: [1,2,3,4]
    ListNode* head = CreateLinkedList({ 1, 2, 3, 4 });

    // Act
    ListNode* result = solution.middleNode(head);

    // Assert: [3,4]
    AssertLinkedListEquals({ 3, 4 }, result);

    // Cleanup
    FreeLinkedList(head);
}

TEST_F(MiddleOfLinkedList_876_Tests, EightElements_ReturnsSecondMiddle) {
    // Arrange: [1,2,3,4,5,6,7,8]
    ListNode* head = CreateLinkedList({ 1, 2, 3, 4, 5, 6, 7, 8 });

    // Act
    ListNode* result = solution.middleNode(head);

    // Assert: [5,6,7,8]
    AssertLinkedListEquals({ 5, 6, 7, 8 }, result);

    // Cleanup
    FreeLinkedList(head);
}

// Different Value Patterns

TEST_F(MiddleOfLinkedList_876_Tests, WithNegativeNumbers_ReturnsMiddleNode) {
    // Arrange: [-5,-3,-1,0,1,3,5]
    ListNode* head = CreateLinkedList({ -5, -3, -1, 0, 1, 3, 5 });

    // Act
    ListNode* result = solution.middleNode(head);

    // Assert: [0,1,3,5]
    AssertLinkedListEquals({ 0, 1, 3, 5 }, result);

    // Cleanup
    FreeLinkedList(head);
}

TEST_F(MiddleOfLinkedList_876_Tests, WithDuplicates_ReturnsMiddleNode) {
    // Arrange: [1,1,2,2,3,3]
    ListNode* head = CreateLinkedList({ 1, 1, 2, 2, 3, 3 });

    // Act
    ListNode* result = solution.middleNode(head);

    // Assert: [2,3,3]
    AssertLinkedListEquals({ 2, 3, 3 }, result);

    // Cleanup
    FreeLinkedList(head);
}

TEST_F(MiddleOfLinkedList_876_Tests, AllSameValues_ReturnsMiddleNode) {
    // Arrange: [5,5,5,5,5]
    ListNode* head = CreateLinkedList({ 5, 5, 5, 5, 5 });

    // Act
    ListNode* result = solution.middleNode(head);

    // Assert: [5,5,5]
    AssertLinkedListEquals({ 5, 5, 5 }, result);

    // Cleanup
    FreeLinkedList(head);
}

// Verify Original List Unchanged

TEST_F(MiddleOfLinkedList_876_Tests, DoesNotModifyOriginalList) {
    // Arrange: [1,2,3,4,5]
    ListNode* head = CreateLinkedList({ 1, 2, 3, 4, 5 });
    std::vector<int> originalValues = LinkedListToVector(head);

    // Act
    ListNode* result = solution.middleNode(head);

    // Assert: Original list unchanged
    std::vector<int> currentValues = LinkedListToVector(head);
    ASSERT_EQ(originalValues, currentValues);

    // Result is correct
    AssertLinkedListEquals({ 3, 4, 5 }, result);

    // Cleanup
    FreeLinkedList(head);
}