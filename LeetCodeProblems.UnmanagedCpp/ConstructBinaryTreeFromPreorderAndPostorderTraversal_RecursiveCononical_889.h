#pragma once

#include "AbstractConstructBinaryTreeFromPreorderAndPostorderTraversal_889.h"
#include <unordered_map>

using index = int;

class HashmapCreator {
public:
	inline static unordered_map<int, index> createIndices(vector<int>& vec)
	{
		unordered_map<int, index> ret;
		for (index i = 0; i < vec.size(); i++) ret[vec[i]] = i;
		return ret;
	}
};

class ConstructBinaryTreeFromPreorderAndPostorderTraversal_RecursiveCononical_889 : public AbstractConstructBinaryTreeFromPreorderAndPostorderTraversal_889 {
	using index = int;
public:
	inline TreeNode* constructFromPrePost(vector<int>& preorder, vector<int>& postorder)
	{
		unordered_map<int, index> postIndices = HashmapCreator::createIndices(postorder);

		return buildTree(preorder, postIndices, 0, preorder.size(), 0, postorder.size());
	}

	inline TreeNode* buildTree(vector<int>& preorder, unordered_map<int, index> postIndices, index preStart, index preEnd, index postStart, index postEnd)
	{
		if (preStart >= preEnd) return nullptr;
		if (postStart >= postEnd) return nullptr;

		auto currentValue = preorder[preStart];
		auto node = new TreeNode(currentValue);
		auto preIndexOfLeft = preStart + 1;
		if (preIndexOfLeft == preEnd) return node;

		auto leftValue = preorder[preIndexOfLeft];
		auto postIndexOfLeft = postIndices[leftValue];
		auto leftSize = postIndexOfLeft - postStart + 1;

		index leftPreStart = preStart + 1;
		index leftPreEnd = preStart + leftSize + 1;
		index rightPreStart = preStart + leftSize + 1;
		index rightPreEnd = preEnd;

		index leftPostStart = postStart;
		index leftPostEnd = postIndexOfLeft + 1;
		index rightPostStart = postIndexOfLeft + 1;
		index rightPostEnd = postEnd;

		node->left = buildTree(preorder, postIndices, leftPreStart, leftPreEnd, leftPostStart, leftPostEnd);
		node->right = buildTree(preorder, postIndices, rightPreStart, rightPreEnd, rightPostStart, rightPostEnd);

		return node;
	}
};
