#pragma once

#include <vector>
#include <stack>
#include <utility>
#include "AbstractSubsets_78.h"

class Subsets_Iterative_78 : public AbstractSubsets_78 {
public:
    inline std::vector<std::vector<int>> subsets(std::vector<int>& nums) override 
    {
        std::vector<std::vector<int>> response;
        std::vector<int> currentSubset;
        std::stack<std::pair<int, std::vector<int>>> stack;
        stack.push(std::make_pair(0, currentSubset));

        while (!stack.empty())
        {
            auto stack_frame = std::move(stack.top());  
            stack.pop();

            if (stack_frame.first >= (int)nums.size()) {
                response.push_back(std::move(stack_frame.second));
                continue;
            }

            std::vector<int> with = stack_frame.second;
            with.push_back(nums[stack_frame.first]);
            stack.push(std::make_pair(stack_frame.first + 1, std::move(with)));
            stack.push(std::make_pair(stack_frame.first + 1, std::move(stack_frame.second)));
        }

        return response;
    }
};
