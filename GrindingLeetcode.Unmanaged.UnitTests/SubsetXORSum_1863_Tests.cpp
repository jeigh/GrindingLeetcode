#include "gtest/gtest.h"
#include "SubsetXORSum_Recursive_1863.h"
#include "SubsetXORSum_Iterative_1863.h"

// Test fixture for SubsetXORSum_Recursive_1863
class SubsetXORSum_Recursive_1863_Tests : public ::testing::Test {
protected:
    SubsetXORSum_Recursive_1863 solution;
};

// Test fixture for SubsetXORSum_Iterative_1863
class SubsetXORSum_Iterative_1863_Tests : public ::testing::Test {
protected:
    SubsetXORSum_Iterative_1863 solution;
};

#pragma region LeetCode Examples - Recursive

// Input: nums = [1,3]
// Subsets: [] -> 0, [1] -> 1, [3] -> 3, [1,3] -> 2
// Sum = 6
TEST_F(SubsetXORSum_Recursive_1863_Tests, SubsetXORSum_Example1_Returns6) {
    std::vector<int> nums = { 1, 3 };
    ASSERT_EQ(6, solution.subsetXORSum(nums));
}

// Input: nums = [5,1,6]
// Sum = 28
TEST_F(SubsetXORSum_Recursive_1863_Tests, SubsetXORSum_Example2_Returns28) {
    std::vector<int> nums = { 5, 1, 6 };
    ASSERT_EQ(28, solution.subsetXORSum(nums));
}

// Input: nums = [3,4,5,6,7,8]
// Sum = 480
TEST_F(SubsetXORSum_Recursive_1863_Tests, SubsetXORSum_Example3_Returns480) {
    std::vector<int> nums = { 3, 4, 5, 6, 7, 8 };
    ASSERT_EQ(480, solution.subsetXORSum(nums));
}

// Single element: only two subsets [] -> 0 and [n] -> n, sum = n
TEST_F(SubsetXORSum_Recursive_1863_Tests, SubsetXORSum_SingleElement_ReturnsElement) {
    std::vector<int> nums = { 7 };
    ASSERT_EQ(7, solution.subsetXORSum(nums));
}

// All zeros: every subset XORs to 0
TEST_F(SubsetXORSum_Recursive_1863_Tests, SubsetXORSum_AllZeros_ReturnsZero) {
    std::vector<int> nums = { 0, 0, 0 };
    ASSERT_EQ(0, solution.subsetXORSum(nums));
}

// Two identical elements: [n,n] -> subsets [] 0, [n] n, [n] n, [n,n] 0 -> sum = 2n
TEST_F(SubsetXORSum_Recursive_1863_Tests, SubsetXORSum_TwoIdenticalElements_ReturnsDoubled) {
    std::vector<int> nums = { 4, 4 };
    ASSERT_EQ(8, solution.subsetXORSum(nums));
}

#pragma endregion

#pragma region LeetCode Examples - Iterative

TEST_F(SubsetXORSum_Iterative_1863_Tests, SubsetXORSum_Example1_Returns6) {
    std::vector<int> nums = { 1, 3 };
    ASSERT_EQ(6, solution.subsetXORSum(nums));
}

TEST_F(SubsetXORSum_Iterative_1863_Tests, SubsetXORSum_Example2_Returns28) {
    std::vector<int> nums = { 5, 1, 6 };
    ASSERT_EQ(28, solution.subsetXORSum(nums));
}

TEST_F(SubsetXORSum_Iterative_1863_Tests, SubsetXORSum_Example3_Returns480) {
    std::vector<int> nums = { 3, 4, 5, 6, 7, 8 };
    ASSERT_EQ(480, solution.subsetXORSum(nums));
}

TEST_F(SubsetXORSum_Iterative_1863_Tests, SubsetXORSum_SingleElement_ReturnsElement) {
    std::vector<int> nums = { 7 };
    ASSERT_EQ(7, solution.subsetXORSum(nums));
}

TEST_F(SubsetXORSum_Iterative_1863_Tests, SubsetXORSum_AllZeros_ReturnsZero) {
    std::vector<int> nums = { 0, 0, 0 };
    ASSERT_EQ(0, solution.subsetXORSum(nums));
}

TEST_F(SubsetXORSum_Iterative_1863_Tests, SubsetXORSum_TwoIdenticalElements_ReturnsDoubled) {
    std::vector<int> nums = { 4, 4 };
    ASSERT_EQ(8, solution.subsetXORSum(nums));
}

#pragma endregion