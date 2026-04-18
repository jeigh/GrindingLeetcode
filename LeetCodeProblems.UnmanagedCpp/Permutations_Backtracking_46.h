#pragma once

#include <vector>
#include "AbstractPermutations_46.h"

// time complexity: O(n * n!)
// space complexity: O(n)
class Permutations_Backtracking_46 : public AbstractPermutations_46 {
public:
    inline std::vector<std::vector<int>> permute(std::vector<int>& nums) override 
    {
        std::vector<std::vector<int>> result;
        std::vector<bool> pick(nums.size(), false);
        std::vector<int> currentList;

        backtrack(currentList, nums, pick, result);

        return result;
    }

    inline void backtrack(std::vector<int>& currentList, std::vector<int>& nums, std::vector<bool>& pick, std::vector<std::vector<int>>& result) 
    {
        if (currentList.size() == nums.size()) {
            result.push_back(currentList);
            return;
        }

        for(int i = 0; i < nums.size(); i++) {
            if (!pick[i]) {
                currentList.push_back(nums[i]);
                pick[i] = true;
                backtrack(currentList, nums, pick, result);
                currentList.pop_back();
                pick[i] = false;
            }
        }
    }
};
