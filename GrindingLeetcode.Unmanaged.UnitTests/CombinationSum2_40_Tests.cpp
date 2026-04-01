#include "gtest/gtest.h"
#include "CombinationSum2_Backtracking_40.h"
#include "CombinationSum2_BacktrackingHashmap_40.h"

#include <algorithm>
#include <vector>

// Normalizes results for order-independent comparison:
// sorts each inner combination, then sorts the collection of combinations.
static std::vector<std::vector<int>> Normalize(std::vector<std::vector<int>> result) {
    for (auto& combo : result)
        std::sort(combo.begin(), combo.end());
    std::sort(result.begin(), result.end());
    return result;
}

// Test fixture for CombinationSum2_Backtracking_40
class CombinationSum2_Backtracking_40_Tests : public ::testing::Test {
protected:
    CombinationSum2_Backtracking_40 solution;
};

// Test fixture for CombinationSum2_BacktrackingHashmap_40
class CombinationSum2_BacktrackingHashmap_40_Tests : public ::testing::Test {
protected:
    CombinationSum2_BacktrackingHashmap_40 solution;
};


#pragma region Backtracking

// Input: candidates = [10,1,2,7,6,1,5], target = 8
// Output: [[1,1,6],[1,2,5],[1,7],[2,6]]
TEST_F(CombinationSum2_Backtracking_40_Tests, Example1_ReturnsCorrectCombinations) {
    std::vector<int> candidates = {10, 1, 2, 7, 6, 1, 5};
    std::vector<std::vector<int>> expected = {{1, 1, 6}, {1, 2, 5}, {1, 7}, {2, 6}};
    ASSERT_EQ(Normalize(expected), Normalize(solution.combinationSum2(candidates, 8)));
}

// Input: candidates = [2,5,2,1,2], target = 5
// Output: [[1,2,2],[5]]
TEST_F(CombinationSum2_Backtracking_40_Tests, Example2_ReturnsCorrectCombinations) {
    std::vector<int> candidates = {2, 5, 2, 1, 2};
    std::vector<std::vector<int>> expected = {{1, 2, 2}, {5}};
    ASSERT_EQ(Normalize(expected), Normalize(solution.combinationSum2(candidates, 5)));
}

TEST_F(CombinationSum2_Backtracking_40_Tests, NoValidCombination_ReturnsEmpty) {
    std::vector<int> candidates = {5};
    ASSERT_TRUE(solution.combinationSum2(candidates, 3).empty());
}

TEST_F(CombinationSum2_Backtracking_40_Tests, SingleCandidateExactMatch_ReturnsSingleCombination) {
    std::vector<int> candidates = {7};
    std::vector<std::vector<int>> expected = {{7}};
    ASSERT_EQ(Normalize(expected), Normalize(solution.combinationSum2(candidates, 7)));
}

// [1,1,1], target = 2 -> [[1,1]] not three copies
TEST_F(CombinationSum2_Backtracking_40_Tests, NoDuplicateCombinations_WhenCandidatesHaveDuplicates) {
    std::vector<int> candidates = {1, 1, 1};
    std::vector<std::vector<int>> expected = {{1, 1}};
    ASSERT_EQ(Normalize(expected), Normalize(solution.combinationSum2(candidates, 2)));
}

// [1,2], target = 4 -> [] each element used once only
TEST_F(CombinationSum2_Backtracking_40_Tests, EachCandidateUsedOnlyOnce_ReturnsEmpty) {
    std::vector<int> candidates = {1, 2};
    ASSERT_TRUE(solution.combinationSum2(candidates, 4).empty());
}

#pragma endregion

#pragma region BacktrackingHashmap

TEST_F(CombinationSum2_BacktrackingHashmap_40_Tests, Example1_ReturnsCorrectCombinations) {
    std::vector<int> candidates = {10, 1, 2, 7, 6, 1, 5};
    std::vector<std::vector<int>> expected = {{1, 1, 6}, {1, 2, 5}, {1, 7}, {2, 6}};
    ASSERT_EQ(Normalize(expected), Normalize(solution.combinationSum2(candidates, 8)));
}

TEST_F(CombinationSum2_BacktrackingHashmap_40_Tests, Example2_ReturnsCorrectCombinations) {
    std::vector<int> candidates = {2, 5, 2, 1, 2};
    std::vector<std::vector<int>> expected = {{1, 2, 2}, {5}};
    ASSERT_EQ(Normalize(expected), Normalize(solution.combinationSum2(candidates, 5)));
}

TEST_F(CombinationSum2_BacktrackingHashmap_40_Tests, NoValidCombination_ReturnsEmpty) {
    std::vector<int> candidates = {5};
    ASSERT_TRUE(solution.combinationSum2(candidates, 3).empty());
}

TEST_F(CombinationSum2_BacktrackingHashmap_40_Tests, SingleCandidateExactMatch_ReturnsSingleCombination) {
    std::vector<int> candidates = {7};
    std::vector<std::vector<int>> expected = {{7}};
    ASSERT_EQ(Normalize(expected), Normalize(solution.combinationSum2(candidates, 7)));
}

TEST_F(CombinationSum2_BacktrackingHashmap_40_Tests, NoDuplicateCombinations_WhenCandidatesHaveDuplicates) {
    std::vector<int> candidates = {1, 1, 1};
    std::vector<std::vector<int>> expected = {{1, 1}};
    ASSERT_EQ(Normalize(expected), Normalize(solution.combinationSum2(candidates, 2)));
}

TEST_F(CombinationSum2_BacktrackingHashmap_40_Tests, EachCandidateUsedOnlyOnce_ReturnsEmpty) {
    std::vector<int> candidates = {1, 2};
    ASSERT_TRUE(solution.combinationSum2(candidates, 4).empty());
}

#pragma endregion


