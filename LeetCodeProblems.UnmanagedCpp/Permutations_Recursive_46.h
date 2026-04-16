#pragma once

#include <vector>
#include "AbstractPermutations_46.h"

// time complexity: O(n * n!)
// space complexity: O(n)
class Permutations_Recursive_46 : public AbstractPermutations_46 {
public:
    inline std::vector<std::vector<int>> permute(std::vector<int>& nums) override {
        std::vector<std::vector<int>> result;
        permute(nums, 0, result);
        return result;
    }

private:
    inline void permute(std::vector<int>& nums, int startIndex, std::vector<std::vector<int>>& result)
    {
        if (startIndex == nums.size()) {
            result.push_back(nums);  
            return;
        }

        for (int i = startIndex; i < (int)nums.size(); i++) {
            std::swap(nums[startIndex], nums[i]);   
            permute(nums, startIndex + 1, result);
            std::swap(nums[startIndex], nums[i]);   
        }
    }

};
