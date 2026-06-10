#pragma once

#include <vector>
#include "AbstractPermutationsII_47.h"

class PermutationsII_Backtracking_47 : public AbstractPermutationsII_47 {
public:
    inline std::vector<std::vector<int>> permute(std::vector<int>& nums) override 
    {
        std::vector<int> currentList;
        std::vector<std::vector<int>> result;
    
        std::sort(nums.begin(), nums.end());
        std::vector<bool> pick(nums.size(), false);
        recurse(nums, currentList, result, pick);

        return result;
    }

private:
    

    inline void recurse(std::vector<int>& nums, std::vector<int>& currentList, std::vector<std::vector<int>>& result, std::vector<bool>& pick) {
        
        if (currentList.size() == nums.size()) {
            result.push_back(currentList);
            return;
        }

        for (int i = 0; i < nums.size(); i++) 
        {
            if (i > 0 && nums[i] == nums[i - 1] && !pick[i - 1]) continue;
            if (pick[i]) continue;

            currentList.push_back(nums[i]);
            pick[i] = true;
            recurse(nums, currentList, result, pick);
            pick[i] = false;
            currentList.pop_back();
        }

    }

};
