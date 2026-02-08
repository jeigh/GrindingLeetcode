#pragma once

#include "AbstractConstructBinaryTreeFromPreorderAndInorder_105.h"
#include <unordered_map>

class ConstructBinaryTreeFromPreorderAndInorderTraversal_HashMap_105 : public AbstractConstructBinaryTreeFromPreorderAndInorder_105
{
    using index = long long;

public:
    inline TreeNode* buildTree(vector<int>& preorder, vector<int>& inorder) override
    {
        if (preorder.empty()) return nullptr;
        auto inorderIndices = CreateHashmap(inorder);
        index inLeft = 0;
        index inRight = inorder.size();
        index preIndex = 0;

        return BuildSubTree(preorder, inorderIndices, inLeft, inRight, preIndex);
    }

private:
    static inline TreeNode * BuildSubTree(
        vector<int>& preorder,
        std::unordered_map<int, index> inorderIndices,
        index inLeft,
        index inRight,
        index & preIndex)
    {
        if ( inLeft > inRight) return nullptr;
        if (preIndex >= preorder.size()) return nullptr;

        const int currentValue = preorder[preIndex++];
        const index inMid = inorderIndices[currentValue];

        index leftStart = inLeft;
        index leftEnd = inMid - 1;
        index rightStart = inMid + 1;
        index rightEnd = inRight;

        TreeNode * left = BuildSubTree(preorder, inorderIndices, leftStart, leftEnd, preIndex);
        TreeNode * right = BuildSubTree(preorder, inorderIndices, rightStart, rightEnd, preIndex);

        return new TreeNode(currentValue, left, right);
    }

    static inline std::unordered_map<int, index> CreateHashmap(const vector<int>& inorder)
    {
        auto returnable = std::unordered_map<int, index>();
        for (index i = 0; i < inorder.size(); i++) returnable[inorder[i]] = i;
        return returnable;
    }

};