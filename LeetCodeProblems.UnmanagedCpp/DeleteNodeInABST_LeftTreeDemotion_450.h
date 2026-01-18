#pragma once

#include "DeleteNodeInABST_450.h"
#include <stack>
#include <algorithm>

class DeleteNodeInABST_LeftTreeDemotion_450 : public  DeleteNodeInABST_450 {
public:
    inline TreeNode* deleteNode(TreeNode* root, int k) {
        if (root == nullptr) return nullptr;

        if (k > root->val) {
            root->right = deleteNode(root->right, k);
            return root;
        }

        if (k < root->val) {
            root->left = deleteNode(root->left, k);
            return root;
        }

        if (root->left == nullptr) {
            auto returnable = root->right;
            delete root;
            return returnable;
        }

        if (root->right == nullptr) {
            auto returnable = root->left;
            delete root;
            return returnable;
        }

        auto leftTree = root->left;
        auto rightTree = root->right;
        delete root;

        auto attachPoint = rightTree;
        while (attachPoint->left != nullptr) {
            attachPoint = attachPoint->left;
        }

        attachPoint->left = leftTree;

        return rightTree;        
    }
};