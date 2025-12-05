#include "gtest/gtest.h"
#include "ListNode.h"
#include "AddTwoNumbers_2.h"
#include "TestHelpers.h"

using namespace LeetCodeTests;

class AddTwoNumbers_2_Tests : public ::testing::Test {
protected:
    AddTwoNumbers_2 solution;

    void TearDown() override {
        // Cleanup is handled by FreeLinkedList in each test
    }
};

#pragma region LeetCode Examples

// Test 1: LeetCode Example 1 - 342 + 465 = 807
TEST_F(AddTwoNumbers_2_Tests, AddTwoNumbers_Example1_Returns807) {
    // Arrange: 342 + 465 = 807 (stored as 2->4->3 and 5->6->4)
    ListNode* l1 = CreateLinkedList({ 2, 4, 3 });
    ListNode* l2 = CreateLinkedList({ 5, 6, 4 });

    // Act
    ListNode* result = solution.addTwoNumbers(l1, l2);

    // Assert: 7->0->8
    AssertLinkedListEquals({ 7, 0, 8 }, result);

    // Cleanup
    FreeLinkedList(result);
}

// Test 2: LeetCode Example 2 - 0 + 0 = 0
TEST_F(AddTwoNumbers_2_Tests, AddTwoNumbers_Example2_ZeroPlusZero_ReturnsZero) {
    // Arrange: 0 + 0 = 0
    ListNode* l1 = CreateLinkedList({ 0 });
    ListNode* l2 = CreateLinkedList({ 0 });

    // Act
    ListNode* result = solution.addTwoNumbers(l1, l2);

    // Assert: 0
    AssertLinkedListEquals({ 0 }, result);

    // Cleanup
    FreeLinkedList(result);
}

// Test 3: LeetCode Example 3 - 9999999 + 9999 = 10009998
TEST_F(AddTwoNumbers_2_Tests, AddTwoNumbers_Example3_LargeDifferentLengths_ReturnsCorrectSum) {
    // Arrange: 9999999 + 9999 = 10009998 (stored reversed)
    ListNode* l1 = CreateLinkedList({ 9, 9, 9, 9, 9, 9, 9 });
    ListNode* l2 = CreateLinkedList({ 9, 9, 9, 9 });

    // Act
    ListNode* result = solution.addTwoNumbers(l1, l2);

    // Assert: 8->9->9->9->0->0->0->1
    AssertLinkedListEquals({ 8, 9, 9, 9, 0, 0, 0, 1 }, result);

    // Cleanup
    FreeLinkedList(result);
}

#pragma endregion

#pragma region Basic Cases

TEST_F(AddTwoNumbers_2_Tests, AddTwoNumbers_SingleDigitNoCarry_ReturnsSum) {
    // Arrange: 2 + 3 = 5
    ListNode* l1 = CreateLinkedList({ 2 });
    ListNode* l2 = CreateLinkedList({ 3 });

    // Act
    ListNode* result = solution.addTwoNumbers(l1, l2);

    // Assert: 5
    AssertLinkedListEquals({ 5 }, result);

    // Cleanup
    FreeLinkedList(result);
}

TEST_F(AddTwoNumbers_2_Tests, AddTwoNumbers_SingleDigitWithCarry_ReturnsTwoDigits) {
    // Arrange: 5 + 5 = 10
    ListNode* l1 = CreateLinkedList({ 5 });
    ListNode* l2 = CreateLinkedList({ 5 });

    // Act
    ListNode* result = solution.addTwoNumbers(l1, l2);

    // Assert: 0->1
    AssertLinkedListEquals({ 0, 1 }, result);

    // Cleanup
    FreeLinkedList(result);
}

TEST_F(AddTwoNumbers_2_Tests, AddTwoNumbers_TwoDigitsNoCarry_ReturnsSum) {
    // Arrange: 12 + 23 = 35 (stored as 2->1 and 3->2)
    ListNode* l1 = CreateLinkedList({ 2, 1 });
    ListNode* l2 = CreateLinkedList({ 3, 2 });

    // Act
    ListNode* result = solution.addTwoNumbers(l1, l2);

    // Assert: 5->3
    AssertLinkedListEquals({ 5, 3 }, result);

    // Cleanup
    FreeLinkedList(result);
}

