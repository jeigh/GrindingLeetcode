#include "gtest/gtest.h"
#include "ListNode.h"
#include "ReverseLinkedListII_ReversalAndReconnect_92.h"
#include "ReverseLinkedListII_MoveToFront_92.h"
#include "TestHelpers.h"

using namespace LeetCodeTests;

// Test fixture for ReverseLinkedListII_ReverseThenReconnect_92
class ReverseLinkedListII_ReverseThenReconnect_92_Tests : public ::testing::Test {
protected:
    ReverseLinkedListII_ReverseAndReconnect_92 solution;

    void TearDown() override {
        // Cleanup is handled by FreeLinkedList in each test
    }
};

// Test fixture for ReverseLinkedListII_MoveToFront_92
class ReverseLinkedListII_MoveToFront_92_Tests : public ::testing::Test {
protected:
    ReverseLinkedListII_MoveToFront_92 solution;

    void TearDown() override {
        // Cleanup is handled by FreeLinkedList in each test
    }
};

// Macro to define the same test for both implementations
#define DEFINE_TEST_FOR_BOTH(TestName, TestBody) \
    TEST_F(ReverseLinkedListII_ReverseThenReconnect_92_Tests, TestName) TestBody \
    TEST_F(ReverseLinkedListII_MoveToFront_92_Tests, TestName) TestBody


#pragma region LeetCode Examples

DEFINE_TEST_FOR_BOTH(ReverseBetween_Example1_ReversesMiddleThreeNodes, {
    // Arrange: [1,2,3,4,5], left = 2, right = 4
    ListNode * head = CreateLinkedList({ 1, 2, 3, 4, 5 });

// Act
ListNode* result = solution.reverseBetween(head, 2, 4);

// Assert: [1,4,3,2,5]
AssertLinkedListEquals({ 1, 4, 3, 2, 5 }, result);

// Cleanup
FreeLinkedList(result);
    })

    DEFINE_TEST_FOR_BOTH(ReverseBetween_Example2_ReversesSingleNode, {
    // Arrange: [5], left = 1, right = 1
    ListNode * head = CreateLinkedList({ 5 });

// Act
ListNode* result = solution.reverseBetween(head, 1, 1);

// Assert: [5] - no change
AssertLinkedListEquals({ 5 }, result);

// Cleanup
FreeLinkedList(result);
        })

#pragma endregion

#pragma region Reverse Entire List

    DEFINE_TEST_FOR_BOTH(ReverseBetween_ReverseEntireList_TwoNodes, {
    // Arrange: [1,2], left = 1, right = 2
    ListNode * head = CreateLinkedList({ 1, 2 });

// Act
ListNode* result = solution.reverseBetween(head, 1, 2);

// Assert: [2,1]
AssertLinkedListEquals({ 2, 1 }, result);

// Cleanup
FreeLinkedList(result);
        })

    DEFINE_TEST_FOR_BOTH(ReverseBetween_ReverseEntireList_ThreeNodes, {
    // Arrange: [1,2,3], left = 1, right = 3
    ListNode * head = CreateLinkedList({ 1, 2, 3 });

// Act
ListNode* result = solution.reverseBetween(head, 1, 3);

// Assert: [3,2,1]
AssertLinkedListEquals({ 3, 2, 1 }, result);

// Cleanup
FreeLinkedList(result);
        })

    DEFINE_TEST_FOR_BOTH(ReverseBetween_ReverseEntireList_FiveNodes, {
    // Arrange: [1,2,3,4,5], left = 1, right = 5
    ListNode * head = CreateLinkedList({ 1, 2, 3, 4, 5 });

// Act
ListNode* result = solution.reverseBetween(head, 1, 5);

// Assert: [5,4,3,2,1]
AssertLinkedListEquals({ 5, 4, 3, 2, 1 }, result);

// Cleanup
FreeLinkedList(result);
        })

    DEFINE_TEST_FOR_BOTH(ReverseBetween_ReverseEntireList_TenNodes, {
    // Arrange: [1,2,3,4,5,6,7,8,9,10], left = 1, right = 10
    ListNode * head = CreateLinkedList({ 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });

// Act
ListNode* result = solution.reverseBetween(head, 1, 10);

// Assert: [10,9,8,7,6,5,4,3,2,1]
AssertLinkedListEquals({ 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 }, result);

// Cleanup
FreeLinkedList(result);
        })

