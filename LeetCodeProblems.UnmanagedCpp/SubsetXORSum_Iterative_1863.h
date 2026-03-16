#pragma once

#include <vector>
#include <stack>
#include <utility>
#include "AbstractSubsetXORSum_1863.h"

class SubsetXORSum_Iterative_1863 : public AbstractSubsetXORSum_1863 {
public:
    inline int subsetXORSum(std::vector<int>& nums) override {
        int result = 0;
        auto stack = std::stack<std::pair<int, int>>();
        stack.push(std::make_pair<int, int>(0, 0));

        while (!stack.empty())
        {
            auto popped = stack.top();
            stack.pop();

            if (popped.first >= nums.size()) {
                result += popped.second;
                continue;
            }

            stack.push(std::make_pair(popped.first + 1, popped.second ^ nums[popped.first]));
            stack.push(std::make_pair(popped.first + 1, popped.second));
        }

        return result;
    }
};