TEST_F(AddTwoNumbers_2_Tests, AddTwoNumbers_TwoDigitsWithCarry_ReturnsCorrectSum) {
    // Arrange: 89 + 99 = 188 (stored as 9->8 and 9->9)
    ListNode* l1 = CreateLinkedList({ 9, 8 });
    ListNode* l2 = CreateLinkedList({ 9, 9 });

    // Act
    ListNode* result = solution.addTwoNumbers(l1, l2);

    // Assert: 8->8->1
    AssertLinkedListEquals({ 8, 8, 1 }, result);

    // Cleanup
    FreeLinkedList(result);
}

#pragma endregion

#pragma region Carry Propagation

TEST_F(AddTwoNumbers_2_Tests, AddTwoNumbers_CarryPropagatesMultipleDigits_ReturnsCorrectSum) {
    // Arrange: 999 + 1 = 1000 (stored as 9->9->9 and 1)
    ListNode* l1 = CreateLinkedList({ 9, 9, 9 });
    ListNode* l2 = CreateLinkedList({ 1 });

    // Act
    ListNode* result = solution.addTwoNumbers(l1, l2);

    // Assert: 0->0->0->1
    AssertLinkedListEquals({ 0, 0, 0, 1 }, result);

    // Cleanup
    FreeLinkedList(result);
}

TEST_F(AddTwoNumbers_2_Tests, AddTwoNumbers_CarryAtEnd_ReturnsExtraDigit) {
    // Arrange: 99 + 1 = 100 (stored as 9->9 and 1)
    ListNode* l1 = CreateLinkedList({ 9, 9 });
    ListNode* l2 = CreateLinkedList({ 1 });

    // Act
    ListNode* result = solution.addTwoNumbers(l1, l2);

    // Assert: 0->0->1
    AssertLinkedListEquals({ 0, 0, 1 }, result);

    // Cleanup
    FreeLinkedList(result);
}

TEST_F(AddTwoNumbers_2_Tests, AddTwoNumbers_BothAllNines_ReturnsCorrectSum) {
    // Arrange: 99 + 99 = 198 (stored as 9->9 and 9->9)
    ListNode* l1 = CreateLinkedList({ 9, 9 });
    ListNode* l2 = CreateLinkedList({ 9, 9 });

    // Act
    ListNode* result = solution.addTwoNumbers(l1, l2);

    // Assert: 8->9->1
    AssertLinkedListEquals({ 8, 9, 1 }, result);

    // Cleanup
    FreeLinkedList(result);
}

TEST_F(AddTwoNumbers_2_Tests, AddTwoNumbers_CarryInMiddle_ReturnsCorrectSum) {
    // Arrange: 195 + 6 = 201 (stored as 5->9->1 and 6)
    ListNode* l1 = CreateLinkedList({ 5, 9, 1 });
    ListNode* l2 = CreateLinkedList({ 6 });

    // Act
    ListNode* result = solution.addTwoNumbers(l1, l2);

    // Assert: 1->0->2
    AssertLinkedListEquals({ 1, 0, 2 }, result);

    // Cleanup
    FreeLinkedList(result);
}

#pragma endregion

#pragma region Different Lengths

TEST_F(AddTwoNumbers_2_Tests, AddTwoNumbers_FirstLongerThanSecond_ReturnsCorrectSum) {
    // Arrange: 12345 + 67 = 12412 (stored reversed)
    ListNode* l1 = CreateLinkedList({ 5, 4, 3, 2, 1 });
    ListNode* l2 = CreateLinkedList({ 7, 6 });

    // Act
    ListNode* result = solution.addTwoNumbers(l1, l2);

    // Assert: 2->1->4->2->1
    AssertLinkedListEquals({ 2, 1, 4, 2, 1 }, result);

    // Cleanup
    FreeLinkedList(result);
}

TEST_F(AddTwoNumbers_2_Tests, AddTwoNumbers_SecondLongerThanFirst_ReturnsCorrectSum) {
    // Arrange: 67 + 12345 = 12412 (stored reversed)
    ListNode* l1 = CreateLinkedList({ 7, 6 });
    ListNode* l2 = CreateLinkedList({ 5, 4, 3, 2, 1 });

    // Act
    ListNode* result = solution.addTwoNumbers(l1, l2);

    // Assert: 2->1->4->2->1
    AssertLinkedListEquals({ 2, 1, 4, 2, 1 }, result);

    // Cleanup
    FreeLinkedList(result);
}

