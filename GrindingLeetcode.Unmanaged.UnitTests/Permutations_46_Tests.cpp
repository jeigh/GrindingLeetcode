#include "gtest/gtest.h"
#include "Permutations_Backtracking_46.h"
#include "Permutations_Recursive_46.h"
#include "Permutations_Iterative_46.h"

#include <algorithm>
#include <vector>

// Normalizes results for order-independent comparison:
// sorts each inner permutation, then sorts the collection of permutations.
static std::vector<std::vector<int>> NormalizePerms(std::vector<std::vector<int>> result) {
    for (auto& perm : result)
        std::sort(perm.begin(), perm.end());
    std::sort(result.begin(), result.end());
    return result;
}

// Test fixture for Permutations_Backtracking_46
class Permutations_Backtracking_46_Tests : public ::testing::Test {
protected:
    Permutations_Backtracking_46 solution;
};

// Test fixture for Permutations_Recursive_46
class Permutations_Recursive_46_Tests : public ::testing::Test {
protected:
    Permutations_Recursive_46 solution;
};

// Test fixture for Permutations_Iterative_46
class Permutations_Iterative_46_Tests : public ::testing::Test {
protected:
    Permutations_Iterative_46 solution;
};

#pragma region Backtracking

// Input: nums = [1,2,3]
// Output: [[1,2,3],[1,3,2],[2,1,3],[2,3,1],[3,1,2],[3,2,1]]
TEST_F(Permutations_Backtracking_46_Tests, Permute_Example1_ReturnsAllPermutations) {
    std::vector<int> nums = {1, 2, 3};
    std::vector<std::vector<int>> expected = {{1,2,3},{1,3,2},{2,1,3},{2,3,1},{3,1,2},{3,2,1}};
    ASSERT_EQ(NormalizePerms(expected), NormalizePerms(solution.permute(nums)));
}

// Input: nums = [0,1]
// Output: [[0,1],[1,0]]
TEST_F(Permutations_Backtracking_46_Tests, Permute_Example2_ReturnsBothPermutations) {
    std::vector<int> nums = {0, 1};
    std::vector<std::vector<int>> expected = {{0, 1}, {1, 0}};
    ASSERT_EQ(NormalizePerms(expected), NormalizePerms(solution.permute(nums)));
}

// Input: nums = [1]
// Output: [[1]]
TEST_F(Permutations_Backtracking_46_Tests, Permute_Example3_SingleElement_ReturnsSelf) {
    std::vector<int> nums = {1};
    std::vector<std::vector<int>> expected = {{1}};
    ASSERT_EQ(NormalizePerms(expected), NormalizePerms(solution.permute(nums)));
}

// n=3 -> 3! = 6 permutations
TEST_F(Permutations_Backtracking_46_Tests, Permute_ThreeElements_Returns6Permutations) {
    std::vector<int> nums = {1, 2, 3};
    ASSERT_EQ(6, (int)solution.permute(nums).size());
}

// n=4 -> 4! = 24 permutations
TEST_F(Permutations_Backtracking_46_Tests, Permute_FourElements_Returns24Permutations) {
    std::vector<int> nums = {1, 2, 3, 4};
    ASSERT_EQ(24, (int)solution.permute(nums).size());
}

// Every permutation must contain all elements of the input exactly once.
TEST_F(Permutations_Backtracking_46_Tests, Permute_AllPermutationsContainAllElements) {
    std::vector<int> nums = {1, 2, 3};
    auto result = solution.permute(nums);
    auto sortedNums = nums;
    std::sort(sortedNums.begin(), sortedNums.end());
    for (auto& perm : result) {
        auto sortedPerm = perm;
        std::sort(sortedPerm.begin(), sortedPerm.end());
        ASSERT_EQ(sortedNums, sortedPerm);
    }
}

// No two permutations in the result should be identical.
TEST_F(Permutations_Backtracking_46_Tests, Permute_NoDuplicatePermutations) {
    std::vector<int> nums = {1, 2, 3};
    auto result = solution.permute(nums);
    std::sort(result.begin(), result.end());
    auto last = std::unique(result.begin(), result.end());
    ASSERT_EQ(result.size(), (size_t)std::distance(result.begin(), last));
}

// Negative numbers should be handled correctly.
TEST_F(Permutations_Backtracking_46_Tests, Permute_NegativeNumbers_ReturnsAllPermutations) {
    std::vector<int> nums = {-1, 0, 1};
    std::vector<std::vector<int>> expected = {{-1,0,1},{-1,1,0},{0,-1,1},{0,1,-1},{1,-1,0},{1,0,-1}};
    ASSERT_EQ(NormalizePerms(expected), NormalizePerms(solution.permute(nums)));
}

#pragma endregion

#pragma region Recursive

TEST_F(Permutations_Recursive_46_Tests, Permute_Example1_ReturnsAllPermutations) {
    std::vector<int> nums = {1, 2, 3};
    std::vector<std::vector<int>> expected = {{1,2,3},{1,3,2},{2,1,3},{2,3,1},{3,1,2},{3,2,1}};
    ASSERT_EQ(NormalizePerms(expected), NormalizePerms(solution.permute(nums)));
}