#pragma endregion

#pragma region Reverse From Start

    DEFINE_TEST_FOR_BOTH(ReverseBetween_ReverseFromStart_FirstTwo, {
    // Arrange: [1,2,3,4,5], left = 1, right = 2
    ListNode * head = CreateLinkedList({ 1, 2, 3, 4, 5 });

// Act
ListNode* result = solution.reverseBetween(head, 1, 2);

// Assert: [2,1,3,4,5]
AssertLinkedListEquals({ 2, 1, 3, 4, 5 }, result);

// Cleanup
FreeLinkedList(result);
        })

    DEFINE_TEST_FOR_BOTH(ReverseBetween_ReverseFromStart_FirstThree, {
    // Arrange: [1,2,3,4,5], left = 1, right = 3
    ListNode * head = CreateLinkedList({ 1, 2, 3, 4, 5 });

// Act
ListNode* result = solution.reverseBetween(head, 1, 3);

// Assert: [3,2,1,4,5]
AssertLinkedListEquals({ 3, 2, 1, 4, 5 }, result);

// Cleanup
FreeLinkedList(result);
        })

    DEFINE_TEST_FOR_BOTH(ReverseBetween_ReverseFromStart_FirstFour, {
    // Arrange: [1,2,3,4,5], left = 1, right = 4
    ListNode * head = CreateLinkedList({ 1, 2, 3, 4, 5 });

// Act
ListNode* result = solution.reverseBetween(head, 1, 4);

// Assert: [4,3,2,1,5]
AssertLinkedListEquals({ 4, 3, 2, 1, 5 }, result);

// Cleanup
FreeLinkedList(result);
        })

#pragma endregion

#pragma region Reverse To End

    DEFINE_TEST_FOR_BOTH(ReverseBetween_ReverseToEnd_LastTwo, {
    // Arrange: [1,2,3,4,5], left = 4, right = 5
    ListNode * head = CreateLinkedList({ 1, 2, 3, 4, 5 });

// Act
ListNode* result = solution.reverseBetween(head, 4, 5);

// Assert: [1,2,3,5,4]
AssertLinkedListEquals({ 1, 2, 3, 5, 4 }, result);

// Cleanup
FreeLinkedList(result);
        })

    DEFINE_TEST_FOR_BOTH(ReverseBetween_ReverseToEnd_LastThree, {
    // Arrange: [1,2,3,4,5], left = 3, right = 5
    ListNode * head = CreateLinkedList({ 1, 2, 3, 4, 5 });

// Act
ListNode* result = solution.reverseBetween(head, 3, 5);

// Assert: [1,2,5,4,3]
AssertLinkedListEquals({ 1, 2, 5, 4, 3 }, result);

// Cleanup
FreeLinkedList(result);
        })

    DEFINE_TEST_FOR_BOTH(ReverseBetween_ReverseToEnd_LastFour, {
    // Arrange: [1,2,3,4,5], left = 2, right = 5
    ListNode * head = CreateLinkedList({ 1, 2, 3, 4, 5 });

// Act
ListNode* result = solution.reverseBetween(head, 2, 5);

// Assert: [1,5,4,3,2]
AssertLinkedListEquals({ 1, 5, 4, 3, 2 }, result);

// Cleanup
FreeLinkedList(result);
        })

#pragma endregion