TEST_F(AddTwoNumbers_2_Tests, AddTwoNumbers_OneSingleDigitOtherMultiple_ReturnsCorrectSum) {
    // Arrange: 5 + 123 = 128 (stored as 5 and 3->2->1)
    ListNode* l1 = CreateLinkedList({ 5 });
    ListNode* l2 = CreateLinkedList({ 3, 2, 1 });

    // Act
    ListNode* result = solution.addTwoNumbers(l1, l2);

    // Assert: 8->2->1
    AssertLinkedListEquals({ 8, 2, 1 }, result);

    // Cleanup
    FreeLinkedList(result);
}

TEST_F(AddTwoNumbers_2_Tests, AddTwoNumbers_VeryDifferentLengths_ReturnsCorrectSum) {
    // Arrange: 9 + 9999999 = 10000008 (stored reversed)
    ListNode* l1 = CreateLinkedList({ 9 });
    ListNode* l2 = CreateLinkedList({ 9, 9, 9, 9, 9, 9, 9 });

    // Act
    ListNode* result = solution.addTwoNumbers(l1, l2);

    // Assert: 8->0->0->0->0->0->0->1
    AssertLinkedListEquals({ 8, 0, 0, 0, 0, 0, 0, 1 }, result);

    // Cleanup
    FreeLinkedList(result);
}

#pragma endregion

#pragma region Zero Cases

TEST_F(AddTwoNumbers_2_Tests, AddTwoNumbers_ZeroPlusNumber_ReturnsNumber) {
    // Arrange: 0 + 123 = 123
    ListNode* l1 = CreateLinkedList({ 0 });
    ListNode* l2 = CreateLinkedList({ 3, 2, 1 });

    // Act
    ListNode* result = solution.addTwoNumbers(l1, l2);

    // Assert: 3->2->1
    AssertLinkedListEquals({ 3, 2, 1 }, result);

    // Cleanup
    FreeLinkedList(result);
}

TEST_F(AddTwoNumbers_2_Tests, AddTwoNumbers_NumberPlusZero_ReturnsNumber) {
    // Arrange: 456 + 0 = 456
    ListNode* l1 = CreateLinkedList({ 6, 5, 4 });
    ListNode* l2 = CreateLinkedList({ 0 });

    // Act
    ListNode* result = solution.addTwoNumbers(l1, l2);

    // Assert: 6->5->4
    AssertLinkedListEquals({ 6, 5, 4 }, result);

    // Cleanup
    FreeLinkedList(result);
}

TEST_F(AddTwoNumbers_2_Tests, AddTwoNumbers_WithZerosInMiddle_ReturnsCorrectSum) {
    // Arrange: 102 + 203 = 305 (stored as 2->0->1 and 3->0->2)
    ListNode* l1 = CreateLinkedList({ 2, 0, 1 });
    ListNode* l2 = CreateLinkedList({ 3, 0, 2 });

    // Act
    ListNode* result = solution.addTwoNumbers(l1, l2);

    // Assert: 5->0->3
    AssertLinkedListEquals({ 5, 0, 3 }, result);

    // Cleanup
    FreeLinkedList(result);
}

TEST_F(AddTwoNumbers_2_Tests, AddTwoNumbers_ResultHasZerosInMiddle_ReturnsCorrectSum) {
    // Arrange: 101 + 909 = 1010 (stored as 1->0->1 and 9->0->9)
    ListNode* l1 = CreateLinkedList({ 1, 0, 1 });
    ListNode* l2 = CreateLinkedList({ 9, 0, 9 });

    // Act
    ListNode* result = solution.addTwoNumbers(l1, l2);

    // Assert: 0->1->0->1
    AssertLinkedListEquals({ 0, 1, 0, 1 }, result);

    // Cleanup
    FreeLinkedList(result);
}

#pragma endregion

#pragma region Edge Cases

TEST_F(AddTwoNumbers_2_Tests, AddTwoNumbers_BothSingleDigitMax_ReturnsCorrectSum) {
    // Arrange: 9 + 9 = 18
    ListNode* l1 = CreateLinkedList({ 9 });
    ListNode* l2 = CreateLinkedList({ 9 });

    // Act
    ListNode* result = solution.addTwoNumbers(l1, l2);

    // Assert: 8->1
    AssertLinkedListEquals({ 8, 1 }, result);

    // Cleanup
    FreeLinkedList(result);
}

