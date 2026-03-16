#pragma once

#include <vector>
#include "AbstractSubsetXORSum_1863.h"

class SubsetXORSum_Recursive_1863 : public AbstractSubsetXORSum_1863 {
public:
    int subsetXORSum(std::vector<int>& nums) override {
        return recurse(nums, 0, 0);
    }

private:
    int recurse(std::vector<int>& nums, int i, int total) {
        if (i >= nums.size()) return total;

        auto with = recurse(nums, i + 1, total ^ nums[i]);
        auto without = recurse(nums, i + 1, total);
        return with + without;
    }
};