#pragma region Reverse Middle Sections

    DEFINE_TEST_FOR_BOTH(ReverseBetween_ReverseMiddle_TwoNodes, {
    // Arrange: [1,2,3,4,5], left = 2, right = 3
    ListNode * head = CreateLinkedList({ 1, 2, 3, 4, 5 });

// Act
ListNode* result = solution.reverseBetween(head, 2, 3);

// Assert: [1,3,2,4,5]
AssertLinkedListEquals({ 1, 3, 2, 4, 5 }, result);

// Cleanup
FreeLinkedList(result);
        })

    DEFINE_TEST_FOR_BOTH(ReverseBetween_ReverseMiddle_ThreeNodesInMiddle, {
    // Arrange: [1,2,3,4,5,6,7], left = 3, right = 5
    ListNode * head = CreateLinkedList({ 1, 2, 3, 4, 5, 6, 7 });

// Act
ListNode* result = solution.reverseBetween(head, 3, 5);

// Assert: [1,2,5,4,3,6,7]
AssertLinkedListEquals({ 1, 2, 5, 4, 3, 6, 7 }, result);

// Cleanup
FreeLinkedList(result);
        })

    DEFINE_TEST_FOR_BOTH(ReverseBetween_ReverseMiddle_FourNodesInMiddle, {
    // Arrange: [1,2,3,4,5,6,7,8], left = 3, right = 6
    ListNode * head = CreateLinkedList({ 1, 2, 3, 4, 5, 6, 7, 8 });

// Act
ListNode* result = solution.reverseBetween(head, 3, 6);

// Assert: [1,2,6,5,4,3,7,8]
AssertLinkedListEquals({ 1, 2, 6, 5, 4, 3, 7, 8 }, result);

// Cleanup
FreeLinkedList(result);
        })

#pragma endregion

#pragma region Single Node Reversals (left == right)

    DEFINE_TEST_FOR_BOTH(ReverseBetween_SingleNodeReversal_FirstNode, {
    // Arrange: [1,2,3,4,5], left = 1, right = 1
    ListNode * head = CreateLinkedList({ 1, 2, 3, 4, 5 });

// Act
ListNode* result = solution.reverseBetween(head, 1, 1);

// Assert: [1,2,3,4,5] - no change
AssertLinkedListEquals({ 1, 2, 3, 4, 5 }, result);

// Cleanup
FreeLinkedList(result);
        })

    DEFINE_TEST_FOR_BOTH(ReverseBetween_SingleNodeReversal_MiddleNode, {
    // Arrange: [1,2,3,4,5], left = 3, right = 3
    ListNode * head = CreateLinkedList({ 1, 2, 3, 4, 5 });

// Act
ListNode* result = solution.reverseBetween(head, 3, 3);

// Assert: [1,2,3,4,5] - no change
AssertLinkedListEquals({ 1, 2, 3, 4, 5 }, result);

// Cleanup
FreeLinkedList(result);
        })

    DEFINE_TEST_FOR_BOTH(ReverseBetween_SingleNodeReversal_LastNode, {
    // Arrange: [1,2,3,4,5], left = 5, right = 5
    ListNode * head = CreateLinkedList({ 1, 2, 3, 4, 5 });

// Act
ListNode* result = solution.reverseBetween(head, 5, 5);

// Assert: [1,2,3,4,5] - no change
AssertLinkedListEquals({ 1, 2, 3, 4, 5 }, result);

// Cleanup
FreeLinkedList(result);
        })

    DEFINE_TEST_FOR_BOTH(ReverseBetween_SingleNodeList_NoChange, {
    // Arrange: [1], left = 1, right = 1
    ListNode * head = CreateLinkedList({ 1 });

// Act
ListNode* result = solution.reverseBetween(head, 1, 1);

// Assert: [1] - no change
AssertLinkedListEquals({ 1 }, result);

// Cleanup
FreeLinkedList(result);
        })

#pragma endregion