TEST_F(AddTwoNumbers_2_Tests, AddTwoNumbers_AllDigitsMax_ReturnsCorrectSum) {
    // Arrange: 9999 + 9999 = 19998
    ListNode* l1 = CreateLinkedList({ 9, 9, 9, 9 });
    ListNode* l2 = CreateLinkedList({ 9, 9, 9, 9 });

    // Act
    ListNode* result = solution.addTwoNumbers(l1, l2);

    // Assert: 8->9->9->9->1
    AssertLinkedListEquals({ 8, 9, 9, 9, 1 }, result);

    // Cleanup
    FreeLinkedList(result);
}

TEST_F(AddTwoNumbers_2_Tests, AddTwoNumbers_AlternatingDigits_ReturnsCorrectSum) {
    // Arrange: 135 + 246 = 381 (stored as 5->3->1 and 6->4->2)
    ListNode* l1 = CreateLinkedList({ 5, 3, 1 });
    ListNode* l2 = CreateLinkedList({ 6, 4, 2 });

    // Act
    ListNode* result = solution.addTwoNumbers(l1, l2);

    // Assert: 1->8->3
    AssertLinkedListEquals({ 1, 8, 3 }, result);

    // Cleanup
    FreeLinkedList(result);
}

TEST_F(AddTwoNumbers_2_Tests, AddTwoNumbers_SameNumber_ReturnsDouble) {
    // Arrange: 555 + 555 = 1110 (stored as 5->5->5 and 5->5->5)
    ListNode* l1 = CreateLinkedList({ 5, 5, 5 });
    ListNode* l2 = CreateLinkedList({ 5, 5, 5 });

    // Act
    ListNode* result = solution.addTwoNumbers(l1, l2);

    // Assert: 0->1->1->1
    AssertLinkedListEquals({ 0, 1, 1, 1 }, result);

    // Cleanup
    FreeLinkedList(result);
}

#pragma endregion

#pragma region Large Numbers

TEST_F(AddTwoNumbers_2_Tests, AddTwoNumbers_LargeNumbers_ReturnsCorrectSum) {
    // Arrange: 123456789 + 987654321 = 1111111110 (stored reversed)
    ListNode* l1 = CreateLinkedList({ 9, 8, 7, 6, 5, 4, 3, 2, 1 });
    ListNode* l2 = CreateLinkedList({ 1, 2, 3, 4, 5, 6, 7, 8, 9 });

    // Act
    ListNode* result = solution.addTwoNumbers(l1, l2);

    // Assert: 0->1->1->1->1->1->1->1->1->1
    AssertLinkedListEquals({ 0, 1, 1, 1, 1, 1, 1, 1, 1, 1 }, result);

    // Cleanup
    FreeLinkedList(result);
}

TEST_F(AddTwoNumbers_2_Tests, AddTwoNumbers_VeryLargeNumbers_ReturnsCorrectSum) {
    // Arrange: 99999999 + 1 = 100000000 (stored reversed)
    ListNode* l1 = CreateLinkedList({ 9, 9, 9, 9, 9, 9, 9, 9 });
    ListNode* l2 = CreateLinkedList({ 1 });

    // Act
    ListNode* result = solution.addTwoNumbers(l1, l2);

    // Assert: 0->0->0->0->0->0->0->0->1
    AssertLinkedListEquals({ 0, 0, 0, 0, 0, 0, 0, 0, 1 }, result);

    // Cleanup
    FreeLinkedList(result);
}

TEST_F(AddTwoNumbers_2_Tests, AddTwoNumbers_ManyDigitsNoCarry_ReturnsCorrectSum) {
    // Arrange: 11111111 + 22222222 = 33333333 (stored reversed)
    ListNode* l1 = CreateLinkedList({ 1, 1, 1, 1, 1, 1, 1, 1 });
    ListNode* l2 = CreateLinkedList({ 2, 2, 2, 2, 2, 2, 2, 2 });

    // Act
    ListNode* result = solution.addTwoNumbers(l1, l2);

    // Assert: 3->3->3->3->3->3->3->3
    AssertLinkedListEquals({ 3, 3, 3, 3, 3, 3, 3, 3 }, result);

    // Cleanup
    FreeLinkedList(result);
}

