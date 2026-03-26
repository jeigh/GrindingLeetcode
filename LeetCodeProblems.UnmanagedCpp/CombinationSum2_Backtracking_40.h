#pragma once

#include <vector>
#include <algorithm>
#include "AbstractCombinationSum2_40.h"

class CombinationSum2_Backtracking_40 : public AbstractCombinationSum2_40 {
public:
    inline std::vector<std::vector<int>> combinationSum2(std::vector<int>& candidates, int target) override {
        std::sort(candidates.begin(), candidates.end());

        std::vector<std::vector<int>> result;
        std::vector<int> currentList;
        backtrack(candidates, target, currentList, 0, 0, result);

        return result;
    }

private:
    inline void backtrack(
        std::vector<int>& candidates, 
        int target, 
        std::vector<int>& currentList, 
        int currentListSum, 
        int i, 
        std::vector<std::vector<int>>& result)
    {
        if (currentListSum == target) 
        {            
            result.push_back(currentList);
            return;
        }
        if (i >= candidates.size()) return;

        auto currentValue = candidates[i];
        currentList.push_back(currentValue);
        currentListSum += currentValue;
        backtrack(candidates, target, currentList, currentListSum, i + 1, result);
        currentListSum -= currentValue;
        currentList.pop_back();
        
        while (i + 1 < candidates.size() && candidates[i + 1] == currentValue) i += 1;

        backtrack(candidates, target, currentList, currentListSum, i + 1, result);
    }
};
