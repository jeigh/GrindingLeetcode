#include "gtest/gtest.h"
#include "Subsets_Recursive_78.h"
#include "Subsets_Iterative_78.h"
#include "Subsets_ForLoop_78.h"

#include <algorithm>
#include <vector>

// Normalizes a result for order-independent comparison:
// sorts each inner subset, then sorts the collection of subsets.
static std::vector<std::vector<int>> Normalize(std::vector<std::vector<int>> result) {
    for (auto& subset : result)
        std::sort(subset.begin(), subset.end());
    std::sort(result.begin(), result.end());
    return result;
}

// Test fixture for Subsets_Recursive_78
class Subsets_Recursive_78_Tests : public ::testing::Test {
protected:
    Subsets_Recursive_78 solution;
};

// Test fixture for Subsets_Iterative_78
class Subsets_Iterative_78_Tests : public ::testing::Test {
protected:
    Subsets_Iterative_78 solution;
};

// Test fixture for Subsets_ForLoop_78
class Subsets_ForLoop_78_Tests : public ::testing::Test {
protected:
    Subsets_ForLoop_78 solution;
};

#pragma region Recursive

// Input: nums = [1,2,3]
// Output: [[],[1],[2],[3],[1,2],[1,3],[2,3],[1,2,3]]
TEST_F(Subsets_Recursive_78_Tests, Subsets_Example1_ReturnsAllSubsets) {
    std::vector<int> nums = {1, 2, 3};
    std::vector<std::vector<int>> expected = {{}, {1}, {2}, {3}, {1, 2}, {1, 3}, {2, 3}, {1, 2, 3}};
    ASSERT_EQ(Normalize(expected), Normalize(solution.subsets(nums)));
}

// Input: nums = [0]
// Output: [[],[0]]
TEST_F(Subsets_Recursive_78_Tests, Subsets_Example2_ReturnsBothSubsets) {
    std::vector<int> nums = {0};
    std::vector<std::vector<int>> expected = {{}, {0}};
    ASSERT_EQ(Normalize(expected), Normalize(solution.subsets(nums)));
}

// nums = [1,2] -> [], [1], [2], [1,2]
TEST_F(Subsets_Recursive_78_Tests, Subsets_TwoElements_ReturnsFourSubsets) {
    std::vector<int> nums = {1, 2};
    std::vector<std::vector<int>> expected = {{}, {1}, {2}, {1, 2}};
    ASSERT_EQ(Normalize(expected), Normalize(solution.subsets(nums)));
}

// For n elements the power set always has exactly 2^n subsets.
TEST_F(Subsets_Recursive_78_Tests, Subsets_FourElements_Returns16Subsets) {
    std::vector<int> nums = {1, 2, 3, 4};
    ASSERT_EQ(16, (int)solution.subsets(nums).size());
}

// The empty subset must always be present.
TEST_F(Subsets_Recursive_78_Tests, Subsets_AlwaysContainsEmptySubset) {
    std::vector<int> nums = {5, 10, 15};
    auto result = solution.subsets(nums);
    bool containsEmpty = false;
    for (const auto& s : result)
        if (s.empty()) { containsEmpty = true; break; }
    ASSERT_TRUE(containsEmpty);
}

// No two subsets in the result should be identical.
TEST_F(Subsets_Recursive_78_Tests, Subsets_NoDuplicateSubsets) {
    std::vector<int> nums = {1, 2, 3};
    auto result = Normalize(solution.subsets(nums));
    auto copy = result;
    std::sort(copy.begin(), copy.end());
    auto last = std::unique(copy.begin(), copy.end());
    ASSERT_EQ(result.size(), (size_t)std::distance(copy.begin(), last));
}

#pragma endregion

#pragma region Iterative

TEST_F(Subsets_Iterative_78_Tests, Subsets_Example1_ReturnsAllSubsets) {
    std::vector<int> nums = {1, 2, 3};
    std::vector<std::vector<int>> expected = {{}, {1}, {2}, {3}, {1, 2}, {1, 3}, {2, 3}, {1, 2, 3}};
    ASSERT_EQ(Normalize(expected), Normalize(solution.subsets(nums)));
}

