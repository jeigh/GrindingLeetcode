#pragma once

#include <vector>
#include "TreeNode.h"

// Base interface for Binary Tree Post-Order Traversal implementations
class AbstractBinaryTreePostOrderTraversal_145 {
public:
    virtual std::vector<int> postorderTraversal(TreeNode* root) = 0;
    virtual ~AbstractBinaryTreePostOrderTraversal_145() = default;
};
