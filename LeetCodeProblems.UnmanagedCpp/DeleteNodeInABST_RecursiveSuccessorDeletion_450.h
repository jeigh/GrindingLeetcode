#pragma once

#include "DeleteNodeInABST_450.h"
#include <stack>
#include <algorithm>

class DeleteNodeInABST_RecursiveSuccessorDeletion_450 : public  DeleteNodeInABST_450 {
public:
    inline TreeNode* deleteNode(TreeNode* root, int k) {
        if (root == nullptr) return root;

        if (k > root->val) {
            root->right = deleteNode(root->right, k);
            return root;
        }

        if (k < root->val) {
            root->left = deleteNode(root->left, k);
            return root;
        }

        if (root->left == nullptr) 
        {
            auto temp = root->right;
            delete root;
            return temp;
        }

        if (root->right == nullptr)
        {
            auto temp = root->left;
            delete root;
            return temp;
        }

        auto current = root->right;
        while (current->left != nullptr) current = current->left;

        root->val = current->val;
        root->right = deleteNode(root->right, current->val);

        return root;
    }
};
