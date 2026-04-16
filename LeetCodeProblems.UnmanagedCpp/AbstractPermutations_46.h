#pragma once

#include <vector>

// LeetCode 46: Permutations
//
// Given an array nums of distinct integers, return all the possible
// permutations. You can return the answer in any order.
class AbstractPermutations_46 {
public:
    virtual std::vector<std::vector<int>> permute(std::vector<int>& nums) = 0;
    virtual ~AbstractPermutations_46() = default;
};
