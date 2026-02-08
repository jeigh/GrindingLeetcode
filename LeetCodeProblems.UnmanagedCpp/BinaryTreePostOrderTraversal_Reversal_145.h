#pragma once

#include "AbstractBinaryTreePostOrderTraversal_145.h"
#include <stack>
#include <algorithm>

// solved 2025-12-20
class BinaryTreePostOrderTraversal_Reversal_145 : public AbstractBinaryTreePostOrderTraversal_145 {
public:
    inline std::vector<int> postorderTraversal(TreeNode* root) override
    {
        std::vector<int> result;
        auto stack = std::stack<TreeNode*>();
        auto currentNode = root;
        while (stack.size() > 0 || currentNode != nullptr)
        {
            while (currentNode != nullptr) 
            {
                result.push_back(currentNode->val);
                stack.push(currentNode);
                currentNode = currentNode->right;
            }

            currentNode = stack.top()->left;
            stack.pop();
        }          
        
        std::reverse(result.begin(), result.end());
        return result;
    }
};
