#pragma once

#include <vector>

// LeetCode 1863: Sum of All Subset XOR Totals
//
// Return the sum of XOR totals for every subset of nums.
// The XOR total of an array is the bitwise XOR of all its elements (0 if empty).
class AbstractSubsetXORSum_1863 {
public:
    virtual int subsetXORSum(std::vector<int>& nums) = 0;
    virtual ~AbstractSubsetXORSum_1863() = default;
};
