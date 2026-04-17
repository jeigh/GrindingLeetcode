#pragma once

#include <vector>
#include "AbstractPermutations_46.h"

// time complexity: O(n * n!)
// space complexity: O(n * n!)
class Permutations_Iterative_46 : public AbstractPermutations_46 {
public:
    inline std::vector<std::vector<int>> permute(std::vector<int>& nums) override {
        std::vector<std::vector<int>> result = {{}};

        for (int n : nums)
        {
            std::vector<std::vector<int>> next;
            for (const std::vector<int>& resultItem : result)
            {
                for (int i = 0; i <= (int)resultItem.size(); i++)
                {
                    auto copy = resultItem;
                    copy.insert(copy.begin() + i, n);
                    next.push_back(std::move(copy));
                }
            }
            result = std::move(next);
        }

        return result;
    }
};
