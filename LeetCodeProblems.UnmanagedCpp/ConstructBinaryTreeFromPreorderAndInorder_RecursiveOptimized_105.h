#pragma once

#include "AbstractConstructBinaryTreeFromPreorderAndInorder_105.h"
#include <limits>

class ConstructBinaryTreeFromPreorderAndInorder_RecursiveOptimized_105 : public AbstractConstructBinaryTreeFromPreorderAndInorder_105 {
private:
	using index = int;
	

public:
	inline TreeNode* buildTree(vector<int>& preorder, vector<int>& inorder) {
		index preorderIndex = index(0);
		index inorderIndex = index(0);

		return BuildSubTree(preorder, inorder, std::numeric_limits<long long>::max(), preorderIndex, inorderIndex);
    }

private:
	inline TreeNode* BuildSubTree(vector<int>& preorder, vector<int>& inorder, long long limitValue, index & preorderIndex, index & inorderIndex) {
		if (preorderIndex >= static_cast<int>(preorder.size())) return nullptr;
		if (inorderIndex >= static_cast<int>(inorder.size())) return nullptr;

		if (inorder[inorderIndex] == limitValue) {
			inorderIndex++;
			return nullptr;
		}
		auto currentValue = preorder[preorderIndex];
		preorderIndex++;

		TreeNode * left = BuildSubTree(preorder, inorder, currentValue, preorderIndex, inorderIndex);
		TreeNode * right = BuildSubTree(preorder, inorder, limitValue, preorderIndex, inorderIndex);

		return new TreeNode(currentValue, left, right);
	}


};