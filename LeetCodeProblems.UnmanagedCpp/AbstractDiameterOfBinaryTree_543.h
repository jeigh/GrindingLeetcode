#pragma once

#include "TreeNode.h"

// Base interface for Diameter of Binary Tree implementations
class AbstractDiameterOfBinaryTree_543 {
public:
    virtual int diameterOfBinaryTree(TreeNode* root) = 0;
    virtual ~AbstractDiameterOfBinaryTree_543() = default;
};
