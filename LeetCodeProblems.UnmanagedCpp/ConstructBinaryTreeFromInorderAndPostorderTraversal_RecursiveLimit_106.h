#pragma once

#include "AbstractConstructBinaryTreeFromInorderAndPostorderTraversal_106.h"
#include <limits>

class ConstructBinaryTreeFromInorderAndPostorderTraversal_RecursiveLimit_106 : public AbstractConstructBinaryTreeFromInorderAndPostorderTraversal_106 {
private:
	using index = int;

public:
	inline TreeNode* buildTree(vector<int>& inorder, vector<int>& postorder) {
		index inIndex = inorder.size() - 1;
		index postIndex = postorder.size() - 1;
		long long limitValue = numeric_limits<long long>::max();

		return buildTree(inorder, postorder, limitValue, postIndex, inIndex);

	}

	inline TreeNode* buildTree(
		vector<int>& inorder, 
		vector<int>& postorder, 
		long long limitValue, 
		index & postIndex, 
		index & inIndex) {
		
		if (inIndex < 0) return nullptr;
		if (postIndex < 0) return nullptr;

		if (inorder[inIndex] == limitValue) {
			inIndex--;
			return nullptr;
		}


		int currentValue = postorder[postIndex--];

		TreeNode * right = buildTree(inorder, postorder, currentValue, postIndex, inIndex);
		TreeNode * left = buildTree(inorder, postorder, limitValue, postIndex, inIndex);

		return new TreeNode(currentValue, left, right);
	}
};