#pragma once

#include "DiameterOfBinaryTree_543.h"
#include <stack>
#include <unordered_map>
#include <utility>

// solved 2025-12-23 
class DiameterOfBinaryTree_Stack_543 : public DiameterOfBinaryTree_543 {
public:
    inline int diameterOfBinaryTree(TreeNode* root) override
    {
        if (root == nullptr) return 0;
        // height = first
        // diameter = second
        auto hashMap = std::unordered_map<TreeNode*, std::pair<int, int>>();
        auto stack = std::stack < TreeNode*>();
        stack.push(root);

        while (!stack.empty()) 
        {
            auto peeked = stack.top();

            if (peeked->left != nullptr && !hashMap.contains(peeked->left)) stack.push(peeked->left);
            else if (peeked->right != nullptr && !hashMap.contains(peeked->right)) stack.push(peeked->right);
            else
            {
                stack.pop();

                int leftHeight = 0;
                int leftDiameter = 0;
                int rightHeight = 0;
                int rightDiameter = 0;

                if (hashMap.contains(peeked->left)) 
                {
                    auto left = hashMap[peeked->left];
                    leftHeight = left.first;
                    leftDiameter = left.second;
                }

                if (hashMap.contains(peeked->right))
                {
                    auto right = hashMap[peeked->right];
                    rightHeight = right.first;
                    rightDiameter = right.second;
                }

                int newHeight = 1 + std::max(leftHeight, rightHeight);
                int maxChildDiameter = std::max(leftDiameter, rightDiameter);
                int newDiameter = std::max(leftHeight + rightHeight, maxChildDiameter);

                hashMap[peeked] = std::make_pair(newHeight, newDiameter);
            }
        }

        return hashMap[root].second;
    }
};
