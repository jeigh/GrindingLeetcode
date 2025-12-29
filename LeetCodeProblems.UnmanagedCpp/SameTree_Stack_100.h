#include "TreeNode.h"
#include <stack>

// solved 2025-12-28
class SameTree_Stack_100 {
public:
    inline bool isSameTree(TreeNode* p, TreeNode* q) 
    {
        auto stack = std::stack<std::pair<TreeNode*, TreeNode*>>();
        stack.push(std::make_pair(p, q));

        while (!stack.empty()) {
            auto popped = stack.top();
            stack.pop();

            if (popped.first == nullptr && popped.second == nullptr) continue;
            if (popped.first == nullptr || popped.second == nullptr) return false;
            if (popped.first->val != popped.second->val) return false;

            stack.push(std::make_pair(popped.first->left, popped.second->left));
            stack.push(std::make_pair(popped.first->right, popped.second->right));
        }

        return true;
    }
};
