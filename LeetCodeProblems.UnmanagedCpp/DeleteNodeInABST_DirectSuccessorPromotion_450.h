#pragma once

#include "AbstractDeleteNodeInABST_450.h"
#include <stack>
#include <algorithm>

class DeleteNodeInABST_DirectSuccessorPromotion_450 : public  AbstractDeleteNodeInABST_450 {
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
            auto temp = root->right;
            delete root;
            return temp;
        }

        if (root->right == nullptr) {
            auto temp = root->left;
            delete root;
            return temp;
        }

        auto leftTree = root->left;

        auto successor = DetachSuccessor(root);
        
        auto rightTree = root->right;

        successor->left = leftTree;
        successor->right = rightTree;
        
        delete root;

        return successor;
    }

private:
    inline TreeNode* DetachSuccessor(TreeNode* node) {
        if (node == nullptr) return nullptr;

        auto successor = node->right;
        auto parent = node;
        auto lastMovedRight = true;
        while (successor->left != nullptr) {
            parent = successor;
            successor = successor->left;
            lastMovedRight = false;
        }
        if (lastMovedRight)
            parent->right = successor->right;
        else
            parent->left = successor->right;

        return successor;
    }
};