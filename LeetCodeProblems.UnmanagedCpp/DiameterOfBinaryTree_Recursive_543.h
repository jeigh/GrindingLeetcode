#pragma once

#include "AbstractDiameterOfBinaryTree_543.h"

class DiameterOfBinaryTree_Recursive_543 : public AbstractDiameterOfBinaryTree_543 {
private:
    inline int GetDepth(TreeNode* node, int& diameter)
    {
        if (node == nullptr) return 0;

        auto leftDepth = GetDepth(node->left, diameter);
        auto rightDepth = GetDepth(node->right, diameter);

        diameter = std::max(leftDepth + rightDepth, diameter);

        return 1 + std::max(leftDepth, rightDepth);
    }

public:
    inline int diameterOfBinaryTree(TreeNode* root) override
    {
        int maxDiameter = 0;
        auto depth = GetDepth(root, maxDiameter);
        return maxDiameter;
    }
};