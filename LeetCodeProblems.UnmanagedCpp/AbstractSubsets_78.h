#pragma once

#include <vector>

// LeetCode 78: Subsets
//
// Given an integer array nums of unique elements, return all possible subsets
// (the power set). The solution set must not contain duplicate subsets.
class AbstractSubsets_78 {
public:
    virtual std::vector<std::vector<int>> subsets(std::vector<int>& nums) = 0;
    virtual ~AbstractSubsets_78() = default;
};