TEST_F(AddTwoNumbers_2_Tests, AddTwoNumbers_ManyDigitsWithCarries_ReturnsCorrectSum) {
    // Arrange: 88888888 + 11111111 = 99999999 (stored reversed)
    ListNode* l1 = CreateLinkedList({ 8, 8, 8, 8, 8, 8, 8, 8 });
    ListNode* l2 = CreateLinkedList({ 1, 1, 1, 1, 1, 1, 1, 1 });

    // Act
    ListNode* result = solution.addTwoNumbers(l1, l2);

    // Assert: 9->9->9->9->9->9->9->9
    AssertLinkedListEquals({ 9, 9, 9, 9, 9, 9, 9, 9 }, result);

    // Cleanup
    FreeLinkedList(result);
}

#pragma endregion

#pragma region Specific Patterns

TEST_F(AddTwoNumbers_2_Tests, AddTwoNumbers_PowerOfTen_ReturnsCorrectSum) {
    // Arrange: 1000 + 1 = 1001 (stored as 0->0->0->1 and 1)
    ListNode* l1 = CreateLinkedList({ 0, 0, 0, 1 });
    ListNode* l2 = CreateLinkedList({ 1 });

    // Act
    ListNode* result = solution.addTwoNumbers(l1, l2);

    // Assert: 1->0->0->1
    AssertLinkedListEquals({ 1, 0, 0, 1 }, result);

    // Cleanup
    FreeLinkedList(result);
}

TEST_F(AddTwoNumbers_2_Tests, AddTwoNumbers_ConsecutiveNumbers_ReturnsCorrectSum) {
    // Arrange: 12345 + 12346 = 24691 (stored reversed)
    ListNode* l1 = CreateLinkedList({ 5, 4, 3, 2, 1 });
    ListNode* l2 = CreateLinkedList({ 6, 4, 3, 2, 1 });

    // Act
    ListNode* result = solution.addTwoNumbers(l1, l2);

    // Assert: 1->9->6->4->2
    AssertLinkedListEquals({ 1, 9, 6, 4, 2 }, result);

    // Cleanup
    FreeLinkedList(result);
}

TEST_F(AddTwoNumbers_2_Tests, AddTwoNumbers_Palindrome_ReturnsCorrectSum) {
    // Arrange: 121 + 121 = 242 (stored as 1->2->1 and 1->2->1)
    ListNode* l1 = CreateLinkedList({ 1, 2, 1 });
    ListNode* l2 = CreateLinkedList({ 1, 2, 1 });

    // Act
    ListNode* result = solution.addTwoNumbers(l1, l2);

    // Assert: 2->4->2
    AssertLinkedListEquals({ 2, 4, 2 }, result);

    // Cleanup
    FreeLinkedList(result);
}

TEST_F(AddTwoNumbers_2_Tests, AddTwoNumbers_OneWithTrailingZeros_ReturnsCorrectSum) {
    // Arrange: 100 + 25 = 125 (stored as 0->0->1 and 5->2)
    ListNode* l1 = CreateLinkedList({ 0, 0, 1 });
    ListNode* l2 = CreateLinkedList({ 5, 2 });

    // Act
    ListNode* result = solution.addTwoNumbers(l1, l2);

    // Assert: 5->2->1
    AssertLinkedListEquals({ 5, 2, 1 }, result);

    // Cleanup
    FreeLinkedList(result);
}

TEST_F(AddTwoNumbers_2_Tests, AddTwoNumbers_IncreasingDigits_ReturnsCorrectSum) {
    // Arrange: 123 + 456 = 579 (stored as 3->2->1 and 6->5->4)
    ListNode* l1 = CreateLinkedList({ 3, 2, 1 });
    ListNode* l2 = CreateLinkedList({ 6, 5, 4 });

    // Act
    ListNode* result = solution.addTwoNumbers(l1, l2);

    // Assert: 9->7->5
    AssertLinkedListEquals({ 9, 7, 5 }, result);

    // Cleanup
    FreeLinkedList(result);
}

TEST_F(AddTwoNumbers_2_Tests, AddTwoNumbers_DecreasingDigits_ReturnsCorrectSum) {
    // Arrange: 321 + 654 = 975 (stored as 1->2->3 and 4->5->6)
    ListNode* l1 = CreateLinkedList({ 1, 2, 3 });
    ListNode* l2 = CreateLinkedList({ 4, 5, 6 });

    // Act
    ListNode* result = solution.addTwoNumbers(l1, l2);

    // Assert: 5->7->9
    AssertLinkedListEquals({ 5, 7, 9 }, result);

    // Cleanup
    FreeLinkedList(result);
}

