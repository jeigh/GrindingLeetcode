#pragma once

#include <vector>
#include "AbstractSubsets_78.h"

class Subsets_Recursive_78 : public AbstractSubsets_78 {
public:
    inline std::vector<std::vector<int>> subsets(std::vector<int>& nums) override {
        std::vector<std::vector<int>> result;
        std::vector<int> current;
        recurse(nums, 0, result, current);
        return result;
    }

private:
    inline void recurse(std::vector<int>& nums, int i, std::vector<std::vector<int>>& result, std::vector<int>& current) 
    {
        if (i >= nums.size()) 
        {
            result.push_back(current);
            return;
        }

        current.push_back(nums[i]);
        recurse(nums, i + 1, result, current);
        
        current.pop_back();
        recurse(nums, i + 1, result, current);
    }

};
