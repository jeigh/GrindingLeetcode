#pragma once

#include "TreeNode.h"

class BinaryTreeInorderTraversal_Recursion_94 : public BinaryTreeInorderTraversal_94 {
public:
    inline std::vector<int> inorderTraversal(TreeNode* root) override
    {
        if (root == nullptr) return std::vector<int>();

        auto result1 = inorderTraversal(root->left);
        result1.push_back(root->val);
        auto result2 = inorderTraversal(root->right);

        result1.insert(result1.end(), result2.begin(), result2.end());

        return result1;
    }
};
