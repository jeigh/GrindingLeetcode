#include "TreeNode.h"

class SubtreeOfAnotherTree_Recursive_572 {
private:
    inline bool isSameTree(TreeNode* p, TreeNode* q) {
        if (p == nullptr && q == nullptr) return true;
        if (p == nullptr || q == nullptr) return false;

        if (p->val != q->val) return false;
        if (isSameTree(p->left, q->left) && isSameTree(p->right, q->right)) return true;
    }


public:
    inline bool isSubtree(TreeNode* root, TreeNode* subRoot) 
    {
        if (subRoot == nullptr) return true;
        if (root == nullptr) return false;

        if (isSameTree(root, subRoot)) return true;
        if (isSubtree(root->left, subRoot) || isSubtree(root->right, subRoot)) return true;
        return false;
    }
};