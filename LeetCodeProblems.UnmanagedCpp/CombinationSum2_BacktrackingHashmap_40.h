#pragma once

#include <vector>
#include <unordered_map>
#include "AbstractCombinationSum2_40.h"

class CombinationSum2_BacktrackingHashmap_40 : public AbstractCombinationSum2_40 {
public:
    inline std::vector<std::vector<int>> combinationSum2(std::vector<int>& candidates, int target) override 
    {
        std::vector<std::vector<int>> result;        
        std::vector<int> uniques;
        std::vector<int> currentList;
        std::unordered_map<int, int> hashMap;

        for (auto candidate : candidates) 
        {
            if (hashMap.contains(candidate)) hashMap[candidate] += 1;
            else 
            {
                uniques.push_back(candidate);
                hashMap[candidate] = 1;
            }
        }

        backtrack(uniques, target, currentList, hashMap, result, 0);

        return result;
    }

    inline void backtrack(std::vector<int>& uniques, int target, std::vector<int>& currentList, std::unordered_map<int, int>& counts, std::vector<std::vector<int>>& result, int i)
    {
        if (target == 0) 
        {
            result.push_back(currentList);
            return;
        }

        if (target < 0 || i >= uniques.size()) return;

        if (counts[uniques[i]] > 0) {
            currentList.push_back(uniques[i]);
            counts[uniques[i]] -= 1;
            backtrack(uniques, target - uniques[i], currentList, counts, result, i);
            counts[uniques[i]] += 1;
            currentList.pop_back();
        }
        
        backtrack(uniques, target, currentList, counts, result, i+1);
    }
};