#pragma region Two Node Lists

    DEFINE_TEST_FOR_BOTH(ReverseBetween_TwoNodeList_ReverseBoth, {
    // Arrange: [1,2], left = 1, right = 2
    ListNode * head = CreateLinkedList({ 1, 2 });

// Act
ListNode* result = solution.reverseBetween(head, 1, 2);

// Assert: [2,1]
AssertLinkedListEquals({ 2, 1 }, result);

// Cleanup
FreeLinkedList(result);
        })

    DEFINE_TEST_FOR_BOTH(ReverseBetween_TwoNodeList_ReverseFirst, {
    // Arrange: [1,2], left = 1, right = 1
    ListNode * head = CreateLinkedList({ 1, 2 });

// Act
ListNode* result = solution.reverseBetween(head, 1, 1);

// Assert: [1,2] - no change
AssertLinkedListEquals({ 1, 2 }, result);

// Cleanup
FreeLinkedList(result);
        })

    DEFINE_TEST_FOR_BOTH(ReverseBetween_TwoNodeList_ReverseSecond, {
    // Arrange: [1,2], left = 2, right = 2
    ListNode * head = CreateLinkedList({ 1, 2 });

// Act
ListNode* result = solution.reverseBetween(head, 2, 2);

// Assert: [1,2] - no change
AssertLinkedListEquals({ 1, 2 }, result);

// Cleanup
FreeLinkedList(result);
        })

#pragma endregion

#pragma region Different Value Patterns

    DEFINE_TEST_FOR_BOTH(ReverseBetween_NegativeValues_ReversesCorrectly, {
    // Arrange: [-5,-4,-3,-2,-1], left = 2, right = 4
    ListNode * head = CreateLinkedList({ -5, -4, -3, -2, -1 });

// Act
ListNode* result = solution.reverseBetween(head, 2, 4);

// Assert: [-5,-2,-3,-4,-1]
AssertLinkedListEquals({ -5, -2, -3, -4, -1 }, result);

// Cleanup
FreeLinkedList(result);
        })

    DEFINE_TEST_FOR_BOTH(ReverseBetween_MixedValues_ReversesCorrectly, {
    // Arrange: [-2,-1,0,1,2], left = 2, right = 4
    ListNode * head = CreateLinkedList({ -2, -1, 0, 1, 2 });

// Act
ListNode* result = solution.reverseBetween(head, 2, 4);

// Assert: [-2,1,0,-1,2]
AssertLinkedListEquals({ -2, 1, 0, -1, 2 }, result);

// Cleanup
FreeLinkedList(result);
        })

    DEFINE_TEST_FOR_BOTH(ReverseBetween_WithZeros_ReversesCorrectly, {
    // Arrange: [0,0,1,2,3], left = 1, right = 3
    ListNode * head = CreateLinkedList({ 0, 0, 1, 2, 3 });

// Act
ListNode* result = solution.reverseBetween(head, 1, 3);

// Assert: [1,0,0,2,3]
AssertLinkedListEquals({ 1, 0, 0, 2, 3 }, result);

// Cleanup
FreeLinkedList(result);
        })

    DEFINE_TEST_FOR_BOTH(ReverseBetween_AllSameValues_ReversesCorrectly, {
    // Arrange: [5,5,5,5,5], left = 2, right = 4
    ListNode * head = CreateLinkedList({ 5, 5, 5, 5, 5 });

// Act
ListNode* result = solution.reverseBetween(head, 2, 4);

// Assert: [5,5,5,5,5] - looks the same but order reversed
AssertLinkedListEquals({ 5, 5, 5, 5, 5 }, result);

// Cleanup
FreeLinkedList(result);
        })

    DEFINE_TEST_FOR_BOTH(ReverseBetween_LargeNumbers_ReversesCorrectly, {
    // Arrange: [100,200,300,400,500], left = 2, right = 4
    ListNode * head = CreateLinkedList({ 100, 200, 300, 400, 500 });

// Act
ListNode* result = solution.reverseBetween(head, 2, 4);

// Assert: [100,400,300,200,500]
AssertLinkedListEquals({ 100, 400, 300, 200, 500 }, result);

// Cleanup
FreeLinkedList(result);
        })

