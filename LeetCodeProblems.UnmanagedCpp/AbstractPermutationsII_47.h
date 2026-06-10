#pragma once

#include <vector>

// LeetCode 47: Permutations II
//
// Given a collection of numbers, nums, that might contain duplicates,
// return all possible unique permutations in any order.
class AbstractPermutationsII_47 {
public:
    virtual std::vector<std::vector<int>> permute(std::vector<int>& nums) = 0;
    virtual ~AbstractPermutationsII_47() = default;
};
