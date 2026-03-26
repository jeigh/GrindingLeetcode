#pragma once

#include <vector>

// LeetCode 40: Combination Sum II
//
// Given a collection of candidate numbers and a target number, find all unique
// combinations in candidates where the candidate numbers sum to target.
// Each number in candidates may only be used once in the combination.
// The solution set must not contain duplicate combinations.
class AbstractCombinationSum2_40 {
public:
    virtual std::vector<std::vector<int>> combinationSum2(std::vector<int>& candidates, int target) = 0;
    virtual ~AbstractCombinationSum2_40() = default;
};
