#pragma once

#include <vector>
#include <algorithm>
#include <numeric>
#include "AbstractCombinationSum2_40.h"

class CombinationSum2_Backtracking_40 : public AbstractCombinationSum2_40 {
public:
    inline std::vector<std::vector<int>> combinationSum2(std::vector<int>& candidates, int target) override {
        std::sort(candidates.begin(), candidates.end());

        std::vector<std::vector<int>> result;
        std::vector<int> currentList;

        recurse(candidates, target, 0, currentList, result);

        return result;
    }

private:
    inline void recurse(std::vector<int>& candidates, int target, int i, std::vector<int>& currentList, std::vector<std::vector<int>>& result) 
    {
        auto sum = std::reduce(candidates.begin(), candidates.end());
        if (sum == target) 
        {
            result.push_back(currentList);
            return;
        }
        if (sum > target || i > candidates.size()) return;

        currentList.push_back(candidates[i]);
        recurse(candidates, target, i + 1, currentList, result);
        currentList.pop_back();

        while (i + 1 < candidates.size() && candidates[i] == candidates[i + 1]) i++;

        recurse(candidates, target, i + 1, currentList, result);
    }
};