#pragma endregion

#pragma region Longer Lists

    DEFINE_TEST_FOR_BOTH(ReverseBetween_TenElements_ReverseMiddleFive, {
    // Arrange: [1,2,3,4,5,6,7,8,9,10], left = 3, right = 7
    ListNode * head = CreateLinkedList({ 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });

// Act
ListNode* result = solution.reverseBetween(head, 3, 7);

// Assert: [1,2,7,6,5,4,3,8,9,10]
AssertLinkedListEquals({ 1, 2, 7, 6, 5, 4, 3, 8, 9, 10 }, result);

// Cleanup
FreeLinkedList(result);
        })

    DEFINE_TEST_FOR_BOTH(ReverseBetween_FifteenElements_ReverseFromSecondToFourteenth, {
    // Arrange: [1,2,3,4,5,6,7,8,9,10,11,12,13,14,15], left = 2, right = 14
    ListNode * head = CreateLinkedList({ 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 });

// Act
ListNode* result = solution.reverseBetween(head, 2, 14);

// Assert: [1,14,13,12,11,10,9,8,7,6,5,4,3,2,15]
AssertLinkedListEquals({ 1, 14, 13, 12, 11, 10, 9, 8, 7, 6, 5, 4, 3, 2, 15 }, result);

// Cleanup
FreeLinkedList(result);
        })

    DEFINE_TEST_FOR_BOTH(ReverseBetween_TwentyElements_ReverseMiddleTen, {
    // Arrange: [1..20], left = 6, right = 15
    ListNode * head = CreateLinkedList({ 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 });

// Act
ListNode* result = solution.reverseBetween(head, 6, 15);

// Assert: [1,2,3,4,5,15,14,13,12,11,10,9,8,7,6,16,17,18,19,20]
AssertLinkedListEquals({ 1, 2, 3, 4, 5, 15, 14, 13, 12, 11, 10, 9, 8, 7, 6, 16, 17, 18, 19, 20 }, result);

// Cleanup
FreeLinkedList(result);
        })

#pragma endregion

#pragma region Adjacent Positions

    DEFINE_TEST_FOR_BOTH(ReverseBetween_AdjacentPositions_FirstTwo, {
    // Arrange: [1,2,3,4,5], left = 1, right = 2
    ListNode * head = CreateLinkedList({ 1, 2, 3, 4, 5 });

// Act
ListNode* result = solution.reverseBetween(head, 1, 2);

// Assert: [2,1,3,4,5]
AssertLinkedListEquals({ 2, 1, 3, 4, 5 }, result);

// Cleanup
FreeLinkedList(result);
        })

    DEFINE_TEST_FOR_BOTH(ReverseBetween_AdjacentPositions_SecondAndThird, {
    // Arrange: [1,2,3,4,5], left = 2, right = 3
    ListNode * head = CreateLinkedList({ 1, 2, 3, 4, 5 });

// Act
ListNode* result = solution.reverseBetween(head, 2, 3);

// Assert: [1,3,2,4,5]
AssertLinkedListEquals({ 1, 3, 2, 4, 5 }, result);

// Cleanup
FreeLinkedList(result);
        })

    DEFINE_TEST_FOR_BOTH(ReverseBetween_AdjacentPositions_ThirdAndFourth, {
    // Arrange: [1,2,3,4,5], left = 3, right = 4
    ListNode * head = CreateLinkedList({ 1, 2, 3, 4, 5 });

// Act
ListNode* result = solution.reverseBetween(head, 3, 4);

// Assert: [1,2,4,3,5]
AssertLinkedListEquals({ 1, 2, 4, 3, 5 }, result);

// Cleanup
FreeLinkedList(result);
        })

    DEFINE_TEST_FOR_BOTH(ReverseBetween_AdjacentPositions_LastTwo, {
    // Arrange: [1,2,3,4,5], left = 4, right = 5
    ListNode * head = CreateLinkedList({ 1, 2, 3, 4, 5 });

// Act
ListNode* result = solution.reverseBetween(head, 4, 5);

// Assert: [1,2,3,5,4]
AssertLinkedListEquals({ 1, 2, 3, 5, 4 }, result);

// Cleanup
FreeLinkedList(result);
        })

