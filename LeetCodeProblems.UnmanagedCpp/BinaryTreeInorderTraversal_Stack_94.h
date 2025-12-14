#pragma once

#include "TreeNode.h"
#include <stack>

class BinaryTreeInorderTraversal_Stack_94 : public BinaryTreeInorderTraversal_94 {
public:
    inline std::vector<int> inorderTraversal(TreeNode* root) override
    {
        std::vector<int> result;

        std::stack<TreeNode*> myStack;
        TreeNode* current = root;

        while (!myStack.empty() || current != nullptr) {
            while (current != nullptr) {
                myStack.push(current);
                current = current->left;
            }

            current = myStack.top();
            myStack.pop();

            result.push_back(current->val);

            current = current->right;
        }
        
        return result;
    }
};
