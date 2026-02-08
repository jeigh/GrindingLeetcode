#pragma once

#include "AbstractBinaryTreePostOrderTraversal_145.h"
#include <stack>

// solved 2025-12-20
class BinaryTreePostOrderTraversal_TwoVisit_145 : public AbstractBinaryTreePostOrderTraversal_145 {
public:
    inline std::vector<int> postorderTraversal(TreeNode* root) override
    {
        std::vector<int> result;
        auto stack = std::stack<std::pair<TreeNode*, bool>>();
        stack.push(std::make_pair(root, false));

        while (stack.size() > 0)
        {
            auto popped = stack.top();
            stack.pop();

            if (popped.first == nullptr) continue;
            if (popped.second) result.push_back(popped.first->val);
            else
            {
                stack.push(std::make_pair(popped.first, true));
                stack.push(std::make_pair(popped.first->right, false));
                stack.push(std::make_pair(popped.first->left, false));
            }
        }

        return result;
    }
};