#pragma endregion

#pragma region Multiple Carries

TEST_F(AddTwoNumbers_2_Tests, AddTwoNumbers_MultipleConsecutiveCarries_ReturnsCorrectSum) {
    // Arrange: 5999 + 1 = 6000 (stored as 9->9->9->5 and 1)
    ListNode* l1 = CreateLinkedList({ 9, 9, 9, 5 });
    ListNode* l2 = CreateLinkedList({ 1 });

    // Act
    ListNode* result = solution.addTwoNumbers(l1, l2);

    // Assert: 0->0->0->6
    AssertLinkedListEquals({ 0, 0, 0, 6 }, result);

    // Cleanup
    FreeLinkedList(result);
}

TEST_F(AddTwoNumbers_2_Tests, AddTwoNumbers_AlternatingCarries_ReturnsCorrectSum) {
    // Arrange: 5959 + 4141 = 10100 (stored as 9->5->9->5 and 1->4->1->4)
    ListNode* l1 = CreateLinkedList({ 9, 5, 9, 5 });
    ListNode* l2 = CreateLinkedList({ 1, 4, 1, 4 });

    // Act
    ListNode* result = solution.addTwoNumbers(l1, l2);

    // Assert: 0->0->1->0->1
    AssertLinkedListEquals({ 0, 0, 1, 0, 1 }, result);

    // Cleanup
    FreeLinkedList(result);
}

TEST_F(AddTwoNumbers_2_Tests, AddTwoNumbers_CarryChainReaction_ReturnsCorrectSum) {
    // Arrange: 199999 + 1 = 200000 (stored as 9->9->9->9->9->1 and 1)
    ListNode* l1 = CreateLinkedList({ 9, 9, 9, 9, 9, 1 });
    ListNode* l2 = CreateLinkedList({ 1 });

    // Act
    ListNode* result = solution.addTwoNumbers(l1, l2);

    // Assert: 0->0->0->0->0->2
    AssertLinkedListEquals({ 0, 0, 0, 0, 0, 2 }, result);

    // Cleanup
    FreeLinkedList(result);
}

#pragma endregion

#pragma region Special Sums

TEST_F(AddTwoNumbers_2_Tests, AddTwoNumbers_ResultAllSameDigit_ReturnsCorrectSum) {
    // Arrange: 111 + 111 = 222 (stored as 1->1->1 and 1->1->1)
    ListNode* l1 = CreateLinkedList({ 1, 1, 1 });
    ListNode* l2 = CreateLinkedList({ 1, 1, 1 });

    // Act
    ListNode* result = solution.addTwoNumbers(l1, l2);

    // Assert: 2->2->2
    AssertLinkedListEquals({ 2, 2, 2 }, result);

    // Cleanup
    FreeLinkedList(result);
}

TEST_F(AddTwoNumbers_2_Tests, AddTwoNumbers_OnePlusMaxSingleDigit_ReturnsCorrectSum) {
    // Arrange: 1 + 9 = 10
    ListNode* l1 = CreateLinkedList({ 1 });
    ListNode* l2 = CreateLinkedList({ 9 });

    // Act
    ListNode* result = solution.addTwoNumbers(l1, l2);

    // Assert: 0->1
    AssertLinkedListEquals({ 0, 1 }, result);

    // Cleanup
    FreeLinkedList(result);
}

TEST_F(AddTwoNumbers_2_Tests, AddTwoNumbers_SymmetricNumbers_ReturnsCorrectSum) {
    // Arrange: 1234 + 4321 = 5555 (stored as 4->3->2->1 and 1->2->3->4)
    ListNode* l1 = CreateLinkedList({ 4, 3, 2, 1 });
    ListNode* l2 = CreateLinkedList({ 1, 2, 3, 4 });

    // Act
    ListNode* result = solution.addTwoNumbers(l1, l2);

    // Assert: 5->5->5->5
    AssertLinkedListEquals({ 5, 5, 5, 5 }, result);

    // Cleanup
    FreeLinkedList(result);
}

#pragma endregion