TEST_F(Permutations_Recursive_46_Tests, Permute_Example2_ReturnsBothPermutations) {
    std::vector<int> nums = {0, 1};
    std::vector<std::vector<int>> expected = {{0, 1}, {1, 0}};
    ASSERT_EQ(NormalizePerms(expected), NormalizePerms(solution.permute(nums)));
}

TEST_F(Permutations_Recursive_46_Tests, Permute_Example3_SingleElement_ReturnsSelf) {
    std::vector<int> nums = {1};
    std::vector<std::vector<int>> expected = {{1}};
    ASSERT_EQ(NormalizePerms(expected), NormalizePerms(solution.permute(nums)));
}

TEST_F(Permutations_Recursive_46_Tests, Permute_ThreeElements_Returns6Permutations) {
    std::vector<int> nums = {1, 2, 3};
    ASSERT_EQ(6, (int)solution.permute(nums).size());
}

TEST_F(Permutations_Recursive_46_Tests, Permute_FourElements_Returns24Permutations) {
    std::vector<int> nums = {1, 2, 3, 4};
    ASSERT_EQ(24, (int)solution.permute(nums).size());
}

TEST_F(Permutations_Recursive_46_Tests, Permute_AllPermutationsContainAllElements) {
    std::vector<int> nums = {1, 2, 3};
    auto result = solution.permute(nums);
    auto sortedNums = nums;
    std::sort(sortedNums.begin(), sortedNums.end());
    for (auto& perm : result) {
        auto sortedPerm = perm;
        std::sort(sortedPerm.begin(), sortedPerm.end());
        ASSERT_EQ(sortedNums, sortedPerm);
    }
}

TEST_F(Permutations_Recursive_46_Tests, Permute_NoDuplicatePermutations) {
    std::vector<int> nums = {1, 2, 3};
    auto result = solution.permute(nums);
    std::sort(result.begin(), result.end());
    auto last = std::unique(result.begin(), result.end());
    ASSERT_EQ(result.size(), (size_t)std::distance(result.begin(), last));
}

TEST_F(Permutations_Recursive_46_Tests, Permute_NegativeNumbers_ReturnsAllPermutations) {
    std::vector<int> nums = {-1, 0, 1};
    std::vector<std::vector<int>> expected = {{-1,0,1},{-1,1,0},{0,-1,1},{0,1,-1},{1,-1,0},{1,0,-1}};
    ASSERT_EQ(NormalizePerms(expected), NormalizePerms(solution.permute(nums)));
}

#pragma endregion

#pragma region Iterative

TEST_F(Permutations_Iterative_46_Tests, Permute_Example1_ReturnsAllPermutations) {
    std::vector<int> nums = {1, 2, 3};
    std::vector<std::vector<int>> expected = {{1,2,3},{1,3,2},{2,1,3},{2,3,1},{3,1,2},{3,2,1}};
    ASSERT_EQ(NormalizePerms(expected), NormalizePerms(solution.permute(nums)));
}

TEST_F(Permutations_Iterative_46_Tests, Permute_Example2_ReturnsBothPermutations) {
    std::vector<int> nums = {0, 1};
    std::vector<std::vector<int>> expected = {{0, 1}, {1, 0}};
    ASSERT_EQ(NormalizePerms(expected), NormalizePerms(solution.permute(nums)));
}

TEST_F(Permutations_Iterative_46_Tests, Permute_Example3_SingleElement_ReturnsSelf) {
    std::vector<int> nums = {1};
    std::vector<std::vector<int>> expected = {{1}};
    ASSERT_EQ(NormalizePerms(expected), NormalizePerms(solution.permute(nums)));
}

TEST_F(Permutations_Iterative_46_Tests, Permute_ThreeElements_Returns6Permutations) {
    std::vector<int> nums = {1, 2, 3};
    ASSERT_EQ(6, (int)solution.permute(nums).size());
}

TEST_F(Permutations_Iterative_46_Tests, Permute_FourElements_Returns24Permutations) {
    std::vector<int> nums = {1, 2, 3, 4};
    ASSERT_EQ(24, (int)solution.permute(nums).size());
}

TEST_F(Permutations_Iterative_46_Tests, Permute_AllPermutationsContainAllElements) {
    std::vector<int> nums = {1, 2, 3};
    auto result = solution.permute(nums);
    auto sortedNums = nums;
    std::sort(sortedNums.begin(), sortedNums.end());
    for (auto& perm : result) {
        auto sortedPerm = perm;
        std::sort(sortedPerm.begin(), sortedPerm.end());
        ASSERT_EQ(sortedNums, sortedPerm);
    }
}

TEST_F(Permutations_Iterative_46_Tests, Permute_NoDuplicatePermutations) {
    std::vector<int> nums = {1, 2, 3};
    auto result = solution.permute(nums);
    std::sort(result.begin(), result.end());
    auto last = std::unique(result.begin(), result.end());
    ASSERT_EQ(result.size(), (size_t)std::distance(result.begin(), last));
}

TEST_F(Permutations_Iterative_46_Tests, Permute_NegativeNumbers_ReturnsAllPermutations) {
    std::vector<int> nums = {-1, 0, 1};
    std::vector<std::vector<int>> expected = {{-1,0,1},{-1,1,0},{0,-1,1},{0,1,-1},{1,-1,0},{1,0,-1}};
    ASSERT_EQ(NormalizePerms(expected), NormalizePerms(solution.permute(nums)));
}

#pragma endregion
