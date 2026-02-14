#pragma once

#include "AbstractConstructBinaryTreeFromInorderAndPostorderTraversal_106.h"
#include <unordered_map>

class ConstructBinaryTreeFromInorderAndPostorderTraversal_RecursiveHashmap_106 : public AbstractConstructBinaryTreeFromInorderAndPostorderTraversal_106 {
private:
	using index = int;

public:
	inline TreeNode* buildTree(vector<int>& inorder, vector<int>& postorder) {
		auto inorderIndices = CreateIndices(inorder);
		index postIndex = postorder.size();
		index inStart = 0;
		index inEnd = inorder.size();

		return buildTree(postorder, inorderIndices, postIndex, inStart, inEnd);
	}

	inline TreeNode* buildTree(vector<int>& postorder, std::unordered_map<int, index> & inorderIndices, index & postIndex, index inStart, index inEnd) {
		if (inStart >= inEnd) return nullptr;
		if (postIndex < 1) return nullptr;

		auto currentValue = postorder[--postIndex];
		auto inIndex = inorderIndices[currentValue];
		
		auto right = buildTree(postorder, inorderIndices, postIndex, inIndex + 1, inEnd);
		auto left = buildTree(postorder, inorderIndices, postIndex, inStart, inIndex);

		return new TreeNode(currentValue, left, right);
	}

	inline std::unordered_map<int, index> CreateIndices(vector<int>& vec) {
		std::unordered_map<int, index> returnable;
		for (index i = 0; i < vec.size(); i++) returnable[vec[i]] = i;
		return returnable;
	}
};
