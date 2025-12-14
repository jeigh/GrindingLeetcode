#pragma once

#include <vector>

struct TreeNode
{
    int val;
    TreeNode* left;
    TreeNode* right;
    
    TreeNode() : val(0), left(nullptr), right(nullptr) {}
    explicit TreeNode(int x) : val(x), left(nullptr), right(nullptr) {}
    TreeNode(int x, TreeNode* left, TreeNode* right) : val(x), left(left), right(right) {}
};

// Base interface for Binary Tree Inorder Traversal implementations
class BinaryTreeInorderTraversal_94 {
public:
    virtual std::vector<int> inorderTraversal(TreeNode* root) = 0;
    virtual ~BinaryTreeInorderTraversal_94() = default;
};