#pragma endregion

#pragma region Edge Cases with Three Nodes

    DEFINE_TEST_FOR_BOTH(ReverseBetween_ThreeNodeList_ReverseAll, {
    // Arrange: [1,2,3], left = 1, right = 3
    ListNode * head = CreateLinkedList({ 1, 2, 3 });

// Act
ListNode* result = solution.reverseBetween(head, 1, 3);

// Assert: [3,2,1]
AssertLinkedListEquals({ 3, 2, 1 }, result);

// Cleanup
FreeLinkedList(result);
        })

    DEFINE_TEST_FOR_BOTH(ReverseBetween_ThreeNodeList_ReverseFirstTwo, {
    // Arrange: [1,2,3], left = 1, right = 2
    ListNode * head = CreateLinkedList({ 1, 2, 3 });

// Act
ListNode* result = solution.reverseBetween(head, 1, 2);

// Assert: [2,1,3]
AssertLinkedListEquals({ 2, 1, 3 }, result);

// Cleanup
FreeLinkedList(result);
        })

    DEFINE_TEST_FOR_BOTH(ReverseBetween_ThreeNodeList_ReverseLastTwo, {
    // Arrange: [1,2,3], left = 2, right = 3
    ListNode * head = CreateLinkedList({ 1, 2, 3 });

// Act
ListNode* result = solution.reverseBetween(head, 2, 3);

// Assert: [1,3,2]
AssertLinkedListEquals({ 1, 3, 2 }, result);

// Cleanup
FreeLinkedList(result);
        })

#pragma endregion