TEST_F(Subsets_Iterative_78_Tests, Subsets_Example2_ReturnsBothSubsets) {
    std::vector<int> nums = {0};
    std::vector<std::vector<int>> expected = {{}, {0}};
    ASSERT_EQ(Normalize(expected), Normalize(solution.subsets(nums)));
}

TEST_F(Subsets_Iterative_78_Tests, Subsets_TwoElements_ReturnsFourSubsets) {
    std::vector<int> nums = {1, 2};
    std::vector<std::vector<int>> expected = {{}, {1}, {2}, {1, 2}};
    ASSERT_EQ(Normalize(expected), Normalize(solution.subsets(nums)));
}

TEST_F(Subsets_Iterative_78_Tests, Subsets_FourElements_Returns16Subsets) {
    std::vector<int> nums = {1, 2, 3, 4};
    ASSERT_EQ(16, (int)solution.subsets(nums).size());
}

TEST_F(Subsets_Iterative_78_Tests, Subsets_AlwaysContainsEmptySubset) {
    std::vector<int> nums = {5, 10, 15};
    auto result = solution.subsets(nums);
    bool containsEmpty = false;
    for (const auto& s : result)
        if (s.empty()) { containsEmpty = true; break; }
    ASSERT_TRUE(containsEmpty);
}

TEST_F(Subsets_Iterative_78_Tests, Subsets_NoDuplicateSubsets) {
    std::vector<int> nums = {1, 2, 3};
    auto result = Normalize(solution.subsets(nums));
    auto copy = result;
    std::sort(copy.begin(), copy.end());
    auto last = std::unique(copy.begin(), copy.end());
    ASSERT_EQ(result.size(), (size_t)std::distance(copy.begin(), last));
}

#pragma endregion

#pragma region ForLoop

TEST_F(Subsets_ForLoop_78_Tests, Subsets_Example1_ReturnsAllSubsets) {
    std::vector<int> nums = {1, 2, 3};
    std::vector<std::vector<int>> expected = {{}, {1}, {2}, {3}, {1, 2}, {1, 3}, {2, 3}, {1, 2, 3}};
    ASSERT_EQ(Normalize(expected), Normalize(solution.subsets(nums)));
}

TEST_F(Subsets_ForLoop_78_Tests, Subsets_Example2_ReturnsBothSubsets) {
    std::vector<int> nums = {0};
    std::vector<std::vector<int>> expected = {{}, {0}};
    ASSERT_EQ(Normalize(expected), Normalize(solution.subsets(nums)));
}

TEST_F(Subsets_ForLoop_78_Tests, Subsets_TwoElements_ReturnsFourSubsets) {
    std::vector<int> nums = {1, 2};
    std::vector<std::vector<int>> expected = {{}, {1}, {2}, {1, 2}};
    ASSERT_EQ(Normalize(expected), Normalize(solution.subsets(nums)));
}

TEST_F(Subsets_ForLoop_78_Tests, Subsets_FourElements_Returns16Subsets) {
    std::vector<int> nums = {1, 2, 3, 4};
    ASSERT_EQ(16, (int)solution.subsets(nums).size());
}

TEST_F(Subsets_ForLoop_78_Tests, Subsets_AlwaysContainsEmptySubset) {
    std::vector<int> nums = {5, 10, 15};
    auto result = solution.subsets(nums);
    bool containsEmpty = false;
    for (const auto& s : result)
        if (s.empty()) { containsEmpty = true; break; }
    ASSERT_TRUE(containsEmpty);
}

TEST_F(Subsets_ForLoop_78_Tests, Subsets_NoDuplicateSubsets) {
    std::vector<int> nums = {1, 2, 3};
    auto result = Normalize(solution.subsets(nums));
    auto copy = result;
    std::sort(copy.begin(), copy.end());
    auto last = std::unique(copy.begin(), copy.end());
    ASSERT_EQ(result.size(), (size_t)std::distance(copy.begin(), last));
}

#pragma endregion
