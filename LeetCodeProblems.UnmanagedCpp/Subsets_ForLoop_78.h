#pragma once

#include <vector>
#include "AbstractSubsets_78.h"

class Subsets_ForLoop_78 : public AbstractSubsets_78 {
public:
    std::vector<std::vector<int>> subsets(std::vector<int>& nums) override {
        std::vector<std::vector<int>> result;
        std::vector<int> seed;
        result.push_back(seed);

        for (int num : nums) 
        {
            auto initialResultSize = result.size();
            for (int i = 0; i < initialResultSize; i++)
            {
                auto subset = result[i];
                subset.push_back(num);
                result.push_back(subset);
            }
        }
        return result;
    }
};
