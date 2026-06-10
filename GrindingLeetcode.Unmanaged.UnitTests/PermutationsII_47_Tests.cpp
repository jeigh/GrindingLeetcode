#include "gtest/gtest.h"
#include "PermutationsII_Backtracking_47.h"

#include <algorithm>
#include <vector>

// Sorts the outer collection for order-independent comparison.
// Inner permutation order is preserved — {1,2,1} and {1,1,2} are distinct.
static std::vector<std::vector<int>> NormalizePerms(std::vector<std::vector<int>> result) {
    std::sort(result.begin(), result.end());
    return result;
}

class PermutationsII_Backtracking_47_Tests : public ::testing::Test {
protected:
    PermutationsII_Backtracking_47 solution;
};

#pragma region LeetCode Examples

// Input: nums = [1,1,2]
// Output: [[1,1,2],[1,2,1],[2,1,1]]
TEST_F(PermutationsII_Backtracking_47_Tests, Permute_Example1_ReturnsUniquePermutations) {
    std::vector<int> nums = {1, 1, 2};
    std::vector<std::vector<int>> expected = {{1,1,2},{1,2,1},{2,1,1}};
    ASSERT_EQ(NormalizePerms(expected), NormalizePerms(solution.permute(nums)));
}

// Input: nums = [1,2,3] (no duplicates)
// Output: [[1,2,3],[1,3,2],[2,1,3],[2,3,1],[3,1,2],[3,2,1]]
TEST_F(PermutationsII_Backtracking_47_Tests, Permute_Example2_DistinctInputReturnsAllPermutations) {
    std::vector<int> nums = {1, 2, 3};
    std::vector<std::vector<int>> expected = {{1,2,3},{1,3,2},{2,1,3},{2,3,1},{3,1,2},{3,2,1}};
    ASSERT_EQ(NormalizePerms(expected), NormalizePerms(solution.permute(nums)));
}

#pragma endregion

#pragma region Edge Cases

// Input: nums = [1]
// Output: [[1]]
TEST_F(PermutationsII_Backtracking_47_Tests, Permute_SingleElement_ReturnsSinglePermutation) {
    std::vector<int> nums = {1};
    std::vector<std::vector<int>> expected = {{1}};
    ASSERT_EQ(NormalizePerms(expected), NormalizePerms(solution.permute(nums)));
}

// Input: nums = [2,2]
// Output: [[2,2]]
TEST_F(PermutationsII_Backtracking_47_Tests, Permute_TwoIdenticalElements_ReturnsSinglePermutation) {
    std::vector<int> nums = {2, 2};
    std::vector<std::vector<int>> expected = {{2, 2}};
    ASSERT_EQ(NormalizePerms(expected), NormalizePerms(solution.permute(nums)));
}

// Input: nums = [1,1,1]   (3!/3! = 1)
TEST_F(PermutationsII_Backtracking_47_Tests, Permute_AllSameThreeElements_ReturnsSinglePermutation) {
    std::vector<int> nums = {1, 1, 1};
    std::vector<std::vector<int>> expected = {{1, 1, 1}};
    ASSERT_EQ(NormalizePerms(expected), NormalizePerms(solution.permute(nums)));
}

// Input: nums = [5,5,5,5]   (4!/4! = 1)
TEST_F(PermutationsII_Backtracking_47_Tests, Permute_AllSameFourElements_ReturnsSinglePermutation) {
    std::vector<int> nums = {5, 5, 5, 5};
    ASSERT_EQ(1, (int)solution.permute(nums).size());
}

// Input: nums = [-1,-1,0]   (3!/2! = 3)
TEST_F(PermutationsII_Backtracking_47_Tests, Permute_NegativeNumbersWithDuplicates_ReturnsUniquePermutations) {
    std::vector<int> nums = {-1, -1, 0};
    std::vector<std::vector<int>> expected = {{-1,-1,0},{-1,0,-1},{0,-1,-1}};
    ASSERT_EQ(NormalizePerms(expected), NormalizePerms(solution.permute(nums)));
}

// Input: nums = [0,0,1]   (3!/2! = 3)
TEST_F(PermutationsII_Backtracking_47_Tests, Permute_ZerosWithDuplicate_ReturnsUniquePermutations) {
    std::vector<int> nums = {0, 0, 1};
    std::vector<std::vector<int>> expected = {{0,0,1},{0,1,0},{1,0,0}};
    ASSERT_EQ(NormalizePerms(expected), NormalizePerms(solution.permute(nums)));
}

// Input: nums = [1,1,2,2]   (4!/(2!*2!) = 6)
TEST_F(PermutationsII_Backtracking_47_Tests, Permute_TwoPairsOfDuplicates_ReturnsSixPermutations) {
    std::vector<int> nums = {1, 1, 2, 2};
    ASSERT_EQ(6, (int)solution.permute(nums).size());
}

// Input: nums = [1,1,2,3]   (4!/2! = 12)
TEST_F(PermutationsII_Backtracking_47_Tests, Permute_OneDuplicateInFourElements_ReturnsTwelvePermutations) {
    std::vector<int> nums = {1, 1, 2, 3};
    ASSERT_EQ(12, (int)solution.permute(nums).size());
}

// No two permutations in the result should be identical.
TEST_F(PermutationsII_Backtracking_47_Tests, Permute_NoDuplicatePermutations) {
    std::vector<int> nums = {1, 1, 2};
    auto result = solution.permute(nums);
    auto sorted = result;
    std::sort(sorted.begin(), sorted.end());
    auto last = std::unique(sorted.begin(), sorted.end());
    ASSERT_EQ(sorted.size(), (size_t)std::distance(sorted.begin(), last));
}

// No duplicate permutations for a larger input.
TEST_F(PermutationsII_Backtracking_47_Tests, Permute_NoDuplicatePermutations_LargerInput) {
    std::vector<int> nums = {1, 1, 2, 2};
    auto result = solution.permute(nums);
    auto sorted = result;
    std::sort(sorted.begin(), sorted.end());
    auto last = std::unique(sorted.begin(), sorted.end());
    ASSERT_EQ(sorted.size(), (size_t)std::distance(sorted.begin(), last));
}

// Every permutation must have the same length as the input.
TEST_F(PermutationsII_Backtracking_47_Tests, Permute_AllPermutationsHaveCorrectLength) {
    std::vector<int> nums = {1, 1, 2};
    auto result = solution.permute(nums);
    for (const auto& perm : result)
        ASSERT_EQ((int)nums.size(), (int)perm.size());
}

// Every permutation must contain exactly the same multiset of elements as the input.
TEST_F(PermutationsII_Backtracking_47_Tests, Permute_AllPermutationsContainAllOriginalElements) {
    std::vector<int> nums = {1, 1, 2};
    auto result = solution.permute(nums);
    auto sortedNums = nums;
    std::sort(sortedNums.begin(), sortedNums.end());
    for (auto& perm : result) {
        auto sortedPerm = perm;
        std::sort(sortedPerm.begin(), sortedPerm.end());
        ASSERT_EQ(sortedNums, sortedPerm);
    }
}

// [1,2,1] and [1,1,2] describe the same multiset — both should produce 3 unique permutations.
TEST_F(PermutationsII_Backtracking_47_Tests, Permute_InputOrderDoesNotAffectResult) {
    std::vector<int> numsA = {1, 2, 1};
    std::vector<int> numsB = {1, 1, 2};
    ASSERT_EQ(NormalizePerms(solution.permute(numsA)), NormalizePerms(solution.permute(numsB)));
}

#pragma endregion