#pragma region Boundary Constraints

    DEFINE_TEST_FOR_BOTH(ReverseBetween_LargeList_ReverseMiddleSection, {
    // Arrange: Create [1..100], left = 25, right = 75
    std::vector<int> values;
    for (int i = 1; i <= 100; i++) {
        values.push_back(i);
    }

    ListNode* head = nullptr;
    ListNode* current = nullptr;
    for (int val : values) {
        ListNode* newNode = new ListNode(val);
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
    ListNode* result = solution.reverseBetween(head, 25, 75);

    // Assert: [1..24, 75..25, 76..100]
    std::vector<int> expected;
    for (int i = 1; i <= 24; i++) expected.push_back(i);
    for (int i = 75; i >= 25; i--) expected.push_back(i);
    for (int i = 76; i <= 100; i++) expected.push_back(i);

    std::vector<int> actual = LinkedListToVector(result);
    ASSERT_EQ(expected, actual);

    // Cleanup
    FreeLinkedList(result);
        })

    DEFINE_TEST_FOR_BOTH(ReverseBetween_LargeList_ReverseLargeMiddle, {
    // Arrange: Create [1..200], left = 10, right = 190
    std::vector<int> values;
    for (int i = 1; i <= 200; i++) {
        values.push_back(i);
    }

    ListNode* head = nullptr;
    ListNode* current = nullptr;
    for (int val : values) {
        ListNode* newNode = new ListNode(val);
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
    ListNode* result = solution.reverseBetween(head, 10, 190);

    // Assert: [1..9, 190..10, 191..200]
    std::vector<int> expected;
    for (int i = 1; i <= 9; i++) expected.push_back(i);
    for (int i = 190; i >= 10; i--) expected.push_back(i);
    for (int i = 191; i <= 200; i++) expected.push_back(i);

    std::vector<int> actual = LinkedListToVector(result);
    ASSERT_EQ(expected, actual);

    // Cleanup
    FreeLinkedList(result);
        })

#pragma endregion

#pragma region Special Patterns

    DEFINE_TEST_FOR_BOTH(ReverseBetween_DescendingOrder_ReversesMiddle, {
    // Arrange: [10,9,8,7,6,5,4,3,2,1], left = 3, right = 7
    ListNode * head = CreateLinkedList({ 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 });

// Act
ListNode* result = solution.reverseBetween(head, 3, 7);

// Assert: [10,9,4,5,6,7,8,3,2,1]
AssertLinkedListEquals({ 10, 9, 4, 5, 6, 7, 8, 3, 2, 1 }, result);

// Cleanup
FreeLinkedList(result);
        })

    DEFINE_TEST_FOR_BOTH(ReverseBetween_AlternatingValues_ReversesMiddle, {
    // Arrange: [1,10,2,9,3,8,4,7,5,6], left = 3, right = 8
    ListNode * head = CreateLinkedList({ 1, 10, 2, 9, 3, 8, 4, 7, 5, 6 });

// Act
ListNode* result = solution.reverseBetween(head, 3, 8);

// Assert: [1,10,7,4,8,3,9,2,5,6]
AssertLinkedListEquals({ 1, 10, 7, 4, 8, 3, 9, 2, 5, 6 }, result);

// Cleanup
FreeLinkedList(result);
        })

    DEFINE_TEST_FOR_BOTH(ReverseBetween_WithDuplicates_ReversesCorrectly, {
    // Arrange: [1,2,2,3,3,3,4,4,4,4], left = 3, right = 8
    ListNode * head = CreateLinkedList({ 1, 2, 2, 3, 3, 3, 4, 4, 4, 4 });

// Act
ListNode* result = solution.reverseBetween(head, 3, 8);

// Assert: [1,2,4,4,3,3,3,2,4,4]
AssertLinkedListEquals({ 1, 2, 4, 4, 3, 3, 3, 2, 4, 4 }, result);

// Cleanup
FreeLinkedList(result);
        })

#pragma endregion

#pragma region Multiple Reversal Positions

    DEFINE_TEST_FOR_BOTH(ReverseBetween_NearBeginning_Position2To4, {
    // Arrange: [1,2,3,4,5,6,7,8,9,10], left = 2, right = 4
    ListNode * head = CreateLinkedList({ 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });

// Act
ListNode* result = solution.reverseBetween(head, 2, 4);

// Assert: [1,4,3,2,5,6,7,8,9,10]
AssertLinkedListEquals({ 1, 4, 3, 2, 5, 6, 7, 8, 9, 10 }, result);

// Cleanup
FreeLinkedList(result);
        })

    DEFINE_TEST_FOR_BOTH(ReverseBetween_NearEnd_Position7To9, {
    // Arrange: [1,2,3,4,5,6,7,8,9,10], left = 7, right = 9
    ListNode * head = CreateLinkedList({ 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });

// Act
ListNode* result = solution.reverseBetween(head, 7, 9);

// Assert: [1,2,3,4,5,6,9,8,7,10]
AssertLinkedListEquals({ 1, 2, 3, 4, 5, 6, 9, 8, 7, 10 }, result);

// Cleanup
FreeLinkedList(result);
        })

    DEFINE_TEST_FOR_BOTH(ReverseBetween_ExactMiddle_Position4To7, {
    // Arrange: [1,2,3,4,5,6,7,8,9,10], left = 4, right = 7
    ListNode * head = CreateLinkedList({ 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });

// Act
ListNode* result = solution.reverseBetween(head, 4, 7);

// Assert: [1,2,3,7,6,5,4,8,9,10]
AssertLinkedListEquals({ 1, 2, 3, 7, 6, 5, 4, 8, 9, 10 }, result);

// Cleanup
FreeLinkedList(result);
        })

#pragma endregion